namespace Zeus.UIElements
{
    partial class PanelEstadoCarros
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ToolBox = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTwitter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTonos = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCentral132 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSgas = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnOperadora = new System.Windows.Forms.ToolStripButton();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnServicio = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new Zeus.UIElements.DoubleBufferedTableLayoutPanel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ToolBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(902, 456);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel1.Controls.Add(this.ToolBox);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.btnCerrar);
            this.splitContainer1.Panel1.Controls.Add(this.btnServicio);
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(902, 456);
            this.splitContainer1.SplitterDistance = 581;
            this.splitContainer1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Zeus.UIElements.Properties.Resources.ZEUS_TreeView;
            this.pictureBox1.InitialImage = global::Zeus.UIElements.Properties.Resources.ZEUS_TreeView;
            this.pictureBox1.Location = new System.Drawing.Point(241, 414);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(330, 87);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // ToolBox
            // 
            this.ToolBox.AllowItemReorder = true;
            this.ToolBox.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ToolBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripButton3,
            this.toolStripSeparator3,
            this.toolStripButton4,
            this.toolStripSeparator5,
            this.btnTwitter,
            this.toolStripSeparator2,
            this.btnTonos,
            this.toolStripSeparator4,
            this.btnCentral132,
            this.toolStripSeparator6,
            this.btnSgas,
            this.toolStripSeparator7,
            this.btnOperadora});
            this.ToolBox.Location = new System.Drawing.Point(0, 0);
            this.ToolBox.Name = "ToolBox";
            this.ToolBox.Size = new System.Drawing.Size(737, 63);
            this.ToolBox.TabIndex = 13;
            this.ToolBox.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.Image = global::Zeus.UIElements.Properties.Resources.Salir;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(90, 60);
            this.toolStripButton2.Text = "Cerrar";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton2.ToolTipText = "Cerrar Material Mayor";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 63);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.AutoSize = false;
            this.toolStripButton3.Image = global::Zeus.UIElements.Properties.Resources.Estado_MM;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(90, 60);
            this.toolStripButton3.Text = "Entrega Turno";
            this.toolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton3.ToolTipText = "Reporte de Entrega de Turno";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 63);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.AutoSize = false;
            this.toolStripButton4.Image = global::Zeus.UIElements.Properties.Resources.Candado;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(90, 60);
            this.toolStripButton4.Text = "Conductor";
            this.toolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton4.ToolTipText = "Liberar Conductor";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 63);
            // 
            // btnTwitter
            // 
            this.btnTwitter.AutoSize = false;
            this.btnTwitter.BackColor = System.Drawing.Color.OrangeRed;
            this.btnTwitter.Checked = true;
            this.btnTwitter.CheckOnClick = true;
            this.btnTwitter.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.btnTwitter.Image = global::Zeus.UIElements.Properties.Resources.Twitter;
            this.btnTwitter.ImageTransparentColor = System.Drawing.SystemColors.Control;
            this.btnTwitter.Name = "btnTwitter";
            this.btnTwitter.Size = new System.Drawing.Size(90, 60);
            this.btnTwitter.Text = "Twitter";
            this.btnTwitter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTwitter.ToolTipText = "Publica Despachos en Twitter";
            this.btnTwitter.Click += new System.EventHandler(this.btnTwitter_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 63);
            // 
            // btnTonos
            // 
            this.btnTonos.AutoSize = false;
            this.btnTonos.BackColor = System.Drawing.Color.OrangeRed;
            this.btnTonos.Checked = true;
            this.btnTonos.CheckOnClick = true;
            this.btnTonos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnTonos.Image = global::Zeus.UIElements.Properties.Resources.Tonos;
            this.btnTonos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTonos.Name = "btnTonos";
            this.btnTonos.Size = new System.Drawing.Size(90, 60);
            this.btnTonos.Text = "Tonos";
            this.btnTonos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTonos.ToolTipText = "Activa Tonos de Despacho";
            this.btnTonos.Click += new System.EventHandler(this.btnTonos_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 63);
            // 
            // btnCentral132
            // 
            this.btnCentral132.AutoSize = false;
            this.btnCentral132.BackColor = System.Drawing.Color.OrangeRed;
            this.btnCentral132.Checked = true;
            this.btnCentral132.CheckOnClick = true;
            this.btnCentral132.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnCentral132.Image = global::Zeus.UIElements.Properties.Resources.logo_viper_512;
            this.btnCentral132.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCentral132.Name = "btnCentral132";
            this.btnCentral132.Size = new System.Drawing.Size(90, 60);
            this.btnCentral132.Text = "Cen 132";
            this.btnCentral132.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCentral132.ToolTipText = "Publica Despacho en Central 132";
            this.btnCentral132.Click += new System.EventHandler(this.btnCentral132_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 63);
            // 
            // btnSgas
            // 
            this.btnSgas.AutoSize = false;
            this.btnSgas.Checked = true;
            this.btnSgas.CheckOnClick = true;
            this.btnSgas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnSgas.Image = global::Zeus.UIElements.Properties.Resources.SGAS;
            this.btnSgas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSgas.Name = "btnSgas";
            this.btnSgas.Size = new System.Drawing.Size(90, 60);
            this.btnSgas.Text = "SGAS";
            this.btnSgas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSgas.ToolTipText = "Envía Despacho al Sistema SGAS";
            this.btnSgas.Click += new System.EventHandler(this.btnSgas_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 63);
            // 
            // btnOperadora
            // 
            this.btnOperadora.AutoSize = false;
            this.btnOperadora.Checked = true;
            this.btnOperadora.CheckOnClick = true;
            this.btnOperadora.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnOperadora.Image = global::Zeus.UIElements.Properties.Resources.Operadora;
            this.btnOperadora.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOperadora.Name = "btnOperadora";
            this.btnOperadora.Size = new System.Drawing.Size(90, 60);
            this.btnOperadora.Text = "Con TwLogin";
            this.btnOperadora.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOperadora.ToolTipText = "Publica en Twitter En Servicio 39-..";
            this.btnOperadora.Click += new System.EventHandler(this.btnOperadora_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(640, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 28);
            this.button1.TabIndex = 12;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(509, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(122, 28);
            this.btnCerrar.TabIndex = 11;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // btnServicio
            // 
            this.btnServicio.Location = new System.Drawing.Point(381, 12);
            this.btnServicio.Name = "btnServicio";
            this.btnServicio.Size = new System.Drawing.Size(122, 28);
            this.btnServicio.TabIndex = 10;
            this.btnServicio.Text = "Puesta en Servicio...";
            this.btnServicio.UseVisualStyleBackColor = true;
            this.btnServicio.Click += new System.EventHandler(this.btnServicio_Click_1);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 68);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(51, 42);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // PanelEstadoCarros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "PanelEstadoCarros";
            this.Size = new System.Drawing.Size(902, 456);
            this.Load += new System.EventHandler(this.PanelEstadoCarros_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ToolBox.ResumeLayout(false);
            this.ToolBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnServicio;
        private DoubleBufferedTableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStrip ToolBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnTwitter;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnTonos;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnCentral132;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnSgas;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton btnOperadora;
    }
}
