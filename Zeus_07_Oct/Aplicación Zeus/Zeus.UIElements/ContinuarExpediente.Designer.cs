namespace Zeus.UIElements
{
    partial class ContinuarExpediente
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridExpedientes = new System.Windows.Forms.DataGridView();
            this.id_expediente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.servicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seis2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cero5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.puntoX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.puntoY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clave_dir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_operadora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textContraseña = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridExpedientes)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridExpedientes);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(703, 228);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione Expediente Activo";
            // 
            // dataGridExpedientes
            // 
            this.dataGridExpedientes.AllowUserToAddRows = false;
            this.dataGridExpedientes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridExpedientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridExpedientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridExpedientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridExpedientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_expediente,
            this.servicio,
            this.seis2,
            this.cero5,
            this.puntoX,
            this.puntoY,
            this.fecha,
            this.hora,
            this.login,
            this.clave,
            this.clave_dir,
            this.id_operadora});
            this.dataGridExpedientes.Location = new System.Drawing.Point(6, 19);
            this.dataGridExpedientes.Name = "dataGridExpedientes";
            this.dataGridExpedientes.ReadOnly = true;
            this.dataGridExpedientes.RowHeadersVisible = false;
            this.dataGridExpedientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridExpedientes.Size = new System.Drawing.Size(691, 203);
            this.dataGridExpedientes.TabIndex = 2;
            // 
            // id_expediente
            // 
            this.id_expediente.DataPropertyName = "id_expediente";
            this.id_expediente.HeaderText = "id_expediente";
            this.id_expediente.Name = "id_expediente";
            this.id_expediente.ReadOnly = true;
            this.id_expediente.Visible = false;
            // 
            // servicio
            // 
            this.servicio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.servicio.DataPropertyName = "servicio";
            this.servicio.HeaderText = "Servicio";
            this.servicio.MinimumWidth = 50;
            this.servicio.Name = "servicio";
            this.servicio.ReadOnly = true;
            // 
            // seis2
            // 
            this.seis2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.seis2.DataPropertyName = "seis2";
            this.seis2.HeaderText = "6-2";
            this.seis2.Name = "seis2";
            this.seis2.ReadOnly = true;
            this.seis2.Width = 48;
            // 
            // cero5
            // 
            this.cero5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cero5.DataPropertyName = "cero5";
            this.cero5.HeaderText = "0-5";
            this.cero5.Name = "cero5";
            this.cero5.ReadOnly = true;
            // 
            // puntoX
            // 
            this.puntoX.DataPropertyName = "puntoX";
            this.puntoX.HeaderText = "puntoX";
            this.puntoX.Name = "puntoX";
            this.puntoX.ReadOnly = true;
            this.puntoX.Visible = false;
            // 
            // puntoY
            // 
            this.puntoY.DataPropertyName = "puntoY";
            this.puntoY.HeaderText = "puntoY";
            this.puntoY.Name = "puntoY";
            this.puntoY.ReadOnly = true;
            this.puntoY.Visible = false;
            // 
            // fecha
            // 
            this.fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fecha.DataPropertyName = "fecha";
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Width = 61;
            // 
            // hora
            // 
            this.hora.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.hora.DataPropertyName = "hora";
            dataGridViewCellStyle2.Format = "t";
            dataGridViewCellStyle2.NullValue = null;
            this.hora.DefaultCellStyle = dataGridViewCellStyle2;
            this.hora.HeaderText = "Hora";
            this.hora.Name = "hora";
            this.hora.ReadOnly = true;
            this.hora.Width = 55;
            // 
            // login
            // 
            this.login.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.login.DataPropertyName = "login";
            this.login.HeaderText = "Asignado A";
            this.login.Name = "login";
            this.login.ReadOnly = true;
            this.login.Width = 86;
            // 
            // clave
            // 
            this.clave.DataPropertyName = "clave";
            this.clave.HeaderText = "clave";
            this.clave.Name = "clave";
            this.clave.ReadOnly = true;
            this.clave.Visible = false;
            // 
            // clave_dir
            // 
            this.clave_dir.DataPropertyName = "clave_dir";
            this.clave_dir.HeaderText = "clave_dir";
            this.clave_dir.Name = "clave_dir";
            this.clave_dir.ReadOnly = true;
            this.clave_dir.Visible = false;
            // 
            // id_operadora
            // 
            this.id_operadora.DataPropertyName = "id_operadora";
            this.id_operadora.HeaderText = "id_operadora";
            this.id_operadora.Name = "id_operadora";
            this.id_operadora.ReadOnly = true;
            this.id_operadora.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textContraseña);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnAceptar);
            this.groupBox2.Location = new System.Drawing.Point(12, 246);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(703, 51);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Autenticación Usuario que se Retira";
            // 
            // textContraseña
            // 
            this.textContraseña.Location = new System.Drawing.Point(114, 19);
            this.textContraseña.Name = "textContraseña";
            this.textContraseña.Size = new System.Drawing.Size(213, 21);
            this.textContraseña.TabIndex = 2;
            this.textContraseña.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ingrese contraseña:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(622, 18);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(12, 303);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // ContinuarExpediente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 337);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ContinuarExpediente";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Continuar Expediente";
            this.Load += new System.EventHandler(this.ContinuarExpediente_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridExpedientes)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridExpedientes;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_expediente;
        private System.Windows.Forms.DataGridViewTextBoxColumn servicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn seis2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cero5;
        private System.Windows.Forms.DataGridViewTextBoxColumn puntoX;
        private System.Windows.Forms.DataGridViewTextBoxColumn puntoY;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn login;
        private System.Windows.Forms.DataGridViewTextBoxColumn clave;
        private System.Windows.Forms.DataGridViewTextBoxColumn clave_dir;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_operadora;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.TextBox textContraseña;
        private System.Windows.Forms.Label label1;
    }
}