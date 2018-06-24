namespace Zeus.UIElements
{
    partial class ucEst
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblEstadoCarro = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDescEstado = new System.Windows.Forms.Label();
            this.lblDesConductor = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_09 = new System.Windows.Forms.Button();
            this.btn_08 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblIngresoOperadora = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbSinConductor = new System.Windows.Forms.RadioButton();
            this.rbLiberarCarro = new System.Windows.Forms.RadioButton();
            this.rbEnServicio = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.txtOtro = new System.Windows.Forms.TextBox();
            this.rbfsOtro = new System.Windows.Forms.RadioButton();
            this.rbfsElectrico = new System.Windows.Forms.RadioButton();
            this.rbfsMecanico = new System.Windows.Forms.RadioButton();
            this.gvDisponible = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbAsignarCarros = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btn_Reporte = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDisponible)).BeginInit();
            this.gbAsignarCarros.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(284, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "RH19";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(8, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(174, 180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblEstadoCarro
            // 
            this.lblEstadoCarro.AutoSize = true;
            this.lblEstadoCarro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoCarro.Location = new System.Drawing.Point(191, 68);
            this.lblEstadoCarro.Name = "lblEstadoCarro";
            this.lblEstadoCarro.Size = new System.Drawing.Size(57, 16);
            this.lblEstadoCarro.TabIndex = 3;
            this.lblEstadoCarro.Text = "Estado: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(191, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Conductor:";
            // 
            // lblDescEstado
            // 
            this.lblDescEstado.AutoSize = true;
            this.lblDescEstado.BackColor = System.Drawing.SystemColors.Control;
            this.lblDescEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescEstado.Location = new System.Drawing.Point(191, 90);
            this.lblDescEstado.Name = "lblDescEstado";
            this.lblDescEstado.Size = new System.Drawing.Size(45, 16);
            this.lblDescEstado.TabIndex = 5;
            this.lblDescEstado.Text = "label3";
            this.lblDescEstado.Click += new System.EventHandler(this.lblDescEstado_Click);
            // 
            // lblDesConductor
            // 
            this.lblDesConductor.AutoSize = true;
            this.lblDesConductor.BackColor = System.Drawing.SystemColors.Control;
            this.lblDesConductor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesConductor.Location = new System.Drawing.Point(191, 147);
            this.lblDesConductor.Name = "lblDesConductor";
            this.lblDesConductor.Size = new System.Drawing.Size(45, 16);
            this.lblDesConductor.TabIndex = 6;
            this.lblDesConductor.Text = "label4";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Reporte);
            this.groupBox1.Controls.Add(this.btn_09);
            this.groupBox1.Controls.Add(this.btn_08);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.lblEstadoCarro);
            this.groupBox1.Controls.Add(this.lblDesConductor);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblDescEstado);
            this.groupBox1.Location = new System.Drawing.Point(1, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 205);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Material Mayor Seleccionado :";
            // 
            // btn_09
            // 
            this.btn_09.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_09.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_09.Location = new System.Drawing.Point(374, 25);
            this.btn_09.Name = "btn_09";
            this.btn_09.Size = new System.Drawing.Size(78, 31);
            this.btn_09.TabIndex = 8;
            this.btn_09.Text = "Twitter 0-9";
            this.btn_09.UseVisualStyleBackColor = false;
            this.btn_09.Click += new System.EventHandler(this.btn_09_Click);
            // 
            // btn_08
            // 
            this.btn_08.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_08.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_08.Location = new System.Drawing.Point(194, 25);
            this.btn_08.Name = "btn_08";
            this.btn_08.Size = new System.Drawing.Size(78, 31);
            this.btn_08.TabIndex = 7;
            this.btn_08.Text = "Twitter 0-8";
            this.btn_08.UseVisualStyleBackColor = false;
            this.btn_08.Click += new System.EventHandler(this.btn_08_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(380, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Grabar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblIngresoOperadora
            // 
            this.lblIngresoOperadora.AutoSize = true;
            this.lblIngresoOperadora.Location = new System.Drawing.Point(85, 23);
            this.lblIngresoOperadora.Name = "lblIngresoOperadora";
            this.lblIngresoOperadora.Size = new System.Drawing.Size(35, 13);
            this.lblIngresoOperadora.TabIndex = 10;
            this.lblIngresoOperadora.Text = "label4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Ingresada por:";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(9, 39);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(365, 20);
            this.txtObservacion.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbSinConductor);
            this.groupBox3.Controls.Add(this.rbLiberarCarro);
            this.groupBox3.Controls.Add(this.rbEnServicio);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.txtOtro);
            this.groupBox3.Controls.Add(this.rbfsOtro);
            this.groupBox3.Controls.Add(this.rbfsElectrico);
            this.groupBox3.Controls.Add(this.rbfsMecanico);
            this.groupBox3.Location = new System.Drawing.Point(1, 316);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(171, 208);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Fuera de Servicio";
            // 
            // rbSinConductor
            // 
            this.rbSinConductor.AutoSize = true;
            this.rbSinConductor.Location = new System.Drawing.Point(8, 62);
            this.rbSinConductor.Name = "rbSinConductor";
            this.rbSinConductor.Size = new System.Drawing.Size(110, 17);
            this.rbSinConductor.TabIndex = 7;
            this.rbSinConductor.TabStop = true;
            this.rbSinConductor.Text = "0-8 Sin Conductor";
            this.rbSinConductor.UseVisualStyleBackColor = true;
            this.rbSinConductor.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // rbLiberarCarro
            // 
            this.rbLiberarCarro.AutoSize = true;
            this.rbLiberarCarro.Location = new System.Drawing.Point(8, 19);
            this.rbLiberarCarro.Name = "rbLiberarCarro";
            this.rbLiberarCarro.Size = new System.Drawing.Size(85, 17);
            this.rbLiberarCarro.TabIndex = 6;
            this.rbLiberarCarro.TabStop = true;
            this.rbLiberarCarro.Text = "Liberar Carro";
            this.rbLiberarCarro.UseVisualStyleBackColor = true;
            // 
            // rbEnServicio
            // 
            this.rbEnServicio.AutoSize = true;
            this.rbEnServicio.Location = new System.Drawing.Point(8, 40);
            this.rbEnServicio.Name = "rbEnServicio";
            this.rbEnServicio.Size = new System.Drawing.Size(97, 17);
            this.rbEnServicio.TabIndex = 5;
            this.rbEnServicio.TabStop = true;
            this.rbEnServicio.Text = "0-9 En Servicio";
            this.rbEnServicio.UseVisualStyleBackColor = true;
            this.rbEnServicio.CheckedChanged += new System.EventHandler(this.rbEnServicio_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(90, 179);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Grabar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtOtro
            // 
            this.txtOtro.Location = new System.Drawing.Point(8, 154);
            this.txtOtro.Name = "txtOtro";
            this.txtOtro.Size = new System.Drawing.Size(157, 20);
            this.txtOtro.TabIndex = 3;
            // 
            // rbfsOtro
            // 
            this.rbfsOtro.AutoSize = true;
            this.rbfsOtro.Location = new System.Drawing.Point(8, 132);
            this.rbfsOtro.Name = "rbfsOtro";
            this.rbfsOtro.Size = new System.Drawing.Size(119, 17);
            this.rbfsOtro.TabIndex = 2;
            this.rbfsOtro.TabStop = true;
            this.rbfsOtro.Text = "0-8 F. Servicio: Otro";
            this.rbfsOtro.UseVisualStyleBackColor = true;
            this.rbfsOtro.CheckedChanged += new System.EventHandler(this.rbfsOtro_CheckedChanged);
            // 
            // rbfsElectrico
            // 
            this.rbfsElectrico.AutoSize = true;
            this.rbfsElectrico.Location = new System.Drawing.Point(8, 104);
            this.rbfsElectrico.Name = "rbfsElectrico";
            this.rbfsElectrico.Size = new System.Drawing.Size(140, 17);
            this.rbfsElectrico.TabIndex = 1;
            this.rbfsElectrico.TabStop = true;
            this.rbfsElectrico.Text = "0-8 F. Servicio: Eléctrico";
            this.rbfsElectrico.UseVisualStyleBackColor = true;
            this.rbfsElectrico.CheckedChanged += new System.EventHandler(this.rbfsElectrico_CheckedChanged);
            // 
            // rbfsMecanico
            // 
            this.rbfsMecanico.AutoSize = true;
            this.rbfsMecanico.Location = new System.Drawing.Point(8, 83);
            this.rbfsMecanico.Name = "rbfsMecanico";
            this.rbfsMecanico.Size = new System.Drawing.Size(146, 17);
            this.rbfsMecanico.TabIndex = 0;
            this.rbfsMecanico.TabStop = true;
            this.rbfsMecanico.Text = "0-8 F. Servicio: Mecánico";
            this.rbfsMecanico.UseVisualStyleBackColor = true;
            this.rbfsMecanico.CheckedChanged += new System.EventHandler(this.rbfsMecanico_CheckedChanged);
            // 
            // gvDisponible
            // 
            this.gvDisponible.AllowUserToAddRows = false;
            this.gvDisponible.AllowUserToDeleteRows = false;
            this.gvDisponible.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDisponible.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.gvDisponible.Location = new System.Drawing.Point(16, 19);
            this.gvDisponible.Name = "gvDisponible";
            this.gvDisponible.ReadOnly = true;
            this.gvDisponible.RowHeadersWidth = 4;
            this.gvDisponible.Size = new System.Drawing.Size(259, 183);
            this.gvDisponible.TabIndex = 0;
            this.gvDisponible.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvDisponible_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Nombre Conductor";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 230;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "idConductor";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 5;
            // 
            // gbAsignarCarros
            // 
            this.gbAsignarCarros.Controls.Add(this.gvDisponible);
            this.gbAsignarCarros.Location = new System.Drawing.Point(178, 319);
            this.gbAsignarCarros.Name = "gbAsignarCarros";
            this.gbAsignarCarros.Size = new System.Drawing.Size(281, 208);
            this.gbAsignarCarros.TabIndex = 10;
            this.gbAsignarCarros.TabStop = false;
            this.gbAsignarCarros.Text = "Asignar Conductor";
            this.gbAsignarCarros.Visible = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtObservacion);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.lblIngresoOperadora);
            this.groupBox5.Location = new System.Drawing.Point(1, 227);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(459, 70);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Observación Asignada al Carro :";
            // 
            // btn_Reporte
            // 
            this.btn_Reporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_Reporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reporte.Location = new System.Drawing.Point(193, 175);
            this.btn_Reporte.Name = "btn_Reporte";
            this.btn_Reporte.Size = new System.Drawing.Size(258, 24);
            this.btn_Reporte.TabIndex = 9;
            this.btn_Reporte.Text = "Reporte en Twitter del Estado del Mat. Mayor";
            this.btn_Reporte.UseVisualStyleBackColor = false;
            this.btn_Reporte.Click += new System.EventHandler(this.btn_Reporte_Click);
            // 
            // ucEst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.gbAsignarCarros);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "ucEst";
            this.Size = new System.Drawing.Size(462, 543);
            this.Load += new System.EventHandler(this.ucEst_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDisponible)).EndInit();
            this.gbAsignarCarros.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblEstadoCarro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDescEstado;
        private System.Windows.Forms.Label lblDesConductor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblIngresoOperadora;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtOtro;
        private System.Windows.Forms.RadioButton rbfsOtro;
        private System.Windows.Forms.RadioButton rbfsElectrico;
        private System.Windows.Forms.RadioButton rbfsMecanico;
        private System.Windows.Forms.DataGridView gvDisponible;
        private System.Windows.Forms.GroupBox gbAsignarCarros;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbSinConductor;
        private System.Windows.Forms.RadioButton rbLiberarCarro;
        private System.Windows.Forms.RadioButton rbEnServicio;
        private System.Windows.Forms.Button btn_08;
        private System.Windows.Forms.Button btn_09;
        private System.Windows.Forms.Button btn_Reporte;
    }
}
