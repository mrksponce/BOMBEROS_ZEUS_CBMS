Option Strict Off
'8/2/2006 - Paul Meems (pm) - Started Duth translation
'28/1/2008 - Jiri Kadlec - Changed ResourceManager (message strings moved to GlobalResource.resx)

Public Class frmOnlineScriptDirectory
    Inherits System.Windows.Forms.Form
#Region "Declarations"
    'PM
    'Private resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmOnlineScriptDirectory))
    'change by Jiri Kadlec
    Private resources As System.Resources.ResourceManager = _
    New System.Resources.ResourceManager("MapWindow.GlobalResource", System.Reflection.Assembly.GetExecutingAssembly())
#End Region

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtLang As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAuthor As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOnlineScriptDirectory))
        Me.Label1 = New System.Windows.Forms.Label
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtAuthor = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtLang = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDesc = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnLoad = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSubmit = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'ListBox1
        '
        resources.ApplyResources(Me.ListBox1, "ListBox1")
        Me.ListBox1.Name = "ListBox1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtAuthor)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtLang)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtDesc)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtName)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnLoad)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'txtAuthor
        '
        resources.ApplyResources(Me.txtAuthor, "txtAuthor")
        Me.txtAuthor.Name = "txtAuthor"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'txtLang
        '
        resources.ApplyResources(Me.txtLang, "txtLang")
        Me.txtLang.Name = "txtLang"
        Me.txtLang.ReadOnly = True
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'txtDesc
        '
        resources.ApplyResources(Me.txtDesc, "txtDesc")
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.ReadOnly = True
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'txtName
        '
        resources.ApplyResources(Me.txtName, "txtName")
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'btnLoad
        '
        resources.ApplyResources(Me.btnLoad, "btnLoad")
        Me.btnLoad.Name = "btnLoad"
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        resources.ApplyResources(Me.btnClose, "btnClose")
        Me.btnClose.Name = "btnClose"
        '
        'btnSubmit
        '
        resources.ApplyResources(Me.btnSubmit, "btnSubmit")
        Me.btnSubmit.Name = "btnSubmit"
        '
        'frmOnlineScriptDirectory
        '
        Me.AcceptButton = Me.btnLoad
        resources.ApplyResources(Me, "$this")
        Me.CancelButton = Me.btnClose
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOnlineScriptDirectory"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Class ScriptItem
        Public Attribs As New Hashtable
        Public Script As String
    End Class

    Private Scripts As New ArrayList

    Private Sub frmOnlineScriptDirectory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not MapWinUtility.MiscUtils.CheckInternetConnection("http://MapWindow.org/site_is_up_flag.txt") Then
            MapWinUtility.Logger.Msg(resources.GetString("msgNoConnection.Text"), MsgBoxStyle.Exclamation, AppInfo.Name)
            Me.Close()
        End If

        LoadScripts()
    End Sub

    Private Sub LoadScripts()
        Dim xml As String = MapWinUtility.Net.DownloadFile("http://MapWindow.org/scriptdirectory.php?MWAPP_fetchXML")
        If xml = "" Then Exit Sub
        Dim xmlReader As New System.Xml.XmlDocument
        xmlReader.LoadXml(xml)
        Dim xmlScriptNode As Xml.XmlNode = xmlReader.GetElementsByTagName("Scripts")(0)

        Dim xmlNode As Xml.XmlNode

        If Scripts Is Nothing Then Scripts = New ArrayList
        Scripts.Clear()

        For Each xmlNode In xmlScriptNode.ChildNodes
            Dim newItem As New ScriptItem

            Dim xmlAttr As Xml.XmlAttribute
            If Not xmlNode.Attributes Is Nothing Then
                For Each xmlAttr In xmlNode.Attributes
                    newItem.Attribs.Add(xmlAttr.Name, xmlAttr.InnerText)
                Next
            End If

            If Not xmlNode.InnerText Is Nothing Then newItem.Script = xmlNode.InnerText
            If Not newItem.Script = "" Then Scripts.Add(newItem)
        Next

        ListBox1.Items.Clear()
        For i As Integer = 0 To Scripts.Count - 1
            ListBox1.Items.Add(Scripts(i).Attribs("Name"))
        Next

        If Not ListBox1.Items.Count = 0 Then ListBox1.SelectedIndex = 0
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        For i As Integer = 0 To Scripts.Count - 1
            If ListBox1.Items(ListBox1.SelectedIndex) = Scripts(i).Attribs("Name") Then
                txtName.Text = Scripts(i).Attribs("Name")
                txtDesc.Text = Scripts(i).Attribs("Desc")
                txtLang.Text = Scripts(i).Attribs("Lang")
                txtAuthor.Text = Scripts(i).Attribs("Author")
                txtAuthor.Tag = Scripts(i).Attribs("AuthorLink")
                Exit For
            End If
        Next
    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        If MapWinUtility.Logger.Msg(resources.GetString("msgOverwriteCurrentlyLoadedScript.Text"), MsgBoxStyle.YesNo, AppInfo.Name) = MsgBoxResult.No Then Exit Sub

        For i As Integer = 0 To Scripts.Count - 1
            If ListBox1.Items(ListBox1.SelectedIndex) = Scripts(i).Attribs("Name") Then
                modMain.Scripts.rdScript.Checked = True
                If Scripts(i).Attribs("Lang") = "VB.Net" Then
                    modMain.Scripts.rdVBNet.Checked = True
                Else
                    modMain.Scripts.rdCS.Checked = True
                End If

                Dim s As Byte() = Convert.FromBase64String(Scripts(i).Script)
                Dim q As Byte
                Dim t As String = ""
                For Each q In s
                    t += Convert.ToChar(q)
                Next
                modMain.Scripts.txtScript.Text = t
                Exit For
            End If
        Next
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtAuthor_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        If Not txtAuthor.Tag = "" Then System.Diagnostics.Process.Start(txtAuthor.Tag)
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim submit As New frmOnlineScriptSubmit
        submit.ShowDialog()

        LoadScripts() 'refresh
    End Sub

End Class
