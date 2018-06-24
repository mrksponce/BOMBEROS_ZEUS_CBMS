namespace Zeus.UIElements.AdminForms
{
    partial class AdminOficiales
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
            this.comboCargos = new System.Windows.Forms.ComboBox();
            this.btnOrden = new System.Windows.Forms.Button();
            this.textLlamado = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textVoluntarios = new System.Windows.Forms.TextBox();
            this.listNombres = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(276, 311);
            this.groupBox1.Text = "Oficiales Actuales";
            // 
            // listActuales
            // 
            this.listActuales.Size = new System.Drawing.Size(264, 264);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(294, 300);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(375, 300);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(456, 300);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(618, 300);
            // 
            // textBusqueda
            // 
            this.textBusqueda.Size = new System.Drawing.Size(264, 21);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboCargos);
            this.groupBox2.Controls.Add(this.btnOrden);
            this.groupBox2.Controls.Add(this.textLlamado);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textVoluntarios);
            this.groupBox2.Controls.Add(this.listNombres);
            this.groupBox2.Location = new System.Drawing.Point(294, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(397, 258);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Información Oficial";
            // 
            // comboCargos
            // 
            this.comboCargos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCargos.FormattingEnabled = true;
            this.comboCargos.Location = new System.Drawing.Point(104, 153);
            this.comboCargos.Name = "comboCargos";
            this.comboCargos.Size = new System.Drawing.Size(186, 21);
            this.comboCargos.TabIndex = 13;
            // 
            // btnOrden
            // 
            this.btnOrden.Location = new System.Drawing.Point(296, 213);
            this.btnOrden.Name = "btnOrden";
            this.btnOrden.Size = new System.Drawing.Size(95, 23);
            this.btnOrden.TabIndex = 12;
            this.btnOrden.Text = "Definir Orden...";
            this.btnOrden.UseVisualStyleBackColor = true;
            this.btnOrden.Click += new System.EventHandler(this.btnOrden_Click);
            // 
            // textLlamado
            // 
            this.textLlamado.Location = new System.Drawing.Point(160, 215);
            this.textLlamado.Name = "textLlamado";
            this.textLlamado.Size = new System.Drawing.Size(130, 21);
            this.textLlamado.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Número de Llamado:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Grado:";
            // 
            // textVoluntarios
            // 
            this.textVoluntarios.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textVoluntarios.Location = new System.Drawing.Point(6, 20);
            this.textVoluntarios.Name = "textVoluntarios";
            this.textVoluntarios.Size = new System.Drawing.Size(284, 22);
            this.textVoluntarios.TabIndex = 4;
            this.textVoluntarios.TextChanged += new System.EventHandler(this.textVoluntarios_TextChanged);
            // 
            // listNombres
            // 
            this.listNombres.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listNombres.FormattingEnabled = true;
            this.listNombres.ItemHeight = 14;
            this.listNombres.Location = new System.Drawing.Point(6, 48);
            this.listNombres.Name = "listNombres";
            this.listNombres.Size = new System.Drawing.Size(284, 88);
            this.listNombres.TabIndex = 5;
            this.listNombres.SelectedIndexChanged += new System.EventHandler(this.listVoluntarios_SelectedIndexChanged);
            // 
            // AdminOficiales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 335);
            this.Controls.Add(this.groupBox2);
            this.Name = "AdminOficiales";
            this.Text = "Administración de Oficiales";
            this.Load += new System.EventHandler(this.AdminOficiales_Load);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.btnActualizar, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textLlamado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textVoluntarios;
        private System.Windows.Forms.ListBox listNombres;
        private System.Windows.Forms.Button btnOrden;
        private System.Windows.Forms.ComboBox comboCargos;
    }
}