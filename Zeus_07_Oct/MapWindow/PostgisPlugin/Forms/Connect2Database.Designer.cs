namespace Database.Forms
{
    partial class Connect2Database
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
            this.comboDbType = new System.Windows.Forms.GroupBox();
            this.port = new System.Windows.Forms.TextBox();
            this.hostName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.password = new System.Windows.Forms.MaskedTextBox();
            this.userName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.database = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbDbType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.comboDbType.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboDbType
            // 
            this.comboDbType.Controls.Add(this.port);
            this.comboDbType.Controls.Add(this.hostName);
            this.comboDbType.Controls.Add(this.label3);
            this.comboDbType.Controls.Add(this.label2);
            this.comboDbType.Location = new System.Drawing.Point(12, 80);
            this.comboDbType.Name = "comboDbType";
            this.comboDbType.Size = new System.Drawing.Size(285, 88);
            this.comboDbType.TabIndex = 0;
            this.comboDbType.TabStop = false;
            this.comboDbType.Text = "Server configure";
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(115, 49);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(145, 20);
            this.port.TabIndex = 4;
            // 
            // hostName
            // 
            this.hostName.Location = new System.Drawing.Point(115, 19);
            this.hostName.Name = "hostName";
            this.hostName.Size = new System.Drawing.Size(145, 20);
            this.hostName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Port number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hostname or IP";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.password);
            this.groupBox2.Controls.Add(this.userName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 174);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(285, 83);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Authentication";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(115, 49);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(145, 20);
            this.password.TabIndex = 7;
            this.password.UseSystemPasswordChar = true;
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(115, 19);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(145, 20);
            this.userName.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "User name";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.database);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(12, 263);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(285, 70);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chose database";
            // 
            // database
            // 
            this.database.FormattingEnabled = true;
            this.database.Location = new System.Drawing.Point(115, 24);
            this.database.Name = "database";
            this.database.Size = new System.Drawing.Size(170, 21);
            this.database.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Database";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbDbType);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(12, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(285, 61);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Database type";
            // 
            // cbDbType
            // 
            this.cbDbType.FormattingEnabled = true;
            this.cbDbType.Items.AddRange(new object[] {
            "PostGIS"});
            this.cbDbType.Location = new System.Drawing.Point(115, 21);
            this.cbDbType.Name = "cbDbType";
            this.cbDbType.Size = new System.Drawing.Size(170, 21);
            this.cbDbType.TabIndex = 1;
            this.cbDbType.SelectedIndexChanged += new System.EventHandler(this.cbDbType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Database type";
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(51, 339);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(85, 23);
            this.btnTestConnection.TabIndex = 3;
            this.btnTestConnection.Text = "Test";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(177, 339);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(85, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // Connect2Database
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 370);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.comboDbType);
            this.Name = "Connect2Database";
            this.Text = "Connect2Database";
            this.Load += new System.EventHandler(this.Connect2Database_Load);
            this.comboDbType.ResumeLayout(false);
            this.comboDbType.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox comboDbType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDbType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox database;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.TextBox hostName;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.MaskedTextBox password;
    }
}