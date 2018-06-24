<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectImages
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelectImages))
        Me.btnMoveDown = New System.Windows.Forms.Button
        Me.btnMoveUp = New System.Windows.Forms.Button
        Me.btnRemove = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.lstImage = New System.Windows.Forms.ListView
        Me.Filename = New System.Windows.Forms.ColumnHeader
        Me.FileSize = New System.Windows.Forms.ColumnHeader
        Me.FileType = New System.Windows.Forms.ColumnHeader
        Me.ImageSizeX = New System.Windows.Forms.ColumnHeader
        Me.ImageSizeY = New System.Windows.Forms.ColumnHeader
        Me.SuspendLayout()
        '
        'btnMoveDown
        '
        resources.ApplyResources(Me.btnMoveDown, "btnMoveDown")
        Me.btnMoveDown.Name = "btnMoveDown"
        Me.btnMoveDown.TabStop = False
        '
        'btnMoveUp
        '
        resources.ApplyResources(Me.btnMoveUp, "btnMoveUp")
        Me.btnMoveUp.Name = "btnMoveUp"
        Me.btnMoveUp.TabStop = False
        '
        'btnRemove
        '
        resources.ApplyResources(Me.btnRemove, "btnRemove")
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.TabStop = False
        '
        'btnAdd
        '
        resources.ApplyResources(Me.btnAdd, "btnAdd")
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.TabStop = False
        '
        'btnNext
        '
        resources.ApplyResources(Me.btnNext, "btnNext")
        Me.btnNext.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnNext.Name = "btnNext"
        '
        'btnCancel
        '
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Name = "btnCancel"
        '
        'lstImage
        '
        resources.ApplyResources(Me.lstImage, "lstImage")
        Me.lstImage.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Filename, Me.FileSize, Me.FileType, Me.ImageSizeX, Me.ImageSizeY})
        Me.lstImage.FullRowSelect = True
        Me.lstImage.GridLines = True
        Me.lstImage.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstImage.HideSelection = False
        Me.lstImage.Name = "lstImage"
        Me.lstImage.TabStop = False
        Me.lstImage.UseCompatibleStateImageBehavior = False
        Me.lstImage.View = System.Windows.Forms.View.Details
        '
        'Filename
        '
        resources.ApplyResources(Me.Filename, "Filename")
        '
        'FileSize
        '
        resources.ApplyResources(Me.FileSize, "FileSize")
        '
        'FileType
        '
        resources.ApplyResources(Me.FileType, "FileType")
        '
        'ImageSizeX
        '
        resources.ApplyResources(Me.ImageSizeX, "ImageSizeX")
        '
        'ImageSizeY
        '
        resources.ApplyResources(Me.ImageSizeY, "ImageSizeY")
        '
        'frmSelectImages
        '
        Me.AcceptButton = Me.btnNext
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.Controls.Add(Me.lstImage)
        Me.Controls.Add(Me.btnMoveDown)
        Me.Controls.Add(Me.btnMoveUp)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnCancel)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelectImages"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnMoveDown As System.Windows.Forms.Button
    Friend WithEvents btnMoveUp As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lstImage As System.Windows.Forms.ListView
    Friend WithEvents Filename As System.Windows.Forms.ColumnHeader
    Friend WithEvents FileSize As System.Windows.Forms.ColumnHeader
    Friend WithEvents FileType As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImageSizeX As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImageSizeY As System.Windows.Forms.ColumnHeader
End Class
