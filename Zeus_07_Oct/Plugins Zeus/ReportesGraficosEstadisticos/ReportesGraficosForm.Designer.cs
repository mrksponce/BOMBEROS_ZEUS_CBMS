namespace ReportesGraficosEstadisticos
{
    partial class ReportesGraficosForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listTablas = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listCampos = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listUnicos = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textDescripcion = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.btnBiblioteca = new System.Windows.Forms.Button();
            this.textSQL = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnGrafico = new System.Windows.Forms.Button();
            this.dgResultados = new System.Windows.Forms.DataGridView();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.textAño = new System.Windows.Forms.MaskedTextBox();
            this.btnVerReporte = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboMes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboTipoReporte = new System.Windows.Forms.ComboBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.dataSet1 = new System.Data.DataSet();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgResultados)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listTablas);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 133);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tablas disponibles";
            // 
            // listTablas
            // 
            this.listTablas.DisplayMember = "nombre";
            this.listTablas.FormattingEnabled = true;
            this.listTablas.Location = new System.Drawing.Point(6, 19);
            this.listTablas.Name = "listTablas";
            this.listTablas.Size = new System.Drawing.Size(188, 108);
            this.listTablas.TabIndex = 2;
            this.listTablas.ValueMember = "nombre";
            this.listTablas.SelectedIndexChanged += new System.EventHandler(this.listTablas_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listCampos);
            this.groupBox2.Location = new System.Drawing.Point(218, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 133);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Campos de la tabla seleccionada";
            // 
            // listCampos
            // 
            this.listCampos.DisplayMember = "nombre";
            this.listCampos.FormattingEnabled = true;
            this.listCampos.Location = new System.Drawing.Point(6, 19);
            this.listCampos.Name = "listCampos";
            this.listCampos.Size = new System.Drawing.Size(188, 108);
            this.listCampos.TabIndex = 3;
            this.listCampos.ValueMember = "nombre";
            this.listCampos.SelectedIndexChanged += new System.EventHandler(this.listCampos_SelectedIndexChanged);
            this.listCampos.DoubleClick += new System.EventHandler(this.listCampos_DoubleClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listUnicos);
            this.groupBox3.Location = new System.Drawing.Point(424, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 133);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Valores únicos";
            // 
            // listUnicos
            // 
            this.listUnicos.DisplayMember = "distintos";
            this.listUnicos.FormattingEnabled = true;
            this.listUnicos.Location = new System.Drawing.Point(6, 19);
            this.listUnicos.Name = "listUnicos";
            this.listUnicos.Size = new System.Drawing.Size(188, 108);
            this.listUnicos.TabIndex = 4;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textDescripcion);
            this.groupBox4.Location = new System.Drawing.Point(12, 151);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(612, 59);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Descripción del elemento seleccionado";
            // 
            // textDescripcion
            // 
            this.textDescripcion.Location = new System.Drawing.Point(6, 19);
            this.textDescripcion.Multiline = true;
            this.textDescripcion.Name = "textDescripcion";
            this.textDescripcion.ReadOnly = true;
            this.textDescripcion.Size = new System.Drawing.Size(600, 31);
            this.textDescripcion.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnAplicar);
            this.groupBox5.Controls.Add(this.btnBiblioteca);
            this.groupBox5.Controls.Add(this.textSQL);
            this.groupBox5.Location = new System.Drawing.Point(12, 216);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(612, 100);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Editor de Consultas";
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(504, 19);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(102, 35);
            this.btnAplicar.TabIndex = 2;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // btnBiblioteca
            // 
            this.btnBiblioteca.Location = new System.Drawing.Point(504, 60);
            this.btnBiblioteca.Name = "btnBiblioteca";
            this.btnBiblioteca.Size = new System.Drawing.Size(102, 34);
            this.btnBiblioteca.TabIndex = 1;
            this.btnBiblioteca.Text = "Biblioteca de Consultas";
            this.btnBiblioteca.UseVisualStyleBackColor = true;
            this.btnBiblioteca.Click += new System.EventHandler(this.btnBiblioteca_Click);
            // 
            // textSQL
            // 
            this.textSQL.Location = new System.Drawing.Point(6, 19);
            this.textSQL.Multiline = true;
            this.textSQL.Name = "textSQL";
            this.textSQL.Size = new System.Drawing.Size(492, 75);
            this.textSQL.TabIndex = 0;
            this.textSQL.Text = "SELECT [columna(s)] FROM [tabla(s)] WHERE [condicion(es)]";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnExportar);
            this.groupBox6.Controls.Add(this.btnGrafico);
            this.groupBox6.Controls.Add(this.dgResultados);
            this.groupBox6.Location = new System.Drawing.Point(12, 322);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(612, 171);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Resultados";
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(531, 49);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(75, 23);
            this.btnExportar.TabIndex = 3;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnGrafico
            // 
            this.btnGrafico.Location = new System.Drawing.Point(531, 20);
            this.btnGrafico.Name = "btnGrafico";
            this.btnGrafico.Size = new System.Drawing.Size(75, 23);
            this.btnGrafico.TabIndex = 2;
            this.btnGrafico.Text = "Gráfico";
            this.btnGrafico.UseVisualStyleBackColor = true;
            this.btnGrafico.Click += new System.EventHandler(this.btnGrafico_Click);
            // 
            // dgResultados
            // 
            this.dgResultados.AllowUserToAddRows = false;
            this.dgResultados.AllowUserToDeleteRows = false;
            this.dgResultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResultados.Location = new System.Drawing.Point(6, 20);
            this.dgResultados.Name = "dgResultados";
            this.dgResultados.ReadOnly = true;
            this.dgResultados.Size = new System.Drawing.Size(519, 145);
            this.dgResultados.TabIndex = 0;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(12, 557);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.textAño);
            this.groupBox7.Controls.Add(this.btnVerReporte);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.comboMes);
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.comboTipoReporte);
            this.groupBox7.Location = new System.Drawing.Point(12, 499);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(612, 52);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Reportes";
            // 
            // textAño
            // 
            this.textAño.Location = new System.Drawing.Point(461, 20);
            this.textAño.Mask = "9999";
            this.textAño.Name = "textAño";
            this.textAño.Size = new System.Drawing.Size(37, 21);
            this.textAño.TabIndex = 7;
            // 
            // btnVerReporte
            // 
            this.btnVerReporte.Location = new System.Drawing.Point(531, 18);
            this.btnVerReporte.Name = "btnVerReporte";
            this.btnVerReporte.Size = new System.Drawing.Size(75, 23);
            this.btnVerReporte.TabIndex = 6;
            this.btnVerReporte.Text = "Ver";
            this.btnVerReporte.UseVisualStyleBackColor = true;
            this.btnVerReporte.Click += new System.EventHandler(this.btnVerReporte_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(425, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Año:";
            // 
            // comboMes
            // 
            this.comboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMes.FormattingEnabled = true;
            this.comboMes.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.comboMes.Location = new System.Drawing.Point(324, 20);
            this.comboMes.Name = "comboMes";
            this.comboMes.Size = new System.Drawing.Size(95, 21);
            this.comboMes.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mes:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Reporte:";
            // 
            // comboTipoReporte
            // 
            this.comboTipoReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipoReporte.FormattingEnabled = true;
            this.comboTipoReporte.Items.AddRange(new object[] {
            "Frecuencias de llamados por Acto",
            "Frecuencias de llamados por Llamado",
            "Actos de Servicio por Compañía",
            "Llamados por Compañía",
            "Actos de Servicio por Comuna",
            "Llamados por Comuna"});
            this.comboTipoReporte.Location = new System.Drawing.Point(62, 20);
            this.comboTipoReporte.Name = "comboTipoReporte";
            this.comboTipoReporte.Size = new System.Drawing.Size(220, 21);
            this.comboTipoReporte.TabIndex = 0;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xls";
            this.saveFileDialog1.FileName = "Nueva Consulta.xls";
            this.saveFileDialog1.Filter = "Hoja de cálculo de Excel 95-2003|*.xls|Hoja de cálculo de Excel 2007|*.xlsx|Todos" +
                " los archivos|*.*";
            this.saveFileDialog1.Title = "Exportar datos de consulta";
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // ReportesGraficosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 592);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportesGraficosForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reportes / Gráficos Estadísticos";
            this.Load += new System.EventHandler(this.ReportesGraficosForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgResultados)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox listTablas;
        private System.Windows.Forms.ListBox listCampos;
        private System.Windows.Forms.ListBox listUnicos;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textDescripcion;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnBiblioteca;
        private System.Windows.Forms.TextBox textSQL;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnGrafico;
        private System.Windows.Forms.DataGridView dgResultados;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnVerReporte;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboMes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboTipoReporte;
        private System.Windows.Forms.MaskedTextBox textAño;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Data.DataSet dataSet1;
    }
}