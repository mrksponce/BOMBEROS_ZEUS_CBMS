namespace ReportesGraficosEstadisticos
{
    partial class BibliotecaConsultasForm
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
            this.btnElimCat = new System.Windows.Forms.Button();
            this.listCategorias = new System.Windows.Forms.ListBox();
            this.btnModifCat = new System.Windows.Forms.Button();
            this.btnNuevaCat = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listConsultas = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnEliminarCons = new System.Windows.Forms.Button();
            this.btnActualizarCons = new System.Windows.Forms.Button();
            this.btnNuevaCons = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textConsulta = new System.Windows.Forms.TextBox();
            this.textDescripcion = new System.Windows.Forms.TextBox();
            this.textAutor = new System.Windows.Forms.TextBox();
            this.textTitulo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnElimCat);
            this.groupBox1.Controls.Add(this.listCategorias);
            this.groupBox1.Controls.Add(this.btnModifCat);
            this.groupBox1.Controls.Add(this.btnNuevaCat);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 152);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Categorías";
            // 
            // btnElimCat
            // 
            this.btnElimCat.Location = new System.Drawing.Point(168, 120);
            this.btnElimCat.Name = "btnElimCat";
            this.btnElimCat.Size = new System.Drawing.Size(75, 23);
            this.btnElimCat.TabIndex = 3;
            this.btnElimCat.Text = "Eliminar";
            this.btnElimCat.UseVisualStyleBackColor = true;
            this.btnElimCat.Click += new System.EventHandler(this.btnElimCat_Click);
            // 
            // listCategorias
            // 
            this.listCategorias.DisplayMember = "nombre";
            this.listCategorias.FormattingEnabled = true;
            this.listCategorias.Location = new System.Drawing.Point(6, 19);
            this.listCategorias.Name = "listCategorias";
            this.listCategorias.Size = new System.Drawing.Size(237, 95);
            this.listCategorias.TabIndex = 1;
            this.listCategorias.ValueMember = "id_categoria";
            this.listCategorias.SelectedIndexChanged += new System.EventHandler(this.listCategorias_SelectedIndexChanged);
            // 
            // btnModifCat
            // 
            this.btnModifCat.Location = new System.Drawing.Point(87, 120);
            this.btnModifCat.Name = "btnModifCat";
            this.btnModifCat.Size = new System.Drawing.Size(75, 23);
            this.btnModifCat.TabIndex = 2;
            this.btnModifCat.Text = "Modificar";
            this.btnModifCat.UseVisualStyleBackColor = true;
            this.btnModifCat.Click += new System.EventHandler(this.btnModifCat_Click);
            // 
            // btnNuevaCat
            // 
            this.btnNuevaCat.Location = new System.Drawing.Point(6, 120);
            this.btnNuevaCat.Name = "btnNuevaCat";
            this.btnNuevaCat.Size = new System.Drawing.Size(75, 23);
            this.btnNuevaCat.TabIndex = 1;
            this.btnNuevaCat.Text = "Nueva";
            this.btnNuevaCat.UseVisualStyleBackColor = true;
            this.btnNuevaCat.Click += new System.EventHandler(this.btnNuevaCat_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listConsultas);
            this.groupBox2.Location = new System.Drawing.Point(268, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(429, 152);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Consultas";
            // 
            // listConsultas
            // 
            this.listConsultas.DisplayMember = "titulo";
            this.listConsultas.FormattingEnabled = true;
            this.listConsultas.Location = new System.Drawing.Point(6, 19);
            this.listConsultas.Name = "listConsultas";
            this.listConsultas.Size = new System.Drawing.Size(417, 121);
            this.listConsultas.TabIndex = 0;
            this.listConsultas.ValueMember = "id_consulta";
            this.listConsultas.SelectedIndexChanged += new System.EventHandler(this.listConsultas_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnEliminarCons);
            this.groupBox3.Controls.Add(this.btnActualizarCons);
            this.groupBox3.Controls.Add(this.btnNuevaCons);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.textConsulta);
            this.groupBox3.Controls.Add(this.textDescripcion);
            this.groupBox3.Controls.Add(this.textAutor);
            this.groupBox3.Controls.Add(this.textTitulo);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(12, 170);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(685, 225);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Detalle";
            // 
            // btnEliminarCons
            // 
            this.btnEliminarCons.Location = new System.Drawing.Point(604, 192);
            this.btnEliminarCons.Name = "btnEliminarCons";
            this.btnEliminarCons.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarCons.TabIndex = 10;
            this.btnEliminarCons.Text = "Eliminar";
            this.btnEliminarCons.UseVisualStyleBackColor = true;
            this.btnEliminarCons.Click += new System.EventHandler(this.btnEliminarCons_Click);
            // 
            // btnActualizarCons
            // 
            this.btnActualizarCons.Location = new System.Drawing.Point(523, 192);
            this.btnActualizarCons.Name = "btnActualizarCons";
            this.btnActualizarCons.Size = new System.Drawing.Size(75, 23);
            this.btnActualizarCons.TabIndex = 9;
            this.btnActualizarCons.Text = "Actualizar";
            this.btnActualizarCons.UseVisualStyleBackColor = true;
            this.btnActualizarCons.Click += new System.EventHandler(this.btnActualizarCons_Click);
            // 
            // btnNuevaCons
            // 
            this.btnNuevaCons.Location = new System.Drawing.Point(442, 192);
            this.btnNuevaCons.Name = "btnNuevaCons";
            this.btnNuevaCons.Size = new System.Drawing.Size(75, 23);
            this.btnNuevaCons.TabIndex = 8;
            this.btnNuevaCons.Text = "Insertar";
            this.btnNuevaCons.UseVisualStyleBackColor = true;
            this.btnNuevaCons.Click += new System.EventHandler(this.btnNuevaCons_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Consulta SQL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Descripción";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Autor";
            // 
            // textConsulta
            // 
            this.textConsulta.Location = new System.Drawing.Point(87, 122);
            this.textConsulta.Multiline = true;
            this.textConsulta.Name = "textConsulta";
            this.textConsulta.Size = new System.Drawing.Size(592, 64);
            this.textConsulta.TabIndex = 4;
            // 
            // textDescripcion
            // 
            this.textDescripcion.Location = new System.Drawing.Point(87, 71);
            this.textDescripcion.Multiline = true;
            this.textDescripcion.Name = "textDescripcion";
            this.textDescripcion.Size = new System.Drawing.Size(592, 45);
            this.textDescripcion.TabIndex = 3;
            // 
            // textAutor
            // 
            this.textAutor.Location = new System.Drawing.Point(87, 45);
            this.textAutor.Name = "textAutor";
            this.textAutor.Size = new System.Drawing.Size(592, 21);
            this.textAutor.TabIndex = 2;
            // 
            // textTitulo
            // 
            this.textTitulo.Location = new System.Drawing.Point(87, 19);
            this.textTitulo.Name = "textTitulo";
            this.textTitulo.Size = new System.Drawing.Size(592, 21);
            this.textTitulo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Título";
            // 
            // btnExportar
            // 
            this.btnExportar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnExportar.Location = new System.Drawing.Point(12, 401);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(75, 23);
            this.btnExportar.TabIndex = 3;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.Location = new System.Drawing.Point(622, 401);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // BibliotecaConsultasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 432);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BibliotecaConsultasForm";
            this.ShowInTaskbar = false;
            this.Text = "Biblioteca de Consultas";
            this.Load += new System.EventHandler(this.BibliotecaConsultasForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnElimCat;
        private System.Windows.Forms.ListBox listCategorias;
        private System.Windows.Forms.Button btnModifCat;
        private System.Windows.Forms.Button btnNuevaCat;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listConsultas;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textAutor;
        private System.Windows.Forms.TextBox textTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEliminarCons;
        private System.Windows.Forms.Button btnActualizarCons;
        private System.Windows.Forms.Button btnNuevaCons;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textConsulta;
        private System.Windows.Forms.TextBox textDescripcion;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnCerrar;
    }
}