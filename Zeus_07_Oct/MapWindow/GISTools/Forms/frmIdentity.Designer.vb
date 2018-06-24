<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIdentity
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIdentity))
        Me.btnBrowseToOut = New System.Windows.Forms.Button
        Me.stsBar = New System.Windows.Forms.StatusBar
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.chkbxAddClip = New System.Windows.Forms.CheckBox
        Me.txtbxOutFile = New System.Windows.Forms.TextBox
        Me.lblSaveAs = New System.Windows.Forms.Label
        Me.btnBrowseIdentity = New System.Windows.Forms.Button
        Me.cmbxIdentity = New System.Windows.Forms.ComboBox
        Me.lblIdentity = New System.Windows.Forms.Label
        Me.btnBrowseInput = New System.Windows.Forms.Button
        Me.cmbxInput = New System.Windows.Forms.ComboBox
        Me.lblInput = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnBrowseToOut
        '
        resources.ApplyResources(Me.btnBrowseToOut, "btnBrowseToOut")
        Me.btnBrowseToOut.Name = "btnBrowseToOut"
        '
        'stsBar
        '
        resources.ApplyResources(Me.stsBar, "stsBar")
        Me.stsBar.Name = "stsBar"
        '
        'btnCancel
        '
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Name = "btnCancel"
        '
        'btnOK
        '
        resources.ApplyResources(Me.btnOK, "btnOK")
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Name = "btnOK"
        '
        'chkbxAddClip
        '
        Me.chkbxAddClip.Checked = True
        Me.chkbxAddClip.CheckState = System.Windows.Forms.CheckState.Checked
        resources.ApplyResources(Me.chkbxAddClip, "chkbxAddClip")
        Me.chkbxAddClip.Name = "chkbxAddClip"
        '
        'txtbxOutFile
        '
        resources.ApplyResources(Me.txtbxOutFile, "txtbxOutFile")
        Me.txtbxOutFile.Name = "txtbxOutFile"
        '
        'lblSaveAs
        '
        resources.ApplyResources(Me.lblSaveAs, "lblSaveAs")
        Me.lblSaveAs.Name = "lblSaveAs"
        '
        'btnBrowseIdentity
        '
        resources.ApplyResources(Me.btnBrowseIdentity, "btnBrowseIdentity")
        Me.btnBrowseIdentity.Name = "btnBrowseIdentity"
        '
        'cmbxIdentity
        '
        resources.ApplyResources(Me.cmbxIdentity, "cmbxIdentity")
        Me.cmbxIdentity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbxIdentity.Name = "cmbxIdentity"
        '
        'lblIdentity
        '
        resources.ApplyResources(Me.lblIdentity, "lblIdentity")
        Me.lblIdentity.Name = "lblIdentity"
        '
        'btnBrowseInput
        '
        resources.ApplyResources(Me.btnBrowseInput, "btnBrowseInput")
        Me.btnBrowseInput.Name = "btnBrowseInput"
        '
        'cmbxInput
        '
        resources.ApplyResources(Me.cmbxInput, "cmbxInput")
        Me.cmbxInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbxInput.Name = "cmbxInput"
        '
        'lblInput
        '
        resources.ApplyResources(Me.lblInput, "lblInput")
        Me.lblInput.Name = "lblInput"
        '
        'frmIdentity
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnBrowseToOut)
        Me.Controls.Add(Me.stsBar)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.chkbxAddClip)
        Me.Controls.Add(Me.txtbxOutFile)
        Me.Controls.Add(Me.lblSaveAs)
        Me.Controls.Add(Me.btnBrowseIdentity)
        Me.Controls.Add(Me.cmbxIdentity)
        Me.Controls.Add(Me.lblIdentity)
        Me.Controls.Add(Me.btnBrowseInput)
        Me.Controls.Add(Me.cmbxInput)
        Me.Controls.Add(Me.lblInput)
        Me.Name = "frmIdentity"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBrowseToOut As System.Windows.Forms.Button
    Friend WithEvents stsBar As System.Windows.Forms.StatusBar
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents chkbxAddClip As System.Windows.Forms.CheckBox
    Friend WithEvents txtbxOutFile As System.Windows.Forms.TextBox
    Friend WithEvents lblSaveAs As System.Windows.Forms.Label
    Friend WithEvents btnBrowseIdentity As System.Windows.Forms.Button
    Friend WithEvents cmbxIdentity As System.Windows.Forms.ComboBox
    Friend WithEvents lblIdentity As System.Windows.Forms.Label
    Friend WithEvents btnBrowseInput As System.Windows.Forms.Button
    Friend WithEvents cmbxInput As System.Windows.Forms.ComboBox
    Friend WithEvents lblInput As System.Windows.Forms.Label
End Class
