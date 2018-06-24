namespace Zeus.UIElements
{
    partial class PuestaServicio
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
            this.btnCerrar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboCompania = new System.Windows.Forms.ComboBox();
            this.textAutoriza = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkTemporal = new System.Windows.Forms.CheckBox();
            this.textNombres = new System.Windows.Forms.TextBox();
            this.listNombres = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listCarros = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.datePuestaServicio = new System.Windows.Forms.DateTimePicker();
            this.radioAlInstante = new System.Windows.Forms.RadioButton();
            this.radioProgramar = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(313, 355);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboCompania);
            this.groupBox1.Controls.Add(this.textAutoriza);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.checkTemporal);
            this.groupBox1.Controls.Add(this.textNombres);
            this.groupBox1.Controls.Add(this.listNombres);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 258);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Conductor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Compañía:";
            // 
            // comboCompania
            // 
            this.comboCompania.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCompania.FormattingEnabled = true;
            this.comboCompania.Location = new System.Drawing.Point(71, 19);
            this.comboCompania.Name = "comboCompania";
            this.comboCompania.Size = new System.Drawing.Size(175, 21);
            this.comboCompania.TabIndex = 9;
            this.comboCompania.SelectedIndexChanged += new System.EventHandler(this.comboCompania_SelectedIndexChanged);
            // 
            // textAutoriza
            // 
            this.textAutoriza.Enabled = false;
            this.textAutoriza.Location = new System.Drawing.Point(9, 219);
            this.textAutoriza.Name = "textAutoriza";
            this.textAutoriza.Size = new System.Drawing.Size(237, 21);
            this.textAutoriza.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(6, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Autorizado por:";
            // 
            // checkTemporal
            // 
            this.checkTemporal.AutoSize = true;
            this.checkTemporal.Location = new System.Drawing.Point(6, 183);
            this.checkTemporal.Name = "checkTemporal";
            this.checkTemporal.Size = new System.Drawing.Size(121, 17);
            this.checkTemporal.TabIndex = 6;
            this.checkTemporal.Text = "Conductor temporal";
            this.checkTemporal.UseVisualStyleBackColor = true;
            this.checkTemporal.CheckedChanged += new System.EventHandler(this.checkTemporal_CheckedChanged);
            // 
            // textNombres
            // 
            this.textNombres.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNombres.Location = new System.Drawing.Point(6, 46);
            this.textNombres.Name = "textNombres";
            this.textNombres.Size = new System.Drawing.Size(240, 22);
            this.textNombres.TabIndex = 4;
            this.textNombres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textNombres_KeyPress);
            this.textNombres.TextChanged += new System.EventHandler(this.textNombres_TextChanged);
            // 
            // listNombres
            // 
            this.listNombres.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listNombres.FormattingEnabled = true;
            this.listNombres.ItemHeight = 14;
            this.listNombres.Location = new System.Drawing.Point(6, 75);
            this.listNombres.Name = "listNombres";
            this.listNombres.Size = new System.Drawing.Size(240, 102);
            this.listNombres.TabIndex = 5;
            this.listNombres.SelectedIndexChanged += new System.EventHandler(this.listNombres_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listCarros);
            this.groupBox2.Location = new System.Drawing.Point(270, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(118, 258);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Carros Autorizados";
            // 
            // listCarros
            // 
            this.listCarros.FormattingEnabled = true;
            this.listCarros.Location = new System.Drawing.Point(6, 19);
            this.listCarros.Name = "listCarros";
            this.listCarros.Size = new System.Drawing.Size(106, 228);
            this.listCarros.TabIndex = 0;
            this.listCarros.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listCarros_ItemCheck);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.datePuestaServicio);
            this.groupBox3.Controls.Add(this.radioAlInstante);
            this.groupBox3.Controls.Add(this.radioProgramar);
            this.groupBox3.Location = new System.Drawing.Point(12, 276);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(376, 73);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Momento de asignación";
            // 
            // datePuestaServicio
            // 
            this.datePuestaServicio.CustomFormat = "dd/MM/yyyy HH:mm";
            this.datePuestaServicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePuestaServicio.Location = new System.Drawing.Point(237, 42);
            this.datePuestaServicio.Name = "datePuestaServicio";
            this.datePuestaServicio.Size = new System.Drawing.Size(134, 21);
            this.datePuestaServicio.TabIndex = 2;
            this.datePuestaServicio.Value = new System.DateTime(2007, 8, 10, 0, 0, 0, 0);
            // 
            // radioAlInstante
            // 
            this.radioAlInstante.AutoSize = true;
            this.radioAlInstante.Checked = true;
            this.radioAlInstante.Location = new System.Drawing.Point(6, 19);
            this.radioAlInstante.Name = "radioAlInstante";
            this.radioAlInstante.Size = new System.Drawing.Size(76, 17);
            this.radioAlInstante.TabIndex = 1;
            this.radioAlInstante.TabStop = true;
            this.radioAlInstante.Text = "Al instante";
            this.radioAlInstante.UseVisualStyleBackColor = true;
            // 
            // radioProgramar
            // 
            this.radioProgramar.AutoSize = true;
            this.radioProgramar.Location = new System.Drawing.Point(237, 19);
            this.radioProgramar.Name = "radioProgramar";
            this.radioProgramar.Size = new System.Drawing.Size(75, 17);
            this.radioProgramar.TabIndex = 0;
            this.radioProgramar.Text = "Programar";
            this.radioProgramar.UseVisualStyleBackColor = true;
            this.radioProgramar.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 355);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Ingresar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PuestaServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 390);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PuestaServicio";
            this.ShowInTaskbar = false;
            this.Text = "Puesta en Servicio de Carros";
            this.Load += new System.EventHandler(this.PuestaServicio_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textNombres;
        private System.Windows.Forms.ListBox listNombres;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox listCarros;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker datePuestaServicio;
        private System.Windows.Forms.RadioButton radioAlInstante;
        private System.Windows.Forms.RadioButton radioProgramar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textAutoriza;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkTemporal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboCompania;
    }
}