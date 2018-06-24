using Zeus.UIElements;
namespace Zeus.Application
{
    partial class MaterialMayor
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
            //this.components = new System.ComponentModel.Container();
            this.panelEstadoCarros1 = new Zeus.UIElements.PanelEstadoCarros();
            //this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // panelEstadoCarros1
            // 
            this.panelEstadoCarros1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEstadoCarros1.Location = new System.Drawing.Point(0, 0);
            this.panelEstadoCarros1.Name = "panelEstadoCarros1";
            this.panelEstadoCarros1.Size = new System.Drawing.Size(1016, 480);
            this.panelEstadoCarros1.TabIndex = 0;
            this.panelEstadoCarros1.ZeusWin = null;
            // 
            // timer1
            // 
            //this.timer1.Interval = 300000;
            //this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MaterialMayor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 480);
            this.Controls.Add(this.panelEstadoCarros1);
            this.Name = "MaterialMayor";
            this.ShowInTaskbar = false;
            this.Text = "Material Mayor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MaterialMayor_FormClosed);
            this.Load += new System.EventHandler(this.MaterialMayor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private PanelEstadoCarros panelEstadoCarros1;
        private System.Windows.Forms.Timer timer1;
    }
}