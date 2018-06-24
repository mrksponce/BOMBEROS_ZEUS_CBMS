namespace Zeus.UIElements
{
    partial class OtrosEventos
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
            this.btnVoluntarioAgredido = new System.Windows.Forms.Button();
            this.btnVoluntarioLesionado = new System.Windows.Forms.Button();
            this.btnDestrozoCarro = new System.Windows.Forms.Button();
            this.bntDestrozoCuartel = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnVoluntarioAgredido
            // 
            this.btnVoluntarioAgredido.Location = new System.Drawing.Point(12, 12);
            this.btnVoluntarioAgredido.Name = "btnVoluntarioAgredido";
            this.btnVoluntarioAgredido.Size = new System.Drawing.Size(193, 23);
            this.btnVoluntarioAgredido.TabIndex = 0;
            this.btnVoluntarioAgredido.Text = "7-5: Voluntario Agredido";
            this.btnVoluntarioAgredido.UseVisualStyleBackColor = true;
            this.btnVoluntarioAgredido.Click += new System.EventHandler(this.btnVoluntarioAgredido_Click);
            // 
            // btnVoluntarioLesionado
            // 
            this.btnVoluntarioLesionado.Location = new System.Drawing.Point(12, 41);
            this.btnVoluntarioLesionado.Name = "btnVoluntarioLesionado";
            this.btnVoluntarioLesionado.Size = new System.Drawing.Size(193, 23);
            this.btnVoluntarioLesionado.TabIndex = 1;
            this.btnVoluntarioLesionado.Text = "7-5: Voluntario Lesionado";
            this.btnVoluntarioLesionado.UseVisualStyleBackColor = true;
            this.btnVoluntarioLesionado.Click += new System.EventHandler(this.btnVoluntarioLesionado_Click);
            // 
            // btnDestrozoCarro
            // 
            this.btnDestrozoCarro.Location = new System.Drawing.Point(12, 70);
            this.btnDestrozoCarro.Name = "btnDestrozoCarro";
            this.btnDestrozoCarro.Size = new System.Drawing.Size(193, 23);
            this.btnDestrozoCarro.TabIndex = 2;
            this.btnDestrozoCarro.Text = "7-5: Destrozo en Carro";
            this.btnDestrozoCarro.UseVisualStyleBackColor = true;
            this.btnDestrozoCarro.Click += new System.EventHandler(this.btnDestrozoCarro_Click);
            // 
            // bntDestrozoCuartel
            // 
            this.bntDestrozoCuartel.Location = new System.Drawing.Point(12, 99);
            this.bntDestrozoCuartel.Name = "bntDestrozoCuartel";
            this.bntDestrozoCuartel.Size = new System.Drawing.Size(193, 23);
            this.bntDestrozoCuartel.TabIndex = 3;
            this.bntDestrozoCuartel.Text = "7-5: Destrozo en Cuartel";
            this.bntDestrozoCuartel.UseVisualStyleBackColor = true;
            this.bntDestrozoCuartel.Click += new System.EventHandler(this.bntDestrozoCuartel_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(74, 152);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // OtrosEventos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 187);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.bntDestrozoCuartel);
            this.Controls.Add(this.btnDestrozoCarro);
            this.Controls.Add(this.btnVoluntarioLesionado);
            this.Controls.Add(this.btnVoluntarioAgredido);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OtrosEventos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Otros Eventos";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVoluntarioAgredido;
        private System.Windows.Forms.Button btnVoluntarioLesionado;
        private System.Windows.Forms.Button btnDestrozoCarro;
        private System.Windows.Forms.Button bntDestrozoCuartel;
        private System.Windows.Forms.Button btnCerrar;

    }
}