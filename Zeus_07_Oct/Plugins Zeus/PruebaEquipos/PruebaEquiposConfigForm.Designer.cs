namespace PruebaEquipos
{
    partial class PruebaEquiposConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PruebaEquiposConfigForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.clTipoCarro = new System.Windows.Forms.CheckedListBox();
            this.checkTipoCarro = new System.Windows.Forms.CheckBox();
            this.textFin = new System.Windows.Forms.TextBox();
            this.textMensaje = new System.Windows.Forms.TextBox();
            this.textSaludo = new System.Windows.Forms.TextBox();
            this.textTitulo = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textTitulo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 118);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Título";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textSaludo);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(392, 95);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Saludo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ingrese el saludo.";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textMensaje);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(12, 237);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(392, 95);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mensaje de Inicio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ingrese el mensaje de inicio.";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textFin);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(12, 338);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(392, 95);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Mensaje de Término";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(274, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ingrese el mensaje de término de la prueba de equipos.";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(12, 581);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(329, 581);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.clTipoCarro);
            this.groupBox5.Controls.Add(this.checkTipoCarro);
            this.groupBox5.Location = new System.Drawing.Point(12, 439);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(392, 136);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Filtrado de Carros";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Mostrar los siguientes tipos de carros:";
            // 
            // clTipoCarro
            // 
            this.clTipoCarro.FormattingEnabled = true;
            this.clTipoCarro.Location = new System.Drawing.Point(9, 55);
            this.clTipoCarro.MultiColumn = true;
            this.clTipoCarro.Name = "clTipoCarro";
            this.clTipoCarro.Size = new System.Drawing.Size(377, 68);
            this.clTipoCarro.TabIndex = 1;
            // 
            // checkTipoCarro
            // 
            this.checkTipoCarro.AutoSize = true;
            this.checkTipoCarro.Checked = true;
            this.checkTipoCarro.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkTipoCarro.Location = new System.Drawing.Point(6, 19);
            this.checkTipoCarro.Name = "checkTipoCarro";
            this.checkTipoCarro.Size = new System.Drawing.Size(185, 17);
            this.checkTipoCarro.TabIndex = 0;
            this.checkTipoCarro.Text = "Habilitar filtrado por tipo de carro";
            this.checkTipoCarro.UseVisualStyleBackColor = true;
            this.checkTipoCarro.CheckedChanged += new System.EventHandler(this.checkTipoCarro_CheckedChanged);
            // 
            // textFin
            // 
            this.textFin.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::PruebaEquipos.Settings.Default, "MensajeTermino", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textFin.Location = new System.Drawing.Point(6, 37);
            this.textFin.Multiline = true;
            this.textFin.Name = "textFin";
            this.textFin.Size = new System.Drawing.Size(380, 46);
            this.textFin.TabIndex = 2;
            this.textFin.Text = global::PruebaEquipos.Settings.Default.MensajeTermino;
            // 
            // textMensaje
            // 
            this.textMensaje.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::PruebaEquipos.Settings.Default, "MensajeInicio", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textMensaje.Location = new System.Drawing.Point(6, 37);
            this.textMensaje.Multiline = true;
            this.textMensaje.Name = "textMensaje";
            this.textMensaje.Size = new System.Drawing.Size(380, 46);
            this.textMensaje.TabIndex = 2;
            this.textMensaje.Text = global::PruebaEquipos.Settings.Default.MensajeInicio;
            // 
            // textSaludo
            // 
            this.textSaludo.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::PruebaEquipos.Settings.Default, "Saludo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textSaludo.Location = new System.Drawing.Point(6, 37);
            this.textSaludo.Multiline = true;
            this.textSaludo.Name = "textSaludo";
            this.textSaludo.Size = new System.Drawing.Size(380, 46);
            this.textSaludo.TabIndex = 2;
            this.textSaludo.Text = global::PruebaEquipos.Settings.Default.Saludo;
            // 
            // textTitulo
            // 
            this.textTitulo.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::PruebaEquipos.Settings.Default, "Titulo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textTitulo.Location = new System.Drawing.Point(6, 61);
            this.textTitulo.Multiline = true;
            this.textTitulo.Name = "textTitulo";
            this.textTitulo.Size = new System.Drawing.Size(380, 46);
            this.textTitulo.TabIndex = 1;
            this.textTitulo.Text = global::PruebaEquipos.Settings.Default.Titulo;
            // 
            // FormPruebaAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 616);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPruebaAdmin";
            this.ShowInTaskbar = false;
            this.Text = "Administración Prueba de Equipos";
            this.Load += new System.EventHandler(this.FormPruebaAdmin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textTitulo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textSaludo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textMensaje;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textFin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox clTipoCarro;
        private System.Windows.Forms.CheckBox checkTipoCarro;
    }
}