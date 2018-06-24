Public Class StatusBarItem
    Implements Interfaces.StatusBarItem

    Friend m_Index As Integer

    <CLSCompliant(False)> _
    Public Property Alignment() As Interfaces.eAlignment Implements Interfaces.StatusBarItem.Alignment
        Get
            Try
                Select Case frmMain.StatusBar1.Panels(m_Index).Alignment
                    Case HorizontalAlignment.Center
                        Return Interfaces.eAlignment.Center
                    Case HorizontalAlignment.Left
                        Return Interfaces.eAlignment.Left
                    Case HorizontalAlignment.Right
                        Return Interfaces.eAlignment.Right
                End Select
            Catch ex As Exception
                g_error = ex.Message
                ShowError(ex)
            End Try
        End Get
        Set(ByVal Value As Interfaces.eAlignment)
            Try
                Select Case Value

                End Select
                frmMain.StatusBar1.Panels(m_Index).Alignment = CType(Value, System.Windows.Forms.HorizontalAlignment)
            Catch ex As Exception
                g_error = ex.Message
                ShowError(ex)
            End Try
        End Set
    End Property

    Public Property AutoSize() As Boolean Implements Interfaces.StatusBarItem.AutoSize
        Get
            Try
                Return CBool(frmMain.StatusBar1.Panels(m_Index).AutoSize)
            Catch ex As Exception
                g_error = ex.Message
                ShowError(ex)
            End Try
        End Get
        Set(ByVal Value As Boolean)
            Try
                If Value = True Then
                    frmMain.StatusBar1.Panels(m_Index).AutoSize = StatusBarPanelAutoSize.Spring
                Else
                    frmMain.StatusBar1.Panels(m_Index).AutoSize = StatusBarPanelAutoSize.None
                End If
                frmMain.m_StatusBar.ResizeProgressBar()
            Catch ex As Exception
                g_error = ex.Message
                ShowError(ex)
            End Try
        End Set
    End Property

    Public Property MinWidth() As Integer Implements Interfaces.StatusBarItem.MinWidth
        Get
            Try
                Return frmMain.StatusBar1.Panels(m_Index).MinWidth
            Catch ex As Exception
                g_error = ex.Message
                ShowError(ex)
            End Try
        End Get
        Set(ByVal Value As Integer)
            Try
                frmMain.StatusBar1.Panels(m_Index).MinWidth = Value
                frmMain.m_StatusBar.ResizeProgressBar()
            Catch ex As Exception
                g_error = ex.Message
                ShowError(ex)
            End Try
        End Set
    End Property

    Public Property Text() As String Implements Interfaces.StatusBarItem.Text
        Get
            Try
                Return frmMain.StatusBar1.Panels(m_Index).Text
            Catch ex As Exception
                g_error = ex.Message
                ShowError(ex)
                Return ""
            End Try
        End Get
        Set(ByVal Value As String)
            Try
                frmMain.StatusBar1.Panels(m_Index).Text = Value
            Catch ex As Exception
                g_error = ex.Message
                ShowError(ex)
            End Try
        End Set
    End Property

    Public Property Width() As Integer Implements Interfaces.StatusBarItem.Width
        Get
            Try
                Return frmMain.StatusBar1.Panels(m_Index).Width
            Catch ex As Exception
                g_error = ex.Message
                ShowError(ex)
            End Try
        End Get
        Set(ByVal Value As Integer)
            Try
                frmMain.StatusBar1.Panels(m_Index).Width = Value
                frmMain.m_StatusBar.ResizeProgressBar()
            Catch ex As Exception
                g_error = ex.Message
                ShowError(ex)
            End Try
        End Set
    End Property

    Friend Sub New(ByVal Index As Integer)
        m_Index = Index
    End Sub

    Public Sub New()
        m_Index = -1
    End Sub
End Class
