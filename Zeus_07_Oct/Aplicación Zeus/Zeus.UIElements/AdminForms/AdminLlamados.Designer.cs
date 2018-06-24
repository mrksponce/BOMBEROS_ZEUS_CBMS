namespace Zeus.UIElements.AdminForms
{
    partial class AdminLlamados
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.checkRestr = new System.Windows.Forms.CheckBox();
            this.checkIncendio = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numericMaxB = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.textDescripcion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textClave = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxB)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(187, 273);
            this.groupBox1.Text = "Claves";
            // 
            // listActuales
            // 
            this.listActuales.DisplayMember = "desc";
            this.listActuales.Size = new System.Drawing.Size(175, 225);
            this.listActuales.ValueMember = "id_llamado";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(205, 262);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(286, 262);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(367, 262);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(491, 262);
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "desc";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(205, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(361, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.ValueMember = "clave";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.checkRestr);
            this.groupBox2.Controls.Add(this.checkIncendio);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.numericMaxB);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textDescripcion);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textClave);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textCodigo);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(205, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(361, 186);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Descripción del llamado";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(357, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "* Para agregar una nueva clave principal, ingrese un código menor a 100";
            // 
            // checkRestr
            // 
            this.checkRestr.AutoSize = true;
            this.checkRestr.Location = new System.Drawing.Point(9, 130);
            this.checkRestr.Name = "checkRestr";
            this.checkRestr.Size = new System.Drawing.Size(139, 17);
            this.checkRestr.TabIndex = 10;
            this.checkRestr.Text = "Restringida en Incendio";
            this.checkRestr.UseVisualStyleBackColor = true;
            // 
            // checkIncendio
            // 
            this.checkIncendio.AutoSize = true;
            this.checkIncendio.Location = new System.Drawing.Point(9, 107);
            this.checkIncendio.Name = "checkIncendio";
            this.checkIncendio.Size = new System.Drawing.Size(112, 17);
            this.checkIncendio.TabIndex = 9;
            this.checkIncendio.Text = "Clave de Incendio";
            this.checkIncendio.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(205, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "(0 = sin restricción)";
            // 
            // numericMaxB
            // 
            this.numericMaxB.Location = new System.Drawing.Point(163, 78);
            this.numericMaxB.Name = "numericMaxB";
            this.numericMaxB.Size = new System.Drawing.Size(36, 21);
            this.numericMaxB.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cantidad máxima de carros B:";
            // 
            // textDescripcion
            // 
            this.textDescripcion.Location = new System.Drawing.Point(109, 45);
            this.textDescripcion.Name = "textDescripcion";
            this.textDescripcion.Size = new System.Drawing.Size(246, 21);
            this.textDescripcion.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Descripción:";
            // 
            // textClave
            // 
            this.textClave.Location = new System.Drawing.Point(275, 19);
            this.textClave.Name = "textClave";
            this.textClave.Size = new System.Drawing.Size(80, 21);
            this.textClave.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Clave:";
            // 
            // textCodigo
            // 
            this.textCodigo.Location = new System.Drawing.Point(109, 19);
            this.textCodigo.Name = "textCodigo";
            this.textCodigo.Size = new System.Drawing.Size(80, 21);
            this.textCodigo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código de llamado:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(205, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Clave Principal:";
            // 
            // AdminLlamados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 297);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "AdminLlamados";
            this.Text = "Administración Claves de Llamados";
            this.Load += new System.EventHandler(this.AdminLlamados_Load);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.comboBox1, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnActualizar, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkRestr;
        private System.Windows.Forms.CheckBox checkIncendio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericMaxB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textDescripcion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textClave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}