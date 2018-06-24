'********************************************************************************************************
'File Name: clsLayers.vb
'Description: Public class on the plugin interface for managing layers.    
'********************************************************************************************************
'The contents of this file are subject to the Mozilla Public License Version 1.1 (the "License"); 
'you may not use this file except in compliance with the License. You may obtain a copy of the License at 
'http://www.mozilla.org/MPL/ 
'Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF 
'ANY KIND, either express or implied. See the License for the specificlanguage governing rights and 
'limitations under the License. 
'
'The Original Code is MapWindow Open Source. 
'
'The Initial Developer of this version of the Original Code is Daniel P. Ames using portions created by 
'Utah State University and the Idaho National Engineering and Environmental Lab that were released as 
'public domain in March 2004.  
'
'Contributor(s): (Open source contributors should list themselves and their modifications here). 
'1/31/2005 - No change from the public domain version. 
'4/23/2005 - dpa - modified remove layer and add layer functions to not lock images after removed.  
'6/30/2005 - cdm - Corrected a small problem where LineOrPointSize wasn't being set.
'7/2/2005 - cdm - Added CheckWriteTimes test to AddLayer to optimize grid loading by not rebuilding the grid image every time if unnecessary.
'3/24/2008 - dpa - Modified error associted with corrupt shapefiles to include the problem shapefile name.
'********************************************************************************************************

Option Strict Off

Imports System.drawing

