Public Class SelectedShape
    Implements Interfaces.SelectedShape

    '-------------------Private members for public properties-------------------
    Private m_Fields() As String
    Private m_NumFields As Integer
    Private m_OriginalColor As UInt32
    Private m_OriginalDrawFill As Boolean
    Private m_OriginalTransparency As Single
    Private m_OriginalOutlineColor As UInt32
    Private m_ShapeIndex As Integer
    Private m_Values() As Object

    '--------------------------------------SelectedShape Public Interface----------------------------------------
    '30 Aug 2001  Darrel Brown.  Refer to Document "MapWindow 2.0 Public Interface" Page 2
    '------------------------------------------------------------------------------------------------------------

    '-------------------Subs-------------------
    Public Sub Add(ByVal ShapeIndex As Integer, ByVal SelectColor As System.Drawing.Color) Implements Interfaces.SelectedShape.Add
        Dim tShpObj As MapWinGIS.Shapefile
        Dim curLyr As Integer = frmMain.Legend.SelectedLayer
        If frmMain.Legend.SelectedLayer = -1 Then Exit Sub

        tShpObj = CType(frmMain.MapMain.get_GetObject(curLyr), MapWinGIS.Shapefile) : If tShpObj Is Nothing Then Exit Sub

        m_OriginalOutlineColor = MapWinUtility.Colors.ColorToUInteger(frmMain.MapMain.get_ShapeLineColor(curLyr, ShapeIndex))
        m_OriginalDrawFill = frmMain.MapMain.get_ShapeDrawFill(curLyr, ShapeIndex)
        m_ShapeIndex = ShapeIndex
        m_OriginalTransparency = frmMain.MapMain.get_ShapeFillTransparency(curLyr, ShapeIndex)

        Select Case tShpObj.ShapefileType
            Case MapWinGIS.ShpfileType.SHP_POLYGON, MapWinGIS.ShpfileType.SHP_POLYGONM, MapWinGIS.ShpfileType.SHP_POLYGONZ
                m_OriginalColor = MapWinUtility.Colors.ColorToUInteger(frmMain.MapMain.get_ShapeFillColor(curLyr, ShapeIndex))
                frmMain.MapMain.set_ShapeDrawFill(curLyr, ShapeIndex, True)
                frmMain.MapMain.set_ShapeFillColor(curLyr, ShapeIndex, MapWinUtility.Colors.ColorToUInteger(SelectColor))

                'Bugzilla 222 and Bugzilla 520
                If ProjInfo.TransparentSelection Then frmMain.MapMain.set_ShapeFillTransparency(curLyr, ShapeIndex, 0.5)

            Case MapWinGIS.ShpfileType.SHP_POINT, MapWinGIS.ShpfileType.SHP_POINTM, MapWinGIS.ShpfileType.SHP_POINTZ
                m_OriginalColor = MapWinUtility.Colors.ColorToUInteger(frmMain.MapMain.get_ShapePointColor(curLyr, ShapeIndex))
                frmMain.MapMain.set_ShapePointColor(curLyr, ShapeIndex, MapWinUtility.Colors.ColorToUInteger(SelectColor))

            Case Else
                m_OriginalColor = MapWinUtility.Colors.ColorToUInteger(frmMain.MapMain.get_ShapeLineColor(curLyr, ShapeIndex))
                frmMain.MapMain.set_ShapeLineColor(curLyr, ShapeIndex, MapWinUtility.Colors.ColorToUInteger(SelectColor))
        End Select
    End Sub


    '-------------------Properties-------------------
    <CLSCompliant(False)> _
    Public ReadOnly Property Extents() As MapWinGIS.Extents Implements Interfaces.SelectedShape.Extents
        Get
            Dim tShpObj As MapWinGIS.Shapefile, tLyr As Integer, i As Integer
            If frmMain.Legend.SelectedLayer = -1 Then Return Nothing

            On Error Resume Next
            tLyr = frmMain.Legend.SelectedLayer

            tShpObj = CType(frmMain.MapMain.get_GetObject(tLyr), MapWinGIS.Shapefile)
            If tShpObj Is Nothing Then Return Nothing
            On Error GoTo 0

            Extents = tShpObj.Shape(m_ShapeIndex).Extents
        End Get
    End Property

    Friend ReadOnly Property OriginalColor() As UInt32
        Get
            OriginalColor = m_OriginalColor
        End Get
    End Property

    Friend ReadOnly Property OriginalDrawFill() As Boolean
        Get
            OriginalDrawFill = m_OriginalDrawFill
        End Get
    End Property

    Friend ReadOnly Property OriginalTransparency() As Single
        Get
            Return m_OriginalTransparency
        End Get
    End Property

    Friend ReadOnly Property OriginalOutlineColor() As UInt32
        Get
            OriginalOutlineColor = m_OriginalOutlineColor
        End Get
    End Property

    Public ReadOnly Property ShapeIndex() As Integer Implements Interfaces.SelectedShape.ShapeIndex
        Get
            ShapeIndex = m_ShapeIndex
        End Get
    End Property
End Class


