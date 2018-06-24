namespace Zeus.UIElements
{
    partial class CarroDisponible
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
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lbl_cia = new System.Windows.Forms.Label();
            this.cmbx_origen = new System.Windows.Forms.ComboBox();
            this.lbl_carro = new System.Windows.Forms.Label();
            this.cmbx_carro = new System.Windows.Forms.ComboBox();
            this.lbl_tipo_carro = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbx_funcion = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnSelect
            // 
            this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSelect.Location = new System.Drawing.Point(27, 275);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(104, 23);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "Asignar";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(135, 275);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(102, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lbl_cia
            // 
            this.lbl_cia.AutoSize = true;
            this.lbl_cia.Location = new System.Drawing.Point(26, 27);
            this.lbl_cia.Name = "lbl_cia";
            this.lbl_cia.Size = new System.Drawing.Size(58, 13);
            this.lbl_cia.TabIndex = 4;
            this.lbl_cia.Text = "Compañía:";
            // 
            // cmbx_origen
            // 
            this.cmbx_origen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbx_origen.FormattingEnabled = true;
            this.cmbx_origen.Location = new System.Drawing.Point(29, 43);
            this.cmbx_origen.Name = "cmbx_origen";
            this.cmbx_origen.Size = new System.Drawing.Size(209, 21);
            this.cmbx_origen.TabIndex = 5;
            this.cmbx_origen.SelectedIndexChanged += new System.EventHandler(this.cmbx_origen_SelectedIndexChanged);
            // 
            // lbl_carro
            // 
            this.lbl_carro.AutoSize = true;
            this.lbl_carro.Location = new System.Drawing.Point(26, 87);
            this.lbl_carro.Name = "lbl_carro";
            this.lbl_carro.Size = new System.Drawing.Size(38, 13);
            this.lbl_carro.TabIndex = 6;
            this.lbl_carro.Text = "Carro:";
            // 
            // cmbx_carro
            // 
            this.cmbx_carro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbx_carro.FormattingEnabled = true;
            this.cmbx_carro.Location = new System.Drawing.Point(29, 103);
            this.cmbx_carro.Name = "cmbx_carro";
            this.cmbx_carro.Size = new System.Drawing.Size(209, 21);
            this.cmbx_carro.TabIndex = 7;
            // 
            // lbl_tipo_carro
            // 
            this.lbl_tipo_carro.AutoSize = true;
            this.lbl_tipo_carro.Location = new System.Drawing.Point(26, 149);
            this.lbl_tipo_carro.Name = "lbl_tipo_carro";
            this.lbl_tipo_carro.Size = new System.Drawing.Size(153, 13);
            this.lbl_tipo_carro.TabIndex = 8;
            this.lbl_tipo_carro.Text = "El carro cumplirá la función de:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 42);
            this.label2.TabIndex = 10;
            this.label2.Text = "Según la función que seleccione,\r\nel carro será contabilizado en un\r\nIncendio o R" +
                "ectificación de Clave.";
            // 
            // cmbx_funcion
            // 
            this.cmbx_funcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbx_funcion.FormattingEnabled = true;
            this.cmbx_funcion.Location = new System.Drawing.Point(27, 165);
            this.cmbx_funcion.Name = "cmbx_funcion";
            this.cmbx_funcion.Size = new System.Drawing.Size(209, 21);
            this.cmbx_funcion.TabIndex = 12;
            // 
            // CarroDisponible
            // 
            this.AcceptButton = this.btnSelect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(262, 317);
            this.Controls.Add(this.cmbx_funcion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_tipo_carro);
            this.Controls.Add(this.cmbx_carro);
            this.Controls.Add(this.lbl_carro);
            this.Controls.Add(this.cmbx_origen);
            this.Controls.Add(this.lbl_cia);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSelect);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CarroDisponible";
            this.ShowInTaskbar = false;
            this.Text = "Seleccionar Carro 2-6";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lbl_cia;
        private System.Windows.Forms.ComboBox cmbx_origen;
        private System.Windows.Forms.Label lbl_carro;
        private System.Windows.Forms.ComboBox cmbx_carro;
        private System.Windows.Forms.Label lbl_tipo_carro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbx_funcion;
    }
}