namespace Zeus.UIElements.AdminForms
{
    partial class AdminConductor
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
            this.radioCuartelero = new System.Windows.Forms.RadioButton();
            this.radioVoluntario = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkCompania = new System.Windows.Forms.CheckBox();
            this.textVoluntarios = new System.Windows.Forms.TextBox();
            this.listNombres = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listConductores = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dateLicencia = new System.Windows.Forms.DateTimePicker();
            this.textCodigo = new System.Windows.Forms.TextBox();
            this.textTipo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listCarros = new System.Windows.Forms.CheckedListBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.textBusqueda = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioCuartelero
            // 
            this.radioCuartelero.AutoSize = true;
            this.radioCuartelero.Checked = true;
            this.radioCuartelero.Location = new System.Drawing.Point(6, 19);
            this.radioCuartelero.Name = "radioCuartelero";
            this.radioCuartelero.Size = new System.Drawing.Size(76, 17);
            this.radioCuartelero.TabIndex = 0;
            this.radioCuartelero.TabStop = true;
            this.radioCuartelero.Text = "Cuartelero";
            this.radioCuartelero.UseVisualStyleBackColor = true;
            this.radioCuartelero.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // radioVoluntario
            // 
            this.radioVoluntario.AutoSize = true;
            this.radioVoluntario.Location = new System.Drawing.Point(173, 19);
            this.radioVoluntario.Name = "radioVoluntario";
            this.radioVoluntario.Size = new System.Drawing.Size(73, 17);
            this.radioVoluntario.TabIndex = 1;
            this.radioVoluntario.Text = "Voluntario";
            this.radioVoluntario.UseVisualStyleBackColor = true;
            this.radioVoluntario.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.checkCompania);
            this.groupBox1.Controls.Add(this.textVoluntarios);
            this.groupBox1.Controls.Add(this.listNombres);
            this.groupBox1.Controls.Add(this.radioCuartelero);
            this.groupBox1.Controls.Add(this.radioVoluntario);
            this.groupBox1.Location = new System.Drawing.Point(246, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 209);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de Conductor";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(124, 50);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // checkCompania
            // 
            this.checkCompania.AutoSize = true;
            this.checkCompania.Enabled = false;
            this.checkCompania.Location = new System.Drawing.Point(6, 52);
            this.checkCompania.Name = "checkCompania";
            this.checkCompania.Size = new System.Drawing.Size(73, 17);
            this.checkCompania.TabIndex = 4;
            this.checkCompania.Text = "Compañía";
            this.checkCompania.UseVisualStyleBackColor = true;
            this.checkCompania.CheckedChanged += new System.EventHandler(this.checkCompania_CheckedChanged);
            // 
            // textVoluntarios
            // 
            this.textVoluntarios.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textVoluntarios.Location = new System.Drawing.Point(6, 87);
            this.textVoluntarios.Name = "textVoluntarios";
            this.textVoluntarios.Size = new System.Drawing.Size(239, 22);
            this.textVoluntarios.TabIndex = 2;
            this.textVoluntarios.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textVoluntarios_KeyPress);
            this.textVoluntarios.TextChanged += new System.EventHandler(this.textVoluntarios_TextChanged);
            // 
            // listNombres
            // 
            this.listNombres.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listNombres.FormattingEnabled = true;
            this.listNombres.ItemHeight = 14;
            this.listNombres.Location = new System.Drawing.Point(6, 115);
            this.listNombres.Name = "listNombres";
            this.listNombres.Size = new System.Drawing.Size(239, 88);
            this.listNombres.TabIndex = 3;
            this.listNombres.SelectedIndexChanged += new System.EventHandler(this.listVoluntarios_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBusqueda);
            this.groupBox2.Controls.Add(this.listConductores);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 359);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Conductores existentes";
            // 
            // listConductores
            // 
            this.listConductores.FormattingEnabled = true;
            this.listConductores.Location = new System.Drawing.Point(6, 45);
            this.listConductores.Name = "listConductores";
            this.listConductores.Size = new System.Drawing.Size(216, 303);
            this.listConductores.TabIndex = 0;
            this.listConductores.SelectedIndexChanged += new System.EventHandler(this.listConductores_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dateLicencia);
            this.groupBox3.Controls.Add(this.textCodigo);
            this.groupBox3.Controls.Add(this.textTipo);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(246, 227);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(251, 144);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Información";
            // 
            // dateLicencia
            // 
            this.dateLicencia.CustomFormat = "dd/MM/yyyy";
            this.dateLicencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateLicencia.Location = new System.Drawing.Point(118, 64);
            this.dateLicencia.Name = "dateLicencia";
            this.dateLicencia.Size = new System.Drawing.Size(127, 21);
            this.dateLicencia.TabIndex = 5;
            // 
            // textCodigo
            // 
            this.textCodigo.Location = new System.Drawing.Point(118, 111);
            this.textCodigo.Name = "textCodigo";
            this.textCodigo.Size = new System.Drawing.Size(127, 21);
            this.textCodigo.TabIndex = 4;
            // 
            // textTipo
            // 
            this.textTipo.Location = new System.Drawing.Point(118, 19);
            this.textTipo.Name = "textTipo";
            this.textTipo.Size = new System.Drawing.Size(127, 21);
            this.textTipo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Código conductor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Licencia vence:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo Licencia:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listCarros);
            this.groupBox4.Location = new System.Drawing.Point(503, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 359);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Carros que puede conducir";
            // 
            // listCarros
            // 
            this.listCarros.FormattingEnabled = true;
            this.listCarros.Location = new System.Drawing.Point(6, 19);
            this.listCarros.Name = "listCarros";
            this.listCarros.Size = new System.Drawing.Size(188, 334);
            this.listCarros.TabIndex = 0;
            this.listCarros.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listCarros_ItemCheck);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(246, 377);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 6;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(327, 377);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 7;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(408, 377);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(628, 377);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 9;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // textBusqueda
            // 
            this.textBusqueda.Location = new System.Drawing.Point(6, 20);
            this.textBusqueda.Name = "textBusqueda";
            this.textBusqueda.Size = new System.Drawing.Size(216, 21);
            this.textBusqueda.TabIndex = 1;
            this.textBusqueda.TextChanged += new System.EventHandler(this.textBusqueda_TextChanged);
            // 
            // AdminConductor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 412);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminConductor";
            this.ShowInTaskbar = false;
            this.Text = "Administración de Conductores";
            this.Load += new System.EventHandler(this.CrearConductor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radioCuartelero;
        private System.Windows.Forms.RadioButton radioVoluntario;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textVoluntarios;
        private System.Windows.Forms.ListBox listNombres;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listConductores;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textCodigo;
        private System.Windows.Forms.TextBox textTipo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateLicencia;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckedListBox listCarros;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox checkCompania;
        private System.Windows.Forms.TextBox textBusqueda;
    }
}