Imports MapWinUtility

Public Class frmOutput
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents lblOutputPath As System.Windows.Forms.Label
    Friend WithEvents txtOutputPath As System.Windows.Forms.TextBox
    Friend WithEvents btnOutputPath As System.Windows.Forms.Button
    Friend WithEvents lblFormat As System.Windows.Forms.Label
    Friend WithEvents cmbFormat As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDataType As System.Windows.Forms.ComboBox
    Friend WithEvents lblDataType As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblMultiplier As System.Windows.Forms.Label
    Friend WithEvents txtMultiplier As System.Windows.Forms.TextBox
    Friend WithEvents chkAdd As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOutput))
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.lblOutputPath = New System.Windows.Forms.Label
        Me.txtOutputPath = New System.Windows.Forms.TextBox
        Me.btnOutputPath = New System.Windows.Forms.Button
        Me.lblFormat = New System.Windows.Forms.Label
        Me.cmbFormat = New System.Windows.Forms.ComboBox
        Me.cmbDataType = New System.Windows.Forms.ComboBox
        Me.lblDataType = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.lblName = New System.Windows.Forms.Label
        Me.chkAdd = New System.Windows.Forms.CheckBox
        Me.lblMultiplier = New System.Windows.Forms.Label
        Me.txtMultiplier = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'btnCancel
        '
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Name = "btnCancel"
        '
        'btnNext
        '
        resources.ApplyResources(Me.btnNext, "btnNext")
        Me.btnNext.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnNext.Name = "btnNext"
        '
        'lblOutputPath
        '
        resources.ApplyResources(Me.lblOutputPath, "lblOutputPath")
        Me.lblOutputPath.Name = "lblOutputPath"
        '
        'txtOutputPath
        '
        resources.ApplyResources(Me.txtOutputPath, "txtOutputPath")
        Me.txtOutputPath.Name = "txtOutputPath"
        '
        'btnOutputPath
        '
        resources.ApplyResources(Me.btnOutputPath, "btnOutputPath")
        Me.btnOutputPath.Name = "btnOutputPath"
        Me.btnOutputPath.TabStop = False
        '
        'lblFormat
        '
        resources.ApplyResources(Me.lblFormat, "lblFormat")
        Me.lblFormat.Name = "lblFormat"
        '
        'cmbFormat
        '
        resources.ApplyResources(Me.cmbFormat, "cmbFormat")
        Me.cmbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormat.Items.AddRange(New Object() {resources.GetString("cmbFormat.Items"), resources.GetString("cmbFormat.Items1"), resources.GetString("cmbFormat.Items2")})
        Me.cmbFormat.Name = "cmbFormat"
        '
        'cmbDataType
        '
        resources.ApplyResources(Me.cmbDataType, "cmbDataType")
        Me.cmbDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDataType.Items.AddRange(New Object() {resources.GetString("cmbDataType.Items"), resources.GetString("cmbDataType.Items1"), resources.GetString("cmbDataType.Items2"), resources.GetString("cmbDataType.Items3")})
        Me.cmbDataType.Name = "cmbDataType"
        '
        'lblDataType
        '
        resources.ApplyResources(Me.lblDataType, "lblDataType")
        Me.lblDataType.Name = "lblDataType"
        '
        'txtName
        '
        resources.ApplyResources(Me.txtName, "txtName")
        Me.txtName.Name = "txtName"
        '
        'lblName
        '
        resources.ApplyResources(Me.lblName, "lblName")
        Me.lblName.Name = "lblName"
        '
        'chkAdd
        '
        resources.ApplyResources(Me.chkAdd, "chkAdd")
        Me.chkAdd.Checked = True
        Me.chkAdd.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAdd.Name = "chkAdd"
        '
        'lblMultiplier
        '
        resources.ApplyResources(Me.lblMultiplier, "lblMultiplier")
        Me.lblMultiplier.Name = "lblMultiplier"
        '
        'txtMultiplier
        '
        resources.ApplyResources(Me.txtMultiplier, "txtMultiplier")
        Me.txtMultiplier.Name = "txtMultiplier"
        '
        'frmOutput
        '
        Me.AcceptButton = Me.btnNext
        resources.ApplyResources(Me, "$this")
        Me.CancelButton = Me.btnCancel
        Me.Controls.Add(Me.txtMultiplier)
        Me.Controls.Add(Me.lblMultiplier)
        Me.Controls.Add(Me.chkAdd)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.cmbDataType)
        Me.Controls.Add(Me.lblDataType)
        Me.Controls.Add(Me.cmbFormat)
        Me.Controls.Add(Me.lblFormat)
        Me.Controls.Add(Me.btnOutputPath)
        Me.Controls.Add(Me.txtOutputPath)
        Me.Controls.Add(Me.lblOutputPath)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnNext)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOutput"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Cleanup()
        Logger.Dbg("User Cancelled")

        'Must set dialog result or GISTools routines will hang.
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Logger.Dbg("Checking Details")

        Select Case cmbDataType.Text
            Case "Short Integer (2 bytes)"
                g_newDataType = MapWinGIS.GridDataType.ShortDataType
            Case "Long Integer (4 bytes)"
                g_newDataType = MapWinGIS.GridDataType.LongDataType
            Case "Single Precision Float (4 bytes)"
                g_newDataType = MapWinGIS.GridDataType.FloatDataType
            Case "Double Precision Float (8 bytes)"
                g_newDataType = MapWinGIS.GridDataType.DoubleDataType
            Case Else
                g_newDataType = MapWinGIS.GridDataType.DoubleDataType
        End Select
        Logger.Dbg("NewDataType " & g_newDataType)

        Select Case cmbFormat.Text
            Case "USU Binary (*.bgd)"
                g_newFormat = MapWinGIS.GridFileType.Binary
                g_newExt = ".bgd"
            Case "ASCII (*.asc)"
                g_newFormat = MapWinGIS.GridFileType.Ascii
                g_newExt = ".asc"
            Case "ESRI Binary"
                g_newFormat = MapWinGIS.GridFileType.Esri
                g_newExt = ""
            Case "GeoTIFF (*.tif)"
                g_newFormat = MapWinGIS.GridFileType.GeoTiff
                g_newExt = ".tif"
            Case Else
                g_newFormat = MapWinGIS.GridFileType.Ascii
                g_newExt = ".asc"
        End Select
        Logger.Dbg("NewFormat " & g_newFormat & " NewExt '" & g_newExt & "'")

        If txtOutputPath.Text.Substring(txtOutputPath.Text.Length - 1) = "\" Then
            txtOutputPath.Text = txtOutputPath.Text.Substring(0, txtOutputPath.Text.Length - 1)
        End If

        If (txtOutputPath.Enabled) Then
            g_OutputPath = txtOutputPath.Text
        End If
        Logger.Dbg("OutputPath '" & g_OutputPath & "'")

        If (txtName.Enabled) Then
            g_OutputName = txtName.Text
        End If
        Logger.Dbg("OutputName '" & g_OutputName & "'")

        'Must set dialog result or GISTools routines will hang.
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnOutputPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOutputPath.Click
        Dim fldr As New System.Windows.Forms.FolderBrowserDialog
        fldr.SelectedPath = txtOutputPath.Text
        fldr.Description = "Choose output path"
        If fldr.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtOutputPath.Text = fldr.SelectedPath
        End If
    End Sub

    Private Function ValidateInputs() As Boolean
        btnNext.Enabled = False
        If cmbFormat.Enabled AndAlso cmbFormat.Text = "[Choose File Format]" Then Return False
        If cmbDataType.Enabled AndAlso cmbDataType.Text = "[Choose Data Type]" Then Return False
        If txtOutputPath.Text = "" Then Return False
        If Dir(txtOutputPath.Text, FileAttribute.Directory) = "" Then Return False
        If txtName.Enabled AndAlso txtName.Text = "" Then Return False
        btnNext.Enabled = True
        Return True
    End Function

    Private Sub cmbFormat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFormat.SelectedIndexChanged
        ValidateInputs()
    End Sub

    Private Sub cmbDataType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDataType.SelectedIndexChanged
        ValidateInputs()
    End Sub

    Private Sub txtOutputPath_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOutputPath.TextChanged
        ValidateInputs()
    End Sub

    Private Sub txtName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.Leave
        Try
            If txtName.Text.Contains("\") Then
                mapwinutility.logger.msg("Please choose the path in the 'Output Path' box, not in the 'Output Name' box.", MsgBoxStyle.Exclamation, "Output Path")
                Try
                    txtName.Text = System.IO.Path.GetFileNameWithoutExtension(txtName.Text)
                Catch
                End Try
            End If
            If txtName.Text.Contains(".") Then txtName.Text = System.IO.Path.GetFileNameWithoutExtension(txtName.Text)
        Catch
        End Try
        ValidateInputs()
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
        ValidateInputs()
    End Sub

    Public Sub SetOptionsEnabled(ByVal DataTypeEnable As Boolean, ByVal FormatEnable As Boolean, ByVal PathEnable As Boolean, ByVal NameEnable As Boolean, Optional ByVal AddToMapWinEnable As Boolean = True, Optional ByVal ShowMultiplier As Boolean = False)
        cmbDataType.Enabled = DataTypeEnable
        lblDataType.Enabled = DataTypeEnable
        cmbFormat.Enabled = FormatEnable
        lblFormat.Enabled = FormatEnable
        lblOutputPath.Enabled = PathEnable
        txtOutputPath.Enabled = PathEnable
        btnOutputPath.Enabled = PathEnable
        txtName.Enabled = NameEnable
        lblName.Enabled = NameEnable
        chkAdd.Enabled = AddToMapWinEnable

        lblMultiplier.Visible = ShowMultiplier
        txtMultiplier.Visible = ShowMultiplier
    End Sub

    <CLSCompliant(False)> _
    Public Sub SetDefaultDataType(ByVal DataType As MapWinGIS.GridDataType)
        Select Case DataType
            Case MapWinGIS.GridDataType.DoubleDataType
                cmbDataType.SelectedItem = "Double Precision Float (8 bytes)"
            Case MapWinGIS.GridDataType.FloatDataType
                cmbDataType.SelectedItem = "Single Precision Float (4 bytes)"
            Case MapWinGIS.GridDataType.LongDataType
                cmbDataType.SelectedItem = "Long Integer (4 bytes)"
            Case MapWinGIS.GridDataType.ShortDataType
                cmbDataType.SelectedItem = "Short Integer (2 bytes)"
            Case MapWinGIS.GridDataType.UnknownDataType
            Case MapWinGIS.GridDataType.InvalidDataType
        End Select
    End Sub

    <CLSCompliant(False)> _
    Public Sub SetDefaultOutputFormat(ByVal Extension As String)
        If (Extension.ToLower().EndsWith(".asc")) Then
            cmbFormat.SelectedItem = "ASCII (*.asc)"
        ElseIf (Extension.ToLower().EndsWith(".bgd")) Then
            cmbFormat.SelectedItem = "USU Binary (*.bgd)"
        Else
            cmbFormat.SelectedItem = "GeoTIFF (*.tif)"
        End If
    End Sub

    Private Sub OutputForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If cmbDataType.SelectedIndex = -1 Then cmbDataType.SelectedIndex = 0
        If cmbFormat.SelectedIndex = -1 Then cmbFormat.SelectedIndex = 0
        txtOutputPath.Text = CurDir()
        txtName.Focus()
    End Sub

    Private Sub chkAdd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAdd.CheckedChanged
        g_AddOutputToMW = chkAdd.Checked
    End Sub

    Private Sub txtMultiplier_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMultiplier.TextChanged
        If Not txtMultiplier.Text.Trim() = "" Then
            Dim x As Double = 0
            If Not Double.TryParse(txtMultiplier.Text, x) Then
                mapwinutility.logger.msg("Please enter only numbers in the multiplier field. Leave it at 1 (or 1.0) if no multiplier is needed.", MsgBoxStyle.Information, "Multiplier Value")
            End If
        End If
    End Sub
End Class
