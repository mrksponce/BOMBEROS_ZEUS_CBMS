namespace Zeus.UIElements.OtrosEventosForms
{
    partial class VoluntarioAccidentado
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
            this.groupVoluntarioAccidentado = new System.Windows.Forms.GroupBox();
            this.btnIngresarVoluntarioAccidentado = new System.Windows.Forms.Button();
            this.textDescripcionAccidente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textNombreVoluntarioAccidentado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.groupVoluntarioAccidentado.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupVoluntarioAccidentado
            // 
            this.groupVoluntarioAccidentado.Controls.Add(this.btnIngresarVoluntarioAccidentado);
            this.groupVoluntarioAccidentado.Controls.Add(this.textDescripcionAccidente);
            this.groupVoluntarioAccidentado.Controls.Add(this.label2);
            this.groupVoluntarioAccidentado.Controls.Add(this.textNombreVoluntarioAccidentado);
            this.groupVoluntarioAccidentado.Controls.Add(this.label1);
            this.groupVoluntarioAccidentado.Location = new System.Drawing.Point(12, 12);
            this.groupVoluntarioAccidentado.Name = "groupVoluntarioAccidentado";
            this.groupVoluntarioAccidentado.Size = new System.Drawing.Size(452, 159);
            this.groupVoluntarioAccidentado.TabIndex = 1;
            this.groupVoluntarioAccidentado.TabStop = false;
            this.groupVoluntarioAccidentado.Text = "Voluntario Accidentado";
            // 
            // btnIngresarVoluntarioAccidentado
            // 
            this.btnIngresarVoluntarioAccidentado.Location = new System.Drawing.Point(6, 127);
            this.btnIngresarVoluntarioAccidentado.Name = "btnIngresarVoluntarioAccidentado";
            this.btnIngresarVoluntarioAccidentado.Size = new System.Drawing.Size(75, 23);
            this.btnIngresarVoluntarioAccidentado.TabIndex = 1;
            this.btnIngresarVoluntarioAccidentado.Text = "Ingresar";
            this.btnIngresarVoluntarioAccidentado.UseVisualStyleBackColor = true;
            this.btnIngresarVoluntarioAccidentado.Click += new System.EventHandler(this.btnIngresarVoluntarioAccidentado_Click);
            // 
            // textDescripcionAccidente
            // 
            this.textDescripcionAccidente.Location = new System.Drawing.Point(6, 81);
            this.textDescripcionAccidente.Multiline = true;
            this.textDescripcionAccidente.Name = "textDescripcionAccidente";
            this.textDescripcionAccidente.Size = new System.Drawing.Size(440, 40);
            this.textDescripcionAccidente.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descripción Accidente:";
            // 
            // textNombreVoluntarioAccidentado
            // 
            this.textNombreVoluntarioAccidentado.Location = new System.Drawing.Point(6, 32);
            this.textNombreVoluntarioAccidentado.Name = "textNombreVoluntarioAccidentado";
            this.textNombreVoluntarioAccidentado.Size = new System.Drawing.Size(440, 20);
            this.textNombreVoluntarioAccidentado.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre Voluntario:";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(389, 177);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // VoluntarioAccidentado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 206);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.groupVoluntarioAccidentado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VoluntarioAccidentado";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Voluntario Accidentado";
            this.groupVoluntarioAccidentado.ResumeLayout(false);
            this.groupVoluntarioAccidentado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupVoluntarioAccidentado;
        private System.Windows.Forms.Button btnIngresarVoluntarioAccidentado;
        private System.Windows.Forms.TextBox textDescripcionAccidente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textNombreVoluntarioAccidentado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCerrar;
    }
}