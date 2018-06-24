Imports System.Collections
Imports MapWinUtility

Public Class clsMenus
    Private m_Map As MapWindow.Interfaces.IMapWin
    Private m_MenuItems As ArrayList
    Private m_MenusExist As Boolean
    Private res As System.Resources.ResourceManager

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' TITLE: New
    ' AUTHOR: Chris Michaelis
    ' DESCRIPTION: Handler for new menu to assign map calling it
    '
    ' INPUTS:   Map: Map calling the new menu
    '
    ' OUTPUTS: None
    '
    ' NOTES: None
    '
    ' Change Log: 
    ' Date          Changed By      Notes
    ' 11/03/2005    ARA             Added Header
    ' 03/10/2007    Frank Lieber    Added ResourceManager
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    <CLSCompliant(False)> _
    Public Sub New(ByRef Map As MapWindow.Interfaces.IMapWin)
        m_Map = Map
        res = New System.Resources.ResourceManager("GISTools.Resource", System.Reflection.Assembly.GetExecutingAssembly())
    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' TITLE: LoadMenus
    ' AUTHOR: Chris Michaelis
    ' DESCRIPTION: Method to load GIS Tool Menu items
    '
    ' INPUTS:   None
    '
    ' OUTPUTS: None
    '
    ' NOTES: None
    '
    ' Change Log: 
    ' Date          Changed By      Notes
    ' 11/03/2005    ARA             Added Header and added ClipMerge submenu
    ' 11/21/2005    Chris Michaelis Added Georeferencing Stuff
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Sub LoadMenus()
        If m_MenusExist Then Return
        If m_Map Is Nothing Then Return

        If (m_MenuItems Is Nothing) Then
            m_MenuItems = New ArrayList
        Else
            m_MenuItems.Clear()
        End If

        m_MenusExist = True

        ' Here, use a very unique phrase to avoid duplication: mwTools_MapWindowTools
        ' Each subitem will begin with "mwTools_" by convention
        Dim rootItem As MapWindow.Interfaces.MenuItem = m_Map.Menus.Item("mwTools_MapWindowTools")
        If (rootItem Is Nothing) Then rootItem = m_Map.Menus.AddMenu("mwTools_MapWindowTools", "", Nothing, res.GetString("mnuGISTools.Text"))
        m_MenuItems.Add(rootItem)

        Dim rasterRootItem As MapWindow.Interfaces.MenuItem = m_Map.Menus.Item("mwTools_Raster")
        If (rasterRootItem Is Nothing) Then rasterRootItem = m_Map.Menus.AddMenu("mwTools_Raster", rootItem.Name, Nothing, res.GetString("mnuRaster.Text"))
        m_MenuItems.Add(rasterRootItem)

        Dim vectorRootItem As MapWindow.Interfaces.MenuItem = m_Map.Menus.Item("mwTools_Vector")
        If (vectorRootItem Is Nothing) Then vectorRootItem = m_Map.Menus.AddMenu("mwTools_Vector", rootItem.Name, Nothing, res.GetString("mnuVector.Text"))
        m_MenuItems.Add(vectorRootItem)

        Dim imageRootItem As MapWindow.Interfaces.MenuItem = m_Map.Menus.Item("mwTools_Image")
        If (imageRootItem Is Nothing) Then imageRootItem = m_Map.Menus.AddMenu("mwTools_Image", rootItem.Name, Nothing, res.GetString("mnuImage.Text"))
        m_MenuItems.Add(imageRootItem)

        'Vector:
        m_MenuItems.Add(m_Map.Menus.AddMenu("mwTools_ApplyProjSF", vectorRootItem.Name, Nothing, res.GetString("mnuApplyProjSF.Text")))
        m_MenuItems.Add(m_Map.Menus.AddMenu("mwTools_ReProjSF", vectorRootItem.Name, Nothing, res.GetString("mnuReProjSF.Text")))
        m_MenuItems.Add(m_Map.Menus.AddMenu("mwTools_Buffer", vectorRootItem.Name, Nothing, res.GetString("mnuBuffer.Text")))
        m_MenuItems.Add(m_Map.Menus.AddMenu("mwTools_CalculateArea", vectorRootItem.Name, Nothing, res.GetString("mnuCalculateArea.Text")))
        m_MenuItems.Add(m_Map.Menus.AddMenu("mwTools_ClipPolyWithLine", vectorRootItem.Name, Nothing, res.GetString("mnuClipPolyWithLine.Text")))
        m_MenuItems.Add(m_Map.Menus.AddMenu("mwTools_ClipSFWithPoly", vectorRootItem.Name, Nothing, res.GetString("mnuClipSFWithPoly.Text")))
        m_MenuItems.Add(m_Map.Menus.AddMenu("mwTools_EraseSFWithPoly", vectorRootItem.Name, Nothing, res.GetString("mnuEraseSFWithPoly.Text")))
        m_MenuItems.Add(m_Map.Menus.AddMenu("mwTools_ExportSelected", vectorRootItem.Name, Nothing, res.GetString("mnuExportSelected.Text")))
        m_MenuItems.Add(m_Map.Menus.AddMenu("mwTools_ExportByMask", vectorRootItem.Name, Nothing, res.GetString("mnuExportByMask.Text")))
        m_MenuItems.Add(m_Map.Menus.AddMenu("mwTools_Merge", vectorRootItem.Name, Nothing, res.GetString("mnuMerge.Text")))
        m_MenuItems.Add(m_Map.Menus.AddMenu("mwTools_MergeSF", vectorRootItem.Name, Nothing, res.GetString("mnuMergeSF.Text")))
        m_MenuItems.Add(m_Map.Menus.AddMenu("mwTools_Identity", vectorRootItem.Name, Nothing, res.GetString("mnuIdentity.Text")))

        'Raster:
        m_MenuItems.Add(m_Map.Menus.AddMenu("mwTools_ApplyProjGRID", rasterRootItem.Name, Nothing, res.GetString("mnuApplyProjGRID.Text")))
        m_MenuItems.Add(m_Map.Menus.AddMenu("mwTools_ReProjGRID", rasterRootItem.Name, Nothing, res.GetString("mnuReProjGRID.Text")))
        m_MenuItems.Add(m_Map.Menus.AddMenu("mwTools_ChangeFormatGRID", rasterRootItem.Name, Nothing, res.GetString("mnuChangeFormatGRID.Text")))
        m_MenuItems.Add(m_Map.Menus.AddMenu("mwTools_CreateImageGRID", rasterRootItem.Name, Nothing, res.GetString("mnuCreateImageGRID.Text")))
        m_MenuItems.Add(m_Map.Menus.AddMenu("mwTools_ResampleGRID", rasterRootItem.Name, Nothing, res.GetString("mnuResampleGRID.Text")))
        m_MenuItems.Add(m_Map.Menus.AddMenu("mwTools_MergeGRIDS", rasterRootItem.Name, Nothing, res.GetString("mnuMergeGRIDS.Text")))
        m_MenuItems.Add(m_Map.Menus.AddMenu("mwTools_ClipGridWithPoly", rasterRootItem.Name, Nothing, res.GetString("mnuClipGridWithPoly.Text")))
        m_MenuItems.Add(m_Map.Menus.AddMenu("mwTools_Georeference", rasterRootItem.Name, Nothing, res.GetString("mnuGeoreference.Text")))
        m_MenuItems.Add(m_Map.Menus.AddMenu("mwTools_Contour", rasterRootItem.Name, Nothing, res.GetString("mnuContour.Text")))
        m_MenuItems.Add(m_Map.Menus.AddMenu("mwTools_ChangeNodata", rasterRootItem.Name, Nothing, res.GetString("mnuChangeNodata.Text")))

        'Image:
        m_MenuItems.Add(m_Map.Menus.AddMenu("mwTools_ApplyProjImage", imageRootItem.Name, Nothing, res.GetString("mnuApplyProjImage.Text")))
        m_MenuItems.Add(m_Map.Menus.AddMenu("mwTools_RectifyToWorldfile", imageRootItem.Name, Nothing, res.GetString("mnuRectifyToWorldfile.Text")))
        m_MenuItems.Add(m_Map.Menus.AddMenu("mwTools_ReProjImage", imageRootItem.Name, Nothing, res.GetString("mnuReProjImage.Text")))

    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' TITLE: DestroyMenus
    ' AUTHOR: Chris Michaelis
    ' DESCRIPTION: Method to destroy GIS Tool Menu items
    '
    ' INPUTS:   None
    '
    ' OUTPUTS: None
    '
    ' NOTES: None
    '
    ' Change Log: 
    ' Date          Changed By      Notes
    ' 11/03/2005    ARA             Added Header
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Sub DestroyMenus()
        If Not m_MenusExist Then Return
        If m_Map Is Nothing Then Return

        Dim i As IEnumerator = m_MenuItems.GetEnumerator()
        While (i.MoveNext())
            If CType(i.Current, MapWindow.Interfaces.MenuItem).Name = "" Then
                m_Map.Menus.Remove(CType(i.Current, MapWindow.Interfaces.MenuItem).Text)
            Else
                m_Map.Menus.Remove(CType(i.Current, MapWindow.Interfaces.MenuItem).Name)
            End If
        End While

        m_MenusExist = False
        m_MenuItems.Clear()
    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' TITLE: HandleMenuEvent
    ' AUTHOR: Chris Michaelis
    ' DESCRIPTION: Method to handl GIS Tool Menu item events
    '
    ' INPUTS:   MenuText as menu item to handle
    '
    ' OUTPUTS: None
    '
    ' NOTES: None
    '
    ' Change Log: 
    ' Date          Changed By      Notes
    ' 11/03/2005    ARA             Added Header and handling for the clipmerge menu
    ' 04/05/2006    Angela Hillier  Added handling for Buffer
    ' 08/22/2006    JLK             Added use of Logger
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Sub HandleMenuEvent(ByVal MenuText As String, ByRef Handled As Boolean)
        If Not m_MenusExist Then Return

        Dim i As IEnumerator = m_MenuItems.GetEnumerator()
        While (i.MoveNext())
            If CType(i.Current, MapWindow.Interfaces.MenuItem).Name = MenuText Then
                ' Else it's not one of my menu items, as it wasn't in m_MenuItems

                Select Case MenuText
                    Case "mwTools_ExportSelected"
                        DoExportSelected()
                    Case "mwTools_ExportByMask"
                        If g_exportbymask_form Is Nothing OrElse g_exportbymask_form.IsDisposed Then g_exportbymask_form = New frmExportByMask()
                        g_exportbymask_form.Initialize()
                        g_exportbymask_form.Show()
                    Case "mwTools_MapWindowTools"
                        'Do nothing; placeholder.
                    Case "mwTools_Raster"
                        'Do nothing; placeholder.
                    Case "mwTools_Vector"
                        'Do nothing; placeholder.
                    Case "mwTools_ApplyProjSF"
                        DoApplySFProj()
                    Case "mwTools_ChangeNodata"
                        Dim ChangeNodataDlg As New frmChangeNodataVal
                        ChangeNodataDlg.showdialog()
                    Case "mwTools_ReProjSF"
                        DoSFReproject()
                    Case "mwTools_ApplyProjGRID"
                        DoApplyGridProj()
                    Case "mwTools_ReProjGRID"
                        DoGridReproject()
                    Case "mwTools_ChangeFormatGRID"
                        mnuChangeGridFormats()
                    Case "mwTools_CreateImageGRID"
                        mnuCreateGridImages()
                    Case "mwTools_MergeGRIDS"
                        mnuMergeGrids()
                    Case "mwTools_ResampleGRID"
                        mnuResampleGrids()
                    Case "mwTools_ClipGridWithPoly"
                        mnuClipWithPoly(0)
                    Case "mwTools_Buffer"
                        mnuBuffer()
                    Case "mwTools_ClipSFWithPoly"
                        mnuClipWithPoly(1)
                    Case "mwTools_ClipPolyWithLine"
                        mnuClipPolyWLine()
                    Case "mwTools_EraseSFWithPoly"
                        mnuEraseWithPoly()
                    Case "mwTools_CalculateArea"
                        mnuCalculateArea()
                    Case "mwTools_Contour"
                        mnuContour()
                    Case "mwTools_Merge"
                        mnuMerge()
                    Case "mwTools_MergeSF"
                        Dim mrg As New frmMergeShapefiles(m_Map)
                        mrg.ShowDialog()
                    Case "mwTools_Identity"
                        mnuIdentity()
                    Case "mwTools_Georeference"
                        If g_georef_form Is Nothing OrElse _
                           g_georef_form.IsDisposed Then
                            g_georef_form = New frmGeoreference()
                        End If
                        g_georef_form.Show()
                    Case "mwTools_ApplyProjImage"
                        DoApplyImageProj()
                    Case "mwTools_RectifyToWorldfile"
                        DoRectifyToWorldfile()
                    Case "mwTools_ReProjImage"
                        DoImageReproject()
                    Case Else
                        'It's one of my menu items, but apparently unhandled.
                        Logger.Msg("Functionality for " & MenuText & " has not yet been implemented.", _
                                    MsgBoxStyle.Information, _
                                    "GISTools:MenuEvent:" & MenuText & " Not Implemented")
                        'mapwinutility.logger.dbg("DEBUG: " + "Unimplemented Menu: " + MenuText)
                End Select
                Handled = True
            End If
        End While
    End Sub
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' TITLE: mnuEraseWithPoly
    ' AUTHOR: Angela Hillier
    ' DESCRIPTION: Displays the Buffer window.
    '
    ' INPUTS:   None
    '
    ' OUTPUTS: None
    '
    ' NOTES: None
    '
    ' Change Log: 
    ' Date          Changed By      Notes
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Sub mnuEraseWithPoly()
        Dim eraseForm As New frmErase()
        eraseForm.Initialize()
        eraseForm.Show()
    End Sub
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' TITLE: mnuBuffer
    ' AUTHOR: Angela Hillier
    ' DESCRIPTION: Displays the Buffer window.
    '
    ' INPUTS:   None
    '
    ' OUTPUTS: None
    '
    ' NOTES: None
    '
    ' Change Log: 
    ' Date          Changed By      Notes
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Sub mnuBuffer()
        Dim bufferForm As New frmBuffer()
        bufferForm.Initialize()
        bufferForm.Show()
    End Sub
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' TITLE: mnuCalculateArea
    ' AUTHOR: Chris Michaelis
    ' DESCRIPTION: Displays the area calculator window.
    '
    ' INPUTS:   None
    '
    ' OUTPUTS: None
    '
    ' NOTES: None
    '
    ' Change Log: 
    ' Date          Changed By      Notes
    ' 11/03/2005    ARA             Added Header
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Sub mnuCalculateArea()
        Dim calcfrm As New frmCalculateArea(m_Map)
        calcfrm.Show()
    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' TITLE: mnuContour
    ' AUTHOR: Chris Michaelis
    ' DESCRIPTION: Displays the contour generator window.
    '
    ' INPUTS:   None
    '
    ' OUTPUTS: None
    '
    ' NOTES: None
    '
    ' Change Log: 
    ' Date          Changed By      Notes
    ' 11/03/2005    ARA             Added Header
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Sub mnuContour()
        Dim calcfrm As New frmGenerateContour(m_Map)
        calcfrm.Show()
    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' TITLE: mnuChangeGridFormats
    ' AUTHOR: Chris Michaelis
    ' DESCRIPTION: Method to change grid formats
    '
    ' INPUTS:   None
    '
    ' OUTPUTS: None
    '
    ' NOTES: None
    '
    ' Change Log: 
    ' Date          Changed By      Notes
    ' 11/03/2005    ARA             Added Header
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Sub mnuChangeGridFormats()
        Try
            Logger.Dbg("ChangeGridFormats")
            Dim Errors As Boolean = False
            Dim gridFinder As New frmSelectGrids
            gridFinder.ShowDialog(g_MapWindowForm)

            If g_Grids Is Nothing Then
                Logger.Dbg("ChangeGridFormats - Grids is Nothing")
                Return
            End If

            If g_Grids.Count > 0 Then
                'Haven't cancelled; proceeding.

                Dim output As New frmOutput
                output.SetOptionsEnabled(True, True, True, False, True, True)

                'Default to data type of first grid for output
                Select Case CType(g_Grids(0), MapWinGIS.Grid).DataType
                    Case MapWinGIS.GridDataType.DoubleDataType
                        output.cmbDataType.Text = "Double Precision Float (8 bytes)"
                    Case MapWinGIS.GridDataType.FloatDataType
                        output.cmbDataType.Text = "Single Precision Float (4 bytes)"
                    Case MapWinGIS.GridDataType.InvalidDataType
                        output.cmbDataType.Text = "Double Precision Float (8 bytes)"
                    Case MapWinGIS.GridDataType.LongDataType
                        output.cmbDataType.Text = "Long Integer (4 bytes)"
                    Case MapWinGIS.GridDataType.ShortDataType
                        output.cmbDataType.Text = "Short Integer (2 bytes)"
                    Case MapWinGIS.GridDataType.UnknownDataType
                        output.cmbDataType.Text = "Double Precision Float (8 bytes)"
                End Select

                output.txtName.Text = "(original filename)"
                output.ShowDialog(g_MapWindowForm)
                If g_OutputPath = "" Then Errors = True 'Prevent the "Succeeded!" dialog from proclaiming a lie

                If Not g_OutputPath = "" Then
                    For j As Integer = 0 To g_Grids.Count - 1
                        Try
                            Dim tGrd As MapWinGIS.Grid = CType(g_Grids(j), MapWinGIS.Grid)
                            Dim filename As String = ""
                            Try
                                filename = g_OutputPath + IIf(g_OutputPath.EndsWith("\"), "", "\") + IIf(System.IO.Path.GetFileNameWithoutExtension(tGrd.Filename) = "", "NewGrid", System.IO.Path.GetFileNameWithoutExtension(tGrd.Filename)) + g_newExt
                            Catch
                                filename = g_OutputPath + IIf(g_OutputPath.EndsWith("\"), "", "\") + "NewGrid" + g_newExt
                            End Try

                            If Not MapWinGeoProc.DataManagement.ChangeGridFormat(tGrd.Filename, filename, g_newFormat, g_newDataType, Double.Parse(output.txtMultiplier.Text)) Then Errors = True

                            If g_AddOutputToMW Then
                                Logger.Status("Adding Grid to Project")
                                g_MW.Layers.Add(filename)
                                Logger.Status("Done adding Grid to Project")
                            End If

                        Catch ex As Exception
                            Errors = True
                            Logger.Msg("An error has occurred. Processing will continue; the full error text for this operation follows below." + vbCrLf + vbCrLf + ex.ToString())
                        End Try
                    Next
                End If

                If Not Errors Then
                    Logger.Status("Grid format changed successfully.")
                End If
            End If

            Cleanup()
        Catch e As Exception
            'mapwinutility.logger.dbg("DEBUG: " + e.ToString())
            Logger.Dbg("ChangeGridFormats:Error:" & e.ToString())
        End Try
    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' TITLE: mnuCreateGridImages
    ' AUTHOR: Chris Michaelis
    ' DESCRIPTION: Method to create grid images
    '
    ' INPUTS:   None
    '
    ' OUTPUTS: None
    '
    ' NOTES: None
    '
    ' Change Log: 
    ' Date          Changed By      Notes
    ' 11/03/2005    ARA             Added Header
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Sub mnuCreateGridImages()
        Dim Errors As Boolean = False
        Dim gridFinder As New frmSelectGrids
        gridFinder.ShowDialog(g_MapWindowForm)

        If g_Grids Is Nothing Then Return

        If g_Grids.Count > 0 Then
            'Haven't cancelled; proceeding.

            Dim output As New frmOutput
            output.SetOptionsEnabled(False, False, True, False, False)
            output.chkAdd.Checked = False
            output.txtName.Text = "(original filename)"
            output.ShowDialog(g_MapWindowForm)
            If Not g_OutputPath = "" Then

                For j As Integer = 0 To g_Grids.Count - 1
                    Try
                        Dim tGrd As MapWinGIS.Grid = CType(g_Grids(j), MapWinGIS.Grid)
                        'Prompt for a coloring scheme
                        Dim MyDialog As New frmColoringSchemeStylePicker
                        MyDialog.SetGridObject(tGrd)
                        MyDialog.ShowDialog(g_MapWindowForm)

                        Dim ProgressForm As New frmProgress
                        ProgressForm.Owner = g_MapWindowForm
                        ProgressForm.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
                        ProgressForm.Show()
                        ProgressForm.Taskname = "Creating Image..."

                        Dim filename As String = g_OutputPath + "\" + System.IO.Path.GetFileNameWithoutExtension(tGrd.Filename) + ".bmp"

                        If g_Scheme Is Nothing OrElse g_Scheme.NumBreaks = 0 Then
                            g_Scheme = New MapWinGIS.GridColorScheme
                            g_Scheme.UsePredefined(tGrd.Minimum, tGrd.Maximum, MapWinGIS.PredefinedColorScheme.SummerMountains)
                            CreateImage(filename, tGrd, g_Scheme, ProgressForm)
                            g_Scheme = Nothing
                        Else
                            CreateImage(filename, tGrd, g_Scheme, ProgressForm)
                        End If
                        ProgressForm.Close()
                        ProgressForm.Dispose()
                        ProgressForm = Nothing
                    Catch ex As Exception
                        Errors = True
                        mapwinutility.logger.msg("An error has occurred. Processing will continue; the full error text for this operation follows below." + vbCrLf + vbCrLf + ex.ToString())
                    End Try
                Next

            End If
            If Not Errors Then mapwinutility.logger.msg("The grid image(s) were created successfully.", MsgBoxStyle.Information, "MapWindow Tools 3.0")
        End If

        Cleanup()
    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' TITLE: mnuResampleGrids
    ' AUTHOR: Chris Michaelis
    ' DESCRIPTION: Method to resample grids
    '
    ' INPUTS:   None
    '
    ' OUTPUTS: None
    '
    ' NOTES: None
    '
    ' Change Log: 
    ' Date          Changed By      Notes
    ' 11/03/2005    ARA             Added Header
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Sub mnuResampleGrids()
        Dim Errors As Boolean = False
        Dim gridFinder As New frmSelectGrids
        gridFinder.ShowDialog(g_MapWindowForm)

        If g_Grids Is Nothing Then Return

        If g_Grids.Count > 0 Then
            'Haven't cancelled; proceeding.
            Dim resampleOpts As New frmResampleOpts
            resampleOpts.ShowDialog(g_MapWindowForm)

            If Not g_NewCellSize = -1 Then
                'Still haven't canceled. Proceed.
                Dim output As New frmOutput
                output.SetOptionsEnabled(True, True, True, False)
                output.txtName.Text = "(original filename)"
                output.ShowDialog(g_MapWindowForm)

                If Not g_newDataType = MapWinGIS.GridDataType.UnknownDataType _
                 And Not g_newFormat = MapWinGIS.GridFileType.InvalidGridFileType Then
                    Try
                        For j As Integer = 0 To g_Grids.Count - 1
                            Dim ProgressForm As New frmProgress
                            ProgressForm.Owner = g_MapWindowForm
                            ProgressForm.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
                            ProgressForm.Show()

                            ProgressForm.Taskname = "Resampling..."

                            ProgressForm.Filename = CType(g_Grids(j), MapWinGIS.Grid).Filename
                            DoResample(g_Grids(j), g_NewCellSize, CType(ProgressForm, MapWinGIS.ICallback))
                            ProgressForm.CurrentStep += 1
                            Dim filen As String = CType(g_Grids(j), MapWinGIS.Grid).Filename
                            If g_AddOutputToMW Then g_MW.Layers.Add(filen, System.IO.Path.GetFileNameWithoutExtension(filen))
                            ProgressForm.Close()
                            ProgressForm.Dispose()
                            ProgressForm = Nothing
                        Next
                    Catch ex As Exception
                        Errors = True
                        mapwinutility.logger.msg("An error has occurred. Processing will continue; the full error text for this operation follows below." + vbCrLf + vbCrLf + ex.ToString())
                    End Try
                End If
                If Not Errors Then mapwinutility.logger.msg("The grid(s) were resampled successfully.", MsgBoxStyle.Information, "MapWindow Tools 3.0")
            End If
        End If

        Cleanup()
    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' TITLE: mnuMergeGrids
    ' AUTHOR: Chris Michaelis
    ' DESCRIPTION: Method to merge grids
    '
    ' INPUTS:   None
    '
    ' OUTPUTS: None
    '
    ' NOTES: None
    '
    ' Change Log: 
    ' Date          Changed By      Notes
    ' 11/03/2005    ARA             Added Header
    ' 11/15/2006    JLK             Added logging
    ' 11/21/2006    JLK             Use renderer from first grid in new grid
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Sub mnuMergeGrids()
        Dim Errors As Boolean = False
        Logger.Dbg("Start")

        Dim gridFinder As New frmSelectGrids
        If gridFinder.ShowDialog(g_MapWindowForm) = Windows.Forms.DialogResult.Cancel Then
            Logger.Dbg("SelectGrids:UserCancel")
        Else
            If g_Grids Is Nothing OrElse g_Grids.Count = 0 Then
                Logger.Dbg("NoGridsToMerge")
            Else 'Process selected grids
                Logger.Dbg("Merge " & g_Grids.Count & " Grids")
                Dim ProgressForm As New frmProgress
                Try
                    Dim output As New frmOutput
                    output.SetOptionsEnabled(False, True, True, True)
                    output.SetDefaultDataType(CType(g_Grids(0), MapWinGIS.Grid).DataType)
                    output.SetDefaultOutputFormat(System.IO.Path.GetExtension(CType(g_Grids(0), MapWinGIS.Grid).Filename))
                    If output.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                        Logger.Dbg("UserCanceled")
                        Errors = True
                    Else
                        If g_newDataType = MapWinGIS.GridDataType.UnknownDataType Then
                            Logger.Dbg("UnknownDataType")
                        ElseIf g_newFormat = MapWinGIS.GridFileType.InvalidGridFileType Then
                            Logger.Dbg("InvalidGridFileType")
                        Else
                            ProgressForm.Owner = g_MapWindowForm
                            ProgressForm.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
                            ProgressForm.Show()
                            ProgressForm.Taskname = "Merging..."
                            ProgressForm.Filename = g_OutputPath & "\" & g_OutputName & g_newExt
                            ProgressForm.CurrentStep += 1
                            Logger.Dbg("MergeGrids")
                            Dim grd As MapWinGIS.Grid = DoMerge(g_OutputPath & "\" & g_OutputName & g_newExt, _
                                                                CType(ProgressForm, MapWinGIS.ICallback))
                            If grd Is Nothing Then
                                ' The merge function will have displayed an error message. Don't duplicate it here.
                                Logger.Dbg("NoGridCreated")
                                Errors = True
                            Else
                                Logger.Dbg("SaveMergedGrid")
                                ProgressForm.Taskname = "Saving merged grid..."
                                ProgressForm.Filename = g_OutputPath & "\" & g_OutputName & g_newExt
                                grd.Save(g_OutputPath & "\" & g_OutputName & g_newExt, g_newFormat, ProgressForm)

                                Logger.Dbg("CloseNewGrid")
                                grd.Close()

                                If g_AddOutputToMW Then
                                    Logger.Dbg("AddGridToProject")
                                    ProgressForm.Taskname = "Adding Grid to Project"
                                    'Note: The coloring scheme from the original grid (the first input file)
                                    'is already copied at this point -- it was done in the DoMerge() function.
                                    'Therefore when the layer is added, it will be displayed with the same rendering
                                    g_MW.Layers.Add(g_OutputPath & "\" & g_OutputName & g_newExt, g_OutputName, True, True)
                                End If
                            End If
                        End If
                        Logger.Dbg("CloseOldGrids")
                        For q As Integer = 0 To g_Grids.Count - 1
                            CType(g_Grids(q), MapWinGIS.Grid).Close()
                        Next
                        g_Grids.Clear()
                    End If
                Catch ex As Exception
                    Errors = True
                    Logger.Msg("An error has occurred. The full error text for this operation follows below." + vbCrLf + vbCrLf + ex.ToString(), _
                               "GISTools Merge Grids")
                End Try

                ProgressForm.Close()
                ProgressForm.Dispose()
                ProgressForm = Nothing

                If Not Errors Then
                    Logger.Msg("The grid(s) were merged successfully.", _
                               MsgBoxStyle.Information, _
                               "GISTools")
                End If
            End If
        End If
        Cleanup()

    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' TITLE: DoApplyGridProj
    ' AUTHOR: Chris Michaelis
    ' DESCRIPTION: Method to apply grid projection
    '
    ' INPUTS:   None
    '
    ' OUTPUTS: None
    '
    ' NOTES: None
    '
    ' Change Log: 
    ' Date          Changed By      Notes
    ' 11/03/2005    ARA             Added Header
    ' 11/15/2006    JLK             Added logging
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Sub DoApplyGridProj()
        Dim Errors As Boolean = False
        Logger.Dbg("Start")

        Dim gridFinder As New frmSelectGrids
        gridFinder.ShowDialog(g_MapWindowForm)

        If g_Grids Is Nothing OrElse g_Grids.Count = 0 Then
            Logger.Dbg("NoGridsToApplyProjectionTo")
        Else
            'Haven't cancelled; proceeding.
            Dim defaultProjection As String = ""

            'Open the first grid and get it's projection, just to try to give
            'the user the current projection.
            Try
                defaultProjection = CType(g_Grids(0), MapWinGIS.Grid).Header.Projection
                Logger.Dbg("DefaultProjectionSet")
            Catch
                'Noncritical; this is for user friendliness
            End Try

            Dim selectedProjection As String = m_Map.GetProjectionFromUser("Please select the projection to be applied.", defaultProjection)
            Logger.Dbg("ProjectionSelected:'" & selectedProjection & "'")

            If Not selectedProjection = "" Then
                For j As Integer = 0 To g_Grids.Count - 1
                    Try
                        Logger.Dbg("GridProjectionApply " & j + 1 & " " & CType(g_Grids(j), MapWinGIS.Grid).Filename)
                        CType(g_Grids(j), MapWinGIS.Grid).AssignNewProjection(selectedProjection)
                    Catch ex As Exception
                        Errors = True
                        Logger.Msg("An error occurred while applying the specified projection to: " + vbCrLf + CType(g_Grids(j), MapWinGIS.Grid).Filename + vbCrLf + vbCrLf + "The error text is:" + vbCrLf + ex.ToString())
                    End Try
                Next
                If Not Errors Then
                    Logger.Msg("The projection(s) have been applied.", _
                                MsgBoxStyle.Information, _
                                "GISTools")
                End If
            End If
        End If

        Cleanup()
    End Sub

    ''' <summary>
    ''' DoExportSelected                                              
    ''' Exports the selected MapWindow shapes to a new shapefile.
    ''' </summary>
    ''' <remarks>
    ''' By Chris Michaelis Aug 2006
    ''' Change Log: 
    ''' Date          Changed By      Notes
    ''' 08/22/2006    JLK             MsgBox to Logger.Msg, added additional Logger messages
    ''' </remarks>
    Private Sub DoExportSelected()
        Dim lDisplayName As String = "GIS Tools:Export Selected:"
        If mPublics.g_MW.Layers.NumLayers = 0 Then
            Logger.Msg("No layers available to export selected shapes from.", _
                       MsgBoxStyle.Exclamation, _
                       lDisplayName & "No Layers")
            Exit Sub
        End If
        If mPublics.g_MW.View.SelectedShapes.NumSelected = 0 Then
            Logger.Msg("There are no selected features to export! Please select a feature first.", _
                       MsgBoxStyle.Exclamation, _
                       lDisplayName & "Empty Selection")
            Exit Sub
        End If

        Dim saveFileDialog1 As New System.Windows.Forms.SaveFileDialog
        saveFileDialog1.Filter = "Shapefiles (*.shp)|*.shp"
        saveFileDialog1.FilterIndex = 2
        saveFileDialog1.RestoreDirectory = True
        saveFileDialog1.Title = lDisplayName & "Save File Name"
        If saveFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim loadshapefilechoice As Boolean = _
              IIf(mapwinutility.logger.msg("Do you want to load the new shapefile?", _
                  MsgBoxStyle.YesNo, lDisplayName & "Load Layer") _
                  = MsgBoxResult.Yes, True, False)
            Logger.Dbg(lDisplayName & "Start Export of " & _
                       mPublics.g_MW.View.SelectedShapes.NumSelected & _
                       " shapes from file <" & mPublics.g_MW.Layers(mPublics.g_MW.Layers.CurrentLayer).FileName & _
                       "> to file <" & saveFileDialog1.FileName & ">")
            MapWinGeoProc.Selection.ExportSelectedMWViewShapes( _
              mPublics.g_MW, _
              saveFileDialog1.FileName, _
              loadshapefilechoice)
            Logger.Dbg(lDisplayName & "Done")
        Else
            Logger.Dbg(lDisplayName & "User Canceled Save File Dialog")
            Exit Sub
        End If
    End Sub

    ''' <summary>
    ''' DoApplyImageProj                                              
    ''' Opens an instance of frmSelectImages to allow image selection
    ''' Opens a dialog to allow the user to specify a projection
    ''' Creates a prj file with the projection string
    ''' </summary>
    ''' <remarks>
    ''' By Ted Dunsford on 6/27/2006
    ''' Derived from Chris's DoAPplyGridProj
    ''' </remarks>
    Private Sub DoApplyImageProj()
        Dim Errors As Boolean = False
        Dim ImageFinder As New frmSelectImages
        ImageFinder.ShowDialog(g_MapWindowForm)
        Dim img As MapWinGIS.Image

        If g_Images Is Nothing Then Return

        If g_Images.Count > 0 Then
            'Haven't cancelled; proceeding.
            Dim defaultProjection As String = ""

            ''Open the first image and get it's projection, just to try to give
            ''the user the current projection.
            'Try
            '    defaultProjection = CType(g_Grids(0), MapWinGIS.Grid).Header.Projection
            'Catch
            '    'Noncritical; this is for user friendliness
            'End Try

            Dim selectedProjection As String = m_Map.GetProjectionFromUser("Please select the projection to be applied.", defaultProjection)

            If Not selectedProjection = "" Then
                For j As Integer = 0 To g_Images.Count - 1
                    Try
                        'Just paste the text into a file named filename.prj
                        img = g_Images(j)
                        img.SetProjection(selectedProjection)
                    Catch ex As Exception
                        Errors = True
                        Windows.Forms.MessageBox.Show("An error occurred while applying the specified projection to: " + vbCrLf + g_Images(j).Filename + vbCrLf + vbCrLf + "The error text is:" + vbCrLf + ex.ToString())
                    End Try
                Next
                If Not Errors Then mapwinutility.logger.msg("The projection(s) have been applied.", MsgBoxStyle.Information, "Finished")
            End If
        End If
        Cleanup()
    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' TITLE: DoImageReproject
    ' AUTHOR: Ted Dunsford
    ' DESCRIPTION: Method to reproject Images
    ' (This calling method was basically copied from Chris's ReProject Grid code)
    ' This uses the new Projective class in MapWinGeoProc 
    ' and the ProjectImage function stored there
    ' INPUTS:   None
    '
    ' OUTPUTS: None
    '
    ' NOTES: None
    '
    ' Change Log: 
    ' Date          Changed By      Notes
    ' 11/03/2006    Ted           Created initial function
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Sub DoImageReproject()
        Dim Errors As Boolean = False
        Dim imageFinder As New frmSelectImages
        imageFinder.ShowDialog(g_MapWindowForm)

        If g_Images Is Nothing Then Return

        If g_Images.Count > 0 Then
            'Haven't cancelled; proceeding.
            Dim defaultProjection As String = ""

            'Open the first grid and get it's projection, just to try to give
            'the user the current projection.
            Try
                defaultProjection = CType(g_Images(0), MapWinGIS.Grid).Header.Projection
            Catch
                'Noncritical; this is for user friendliness
            End Try

            Dim selectedProjection As String = m_Map.GetProjectionFromUser("Please select the new grid projection.", defaultProjection)

            If Not selectedProjection = "" Then
                For j As Integer = 0 To g_Images.Count - 1
                    Errors = False
                    Try
                        Dim oldProjection As String = CType(g_Images(j), MapWinGIS.Image).GetProjection
                        Dim origFilename As String = CType(g_Images(j), MapWinGIS.Image).Filename


                        Try
                            If System.IO.File.Exists(System.IO.Path.GetDirectoryName(CType(g_Images(j), MapWinGIS.Image).Filename) + IIf(System.IO.Path.GetDirectoryName(CType(g_Images(j), MapWinGIS.Image).Filename).EndsWith("\"), "", "\") + "ErrorLog.txt") Then
                                System.IO.File.Delete(System.IO.File.Exists(System.IO.Path.GetDirectoryName(CType(g_Images(j), MapWinGIS.Image).Filename) + IIf(System.IO.Path.GetDirectoryName(CType(g_Images(j), MapWinGIS.Image).Filename).EndsWith("\"), "", "\") + "ErrorLog.txt"))
                            End If
                        Catch ex As Exception
                        End Try

                        Try
                            CType(g_Images(j), MapWinGIS.Image).Close()
                        Catch
                        End Try

                        If (oldProjection Is Nothing OrElse oldProjection = "" OrElse Not oldProjection.StartsWith("+")) Then
                            'mapwinutility.logger.msg("One of the grids you're attempting to project does not currently have a projection. In order to reproject this file, you must use the following dialog to select the current grid projection." + vbCrLf + vbCrLf + "Please choose the current projection of: " + origFilename, MsgBoxStyle.Exclamation, "No Projection for " + System.IO.Path.GetFileName(origFilename))
                            oldProjection = m_Map.GetProjectionFromUser("The current projection of the file " + System.IO.Path.GetFileName(origFilename) + " cannot be determined." + vbCrLf + "Please select the current projection of the file.", "")

                            'Give up if they fail to provide a projection
                            If oldProjection = "" Then
                                Errors = True 'prevent 'success' message
                                GoTo skip1
                            End If
                        End If

                        Dim newFilename As String = System.IO.Path.ChangeExtension(origFilename, "")
                        If newFilename.EndsWith(".") Then newFilename = newFilename.Substring(0, newFilename.Length - 1)
                        newFilename += "_Reprojected" + System.IO.Path.GetExtension(origFilename)
                        Dim bob As New ProjectionViewer
                        bob.SetProjIn(oldProjection)
                        bob.SetProjOut(selectedProjection)
                        bob.ShowDialog()

                        Dim ProgressForm As New frmProgress
                        ProgressForm.Owner = g_MapWindowForm
                        ProgressForm.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
                        ProgressForm.Show()
                        ProgressForm.Taskname = "Reprojecting..."
                        ProgressForm.Filename = CType(g_Images(j), MapWinGIS.Image).Filename

                        MapWinGeoProc.SpatialReference.ProjectImage(oldProjection, selectedProjection, origFilename, newFilename, Nothing)

                        ProgressForm.CurrentStep += 1
                        ProgressForm.Close()
                        ProgressForm.Dispose()
                        ProgressForm = Nothing

                        Dim newImg As New MapWinGIS.Image
                        newImg.Open(newFilename)

                        g_Images(j) = newImg

                        If Not CType(g_Images(j), MapWinGIS.Image).Filename = "" Then
                            If System.IO.File.Exists(System.IO.Path.GetDirectoryName(CType(g_Images(j), MapWinGIS.Image).Filename) + IIf(System.IO.Path.GetDirectoryName(CType(g_Images(j), MapWinGIS.Image).Filename).EndsWith("\"), "", "\") + "ErrorLog.txt") Then
                                Errors = True
                                mapwinutility.logger.msg("One or more errors occurred during reprojection. Please see the file:" + vbCrLf + System.IO.Path.GetDirectoryName(CType(g_Images(j), MapWinGIS.Image).Filename) + IIf(System.IO.Path.GetDirectoryName(CType(g_Images(j), MapWinGIS.Image).Filename).EndsWith("\"), "", "\") + "ErrorLog.txt" + vbCrLf + "for more information.")
                            End If
                        End If

                        CType(g_Images(j), MapWinGIS.Image).Close()

                        If Not Errors And System.IO.File.Exists(newFilename) Then
                            If mapwinutility.logger.msg("The reprojection of " + System.IO.Path.GetFileName(origFilename) + " has completed." + vbCrLf + vbCrLf + "The reprojected file is called " + System.IO.Path.GetFileName(newFilename) + "." + vbCrLf + vbCrLf + "Add it to the map now?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Finished! Add to map?") = MsgBoxResult.Yes Then
                                m_Map.Layers.Add(newFilename)
                            End If
                        End If
                    Catch ex As Exception
                        'If Not g_Images(j).Filename = "" Then
                        Windows.Forms.MessageBox.Show("An error occurred while reprojecting the grid(s): " + vbCrLf + vbCrLf + "The error text is:" + vbCrLf + ex.ToString())
                        'If System.IO.File.Exists(System.IO.Path.GetDirectoryName(CType(g_Images(j), MapWinGIS.Image).Filename) + IIf(System.IO.Path.GetDirectoryName(CType(g_Images(j), MapWinGIS.Image).Filename).EndsWith("\"), "", "\") + "ErrorLog.txt") Then
                        'Errors = True
                        'mapwinutility.logger.msg("One or more errors occurred during reprojection. Please see the file:" + vbCrLf + System.IO.Path.GetDirectoryName(CType(g_Images(j), MapWinGIS.Image).Filename) + IIf(System.IO.Path.GetDirectoryName(CType(g_Images(j), MapWinGIS.Image).Filename).EndsWith("\"), "", "\") + "ErrorLog.txt" + vbCrLf + "for more information.")
                        'End If
                        'End If
                    End Try

skip1:
                Next
            End If
        End If

        Cleanup()
    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' TITLE: DoRectifyToWorldfile
    ' AUTHOR: Ted Dunsford
    ' DESCRIPTION: Since MapWindow can't do skew or rotation from a world file on the fly
    ' this function creates a modified image that will match the affine skew/rotate.
    ' Depends SpatialReferencing tools in MapWinGeoProc.
    ' This also uses the new Projective class in MapWinGeoProc 
    ' and the ProjectImage function stored there
    ' INPUTS:   None
    '
    ' OUTPUTS: None
    '
    ' NOTES: None
    '
    ' Change Log: 
    ' Date          Changed By      Notes
    ' 11/04/2006    Ted           Created initial function
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Sub DoRectifyToWorldfile()
        Dim Errors As Boolean = False
        Dim imageFinder As New frmSelectImages
        imageFinder.ShowDialog(g_MapWindowForm)

        If g_Images Is Nothing Then Return

        If g_Images.Count > 0 Then
            
            For j As Integer = 0 To g_Images.Count - 1
                Errors = False
                Try
                    
                    Try
                        If System.IO.File.Exists(System.IO.Path.GetDirectoryName(CType(g_Images(j), MapWinGIS.Image).Filename) + IIf(System.IO.Path.GetDirectoryName(CType(g_Images(j), MapWinGIS.Image).Filename).EndsWith("\"), "", "\") + "ErrorLog.txt") Then
                            System.IO.File.Delete(System.IO.File.Exists(System.IO.Path.GetDirectoryName(CType(g_Images(j), MapWinGIS.Image).Filename) + IIf(System.IO.Path.GetDirectoryName(CType(g_Images(j), MapWinGIS.Image).Filename).EndsWith("\"), "", "\") + "ErrorLog.txt"))
                        End If
                    Catch ex As Exception
                    End Try

                    Try
                        CType(g_Images(j), MapWinGIS.Image).Close()
                    Catch
                    End Try

                    Dim origFilename As String = CType(g_Images(j), MapWinGIS.Image).Filename
                    Dim newFilename As String = System.IO.Path.ChangeExtension(origFilename, "")
                    If newFilename.EndsWith(".") Then newFilename = newFilename.Substring(0, newFilename.Length - 1)
                    newFilename += "_Rect" + System.IO.Path.GetExtension(origFilename)

                    Dim ProgressForm As New frmProgress
                    ProgressForm.Owner = g_MapWindowForm
                    ProgressForm.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
                    ProgressForm.Show()
                    ProgressForm.Taskname = "Rectifying..."
                    ProgressForm.Filename = CType(g_Images(j), MapWinGIS.Image).Filename

                    MapWinGeoProc.SpatialReference.RectifyToWorldFile(origFilename, newFilename, CType(ProgressForm, MapWinGIS.ICallback))

                    ProgressForm.CurrentStep += 1
                    ProgressForm.Close()
                    ProgressForm.Dispose()
                    ProgressForm = Nothing

                    Dim newImg As New MapWinGIS.Image
                    newImg.Open(newFilename)

                    g_Images(j) = newImg

                    If Not CType(g_Images(j), MapWinGIS.Image).Filename = "" Then
                        If System.IO.File.Exists(System.IO.Path.GetDirectoryName(CType(g_Images(j), MapWinGIS.Image).Filename) + IIf(System.IO.Path.GetDirectoryName(CType(g_Images(j), MapWinGIS.Image).Filename).EndsWith("\"), "", "\") + "ErrorLog.txt") Then
                            Errors = True
                            mapwinutility.logger.msg("One or more errors occurred during rectification. Please see the file:" + vbCrLf + System.IO.Path.GetDirectoryName(CType(g_Images(j), MapWinGIS.Image).Filename) + IIf(System.IO.Path.GetDirectoryName(CType(g_Images(j), MapWinGIS.Image).Filename).EndsWith("\"), "", "\") + "ErrorLog.txt" + vbCrLf + "for more information.")
                        End If
                    End If

                    CType(g_Images(j), MapWinGIS.Image).Close()

                    If Not Errors And System.IO.File.Exists(newFilename) Then
                        If mapwinutility.logger.msg("The reprojection of " + System.IO.Path.GetFileName(origFilename) + " has completed." + vbCrLf + vbCrLf + "The reprojected file is called " + System.IO.Path.GetFileName(newFilename) + "." + vbCrLf + vbCrLf + "Add it to the map now?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Finished! Add to map?") = MsgBoxResult.Yes Then
                            m_Map.Layers.Add(newFilename)
                        End If
                    End If
                Catch ex As Exception
                    'If Not g_Images(j).Filename = "" Then
                    Windows.Forms.MessageBox.Show("An error occurred while reprojecting the grid(s): " + vbCrLf + vbCrLf + "The error text is:" + vbCrLf + ex.ToString())
                    'If System.IO.File.Exists(System.IO.Path.GetDirectoryName(CType(g_Images(j), MapWinGIS.Image).Filename) + IIf(System.IO.Path.GetDirectoryName(CType(g_Images(j), MapWinGIS.Image).Filename).EndsWith("\"), "", "\") + "ErrorLog.txt") Then
                    'Errors = True
                    'mapwinutility.logger.msg("One or more errors occurred during reprojection. Please see the file:" + vbCrLf + System.IO.Path.GetDirectoryName(CType(g_Images(j), MapWinGIS.Image).Filename) + IIf(System.IO.Path.GetDirectoryName(CType(g_Images(j), MapWinGIS.Image).Filename).EndsWith("\"), "", "\") + "ErrorLog.txt" + vbCrLf + "for more information.")
                    'End If
                    'End If
                End Try

skip1:
            Next
        End If

        Cleanup()
    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' TITLE: DoApplySFProj
    ' AUTHOR: Chris Michaelis
    ' DESCRIPTION: Method to apply shapefile projection
    '
    ' INPUTS:   None
    '
    ' OUTPUTS: None
    '
    ' NOTES: None
    '
    ' Change Log: 
    ' Date          Changed By      Notes
    ' 11/03/2005    ARA             Added Header
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Sub DoApplySFProj()
        Dim Errors As Boolean = False
        Dim shpfileFinder As New Windows.Forms.OpenFileDialog
        shpfileFinder.Filter = "Shapefiles (*.shp)|*.shp"
        shpfileFinder.Multiselect = True
        shpfileFinder.ShowDialog(g_MapWindowForm)

        If shpfileFinder.FileNames.Length > 0 Then

            Dim defaultProjection As String = ""
            'Open the first SF and get it's projection, just to try to give
            'the user the current projection.
            Try
                If (System.IO.File.Exists(shpfileFinder.FileNames(0))) Then
                    Dim gp_sf As New MapWinGIS.Shapefile
                    gp_sf.Open(shpfileFinder.FileNames(0))
                    defaultProjection = gp_sf.Projection
                    gp_sf.Close()
                End If
            Catch
                'Noncritical; this is for user friendliness
            End Try

            Dim selectedProjection As String = m_Map.GetProjectionFromUser("Please select the projection to be applied.", defaultProjection)
            If Not selectedProjection = "" Then
                Dim filen As String
                For Each filen In shpfileFinder.FileNames
                    If (System.IO.File.Exists(filen)) Then
                        Try
                            Dim sf As New MapWinGIS.Shapefile
                            sf.Open(filen, Nothing)
                            sf.Projection = selectedProjection
                            sf.Close()
                        Catch ex As Exception
                            Errors = True
                            Windows.Forms.MessageBox.Show("An error occurred while applying the specified projection to: " + vbCrLf + filen + vbCrLf + vbCrLf + "The error text is:" + vbCrLf + ex.ToString())
                        End Try
                    End If
                Next

                If Not Errors Then mapwinutility.logger.msg("The projection(s) have been applied.", MsgBoxStyle.Information, "Finished")
            End If
        End If

        Cleanup()
    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' TITLE: DoGridReproject
    ' AUTHOR: Chris Michaelis
    ' DESCRIPTION: Method to reproject Grid
    '
    ' INPUTS:   None
    '
    ' OUTPUTS: None
    '
    ' NOTES: None
    '
    ' Change Log: 
    ' Date          Changed By      Notes
    ' 11/03/2005    ARA             Added Header
    ' 11/15/2006    JLK             Added logging
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Sub DoGridReproject()
        Dim Errors As Boolean = False
        Logger.Dbg("Start")

        Dim gridFinder As New frmSelectGrids
        gridFinder.ShowDialog(g_MapWindowForm)

        If g_Grids Is Nothing OrElse g_Grids.Count = 0 Then
            Logger.Dbg("NoGridsToProject")
        Else
            'Haven't cancelled; proceeding.
            Dim defaultProjection As String = ""

            'Open the first grid and get it's projection, just to try to give
            'the user the current projection.
            Try
                defaultProjection = CType(g_Grids(0), MapWinGIS.Grid).Header.Projection
                Logger.Dbg("DefaultProjectionSet")
            Catch
                'Noncritical; this is for user friendliness
            End Try

            Dim selectedProjection As String = m_Map.GetProjectionFromUser("Please select the new grid projection.", defaultProjection)
            Logger.Dbg("ProjectionSelected:'" & selectedProjection & "'")

            If Not selectedProjection = "" Then
                For j As Integer = 0 To g_Grids.Count - 1
                    Errors = False
                    Try
                        Logger.Dbg("GridProject " & j + 1 & " " & CType(g_Grids(j), MapWinGIS.Grid).Filename)
                        Dim oldProjection As String = CType(g_Grids(j), MapWinGIS.Grid).Header.Projection
                        Dim origFilename As String = CType(g_Grids(j), MapWinGIS.Grid).Filename

                        Try
                            If System.IO.File.Exists(System.IO.Path.GetDirectoryName(CType(g_Grids(j), MapWinGIS.Grid).Filename) + IIf(System.IO.Path.GetDirectoryName(CType(g_Grids(j), MapWinGIS.Grid).Filename).EndsWith("\"), "", "\") + "ErrorLog.txt") Then
                                System.IO.File.Delete(System.IO.File.Exists(System.IO.Path.GetDirectoryName(CType(g_Grids(j), MapWinGIS.Grid).Filename) + IIf(System.IO.Path.GetDirectoryName(CType(g_Grids(j), MapWinGIS.Grid).Filename).EndsWith("\"), "", "\") + "ErrorLog.txt"))
                            End If
                        Catch ex As Exception
                        End Try

                        Try
                            CType(g_Grids(j), MapWinGIS.Grid).Close()
                        Catch
                        End Try

                        If (oldProjection Is Nothing OrElse _
                            oldProjection = "" OrElse _
                            Not oldProjection.StartsWith("+")) Then
                            'mapwinutility.logger.msg("One of the grids you're attempting to project does not currently have a projection. In order to reproject this file, you must use the following dialog to select the current grid projection." + vbCrLf + vbCrLf + "Please choose the current projection of: " + origFilename, MsgBoxStyle.Exclamation, "No Projection for " + System.IO.Path.GetFileName(origFilename))
                            oldProjection = m_Map.GetProjectionFromUser("The current projection of the file " + System.IO.Path.GetFileName(origFilename) + " cannot be determined." + vbCrLf + "Please select the current projection of the file.", "")

                            'Give up if they fail to provide a projection
                            If oldProjection = "" Then
                                Errors = True 'prevent 'success' message
                                GoTo skip1
                            End If
                        End If

                        Dim newFilename As String = System.IO.Path.ChangeExtension(origFilename, "")
                        If newFilename.EndsWith(".") Then
                            newFilename = newFilename.Substring(0, newFilename.Length - 1)
                        End If
                        newFilename += "_Reprojected" + System.IO.Path.GetExtension(origFilename)

                        Logger.Dbg("OrigFileName " & origFilename)
                        Logger.Dbg("OldProjection " & oldProjection)
                        Logger.Dbg("newFilename " & newFilename)
                        Logger.Dbg("selectedProjection " & selectedProjection)
                        MapWinGeoProc.SpatialReference.ProjectGrid(oldProjection, selectedProjection, origFilename, newFilename, True)

                        Dim newGrd As New MapWinGIS.Grid
                        newGrd.Open(newFilename)
                        newGrd.AssignNewProjection(selectedProjection)

                        g_Grids(j) = newGrd

                        If Not CType(g_Grids(j), MapWinGIS.Grid).Filename = "" Then
                            If System.IO.File.Exists(System.IO.Path.GetDirectoryName(CType(g_Grids(j), MapWinGIS.Grid).Filename) + IIf(System.IO.Path.GetDirectoryName(CType(g_Grids(j), MapWinGIS.Grid).Filename).EndsWith("\"), "", "\") + "ErrorLog.txt") Then
                                Errors = True
                                Logger.Msg("One or more errors occurred during reprojection. Please see the file:" + vbCrLf + System.IO.Path.GetDirectoryName(CType(g_Grids(j), MapWinGIS.Grid).Filename) + IIf(System.IO.Path.GetDirectoryName(CType(g_Grids(j), MapWinGIS.Grid).Filename).EndsWith("\"), "", "\") + "ErrorLog.txt" + vbCrLf + "for more information.")
                            End If
                        End If

                        CType(g_Grids(j), MapWinGIS.Grid).Close()

                        If Not Errors And System.IO.File.Exists(newFilename) Then
                            If Logger.Msg("The reprojection of " + System.IO.Path.GetFileName(origFilename) + " has completed." + vbCrLf + vbCrLf + "The reprojected file is called " + System.IO.Path.GetFileName(newFilename) + "." + vbCrLf + vbCrLf + "Add it to the map now?", _
                                          MsgBoxStyle.Question + MsgBoxStyle.YesNo, _
                                          "Finished! Add to map?") = MsgBoxResult.Yes Then
                                m_Map.Layers.Add(newFilename)
                            End If
                        End If
                    Catch ex As Exception
                        'If Not g_Grids(j).Filename = "" Then
                        Logger.Msg("An error occurred while reprojecting the grid(s): " + vbCrLf + vbCrLf + "The error text is:" + vbCrLf + ex.ToString())
                        'If System.IO.File.Exists(System.IO.Path.GetDirectoryName(CType(g_Grids(j), MapWinGIS.Grid).Filename) + IIf(System.IO.Path.GetDirectoryName(CType(g_Grids(j), MapWinGIS.Grid).Filename).EndsWith("\"), "", "\") + "ErrorLog.txt") Then
                        'Errors = True
                        'mapwinutility.logger.msg("One or more errors occurred during reprojection. Please see the file:" + vbCrLf + System.IO.Path.GetDirectoryName(CType(g_Grids(j), MapWinGIS.Grid).Filename) + IIf(System.IO.Path.GetDirectoryName(CType(g_Grids(j), MapWinGIS.Grid).Filename).EndsWith("\"), "", "\") + "ErrorLog.txt" + vbCrLf + "for more information.")
                        'End If
                        'End If
                    End Try

skip1:
                Next
            End If
        End If

        Cleanup()
    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' TITLE: DoSFReproject
    ' AUTHOR: Chris Michaelis
    ' DESCRIPTION: Method to Reproject shapefile
    '
    ' INPUTS:   None
    '
    ' OUTPUTS: None
    '
    ' NOTES: None
    '
    ' Change Log: 
    ' Date          Changed By      Notes
    ' 11/03/2005    ARA             Added Header
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Sub DoSFReproject()
        Dim Errors As Boolean = False
        Dim shpfileFinder As New Windows.Forms.OpenFileDialog
        shpfileFinder.Filter = "Shapefiles (*.shp)|*.shp"
        shpfileFinder.Multiselect = True
        shpfileFinder.ShowDialog(g_MapWindowForm)

        If shpfileFinder.FileNames.Length > 0 Then
            Dim defaultPRojection As String = ""
            'Open the first SF and get it's projection, just to try to give
            'the user the current projection.
            Try
                If (System.IO.File.Exists(shpfileFinder.FileNames(0))) Then
                    Dim gp_sf As New MapWinGIS.Shapefile
                    gp_sf.Open(shpfileFinder.FileNames(0))
                    Try
                        defaultPRojection = gp_sf.Projection
                    Catch
                        defaultPRojection = ""
                    End Try
                    gp_sf.Close()
                End If
            Catch
                'Noncritical; this is for user friendliness
            End Try

            Dim selectedProjection As String = m_Map.GetProjectionFromUser("Please select the projection to be applied.", defaultPRojection)

            If Not selectedProjection = "" Then
                Dim filen As String
                For Each filen In shpfileFinder.FileNames
                    Errors = False

                    Try
                        If System.IO.File.Exists(System.IO.Path.GetDirectoryName(filen) + IIf(System.IO.Path.GetDirectoryName(filen).EndsWith("\"), "", "\") + "ErrorLog.txt") Then
                            System.IO.File.Delete(System.IO.File.Exists(System.IO.Path.GetDirectoryName(filen) + IIf(System.IO.Path.GetDirectoryName(filen).EndsWith("\"), "", "\") + "ErrorLog.txt"))
                        End If
                    Catch ex As Exception
                    End Try

                    If (System.IO.File.Exists(filen)) Then
                        Try
                            Dim sf As New MapWinGIS.Shapefile
                            sf.Open(filen)

                            Dim oldProjection As String = ""
                            Try
                                oldProjection = sf.Projection
                            Catch
                                oldProjection = ""
                            End Try

                            sf.Close()


                            If (oldProjection Is Nothing OrElse oldProjection = "" OrElse Not oldProjection.StartsWith("+")) Then
                                'mapwinutility.logger.msg("One of the grids you're attempting to project does not currently have a projection. In order to reproject this file, you must use the following dialog to select the current grid projection." + vbCrLf + vbCrLf + "Please choose the current projection of: " + origFilename, MsgBoxStyle.Exclamation, "No Projection for " + System.IO.Path.GetFileName(origFilename))
                                oldProjection = m_Map.GetProjectionFromUser("The current projection of the file " + System.IO.Path.GetFileName(filen) + " cannot be determined." + vbCrLf + "Please select the current projection of the file.", "")

                                'Give up if they fail to provide a projection
                                If oldProjection = "" Then
                                    Errors = True 'prevent 'success' message
                                    GoTo skip1
                                End If
                            End If

                            Dim newFilename As String = System.IO.Path.ChangeExtension(filen, "")
                            If newFilename.EndsWith(".") Then newFilename = newFilename.Substring(0, newFilename.Length - 1)
                            newFilename += "_Reprojected" + System.IO.Path.GetExtension(filen)
                            MapWinGeoProc.SpatialReference.ProjectShapefile(oldProjection, selectedProjection, filen, newFilename)

                            Dim newsf As New MapWinGIS.Shapefile
                            newsf.Open(newFilename)
                            newsf.Projection = selectedProjection

                            newsf.Close()

                            If Not filen = "" Then
                                If System.IO.File.Exists(System.IO.Path.GetDirectoryName(filen) + IIf(System.IO.Path.GetDirectoryName(filen).EndsWith("\"), "", "\") + "ErrorLog.txt") Then
                                    Errors = True
                                    mapwinutility.logger.msg("One or more errors occurred during reprojection. Please see the file:" + vbCrLf + System.IO.Path.GetDirectoryName(filen) + IIf(System.IO.Path.GetDirectoryName(filen).EndsWith("\"), "", "\") + "ErrorLog.txt" + vbCrLf + "for more information.")
                                End If
                            End If

                            If Not Errors And System.IO.File.Exists(newFilename) Then
                                If MapWinUtility.Logger.Msg("The reprojection of " + System.IO.Path.GetFileName(filen) + " has completed." + vbCrLf + vbCrLf + "The reprojected file is called " + System.IO.Path.GetFileName(newFilename) + "." + vbCrLf + vbCrLf + "Add it to the map now?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Finished! Add to map?") = MsgBoxResult.Yes Then
                                    m_Map.Layers.Add(newFilename)
                                End If
                            End If
                        Catch ex As Exception
                            'Windows.Forms.MessageBox.Show("An error occurred while reprojecting the shapefile: " + vbCrLf + filen + vbCrLf + vbCrLf + "The error text is:" + vbCrLf + ex.ToString())
                            If Not filen = "" Then
                                If System.IO.File.Exists(System.IO.Path.GetDirectoryName(filen) + IIf(System.IO.Path.GetDirectoryName(filen).EndsWith("\"), "", "\") + "ErrorLog.txt") Then
                                    Errors = True
                                    MapWinUtility.Logger.Msg("One or more errors occurred during reprojection. Please see the file:" + vbCrLf + System.IO.Path.GetDirectoryName(filen) + IIf(System.IO.Path.GetDirectoryName(filen).EndsWith("\"), "", "\") + "ErrorLog.txt" + vbCrLf + "for more information.")
                                End If
                            End If
                        End Try
                    End If
skip1:
                Next
            End If
        End If

            Cleanup()
    End Sub

    Private Sub mnuClipWithPoly(ByVal clipType As Integer)
        Dim frmClipping As New frmClip
        frmClipping.Initialize(clipType)
        frmClipping.Show()
    End Sub

    Private Sub mnuClipPolyWLine()
        Dim frmClipping As New frmClipPolyWLine
        frmClipping.Initialize()
        frmClipping.Show()
    End Sub

    Private Sub mnuMerge()
        Dim frmMergeShapes As New frmMerge
        frmMergeShapes.Initialize()
        frmMergeShapes.Show()
    End Sub

    Private Sub mnuIdentity()
        Dim frmIdentity As New frmIdentity
        frmIdentity.Initialize()
        frmIdentity.Show()

    End Sub
End Class
