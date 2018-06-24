namespace Zeus.PluginGeocodificacion.Forms
{
    partial class Agenda
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
            this.tabAgenda = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listEmpresas = new System.Windows.Forms.ListBox();
            this.listSubcat = new System.Windows.Forms.ListBox();
            this.listClaves = new System.Windows.Forms.ListBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnLugar = new System.Windows.Forms.Button();
            this.btnSolicita = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textInformacion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboExpedientes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listEmpresasAd = new System.Windows.Forms.ListBox();
            this.listSubcatAd = new System.Windows.Forms.ListBox();
            this.listClavesAd = new System.Windows.Forms.ListBox();
            this.btnCerrar2 = new System.Windows.Forms.Button();
            this.btnEliminar3 = new System.Windows.Forms.Button();
            this.btnModif3 = new System.Windows.Forms.Button();
            this.btnNueva3 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnEliminar2 = new System.Windows.Forms.Button();
            this.btnModif2 = new System.Windows.Forms.Button();
            this.btnNueva2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnEliminar1 = new System.Windows.Forms.Button();
            this.btnModif1 = new System.Windows.Forms.Button();
            this.btnNueva1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tabAgenda.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabAgenda
            // 
            this.tabAgenda.Controls.Add(this.tabPage1);
            this.tabAgenda.Controls.Add(this.tabPage2);
            this.tabAgenda.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabAgenda.Location = new System.Drawing.Point(0, 12);
            this.tabAgenda.Multiline = true;
            this.tabAgenda.Name = "tabAgenda";
            this.tabAgenda.SelectedIndex = 0;
            this.tabAgenda.Size = new System.Drawing.Size(466, 461);
            this.tabAgenda.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabAgenda.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listEmpresas);
            this.tabPage1.Controls.Add(this.listSubcat);
            this.tabPage1.Controls.Add(this.listClaves);
            this.tabPage1.Controls.Add(this.btnCerrar);
            this.tabPage1.Controls.Add(this.btnLugar);
            this.tabPage1.Controls.Add(this.btnSolicita);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.comboExpedientes);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(458, 435);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Agenda";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listEmpresas
            // 
            this.listEmpresas.FormattingEnabled = true;
            this.listEmpresas.Location = new System.Drawing.Point(244, 204);
            this.listEmpresas.Name = "listEmpresas";
            this.listEmpresas.Size = new System.Drawing.Size(206, 95);
            this.listEmpresas.TabIndex = 6;
            this.listEmpresas.SelectedIndexChanged += new System.EventHandler(this.listEmpresas_SelectedIndexChanged);
            // 
            // listSubcat
            // 
            this.listSubcat.FormattingEnabled = true;
            this.listSubcat.Location = new System.Drawing.Point(244, 100);
            this.listSubcat.Name = "listSubcat";
            this.listSubcat.Size = new System.Drawing.Size(206, 82);
            this.listSubcat.TabIndex = 5;
            this.listSubcat.SelectedIndexChanged += new System.EventHandler(this.listSubcat_SelectedIndexChanged);
            // 
            // listClaves
            // 
            this.listClaves.FormattingEnabled = true;
            this.listClaves.Location = new System.Drawing.Point(7, 100);
            this.listClaves.Name = "listClaves";
            this.listClaves.Size = new System.Drawing.Size(206, 199);
            this.listClaves.TabIndex = 2;
            this.listClaves.SelectedIndexChanged += new System.EventHandler(this.listApoyos_SelectedIndexChanged);
            // 
            // btnCerrar
            // 
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCerrar.Location = new System.Drawing.Point(343, 396);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(101, 23);
            this.btnCerrar.TabIndex = 11;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // btnLugar
            // 
            this.btnLugar.Location = new System.Drawing.Point(178, 396);
            this.btnLugar.Name = "btnLugar";
            this.btnLugar.Size = new System.Drawing.Size(101, 23);
            this.btnLugar.TabIndex = 10;
            this.btnLugar.Text = "En el Lugar";
            this.btnLugar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLugar.UseVisualStyleBackColor = true;
            this.btnLugar.Click += new System.EventHandler(this.btnLugar_Click);
            // 
            // btnSolicita
            // 
            this.btnSolicita.Location = new System.Drawing.Point(14, 396);
            this.btnSolicita.Name = "btnSolicita";
            this.btnSolicita.Size = new System.Drawing.Size(101, 23);
            this.btnSolicita.TabIndex = 9;
            this.btnSolicita.Text = "Se Solicita";
            this.btnSolicita.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSolicita.UseVisualStyleBackColor = true;
            this.btnSolicita.Click += new System.EventHandler(this.btnSolicita_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textInformacion);
            this.groupBox1.Location = new System.Drawing.Point(7, 305);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(443, 79);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información de Contacto";
            // 
            // textInformacion
            // 
            this.textInformacion.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textInformacion.ForeColor = System.Drawing.Color.Red;
            this.textInformacion.Location = new System.Drawing.Point(7, 20);
            this.textInformacion.Multiline = true;
            this.textInformacion.Name = "textInformacion";
            this.textInformacion.ReadOnly = true;
            this.textInformacion.Size = new System.Drawing.Size(430, 53);
            this.textInformacion.TabIndex = 0;
            this.textInformacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(241, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Empresa / Institución:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(241, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Subcategoría:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Claves Solicitud Apoyo:";
            // 
            // comboExpedientes
            // 
            this.comboExpedientes.FormattingEnabled = true;
            this.comboExpedientes.Location = new System.Drawing.Point(9, 37);
            this.comboExpedientes.Name = "comboExpedientes";
            this.comboExpedientes.Size = new System.Drawing.Size(441, 21);
            this.comboExpedientes.TabIndex = 1;
            this.comboExpedientes.SelectedIndexChanged += new System.EventHandler(this.comboExpedientes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Expediente Activo:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listEmpresasAd);
            this.tabPage2.Controls.Add(this.listSubcatAd);
            this.tabPage2.Controls.Add(this.listClavesAd);
            this.tabPage2.Controls.Add(this.btnCerrar2);
            this.tabPage2.Controls.Add(this.btnEliminar3);
            this.tabPage2.Controls.Add(this.btnModif3);
            this.tabPage2.Controls.Add(this.btnNueva3);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.btnEliminar2);
            this.tabPage2.Controls.Add(this.btnModif2);
            this.tabPage2.Controls.Add(this.btnNueva2);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.btnEliminar1);
            this.tabPage2.Controls.Add(this.btnModif1);
            this.tabPage2.Controls.Add(this.btnNueva1);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(458, 435);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Administración";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listEmpresasAd
            // 
            this.listEmpresasAd.FormattingEnabled = true;
            this.listEmpresasAd.Location = new System.Drawing.Point(4, 261);
            this.listEmpresasAd.Name = "listEmpresasAd";
            this.listEmpresasAd.Size = new System.Drawing.Size(359, 82);
            this.listEmpresasAd.TabIndex = 18;
            // 
            // listSubcatAd
            // 
            this.listSubcatAd.FormattingEnabled = true;
            this.listSubcatAd.Location = new System.Drawing.Point(4, 149);
            this.listSubcatAd.Name = "listSubcatAd";
            this.listSubcatAd.Size = new System.Drawing.Size(359, 82);
            this.listSubcatAd.TabIndex = 17;
            this.listSubcatAd.SelectedIndexChanged += new System.EventHandler(this.comboSubcat_SelectedIndexChanged);
            // 
            // listClavesAd
            // 
            this.listClavesAd.FormattingEnabled = true;
            this.listClavesAd.Location = new System.Drawing.Point(4, 37);
            this.listClavesAd.Name = "listClavesAd";
            this.listClavesAd.Size = new System.Drawing.Size(359, 82);
            this.listClavesAd.TabIndex = 16;
            this.listClavesAd.SelectedIndexChanged += new System.EventHandler(this.comboClaves_SelectedIndexChanged);
            // 
            // btnCerrar2
            // 
            this.btnCerrar2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCerrar2.Location = new System.Drawing.Point(343, 396);
            this.btnCerrar2.Name = "btnCerrar2";
            this.btnCerrar2.Size = new System.Drawing.Size(101, 23);
            this.btnCerrar2.TabIndex = 15;
            this.btnCerrar2.Text = "Cerrar";
            this.btnCerrar2.UseVisualStyleBackColor = true;
            // 
            // btnEliminar3
            // 
            this.btnEliminar3.Location = new System.Drawing.Point(375, 320);
            this.btnEliminar3.Name = "btnEliminar3";
            this.btnEliminar3.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar3.TabIndex = 14;
            this.btnEliminar3.Text = "Eliminar";
            this.btnEliminar3.UseVisualStyleBackColor = true;
            this.btnEliminar3.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModif3
            // 
            this.btnModif3.Location = new System.Drawing.Point(375, 290);
            this.btnModif3.Name = "btnModif3";
            this.btnModif3.Size = new System.Drawing.Size(75, 23);
            this.btnModif3.TabIndex = 13;
            this.btnModif3.Text = "Modificar...";
            this.btnModif3.UseVisualStyleBackColor = true;
            this.btnModif3.Click += new System.EventHandler(this.btnModif_Click);
            // 
            // btnNueva3
            // 
            this.btnNueva3.Location = new System.Drawing.Point(375, 261);
            this.btnNueva3.Name = "btnNueva3";
            this.btnNueva3.Size = new System.Drawing.Size(75, 23);
            this.btnNueva3.TabIndex = 12;
            this.btnNueva3.Text = "Nueva...";
            this.btnNueva3.UseVisualStyleBackColor = true;
            this.btnNueva3.Click += new System.EventHandler(this.btnNueva_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 244);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Empresa / Institución:";
            // 
            // btnEliminar2
            // 
            this.btnEliminar2.Location = new System.Drawing.Point(375, 208);
            this.btnEliminar2.Name = "btnEliminar2";
            this.btnEliminar2.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar2.TabIndex = 9;
            this.btnEliminar2.Text = "Eliminar";
            this.btnEliminar2.UseVisualStyleBackColor = true;
            this.btnEliminar2.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModif2
            // 
            this.btnModif2.Location = new System.Drawing.Point(375, 178);
            this.btnModif2.Name = "btnModif2";
            this.btnModif2.Size = new System.Drawing.Size(75, 23);
            this.btnModif2.TabIndex = 8;
            this.btnModif2.Text = "Modificar...";
            this.btnModif2.UseVisualStyleBackColor = true;
            this.btnModif2.Click += new System.EventHandler(this.btnModif_Click);
            // 
            // btnNueva2
            // 
            this.btnNueva2.Location = new System.Drawing.Point(375, 149);
            this.btnNueva2.Name = "btnNueva2";
            this.btnNueva2.Size = new System.Drawing.Size(75, 23);
            this.btnNueva2.TabIndex = 7;
            this.btnNueva2.Text = "Nueva...";
            this.btnNueva2.UseVisualStyleBackColor = true;
            this.btnNueva2.Click += new System.EventHandler(this.btnNueva_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Subcategoría:";
            // 
            // btnEliminar1
            // 
            this.btnEliminar1.Location = new System.Drawing.Point(375, 96);
            this.btnEliminar1.Name = "btnEliminar1";
            this.btnEliminar1.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar1.TabIndex = 4;
            this.btnEliminar1.Text = "Eliminar";
            this.btnEliminar1.UseVisualStyleBackColor = true;
            this.btnEliminar1.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModif1
            // 
            this.btnModif1.Location = new System.Drawing.Point(375, 66);
            this.btnModif1.Name = "btnModif1";
            this.btnModif1.Size = new System.Drawing.Size(75, 23);
            this.btnModif1.TabIndex = 3;
            this.btnModif1.Text = "Modificar...";
            this.btnModif1.UseVisualStyleBackColor = true;
            this.btnModif1.Click += new System.EventHandler(this.btnModif_Click);
            // 
            // btnNueva1
            // 
            this.btnNueva1.Location = new System.Drawing.Point(375, 37);
            this.btnNueva1.Name = "btnNueva1";
            this.btnNueva1.Size = new System.Drawing.Size(75, 23);
            this.btnNueva1.TabIndex = 2;
            this.btnNueva1.Text = "Nueva...";
            this.btnNueva1.UseVisualStyleBackColor = true;
            this.btnNueva1.Click += new System.EventHandler(this.btnNueva_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Claves Solicitud Apoyo:";
            // 
            // Agenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 473);
            this.Controls.Add(this.tabAgenda);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(100, 100);
            this.MaximizeBox = false;
            this.Name = "Agenda";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GEO Agenda";
            this.tabAgenda.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabAgenda;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox listSubcat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listClaves;
        private System.Windows.Forms.ComboBox comboExpedientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textInformacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listEmpresas;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnLugar;
        private System.Windows.Forms.Button btnSolicita;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEliminar2;
        private System.Windows.Forms.Button btnModif2;
        private System.Windows.Forms.Button btnNueva2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnEliminar1;
        private System.Windows.Forms.Button btnModif1;
        private System.Windows.Forms.Button btnNueva1;
        private System.Windows.Forms.Button btnCerrar2;
        private System.Windows.Forms.Button btnEliminar3;
        private System.Windows.Forms.Button btnModif3;
        private System.Windows.Forms.Button btnNueva3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox listClavesAd;
        private System.Windows.Forms.ListBox listSubcatAd;
        private System.Windows.Forms.ListBox listEmpresasAd;
    }
}