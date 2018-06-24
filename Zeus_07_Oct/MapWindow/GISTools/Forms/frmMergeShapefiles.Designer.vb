<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMergeShapefiles
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMergeShapefiles))
        Me.Label1 = New System.Windows.Forms.Label
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.rdIgnore = New System.Windows.Forms.RadioButton
        Me.rdGeometry = New System.Windows.Forms.RadioButton
        Me.rdAttributes = New System.Windows.Forms.RadioButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnBrowseToOut = New System.Windows.Forms.Button
        Me.txtOut = New System.Windows.Forms.TextBox
        Me.rdOneAttribute = New System.Windows.Forms.RadioButton
        Me.cmbField = New System.Windows.Forms.ComboBox
        Me.chbAddtoMap = New System.Windows.Forms.CheckBox
        Me.txtProgress = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(464, 30)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "This tool will combine multiple complete shapefiles into one, optionally removing" & _
            " duplicate shapes."
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(15, 62)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(461, 108)
        Me.ListBox1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Shapefiles to Combine:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(377, 176)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(99, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "&Add Shapefiles..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(376, 364)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(99, 23)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "&Merge Shapefiles"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Enabled = False
        Me.Button3.Location = New System.Drawing.Point(252, 176)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(119, 23)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "&Remove Selected"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 203)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(208, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "How should duplicate shapes be handled?"
        '
        'rdIgnore
        '
        Me.rdIgnore.AutoSize = True
        Me.rdIgnore.Location = New System.Drawing.Point(38, 225)
        Me.rdIgnore.Name = "rdIgnore"
        Me.rdIgnore.Size = New System.Drawing.Size(182, 17)
        Me.rdIgnore.TabIndex = 3
        Me.rdIgnore.Text = "Ignore (Allow Duplicated Shapes)"
        Me.rdIgnore.UseVisualStyleBackColor = True
        '
        'rdGeometry
        '
        Me.rdGeometry.AutoSize = True
        Me.rdGeometry.Checked = True
        Me.rdGeometry.Location = New System.Drawing.Point(38, 248)
        Me.rdGeometry.Name = "rdGeometry"
        Me.rdGeometry.Size = New System.Drawing.Size(243, 17)
        Me.rdGeometry.TabIndex = 4
        Me.rdGeometry.TabStop = True
        Me.rdGeometry.Text = "Filter Duplicates by Geometry (Recommended)"
        Me.rdGeometry.UseVisualStyleBackColor = True
        '
        'rdAttributes
        '
        Me.rdAttributes.AutoSize = True
        Me.rdAttributes.Location = New System.Drawing.Point(38, 271)
        Me.rdAttributes.Name = "rdAttributes"
        Me.rdAttributes.Size = New System.Drawing.Size(161, 17)
        Me.rdAttributes.TabIndex = 5
        Me.rdAttributes.Text = "Filter Duplicates by Attributes"
        Me.rdAttributes.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 324)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Save output to..."
        '
        'btnBrowseToOut
        '
        Me.btnBrowseToOut.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowseToOut.Image = CType(resources.GetObject("btnBrowseToOut.Image"), System.Drawing.Image)
        Me.btnBrowseToOut.Location = New System.Drawing.Point(341, 343)
        Me.btnBrowseToOut.Name = "btnBrowseToOut"
        Me.btnBrowseToOut.Size = New System.Drawing.Size(23, 24)
        Me.btnBrowseToOut.TabIndex = 7
        '
        'txtOut
        '
        Me.txtOut.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOut.Location = New System.Drawing.Point(12, 346)
        Me.txtOut.Name = "txtOut"
        Me.txtOut.Size = New System.Drawing.Size(323, 20)
        Me.txtOut.TabIndex = 6
        '
        'rdOneAttribute
        '
        Me.rdOneAttribute.AutoSize = True
        Me.rdOneAttribute.Location = New System.Drawing.Point(38, 294)
        Me.rdOneAttribute.Name = "rdOneAttribute"
        Me.rdOneAttribute.Size = New System.Drawing.Size(191, 17)
        Me.rdOneAttribute.TabIndex = 11
        Me.rdOneAttribute.Text = "Filter Duplicates by Single Attribute:"
        Me.rdOneAttribute.UseVisualStyleBackColor = True
        '
        'cmbField
        '
        Me.cmbField.Enabled = False
        Me.cmbField.FormattingEnabled = True
        Me.cmbField.Location = New System.Drawing.Point(235, 293)
        Me.cmbField.Name = "cmbField"
        Me.cmbField.Size = New System.Drawing.Size(154, 21)
        Me.cmbField.TabIndex = 12
        '
        'chbAddtoMap
        '
        Me.chbAddtoMap.AutoSize = True
        Me.chbAddtoMap.Checked = True
        Me.chbAddtoMap.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbAddtoMap.Location = New System.Drawing.Point(15, 372)
        Me.chbAddtoMap.Name = "chbAddtoMap"
        Me.chbAddtoMap.Size = New System.Drawing.Size(122, 17)
        Me.chbAddtoMap.TabIndex = 13
        Me.chbAddtoMap.Text = "Add Output to Map?"
        Me.chbAddtoMap.UseVisualStyleBackColor = True
        '
        'txtProgress
        '
        Me.txtProgress.Location = New System.Drawing.Point(252, 372)
        Me.txtProgress.Name = "txtProgress"
        Me.txtProgress.Size = New System.Drawing.Size(83, 20)
        Me.txtProgress.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(193, 374)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Progress"
        '
        'frmMergeShapefiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(489, 399)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtProgress)
        Me.Controls.Add(Me.chbAddtoMap)
        Me.Controls.Add(Me.cmbField)
        Me.Controls.Add(Me.rdOneAttribute)
        Me.Controls.Add(Me.btnBrowseToOut)
        Me.Controls.Add(Me.txtOut)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.rdAttributes)
        Me.Controls.Add(Me.rdGeometry)
        Me.Controls.Add(Me.rdIgnore)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMergeShapefiles"
        Me.Text = "Merge Shapefiles"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rdIgnore As System.Windows.Forms.RadioButton
    Friend WithEvents rdGeometry As System.Windows.Forms.RadioButton
    Friend WithEvents rdAttributes As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnBrowseToOut As System.Windows.Forms.Button
    Friend WithEvents txtOut As System.Windows.Forms.TextBox
    Friend WithEvents rdOneAttribute As System.Windows.Forms.RadioButton
    Friend WithEvents cmbField As System.Windows.Forms.ComboBox
    Friend WithEvents chbAddtoMap As System.Windows.Forms.CheckBox
    Friend WithEvents txtProgress As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
