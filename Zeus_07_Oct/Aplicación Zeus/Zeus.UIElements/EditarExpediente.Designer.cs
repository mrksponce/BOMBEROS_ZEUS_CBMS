namespace Zeus.UIElements
{
    partial class EditarExpediente
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
            this.informacionExpediente1 = new Zeus.UIElements.InformacionExpediente();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(615, 376);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // informacionExpediente1
            // 
            this.informacionExpediente1.ComunasDataSource = null;
            this.informacionExpediente1.Expediente = null;
            this.informacionExpediente1.Location = new System.Drawing.Point(12, 12);
            this.informacionExpediente1.MinimumSize = new System.Drawing.Size(657, 392);
            this.informacionExpediente1.Name = "informacionExpediente1";
            this.informacionExpediente1.Size = new System.Drawing.Size(684, 710);
            this.informacionExpediente1.TabIndex = 0;
            // 
            // EditarExpediente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 734);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.informacionExpediente1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditarExpediente";
            this.ShowInTaskbar = false;
            this.Text = "Editar Expediente";
            this.Load += new System.EventHandler(this.EditarExpediente_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private InformacionExpediente informacionExpediente1;
        private System.Windows.Forms.Button btnCerrar;
    }
}