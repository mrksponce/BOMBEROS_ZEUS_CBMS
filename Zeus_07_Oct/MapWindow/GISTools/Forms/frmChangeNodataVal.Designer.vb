<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChangeNodataVal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChangeNodataVal))
        Me.btnBrowseSrc1 = New System.Windows.Forms.Button
        Me.cmbxSrc1 = New System.Windows.Forms.ComboBox
        Me.lblSrc1 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtOrig = New System.Windows.Forms.TextBox
        Me.txtNew = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOk = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnBrowseSrc1
        '
        resources.ApplyResources(Me.btnBrowseSrc1, "btnBrowseSrc1")
        Me.btnBrowseSrc1.Name = "btnBrowseSrc1"
        '
        'cmbxSrc1
        '
        resources.ApplyResources(Me.cmbxSrc1, "cmbxSrc1")
        Me.cmbxSrc1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbxSrc1.Items.AddRange(New Object() {resources.GetString("cmbxSrc1.Items")})
        Me.cmbxSrc1.Name = "cmbxSrc1"
        '
        'lblSrc1
        '
        resources.ApplyResources(Me.lblSrc1, "lblSrc1")
        Me.lblSrc1.Name = "lblSrc1"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'txtOrig
        '
        resources.ApplyResources(Me.txtOrig, "txtOrig")
        Me.txtOrig.Name = "txtOrig"
        '
        'txtNew
        '
        resources.ApplyResources(Me.txtNew, "txtNew")
        Me.txtNew.Name = "txtNew"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'btnCancel
        '
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Name = "btnCancel"
        '
        'btnOk
        '
        resources.ApplyResources(Me.btnOk, "btnOk")
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.Name = "btnOk"
        '
        'frmChangeNodataVal
        '
        Me.AcceptButton = Me.btnOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNew)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtOrig)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnBrowseSrc1)
        Me.Controls.Add(Me.cmbxSrc1)
        Me.Controls.Add(Me.lblSrc1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChangeNodataVal"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBrowseSrc1 As System.Windows.Forms.Button
    Friend WithEvents cmbxSrc1 As System.Windows.Forms.ComboBox
    Friend WithEvents lblSrc1 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtOrig As System.Windows.Forms.TextBox
    Friend WithEvents txtNew As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
End Class
