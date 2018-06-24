namespace Zeus.UIElements.AdminForms
{
    partial class AdminLocutores
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
            this.textVoluntarios = new System.Windows.Forms.TextBox();
            this.listNombres = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listLocutores = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkAdmin = new System.Windows.Forms.CheckBox();
            this.textPass2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textPass = new System.Windows.Forms.TextBox();
            this.textUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.textBusqueda = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioCuartelero
            // 
            this.radioCuartelero.AutoSize = true;
            this.radioCuartelero.Checked = true;
            this.radioCuartelero.Location = new System.Drawing.Point(6, 19);
            this.radioCuartelero.Name = "radioCuartelero";
            this.radioCuartelero.Size = new System.Drawing.Size(75, 17);
            this.radioCuartelero.TabIndex = 0;
            this.radioCuartelero.TabStop = true;
            this.radioCuartelero.Text = "Operadora";
            this.radioCuartelero.UseVisualStyleBackColor = true;
            this.radioCuartelero.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // radioVoluntario
            // 
            this.radioVoluntario.AutoSize = true;
            this.radioVoluntario.Location = new System.Drawing.Point(249, 19);
            this.radioVoluntario.Name = "radioVoluntario";
            this.radioVoluntario.Size = new System.Drawing.Size(72, 17);
            this.radioVoluntario.TabIndex = 1;
            this.radioVoluntario.Text = "Voluntario";
            this.radioVoluntario.UseVisualStyleBackColor = true;
            this.radioVoluntario.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textVoluntarios);
            this.groupBox1.Controls.Add(this.listNombres);
            this.groupBox1.Controls.Add(this.radioCuartelero);
            this.groupBox1.Controls.Add(this.radioVoluntario);
            this.groupBox1.Location = new System.Drawing.Point(246, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 185);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de Locutor";
            // 
            // textVoluntarios
            // 
            this.textVoluntarios.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textVoluntarios.Location = new System.Drawing.Point(6, 56);
            this.textVoluntarios.Name = "textVoluntarios";
            this.textVoluntarios.Size = new System.Drawing.Size(315, 22);
            this.textVoluntarios.TabIndex = 2;
            this.textVoluntarios.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textVoluntarios_KeyPress);
            this.textVoluntarios.TextChanged += new System.EventHandler(this.textVoluntarios_TextChanged);
            // 
            // listNombres
            // 
            this.listNombres.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listNombres.FormattingEnabled = true;
            this.listNombres.ItemHeight = 14;
            this.listNombres.Location = new System.Drawing.Point(6, 84);
            this.listNombres.Name = "listNombres";
            this.listNombres.Size = new System.Drawing.Size(315, 88);
            this.listNombres.TabIndex = 3;
            this.listNombres.SelectedIndexChanged += new System.EventHandler(this.listVoluntarios_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBusqueda);
            this.groupBox2.Controls.Add(this.listLocutores);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 322);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Locutores existentes";
            // 
            // listLocutores
            // 
            this.listLocutores.FormattingEnabled = true;
            this.listLocutores.Location = new System.Drawing.Point(6, 45);
            this.listLocutores.Name = "listLocutores";
            this.listLocutores.Size = new System.Drawing.Size(216, 264);
            this.listLocutores.TabIndex = 0;
            this.listLocutores.SelectedIndexChanged += new System.EventHandler(this.listLocutores_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkAdmin);
            this.groupBox3.Controls.Add(this.textPass2);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textPass);
            this.groupBox3.Controls.Add(this.textUser);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(246, 203);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(327, 131);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Información";
            // 
            // checkAdmin
            // 
            this.checkAdmin.AutoSize = true;
            this.checkAdmin.Location = new System.Drawing.Point(118, 97);
            this.checkAdmin.Name = "checkAdmin";
            this.checkAdmin.Size = new System.Drawing.Size(154, 17);
            this.checkAdmin.TabIndex = 8;
            this.checkAdmin.Text = "Privilegios de Administrador";
            this.checkAdmin.UseVisualStyleBackColor = true;
            // 
            // textPass2
            // 
            this.textPass2.Location = new System.Drawing.Point(118, 71);
            this.textPass2.Name = "textPass2";
            this.textPass2.Size = new System.Drawing.Size(203, 20);
            this.textPass2.TabIndex = 7;
            this.textPass2.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Repita Contraseña:";
            // 
            // textPass
            // 
            this.textPass.Location = new System.Drawing.Point(118, 45);
            this.textPass.Name = "textPass";
            this.textPass.Size = new System.Drawing.Size(203, 20);
            this.textPass.TabIndex = 5;
            this.textPass.UseSystemPasswordChar = true;
            this.textPass.TextChanged += new System.EventHandler(this.textPass_TextChanged);
            // 
            // textUser
            // 
            this.textUser.Location = new System.Drawing.Point(118, 19);
            this.textUser.Name = "textUser";
            this.textUser.Size = new System.Drawing.Size(203, 20);
            this.textUser.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inicio Sesión:";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(246, 340);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 6;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(327, 340);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 7;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(408, 340);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(498, 340);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 9;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // textBusqueda
            // 
            this.textBusqueda.Location = new System.Drawing.Point(6, 19);
            this.textBusqueda.Name = "textBusqueda";
            this.textBusqueda.Size = new System.Drawing.Size(216, 20);
            this.textBusqueda.TabIndex = 1;
            this.textBusqueda.TextChanged += new System.EventHandler(this.textBusqueda_TextChanged);
            // 
            // AdminLocutores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 369);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminLocutores";
            this.ShowInTaskbar = false;
            this.Text = "Administración de Locutores";
            this.Load += new System.EventHandler(this.CrearLocutores_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radioCuartelero;
        private System.Windows.Forms.RadioButton radioVoluntario;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textVoluntarios;
        private System.Windows.Forms.ListBox listNombres;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listLocutores;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.CheckBox checkAdmin;
        private System.Windows.Forms.TextBox textPass2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textPass;
        private System.Windows.Forms.TextBox textBusqueda;
    }
}