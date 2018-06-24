namespace Zeus.UIElements.AdminForms
{
    partial class AdminModulos
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDetener = new System.Windows.Forms.Button();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.clPlugins = new System.Windows.Forms.CheckedListBox();
            this.rtfDatosPlugin = new System.Windows.Forms.RichTextBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDetener);
            this.groupBox1.Controls.Add(this.btnIniciar);
            this.groupBox1.Controls.Add(this.clPlugins);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 230);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Módulos Cargados";
            // 
            // btnDetener
            // 
            this.btnDetener.Location = new System.Drawing.Point(216, 194);
            this.btnDetener.Name = "btnDetener";
            this.btnDetener.Size = new System.Drawing.Size(88, 23);
            this.btnDetener.TabIndex = 2;
            this.btnDetener.Text = "Detener Todos";
            this.btnDetener.UseVisualStyleBackColor = true;
            this.btnDetener.Click += new System.EventHandler(this.btnDetener_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(6, 194);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(88, 23);
            this.btnIniciar.TabIndex = 1;
            this.btnIniciar.Text = "Iniciar Todos";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // clPlugins
            // 
            this.clPlugins.FormattingEnabled = true;
            this.clPlugins.Location = new System.Drawing.Point(6, 19);
            this.clPlugins.Name = "clPlugins";
            this.clPlugins.Size = new System.Drawing.Size(299, 169);
            this.clPlugins.TabIndex = 0;
            this.clPlugins.SelectedIndexChanged += new System.EventHandler(this.clPlugins_SelectedIndexChanged);
            this.clPlugins.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clPlugins_ItemCheck);
            // 
            // rtfDatosPlugin
            // 
            this.rtfDatosPlugin.Location = new System.Drawing.Point(12, 248);
            this.rtfDatosPlugin.Name = "rtfDatosPlugin";
            this.rtfDatosPlugin.ReadOnly = true;
            this.rtfDatosPlugin.Size = new System.Drawing.Size(311, 161);
            this.rtfDatosPlugin.TabIndex = 1;
            this.rtfDatosPlugin.Text = "";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(248, 415);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // AdminModulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 450);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.rtfDatosPlugin);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminModulos";
            this.ShowInTaskbar = false;
            this.Text = "Administración de Módulos";
            this.Load += new System.EventHandler(this.AdminModulos_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox clPlugins;
        private System.Windows.Forms.Button btnDetener;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.RichTextBox rtfDatosPlugin;
        private System.Windows.Forms.Button btnCerrar;
    }
}