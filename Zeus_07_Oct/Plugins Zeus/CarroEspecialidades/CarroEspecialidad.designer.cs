namespace CarroEspecialidades
{
    partial class CarroEspecialidad
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboClaves = new System.Windows.Forms.ComboBox();
            this.comboExpediente = new System.Windows.Forms.ComboBox();
            this.comboEspecialidad = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listCarros = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 397);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(159, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Utilizar Punto Geocodificado";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // comboClaves
            // 
            this.comboClaves.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboClaves.FormattingEnabled = true;
            this.comboClaves.Location = new System.Drawing.Point(12, 29);
            this.comboClaves.Name = "comboClaves";
            this.comboClaves.Size = new System.Drawing.Size(324, 21);
            this.comboClaves.TabIndex = 1;
            this.comboClaves.SelectedIndexChanged += new System.EventHandler(this.comboClaves_SelectedIndexChanged);
            // 
            // comboExpediente
            // 
            this.comboExpediente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboExpediente.FormattingEnabled = true;
            this.comboExpediente.Location = new System.Drawing.Point(12, 69);
            this.comboExpediente.Name = "comboExpediente";
            this.comboExpediente.Size = new System.Drawing.Size(324, 21);
            this.comboExpediente.TabIndex = 2;
            // 
            // comboEspecialidad
            // 
            this.comboEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEspecialidad.FormattingEnabled = true;
            this.comboEspecialidad.Items.AddRange(new object[] {
            "Haz-Mat",
            "Mecánica",
            "Bomba",
            "Rescate",
            "Puesto Aire",
            "Rescate Urbano",
            "Cisternas Z",
            "Aljibe"});
            this.comboEspecialidad.Location = new System.Drawing.Point(12, 109);
            this.comboEspecialidad.Name = "comboEspecialidad";
            this.comboEspecialidad.Size = new System.Drawing.Size(324, 21);
            this.comboEspecialidad.TabIndex = 3;
            this.comboEspecialidad.SelectedIndexChanged += new System.EventHandler(this.comboEspecialidad_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Clave de Llamado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Esquina de Referencia:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tipo de Especialidad:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Prioridad de Solicitud:";
            // 
            // listCarros
            // 
            this.listCarros.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listCarros.FullRowSelect = true;
            this.listCarros.HideSelection = false;
            this.listCarros.Location = new System.Drawing.Point(12, 174);
            this.listCarros.MultiSelect = false;
            this.listCarros.Name = "listCarros";
            this.listCarros.Size = new System.Drawing.Size(324, 97);
            this.listCarros.TabIndex = 8;
            this.listCarros.UseCompatibleStateImageBehavior = false;
            this.listCarros.View = System.Windows.Forms.View.Details;
            this.listCarros.SelectedIndexChanged += new System.EventHandler(this.listCarros_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Prioridad";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Contacto";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDetalle);
            this.groupBox1.Location = new System.Drawing.Point(12, 277);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 74);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // lblDetalle
            // 
            this.lblDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDetalle.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalle.ForeColor = System.Drawing.Color.Red;
            this.lblDetalle.Location = new System.Drawing.Point(3, 17);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(318, 54);
            this.lblDetalle.TabIndex = 0;
            this.lblDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(137, 375);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 10;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // CarroEspecialidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 406);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listCarros);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboEspecialidad);
            this.Controls.Add(this.comboExpediente);
            this.Controls.Add(this.comboClaves);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CarroEspecialidad";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Solicitud Carros de Especialidades";
            this.Load += new System.EventHandler(this.CarroEspecialidad_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox comboClaves;
        private System.Windows.Forms.ComboBox comboExpediente;
        private System.Windows.Forms.ComboBox comboEspecialidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView listCarros;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}