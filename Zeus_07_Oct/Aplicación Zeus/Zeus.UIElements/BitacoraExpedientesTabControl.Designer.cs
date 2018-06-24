namespace Zeus.UIElements
{
    partial class BitacoraExpedientesTabControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BitacoraExpedientesTabControl));
            this.tabVisibles = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlCarrosBitacoraExp = new System.Windows.Forms.ComboBox();
            this.dgBitacoraLlamados = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chkBgestion = new System.Windows.Forms.CheckBox();
            this.ddl2 = new System.Windows.Forms.ComboBox();
            this.dgBitacoraGestion = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabExpedientes = new System.Windows.Forms.TabPage();
            this.dgExpedientes = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabVisibles.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBitacoraLlamados)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBitacoraGestion)).BeginInit();
            this.tabExpedientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgExpedientes)).BeginInit();
            this.SuspendLayout();
            // 
            // tabVisibles
            // 
            this.tabVisibles.Controls.Add(this.tabPage1);
            this.tabVisibles.Controls.Add(this.tabExpedientes);
            this.tabVisibles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabVisibles.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabVisibles.ImageList = this.imageList1;
            this.tabVisibles.Location = new System.Drawing.Point(0, 0);
            this.tabVisibles.Name = "tabVisibles";
            this.tabVisibles.SelectedIndex = 0;
            this.tabVisibles.Size = new System.Drawing.Size(486, 302);
            this.tabVisibles.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tabControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(478, 273);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Bitácora";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(472, 267);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.ddlCarrosBitacoraExp);
            this.tabPage2.Controls.Add(this.dgBitacoraLlamados);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(464, 241);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Bitácora Llamados";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Horas por carro:";
            // 
            // ddlCarrosBitacoraExp
            // 
            this.ddlCarrosBitacoraExp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCarrosBitacoraExp.FormattingEnabled = true;
            this.ddlCarrosBitacoraExp.Location = new System.Drawing.Point(95, 6);
            this.ddlCarrosBitacoraExp.Name = "ddlCarrosBitacoraExp";
            this.ddlCarrosBitacoraExp.Size = new System.Drawing.Size(76, 21);
            this.ddlCarrosBitacoraExp.TabIndex = 2;
            this.ddlCarrosBitacoraExp.SelectedIndexChanged += new System.EventHandler(this.ddlCarrosBitacoraExp_SelectedIndexChanged);
            // 
            // dgBitacoraLlamados
            // 
            this.dgBitacoraLlamados.AllowUserToAddRows = false;
            this.dgBitacoraLlamados.AllowUserToDeleteRows = false;
            this.dgBitacoraLlamados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBitacoraLlamados.Location = new System.Drawing.Point(-23, 33);
            this.dgBitacoraLlamados.Name = "dgBitacoraLlamados";
            this.dgBitacoraLlamados.ReadOnly = true;
            this.dgBitacoraLlamados.Size = new System.Drawing.Size(1011, 513);
            this.dgBitacoraLlamados.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chkBgestion);
            this.tabPage3.Controls.Add(this.ddl2);
            this.tabPage3.Controls.Add(this.dgBitacoraGestion);
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(464, 241);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Bitácora Gestión";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chkBgestion
            // 
            this.chkBgestion.AutoSize = true;
            this.chkBgestion.Location = new System.Drawing.Point(6, 9);
            this.chkBgestion.Name = "chkBgestion";
            this.chkBgestion.Size = new System.Drawing.Size(101, 17);
            this.chkBgestion.TabIndex = 7;
            this.chkBgestion.Text = "Horas por carro";
            this.chkBgestion.UseVisualStyleBackColor = true;
            this.chkBgestion.CheckedChanged += new System.EventHandler(this.chkBgestion_CheckedChanged);
            // 
            // ddl2
            // 
            this.ddl2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl2.FormattingEnabled = true;
            this.ddl2.Location = new System.Drawing.Point(111, 6);
            this.ddl2.Name = "ddl2";
            this.ddl2.Size = new System.Drawing.Size(76, 21);
            this.ddl2.TabIndex = 5;
            this.ddl2.SelectedIndexChanged += new System.EventHandler(this.ddl2_SelectedIndexChanged);
            // 
            // dgBitacoraGestion
            // 
            this.dgBitacoraGestion.AllowUserToAddRows = false;
            this.dgBitacoraGestion.AllowUserToDeleteRows = false;
            this.dgBitacoraGestion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBitacoraGestion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.asd,
            this.Column3,
            this.Column4});
            this.dgBitacoraGestion.Location = new System.Drawing.Point(1, 34);
            this.dgBitacoraGestion.Name = "dgBitacoraGestion";
            this.dgBitacoraGestion.ReadOnly = true;
            this.dgBitacoraGestion.Size = new System.Drawing.Size(913, 412);
            this.dgBitacoraGestion.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "fecha";
            this.Column1.HeaderText = "Fecha/Hora";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // asd
            // 
            this.asd.DataPropertyName = "realiza";
            this.asd.HeaderText = "Realiza";
            this.asd.Name = "asd";
            this.asd.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "autoriza";
            this.Column3.HeaderText = "Autoriza";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "evento";
            this.Column4.HeaderText = "Evento";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 500;
            // 
            // tabExpedientes
            // 
            this.tabExpedientes.Controls.Add(this.dgExpedientes);
            this.tabExpedientes.Location = new System.Drawing.Point(4, 25);
            this.tabExpedientes.Name = "tabExpedientes";
            this.tabExpedientes.Padding = new System.Windows.Forms.Padding(3);
            this.tabExpedientes.Size = new System.Drawing.Size(478, 273);
            this.tabExpedientes.TabIndex = 1;
            this.tabExpedientes.Text = "Expedientes";
            this.tabExpedientes.UseVisualStyleBackColor = true;
            // 
            // dgExpedientes
            // 
            this.dgExpedientes.AllowUserToAddRows = false;
            this.dgExpedientes.AllowUserToDeleteRows = false;
            this.dgExpedientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgExpedientes.Location = new System.Drawing.Point(6, 6);
            this.dgExpedientes.Name = "dgExpedientes";
            this.dgExpedientes.ReadOnly = true;
            this.dgExpedientes.Size = new System.Drawing.Size(823, 311);
            this.dgExpedientes.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imageList1.Images.SetKeyName(0, "aviso_on.bmp");
            this.imageList1.Images.SetKeyName(1, "aviso_off.bmp");
            // 
            // BitacoraExpedientesTabControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabVisibles);
            this.Name = "BitacoraExpedientesTabControl";
            this.Size = new System.Drawing.Size(486, 302);
            this.Load += new System.EventHandler(this.MainTabs_Load);
            this.tabVisibles.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBitacoraLlamados)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBitacoraGestion)).EndInit();
            this.tabExpedientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgExpedientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabVisibles;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabExpedientes;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgBitacoraLlamados;
        private System.Windows.Forms.ComboBox ddlCarrosBitacoraExp;
        private System.Windows.Forms.DataGridView dgExpedientes;
        private System.Windows.Forms.DataGridView dgBitacoraGestion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddl2;
        private System.Windows.Forms.CheckBox chkBgestion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn asd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}
