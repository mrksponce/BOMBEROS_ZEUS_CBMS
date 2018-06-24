using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mwLabeler
{
	/// <summary>
	/// Summary description for frmProgress.
	/// </summary>
	public class frmProgress : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ProgressBar Progress;
		private System.Windows.Forms.Label lbtitle;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmProgress()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Progress = new System.Windows.Forms.ProgressBar();
			this.lbtitle = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Progress
			// 
			this.Progress.Location = new System.Drawing.Point(8, 56);
			this.Progress.Name = "Progress";
			this.Progress.Size = new System.Drawing.Size(248, 24);
			this.Progress.TabIndex = 0;
			// 
			// lbtitle
			// 
			this.lbtitle.Location = new System.Drawing.Point(8, 8);
			this.lbtitle.Name = "lbtitle";
			this.lbtitle.Size = new System.Drawing.Size(248, 40);
			this.lbtitle.TabIndex = 1;
			this.lbtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// frmProgress
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(266, 88);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.lbtitle,
																		  this.Progress});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmProgress";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Progress";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmProgress_Closing);
			this.Load += new System.EventHandler(this.frmProgress_Load);
			this.ResumeLayout(false);

		}
		#endregion


		public void SetProgress(string title,double perc)
		{	
			this.lbtitle.Text = title;
			Progress.Value = (int)perc;
			this.Refresh();
		}

		private void frmProgress_Load(object sender, System.EventArgs e)
		{
		
		}

		private void frmProgress_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = true;
		}


	}
}
