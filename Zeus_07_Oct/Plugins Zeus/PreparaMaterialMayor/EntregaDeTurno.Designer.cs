
//namespace Zeus.UIElements
namespace PreparaMaterialMayor
{
    partial class EntregaDeTurno
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dg_EntregaTurno = new System.Windows.Forms.DataGridView();
            this.maquina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conductor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_AgregaCarro = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txb_Observacion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_Conductores = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_Estado = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_Material = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_Compania = new System.Windows.Forms.ComboBox();
            this.btn_AsignacionMasiva = new System.Windows.Forms.Button();
            this.btn_Cerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg_EntregaTurno)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dg_EntregaTurno
            // 
            this.dg_EntregaTurno.AllowUserToAddRows = false;
            this.dg_EntregaTurno.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_EntregaTurno.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_EntregaTurno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_EntregaTurno.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maquina,
            this.estado,
            this.codigo,
            this.conductor,
            this.observacion});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_EntregaTurno.DefaultCellStyle = dataGridViewCellStyle2;
            this.dg_EntregaTurno.Location = new System.Drawing.Point(12, 119);
            this.dg_EntregaTurno.Name = "dg_EntregaTurno";
            this.dg_EntregaTurno.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_EntregaTurno.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dg_EntregaTurno.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_EntregaTurno.Size = new System.Drawing.Size(1207, 338);
            this.dg_EntregaTurno.TabIndex = 0;
            this.dg_EntregaTurno.Click += new System.EventHandler(this.dg_EntregaTurno_Click);
            // 
            // maquina
            // 
            this.maquina.HeaderText = "Maquina";
            this.maquina.Name = "maquina";
            this.maquina.ReadOnly = true;
            this.maquina.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.maquina.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.maquina.Width = 70;
            // 
            // estado
            // 
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            this.estado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.estado.Width = 170;
            // 
            // codigo
            // 
            this.codigo.HeaderText = "Código";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.codigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.codigo.Width = 70;
            // 
            // conductor
            // 
            this.conductor.HeaderText = "Conductor";
            this.conductor.Name = "conductor";
            this.conductor.ReadOnly = true;
            this.conductor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.conductor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.conductor.Width = 300;
            // 
            // observacion
            // 
            this.observacion.HeaderText = "Observación";
            this.observacion.Name = "observacion";
            this.observacion.ReadOnly = true;
            this.observacion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.observacion.Width = 530;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_AgregaCarro);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txb_Observacion);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmb_Conductores);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmb_Estado);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmb_Material);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmb_Compania);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1207, 90);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selección de Material Mayor:";
            // 
            // btn_AgregaCarro
            // 
            this.btn_AgregaCarro.Location = new System.Drawing.Point(1122, 32);
            this.btn_AgregaCarro.Name = "btn_AgregaCarro";
            this.btn_AgregaCarro.Size = new System.Drawing.Size(79, 41);
            this.btn_AgregaCarro.TabIndex = 10;
            this.btn_AgregaCarro.Text = "Agregar";
            this.btn_AgregaCarro.UseVisualStyleBackColor = true;
            this.btn_AgregaCarro.Click += new System.EventHandler(this.btn_AgregaCarro_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(770, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Observación:";
            // 
            // txb_Observacion
            // 
            this.txb_Observacion.Location = new System.Drawing.Point(773, 50);
            this.txb_Observacion.Name = "txb_Observacion";
            this.txb_Observacion.Size = new System.Drawing.Size(331, 22);
            this.txb_Observacion.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(448, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Conductor:";
            // 
            // cmb_Conductores
            // 
            this.cmb_Conductores.FormattingEnabled = true;
            this.cmb_Conductores.Location = new System.Drawing.Point(451, 49);
            this.cmb_Conductores.Name = "cmb_Conductores";
            this.cmb_Conductores.Size = new System.Drawing.Size(297, 24);
            this.cmb_Conductores.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(256, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Estado:";
            // 
            // cmb_Estado
            // 
            this.cmb_Estado.FormattingEnabled = true;
            this.cmb_Estado.Location = new System.Drawing.Point(259, 48);
            this.cmb_Estado.Name = "cmb_Estado";
            this.cmb_Estado.Size = new System.Drawing.Size(171, 24);
            this.cmb_Estado.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Maquina:";
            // 
            // cmb_Material
            // 
            this.cmb_Material.FormattingEnabled = true;
            this.cmb_Material.Location = new System.Drawing.Point(163, 48);
            this.cmb_Material.Name = "cmb_Material";
            this.cmb_Material.Size = new System.Drawing.Size(76, 24);
            this.cmb_Material.TabIndex = 2;
            this.cmb_Material.SelectedIndexChanged += new System.EventHandler(this.cmb_Material_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Compañía:";
            // 
            // cmb_Compania
            // 
            this.cmb_Compania.FormattingEnabled = true;
            this.cmb_Compania.Location = new System.Drawing.Point(19, 48);
            this.cmb_Compania.Name = "cmb_Compania";
            this.cmb_Compania.Size = new System.Drawing.Size(126, 24);
            this.cmb_Compania.TabIndex = 0;
            this.cmb_Compania.SelectedIndexChanged += new System.EventHandler(this.cmb_Compania_SelectedIndexChanged);
            // 
            // btn_AsignacionMasiva
            // 
            this.btn_AsignacionMasiva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_AsignacionMasiva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AsignacionMasiva.Location = new System.Drawing.Point(869, 476);
            this.btn_AsignacionMasiva.Name = "btn_AsignacionMasiva";
            this.btn_AsignacionMasiva.Size = new System.Drawing.Size(226, 27);
            this.btn_AsignacionMasiva.TabIndex = 2;
            this.btn_AsignacionMasiva.Text = "Aplicar Asignación de Conductores";
            this.btn_AsignacionMasiva.UseVisualStyleBackColor = false;
            this.btn_AsignacionMasiva.Click += new System.EventHandler(this.btn_AsignacionMasiva_Click);
            // 
            // btn_Cerrar
            // 
            this.btn_Cerrar.Location = new System.Drawing.Point(1110, 476);
            this.btn_Cerrar.Name = "btn_Cerrar";
            this.btn_Cerrar.Size = new System.Drawing.Size(109, 28);
            this.btn_Cerrar.TabIndex = 3;
            this.btn_Cerrar.Text = "Cerrar";
            this.btn_Cerrar.UseVisualStyleBackColor = true;
            this.btn_Cerrar.Click += new System.EventHandler(this.btn_Cerrar_Click);
            // 
            // EntregaDeTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 515);
            this.Controls.Add(this.btn_Cerrar);
            this.Controls.Add(this.btn_AsignacionMasiva);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dg_EntregaTurno);
            this.Name = "EntregaDeTurno";
            this.Text = "Preparación de Puesta en Servicio para Asignación Masiva";
            this.Load += new System.EventHandler(this.EntregaDeTurno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_EntregaTurno)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_EntregaTurno;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_Compania;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_Conductores;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_Estado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_Material;
        private System.Windows.Forms.Button btn_AgregaCarro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txb_Observacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn maquina;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn conductor;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacion;
        private System.Windows.Forms.Button btn_AsignacionMasiva;
        private System.Windows.Forms.Button btn_Cerrar;
    }
}