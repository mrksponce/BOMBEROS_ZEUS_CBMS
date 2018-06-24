namespace Zeus.UIElements
{
    partial class _011_CubrirCuartel
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
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ddlCompanias = new System.Windows.Forms.ComboBox();
            this.ddlCarros = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Cia_Origen = new System.Windows.Forms.Label();
            this.ddlOrigen = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ddlOrigen);
            this.groupBox1.Controls.Add(this.lbl_Cia_Origen);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.ddlCompanias);
            this.groupBox1.Controls.Add(this.ddlCarros);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 350);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cubrir Cuartel";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 312);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(107, 23);
            this.button4.TabIndex = 16;
            this.button4.Text = "Asignar 6-10";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(206, 312);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "Asignar 6-20";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(181, 160);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Retornar 0-11";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridView1.Location = new System.Drawing.Point(7, 203);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 4;
            this.dataGridView1.Size = new System.Drawing.Size(295, 94);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Carros en 0-11";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 265;
            // 
            // ddlCompanias
            // 
            this.ddlCompanias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCompanias.FormattingEnabled = true;
            this.ddlCompanias.Location = new System.Drawing.Point(136, 111);
            this.ddlCompanias.Name = "ddlCompanias";
            this.ddlCompanias.Size = new System.Drawing.Size(149, 21);
            this.ddlCompanias.TabIndex = 12;
            // 
            // ddlCarros
            // 
            this.ddlCarros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCarros.FormattingEnabled = true;
            this.ddlCarros.Location = new System.Drawing.Point(136, 67);
            this.ddlCarros.Name = "ddlCarros";
            this.ddlCarros.Size = new System.Drawing.Size(149, 21);
            this.ddlCarros.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Despachar 0-11";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cía. de Destino:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Carro:";
            // 
            // lbl_Cia_Origen
            // 
            this.lbl_Cia_Origen.AutoSize = true;
            this.lbl_Cia_Origen.Location = new System.Drawing.Point(27, 34);
            this.lbl_Cia_Origen.Name = "lbl_Cia_Origen";
            this.lbl_Cia_Origen.Size = new System.Drawing.Size(79, 13);
            this.lbl_Cia_Origen.TabIndex = 17;
            this.lbl_Cia_Origen.Text = "Cía. de Origen:";
            // 
            // ddlOrigen
            // 
            this.ddlOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlOrigen.FormattingEnabled = true;
            this.ddlOrigen.Location = new System.Drawing.Point(136, 31);
            this.ddlOrigen.Name = "ddlOrigen";
            this.ddlOrigen.Size = new System.Drawing.Size(147, 21);
            this.ddlOrigen.TabIndex = 18;
            this.ddlOrigen.SelectedIndexChanged += new System.EventHandler(this.ddlOrigen_SelectedIndexChanged);
            // 
            // _011_CubrirCuartel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 374);
            this.Controls.Add(this.groupBox1);
            this.Name = "_011_CubrirCuartel";
            this.Text = "0-11 Cubrir Cuartel";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox ddlCompanias;
        private System.Windows.Forms.ComboBox ddlCarros;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbl_Cia_Origen;
        private System.Windows.Forms.ComboBox ddlOrigen;

    }
}