namespace Zeus.UIElements
{
    partial class Frm615
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
            this.txtLugar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chk09 = new System.Windows.Forms.RadioButton();
            this.chk08 = new System.Windows.Forms.RadioButton();
            this.btn614 = new System.Windows.Forms.Button();
            this.lbResultados = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLugar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ingreso de lugar";
            // 
            // txtLugar
            // 
            this.txtLugar.Location = new System.Drawing.Point(55, 23);
            this.txtLugar.Name = "txtLugar";
            this.txtLugar.Size = new System.Drawing.Size(279, 20);
            this.txtLugar.TabIndex = 1;
            this.txtLugar.TextChanged += new System.EventHandler(this.txtLugar_TextChanged);
            this.txtLugar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLugar_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lugar:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chk09);
            this.groupBox2.Controls.Add(this.chk08);
            this.groupBox2.Controls.Add(this.btn614);
            this.groupBox2.Controls.Add(this.lbResultados);
            this.groupBox2.Location = new System.Drawing.Point(12, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(340, 238);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resultados";
            // 
            // chk09
            // 
            this.chk09.AutoSize = true;
            this.chk09.BackColor = System.Drawing.Color.Lime;
            this.chk09.Checked = true;
            this.chk09.Location = new System.Drawing.Point(294, 25);
            this.chk09.Name = "chk09";
            this.chk09.Size = new System.Drawing.Size(40, 17);
            this.chk09.TabIndex = 3;
            this.chk09.TabStop = true;
            this.chk09.Text = "0-9";
            this.chk09.UseVisualStyleBackColor = false;
            // 
            // chk08
            // 
            this.chk08.AutoSize = true;
            this.chk08.BackColor = System.Drawing.Color.Red;
            this.chk08.Location = new System.Drawing.Point(9, 25);
            this.chk08.Name = "chk08";
            this.chk08.Size = new System.Drawing.Size(40, 17);
            this.chk08.TabIndex = 2;
            this.chk08.Text = "0-8";
            this.chk08.UseVisualStyleBackColor = false;
            // 
            // btn614
            // 
            this.btn614.Location = new System.Drawing.Point(244, 204);
            this.btn614.Name = "btn614";
            this.btn614.Size = new System.Drawing.Size(90, 23);
            this.btn614.TabIndex = 1;
            this.btn614.Text = "Asignar 6-15";
            this.btn614.UseVisualStyleBackColor = true;
            this.btn614.Click += new System.EventHandler(this.btn614_Click);
            // 
            // lbResultados
            // 
            this.lbResultados.FormattingEnabled = true;
            this.lbResultados.Location = new System.Drawing.Point(9, 51);
            this.lbResultados.Name = "lbResultados";
            this.lbResultados.Size = new System.Drawing.Size(325, 147);
            this.lbResultados.TabIndex = 0;
            this.lbResultados.SelectedIndexChanged += new System.EventHandler(this.lbResultados_SelectedIndexChanged);
            // 
            // Frm615
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 324);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm615";
            this.Text = "Asignar 6-15";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtLugar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn614;
        private System.Windows.Forms.ListBox lbResultados;
        private System.Windows.Forms.RadioButton chk09;
        private System.Windows.Forms.RadioButton chk08;
    }
}