namespace Zeus.PluginGeocodificacion.Forms
{
    partial class Coincidencias
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
            this.listCalles = new System.Windows.Forms.ListView();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnGenerar = new Zeus.UIElements.BlinkButton();
            this.btn_Asignar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listCalles
            // 
            this.listCalles.FullRowSelect = true;
            this.listCalles.HideSelection = false;
            this.listCalles.Location = new System.Drawing.Point(8, 6);
            this.listCalles.MultiSelect = false;
            this.listCalles.Name = "listCalles";
            this.listCalles.Size = new System.Drawing.Size(521, 115);
            this.listCalles.TabIndex = 0;
            this.listCalles.UseCompatibleStateImageBehavior = false;
            this.listCalles.View = System.Windows.Forms.View.Details;
            this.listCalles.SelectedIndexChanged += new System.EventHandler(this.listCalles_SelectedIndexChanged);
            this.listCalles.Click += new System.EventHandler(this.listCalles_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(382, 127);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(147, 23);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.SystemColors.Control;
            this.btnGenerar.Blink = true;
            this.btnGenerar.Location = new System.Drawing.Point(195, 127);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(147, 23);
            this.btnGenerar.TabIndex = 4;
            this.btnGenerar.Text = "Generar Expediente";
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btn_Asignar
            // 
            this.btn_Asignar.Location = new System.Drawing.Point(8, 127);
            this.btn_Asignar.Name = "btn_Asignar";
            this.btn_Asignar.Size = new System.Drawing.Size(150, 23);
            this.btn_Asignar.TabIndex = 5;
            this.btn_Asignar.Text = "Asignar 6-3";
            this.btn_Asignar.UseVisualStyleBackColor = true;
            this.btn_Asignar.Click += new System.EventHandler(this.btn_Asignar_Click);
            // 
            // Coincidencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 167);
            this.Controls.Add(this.btn_Asignar);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.listCalles);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Coincidencias";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Coincidencias";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listCalles;
        private System.Windows.Forms.Button btnCerrar;
        private Zeus.UIElements.BlinkButton btnGenerar;
        private System.Windows.Forms.Button btn_Asignar;
    }
}