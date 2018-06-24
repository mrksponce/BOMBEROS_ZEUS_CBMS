namespace AgendaDepartamentos
{
    partial class AgendaDepartamentosAdminForm
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
            this.btnActualizarDepto = new System.Windows.Forms.Button();
            this.btnEliminarDepto = new System.Windows.Forms.Button();
            this.btnNuevoDepto = new System.Windows.Forms.Button();
            this.textNombreDepto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listDeptos = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnActualizarDetalle = new System.Windows.Forms.Button();
            this.btnEliminarDetalle = new System.Windows.Forms.Button();
            this.btnNuevoDetalle = new System.Windows.Forms.Button();
            this.textFonoMovil = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textFonoFijo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textCodigo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textCargo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textNombreDet = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listDetalle = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnActualizarDepto);
            this.groupBox1.Controls.Add(this.btnEliminarDepto);
            this.groupBox1.Controls.Add(this.btnNuevoDepto);
            this.groupBox1.Controls.Add(this.textNombreDepto);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.listDeptos);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 195);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Departamentos";
            // 
            // btnActualizarDepto
            // 
            this.btnActualizarDepto.Location = new System.Drawing.Point(160, 166);
            this.btnActualizarDepto.Name = "btnActualizarDepto";
            this.btnActualizarDepto.Size = new System.Drawing.Size(75, 23);
            this.btnActualizarDepto.TabIndex = 6;
            this.btnActualizarDepto.Text = "Actualizar";
            this.btnActualizarDepto.UseVisualStyleBackColor = true;
            this.btnActualizarDepto.Click += new System.EventHandler(this.btnActualizarDepto_Click);
            // 
            // btnEliminarDepto
            // 
            this.btnEliminarDepto.Location = new System.Drawing.Point(314, 166);
            this.btnEliminarDepto.Name = "btnEliminarDepto";
            this.btnEliminarDepto.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarDepto.TabIndex = 5;
            this.btnEliminarDepto.Text = "Eliminar";
            this.btnEliminarDepto.UseVisualStyleBackColor = true;
            this.btnEliminarDepto.Click += new System.EventHandler(this.btnEliminarDepto_Click);
            // 
            // btnNuevoDepto
            // 
            this.btnNuevoDepto.Location = new System.Drawing.Point(9, 166);
            this.btnNuevoDepto.Name = "btnNuevoDepto";
            this.btnNuevoDepto.Size = new System.Drawing.Size(75, 23);
            this.btnNuevoDepto.TabIndex = 4;
            this.btnNuevoDepto.Text = "Nuevo";
            this.btnNuevoDepto.UseVisualStyleBackColor = true;
            this.btnNuevoDepto.Click += new System.EventHandler(this.btnNuevoDepto_Click);
            // 
            // textNombreDepto
            // 
            this.textNombreDepto.Location = new System.Drawing.Point(59, 126);
            this.textNombreDepto.Name = "textNombreDepto";
            this.textNombreDepto.Size = new System.Drawing.Size(330, 20);
            this.textNombreDepto.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Departamentos Actuales:";
            // 
            // listDeptos
            // 
            this.listDeptos.FormattingEnabled = true;
            this.listDeptos.Location = new System.Drawing.Point(6, 32);
            this.listDeptos.Name = "listDeptos";
            this.listDeptos.Size = new System.Drawing.Size(383, 82);
            this.listDeptos.TabIndex = 0;
            this.listDeptos.SelectedIndexChanged += new System.EventHandler(this.listDeptos_SelectedIndexChanged);
            this.listDeptos.DataSourceChanged += new System.EventHandler(this.listDeptos_DataSourceChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnActualizarDetalle);
            this.groupBox2.Controls.Add(this.btnEliminarDetalle);
            this.groupBox2.Controls.Add(this.btnNuevoDetalle);
            this.groupBox2.Controls.Add(this.textFonoMovil);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textFonoFijo);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textCodigo);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textCargo);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textNombreDet);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.listDetalle);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 213);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(395, 263);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalle";
            // 
            // btnActualizarDetalle
            // 
            this.btnActualizarDetalle.Location = new System.Drawing.Point(160, 228);
            this.btnActualizarDetalle.Name = "btnActualizarDetalle";
            this.btnActualizarDetalle.Size = new System.Drawing.Size(75, 23);
            this.btnActualizarDetalle.TabIndex = 14;
            this.btnActualizarDetalle.Text = "Actualizar";
            this.btnActualizarDetalle.UseVisualStyleBackColor = true;
            this.btnActualizarDetalle.Click += new System.EventHandler(this.btnActualizarDetalle_Click);
            // 
            // btnEliminarDetalle
            // 
            this.btnEliminarDetalle.Location = new System.Drawing.Point(314, 228);
            this.btnEliminarDetalle.Name = "btnEliminarDetalle";
            this.btnEliminarDetalle.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarDetalle.TabIndex = 13;
            this.btnEliminarDetalle.Text = "Eliminar";
            this.btnEliminarDetalle.UseVisualStyleBackColor = true;
            this.btnEliminarDetalle.Click += new System.EventHandler(this.btnEliminarDetalle_Click);
            // 
            // btnNuevoDetalle
            // 
            this.btnNuevoDetalle.Location = new System.Drawing.Point(9, 228);
            this.btnNuevoDetalle.Name = "btnNuevoDetalle";
            this.btnNuevoDetalle.Size = new System.Drawing.Size(75, 23);
            this.btnNuevoDetalle.TabIndex = 12;
            this.btnNuevoDetalle.Text = "Nuevo";
            this.btnNuevoDetalle.UseVisualStyleBackColor = true;
            this.btnNuevoDetalle.Click += new System.EventHandler(this.btnNuevoDetalle_Click);
            // 
            // textFonoMovil
            // 
            this.textFonoMovil.Location = new System.Drawing.Point(261, 202);
            this.textFonoMovil.Name = "textFonoMovil";
            this.textFonoMovil.Size = new System.Drawing.Size(128, 20);
            this.textFonoMovil.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(196, 205);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Fono Móvil:";
            // 
            // textFonoFijo
            // 
            this.textFonoFijo.Location = new System.Drawing.Point(59, 202);
            this.textFonoFijo.Name = "textFonoFijo";
            this.textFonoFijo.Size = new System.Drawing.Size(128, 20);
            this.textFonoFijo.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Fono Fijo:";
            // 
            // textCodigo
            // 
            this.textCodigo.Location = new System.Drawing.Point(59, 176);
            this.textCodigo.Name = "textCodigo";
            this.textCodigo.Size = new System.Drawing.Size(330, 20);
            this.textCodigo.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Código:";
            // 
            // textCargo
            // 
            this.textCargo.Location = new System.Drawing.Point(59, 150);
            this.textCargo.Name = "textCargo";
            this.textCargo.Size = new System.Drawing.Size(330, 20);
            this.textCargo.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Cargo:";
            // 
            // textNombreDet
            // 
            this.textNombreDet.Location = new System.Drawing.Point(59, 124);
            this.textNombreDet.Name = "textNombreDet";
            this.textNombreDet.Size = new System.Drawing.Size(330, 20);
            this.textNombreDet.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Nombre:";
            // 
            // listDetalle
            // 
            this.listDetalle.DisplayMember = "nombre";
            this.listDetalle.FormattingEnabled = true;
            this.listDetalle.Location = new System.Drawing.Point(6, 32);
            this.listDetalle.Name = "listDetalle";
            this.listDetalle.Size = new System.Drawing.Size(383, 82);
            this.listDetalle.TabIndex = 1;
            this.listDetalle.ValueMember = "id_detalle";
            this.listDetalle.SelectedIndexChanged += new System.EventHandler(this.listDetalle_SelectedIndexChanged);
            this.listDetalle.DataSourceChanged += new System.EventHandler(this.listDetalle_DataSourceChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Elementos Actuales:";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(332, 482);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // AgendaDepartamentosAdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 513);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AgendaDepartamentosAdminForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Administración de Agenda Inspectores";
            this.Load += new System.EventHandler(this.AgendaDepartamentosAdminForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnActualizarDepto;
        private System.Windows.Forms.Button btnEliminarDepto;
        private System.Windows.Forms.Button btnNuevoDepto;
        private System.Windows.Forms.TextBox textNombreDepto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listDeptos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnActualizarDetalle;
        private System.Windows.Forms.Button btnEliminarDetalle;
        private System.Windows.Forms.Button btnNuevoDetalle;
        private System.Windows.Forms.TextBox textFonoMovil;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textFonoFijo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textCodigo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textCargo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textNombreDet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listDetalle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCerrar;
    }
}