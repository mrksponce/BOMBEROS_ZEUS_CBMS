namespace Zeus.PluginGeocodificacion.Forms
{
    partial class Direcciones
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
            this.textPrimeraCalle = new System.Windows.Forms.TextBox();
            this.checkAltura = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textAltura = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCantidadResultados = new System.Windows.Forms.Label();
            this.textEsquina = new System.Windows.Forms.TextBox();
            this.listEsquinas = new System.Windows.Forms.ListBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.listCalles = new System.Windows.Forms.ListBox();
            this.checkComuna = new System.Windows.Forms.CheckBox();
            this.comboComuna = new System.Windows.Forms.ComboBox();
            this.checkRM = new System.Windows.Forms.CheckBox();
            this.btnMostrarCoincidencias = new Zeus.UIElements.BlinkButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de Calle:";
            // 
            // textPrimeraCalle
            // 
            this.textPrimeraCalle.Location = new System.Drawing.Point(12, 75);
            this.textPrimeraCalle.Name = "textPrimeraCalle";
            this.textPrimeraCalle.Size = new System.Drawing.Size(215, 21);
            this.textPrimeraCalle.TabIndex = 0;
            this.textPrimeraCalle.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textPrimeraCalle_KeyUp);
            // 
            // checkAltura
            // 
            this.checkAltura.AutoSize = true;
            this.checkAltura.Location = new System.Drawing.Point(12, 192);
            this.checkAltura.Name = "checkAltura";
            this.checkAltura.Size = new System.Drawing.Size(98, 17);
            this.checkAltura.TabIndex = 2;
            this.checkAltura.Text = "Ingresar altura";
            this.checkAltura.UseVisualStyleBackColor = true;
            this.checkAltura.CheckedChanged += new System.EventHandler(this.checkAltura_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(12, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Altura:";
            // 
            // textAltura
            // 
            this.textAltura.Enabled = false;
            this.textAltura.Location = new System.Drawing.Point(56, 219);
            this.textAltura.Name = "textAltura";
            this.textAltura.Size = new System.Drawing.Size(171, 21);
            this.textAltura.TabIndex = 3;
            this.textAltura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textAltura_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nombre de Esquina:";
            // 
            // lblCantidadResultados
            // 
            this.lblCantidadResultados.Location = new System.Drawing.Point(190, 254);
            this.lblCantidadResultados.Name = "lblCantidadResultados";
            this.lblCantidadResultados.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCantidadResultados.Size = new System.Drawing.Size(37, 13);
            this.lblCantidadResultados.TabIndex = 6;
            this.lblCantidadResultados.Text = "0";
            this.lblCantidadResultados.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textEsquina
            // 
            this.textEsquina.Location = new System.Drawing.Point(12, 270);
            this.textEsquina.Name = "textEsquina";
            this.textEsquina.Size = new System.Drawing.Size(215, 21);
            this.textEsquina.TabIndex = 4;
            this.textEsquina.TextChanged += new System.EventHandler(this.textEsquina_TextChanged);
            // 
            // listEsquinas
            // 
            this.listEsquinas.FormattingEnabled = true;
            this.listEsquinas.Location = new System.Drawing.Point(12, 296);
            this.listEsquinas.Name = "listEsquinas";
            this.listEsquinas.Size = new System.Drawing.Size(215, 82);
            this.listEsquinas.TabIndex = 5;
            this.listEsquinas.SelectedIndexChanged += new System.EventHandler(this.listEsquinas_SelectedIndexChanged);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(12, 427);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(215, 23);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // listCalles
            // 
            this.listCalles.FormattingEnabled = true;
            this.listCalles.Location = new System.Drawing.Point(12, 103);
            this.listCalles.Name = "listCalles";
            this.listCalles.Size = new System.Drawing.Size(215, 82);
            this.listCalles.TabIndex = 1;
            this.listCalles.SelectedIndexChanged += new System.EventHandler(this.listCalles_SelectedIndexChanged);
            // 
            // checkComuna
            // 
            this.checkComuna.AutoSize = true;
            this.checkComuna.Location = new System.Drawing.Point(12, 12);
            this.checkComuna.Name = "checkComuna";
            this.checkComuna.Size = new System.Drawing.Size(123, 17);
            this.checkComuna.TabIndex = 8;
            this.checkComuna.Text = "Restringir a Comuna";
            this.checkComuna.UseVisualStyleBackColor = true;
            this.checkComuna.CheckedChanged += new System.EventHandler(this.checkComuna_CheckedChanged);
            // 
            // comboComuna
            // 
            this.comboComuna.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboComuna.Enabled = false;
            this.comboComuna.FormattingEnabled = true;
            this.comboComuna.Location = new System.Drawing.Point(12, 35);
            this.comboComuna.Name = "comboComuna";
            this.comboComuna.Size = new System.Drawing.Size(212, 21);
            this.comboComuna.TabIndex = 10;
            // 
            // checkRM
            // 
            this.checkRM.AutoSize = true;
            this.checkRM.Location = new System.Drawing.Point(175, 12);
            this.checkRM.Name = "checkRM";
            this.checkRM.Size = new System.Drawing.Size(49, 17);
            this.checkRM.TabIndex = 9;
            this.checkRM.Text = "R.M.";
            this.checkRM.UseVisualStyleBackColor = true;
            this.checkRM.CheckedChanged += new System.EventHandler(this.checkRM_CheckedChanged);
            // 
            // btnMostrarCoincidencias
            // 
            this.btnMostrarCoincidencias.BackColor = System.Drawing.SystemColors.Control;
            this.btnMostrarCoincidencias.Blink = false;
            this.btnMostrarCoincidencias.Location = new System.Drawing.Point(12, 398);
            this.btnMostrarCoincidencias.Name = "btnMostrarCoincidencias";
            this.btnMostrarCoincidencias.Size = new System.Drawing.Size(215, 23);
            this.btnMostrarCoincidencias.TabIndex = 11;
            this.btnMostrarCoincidencias.Text = "Mostrar Coincidencias";
            this.btnMostrarCoincidencias.UseVisualStyleBackColor = false;
            this.btnMostrarCoincidencias.Click += new System.EventHandler(this.btnMostrarCoincidencias_Click);
            // 
            // Direcciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 472);
            this.Controls.Add(this.btnMostrarCoincidencias);
            this.Controls.Add(this.checkRM);
            this.Controls.Add(this.comboComuna);
            this.Controls.Add(this.checkComuna);
            this.Controls.Add(this.listCalles);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.listEsquinas);
            this.Controls.Add(this.textEsquina);
            this.Controls.Add(this.lblCantidadResultados);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textAltura);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkAltura);
            this.Controls.Add(this.textPrimeraCalle);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Direcciones";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Geocodificador de Direcciones";
            this.Load += new System.EventHandler(this.Direcciones_Load);
            this.VisibleChanged += new System.EventHandler(this.Direcciones_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textPrimeraCalle;
        private System.Windows.Forms.CheckBox checkAltura;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textAltura;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCantidadResultados;
        private System.Windows.Forms.TextBox textEsquina;
        private System.Windows.Forms.ListBox listEsquinas;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.ListBox listCalles;
        private System.Windows.Forms.CheckBox checkComuna;
        private System.Windows.Forms.ComboBox comboComuna;
        private System.Windows.Forms.CheckBox checkRM;
        private Zeus.UIElements.BlinkButton btnMostrarCoincidencias;
    }
}