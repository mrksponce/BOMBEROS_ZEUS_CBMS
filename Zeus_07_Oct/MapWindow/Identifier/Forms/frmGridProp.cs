using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using MapWinGIS;

namespace mwIdentifier.Forms
{
	struct GridValue
	{
		public int count;
		public double cellValue;
	}

	enum Column	{Value,Count,Ascending,Descending};
	
	public class frmGridProp : System.Windows.Forms.Form
	{
		private mwIdentPlugin m_parent;
		private MapWinGIS.Extents m_Extents;
		private MapWinGIS.Grid m_Grid;
		private System.Drawing.Color RED = System.Drawing.Color.Red;
        public int m_hDraw;
        public Panel panel1;
        private Label lbLowValue;
        private Label lbHighValue;
        private LinkLabel LinkLowValue;
        private LinkLabel LinkHighValue;
        private bool m_HavePanel = false;
        private Button button1;
        private Panel panel2;
        private DataGridView dgv;
        private bool SkipDisplayValues;
        private string MostRecentlySelectedValue = "";
 
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmGridProp(mwIdentPlugin p)
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
						
			m_hDraw = -1;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGridProp));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.lbLowValue = new System.Windows.Forms.Label();
            this.lbHighValue = new System.Windows.Forms.Label();
            this.LinkLowValue = new System.Windows.Forms.LinkLabel();
            this.LinkHighValue = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lbLowValue);
            this.panel1.Controls.Add(this.lbHighValue);
            this.panel1.Controls.Add(this.LinkLowValue);
            this.panel1.Controls.Add(this.LinkHighValue);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 317);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dgv);
            this.panel2.Location = new System.Drawing.Point(10, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(372, 223);
            this.panel2.TabIndex = 18;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(372, 223);
            this.dgv.TabIndex = 17;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dgv.Sorted += new System.EventHandler(this.dgv_Sorted);
            this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(10, 285);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "&Copy to Clipboard";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbLowValue
            // 
            this.lbLowValue.Location = new System.Drawing.Point(104, 37);
            this.lbLowValue.Name = "lbLowValue";
            this.lbLowValue.Size = new System.Drawing.Size(208, 16);
            this.lbLowValue.TabIndex = 15;
            // 
            // lbHighValue
            // 
            this.lbHighValue.Location = new System.Drawing.Point(104, 9);
            this.lbHighValue.Name = "lbHighValue";
            this.lbHighValue.Size = new System.Drawing.Size(208, 16);
            this.lbHighValue.TabIndex = 14;
            // 
            // LinkLowValue
            // 
            this.LinkLowValue.AutoSize = true;
            this.LinkLowValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkLowValue.Location = new System.Drawing.Point(4, 35);
            this.LinkLowValue.Name = "LinkLowValue";
            this.LinkLowValue.Size = new System.Drawing.Size(67, 15);
            this.LinkLowValue.TabIndex = 13;
            this.LinkLowValue.TabStop = true;
            this.LinkLowValue.Text = "Low Value:";
            this.LinkLowValue.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLowValue_LinkClicked);
            // 
            // LinkHighValue
            // 
            this.LinkHighValue.AutoSize = true;
            this.LinkHighValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkHighValue.Location = new System.Drawing.Point(4, 7);
            this.LinkHighValue.Name = "LinkHighValue";
            this.LinkHighValue.Size = new System.Drawing.Size(70, 15);
            this.LinkHighValue.TabIndex = 12;
            this.LinkHighValue.TabStop = true;
            this.LinkHighValue.Text = "High Value:";
            this.LinkHighValue.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkHighValue_LinkClicked);
            // 
            // frmGridProp
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(394, 317);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(0, 200);
            this.Name = "frmGridProp";
            this.Text = "Identifier";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmGridProp_Closing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        public void PopulateForm(bool ShowAfterward, MapWinGIS.Grid grid, string layerName, MapWinGIS.Extents ex, int LyrHandle)
		{
            m_HavePanel = !ShowAfterward;

			try
			{
				SetTitle(layerName);
				MapWinGIS.Extents extents = null;

				//clear the list view
                dgv.DataSource = null;

                System.Data.DataSet ds = new System.Data.DataSet();
                ds.Tables.Add();
                ds.Tables[0].Columns.Add("Value", typeof(string));
                ds.Tables[0].Columns.Add("Count", typeof(long));

				if(m_hDraw != -1)
				{
					m_parent.m_MapWin.View.Draw.ClearDrawing(m_hDraw);
					m_hDraw = -1;
				}
			
				//recalculates the extents if needed
				extents = GetMaxExtents(ex,grid.Header);

				extents = ex;

				if(extents != null)
				{	
					//set the map cursor to a wait cursor
					MapWinGIS.tkCursor m_PreviousCursor = m_parent.m_MapWin.View.MapCursor;
					m_parent.m_MapWin.View.MapCursor = MapWinGIS.tkCursor.crsrWait;
					
					//populate all the values and counts
                    PopulateLV(ref ds, grid, extents, LyrHandle);
					
					//set the cursor back to the Identifier cursor
					m_parent.m_MapWin.View.MapCursor = m_PreviousCursor;
				}
				else
				{
					lbHighValue.Text = "No Data";
					lbLowValue.Text = "No Data";
				}

                SkipDisplayValues = true;
                if(m_hDraw != -1)
					m_parent.m_MapWin.View.Draw.ClearDrawing(m_hDraw);

                dgv.DataSource = ds.Tables[0];
                
                if (dgv.SelectedRows.Count > 0)
                    dgv.SelectedRows[0].Selected = false;

                SkipDisplayValues = false;

				m_Extents = extents;
				m_Grid = grid;
			
				if (ShowAfterward) this.Show();
			}
			catch(System.Exception exception)
			{
				ShowErrorBox("PopulateForm()",exception.Message);
			}
		}

        private void PopulateLV(ref System.Data.DataSet dataset, Grid grid, MapWinGIS.Extents extents, int LyrHandle)
		{
			int maxCapacity = grid.Header.NumberCols * grid.Header.NumberRows;
			System.Collections.Hashtable table = new Hashtable();
			int endRow =0, endCol = 0;
			int startRow = 0,startCol = 0;
			double cellValue=0;
			GridValue gridValue;

			try
			{
				//find the begining and end cells
				grid.ProjToCell(extents.xMin,extents.yMax,out startCol,out startRow);
				grid.ProjToCell(extents.xMax,extents.yMin,out endCol,out endRow);
			
				MapWinGIS.GridDataType type = grid.DataType;
				
				// Ensure the same datatype is used between noDataValue and Cell Value to prevent missing
				// digits on scientific notation
				double noDataValue = 0;

				if(type == MapWinGIS.GridDataType.LongDataType)
					noDataValue = (double)Math.Round(double.Parse(grid.Header.NodataValue.ToString()));
				else if(type == MapWinGIS.GridDataType.DoubleDataType)
					noDataValue = double.Parse(grid.Header.NodataValue.ToString());
				else if(type == MapWinGIS.GridDataType.FloatDataType)
					noDataValue = (double)float.Parse(grid.Header.NodataValue.ToString());
				else if(type == MapWinGIS.GridDataType.ShortDataType)
					noDataValue = (double)short.Parse(grid.Header.NodataValue.ToString());

                bool WarnedBefore = false;
				//find all the values and the count
				for(int row = startRow; row <= endRow; row++)
					for(int col = startCol; col <= endCol; col++)
					{
                        try
                        {
						//System.Diagnostics.Debug.WriteLine("Col: " + col + " Row: " + row);
						//System.Diagnostics.Debug.WriteLine(grid.get_Value(col,row).ToString());
						if(type == MapWinGIS.GridDataType.LongDataType)
							cellValue = long.Parse(grid.get_Value(col,row).ToString());
						else if(type == MapWinGIS.GridDataType.DoubleDataType)
							cellValue = double.Parse(grid.get_Value(col,row).ToString());
						else if(type == MapWinGIS.GridDataType.FloatDataType)
							cellValue = float.Parse(grid.get_Value(col,row).ToString());
						else if(type == MapWinGIS.GridDataType.ShortDataType)
							cellValue = short.Parse(grid.get_Value(col,row).ToString());
												
						//ignore the value if it is a no data value
                        // Assume that if the value and the nodata value are both very near min long, it's nodata (float rounding errors)
                        if (cellValue != noDataValue && !(cellValue < -2147483640 && noDataValue < -2147483640))
                        {
                            //if the table contains the value then increment the count
                            if (table.Contains(cellValue))
                            {
                                gridValue = (GridValue)table[cellValue];
                                gridValue.count++;
                                table[cellValue] = gridValue;
                            }
                            //add a new value to the table.
                            // Cap to maximum size of unique values
                            else if (table.Count < 10000)
                            {
                                gridValue = new GridValue();
                                gridValue.cellValue = cellValue;
                                gridValue.count = 1;
                                table.Add(cellValue, gridValue);
                            }
                            else
                            {
                                if (!WarnedBefore)
                                {
                                    MapWinUtility.Logger.Message("Warning: Exceeded maximum cap of 10,000 unique values in the table. Some values may be ommitted.", "Exceeded Max Unique Values", MessageBoxButtons.OK, MessageBoxIcon.Information, DialogResult.OK);
                                    WarnedBefore = true;
                                }
                            }
                        }
                       }
                       catch (FormatException)
                       {
                           // Probably a bad nodata value.
                       }
					}

				if(table.Count > 0)
				{
					IDictionaryEnumerator myEnumerator = table.GetEnumerator();

					//itialize the high and low values
					myEnumerator.MoveNext();
					double high = ((GridValue)myEnumerator.Value).cellValue;
					double low = ((GridValue)myEnumerator.Value).cellValue;
					myEnumerator.Reset();

					//move to the next value in the hashtable
					while (myEnumerator.MoveNext() )
					{
						gridValue = (GridValue)myEnumerator.Value;
                        string s = gridValue.cellValue.ToString();
                        double ds = 0;
                        double.TryParse(s, out ds);

                        if (m_parent.m_MapWin.Layers[LyrHandle].ColoringScheme != null)
                        {
                            MapWinGIS.GridColorScheme sch = (MapWinGIS.GridColorScheme)m_parent.m_MapWin.Layers[LyrHandle].ColoringScheme;
                            for (int z = 0; z < sch.NumBreaks; z++)
                            {
                                MapWinGIS.GridColorBreak brk = sch.get_Break(z);
                                double compareStart = 0;
                                double compareEnd = 0;
                                if (double.TryParse(brk.HighValue.ToString(), out compareEnd) && double.TryParse(brk.LowValue.ToString(), out compareStart))
                                {
                                    if (compareEnd >= ds && compareStart <= ds && brk.Caption != "")
                                    {
                                        s += " (" + brk.Caption + ")";
                                        break;
                                    }
                                }
                                else
                                {
                                    if (brk.HighValue.ToString() == s && brk.LowValue.ToString() == s && brk.Caption != "")
                                    {
                                        s += " (" + brk.Caption + ")";
                                        break;
                                    }
                                }
                            }
                        }

                        dataset.Tables[0].Rows.Add(s, gridValue.count.ToString());
                        						
						//keep track of the high and low values in the hashtable
						if(gridValue.cellValue > high)
							high = gridValue.cellValue;

						if(gridValue.cellValue < low)
							low = gridValue.cellValue;
					}

					lbHighValue.Text = high.ToString();
					lbLowValue.Text = low.ToString();
				}
				//the region that was selected was out of the grid bounds
				else
				{
					lbHighValue.Text = "No Data";
					lbLowValue.Text = "No Data";
				}
			}
			catch(System.Exception ex)
			{
				ShowErrorBox("PopulateLV()",ex.Message);
			}
		}
			
		private MapWinGIS.Extents GetMaxExtents(MapWinGIS.Extents ex,MapWinGIS.GridHeader header)
		{
			MapWinGIS.Extents extents = new MapWinGIS.ExtentsClass();
			double xMin=0, xMax=0, yMin=0, yMax=0;
			double newXMin=0, newXMax=0, newYMin=0, newYMax=0;
			
			//find the grid Max and Min extents
			xMin = header.XllCenter;
			yMin = header.YllCenter;
			xMax = header.XllCenter + header.dX * header.NumberCols;
			yMax = header.YllCenter + header.dY * header.NumberRows;

			if(ex == null)
			{
				return null;
			}
			else if(ex.xMax < xMin || ex.yMax < yMin || ex.xMin > xMax || ex.yMin > yMax)
			{
				//out of bounds return nothing
				return null;
			}
			else
			{
				//check to make sure the selected bounds are within the grid
				if(ex.xMin < xMin)
					newXMin = xMin;
				else
					newXMin = ex.xMin;

				if(ex.yMin < yMin)
					newYMin = yMin;
				else
					newYMin = ex.yMin;

				if(ex.xMax > xMax)
					newXMax = xMax;
				else
					newXMax = ex.xMax;

				if(ex.yMax > yMax)
					newYMax = yMax;
				else
					newYMax = ex.yMax;

				extents.SetBounds(newXMin,newYMin,0,newXMax,newYMax,0);
			}

			return extents;
		}
		
		private void SetTitle(string layerName)
		{
			this.Text = "Identifier - " + layerName;
		}

		private void frmGridProp_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = true;
			Unitialize();
			m_parent.Activated = false;
            if (!m_HavePanel) this.Hide();
            m_parent.Deactivate();
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			m_parent.Activated = false;
			Unitialize();
			if (!m_HavePanel) this.Hide();
            m_parent.Deactivate();
		}

		public void Unitialize()
		{
			m_parent.m_MapWin.View.Draw.ClearDrawing(m_hDraw);
			m_Grid = null;
			m_hDraw = -1;
		}

		private void DisplaySelectedValues(double SelValue)
		{
            if (SkipDisplayValues) return;
            if (m_Extents == null || m_Grid == null) return;

			try
			{
				int endRow =0, endCol = 0;
				int startRow = 0,startCol = 0;
				double x=0, y=0;
				double cellValue=0;

				//find the begining and end cells
				m_Grid.ProjToCell(m_Extents.xMin,m_Extents.yMax,out startCol,out startRow);
				m_Grid.ProjToCell(m_Extents.xMax,m_Extents.yMin,out endCol,out endRow);
						
				//get the data type of the grid
				MapWinGIS.GridDataType type = m_Grid.DataType;

				//creat a drawing suface
				if(m_hDraw == -1)
					m_hDraw = m_parent.m_MapWin.View.Draw.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList);
				else
				{
					m_parent.m_MapWin.View.Draw.ClearDrawing(m_hDraw);
					m_hDraw = m_parent.m_MapWin.View.Draw.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList);
				}
		
				//display all the selected values
				for(int row = startRow; row <= endRow; row++)
					for(int col = startCol; col <= endCol; col++)
					{
						if(type == MapWinGIS.GridDataType.LongDataType)
							cellValue = int.Parse(m_Grid.get_Value(col,row).ToString());
						else if(type == MapWinGIS.GridDataType.DoubleDataType)
							cellValue = double.Parse(m_Grid.get_Value(col,row).ToString());
						else if(type == MapWinGIS.GridDataType.FloatDataType)
							cellValue = float.Parse(m_Grid.get_Value(col,row).ToString());
						else if(type == MapWinGIS.GridDataType.ShortDataType)
                            cellValue = short.Parse(m_Grid.get_Value(col, row).ToString());
					
						if(Math.Round(SelValue,8) == Math.Round(cellValue,8))
						{
							m_Grid.CellToProj(col,row,out x,out y);
							m_parent.m_MapWin.View.Draw.DrawPoint(x,y,3,RED);
						}
					}
			}
			catch(System.Exception ex)
			{
				ShowErrorBox("DisplaySelectedValues()",ex.Message);
			}
		}

		private void ShowErrorBox(string functionName,string errorMsg)
		{
			MapWinUtility.Logger.Message("Error in " + functionName + ", Message: " + errorMsg,"Identifier",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error, DialogResult.OK);
		}

		private void LinkHighValue_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
            double d = 0;
            if (lbHighValue.Text != "No Data" && double.TryParse(lbHighValue.Text, out d))
            {
                DisplaySelectedValues(d);
            }
		}

		private void LinkLowValue_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
            double d = 0;
            if (lbLowValue.Text != "No Data" && double.TryParse(lbLowValue.Text, out d))
            {
                DisplaySelectedValues(d);
            }
		}

        private void dockImage_Click(object sender, EventArgs e)
        {
            m_parent.ToggleDockedStatus(this, panel1);
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                if (dgv.SelectedRows[0].Cells.Count > 0)
                {
                    double SelValue = 0;
                    string s = dgv.SelectedRows[0].Cells[0].Value.ToString();
                    if (s.Contains(" (")) s = s.Substring(0, s.IndexOf(" ("));
                    double.TryParse(s, out SelValue);
                    DisplaySelectedValues(SelValue);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = m_parent.m_MapWin.Layers[m_parent.m_MapWin.Layers.CurrentLayer].ToString() + Environment.NewLine + Environment.NewLine + "Value" + Convert.ToChar(9) + "Count" + Environment.NewLine;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                s += dgv.Rows[i].Cells[0].Value.ToString() + Convert.ToChar(9) + dgv.Rows[i].Cells[1].Value.ToString() + Environment.NewLine;
            }
            Clipboard.SetText(s);
        }

        private void dgv_Sorted(object sender, EventArgs e)
        {
            while (dgv.SelectedRows.Count > 0)
                dgv.SelectedRows[0].Selected = false;

            if (MostRecentlySelectedValue != "")
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (dgv.Rows[i].Cells.Count > 0)
                    {
                        if (dgv.Rows[i].Cells[0].Value.ToString().StartsWith(MostRecentlySelectedValue))
                        {
                            dgv.Rows[i].Selected = true;
                            dgv.FirstDisplayedScrollingRowIndex = i;
                            return;
                        }
                    }
                }
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (dgv.Rows[e.RowIndex].Selected)
                MostRecentlySelectedValue = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
            else
                MostRecentlySelectedValue = "";
        }
    }
}
