Public Class frmPrint
    Inherits System.Windows.Forms.Form
    Private m_Image As Bitmap
    Private m_Font As Font

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
    Friend WithEvents PrintDocument As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintPreviewDialog As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnPrintProperties As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents cbScaleBar As System.Windows.Forms.CheckBox
    Friend WithEvents cbLegend As System.Windows.Forms.CheckBox
    Friend WithEvents cbVisibleLayersOnly As System.Windows.Forms.CheckBox
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents cbTitle As System.Windows.Forms.CheckBox
    Friend WithEvents btnFont As System.Windows.Forms.Button
    Friend WithEvents FontDialog As System.Windows.Forms.FontDialog
    Friend WithEvents cbNorthArrow As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPrint))
        Me.PrintDocument = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.btnPrintProperties = New System.Windows.Forms.Button()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.PrintDialog = New System.Windows.Forms.PrintDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnFont = New System.Windows.Forms.Button()
        Me.cbTitle = New System.Windows.Forms.CheckBox()
        Me.cbNorthArrow = New System.Windows.Forms.CheckBox()
        Me.cbScaleBar = New System.Windows.Forms.CheckBox()
        Me.cbVisibleLayersOnly = New System.Windows.Forms.CheckBox()
        Me.cbLegend = New System.Windows.Forms.CheckBox()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.FontDialog = New System.Windows.Forms.FontDialog()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PrintDocument
        '
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Location = New System.Drawing.Point(150, 17)
        Me.PrintPreviewDialog1.MaximumSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Opacity = 1
        Me.PrintPreviewDialog1.TransparencyKey = System.Drawing.Color.Empty
        Me.PrintPreviewDialog1.Visible = False
        '
        'btnPrintProperties
        '
        Me.btnPrintProperties.Location = New System.Drawing.Point(256, 16)
        Me.btnPrintProperties.Name = "btnPrintProperties"
        Me.btnPrintProperties.Size = New System.Drawing.Size(104, 24)
        Me.btnPrintProperties.TabIndex = 0
        Me.btnPrintProperties.Text = "Properties"
        '
        'btnPreview
        '
        Me.btnPreview.Location = New System.Drawing.Point(256, 48)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(104, 24)
        Me.btnPreview.TabIndex = 1
        Me.btnPreview.Text = "Preview"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnFont, Me.cbTitle, Me.cbNorthArrow, Me.cbScaleBar, Me.cbVisibleLayersOnly, Me.cbLegend, Me.txtTitle})
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(240, 144)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Options"
        '
        'btnFont
        '
        Me.btnFont.Image = CType(resources.GetObject("btnFont.Image"), System.Drawing.Bitmap)
        Me.btnFont.Location = New System.Drawing.Point(200, 104)
        Me.btnFont.Name = "btnFont"
        Me.btnFont.Size = New System.Drawing.Size(32, 24)
        Me.btnFont.TabIndex = 8
        '
        'cbTitle
        '
        Me.cbTitle.Location = New System.Drawing.Point(8, 80)
        Me.cbTitle.Name = "cbTitle"
        Me.cbTitle.Size = New System.Drawing.Size(120, 16)
        Me.cbTitle.TabIndex = 7
        Me.cbTitle.Text = "Title"
        '
        'cbNorthArrow
        '
        Me.cbNorthArrow.Location = New System.Drawing.Point(136, 48)
        Me.cbNorthArrow.Name = "cbNorthArrow"
        Me.cbNorthArrow.Size = New System.Drawing.Size(88, 16)
        Me.cbNorthArrow.TabIndex = 3
        Me.cbNorthArrow.Text = "North Arrow"
        '
        'cbScaleBar
        '
        Me.cbScaleBar.Location = New System.Drawing.Point(136, 24)
        Me.cbScaleBar.Name = "cbScaleBar"
        Me.cbScaleBar.Size = New System.Drawing.Size(72, 16)
        Me.cbScaleBar.TabIndex = 2
        Me.cbScaleBar.Text = "Scale Bar"
        '
        'cbVisibleLayersOnly
        '
        Me.cbVisibleLayersOnly.Location = New System.Drawing.Point(8, 48)
        Me.cbVisibleLayersOnly.Name = "cbVisibleLayersOnly"
        Me.cbVisibleLayersOnly.Size = New System.Drawing.Size(120, 16)
        Me.cbVisibleLayersOnly.TabIndex = 1
        Me.cbVisibleLayersOnly.Text = "Visible Layers Only"
        '
        'cbLegend
        '
        Me.cbLegend.Location = New System.Drawing.Point(8, 24)
        Me.cbLegend.Name = "cbLegend"
        Me.cbLegend.Size = New System.Drawing.Size(72, 16)
        Me.cbLegend.TabIndex = 0
        Me.cbLegend.Text = "Legend"
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(8, 104)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(184, 20)
        Me.txtTitle.TabIndex = 6
        Me.txtTitle.Text = ""
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnPrint.Location = New System.Drawing.Point(216, 160)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(72, 24)
        Me.btnPrint.TabIndex = 4
        Me.btnPrint.Text = "Print"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCancel.Location = New System.Drawing.Point(296, 160)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(72, 24)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        '
        'frmPrint
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(376, 190)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancel, Me.btnPrint, Me.GroupBox1, Me.btnPreview, Me.btnPrintProperties})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Print"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub PrintDocument_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument.PrintPage
        Try
            If (frmMain.Layers.NumLayers <= 0) Then
                e.Cancel = True
                Exit Sub
            End If

            Dim MapImage As Drawing.Bitmap = Microsoft.VisualBasic.Compatibility.VB6.IPictureDispToImage(frmMain.Reports.GetScreenPicture(frmMain.View.Extents).Picture)
            Dim Legend As Drawing.Bitmap = frmMain.Reports.GetLegendSnapshot(cbVisibleLayersOnly.Checked, 200)
            Dim NorthArrow As Drawing.Bitmap = frmMain.Reports.GetNorthArrow()

            'get the drawing graphic
            Dim g As System.Drawing.Graphics = e.Graphics

            'if the image is not nothing then we are printing additional pages
            If (Not m_Image Is Nothing) Then

                If (e.MarginBounds.Top + m_Image.Height > e.MarginBounds.Bottom) Then
                    'draw the legend
                    g.DrawImage(m_Image.Clone(New Rectangle(0, 0, Legend.Width, e.MarginBounds.Bottom - e.MarginBounds.Top), Legend.PixelFormat), e.MarginBounds.Left, e.MarginBounds.Top)

                    m_Image = m_Image.Clone(New Rectangle(0, e.MarginBounds.Bottom - e.MarginBounds.Top, m_Image.Width, m_Image.Height - (e.MarginBounds.Bottom - e.MarginBounds.Top)), m_Image.PixelFormat)
                    e.HasMorePages = True
                Else
                    g.DrawImage(m_Image, e.MarginBounds.Left, e.MarginBounds.Top)
                    m_Image = Nothing
                End If
                Exit Sub
            End If

            Dim brush As New System.Drawing.SolidBrush(System.Drawing.Color.Black)
            'set the title
            If (cbTitle.Checked) Then
                g.DrawString(txtTitle.Text, m_Font, brush, (e.MarginBounds.Right - e.MarginBounds.Left) / 2 - GetLen(txtTitle.Text) / 2, e.MarginBounds.Top - 30)
            End If

            Dim Pad As Integer = 25, DrawingWidth As Integer, DrawingHeight As Integer
            If (cbLegend.Checked = True) Then
                DrawingWidth = (e.MarginBounds.Right) - (e.MarginBounds.Left + Legend.Width + Pad)
            Else
                DrawingWidth = e.MarginBounds.Right - e.MarginBounds.Left
            End If
            DrawingHeight = (e.MarginBounds.Bottom) - (e.MarginBounds.Top)

            'calculate the image size
            Dim MapImageWidth As Integer, MapImageHeight As Integer
            If (MapImage.Width > MapImage.Height) Then
                If (MapImage.Width > DrawingWidth) Then
                    MapImageWidth = DrawingWidth
                    MapImageHeight = MapImage.Height - (MapImage.Width - DrawingWidth)
                Else
                    MapImageWidth = MapImage.Width
                    MapImageHeight = MapImage.Height
                End If
            ElseIf (MapImage.Height > MapImage.Width) Then
                If (MapImage.Height > DrawingHeight) Then
                    MapImageHeight = DrawingHeight
                    MapImageWidth = MapImage.Width - (MapImage.Height - DrawingHeight)
                Else
                    MapImageWidth = MapImage.Width
                    MapImageHeight = MapImage.Height
                End If
            End If

            'draw the mapImage
            Dim MapBounds As System.Drawing.Rectangle
            If (cbLegend.Checked) Then
                MapBounds = New Rectangle(e.MarginBounds.Left + Legend.Width + Pad + (DrawingWidth - MapImageWidth) / 2, e.MarginBounds.Top + ((DrawingHeight - MapImageHeight) / 2), MapImageWidth, MapImageHeight)
            Else
                MapBounds = New Rectangle(e.MarginBounds.Left + (DrawingWidth - MapImageWidth) / 2, e.MarginBounds.Top + ((DrawingHeight - MapImageHeight) / 2), MapImageWidth, MapImageHeight)
            End If
            g.DrawImage(MapImage, MapBounds)

            'draw the scalebar
            If (cbScaleBar.Checked) Then
                Dim ScaleBar As Drawing.Bitmap = frmMain.Reports.GetScaleBar(Interfaces.UnitOfMeasure.Meters, Interfaces.UnitOfMeasure.Meters, MapImageWidth)
                If (cbLegend.Checked) Then
                    g.DrawImage(ScaleBar, CInt(e.MarginBounds.Left + Legend.Width + Pad + (DrawingWidth / 2 - ScaleBar.Width / 2)), CInt(e.MarginBounds.Top + ((DrawingHeight - MapImageHeight) / 2) + MapImageHeight + Pad))
                Else
                    g.DrawImage(ScaleBar, CInt(e.MarginBounds.Left + (DrawingWidth / 2 - ScaleBar.Width / 2)), CInt(e.MarginBounds.Top + ((DrawingHeight - MapImageHeight) / 2) + MapImageHeight + Pad))
                End If
            End If

            'draw the north arrow
            If (cbNorthArrow.Checked) Then
                Dim image As Bitmap = New Icon(Me.GetType, "NorthArrow.ico").ToBitmap
                g.DrawImage(image, e.MarginBounds.Right - image.Width, e.MarginBounds.Top)
            End If

            'check to see if we need to print another page
            If (cbLegend.Checked) Then
                If (e.MarginBounds.Top + Legend.Height > e.MarginBounds.Bottom) Then

                    'draw the legend
                    g.DrawImage(Legend.Clone(New Rectangle(0, 0, Legend.Width, e.MarginBounds.Bottom - e.MarginBounds.Top), Legend.PixelFormat), e.MarginBounds.Left, e.MarginBounds.Top)

                    'save the remainder of the image
                    m_Image = Legend.Clone(New Rectangle(0, e.MarginBounds.Bottom - e.MarginBounds.Top, Legend.Width, Legend.Height - (e.MarginBounds.Bottom - e.MarginBounds.Top)), Legend.PixelFormat)
                    e.HasMorePages = True
                Else
                    g.DrawImage(Legend, e.MarginBounds.Left, e.MarginBounds.Top)
                End If
            End If

            ' g.DrawRectangle(New Pen(System.Drawing.Color.Red), New Rectangle(e.MarginBounds.Left + Legend.Width + Pad, e.MarginBounds.Top, DrawingWidth, DrawingHeight))
        Catch ex As System.Exception
            MsgBox("Error in PrintDocument_PrintPage, Message: " & ex.Message)
        End Try
    End Sub

    Private Sub frmPrint_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmMain.Icon
        cbTitle.Checked = False
        txtTitle.Enabled = False
        PrintPreviewDialog1.Icon = frmMain.Icon
        m_Font = Me.Font

        PrintDocument.DocumentName = "MapWindow"
        PrintDocument.DefaultPageSettings.Landscape = True
    End Sub

    Private Sub btnPrintProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintProperties.Click
        PrintDialog.Document = PrintDocument
        PrintDialog.ShowDialog()
    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Try
            PrintPreviewDialog1.Document = PrintDocument
            PrintPreviewDialog1.ShowDialog()
        Catch ex As System.Exception
            MsgBox("Error in btnPreview_Click, Message: " & ex.Message)
        End Try
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        PrintDocument.Print()
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub cbTitle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTitle.CheckedChanged
        If (cbTitle.Checked) Then
            txtTitle.Enabled = True
            btnFont.Enabled = True
        Else
            txtTitle.Enabled = False
            btnFont.Enabled = False
        End If
    End Sub

    Private Sub btnFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFont.Click
        FontDialog.MaxSize = 28
        FontDialog.ShowDialog()
        m_Font = FontDialog.Font
    End Sub

    Private Function GetLen(ByVal s As String) As Integer
        Dim lb As New Label()
        lb.Text = s
        lb.AutoSize = True
        Return lb.Width
    End Function
End Class
