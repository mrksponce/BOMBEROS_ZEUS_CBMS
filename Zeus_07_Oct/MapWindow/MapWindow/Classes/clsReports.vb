Imports System.Drawing

Public Class Reports
    Implements MapWindow.Interfaces.Reports


    Public Function GetNorthArrow() As Image Implements MapWindow.Interfaces.Reports.GetNorthArrow
        Try
            Return Nothing
        Catch ex As System.Exception
            Return Nothing
        End Try
    End Function

    <CLSCompliant(False)> _
    Public Function GetScaleBar(ByVal MapUnits As MapWindow.Interfaces.UnitOfMeasure, ByVal ScalebarUnits As MapWindow.Interfaces.UnitOfMeasure, ByVal MaxWidth As Integer) As Image Implements MapWindow.Interfaces.Reports.GetScaleBar
        Try
            Dim sb As New ScaleBarUtility()
            Dim img As Image
            img = sb.GenerateScaleBar(CType(frmMain.MapMain.Extents, MapWinGIS.Extents), MapUnits, ScalebarUnits, MaxWidth, Color.White, Color.Black)
            Return img
        Catch ex As System.Exception
            g_error = ex.Message
            ShowError(ex)
            Return Nothing
        End Try
    End Function

    Public Function GetScaleBar(ByVal MapUnits As String, ByVal ScalebarUnits As String, ByVal MaxWidth As Integer) As Image Implements MapWindow.Interfaces.Reports.GetScaleBar
        Try
            Dim sb As New ScaleBarUtility()
            Dim img As Image
            img = sb.GenerateScaleBar(CType(frmMain.MapMain.Extents, MapWinGIS.Extents), StringToUOM(MapUnits), StringToUOM(ScalebarUnits), MaxWidth, Color.White, Color.Black)
            Return img
        Catch ex As System.Exception
            g_error = ex.Message
            ShowError(ex)
            Return Nothing
        End Try
    End Function

    <CLSCompliant(False)> _
    Public Shared Function StringToUOM(ByVal inStr As String) As MapWindow.Interfaces.UnitOfMeasure
        Select Case inStr.ToLower()
            Case "centimeters"
                Return MapWindow.Interfaces.UnitOfMeasure.Centimeters
            Case "decimaldegrees", "longlat", "latlong", "lat/long", "long/lat"
                Return MapWindow.Interfaces.UnitOfMeasure.DecimalDegrees
            Case "feet"
                Return MapWindow.Interfaces.UnitOfMeasure.Feet
            Case "inches"
                Return MapWindow.Interfaces.UnitOfMeasure.Inches
            Case "kilometers"
                Return MapWindow.Interfaces.UnitOfMeasure.Kilometers
            Case "meters"
                Return MapWindow.Interfaces.UnitOfMeasure.Meters
            Case "miles"
                Return MapWindow.Interfaces.UnitOfMeasure.Miles
            Case "millimeters"
                Return MapWindow.Interfaces.UnitOfMeasure.Millimeters
            Case "yards"
                Return MapWindow.Interfaces.UnitOfMeasure.Yards
            Case Else
                Return Interfaces.UnitOfMeasure.Meters
        End Select
    End Function

    <CLSCompliant(False)> _
    Public Function GetScreenPicture(ByVal BoundBox As MapWinGIS.Extents) As MapWinGIS.Image Implements MapWindow.Interfaces.Reports.GetScreenPicture
        Try
            Return CType(frmMain.MapMain.SnapShot(BoundBox), MapWinGIS.Image)
        Catch ex As System.Exception
            ShowError(ex)
            Return Nothing
        End Try
    End Function

    Public Function GetLegendSnapshot(ByVal LayerHandle As Integer, ByVal imgWidth As Integer) As System.Drawing.Image Implements MapWindow.Interfaces.Reports.GetLegendLayerSnapshot
        Try
            Return frmMain.Legend.Layers.ItemByHandle(LayerHandle).Snapshot(imgWidth)
        Catch ex As System.Exception
            g_error = ex.Message
            ShowError(ex)
            Return Nothing
        End Try

        Return Nothing
    End Function

    Public Function GetLegendSnapshot2(ByVal VisibleLayersOnly As Boolean, ByVal imgWidth As Integer) As System.Drawing.Image Implements MapWindow.Interfaces.Reports.GetLegendSnapshot
        Try
            Return frmMain.Legend.Snapshot(VisibleLayersOnly, imgWidth)
        Catch ex As System.Exception
            g_error = ex.Message
            ShowError(ex)
            Return Nothing
        End Try
    End Function

    Private Function IPictureDispToImage(ByVal img As stdole.IPictureDisp) As System.Drawing.Image
        Dim cvter As New MapWinUtility.ImageUtils
        Return cvter.IPictureDispToImage(img)
    End Function
End Class
