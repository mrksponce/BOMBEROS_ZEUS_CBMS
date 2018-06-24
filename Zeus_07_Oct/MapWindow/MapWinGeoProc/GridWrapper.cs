//********************************************************************************************************
//File name: GridWrapper.cs
//Description: Internal class, wrapper for the MapWinGIS COM grid class.
//********************************************************************************************************
//The contents of this file are subject to the Mozilla Public License Version 1.1 (the "License"); 
//you may not use this file except in compliance with the License. You may obtain a copy of the License at 
//http://www.mozilla.org/MPL/ 
//Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF 
//ANY KIND, either express or implied. See the License for the specificlanguage governing rights and 
//limitations under the License. 
//
//The Original Code is MapWindow Open Source. 
//
//Contributor(s): (Open source contributors should list themselves and their modifications here). 
//1-20-06 - Angela Hillier - created wrapper for heavy use of the COM grid object to insure proper memory disposal.
//********************************************************************************************************
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MapWinGeoProc
{
	/// <summary>
	/// Summary description for GridWrapper.
	/// </summary>
	internal class GridWrapper:IDisposable
	{
		// External unmanaged resource.
		private MapWinGIS.Grid grid;
		// Other managed resource this class uses.
		private string gErrorMsg = "";
		// Track whether Dispose has been called.
		private bool disposed = false;

		
		public GridWrapper()
		{
			grid = new MapWinGIS.GridClass();
		}

		#region IDisposable Members

		//Implement IDisposable.
		public void Dispose() 
		{
			//Trace.WriteLine("GridWrapper: Dispose");
			// dispose of the managed and unmanaged resources
			Dispose(true);

			// tell the GC that the Finalize process no longer needs
			// to be run for this object.
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposeManagedResources) 
		{
			// process only if mananged and unmanaged resources have
			// not been disposed of.
			if (!this.disposed)
			{
				//Trace.WriteLine("GridWrapper: Resources not disposed");
				if (disposeManagedResources)
				{
					//Trace.WriteLine("GridWrapper: Disposing managed resources");
					// dispose managed resources
					gErrorMsg = null;
				}
				// dispose unmanaged resources
				//Trace.WriteLine("GridWrapper: Disposing unmanaged resouces");
				if (grid != null)
				{
					//Trace.WriteLine("GridWrapper: Disposing of grid COM object");
					grid.Close();
					while(Marshal.ReleaseComObject(grid) != 0);
					grid = null;
				}
				disposed=true;
			}
			else
			{
				Trace.WriteLine("GridWrapper: Resources already disposed");
			}			
		}

		// Use C# destructor syntax for finalization code.
		~GridWrapper()
		{
			//Trace.WriteLine("GridWrapper: Destructor");
			// call Dispose with false.  Since we're in the
			// destructor call, the managed resources will be
			// disposed of anyways.
			Dispose(false);
		}

		#endregion

		#region MapWinGIS Grid Members
		
		public bool Open(string gridFile, bool inRAM)
		{
			if(grid.Open(gridFile, MapWinGIS.GridDataType.UnknownDataType, inRAM, MapWinGIS.GridFileType.UseExtension, null) == false)
			{
				gErrorMsg = "Problem opening grid: " + grid.get_ErrorMsg(grid.LastErrorCode);
				Error.SetErrorMsg(gErrorMsg);
				Debug.WriteLine(gErrorMsg);
				return false;
			}
			else
			{
				return true;
			}
			
		}

		public bool Save(string gridFile)
		{
			if(grid.Save(gridFile, MapWinGIS.GridFileType.UseExtension, null) == false)
			{
				gErrorMsg = "Problem saving grid: " + grid.get_ErrorMsg(grid.LastErrorCode);
				Error.SetErrorMsg(gErrorMsg);
				Debug.WriteLine(gErrorMsg);
				return false;
			}
			else
			{
				return true;
			}
		}

		public bool Close()
		{
			if(grid.Close() == false)
			{
				gErrorMsg = "Problem saving grid: " + grid.get_ErrorMsg(grid.LastErrorCode);
				Error.SetErrorMsg(gErrorMsg);
				Debug.WriteLine(gErrorMsg);
				return false;
			}
			else
			{
				return true;
			}
		}

		public double GetCellHeight()
		{
			return grid.Header.dY;
		}
		
		public double GetCellWidth()
		{
			return grid.Header.dX;
		}

		public int GetNumCols()
		{
			return grid.Header.NumberCols;
		}

		public int GetNumRows()
		{
			return grid.Header.NumberRows;
		}

		public object GetNodataValue()
		{
			return grid.Header.NodataValue;
		}

        // Dangerous. Too dangerous.
        // Does the caller want a reference to the header so they can change it?
        // Does the caller want a copy of the header that they can safely modify for creating a new (slightly different) grid?
        /*public MapWinGIS.GridHeader GetHeader()
		{
			return grid.Header;
		}*/
        // Create functions explcitly for each so those using it will choose the right one
        public MapWinGIS.GridHeader GetHeaderCopy()
        {
            MapWinGIS.GridHeader newHdr = new MapWinGIS.GridHeader();
            newHdr.CopyFrom(grid.Header);
            return newHdr;
        }
        public MapWinGIS.GridHeader GetHeaderReference()
        {
            // A reference -- i.e., the original may be changed if this
            // header is changed.
            return grid.Header;
        }

		public void ProjToCell(double x, double y, out int col, out int row)
		{
			grid.ProjToCell(x, y, out col, out row);
		}

		public void CellToProj(int col, int row, out double x, out double y)
		{
			grid.CellToProj(col, row, out x, out y);
		}

		public object get_Value(int col, int row)
		{
			return grid.get_Value(col, row);
		}

		public void set_Value(int col, int row, object pVal)
		{
			grid.set_Value(col, row, pVal);
		}

		public bool get_Row(int row, ref float[] valArray)
		{
			//talk to Chris about why this returns false....
			grid.GetRow(row, ref valArray[0]);
			return true;
		}

		public void set_Row(int row, ref float[] valArray)
		{
			grid.PutRow(row, ref valArray[0]);
		}
		
		
		#endregion
	}
}
