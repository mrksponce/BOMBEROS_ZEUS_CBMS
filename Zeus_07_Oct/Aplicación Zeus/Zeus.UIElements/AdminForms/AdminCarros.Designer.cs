namespace Zeus.UIElements.AdminForms
{
    partial class AdminCarros
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnFoto = new System.Windows.Forms.Button();
            this.comboCompañia = new System.Windows.Forms.ComboBox();
            this.comboTipo = new System.Windows.Forms.ComboBox();
            this.pictureFoto = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(187, 223);
            this.groupBox1.Text = "Carros Actuales";
            // 
            // listActuales
            // 
            this.listActuales.Size = new System.Drawing.Size(175, 160);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(205, 212);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(286, 212);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(367, 212);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(460, 212);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnFoto);
            this.groupBox2.Controls.Add(this.comboCompañia);
            this.groupBox2.Controls.Add(this.comboTipo);
            this.groupBox2.Controls.Add(this.pictureFoto);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textNombre);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(205, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(330, 194);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Carro";
            // 
            // btnFoto
            // 
            this.btnFoto.Location = new System.Drawing.Point(6, 145);
            this.btnFoto.Name = "btnFoto";
            this.btnFoto.Size = new System.Drawing.Size(160, 23);
            this.btnFoto.TabIndex = 7;
            this.btnFoto.Text = "Cambiar Foto...";
            this.btnFoto.UseVisualStyleBackColor = true;
            this.btnFoto.Click += new System.EventHandler(this.btnFoto_Click);
            // 
            // comboCompañia
            // 
            this.comboCompañia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCompañia.FormattingEnabled = true;
            this.comboCompañia.Location = new System.Drawing.Point(173, 114);
            this.comboCompañia.Name = "comboCompañia";
            this.comboCompañia.Size = new System.Drawing.Size(151, 21);
            this.comboCompañia.TabIndex = 6;
            // 
            // comboTipo
            // 
            this.comboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipo.FormattingEnabled = true;
            this.comboTipo.Location = new System.Drawing.Point(173, 74);
            this.comboTipo.Name = "comboTipo";
            this.comboTipo.Size = new System.Drawing.Size(151, 21);
            this.comboTipo.TabIndex = 5;
            // 
            // pictureFoto
            // 
            this.pictureFoto.Location = new System.Drawing.Point(6, 19);
            this.pictureFoto.Name = "pictureFoto";
            this.pictureFoto.Size = new System.Drawing.Size(160, 120);
            this.pictureFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureFoto.TabIndex = 4;
            this.pictureFoto.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(170, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Compañía:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo de Carro:";
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(173, 35);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(151, 21);
            this.textNombre.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Imágenes|*.jpg;*.gif;*.bmp;*.png";
            this.openFileDialog1.Title = "Seleccione foto de carro";
            // 
            // AdminCarros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 247);
            this.Controls.Add(this.groupBox2);
            this.Name = "AdminCarros";
            this.Text = "Admininstración de Material Mayor";
            this.Load += new System.EventHandler(this.AdminCarros_Load);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnActualizar, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboCompañia;
        private System.Windows.Forms.ComboBox comboTipo;
        private System.Windows.Forms.PictureBox pictureFoto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFoto;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}