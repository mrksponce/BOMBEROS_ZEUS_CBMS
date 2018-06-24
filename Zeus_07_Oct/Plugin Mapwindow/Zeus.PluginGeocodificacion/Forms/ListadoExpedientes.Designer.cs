namespace Zeus.PluginGeocodificacion.Forms
{
    partial class ListadoExpedientes
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
            this.dgExpedientes = new System.Windows.Forms.DataGridView();
            this.id_expediente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cero5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.bEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.puntoX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.puntoY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo_llamado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnMapa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgExpedientes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgExpedientes
            // 
            this.dgExpedientes.AllowUserToAddRows = false;
            this.dgExpedientes.AllowUserToDeleteRows = false;
            this.dgExpedientes.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgExpedientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgExpedientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_expediente,
            this.Column1,
            this.Column2,
            this.cero5,
            this.Fecha,
            this.Hora,
            this.bEditar,
            this.bEliminar,
            this.puntoX,
            this.puntoY,
            this.codigo_llamado});
            this.dgExpedientes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgExpedientes.Location = new System.Drawing.Point(12, 12);
            this.dgExpedientes.MultiSelect = false;
            this.dgExpedientes.Name = "dgExpedientes";
            this.dgExpedientes.ReadOnly = true;
            this.dgExpedientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgExpedientes.Size = new System.Drawing.Size(770, 314);
            this.dgExpedientes.TabIndex = 0;
            this.dgExpedientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgExpedientes_CellContentClick);
            // 
            // id_expediente
            // 
            this.id_expediente.DataPropertyName = "id_expediente";
            this.id_expediente.HeaderText = "id_expediente";
            this.id_expediente.Name = "id_expediente";
            this.id_expediente.ReadOnly = true;
            this.id_expediente.Visible = false;
            this.id_expediente.Width = 150;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "servicio";
            this.Column1.HeaderText = "Servicio";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "seis2";
            this.Column2.HeaderText = "6-2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 250;
            // 
            // cero5
            // 
            this.cero5.DataPropertyName = "cero5";
            this.cero5.HeaderText = "0-5";
            this.cero5.Name = "cero5";
            this.cero5.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "fecha";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle1;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // Hora
            // 
            this.Hora.DataPropertyName = "hora";
            dataGridViewCellStyle2.Format = "t";
            dataGridViewCellStyle2.NullValue = null;
            this.Hora.DefaultCellStyle = dataGridViewCellStyle2;
            this.Hora.HeaderText = "Hora";
            this.Hora.Name = "Hora";
            this.Hora.ReadOnly = true;
            this.Hora.Width = 50;
            // 
            // bEditar
            // 
            this.bEditar.HeaderText = "";
            this.bEditar.Name = "bEditar";
            this.bEditar.ReadOnly = true;
            this.bEditar.Text = "Editar";
            this.bEditar.UseColumnTextForButtonValue = true;
            this.bEditar.Width = 80;
            // 
            // bEliminar
            // 
            this.bEliminar.HeaderText = "";
            this.bEliminar.Name = "bEliminar";
            this.bEliminar.ReadOnly = true;
            this.bEliminar.Text = "Eliminar";
            this.bEliminar.UseColumnTextForButtonValue = true;
            this.bEliminar.Width = 80;
            // 
            // puntoX
            // 
            this.puntoX.DataPropertyName = "puntoX";
            this.puntoX.HeaderText = "Column3";
            this.puntoX.Name = "puntoX";
            this.puntoX.ReadOnly = true;
            this.puntoX.Visible = false;
            // 
            // puntoY
            // 
            this.puntoY.DataPropertyName = "puntoY";
            this.puntoY.HeaderText = "Column4";
            this.puntoY.Name = "puntoY";
            this.puntoY.ReadOnly = true;
            this.puntoY.Visible = false;
            // 
            // codigo_llamado
            // 
            this.codigo_llamado.DataPropertyName = "codigo_llamado";
            this.codigo_llamado.HeaderText = "Column3";
            this.codigo_llamado.Name = "codigo_llamado";
            this.codigo_llamado.ReadOnly = true;
            this.codigo_llamado.Visible = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(612, 332);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(170, 23);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnMapa
            // 
            this.btnMapa.Location = new System.Drawing.Point(12, 332);
            this.btnMapa.Name = "btnMapa";
            this.btnMapa.Size = new System.Drawing.Size(170, 23);
            this.btnMapa.TabIndex = 2;
            this.btnMapa.Text = "Mostrar en Mapa";
            this.btnMapa.UseVisualStyleBackColor = true;
            this.btnMapa.Click += new System.EventHandler(this.btnMapa_Click);
            // 
            // ListadoExpedientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 362);
            this.Controls.Add(this.btnMapa);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dgExpedientes);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "ListadoExpedientes";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Listado de Expedientes";
            this.Load += new System.EventHandler(this.ListadoExpedientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgExpedientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgExpedientes;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnMapa;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_expediente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cero5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
        private System.Windows.Forms.DataGridViewButtonColumn bEditar;
        private System.Windows.Forms.DataGridViewButtonColumn bEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn puntoX;
        private System.Windows.Forms.DataGridViewTextBoxColumn puntoY;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_llamado;
    }
}