'Imports System.Runtime.InteropServices

Public Class StatusBar
    Implements Interfaces.StatusBar

    Public Property Enabled() As Boolean Implements Interfaces.StatusBar.Enabled
        Get
            Enabled = frmMain.StatusBar1.Enabled
        End Get
        Set(ByVal Value As Boolean)
            frmMain.StatusBar1.Enabled = Value
        End Set
    End Property

    Public Property ShowProgressBar() As Boolean Implements Interfaces.StatusBar.ShowProgressBar
        Get
            Return frmMain.ProgressBar1.Visible
        End Get
        Set(ByVal Value As Boolean)
            frmMain.ProgressBar1.Visible = Value
            If Value = True Then frmMain.ProgressBar1.BringToFront()
        End Set
    End Property

    Public Property ProgressBarValue() As Integer Implements MapWindow.Interfaces.StatusBar.ProgressBarValue
        Get
            Return frmMain.ProgressBar1.Value
        End Get
        Set(ByVal Value As Integer)
            If Value > 100 Then
                Value = 100
            ElseIf Value < 0 Then
                Value = 0
            End If
            If Value > 0 Then
                If frmMain.ProgressBar1.Visible = False Then
                    frmMain.ProgressBar1.Visible = True
                    frmMain.ProgressBar1.BringToFront()
                    'frmMain.ResizeProgressBar()
                End If
            Else
                frmMain.ProgressBar1.Visible = False
            End If
            frmMain.ProgressBar1.Value = Value
            Try
                frmMain.ProgressBar1.Refresh()
            Catch
            End Try
        End Set
    End Property

    <CLSCompliant(False)> _
    Public Function AddPanel(ByVal InsertAt As Integer) As Interfaces.StatusBarItem Implements Interfaces.StatusBar.AddPanel
        Try
            Dim newItem As New MapWindow.StatusBarItem()

            Dim newPanel As New StatusBarPanel()
            Dim numPanels As Integer = Me.NumPanels

            If InsertAt > numPanels Then
                InsertAt = numPanels + 1
            End If

            frmMain.StatusBar1.Panels.Insert(InsertAt, newPanel)
            ResizeProgressBar()
            newItem.m_Index = InsertAt
            Return newItem
        Catch ex As Exception
            Throw New Exception("Failed to add StatusBar Panel." & vbCrLf & ex.Message)
            Return Nothing
        End Try
    End Function

    <CLSCompliant(False)> _
    Public Function AddPanel() As Interfaces.StatusBarItem Implements Interfaces.StatusBar.AddPanel
        Try
            Dim newItem As New MapWindow.StatusBarItem()

            Dim newPanel As New StatusBarPanel()
            Dim InsertAt As Integer = Me.NumPanels + 1

            frmMain.StatusBar1.Panels.Insert(InsertAt, newPanel)
            ResizeProgressBar()
            newItem.m_Index = InsertAt
            Return newItem
        Catch ex As Exception
            Throw New Exception("Failed to add StatusBar Panel." & vbCrLf & ex.Message)
            Return Nothing
        End Try
    End Function

    <CLSCompliant(False)> _
    Default Public ReadOnly Property Item(ByVal Index As Integer) As Interfaces.StatusBarItem Implements Interfaces.StatusBar.Item
        Get
            Return New StatusBarItem(Index)
        End Get
    End Property

    Public Sub RemovePanel(ByVal Index As Integer) Implements Interfaces.StatusBar.RemovePanel
        Try
            If (Not frmMain.StatusBar1.Panels(Index) Is Nothing) Then
                frmMain.StatusBar1.Panels.Remove(frmMain.StatusBar1.Panels(Index))
                ResizeProgressBar()
            End If
            If NumPanels = 0 Then
                AddPanel("", 0, 100, StatusBarPanelAutoSize.Spring)
            End If
        Catch ex As Exception
            g_error = ex.Message
            ShowError(ex)
        End Try
    End Sub

    Public Sub RemovePanel(ByRef Panel As System.Windows.Forms.StatusBarPanel) Implements MapWindow.Interfaces.StatusBar.RemovePanel
        Try
            If Not Panel Is Nothing AndAlso frmMain.StatusBar1.Panels.Contains(Panel) Then
                frmMain.StatusBar1.Panels.Remove(Panel)
                ResizeProgressBar()
            End If
            If NumPanels = 0 Then
                AddPanel("", 0, 100, StatusBarPanelAutoSize.Spring)
            End If
        Catch ex As System.Exception
            g_error = ex.Message
            ShowError(ex)
        End Try
    End Sub

    Public Function AddPanel(ByVal [Text] As String, ByVal Position As Integer, ByVal [Width] As Integer, ByVal AutoSize As System.Windows.Forms.StatusBarPanelAutoSize) As System.Windows.Forms.StatusBarPanel Implements MapWindow.Interfaces.StatusBar.AddPanel
        Try
            Dim newPanel As New Windows.Forms.StatusBarPanel()
            newPanel.Text = [Text]
            newPanel.Width = [Width]
            newPanel.AutoSize = AutoSize
            frmMain.StatusBar1.Panels.Insert(Position, newPanel)
            ResizeProgressBar()
            Return newPanel
        Catch ex As System.Exception
            g_error = ex.Message
            ShowError(ex)
            Return Nothing
        End Try
    End Function

    Public ReadOnly Property NumPanels() As Integer Implements MapWindow.Interfaces.StatusBar.NumPanels
        Get
            'Dim i As Integer = 0
            'Dim lastPanel As StatusBarPanel = Nothing
            'Try
            '    While True
            '        lastPanel = frmMain.StatusBar1.Panels(i)
            '        i = i + 1
            '    End While
            'Catch
            '    ' ha!  found the last one!
            'End Try
            Return frmMain.StatusBar1.Panels.Count
        End Get
    End Property

    Public Sub ResizeProgressBar() Implements MapWindow.Interfaces.StatusBar.ResizeProgressBar
        Dim i, width, prevWidth As Integer
        Dim lastPanel As StatusBarPanel
        Try
            While True
                lastPanel = frmMain.StatusBar1.Panels(i)
                i = i + 1
                prevWidth = width
                width += lastPanel.Width + 1
            End While
        Catch
            ' ha!  found the last one!
        End Try
        frmMain.ProgressBar1.Top = frmMain.StatusBar1.Top + 2
        frmMain.ProgressBar1.Left = prevWidth + 2
        frmMain.ProgressBar1.Width = width - prevWidth - 2
        frmMain.ProgressBar1.Height = frmMain.StatusBar1.Height - 2
        frmMain.ProgressBar1.BringToFront()
        Try
            frmMain.Refresh()
        Catch
        End Try
    End Sub
End Class


