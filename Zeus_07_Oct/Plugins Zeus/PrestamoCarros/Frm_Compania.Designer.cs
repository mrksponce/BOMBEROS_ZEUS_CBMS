namespace PrestamoCarros
{
    partial class Frm_Compania
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
            this.lbl_compania = new System.Windows.Forms.Label();
            this.cmb_compania = new System.Windows.Forms.ComboBox();
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_compania
            // 
            this.lbl_compania.AutoSize = true;
            this.lbl_compania.Location = new System.Drawing.Point(80, 52);
            this.lbl_compania.Name = "lbl_compania";
            this.lbl_compania.Size = new System.Drawing.Size(100, 13);
            this.lbl_compania.TabIndex = 0;
            this.lbl_compania.Text = "Asignar Compañía :";
            // 
            // cmb_compania
            // 
            this.cmb_compania.FormattingEnabled = true;
            this.cmb_compania.Location = new System.Drawing.Point(83, 77);
            this.cmb_compania.Name = "cmb_compania";
            this.cmb_compania.Size = new System.Drawing.Size(131, 21);
            this.cmb_compania.TabIndex = 1;
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.Location = new System.Drawing.Point(83, 133);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(131, 29);
            this.btn_aceptar.TabIndex = 2;
            this.btn_aceptar.Text = "Aceptar";
            this.btn_aceptar.UseVisualStyleBackColor = true;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // Frm_Compania
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 207);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.cmb_compania);
            this.Controls.Add(this.lbl_compania);
            this.Name = "Frm_Compania";
            this.Text = "Asignación de Compañía";
            this.Load += new System.EventHandler(this.Frm_Compania_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_compania;
        private System.Windows.Forms.ComboBox cmb_compania;
        private System.Windows.Forms.Button btn_aceptar;
    }
}