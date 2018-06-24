namespace Zeus.UIElements
{
    partial class frmGps
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gvGps = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.rbtn_610 = new System.Windows.Forms.RadioButton();
            this.rbtn_614 = new System.Windows.Forms.RadioButton();
            this.rbtn_615 = new System.Windows.Forms.RadioButton();
            this.rbtn_63 = new System.Windows.Forms.RadioButton();
            this.rbtn_613 = new System.Windows.Forms.RadioButton();
            this.rbtn_todos = new System.Windows.Forms.RadioButton();
            this.grpbx_opciones = new System.Windows.Forms.GroupBox();
            this.btn_mostrar = new System.Windows.Forms.Button();
            this.btn_Exportar_Excel = new System.Windows.Forms.Button();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvGps)).BeginInit();
            this.grpbx_opciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvGps
            // 
            this.gvGps.AllowUserToAddRows = false;
            this.gvGps.AllowUserToDeleteRows = false;
            this.gvGps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvGps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.gvGps.Location = new System.Drawing.Point(11, 79);
            this.gvGps.Name = "gvGps";
            this.gvGps.ReadOnly = true;
            this.gvGps.Size = new System.Drawing.Size(572, 365);
            this.gvGps.TabIndex = 0;
            this.gvGps.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvGps_CellContentClick);
            this.gvGps.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gvGps_EditingControlShowing);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID Carro";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.ToolTipText = "asdasdsa";
            this.Column1.Width = 5;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Nombre Carro";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Resultado";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "6-10";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "6-14";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "6-15";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // rbtn_610
            // 
            this.rbtn_610.AutoSize = true;
            this.rbtn_610.Location = new System.Drawing.Point(78, 24);
            this.rbtn_610.Name = "rbtn_610";
            this.rbtn_610.Size = new System.Drawing.Size(46, 17);
            this.rbtn_610.TabIndex = 1;
            this.rbtn_610.TabStop = true;
            this.rbtn_610.Text = "6-10";
            this.rbtn_610.UseVisualStyleBackColor = true;
            // 
            // rbtn_614
            // 
            this.rbtn_614.AutoSize = true;
            this.rbtn_614.Location = new System.Drawing.Point(234, 25);
            this.rbtn_614.Name = "rbtn_614";
            this.rbtn_614.Size = new System.Drawing.Size(46, 17);
            this.rbtn_614.TabIndex = 2;
            this.rbtn_614.TabStop = true;
            this.rbtn_614.Text = "6-14";
            this.rbtn_614.UseVisualStyleBackColor = true;
            // 
            // rbtn_615
            // 
            this.rbtn_615.AutoSize = true;
            this.rbtn_615.Location = new System.Drawing.Point(302, 25);
            this.rbtn_615.Name = "rbtn_615";
            this.rbtn_615.Size = new System.Drawing.Size(46, 17);
            this.rbtn_615.TabIndex = 3;
            this.rbtn_615.TabStop = true;
            this.rbtn_615.Text = "6-15";
            this.rbtn_615.UseVisualStyleBackColor = true;
            // 
            // rbtn_63
            // 
            this.rbtn_63.AutoSize = true;
            this.rbtn_63.Location = new System.Drawing.Point(16, 24);
            this.rbtn_63.Name = "rbtn_63";
            this.rbtn_63.Size = new System.Drawing.Size(40, 17);
            this.rbtn_63.TabIndex = 4;
            this.rbtn_63.TabStop = true;
            this.rbtn_63.Text = "6-3";
            this.rbtn_63.UseVisualStyleBackColor = true;
            // 
            // rbtn_613
            // 
            this.rbtn_613.AutoSize = true;
            this.rbtn_613.Location = new System.Drawing.Point(144, 24);
            this.rbtn_613.Name = "rbtn_613";
            this.rbtn_613.Size = new System.Drawing.Size(70, 17);
            this.rbtn_613.TabIndex = 5;
            this.rbtn_613.TabStop = true;
            this.rbtn_613.Text = "6-13 ó ¿?";
            this.rbtn_613.UseVisualStyleBackColor = true;
            // 
            // rbtn_todos
            // 
            this.rbtn_todos.AutoSize = true;
            this.rbtn_todos.Checked = true;
            this.rbtn_todos.Location = new System.Drawing.Point(372, 25);
            this.rbtn_todos.Name = "rbtn_todos";
            this.rbtn_todos.Size = new System.Drawing.Size(55, 17);
            this.rbtn_todos.TabIndex = 6;
            this.rbtn_todos.TabStop = true;
            this.rbtn_todos.Text = "Todos";
            this.rbtn_todos.UseVisualStyleBackColor = true;
            // 
            // grpbx_opciones
            // 
            this.grpbx_opciones.Controls.Add(this.btn_mostrar);
            this.grpbx_opciones.Controls.Add(this.rbtn_todos);
            this.grpbx_opciones.Controls.Add(this.rbtn_613);
            this.grpbx_opciones.Controls.Add(this.rbtn_63);
            this.grpbx_opciones.Controls.Add(this.rbtn_615);
            this.grpbx_opciones.Controls.Add(this.rbtn_614);
            this.grpbx_opciones.Controls.Add(this.rbtn_610);
            this.grpbx_opciones.Location = new System.Drawing.Point(12, 12);
            this.grpbx_opciones.Name = "grpbx_opciones";
            this.grpbx_opciones.Size = new System.Drawing.Size(570, 52);
            this.grpbx_opciones.TabIndex = 7;
            this.grpbx_opciones.TabStop = false;
            this.grpbx_opciones.Text = "Opciones de Localización :";
            // 
            // btn_mostrar
            // 
            this.btn_mostrar.Location = new System.Drawing.Point(446, 12);
            this.btn_mostrar.Name = "btn_mostrar";
            this.btn_mostrar.Size = new System.Drawing.Size(115, 32);
            this.btn_mostrar.TabIndex = 7;
            this.btn_mostrar.Text = "Mostrar Carros";
            this.btn_mostrar.UseVisualStyleBackColor = true;
            this.btn_mostrar.Click += new System.EventHandler(this.btn_mostrar_Click);
            // 
            // btn_Exportar_Excel
            // 
            this.btn_Exportar_Excel.Location = new System.Drawing.Point(199, 461);
            this.btn_Exportar_Excel.Name = "btn_Exportar_Excel";
            this.btn_Exportar_Excel.Size = new System.Drawing.Size(124, 22);
            this.btn_Exportar_Excel.TabIndex = 8;
            this.btn_Exportar_Excel.Text = "Exportar a Excel";
            this.btn_Exportar_Excel.UseVisualStyleBackColor = true;
            this.btn_Exportar_Excel.Visible = false;
            this.btn_Exportar_Excel.Click += new System.EventHandler(this.btn_Exportar_Excel_Click);
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.Location = new System.Drawing.Point(71, 461);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(122, 21);
            this.btn_cerrar.TabIndex = 9;
            this.btn_cerrar.Text = "Cerrar";
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(462, 460);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Exportar a PDF";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(329, 466);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Operadora Nº";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(407, 462);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(49, 20);
            this.textBox1.TabIndex = 12;
            // 
            // frmGps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 492);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_cerrar);
            this.Controls.Add(this.btn_Exportar_Excel);
            this.Controls.Add(this.grpbx_opciones);
            this.Controls.Add(this.gvGps);
            this.Name = "frmGps";
            this.Text = "Localización del Material Mayor";
            this.Load += new System.EventHandler(this.frmGps_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvGps)).EndInit();
            this.grpbx_opciones.ResumeLayout(false);
            this.grpbx_opciones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvGps;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
        private System.Windows.Forms.DataGridViewButtonColumn Column5;
        private System.Windows.Forms.DataGridViewButtonColumn Column6;
        private System.Windows.Forms.RadioButton rbtn_610;
        private System.Windows.Forms.RadioButton rbtn_614;
        private System.Windows.Forms.RadioButton rbtn_615;
        private System.Windows.Forms.RadioButton rbtn_63;
        private System.Windows.Forms.RadioButton rbtn_613;
        private System.Windows.Forms.RadioButton rbtn_todos;
        private System.Windows.Forms.GroupBox grpbx_opciones;
        private System.Windows.Forms.Button btn_mostrar;
        private System.Windows.Forms.Button btn_Exportar_Excel;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}