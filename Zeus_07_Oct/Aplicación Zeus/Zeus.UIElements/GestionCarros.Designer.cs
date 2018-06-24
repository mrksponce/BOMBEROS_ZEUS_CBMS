namespace Zeus.UIElements
{
    partial class GestionCarros
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboClave = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboCarro = new System.Windows.Forms.ComboBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.radio08 = new System.Windows.Forms.RadioButton();
            this.radio09 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.comboCoordenada = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.radioDisp09 = new System.Windows.Forms.RadioButton();
            this.radioDisp08 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.listDisp = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clave:";
            // 
            // comboClave
            // 
            this.comboClave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboClave.FormattingEnabled = true;
            this.comboClave.Items.AddRange(new object[] {
            "6-13: Trámite de Compañía",
            "6-14: Cargar Combustible",
            "6-15: Se dirige a Servicio de Salud"});
            this.comboClave.Location = new System.Drawing.Point(6, 47);
            this.comboClave.Name = "comboClave";
            this.comboClave.Size = new System.Drawing.Size(257, 21);
            this.comboClave.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Material Mayor:";
            // 
            // comboCarro
            // 
            this.comboCarro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCarro.FormattingEnabled = true;
            this.comboCarro.Location = new System.Drawing.Point(6, 116);
            this.comboCarro.Name = "comboCarro";
            this.comboCarro.Size = new System.Drawing.Size(257, 21);
            this.comboCarro.TabIndex = 3;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(6, 196);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 4;
            this.btnConfirmar.Text = "Despachar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(18, 308);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Disponibilidad:";
            // 
            // radio08
            // 
            this.radio08.AutoSize = true;
            this.radio08.BackColor = System.Drawing.Color.Salmon;
            this.radio08.Checked = true;
            this.radio08.Location = new System.Drawing.Point(6, 160);
            this.radio08.Name = "radio08";
            this.radio08.Size = new System.Drawing.Size(41, 17);
            this.radio08.TabIndex = 7;
            this.radio08.TabStop = true;
            this.radio08.Text = "0-8";
            this.radio08.UseVisualStyleBackColor = false;
            // 
            // radio09
            // 
            this.radio09.AutoSize = true;
            this.radio09.BackColor = System.Drawing.Color.LightGreen;
            this.radio09.Location = new System.Drawing.Point(219, 160);
            this.radio09.Name = "radio09";
            this.radio09.Size = new System.Drawing.Size(41, 17);
            this.radio09.TabIndex = 8;
            this.radio09.Text = "0-9";
            this.radio09.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboCoordenada);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.radio09);
            this.groupBox1.Controls.Add(this.btnConfirmar);
            this.groupBox1.Controls.Add(this.comboClave);
            this.groupBox1.Controls.Add(this.radio08);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboCarro);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 274);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Despacho";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(137, 240);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(123, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "Asignar 6-15 habitual";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 240);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Asignar 6-14 habitual";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Dirección:";
            this.label6.Visible = false;
            // 
            // comboCoordenada
            // 
            this.comboCoordenada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCoordenada.FormattingEnabled = true;
            this.comboCoordenada.Location = new System.Drawing.Point(6, 74);
            this.comboCoordenada.Name = "comboCoordenada";
            this.comboCoordenada.Size = new System.Drawing.Size(257, 21);
            this.comboCoordenada.TabIndex = 10;
            this.comboCoordenada.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnModificar);
            this.groupBox2.Controls.Add(this.radioDisp09);
            this.groupBox2.Controls.Add(this.radioDisp08);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.listDisp);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(283, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(129, 274);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Disponibilidad";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(5, 244);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(118, 23);
            this.btnModificar.TabIndex = 14;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // radioDisp09
            // 
            this.radioDisp09.AutoSize = true;
            this.radioDisp09.BackColor = System.Drawing.Color.LightGreen;
            this.radioDisp09.Location = new System.Drawing.Point(81, 217);
            this.radioDisp09.Name = "radioDisp09";
            this.radioDisp09.Size = new System.Drawing.Size(41, 17);
            this.radioDisp09.TabIndex = 13;
            this.radioDisp09.Text = "0-9";
            this.radioDisp09.UseVisualStyleBackColor = false;
            // 
            // radioDisp08
            // 
            this.radioDisp08.AutoSize = true;
            this.radioDisp08.BackColor = System.Drawing.Color.Salmon;
            this.radioDisp08.Checked = true;
            this.radioDisp08.Location = new System.Drawing.Point(6, 217);
            this.radioDisp08.Name = "radioDisp08";
            this.radioDisp08.Size = new System.Drawing.Size(41, 17);
            this.radioDisp08.TabIndex = 12;
            this.radioDisp08.TabStop = true;
            this.radioDisp08.Text = "6-2";
            this.radioDisp08.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Estado:";
            // 
            // listDisp
            // 
            this.listDisp.FormattingEnabled = true;
            this.listDisp.Location = new System.Drawing.Point(6, 32);
            this.listDisp.Name = "listDisp";
            this.listDisp.Size = new System.Drawing.Size(117, 160);
            this.listDisp.TabIndex = 10;
            this.listDisp.SelectedIndexChanged += new System.EventHandler(this.listDisp_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Material Mayor:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(283, 294);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 37);
            this.button1.TabIndex = 11;
            this.button1.Text = "0-11 Cubrir Cuartel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GestionCarros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 343);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCerrar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GestionCarros";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestión de Carros";
            this.Load += new System.EventHandler(this.GestionCarros_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboClave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboCarro;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radio08;
        private System.Windows.Forms.RadioButton radio09;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.RadioButton radioDisp09;
        private System.Windows.Forms.RadioButton radioDisp08;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listDisp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboCoordenada;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}