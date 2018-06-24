namespace ResumenEmergencias
{
    partial class ResumenEmergenciasForm
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
            this.listEmergencias = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.button1 = new System.Windows.Forms.Button();
            this.radio24Horas = new System.Windows.Forms.RadioButton();
            this.radioIntervalo = new System.Windows.Forms.RadioButton();
            this.dateDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateHasta = new System.Windows.Forms.DateTimePicker();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listEmergencias
            // 
            this.listEmergencias.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14});
            this.listEmergencias.FullRowSelect = true;
            this.listEmergencias.Location = new System.Drawing.Point(12, 38);
            this.listEmergencias.MultiSelect = false;
            this.listEmergencias.Name = "listEmergencias";
            this.listEmergencias.Size = new System.Drawing.Size(829, 315);
            this.listEmergencias.TabIndex = 0;
            this.listEmergencias.UseCompatibleStateImageBehavior = false;
            this.listEmergencias.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Fecha";
            this.columnHeader1.Width = 140;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Llamado";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Direccion";
            this.columnHeader3.Width = 312;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "N. General";
            this.columnHeader4.Width = 74;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "N. Incendio";
            this.columnHeader5.Width = 78;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "N. RedTIC";
            this.columnHeader6.Width = 74;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Oficial a Cargo";
            this.columnHeader7.Width = 154;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Material Mayor";
            this.columnHeader8.Width = 95;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "6-0";
            this.columnHeader9.Width = 69;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "6-3";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "6-7";
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "6-8";
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "6-9";
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "6-10";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(725, 366);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 21);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cerrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radio24Horas
            // 
            this.radio24Horas.AutoSize = true;
            this.radio24Horas.Location = new System.Drawing.Point(12, 11);
            this.radio24Horas.Name = "radio24Horas";
            this.radio24Horas.Size = new System.Drawing.Size(105, 17);
            this.radio24Horas.TabIndex = 2;
            this.radio24Horas.TabStop = true;
            this.radio24Horas.Text = "Últimas 24 Horas";
            this.radio24Horas.UseVisualStyleBackColor = true;
            // 
            // radioIntervalo
            // 
            this.radioIntervalo.AutoSize = true;
            this.radioIntervalo.Location = new System.Drawing.Point(407, 11);
            this.radioIntervalo.Name = "radioIntervalo";
            this.radioIntervalo.Size = new System.Drawing.Size(55, 17);
            this.radioIntervalo.TabIndex = 3;
            this.radioIntervalo.TabStop = true;
            this.radioIntervalo.Text = "Desde";
            this.radioIntervalo.UseVisualStyleBackColor = true;
            // 
            // dateDesde
            // 
            this.dateDesde.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDesde.Location = new System.Drawing.Point(463, 9);
            this.dateDesde.Name = "dateDesde";
            this.dateDesde.Size = new System.Drawing.Size(133, 21);
            this.dateDesde.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(601, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "hasta";
            // 
            // dateHasta
            // 
            this.dateHasta.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateHasta.Location = new System.Drawing.Point(637, 9);
            this.dateHasta.Name = "dateHasta";
            this.dateHasta.Size = new System.Drawing.Size(133, 21);
            this.dateHasta.TabIndex = 6;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Location = new System.Drawing.Point(776, 9);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(64, 21);
            this.btnRefrescar.TabIndex = 7;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 366);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 21);
            this.button2.TabIndex = 8;
            this.button2.Text = "Enviar por e-mail...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ResumenEmergenciasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 398);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnRefrescar);
            this.Controls.Add(this.dateHasta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateDesde);
            this.Controls.Add(this.radioIntervalo);
            this.Controls.Add(this.radio24Horas);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listEmergencias);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResumenEmergenciasForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Resumen Emergencias Últimas 24 Horas";
            this.Load += new System.EventHandler(this.ResumenEmergenciasForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listEmergencias;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.RadioButton radio24Horas;
        private System.Windows.Forms.RadioButton radioIntervalo;
        private System.Windows.Forms.DateTimePicker dateDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateHasta;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}