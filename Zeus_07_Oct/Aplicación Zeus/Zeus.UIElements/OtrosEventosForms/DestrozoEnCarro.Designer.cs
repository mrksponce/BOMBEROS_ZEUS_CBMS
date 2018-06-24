namespace Zeus.UIElements.OtrosEventosForms
{
    partial class DestrozoEnCarro
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
            this.groupDestrozoCarros = new System.Windows.Forms.GroupBox();
            this.btnIngresarCarro = new System.Windows.Forms.Button();
            this.textDestrozoCarro = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textCarro = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.groupDestrozoCarros.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupDestrozoCarros
            // 
            this.groupDestrozoCarros.Controls.Add(this.btnIngresarCarro);
            this.groupDestrozoCarros.Controls.Add(this.textDestrozoCarro);
            this.groupDestrozoCarros.Controls.Add(this.label5);
            this.groupDestrozoCarros.Controls.Add(this.textCarro);
            this.groupDestrozoCarros.Controls.Add(this.label6);
            this.groupDestrozoCarros.Location = new System.Drawing.Point(12, 12);
            this.groupDestrozoCarros.Name = "groupDestrozoCarros";
            this.groupDestrozoCarros.Size = new System.Drawing.Size(452, 159);
            this.groupDestrozoCarros.TabIndex = 6;
            this.groupDestrozoCarros.TabStop = false;
            this.groupDestrozoCarros.Text = "Destrozo en Carros";
            // 
            // btnIngresarCarro
            // 
            this.btnIngresarCarro.Location = new System.Drawing.Point(6, 127);
            this.btnIngresarCarro.Name = "btnIngresarCarro";
            this.btnIngresarCarro.Size = new System.Drawing.Size(75, 23);
            this.btnIngresarCarro.TabIndex = 1;
            this.btnIngresarCarro.Text = "Ingresar";
            this.btnIngresarCarro.UseVisualStyleBackColor = true;
            this.btnIngresarCarro.Click += new System.EventHandler(this.btnIngresarCarro_Click);
            // 
            // textDestrozoCarro
            // 
            this.textDestrozoCarro.Location = new System.Drawing.Point(6, 81);
            this.textDestrozoCarro.Multiline = true;
            this.textDestrozoCarro.Name = "textDestrozoCarro";
            this.textDestrozoCarro.Size = new System.Drawing.Size(440, 40);
            this.textDestrozoCarro.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Descripción Destrozo:";
            // 
            // textCarro
            // 
            this.textCarro.Location = new System.Drawing.Point(6, 32);
            this.textCarro.Name = "textCarro";
            this.textCarro.Size = new System.Drawing.Size(440, 20);
            this.textCarro.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Carro:";
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
            // DestrozoEnCarro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 206);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.groupDestrozoCarros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DestrozoEnCarro";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Destrozo En Carro";
            this.groupDestrozoCarros.ResumeLayout(false);
            this.groupDestrozoCarros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupDestrozoCarros;
        private System.Windows.Forms.Button btnIngresarCarro;
        private System.Windows.Forms.TextBox textDestrozoCarro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textCarro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCerrar;
    }
}