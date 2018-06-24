namespace DespachoHerramientasEquipos
{
    partial class DespachoHerramientasEquiposForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DespachoHerramientasEquiposForm));
            this.treeCategorias = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureHerramienta = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textCantidad = new Zeus.UIElements.NumericTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboExpedientes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnPrepararDespacho = new System.Windows.Forms.Button();
            this.listHerramientas = new Zeus.UIElements.DataListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.listCarrosCantidad = new Zeus.UIElements.DataListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureHerramienta)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeCategorias
            // 
            this.treeCategorias.FullRowSelect = true;
            this.treeCategorias.ImageIndex = 0;
            this.treeCategorias.ImageList = this.imageList1;
            this.treeCategorias.Location = new System.Drawing.Point(6, 20);
            this.treeCategorias.Name = "treeCategorias";
            this.treeCategorias.SelectedImageIndex = 0;
            this.treeCategorias.Size = new System.Drawing.Size(188, 285);
            this.treeCategorias.TabIndex = 0;
            this.treeCategorias.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeCategorias_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icon-toolbox");
            this.imageList1.Images.SetKeyName(1, "icon-tools");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBuscar);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.treeCategorias);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 340);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Categorías";
            // 
            // textBuscar
            // 
            this.textBuscar.Location = new System.Drawing.Point(6, 313);
            this.textBuscar.Name = "textBuscar";
            this.textBuscar.Size = new System.Drawing.Size(127, 21);
            this.textBuscar.TabIndex = 2;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(139, 311);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(55, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureHerramienta);
            this.groupBox2.Controls.Add(this.listHerramientas);
            this.groupBox2.Controls.Add(this.listCarrosCantidad);
            this.groupBox2.Location = new System.Drawing.Point(218, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(462, 185);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Recursos Disponibles";
            // 
            // pictureHerramienta
            // 
            this.pictureHerramienta.Location = new System.Drawing.Point(291, 20);
            this.pictureHerramienta.Name = "pictureHerramienta";
            this.pictureHerramienta.Size = new System.Drawing.Size(160, 120);
            this.pictureHerramienta.TabIndex = 4;
            this.pictureHerramienta.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textCantidad);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.comboExpedientes);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btnCancelar);
            this.groupBox3.Controls.Add(this.btnPrepararDespacho);
            this.groupBox3.Location = new System.Drawing.Point(218, 203);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(462, 149);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Selección de Recursos";
            // 
            // textCantidad
            // 
            this.textCantidad.Location = new System.Drawing.Point(97, 70);
            this.textCantidad.Name = "textCantidad";
            this.textCantidad.Size = new System.Drawing.Size(100, 21);
            this.textCantidad.TabIndex = 5;
            this.textCantidad.TextChanged += new System.EventHandler(this.textCantidad_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cant. Solicitada";
            // 
            // comboExpedientes
            // 
            this.comboExpedientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboExpedientes.FormattingEnabled = true;
            this.comboExpedientes.Location = new System.Drawing.Point(97, 30);
            this.comboExpedientes.Name = "comboExpedientes";
            this.comboExpedientes.Size = new System.Drawing.Size(359, 21);
            this.comboExpedientes.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Llamado";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(327, 120);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(129, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnPrepararDespacho
            // 
            this.btnPrepararDespacho.Enabled = false;
            this.btnPrepararDespacho.Location = new System.Drawing.Point(6, 120);
            this.btnPrepararDespacho.Name = "btnPrepararDespacho";
            this.btnPrepararDespacho.Size = new System.Drawing.Size(129, 23);
            this.btnPrepararDespacho.TabIndex = 0;
            this.btnPrepararDespacho.Text = "Preparar Despacho";
            this.btnPrepararDespacho.UseVisualStyleBackColor = true;
            this.btnPrepararDespacho.Click += new System.EventHandler(this.btnPrepararDespacho_Click);
            // 
            // listHerramientas
            // 
            this.listHerramientas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.listHerramientas.DataSource = null;
            this.listHerramientas.DisplayMember = "herramienta";
            this.listHerramientas.FullRowSelect = true;
            this.listHerramientas.HideSelection = false;
            this.listHerramientas.Location = new System.Drawing.Point(6, 20);
            this.listHerramientas.MultiSelect = false;
            this.listHerramientas.Name = "listHerramientas";
            this.listHerramientas.Size = new System.Drawing.Size(121, 159);
            this.listHerramientas.TabIndex = 3;
            this.listHerramientas.UseCompatibleStateImageBehavior = false;
            this.listHerramientas.ValueMember = "id_herramienta";
            this.listHerramientas.View = System.Windows.Forms.View.Details;
            this.listHerramientas.SelectedIndexChanged += new System.EventHandler(this.listHerramientas_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Herramientas";
            this.columnHeader3.Width = 117;
            // 
            // listCarrosCantidad
            // 
            this.listCarrosCantidad.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listCarrosCantidad.DataSource = null;
            this.listCarrosCantidad.DisplayMember = "nombre";
            this.listCarrosCantidad.Location = new System.Drawing.Point(133, 20);
            this.listCarrosCantidad.Name = "listCarrosCantidad";
            this.listCarrosCantidad.Size = new System.Drawing.Size(152, 159);
            this.listCarrosCantidad.TabIndex = 2;
            this.listCarrosCantidad.UseCompatibleStateImageBehavior = false;
            this.listCarrosCantidad.ValueMember = "cantidad";
            this.listCarrosCantidad.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Carro";
            this.columnHeader1.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Tag = "cantidad";
            this.columnHeader2.Text = "Cantidad";
            this.columnHeader2.Width = 78;
            // 
            // DespachoHerramientasEquiposForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 364);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DespachoHerramientasEquiposForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Despacho de Herramientas y Equipos";
            this.Load += new System.EventHandler(this.DespachoHerramientasEquiposForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureHerramienta)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeCategorias;
        private Zeus.UIElements.DataListView listCarrosCantidad;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Zeus.UIElements.DataListView listHerramientas;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnPrepararDespacho;
        private System.Windows.Forms.PictureBox pictureHerramienta;
        private System.Windows.Forms.ComboBox comboExpedientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private Zeus.UIElements.NumericTextBox textCantidad;
        private System.Windows.Forms.Label label2;

    }
}