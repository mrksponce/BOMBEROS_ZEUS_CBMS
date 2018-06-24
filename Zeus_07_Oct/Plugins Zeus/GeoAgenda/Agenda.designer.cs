namespace GeoAgenda
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
            this.listSolicitado = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.btnLugar2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDeshacer = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listEmpresas
            // 
            this.listEmpresas.FormattingEnabled = true;
            this.listEmpresas.Location = new System.Drawing.Point(248, 340);
            this.listEmpresas.Name = "listEmpresas";
            this.listEmpresas.Size = new System.Drawing.Size(206, 95);
            this.listEmpresas.TabIndex = 18;
            this.listEmpresas.SelectedIndexChanged += new System.EventHandler(this.listEmpresas_SelectedIndexChanged);
            // 
            // listSubcat
            // 
            this.listSubcat.FormattingEnabled = true;
            this.listSubcat.Location = new System.Drawing.Point(248, 236);
            this.listSubcat.Name = "listSubcat";
            this.listSubcat.Size = new System.Drawing.Size(206, 82);
            this.listSubcat.TabIndex = 17;
            this.listSubcat.SelectedIndexChanged += new System.EventHandler(this.listSubcat_SelectedIndexChanged);
            // 
            // listClaves
            // 
            this.listClaves.FormattingEnabled = true;
            this.listClaves.Location = new System.Drawing.Point(11, 236);
            this.listClaves.Name = "listClaves";
            this.listClaves.Size = new System.Drawing.Size(206, 199);
            this.listClaves.TabIndex = 14;
            this.listClaves.SelectedIndexChanged += new System.EventHandler(this.listApoyos_SelectedIndexChanged);
            // 
            // btnCerrar
            // 
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCerrar.Location = new System.Drawing.Point(352, 532);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(101, 23);
            this.btnCerrar.TabIndex = 23;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // btnLugar
            // 
            this.btnLugar.Location = new System.Drawing.Point(6, 135);
            this.btnLugar.Name = "btnLugar";
            this.btnLugar.Size = new System.Drawing.Size(101, 23);
            this.btnLugar.TabIndex = 22;
            this.btnLugar.Text = "En el Lugar";
            this.btnLugar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLugar.UseVisualStyleBackColor = true;
            this.btnLugar.Click += new System.EventHandler(this.btnLugar_Click);
            // 
            // btnSolicita
            // 
            this.btnSolicita.Location = new System.Drawing.Point(18, 532);
            this.btnSolicita.Name = "btnSolicita";
            this.btnSolicita.Size = new System.Drawing.Size(101, 23);
            this.btnSolicita.TabIndex = 21;
            this.btnSolicita.Text = "Se Solicita";
            this.btnSolicita.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSolicita.UseVisualStyleBackColor = true;
            this.btnSolicita.Click += new System.EventHandler(this.btnSolicita_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textInformacion);
            this.groupBox1.Location = new System.Drawing.Point(11, 441);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(443, 79);
            this.groupBox1.TabIndex = 20;
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
            this.label4.Location = new System.Drawing.Point(245, 324);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Empresa / Institución:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(245, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Subcategoría:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Claves Solicitud Apoyo:";
            // 
            // comboExpedientes
            // 
            this.comboExpedientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboExpedientes.FormattingEnabled = true;
            this.comboExpedientes.Location = new System.Drawing.Point(12, 26);
            this.comboExpedientes.Name = "comboExpedientes";
            this.comboExpedientes.Size = new System.Drawing.Size(442, 21);
            this.comboExpedientes.TabIndex = 13;
            this.comboExpedientes.SelectedIndexChanged += new System.EventHandler(this.comboExpedientes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Expediente Activo:";
            // 
            // listSolicitado
            // 
            this.listSolicitado.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listSolicitado.FullRowSelect = true;
            this.listSolicitado.Location = new System.Drawing.Point(6, 19);
            this.listSolicitado.MultiSelect = false;
            this.listSolicitado.Name = "listSolicitado";
            this.listSolicitado.Size = new System.Drawing.Size(432, 110);
            this.listSolicitado.TabIndex = 25;
            this.listSolicitado.UseCompatibleStateImageBehavior = false;
            this.listSolicitado.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Apoyo Solicitado";
            this.columnHeader1.Width = 349;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Estado";
            this.columnHeader2.Width = 79;
            // 
            // btnLugar2
            // 
            this.btnLugar2.Location = new System.Drawing.Point(188, 532);
            this.btnLugar2.Name = "btnLugar2";
            this.btnLugar2.Size = new System.Drawing.Size(101, 23);
            this.btnLugar2.TabIndex = 26;
            this.btnLugar2.Text = "En el Lugar";
            this.btnLugar2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLugar2.UseVisualStyleBackColor = true;
            this.btnLugar2.Click += new System.EventHandler(this.btnLugar2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDeshacer);
            this.groupBox2.Controls.Add(this.listSolicitado);
            this.groupBox2.Controls.Add(this.btnLugar);
            this.groupBox2.Location = new System.Drawing.Point(12, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(444, 164);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Apoyo Solicitado";
            // 
            // btnDeshacer
            // 
            this.btnDeshacer.Location = new System.Drawing.Point(323, 135);
            this.btnDeshacer.Name = "btnDeshacer";
            this.btnDeshacer.Size = new System.Drawing.Size(115, 23);
            this.btnDeshacer.TabIndex = 26;
            this.btnDeshacer.Text = "Deshacer Solicitud";
            this.btnDeshacer.UseVisualStyleBackColor = true;
            this.btnDeshacer.Click += new System.EventHandler(this.btnDeshacer_Click);
            // 
            // Agenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 568);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnLugar2);
            this.Controls.Add(this.listEmpresas);
            this.Controls.Add(this.listSubcat);
            this.Controls.Add(this.listClaves);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnSolicita);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboExpedientes);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(100, 100);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Agenda";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "GeoAgenda";
            this.Load += new System.EventHandler(this.Agenda_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listEmpresas;
        private System.Windows.Forms.ListBox listSubcat;
        private System.Windows.Forms.ListBox listClaves;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnLugar;
        private System.Windows.Forms.Button btnSolicita;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textInformacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboExpedientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listSolicitado;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnLugar2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDeshacer;

    }
}