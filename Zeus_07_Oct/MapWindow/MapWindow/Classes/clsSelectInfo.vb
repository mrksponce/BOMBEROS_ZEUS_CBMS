Public Class SelectInfo
    Implements IEnumerable
    Implements Interfaces.SelectInfo

    Friend Class SelectedShapeEnumerator
        Implements System.Collections.IEnumerator

        Private m_Collection As MapWindow.SelectInfo
        Private m_Idx As Integer = -1

        Public Sub New(ByVal inp As MapWindow.SelectInfo)
            m_Collection = inp
            m_Idx = -1
        End Sub

        Public Sub Reset() Implements IEnumerator.Reset
            m_Idx = -1
        End Sub

        Public ReadOnly Property Current() As Object Implements IEnumerator.Current
            Get
                Return m_Collection.Item(m_Idx)
            End Get
        End Property

        Public Function MoveNext() As Boolean Implements IEnumerator.MoveNext
            m_Idx += 1

            If m_Idx >= m_Collection.NumSelected Then
                Return False
            Else
                Return True
            End If
        End Function
    End Class

    Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
        Return New SelectedShapeEnumerator(Me)
    End Function

    Public Sub New()
        m_SelectBounds = New MapWinGIS.Extents()
        m_LayerHandle = -1
    End Sub

    Protected Overrides Sub Finalize()
        'ClearSelectedShapes()
    End Sub

    '-------------------Private members for public properties-------------------
    Private m_LayerHandle As Integer
    Private m_NumSelected As Integer
    Private m_SelectBounds As MapWinGIS.Extents
    Private m_Shapes() As MapWindow.SelectedShape

    '--------------------------------------SelectInfo Public Interface--------------------------------------
    '30 Aug 2001  Darrel Brown.  Refer to Document "MapWindow 2.0 Public Interface" Page 2
    '---------------------------------------------------------------------------------------------------------

    '-------------------Subs-------------------
    <CLSCompliant(False)> _
    Public Sub AddSelectedShape(ByVal newShape As Interfaces.SelectedShape) Implements Interfaces.SelectInfo.AddSelectedShape
        If m_LayerHandle = -1 Then m_LayerHandle = frmMain.Legend.SelectedLayer

        If newShape Is Nothing Then
            g_error = "AddSelectedShape:  Object variable not set."

        Else
            ReDim Preserve m_Shapes(m_NumSelected)
            m_Shapes(m_NumSelected) = CType(newShape, MapWindow.SelectedShape)
            m_NumSelected = m_NumSelected + 1
        End If
    End Sub

    Public Sub AddByIndex(ByVal ShapeIndex As Integer, ByVal SelectColor As System.Drawing.Color) Implements Interfaces.SelectInfo.AddByIndex
        Dim newShp As New MapWindow.SelectedShape()

        If frmMain.MapMain.get_ShapeVisible(frmMain.Legend.SelectedLayer, ShapeIndex) <> False Then
            newShp.Add(ShapeIndex, SelectColor)
            AddSelectedShape(newShp)
        End If
        newShp = Nothing
    End Sub

    Public Sub ClearSelectedShapes() Implements Interfaces.SelectInfo.ClearSelectedShapes
        Dim isLocked As Boolean = False
        Try
            Dim oneShp As MapWindow.SelectedShape
            Dim i As Integer, tLyrHandle As Integer

            tLyrHandle = m_LayerHandle

            If frmMain.MapMain Is Nothing Then
                For i = m_NumSelected - 1 To 0 Step -1
                    m_Shapes(i) = Nothing
                Next i
                Erase m_Shapes
                m_SelectBounds = Nothing
                Exit Sub
            End If

            If frmMain.MapMain.IsLocked = MapWinGIS.tkLockMode.lmUnlock Then
                frmMain.MapMain.LockWindow(MapWinGIS.tkLockMode.lmLock)
                isLocked = True
            End If

            For i = m_NumSelected - 1 To 0 Step -1
                oneShp = m_Shapes(i)
                If Not oneShp Is Nothing Then
                    With oneShp
                        frmMain.MapMain.set_ShapePointColor(tLyrHandle, .ShapeIndex, .OriginalColor)
                        frmMain.MapMain.set_ShapeLineColor(tLyrHandle, .ShapeIndex, .OriginalOutlineColor)
                        frmMain.MapMain.set_ShapeFillColor(tLyrHandle, .ShapeIndex, .OriginalColor)
                        frmMain.MapMain.set_ShapeDrawFill(tLyrHandle, .ShapeIndex, .OriginalDrawFill)
                        'Bugzilla 520
                        If ProjInfo.TransparentSelection Then frmMain.MapMain.set_ShapeFillTransparency(tLyrHandle, .ShapeIndex, .OriginalTransparency)
                    End With
                End If

                m_NumSelected = m_NumSelected - 1
                oneShp = Nothing

                m_Shapes(i) = Nothing
            Next i

            Erase m_Shapes
            m_SelectBounds = Nothing
            frmMain.UpdateZoomButtons()
            m_LayerHandle = -1

        Catch ex As Exception
            ' something went wrong
            g_error = ex.Message
            ShowError(ex)
        End Try
        If isLocked Then
            frmMain.MapMain.LockWindow(MapWinGIS.tkLockMode.lmUnlock)
        End If
    End Sub

    Public Sub RemoveSelectedShape(ByVal ListIndex As Integer) Implements Interfaces.SelectInfo.RemoveSelectedShape
        Dim i As Integer, tShp As MapWindow.SelectedShape, mapIndex As Integer, mapHandle As Integer

        If frmMain.MapMain Is Nothing Then Exit Sub

        mapHandle = m_LayerHandle

        If ListIndex >= 0 And ListIndex < m_NumSelected Then
            frmMain.MapMain.LockWindow(MapWinGIS.tkLockMode.lmLock)

            Try
                tShp = m_Shapes(ListIndex)
                mapIndex = tShp.ShapeIndex
                frmMain.MapMain.set_ShapePointColor(mapHandle, mapIndex, tShp.OriginalColor)
                frmMain.MapMain.set_ShapeLineColor(mapHandle, mapIndex, tShp.OriginalOutlineColor)
                frmMain.MapMain.set_ShapeFillColor(mapHandle, mapIndex, tShp.OriginalColor)
                frmMain.MapMain.set_ShapeDrawFill(mapHandle, mapIndex, tShp.OriginalDrawFill)
                'Bugzilla 520
                If ProjInfo.TransparentSelection Then frmMain.MapMain.set_ShapeFillTransparency(mapHandle, mapIndex, tShp.OriginalTransparency)
                tShp = Nothing

                For i = ListIndex To m_NumSelected - 2
                    m_Shapes(i) = m_Shapes(i + 1)
                Next i

                m_Shapes(m_NumSelected - 1) = Nothing
                m_NumSelected = m_NumSelected - 1

                If m_NumSelected = 0 Then
                    Erase m_Shapes
                Else
                    ReDim Preserve m_Shapes(m_NumSelected - 1)
                End If
            Finally
                frmMain.MapMain.LockWindow(MapWinGIS.tkLockMode.lmUnlock)
            End Try

        Else
            g_error = "RemoveSelectedShape:  Invalid index"

        End If
    End Sub

    Public Sub RemoveByShapeIndex(ByVal ShapeIndex As Integer) Implements MapWindow.Interfaces.SelectInfo.RemoveByShapeIndex
        Dim i, j As Integer
        Dim tShp As MapWindow.SelectedShape

        If frmMain.MapMain Is Nothing Then Exit Sub

        For i = 0 To m_Shapes.Length - 1
            If m_Shapes(i).ShapeIndex = ShapeIndex Then
                tShp = m_Shapes(i)
                frmMain.MapMain.LockWindow(MapWinGIS.tkLockMode.lmLock)
                Try
                    frmMain.MapMain.set_ShapePointColor(m_LayerHandle, ShapeIndex, tShp.OriginalColor)
                    frmMain.MapMain.set_ShapeLineColor(m_LayerHandle, ShapeIndex, tShp.OriginalOutlineColor)
                    frmMain.MapMain.set_ShapeFillColor(m_LayerHandle, ShapeIndex, tShp.OriginalColor)
                    frmMain.MapMain.set_ShapeDrawFill(m_LayerHandle, ShapeIndex, tShp.OriginalDrawFill)
                    'Bugzilla 520
                    If ProjInfo.TransparentSelection Then frmMain.MapMain.set_ShapeFillTransparency(m_LayerHandle, ShapeIndex, tShp.OriginalTransparency)
                Finally
                    frmMain.MapMain.LockWindow(MapWinGIS.tkLockMode.lmUnlock)
                End Try

                For j = i To m_NumSelected - 2
                    m_Shapes(j) = m_Shapes(j + 1)
                Next j

                m_Shapes(m_NumSelected - 1) = Nothing
                m_NumSelected = m_NumSelected - 1

                If m_NumSelected = 0 Then
                    Erase m_Shapes
                Else
                    ReDim Preserve m_Shapes(m_NumSelected - 1)
                End If

                tShp = Nothing
                ' all done removing so exit
                Exit Sub
            End If
        Next i
    End Sub

    '-------------------Properties-------------------
    Public ReadOnly Property NumSelected() As Integer Implements Interfaces.SelectInfo.NumSelected
        Get
            NumSelected = m_NumSelected
        End Get
    End Property

    <CLSCompliant(False)> _
    Public ReadOnly Property SelectBounds() As MapWinGIS.Extents Implements Interfaces.SelectInfo.SelectBounds
        Get
            ' Calculate the total bounds of the selected items
            Dim NewBounds As New MapWinGIS.Extents(), k As Integer

            Dim curmaxX As Double, curminX As Double
            Dim curmaxY As Double, curminY As Double
            Dim curmaxZ As Double, curminZ As Double

            Dim shpExts As MapWinGIS.Extents


            If m_NumSelected > 0 Then
                shpExts = m_Shapes(0).Extents
                curmaxX = shpExts.xMax
                curminX = shpExts.xMin
                curmaxY = shpExts.yMax
                curminY = shpExts.yMin
                curmaxZ = shpExts.zMax
                curminZ = shpExts.zMin

            Else
                Return Nothing
                Exit Property

            End If

            For k = 1 To m_NumSelected - 1
                shpExts = Nothing
                shpExts = m_Shapes(k).Extents
                If shpExts.xMax > curmaxX Then curmaxX = shpExts.xMax
                If shpExts.xMin < curminX Then curminX = shpExts.xMin
                If shpExts.yMax > curmaxY Then curmaxY = shpExts.yMax
                If shpExts.yMin < curminY Then curminY = shpExts.yMin
                If shpExts.zMax > curmaxZ Then curmaxZ = shpExts.zMax
                If shpExts.zMin < curminZ Then curminZ = shpExts.zMin
            Next k

            NewBounds.SetBounds(curminX, curminY, curminZ, curmaxX, curmaxY, curmaxZ)
            SelectBounds = NewBounds
        End Get
    End Property

    <CLSCompliant(False)> _
    Default Public ReadOnly Property Item(ByVal Index As Integer) As Interfaces.SelectedShape Implements Interfaces.SelectInfo.Item
        Get
            If m_NumSelected = 0 Then
                Return Nothing

            ElseIf Index >= 0 And Index < m_NumSelected Then
                Return m_Shapes(Index)

            Else
                g_error = "SelectedShape:  Invalid Index"
                Return Nothing
            End If
        End Get
    End Property

    Public ReadOnly Property LayerHandle() As Integer Implements Interfaces.SelectInfo.LayerHandle
        Get
            Return m_LayerHandle
        End Get
    End Property

    Friend Sub SetLayerHandle(ByVal NewHandle As Integer)
        ClearSelectedShapes()
        m_LayerHandle = NewHandle
    End Sub
End Class


