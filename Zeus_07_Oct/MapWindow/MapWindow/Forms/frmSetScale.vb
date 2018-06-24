Public Class frmSetScale

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        txtNewScale.Text = ""
        Me.DialogResult = DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Me.DialogResult = DialogResult.OK
        Me.Hide()
    End Sub

    Public Sub New(ByVal CurrentScale As String)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        'May/12/2008 Jiri Kadlec - load icon from shared resources to reduce size of the program
        Me.Icon = My.Resources.MapWindow_new

        txtOldScale.Text = CurrentScale
        txtNewScale.Text = CurrentScale
        Try
            Dim d As Double = Math.Round(Double.Parse(txtNewScale.Text))
            txtNewScale.Text = d.ToString()
        Catch
        End Try
    End Sub
End Class