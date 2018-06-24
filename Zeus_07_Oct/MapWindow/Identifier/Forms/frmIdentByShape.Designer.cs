namespace mwIdentifier.Forms
{
    partial class frmIdentByShape
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIdentByShape));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbIdentFrom = new System.Windows.Forms.ComboBox();
            this.cmbIdentWith = new System.Windows.Forms.ComboBox();
            this.lblSel = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.cmdIdentify = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.chbJustToExtents = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Identify from layer...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Using shapes from layer...";
            // 
            // cmbIdentFrom
            // 
            this.cmbIdentFrom.FormattingEnabled = true;
            this.cmbIdentFrom.Location = new System.Drawing.Point(15, 39);
            this.cmbIdentFrom.Name = "cmbIdentFrom";
            this.cmbIdentFrom.Size = new System.Drawing.Size(265, 21);
            this.cmbIdentFrom.TabIndex = 2;
            // 
            // cmbIdentWith
            // 
            this.cmbIdentWith.FormattingEnabled = true;
            this.cmbIdentWith.Location = new System.Drawing.Point(15, 87);
            this.cmbIdentWith.Name = "cmbIdentWith";
            this.cmbIdentWith.Size = new System.Drawing.Size(265, 21);
            this.cmbIdentWith.TabIndex = 3;
            // 
            // lblSel
            // 
            this.lblSel.AutoSize = true;
            this.lblSel.Location = new System.Drawing.Point(168, 120);
            this.lblSel.Name = "lblSel";
            this.lblSel.Size = new System.Drawing.Size(103, 13);
            this.lblSel.TabIndex = 4;
            this.lblSel.Text = "(0 Shapes Selected)";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(21, 114);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(89, 24);
            this.btnSelect.TabIndex = 5;
            this.btnSelect.Text = "&Select Shapes";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // cmdIdentify
            // 
            this.cmdIdentify.Location = new System.Drawing.Point(191, 155);
            this.cmdIdentify.Name = "cmdIdentify";
            this.cmdIdentify.Size = new System.Drawing.Size(89, 24);
            this.cmdIdentify.TabIndex = 6;
            this.cmdIdentify.Text = "&Identify";
            this.cmdIdentify.UseVisualStyleBackColor = true;
            this.cmdIdentify.Click += new System.EventHandler(this.cmdIdentify_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(96, 155);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(89, 24);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // chbJustToExtents
            // 
            this.chbJustToExtents.AutoSize = true;
            this.chbJustToExtents.Location = new System.Drawing.Point(146, 64);
            this.chbJustToExtents.Name = "chbJustToExtents";
            this.chbJustToExtents.Size = new System.Drawing.Size(136, 17);
            this.chbJustToExtents.TabIndex = 8;
            this.chbJustToExtents.Text = "Just to Extents? [faster]";
            this.chbJustToExtents.UseVisualStyleBackColor = true;
            // 
            // frmIdentByShape
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 189);
            this.Controls.Add(this.chbJustToExtents);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdIdentify);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.lblSel);
            this.Controls.Add(this.cmbIdentWith);
            this.Controls.Add(this.cmbIdentFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIdentByShape";
            this.Text = "Identify by Shape(s)";
            this.Load += new System.EventHandler(this.frmIdentByShape_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbIdentFrom;
        private System.Windows.Forms.ComboBox cmbIdentWith;
        private System.Windows.Forms.Label lblSel;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button cmdIdentify;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.CheckBox chbJustToExtents;
    }
}