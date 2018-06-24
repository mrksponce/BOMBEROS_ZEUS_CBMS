namespace Zeus.UIElements
{
    partial class BtnEstadoCarro
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
            this.menuEstadoCarros = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.info = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmObservacion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmIngresoObs = new System.Windows.Forms.ToolStripTextBox();
            this.tsmUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.enServicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.C0_8 = new System.Windows.Forms.ToolStripMenuItem();
            this.eléctricoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mecánicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.CS_C = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuLiberarCarro = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.liberarCarroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.menuEstadoCarros.SuspendLayout();
            this.menuLiberarCarro.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuEstadoCarros
            // 
            this.menuEstadoCarros.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.info,
            this.toolStripSeparator4,
            this.tsmObservacion,
            this.tsmUsuario,
            this.toolStripSeparator1,
            this.enServicioToolStripMenuItem,
            this.C0_8,
            this.CS_C});
            this.menuEstadoCarros.Name = "MenuEstadoCarros";
            this.menuEstadoCarros.Size = new System.Drawing.Size(153, 170);
            this.menuEstadoCarros.Opening += new System.ComponentModel.CancelEventHandler(this.MenuEstadoCarros_Opening);
            // 
            // info
            // 
            this.info.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.info.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.info.Enabled = false;
            this.info.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.info.ForeColor = System.Drawing.SystemColors.ControlText;
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(152, 22);
            this.info.Text = "(informacion)";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(149, 6);
            // 
            // tsmObservacion
            // 
            this.tsmObservacion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.tsmIngresoObs});
            this.tsmObservacion.Name = "tsmObservacion";
            this.tsmObservacion.Size = new System.Drawing.Size(152, 22);
            this.tsmObservacion.Text = "Observacion:";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(340, 22);
            this.toolStripMenuItem2.Text = "Ingrese Observación:";
            // 
            // tsmIngresoObs
            // 
            this.tsmIngresoObs.Name = "tsmIngresoObs";
            this.tsmIngresoObs.Size = new System.Drawing.Size(280, 23);
            this.tsmIngresoObs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripTextBox3_KeyPress);
            // 
            // tsmUsuario
            // 
            this.tsmUsuario.Name = "tsmUsuario";
            this.tsmUsuario.Size = new System.Drawing.Size(152, 22);
            this.tsmUsuario.Text = "Ingresado por:";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // enServicioToolStripMenuItem
            // 
            this.enServicioToolStripMenuItem.Name = "enServicioToolStripMenuItem";
            this.enServicioToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.enServicioToolStripMenuItem.Text = "En servicio";
            // 
            // C0_8
            // 
            this.C0_8.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eléctricoToolStripMenuItem,
            this.mecánicoToolStripMenuItem,
            this.toolStripTextBox1});
            this.C0_8.Name = "C0_8";
            this.C0_8.Size = new System.Drawing.Size(152, 22);
            this.C0_8.Text = "F. de Servicio";
            // 
            // eléctricoToolStripMenuItem
            // 
            this.eléctricoToolStripMenuItem.Name = "eléctricoToolStripMenuItem";
            this.eléctricoToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.eléctricoToolStripMenuItem.Text = "Eléctrico";
            this.eléctricoToolStripMenuItem.Click += new System.EventHandler(this.FueraServicioMenuItem_Click);
            // 
            // mecánicoToolStripMenuItem
            // 
            this.mecánicoToolStripMenuItem.Name = "mecánicoToolStripMenuItem";
            this.mecánicoToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.mecánicoToolStripMenuItem.Text = "Mecánico";
            this.mecánicoToolStripMenuItem.Click += new System.EventHandler(this.FueraServicioMenuItem_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox1.Text = "Otro:";
            this.toolStripTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripTextBox1_KeyPress);
            // 
            // CS_C
            // 
            this.CS_C.Name = "CS_C";
            this.CS_C.Size = new System.Drawing.Size(152, 22);
            this.CS_C.Text = "Sin Conductor";
            this.CS_C.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 3;
            this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
            this.button1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button1_MouseUp);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 48);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // menuLiberarCarro
            // 
            this.menuLiberarCarro.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator3,
            this.liberarCarroToolStripMenuItem});
            this.menuLiberarCarro.Name = "menuLiberarCarro";
            this.menuLiberarCarro.Size = new System.Drawing.Size(181, 54);
            this.menuLiberarCarro.Opening += new System.ComponentModel.CancelEventHandler(this.menuLiberarCarro_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            // 
            // liberarCarroToolStripMenuItem
            // 
            this.liberarCarroToolStripMenuItem.Name = "liberarCarroToolStripMenuItem";
            this.liberarCarroToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.liberarCarroToolStripMenuItem.Text = "&Liberar Carro";
            this.liberarCarroToolStripMenuItem.Click += new System.EventHandler(this.liberarCarroToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Yellow;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 33);
            this.label3.TabIndex = 3;
            this.label3.Text = "label2";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BtnEstadoCarro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "BtnEstadoCarro";
            this.Size = new System.Drawing.Size(61, 25);
            this.menuEstadoCarros.ResumeLayout(false);
            this.menuLiberarCarro.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip menuEstadoCarros;
        private System.Windows.Forms.ToolStripMenuItem info;
        private System.Windows.Forms.ToolStripMenuItem C0_8;
        private System.Windows.Forms.ToolStripMenuItem CS_C;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem eléctricoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mecánicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem enServicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ContextMenuStrip menuLiberarCarro;
        private System.Windows.Forms.ToolStripMenuItem liberarCarroToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmObservacion;
        private System.Windows.Forms.ToolStripTextBox tsmIngresoObs;
        private System.Windows.Forms.ToolStripMenuItem tsmUsuario;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}
