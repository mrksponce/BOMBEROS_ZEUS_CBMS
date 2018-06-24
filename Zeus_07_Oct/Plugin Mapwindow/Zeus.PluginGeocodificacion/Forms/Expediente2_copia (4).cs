namespace Zeus.PluginGeocodificacion.Forms
{
    partial class Expediente2
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
            this.label2 = new System.Windows.Forms.Label();
            this.textHora = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.textDireccion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textEsquina = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textPoblacion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textCasa = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBlock = new System.Windows.Forms.TextBox();
            this.textTelefono = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClaves = new Zeus.UIElements.BlinkButton();
            this.textClave = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEsquina = new System.Windows.Forms.Button();
            this.checkRM = new System.Windows.Forms.CheckBox();
            this.comboComuna = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textDescripcion = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.comboCompañia = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textQuienLlama = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnRedTic = new System.Windows.Forms.Button();
            this.btnIngresar = new Zeus.UIElements.BlinkButton();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Servicio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(282, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hora:";
            // 
            // textHora
            // 
            this.textHora.Location = new System.Drawing.Point(285, 38);
            this.textHora.Name = "textHora";
            this.textHora.Size = new System.Drawing.Size(75, 21);
            this.textHora.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(374, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha:";
            // 
            // dtFecha
            // 
            this.dtFecha.Location = new System.Drawing.Point(377, 38);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(200, 21);
            this.dtFecha.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Dirección:";
            // 
            // textDireccion
            // 
            this.textDireccion.Location = new System.Drawing.Point(9, 37);
            this.textDireccion.Name = "textDireccion";
            this.textDireccion.Size = new System.Drawing.Size(293, 21);
            this.textDireccion.TabIndex = 0;
            this.textDireccion.Leave += new System.EventHandler(this.Text_lostfocus);
            this.textDireccion.Enter += new System.EventHandler(this.Text_gotfocus);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Esquina de Referencia:";
            // 
            // textEsquina
            // 
            this.textEsquina.Location = new System.Drawing.Point(9, 81);
            this.textEsquina.Name = "textEsquina";
            this.textEsquina.Size = new System.Drawing.Size(447, 21);
            this.textEsquina.TabIndex = 1;
            this.textEsquina.Leave += new System.EventHandler(this.Text_lostfocus);
            this.textEsquina.Enter += new System.EventHandler(this.Text_gotfocus);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Población/Villa:";
            // 
            // textPoblacion
            // 
            this.textPoblacion.Location = new System.Drawing.Point(9, 125);
            this.textPoblacion.Name = "textPoblacion";
            this.textPoblacion.Size = new System.Drawing.Size(137, 21);
            this.textPoblacion.TabIndex = 3;
            this.textPoblacion.Leave += new System.EventHandler(this.Text_lostfocus);
            this.textPoblacion.Enter += new System.EventHandler(this.Text_gotfocus);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(319, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Casa/Depto:";
            // 
            // textCasa
            // 
            this.textCasa.Location = new System.Drawing.Point(322, 125);
            this.textCasa.Name = "textCasa";
            this.textCasa.Size = new System.Drawing.Size(65, 21);
            this.textCasa.TabIndex = 2;
            this.textCasa.Leave += new System.EventHandler(this.Text_lostfocus);
            this.textCasa.Enter += new System.EventHandler(this.Text_gotfocus);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(198, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Block N°:";
            // 
            // textBlock
            // 
            this.textBlock.Location = new System.Drawing.Point(201, 125);
            this.textBlock.Name = "textBlock";
            this.textBlock.Size = new System.Drawing.Size(63, 21);
            this.textBlock.TabIndex = 6;
            this.textBlock.Leave += new System.EventHandler(this.Text_lostfocus);
            this.textBlock.Enter += new System.EventHandler(this.Text_gotfocus);
            // 
            // textTelefono
            // 
            this.textTelefono.Location = new System.Drawing.Point(444, 125);
            this.textTelefono.Name = "textTelefono";
            this.textTelefono.Size = new System.Drawing.Size(132, 21);
            this.textTelefono.TabIndex = 5;
            this.textTelefono.Leave += new System.EventHandler(this.Text_lostfocus);
            this.textTelefono.Enter += new System.EventHandler(this.Text_gotfocus);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(442, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Teléfono:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClaves);
            this.groupBox1.Controls.Add(this.textClave);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textHora);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtFecha);
            this.groupBox1.Location = new System.Drawing.Point(7, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(591, 73);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Básicos";
            // 
            // btnClaves
            // 
            this.btnClaves.BackColor = System.Drawing.SystemColors.Control;
            this.btnClaves.Blink = false;
            this.btnClaves.Location = new System.Drawing.Point(230, 37);
            this.btnClaves.Name = "btnClaves";
            this.btnClaves.Size = new System.Drawing.Size(36, 23);
            this.btnClaves.TabIndex = 8;
            this.btnClaves.Text = "...";
            this.btnClaves.UseVisualStyleBackColor = true;
            this.btnClaves.Click += new System.EventHandler(this.btnClaves_Click);
            // 
            // textClave
            // 
            this.textClave.Location = new System.Drawing.Point(9, 38);
            this.textClave.Name = "textClave";
            this.textClave.ReadOnly = true;
            this.textClave.Size = new System.Drawing.Size(218, 21);
            this.textClave.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btnEsquina);
            this.groupBox2.Controls.Add(this.textDireccion);
            this.groupBox2.Controls.Add(this.textEsquina);
            this.groupBox2.Controls.Add(this.textTelefono);
            this.groupBox2.Controls.Add(this.textPoblacion);
            this.groupBox2.Controls.Add(this.checkRM);
            this.groupBox2.Controls.Add(this.comboComuna);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.textBlock);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textCasa);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(7, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(591, 158);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Localización";
            // 
            // btnEsquina
            // 
            this.btnEsquina.Location = new System.Drawing.Point(502, 79);
            this.btnEsquina.Name = "btnEsquina";
            this.btnEsquina.Size = new System.Drawing.Size(75, 23);
            this.btnEsquina.TabIndex = 21;
            this.btnEsquina.Text = "Esquina...";
            this.btnEsquina.UseVisualStyleBackColor = true;
            this.btnEsquina.Click += new System.EventHandler(this.btnEsquina_Click);
            // 
            // checkRM
            // 
            this.checkRM.AutoSize = true;
            this.checkRM.Location = new System.Drawing.Point(536, 39);
            this.checkRM.Name = "checkRM";
            this.checkRM.Size = new System.Drawing.Size(41, 17);
            this.checkRM.TabIndex = 20;
            this.checkRM.Text = "RM";
            this.checkRM.UseVisualStyleBackColor = true;
            this.checkRM.CheckedChanged += new System.EventHandler(this.checkRM_CheckedChanged);
            // 
            // comboComuna
            // 
            this.comboComuna.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboComuna.FormattingEnabled = true;
            this.comboComuna.Location = new System.Drawing.Point(353, 37);
            this.comboComuna.Name = "comboComuna";
            this.comboComuna.Size = new System.Drawing.Size(174, 21);
            this.comboComuna.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(350, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Comuna:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textDescripcion);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.comboCompañia);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.textQuienLlama);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(7, 248);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(591, 131);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Finalización";
            // 
            // textDescripcion
            // 
            this.textDescripcion.Location = new System.Drawing.Point(9, 81);
            this.textDescripcion.Multiline = true;
            this.textDescripcion.Name = "textDescripcion";
            this.textDescripcion.Size = new System.Drawing.Size(568, 44);
            this.textDescripcion.TabIndex = 1;
            this.textDescripcion.Leave += new System.EventHandler(this.Text_lostfocus);
            this.textDescripcion.Enter += new System.EventHandler(this.Text_gotfocus);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 65);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "Descripción:";
            // 
            // comboCompañia
            // 
            this.comboCompañia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCompañia.FormattingEnabled = true;
            this.comboCompañia.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11"});
            this.comboCompañia.Location = new System.Drawing.Point(303, 37);
            this.comboCompañia.Name = "comboCompañia";
            this.comboCompañia.Size = new System.Drawing.Size(274, 21);
            this.comboCompañia.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(299, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(172, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Compañía Encargada de Terminar:";
            // 
            // textQuienLlama
            // 
            this.textQuienLlama.Location = new System.Drawing.Point(9, 37);
            this.textQuienLlama.Name = "textQuienLlama";
            this.textQuienLlama.Size = new System.Drawing.Size(268, 21);
            this.textQuienLlama.TabIndex = 0;
            this.textQuienLlama.Leave += new System.EventHandler(this.Text_lostfocus);
            this.textQuienLlama.Enter += new System.EventHandler(this.Text_gotfocus);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Quién Llama:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(458, 392);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(124, 23);
            this.btnCancelar.TabIndex = 24;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnRedTic
            // 
            this.btnRedTic.Location = new System.Drawing.Point(237, 392);
            this.btnRedTic.Name = "btnRedTic";
            this.btnRedTic.Size = new System.Drawing.Size(124, 23);
            this.btnRedTic.TabIndex = 23;
            this.btnRedTic.Text = "Enviar a Servidor";
            this.btnRedTic.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRedTic.UseVisualStyleBackColor = true;
            this.btnRedTic.Visible = false;
            this.btnRedTic.Click += new System.EventHandler(this.btnRedTic_Click);
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.SystemColors.Control;
            this.btnIngresar.Blink = false;
            this.btnIngresar.Location = new System.Drawing.Point(16, 392);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(124, 23);
            this.btnIngresar.TabIndex = 25;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Blue;
            this.label14.Location = new System.Drawing.Point(224, 392);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 23);
            this.label14.TabIndex = 26;
            this.label14.Text = "Area:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Blue;
            this.label15.Location = new System.Drawing.Point(281, 392);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 23);
            this.label15.TabIndex = 27;
            this.label15.Text = "label15";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(308, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(461, 79);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(37, 23);
            this.button2.TabIndex = 23;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Expediente2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(615, 435);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.btnRedTic);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Expediente2";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generador de Expedientes";
            this.Load += new System.EventHandler(this.Expediente_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textHora;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textDireccion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textEsquina;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textPoblacion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textCasa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBlock;
        private System.Windows.Forms.TextBox textTelefono;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkRM;
        private System.Windows.Forms.ComboBox comboComuna;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textQuienLlama;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textDescripcion;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboCompañia;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnRedTic;
        private System.Windows.Forms.Button btnEsquina;
        private System.Windows.Forms.TextBox textClave;
        private Zeus.UIElements.BlinkButton btnClaves;
        private Zeus.UIElements.BlinkButton btnIngresar;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}