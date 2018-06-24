namespace Zeus.UIElements
{
    partial class MainLlamadosCarros
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelLlamado1 = new Zeus.UIElements.PanelLlamado();
            this.panelCarro1 = new Zeus.UIElements.PanelCarro();
            this.SuspendLayout();
            // 
            // panelLlamado1
            // 
            this.panelLlamado1.Location = new System.Drawing.Point(210, 82);
            this.panelLlamado1.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.panelLlamado1.Name = "panelLlamado1";
            this.panelLlamado1.Size = new System.Drawing.Size(236, 142);
            this.panelLlamado1.TabIndex = 3;
            this.panelLlamado1.Visible = false;
            this.panelLlamado1.ZeusWin = null;
            // 
            // panelCarro1
            // 
            this.panelCarro1.Location = new System.Drawing.Point(15, 12);
            this.panelCarro1.Name = "panelCarro1";
            this.panelCarro1.Size = new System.Drawing.Size(253, 153);
            this.panelCarro1.TabIndex = 2;
            this.panelCarro1.Visible = false;
            this.panelCarro1.ZeusWin = null;
            // 
            // MainLlamadosCarros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelLlamado1);
            this.Controls.Add(this.panelCarro1);
            this.Name = "MainLlamadosCarros";
            this.Size = new System.Drawing.Size(717, 382);
            this.ResumeLayout(false);

        }

        #endregion

        private PanelLlamado panelLlamado1;
        private PanelCarro panelCarro1;
    }
}
