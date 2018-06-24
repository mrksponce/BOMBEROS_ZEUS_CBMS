namespace Zeus.UIElements
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
            this.dg_EntregaTurno = new System.Windows.Forms.DataGridView();
            this.maquina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conductor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dg_EntregaTurno)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_EntregaTurno
            // 
            this.dg_EntregaTurno.AllowUserToAddRows = false;
            this.dg_EntregaTurno.AllowUserToDeleteRows = false;
            this.dg_EntregaTurno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_EntregaTurno.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maquina,
            this.estado,
            this.codigo,
            this.conductor,
            this.observacion});
            this.dg_EntregaTurno.Location = new System.Drawing.Point(12, 36);
            this.dg_EntregaTurno.Name = "dg_EntregaTurno";
            this.dg_EntregaTurno.ReadOnly = true;
            this.dg_EntregaTurno.Size = new System.Drawing.Size(1057, 460);
            this.dg_EntregaTurno.TabIndex = 0;
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
            this.observacion.Width = 330;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(915, 514);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Exportar a PDF";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(860, 516);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(49, 20);
            this.textBox1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(782, 520);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Operadora Nº";
            // 
            // EntregaDeTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 560);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dg_EntregaTurno);
            this.Name = "EntregaDeTurno";
            this.Text = "EntregaDeTurno";
            this.Load += new System.EventHandler(this.EntregaDeTurno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_EntregaTurno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_EntregaTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn maquina;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn conductor;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}