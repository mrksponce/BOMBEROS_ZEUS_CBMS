'********************************************************************************************************
'File Name: frmTableEditor.vb
'Description: This is the main Table Editor screen with the datagrid.
'*f*******************************************************************************************************
'The contents of this file are subject to the Mozilla Public License Version 1.1 (the "License"); 
'you may not use this file except in compliance with the License. You may obtain a copy of the License at 
'http://www.mozilla.org/MPL/ 
'Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF 
'ANY KIND, either express or implied. See the License for the specificlanguage governing rights and 
'limitations under the License. 
'
'The Original Code is MapWindow Open Source. 
'
'The Initial Developer of this version of the Original Code is Daniel P. Ames using portions created by 
'Utah State University and the Idaho National Engineering and Environmental Lab that were released as 
'public domain in March 2004.  
'
'Contributor(s): (Open source contributors should list themselves and their modifications here). 
'Sept 01 2005: Chris Michaelis cmichaelis@happysquirrel.com - 
'              Replaced the Public Domain table editor with an enhanced version that was
'              contributed by Nathan Eaton at CALM Western Australia. This is released
'              as open source with his permission.
'Oct 03, 2008: Earljon Hidalgo earljon@gmail.com -
'               - Changed icons to fit on the icons found on the MapWindow main UI.
'               + Add new toolbar icon for Query (most commonly used function)
'               + Add Shortcut key for Query assigned as F6
'               + Add Esc key for Close button

Imports System.Windows.Forms
'next import added to be able to query readonly

'***Added by Nathan Eaton, CALM 02/05***'
'Provides FIle Property functionality, ie ability to check readonly
Imports System.IO


Public Class frmTableEditor
    Inherits System.Windows.Forms.Form

    Public Const ShowAllShapesText As String = "Show All Shapes"
    Public Const ShowSelectedShapesText As String = "Show Only Selected Shapes"

    Private m_Connection As OleDb.OleDbConnection
    Private m_Command As OleDb.OleDbCommand
    Private m_CommandBuilder As OleDb.OleDbCommandBuilder
    Private m_Adapter As OleDb.OleDbDataAdapter
    Private m_selected As DataTable
    Private m_sf As MapWinGIS.Shapefile
    Private m_owner As Windows.Forms.Form
    Private m_oldRow, m_oldCol As Integer
    Friend m_TrulyChanged As Boolean = False
    Private Loaded As Boolean = False
    Private calculator As frmFieldCalculator
    Private QueryDlg As New frmQueryBuilder

    Friend m_table As New DataTable("DBF")

    '***Added by Nathan Eaton, CALM 02/05***'
    'the m_MapWindowForm allows other forms to be opened, with MapWindow as the parent
    Private m_MapWindowForm As Windows.Forms.Form
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuShapeID As System.Windows.Forms.MenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnZoomToSelected As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnShowSelected As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnImportFieldsFromDBF As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnFieldCalculator As System.Windows.Forms.ToolStripButton
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    'gb_selected_column is a blobal variable providing access to the selected column in the table
    Public gb_selected_column As Integer
    Friend WithEvents MenuItem14 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem12 As System.Windows.Forms.MenuItem
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents MenuItem15 As System.Windows.Forms.MenuItem
    Friend WithEvents tbbRefresh As System.Windows.Forms.ToolStripButton

    Private SFIsRO As Boolean = False
    Friend WithEvents MenuItem16 As System.Windows.Forms.MenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbbQuery As System.Windows.Forms.ToolStripButton
    Public Table As DataTable

    <CLSCompliant(False)> _
    Public Sub New(ByRef Shapefile As MapWinGIS.Shapefile, ByVal OwnerForm As Windows.Forms.Form)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        m_sf = Shapefile
        m_owner = OwnerForm
        m_oldRow = -1
        m_oldCol = -1
    End Sub

