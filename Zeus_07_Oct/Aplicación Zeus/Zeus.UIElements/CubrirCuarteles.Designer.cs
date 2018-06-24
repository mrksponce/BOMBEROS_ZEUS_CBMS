namespace Zeus.UIElements
{
    partial class CubrirCuarteles
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
            this.label1 = new System.Windows.Forms.Label();
            this.listCarros = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboCompania = new System.Windows.Forms.ComboBox();
            this.btnCubrir = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridActuales = new System.Windows.Forms.DataGridView();
            this.comboCompania_m = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_carro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_compania = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridActuales)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCubrir);
            this.groupBox1.Controls.Add(this.comboCompania);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.listCarros);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(119, 220);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cubrir Cuartel";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Material Mayor:";
            // 
            // listCarros
            // 
            this.listCarros.FormattingEnabled = true;
            this.listCarros.Location = new System.Drawing.Point(6, 33);
            this.listCarros.Name = "listCarros";
            this.listCarros.Size = new System.Drawing.Size(104, 82);
            this.listCarros.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Compañía:";
            // 
            // comboCompania
            // 
            this.comboCompania.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCompania.FormattingEnabled = true;
            this.comboCompania.Location = new System.Drawing.Point(6, 148);
            this.comboCompania.Name = "comboCompania";
            this.comboCompania.Size = new System.Drawing.Size(104, 21);
            this.comboCompania.TabIndex = 3;
            // 
            // btnCubrir
            // 
            this.btnCubrir.Location = new System.Drawing.Point(6, 175);
            this.btnCubrir.Name = "btnCubrir";
            this.btnCubrir.Size = new System.Drawing.Size(104, 23);
            this.btnCubrir.TabIndex = 4;
            this.btnCubrir.Text = "Cubrir";
            this.btnCubrir.UseVisualStyleBackColor = true;
            this.btnCubrir.Click += new System.EventHandler(this.btnCubrir_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEliminar);
            this.groupBox2.Controls.Add(this.btnModificar);
            this.groupBox2.Controls.Add(this.comboCompania_m);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dataGridActuales);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(137, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 220);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Modificar/Eliminar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Material Mayor Actual:";
            // 
            // dataGridActuales
            // 
            this.dataGridActuales.AllowUserToAddRows = false;
            this.dataGridActuales.AllowUserToDeleteRows = false;
            this.dataGridActuales.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridActuales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridActuales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombre,
            this.id_carro,
            this.id_compania});
            this.dataGridActuales.Location = new System.Drawing.Point(6, 33);
            this.dataGridActuales.MultiSelect = false;
            this.dataGridActuales.Name = "dataGridActuales";
            this.dataGridActuales.ReadOnly = true;
            this.dataGridActuales.RowHeadersVisible = false;
            this.dataGridActuales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridActuales.Size = new System.Drawing.Size(216, 82);
            this.dataGridActuales.TabIndex = 1;
            // 
            // comboCompania_m
            // 
            this.comboCompania_m.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCompania_m.FormattingEnabled = true;
            this.comboCompania_m.Location = new System.Drawing.Point(6, 148);
            this.comboCompania_m.Name = "comboCompania_m";
            this.comboCompania_m.Size = new System.Drawing.Size(92, 21);
            this.comboCompania_m.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Compañía:";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(6, 175);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(92, 23);
            this.btnModificar.TabIndex = 7;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(290, 238);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(130, 175);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(92, 23);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // nombre
            // 
            this.nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "Carro";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 59;
            // 
            // id_carro
            // 
            this.id_carro.DataPropertyName = "id_carro";
            this.id_carro.HeaderText = "id_carro";
            this.id_carro.Name = "id_carro";
            this.id_carro.ReadOnly = true;
            this.id_carro.Visible = false;
            // 
            // id_compania
            // 
            this.id_compania.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.id_compania.DataPropertyName = "id_compania";
            this.id_compania.HeaderText = "Cubre Compañía";
            this.id_compania.Name = "id_compania";
            this.id_compania.ReadOnly = true;
            // 
            // CubrirCuarteles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 269);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CubrirCuarteles";
            this.ShowInTaskbar = false;
            this.Text = "Cubrir Cuarteles";
            this.Load += new System.EventHandler(this.CubrirCuarteles_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridActuales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCubrir;
        private System.Windows.Forms.ComboBox comboCompania;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listCarros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridActuales;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.ComboBox comboCompania_m;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_carro;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_compania;
    }
}