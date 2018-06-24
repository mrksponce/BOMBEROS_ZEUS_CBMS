namespace Zeus.UIElements.AdminForms
{
    partial class AdminGuardia
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
            this.label1 = new System.Windows.Forms.Label();
            this.textTipoOficial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textResponsabilidades = new System.Windows.Forms.TextBox();
            this.checkMostrar = new System.Windows.Forms.CheckBox();
            this.textOficial = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(223, 259);
            this.groupBox1.Text = "Oficiales de Guardia Actuales";
            // 
            // listActuales
            // 
            this.listActuales.Size = new System.Drawing.Size(211, 225);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(244, 248);
            this.btnNuevo.TabIndex = 3;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(325, 248);
            this.btnActualizar.TabIndex = 4;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(406, 248);
            this.btnEliminar.TabIndex = 5;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(500, 248);
            this.btnCerrar.TabIndex = 6;
            // 
            // textBusqueda
            // 
            this.textBusqueda.Size = new System.Drawing.Size(211, 21);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(241, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tipo Oficial:";
            // 
            // textTipoOficial
            // 
            this.textTipoOficial.Location = new System.Drawing.Point(244, 47);
            this.textTipoOficial.Name = "textTipoOficial";
            this.textTipoOficial.Size = new System.Drawing.Size(331, 21);
            this.textTipoOficial.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Responsabilidades:";
            // 
            // textResponsabilidades
            // 
            this.textResponsabilidades.Location = new System.Drawing.Point(244, 131);
            this.textResponsabilidades.Multiline = true;
            this.textResponsabilidades.Name = "textResponsabilidades";
            this.textResponsabilidades.Size = new System.Drawing.Size(331, 64);
            this.textResponsabilidades.TabIndex = 2;
            // 
            // checkMostrar
            // 
            this.checkMostrar.AutoSize = true;
            this.checkMostrar.Location = new System.Drawing.Point(244, 201);
            this.checkMostrar.Name = "checkMostrar";
            this.checkMostrar.Size = new System.Drawing.Size(63, 17);
            this.checkMostrar.TabIndex = 9;
            this.checkMostrar.Text = "Mostrar";
            this.checkMostrar.UseVisualStyleBackColor = true;
            // 
            // textOficial
            // 
            this.textOficial.Location = new System.Drawing.Point(244, 86);
            this.textOficial.Name = "textOficial";
            this.textOficial.Size = new System.Drawing.Size(331, 21);
            this.textOficial.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(241, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Oficial:";
            // 
            // AdminGuardia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 283);
            this.Controls.Add(this.textOficial);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textTipoOficial);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textResponsabilidades);
            this.Controls.Add(this.checkMostrar);
            this.Controls.Add(this.label2);
            this.Name = "AdminGuardia";
            this.Text = "Administración Oficiales de Guardia";
            this.Load += new System.EventHandler(this.AdminGuardia_Load);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.checkMostrar, 0);
            this.Controls.SetChildIndex(this.textResponsabilidades, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnActualizar, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.textTipoOficial, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.textOficial, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textTipoOficial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textResponsabilidades;
        private System.Windows.Forms.CheckBox checkMostrar;
        private System.Windows.Forms.TextBox textOficial;
        private System.Windows.Forms.Label label3;
    }
}