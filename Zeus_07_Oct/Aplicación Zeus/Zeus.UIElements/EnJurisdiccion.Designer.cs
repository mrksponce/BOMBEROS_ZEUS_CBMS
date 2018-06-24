namespace Zeus.UIElements
{
    partial class EnJurisdiccion
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.radio617r = new System.Windows.Forms.RadioButton();
            this.radio617v = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Location = new System.Drawing.Point(12, 65);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.Location = new System.Drawing.Point(116, 65);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Cancelar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // radio617r
            // 
            this.radio617r.Appearance = System.Windows.Forms.Appearance.Button;
            this.radio617r.BackColor = System.Drawing.Color.Salmon;
            this.radio617r.Location = new System.Drawing.Point(12, 13);
            this.radio617r.Name = "radio617r";
            this.radio617r.Size = new System.Drawing.Size(75, 24);
            this.radio617r.TabIndex = 4;
            this.radio617r.TabStop = true;
            this.radio617r.Text = "6-17";
            this.radio617r.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radio617r.UseVisualStyleBackColor = false;
            // 
            // radio617v
            // 
            this.radio617v.Appearance = System.Windows.Forms.Appearance.Button;
            this.radio617v.BackColor = System.Drawing.Color.LightGreen;
            this.radio617v.Location = new System.Drawing.Point(116, 13);
            this.radio617v.Name = "radio617v";
            this.radio617v.Size = new System.Drawing.Size(77, 24);
            this.radio617v.TabIndex = 5;
            this.radio617v.TabStop = true;
            this.radio617v.Text = "6-17";
            this.radio617v.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radio617v.UseVisualStyleBackColor = false;
            // 
            // EnJurisdiccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(205, 100);
            this.Controls.Add(this.radio617v);
            this.Controls.Add(this.radio617r);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnAceptar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnJurisdiccion";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "6-17";
            this.Load += new System.EventHandler(this.EnJurisdiccion_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.RadioButton radio617r;
        private System.Windows.Forms.RadioButton radio617v;
    }
}