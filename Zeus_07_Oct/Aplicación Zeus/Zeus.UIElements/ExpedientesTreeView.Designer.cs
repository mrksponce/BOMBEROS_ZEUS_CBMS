namespace Zeus.UIElements
{
    partial class ExpedientesTreeView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpedientesTreeView));
            this.treeExpedientes = new System.Windows.Forms.TreeView();
            this.imageTiposDeLlamado = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // treeExpedientes
            // 
            this.treeExpedientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeExpedientes.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeExpedientes.FullRowSelect = true;
            this.treeExpedientes.HideSelection = false;
            this.treeExpedientes.HotTracking = true;
            this.treeExpedientes.ImageIndex = 0;
            this.treeExpedientes.ImageList = this.imageTiposDeLlamado;
            this.treeExpedientes.ItemHeight = 26;
            this.treeExpedientes.Location = new System.Drawing.Point(0, 26);
            this.treeExpedientes.Name = "treeExpedientes";
            this.treeExpedientes.SelectedImageIndex = 0;
            this.treeExpedientes.Size = new System.Drawing.Size(330, 307);
            this.treeExpedientes.TabIndex = 1;
            this.treeExpedientes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeExpedientes_AfterSelect);
            // 
            // imageTiposDeLlamado
            // 
            this.imageTiposDeLlamado.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageTiposDeLlamado.ImageStream")));
            this.imageTiposDeLlamado.TransparentColor = System.Drawing.Color.Transparent;
            this.imageTiposDeLlamado.Images.SetKeyName(0, "6-0R");
            this.imageTiposDeLlamado.Images.SetKeyName(1, "6-0Rs");
            this.imageTiposDeLlamado.Images.SetKeyName(2, "6-0V");
            this.imageTiposDeLlamado.Images.SetKeyName(3, "6-0Vs");
            this.imageTiposDeLlamado.Images.SetKeyName(4, "6-1");
            this.imageTiposDeLlamado.Images.SetKeyName(5, "6-1s");
            this.imageTiposDeLlamado.Images.SetKeyName(6, "6-3");
            this.imageTiposDeLlamado.Images.SetKeyName(7, "6-3s");
            this.imageTiposDeLlamado.Images.SetKeyName(8, "6-8");
            this.imageTiposDeLlamado.Images.SetKeyName(9, "6-8s");
            this.imageTiposDeLlamado.Images.SetKeyName(10, "6-9");
            this.imageTiposDeLlamado.Images.SetKeyName(11, "6-9s");
            this.imageTiposDeLlamado.Images.SetKeyName(12, "6-10");
            this.imageTiposDeLlamado.Images.SetKeyName(13, "6-10s");
            this.imageTiposDeLlamado.Images.SetKeyName(14, "6-11");
            this.imageTiposDeLlamado.Images.SetKeyName(15, "6-11s");
            this.imageTiposDeLlamado.Images.SetKeyName(16, "6-12");
            this.imageTiposDeLlamado.Images.SetKeyName(17, "6-12s");
            this.imageTiposDeLlamado.Images.SetKeyName(18, "6-13");
            this.imageTiposDeLlamado.Images.SetKeyName(19, "6-13s");
            this.imageTiposDeLlamado.Images.SetKeyName(20, "6-14");
            this.imageTiposDeLlamado.Images.SetKeyName(21, "6-14s");
            this.imageTiposDeLlamado.Images.SetKeyName(22, "6-15");
            this.imageTiposDeLlamado.Images.SetKeyName(23, "6-15s");
            this.imageTiposDeLlamado.Images.SetKeyName(24, "6-16");
            this.imageTiposDeLlamado.Images.SetKeyName(25, "6-16s");
            this.imageTiposDeLlamado.Images.SetKeyName(26, "6-17");
            this.imageTiposDeLlamado.Images.SetKeyName(27, "6-17s");
            this.imageTiposDeLlamado.Images.SetKeyName(28, "BAT5_V_S.png");
            this.imageTiposDeLlamado.Images.SetKeyName(29, "10-0");
            this.imageTiposDeLlamado.Images.SetKeyName(30, "10-0s");
            this.imageTiposDeLlamado.Images.SetKeyName(31, "10-0-ok");
            this.imageTiposDeLlamado.Images.SetKeyName(32, "10-0-oks");
            this.imageTiposDeLlamado.Images.SetKeyName(33, "10-1");
            this.imageTiposDeLlamado.Images.SetKeyName(34, "10-1s");
            this.imageTiposDeLlamado.Images.SetKeyName(35, "10-1-ok");
            this.imageTiposDeLlamado.Images.SetKeyName(36, "10-1-oks");
            this.imageTiposDeLlamado.Images.SetKeyName(37, "10-2");
            this.imageTiposDeLlamado.Images.SetKeyName(38, "10-2s");
            this.imageTiposDeLlamado.Images.SetKeyName(39, "10-2-ok");
            this.imageTiposDeLlamado.Images.SetKeyName(40, "10-2-oks");
            this.imageTiposDeLlamado.Images.SetKeyName(41, "10-3");
            this.imageTiposDeLlamado.Images.SetKeyName(42, "10-3s");
            this.imageTiposDeLlamado.Images.SetKeyName(43, "10-3-ok");
            this.imageTiposDeLlamado.Images.SetKeyName(44, "10-3-oks");
            this.imageTiposDeLlamado.Images.SetKeyName(45, "10-4");
            this.imageTiposDeLlamado.Images.SetKeyName(46, "10-4s");
            this.imageTiposDeLlamado.Images.SetKeyName(47, "10-4-ok");
            this.imageTiposDeLlamado.Images.SetKeyName(48, "10-4-oks");
            this.imageTiposDeLlamado.Images.SetKeyName(49, "10-5");
            this.imageTiposDeLlamado.Images.SetKeyName(50, "10-5s");
            this.imageTiposDeLlamado.Images.SetKeyName(51, "10-5-ok");
            this.imageTiposDeLlamado.Images.SetKeyName(52, "10-5-oks");
            this.imageTiposDeLlamado.Images.SetKeyName(53, "10-6");
            this.imageTiposDeLlamado.Images.SetKeyName(54, "10-6s");
            this.imageTiposDeLlamado.Images.SetKeyName(55, "10-6-ok");
            this.imageTiposDeLlamado.Images.SetKeyName(56, "10-6-oks");
            this.imageTiposDeLlamado.Images.SetKeyName(57, "10-7");
            this.imageTiposDeLlamado.Images.SetKeyName(58, "10-7s");
            this.imageTiposDeLlamado.Images.SetKeyName(59, "10-7-ok");
            this.imageTiposDeLlamado.Images.SetKeyName(60, "10-7-oks");
            this.imageTiposDeLlamado.Images.SetKeyName(61, "10-8");
            this.imageTiposDeLlamado.Images.SetKeyName(62, "10-8s");
            this.imageTiposDeLlamado.Images.SetKeyName(63, "10-8-ok");
            this.imageTiposDeLlamado.Images.SetKeyName(64, "10-8-oks");
            this.imageTiposDeLlamado.Images.SetKeyName(65, "10-9");
            this.imageTiposDeLlamado.Images.SetKeyName(66, "10-9s");
            this.imageTiposDeLlamado.Images.SetKeyName(67, "10-9-ok");
            this.imageTiposDeLlamado.Images.SetKeyName(68, "10-9-oks");
            this.imageTiposDeLlamado.Images.SetKeyName(69, "10-10");
            this.imageTiposDeLlamado.Images.SetKeyName(70, "10-10s");
            this.imageTiposDeLlamado.Images.SetKeyName(71, "10-10-ok");
            this.imageTiposDeLlamado.Images.SetKeyName(72, "10-10-oks");
            this.imageTiposDeLlamado.Images.SetKeyName(73, "10-11");
            this.imageTiposDeLlamado.Images.SetKeyName(74, "10-11s");
            this.imageTiposDeLlamado.Images.SetKeyName(75, "10-11-ok");
            this.imageTiposDeLlamado.Images.SetKeyName(76, "10-11-oks");
            this.imageTiposDeLlamado.Images.SetKeyName(77, "10-12");
            this.imageTiposDeLlamado.Images.SetKeyName(78, "10-12s");
            this.imageTiposDeLlamado.Images.SetKeyName(79, "10-12-ok");
            this.imageTiposDeLlamado.Images.SetKeyName(80, "10-12-oks");
            this.imageTiposDeLlamado.Images.SetKeyName(81, "10-13");
            this.imageTiposDeLlamado.Images.SetKeyName(82, "10-13s");
            this.imageTiposDeLlamado.Images.SetKeyName(83, "10-13-ok");
            this.imageTiposDeLlamado.Images.SetKeyName(84, "10-13-oks");
            this.imageTiposDeLlamado.Images.SetKeyName(85, "10-14");
            this.imageTiposDeLlamado.Images.SetKeyName(86, "10-14s");
            this.imageTiposDeLlamado.Images.SetKeyName(87, "10-14-ok");
            this.imageTiposDeLlamado.Images.SetKeyName(88, "10-14-oks");
            this.imageTiposDeLlamado.Images.SetKeyName(89, "1-BAT");
            this.imageTiposDeLlamado.Images.SetKeyName(90, "1-BATs");
            this.imageTiposDeLlamado.Images.SetKeyName(91, "1-BAT-ok");
            this.imageTiposDeLlamado.Images.SetKeyName(92, "1-BAT-oks");
            this.imageTiposDeLlamado.Images.SetKeyName(93, "2-BAT");
            this.imageTiposDeLlamado.Images.SetKeyName(94, "2-BATs");
            this.imageTiposDeLlamado.Images.SetKeyName(95, "2-BAT-ok");
            this.imageTiposDeLlamado.Images.SetKeyName(96, "2-BAT-oks");
            this.imageTiposDeLlamado.Images.SetKeyName(97, "3-BAT");
            this.imageTiposDeLlamado.Images.SetKeyName(98, "3-BATs");
            this.imageTiposDeLlamado.Images.SetKeyName(99, "3-BAT-ok");
            this.imageTiposDeLlamado.Images.SetKeyName(100, "3-BAT-oks");
            this.imageTiposDeLlamado.Images.SetKeyName(101, "4-BAT");
            this.imageTiposDeLlamado.Images.SetKeyName(102, "4-BATs");
            this.imageTiposDeLlamado.Images.SetKeyName(103, "4-BAT-ok");
            this.imageTiposDeLlamado.Images.SetKeyName(104, "4-BAT-oks");
            this.imageTiposDeLlamado.Images.SetKeyName(105, "5-BAT");
            this.imageTiposDeLlamado.Images.SetKeyName(106, "5-BATs");
            this.imageTiposDeLlamado.Images.SetKeyName(107, "5-BAT-ok");
            this.imageTiposDeLlamado.Images.SetKeyName(108, "0-8");
            this.imageTiposDeLlamado.Images.SetKeyName(109, "0-8s");
            this.imageTiposDeLlamado.Images.SetKeyName(110, "0-9");
            this.imageTiposDeLlamado.Images.SetKeyName(111, "0-9s");
            this.imageTiposDeLlamado.Images.SetKeyName(112, "6-2");
            this.imageTiposDeLlamado.Images.SetKeyName(113, "6-2s");
            this.imageTiposDeLlamado.Images.SetKeyName(114, "INC.");
            this.imageTiposDeLlamado.Images.SetKeyName(115, "INC.s");
            this.imageTiposDeLlamado.Images.SetKeyName(116, "INC.-ok");
            this.imageTiposDeLlamado.Images.SetKeyName(117, "INC.-oks");
            this.imageTiposDeLlamado.Images.SetKeyName(118, "2da Alm.");
            this.imageTiposDeLlamado.Images.SetKeyName(119, "2da Alm.s");
            this.imageTiposDeLlamado.Images.SetKeyName(120, "2da Alm.-ok");
            this.imageTiposDeLlamado.Images.SetKeyName(121, "2da Alm.-oks");
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Actos de Servicio";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdate.Image = global::Zeus.UIElements.Properties.Resources.update;
            this.btnUpdate.Location = new System.Drawing.Point(304, 0);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(23, 23);
            this.btnUpdate.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnUpdate, "Actualizar Lista");
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.BackgroundImage = global::Zeus.UIElements.Properties.Resources.ZEUS_TreeView;
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 339);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(324, 182);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // ExpedientesTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeExpedientes);
            this.Name = "ExpedientesTreeView";
            this.Size = new System.Drawing.Size(330, 466);
            this.Load += new System.EventHandler(this.MainTree_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeExpedientes;
        private System.Windows.Forms.ImageList imageTiposDeLlamado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
