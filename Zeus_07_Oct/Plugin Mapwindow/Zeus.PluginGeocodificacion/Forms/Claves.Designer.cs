namespace Zeus.PluginGeocodificacion.Forms
{
    partial class Claves
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.listClaves = new System.Windows.Forms.ListBox();
            this.listSubclaves = new System.Windows.Forms.ListBox();
            this.textClave = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.blinkButton1 = new Zeus.UIElements.BlinkButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccione las claves correspondientes:";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(659, 427);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // listClaves
            // 
            this.listClaves.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listClaves.FormattingEnabled = true;
            this.listClaves.ItemHeight = 16;
            this.listClaves.Location = new System.Drawing.Point(6, 19);
            this.listClaves.Name = "listClaves";
            this.listClaves.Size = new System.Drawing.Size(710, 164);
            this.listClaves.TabIndex = 7;
            this.listClaves.SelectedIndexChanged += new System.EventHandler(this.listClaves_SelectedIndexChanged);
            // 
            // listSubclaves
            // 
            this.listSubclaves.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listSubclaves.FormattingEnabled = true;
            this.listSubclaves.ItemHeight = 16;
            this.listSubclaves.Location = new System.Drawing.Point(6, 47);
            this.listSubclaves.Name = "listSubclaves";
            this.listSubclaves.Size = new System.Drawing.Size(710, 132);
            this.listSubclaves.TabIndex = 8;
            this.listSubclaves.SelectedIndexChanged += new System.EventHandler(this.listSubclaves_SelectedIndexChanged);
            // 
            // textClave
            // 
            this.textClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textClave.Location = new System.Drawing.Point(6, 19);
            this.textClave.Name = "textClave";
            this.textClave.Size = new System.Drawing.Size(710, 22);
            this.textClave.TabIndex = 9;
            this.textClave.TextChanged += new System.EventHandler(this.textClaves_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listClaves);
            this.groupBox1.Location = new System.Drawing.Point(12, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(722, 201);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Clave";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textClave);
            this.groupBox2.Controls.Add(this.listSubclaves);
            this.groupBox2.Location = new System.Drawing.Point(12, 232);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(722, 189);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Subclave";
            // 
            // blinkButton1
            // 
            this.blinkButton1.BackColor = System.Drawing.Color.OrangeRed;
            this.blinkButton1.Blink = true;
            this.blinkButton1.Location = new System.Drawing.Point(12, 427);
            this.blinkButton1.Name = "blinkButton1";
            this.blinkButton1.Size = new System.Drawing.Size(75, 23);
            this.blinkButton1.TabIndex = 12;
            this.blinkButton1.Text = "Aceptar";
            this.blinkButton1.UseVisualStyleBackColor = false;
            this.blinkButton1.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // Claves
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 462);
            this.Controls.Add(this.blinkButton1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Claves";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clasificación de Emergencias";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.ListBox listClaves;
        private System.Windows.Forms.ListBox listSubclaves;
        private System.Windows.Forms.TextBox textClave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Zeus.UIElements.BlinkButton blinkButton1;
    }
}