'********************************************************************************************************
'File Name: frmQueryBuilder.vb
'Description: This form is used to assemble a query to run against the attribute table.
'********************************************************************************************************
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
'               + Add Shortcut key for Query assigned as F6
'               + Add Esc key for Close button
'               + Add F5 key for Execute (old name: Apply)
Public Class frmQueryBuilder
    Inherits System.Windows.Forms.Form
    Public Tableform As frmTableEditor

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
    Friend WithEvents Fields_lb As System.Windows.Forms.ListBox
    Friend WithEvents equals_op As System.Windows.Forms.Button
    Friend WithEvents notequal_op As System.Windows.Forms.Button
    Friend WithEvents greaterthan_op As System.Windows.Forms.Button
    Friend WithEvents greaterthanorequal_op As System.Windows.Forms.Button
    Friend WithEvents lessthan_op As System.Windows.Forms.Button
    Friend WithEvents lessthanorequal_op As System.Windows.Forms.Button
    Friend WithEvents and_op As System.Windows.Forms.Button
    Friend WithEvents or_op As System.Windows.Forms.Button
    Friend WithEvents not_op As System.Windows.Forms.Button
    Friend WithEvents like_op As System.Windows.Forms.Button
    Friend WithEvents query_text_tb As System.Windows.Forms.TextBox
    Friend WithEvents Apply As System.Windows.Forms.Button
    Friend WithEvents Close_bn As System.Windows.Forms.Button
    Friend WithEvents Query_help As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQueryBuilder))
        Me.Fields_lb = New System.Windows.Forms.ListBox
        Me.equals_op = New System.Windows.Forms.Button
        Me.notequal_op = New System.Windows.Forms.Button
        Me.greaterthan_op = New System.Windows.Forms.Button
        Me.greaterthanorequal_op = New System.Windows.Forms.Button
        Me.lessthan_op = New System.Windows.Forms.Button
        Me.lessthanorequal_op = New System.Windows.Forms.Button
        Me.and_op = New System.Windows.Forms.Button
        Me.or_op = New System.Windows.Forms.Button
        Me.not_op = New System.Windows.Forms.Button
        Me.like_op = New System.Windows.Forms.Button
        Me.query_text_tb = New System.Windows.Forms.TextBox
        Me.Apply = New System.Windows.Forms.Button
        Me.Close_bn = New System.Windows.Forms.Button
        Me.Query_help = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Fields_lb
        '
        resources.ApplyResources(Me.Fields_lb, "Fields_lb")
        Me.Fields_lb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Fields_lb.Name = "Fields_lb"
        Me.Fields_lb.Sorted = True
        '
        'equals_op
        '
        resources.ApplyResources(Me.equals_op, "equals_op")
        Me.equals_op.Name = "equals_op"
        '
        'notequal_op
        '
        resources.ApplyResources(Me.notequal_op, "notequal_op")
        Me.notequal_op.Name = "notequal_op"
        '
        'greaterthan_op
        '
        resources.ApplyResources(Me.greaterthan_op, "greaterthan_op")
        Me.greaterthan_op.Name = "greaterthan_op"
        '
        'greaterthanorequal_op
        '
        resources.ApplyResources(Me.greaterthanorequal_op, "greaterthanorequal_op")
        Me.greaterthanorequal_op.Name = "greaterthanorequal_op"
        '
        'lessthan_op
        '
        resources.ApplyResources(Me.lessthan_op, "lessthan_op")
        Me.lessthan_op.Name = "lessthan_op"
        '
        'lessthanorequal_op
        '
        resources.ApplyResources(Me.lessthanorequal_op, "lessthanorequal_op")
        Me.lessthanorequal_op.Name = "lessthanorequal_op"
        '
        'and_op
        '
        resources.ApplyResources(Me.and_op, "and_op")
        Me.and_op.Name = "and_op"
        '
        'or_op
        '
        resources.ApplyResources(Me.or_op, "or_op")
        Me.or_op.Name = "or_op"
        '
        'not_op
        '
        resources.ApplyResources(Me.not_op, "not_op")
        Me.not_op.Name = "not_op"
        '
        'like_op
        '
        resources.ApplyResources(Me.like_op, "like_op")
        Me.like_op.Name = "like_op"
        '
        'query_text_tb
        '
        resources.ApplyResources(Me.query_text_tb, "query_text_tb")
        Me.query_text_tb.Name = "query_text_tb"
        '
        'Apply
        '
        resources.ApplyResources(Me.Apply, "Apply")
        Me.Apply.Name = "Apply"
        '
        'Close_bn
        '
        resources.ApplyResources(Me.Close_bn, "Close_bn")
        Me.Close_bn.Name = "Close_bn"
        '
        'Query_help
        '
        resources.ApplyResources(Me.Query_help, "Query_help")
        Me.Query_help.Name = "Query_help"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'frmQueryBuilder
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Query_help)
        Me.Controls.Add(Me.Close_bn)
        Me.Controls.Add(Me.Apply)
        Me.Controls.Add(Me.query_text_tb)
        Me.Controls.Add(Me.like_op)
        Me.Controls.Add(Me.not_op)
        Me.Controls.Add(Me.or_op)
        Me.Controls.Add(Me.and_op)
        Me.Controls.Add(Me.lessthanorequal_op)
        Me.Controls.Add(Me.lessthan_op)
        Me.Controls.Add(Me.greaterthanorequal_op)
        Me.Controls.Add(Me.greaterthan_op)
        Me.Controls.Add(Me.notequal_op)
        Me.Controls.Add(Me.equals_op)
        Me.Controls.Add(Me.Fields_lb)
        Me.KeyPreview = True
        Me.Name = "frmQueryBuilder"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    '***Added by Nathan Eaton, CALM 02/05***

    Private Sub Close_bn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Close_bn.Click
        Me.Close()
    End Sub

    Private Sub equals_op_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles equals_op.Click

        Me.query_text_tb.Text = Me.query_text_tb.Text & " = "
        Me.query_text_tb.Focus()
        Me.query_text_tb.AppendText("")
    End Sub

    Private Sub notequal_op_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles notequal_op.Click
        Me.query_text_tb.Text = Me.query_text_tb.Text & " <> "
        Me.query_text_tb.Focus()
        Me.query_text_tb.AppendText("")
    End Sub

    Private Sub greaterthan_op_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles greaterthan_op.Click
        Me.query_text_tb.Text = Me.query_text_tb.Text & " > "
        Me.query_text_tb.Focus()
        Me.query_text_tb.AppendText("")
    End Sub

    Private Sub greaterthanorequal_op_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles greaterthanorequal_op.Click
        Me.query_text_tb.Text = Me.query_text_tb.Text & " >= "
        Me.query_text_tb.Focus()
        Me.query_text_tb.AppendText("")
    End Sub

    Private Sub lessthan_op_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lessthan_op.Click
        Me.query_text_tb.Text = Me.query_text_tb.Text & " < "
        Me.query_text_tb.Focus()
        Me.query_text_tb.AppendText("")
    End Sub

    Private Sub lessthanorequal_op_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lessthanorequal_op.Click
        Me.query_text_tb.Text = Me.query_text_tb.Text & " <= "
        Me.query_text_tb.Focus()
        Me.query_text_tb.AppendText("")
    End Sub

    Private Sub and_op_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles and_op.Click
        Me.query_text_tb.Text = Me.query_text_tb.Text & " And "
        Me.query_text_tb.Focus()
        Me.query_text_tb.AppendText("")
    End Sub

    Private Sub or_op_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles or_op.Click
        Me.query_text_tb.Text = Me.query_text_tb.Text & " Or "
        Me.query_text_tb.Focus()
        Me.query_text_tb.AppendText("")
    End Sub

    Private Sub not_op_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles not_op.Click
        Me.query_text_tb.Text = Me.query_text_tb.Text & " Not "
        Me.query_text_tb.Focus()
        Me.query_text_tb.AppendText("")
    End Sub

    Private Sub like_op_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles like_op.Click
        Me.query_text_tb.Text = Me.query_text_tb.Text & " Like "
        Me.query_text_tb.Focus()
        Me.query_text_tb.AppendText("")
    End Sub

    Private Sub Apply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Apply.Click
        Dim querystring As String
        querystring = Me.query_text_tb.Text

        'Send the query text to the routine that will perform the query on the table
        Tableform.Query(querystring)
    End Sub

    Private Sub Fields_lb_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fields_lb.DoubleClick
        If Me.query_text_tb.Text = "" Then
            Me.query_text_tb.Text = Me.query_text_tb.Text & Me.Fields_lb.Items.Item(Me.Fields_lb.SelectedIndex)
        Else
            Me.query_text_tb.Text = Me.query_text_tb.Text & " " & Me.Fields_lb.Items.Item(Me.Fields_lb.SelectedIndex)
        End If
        Me.query_text_tb.Focus()
        Me.query_text_tb.AppendText("")
    End Sub

    Private Sub Query_help_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Query_help.Click
        Dim dlg As New frmHelp
        dlg.TopMost = True
        'Bring up the help textbox to provide hints on how to create a valid query
        dlg.help_tb.Text = "Boolean Operators:" & ControlChars.NewLine & "AND, OR, NOT" & ControlChars.NewLine & ControlChars.NewLine & "Comparison Operators:" & ControlChars.NewLine & "< >, <=, >=, <>, IN, LIKE" & ControlChars.NewLine & ControlChars.NewLine & "Numeric Constants:" & ControlChars.NewLine & "50 or 50.0 or 5E1 (Numeric constants can be represented as integers, floating point or in scientific notation" & ControlChars.NewLine & ControlChars.NewLine & "String Constants:" & ControlChars.NewLine & "'Tenure' (String Constants should be quoted with single quotes)" & ControlChars.NewLine & ControlChars.NewLine & "Arithmetic Operators:" & ControlChars.NewLine & "+, -, *, /, %" & _
        ControlChars.NewLine & ControlChars.NewLine & "String Concatentaion Operator:" & ControlChars.NewLine & "+ (eg 'cat' + 'inhat' = 'catinhat')" & ControlChars.NewLine & ControlChars.NewLine & "Aggregate Functions:" & ControlChars.NewLine & "Sum(), Avg(), Min(), Max(), StDev(), Var()" & ControlChars.NewLine & ControlChars.NewLine & "String Manipulators:" & ControlChars.NewLine & "TRIM(Expression) - Removes leading and trailing blanks" & ControlChars.NewLine & "SUBSTRING(Expression, start, length) - Returns a substring of an existing string at a given length from the specified starting point" & _
        ControlChars.NewLine & ControlChars.NewLine & "Example1 - Multi Criteria Query" & ControlChars.NewLine & "tenure_type = 'Freehold' AND tenure_area > 5000"
        dlg.help_tb.SelectionLength = 0
        dlg.ShowDialog()
    End Sub

    Private Sub frmQueryBuilder_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Windows.Forms.Keys.F5
                Apply_Click(sender, e.Empty)
            Case Windows.Forms.Keys.Escape
                Close_bn_Click(sender, e.Empty)
        End Select
    End Sub
End Class
