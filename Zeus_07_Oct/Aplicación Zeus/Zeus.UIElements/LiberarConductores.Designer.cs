namespace Zeus.UIElements
{
    partial class LiberarConductores
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
            this.chkList_LiberarConductores = new System.Windows.Forms.CheckedListBox();
            this.btn_Actualizar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkList_LiberarConductores
            // 
            this.chkList_LiberarConductores.FormattingEnabled = true;
            this.chkList_LiberarConductores.Location = new System.Drawing.Point(24, 24);
            this.chkList_LiberarConductores.Name = "chkList_LiberarConductores";
            this.chkList_LiberarConductores.Size = new System.Drawing.Size(370, 184);
            this.chkList_LiberarConductores.TabIndex = 0; //ItemCheckEventHandler
            this.chkList_LiberarConductores.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkList_LiberarConductores_ItemCheck);
            // 
            // btn_Actualizar
            // 
            this.btn_Actualizar.Location = new System.Drawing.Point(287, 225);
            this.btn_Actualizar.Name = "btn_Actualizar";
            this.btn_Actualizar.Size = new System.Drawing.Size(107, 25);
            this.btn_Actualizar.TabIndex = 1;
            this.btn_Actualizar.Text = "Actualizar";
            this.btn_Actualizar.UseVisualStyleBackColor = true;
            this.btn_Actualizar.Click += new System.EventHandler(this.btn_Actualizar_Click);
            // 
            // LiberarConductores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 262);
            this.Controls.Add(this.btn_Actualizar);
            this.Controls.Add(this.chkList_LiberarConductores);
            this.Name = "LiberarConductores";
            this.Text = "Liberar Conductores";
            this.Load += new System.EventHandler(this.LiberarConductores_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chkList_LiberarConductores;
        private System.Windows.Forms.Button btn_Actualizar;
    }
}