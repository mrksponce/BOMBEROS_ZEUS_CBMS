namespace PrestamoCarros
{
    partial class Frm_Tipo
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
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.cbx_tipo_carro = new System.Windows.Forms.ComboBox();
            this.lbl_tipo_carro = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.Location = new System.Drawing.Point(128, 118);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(88, 28);
            this.btn_aceptar.TabIndex = 1;
            this.btn_aceptar.Text = "Aceptar";
            this.btn_aceptar.UseVisualStyleBackColor = true;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // cbx_tipo_carro
            // 
            this.cbx_tipo_carro.FormattingEnabled = true;
            this.cbx_tipo_carro.Location = new System.Drawing.Point(70, 64);
            this.cbx_tipo_carro.Name = "cbx_tipo_carro";
            this.cbx_tipo_carro.Size = new System.Drawing.Size(146, 21);
            this.cbx_tipo_carro.TabIndex = 2;
            // 
            // lbl_tipo_carro
            // 
            this.lbl_tipo_carro.AutoSize = true;
            this.lbl_tipo_carro.Location = new System.Drawing.Point(67, 38);
            this.lbl_tipo_carro.Name = "lbl_tipo_carro";
            this.lbl_tipo_carro.Size = new System.Drawing.Size(77, 13);
            this.lbl_tipo_carro.TabIndex = 3;
            this.lbl_tipo_carro.Text = "Tipo de Carro :";
            // 
            // Frm_Tipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 181);
            this.Controls.Add(this.lbl_tipo_carro);
            this.Controls.Add(this.cbx_tipo_carro);
            this.Controls.Add(this.btn_aceptar);
            this.Name = "Frm_Tipo";
            this.Text = "Clasificación de Carro";
            this.Load += new System.EventHandler(this.Frm_Tipo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_aceptar;
        private System.Windows.Forms.ComboBox cbx_tipo_carro;
        private System.Windows.Forms.Label lbl_tipo_carro;
    }
}