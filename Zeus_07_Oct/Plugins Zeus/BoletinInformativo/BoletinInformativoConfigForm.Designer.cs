namespace BoletinInformativo
{
    partial class BoletinInformativoConfigForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.clTipoCarro = new System.Windows.Forms.CheckedListBox();
            this.checkTipoCarro = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textDias = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkTiempoFuera = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.clTipoCarro);
            this.groupBox1.Controls.Add(this.checkTipoCarro);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 165);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrado de Carros";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mostrar los siguientes tipos de carros:";
            // 
            // clTipoCarro
            // 
            this.clTipoCarro.FormattingEnabled = true;
            this.clTipoCarro.Location = new System.Drawing.Point(9, 55);
            this.clTipoCarro.MultiColumn = true;
            this.clTipoCarro.Name = "clTipoCarro";
            this.clTipoCarro.Size = new System.Drawing.Size(325, 94);
            this.clTipoCarro.TabIndex = 1;
            // 
            // checkTipoCarro
            // 
            this.checkTipoCarro.AutoSize = true;
            this.checkTipoCarro.Checked = true;
            this.checkTipoCarro.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkTipoCarro.Location = new System.Drawing.Point(6, 19);
            this.checkTipoCarro.Name = "checkTipoCarro";
            this.checkTipoCarro.Size = new System.Drawing.Size(185, 17);
            this.checkTipoCarro.TabIndex = 0;
            this.checkTipoCarro.Text = "Habilitar filtrado por tipo de carro";
            this.checkTipoCarro.UseVisualStyleBackColor = true;
            this.checkTipoCarro.CheckedChanged += new System.EventHandler(this.checkTipoCarro_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textDias);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.checkTiempoFuera);
            this.groupBox2.Location = new System.Drawing.Point(12, 183);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(340, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tiempo fuera de servicio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(222, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "días fuera de servicio.";
            // 
            // textDias
            // 
            this.textDias.Location = new System.Drawing.Point(157, 48);
            this.textDias.Name = "textDias";
            this.textDias.Size = new System.Drawing.Size(63, 21);
            this.textDias.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "No mostrar carros con más de ";
            // 
            // checkTiempoFuera
            // 
            this.checkTiempoFuera.AutoSize = true;
            this.checkTiempoFuera.Checked = true;
            this.checkTiempoFuera.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkTiempoFuera.Location = new System.Drawing.Point(6, 19);
            this.checkTiempoFuera.Name = "checkTiempoFuera";
            this.checkTiempoFuera.Size = new System.Drawing.Size(239, 17);
            this.checkTiempoFuera.TabIndex = 0;
            this.checkTiempoFuera.Text = "Habilitar filtrado por tiempo fuera de servicio";
            this.checkTiempoFuera.UseVisualStyleBackColor = true;
            this.checkTiempoFuera.CheckedChanged += new System.EventHandler(this.checkTiempoFuera_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 289);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(277, 289);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // BoletinInformativoConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 323);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BoletinInformativoConfigForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuración Boletín Informativo";
            this.Load += new System.EventHandler(this.BoletinInformativoConfigForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox clTipoCarro;
        private System.Windows.Forms.CheckBox checkTipoCarro;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textDias;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkTiempoFuera;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}