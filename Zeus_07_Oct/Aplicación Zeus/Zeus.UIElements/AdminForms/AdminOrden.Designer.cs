namespace Zeus.UIElements.AdminForms
{
    partial class AdminOrden
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
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.reorderListBox1 = new Zeus.UIElements.ReorderListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(220, 321);
            this.groupBox1.Text = "Subclaves";
            // 
            // listActuales
            // 
            this.listActuales.Size = new System.Drawing.Size(208, 264);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(-5, 329);
            this.btnNuevo.Visible = false;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(238, 310);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(54, 329);
            this.btnEliminar.Visible = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(423, 310);
            // 
            // textBusqueda
            // 
            this.textBusqueda.Size = new System.Drawing.Size(208, 21);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(238, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Clave Principal:";
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "desc";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(238, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(256, 21);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.ValueMember = "clave";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.reorderListBox1);
            this.groupBox2.Location = new System.Drawing.Point(238, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 237);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Orden de Solicitud";
            // 
            // reorderListBox1
            // 
            this.reorderListBox1.DataSource = null;
            this.reorderListBox1.DisplayMember = null;
            this.reorderListBox1.Location = new System.Drawing.Point(6, 19);
            this.reorderListBox1.Name = "reorderListBox1";
            this.reorderListBox1.ReadOnly = true;
            this.reorderListBox1.Size = new System.Drawing.Size(244, 212);
            this.reorderListBox1.TabIndex = 0;
            this.reorderListBox1.ValueMember = null;
            // 
            // AdminOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 345);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox1);
            this.Name = "AdminOrden";
            this.Text = "Administración Orden de Solicitud de Carros";
            this.Load += new System.EventHandler(this.AdminOrden_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnActualizar, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.Controls.SetChildIndex(this.comboBox1, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private UIElements.ReorderListBox reorderListBox1;

    }
}