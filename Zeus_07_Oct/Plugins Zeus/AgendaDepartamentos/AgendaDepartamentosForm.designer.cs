namespace AgendaDepartamentos
{
    partial class AgendaDepartamentosForm
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
            this.comboDepartamento = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.dataOficiales = new System.Windows.Forms.DataGridView();
            this.Oficial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_detalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_departamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fono_fijo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fono_movil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataOficiales)).BeginInit();
            this.SuspendLayout();
            // 
            // comboDepartamento
            // 
            this.comboDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDepartamento.FormattingEnabled = true;
            this.comboDepartamento.Location = new System.Drawing.Point(12, 25);
            this.comboDepartamento.Name = "comboDepartamento";
            this.comboDepartamento.Size = new System.Drawing.Size(360, 21);
            this.comboDepartamento.TabIndex = 1;
            this.comboDepartamento.SelectedIndexChanged += new System.EventHandler(this.comboDepartamento_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Departamento:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Oficiales:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDetalle);
            this.groupBox1.Location = new System.Drawing.Point(12, 198);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 101);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // lblDetalle
            // 
            this.lblDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDetalle.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalle.ForeColor = System.Drawing.Color.Red;
            this.lblDetalle.Location = new System.Drawing.Point(3, 17);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(354, 81);
            this.lblDetalle.TabIndex = 0;
            this.lblDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(155, 305);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 10;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dataOficiales
            // 
            this.dataOficiales.AllowUserToAddRows = false;
            this.dataOficiales.AllowUserToDeleteRows = false;
            this.dataOficiales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataOficiales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Oficial,
            this.Codigo,
            this.id_detalle,
            this.id_departamento,
            this.nombre,
            this.fono_fijo,
            this.fono_movil});
            this.dataOficiales.Location = new System.Drawing.Point(12, 78);
            this.dataOficiales.MultiSelect = false;
            this.dataOficiales.Name = "dataOficiales";
            this.dataOficiales.ReadOnly = true;
            this.dataOficiales.RowHeadersVisible = false;
            this.dataOficiales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataOficiales.Size = new System.Drawing.Size(360, 114);
            this.dataOficiales.TabIndex = 11;
            this.dataOficiales.SelectionChanged += new System.EventHandler(this.dataOficiales_SelectionChanged);
            // 
            // Oficial
            // 
            this.Oficial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Oficial.DataPropertyName = "cargo";
            this.Oficial.HeaderText = "Oficial";
            this.Oficial.Name = "Oficial";
            this.Oficial.ReadOnly = true;
            this.Oficial.Width = 61;
            // 
            // Codigo
            // 
            this.Codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Codigo.DataPropertyName = "codigo";
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // id_detalle
            // 
            this.id_detalle.DataPropertyName = "id_detalle";
            this.id_detalle.HeaderText = "id_detalle";
            this.id_detalle.Name = "id_detalle";
            this.id_detalle.ReadOnly = true;
            this.id_detalle.Visible = false;
            // 
            // id_departamento
            // 
            this.id_departamento.DataPropertyName = "id_departamento";
            this.id_departamento.HeaderText = "id_departamento";
            this.id_departamento.Name = "id_departamento";
            this.id_departamento.ReadOnly = true;
            this.id_departamento.Visible = false;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Visible = false;
            // 
            // fono_fijo
            // 
            this.fono_fijo.DataPropertyName = "fono_fijo";
            this.fono_fijo.HeaderText = "fono_fijo";
            this.fono_fijo.Name = "fono_fijo";
            this.fono_fijo.ReadOnly = true;
            this.fono_fijo.Visible = false;
            // 
            // fono_movil
            // 
            this.fono_movil.DataPropertyName = "fono_movil";
            this.fono_movil.HeaderText = "fono_movil";
            this.fono_movil.Name = "fono_movil";
            this.fono_movil.ReadOnly = true;
            this.fono_movil.Visible = false;
            // 
            // AgendaDepartamentosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 340);
            this.Controls.Add(this.dataOficiales);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboDepartamento);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AgendaDepartamentosForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Agenda Inspectores";
            this.Load += new System.EventHandler(this.AgendaDepartamentosForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataOficiales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboDepartamento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dataOficiales;
        private System.Windows.Forms.DataGridViewTextBoxColumn Oficial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_detalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_departamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn fono_fijo;
        private System.Windows.Forms.DataGridViewTextBoxColumn fono_movil;
    }
}