#Region " Windows Form Designer generated code "

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
    Public WithEvents TableEditorDataGrid As System.Windows.Forms.DataGrid
    Friend WithEvents TableEditorHelp As System.Windows.Forms.HelpProvider
    Friend WithEvents lblUpdating As System.Windows.Forms.Label
    Friend WithEvents UpdateProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Selected_Label As System.Windows.Forms.Label
    Friend WithEvents Column_context As System.Windows.Forms.ContextMenu
    Friend WithEvents sort_asc As System.Windows.Forms.MenuItem
    Friend WithEvents Sort_desc As System.Windows.Forms.MenuItem
    Friend WithEvents Statistics_popup As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents Column_Expression_popup As System.Windows.Forms.MenuItem
    Friend WithEvents Selected_Input_popup As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem13 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem19 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem21 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRemoveField As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAddField As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRenameField As System.Windows.Forms.MenuItem
    Friend WithEvents mnuShowSelected As System.Windows.Forms.MenuItem
    Friend WithEvents mnuZoomToSelected As System.Windows.Forms.MenuItem
    Friend WithEvents mnuQuery As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSelectAll As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSelectNone As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSwitchSelection As System.Windows.Forms.MenuItem
    Friend WithEvents mnuExport As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFind As System.Windows.Forms.MenuItem
    Friend WithEvents mnuReplace As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTableEditor))
        Me.TableEditorDataGrid = New System.Windows.Forms.DataGrid
        Me.TableEditorHelp = New System.Windows.Forms.HelpProvider
        Me.lblUpdating = New System.Windows.Forms.Label
        Me.UpdateProgress = New System.Windows.Forms.ProgressBar
        Me.btnApply = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.Selected_Label = New System.Windows.Forms.Label
        Me.Column_context = New System.Windows.Forms.ContextMenu
        Me.Column_Expression_popup = New System.Windows.Forms.MenuItem
        Me.Selected_Input_popup = New System.Windows.Forms.MenuItem
        Me.MenuItem14 = New System.Windows.Forms.MenuItem
        Me.MenuItem11 = New System.Windows.Forms.MenuItem
        Me.MenuItem12 = New System.Windows.Forms.MenuItem
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.sort_asc = New System.Windows.Forms.MenuItem
        Me.Sort_desc = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.Statistics_popup = New System.Windows.Forms.MenuItem
        Me.MainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.mnuAddField = New System.Windows.Forms.MenuItem
        Me.mnuRemoveField = New System.Windows.Forms.MenuItem
        Me.MenuItem21 = New System.Windows.Forms.MenuItem
        Me.mnuRenameField = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.mnuShowSelected = New System.Windows.Forms.MenuItem
        Me.mnuZoomToSelected = New System.Windows.Forms.MenuItem
        Me.MenuItem15 = New System.Windows.Forms.MenuItem
        Me.MenuItem16 = New System.Windows.Forms.MenuItem
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.mnuQuery = New System.Windows.Forms.MenuItem
        Me.MenuItem13 = New System.Windows.Forms.MenuItem
        Me.mnuSelectAll = New System.Windows.Forms.MenuItem
        Me.mnuSelectNone = New System.Windows.Forms.MenuItem
        Me.mnuSwitchSelection = New System.Windows.Forms.MenuItem
        Me.MenuItem19 = New System.Windows.Forms.MenuItem
        Me.mnuExport = New System.Windows.Forms.MenuItem
        Me.MenuItem6 = New System.Windows.Forms.MenuItem
        Me.mnuFind = New System.Windows.Forms.MenuItem
        Me.mnuReplace = New System.Windows.Forms.MenuItem
        Me.MenuItem9 = New System.Windows.Forms.MenuItem
        Me.MenuItem7 = New System.Windows.Forms.MenuItem
        Me.MenuItem8 = New System.Windows.Forms.MenuItem
        Me.mnuShapeID = New System.Windows.Forms.MenuItem
        Me.MenuItem10 = New System.Windows.Forms.MenuItem
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnZoomToSelected = New System.Windows.Forms.ToolStripButton
        Me.btnShowSelected = New System.Windows.Forms.ToolStripButton
        Me.btnImportFieldsFromDBF = New System.Windows.Forms.ToolStripButton
        Me.btnFieldCalculator = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.tbbRefresh = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tbbQuery = New System.Windows.Forms.ToolStripButton
        CType(Me.TableEditorDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableEditorDataGrid
        '
        Me.TableEditorDataGrid.AllowSorting = False
        resources.ApplyResources(Me.TableEditorDataGrid, "TableEditorDataGrid")
        Me.TableEditorDataGrid.BackgroundColor = System.Drawing.Color.LightGray
        Me.TableEditorDataGrid.DataMember = ""
        Me.TableEditorDataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.TableEditorDataGrid.Name = "TableEditorDataGrid"
        '
        'lblUpdating
        '
        resources.ApplyResources(Me.lblUpdating, "lblUpdating")
        Me.lblUpdating.Name = "lblUpdating"
        '
        'UpdateProgress
        '
        resources.ApplyResources(Me.UpdateProgress, "UpdateProgress")
        Me.UpdateProgress.Name = "UpdateProgress"
        '
        'btnApply
        '
        resources.ApplyResources(Me.btnApply, "btnApply")
        Me.btnApply.Name = "btnApply"
        '
        'btnClose
        '
        resources.ApplyResources(Me.btnClose, "btnClose")
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Name = "btnClose"
        '
        'Selected_Label
        '
        resources.ApplyResources(Me.Selected_Label, "Selected_Label")
        Me.Selected_Label.Name = "Selected_Label"
        '
        'Column_context
        '
        Me.Column_context.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.Column_Expression_popup, Me.Selected_Input_popup, Me.MenuItem14, Me.MenuItem11, Me.MenuItem12, Me.MenuItem1, Me.sort_asc, Me.Sort_desc, Me.MenuItem2, Me.Statistics_popup})
        '
        'Column_Expression_popup
        '
        Me.Column_Expression_popup.Index = 0
        resources.ApplyResources(Me.Column_Expression_popup, "Column_Expression_popup")
        '
        'Selected_Input_popup
        '
        Me.Selected_Input_popup.Index = 1
        resources.ApplyResources(Me.Selected_Input_popup, "Selected_Input_popup")
        '
        'MenuItem14
        '
        Me.MenuItem14.Index = 2
        resources.ApplyResources(Me.MenuItem14, "MenuItem14")
        '
        'MenuItem11
        '
        Me.MenuItem11.Index = 3
        resources.ApplyResources(Me.MenuItem11, "MenuItem11")
        '
        'MenuItem12
        '
        Me.MenuItem12.Index = 4
        resources.ApplyResources(Me.MenuItem12, "MenuItem12")
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 5
        resources.ApplyResources(Me.MenuItem1, "MenuItem1")
        '
        'sort_asc
        '
        Me.sort_asc.Index = 6
        resources.ApplyResources(Me.sort_asc, "sort_asc")
        '
        'Sort_desc
        '
        Me.Sort_desc.Index = 7
        resources.ApplyResources(Me.Sort_desc, "Sort_desc")
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 8
        resources.ApplyResources(Me.MenuItem2, "MenuItem2")
        '
        'Statistics_popup
        '
        Me.Statistics_popup.Index = 9
        resources.ApplyResources(Me.Statistics_popup, "Statistics_popup")
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem3, Me.MenuItem4, Me.MenuItem5, Me.MenuItem6})
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 0
        Me.MenuItem3.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAddField, Me.mnuRemoveField, Me.MenuItem21, Me.mnuRenameField})
        resources.ApplyResources(Me.MenuItem3, "MenuItem3")
        '
        'mnuAddField
        '
        Me.mnuAddField.Index = 0
        resources.ApplyResources(Me.mnuAddField, "mnuAddField")
        '
        'mnuRemoveField
        '
        Me.mnuRemoveField.Index = 1
        resources.ApplyResources(Me.mnuRemoveField, "mnuRemoveField")
        '
        'MenuItem21
        '
        Me.MenuItem21.Index = 2
        resources.ApplyResources(Me.MenuItem21, "MenuItem21")
        '
        'mnuRenameField
        '
        Me.mnuRenameField.Index = 3
        resources.ApplyResources(Me.mnuRenameField, "mnuRenameField")
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 1
        Me.MenuItem4.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuShowSelected, Me.mnuZoomToSelected, Me.MenuItem15, Me.MenuItem16})
        resources.ApplyResources(Me.MenuItem4, "MenuItem4")
        '
        'mnuShowSelected
        '
        Me.mnuShowSelected.Index = 0
        resources.ApplyResources(Me.mnuShowSelected, "mnuShowSelected")
        '
        'mnuZoomToSelected
        '
        Me.mnuZoomToSelected.Index = 1
        resources.ApplyResources(Me.mnuZoomToSelected, "mnuZoomToSelected")
        '
        'MenuItem15
        '
        Me.MenuItem15.Index = 2
        resources.ApplyResources(Me.MenuItem15, "MenuItem15")
        '
        'MenuItem16
        '
        Me.MenuItem16.Index = 3
        resources.ApplyResources(Me.MenuItem16, "MenuItem16")
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 2
        Me.MenuItem5.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuQuery, Me.MenuItem13, Me.mnuSelectAll, Me.mnuSelectNone, Me.mnuSwitchSelection, Me.MenuItem19, Me.mnuExport})
        resources.ApplyResources(Me.MenuItem5, "MenuItem5")
        '
        'mnuQuery
        '
        Me.mnuQuery.Index = 0
        resources.ApplyResources(Me.mnuQuery, "mnuQuery")
        '
        'MenuItem13
        '
        Me.MenuItem13.Index = 1
        resources.ApplyResources(Me.MenuItem13, "MenuItem13")
        '
        'mnuSelectAll
        '
        Me.mnuSelectAll.Index = 2
        resources.ApplyResources(Me.mnuSelectAll, "mnuSelectAll")
        '
        'mnuSelectNone
        '
        Me.mnuSelectNone.Index = 3
        resources.ApplyResources(Me.mnuSelectNone, "mnuSelectNone")
        '
        'mnuSwitchSelection
        '
        Me.mnuSwitchSelection.Index = 4
        resources.ApplyResources(Me.mnuSwitchSelection, "mnuSwitchSelection")
        '
        'MenuItem19
        '
        Me.MenuItem19.Index = 5
        resources.ApplyResources(Me.MenuItem19, "MenuItem19")
        '
        'mnuExport
        '
        Me.mnuExport.Index = 6
        resources.ApplyResources(Me.mnuExport, "mnuExport")
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 3
        Me.MenuItem6.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFind, Me.mnuReplace, Me.MenuItem9, Me.MenuItem7, Me.MenuItem8, Me.mnuShapeID, Me.MenuItem10})
        resources.ApplyResources(Me.MenuItem6, "MenuItem6")
        '
        'mnuFind
        '
        Me.mnuFind.Index = 0
        resources.ApplyResources(Me.mnuFind, "mnuFind")
        '
        'mnuReplace
        '
        Me.mnuReplace.Index = 1
        resources.ApplyResources(Me.mnuReplace, "mnuReplace")
        '
        'MenuItem9
        '
        Me.MenuItem9.Index = 2
        resources.ApplyResources(Me.MenuItem9, "MenuItem9")
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 3
        resources.ApplyResources(Me.MenuItem7, "MenuItem7")
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 4
        resources.ApplyResources(Me.MenuItem8, "MenuItem8")
        '
        'mnuShapeID
        '
        Me.mnuShapeID.Index = 5
        resources.ApplyResources(Me.mnuShapeID, "mnuShapeID")
        '
        'MenuItem10
        '
        Me.MenuItem10.Index = 6
        resources.ApplyResources(Me.MenuItem10, "MenuItem10")
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnZoomToSelected, Me.btnShowSelected, Me.btnImportFieldsFromDBF, Me.btnFieldCalculator, Me.ToolStripButton1, Me.tbbRefresh, Me.ToolStripSeparator1, Me.tbbQuery})
        resources.ApplyResources(Me.ToolStrip1, "ToolStrip1")
        Me.ToolStrip1.Name = "ToolStrip1"
        '
        'btnZoomToSelected
        '
        Me.btnZoomToSelected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnZoomToSelected, "btnZoomToSelected")
        Me.btnZoomToSelected.Name = "btnZoomToSelected"
        '
        'btnShowSelected
        '
        Me.btnShowSelected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnShowSelected, "btnShowSelected")
        Me.btnShowSelected.Name = "btnShowSelected"
        '
        'btnImportFieldsFromDBF
        '
        Me.btnImportFieldsFromDBF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnImportFieldsFromDBF, "btnImportFieldsFromDBF")
        Me.btnImportFieldsFromDBF.Name = "btnImportFieldsFromDBF"
        '
        'btnFieldCalculator
        '
        Me.btnFieldCalculator.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnFieldCalculator, "btnFieldCalculator")
        Me.btnFieldCalculator.Name = "btnFieldCalculator"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.ToolStripButton1, "ToolStripButton1")
        Me.ToolStripButton1.Name = "ToolStripButton1"
        '
        'tbbRefresh
        '
        Me.tbbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.tbbRefresh, "tbbRefresh")
        Me.tbbRefresh.Name = "tbbRefresh"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'tbbQuery
        '
        Me.tbbQuery.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.tbbQuery, "tbbQuery")
        Me.tbbQuery.Name = "tbbQuery"
        '
        'frmTableEditor
        '
        resources.ApplyResources(Me, "$this")
        Me.CancelButton = Me.btnClose
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Selected_Label)
        Me.Controls.Add(Me.lblUpdating)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.UpdateProgress)
        Me.Controls.Add(Me.TableEditorDataGrid)
        Me.DoubleBuffered = True
        Me.KeyPreview = True
        Me.Menu = Me.MainMenu1
        Me.Name = "frmTableEditor"
        CType(Me.TableEditorDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    <CLSCompliant(False)> _
    Public Function Initialize(ByRef Shapefile As MapWinGIS.Shapefile, ByVal OwnerForm As Windows.Forms.Form) As Boolean
        Dim oldCursor, ownerCursor As Windows.Forms.Cursor
        oldCursor = Cursor
        ownerCursor = OwnerForm.Cursor
        Cursor = Cursors.WaitCursor
        OwnerForm.Cursor = Cursors.WaitCursor
        OwnerForm.Refresh()
        m_sf = Shapefile

        If LoadTable(m_sf, m_table) = False Then
            Cursor = oldCursor
            OwnerForm.Cursor = ownerCursor
            Return False
        End If

        TableEditorDataGrid.DataSource = m_table
        TableEditorDataGrid.CaptionText = m_sf.Filename
        SynchSelected()

        Me.Owner = OwnerForm
        Cursor = oldCursor
        OwnerForm.Cursor = ownerCursor
        Me.btnApply.Enabled = True
        m_TrulyChanged = False

        Try
            Dim fi As New System.IO.FileInfo(m_sf.Filename)
            'Note -- parenthesis in line below are critical (will always return true without)
            If (fi.Attributes And System.IO.FileAttributes.ReadOnly) = System.IO.FileAttributes.ReadOnly Then
                TableEditorDataGrid.CaptionText &= " (Read-Only)"
                Me.Text &= " (Read-Only)"
                SFIsRO = True
            End If
        Catch
        End Try

        Return True
    End Function

    Public Property FieldDisplayWidth(ByVal aFieldIndex As Integer) As Integer
        Get
            If aFieldIndex >= 0 AndAlso aFieldIndex < TableEditorDataGrid.TableStyles(0).GridColumnStyles.Count Then
                Return TableEditorDataGrid.TableStyles(0).GridColumnStyles(aFieldIndex).Width
            End If
        End Get
        Set(ByVal value As Integer)
            If aFieldIndex >= 0 AndAlso aFieldIndex < TableEditorDataGrid.TableStyles(0).GridColumnStyles.Count Then
                TableEditorDataGrid.TableStyles(0).GridColumnStyles(aFieldIndex).Width = value
            End If
        End Set
    End Property

    Private Function FindSafeFieldName(ByVal sf As MapWinGIS.Shapefile, ByVal OldName As String) As String
        Dim ht As New Hashtable()
        Dim i As Integer

        ' build a list of unique names
        For i = 0 To sf.NumFields - 1
            Dim cur As String = sf.Field(i).Name
            If ht.ContainsKey(cur) = False Then
                ht.Add(cur, cur)
            End If
        Next

        ' Start mangling the old name to come up with something new by just appending a _# to it.
        i = 1
        While ht.ContainsKey(OldName & "_" & i)
            i += 1
        End While
        Return OldName & "_" & i
    End Function

    Private Function LoadTable(ByVal Shapefile As MapWinGIS.Shapefile, ByRef vTable As DataTable) As Boolean
        Dim keys As DataColumn()
        Dim primKey As Data.DataColumn
        Dim i, j, numFields As Integer
        Dim vals As Object()
        Dim ht As New Hashtable()
        Dim grdTableStyle1 As New DataGridTableStyle()
        Dim grdColStyles() As DataGridTextBoxColumn

        If Not FillFieldHT(Shapefile, ht) Then Exit Function

        Table = New DataTable("DBF")
        vTable = Table 'By Ref assignment in case needed by caller

        With grdTableStyle1
            ' Do not forget to set the MappingName property. 
            ' Without this, the DataGridTableStyle properties
            ' and any associated DataGridColumnStyle objects
            ' will have no effect.
            .MappingName = "DBF"
            '.PreferredColumnWidth = 125
            '.PreferredRowHeight = 15
            '***Added by Nathan Eaton, CALM 02/05***'
            'Disbaled the sort function for the table because this was setting the selection to nothing
            .AllowSorting = False
            '***Added by Nathan Eaton, CALM 02/05***'
            'makes the datagrid readonly if the DBF is readonly
            If (File.GetAttributes(Replace(m_sf.Filename, ".shp", ".dbf")) And FileAttributes.ReadOnly) = FileAttributes.ReadOnly Then
                .ReadOnly = True
            End If
        End With

        ReDim grdColStyles(Shapefile.NumFields)

        primKey = New Data.DataColumn("SHAPE__ID", GetType(Integer))
        primKey.AutoIncrement = True
        primKey.Unique = True
        'primKey.ColumnMapping = MappingType.Hidden

        grdColStyles(0) = New DataGridTextBoxColumn()
        grdColStyles(0).MappingName = "SHAPE__ID"
        grdColStyles(0).HeaderText = "SHAPE__ID"
        AddHandler grdColStyles(0).TextBox.KeyDown, AddressOf DataGridCell_KeyDown
        grdTableStyle1.GridColumnStyles.Add(grdColStyles(0))

        Table.Columns.Add(primKey)

        keys = Table.PrimaryKey
        ReDim keys(0)
        keys(0) = primKey
        Table.PrimaryKey = keys

        numFields = Shapefile.NumFields
        For i = 0 To numFields - 1
            Dim t As Type = Nothing
            Select Case Shapefile.Field(i).Type
                Case MapWinGIS.FieldType.DOUBLE_FIELD
                    t = GetType(Double)
                Case MapWinGIS.FieldType.INTEGER_FIELD
                    t = GetType(Integer)
                Case MapWinGIS.FieldType.STRING_FIELD
                    t = GetType(String)
                Case Else
                    'All others -- assume string
                    t = GetType(String)
            End Select

            grdColStyles(i + 1) = New DataGridTextBoxColumn()
            grdColStyles(i + 1).MappingName = Shapefile.Field(i).Name
            grdColStyles(i + 1).HeaderText = Shapefile.Field(i).Name
            'grdColStyles(i + 1).Width = Shapefile.Field(i).Width
            AddHandler grdColStyles(i + 1).TextBox.KeyDown, AddressOf DataGridCell_KeyDown
            grdTableStyle1.GridColumnStyles.Add(grdColStyles(i + 1))

            Table.Columns.Add(Shapefile.Field(i).Name, t)

        Next

        Table.AcceptChanges()

        '***Added by Nathan Eaton, CALM 02/05***'
        'this is where the Add field error occurs - need to remove style if it exists first
        TableEditorDataGrid.TableStyles.Clear()
        TableEditorDataGrid.TableStyles.Add(grdTableStyle1)

        m_selected = New DataTable("SELECTED_SHAPES")
        m_selected = Table.Copy()

        ReDim vals(numFields)
        Table.BeginLoadData()
        For i = 0 To Shapefile.NumShapes - 1
            vals(0) = i
            For j = 0 To numFields - 1
                vals(j + 1) = Shapefile.CellValue(j, i)
            Next
            Table.LoadDataRow(vals, True)
        Next
        Table.EndLoadData()
        Return True
    End Function

    Private Function FillFieldHT(ByRef Shapefile As MapWinGIS.Shapefile, ByRef ht As Hashtable) As Boolean
        For i As Integer = 0 To Shapefile.NumFields - 1
            Dim cur As String = Shapefile.Field(i).Name
            If ht.ContainsKey(cur) Then
                Dim newName As String = FindSafeFieldName(Shapefile, cur)
                'Chris M 1/3/2007 -- Only do this prompt if the new name
                'is less than or equal to ten chars. Otherwise it will still die.
                'If > 10, prompt for the new name.
                If newName.Length <= 10 Then
                    If MapWinUtility.Logger.Msg("The field name '" & cur & "' already exits in the Attribute Table.  This field must be renamed before displaying the table.  Do you wish to rename this field to '" & newName & "'?", MsgBoxStyle.YesNo, "Name conflict detected") = MsgBoxResult.Yes Then
                        Shapefile.StartEditingTable()
                        Shapefile.Field(i).Name = newName
                        Shapefile.StopEditingTable(True)
                        cur = newName
                    Else
                        Return False ' duplicate field name detected and the user is unwiling to fix the problem.
                    End If
                Else
                    'Prompt for the new name.
                    While cur = newName Or newName.Length < 1 Or newName.Length > 10
                        newName = InputBox("The field name '" & cur & "' already exits in the Attribute Table.  This field must be renamed before displaying the table." & vbCrLf & vbCrLf & "Please enter a new name, less than 10 characters:", "Enter New Field Name", cur)

                        If newName = "" Then Return False 'User didn't do it!
                    End While

                    'Proceed with the new name
                    Shapefile.StartEditingTable()
                    Shapefile.Field(i).Name = newName
                    Shapefile.StopEditingTable(True)
                    cur = newName
                End If
            End If

            ht.Add(cur, cur)
        Next

        Return True
    End Function
    Private Function LoadTable_Columns(ByVal Shapefile As MapWinGIS.Shapefile, ByRef Table As DataTable, ByVal columnOp As Integer, ByVal delcol As Integer) As Boolean
        Dim keys As DataColumn()
        Dim primKey As Data.DataColumn
        Dim i, j, numFields As Integer
        Dim vals As Object()
        Dim ht As New Hashtable
        Dim grdTableStyle1 As New DataGridTableStyle
        Dim grdColStyles() As DataGridTextBoxColumn

        Dim storedatagrid As New DataGrid
        storedatagrid = TableEditorDataGrid


        Dim dt_orig As New DataTable


        dt_orig = storedatagrid.DataSource

        If Not FillFieldHT(Shapefile, ht) Then Exit Function

        Table = New DataTable("DBF")
        With grdTableStyle1
            ' Do not forget to set the MappingName property. 
            ' Without this, the DataGridTableStyle properties
            ' and any associated DataGridColumnStyle objects
            ' will have no effect.
            .MappingName = "DBF"
            '.PreferredColumnWidth = 125
            '.PreferredRowHeight = 15
            '***Added by Nathan Eaton, CALM 02/05***'
            'Disbaled the sort function for the table because this was setting the selection to nothing
            .AllowSorting = False
        End With

        ReDim grdColStyles(Shapefile.NumFields)

        primKey = New Data.DataColumn("SHAPE__ID", GetType(Integer))
        primKey.AutoIncrement = True
        primKey.Unique = True
        'primKey.ColumnMapping = MappingType.Hidden

        grdColStyles(0) = New DataGridTextBoxColumn
        grdColStyles(0).MappingName = "SHAPE__ID"
        grdColStyles(0).HeaderText = "SHAPE__ID"
        AddHandler grdColStyles(0).TextBox.KeyDown, AddressOf DataGridCell_KeyDown
        grdTableStyle1.GridColumnStyles.Add(grdColStyles(0))

        Table.Columns.Add(primKey)

        keys = Table.PrimaryKey
        ReDim keys(0)
        keys(0) = primKey
        Table.PrimaryKey = keys

        numFields = Shapefile.NumFields
        For i = 0 To numFields - 1
            Dim t As Type = Nothing
            Select Case Shapefile.Field(i).Type
                Case MapWinGIS.FieldType.DOUBLE_FIELD
                    t = GetType(Double)
                Case MapWinGIS.FieldType.INTEGER_FIELD
                    t = GetType(Integer)
                Case MapWinGIS.FieldType.STRING_FIELD
                    t = GetType(String)
            End Select

            grdColStyles(i + 1) = New DataGridTextBoxColumn
            grdColStyles(i + 1).MappingName = Shapefile.Field(i).Name
            grdColStyles(i + 1).HeaderText = Shapefile.Field(i).Name
            'grdColStyles(i + 1).Width = Shapefile.Field(i).Width
            AddHandler grdColStyles(i + 1).TextBox.KeyDown, AddressOf DataGridCell_KeyDown
            grdTableStyle1.GridColumnStyles.Add(grdColStyles(i + 1))

            Table.Columns.Add(Shapefile.Field(i).Name, t)

        Next

        Table.AcceptChanges()

        '***Added by Nathan Eaton, CALM 02/05***'
        'this is where the Add field error occurs - need to remove style if it exists first
        TableEditorDataGrid.TableStyles.Clear()
        TableEditorDataGrid.TableStyles.Add(grdTableStyle1)

        m_selected = New DataTable("SELECTED_SHAPES")
        m_selected = Table.Copy()

        ReDim vals(numFields)
        Table.BeginLoadData()



        For i = 0 To dt_orig.Rows.Count - 1  ' Shapefile.NumShapes - 1
            vals(0) = i
            For j = -1 To dt_orig.Columns.Count - columnOp ' 2 for rename, 2 for newfield, 4 for delete
                'CDM -- changed "3 for rename" to "2 for rename", along with matching
                'change in the field rename function, for bugzilla 136
                'mapwinutility.logger.msg(i & "  " & j + 1 & "  " & storedatagrid(i, j + 1)) 'Shapefile.CellValue(j, i)) '

                vals(j + 1) = storedatagrid(i, j + 1)

            Next
            'vals(j + 2) = vbNull
            'mapwinutility.logger.msg("here")
            Table.LoadDataRow(vals, True)

        Next

        Table.EndLoadData()
        Return True
    End Function

    Private Sub DataGrid1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TableEditorDataGrid.MouseUp
        Dim t As DataGrid.HitTestInfo = TableEditorDataGrid.HitTest(e.X, e.Y)
        Dim i As Integer, dt As DataTable

        dt = TableEditorDataGrid.DataSource

        '***Added by Nathan Eaton, CALM 02/05***'
        If mnuShowSelected.Text = ShowAllShapesText Then
            'dont synch shapes if only selected records are shown in the datagrid
            Exit Sub
        End If

        If t.Column = -1 Then ' clicked on the row header column - selecting shapes on map
            If Not g_MW Is Nothing Then 'If this is being called as a plug-in...
                g_MW.View.LockMap()
                g_MW.View.ClearSelectedShapes()


                For i = 0 To dt.Rows.Count - 1
                    If TableEditorDataGrid.IsSelected(i) Then
                        g_MW.View.SelectedShapes.AddByIndex(TableEditorDataGrid.Item(i, 0), g_MW.View.SelectColor)
                    End If
                Next
                mnuZoomToSelected.Enabled = (g_MW.View.SelectedShapes.NumSelected > 0)
                mnuShowSelected.Enabled = (g_MW.View.SelectedShapes.NumSelected > 0)
                g_MW.View.UnlockMap()
            End If
        End If

        '***Added by Nathan Eaton, CALM 02/05***'
        'adjust the select records label 
        Dim querytable As DataTable = Me.TableEditorDataGrid.DataSource
        If Not g_MW Is Nothing Then Me.Selected_Label.Text = g_MW.View.SelectedShapes.NumSelected & " of " & querytable.Rows.Count & " Selected"
    End Sub

    Private Sub DataGrid1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TableEditorDataGrid.MouseDown
        Dim info As DataGrid.HitTestInfo = TableEditorDataGrid.HitTest(e.X, e.Y)
        Dim max As Integer
        Dim mouse_point As System.Drawing.Point
        mouse_point.X = e.X
        mouse_point.Y = e.Y

        '***Added by Nathan Eaton, CALM 02/05***'
        'display the context menu if the column heading was clicked
        If info.Row = -1 And info.Column >= 0 Then
            If e.Button = System.Windows.Forms.MouseButtons.Right Then
                gb_selected_column = info.Column
                Me.Column_context.Show(TableEditorDataGrid, mouse_point)
            End If
        Else
            'Right-clicked a normal column
            Try
                Dim s As String = TableEditorDataGrid.Item(info.Row, info.Column).ToString()
                If s.ToLower.StartsWith("http") Or s.ToLower().StartsWith("file://") Then
                    System.Diagnostics.Process.Start(s)
                End If
            Catch
            End Try
        End If

        If ReferenceEquals(TableEditorDataGrid.DataSource, m_table) Then
            max = m_table.Rows.Count
        Else
            max = m_selected.Rows.Count
        End If

        If info.Row = -1 OrElse info.Column < 1 OrElse info.Row > (max - 1) Then
            TableEditorDataGrid.ReadOnly = True
        Else
            TableEditorDataGrid.ReadOnly = False
        End If
    End Sub

    Private Sub xRestoreMainView()
        If Not ReferenceEquals(TableEditorDataGrid.DataSource, m_table) Then
            mnuShowSelected.Text = ShowSelectedShapesText
            btnShowSelected.ToolTipText = ShowSelectedShapesText

            ' Not Implemented mnuShowSelected.Tooltip = "Show selected shapes"
            TableEditorDataGrid.DataSource = m_table
            Dim i As Integer, ht As New Hashtable
            For i = 0 To m_selected.Rows.Count - 1
                If Not ht.Contains(m_selected.Rows(i)(0)) Then
                    ht.Add(m_selected.Rows(i)(0), True)
                End If
            Next
            Dim curItem As Integer
            For i = 0 To m_table.Rows.Count - 1
                curItem = TableEditorDataGrid.Item(i, 0)
                If ht.ContainsKey(curItem) Then
                    TableEditorDataGrid.Select(i)

                    ht.Remove(curItem)
                End If
            Next
            m_oldRow = -1
            m_oldCol = -1
        End If
    End Sub

    ''' 
    ''' Abel G. Perez
    ''' www.WarpEngine.com
    ''' Sep 20, 2008
    ''' Will simulate flash of a polygon shape by turning its visibility on and off for several seconds
    ''' and will also display a crosshair across the map centered on the shape. Tested with a polygon
    ''' shapefile but should work with lines and points.
    ''' 
    ''' Adapted to MapWindow/Table Editor by Chris Michaelis
    Public Sub FlashSelected()
        If Not g_MW.View.SelectedShapes Is Nothing AndAlso g_MW.View.SelectedShapes.NumSelected > 0 Then
            Dim hndLineDrawing As Integer = g_MW.View.Draw.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList)
            Dim sfl As MapWinGIS.Shapefile = g_MW.Layers(g_MW.Layers.CurrentLayer).GetObject()
            For i As Integer = 0 To g_MW.View.SelectedShapes.NumSelected - 1
                Dim shp As MapWinGIS.Shape = sfl.Shape(g_MW.View.SelectedShapes(i).ShapeIndex)
                Dim exts As MapWinGIS.Extents = g_MW.View.Extents
                Dim pt As New MapWinGIS.Point

                'Centroid function only works for polygons
                If shp.ShapeType = MapWinGIS.ShpfileType.SHP_POLYGON Or shp.ShapeType = MapWinGIS.ShpfileType.SHP_POLYGONZ Or shp.ShapeType = MapWinGIS.ShpfileType.SHP_POLYGONM Then
                    pt = MapWinGeoProc.Utils.Centroid(shp)
                Else
                    pt.x = (shp.Extents.xMax + shp.Extents.xMin) / 2.0F
                    pt.y = (shp.Extents.yMax + shp.Extents.yMin) / 2.0F
                End If

                If Not (pt.x < exts.xMin Or pt.x > exts.xMax Or pt.y < exts.yMin Or pt.y > exts.yMax) Then
                    'now draw two fat lines, one vertical and one horizontal to focus the center of the polygon                    
                    g_MW.View.Draw.DrawLine(pt.x, exts.yMin, pt.x, exts.yMax, 4, Drawing.Color.Cyan) 'horizontal
                    g_MW.View.Draw.DrawLine(exts.xMin, pt.y, shp.Extents.xMax, pt.y, 4, Drawing.Color.Cyan) 'vertical
                End If
            Next i

            'flash for a couple cycles, each one being 100 milliseconds in length
            For cycle As Integer = 0 To 4
                For i As Integer = 0 To g_MW.View.SelectedShapes.NumSelected - 1
                    g_MW.Layers(g_MW.Layers.CurrentLayer).Shapes(g_MW.View.SelectedShapes(i).ShapeIndex).Visible = False
                Next i
                g_MW.Refresh()
                Application.DoEvents()
                Threading.Thread.Sleep(100)
                Application.DoEvents()
                g_MW.View.Redraw()
                For i As Integer = 0 To g_MW.View.SelectedShapes.NumSelected - 1
                    g_MW.Layers(g_MW.Layers.CurrentLayer).Shapes(g_MW.View.SelectedShapes(i).ShapeIndex).Visible = True
                Next i
                g_MW.Refresh()
                Application.DoEvents()
                Threading.Thread.Sleep(100)
                Application.DoEvents()
                g_MW.View.Redraw()
            Next cycle

            'and finally clear the line drawings
            g_MW.View.Draw.ClearDrawing(hndLineDrawing)
        End If
    End Sub

    Private Sub ShowSelected()
        btnApply_Click(tbbRefresh, Nothing) 'Will ask before outright saving
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim i As Integer
            If ReferenceEquals(TableEditorDataGrid.DataSource, m_selected) Then
                InitAll() '...refresh

                'added by NE to stop problems with selected datagrid and editing
                mnuQuery.Enabled = True
                mnuSelectAll.Enabled = True
                mnuSelectNone.Enabled = True
                mnuSwitchSelection.Enabled = True
                mnuReplace.Enabled = True

                'dont allow changes to be saved if you are only looking at the selected records
                'Chris M 7/10/2006 - This is now allowed. See comments on UpdateDBF.
                Me.btnApply.Enabled = True
                Me.btnClose.Enabled = True

            Else
                mnuShowSelected.Text = ShowAllShapesText
                btnShowSelected.ToolTipText = ShowAllShapesText

                'added by NE to stop problems with selected datagrid and editing
                mnuQuery.Enabled = False
                mnuSelectAll.Enabled = False
                mnuSelectNone.Enabled = False
                mnuSwitchSelection.Enabled = False
                mnuReplace.Enabled = False

                'dont allow changes to be saved if you are only looking at the selected records
                'Chris M 7/10/2006 - This is now allowed. See comments on UpdateDBF.
                'Me.btnapply.enabled = false
                'Me.btnClose.Enabled = False

                m_selected.BeginLoadData()
                m_selected.Clear()
                For i = 0 To m_table.Rows.Count - 1
                    If TableEditorDataGrid.IsSelected(i) Then
                        'Chris M fix for selecting shapes after sorting (bug 431) m_selected.ImportRow(m_table.Rows(i))
                        m_selected.ImportRow(m_table.Rows(TableEditorDataGrid.Item(i, 0)))
                    End If
                Next
                m_selected.EndLoadData()
                TableEditorDataGrid.DataSource = m_selected
                m_oldRow = -1
                m_oldCol = -1
            End If
        Catch e As Exception
            MapWinUtility.Logger.Dbg("Error encountered: " + e.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub Column_Expression_Calculate(ByVal DestField As String, ByVal calculate_string As String)
        '***Added by Nathan Eaton, CALM 02/05***'
        'enfore the column expression on the active column

        Dim dt As DataTable
        Dim column As Integer = -1

        Try
            dt = TableEditorDataGrid.DataSource

            For i As Integer = 0 To dt.Columns.Count - 1
                If dt.Columns(i).Caption.ToLower().Trim() = DestField.ToLower().Trim() Then
                    column = i
                End If
            Next

            If column = -1 Then
                MapWinUtility.Logger.Msg("Could not find destination field!", MsgBoxStyle.Exclamation, "Error Occurred")
                Return
            End If

            'Ensure that it's not tolower or toupper -- these can't be done as an expression
            If calculate_string.ToLower().Contains("tolower") Or calculate_string.ToLower().Contains("toupper") Or calculate_string.ToLower().Contains("proper") Then
                If Not calculate_string.Contains("(") Then
                    MapWinUtility.Logger.Msg("The expression doesn't contain parenthesis!", MsgBoxStyle.Exclamation, "No Parenthesis")
                    Return
                End If

                Dim fromfield As String = calculate_string.Substring(calculate_string.IndexOf("(") + 1).Trim()
                fromfield = fromfield.Trim(New Char() {")"})

                Dim fromcolumn As Integer = -1
                For i As Integer = 0 To dt.Columns.Count - 1
                    If dt.Columns(i).Caption.ToLower().Trim() = fromfield.ToLower().Trim() Then
                        fromcolumn = i
                    End If
                Next

                If fromcolumn = -1 Then
                    MapWinUtility.Logger.Msg("Could not find source field!", MsgBoxStyle.Exclamation, "Error Occurred")
                    Return
                End If

                For z As Integer = 0 To CType(TableEditorDataGrid.DataSource, DataTable).Rows.Count - 1
                    If calculate_string.ToLower().Contains("tolower") Then
                        dt.Columns(column).ReadOnly = False
                        TableEditorDataGrid.Item(z, column) = TableEditorDataGrid.Item(z, fromcolumn).ToString().ToLower()
                    ElseIf calculate_string.ToLower().Contains("toupper") Then
                        dt.Columns(column).ReadOnly = False
                        TableEditorDataGrid.Item(z, column) = TableEditorDataGrid.Item(z, fromcolumn).ToString().ToUpper()
                    ElseIf calculate_string.ToLower().Contains("proper") Then
                        dt.Columns(column).ReadOnly = False
                        TableEditorDataGrid.Item(z, column) = ToProper(TableEditorDataGrid.Item(z, fromcolumn).ToString())
                    End If
                Next
            Else
                'Let the datatable do it
                dt.Columns(column).Expression = calculate_string
            End If
        Catch e As System.Exception
            MapWinUtility.Logger.Msg("Syntax Error", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End Try
        btnApply.Enabled = True
        m_TrulyChanged = True

        TableEditorDataGrid.Refresh()
    End Sub

    Private Function ToProper(ByVal calculate_string As String) As String
        ' Added by Simon Batson 05 June 2007
        ' Converts the first character of each word to upper case and the rest of the word to lower case.
        Dim properString As String = ""
        Dim tidy_string As String = calculate_string.ToLower().Trim(New [Char]() {" "c})
        Dim split As String() = tidy_string.Split(New [Char]() {" "c})
        For i As Integer = 0 To split.Length - 1
            If split(i).Length > 0 Then ' Got Something
                properString += split(i).Substring(0, 1).ToUpper()
                If split(i).Length > 1 Then ' Got more than 1 character
                    properString += split(i).Substring(1)
                End If
            End If
            properString += " "
        Next
        ToProper = properString.Trim(New [Char]() {" "c})
    End Function
    Private Sub MenuItemClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuAddField.Click, mnuRemoveField.Click, mnuShowSelected.Click, mnuZoomToSelected.Click, mnuRenameField.Click, mnuQuery.Click, mnuFind.Click, mnuSelectAll.Click, mnuSelectNone.Click, mnuSwitchSelection.Click, mnuReplace.Click, mnuExport.Click
        Dim item As Windows.Forms.MenuItem = CType(sender, MenuItem)

        Select Case (item.Text)
            Case mnuAddField.Text
                AddField()
            Case mnuRemoveField.Text
                RemoveField()
            Case ShowSelectedShapesText, ShowAllShapesText, "Show Selected Shapes", "Show All Shapes", mnuShowSelected.Text
                ShowSelected() 'The same funciton call flips it back to show all.
            Case mnuZoomToSelected.Text
                ZoomToSelected()
            Case mnuRenameField.Text
                RenameField()

                '***Added by Nathan Eaton, CALM 02/05***'
            Case mnuQuery.Text
                Queryform()
            Case mnuFind.Text
                Find()
            Case mnuSelectAll.Text
                Select_All()
            Case mnuSelectNone.Text
                Select_None()
            Case mnuSwitchSelection.Text
                Switch_Selection()
            Case mnuReplace.Text
                Replaceform()
            Case mnuExport.Text
                ExportShapefile()
        End Select
    End Sub

    'From Nathan Eaton, CALM
    Public Sub ExportShapefile()
        If g_MW Is Nothing Then
            MsgBox("The Export Selected Shapes functionality is only valid when used directly from MapWindow.", MsgBoxStyle.Information, "Functionality Unavailable")
            Return 'Called directly, not as a plug-in
        End If

        If mPublics.g_MW.Layers.NumLayers = 0 Then
            MapWinUtility.Logger.Msg("Please select a layer first", MsgBoxStyle.Exclamation, "Select Layer")
            Exit Sub
        End If
        If mPublics.g_MW.View.SelectedShapes.NumSelected = 0 Then
            MapWinUtility.Logger.Msg("There are no Selected Features to Convert", MsgBoxStyle.Exclamation, "Empty Selection")
            Exit Sub
        End If

        Dim saveFileDialog1 As New SaveFileDialog
        saveFileDialog1.Filter = "Shapefiles (*.shp)|*.shp"
        saveFileDialog1.FilterIndex = 2
        saveFileDialog1.RestoreDirectory = True
        If saveFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim loadshapefilechoice As Boolean = IIf(MapWinUtility.Logger.Msg("Do you want to load the new shapefile?", MsgBoxStyle.YesNo, "Load Layer") = MsgBoxResult.Yes, True, False)

            MapWinGeoProc.Selection.ExportSelectedMWViewShapes(mPublics.g_MW, saveFileDialog1.FileName, loadshapefilechoice)
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Statistics_sub()
        '***Added by Nathan Eaton, CALM 02/05***'
        'This Sub computes statistics for the selected column and the selected records

        Dim dt As DataTable
        dt = TableEditorDataGrid.DataSource
        Dim i, count As Integer
        Dim sum As Double, mean As Double, min As Double, max As Double, range As Double, stdev As Double
        Dim current_value As Double
        Dim current_value_collection As New Collection

        count = 0
        sum = 0
        min = 99999999999999999
        max = -99999999999999999


        For i = 0 To dt.Rows.Count - 1
            current_value = TableEditorDataGrid(i, gb_selected_column)
            If TableEditorDataGrid.IsSelected(i) Then
                current_value_collection.Add(current_value)
                sum = sum + current_value
                count = count + 1
                If current_value > max Then
                    max = current_value
                End If
                If current_value < min Then
                    min = current_value
                End If
            End If
        Next

        If count = 0 Then
            MapWinUtility.Logger.Msg("No Rows Selected", MsgBoxStyle.Exclamation, "Statistics")
            Exit Sub
        End If

        mean = sum / count
        range = max - min

        Dim loop_result As Double
        Dim mean_diff As Double
        Dim sum_mean_diff As Double

        sum_mean_diff = 0
        For Each loop_result In current_value_collection
            mean_diff = Math.Pow((loop_result - mean), 2)
            sum_mean_diff = sum_mean_diff + mean_diff
        Next

        stdev = Math.Sqrt(sum_mean_diff / 999)

        Dim stat_form As New frmStatistics
        stat_form.Statistics_tb.Text = "Column:  " & dt.Columns(gb_selected_column).ColumnName & ControlChars.NewLine & "Sum:  " & Math.Round(sum, 2) & ControlChars.NewLine & "Count:  " & count & ControlChars.NewLine & "Mean:  " & Math.Round(mean, 2) & ControlChars.NewLine & "Maximum:  " & Math.Round(max, 2) & ControlChars.NewLine & "Minimum:  " & Math.Round(min, 2) & ControlChars.NewLine & "Range:  " & Math.Round(range, 2) & ControlChars.NewLine & "Standard Deviation:  " & Math.Round(stdev, 2)

        'display the column statistics 
        stat_form.ShowDialog()
    End Sub
    Private Sub Sort_Ascending(ByVal sort_column As Integer)
        '***Added by Nathan Eaton, CALM 02/05***'
        'the sorting functionality for the grid was disabled to stop the selection being reset to nothing
        'so instead this function available on the context menu can store and redeploy the selected records
        'after the sort. It is quite slow, but it works.

        Dim dt As DataTable
        Dim m, n, i, k As Integer
        dt = TableEditorDataGrid.DataSource
        Dim dv As DataView = dt.DefaultView
        Dim selected_collection As New Collection

        If Not g_MW Is Nothing Then g_MW.View.LockMap()

        For i = 0 To dt.Rows.Count - 1
            If TableEditorDataGrid.IsSelected(i) Then
                selected_collection.Add(TableEditorDataGrid(i, 0))
            End If
        Next

        dv.Sort() = dt.Columns(sort_column).ColumnName & " ASC"

        lblUpdating.Visible = True
        lblUpdating.Refresh()
        UpdateProgress.Visible = True
        UpdateProgress.Minimum = 0
        UpdateProgress.Maximum = selected_collection.Count
        k = 0

        For Each m In selected_collection
            UpdateProgress.Value = k
            For n = 0 To dt.Rows.Count - 1
                If TableEditorDataGrid(n, 0) = m.ToString Then
                    TableEditorDataGrid.Select(n)
                    Exit For
                End If
            Next
            k = k + 1
        Next

        lblUpdating.Visible = False
        UpdateProgress.Visible = False

        TableEditorDataGrid.Refresh()
        If Not g_MW Is Nothing Then g_MW.View.UnlockMap()
    End Sub
    Private Sub Sort_Descending(ByVal sort_column As Integer)
        '***Added by Nathan Eaton, CALM 02/05***'
        'the sorting functionality for the grid was disabled to stop the selection being reset to nothing
        'so instead this function available on the context menu can store and redeploy the selected records
        'after the sort. It is quite slow, but it works.

        Dim dt As DataTable
        Dim m, n, i, k As Integer
        dt = TableEditorDataGrid.DataSource
        Dim dv As DataView = dt.DefaultView
        Dim selected_collection As New Collection

        If Not g_MW Is Nothing Then g_MW.View.LockMap()

        For i = 0 To dt.Rows.Count - 1
            If TableEditorDataGrid.IsSelected(i) Then
                selected_collection.Add(TableEditorDataGrid(i, 0))
            End If
        Next

        dv.Sort() = dt.Columns(sort_column).ColumnName & " desc"

        lblUpdating.Visible = True
        lblUpdating.Refresh()
        UpdateProgress.Visible = True
        UpdateProgress.Minimum = 0
        UpdateProgress.Maximum = selected_collection.Count
        k = 0

        For Each m In selected_collection
            UpdateProgress.Value = k
            For n = 0 To dt.Rows.Count - 1
                If TableEditorDataGrid(n, 0) = m.ToString Then
                    TableEditorDataGrid.Select(n)
                    Exit For
                End If
            Next
            k = k + 1
        Next

        lblUpdating.Visible = False
        UpdateProgress.Visible = False

        TableEditorDataGrid.Refresh()
        If Not g_MW Is Nothing Then g_MW.View.UnlockMap()
    End Sub

    Private Sub Replaceform()
        '***Added by Nathan Eaton, CALM 02/05***'
        'this sub fires up the replace form

        Dim dlg As frmReplace

        dlg = New frmReplace
        dlg.Tableform = Me
        dlg.TopMost = True

        If Not g_MW Is Nothing Then
            dlg.Owner = mPublics.g_MW
        Else
            dlg.Owner = Me
        End If

        dlg.Show()
    End Sub
    Public Sub Replace_sub(ByVal find_string As String, ByVal replace_string As String)
        '***Added by Nathan Eaton, CALM 02/05***'
        'This sub performs the replace function on the table

        Dim i, j, k, num_replacements As Integer, dt As DataTable
        Dim cell_string As String, num_replacements_string As String
        Dim format_exception1, format_exception2 As Boolean

        'Need to test for exceptions, ie strings vs numbers, doubles vs integers
        If Char.IsNumber(find_string) = True And Char.IsNumber(replace_string) = False Then
            format_exception1 = True
        End If

        If Char.IsNumber(find_string) = True And replace_string Like "*.*" And Char.IsNumber(replace_string) = True Then
            format_exception2 = True
        End If

        If find_string = "" Then
            Exit Sub
        End If

        dt = TableEditorDataGrid.DataSource

        num_replacements = 0
        lblUpdating.Visible = True
        lblUpdating.Refresh()
        UpdateProgress.Visible = True
        UpdateProgress.Minimum = 0
        UpdateProgress.Maximum = (dt.Rows.Count) * (dt.Columns.Count - 1)
        k = 0

        For i = 0 To dt.Rows.Count - 1
            For j = 1 To dt.Columns.Count - 1
                UpdateProgress.Value = k

                Try
                    cell_string = TableEditorDataGrid(i, j)
                    If cell_string <> "" Then
                        If dt.Columns(j).DataType.ToString <> "System.String" And format_exception1 = True Then
                            'exception where find string is a number but the replace string is a string
                        ElseIf dt.Columns(j).DataType.ToString = "System.Int32" And format_exception2 = True Then
                            'exception where a decimal number is being put into an integer field
                        ElseIf dt.Columns(j).DataType.ToString = "System.Double" And Replace(cell_string, find_string, replace_string).IndexOf(".") <> Replace(cell_string, find_string, replace_string).LastIndexOf(".") Then
                            'exception where replace string has a decimal, and cell string already has a decimal
                        Else
                            If cell_string.ToLower Like "*" & find_string.ToLower & "*" Then
                                'orig_cell_string = cell_string
                                'string_start = InStr(cell_string.ToLower, find_string.ToLower)
                                'cell_string = Replace(cell_string.ToLower, find_string.ToLower, replace_string.ToLower)
                                cell_string = CReplace(cell_string, find_string, replace_string, 1) ' cell_string.Replace(Mid(cell_string, string_start, find_string.Length), replace_string) 'Replace(cell_string, find_string.ToLower, replace_string)
                                TableEditorDataGrid(i, j) = cell_string
                                num_replacements = num_replacements + 1
                            End If
                        End If

                    End If
                Catch ex As Exception
                End Try
                k = k + 1
            Next
        Next

        num_replacements_string = num_replacements

        MapWinUtility.Logger.Msg(num_replacements_string & " Replacements were made", MsgBoxStyle.Information, "Replacements")

        TableEditorDataGrid.Refresh()

        lblUpdating.Visible = False
        UpdateProgress.Visible = False

        If num_replacements > 0 Then
            btnApply.Enabled = True
            m_TrulyChanged = True
        End If

    End Sub

    '--- Custom Replace Function CReplace
    '---	VB.NET Recursive Version
    '---	intMode = 0 = Case-Sensitive
    '---	intMode = 1 = Case-Insensitive
    'Addeed By Nathan Eaton, CALM 03/05
    Function CReplace(ByVal strExpression As String, _
    ByVal strSearch As String, _
    ByVal strReplace As String, _
    ByVal intMode As Integer _
     ) As String
        Dim strReturn As String
        Dim lngPosition As Long
        Dim strTemp As String

        If intMode = 1 Then '--- vbTextCompare
            strTemp = strExpression.ToUpper()
            lngPosition = strTemp.IndexOf(strSearch.ToUpper())
            If lngPosition >= 0 Then
                strTemp = strExpression.Remove(lngPosition, strSearch.Length)
                strTemp = strTemp.Insert(lngPosition, strReplace)
                strReturn = CReplace(strTemp, strSearch, strReplace, intMode)
            Else
                strReturn = strExpression
            End If
        Else
            '--- vbBinaryCompare
            strReturn = strExpression.Replace(strSearch, strReplace)
        End If

        CReplace = strReturn
    End Function


    Private Sub Select_All()
        '03/05/2009
        'Bug no : 1106 is fixed by Kandasamy Prasanna (Kan10)
        If g_MW Is Nothing Then
            MsgBox("The Select All Shapes functionality is only valid when used directly from MapWindow.", MsgBoxStyle.Information, "Functionality Unavailable")
            Return 'Called directly, not as a plug-in
        End If

        '***Added by Nathan Eaton, CALM 02/05***'
        'selects all records

        Dim i, j As Integer, dt As DataTable
        'Dim ht As New Hashtable

        dt = TableEditorDataGrid.DataSource

        lblUpdating.Visible = True
        lblUpdating.Refresh()
        UpdateProgress.Visible = True
        UpdateProgress.Minimum = 0
        'UpdateProgress.Value = 0
        UpdateProgress.Maximum = dt.Rows.Count
        j = 0

        For i = 0 To dt.Rows.Count - 1
            UpdateProgress.Value = j
            TableEditorDataGrid.Select(i)
            g_MW.View.SelectedShapes.AddByIndex(TableEditorDataGrid(i, 0), g_MW.View.SelectColor)
            j = j + 1
        Next
        lblUpdating.Visible = False
        UpdateProgress.Visible = False
        UpdateProgress.Value = UpdateProgress.Value + 1
        Me.Selected_Label.Text = g_MW.View.SelectedShapes.NumSelected & " of " & dt.Rows.Count & " Selected"

    End Sub
    Private Sub Select_None()
        If g_MW Is Nothing Then
            MsgBox("The Select None functionality is only valid when used directly from MapWindow.", MsgBoxStyle.Information, "Functionality Unavailable")
            Return 'Called directly, not as a plug-in
        End If
        '***Added by Nathan Eaton, CALM 02/05***'
        'clears all selected records

        Dim i, j As Integer, dt As DataTable

        dt = TableEditorDataGrid.DataSource

        lblUpdating.Visible = True
        lblUpdating.Refresh()
        UpdateProgress.Visible = True
        UpdateProgress.Minimum = 0
        UpdateProgress.Maximum = dt.Rows.Count - 1
        j = 0

        'code added to cater for colloring problem when new selection is made
        Dim layer_scheme As MapWinGIS.ShapefileColorScheme
        Dim mylayerhandle As Integer

        mylayerhandle = g_MW.Layers.CurrentLayer.GetHashCode

        layer_scheme = g_MW.Layers(mylayerhandle).ColoringScheme
        g_MW.View.ClearSelectedShapes()
        g_MW.Layers(mylayerhandle).ColoringScheme = layer_scheme

        For i = 0 To dt.Rows.Count - 1
            UpdateProgress.Value = j
            TableEditorDataGrid.UnSelect(i)
            j = j + 1
        Next

        lblUpdating.Visible = False
        UpdateProgress.Visible = False

        Me.Selected_Label.Text = g_MW.View.SelectedShapes.NumSelected & " of " & dt.Rows.Count & " Selected"

    End Sub

    Private Sub Switch_Selection()
        If g_MW Is Nothing Then
            MsgBox("The Switch Selection functionality is only valid when used directly from MapWindow.", MsgBoxStyle.Information, "Functionality Unavailable")
            Return 'Called directly, not as a plug-in
        End If

        '***Added by Nathan Eaton, CALM 02/05***'
        'as the name suggests thsi sub switches the selected records

        Dim i, j As Integer, dt As DataTable

        dt = TableEditorDataGrid.DataSource

        lblUpdating.Visible = True
        lblUpdating.Refresh()
        UpdateProgress.Visible = True
        UpdateProgress.Minimum = 0
        UpdateProgress.Maximum = dt.Rows.Count - 1
        j = 0

        Dim selected_shapes As New Collection

        For i = 0 To dt.Rows.Count - 1
            UpdateProgress.Value = j
            If TableEditorDataGrid.IsSelected(i) = True Then
                TableEditorDataGrid.UnSelect(i)
                g_MW.View.SelectedShapes.RemoveByShapeIndex(TableEditorDataGrid(i, 0))
            Else
                TableEditorDataGrid.Select(i)
                selected_shapes.Add((TableEditorDataGrid(i, 0)))
            End If
            j = j + 1
        Next

        'code added to cater for colloring problem when new selection is made
        Dim layer_scheme As MapWinGIS.ShapefileColorScheme
        Dim mylayerhandle As Integer

        mylayerhandle = g_MW.Layers.CurrentLayer.GetHashCode

        layer_scheme = g_MW.Layers(mylayerhandle).ColoringScheme

        g_MW.Layers(mylayerhandle).ColoringScheme = layer_scheme

        For i = 1 To selected_shapes.Count
            g_MW.View.SelectedShapes.AddByIndex(selected_shapes(i), g_MW.View.SelectColor)
        Next

        lblUpdating.Visible = False
        UpdateProgress.Visible = False

        Me.Selected_Label.Text = g_MW.View.SelectedShapes.NumSelected & " of " & dt.Rows.Count & " Selected"

    End Sub

    Private Sub Selected_Input_Sub(ByVal column_index As Integer)
        '***Added by Nathan Eaton, CALM 02/05***'
        'allow the user to specify a value for all of the selected records in the active column

        Dim dt As DataTable
        Dim calculate_string As String
        Dim new_item_collection As New Collection
        Dim i As Integer

        calculate_string = InputBox("Input" & ControlChars.NewLine & ControlChars.NewLine & ControlChars.NewLine & ControlChars.NewLine & "(No Quotes Needed for String Values)", "Assign Values (Selected Records)")

        Try

            dt = TableEditorDataGrid.DataSource

            For i = 0 To dt.Rows.Count - 1
                If TableEditorDataGrid.IsSelected(i) = True Then

                    TableEditorDataGrid(i, column_index) = calculate_string
                End If
            Next

        Catch e As System.ArgumentException
            MapWinUtility.Logger.Msg("Syntax Error", MsgBoxStyle.Exclamation, "Syntax Error")
            Exit Sub
        Catch e As System.FormatException
            MapWinUtility.Logger.Msg("Syntax Error", MsgBoxStyle.Exclamation, "Syntax Error")
            Exit Sub
        End Try

        btnApply.Enabled = True
        m_TrulyChanged = True
    End Sub

    Private Sub Find()
        '***Added by Nathan Eaton, CALM 02/05***
        'This sub finds the first row where a cell contains the given find string

        Dim i, j As Integer, dt As DataTable
        Dim cell_string As String
        Dim find_string As String

        find_string = InputBox("Enter Find String", "Find")

        If find_string = "" Then
            Exit Sub
        End If

        dt = TableEditorDataGrid.DataSource

        For i = 0 To dt.Rows.Count - 1
            For j = 1 To dt.Columns.Count - 1
                Try
                    cell_string = TableEditorDataGrid(i, j)
                    If cell_string.ToLower Like "*" & find_string.ToLower & "*" Then
                        TableEditorDataGrid.Select(i)
                        If mnuShowSelected.Text <> ShowAllShapesText Then
                            'dont synch shapes if only selected records are shown
                            If Not g_MW Is Nothing Then g_MW.View.SelectedShapes.AddByIndex(TableEditorDataGrid(i, 0), g_MW.View.SelectColor)
                            TableEditorDataGrid.CurrentRowIndex = i
                            Dim querytable As DataTable = Me.TableEditorDataGrid.DataSource
                            If Not g_MW Is Nothing Then Me.Selected_Label.Text = g_MW.View.SelectedShapes.NumSelected & " of " & querytable.Rows.Count & " Selected"
                            If Not g_MW Is Nothing Then mnuZoomToSelected.Enabled = (g_MW.View.SelectedShapes.NumSelected > 0)
                            If Not g_MW Is Nothing Then mnuShowSelected.Enabled = (g_MW.View.SelectedShapes.NumSelected > 0)
                            Exit Sub
                        End If
                        Exit Sub
                    End If
                Catch ex As Exception
                End Try
            Next
        Next

        MapWinUtility.Logger.Msg("String could not be found", MsgBoxStyle.Exclamation, "Find")

        'update the selected records label

    End Sub
    Private Sub Queryform()
        '***Added by Nathan Eaton, CALM 02/05***
        'fire up the Query form
        If QueryDlg Is Nothing OrElse QueryDlg.IsDisposed Then QueryDlg = New mwTableEditor.frmQueryBuilder
        QueryDlg.TopMost = True

        QueryDlg.Fields_lb.Items.Clear()
        For i As Integer = 0 To m_sf.NumFields - 1
            QueryDlg.Fields_lb.Items.Insert(i, m_sf.Field(i).Name)
        Next
        QueryDlg.Tableform = Me
        If g_MW Is Nothing Then
            QueryDlg.Owner = Me
        Else
            QueryDlg.Owner = mPublics.g_MW
        End If
        QueryDlg.Show()
    End Sub
    Public Sub Query(ByVal querystring As String)
        '***Added by Nathan Eaton, CALM 02/05***
        'This Sub performs the given query

        Dim querytable As DataTable
        querytable = TableEditorDataGrid.DataSource

        Try

            Dim foundRows As DataRow()

            Try
                'Fix double-quote string enclosures
                If querystring.Contains("""") And Not querystring.Contains("'") Then querystring = querystring.Replace("""", "'")

                foundRows = querytable.Select(querystring) ', strsort, DataViewRowState.Added)
            Catch e As System.Data.EvaluateException
                MapWinUtility.Logger.Msg("The query you have entered is not valid. Please adjust your query syntax", MsgBoxStyle.Exclamation, "Syntax Error")
                Exit Sub
            End Try

            Dim queryhash As New Hashtable
            Dim i, j As Integer
            Dim singlerow As DataRow

            lblUpdating.Visible = True
            lblUpdating.Refresh()
            UpdateProgress.Visible = True
            UpdateProgress.Minimum = 0
            UpdateProgress.Maximum = m_sf.NumShapes - 1
            j = 0

            If foundRows.Length > 0 Then
                If Not g_MW Is Nothing Then g_MW.View.LockMap()
                If Not g_MW Is Nothing Then g_MW.View.ClearSelectedShapes()

                For Each singlerow In foundRows

                    UpdateProgress.Value = j
                    queryhash.Add(singlerow(0), i)
                    If Not g_MW Is Nothing Then g_MW.View.SelectedShapes.AddByIndex(singlerow(0), g_MW.View.SelectColor)
                    j = j + 1
                Next

                SelectShapes(queryhash)

                If Not g_MW Is Nothing Then mnuZoomToSelected.Enabled = (g_MW.View.SelectedShapes.NumSelected > 0)
                If Not g_MW Is Nothing Then mnuShowSelected.Enabled = (g_MW.View.SelectedShapes.NumSelected > 0)
                If Not g_MW Is Nothing Then g_MW.View.UnlockMap()
            Else
                'BugZilla 651
                If Not g_MW Is Nothing Then g_MW.View.ClearSelectedShapes()
                If Not g_MW Is Nothing Then mnuZoomToSelected.Enabled = (g_MW.View.SelectedShapes.NumSelected > 0)
                If Not g_MW Is Nothing Then mnuShowSelected.Enabled = (g_MW.View.SelectedShapes.NumSelected > 0)
                SynchSelected()
            End If

            lblUpdating.Visible = False
            UpdateProgress.Visible = False

        Catch e As System.Exception
            MapWinUtility.Logger.Msg("Syntax Error", MsgBoxStyle.Exclamation, "Syntax Error")
            Exit Sub
        End Try
    End Sub

    Private Sub ZoomToSelected()
        If g_MW Is Nothing Then
            MsgBox("The Zoom To Selected functionality is only valid when used directly from MapWindow.", MsgBoxStyle.Information, "Functionality Unavailable")
            Return 'Called directly, not as a plug-in
        End If

        Try
            Me.Cursor = Cursors.WaitCursor
            If Not g_MW.View.SelectedShapes Is Nothing AndAlso g_MW.View.SelectedShapes.NumSelected > 0 Then
                ' This code borrowed from the MapWindow.  It should be included on the 
                ' MapWindow.View or MapWindow.View.SelectedShapes interfaces sometime
                ' becuase it is a very useful function, and will have to be duplicated
                ' many times if it is not added.
                Dim m_View As MapWindow.Interfaces.View = g_MW.View

                Dim maxX, maxY, minX, minY As Double
                Dim dx, dy As Double
                Dim tExts As MapWinGIS.Extents

                Dim i As Integer

                With m_View.SelectedShapes(0)
                    maxX = .Extents.xMax
                    minX = .Extents.xMin
                    maxY = .Extents.yMax
                    minY = .Extents.yMin
                End With
                For i = 0 To m_View.SelectedShapes.NumSelected - 1
                    If g_MW.Layers(g_MW.Layers.CurrentLayer).Visible = False Then
                        g_MW.Layers(g_MW.Layers.CurrentLayer).Visible = True
                    End If
                    With m_View.SelectedShapes(i).Extents
                        If .xMax > maxX Then maxX = .xMax
                        If .yMax > maxY Then maxY = .yMax
                        If .xMin < minX Then minX = .xMin
                        If .yMin < minY Then minY = .yMin
                    End With
                Next i

                ' Pad extents now
                dx = maxX - minX
                dx = dx / 8
                If dx = 0 Then
                    dx = 1
                End If
                maxX = maxX + dx
                minX = minX - dx

                dy = maxY - minY
                dy = dy / 8
                If dy = 0 Then
                    dy = 1
                End If
                maxY = maxY + dy
                minY = minY - dy

                tExts = New MapWinGIS.Extents
                If m_View.SelectedShapes.NumSelected = 1 And g_MW.Layers(g_MW.Layers.CurrentLayer).LayerType = MapWindow.Interfaces.eLayerType.PointShapefile Then
                    Dim sf As MapWinGIS.Shapefile = CType(g_MW.Layers(g_MW.Layers.CurrentLayer).GetObject(), MapWinGIS.Shapefile)
                    'Use shape extents - best we can do
                    Dim xpad As Double = (1 / 100) * (sf.Extents.xMax - sf.Extents.xMin)
                    Dim ypad As Double = (1 / 100) * (sf.Extents.yMax - sf.Extents.yMin)
                    tExts.SetBounds(minX + xpad, minY - ypad, 0, maxX - xpad, maxY + ypad, 0)
                Else
                    tExts.SetBounds(minX, minY, 0, maxX, maxY, 0)
                End If
                m_View.Extents = tExts
                tExts = Nothing
                m_View = Nothing
            End If
        Catch e As Exception
            MapWinUtility.Logger.Dbg("Error: " + e.ToString())
            Exit Sub
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ImportFieldsFromDBF()
        If (File.GetAttributes(Replace(m_sf.Filename, ".shp", ".dbf")) And FileAttributes.ReadOnly) = FileAttributes.ReadOnly Then
            MapWinUtility.Logger.Msg("The shapefile table is read only, so cannot be edited", MsgBoxStyle.Exclamation, "Read Only")
            Exit Sub
        End If

        Dim fod As New OpenFileDialog
        fod.Filter = "DBF Files (*.dbf)|*.dbf"
        fod.Title = "Please choose the DBF file whose field definitions you would like to import..."
        If fod.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub

        Dim impTable As New MapWinGIS.Table
        If Not impTable.Open(fod.FileName) Then
            MapWinUtility.Logger.Msg("The table could not be opened.", MsgBoxStyle.Exclamation, "Could Not Open Table")
            Exit Sub
        End If

        If m_sf.StartEditingTable() = False Then
            ' False was retuned!  Something is preventing me from editing the shapefile
            MapWinUtility.Logger.Msg("The shapefile could not be edited", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Error")
            impTable.Close()
            Exit Sub
        End If

        Dim startNum As Integer = m_sf.NumFields
        For z As Integer = 0 To impTable.NumFields - 1
            Dim skipField As Boolean = False
            For i As Integer = 0 To m_sf.NumFields - 1
                If impTable.Field(z).Name = m_sf.Field(i).Name Then
                    ' This is a duplicate entry, not allowed!
                    MapWinUtility.Logger.Msg("The field " & impTable.Field(z).Name & " already exists and will be skipped!", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "Skipped Field")
                    skipField = True
                End If
            Next
            If Not skipField Then
                Dim fld As MapWinGIS.Field
                fld = New MapWinGIS.Field
                fld.Name = impTable.Field(z).Name
                fld.Type = impTable.Field(z).Type
                fld.Precision = impTable.Field(z).Precision
                fld.Key = impTable.Field(z).Key
                fld.Width = impTable.Field(z).Width
                m_sf.EditInsertField(fld, startNum)

                For j As Integer = 0 To m_sf.NumShapes - 1
                    m_sf.EditCellValue(startNum, j, Nothing)
                Next

                startNum += 1
            End If
        Next

        'added by Nathan Eaton CALM 03/50
        'This enables edits to not be applied to the DBF until the apply button is pressed
        TableEditorDataGrid.Refresh()
        Dim oldCursor, ownerCursor As Windows.Forms.Cursor
        oldCursor = Cursor
        ownerCursor = m_owner.Cursor
        Cursor = Cursors.WaitCursor
        m_owner.Cursor = Cursors.WaitCursor
        m_owner.Refresh()

        If LoadTable_Columns(m_sf, m_table, 2, 0) = False Then Exit Sub
        TableEditorDataGrid.DataSource = m_table
        TableEditorDataGrid.CaptionText = m_sf.Filename
        SynchSelected()

        Me.Owner = m_owner
        Cursor = oldCursor
        m_owner.Cursor = ownerCursor
        btnApply.Enabled = True
        m_TrulyChanged = True

        impTable.Close()
        MapWinUtility.Logger.Msg("The field definitions have been imported. Click Apply to make the changes permanent.", MsgBoxStyle.Information, "Done!")
    End Sub

    Public ReadOnly Property NumColumns() As Integer
        Get
            If Table Is Nothing Then Throw New Exception("No table/shapefile loaded!")
            Return Table.Columns.Count
        End Get
    End Property

    Public ReadOnly Property ColumnName(ByVal ColIndex As Integer) As String
        Get
            If Table Is Nothing Then Throw New Exception("No table/shapefile loaded!")
            If Table.Columns.Count < ColIndex Then Throw New Exception("Column index out of range of available columns!")

            Return Table.Columns(ColIndex).Caption
        End Get
    End Property

    Public ReadOnly Property ColumnIndex(ByVal ColumnName As String) As Integer
        Get
            If Table Is Nothing Then Throw New Exception("No table/shapefile loaded!")
            For i As Integer = 0 To Table.Columns.Count - 1
                If Table.Columns(i).Caption.ToLower().Trim() = ColumnName.Trim().ToLower() Then
                    Return i
                End If
            Next
            Return -1
        End Get
    End Property

    Public Property ColumnWidth(ByVal Column As Integer) As Integer
        Get
            If Table Is Nothing Then Throw New Exception("No table/shapefile loaded!")
            If Column > Table.Columns.Count Then Throw New Exception("Column outside of bounds of column count.")
            Return TableEditorDataGrid.TableStyles(0).GridColumnStyles.Item(Column).Width
        End Get
        Set(ByVal value As Integer)
            If Table Is Nothing Then Throw New Exception("No table/shapefile loaded!")
            If Column > Table.Columns.Count Then Throw New Exception("Column outside of bounds of column count.")
            TableEditorDataGrid.TableStyles(0).GridColumnStyles.Item(Column).Width = value
        End Set
    End Property

    Public Property ColumnVisible(ByVal Column As Integer) As Boolean
        Get
            If Table Is Nothing Then Throw New Exception("No table/shapefile loaded!")
            If Column > Table.Columns.Count Then Throw New Exception("Column outside of bounds of column count.")
            Return (TableEditorDataGrid.TableStyles(0).GridColumnStyles.Item(Column).Width > 0)
        End Get
        Set(ByVal value As Boolean)
            If Table Is Nothing Then Throw New Exception("No table/shapefile loaded!")
            If Column > Table.Columns.Count Then Throw New Exception("Column outside of bounds of column count.")
            If Not value Then
                TableEditorDataGrid.TableStyles(0).GridColumnStyles.Item(Column).Width = 0
            Else
                'Set to caption width
                TableEditorDataGrid.TableStyles(0).GridColumnStyles.Item(Column).Width = TableEditorDataGrid.CreateGraphics().MeasureString(Table.Columns(Column).Caption, TableEditorDataGrid.Font).Width
            End If
        End Set
    End Property

    Public Sub ConvertColumnToComboBox(ByVal Column As Integer, ByVal Items() As String)
        If Table Is Nothing Then Throw New Exception("No table/shapefile loaded!")
        If Column > Table.Columns.Count Then Throw New Exception("Column outside of bounds of column count.")

        Dim combo As New DataGridComboBoxColumn()
        combo.ComboBox.MaxDropDownItems = 5
        combo.ComboBox.Items.AddRange(Items)
        combo.MappingName = TableEditorDataGrid.TableStyles(0).GridColumnStyles(Column).MappingName
        combo.HeaderText = TableEditorDataGrid.TableStyles(0).GridColumnStyles(Column).HeaderText
        TableEditorDataGrid.TableStyles(0).GridColumnStyles.Remove(TableEditorDataGrid.TableStyles(0).GridColumnStyles(Column))
        Dim added As Integer = TableEditorDataGrid.TableStyles(0).GridColumnStyles.Add(combo)
        MoveColumn(added, Column)
    End Sub

    Public Sub ConvertColumnToNumericRangeLimited(ByVal Column As Integer, ByVal MinValue As Double, ByVal MaxValue As Double)
        If Table Is Nothing Then Throw New Exception("No table/shapefile loaded!")
        If Column > Table.Columns.Count Then Throw New Exception("Column outside of bounds of column count.")

        Dim limited As New DataGridNumericRangeLimit()
        limited.MaxRange = MaxValue
        limited.MinRange = MinValue
        limited.MappingName = TableEditorDataGrid.TableStyles(0).GridColumnStyles(Column).MappingName
        limited.HeaderText = TableEditorDataGrid.TableStyles(0).GridColumnStyles(Column).HeaderText
        TableEditorDataGrid.TableStyles(0).GridColumnStyles.Remove(TableEditorDataGrid.TableStyles(0).GridColumnStyles(Column))
        Dim added As Integer = TableEditorDataGrid.TableStyles(0).GridColumnStyles.Add(limited)
        MoveColumn(added, Column)
    End Sub

    Public Sub ConvertColumnToMaskedTextBox(ByVal Column As Integer, ByVal Mask As String)
        If Table Is Nothing Then Throw New Exception("No table/shapefile loaded!")
        If Column > Table.Columns.Count Then Throw New Exception("Column outside of bounds of column count.")

        Dim masked As New DataGridMaskedTextColumn()
        masked.Mask = Mask
        masked.MappingName = TableEditorDataGrid.TableStyles(0).GridColumnStyles(Column).MappingName
        masked.HeaderText = TableEditorDataGrid.TableStyles(0).GridColumnStyles(Column).HeaderText
        TableEditorDataGrid.TableStyles(0).GridColumnStyles.Remove(TableEditorDataGrid.TableStyles(0).GridColumnStyles(Column))
        Dim added As Integer = TableEditorDataGrid.TableStyles(0).GridColumnStyles.Add(masked)
        MoveColumn(added, Column)
    End Sub

    Public Property ColumnHeaderText(ByVal Column As Integer) As String
        Get
            Return TableEditorDataGrid.TableStyles(0).GridColumnStyles(Column).HeaderText
        End Get
        Set(ByVal value As String)
            TableEditorDataGrid.TableStyles(0).GridColumnStyles(Column).HeaderText = value
        End Set
    End Property

    Public Sub MoveColumn(ByVal theOldColumn As Integer, ByVal theNewColumn As Integer)
        If theOldColumn = theNewColumn Then Return

        Dim oldTS As DataGridTableStyle = TableEditorDataGrid.TableStyles(0)
        Dim newTS As New DataGridTableStyle()
        Dim i As Integer = 0

        newTS.MappingName = TableEditorDataGrid.TableStyles(0).MappingName

        While i < oldTS.GridColumnStyles.Count
            If i <> theOldColumn And theOldColumn < theNewColumn Then
                newTS.GridColumnStyles.Add(oldTS.GridColumnStyles(i))
            End If

            If i = theNewColumn Then
                newTS.GridColumnStyles.Add(oldTS.GridColumnStyles(theOldColumn))
            End If

            If i <> theOldColumn And theOldColumn > theNewColumn Then
                newTS.GridColumnStyles.Add(oldTS.GridColumnStyles(i))
            End If

            i += 1
        End While

        TableEditorDataGrid.TableStyles.Remove(oldTS)
        TableEditorDataGrid.TableStyles.Add(newTS)
    End Sub

    Public Sub AddField()
        Dim dlg As frmNewField
        Dim i As Integer
        'Dim sf As MapWinGIS.Shapefile

        '***Added by Nathan Eaton, CALM 02/05***
        If (File.GetAttributes(Replace(m_sf.Filename, ".shp", ".dbf")) And FileAttributes.ReadOnly) = FileAttributes.ReadOnly Then
            MapWinUtility.Logger.Msg("The shapefile table is read only, so cannot be edited", MsgBoxStyle.Exclamation, "Read Only")
            Exit Sub
        End If

        dlg = New frmNewField
        dlg.TopMost = True

        If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then

            If dlg.txtFieldName.Text = String.Empty OrElse dlg.txtFieldName.Text.Length < 1 Then
                MapWinUtility.Logger.Msg("Please enter a valid field name", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Error")
                Exit Sub
            End If
            For i = 0 To m_sf.NumFields - 1
                If dlg.txtFieldName.Text = m_sf.Field(i).Name Then
                    ' This is a duplicate entry, not allowed!
                    MapWinUtility.Logger.Msg("The field " & dlg.txtFieldName.Text & " already exists!", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "Error")
                    Exit Sub
                End If
            Next

            ' If I've made it this far then there are no duplicates and the name is valid
            If m_sf.StartEditingTable() = False Then
                ' False was retuned!  Something is preventing me from editing the shapefile
                MapWinUtility.Logger.Msg("The shapefile could not be edited", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Error")
                Exit Sub
            End If

            Dim fld As MapWinGIS.Field
            fld = New MapWinGIS.Field
            fld.Name = dlg.txtFieldName.Text
            Select Case dlg.cmbFieldType.Text
                Case "Double"
                    fld.Type = MapWinGIS.FieldType.DOUBLE_FIELD
                    fld.Precision = dlg.fldPrecision.Value
                Case "Integer"
                    fld.Type = MapWinGIS.FieldType.INTEGER_FIELD
                    fld.Precision = 0
                Case "String"
                    fld.Type = MapWinGIS.FieldType.STRING_FIELD
                    fld.Precision = 0
                Case "Else"
                    ' This case should not happen because I check for these things inside the dlg form.
                    Debug.WriteLine("Wow!  An unexpected error!")
            End Select
            fld.Key = ""
            fld.Width = dlg.fldWidth.Value
            m_sf.EditInsertField(fld, i)

            'added by Nathan Eaton CALM 03/50
            'This enables edits to not be applied to the DBF until the apply button is pressed
            TableEditorDataGrid.Refresh()
            Dim oldCursor, ownerCursor As Windows.Forms.Cursor
            oldCursor = Cursor
            ownerCursor = m_owner.Cursor
            Cursor = Cursors.WaitCursor
            m_owner.Cursor = Cursors.WaitCursor
            m_owner.Refresh()

            If LoadTable_Columns(m_sf, m_table, 2, 0) = False Then Exit Sub
            TableEditorDataGrid.DataSource = m_table
            TableEditorDataGrid.CaptionText = m_sf.Filename
            SynchSelected()

            Me.Owner = m_owner
            Cursor = oldCursor
            m_owner.Cursor = ownerCursor
            Me.btnApply.Enabled = True
            m_TrulyChanged = True
            btnApply.Enabled = True

        End If


    End Sub

    Private Sub RemoveField()

        '***Added by Nathan Eaton, CALM 02/05***
        If (File.GetAttributes(Replace(m_sf.Filename, ".shp", ".dbf")) And FileAttributes.ReadOnly) = FileAttributes.ReadOnly Then
            MapWinUtility.Logger.Msg("The shapefile table is read only, so cannot be edited", MsgBoxStyle.Exclamation, "Read Only")
            Exit Sub
        End If

        Dim dlg As New frmDeleteField(m_sf, IIf(TableEditorDataGrid.CurrentCell.ColumnNumber > 0, TableEditorDataGrid.CurrentCell.ColumnNumber - 1, 0))

        If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            'Cannot remove fields with a selection in place - will cause problems.
            g_MW.View.ClearSelectedShapes()
            SynchSelected()

            m_sf.StartEditingTable()
            Dim numDeleted As Integer = 0
            For i As Integer = dlg.clb.CheckedIndices.Count - 1 To 0 Step -1
                m_sf.EditDeleteField(dlg.clb.CheckedIndices(i))
                numDeleted += 1
            Next

            'added by Nathan Eaton CALM 03/50
            'This enables edits to not be applied to the DBF until the apply button is pressed
            Dim oldCursor, ownerCursor As Windows.Forms.Cursor
            oldCursor = Cursor
            ownerCursor = m_owner.Cursor
            Cursor = Cursors.WaitCursor
            m_owner.Cursor = Cursors.WaitCursor
            m_owner.Refresh()

            If LoadTable_Columns(m_sf, m_table, numDeleted * 3, TableEditorDataGrid.CurrentCell.ColumnNumber - 1) = False Then Exit Sub
            TableEditorDataGrid.DataSource = m_table
            TableEditorDataGrid.CaptionText = m_sf.Filename
            SynchSelected()

            Me.Owner = m_owner
            Cursor = oldCursor
            m_owner.Cursor = ownerCursor

            m_TrulyChanged = True
            btnApply.Enabled = True
        End If
    End Sub

    Friend Sub SelectShapes(ByRef ShapeHandles As Hashtable)
        Dim i As Integer
        Dim curItem As Integer
        Dim SelectedFirstAlready As Boolean = False
        If ShapeHandles.Count = 0 Then
            Static preventRecurse As Boolean = False
            If Not preventRecurse Then
                preventRecurse = True
                InitAll()
                preventRecurse = False
            End If
            Exit Sub
        End If

        If ReferenceEquals(TableEditorDataGrid.DataSource, m_table) Then

            For i = 0 To m_table.Rows.Count - 1
                curItem = TableEditorDataGrid.Item(i, 0)
                If ShapeHandles.ContainsKey(curItem) Then
                    TableEditorDataGrid.Select(i)

                    'BugZilla 312 - scroll to first selected shape
                    If Not SelectedFirstAlready Then
                        TableEditorDataGrid.CurrentRowIndex = i
                        SelectedFirstAlready = True
                    End If

                    ShapeHandles.Remove(curItem)
                Else
                    TableEditorDataGrid.UnSelect(i)
                End If
            Next

        Else
            m_selected.BeginLoadData()
            m_selected.Clear()
            For i = 0 To m_table.Rows.Count - 1
                If ShapeHandles.ContainsKey(m_table.Rows(i).Item(0)) Then
                    m_selected.ImportRow(m_table.Rows(i))
                End If
            Next
            m_selected.EndLoadData()
            TableEditorDataGrid.DataSource = m_selected
        End If

        '***Added by Nathan Eaton, CALM 02/05***
        'update the selected records label
        Dim querytable As DataTable = Me.TableEditorDataGrid.DataSource
        If Not g_MW Is Nothing Then Me.Selected_Label.Text = g_MW.View.SelectedShapes.NumSelected & " of " & querytable.Rows.Count & " Selected"
    End Sub

    Friend Sub ClearSelectedShapes()
        Dim i As Integer
        If ReferenceEquals(TableEditorDataGrid.DataSource, m_table) Then
            For i = 0 To m_table.Rows.Count - 1
                TableEditorDataGrid.UnSelect(i)
            Next
        Else
            For i = 0 To m_selected.Rows.Count - 1
                TableEditorDataGrid.UnSelect(i)
            Next
        End If
    End Sub

    Friend Sub SynchSelected()
        If g_MW Is Nothing Then Return 'Called directly, not as a plug-in

        Dim i As Integer
        Dim ht As New Hashtable
        Dim totalselected As Integer = g_MW.View.SelectedShapes.NumSelected

        If g_MW.View.SelectedShapes Is Nothing Then Exit Sub

        With g_MW.View.SelectedShapes
            For i = 0 To .NumSelected - 1
                If Not ht.Contains(.Item(i).ShapeIndex) Then
                    ht.Add(.Item(i).ShapeIndex, i)
                Else
                    totalselected -= 1 'Duplicate
                End If
            Next
            ClearSelectedShapes()
            mnuZoomToSelected.Enabled = (ht.Count > 0)
            mnuShowSelected.Enabled = (ht.Count > 0)
            SelectShapes(ht)
        End With

        '***Added by Nathan Eaton, CALM 02/05***
        'Update the Selected Records Label
        Dim querytable As DataTable = Me.TableEditorDataGrid.DataSource
        Me.Selected_Label.Text = totalselected & " of " & querytable.Rows.Count & " Selected"

    End Sub

    Private Sub UpdateDBF()
        Dim i, j As Integer

        If m_sf.StartEditingTable Then
            lblUpdating.Visible = True
            lblUpdating.Refresh()
            UpdateProgress.Visible = True
            Try
                UpdateProgress.Minimum = 0
                UpdateProgress.Maximum = Math.Max(m_sf.NumShapes - 1, 1)
            Catch
            End Try

            'Chris M 7/10/2006 -- If they're only viewing the selected shapes
            'this loop would be damaging. Instead, loop through all available
            'datagrid items.
            'For i = 0 To m_sf.NumShapes - 1
            Dim upperCount As Integer = 0
            Try
                Dim TableGrid As DataTable = Nothing
                If (TableEditorDataGrid.DataSource.GetType() Is GetType(DataView)) Then
                    Dim ViewGrid As DataView = CType(TableEditorDataGrid.DataSource, DataView)
                    TableGrid = ViewGrid.Table
                Else
                    TableGrid = CType(TableEditorDataGrid.DataSource, DataTable)
                End If

                upperCount = TableGrid.Rows.Count - 1
            Catch ex As Exception
                upperCount = m_sf.NumShapes - 1
            End Try

            For i = 0 To upperCount
                Try
                    UpdateProgress.Value = i
                Catch
                End Try

                For j = 0 To m_sf.NumFields - 1
                    Select Case m_sf.Field(j).Type
                        Case MapWinGIS.FieldType.DOUBLE_FIELD
                            m_sf.EditCellValue(j, TableEditorDataGrid.Item(i, 0), TableEditorDataGrid.Item(i, j + 1))
                        Case MapWinGIS.FieldType.INTEGER_FIELD
                            m_sf.EditCellValue(j, TableEditorDataGrid.Item(i, 0), TableEditorDataGrid.Item(i, j + 1))
                        Case MapWinGIS.FieldType.STRING_FIELD
                            m_sf.EditCellValue(j, TableEditorDataGrid.Item(i, 0), TableEditorDataGrid.Item(i, j + 1))
                    End Select
                Next
            Next
            lblUpdating.Visible = False
            UpdateProgress.Visible = False
        Else
            MapWinUtility.Logger.Msg("Failed to update the table", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            Exit Sub
        End If
        If m_sf.StopEditingTable() = False Then
            MapWinUtility.Logger.Msg("Failed to update the table", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End If
    End Sub

    Private Sub frmTableEditor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitAll()

        'Remember the last size and position -- bugzilla 117
        Try
            Dim rk As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\MapWindow", False)
            If Not rk.GetValue(Me.Name + "_x").ToString() = "" And Not rk.GetValue(Me.Name + "_y").ToString() = "" And Not rk.GetValue(Me.Name + "_w").ToString() = "" And Not rk.GetValue(Me.Name + "_h").ToString() = "" Then
                Me.Location = New System.Drawing.Point(Double.Parse(rk.GetValue(Me.Name + "_x").ToString()), Double.Parse(rk.GetValue(Me.Name + "_y").ToString()))
                Me.Size = New System.Drawing.Size(Double.Parse(rk.GetValue(Me.Name + "_w").ToString()), Double.Parse(rk.GetValue(Me.Name + "_h").ToString()))
            End If
        Catch
            'Use defaults:
            Me.Size = New System.Drawing.Size(608, 469)
            Me.Location = New System.Drawing.Point(10, 10)
        End Try
        Loaded = True

        If g_MW Is Nothing Then
            'Disable menu items that are unavailable
            MenuItem15.Enabled = False
            mnuZoomToSelected.Enabled = False
            mnuShowSelected.Enabled = False
            mnuExport.Enabled = False

            btnZoomToSelected.Enabled = False
            Me.btnShowSelected.Enabled = False
            Me.btnZoomToSelected.Enabled = False
        End If
    End Sub

    Private Sub InitAll()
        If Not Initialize(m_sf, m_owner) Then Me.Close()

        '***Added by Nathan Eaton, CALM 02/05***
        'disable any edit functionality if the dbf is readonly
        If (File.GetAttributes(Replace(m_sf.Filename, ".shp", ".dbf")) And FileAttributes.ReadOnly) = FileAttributes.ReadOnly Then
            mnuAddField.Enabled = False
            mnuRemoveField.Enabled = False
            mnuRenameField.Enabled = False
            mnuReplace.Enabled = False
        End If
    End Sub

    Private Sub DataGrid1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TableEditorDataGrid.CurrentCellChanged
        TestForChanges()
    End Sub

    Private Sub TestForChanges()
        Dim oldVal As Object = Nothing

        Debug.WriteLine(m_oldRow & ", " & m_oldCol)
        Debug.WriteLine(TableEditorDataGrid.CurrentCell.RowNumber & ", " & TableEditorDataGrid.CurrentCell.ColumnNumber)
        Debug.WriteLine("")

        If m_TrulyChanged = True Then Exit Sub ' something has already changed, don't bother checking anymore

        With TableEditorDataGrid.CurrentCell
            If m_oldRow = -1 OrElse m_oldCol = -1 Then
                m_oldRow = .RowNumber
                m_oldCol = .ColumnNumber
            End If
            If .ColumnNumber < 1 OrElse _
               .RowNumber < 0 OrElse _
               .ColumnNumber > m_sf.NumFields OrElse _
               .RowNumber >= m_sf.NumShapes Then Exit Sub

            Try
                Select Case m_sf.Field(m_oldCol - 1).Type
                    Case MapWinGIS.FieldType.DOUBLE_FIELD
                        oldVal = m_sf.CellValue(m_oldCol - 1, m_oldRow)
                    Case MapWinGIS.FieldType.INTEGER_FIELD
                        oldVal = m_sf.CellValue(m_oldCol - 1, m_oldRow)
                    Case MapWinGIS.FieldType.STRING_FIELD
                        oldVal = m_sf.CellValue(m_oldCol - 1, m_oldRow)
                End Select

                ' Is the old value null?
                If IsDBNull(oldVal) And Not IsDBNull(TableEditorDataGrid.Item(m_oldRow, m_oldCol)) Then
                    m_TrulyChanged = True
                ElseIf oldVal <> TableEditorDataGrid.Item(m_oldRow, m_oldCol) Then
                    m_TrulyChanged = True
                End If

            Catch
                Debug.WriteLine("Cast exception occured!")
                Debug.WriteLine(oldVal)
            End Try

            m_oldRow = .RowNumber
            m_oldCol = .ColumnNumber
        End With
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'Checking for, and prompting to save, changes is done on the Closing event.
        Me.Close()
    End Sub

    Public Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        TestForChanges()
        If m_TrulyChanged = False Then Exit Sub 'Don't allow saving changes if no changes have been made.

        If SFIsRO Then
            MapWinUtility.Logger.Msg("Shapefile is Read-Only!" + vbCrLf + vbCrLf + "This shapefile is read-only, and cannot be changed.", MsgBoxStyle.Information, "Read-Only Shapefile")
            Exit Sub
        End If

        'Don't ask if the sender is the button itself - if you pushed the button,
        'you want it. Bugzilla 64
        If sender Is btnApply OrElse MapWinUtility.Logger.Msg("Do you want to save the changes that have been made?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Save the changes?") = MsgBoxResult.Yes Then
            Dim oldCursor As System.Windows.Forms.Cursor = Cursor
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            Me.Enabled = False
            UpdateDBF()
            Cursor = oldCursor
            Me.Enabled = True
            btnClose.Focus()
            btnApply.Enabled = False 'will be enabled when close loses focus
            m_TrulyChanged = False

            'Trigger a coloring scheme update -- BugZilla 313
            If Not g_MW Is Nothing Then
                If Not g_MW.Layers.CurrentLayer = -1 Then
                    If Not g_MW.Layers(g_MW.Layers.CurrentLayer).ColoringScheme Is Nothing Then
                        Dim reselect(g_MW.View.SelectedShapes.NumSelected - 1) As Long
                        For i As Integer = 0 To g_MW.View.SelectedShapes.NumSelected - 1
                            reselect(i) = g_MW.View.SelectedShapes(i).ShapeIndex
                        Next
                        g_MW.View.SelectedShapes.ClearSelectedShapes()
                        g_MW.Layers(g_MW.Layers.CurrentLayer).ColoringScheme = g_MW.Layers(g_MW.Layers.CurrentLayer).ColoringScheme
                        For Each i As Integer In reselect
                            g_MW.View.SelectedShapes.AddByIndex(i, g_MW.View.SelectColor)
                        Next
                    End If
                End If
            End If
        Else
            'this line added by Nathan Eaton, Calm 03/05 to enable an undo function for field operations
            m_sf.StopEditingTable(False)
            m_TrulyChanged = False 'Discarded by user option
        End If
    End Sub

    Private Sub RenameField()

        '***Added by Nathan Eaton, CALM 02/05***
        'Double Check for Read only attributes
        If (File.GetAttributes(Replace(m_sf.Filename, ".shp", ".dbf")) And FileAttributes.ReadOnly) = FileAttributes.ReadOnly Then
            MapWinUtility.Logger.Msg("The shapefile table is read only, so cannot be edited", MsgBoxStyle.Exclamation, "Read Only")
            Exit Sub
        End If

        Dim dlg As New frmRenameField(m_sf, IIf(TableEditorDataGrid.CurrentCell.ColumnNumber > 0, TableEditorDataGrid.CurrentCell.ColumnNumber - 1, 0))

        If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            'Check for existing name - CDM for bugzilla 136
            For i As Integer = 0 To m_sf.NumFields - 1
                If m_sf.Field(i).Name.ToLower() = dlg.txtNewName.Text.ToLower() Then
                    MapWinUtility.Logger.Msg("The field '" + dlg.txtNewName.Text + "' already exists. Please choose a different name to rename this field to. (Rename aborted)", MsgBoxStyle.Exclamation, "Field Already Exists")
                    Exit Sub
                End If
            Next

            m_sf.StartEditingTable()
            m_sf.Field(dlg.retval).Name = dlg.txtNewName.Text

            'added by Nathan Eaton CALM 03/50
            'This enables edits to not be applied to the DBF until the apply button is pressed
            Dim oldCursor, ownerCursor As Windows.Forms.Cursor
            oldCursor = Cursor
            ownerCursor = m_owner.Cursor
            Cursor = Cursors.WaitCursor
            m_owner.Cursor = Cursors.WaitCursor
            m_owner.Refresh()
            m_table.Columns(dlg.retval + 1).ColumnName = dlg.txtNewName.Text
            If LoadTable_Columns(m_sf, m_table, 2, 0) = False Then Exit Sub
            TableEditorDataGrid.DataSource = m_table
            TableEditorDataGrid.CaptionText = m_sf.Filename
            SynchSelected()

            Me.Owner = m_owner
            Cursor = oldCursor
            m_owner.Cursor = ownerCursor

            btnApply.Enabled = True
            m_TrulyChanged = True
        End If
    End Sub

    Private Sub DataGridCell_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Debug.WriteLine("KeyDown")
        If e.KeyCode = Keys.Delete Then
            With TableEditorDataGrid.CurrentCell
                If .ColumnNumber < 1 OrElse _
                    .RowNumber < 0 OrElse _
                    .ColumnNumber > m_sf.NumFields OrElse _
                    .RowNumber >= m_sf.NumShapes Then Exit Sub

                TableEditorDataGrid.Item(.RowNumber, .ColumnNumber) = DBNull.Value
                btnApply.Enabled = True
                m_TrulyChanged = True
            End With
        End If
    End Sub

    Private Sub frmTableEditor_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        'Since the sender (the first param) is not the apply button itself,
        'the apply button will ask if changes should be saved. for Bugzilla 64
        btnApply_Click(Nothing, Nothing)

        'Close query window if open (bug 651)
        If Not QueryDlg Is Nothing OrElse Not QueryDlg.IsDisposed Then QueryDlg.Close()

        'Bring MapWindow back forward
        If Not Me.Owner Is Nothing Then Me.Owner.Activate()
    End Sub

    Private Sub Context_Calculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Column_Expression_popup.Click
        FieldCalculator()
    End Sub

    Private Sub sort_asc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sort_asc.Click
        Sort_Ascending(gb_selected_column)
    End Sub

    Private Sub Sort_desc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Sort_desc.Click
        Sort_Descending(gb_selected_column)
    End Sub

    Private Sub Column_context_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Column_context.Popup
        '***Added by Nathan Eaton, CALM 02/05***

        Dim dt As DataTable
        dt = TableEditorDataGrid.DataSource

        If gb_selected_column = 0 Then
            Me.Column_Expression_popup.Enabled = False
            Me.Selected_Input_popup.Enabled = False
        Else
            Me.Column_Expression_popup.Enabled = True
            Me.Selected_Input_popup.Enabled = True
        End If

        If mnuShowSelected.Text = ShowAllShapesText Then
            Me.Column_Expression_popup.Enabled = False
            Me.Selected_Input_popup.Enabled = False
        End If

        If (File.GetAttributes(Replace(m_sf.Filename, ".shp", ".dbf")) And FileAttributes.ReadOnly) = FileAttributes.ReadOnly Then
            Me.Column_Expression_popup.Enabled = False
            Me.Selected_Input_popup.Enabled = False
        End If

        If dt.Columns(gb_selected_column).DataType.ToString <> "System.String" Then
            Me.Statistics_popup.Enabled = True
        Else
            Me.Statistics_popup.Enabled = False
        End If
    End Sub

    Private Sub Statistics_popup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Statistics_popup.Click
        Statistics_sub()
    End Sub

    Private Sub Selected_Input_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Selected_Input_popup.Click
        Selected_Input_Sub(gb_selected_column)
    End Sub

    Private Sub frmTableEditor_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Move
        Dim rk As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\MapWindow")
        If (Me.Visible And Loaded And Not Me.WindowState = FormWindowState.Minimized) Then
            rk.SetValue(Me.Name + "_x", Me.Location.X)
            rk.SetValue(Me.Name + "_y", Me.Location.Y)
            rk.SetValue(Me.Name + "_w", Me.Size.Width)
            rk.SetValue(Me.Name + "_h", Me.Size.Height)
        End If
    End Sub

    Private Sub frmTableEditor_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Dim rk As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\MapWindow")
        If (Me.Visible And Loaded And Not Me.WindowState = FormWindowState.Minimized) Then
            rk.SetValue(Me.Name + "_x", Me.Location.X)
            rk.SetValue(Me.Name + "_y", Me.Location.Y)
            rk.SetValue(Me.Name + "_w", Me.Size.Width)
            rk.SetValue(Me.Name + "_h", Me.Size.Height)
        End If
    End Sub

    'Import Fields from DBF -- Chris M - April 20 2006
    Private Sub MenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem7.Click
        ImportFieldsFromDBF()
    End Sub

    'Field Calculator tool. Brought in from the USU code base
    'during merger by Chris M on April 21 2006. Thanks to USU
    'for this!
    Private Sub FieldCalculator()
        calculator = New frmFieldCalculator(m_sf, TableEditorDataGrid)
        calculator.Owner = Me
        calculator.Show()
    End Sub

    Private Sub MenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem8.Click
        FieldCalculator()
    End Sub

    Private Sub mnuShapeID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShapeID.Click
        GenerateShapeIDField("MWShapeID")
    End Sub

    Private Sub btnZoomToSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomToSelected.Click
        ZoomToSelected()
    End Sub

    Private Sub btnShowSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowSelected.Click
        ShowSelected()
    End Sub

    Private Sub btnImportFieldsFromDBF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportFieldsFromDBF.Click
        ImportFieldsFromDBF()
    End Sub

    Private Sub btnFieldCalculator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFieldCalculator.Click
        FieldCalculator()
    End Sub

    Private Sub MenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem10.Click
        Dim s As String = InputBox("Please enter the name of the field to place ID values in." + vbCrLf + vbCrLf + "If the field exists it will be overwritten.", "Enter Field Name", "MWShapeID")
        If Not s = "" And s.Length < 11 Then
            GenerateShapeIDField(s)
        ElseIf s.Length > 10 Then
            MapWinUtility.Logger.Msg("The field name can only be 10 characters long. Aborting.", MsgBoxStyle.Exclamation, "Field Name Too Long")
        Else
            MapWinUtility.Logger.Msg("No field name was specified. Aborting.", MsgBoxStyle.Exclamation, "No Field Specified")
        End If
    End Sub

    Private Sub GenerateShapeIDField(ByVal DestField As String)
        Dim createdNew As Boolean = False
        Dim sid As Integer = -1
        For i As Integer = 0 To m_sf.NumFields - 1
            If m_sf.Field(i).Name.ToLower() = DestField.ToLower() Then
                sid = i
                Exit For
            End If
        Next

        If m_sf.StartEditingTable() = False Then
            ' False was retuned!  Something is preventing me from editing the shapefile
            MapWinUtility.Logger.Msg("The shapefile could not be edited", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Error")
            Exit Sub
        End If

        If sid = -1 Then
            createdNew = True
            Dim newfld As New MapWinGIS.Field
            newfld.Name = DestField
            newfld.Type = MapWinGIS.FieldType.INTEGER_FIELD
            newfld.Width = 10
            newfld.Precision = 10
            sid = m_sf.NumFields
            m_sf.EditInsertField(newfld, sid)
        End If

        'Nathan Eaton CALM 03/50:  This enables edits to not be applied to the DBF until the apply button is pressed
        TableEditorDataGrid.Refresh()
        Dim oldCursor, ownerCursor As Windows.Forms.Cursor
        oldCursor = Cursor
        ownerCursor = m_owner.Cursor
        Cursor = Cursors.WaitCursor
        m_owner.Cursor = Cursors.WaitCursor
        m_owner.Refresh()

        If LoadTable_Columns(m_sf, m_table, 2, 0) = False Then Exit Sub
        TableEditorDataGrid.DataSource = m_table
        TableEditorDataGrid.CaptionText = m_sf.Filename
        SynchSelected()

        Dim dt As DataTable = TableEditorDataGrid.DataSource
        Dim tc As Integer = -1
        For j As Integer = 0 To dt.Columns.Count - 1
            If dt.Columns(j).ColumnName.ToLower() = DestField.ToLower() Then
                tc = j
                Exit For
            End If
        Next

        For j As Integer = 0 To dt.Rows.Count - 1
            TableEditorDataGrid.Item(j, tc) = j
        Next j

        Me.Owner = m_owner
        Cursor = oldCursor
        m_owner.Cursor = ownerCursor
        btnApply.Enabled = True
        m_TrulyChanged = True

        MapWinUtility.Logger.Msg("The " + DestField + " field has been " + IIf(createdNew, "created", "updated") + ". Click Apply to make the changes permanent.", MsgBoxStyle.Information, "Done!")
    End Sub

    Public Sub TextCalculator()
        '***Added by Nathan Eaton, CALM 02/05***'
        'Bring up the Column Expression form to create the expression with

        Dim dlg As New frmTextCalculator
        dlg.TopMost = True

        dlg.Fields_lb.Items.Clear()
        For i As Integer = 0 To m_sf.NumFields - 1
            dlg.Fields_lb.Items.Insert(i, m_sf.Field(i).Name)
            dlg.DestFieldComboBox.Items.Insert(i, m_sf.Field(i).Name)
        Next

        If Not dlg.DestFieldComboBox.Items.Count = 0 Then dlg.DestFieldComboBox.SelectedIndex = 0

        If Not g_MW Is Nothing Then
            dlg.Owner = mPublics.g_MW
        Else
            dlg.Owner = Me
        End If

        dlg.Show()
    End Sub

    Private Sub btnApplyOrClose_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Leave, btnClose.Leave
        btnApply.Enabled = True
    End Sub

    Private Sub MenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem11.Click
        Dim dt As DataTable
        Dim new_item_collection As New Collection
        Dim i As Integer

        Try
            dt = TableEditorDataGrid.DataSource

            For i = 0 To dt.Rows.Count - 1
                TableEditorDataGrid(i, gb_selected_column) = Trim(TableEditorDataGrid(i, gb_selected_column))
            Next
        Catch ex As System.ArgumentException
            MapWinUtility.Logger.Msg("Syntax Error", MsgBoxStyle.Exclamation, "Syntax Error")
            Exit Sub
        Catch ex As System.FormatException
            MapWinUtility.Logger.Msg("Syntax Error", MsgBoxStyle.Exclamation, "Syntax Error")
            Exit Sub
        End Try

        btnApply.Enabled = True
        m_TrulyChanged = True
    End Sub

    Private Sub MenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem12.Click
        Dim dt As DataTable
        Dim new_item_collection As New Collection
        Dim i As Integer

        Try
            dt = TableEditorDataGrid.DataSource

            For i = 0 To dt.Rows.Count - 1
                If TableEditorDataGrid.IsSelected(i) = True Then
                    TableEditorDataGrid(i, gb_selected_column) = Trim(TableEditorDataGrid(i, gb_selected_column))
                End If
            Next
        Catch ex As System.ArgumentException
            MapWinUtility.Logger.Msg("Syntax Error", MsgBoxStyle.Exclamation, "Syntax Error")
            Exit Sub
        Catch ex As System.FormatException
            MapWinUtility.Logger.Msg("Syntax Error", MsgBoxStyle.Exclamation, "Syntax Error")
            Exit Sub
        End Try

        btnApply.Enabled = True
        m_TrulyChanged = True
    End Sub

    Public Sub RefreshWithSavePrompt()
        btnApply_Click(tbbRefresh, Nothing) 'Will ask before outright saving
        InitAll()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If g_MW Is Nothing Then Return

        If Not m_sf Is Nothing Then
            If Not g_MW.Layers(g_MW.Layers.CurrentLayer).ColoringScheme Is Nothing Then
                'Just resetting the coloring scheme to itself causes a refresh of coloring.
                g_MW.Layers(g_MW.Layers.CurrentLayer).ColoringScheme = g_MW.Layers(g_MW.Layers.CurrentLayer).ColoringScheme
                g_MW.View.Redraw()
            End If
        End If
    End Sub

    Private Sub MenuItem15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem15.Click
        If g_MW Is Nothing Then Return 'No map to work with...

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim maxX, maxY, minX, minY As Double
            Dim dx, dy As Double
            Dim tExts As MapWinGIS.Extents

            'CDM fix to zoom to actual selected shape, in the case that
            'only a subset is currently shown (bug 483) - (index 0 is shape ID)
            'With m_sf.Shape(DataGrid1.CurrentCell.RowNumber)
            With m_sf.Shape(TableEditorDataGrid.Item(TableEditorDataGrid.CurrentCell.RowNumber, 0))
                maxX = .Extents.xMax
                minX = .Extents.xMin
                maxY = .Extents.yMax
                minY = .Extents.yMin
            End With
            If g_MW.Layers(g_MW.Layers.CurrentLayer).Visible = False Then
                g_MW.Layers(g_MW.Layers.CurrentLayer).Visible = True
            End If

            ' Pad extents now
            dx = maxX - minX
            dx = dx * g_MW.View.ExtentPad
            If dx = 0 Then
                dx = 1
            End If
            maxX = maxX + dx
            minX = minX - dx

            dy = maxY - minY
            dy = dy * g_MW.View.ExtentPad
            If dy = 0 Then
                dy = 1
            End If
            maxY = maxY + dy
            minY = minY - dy

            tExts = New MapWinGIS.Extents
            tExts.SetBounds(minX, minY, 0, maxX, maxY, 0)
            g_MW.View.Extents = tExts
            tExts = Nothing
        Catch ex As Exception
            MapWinUtility.Logger.Dbg("Error: " + ex.ToString())
            Exit Sub
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    <CLSCompliant(False)> _
    Public Property MapWindowInterface() As MapWindow.Interfaces.IMapWin
        Get
            Return g_MW
        End Get
        Set(ByVal value As MapWindow.Interfaces.IMapWin)
            g_MW = value
        End Set
    End Property

    Private Sub tbbRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbbRefresh.Click
        RefreshWithSavePrompt()
    End Sub

    Private Sub MenuItem16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem16.Click
        FlashSelected()
    End Sub

    ' Added on 10/03/2008 Earljon Hidalgo
    Private Sub tbbQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbbQuery.Click
        Queryform()
    End Sub
End Class
