namespace Zeus.PluginGeocodificacion.Forms
{
    partial class ListadoGrifos
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListadoGrifos));
            this.label1 = new System.Windows.Forms.Label();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textRadio = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listGrifos = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.comboTipoLlamado = new System.Windows.Forms.ComboBox();
            this.checkPunto = new System.Windows.Forms.CheckBox();
            this.comboDireccion = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textGeoz = new System.Windows.Forms.TextBox();
            this.btnHide = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Radio de Selección:";
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(86, 123);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(75, 23);
            this.btnAplicar.TabIndex = 3;
            this.btnAplicar.Text = "Mostrar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tipo de Llamado:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "0-5:";
            // 
            // textRadio
            // 
            this.textRadio.Location = new System.Drawing.Point(7, 125);
            this.textRadio.Name = "textRadio";
            this.textRadio.Size = new System.Drawing.Size(73, 21);
            this.textRadio.TabIndex = 8;
            this.textRadio.Text = "500";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Agenda.ico");
            // 
            // listGrifos
            // 
            this.listGrifos.CheckBoxes = true;
            this.listGrifos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listGrifos.FullRowSelect = true;
            this.listGrifos.HideSelection = false;
            this.listGrifos.Location = new System.Drawing.Point(7, 152);
            this.listGrifos.MultiSelect = false;
            this.listGrifos.Name = "listGrifos";
            this.listGrifos.Size = new System.Drawing.Size(529, 242);
            this.listGrifos.TabIndex = 9;
            this.listGrifos.UseCompatibleStateImageBehavior = false;
            this.listGrifos.View = System.Windows.Forms.View.Details;
            this.listGrifos.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listGrifos_ItemCheck);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Utilizado";
            this.columnHeader1.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Dirección";
            this.columnHeader2.Width = 255;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Distancia";
            this.columnHeader3.Width = 1;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Esquina";
            this.columnHeader4.Width = 181;
            // 
            // comboTipoLlamado
            // 
            this.comboTipoLlamado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipoLlamado.FormattingEnabled = true;
            this.comboTipoLlamado.Location = new System.Drawing.Point(7, 41);
            this.comboTipoLlamado.Name = "comboTipoLlamado";
            this.comboTipoLlamado.Size = new System.Drawing.Size(350, 21);
            this.comboTipoLlamado.TabIndex = 10;
            this.comboTipoLlamado.SelectedIndexChanged += new System.EventHandler(this.comboTipoLlamado_SelectedIndexChanged);
            // 
            // checkPunto
            // 
            this.checkPunto.AutoSize = true;
            this.checkPunto.Location = new System.Drawing.Point(7, 5);
            this.checkPunto.Name = "checkPunto";
            this.checkPunto.Size = new System.Drawing.Size(158, 17);
            this.checkPunto.TabIndex = 11;
            this.checkPunto.Text = "Utilizar punto geocodificado";
            this.checkPunto.UseVisualStyleBackColor = true;
            this.checkPunto.CheckedChanged += new System.EventHandler(this.checkPunto_CheckedChanged);
            // 
            // comboDireccion
            // 
            this.comboDireccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDireccion.FormattingEnabled = true;
            this.comboDireccion.Location = new System.Drawing.Point(7, 84);
            this.comboDireccion.Name = "comboDireccion";
            this.comboDireccion.Size = new System.Drawing.Size(350, 21);
            this.comboDireccion.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(201, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Código Geoz:";
            // 
            // textGeoz
            // 
            this.textGeoz.Location = new System.Drawing.Point(201, 125);
            this.textGeoz.Name = "textGeoz";
            this.textGeoz.ReadOnly = true;
            this.textGeoz.Size = new System.Drawing.Size(156, 21);
            this.textGeoz.TabIndex = 14;
            // 
            // btnHide
            // 
            this.btnHide.Location = new System.Drawing.Point(282, 400);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(75, 23);
            this.btnHide.TabIndex = 15;
            this.btnHide.Text = "Menos <<";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Visible = false;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCerrar.Location = new System.Drawing.Point(7, 400);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 16;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // ListadoGrifos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 448);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.textGeoz);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboDireccion);
            this.Controls.Add(this.checkPunto);
            this.Controls.Add(this.comboTipoLlamado);
            this.Controls.Add(this.listGrifos);
            this.Controls.Add(this.textRadio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "ListadoGrifos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Listado de Grifos";
            this.Load += new System.EventHandler(this.ListadoGrifos_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ListadoGrifos_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textRadio;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView listGrifos;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ComboBox comboTipoLlamado;
        private System.Windows.Forms.CheckBox checkPunto;
        private System.Windows.Forms.ComboBox comboDireccion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textGeoz;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}