namespace Zeus.PluginGeocodificacion.Forms
{
    partial class Carreteras
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
            this.groupTipo = new System.Windows.Forms.GroupBox();
            this.groupZoom = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Etiqueta2 = new System.Windows.Forms.Label();
            this.Etiqueta1 = new System.Windows.Forms.Label();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.groupZoom.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupTipo
            // 
            this.groupTipo.AutoSize = true;
            this.groupTipo.Location = new System.Drawing.Point(12, 12);
            this.groupTipo.Name = "groupTipo";
            this.groupTipo.Size = new System.Drawing.Size(301, 28);
            this.groupTipo.TabIndex = 0;
            this.groupTipo.TabStop = false;
            this.groupTipo.Text = "Tipo de Información";
            // 
            // groupZoom
            // 
            this.groupZoom.Controls.Add(this.comboBox2);
            this.groupZoom.Controls.Add(this.comboBox1);
            this.groupZoom.Controls.Add(this.Etiqueta2);
            this.groupZoom.Controls.Add(this.Etiqueta1);
            this.groupZoom.Location = new System.Drawing.Point(12, 63);
            this.groupZoom.Name = "groupZoom";
            this.groupZoom.Size = new System.Drawing.Size(301, 130);
            this.groupZoom.TabIndex = 1;
            this.groupZoom.TabStop = false;
            this.groupZoom.Text = "Zoom";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(6, 86);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(289, 21);
            this.comboBox2.TabIndex = 3;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(289, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Etiqueta2
            // 
            this.Etiqueta2.AutoSize = true;
            this.Etiqueta2.Location = new System.Drawing.Point(6, 70);
            this.Etiqueta2.Name = "Etiqueta2";
            this.Etiqueta2.Size = new System.Drawing.Size(0, 13);
            this.Etiqueta2.TabIndex = 2;
            // 
            // Etiqueta1
            // 
            this.Etiqueta1.AutoSize = true;
            this.Etiqueta1.Location = new System.Drawing.Point(6, 16);
            this.Etiqueta1.Name = "Etiqueta1";
            this.Etiqueta1.Size = new System.Drawing.Size(0, 13);
            this.Etiqueta1.TabIndex = 2;
            // 
            // btnMostrar
            // 
            this.btnMostrar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrar.Location = new System.Drawing.Point(149, 208);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(164, 23);
            this.btnMostrar.TabIndex = 2;
            this.btnMostrar.Text = "Generar Expediente";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // Carreteras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(325, 243);
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.groupZoom);
            this.Controls.Add(this.groupTipo);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Carreteras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Localización en Autopistas";
            this.groupZoom.ResumeLayout(false);
            this.groupZoom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupTipo;
        private System.Windows.Forms.GroupBox groupZoom;
        private System.Windows.Forms.Label Etiqueta1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label Etiqueta2;
        private System.Windows.Forms.Button btnMostrar;
    }
}