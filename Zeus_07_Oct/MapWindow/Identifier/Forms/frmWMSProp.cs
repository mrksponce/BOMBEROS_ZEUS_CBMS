//********************************************************************************************************
//The contents of this file are subject to the Mozilla Public License Version 1.1 (the "License"); 
//you may not use this file except in compliance with the License. You may obtain a copy of the License at 
//http://www.mozilla.org/MPL/ 
//Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF 
//ANY KIND, either express or implied. See the License for the specificlanguage governing rights and 
//limitations under the License. 
//
//The Original Code is MapWindow Identifier Plug-in. 
//
//The Initial Developer of this version of the Original Code is Daniel P. Ames using portions created by 
//Utah State University and the Idaho National Engineering and Environmental Lab that were released as 
//public domain in March 2004.  
//
//Contributor(s): (Open source contributors should list themselves and their modifications here). 
//********************************************************************************************************

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using MapWinGIS;

namespace mwIdentifier.Forms
{
	public class frmWMSProp : System.Windows.Forms.Form
    {
		#region Windows Form Designer generated code
        private Label lblLyrID;
        private Label lblLength;
        private Label lblArea;
        private ListView lv;
        private ColumnHeader columnHeader1;
        private TextBox txtbxError;
        private ColumnHeader columnHeader2;
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWMSProp));
            this.PopupMenu = new System.Windows.Forms.ContextMenu();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLength = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblLyrID = new System.Windows.Forms.Label();
            this.lv = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.txtbxError = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblLength);
            this.panel1.Controls.Add(this.lblArea);
            this.panel1.Controls.Add(this.lblLyrID);
            this.panel1.Controls.Add(this.lv);
            this.panel1.Controls.Add(this.txtbxError);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 274);
            this.panel1.TabIndex = 0;
            // 
            // lblLength
            // 
            this.lblLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLength.Location = new System.Drawing.Point(7, 46);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(272, 21);
            this.lblLength.TabIndex = 14;
            this.lblLength.Text = "Length:";
            // 
            // lblArea
            // 
            this.lblArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArea.Location = new System.Drawing.Point(7, 25);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(272, 21);
            this.lblArea.TabIndex = 13;
            this.lblArea.Text = "Area:";
            // 
            // lblLyrID
            // 
            this.lblLyrID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLyrID.Location = new System.Drawing.Point(7, 4);
            this.lblLyrID.Name = "lblLyrID";
            this.lblLyrID.Size = new System.Drawing.Size(272, 21);
            this.lblLyrID.TabIndex = 12;
            this.lblLyrID.Text = "Layer ID:";
            // 
            // lv
            // 
            this.lv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lv.FullRowSelect = true;
            this.lv.GridLines = true;
            this.lv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv.Location = new System.Drawing.Point(8, 70);
            this.lv.MultiSelect = false;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(280, 192);
            this.lv.TabIndex = 10;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.SizeChanged += new System.EventHandler(this.lv_SizeChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Field Name";
            this.columnHeader1.Width = 75;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Field Value";
            this.columnHeader2.Width = 76;
            // 
            // txtbxError
            // 
            this.txtbxError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbxError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxError.ForeColor = System.Drawing.Color.Red;
            this.txtbxError.Location = new System.Drawing.Point(8, 70);
            this.txtbxError.Multiline = true;
            this.txtbxError.Name = "txtbxError";
            this.txtbxError.Size = new System.Drawing.Size(280, 192);
            this.txtbxError.TabIndex = 15;
            // 
            // frmWMSProp
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(296, 274);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "frmWMSProp";
            this.Text = "Identifier";
            this.Load += new System.EventHandler(this.frmWMSProp_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmWMSProp_Closing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private mwIdentPlugin m_parent;
		private System.Drawing.Color RED = System.Drawing.Color.Red;
		private System.Drawing.Color YELLOW = System.Drawing.Color.Yellow; 
		private string m_LayerName;
		private frmEdit frmEdit = new frmEdit();
        private System.Windows.Forms.ContextMenu PopupMenu;
        private bool m_Editable = false;
        public Panel panel1;
        private bool m_HavePanel = false;


	
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmWMSProp(mwIdentPlugin p)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			//get a copy of the parent
			m_parent = p;

			//set the parent form
			System.IntPtr tempPtr = (System.IntPtr)m_parent.m_ParentHandle;
			Form mapFrm = (Form)System.Windows.Forms.Control.FromHandle(tempPtr);
			mapFrm.AddOwnedForm(this);
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

		public bool Editable
		{
			get
			{
				return m_Editable;
			}
			set
			{	
				m_Editable = value;
			}
		}


        private void frmWMSProp_Load(object sender, System.EventArgs e)
        {
            int width = lv.Size.Width;
            lv.Columns[0].Width = width / 2;
            lv.Columns[1].Width = width / 2;

            lblLyrID.Text = "Layer ID: ";
            lblArea.Text = "Area: ";
            lblLength.Text = "Length: ";
            txtbxError.Visible = false;
            lv.Visible = true;
        }

        private void frmWMSProp_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            m_parent.Activated = false;
            if (!m_HavePanel) this.Hide();
            m_parent.Deactivate();
        }
	
		private void lv_SizeChanged(object sender, System.EventArgs e)
		{	
			int width = lv.Size.Width;
			lv.Columns[0].Width = width /2;
			lv.Columns[1].Width = width /2;
		}


        public void PopulateForm(bool ShowAfterward, string WMSInfo, string layerName, bool calledBySelf)
        {
            lblLyrID.Text = "Layer ID: ";
            lblArea.Text = "Area: ";
            lblLength.Text = "Length: ";
            txtbxError.Visible = false;
            lv.Visible = true;

            if (!calledBySelf) m_HavePanel = !ShowAfterward;

            try
            {
                m_LayerName = layerName;
                SetTitle();

                //clear the selected box
                m_parent.m_MapWin.View.Draw.ClearDrawing(m_parent.m_hDraw);

                //clear the list view items
                lv.Items.Clear();

                if (WMSInfo.StartsWith("Error"))
                {
                    lv.Visible = false; 
                    txtbxError.Visible = true;
                    if (WMSInfo == "Error: No feature found.")
                    {
                        txtbxError.ForeColor = System.Drawing.Color.Black;
                        txtbxError.Text = "No feature found."; 
                    }
                    else
                    {
                        txtbxError.ForeColor = System.Drawing.Color.Red;
                        txtbxError.Text = WMSInfo;
                    }
                }
                else
                {
                    if (!WMSInfo.Contains("|"))
                    {
                        ShowErrorBox("PopulateForm()", "Unknown WMS Info Format");
                    }
                    else
                    {
                        lv.Visible = true;
                        txtbxError.Visible = false;

                        string[] pairs = WMSInfo.Split('|');
                        for (int i = 0; i < pairs.Length; i++)
                        {
                            if (pairs[i] != "" && pairs[i].Contains("="))
                            {
                                string[] vals = pairs[i].Split('=');
                                if (vals[0] == "_SHAPE_")
                                {

                                }
                                else if (vals[0] == "_LAYERID_")
                                {
                                    lblLyrID.Text = "Layer ID: " + vals[1];
                                }
                                else if (vals[0] == "SHAPE.AREA")
                                {
                                    lblArea.Text = "Area: " + vals[1];
                                }
                                else if (vals[0] == "SHAPE.LEN")
                                {
                                    lblLength.Text = "Length: " + vals[1];
                                }
                                else
                                {
                                    System.Windows.Forms.ListViewItem item;
                                    item = lv.Items.Add(vals[0]);
                                    item.SubItems.Add(vals[1]);
                                }
                            }
                        }
                    }
                }

                if (ShowAfterward) this.Show();
            }
            catch (System.Exception ex)
            {
                ShowErrorBox("PopulateForm()", ex.Message);
            }
        }
        
        private void SetTitle()
		{
			this.Text = "Identifier - " + m_LayerName;
		}

		private void ShowErrorBox(string functionName,string errorMsg)
		{
			MapWinUtility.Logger.Message("Error in " + functionName + ", Message: " + errorMsg,"Identifier",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error, DialogResult.OK);
		}

        private void DockImage_Click(object sender, EventArgs e)
        {
            m_parent.ToggleDockedStatus(this, panel1);
        }

	}
}
