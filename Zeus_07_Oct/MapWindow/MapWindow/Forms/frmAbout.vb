'10/18/2005 - Paul Meems (pm) - Starting with translating resourcefile into Dutch.
'7/31/2006 PM - Translated new strings into Dutch and set the localization to true agian

Friend Class frmAbout
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        'May/12/2008 Jiri Kadlec - load icon from shared resources to reduce size of the program
        Me.Icon = My.Resources.MapWindow_new
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents Developer As System.Windows.Forms.Label
    Friend WithEvents Version As System.Windows.Forms.Label
    Friend WithEvents BuildDate As System.Windows.Forms.Label
    Friend WithEvents MapwinVersion As System.Windows.Forms.Label
    Friend WithEvents lbName As System.Windows.Forms.Label
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents notes As System.Windows.Forms.RichTextBox
    Friend WithEvents lbURL As System.Windows.Forms.LinkLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents picMapWindow As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblProjFile As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents btnProcInfo As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents lblConfigFile As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbout))
        Me.lbName = New System.Windows.Forms.Label
        Me.Developer = New System.Windows.Forms.Label
        Me.Version = New System.Windows.Forms.Label
        Me.BuildDate = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.MapwinVersion = New System.Windows.Forms.Label
        Me.picMapWindow = New System.Windows.Forms.PictureBox
        Me.btnOk = New System.Windows.Forms.Button
        Me.notes = New System.Windows.Forms.RichTextBox
        Me.lbURL = New System.Windows.Forms.LinkLabel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblProjFile = New System.Windows.Forms.Label
        Me.lblConfigFile = New System.Windows.Forms.Label
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.btnProcInfo = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.picMapWindow, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbName
        '
        resources.ApplyResources(Me.lbName, "lbName")
        Me.lbName.Name = "lbName"
        '
        'Developer
        '
        resources.ApplyResources(Me.Developer, "Developer")
        Me.Developer.Name = "Developer"
        '
        'Version
        '
        resources.ApplyResources(Me.Version, "Version")
        Me.Version.Name = "Version"
        '
        'BuildDate
        '
        resources.ApplyResources(Me.BuildDate, "BuildDate")
        Me.BuildDate.Name = "BuildDate"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.LinkLabel2)
        Me.GroupBox1.Controls.Add(Me.MapwinVersion)
        Me.GroupBox1.Controls.Add(Me.picMapWindow)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'LinkLabel2
        '
        resources.ApplyResources(Me.LinkLabel2, "LinkLabel2")
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.TabStop = True
        '
        'MapwinVersion
        '
        resources.ApplyResources(Me.MapwinVersion, "MapwinVersion")
        Me.MapwinVersion.Name = "MapwinVersion"
        '
        'picMapWindow
        '
        Me.picMapWindow.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.picMapWindow, "picMapWindow")
        Me.picMapWindow.Name = "picMapWindow"
        Me.picMapWindow.TabStop = False
        '
        'btnOk
        '
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        resources.ApplyResources(Me.btnOk, "btnOk")
        Me.btnOk.Name = "btnOk"
        '
        'notes
        '
        Me.notes.BackColor = System.Drawing.SystemColors.Control
        Me.notes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.notes, "notes")
        Me.notes.Name = "notes"
        Me.notes.ReadOnly = True
        '
        'lbURL
        '
        resources.ApplyResources(Me.lbURL, "lbURL")
        Me.lbURL.Name = "lbURL"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
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
        'lblProjFile
        '
        Me.lblProjFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        resources.ApplyResources(Me.lblProjFile, "lblProjFile")
        Me.lblProjFile.Name = "lblProjFile"
        '
        'lblConfigFile
        '
        Me.lblConfigFile.BackColor = System.Drawing.SystemColors.Control
        Me.lblConfigFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        resources.ApplyResources(Me.lblConfigFile, "lblConfigFile")
        Me.lblConfigFile.Name = "lblConfigFile"
        '
        'LinkLabel1
        '
        resources.ApplyResources(Me.LinkLabel1, "LinkLabel1")
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.TabStop = True
        '
        'btnProcInfo
        '
        resources.ApplyResources(Me.btnProcInfo, "btnProcInfo")
        Me.btnProcInfo.Name = "btnProcInfo"
        Me.btnProcInfo.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        resources.ApplyResources(Me.TextBox1, "TextBox1")
        Me.TextBox1.Name = "TextBox1"
        '
        'frmAbout
        '
        Me.AcceptButton = Me.btnProcInfo
        resources.ApplyResources(Me, "$this")
        Me.CancelButton = Me.btnOk
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btnProcInfo)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.lblConfigFile)
        Me.Controls.Add(Me.lblProjFile)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbURL)
        Me.Controls.Add(Me.notes)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BuildDate)
        Me.Controls.Add(Me.Version)
        Me.Controls.Add(Me.Developer)
        Me.Controls.Add(Me.lbName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.picMapWindow, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Sub ShowAbout(ByVal frm As System.Windows.Forms.Form)
        Try
            Me.Icon = frmMain.Icon

            With AppInfo
                lbName.Text = .Name
                Developer.Text += .Developer

                Version.Text += .Version

                BuildDate.Text += .BuildDate
                LinkLabel1.Text = .URL

                ''load the application license agrement
                'Chris M 3/14/2006 added ability to read from a txt or rtf file

                If (.Comments = "") Then
                    Dim lic As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(Me.GetType).Location) & "\MapWindowNotes.rtf"
                    If System.IO.File.Exists(lic) Then
                        notes.LoadFile(lic, RichTextBoxStreamType.RichText)
                    End If
                ElseIf (.Comments.ToLower().EndsWith(".txt") Or .Comments.ToLower().EndsWith(".rtf")) And System.IO.File.Exists(.Comments) Then
                    If .Comments.ToLower().EndsWith(".txt") Then
                        notes.LoadFile(.Comments, RichTextBoxStreamType.RichText)
                    Else
                        notes.LoadFile(.Comments, RichTextBoxStreamType.PlainText)
                    End If
                Else
                    notes.Text = .Comments
                End If

                MapwinVersion.Text += App.VersionString + " (" + System.IO.File.GetLastWriteTime(System.Reflection.Assembly.GetExecutingAssembly().Location).ToShortDateString() + ")"
                lblProjFile.Text = ProjInfo.ProjectFileName
                lblConfigFile.Text = ProjInfo.ConfigFileName

                If lblProjFile.Text.Length > 30 Then lblProjFile.Text = lblProjFile.Text.Substring(0, 10) + " . . . " + lblProjFile.Text.Substring(lblProjFile.Text.Length - 38)
                If lblConfigFile.Text.Length > 30 Then lblConfigFile.Text = lblConfigFile.Text.Substring(0, 10) + " . . . " + lblConfigFile.Text.Substring(lblConfigFile.Text.Length - 38)

                ''if there is no splash screen then set default image
                'If (.SplashPicture Is Nothing) Then
                '    Pic.Image = New System.Drawing.Bitmap(Me.GetType, "About Box.bmp")
                'Else
                '    Pic.Image = .SplashPicture
                'End If
            End With

            Me.ShowDialog(frm)
        Catch ex As System.Exception
            frmMain.ShowErrorDialog(ex)
        End Try
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Me.Hide()
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Try
            ' Call the Process.Start method to open the default browser 
            ' with a URL:
            System.Diagnostics.Process.Start("http://www.MapWindow.org")
        Catch ex As System.Exception
        End Try
    End Sub

    Private Sub PicMapWin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            ' Call the Process.Start method to open the default browser 
            ' with a URL:
            System.Diagnostics.Process.Start("http://www.MapWindow.org")
        Catch ex As System.Exception
        End Try
    End Sub

    Private Sub lbURL_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lbURL.LinkClicked
        ' Call the Process.Start method to open the default browser 
        ' with a URL:
        System.Diagnostics.Process.Start(AppInfo.URL)
    End Sub

    Private Sub Pic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Call the Process.Start method to open the default browser 
        ' with a URL:
        Try
            System.Diagnostics.Process.Start(AppInfo.URL)
        Catch
        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If Not LinkLabel1.Text.ToLower().StartsWith("http://") Then
            Diagnostics.Process.Start("http://" + LinkLabel1.Text)
        Else
            Diagnostics.Process.Start(LinkLabel1.Text)
        End If
    End Sub

    Private Sub btnProcInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcInfo.Click
        Dim userTempPath = Application.LocalUserAppDataPath + "\" + System.DateTime.Now.Ticks.ToString() + ".txt"
        Dim procInfofile As System.IO.StreamWriter = System.IO.File.CreateText(userTempPath)
        procInfofile.WriteLine(MapWinUtility.MiscUtils.GetDebugInfo())
        procInfofile.Flush()
        procInfofile.Close()
        System.Diagnostics.Process.Start(userTempPath)

    End Sub
End Class
