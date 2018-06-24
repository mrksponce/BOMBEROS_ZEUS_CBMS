namespace DespachoHerramientasEquipos
{
    partial class AdminDespachoHerramientasEquiposForm
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
            this.btnModificarHerramienta = new System.Windows.Forms.Button();
            this.btnEliminarHerramienta = new System.Windows.Forms.Button();
            this.btnAgregarHerramienta = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnModificarSubcategoria = new System.Windows.Forms.Button();
            this.btnModificarCategoria = new System.Windows.Forms.Button();
            this.btnEliminarSubcategoria = new System.Windows.Forms.Button();
            this.btnEliminarCategoria = new System.Windows.Forms.Button();
            this.btnAgregarCategoria = new System.Windows.Forms.Button();
            this.btnAgregarSubcategoria = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgCantidad = new System.Windows.Forms.DataGridView();
            this.colCarros = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActualizar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnEliminarCantidad = new System.Windows.Forms.Button();
            this.btnAgregarCantidad = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboArea = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.reorderPrioridad = new Zeus.UIElements.ReorderListBox();
            this.listSubcategorias = new Zeus.UIElements.DataListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.listCategorias = new Zeus.UIElements.DataListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.listHerramientas = new Zeus.UIElements.DataListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCantidad)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnModificarHerramienta);
            this.groupBox1.Controls.Add(this.listHerramientas);
            this.groupBox1.Controls.Add(this.btnEliminarHerramienta);
            this.groupBox1.Controls.Add(this.btnAgregarHerramienta);
            this.groupBox1.Location = new System.Drawing.Point(230, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 179);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Herramientas";
            // 
            // btnModificarHerramienta
            // 
            this.btnModificarHerramienta.Enabled = false;
            this.btnModificarHerramienta.Location = new System.Drawing.Point(75, 145);
            this.btnModificarHerramienta.Name = "btnModificarHerramienta";
            this.btnModificarHerramienta.Size = new System.Drawing.Size(63, 23);
            this.btnModificarHerramienta.TabIndex = 11;
            this.btnModificarHerramienta.Text = "Modificar";
            this.btnModificarHerramienta.UseVisualStyleBackColor = true;
            this.btnModificarHerramienta.Click += new System.EventHandler(this.btnModificarHerramienta_Click);
            // 
            // btnEliminarHerramienta
            // 
            this.btnEliminarHerramienta.Enabled = false;
            this.btnEliminarHerramienta.Location = new System.Drawing.Point(144, 145);
            this.btnEliminarHerramienta.Name = "btnEliminarHerramienta";
            this.btnEliminarHerramienta.Size = new System.Drawing.Size(63, 23);
            this.btnEliminarHerramienta.TabIndex = 9;
            this.btnEliminarHerramienta.Text = "Eliminar";
            this.btnEliminarHerramienta.UseVisualStyleBackColor = true;
            this.btnEliminarHerramienta.Click += new System.EventHandler(this.btnEliminarHerramienta_Click);
            // 
            // btnAgregarHerramienta
            // 
            this.btnAgregarHerramienta.Enabled = false;
            this.btnAgregarHerramienta.Location = new System.Drawing.Point(6, 145);
            this.btnAgregarHerramienta.Name = "btnAgregarHerramienta";
            this.btnAgregarHerramienta.Size = new System.Drawing.Size(63, 23);
            this.btnAgregarHerramienta.TabIndex = 9;
            this.btnAgregarHerramienta.Text = "Agregar";
            this.btnAgregarHerramienta.UseVisualStyleBackColor = true;
            this.btnAgregarHerramienta.Click += new System.EventHandler(this.btnAgregarHerramienta_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnModificarSubcategoria);
            this.groupBox2.Controls.Add(this.btnModificarCategoria);
            this.groupBox2.Controls.Add(this.btnEliminarSubcategoria);
            this.groupBox2.Controls.Add(this.btnEliminarCategoria);
            this.groupBox2.Controls.Add(this.btnAgregarCategoria);
            this.groupBox2.Controls.Add(this.btnAgregarSubcategoria);
            this.groupBox2.Controls.Add(this.listSubcategorias);
            this.groupBox2.Controls.Add(this.listCategorias);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(212, 355);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Categorías y Subcategorías";
            // 
            // btnModificarSubcategoria
            // 
            this.btnModificarSubcategoria.Enabled = false;
            this.btnModificarSubcategoria.Location = new System.Drawing.Point(75, 325);
            this.btnModificarSubcategoria.Name = "btnModificarSubcategoria";
            this.btnModificarSubcategoria.Size = new System.Drawing.Size(63, 23);
            this.btnModificarSubcategoria.TabIndex = 10;
            this.btnModificarSubcategoria.Text = "Modificar";
            this.btnModificarSubcategoria.UseVisualStyleBackColor = true;
            this.btnModificarSubcategoria.Click += new System.EventHandler(this.btnModificarSubcategoria_Click);
            // 
            // btnModificarCategoria
            // 
            this.btnModificarCategoria.Enabled = false;
            this.btnModificarCategoria.Location = new System.Drawing.Point(75, 145);
            this.btnModificarCategoria.Name = "btnModificarCategoria";
            this.btnModificarCategoria.Size = new System.Drawing.Size(63, 23);
            this.btnModificarCategoria.TabIndex = 9;
            this.btnModificarCategoria.Text = "Modificar";
            this.btnModificarCategoria.UseVisualStyleBackColor = true;
            this.btnModificarCategoria.Click += new System.EventHandler(this.btnModificarCategoria_Click);
            // 
            // btnEliminarSubcategoria
            // 
            this.btnEliminarSubcategoria.Enabled = false;
            this.btnEliminarSubcategoria.Location = new System.Drawing.Point(143, 325);
            this.btnEliminarSubcategoria.Name = "btnEliminarSubcategoria";
            this.btnEliminarSubcategoria.Size = new System.Drawing.Size(63, 23);
            this.btnEliminarSubcategoria.TabIndex = 8;
            this.btnEliminarSubcategoria.Text = "Eliminar";
            this.btnEliminarSubcategoria.UseVisualStyleBackColor = true;
            this.btnEliminarSubcategoria.Click += new System.EventHandler(this.btnEliminarSubcategoria_Click);
            // 
            // btnEliminarCategoria
            // 
            this.btnEliminarCategoria.Enabled = false;
            this.btnEliminarCategoria.Location = new System.Drawing.Point(144, 145);
            this.btnEliminarCategoria.Name = "btnEliminarCategoria";
            this.btnEliminarCategoria.Size = new System.Drawing.Size(63, 23);
            this.btnEliminarCategoria.TabIndex = 7;
            this.btnEliminarCategoria.Text = "Eliminar";
            this.btnEliminarCategoria.UseVisualStyleBackColor = true;
            this.btnEliminarCategoria.Click += new System.EventHandler(this.btnEliminarCategoria_Click);
            // 
            // btnAgregarCategoria
            // 
            this.btnAgregarCategoria.Location = new System.Drawing.Point(6, 145);
            this.btnAgregarCategoria.Name = "btnAgregarCategoria";
            this.btnAgregarCategoria.Size = new System.Drawing.Size(63, 23);
            this.btnAgregarCategoria.TabIndex = 6;
            this.btnAgregarCategoria.Text = "Agregar";
            this.btnAgregarCategoria.UseVisualStyleBackColor = true;
            this.btnAgregarCategoria.Click += new System.EventHandler(this.btnAgregarCategoria_Click);
            // 
            // btnAgregarSubcategoria
            // 
            this.btnAgregarSubcategoria.Enabled = false;
            this.btnAgregarSubcategoria.Location = new System.Drawing.Point(6, 325);
            this.btnAgregarSubcategoria.Name = "btnAgregarSubcategoria";
            this.btnAgregarSubcategoria.Size = new System.Drawing.Size(63, 23);
            this.btnAgregarSubcategoria.TabIndex = 5;
            this.btnAgregarSubcategoria.Text = "Agregar";
            this.btnAgregarSubcategoria.UseVisualStyleBackColor = true;
            this.btnAgregarSubcategoria.Click += new System.EventHandler(this.btnAgregarSubcategoria_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgCantidad);
            this.groupBox3.Controls.Add(this.btnEliminarCantidad);
            this.groupBox3.Controls.Add(this.btnAgregarCantidad);
            this.groupBox3.Location = new System.Drawing.Point(230, 197);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(417, 170);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cantidades";
            // 
            // dgCantidad
            // 
            this.dgCantidad.AllowUserToAddRows = false;
            this.dgCantidad.AllowUserToDeleteRows = false;
            this.dgCantidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCantidad.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCarros,
            this.colId,
            this.colCantidad,
            this.colActualizar});
            this.dgCantidad.Location = new System.Drawing.Point(6, 19);
            this.dgCantidad.MultiSelect = false;
            this.dgCantidad.Name = "dgCantidad";
            this.dgCantidad.RowHeadersVisible = false;
            this.dgCantidad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCantidad.Size = new System.Drawing.Size(405, 115);
            this.dgCantidad.TabIndex = 12;
            this.dgCantidad.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgCantidad_CellValidating);
            this.dgCantidad.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCantidad_CellClick);
            // 
            // colCarros
            // 
            this.colCarros.HeaderText = "Carro";
            this.colCarros.Name = "colCarros";
            this.colCarros.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCarros.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colId
            // 
            this.colId.HeaderText = "colId";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colCantidad
            // 
            this.colCantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            // 
            // colActualizar
            // 
            this.colActualizar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colActualizar.HeaderText = "";
            this.colActualizar.Name = "colActualizar";
            this.colActualizar.Text = "Actualizar";
            this.colActualizar.UseColumnTextForButtonValue = true;
            // 
            // btnEliminarCantidad
            // 
            this.btnEliminarCantidad.Enabled = false;
            this.btnEliminarCantidad.Location = new System.Drawing.Point(348, 140);
            this.btnEliminarCantidad.Name = "btnEliminarCantidad";
            this.btnEliminarCantidad.Size = new System.Drawing.Size(63, 23);
            this.btnEliminarCantidad.TabIndex = 11;
            this.btnEliminarCantidad.Text = "Eliminar";
            this.btnEliminarCantidad.UseVisualStyleBackColor = true;
            this.btnEliminarCantidad.Click += new System.EventHandler(this.btnEliminarCantidad_Click);
            // 
            // btnAgregarCantidad
            // 
            this.btnAgregarCantidad.Enabled = false;
            this.btnAgregarCantidad.Location = new System.Drawing.Point(6, 140);
            this.btnAgregarCantidad.Name = "btnAgregarCantidad";
            this.btnAgregarCantidad.Size = new System.Drawing.Size(63, 23);
            this.btnAgregarCantidad.TabIndex = 10;
            this.btnAgregarCantidad.Text = "Agregar";
            this.btnAgregarCantidad.UseVisualStyleBackColor = true;
            this.btnAgregarCantidad.Click += new System.EventHandler(this.btnAgregarCantidad_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(572, 370);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnGuardar);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.comboArea);
            this.groupBox4.Controls.Add(this.reorderPrioridad);
            this.groupBox4.Location = new System.Drawing.Point(450, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(204, 179);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Prioridades";
            // 
            // comboArea
            // 
            this.comboArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboArea.FormattingEnabled = true;
            this.comboArea.Location = new System.Drawing.Point(62, 19);
            this.comboArea.Name = "comboArea";
            this.comboArea.Size = new System.Drawing.Size(121, 21);
            this.comboArea.TabIndex = 0;
            this.comboArea.SelectedIndexChanged += new System.EventHandler(this.comboArea_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Área:";
            // 
            // reorderPrioridad
            // 
            this.reorderPrioridad.DataSource = null;
            this.reorderPrioridad.DisplayMember = null;
            this.reorderPrioridad.Location = new System.Drawing.Point(6, 32);
            this.reorderPrioridad.Name = "reorderPrioridad";
            this.reorderPrioridad.Size = new System.Drawing.Size(177, 141);
            this.reorderPrioridad.TabIndex = 1;
            this.reorderPrioridad.ValueMember = null;
            // 
            // listSubcategorias
            // 
            this.listSubcategorias.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listSubcategorias.DataSource = null;
            this.listSubcategorias.DisplayMember = null;
            this.listSubcategorias.FullRowSelect = true;
            this.listSubcategorias.HideSelection = false;
            this.listSubcategorias.Location = new System.Drawing.Point(6, 199);
            this.listSubcategorias.MultiSelect = false;
            this.listSubcategorias.Name = "listSubcategorias";
            this.listSubcategorias.Size = new System.Drawing.Size(201, 120);
            this.listSubcategorias.TabIndex = 3;
            this.listSubcategorias.UseCompatibleStateImageBehavior = false;
            this.listSubcategorias.ValueMember = null;
            this.listSubcategorias.View = System.Windows.Forms.View.Details;
            this.listSubcategorias.SelectedIndexChanged += new System.EventHandler(this.listSubcategorias_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Subcategorías";
            this.columnHeader2.Width = 197;
            // 
            // listCategorias
            // 
            this.listCategorias.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listCategorias.DataSource = null;
            this.listCategorias.DisplayMember = null;
            this.listCategorias.FullRowSelect = true;
            this.listCategorias.HideSelection = false;
            this.listCategorias.Location = new System.Drawing.Point(6, 19);
            this.listCategorias.MultiSelect = false;
            this.listCategorias.Name = "listCategorias";
            this.listCategorias.Size = new System.Drawing.Size(201, 120);
            this.listCategorias.TabIndex = 4;
            this.listCategorias.UseCompatibleStateImageBehavior = false;
            this.listCategorias.ValueMember = null;
            this.listCategorias.View = System.Windows.Forms.View.Details;
            this.listCategorias.SelectedIndexChanged += new System.EventHandler(this.listCategorias_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Categorías";
            this.columnHeader1.Width = 197;
            // 
            // listHerramientas
            // 
            this.listHerramientas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.listHerramientas.DataSource = null;
            this.listHerramientas.DisplayMember = null;
            this.listHerramientas.FullRowSelect = true;
            this.listHerramientas.HideSelection = false;
            this.listHerramientas.Location = new System.Drawing.Point(6, 19);
            this.listHerramientas.MultiSelect = false;
            this.listHerramientas.Name = "listHerramientas";
            this.listHerramientas.Size = new System.Drawing.Size(201, 120);
            this.listHerramientas.TabIndex = 9;
            this.listHerramientas.UseCompatibleStateImageBehavior = false;
            this.listHerramientas.ValueMember = null;
            this.listHerramientas.View = System.Windows.Forms.View.Details;
            this.listHerramientas.SelectedIndexChanged += new System.EventHandler(this.listHerramientas_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Herramientas";
            this.columnHeader3.Width = 197;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(147, 150);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(55, 23);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // AdminDespachoHerramientasEquiposForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 405);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AdminDespachoHerramientasEquiposForm";
            this.Text = "Administración Despacho Herramientas y Equipos";
            this.Load += new System.EventHandler(this.AdminDespachoHerramientasEquiposForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCantidad)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Zeus.UIElements.DataListView listSubcategorias;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private Zeus.UIElements.DataListView listCategorias;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox groupBox3;
        private Zeus.UIElements.DataListView listHerramientas;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnEliminarHerramienta;
        private System.Windows.Forms.Button btnAgregarHerramienta;
        private System.Windows.Forms.Button btnEliminarSubcategoria;
        private System.Windows.Forms.Button btnEliminarCategoria;
        private System.Windows.Forms.Button btnAgregarCategoria;
        private System.Windows.Forms.Button btnAgregarSubcategoria;
        private System.Windows.Forms.Button btnEliminarCantidad;
        private System.Windows.Forms.Button btnAgregarCantidad;
        private System.Windows.Forms.DataGridView dgCantidad;
        private System.Windows.Forms.Button btnModificarCategoria;
        private System.Windows.Forms.Button btnModificarHerramienta;
        private System.Windows.Forms.Button btnModificarSubcategoria;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridViewComboBoxColumn colCarros;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewButtonColumn colActualizar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboArea;
        private Zeus.UIElements.ReorderListBox reorderPrioridad;
        private System.Windows.Forms.Button btnGuardar;
    }
}