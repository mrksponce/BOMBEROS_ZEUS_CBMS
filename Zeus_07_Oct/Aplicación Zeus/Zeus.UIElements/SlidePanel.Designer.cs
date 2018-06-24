namespace Zeus.UIElements
{
    partial class SlidePanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SlidePanel));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.mainbtn = new System.Windows.Forms.Panel();
            this.btnGps = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.LinkLabel();
            this.btnExpedientes = new System.Windows.Forms.Button();
            this.btnReabrir = new System.Windows.Forms.Button();
            this.btnGestion = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.mainbtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "arrow-down.png");
            this.imageList1.Images.SetKeyName(1, "arrow-up.png");
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // mainbtn
            // 
            this.mainbtn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainbtn.Controls.Add(this.btnGps);
            this.mainbtn.Controls.Add(this.lblInfo);
            this.mainbtn.Controls.Add(this.btnExpedientes);
            this.mainbtn.Controls.Add(this.btnReabrir);
            this.mainbtn.Controls.Add(this.btnGestion);
            this.mainbtn.Controls.Add(this.button1);
            this.mainbtn.Location = new System.Drawing.Point(0, 153);
            this.mainbtn.Name = "mainbtn";
            this.mainbtn.Size = new System.Drawing.Size(489, 45);
            this.mainbtn.TabIndex = 2;
            // 
            // btnGps
            // 
            this.btnGps.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGps.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGps.Location = new System.Drawing.Point(238, 10);
            this.btnGps.Name = "btnGps";
            this.btnGps.Size = new System.Drawing.Size(62, 23);
            this.btnGps.TabIndex = 7;
            this.btnGps.Text = "GPS";
            this.btnGps.UseVisualStyleBackColor = true;
            this.btnGps.Click += new System.EventHandler(this.btnGps_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.Red;
            this.lblInfo.Location = new System.Drawing.Point(326, 19);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 14);
            this.lblInfo.TabIndex = 6;
            this.lblInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblInfo_LinkClicked);
            // 
            // btnExpedientes
            // 
            this.btnExpedientes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExpedientes.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpedientes.Location = new System.Drawing.Point(3, 10);
            this.btnExpedientes.Name = "btnExpedientes";
            this.btnExpedientes.Size = new System.Drawing.Size(122, 23);
            this.btnExpedientes.TabIndex = 5;
            this.btnExpedientes.Text = "Exps";
            this.btnExpedientes.UseVisualStyleBackColor = true;
            this.btnExpedientes.Click += new System.EventHandler(this.btnExpedientes_Click);
            // 
            // btnReabrir
            // 
            this.btnReabrir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReabrir.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReabrir.Location = new System.Drawing.Point(131, 10);
            this.btnReabrir.Name = "btnReabrir";
            this.btnReabrir.Size = new System.Drawing.Size(101, 23);
            this.btnReabrir.TabIndex = 4;
            this.btnReabrir.Text = "Expedientes...";
            this.btnReabrir.UseVisualStyleBackColor = true;
            this.btnReabrir.Click += new System.EventHandler(this.btnReabrir_Click);
            // 
            // btnGestion
            // 
            this.btnGestion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGestion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGestion.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestion.Location = new System.Drawing.Point(306, 10);
            this.btnGestion.Name = "btnGestion";
            this.btnGestion.Size = new System.Drawing.Size(120, 23);
            this.btnGestion.TabIndex = 3;
            this.btnGestion.Text = "Gestión Carros";
            this.btnGestion.UseVisualStyleBackColor = true;
            this.btnGestion.Click += new System.EventHandler(this.btnGestion_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ImageIndex = 1;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(432, -1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 45);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SlidePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainbtn);
            this.DoubleBuffered = true;
            this.Name = "SlidePanel";
            this.Size = new System.Drawing.Size(513, 259);
            this.Load += new System.EventHandler(this.SlidePanel_Load);
            this.SizeChanged += new System.EventHandler(this.SlidePanel_SizeChanged);
            this.mainbtn.ResumeLayout(false);
            this.mainbtn.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel mainbtn;
        private System.Windows.Forms.Button btnGestion;
        private System.Windows.Forms.Button btnReabrir;
        private System.Windows.Forms.Button btnExpedientes;
        private System.Windows.Forms.LinkLabel lblInfo;
        private System.Windows.Forms.Button btnGps;
    }
}
