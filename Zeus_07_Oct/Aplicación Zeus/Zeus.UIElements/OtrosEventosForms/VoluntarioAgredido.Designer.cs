namespace Zeus.UIElements.OtrosEventosForms
{
    partial class VoluntarioAgredido
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
            this.groupAgresionVoluntario = new System.Windows.Forms.GroupBox();
            this.btnIngresarAgresion = new System.Windows.Forms.Button();
            this.textDescripcionAgresion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textNombreVoluntarioAgredido = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.groupAgresionVoluntario.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupAgresionVoluntario
            // 
            this.groupAgresionVoluntario.Controls.Add(this.btnIngresarAgresion);
            this.groupAgresionVoluntario.Controls.Add(this.textDescripcionAgresion);
            this.groupAgresionVoluntario.Controls.Add(this.label3);
            this.groupAgresionVoluntario.Controls.Add(this.textNombreVoluntarioAgredido);
            this.groupAgresionVoluntario.Controls.Add(this.label4);
            this.groupAgresionVoluntario.Location = new System.Drawing.Point(12, 12);
            this.groupAgresionVoluntario.Name = "groupAgresionVoluntario";
            this.groupAgresionVoluntario.Size = new System.Drawing.Size(452, 159);
            this.groupAgresionVoluntario.TabIndex = 5;
            this.groupAgresionVoluntario.TabStop = false;
            this.groupAgresionVoluntario.Text = "Agresión a voluntario";
            // 
            // btnIngresarAgresion
            // 
            this.btnIngresarAgresion.Location = new System.Drawing.Point(6, 127);
            this.btnIngresarAgresion.Name = "btnIngresarAgresion";
            this.btnIngresarAgresion.Size = new System.Drawing.Size(75, 23);
            this.btnIngresarAgresion.TabIndex = 1;
            this.btnIngresarAgresion.Text = "Ingresar";
            this.btnIngresarAgresion.UseVisualStyleBackColor = true;
            this.btnIngresarAgresion.Click += new System.EventHandler(this.btnIngresarAgresion_Click);
            // 
            // textDescripcionAgresion
            // 
            this.textDescripcionAgresion.Location = new System.Drawing.Point(6, 81);
            this.textDescripcionAgresion.Multiline = true;
            this.textDescripcionAgresion.Name = "textDescripcionAgresion";
            this.textDescripcionAgresion.Size = new System.Drawing.Size(440, 40);
            this.textDescripcionAgresion.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Descripción Agresión:";
            // 
            // textNombreVoluntarioAgredido
            // 
            this.textNombreVoluntarioAgredido.Location = new System.Drawing.Point(6, 32);
            this.textNombreVoluntarioAgredido.Name = "textNombreVoluntarioAgredido";
            this.textNombreVoluntarioAgredido.Size = new System.Drawing.Size(440, 20);
            this.textNombreVoluntarioAgredido.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nombre Voluntario:";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(389, 177);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // VoluntarioAgredido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 206);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.groupAgresionVoluntario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VoluntarioAgredido";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "VoluntarioAgredido";
            this.groupAgresionVoluntario.ResumeLayout(false);
            this.groupAgresionVoluntario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupAgresionVoluntario;
        private System.Windows.Forms.Button btnIngresarAgresion;
        private System.Windows.Forms.TextBox textDescripcionAgresion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textNombreVoluntarioAgredido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCerrar;
    }
}