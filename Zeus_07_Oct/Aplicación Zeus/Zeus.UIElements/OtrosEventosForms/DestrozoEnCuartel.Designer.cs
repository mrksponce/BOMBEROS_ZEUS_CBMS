namespace Zeus.UIElements.OtrosEventosForms
{
    partial class DestrozoEnCuartel
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
            this.groupDestrozoCuartel = new System.Windows.Forms.GroupBox();
            this.btnIngresarCuartel = new System.Windows.Forms.Button();
            this.textDescripcionCuartel = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textCuartel = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.groupDestrozoCuartel.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupDestrozoCuartel
            // 
            this.groupDestrozoCuartel.Controls.Add(this.btnIngresarCuartel);
            this.groupDestrozoCuartel.Controls.Add(this.textDescripcionCuartel);
            this.groupDestrozoCuartel.Controls.Add(this.label7);
            this.groupDestrozoCuartel.Controls.Add(this.textCuartel);
            this.groupDestrozoCuartel.Controls.Add(this.label8);
            this.groupDestrozoCuartel.Location = new System.Drawing.Point(12, 12);
            this.groupDestrozoCuartel.Name = "groupDestrozoCuartel";
            this.groupDestrozoCuartel.Size = new System.Drawing.Size(452, 159);
            this.groupDestrozoCuartel.TabIndex = 7;
            this.groupDestrozoCuartel.TabStop = false;
            this.groupDestrozoCuartel.Text = "Destrozo en Cuartel";
            // 
            // btnIngresarCuartel
            // 
            this.btnIngresarCuartel.Location = new System.Drawing.Point(6, 127);
            this.btnIngresarCuartel.Name = "btnIngresarCuartel";
            this.btnIngresarCuartel.Size = new System.Drawing.Size(75, 23);
            this.btnIngresarCuartel.TabIndex = 1;
            this.btnIngresarCuartel.Text = "Ingresar";
            this.btnIngresarCuartel.UseVisualStyleBackColor = true;
            this.btnIngresarCuartel.Click += new System.EventHandler(this.btnIngresarCuartel_Click);
            // 
            // textDescripcionCuartel
            // 
            this.textDescripcionCuartel.Location = new System.Drawing.Point(6, 81);
            this.textDescripcionCuartel.Multiline = true;
            this.textDescripcionCuartel.Name = "textDescripcionCuartel";
            this.textDescripcionCuartel.Size = new System.Drawing.Size(440, 40);
            this.textDescripcionCuartel.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Descripción Destrozo:";
            // 
            // textCuartel
            // 
            this.textCuartel.Location = new System.Drawing.Point(6, 32);
            this.textCuartel.Name = "textCuartel";
            this.textCuartel.Size = new System.Drawing.Size(440, 20);
            this.textCuartel.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Cuartel:";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(389, 177);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // DestrozoEnCuartel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 206);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.groupDestrozoCuartel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DestrozoEnCuartel";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Destrozo En Cuartel";
            this.groupDestrozoCuartel.ResumeLayout(false);
            this.groupDestrozoCuartel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupDestrozoCuartel;
        private System.Windows.Forms.Button btnIngresarCuartel;
        private System.Windows.Forms.TextBox textDescripcionCuartel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textCuartel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCerrar;
    }
}