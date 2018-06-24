'********************************************************************************************************
'File Name: clsView.vb
'Description: Public class used to access the main map view through the plugin interface.
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
'1/31/2005 - minor modifications. (dpa)
'********************************************************************************************************

Public Class View
    Implements Interfaces.View


    Public Sub New()
        MyBase.New()
        m_SelectedShapes = New MapWindow.SelectInfo
    End Sub

    Private Const lmUnlock As Integer = 0
    Private Const lmLock As Integer = 1

    '-------------------Private members for public properties-------------------
    Private m_SelectColor As Integer = RGB(255, 255, 0) ' System.Drawing.Color.Yellow.ToArgb() And &HFFFFFF
    Private m_SelectionPersistence As Boolean
    Private m_SelectionTolerance As Double
    Private m_Selectmethod As MapWinGIS.SelectMode

    '-------------------Selected Shape Info-------------------
    Private m_SelectedShapes As MapWindow.SelectInfo

    '-------------------Subs-------------------
    Public Sub ClearSelectedShapes() Implements Interfaces.View.ClearSelectedShapes
        m_SelectedShapes.ClearSelectedShapes()
    End Sub

    <CLSCompliant(False)> _
    Public Function Identify(ByVal ProjX As Double, ByVal ProjY As Double, ByVal Tolerance As Double) As Interfaces.IdentifiedLayers Implements Interfaces.View.Identify
        Dim tShp As MapWindow.IdentifiedShapes
        Dim tLyr As New MapWindow.IdentifiedLayers
        Dim i As Integer, j As Integer
        Dim tSF As MapWinGIS.Shapefile, o As Object, box As MapWinGIS.Extents, res As Object = Nothing

        For i = 0 To frmMain.MapMain.NumLayers - 1
            If frmMain.MapMain.get_LayerVisible(frmMain.MapMain.get_LayerHandle(i)) = True Then
                o = frmMain.MapMain.get_GetObject(frmMain.MapMain.get_LayerHandle(i))
                If TypeOf o Is MapWinGIS.Shapefile Then
                    tSF = CType(o, MapWinGIS.Shapefile)
                    o = Nothing

                    box = New MapWinGIS.Extents
                    box.SetBounds(ProjX, ProjY, 0, ProjX, ProjY, 0)

                    If tSF.SelectShapes(box, Tolerance, MapWinGIS.SelectMode.INTERSECTION, res) Then
                        tShp = New MapWindow.IdentifiedShapes

                        Dim arr As System.Array
                        arr = CType(res, System.Array)
                        For j = 0 To UBound(arr)
                            tShp.Add(CType(arr.GetValue(j), Integer))
                        Next j

                        tLyr.Add(tShp, frmMain.MapMain.get_LayerHandle(i))
                    End If

                End If
            End If
        Next i
        Identify = tLyr
    End Function

    Public Property LegendVisible() As Boolean Implements Interfaces.View.LegendVisible
        Get
            Return frmMain.m_Menu("mnuLegendVisible").Checked
        End Get
        Set(ByVal value As Boolean)
            If frmMain.m_Menu("mnuLegendVisible").Checked = Not value Then
                frmMain.HandleClickedMenu("mnuLegendVisible")
            End If
        End Set
    End Property

    Public Property LabelsUseProjectLevel() As Boolean Implements Interfaces.View.LabelsUseProjectLevel
        Get
            Return AppInfo.LabelsUseProjectLevel
        End Get
        Set(ByVal value As Boolean)
            AppInfo.LabelsUseProjectLevel = value
            frmMain.SetModified(True)
        End Set
    End Property

    Public Sub LabelsEdit(ByVal LayerHandle As Integer) Implements Interfaces.View.LabelsEdit
        If frmMain.Layers.IsValidHandle(LayerHandle) AndAlso (frmMain.Layers.Item(LayerHandle).LayerType = Interfaces.eLayerType.LineShapefile Or frmMain.Layers.Item(LayerHandle).LayerType = Interfaces.eLayerType.PointShapefile Or frmMain.Layers.Item(LayerHandle).LayerType = Interfaces.eLayerType.PolygonShapefile) Then
            frmMain.DoLabelsEdit(LayerHandle)
        End If
    End Sub

    Public Sub LabelsRelabel(ByVal LayerHandle As Integer) Implements Interfaces.View.LabelsRelabel
        If frmMain.Layers.IsValidHandle(LayerHandle) AndAlso (frmMain.Layers.Item(LayerHandle).LayerType = Interfaces.eLayerType.LineShapefile Or frmMain.Layers.Item(LayerHandle).LayerType = Interfaces.eLayerType.PointShapefile Or frmMain.Layers.Item(LayerHandle).LayerType = Interfaces.eLayerType.PolygonShapefile) Then
            frmMain.DoLabelsRelabel(LayerHandle)
        End If
    End Sub

    Public Property PreviewVisible() As Boolean Implements Interfaces.View.PreviewVisible
        Get
            Return frmMain.m_Menu("mnuPreviewVisible").Checked
        End Get
        Set(ByVal value As Boolean)
            If frmMain.m_Menu("mnuPreviewVisible").Checked = Not value Then
                frmMain.HandleClickedMenu("mnuPreviewVisible")
            End If
        End Set
    End Property

    Public Sub LockLegend() Implements Interfaces.View.LockLegend
        frmMain.Legend.Lock()
    End Sub

    Public Sub UnlockLegend() Implements Interfaces.View.UnlockLegend
        frmMain.Legend.Unlock()
    End Sub

    Public Sub LockMap() Implements Interfaces.View.LockMap
        frmMain.MapMain.LockWindow(MapWinGIS.tkLockMode.lmLock)
    End Sub

    Public Sub UnlockMap() Implements Interfaces.View.UnlockMap
        frmMain.MapMain.LockWindow(MapWinGIS.tkLockMode.lmUnlock)
    End Sub

    Public Sub PixelToProj(ByVal PixelX As Double, ByVal PixelY As Double, ByRef ProjX As Double, ByRef ProjY As Double) Implements Interfaces.View.PixelToProj
        frmMain.MapMain.PixelToProj(PixelX, PixelY, ProjX, ProjY)
    End Sub

    Public Sub ProjToPixel(ByVal ProjX As Double, ByVal ProjY As Double, ByRef PixelX As Double, ByRef PixelY As Double) Implements Interfaces.View.ProjToPixel
        frmMain.MapMain.ProjToPixel(ProjX, ProjY, PixelX, PixelY)
    End Sub

    Public Sub Redraw() Implements Interfaces.View.Redraw
        frmMain.MapMain.Redraw()
    End Sub

    Public Sub ShowToolTip(ByVal Text As String, ByVal Milliseconds As Integer) Implements Interfaces.View.ShowToolTip
        frmMain.MapMain.ShowToolTip(Text, Milliseconds)
    End Sub

    Public Sub ZoomToMaxExtents() Implements Interfaces.View.ZoomToMaxExtents
        frmMain.MapMain.ZoomToMaxExtents()
        frmMain.m_PreviewMap.UpdateLocatorBox()
    End Sub

    Public Sub ZoomIn(ByVal Percent As Double) Implements Interfaces.View.ZoomIn
        frmMain.MapMain.ZoomIn(Percent)
        frmMain.m_PreviewMap.UpdateLocatorBox()
    End Sub

    Public Sub ZoomOut(ByVal Percent As Double) Implements Interfaces.View.ZoomOut
        frmMain.MapMain.ZoomOut(Percent)
        frmMain.m_PreviewMap.UpdateLocatorBox()
    End Sub

    Public Sub ZoomToPrev() Implements Interfaces.View.ZoomToPrev
        frmMain.MapMain.ZoomToPrev()
        frmMain.m_PreviewMap.UpdateLocatorBox()
    End Sub

    Public Property HandleFileDrop() As Boolean Implements Interfaces.View.HandleFileDrop
        Get
            Return frmMain.m_HandleFileDrop
        End Get
        Set(ByVal value As Boolean)
            frmMain.m_HandleFileDrop = value
        End Set
    End Property

    '-------------------Functions-------------------
    <CLSCompliant(False)> _
    Public Function Snapshot(ByVal Bounds As MapWinGIS.Extents) As MapWinGIS.Image Implements Interfaces.View.Snapshot
        Snapshot = CType(frmMain.MapMain.SnapShot(Bounds), MapWinGIS.Image)
    End Function

    '-------------------Properties-------------------
    Public Property BackColor() As System.Drawing.Color Implements Interfaces.View.BackColor
        Get
            Dim map As MapWinGIS.Map = CType(CType(frmMain.MapMain, AxHost).GetOcx(), MapWinGIS.Map)
            Return MapWinUtility.Colors.IntegerToColor(map.BackColor)
        End Get
        Set(ByVal Value As System.Drawing.Color)
            'note: calling frmMain.MapMain.BackColor doesn't correctly set the back color.
            'by getting the ocx object directly, we can set the value directly and it works correctly
            Dim map As MapWinGIS.Map = CType(CType(frmMain.MapMain, AxHost).GetOcx(), MapWinGIS.Map)
            map.BackColor = MapWinUtility.Colors.ColorToUInteger(Value)
            map = Nothing
        End Set
    End Property

    <CLSCompliant(False)> _
    Public Property CursorMode() As MapWinGIS.tkCursorMode Implements Interfaces.View.CursorMode
        Get
            CursorMode = frmMain.MapMain.CursorMode
        End Get
        Set(ByVal Value As MapWinGIS.tkCursorMode)
            frmMain.MapMain.CursorMode = Value

            frmMain.UpdateZoomButtons()
        End Set
    End Property

    <CLSCompliant(False)> _
    Public ReadOnly Property Draw() As Interfaces.Draw Implements Interfaces.View.Draw
        Get
            Dim df As New MapWindow.Draw
            Draw = df
        End Get
    End Property

    Public Property ExtentPad() As Double Implements Interfaces.View.ExtentPad
        Get
            ExtentPad = frmMain.MapMain.ExtentPad
        End Get
        Set(ByVal Value As Double)
            frmMain.MapMain.ExtentPad = Value
        End Set
    End Property

    <CLSCompliant(False)> _
    Public Property Extents() As MapWinGIS.Extents Implements Interfaces.View.Extents
        Get
            Extents = CType(frmMain.MapMain.Extents, MapWinGIS.Extents)
        End Get
        Set(ByVal Value As MapWinGIS.Extents)
            frmMain.MapMain.Extents = Value
            frmMain.m_PreviewMap.UpdateLocatorBox()
        End Set
    End Property

    <CLSCompliant(False)> _
    Public Property MapCursor() As MapWinGIS.tkCursor Implements Interfaces.View.MapCursor
        Get
            MapCursor = frmMain.MapMain.MapCursor
        End Get
        Set(ByVal Value As MapWinGIS.tkCursor)
            frmMain.MapMain.MapCursor = Value
        End Set
    End Property

    Public Property MapState() As String Implements Interfaces.View.MapState
        Get
            MapState = frmMain.MapMain.MapState
        End Get
        Set(ByVal Value As String)
            frmMain.MapMain.LockWindow(MapWinGIS.tkLockMode.lmLock)
            Try
                frmMain.Legend.Lock()
                frmMain.Legend.Layers.Clear()
                frmMain.MapMain.RemoveAllLayers()
                frmMain.MapPreview.ClearDrawings()
                frmMain.MapPreview.RemoveAllLayers()
                frmMain.MapMain.MapState = Value
                frmMain.Legend.Unlock()
            Finally
                frmMain.MapMain.LockWindow(MapWinGIS.tkLockMode.lmUnlock)
            End Try
        End Set
    End Property

    <CLSCompliant(False)> _
    Public ReadOnly Property SelectedShapes() As Interfaces.SelectInfo Implements Interfaces.View.SelectedShapes
        Get
            SelectedShapes = m_SelectedShapes
        End Get
    End Property

    Public Property SelectionPersistence() As Boolean Implements Interfaces.View.SelectionPersistence
        Get
            SelectionPersistence = m_SelectionPersistence
        End Get
        Set(ByVal Value As Boolean)
            m_SelectionPersistence = Value
        End Set
    End Property

    Public Property SelectionTolerance() As Double Implements Interfaces.View.SelectionTolerance
        Get
            SelectionTolerance = m_SelectionTolerance
        End Get
        Set(ByVal Value As Double)
            m_SelectionTolerance = Value
        End Set
    End Property

    <CLSCompliant(False)> _
    Public Property SelectMethod() As MapWinGIS.SelectMode Implements Interfaces.View.SelectMethod
        Get
            SelectMethod = m_Selectmethod
        End Get
        Set(ByVal Value As MapWinGIS.SelectMode)
            m_Selectmethod = Value
        End Set
    End Property

    Public Property SelectColor() As System.Drawing.Color Implements Interfaces.View.SelectColor
        Get
            SelectColor = MapWinUtility.Colors.IntegerToColor(m_SelectColor)
        End Get
        Set(ByVal Value As System.Drawing.Color)
            m_SelectColor = MapWinUtility.Colors.ColorToInteger(Value)
        End Set
    End Property

    Public Property Tag() As String Implements Interfaces.View.Tag
        Get
            Tag = frmMain.MapMain.Key
        End Get
        Set(ByVal Value As String)
            frmMain.MapMain.Key = Value
        End Set
    End Property

    Public Property UserCursorHandle() As Integer Implements Interfaces.View.UserCursorHandle
        Get
            UserCursorHandle = frmMain.MapMain.UDCursorHandle
        End Get
        Set(ByVal Value As Integer)
            frmMain.MapMain.UDCursorHandle = Value
        End Set
    End Property

    Public Property ZoomPercent() As Double Implements Interfaces.View.ZoomPercent
        Get
            ZoomPercent = frmMain.MapMain.ZoomPercent
        End Get
        Set(ByVal Value As Double)
            frmMain.MapMain.ZoomPercent = Value
        End Set
    End Property

    '--------------------------------------MapWin 2.0 Selection Routines--------------------------------------
    '30 Aug 2001  Darrel Brown.  Refer to Document "MapWindow 2.0 Public Interface" Page 2
    '---------------------------------------------------------------------------------------------------------

    Private Sub AddToSelectList(ByVal MapLayerHandle As Integer, ByVal lSelectedShapes() As Integer)
        Dim curShape As MapWinGIS.Shape, curShapeFile As MapWinGIS.Shapefile
        Dim j As Integer, k As Integer, foundIndex As Integer
        Dim newSel As MapWindow.SelectedShape

        curShapeFile = CType(frmMain.MapMain.get_GetObject(MapLayerHandle), MapWinGIS.Shapefile)
        If curShapeFile Is Nothing Then
            Exit Sub
        End If

        On Error Resume Next
        If UBound(lSelectedShapes) >= 0 Then
            If Err.Number = 0 Then
                On Error GoTo 0
                'now add the shapefile.   If the shapefile already exists it will not
                'create a duplicate, but return the existing one

                For j = 0 To UBound(lSelectedShapes)

                    If m_SelectionPersistence = True Then

                        If IsSelected(MapLayerHandle, lSelectedShapes(j), foundIndex) Then ' unselect if selected
                            m_SelectedShapes.RemoveSelectedShape(foundIndex)

                        Else ' select the shape
                            If frmMain.MapMain.get_ShapeVisible(MapLayerHandle, lSelectedShapes(j)) <> False Then
                                newSel = New MapWindow.SelectedShape
                                newSel.Add(lSelectedShapes(j), MapWinUtility.Colors.IntegerToColor(m_SelectColor))
                                m_SelectedShapes.AddSelectedShape(newSel)
                            End If
                        End If

                    Else
                        'loop through each of the selected items, add it to the list and color it
                        If Not IsSelected(MapLayerHandle, lSelectedShapes(j), foundIndex) Then
                            If frmMain.MapMain.get_ShapeVisible(MapLayerHandle, lSelectedShapes(j)) <> False Then
                                newSel = New MapWindow.SelectedShape
                                newSel.Add(lSelectedShapes(j), MapWinUtility.Colors.IntegerToColor(m_SelectColor))
                                m_SelectedShapes.AddSelectedShape(newSel)
                            End If
                        End If

                    End If

                Next j

            End If
        End If
    End Sub

    Private Function IsSelected(ByVal MapLayerIndex As Integer, ByVal ShapeIndex As Integer, ByRef outListIndex As Integer) As Boolean
        Dim i As Integer

        'On Error Resume Next
        outListIndex = -1

        For i = 0 To m_SelectedShapes.NumSelected - 1
            If m_SelectedShapes(i).ShapeIndex = ShapeIndex Then
                IsSelected = True
                outListIndex = i
                Exit Function
            End If
        Next i
    End Function

    Friend Function SelectShapesByPoint(ByVal ScreenX As Integer, ByVal ScreenY As Integer, Optional ByVal ctrlDown As Boolean = False) As MapWindow.SelectInfo
        SelectShapesByPoint = Nothing
        Dim j As Integer
        Dim curShapeFile As MapWinGIS.Shapefile, curLyr As Integer
        Dim lSelectResults As System.Array = Nothing, bResult As Boolean, foundIndex As Integer
        Dim X1 As Double, Y1 As Double, dTol As Double
        Dim tx As Double, ty As Double
        Dim tPSize As Integer
        Dim NewBounds As MapWinGIS.Extents
        curLyr = frmMain.Layers.CurrentLayer

        If frmMain.Legend.SelectedLayer = -1 Then Return Nothing

        If m_SelectedShapes Is Nothing Then m_SelectedShapes = New MapWindow.SelectInfo

        frmMain.MapMain.LockWindow(MapWinGIS.tkLockMode.lmLock)
        Try
            If m_SelectionPersistence = False And ctrlDown = False Then 'do not persist selection, clear all selected shapes
                If ctrlDown = False And m_SelectedShapes.NumSelected <> 0 Then
                    m_SelectedShapes.ClearSelectedShapes()
                End If
            End If

            PixelToProj(ScreenX, ScreenY, X1, Y1)
            NewBounds = New MapWinGIS.Extents
            With NewBounds
                .SetBounds(X1, Y1, 0, X1, Y1, 0)
            End With

            curShapeFile = Nothing

            Try
                curShapeFile = CType(frmMain.MapMain.get_GetObject(curLyr), MapWinGIS.Shapefile)
            Catch
                frmMain.MapMain.LockWindow(MapWinGIS.tkLockMode.lmUnlock)
                Return Nothing
            End Try

            If Not curShapeFile Is Nothing Then
                'The object was successfully returned, now select on it
                'do selection based on type of file, tol. for point/line, no tol for polygon

                Select Case curShapeFile.ShapefileType
                    Case MapWinGIS.ShpfileType.SHP_POLYGON, MapWinGIS.ShpfileType.SHP_POLYGONM, MapWinGIS.ShpfileType.SHP_POLYGONZ
                        Dim tobj As Object = Nothing
                        bResult = curShapeFile.SelectShapes(NewBounds, 0.0#, m_Selectmethod, tobj)
                        If bResult Then
                            lSelectResults = CType(tobj, System.Array)
                        End If

                    Case MapWinGIS.ShpfileType.SHP_POINT, MapWinGIS.ShpfileType.SHP_POINTM, MapWinGIS.ShpfileType.SHP_POINTZ
                        If frmMain.MapMain.get_ShapeLayerPointType(curLyr) <> MapWinGIS.tkPointType.ptUserDefined Then
                            tPSize = CInt(frmMain.MapMain.get_ShapeLayerPointSize(curLyr))
                            If tPSize < 5 Then
                                tPSize = 5
                            End If
                        Else
                            'find how large the image is
                            Dim tPic As MapWinGIS.Image
                            tPic = CType(frmMain.MapMain.get_UDPointType(curLyr), MapWinGIS.Image)
                            If Not tPic Is Nothing Then
                                tPSize = CInt((tPic.Height + tPic.Width) * 0.5 * frmMain.Layers(frmMain.Layers.CurrentLayer).LineOrPointSize)
                            End If
                        End If

                        PixelToProj(ScreenX + tPSize, ScreenY + tPSize, tx, ty)

                        If m_SelectionTolerance = 0 Then
                            dTol = System.Math.Sqrt((tx - X1) ^ 2 + (ty - Y1) ^ 2)
                        Else
                            dTol = m_SelectionTolerance
                        End If

                        Dim tobj As Object = Nothing
                        bResult = curShapeFile.SelectShapes(NewBounds, dTol, m_Selectmethod, tobj)
                        lSelectResults = CType(tobj, System.Array)

                    Case Else
                        PixelToProj(ScreenX + 5, ScreenY + 5, tx, ty)

                        If m_SelectionTolerance = 0 Then
                            dTol = System.Math.Sqrt((tx - X1) ^ 2 + (ty - Y1) ^ 2)
                        Else
                            dTol = m_SelectionTolerance
                        End If

                        Dim tobj As Object = Nothing
                        bResult = curShapeFile.SelectShapes(NewBounds, dTol, m_Selectmethod, tobj)
                        lSelectResults = CType(tobj, System.Array)
                End Select

                If bResult = False Then
                    'Debug.Print "no results"
                    frmMain.MapMain.LockWindow(MapWinGIS.tkLockMode.lmUnlock)
                    Return Nothing
                End If

                If lSelectResults.Length > 0 Then
                    Dim newSel As MapWindow.SelectedShape

                    For j = 0 To UBound(lSelectResults)
                        If (m_SelectionPersistence = True) Or (ctrlDown = True) Then
                            If IsSelected(curLyr, CInt(lSelectResults.GetValue(j)), foundIndex) Then ' unselect if selected
                                m_SelectedShapes.RemoveSelectedShape(foundIndex)

                            Else ' select the shape
                                If frmMain.MapMain.get_ShapeVisible(curLyr, CInt(lSelectResults.GetValue(j))) <> False Then
                                    newSel = New MapWindow.SelectedShape
                                    newSel.Add(CInt(lSelectResults.GetValue(j)), MapWinUtility.Colors.IntegerToColor(m_SelectColor))
                                    m_SelectedShapes.AddSelectedShape(newSel)
                                End If
                            End If

                        Else
                            ' loop through each of the selected items, add it to the list and color it
                            If frmMain.MapMain.get_ShapeVisible(curLyr, CInt(lSelectResults.GetValue(j))) <> False Then
                                newSel = New MapWindow.SelectedShape
                                newSel.Add(CInt(lSelectResults.GetValue(j)), MapWinUtility.Colors.IntegerToColor(m_SelectColor))
                                m_SelectedShapes.AddSelectedShape(newSel)
                            End If
                        End If

                    Next j

                    SelectShapesByPoint = m_SelectedShapes

                End If
            End If
        Finally
            frmMain.MapMain.LockWindow(MapWinGIS.tkLockMode.lmUnlock)
        End Try

        Return SelectShapesByPoint
    End Function

    Friend Function SelectShapesByRectangle(ByVal ScreenLeft As Integer, ByVal ScreenRight As Integer, ByVal ScreenTop As Integer, ByVal ScreenBottom As Integer, Optional ByVal ctrlDown As Boolean = False) As MapWindow.SelectInfo
        SelectShapesByRectangle = Nothing
        Dim geoL As Double, geoR As Double, geoT As Double, geoB As Double
        Dim j As Integer
        Dim curShapeFile As MapWinGIS.Shapefile, curLyr As Integer, foundIndex As Integer
        Dim lSelectResults As Object = Nothing, bResult As Boolean
        Dim NewBounds As New MapWinGIS.Extents
        Dim newSel As MapWindow.SelectedShape

        Try
            curLyr = frmMain.Legend.SelectedLayer
            If curLyr = -1 Then Return Nothing

            'make sure it is a shapefile layer
            If (frmMain.Layers(curLyr).LayerType = Interfaces.eLayerType.Grid _
            Or frmMain.Layers(curLyr).LayerType = Interfaces.eLayerType.Image _
            Or frmMain.Layers(curLyr).LayerType = Interfaces.eLayerType.Invalid) Then
                m_SelectedShapes.ClearSelectedShapes()
                Return m_SelectedShapes
            End If

            frmMain.MapMain.LockWindow(MapWinGIS.tkLockMode.lmLock)

            curShapeFile = Nothing
            curShapeFile = CType(frmMain.MapMain.get_GetObject(curLyr), MapWinGIS.Shapefile)

            frmMain.MapMain.PixelToProj(ScreenLeft, ScreenTop, geoL, geoT)
            frmMain.MapMain.PixelToProj(ScreenRight, ScreenBottom, geoR, geoB)

            NewBounds.SetBounds(geoL, geoB, 0, geoR, geoT, 0)

            If m_SelectionPersistence = False And ctrlDown = False Then 'do not persist selection, clear all selected shapes
                'clear all selected items
                m_SelectedShapes.ClearSelectedShapes()
            End If

            If Not curShapeFile Is Nothing Then
                bResult = curShapeFile.SelectShapes(NewBounds, 0.0#, m_Selectmethod, lSelectResults)

                If bResult = False Then
                    'Debug.Print "RectSelect: no shapes found"
                    frmMain.MapMain.LockWindow(MapWinGIS.tkLockMode.lmUnlock)
                    Return Nothing
                End If

                Dim res As Integer()
                ReDim res(CType(lSelectResults, System.Array).Length - 1)
                CType(lSelectResults, System.Array).CopyTo(res, 0)

                If UBound(res) >= 0 Then
                    For j = 0 To UBound(res)
                        If m_SelectionPersistence = True Or ctrlDown = True Then
                            If IsSelected(curLyr, res(j), foundIndex) Then ' unselect if selected
                                m_SelectedShapes.RemoveSelectedShape(foundIndex)

                            Else ' select the shape
                                newSel = New SelectedShape
                                newSel.Add(res(j), MapWinUtility.Colors.IntegerToColor(m_SelectColor))
                                m_SelectedShapes.AddSelectedShape(newSel)
                            End If
                        Else
                            'loop through each of the selected items, add it to the list and color it
                            If frmMain.MapMain.get_ShapeVisible(curLyr, res(j)) <> False Then
                                newSel = New MapWindow.SelectedShape
                                newSel.Add(res(j), MapWinUtility.Colors.IntegerToColor(m_SelectColor))
                                m_SelectedShapes.AddSelectedShape(newSel)
                            End If
                        End If
                    Next j
                    SelectShapesByRectangle = m_SelectedShapes
                End If
            End If
        Catch ex As Exception
            g_error = ex.Message
            ShowError(ex)
            Debug.WriteLine(g_error, "ERROR!!!")
        Finally
            frmMain.MapMain.LockWindow(MapWinGIS.tkLockMode.lmUnlock)
        End Try

        Return SelectShapesByRectangle
    End Function

    <CLSCompliant(False)> _
    Public Function [Select](ByVal ScreenX As Integer, ByVal ScreenY As Integer, ByVal ClearOldSelection As Boolean) As MapWindow.Interfaces.SelectInfo Implements MapWindow.Interfaces.View.Select
        Return Me.SelectShapesByPoint(ScreenX, ScreenY, Not ClearOldSelection)
    End Function

    <CLSCompliant(False)> _
    Public Function [Select](ByVal ScreenBounds As System.Drawing.Rectangle, ByVal ClearOldSelection As Boolean) As MapWindow.Interfaces.SelectInfo Implements MapWindow.Interfaces.View.Select
        Return Me.SelectShapesByRectangle(ScreenBounds.Left, ScreenBounds.Right, ScreenBounds.Top, ScreenBounds.Bottom, Not ClearOldSelection)
    End Function

End Class


