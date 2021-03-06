'Field Calculator tool. Brought in from the USU code base
'during merger by Chris M on April 21 2006.
'
'Extended 11/4/2006 by Chris M to use clsMathParser.vb, see the top of that
'file for sources and more info. This provides dozens more functions and
'logical operators.

Imports System.Windows.Forms
Public Class frmFieldCalculator
    Inherits System.Windows.Forms.Form

#Region "Member Variables"
    Private m_shapefile As MapWinGIS.Shapefile
    Private m_Grid As DataGrid
    Private m_DestFieldName As String = ""
    Private m_DestFieldColumn As Integer
    Friend WithEvents lstFunctions As System.Windows.Forms.ListBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Private m_parser As New clsMathParser
#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
    End Sub

    <CLSCompliant(False)> _
    Public Sub New(ByVal shapefile As MapWinGIS.Shapefile, ByVal grid As DataGrid)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        m_shapefile = shapefile
        m_Grid = grid

        InitializeFieldValues()
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
    Friend WithEvents DestFieldComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents FieldsListView As System.Windows.Forms.ListView
    Friend WithEvents FieldsTitleLabel As System.Windows.Forms.Label
    Friend WithEvents DestFieldTitleLabel As System.Windows.Forms.Label
    Friend WithEvents ComputationTextBox As System.Windows.Forms.TextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnSubtract As System.Windows.Forms.Button
    Friend WithEvents btnMultiply As System.Windows.Forms.Button
    Friend WithEvents btnDivide As System.Windows.Forms.Button
    Friend WithEvents btnConcat As System.Windows.Forms.Button
    Friend WithEvents FunctionTitleLabel As System.Windows.Forms.Label
    Friend WithEvents AssignmentLabel As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFieldCalculator))
        Me.DestFieldComboBox = New System.Windows.Forms.ComboBox
        Me.FieldsListView = New System.Windows.Forms.ListView
        Me.FieldsTitleLabel = New System.Windows.Forms.Label
        Me.DestFieldTitleLabel = New System.Windows.Forms.Label
        Me.ComputationTextBox = New System.Windows.Forms.TextBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnSubtract = New System.Windows.Forms.Button
        Me.btnMultiply = New System.Windows.Forms.Button
        Me.btnDivide = New System.Windows.Forms.Button
        Me.btnConcat = New System.Windows.Forms.Button
        Me.FunctionTitleLabel = New System.Windows.Forms.Label
        Me.AssignmentLabel = New System.Windows.Forms.Label
        Me.lstFunctions = New System.Windows.Forms.ListBox
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.SuspendLayout()
        '
        'DestFieldComboBox
        '
        resources.ApplyResources(Me.DestFieldComboBox, "DestFieldComboBox")
        Me.DestFieldComboBox.Name = "DestFieldComboBox"
        '
        'FieldsListView
        '
        resources.ApplyResources(Me.FieldsListView, "FieldsListView")
        Me.FieldsListView.Name = "FieldsListView"
        Me.FieldsListView.UseCompatibleStateImageBehavior = False
        Me.FieldsListView.View = System.Windows.Forms.View.List
        '
        'FieldsTitleLabel
        '
        resources.ApplyResources(Me.FieldsTitleLabel, "FieldsTitleLabel")
        Me.FieldsTitleLabel.Name = "FieldsTitleLabel"
        '
        'DestFieldTitleLabel
        '
        resources.ApplyResources(Me.DestFieldTitleLabel, "DestFieldTitleLabel")
        Me.DestFieldTitleLabel.Name = "DestFieldTitleLabel"
        '
        'ComputationTextBox
        '
        resources.ApplyResources(Me.ComputationTextBox, "ComputationTextBox")
        Me.ComputationTextBox.Name = "ComputationTextBox"
        '
        'btnOK
        '
        resources.ApplyResources(Me.btnOK, "btnOK")
        Me.btnOK.Name = "btnOK"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.Name = "btnCancel"
        '
        'btnAdd
        '
        resources.ApplyResources(Me.btnAdd, "btnAdd")
        Me.btnAdd.Name = "btnAdd"
        '
        'btnSubtract
        '
        resources.ApplyResources(Me.btnSubtract, "btnSubtract")
        Me.btnSubtract.Name = "btnSubtract"
        '
        'btnMultiply
        '
        resources.ApplyResources(Me.btnMultiply, "btnMultiply")
        Me.btnMultiply.Name = "btnMultiply"
        '
        'btnDivide
        '
        resources.ApplyResources(Me.btnDivide, "btnDivide")
        Me.btnDivide.Name = "btnDivide"
        '
        'btnConcat
        '
        resources.ApplyResources(Me.btnConcat, "btnConcat")
        Me.btnConcat.Name = "btnConcat"
        '
        'FunctionTitleLabel
        '
        resources.ApplyResources(Me.FunctionTitleLabel, "FunctionTitleLabel")
        Me.FunctionTitleLabel.Name = "FunctionTitleLabel"
        '
        'AssignmentLabel
        '
        resources.ApplyResources(Me.AssignmentLabel, "AssignmentLabel")
        Me.AssignmentLabel.Name = "AssignmentLabel"
        '
        'lstFunctions
        '
        Me.lstFunctions.FormattingEnabled = True
        Me.lstFunctions.Items.AddRange(New Object() {resources.GetString("lstFunctions.Items"), resources.GetString("lstFunctions.Items1"), resources.GetString("lstFunctions.Items2"), resources.GetString("lstFunctions.Items3"), resources.GetString("lstFunctions.Items4"), resources.GetString("lstFunctions.Items5"), resources.GetString("lstFunctions.Items6"), resources.GetString("lstFunctions.Items7"), resources.GetString("lstFunctions.Items8"), resources.GetString("lstFunctions.Items9"), resources.GetString("lstFunctions.Items10"), resources.GetString("lstFunctions.Items11"), resources.GetString("lstFunctions.Items12"), resources.GetString("lstFunctions.Items13"), resources.GetString("lstFunctions.Items14"), resources.GetString("lstFunctions.Items15"), resources.GetString("lstFunctions.Items16"), resources.GetString("lstFunctions.Items17"), resources.GetString("lstFunctions.Items18"), resources.GetString("lstFunctions.Items19"), resources.GetString("lstFunctions.Items20"), resources.GetString("lstFunctions.Items21"), resources.GetString("lstFunctions.Items22"), resources.GetString("lstFunctions.Items23"), resources.GetString("lstFunctions.Items24"), resources.GetString("lstFunctions.Items25"), resources.GetString("lstFunctions.Items26"), resources.GetString("lstFunctions.Items27"), resources.GetString("lstFunctions.Items28"), resources.GetString("lstFunctions.Items29"), resources.GetString("lstFunctions.Items30"), resources.GetString("lstFunctions.Items31"), resources.GetString("lstFunctions.Items32"), resources.GetString("lstFunctions.Items33"), resources.GetString("lstFunctions.Items34"), resources.GetString("lstFunctions.Items35"), resources.GetString("lstFunctions.Items36"), resources.GetString("lstFunctions.Items37"), resources.GetString("lstFunctions.Items38"), resources.GetString("lstFunctions.Items39"), resources.GetString("lstFunctions.Items40"), resources.GetString("lstFunctions.Items41"), resources.GetString("lstFunctions.Items42"), resources.GetString("lstFunctions.Items43"), resources.GetString("lstFunctions.Items44"), resources.GetString("lstFunctions.Items45"), resources.GetString("lstFunctions.Items46"), resources.GetString("lstFunctions.Items47"), resources.GetString("lstFunctions.Items48"), resources.GetString("lstFunctions.Items49"), resources.GetString("lstFunctions.Items50"), resources.GetString("lstFunctions.Items51"), resources.GetString("lstFunctions.Items52"), resources.GetString("lstFunctions.Items53"), resources.GetString("lstFunctions.Items54"), resources.GetString("lstFunctions.Items55"), resources.GetString("lstFunctions.Items56"), resources.GetString("lstFunctions.Items57"), resources.GetString("lstFunctions.Items58"), resources.GetString("lstFunctions.Items59"), resources.GetString("lstFunctions.Items60"), resources.GetString("lstFunctions.Items61"), resources.GetString("lstFunctions.Items62"), resources.GetString("lstFunctions.Items63"), resources.GetString("lstFunctions.Items64"), resources.GetString("lstFunctions.Items65"), resources.GetString("lstFunctions.Items66"), resources.GetString("lstFunctions.Items67"), resources.GetString("lstFunctions.Items68"), resources.GetString("lstFunctions.Items69"), resources.GetString("lstFunctions.Items70"), resources.GetString("lstFunctions.Items71"), resources.GetString("lstFunctions.Items72"), resources.GetString("lstFunctions.Items73"), resources.GetString("lstFunctions.Items74"), resources.GetString("lstFunctions.Items75"), resources.GetString("lstFunctions.Items76"), resources.GetString("lstFunctions.Items77"), resources.GetString("lstFunctions.Items78"), resources.GetString("lstFunctions.Items79"), resources.GetString("lstFunctions.Items80"), resources.GetString("lstFunctions.Items81"), resources.GetString("lstFunctions.Items82"), resources.GetString("lstFunctions.Items83"), resources.GetString("lstFunctions.Items84"), resources.GetString("lstFunctions.Items85"), resources.GetString("lstFunctions.Items86"), resources.GetString("lstFunctions.Items87"), resources.GetString("lstFunctions.Items88"), resources.GetString("lstFunctions.Items89"), resources.GetString("lstFunctions.Items90"), resources.GetString("lstFunctions.Items91"), resources.GetString("lstFunctions.Items92"), resources.GetString("lstFunctions.Items93"), resources.GetString("lstFunctions.Items94"), resources.GetString("lstFunctions.Items95"), resources.GetString("lstFunctions.Items96"), resources.GetString("lstFunctions.Items97"), resources.GetString("lstFunctions.Items98"), resources.GetString("lstFunctions.Items99"), resources.GetString("lstFunctions.Items100"), resources.GetString("lstFunctions.Items101"), resources.GetString("lstFunctions.Items102"), resources.GetString("lstFunctions.Items103"), resources.GetString("lstFunctions.Items104"), resources.GetString("lstFunctions.Items105"), resources.GetString("lstFunctions.Items106"), resources.GetString("lstFunctions.Items107"), resources.GetString("lstFunctions.Items108"), resources.GetString("lstFunctions.Items109"), resources.GetString("lstFunctions.Items110"), resources.GetString("lstFunctions.Items111"), resources.GetString("lstFunctions.Items112"), resources.GetString("lstFunctions.Items113"), resources.GetString("lstFunctions.Items114"), resources.GetString("lstFunctions.Items115"), resources.GetString("lstFunctions.Items116"), resources.GetString("lstFunctions.Items117"), resources.GetString("lstFunctions.Items118"), resources.GetString("lstFunctions.Items119"), resources.GetString("lstFunctions.Items120"), resources.GetString("lstFunctions.Items121"), resources.GetString("lstFunctions.Items122"), resources.GetString("lstFunctions.Items123"), resources.GetString("lstFunctions.Items124"), resources.GetString("lstFunctions.Items125"), resources.GetString("lstFunctions.Items126"), resources.GetString("lstFunctions.Items127"), resources.GetString("lstFunctions.Items128"), resources.GetString("lstFunctions.Items129"), resources.GetString("lstFunctions.Items130"), resources.GetString("lstFunctions.Items131"), resources.GetString("lstFunctions.Items132"), resources.GetString("lstFunctions.Items133"), resources.GetString("lstFunctions.Items134"), resources.GetString("lstFunctions.Items135"), resources.GetString("lstFunctions.Items136"), resources.GetString("lstFunctions.Items137"), resources.GetString("lstFunctions.Items138"), resources.GetString("lstFunctions.Items139"), resources.GetString("lstFunctions.Items140"), resources.GetString("lstFunctions.Items141"), resources.GetString("lstFunctions.Items142"), resources.GetString("lstFunctions.Items143"), resources.GetString("lstFunctions.Items144"), resources.GetString("lstFunctions.Items145"), resources.GetString("lstFunctions.Items146"), resources.GetString("lstFunctions.Items147")})
        resources.ApplyResources(Me.lstFunctions, "lstFunctions")
        Me.lstFunctions.Name = "lstFunctions"
        '
        'LinkLabel1
        '
        resources.ApplyResources(Me.LinkLabel1, "LinkLabel1")
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.TabStop = True
        '
        'LinkLabel2
        '
        resources.ApplyResources(Me.LinkLabel2, "LinkLabel2")
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.TabStop = True
        '
        'frmFieldCalculator
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.lstFunctions)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.AssignmentLabel)
        Me.Controls.Add(Me.FunctionTitleLabel)
        Me.Controls.Add(Me.btnConcat)
        Me.Controls.Add(Me.btnDivide)
        Me.Controls.Add(Me.btnMultiply)
        Me.Controls.Add(Me.btnSubtract)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.ComputationTextBox)
        Me.Controls.Add(Me.DestFieldComboBox)
        Me.Controls.Add(Me.DestFieldTitleLabel)
        Me.Controls.Add(Me.FieldsTitleLabel)
        Me.Controls.Add(Me.FieldsListView)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFieldCalculator"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    <CLSCompliant(False)> _
    Public Property shapefile() As MapWinGIS.Shapefile
        Get
            Return m_shapefile
        End Get
        Set(ByVal Value As MapWinGIS.Shapefile)
            m_shapefile = Value
            InitializeFieldValues()
        End Set
    End Property

    Public Property grid() As DataGrid
        Get
            Return m_Grid
        End Get
        Set(ByVal Value As DataGrid)
            m_Grid = Value
        End Set
    End Property

    Private Sub InitializeFieldValues()
        If m_shapefile Is Nothing Then
            Exit Sub
        End If

        Dim i As Integer
        For i = 0 To m_shapefile.NumFields - 1
            FieldsListView.Items.Add(m_shapefile.Field(i).Name)
            DestFieldComboBox.Items.Add(m_shapefile.Field(i).Name)
        Next i

        If DestFieldComboBox.Items.Count > 0 Then
            DestFieldComboBox.SelectedIndex = 0
        End If

        If m_shapefile.ShapefileType = MapWinGIS.ShpfileType.SHP_MULTIPOINT Or m_shapefile.ShapefileType = MapWinGIS.ShpfileType.SHP_MULTIPOINTM Or m_shapefile.ShapefileType = MapWinGIS.ShpfileType.SHP_MULTIPOINTZ Or m_shapefile.ShapefileType = MapWinGIS.ShpfileType.SHP_POINT Or m_shapefile.ShapefileType = MapWinGIS.ShpfileType.SHP_POINTZ Or m_shapefile.ShapefileType = MapWinGIS.ShpfileType.SHP_POINTM Then
            lstFunctions.Items.Add("ShapeX")
            lstFunctions.Items.Add("ShapeY")
            lstFunctions.Items.Add("ShapeZ")
        ElseIf m_shapefile.ShapefileType = MapWinGIS.ShpfileType.SHP_POLYLINE Or m_shapefile.ShapefileType = MapWinGIS.ShpfileType.SHP_POLYLINEZ Or m_shapefile.ShapefileType = MapWinGIS.ShpfileType.SHP_POLYLINEM Then
            lstFunctions.Items.Add("ShapeXFirst")
            lstFunctions.Items.Add("ShapeYFirst")
            lstFunctions.Items.Add("ShapeZFirst")
            lstFunctions.Items.Add("ShapeXLast")
            lstFunctions.Items.Add("ShapeYLast")
            lstFunctions.Items.Add("ShapeZLast")
        End If
        lstFunctions.Sorted = True
    End Sub

    Private Sub AddTextToComputation(ByVal value As String)
        If ComputationTextBox.Text <> "" Then
            value = " " & value
        End If
        Dim startLength As Integer = ComputationTextBox.Text.Length
        ComputationTextBox.Text = String.Concat(ComputationTextBox.Text, value)
        ComputationTextBox.Focus()

        'Highlight the (first?) variable in parens
        Try
            If ComputationTextBox.Text.IndexOf("(", startLength) > -1 Then
                ComputationTextBox.SelectionStart = ComputationTextBox.Text.IndexOf("(", startLength) + 1
                ComputationTextBox.SelectionLength = 1
            End If
        Catch
        End Try
    End Sub

    Private Sub FieldsListView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles FieldsListView.DoubleClick
        Dim value As String
        If FieldsListView.SelectedItems.Count > 0 Then
            value = "[" & FieldsListView.SelectedItems.Item(0).Text & "]"
            AddTextToComputation(value)
        End If
    End Sub

    Private Sub lstFunctions_dblclick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstFunctions.DoubleClick
        If lstFunctions.SelectedItems.Count > 0 Then
            AddTextToComputation(lstFunctions.SelectedItems.Item(0).ToString())
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        AddTextToComputation("+")
    End Sub

    Private Sub btnSubtract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubtract.Click
        AddTextToComputation("-")
    End Sub

    Private Sub btnMultiply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMultiply.Click
        AddTextToComputation("*")
    End Sub

    Private Sub btnDivide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDivide.Click
        AddTextToComputation("/")
    End Sub

    Private Sub btnConcat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConcat.Click
        AddTextToComputation("&")
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If ComputationTextBox.Text <> "" Then
            'Make sure all open parenthesis are closed to avoid stack overrun in parser
            CloseParens(ComputationTextBox.Text)
            Me.Refresh()
            Try
                Dim rt As Boolean = m_parser.StoreExpression(ComputationTextBox.Text)
                If Not rt Then
                    mapwinutility.logger.msg("Could not parse computation equation: Invalid Syntax", MsgBoxStyle.Critical, "Field Calculator: Syntax Error")
                    Exit Sub
                End If
            Catch ex As Exception
                mapwinutility.logger.msg("Could not parse computation equation: Invalid Syntax", MsgBoxStyle.Critical, "Field Calculator: Syntax Error")
                Exit Sub
            End Try
            If CalculateValues() Then
                If Not Me.Owner Is Nothing Then
                    CType(Me.Owner, frmTableEditor).TableEditorDataGrid.Refresh()
                    CType(Me.Owner, frmTableEditor).btnApply.Enabled = True
                    CType(Me.Owner, frmTableEditor).m_TrulyChanged = True
                End If

                If mapwinutility.logger.msg("The calculation has completed. Would you like to close the Field Calculator now?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Complete! Close window?") = MsgBoxResult.Yes Then Me.Close()
            End If
        End If
    End Sub

    Public Function CalculateValues() As Boolean
        m_DestFieldColumn = GetFieldColumn(DestFieldComboBox.SelectedItem, m_Grid)
        Dim SettingAll As Boolean = True
        Dim i As Integer

        For i = 0 To CType(m_Grid.DataSource, DataTable).Rows.Count - 1
            If m_Grid.IsSelected(i) Then
                SettingAll = False
                Exit For
            End If
        Next

        For i = 0 To CType(m_Grid.DataSource, DataTable).Rows.Count - 1
            If m_Grid.IsSelected(i) Or SettingAll Then
                Try
                    'Note index starts at 1, not zero
                    For j As Integer = 1 To m_parser.VarTop
                        For z As Integer = 0 To CType(m_Grid.DataSource, DataTable).Columns.Count - 1
                            Try
                                If CType(m_Grid.DataSource, DataTable).Columns(z).ColumnName.ToLower() = m_parser.VarName(j).ToLower() Then
                                    m_parser.VarValue(j) = Double.Parse(m_Grid.Item(i, z).ToString())
                                ElseIf m_parser.VarName(j).ToLower() = "shapex" Then
                                    m_parser.VarValue(j) = m_shapefile.Shape(Long.Parse(m_Grid.Item(i, 0).ToString())).Point(0).x
                                ElseIf m_parser.VarName(j).ToLower() = "shapey" Then
                                    m_parser.VarValue(j) = m_shapefile.Shape(Long.Parse(m_Grid.Item(i, 0).ToString())).Point(0).y
                                ElseIf m_parser.VarName(j).ToLower() = "shapez" Then
                                    m_parser.VarValue(j) = m_shapefile.Shape(Long.Parse(m_Grid.Item(i, 0).ToString())).Point(0).Z
                                ElseIf m_parser.VarName(j).ToLower() = "shapexfirst" Then
                                    m_parser.VarValue(j) = m_shapefile.Shape(Long.Parse(m_Grid.Item(i, 0).ToString())).Point(0).x
                                ElseIf m_parser.VarName(j).ToLower() = "shapeyfirst" Then
                                    m_parser.VarValue(j) = m_shapefile.Shape(Long.Parse(m_Grid.Item(i, 0).ToString())).Point(0).y
                                ElseIf m_parser.VarName(j).ToLower() = "shapezfirst" Then
                                    m_parser.VarValue(j) = m_shapefile.Shape(Long.Parse(m_Grid.Item(i, 0).ToString())).Point(0).Z
                                ElseIf m_parser.VarName(j).ToLower() = "shapexlast" Then
                                    m_parser.VarValue(j) = m_shapefile.Shape(Long.Parse(m_Grid.Item(i, 0).ToString())).Point(m_shapefile.NumShapes - 1).x
                                ElseIf m_parser.VarName(j).ToLower() = "shapeylast" Then
                                    m_parser.VarValue(j) = m_shapefile.Shape(Long.Parse(m_Grid.Item(i, 0).ToString())).Point(m_shapefile.NumShapes - 1).y
                                ElseIf m_parser.VarName(j).ToLower() = "shapezlast" Then
                                    m_parser.VarValue(j) = m_shapefile.Shape(Long.Parse(m_Grid.Item(i, 0).ToString())).Point(m_shapefile.NumShapes - 1).Z
                                End If
                            Catch ex2 As Exception
                                mapwinutility.logger.dbg("DEBUG: " + ex2.ToString())
                            End Try
                        Next
                    Next

                    Dim val As String = m_parser.Eval().ToString()
                    m_Grid.Item(i, m_DestFieldColumn) = val
                Catch ex2 As Exception
                    mapwinutility.logger.msg("The data is an invalid type for the destination table cell.", MsgBoxStyle.Exclamation, "Field Calculator: Cannot Store Field Value")
                    Return False
                End Try
            End If
        Next i

        Return True
    End Function

    Private Sub DestFieldComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DestFieldComboBox.SelectedIndexChanged
        Try
            Dim isNumber As Boolean = False
            m_DestFieldName = DestFieldComboBox.SelectedItem
            m_DestFieldColumn = GetFieldColumn(DestFieldComboBox.SelectedItem, m_Grid)
            If CType(m_Grid.DataSource, DataTable).Columns(m_DestFieldColumn).DataType.Name = "Int16" Then
                isNumber = True
            ElseIf CType(m_Grid.DataSource, DataTable).Columns(m_DestFieldColumn).DataType.Name = "Int32" Then
                isNumber = True
            ElseIf CType(m_Grid.DataSource, DataTable).Columns(m_DestFieldColumn).DataType.Name = "Int64" Then
                isNumber = True
            ElseIf CType(m_Grid.DataSource, DataTable).Columns(m_DestFieldColumn).DataType.Name = "Integer" Then
                isNumber = True
            ElseIf CType(m_Grid.DataSource, DataTable).Columns(m_DestFieldColumn).DataType.Name = "Double" Then
                isNumber = True
            End If
            If isNumber Then
                btnConcat.Enabled = False
            Else
                btnConcat.Enabled = True
            End If
        Catch ex As Exception
            mapwinutility.logger.msg("Could not set destination field name: " & ex.Message, MsgBoxStyle.Exclamation, "Field Calculator: Error setting field name")
        End Try
    End Sub

    Private Function GetFieldColumn(ByVal fieldName As String, ByVal grid As DataGrid) As Integer
        Dim i As Integer
        For i = 0 To CType(grid.DataSource, DataTable).Columns.Count - 1
            If fieldName = CType(grid.DataSource, DataTable).Columns.Item(i).Caption Then
                Return i
            End If
        Next i
        mapwinutility.logger.msg("An Invalid Field was selected in the Field Calculator Tool: " & fieldName, MsgBoxStyle.Critical, "Field Calculator: Invalid Field Selected")
        Return 0
    End Function

    Private Sub CloseParens(ByRef text As String)
        Dim opencount As Integer = 0
        Dim i As Integer
        For i = 0 To text.Length - 1
            If text.Chars(i) = "(" Then
                opencount = opencount + 1
            ElseIf text.Chars(i) = ")" Then
                opencount = opencount - 1
            End If
        Next i
        For i = 0 To opencount - 1
            text = String.Concat(text, ")")
        Next i
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("http://www.mapwindow.org/wiki/index.php/MapWindow:TableEditorFunctions")
    End Sub

    Private Sub frmFieldCalculator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        CType(Me.Owner, frmTableEditor).TextCalculator()
        Me.Close()
    End Sub
End Class
