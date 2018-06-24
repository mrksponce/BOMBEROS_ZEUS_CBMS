namespace PrestamoCarros
{
    partial class FormularioCarrosVecinos
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
            this.dgv_Apoyos = new System.Windows.Forms.DataGridView();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.lbx_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lnk_carro = new System.Windows.Forms.DataGridViewLinkColumn();
            this.lnk_tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lnk_compania = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chk_habilitar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tbx_IdCarro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Apoyos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Apoyos
            // 
            this.dgv_Apoyos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Apoyos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lbx_id,
            this.lnk_carro,
            this.lnk_tipo,
            this.lnk_compania,
            this.chk_habilitar,
            this.tbx_IdCarro});
            this.dgv_Apoyos.Location = new System.Drawing.Point(12, 24);
            this.dgv_Apoyos.Name = "dgv_Apoyos";
            this.dgv_Apoyos.Size = new System.Drawing.Size(455, 480);
            this.dgv_Apoyos.TabIndex = 2;
            this.dgv_Apoyos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Apoyos_CellContentClick);
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.Location = new System.Drawing.Point(345, 510);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(122, 29);
            this.btn_cerrar.TabIndex = 3;
            this.btn_cerrar.Text = "Cerrar";
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // lbx_id
            // 
            this.lbx_id.HeaderText = "ID";
            this.lbx_id.Name = "lbx_id";
            this.lbx_id.Width = 50;
            // 
            // lnk_carro
            // 
            this.lnk_carro.HeaderText = "CARRO";
            this.lnk_carro.Name = "lnk_carro";
            this.lnk_carro.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lnk_carro.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.lnk_carro.Width = 80;
            // 
            // lnk_tipo
            // 
            this.lnk_tipo.HeaderText = "ALIAS";
            this.lnk_tipo.Name = "lnk_tipo";
            this.lnk_tipo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lnk_tipo.Width = 80;
            // 
            // lnk_compania
            // 
            this.lnk_compania.HeaderText = "COMPAÑIA";
            this.lnk_compania.Name = "lnk_compania";
            this.lnk_compania.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lnk_compania.Width = 80;
            // 
            // chk_habilitar
            // 
            this.chk_habilitar.HeaderText = "HABILITAR";
            this.chk_habilitar.Name = "chk_habilitar";
            this.chk_habilitar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chk_habilitar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // tbx_IdCarro
            // 
            this.tbx_IdCarro.HeaderText = "IdCarr";
            this.tbx_IdCarro.Name = "tbx_IdCarro";
            this.tbx_IdCarro.Visible = false;
            // 
            // FormularioCarrosVecinos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 551);
            this.Controls.Add(this.btn_cerrar);
            this.Controls.Add(this.dgv_Apoyos);
            this.Name = "FormularioCarrosVecinos";
            this.Text = "Formulario de Material del Apoyo";
            this.Load += new System.EventHandler(this.FormularioCarrosVecinos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Apoyos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Apoyos;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn lbx_id;
        private System.Windows.Forms.DataGridViewLinkColumn lnk_carro;
        private System.Windows.Forms.DataGridViewTextBoxColumn lnk_tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn lnk_compania;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk_habilitar;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbx_IdCarro;
    }
}