Public Class Layers
    Implements Interfaces.Layers
    Implements MapWinGIS.ICallback
    Implements IEnumerable

    Private m_PluginCall As Boolean = False

    Friend m_Grids As New Hashtable()

    Friend Class LayerEnumerator
        Implements System.Collections.IEnumerator

        Private m_Lyrs As MapWindow.Interfaces.Layers
        Private m_Idx As Integer = -1

        Public Sub New(ByVal lyrs As MapWindow.Layers)
            m_Lyrs = lyrs
            m_Idx = -1
        End Sub

        Public Sub Reset() Implements IEnumerator.Reset
            m_Idx = -1
        End Sub

        Public ReadOnly Property Current() As Object Implements IEnumerator.Current
            Get
                Return m_Lyrs.Item(m_Lyrs.GetHandle(m_Idx))
            End Get
        End Property

        Public Function MoveNext() As Boolean Implements IEnumerator.MoveNext
            m_Idx += 1

            If m_Idx >= m_Lyrs.NumLayers Then
                Return False
            Else
                Return True
            End If
        End Function
    End Class

    Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
        Return New LayerEnumerator(Me)
    End Function

    Friend Class LoadedGrid
        Public GridColorScheme As MapWinGIS.GridColorScheme
        Public GridObject As MapWinGIS.Grid

        Public Sub New()
            GridColorScheme = Nothing
            GridObject = Nothing
        End Sub

        Public Sub New(ByVal ColorScheme As MapWinGIS.GridColorScheme, ByVal [Object] As MapWinGIS.Grid)
            GridColorScheme = ColorScheme
            GridObject = [Object]
        End Sub

        Protected Overrides Sub Finalize()
            If Not GridColorScheme Is Nothing Then
                GridColorScheme = Nothing
            End If
            If Not GridObject Is Nothing Then
                GridObject.Close()
                GridObject = Nothing
            End If
            MyBase.Finalize()
        End Sub
    End Class

    Public Sub New()
        Randomize()
    End Sub

    Protected Overrides Sub Finalize()
        'Clear()
    End Sub

    '--------------------------------------Layers Private Sub/Function/Event--------------------------------------
    '23 Aug 2001  Darrel Brown.
    '---------------------------------------------------------------------------------------------------------------
    Private Function MakeRandomColor() As Integer
        Return RGB(CInt(Rnd() * 255), CInt(Rnd() * 255), CInt(Rnd() * 255))
    End Function

    '--------------------------------------Layers Public Interface--------------------------------------
    '23 Aug 2001  Darrel Brown.  Refer to Document "MapWindow 2.0 Public Interface" Page 1
    '-----------------------------------------------------------------------------------------------------
    '-------------------Subs-------------------
    Public Sub Clear() Implements Interfaces.Layers.Clear
        Try
            Dim i As Integer
            For i = 0 To frmMain.MapMain.NumLayers - 1
                With Item(Me.GetHandle(i))
                    Select Case .LayerType
                        Case Interfaces.eLayerType.Grid
                            Try
                                If Not .GetGridObject Is Nothing Then
                                    CType(.GetGridObject, MapWinGIS.Grid).Close()
                                End If
                            Catch
                            End Try

                            'Chris Michaelis Aug 10 2006 -- Also close the image behind
                            'the grid, to avoid locking it until app ends
                            Dim o As MapWinGIS.Image
                            o = CType(frmMain.MapMain.get_GetObject(Me.GetHandle(i)), MapWinGIS.Image)
                            If Not o Is Nothing Then o.Close()
                            o = Nothing
                        Case Interfaces.eLayerType.Image
                            CType(.GetObject, MapWinGIS.Image).Close()
                        Case Interfaces.eLayerType.Invalid
                            Exit Select
                        Case Else
                            CType(.GetObject, MapWinGIS.Shapefile).Close()
                    End Select
                End With
            Next
            frmMain.Legend.Layers.Clear()
            frmMain.Legend.Groups.Clear()
            m_Grids.Clear()
            If Not frmMain.m_PluginManager Is Nothing Then
                frmMain.m_PluginManager.LayersCleared()
            End If
            frmMain.m_AutoVis.Clear()

            'No layers - no need to keep the project projection.
            modMain.ProjInfo.ProjectProjection = ""

        Catch ex As Exception
            g_error = ex.Message
            ShowError(ex)
            ' if anything happens I must be shutting down and ptrs are no longer valid
        End Try
    End Sub

    Public Sub MoveLayer(ByVal Handle As Integer, ByVal NewPosition As Integer, ByVal TargetGroup As Integer) Implements Interfaces.Layers.MoveLayer

        If TargetGroup = -1 Then
            frmMain.Legend.Layers.MoveLayerWithinGroup(Handle, NewPosition)
        Else
            frmMain.Legend.Layers.MoveLayer(Handle, TargetGroup, NewPosition)
        End If

    End Sub

    Public Sub Remove(ByVal LayerHandle As Integer) Implements Interfaces.Layers.Remove
        'Removes a layer from the map
        'dpa 4/25/2005 modified to close the associated object.
        If LayerHandle >= 0 AndAlso frmMain.MapMain.get_LayerPosition(LayerHandle) >= 0 Then
            'Close the object associated with the layer we are removing.
            With Item(LayerHandle)
                Select Case .LayerType
                    Case Interfaces.eLayerType.Grid
                        Try
                            CType(.GetGridObject, MapWinGIS.Grid).Close()
                        Catch
                        End Try

                        'Chris Michaelis Aug 10 2006 -- Also close the image behind
                        'the grid, to avoid locking it until app ends
                        Dim o As MapWinGIS.Image
                        o = CType(frmMain.MapMain.get_GetObject(LayerHandle), MapWinGIS.Image)
                        If Not o Is Nothing Then o.Close()
                        o = Nothing
                    Case Interfaces.eLayerType.Image
                        CType(.GetObject, MapWinGIS.Image).Close()
                    Case Interfaces.eLayerType.Invalid
                        Exit Select
                    Case Else
                        CType(.GetObject, MapWinGIS.Shapefile).Close()
                End Select
            End With
            frmMain.Legend.Layers.Remove(LayerHandle)
            frmMain.m_PluginManager.LayerRemoved(LayerHandle)
            frmMain.UpdateZoomButtons()
            If Not frmMain.m_AutoVis(LayerHandle) Is Nothing Then
                frmMain.m_AutoVis.Remove(LayerHandle)
            End If
        End If
    End Sub

    '-------------------Functions-------------------
    Public Shared Function GetDefaultLayerVis()
        Dim Grp As Integer = -1
        If frmMain.Legend.SelectedLayer <> -1 Then
            Grp = frmMain.Legend.Layers.GroupOf(frmMain.m_layers.CurrentLayer)
        ElseIf frmMain.Legend.Groups.Count > 0 Then
            Grp = 0
        End If

        If Grp = -1 Then Return True
        Dim oGrp As LegendControl.Group = frmMain.Legend.Groups.ItemByHandle(Grp)
        If oGrp Is Nothing Then Return True
        Return oGrp.LayersVisible()
    End Function

    <CLSCompliant(False)> _
    Public Function Add(ByVal Filename As String) As MapWindow.Interfaces.Layer Implements MapWindow.Interfaces.Layers.Add
        m_PluginCall = True
        Dim b As MapWindow.Interfaces.Layer = AddLayer(Filename, "", -1, GetDefaultLayerVis)(0)
        m_PluginCall = False
        Return b
    End Function

    <CLSCompliant(False)> _
    Public Function Add(ByVal Filename As String, ByVal Layername As String, ByVal Visible As Boolean, ByVal PlaceAboveSelected As Boolean) As MapWindow.Interfaces.Layer Implements Interfaces.Layers.Add
        m_PluginCall = True
        Dim b As MapWindow.Interfaces.Layer = AddLayer(Filename, Layername, , Visible, , , , , , , , PlaceAboveSelected)(0)
        m_PluginCall = False
        Return b
    End Function

    <CLSCompliant(False)> _
    Public Function Add(ByVal Filename As String, ByVal LayerName As String) As MapWindow.Interfaces.Layer Implements MapWindow.Interfaces.Layers.Add
        m_PluginCall = True
        Dim b As MapWindow.Interfaces.Layer = AddLayer(Filename, LayerName, -1, GetDefaultLayerVis)(0)
        m_PluginCall = False
        Return b
    End Function

    <CLSCompliant(False)> _
    Public Function Add(ByVal Filename As String, ByVal LayerName As String, ByVal LegendVisible As Boolean) As MapWindow.Interfaces.Layer Implements MapWindow.Interfaces.Layers.Add
        m_PluginCall = True
        Dim b As MapWindow.Interfaces.Layer = AddLayer(Filename, LayerName, -1, GetDefaultLayerVis, -1, -1, True, 1.0, 0, Nothing, LegendVisible)(0)
        m_PluginCall = False
        Return b
    End Function

    <CLSCompliant(False)> _
    Public Function Add(ByRef ImageObject As MapWinGIS.Image) As MapWindow.Interfaces.Layer Implements MapWindow.Interfaces.Layers.Add
        m_PluginCall = True
        Dim b As MapWindow.Interfaces.Layer = AddLayer(ImageObject, , , GetDefaultLayerVis)(0)
        m_PluginCall = False
        Return b
    End Function

    <CLSCompliant(False)> _
    Public Function Add(ByRef Image As MapWinGIS.Image, ByVal LayerName As String) As MapWindow.Interfaces.Layer Implements MapWindow.Interfaces.Layers.Add
        m_PluginCall = True
        Dim b As MapWindow.Interfaces.Layer = AddLayer(Image, LayerName, , GetDefaultLayerVis)(0)
        m_PluginCall = False
        Return b
    End Function

    <CLSCompliant(False)> _
    Public Function Add(ByRef Shapefile As MapWinGIS.Shapefile) As MapWindow.Interfaces.Layer Implements MapWindow.Interfaces.Layers.Add
        m_PluginCall = True
        Dim b As MapWindow.Interfaces.Layer = AddLayer(Shapefile, , , GetDefaultLayerVis)(0)
        m_PluginCall = False
        Return b
    End Function

    <CLSCompliant(False)> _
    Public Function Add(ByRef Shapefile As MapWinGIS.Shapefile, ByVal LayerName As String) As MapWindow.Interfaces.Layer Implements MapWindow.Interfaces.Layers.Add
        m_PluginCall = True
        Dim b As MapWindow.Interfaces.Layer = AddLayer(Shapefile, LayerName, , GetDefaultLayerVis)(0)
        m_PluginCall = False
        Return b
    End Function

    <CLSCompliant(False)> _
    Public Function Add(ByRef GridObject As MapWinGIS.Grid) As MapWindow.Interfaces.Layer Implements MapWindow.Interfaces.Layers.Add
        m_PluginCall = True
        Dim b As MapWindow.Interfaces.Layer = AddLayer(GridObject, , , GetDefaultLayerVis)(0)
        m_PluginCall = False
        Return b
    End Function

    <CLSCompliant(False)> _
    Public Function Add(ByRef GridObject As MapWinGIS.Grid, ByVal LayerName As String) As MapWindow.Interfaces.Layer Implements MapWindow.Interfaces.Layers.Add
        m_PluginCall = True
        Dim b As MapWindow.Interfaces.Layer = AddLayer(GridObject, LayerName, , GetDefaultLayerVis)(0)
        m_PluginCall = False
        Return b
    End Function

    <CLSCompliant(False)> _
    Public Function Add(ByRef GridObject As MapWinGIS.Grid, ByVal ColorScheme As MapWinGIS.GridColorScheme) As MapWindow.Interfaces.Layer Implements MapWindow.Interfaces.Layers.Add
        m_PluginCall = True
        Dim b As MapWindow.Interfaces.Layer = AddLayer(GridObject, , , GetDefaultLayerVis, , , , , , ColorScheme)(0)
        m_PluginCall = False
        Return b
    End Function

    <CLSCompliant(False)> _
    Public Function Add(ByRef GridObject As MapWinGIS.Grid, ByVal ColorScheme As MapWinGIS.GridColorScheme, ByVal LayerName As String) As MapWindow.Interfaces.Layer Implements MapWindow.Interfaces.Layers.Add
        m_PluginCall = True
        Dim b As MapWindow.Interfaces.Layer = AddLayer(GridObject, LayerName, , GetDefaultLayerVis, , , , , , ColorScheme)(0)
        m_PluginCall = False
        Return b
    End Function

    <CLSCompliant(False)> _
    Public Function Add() As MapWindow.Interfaces.Layer() Implements MapWindow.Interfaces.Layers.Add
        m_PluginCall = True
        Dim retval As MapWindow.Interfaces.Layer()
        Dim b As Object = AddLayer(, , , GetDefaultLayerVis)
        If TypeOf (b) Is MapWindow.Interfaces.Layer() Then
            'Great
            retval = b
        Else
            Dim newret(0) As MapWindow.Interfaces.Layer
            newret(0) = CType(b, MapWindow.Interfaces.Layer)
            retval = newret
        End If

        m_PluginCall = False
        Return retval
    End Function

    Public Function GetSupportedFormats() As String
        'build the new common dialog filter from what is available
        Dim GridUtil As New GridUtils, sf As New MapWinGIS.Shapefile, img As New MapWinGIS.Image
        Dim vArr() As String, allNames As New ArrayList, allVals As New ArrayList
        Dim i As Integer

        vArr = Split(sf.CdlgFilter, "|")

        On Error Resume Next
        For i = 0 To UBound(vArr) Step 2
            If LCase(Left(vArr(i), Len("all supported"))) <> "all supported" And Not allVals.Contains(vArr(i + 1)) And Not allNames.Contains(vArr(i)) Then
                allNames.Add(vArr(i)) ' value
                allVals.Add(vArr(i + 1)) ' key
            End If
        Next i

        vArr = Split(GridUtil.GridCdlgFilter, "|")
        GridUtil = Nothing

        On Error Resume Next
        For i = 0 To UBound(vArr) Step 2
            If LCase(Left(vArr(i), Len("all supported"))) <> "all supported" And Not allVals.Contains(vArr(i + 1)) And Not allNames.Contains(vArr(i)) Then
                allNames.Add(vArr(i)) ' value
                allVals.Add(vArr(i + 1)) ' key
            End If
        Next i

        vArr = Split(img.CdlgFilter, "|")

        For i = 0 To UBound(vArr) Step 2
            If LCase(Left(vArr(i), Len("all supported"))) <> "all supported" And Not allVals.Contains(vArr(i + 1)) And Not allNames.Contains(vArr(i)) Then
                If Left(vArr(i), Len("MRSID")) <> "MrSID" Then 'Fix the dumplicate SID problem. Laiin Chen 2006/4/7
                    allNames.Add(vArr(i))
                    allVals.Add(vArr(i + 1))
                End If
            End If
        Next i

        allNames.Add("Windows Metafile (*.wmf)")
        allVals.Add("*.WMF")

        Dim keys() As Object
        keys = allVals.ToArray()

        Dim allExtensions As String = ""
        Dim allTypes As String = ""

        For i = 0 To UBound(keys)
            If Len(allExtensions) = 0 Then
                If Right(CStr(keys(i)), 1) = ";" Then
                    allExtensions = Trim(Left(keys(i).ToString, Len(keys(i)) - 1))
                Else
                    allExtensions = Trim(keys(i).ToString)
                End If
            Else
                If Right(keys(i).ToString, 1) = ";" Then
                    allExtensions &= ";" & Trim(Left(keys(i).ToString, Len(keys(i)) - 1))
                Else
                    allExtensions &= ";" & Trim(keys(i).ToString)
                End If
            End If

            If Len(allTypes) = 0 Then
                allTypes = allNames(allVals.IndexOf(keys(i))).ToString & "|" & Trim(keys(i).ToString)
            Else
                allTypes &= "|" & Trim(allNames(allVals.IndexOf(keys(i))).ToString) & "|" & Trim(keys(i).ToString)
            End If
        Next i

        Return "All supported formats|" & allExtensions & "|" & allTypes
    End Function

    Private Sub TryCloseObject(ByVal newObject As Object)
        Try
            If Not newObject Is Nothing Then
                If TypeOf (newObject) Is MapWinGIS.Grid Then
                    CType(newObject, MapWinGIS.Grid).Close()
                ElseIf TypeOf (newObject) Is MapWinGIS.Shapefile Then
                    CType(newObject, MapWinGIS.Shapefile).Close()
                ElseIf TypeOf (newObject) Is MapWinGIS.Image Then
                    CType(newObject, MapWinGIS.Image).Close()
                End If
            End If
        Catch
        End Try
    End Sub

    Friend Function AddLayer(Optional ByVal ObjectOrFilename As Object = "", Optional ByVal LayerName As String = "", Optional ByVal Group As Integer = -1, _
            Optional ByVal LayerVisible As Boolean = True, Optional ByVal Color As Integer = -1, _
            Optional ByVal OutlineColor As Integer = -1, Optional ByVal DrawFill As Boolean = True, _
            Optional ByVal LineOrPointSize As Single = 1, Optional ByVal PointType As MapWinGIS.tkPointType = 0, _
            Optional ByVal GrdColorScheme As MapWinGIS.GridColorScheme = Nothing, Optional ByVal LegendVisible As Boolean = True, _
            Optional ByVal PositionFromSelected As Boolean = False) As Interfaces.Layer()
        Dim retVal As Layer() = Nothing

        Dim InitialNumLayers As Integer = frmMain.MapMain.NumLayers

        Static addList() As String
        Static addCnt As Integer
        Static newLayers As ArrayList

        If frmMain.MapMain.NumLayers = 0 Then
            ' make sure there are no old extent history items left in the mapwindow
            frmMain.m_Extents.Clear()
            frmMain.m_CurrentExtent = -1
        End If

        Dim newLyr As New MapWindow.Layer
        Dim newObject As Object = Nothing
        Dim NewPos As Integer
        Dim lyrFilename As String = ""
        Dim lyrName As String, mapHandle As Integer
        Dim newGrid As MapWinGIS.Grid
        Dim newImage As New MapWinGIS.Image
        Dim imgName As String = ""
        Dim legFile As String = ""

        Dim newSF As New MapWinGIS.Shapefile
        Dim doImportScheme As Boolean = False
        Dim lyrType As Interfaces.eLayerType = Interfaces.eLayerType.Invalid

        newGrid = New MapWinGIS.Grid

        If addList Is Nothing Then
            newLayers = New ArrayList
            frmMain.MapMain.LockWindow(MapWinGIS.tkLockMode.lmLock)
        End If

        If TypeName(ObjectOrFilename) = "String" Then 'the ObjectOrFilename is a string value
            If ObjectOrFilename.ToString = "" Then ' no  filename passed, open the common dialog.
                Dim cdlOpen As New OpenFileDialog

                'set the default dir
                If (System.IO.Directory.Exists(AppInfo.DefaultDir)) Then
                    cdlOpen.InitialDirectory = AppInfo.DefaultDir
                End If

                cdlOpen.FileName = ""
                cdlOpen.Title = "Add Map Layer"
                cdlOpen.Filter = GetSupportedFormats()

                cdlOpen.CheckFileExists = True
                cdlOpen.CheckPathExists = True
                cdlOpen.Multiselect = True
                cdlOpen.ShowReadOnly = False

                If addList Is Nothing Then
                    If cdlOpen.ShowDialog() = DialogResult.Cancel Then
                        frmMain.MapMain.LockWindow(MapWinGIS.tkLockMode.lmUnlock)
                        GoTo ENDFUNC
                    Else
                        frmMain.Update()
                        addList = cdlOpen.FileNames()
                    End If
                End If

                'save the location of the last open dir
                If (System.IO.File.Exists(cdlOpen.FileName)) Then
                    Dim dir As String = System.IO.Path.GetDirectoryName(cdlOpen.FileName)
                    If (System.IO.Directory.Exists(dir)) Then
                        AppInfo.DefaultDir = System.IO.Path.GetDirectoryName(cdlOpen.FileName)
                    End If
                End If

                lyrFilename = addList(UBound(addList))
                If addList.Length = 1 Then
                    Erase addList
                    addList = Nothing
                Else
                    ReDim Preserve addList(UBound(addList) - 1)
                End If

                If LayerName = "" Then
                    lyrName = MapWinUtility.MiscUtils.GetBaseName(lyrFilename)
                Else
                    lyrName = LayerName
                End If

            Else    ' Filename was passed
                If LayerName = "" Then
                    lyrName = MapWinUtility.MiscUtils.GetBaseName(ObjectOrFilename.ToString)
                Else
                    lyrName = LayerName
                End If
                If Dir(ObjectOrFilename.ToString) = "" Then
                    MapWinUtility.Logger.Msg("Invalid file: " & ObjectOrFilename.ToString, "MapWin.Layers.AddLayer")
                    GoTo ENDFUNC
                End If

                lyrFilename = ObjectOrFilename.ToString
            End If

            Cursor.Current = Cursors.WaitCursor
            Cursor.Show()

            'get cdlgfilter from image, then see if the extension is in that filter
            Dim ExtName As String = LCase(MapWinUtility.MiscUtils.GetExtensionName(lyrFilename))

            'convert wmf to bitmap to make it openable
            If (InStr(1, lyrFilename, ".wmf", vbTextCompare) <> 0) Then
                Dim cvter As New System.Drawing.Bitmap(lyrFilename)
                lyrFilename = GetMWTempFile + ".bmp"
                ExtName = "bmp"
                cvter.Save(lyrFilename, System.Drawing.Imaging.ImageFormat.Bmp)
            End If

            'Convert flt, dem, grd into binary grids that can
            'be opened reliably. This causes it to open twice
            'technically, but is worth it in the long run for speed
            'versus running with SuperGrid
            If ExtName.ToLower().EndsWith("flt") Or ExtName.ToLower().EndsWith("dem") Or ExtName.ToLower().EndsWith("grd") Then
                Dim bgdequiv As String = System.IO.Path.ChangeExtension(lyrFilename, ".bgd")
                If IO.File.Exists(bgdequiv) AndAlso MapWinUtility.DataManagement.CheckFile2Newest(lyrFilename, bgdequiv) Then
                    lyrFilename = bgdequiv
                Else
                    'Convert it
                    Dim cvg As New SuperGrid
                    If cvg.Open(lyrFilename) Then
                        'Opening it will cause the equiv. bgd to be written
                        cvg.Close()
                        lyrFilename = bgdequiv
                        'else -- try to open with grid handler in ocx - may fail for these three formats though.
                    End If
                End If
            End If

            'Treat aux file: 
            Try
                Dim IsAuxHeader As Boolean = False
                Dim lyrFileStm As System.IO.FileStream = System.IO.File.OpenRead(lyrFilename)
                If Not lyrFileStm Is Nothing Then
                    Dim header(10) As Byte
                    lyrFileStm.Read(header, 0, 11)
                    lyrFileStm.Close()
                    Dim headerEncoding As New System.Text.ASCIIEncoding
                    Dim strheader As String = headerEncoding.GetString(header)
                    If strheader = "EHFA_HEADER" Then 'open the sta.adf file instead
                        ' Chris M 1/27/2007 -- IF it exists
                        If System.IO.File.Exists(lyrFilename.Substring(0, lyrFilename.Length - 4) + "\sta.adf") Then
                            lyrFilename = lyrFilename.Substring(0, lyrFilename.Length - 4) + "\sta.adf"
                        End If
                    End If
                End If
            Catch ex As System.IO.IOException
                If ex.ToString().ToLower().Contains("being used") Then
                    'Warn
                    MapWinUtility.Logger.Msg("Warning: The file (" + System.IO.Path.GetFileName(lyrFilename) + ") appears to be in use." + vbCrLf + vbCrLf + "MapWindow will continue to try to open it, but may be unsuccessful.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "File In Use")
                Else
                    'This is a minor test -- don't show the error. ShowError(ex)
                End If
            Catch ex As Exception
                'This is a minor test -- don't show the error. ShowError(ex)
            End Try

            If InStr(1, lyrFilename, ".adf", vbTextCompare) <> 0 Or InStr(1, lyrFilename, ".asc", vbTextCompare) <> 0 Then
                ' If it's an ESRI GRid, open it as an image
                ' or as a grid depending on the project setting.

                If AppInfo.LoadESRIAsGrid = ESRIBehavior.LoadAsGrid Then
                    'Load as grid
                    newGrid.Open(lyrFilename, MapWinGIS.GridDataType.UnknownDataType, True, MapWinGIS.GridFileType.UseExtension, CType(Me, MapWinGIS.ICallback))
                    newObject = newGrid 'This is set temporarily; the code below changes this by generating corresponding image
                    lyrType = Interfaces.eLayerType.Grid

                    'Check the projection of the layer; ensure it's in sync with everything
                    'else, prompt the user if not. For full details see the frmProjMismatch.
                    'This function will alter "newObject" however necessary.
                    Dim mismatchTester_1 As New frmProjMismatch
                    Dim abort_1 As Boolean = False
                    mismatchTester_1.TestProjection(newObject, abort_1, lyrFilename)

                    If abort_1 Then
                        TryCloseObject(newObject)
                        GoTo ENDFUNC
                    End If

                    legFile = IO.Path.ChangeExtension(lyrFilename, ".mwleg")
                    If lyrFilename <> "" AndAlso IO.File.Exists(IO.Path.ChangeExtension(lyrFilename, ".bmp")) AndAlso _
                                      IO.File.Exists(legFile) AndAlso (GrdColorScheme Is Nothing OrElse ColoringSchemeTools.ColoringSchemesAreEqual(GrdColorScheme, legFile) = True) Then
                        imgName = IO.Path.ChangeExtension(lyrFilename, ".bmp")
                        newImage.Open(imgName, MapWinGIS.ImageType.USE_FILE_EXTENSION, False, CType(Me, MapWinGIS.ICallback))
                        newObject = newImage
                    Else
                        If lyrFilename = "" Then
                            imgName = GetMWTempFile
                        Else
                            imgName = IO.Path.ChangeExtension(lyrFilename, ".bmp")
                        End If

                        GenerateGridColorScheme(newGrid, GrdColorScheme)

                        If GrdColorScheme Is Nothing Then
                            MapWinUtility.Logger.Msg("Failed to Generate Coloring for Grid", "MapWin.Layers.AddLayer")
                            GoTo ENDFUNC
                        End If

                        GetImageRep(lyrFilename, newImage, newGrid, GrdColorScheme, CType(Me, MapWinGIS.ICallback))
                        ReportProgress("", 0, "")

                        If newImage Is Nothing Then
                            GoTo ENDFUNC
                        Else
                            newObject = newImage
                        End If
                    End If
                Else
                    'Load as image
                    If newImage.Open(lyrFilename, MapWinGIS.ImageType.USE_FILE_EXTENSION, False, CType(Me, MapWinGIS.ICallback)) = False Then
                        MapWinUtility.Logger.Msg("Failed to open file", "MapWin.Layers.AddLayer")
                        GoTo ENDFUNC
                    End If
                    newObject = newImage
                End If

            ElseIf InStr(1, lyrFilename, ".tif", vbTextCompare) <> 0 Or InStr(1, lyrFilename, ".img", vbTextCompare) <> 0 Then
                ' Chris Michaelis August 31 2005 (for tif) and Feb 8 2007 (for img)
                ' Note -- treat these together because they both have the potential of having
                ' an embedded coloring scheme (whereas ESRI grids do not).

                'Chris Michaelis -- 3/13/2006 -- now use the project setting to
                'tell what to do here. Old IF: If (frmMain.MapMain.IsTIFFGrid(lyrFilename)) Then
                If LoadingTIForIMGasGrid(lyrFilename) Then
                    'Load as grid
                    newGrid.Open(lyrFilename, MapWinGIS.GridDataType.UnknownDataType, True, MapWinGIS.GridFileType.GeoTiff, Nothing)
                    newObject = newGrid 'This is set temporarily; the code below changes this by generating corresponding image
                    lyrType = Interfaces.eLayerType.Grid

                    'Check the projection of the layer; ensure it's in sync with everything
                    'else, prompt the user if not. For full details see the frmProjMismatch.
                    'This function will alter "newObject" however necessary.
                    Dim mismatchTester_1 As New frmProjMismatch
                    Dim abort_1 As Boolean = False
                    mismatchTester_1.TestProjection(newObject, abort_1, lyrFilename)

                    If abort_1 Then
                        TryCloseObject(newObject)
                        GoTo ENDFUNC
                    End If

                    legFile = IO.Path.ChangeExtension(lyrFilename, ".mwleg")
                    If lyrFilename <> "" AndAlso IO.File.Exists(IO.Path.ChangeExtension(lyrFilename, ".bmp")) AndAlso _
                                      IO.File.Exists(legFile) AndAlso (GrdColorScheme Is Nothing OrElse ColoringSchemeTools.ColoringSchemesAreEqual(GrdColorScheme, legFile) = True) Then
                        imgName = IO.Path.ChangeExtension(lyrFilename, ".bmp")
                        newImage.Open(imgName, MapWinGIS.ImageType.USE_FILE_EXTENSION, False, CType(Me, MapWinGIS.ICallback))
                        newObject = newImage
                    Else
                        If lyrFilename = "" Then
                            imgName = GetMWTempFile
                        Else
                            imgName = IO.Path.ChangeExtension(lyrFilename, ".bmp")
                        End If

                        'Chris M 1/26/2006 -- if an existing .mwleg is there,
                        'generate with it rather than generating a fully new one.
                        'Just because a few values in a grid changed doesn't mean
                        'they want a fully new coloring scheme regenerated
                        If GrdColorScheme Is Nothing And System.IO.File.Exists(legFile) Then
                            Dim doc As New System.Xml.XmlDocument
                            doc.Load(legFile)
                            GrdColorScheme = New MapWinGIS.GridColorScheme
                            ColoringSchemeTools.ImportScheme(GrdColorScheme, doc.DocumentElement.Item("GridColoringScheme"))
                        End If

                        If GrdColorScheme Is Nothing Then
                            'Let's try to get it from the TIF palette.
                            GrdColorScheme = newGrid.RasterColorTableColoringScheme()
                        End If

                        ' It may be null from the above call to RasterColorTableColoringScheme
                        If (GrdColorScheme Is Nothing) Then
                            'Make a new one
                            GenerateGridColorScheme(newGrid, GrdColorScheme)
                        End If

                        If GrdColorScheme Is Nothing Then
                            'I give up
                            MapWinUtility.Logger.Msg("Failed to Generate Coloring for Grid", "MapWin.Layers.AddLayer")
                            GoTo ENDFUNC
                        End If

                        GetImageRep(lyrFilename, newImage, newGrid, GrdColorScheme, CType(Me, MapWinGIS.ICallback))

                        ReportProgress("", 0, "")

                        If newImage Is Nothing Then
                            GoTo ENDFUNC
                        Else
                            newObject = newImage
                        End If
                    End If
                Else
                    'Load as image
                    If newImage.Open(lyrFilename, MapWinGIS.ImageType.USE_FILE_EXTENSION, False, CType(Me, MapWinGIS.ICallback)) = False Then
                        MapWinUtility.Logger.Msg("Failed to open file", "MapWin.Layers.AddLayer")
                        GoTo ENDFUNC
                    End If
                    newObject = newImage

                End If
            ElseIf InStr(1, LCase(newSF.CdlgFilter), ExtName, vbTextCompare) <> 0 Then
                'Shapefile filename was passed.

                'Chris M 5/15/2007
                'Check it for read-only - and ask the user if they'd like to copy it to non-RO
                Dim fi As New System.IO.FileInfo(lyrFilename)
                If (fi.Attributes And System.IO.FileAttributes.ReadOnly) = IO.FileAttributes.ReadOnly Then
                    'Note parenthesis placement above (important)
                    Static LastAnswer As frmYesNoToAll.DialogResult = frmYesNoToAll.DialogResult.Undefined
                    Static LastPath As String = ""
                    If LastAnswer = frmYesNoToAll.DialogResult.NoToAll Then
                        'No action needed
                    ElseIf LastAnswer = frmYesNoToAll.DialogResult.YesToAll And Not LastPath = "" Then
                        'Don't show dialog - just do it
                        MapWinGeoProc.DataManagement.CopyShapefile(lyrFilename, LastPath + "\" + System.IO.Path.GetFileName(lyrFilename))
                        lyrFilename = LastPath + "\" + System.IO.Path.GetFileName(lyrFilename)
                        'Path is updated - proceed
                    Else
                        LastAnswer = frmYesNoToAll.ShowPrompt("Warning: The layer you are adding is read-only. Do you wish to copy the layer to another location before adding it?", "Read-Only Layer - Copy?")
                        If LastAnswer = frmYesNoToAll.DialogResult.Yes Or LastAnswer = frmYesNoToAll.DialogResult.YesToAll Then
                            Dim fb As New FolderBrowserDialog
                            fb.SelectedPath = AppInfo.DefaultDir
                            If fb.ShowDialog() = DialogResult.OK Then
                                MapWinGeoProc.DataManagement.CopyShapefile(lyrFilename, fb.SelectedPath + "\" + System.IO.Path.GetFileName(lyrFilename))
                                lyrFilename = fb.SelectedPath + "\" + System.IO.Path.GetFileName(lyrFilename)
                                LastPath = fb.SelectedPath
                                'Path is updated - proceed
                            End If
                        End If
                    End If
                End If

                If newSF.Open(lyrFilename, CType(Me, MapWinGIS.ICallback)) = False Then
                    MapWinUtility.Logger.Msg("Failed to open file: " & newSF.ErrorMsg(newSF.LastErrorCode), "MapWin.Layers.AddLayer")
                    GoTo ENDFUNC
                End If

                newObject = newSF

                'Perform some basic testing on the shapefile
                Dim abort_1 As Boolean = False
                TestShapefile(newSF, abort_1)
                If abort_1 Then
                    TryCloseObject(newObject)
                    GoTo endfunc
                End If

                'Check the projection of the layer; ensure it's in sync with everything
                'else, prompt the user if not. For full details see the frmProjMismatch.
                'This function will alter "newObject" however necessary.
                abort_1 = False
                Dim mismatchTester_1 As New frmProjMismatch
                mismatchTester_1.TestProjection(newObject, abort_1, lyrFilename)

                If abort_1 Then
                    TryCloseObject(newObject)
                    GoTo ENDFUNC
                End If

            ElseIf InStr(1, LCase(newGrid.CdlgFilter), ExtName, vbTextCompare) <> 0 Or ExtName.ToLower().EndsWith("flt") Or ExtName.ToLower().EndsWith("dem") Or ExtName.ToLower().EndsWith("grd") Then
                'Grid filename was passed. 
                lyrType = Interfaces.eLayerType.Grid
                If lyrFilename.ToLower.EndsWith("sta.adf") Then
                    'chop ESRI files down to just the directory name
                    lyrFilename = lyrFilename.Substring(0, lyrFilename.Length - 8)
                End If

                Try
                    If (newGrid.Open(lyrFilename, MapWinGIS.GridDataType.UnknownDataType, True, MapWinGIS.GridFileType.UseExtension, CType(Me, MapWinGIS.ICallback)) = False) Then
                        MapWinUtility.Logger.Msg("Failed to open file: " & lyrFilename, "MapWin.Layers.AddLayer")
                        GoTo ENDFUNC
                    End If
                Catch ex As Exception
                    Dim e As New Exception("GRID OPEN failure: " + lyrFilename + " -- " + ex.ToString())
                    CustomExceptionHandler.OnThreadException(e)
                    GoTo endfunc
                End Try

                'Check the projection of the layer; ensure it's in sync with everything
                'else, prompt the user if not. For full details see the frmProjMismatch.
                'This function will alter "newObject" however necessary.
                Dim mismatchTester_1 As New frmProjMismatch
                Dim abort_1 As Boolean = False
                mismatchTester_1.TestProjection(CType(newGrid, Object), abort_1, lyrFilename)

                If abort_1 Then
                    TryCloseObject(newObject)
                    GoTo ENDFUNC
                End If

                legFile = IO.Path.ChangeExtension(lyrFilename, ".mwleg")
                imgName = IO.Path.ChangeExtension(lyrFilename, ".bmp")

                ' Chris Michaelis July 2 2005 - added CheckWriteTimes to
                ' optimize grid loading by not rebuilding the grid image every time if
                ' it's unnecessary.
                If IO.File.Exists(imgName) AndAlso MapWinUtility.DataManagement.CheckFile2Newest(lyrFilename, imgName) AndAlso IO.File.Exists(legFile) AndAlso (GrdColorScheme Is Nothing OrElse ColoringSchemeTools.ColoringSchemesAreEqual(GrdColorScheme, legFile) = True) Then
                    newImage.Open(IO.Path.ChangeExtension(lyrFilename, ".bmp"), MapWinGIS.ImageType.USE_FILE_EXTENSION, False, CType(Me, MapWinGIS.ICallback))
                    newObject = newImage
                Else
                    'The grid coloring scheme either doesn't exist or is out of sync with the image, or the grid doesn't have an image.

                    'Chris M 1/26/2006 -- if an existing .mwleg is there,
                    'generate with it rather than generating a fully new one.
                    'Just because a few values in a grid changed doesn't mean
                    'they want a fully new coloring scheme regenerated
                    If GrdColorScheme Is Nothing And System.IO.File.Exists(legFile) Then
                        GrdColorScheme = New MapWinGIS.GridColorScheme
                        Dim doc As New System.Xml.XmlDocument
                        doc.Load(legFile)
                        ColoringSchemeTools.ImportScheme(GrdColorScheme, doc.DocumentElement.Item("GridColoringScheme"))
                    ElseIf GrdColorScheme Is Nothing Then
                        'Create a generic random grid coloring scheme.
                        GenerateGridColorScheme(newGrid, GrdColorScheme)
                    End If

                    If GrdColorScheme Is Nothing Then
                        MapWinUtility.Logger.Msg("Failed to Generate Coloring for Grid: Null Object", "MapWin.Layers.AddLayer")
                        GoTo ENDFUNC
                    End If

                    'Create an image using the grid coloring scheme.
                    GetImageRep(lyrFilename, newImage, newGrid, GrdColorScheme, CType(Me, MapWinGIS.ICallback))

                    ReportProgress("", 0, "")
                    If newImage Is Nothing Then
                        GoTo ENDFUNC
                    Else
                        newObject = newImage
                    End If
                End If
            ElseIf InStr(1, LCase(newImage.CdlgFilter), ExtName, vbTextCompare) <> 0 Then
                'dpa 4/14/2005 changed the following line to open the file in ram.  Otherwise it locks the
                'file and won't allow us to delete it after its been removed from the map.

                'Chris Michaelis and Lailin Chen Aug 23 2005 -- This must be false or we will see a huge
                'performance hit. The problem with the file lock has now been fixed in MapWinGIS.
                If newImage.Open(lyrFilename, MapWinGIS.ImageType.USE_FILE_EXTENSION, False, CType(Me, MapWinGIS.ICallback)) = False Then
                    MapWinUtility.Logger.Msg("Failed to open file", "MapWin.Layers.AddLayer")
                    GoTo ENDFUNC
                End If
                newObject = newImage
            Else
                MapWinUtility.Logger.Msg("File format not supported.", "MapWin.Layers.AddLayer")
                GoTo ENDFUNC
            End If

        Else ' An object was passed
            newObject = ObjectOrFilename
            If LayerName = "" Then
                addCnt = addCnt + 1
                lyrName = "Layer " & addCnt
            Else
                lyrName = LayerName
            End If

            'On Error Resume Next
            'lyrFilename = newObject.FileName
            'On Error GoTo 0

            If TypeOf (newObject) Is MapWinGIS.Grid Then
                'Check the projection of the layer; ensure it's in sync with everything
                'else, prompt the user if not. For full details see the frmProjMismatch.
                'This function will alter "newObject" however necessary.
                Dim mismatchTester_1 As New frmProjMismatch
                Dim abort_1 As Boolean = False
                mismatchTester_1.TestProjection(newObject, abort_1, lyrFilename)

                If abort_1 Then
                    TryCloseObject(newObject)
                    GoTo ENDFUNC
                End If

                lyrType = Interfaces.eLayerType.Grid
                newGrid = CType(newObject, MapWinGIS.Grid)
                lyrFilename = newGrid.Filename

                legFile = IO.Path.ChangeExtension(lyrFilename, ".mwleg")

                If lyrFilename <> "" AndAlso IO.File.Exists(IO.Path.ChangeExtension(lyrFilename, ".bmp")) AndAlso _
                                  IO.File.Exists(legFile) AndAlso (GrdColorScheme Is Nothing OrElse ColoringSchemeTools.ColoringSchemesAreEqual(GrdColorScheme, legFile) = True) Then
                    imgName = IO.Path.ChangeExtension(lyrFilename, ".bmp")
                    newImage.Open(imgName, MapWinGIS.ImageType.USE_FILE_EXTENSION, False, CType(Me, MapWinGIS.ICallback))
                    newObject = newImage
                Else
                    If lyrFilename = "" Then
                        imgName = GetMWTempFile
                    Else
                        imgName = IO.Path.ChangeExtension(lyrFilename, ".bmp")
                    End If

                    'Chris M 1/26/2006 -- if an existing .mwleg is there,
                    'generate with it rather than generating a fully new one.
                    'Just because a few values in a grid changed doesn't mean
                    'they want a fully new coloring scheme regenerated
                    If GrdColorScheme Is Nothing And System.IO.File.Exists(legFile) Then
                        Dim doc As New System.Xml.XmlDocument
                        doc.Load(legFile)
                        GrdColorScheme = New MapWinGIS.GridColorScheme
                        ColoringSchemeTools.ImportScheme(GrdColorScheme, doc.DocumentElement.Item("GridColoringScheme"))
                    End If

                    If GrdColorScheme Is Nothing Then
                        GenerateGridColorScheme(newGrid, GrdColorScheme)
                    End If

                    If GrdColorScheme Is Nothing Then
                        MapWinUtility.Logger.Msg("Failed to Generate Coloring for Grid", "MapWin.Layers.AddLayer")
                        GoTo ENDFUNC
                    End If

                    GetImageRep(lyrFilename, newImage, newGrid, GrdColorScheme, CType(Me, MapWinGIS.ICallback))
                    ReportProgress("", 0, "")

                    If newImage Is Nothing Then
                        GoTo ENDFUNC
                    Else
                        newObject = newImage
                    End If

                End If

            ElseIf TypeOf (newObject) Is MapWinGIS.Grid Then
                'Check the projection of the layer; ensure it's in sync with everything
                'else, prompt the user if not. For full details see the frmProjMismatch.
                'This function will alter "newObject" however necessary.
                Dim mismatchTester_1 As New frmProjMismatch
                Dim abort_1 As Boolean = False
                mismatchTester_1.TestProjection(newObject, abort_1, lyrFilename)

                If abort_1 Then
                    TryCloseObject(newObject)
                    GoTo ENDFUNC
                End If
            End If
        End If

        'now add the object (created or passed) to the Map
        'this function actually returns the layer handle, not position

        'Chris Michaelis for Bugzilla 310 - add above currently selected layer (if any)
        If (PositionFromSelected And Not frmMain.Legend.SelectedLayer = -1) Then
            Dim addPos As Integer = 0
            Dim addGrp As Integer = 0
            addPos = frmMain.Legend.Layers.PositionInGroup(frmMain.m_layers.CurrentLayer) + 1
            addGrp = frmMain.Legend.Layers.GroupOf(frmMain.m_layers.CurrentLayer)

            mapHandle = frmMain.Legend.Layers.Add(LegendVisible, newObject, LayerVisible)
            frmMain.Legend.Layers.MoveLayer(mapHandle, addGrp, addPos)
        Else
            mapHandle = frmMain.Legend.Layers.Add(LegendVisible, newObject, LayerVisible)
        End If

        'Moved to a more appropriate location; tests will still be run with this.
        'newObject = Nothing

        ' this lets the legend know we are working with a grid.  
        ' The lyrType is ignored for all other types other than grid
        ' (the legend is smart enough to figure the others out by itself)
        If lyrType = Interfaces.eLayerType.Grid Then
            If m_Grids.Contains(mapHandle) Then m_Grids.Remove(mapHandle)

            m_Grids.Add(mapHandle, newGrid)
            frmMain.Legend.Layers.ItemByHandle(mapHandle).Type = lyrType
        End If

        If lyrType = Interfaces.eLayerType.Grid AndAlso GrdColorScheme Is Nothing AndAlso IsValidHandle(mapHandle) Then
            GrdColorScheme = CType(ColoringSchemeTools.ImportScheme(frmMain.Layers(mapHandle), IO.Path.ChangeExtension(lyrFilename, ".mwleg")), MapWinGIS.GridColorScheme)
        End If

        If NewPos < 0 Then 'it didn't open successfully
            MapWinUtility.Logger.Msg("Failed to open file", "MapWin.Layers.AddLayer")
            GoTo ENDFUNC
        Else
            NewPos = frmMain.MapMain.get_LayerPosition(mapHandle) 'now get the actual position by the handle

            newLyr.Handle = mapHandle

            With newLyr
                .Name = lyrName
                .DrawFill = DrawFill
                If Color = -1 Then
                    .Color = MapWinUtility.Colors.IntegerToColor(MakeRandomColor())
                Else
                    .Color = MapWinUtility.Colors.IntegerToColor(Color)
                End If
                If OutlineColor = -1 Then
                    .OutlineColor = MapWinUtility.Colors.IntegerToColor(MakeRandomColor())
                Else
                    .OutlineColor = MapWinUtility.Colors.IntegerToColor(OutlineColor)
                End If

                If TypeOf newObject Is MapWinGIS.Shapefile Then
                    Dim sf As MapWinGIS.Shapefile
                    sf = CType(newObject, MapWinGIS.Shapefile)
                    Select Case sf.ShapefileType
                        Case MapWinGIS.ShpfileType.SHP_POINT, MapWinGIS.ShpfileType.SHP_POINTM, MapWinGIS.ShpfileType.SHP_POINTZ
                            If PointType = MapWinGIS.tkPointType.ptUserDefined Then
                                .LineOrPointSize = LineOrPointSize

                            Else
                                If LineOrPointSize = 1 Then
                                    .LineOrPointSize = 3
                                Else
                                    .LineOrPointSize = LineOrPointSize
                                End If

                            End If

                        Case Else
                            .LineOrPointSize = LineOrPointSize

                    End Select
                End If

                .PointType = PointType
            End With
        End If

        newLayers.Add(newLyr)

        'If it was a shapefile, load any rendering info
        If newLyr.LayerType = Interfaces.eLayerType.LineShapefile Or newLyr.LayerType = Interfaces.eLayerType.PointShapefile Or newLyr.LayerType = Interfaces.eLayerType.PolygonShapefile Then
            'Note: This call contains logic to determine if loading from a project file
            ' (no mwsr use) or if adding outside of a project (use mwsr)
            frmMain.LoadShapeLayerProps(newLyr.Handle, "", m_PluginCall)
        ElseIf newLyr.LayerType = Interfaces.eLayerType.Grid Then
            ' 10/17/2007 - SaveShapeLayerProps == misnomer - can also be used for saving grid coloring scheme.
            ' Can't change name now without breaking interface

            'Load mwleg only if layername == "" -- this indicates it's not adding
            'from within a project file context
            If LayerName = "" Then frmMain.LoadShapeLayerProps(newLyr.Handle, "", m_PluginCall)
        End If

        'Note: Run this after loadshapelayerprops - it will resave out any mwsr file with latest information (e.g., last used rendering)
        If Not GrdColorScheme Is Nothing Then
            frmMain.MapMain.SetImageLayerColorScheme(mapHandle, GrdColorScheme)
            frmMain.MapMain.set_GridFileName(mapHandle, lyrFilename)
            Dim o As MapWinGIS.Image
            o = CType(frmMain.MapMain.get_GetObject(mapHandle), MapWinGIS.Image)
            If Not o Is Nothing Then
                o.TransparencyColor = GrdColorScheme.NoDataColor
                o.UseTransparencyColor = True
                o = Nothing
            End If
            frmMain.Legend.Layers.ItemByHandle(mapHandle).Refresh()
            ColoringSchemeTools.ExportScheme(frmMain.Layers(mapHandle), IO.Path.ChangeExtension(imgName, ".mwleg"))
        End If

        'Moved from above, where it had been set to nothing before all checks had been run.
        newObject = Nothing
        newImage = Nothing
        GC.Collect()

        'check for any label file
        frmMain.m_Labels.LoadLabelInfo(newLyr, Nothing)

ENDFUNC:

        If addList Is Nothing Then
            frmMain.MapMain.LockWindow(MapWinGIS.tkLockMode.lmUnlock)

            frmMain.UpdateZoomButtons()
            ReportProgress("", 0, "")

            If newLayers.Count = 0 Then
                retVal = Nothing
            End If

            If newLayers.Count = 1 AndAlso frmMain.MapMain.NumLayers = 1 Then
                frmMain.MapMain.ZoomToMaxExtents()
            End If

            If newLayers.Count > 0 Then
                frmMain.m_PluginManager.LayersAdded(CType(newLayers.ToArray(GetType(Layer)), MapWindow.Interfaces.Layer()))
                retVal = CType(newLayers.ToArray(GetType(Layer)), Interfaces.Layer())
            End If
        Else
            retVal = AddLayer()
        End If

        modMain.frmMain.UpdateZoomButtons()
        If Not InitialNumLayers = frmMain.MapMain.NumLayers Then modMain.frmMain.SetModified(True) 'We changed - otherwise aborted through any number of routes
        Return retVal
    End Function

    Private Sub TestShapefile(ByRef sf As MapWinGIS.Shapefile, ByRef abort As Boolean)
        abort = False

        'Test 1 - Ensure that the DBF exists
        If Not System.IO.File.Exists(System.IO.Path.ChangeExtension(sf.Filename, ".dbf")) Then
            If Not MapWinUtility.Logger.Msg("Warning: This shapefile appears to have no database table (.dbf) associated with it!" + vbCrLf + vbCrLf + "Do you wish to continue adding this layer?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Missing Database Table") = MsgBoxResult.Yes Then abort = True
            Exit Sub
        End If

        'Test 2 -- Check that the number of DBF records matches the number of shapes.
        Dim tbl As New MapWinGIS.Table
        tbl.Open(System.IO.Path.ChangeExtension(sf.Filename, ".dbf"))
        If Not sf.NumShapes = tbl.NumRows Then
            If Not MapWinUtility.Logger.Msg("The number of features does not match the number of records in this file:" & vbCrLf & vbCrLf & _
                       sf.Filename & vbCrLf & vbCrLf & "The ShapeCheck utility (http://www.mapwindow.org/download/shapechk.zip) can correct this and other shapefile errors." + vbCrLf + vbCrLf + "Continue adding this layer?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Corrupt Shapefile") = MsgBoxResult.Yes Then abort = True
            tbl.Close()
            Exit Sub
        Else
            tbl.Close()
        End If
    End Sub

    Private Function LoadingTIForIMGasGrid(ByVal fn As String) As Boolean
        If fn.ToLower().EndsWith(".img") Then
            If AppInfo.LoadTIFFandIMGasgrid = GeoTIFFAndImgBehavior.LoadAsGrid Then
                Return True
            Else
                Return False
            End If
        Else 'is a tif
            If AppInfo.LoadTIFFandIMGasgrid = GeoTIFFAndImgBehavior.LoadAsGrid Then Return True
            If AppInfo.LoadTIFFandIMGasgrid = GeoTIFFAndImgBehavior.Automatic And frmMain.MapMain.IsTIFFGrid(fn) Then Return True
            Return False
        End If
    End Function

    Private Sub GenerateGridColorScheme(ByRef newGrid As MapWinGIS.Grid, ByRef GrdColorScheme As MapWinGIS.GridColorScheme)
        'Changed to create unique breaks if less than one hundred unique values.
        'Chris M May 2006
        'The function returns false if there were > 100 or if unique break creation failed.
        If Not GridColoringSchemeForm.GetUniqueBreaks(newGrid, True, GrdColorScheme, MapWinGIS.GradientModel.Linear, MapWinGIS.ColoringType.Gradient, "N", 3) Then
            GrdColorScheme = New MapWinGIS.GridColorScheme
            GrdColorScheme.UsePredefined(newGrid.Minimum, newGrid.Maximum, MapWinGIS.PredefinedColorScheme.FallLeaves)
        End If
    End Sub

    <CLSCompliant(False)> _
    Public Function RebuildGridLayer(ByVal LayerHandle As Integer, ByVal GridObject As MapWinGIS.Grid, ByVal ColorScheme As MapWinGIS.GridColorScheme) As Boolean Implements MapWindow.Interfaces.Layers.RebuildGridLayer
        'Rebuilds an image associated with a grid layer.
        '4/23/2005 - dpa - Updated to sync the legend with the new coloring scheme that may have been passed in. 
        Dim img As MapWinGIS.Image = Nothing
        Dim NewScheme As MapWinGIS.GridColorScheme = Nothing
        Dim fileName As String
        Dim tmpImage As MapWinGIS.Image
        Dim gc As New MapWinGIS.Utils
        Dim oldUseTrans As Boolean
        Dim oldTransColor As UInt32

        Try
            'Make sure there is a valid grid object at the current layer handle.
            img = CType(frmMain.MapMain.get_GetObject(LayerHandle), MapWinGIS.Image)
            If GridObject Is Nothing Then
                g_error = "RebuildGridLayer:  GridObject parameter is 'Nothing'"
                Return False
            End If
            If img Is Nothing Then
                g_error = frmMain.MapMain.get_ErrorMsg(frmMain.MapMain.LastErrorCode)
                Return False
            End If

            'Make sure there is a valid coloring scheme object.
            If ColorScheme Is Nothing Then
                GenerateGridColorScheme(GridObject, NewScheme)
            Else
                NewScheme = ColorScheme
            End If

            'Create the new image.
            frmMain.MapMain.LockWindow(MapWinGIS.tkLockMode.lmLock)
            Try
                If FileLen(img.Filename) > 2000000000 AndAlso (img.Filename.EndsWith(".tif") OrElse img.Filename.EndsWith(".tiff")) Then
                    Try
                        CType(frmMain.Layers(LayerHandle).GetObject(), MapWinGIS.Image)._pushSchemetkRaster(ColorScheme)
                    Catch e As Exception
                        Debug.WriteLine(e.ToString())
                    End Try
                Else
                    fileName = img.Filename
                    'Ensure that the filename ends in BMP -- don't rewrite TIF or BIL with bitmap data into the TIF or BIL extension
                    fileName = System.IO.Path.ChangeExtension(fileName, ".bmp")

                    oldUseTrans = img.UseTransparencyColor
                    oldTransColor = img.TransparencyColor
                    img.Close()
                    tmpImage = gc.GridToImage(GridObject, NewScheme)
                    tmpImage.Save(fileName, True, MapWinGIS.ImageType.BITMAP_FILE, Me)
                    tmpImage.Close()
                    tmpImage = Nothing
                    img.Open(fileName, MapWinGIS.ImageType.BITMAP_FILE, False, Me)
                    img.UseTransparencyColor = oldUseTrans
                    img.TransparencyColor = oldTransColor
                End If
            Finally
                frmMain.MapMain.LockWindow(MapWinGIS.tkLockMode.lmUnlock)
            End Try
            frmMain.View.Extents = frmMain.View.Extents
            frmMain.MapMain.UpdateImage(LayerHandle)
            frmMain.MapMain.Redraw()

            'Update the Legend (added 4/22/2005 - dpa)
            frmMain.MapMain.SetImageLayerColorScheme(LayerHandle, NewScheme)
            frmMain.MapMain.set_GridFileName(LayerHandle, GridObject.Filename)
            frmMain.Legend.Layers.ItemByHandle(LayerHandle).Refresh()
            ColoringSchemeTools.ExportScheme(frmMain.Layers(LayerHandle), IO.Path.ChangeExtension(img.Filename, ".mwleg"))

            ReportProgress("", 0, "")

        Catch ex As Exception
            g_error = ex.Message
            ShowError(ex)
            Return False
        End Try
    End Function

    '-------------------Properties-------------------
    Public Property CurrentLayer() As Integer Implements Interfaces.Layers.CurrentLayer
        Get
            CurrentLayer = frmMain.Legend.SelectedLayer
        End Get
        Set(ByVal Value As Integer)
            frmMain.Legend.SelectedLayer = Value
        End Set
    End Property

    <CLSCompliant(False)> _
    Default Public ReadOnly Property Item(ByVal LayerHandle As Integer) As Interfaces.Layer Implements Interfaces.Layers.Item
        Get
            If frmMain.MapMain.NumLayers = 0 Then
                g_error = "No layers to return!"
                Return Nothing
            End If

            If Not IsValidHandle(LayerHandle) Then
                g_error = "Invalid layer handle " + LayerHandle.ToString() + " requested. If cycling from 0 to NumLayers, route through '.GetHandle'"
                Return Nothing
            End If

            Dim newLyr As New MapWindow.Layer
            newLyr.Handle = LayerHandle
            Return newLyr
        End Get
    End Property

    Public ReadOnly Property NumLayers() As Integer Implements Interfaces.Layers.NumLayers
        Get
            NumLayers = frmMain.MapMain.NumLayers
        End Get
    End Property

    Public Sub ReportProgress(ByVal KeyOfSender As String, ByVal Percent As Integer, ByVal Message As String) Implements MapWinGIS.ICallback.Progress
        'loading project is set in xmlProjectFile so it can keep track of entire progress  
        'of the project not every layer
        If (frmMain.m_LoadingProject = False) Then
            frmMain.StatusBar.ProgressBarValue = Percent
        End If
    End Sub

    Public Sub ReportError(ByVal KeyOfSender As String, ByVal ErrorMsg As String) Implements MapWinGIS.ICallback.Error
        g_error = ErrorMsg
    End Sub

    Public Function GetHandle(ByVal Position As Integer) As Integer Implements MapWindow.Interfaces.Layers.GetHandle
        Try
            If Position < NumLayers() And Position >= 0 Then
                Return frmMain.MapMain.get_LayerHandle(Position)
            End If

            Return -1
        Catch ex As System.Exception
            g_error = ex.Message
            ShowError(ex)
            Return -1
        End Try
    End Function

    <CLSCompliant(False)> _
    ReadOnly Property Groups() As LegendControl.Groups Implements MapWindow.Interfaces.Layers.Groups
        Get
            Return frmMain.Legend.Groups
        End Get
    End Property

    <CLSCompliant(False)> _
    Public Function Add(ByRef ShapefileObject As MapWinGIS.Shapefile, ByVal LayerName As String, ByVal Color As Integer, ByVal OutlineColor As Integer, ByVal LineOrPointSize As Integer) As MapWindow.Interfaces.Layer Implements MapWindow.Interfaces.Layers.Add
        Return AddLayer(ShapefileObject, LayerName, , , Color, OutlineColor, , LineOrPointSize)(0)
    End Function

    <CLSCompliant(False)> _
    Public Function Add(ByRef ShapefileObject As MapWinGIS.Shapefile, ByVal LayerName As String, ByVal Color As Integer, ByVal OutlineColor As Integer) As MapWindow.Interfaces.Layer Implements MapWindow.Interfaces.Layers.Add
        Return AddLayer(ShapefileObject, LayerName, , , Color, OutlineColor)(0)
    End Function

    Public Function IsValidHandle(ByVal LayerHandle As Integer) As Boolean Implements MapWindow.Interfaces.Layers.IsValidHandle
        Return frmMain.Legend.Layers.IsValidHandle(LayerHandle)
    End Function

    'Chris Michaelis Sept 2006
    'Find a suitable image representation of the grid data
    <CLSCompliant(False)> _
    Public Sub GetImageRep(ByVal filename As String, ByRef newImage As MapWinGIS.Image, ByRef newGrid As MapWinGIS.Grid, ByRef GrdColorScheme As MapWinGIS.GridColorScheme, ByRef cb As MapWinGIS.ICallback)
        Try
            If newGrid Is Nothing Then Return

            MapWinUtility.Logger.Status("Creating image representation of raster " + filename, True)

            If newImage Is Nothing Then newImage = New MapWinGIS.Image

            Dim ext As String = System.IO.Path.GetExtension(filename).ToLower()

            If (Not frmMain.MapMain.IsTIFFGrid(filename) OrElse FileLen(filename) > 2000000000) AndAlso (ext.EndsWith(".tif") OrElse ext.EndsWith(".tiff")) Then
                'A tiff returning false here likely has a colormap and can be opened 
                'as an image by GDAL -- do so
                'Chris Michaelis March 2009 - If the file is >2GB, force opening it with GDAL
                'and note that we'll force our "coloring scheme" in through tkRaster
                MapWinUtility.Logger.Dbg("Try opening TIFF with GDAL")
                If Not newImage.Open(filename, MapWinGIS.ImageType.USE_FILE_EXTENSION, False, cb) Then
                    Try
                        newImage.Close()
                    Catch
                    End Try
                    newImage = Nothing
                    MapWinUtility.Logger.Msg("An error occurred opening the image. Please try again, and if the problem persists, submit a bug report including sample data at http://bugs.MapWindow.org/. Thank you!", MsgBoxStyle.Exclamation, "Error Opening Image")
                Else
                    'Push our coloring scheme in - normally this will have no effect for an image, but
                    'iff tkRaster is rendering it, it will indeed get used
                    newImage._pushSchemetkRaster(GrdColorScheme)
                End If
            ElseIf ext.EndsWith(".img") Then
                'Likely has a colormap and can be opened as an image by GDAL -- do so
                MapWinUtility.Logger.Dbg("Try opening img with GDAL")
                If Not newImage.Open(filename, MapWinGIS.ImageType.USE_FILE_EXTENSION, False, cb) Then
                    Try
                        newImage.Close()
                    Catch
                    End Try

                    'ok, ok, do it the slow way - convert image
                    Dim converter As New MapWinGIS.Utils
                    newImage = converter.GridToImage(newGrid, GrdColorScheme, CType(Me, MapWinGIS.ICallback))
                    Dim imgName As String = IO.Path.ChangeExtension(filename, ".bmp")
                    newImage.Save(imgName, True, MapWinGIS.ImageType.BITMAP_FILE, CType(Me, MapWinGIS.ICallback))
                    'Open with inram=false now that conversion is done:
                    newImage.Close()
                    newImage.Open(imgName, MapWinGIS.ImageType.BITMAP_FILE, False, CType(Me, MapWinGIS.ICallback))
                    newImage.TransparencyColor = GrdColorScheme.NoDataColor
                    'CDM 11/14/05 Set the below to true to enable using the nodatavalue as transparency color
                    newImage.UseTransparencyColor = True
                End If
            ElseIf ext.EndsWith(".bil") Then
                'Open the underlying BIL instead
                MapWinUtility.Logger.Dbg("Open the underlying BIL instead")
                If Not newImage.Open(filename, MapWinGIS.ImageType.USE_FILE_EXTENSION, False, cb) Then
                    Try
                        newImage.Close()
                    Catch
                    End Try
                    newImage = Nothing
                    MapWinUtility.Logger.Msg("An error occurred opening the image. Please try again, and if the problem persists, submit a bug report including sample data at http://bugs.MapWindow.org/. Thank you!", MsgBoxStyle.Exclamation, "Error Opening Image")
                End If
            Else
                'Convert image
                MapWinUtility.Logger.Dbg("Convert image")
                Dim converter As New MapWinGIS.Utils
                newImage = converter.GridToImage(newGrid, GrdColorScheme, CType(Me, MapWinGIS.ICallback))
                Dim imgName As String = IO.Path.ChangeExtension(filename, ".bmp")
                newImage.Save(imgName, True, MapWinGIS.ImageType.BITMAP_FILE, CType(Me, MapWinGIS.ICallback))
                'Open with inram=false now that conversion is done:
                newImage.Close()
                newImage.Open(imgName, MapWinGIS.ImageType.BITMAP_FILE, False, CType(Me, MapWinGIS.ICallback))
                newImage.TransparencyColor = GrdColorScheme.NoDataColor
                'CDM 11/14/05 Set the below to true to enable using the nodatavalue as transparency color
                newImage.UseTransparencyColor = True
            End If
        Catch ex As Exception
            Dim e As New Exception("GetImageRep failed processing filename: " + filename + vbCrLf + vbCrLf + "Full Exception:" + vbCrLf + ex.ToString())
            ShowError(e)
            MapWinUtility.Logger.Dbg("Error occurred in GetImageRep: " + ex.ToString())
        End Try

        MapWinUtility.Logger.Dbg("Finished creating image representation of raster " + filename)
        MapWinUtility.Logger.Status("")
    End Sub
End Class