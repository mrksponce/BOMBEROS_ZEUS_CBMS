namespace AlertaFerias
{
    partial class ConfigFerias
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
            this.checkHabilitar = new System.Windows.Forms.CheckBox();
            this.textRadio = new System.Windows.Forms.TextBox();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bntCancelar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textTiempo = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkHabilitar
            // 
            this.checkHabilitar.AutoSize = true;
            this.checkHabilitar.Location = new System.Drawing.Point(12, 12);
            this.checkHabilitar.Name = "checkHabilitar";
            this.checkHabilitar.Size = new System.Drawing.Size(144, 17);
            this.checkHabilitar.TabIndex = 0;
            this.checkHabilitar.Text = "Habilitar Alerta de Ferias";
            this.checkHabilitar.UseVisualStyleBackColor = true;
            this.checkHabilitar.CheckedChanged += new System.EventHandler(this.checkHabilitar_CheckedChanged);
            // 
            // textRadio
            // 
            this.textRadio.Location = new System.Drawing.Point(6, 24);
            this.textRadio.Name = "textRadio";
            this.textRadio.Size = new System.Drawing.Size(137, 21);
            this.textRadio.TabIndex = 1;
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(12, 185);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(75, 23);
            this.btnAplicar.TabIndex = 2;
            this.btnAplicar.Text = "Aceptar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "mts.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textRadio);
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 59);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Radio de Selección";
            // 
            // bntCancelar
            // 
            this.bntCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bntCancelar.Location = new System.Drawing.Point(177, 185);
            this.bntCancelar.Name = "bntCancelar";
            this.bntCancelar.Size = new System.Drawing.Size(75, 23);
            this.bntCancelar.TabIndex = 6;
            this.bntCancelar.Text = "Cancelar";
            this.bntCancelar.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textTiempo);
            this.groupBox2.Location = new System.Drawing.Point(12, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(240, 59);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tiempo de activación";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "segundos";
            // 
            // textTiempo
            // 
            this.textTiempo.Location = new System.Drawing.Point(6, 24);
            this.textTiempo.Name = "textTiempo";
            this.textTiempo.Size = new System.Drawing.Size(137, 21);
            this.textTiempo.TabIndex = 1;
            // 
            // ConfigFerias
            // 
            this.AcceptButton = this.btnAplicar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bntCancelar;
            this.ClientSize = new System.Drawing.Size(264, 229);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.bntCancelar);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkHabilitar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigFerias";
            this.ShowInTaskbar = false;
            this.Text = "Ferias";
            this.Load += new System.EventHandler(this.ConfigFerias_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkHabilitar;
        private System.Windows.Forms.TextBox textRadio;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bntCancelar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textTiempo;
    }
}