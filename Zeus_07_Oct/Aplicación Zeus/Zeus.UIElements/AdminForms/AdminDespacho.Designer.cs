namespace Zeus.UIElements.AdminForms
{
    partial class AdminDespacho
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
            this.comboClaves = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboArea = new System.Windows.Forms.ComboBox();
            this.groupdh = new System.Windows.Forms.GroupBox();
            this.dbHabil = new Zeus.UIElements.DoubleBufferedTableLayoutPanel();
            this.listCarro = new System.Windows.Forms.ListBox();
            this.listBloques = new System.Windows.Forms.CheckedListBox();
            this.checkInhabil = new System.Windows.Forms.CheckBox();
            this.check2_6 = new System.Windows.Forms.CheckBox();
            this.groupdi = new System.Windows.Forms.GroupBox();
            this.dbInhabil = new Zeus.UIElements.DoubleBufferedTableLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.groupdh.SuspendLayout();
            this.groupdi.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(187, 378);
            this.groupBox1.Text = "Subclaves";
            // 
            // listActuales
            // 
            this.listActuales.Size = new System.Drawing.Size(175, 316);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(-7, 379);
            this.btnNuevo.Visible = false;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(205, 367);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(103, 379);
            this.btnEliminar.Visible = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(689, 367);
            // 
            // comboClaves
            // 
            this.comboClaves.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboClaves.FormattingEnabled = true;
            this.comboClaves.Location = new System.Drawing.Point(339, 31);
            this.comboClaves.Name = "comboClaves";
            this.comboClaves.Size = new System.Drawing.Size(236, 21);
            this.comboClaves.TabIndex = 5;
            this.comboClaves.SelectedIndexChanged += new System.EventHandler(this.comboClaves_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(202, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Área:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(336, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Clave Principal:";
            // 
            // comboArea
            // 
            this.comboArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboArea.FormattingEnabled = true;
            this.comboArea.Location = new System.Drawing.Point(205, 31);
            this.comboArea.Name = "comboArea";
            this.comboArea.Size = new System.Drawing.Size(121, 21);
            this.comboArea.TabIndex = 8;
            this.comboArea.SelectedIndexChanged += new System.EventHandler(this.comboArea_SelectedIndexChanged);
            // 
            // groupdh
            // 
            this.groupdh.AutoSize = true;
            this.groupdh.Controls.Add(this.dbHabil);
            this.groupdh.Controls.Add(this.listCarro);
            this.groupdh.Controls.Add(this.listBloques);
            this.groupdh.Controls.Add(this.checkInhabil);
            this.groupdh.Controls.Add(this.check2_6);
            this.groupdh.Location = new System.Drawing.Point(205, 58);
            this.groupdh.Name = "groupdh";
            this.groupdh.Size = new System.Drawing.Size(549, 158);
            this.groupdh.TabIndex = 9;
            this.groupdh.TabStop = false;
            this.groupdh.Text = "Despacho Hábil";
            // 
            // dbHabil
            // 
            this.dbHabil.AutoSize = true;
            this.dbHabil.ColumnCount = 2;
            this.dbHabil.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.dbHabil.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.dbHabil.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.dbHabil.Location = new System.Drawing.Point(6, 20);
            this.dbHabil.Name = "dbHabil";
            this.dbHabil.RowCount = 2;
            this.dbHabil.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.dbHabil.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dbHabil.Size = new System.Drawing.Size(200, 29);
            this.dbHabil.TabIndex = 61;
            // 
            // listCarro
            // 
            this.listCarro.Enabled = false;
            this.listCarro.FormattingEnabled = true;
            this.listCarro.Location = new System.Drawing.Point(60, 80);
            this.listCarro.Name = "listCarro";
            this.listCarro.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listCarro.Size = new System.Drawing.Size(66, 56);
            this.listCarro.TabIndex = 34;
            this.listCarro.SelectedIndexChanged += new System.EventHandler(this.listCarro_SelectedIndexChanged);
            // 
            // listBloques
            // 
            this.listBloques.Enabled = false;
            this.listBloques.FormattingEnabled = true;
            this.listBloques.Location = new System.Drawing.Point(304, 80);
            this.listBloques.Name = "listBloques";
            this.listBloques.Size = new System.Drawing.Size(239, 52);
            this.listBloques.TabIndex = 33;
            this.listBloques.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listBloques_ItemCheck);
            // 
            // checkInhabil
            // 
            this.checkInhabil.AutoSize = true;
            this.checkInhabil.Location = new System.Drawing.Point(199, 82);
            this.checkInhabil.Name = "checkInhabil";
            this.checkInhabil.Size = new System.Drawing.Size(96, 17);
            this.checkInhabil.TabIndex = 32;
            this.checkInhabil.Text = "Horario Inhábil";
            this.checkInhabil.UseVisualStyleBackColor = true;
            this.checkInhabil.CheckedChanged += new System.EventHandler(this.checkInhabil_CheckedChanged);
            // 
            // check2_6
            // 
            this.check2_6.AutoSize = true;
            this.check2_6.Location = new System.Drawing.Point(6, 80);
            this.check2_6.Name = "check2_6";
            this.check2_6.Size = new System.Drawing.Size(42, 17);
            this.check2_6.TabIndex = 30;
            this.check2_6.Text = "2-6";
            this.check2_6.UseVisualStyleBackColor = true;
            this.check2_6.CheckedChanged += new System.EventHandler(this.check2_6_CheckedChanged);
            // 
            // groupdi
            // 
            this.groupdi.AutoSize = true;
            this.groupdi.Controls.Add(this.dbInhabil);
            this.groupdi.Enabled = false;
            this.groupdi.Location = new System.Drawing.Point(205, 222);
            this.groupdi.Name = "groupdi";
            this.groupdi.Size = new System.Drawing.Size(549, 69);
            this.groupdi.TabIndex = 10;
            this.groupdi.TabStop = false;
            this.groupdi.Text = "Despacho Inhábil";
            // 
            // dbInhabil
            // 
            this.dbInhabil.AutoSize = true;
            this.dbInhabil.ColumnCount = 2;
            this.dbInhabil.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.dbInhabil.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.dbInhabil.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.dbInhabil.Location = new System.Drawing.Point(6, 20);
            this.dbInhabil.Name = "dbInhabil";
            this.dbInhabil.RowCount = 2;
            this.dbInhabil.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.dbInhabil.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dbInhabil.Size = new System.Drawing.Size(200, 29);
            this.dbInhabil.TabIndex = 60;
            // 
            // AdminDespacho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(776, 402);
            this.Controls.Add(this.groupdh);
            this.Controls.Add(this.comboArea);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboClaves);
            this.Controls.Add(this.groupdi);
            this.Name = "AdminDespacho";
            this.Text = "Administración Cantidades Despacho";
            this.Load += new System.EventHandler(this.AdminDespacho_Load);
            this.Controls.SetChildIndex(this.groupdi, 0);
            this.Controls.SetChildIndex(this.comboClaves, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.btnActualizar, 0);
            this.Controls.SetChildIndex(this.comboArea, 0);
            this.Controls.SetChildIndex(this.groupdh, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupdh.ResumeLayout(false);
            this.groupdh.PerformLayout();
            this.groupdi.ResumeLayout(false);
            this.groupdi.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboClaves;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboArea;
        private System.Windows.Forms.GroupBox groupdh;
        private System.Windows.Forms.GroupBox groupdi;
        private System.Windows.Forms.CheckedListBox listBloques;
        private System.Windows.Forms.CheckBox checkInhabil;
        private System.Windows.Forms.CheckBox check2_6;
        private System.Windows.Forms.ListBox listCarro;
        private DoubleBufferedTableLayoutPanel dbInhabil;
        private DoubleBufferedTableLayoutPanel dbHabil;
    }
}