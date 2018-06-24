Imports System.Drawing
Imports System.Xml
Imports MapWinUtility

Module mPublics

    Public g_MW As MapWindow.Interfaces.IMapWin
    Public g_MWMenus As clsMenus
    Public g_MapWindowForm As System.Windows.Forms.Form
    Public g_Grids As New ArrayList()
    Public g_Images As New ArrayList()
    Public g_NewCellSize As Double
    Public g_Scheme As New MapWinGIS.GridColorScheme
    Public g_newDataType As MapWinGIS.GridDataType
    Public g_newFormat As MapWinGIS.GridFileType
    Public g_newExt As String
    Public g_AddOutputToMW As Boolean
    Public g_OutputPath As String
    Public g_OutputName As String
    Public g_georef_form As New frmGeoreference
    Public g_exportbymask_form As New frmExportByMask()

    Public Sub Cleanup()
        On Error Resume Next
        g_MapWindowForm.BringToFront()
        g_MapWindowForm.Focus()
        g_Grids.Clear()
        g_Grids = Nothing
        g_Images.Clear()
        g_Images = Nothing
        g_NewCellSize = -1
        g_Scheme = Nothing
        g_newDataType = MapWinGIS.GridDataType.UnknownDataType
        g_newFormat = MapWinGIS.GridFileType.InvalidGridFileType
        g_newExt = ""
        g_AddOutputToMW = True
    End Sub

    Public Function ColorToInteger(ByVal c As Color) As Integer
        Return RGB(c.R, c.G, c.B)
    End Function

    Public Function ColorToUInteger(ByVal c As Color) As UInt32
        Return System.Convert.ToUInt32(RGB(c.R, c.G, c.B))
    End Function

    Public Function IntegerToColor(ByVal IntColor As UInt32) As Color
        Dim r, g, b As Integer
        GetRGB(System.Convert.ToInt32(IntColor), r, g, b)
        Return Color.FromArgb(255, r, g, b)
    End Function

    Public Function IntegerToColor(ByVal IntColor As Integer) As Color
        Dim r, g, b As Integer
        GetRGB(IntColor, r, g, b)
        Return Color.FromArgb(255, r, g, b)
    End Function

    Public Sub GetRGB(ByVal color As Integer, ByRef r As Integer, ByRef g As Integer, ByRef b As Integer)
        r = color And &HFF
        g = (color And &HFF00) / 256 'shift right 8 bits
        b = (color And &HFF0000) / 65536 ' shift right 16 bits
    End Sub

    Friend Function ImportScheme(ByVal Filename As String) As Object
        Dim doc As New XmlDocument
        Dim root As XmlElement = Nothing

        Try
            Dim sch As New MapWinGIS.GridColorScheme
            If root.Attributes("SchemeType").InnerText = "Grid" Then
                If ImportScheme(sch, root.Item("GridColoringScheme")) Then
                    Return sch
                End If
            Else
                mapwinutility.logger.msg("File contains invalid coloring scheme type.")
                Return Nothing
            End If

        Catch ex As Exception
            MapWinUtility.Logger.Msg("Failed to import color scheme")
            Return Nothing
        End Try
        Return Nothing
    End Function

    Private Function ImportScheme(ByRef sch As MapWinGIS.GridColorScheme, ByVal e As XmlElement) As Boolean
        Dim i As Integer
        Dim brk As MapWinGIS.GridColorBreak
        Dim t As String
        Dim azimuth, elevation As Double
        Dim n As XmlNode

        If e Is Nothing Then Return False

        sch.Key = e.Attributes("Key").InnerText
        t = e.Attributes("AmbientIntensity").InnerText
        sch.AmbientIntensity = IIf(IsNumeric(t), CDbl(t), 0.7)
        t = e.Attributes("LightSourceAzimuth").InnerText
        azimuth = IIf(IsNumeric(t), CDbl(t), 90)
        t = e.Attributes("LightSourceElevation").InnerText
        elevation = IIf(IsNumeric(t), CDbl(t), 45)
        sch.SetLightSource(azimuth, elevation)
        t = e.Attributes("LightSourceIntensity").InnerText
        sch.LightSourceIntensity = IIf(IsNumeric(t), CDbl(t), 0.7)

        For i = 0 To e.ChildNodes.Count - 1
            n = e.ChildNodes(i)
            brk = New MapWinGIS.GridColorBreak
            brk.Caption = n.Attributes("Caption").InnerText
            brk.LowColor = ColorToUInteger(Color.FromArgb(n.Attributes("LowColor").InnerText))
            brk.HighColor = ColorToUInteger(Color.FromArgb(n.Attributes("HighColor").InnerText))
            brk.LowValue = n.Attributes("LowValue").InnerText
            brk.HighValue = n.Attributes("HighValue").InnerText
            brk.ColoringType = n.Attributes("ColoringType").InnerText
            brk.GradientModel = n.Attributes("GradientModel").InnerText
            sch.InsertBreak(brk)
        Next
        Return True
    End Function

    Friend Function ExportScheme(ByVal Path As String, ByVal Scheme As MapWinGIS.GridColorScheme) As Boolean
        Dim doc As New XmlDocument
        Dim mainScheme, root As XmlElement
        Dim schemeType As XmlAttribute
        root = doc.CreateElement("ColoringScheme")

        Dim AmbientIntensity, Key, LightSourceAzimuth As XmlAttribute
        Dim LightSourceElevation, LightSourceIntensity, NoDataColor As XmlAttribute

        If Scheme Is Nothing OrElse Scheme.NumBreaks = 0 Then Return False
        schemeType = doc.CreateAttribute("SchemeType")
        schemeType.InnerText = "Grid"
        root.Attributes.Append(schemeType)
        AmbientIntensity = doc.CreateAttribute("AmbientIntensity")
        Key = doc.CreateAttribute("Key")
        LightSourceAzimuth = doc.CreateAttribute("LightSourceAzimuth")
        LightSourceElevation = doc.CreateAttribute("LightSourceElevation")
        LightSourceIntensity = doc.CreateAttribute("LightSourceIntensity")
        NoDataColor = doc.CreateAttribute("NoDataColor")
        AmbientIntensity.InnerText = Scheme.AmbientIntensity
        Key.InnerText = Scheme.Key
        LightSourceAzimuth.InnerText = Scheme.LightSourceAzimuth
        LightSourceElevation.InnerText = Scheme.LightSourceElevation
        LightSourceIntensity.InnerText = Scheme.LightSourceIntensity
        NoDataColor.InnerText = IntegerToColor(Scheme.NoDataColor).ToArgb

        mainScheme = doc.CreateElement("GridColoringScheme")
        mainScheme.Attributes.Append(AmbientIntensity)
        mainScheme.Attributes.Append(Key)
        mainScheme.Attributes.Append(LightSourceAzimuth)
        mainScheme.Attributes.Append(LightSourceElevation)
        mainScheme.Attributes.Append(LightSourceIntensity)
        mainScheme.Attributes.Append(NoDataColor)
        root.AppendChild(mainScheme)
        doc.AppendChild(root)
        If ExportScheme(Scheme, doc, mainScheme) Then
            doc.Save(Path)
            Return True
        Else
            MapWinUtility.Logger.Msg("Failed to export coloring scheme.", MsgBoxStyle.Exclamation, "Error")
            Return False
        End If
    End Function

    Public Function ExportScheme(ByVal Scheme As MapWinGIS.GridColorScheme, ByVal RootDoc As XmlDocument, ByVal Parent As XmlElement) As Boolean
        Dim i As Integer
        Dim brk As XmlElement
        Dim caption As XmlAttribute
        Dim sValue As XmlAttribute
        Dim eValue As XmlAttribute
        Dim sColor As XmlAttribute
        Dim eColor As XmlAttribute
        Dim coloringType As XmlAttribute
        Dim gradientModel As XmlAttribute
        Dim curBrk As MapWinGIS.GridColorBreak

        If Scheme Is Nothing OrElse Scheme.NumBreaks = 0 Then Return False

        For i = 0 To Scheme.NumBreaks - 1
            curBrk = Scheme.Break(i)
            brk = RootDoc.CreateElement("Break")
            caption = RootDoc.CreateAttribute("Caption")
            sValue = RootDoc.CreateAttribute("LowValue")
            eValue = RootDoc.CreateAttribute("HighValue")
            sColor = RootDoc.CreateAttribute("LowColor")
            eColor = RootDoc.CreateAttribute("HighColor")
            coloringType = RootDoc.CreateAttribute("ColoringType")
            gradientModel = RootDoc.CreateAttribute("GradientModel")
            caption.InnerText = curBrk.Caption
            sValue.InnerText = curBrk.LowValue
            eValue.InnerText = curBrk.HighValue
            sColor.InnerText = IntegerToColor(curBrk.LowColor).ToArgb
            eColor.InnerText = IntegerToColor(curBrk.HighColor).ToArgb
            coloringType.InnerText = curBrk.ColoringType
            gradientModel.InnerText = curBrk.GradientModel
            brk.Attributes.Append(caption)
            brk.Attributes.Append(sValue)
            brk.Attributes.Append(eValue)
            brk.Attributes.Append(sColor)
            brk.Attributes.Append(eColor)
            brk.Attributes.Append(coloringType)
            brk.Attributes.Append(gradientModel)
            Parent.AppendChild(brk)
            curBrk = Nothing
        Next
        Return True
    End Function

    Public Function DoResample(ByRef grd As MapWinGIS.Grid, ByVal CellSize As Double, ByRef Progress As MapWinGIS.ICallback) As Boolean
        Dim i, j As Integer
        Dim newGrid As New MapWinGIS.Grid
        Dim newHeader As New MapWinGIS.GridHeader
        Dim numCols, numRows As Integer
        Dim absLeft, absRight, absBottom, absTop As Double
        Dim halfDX, halfDY As Double
        Dim tX, tY, oldX, oldY, nDX, cDX As Double

        Dim newFilen As String = System.IO.Path.GetFileName(grd.Filename)

        Try
            With newHeader
                numCols = Int((grd.Header.dX * grd.Header.NumberCols) / CellSize)
                numRows = Int((grd.Header.dY * grd.Header.NumberRows) / CellSize)

                absLeft = grd.Header.XllCenter - (grd.Header.dX / 2)
                absBottom = grd.Header.YllCenter - (grd.Header.dY / 2)
                absRight = absLeft + (grd.Header.dX * grd.Header.NumberCols)
                absTop = absBottom + (grd.Header.dY * grd.Header.NumberRows)

                newHeader.NumberCols = numCols
                newHeader.NumberRows = numRows
                newHeader.dX = CellSize
                newHeader.dY = CellSize
                newHeader.XllCenter = absLeft + (CellSize / 2)
                newHeader.YllCenter = absBottom + (CellSize / 2)
                newHeader.NodataValue = grd.Header.NodataValue
                newHeader.Notes = grd.Header.Notes
                newHeader.Key = grd.Header.Key
                newHeader.Projection = grd.Header.Projection

                If newGrid.CreateNew(g_OutputPath + "\" + newFilen, newHeader, g_newDataType, grd.Header.NodataValue, True, g_newFormat) = False Then
                    Return False
                End If

                halfDX = newHeader.dX * 0.5
                halfDY = newHeader.dY * 0.5

                For j = 0 To numRows - 1
                    tY = absTop - (j * newHeader.dY) - halfDY
                    Progress.Progress(grd.Filename, j / numRows * 100, "Resampling " & grd.Filename & " row " & j)

                    nDX = newHeader.dX
                    cDX = grd.Header.dX

                    oldY = Int(grd.Header.NumberRows - ((tY - absBottom) / grd.Header.dY))

                    For i = 0 To numCols - 1
                        tX = absLeft + (i * nDX) + halfDX
                        oldX = Int((tX - absLeft) / cDX)
                        newGrid.Value(i, j) = grd.Value(oldX, oldY)
                    Next i
                Next j
            End With

            grd.Close()
            grd = newGrid
            grd.Save(g_OutputPath + "\" + newFilen, g_newFormat, Progress)

        Catch ex As Exception
            MapWinUtility.Logger.Msg(ex.Message & vbCrLf & ex.StackTrace, MsgBoxStyle.Critical Or MsgBoxStyle.Information, "Grid Wizard 2.0 - Error")

        End Try
    End Function

    Public Function DoMerge(ByVal NewFilename As String, ByRef Progress As MapWinGIS.ICallback) As MapWinGIS.Grid
        Dim merger As New MapWinGIS.Utils
        Dim tGrids(), newGrid As MapWinGIS.Grid

        Logger.Dbg("OutputGridName: " & NewFilename & " Format: " & g_newFormat.ToString)
        Logger.Dbg("InputGridCount: " & g_Grids.Count)

        ReDim tGrids(g_Grids.Count - 1)
        tGrids = g_Grids.ToArray(GetType(MapWinGIS.Grid))
        For i As Integer = 0 To g_Grids.Count - 1
            Logger.Dbg("  InputGrid " & i + 1 & " " & tGrids(i).Filename)
        Next

        'merge the grids if there is more than one added
        If g_Grids.Count > 1 Then
            newGrid = merger.GridMerge(tGrids, NewFilename, True, g_newFormat, Progress)
            If newGrid Is Nothing Then
                Logger.Msg("Error merging grids!", _
                           MsgBoxStyle.Critical Or MsgBoxStyle.Information, _
                           "GISTools - DoMerge Error")
                Return Nothing
            Else
                ' What do do about coloring...? Bugzila 500
                ' Find all mins and maxes from all grids
                ' Ideally, find one grid that contains all mins and maxes
                ' use that one. Else, generate a new coloring scheme.
                Dim Mins As New ArrayList()
                Dim Maxs As New ArrayList()
                For i As Integer = 0 To g_Grids.Count - 1
                    Mins.Add(Double.Parse(CType(g_Grids(i), MapWinGIS.Grid).Minimum.ToString()))
                    Maxs.Add(Double.Parse(CType(g_Grids(i), MapWinGIS.Grid).Maximum.ToString()))
                Next

                Dim ColorSchemeToUse As Integer = -1
                For x As Integer = 0 To g_Grids.Count - 1
                    Dim AllGridsInThisOne As Boolean = True
                    For i As Integer = 0 To g_Grids.Count - 1
                        If Not x = i Then
                            If (CType(Mins(i), Double) < CType(Mins(x), Double)) Then
                                AllGridsInThisOne = False
                                Exit For
                            End If
                            If (CType(Maxs(i), Double) > CType(Maxs(x), Double)) Then
                                AllGridsInThisOne = False
                                Exit For
                            End If
                        End If
                    Next

                    If AllGridsInThisOne = True Then
                        ColorSchemeToUse = x
                        Exit For
                    End If
                Next

                If ColorSchemeToUse = -1 Then 'Need new coloring scheme
                    'Do nothing - just add it (no .mwleg == new coloring scheme)
                    Logger.Dbg("MergeGrid: No suitable coloring scheme contains full value range - will generate new one")
                Else
                    'Copy from the one we wanted
                    Logger.Dbg("MergeGrid: Coloring scheme " + ColorSchemeToUse.ToString() + " is suitable - copying")

                    Try
                        Dim fn1 As String = "noexist"
                        Dim o As MapWinGIS.Grid = CType(g_Grids(ColorSchemeToUse), MapWinGIS.Grid)
                        If Not o Is Nothing Then fn1 = o.Filename
                        o = Nothing
                        If Not fn1 = "noexist" AndAlso System.IO.File.Exists(System.IO.Path.ChangeExtension(fn1, ".mwleg")) Then
                            System.IO.File.Copy(System.IO.Path.ChangeExtension(fn1, ".mwleg"), System.IO.Path.ChangeExtension(NewFilename, ".mwleg"))
                            Logger.Dbg("MergeGrid: Coloring scheme from " + fn1 + " applied to output grid")
                        End If
                    Catch e As Exception
                        Logger.Dbg("Unable to copy old coloring scheme to merged grid: " + e.Message)
                    End Try
                End If
                Logger.Dbg("MergeComplete")
                Return newGrid
            End If
        Else
            Logger.Dbg("MergeNotNeeted:Only 1 Grid")
            Return CType(g_Grids(0), MapWinGIS.Grid)
        End If
    End Function

    Public Sub CreateImage(ByVal Filename As String, ByVal Grid As MapWinGIS.Grid, ByVal ColoringScheme As MapWinGIS.GridColorScheme, ByVal Progress As MapWinGIS.ICallback)
        Dim img As MapWinGIS.Image
        Dim g As New MapWinGIS.Utils

        img = g.GridToImage(Grid, ColoringScheme, Progress)
        If Not img Is Nothing Then
            'If newFormat = MapWinGIS.GridFileType.Esri Then
            '    Filename = Grid.Filename & ".bmp"
            'Else
            '    Filename = Grid.Filename.Substring(0, Grid.Filename.LastIndexOf(".")) & ".bmp"
            'End If
            img.Save(Filename, True, MapWinGIS.ImageType.USE_FILE_EXTENSION)
            If g_AddOutputToMW Then
                g_MW.Layers.Add(Filename)
            End If
        Else
            MapWinUtility.Logger.Msg("Image creation failed.", MsgBoxStyle.Critical Or MsgBoxStyle.Information, "Grid Wizard 2.0 - Error")
        End If
    End Sub

End Module
