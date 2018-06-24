//********************************************************************************************************
//File name: ClipGridWithPoly.cs
//Description: Internal class for grid clipping.
//********************************************************************************************************
//The contents of this file are subject to the Mozilla Public License Version 1.1 (the "License"); 
//you may not use this file except in compliance with the License. You may obtain a copy of the License at 
//http://www.mozilla.org/MPL/ 
//Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF 
//ANY KIND, either express or implied. See the License for the specific language governing rights and 
//limitations under the License. 
//
//The Original Code is MapWindow Open Source. 
//
//Contributor(s): (Open source contributors should list themselves and their modifications here). 
//9-1-05 ah - Angela Hillier - Created grid clipping method.
//2-10-06 ah - Angela Hillier - updated with memory and speed optimizations							
//4-14-06 mg - Mark Gray - speed optimizations and change to using new PointInPoly
//********************************************************************************************************
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace MapWinGeoProc
{
	/// <summary>
	/// Clips a grid so that it contains only data that falls within the polygon.
	/// </summary>
	internal class ClipGridWithPoly
	{
		private static string gErrorMsg = "";

		#region ClipGridWithPolygon()
		/// <summary>
		/// Creates a new grid containing data from the input grid that
		/// falls within the polygon boundary.
		/// </summary>
		/// <param name="inputGF">Full path to the input grid file.</param>
		/// <param name="poly">The 2D polygon used for clipping the input grid.</param>
		/// <param name="resultGF">Full path to where the resulting grid will be saved.</param>
		/// <param name="clipToExtents">True if clipping to polygon extents rather than actual polygon shape.</param>
		/// <returns>True if clipping was successful, false if an error occurs.</returns>
		public static bool ClipGridWithPolygon(ref string inputGF, ref MapWinGIS.Shape poly, ref string resultGF, bool clipToExtents)
		{
            MapWinUtility.Logger.Dbg("ClipGridWithPolygon(inputGF: " + inputGF + ",\n" +
                                     "                    poly: " + Macro.ParamName(poly) + ",\n" +
                                     "                    resultGF: " + resultGF + ",\n" +
                                     "                    clipToExtents: " + clipToExtents.ToString());
			Error.ClearErrorLog();
			//			System.Diagnostics.PerformanceCounter ramCounter;
			//			ramCounter = new PerformanceCounter("Memory", "Available Bytes");
			//			float availableRAM = ramCounter.NextValue();
			bool inRAM = true;	
			
			//open grid to get info and traverse through points
			MapWinGIS.Grid grid = new MapWinGIS.GridClass();

			//check memory availability
			//			availableRAM = ramCounter.NextValue();//amount of RAM in bytes
			//			Debug.WriteLine("available RAM: " + availableRAM.ToString() + " bytes");
					
			//			System.IO.FileInfo fileInfo = new FileInfo(inputGF);
			//			long fileSize = fileInfo.Length; //size of file in bytes
			//			Debug.WriteLine("file size: " + fileSize.ToString() + " bytes");
			//			if(fileSize*2 < availableRAM)
			//			{//go ahead and load grid into memory
			//				inRAM = true;
			//			}
			//			else
			//			{
			//				inRAM = false;
			//			}
			if(grid.Open(inputGF, MapWinGIS.GridDataType.UnknownDataType, inRAM, MapWinGIS.GridFileType.UseExtension, null) == false)
			{
				gErrorMsg = "Error occurred while trying to open grid: " + grid.get_ErrorMsg(grid.LastErrorCode);
				Error.SetErrorMsg(gErrorMsg);
				Debug.WriteLine(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
				return false;
			}

			int numCols = grid.Header.NumberCols;
			int numRows = grid.Header.NumberRows;
			double cellWidth = grid.Header.dX;
			double cellHeight = grid.Header.dY;
			double xllCenter = grid.Header.XllCenter;
			double yllCenter = grid.Header.YllCenter;
			//now calculate the UNCOMPRESSED grid file size:
			long inputGFSize = numCols * numRows * 8;

			//find the grid extents
			double minX, maxX, minY, maxY;
			minX = xllCenter - (cellWidth/2);
			maxX = xllCenter + (cellWidth * (numCols-1)) + (cellWidth/2);
			minY = yllCenter - (cellHeight / 2);
			maxY = yllCenter + (cellHeight * (numRows-1)) + (cellHeight/2);
			
			//see if grid and poly extents cross:
			double polyMinX = poly.Extents.xMin;
			double polyMaxX = poly.Extents.xMax;
			double polyMinY = poly.Extents.yMin;
			double polyMaxY = poly.Extents.yMax;
			
			bool boundsIntersect = Globals.CheckBounds(minX, maxX, minY, maxY, polyMinX, polyMaxX, polyMinY, polyMaxY);

			if(boundsIntersect == false)
			{
                grid.Close();
				gErrorMsg = "Polygon and Grid boundaries do not overlap.";
				Error.SetErrorMsg(gErrorMsg);
				Debug.WriteLine(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
				return false;
			}

			double newXll, newYll, firstXPt, firstYPt;
			int newNumCols, newNumRows, firstCol, firstRow;

			//check if polygon extents are completely inside of grid extents
			if((polyMinX >= minX && polyMinX <= maxX) && (polyMaxX >= minX && polyMaxX <= maxX) 
				&& (polyMinY >= minY && polyMinY <= maxY) && (polyMaxY >= minY && polyMaxY <= maxY))
			{
				Debug.WriteLine("Poly extents are inside of grid extents.");
				minX = polyMinX;
				minY = polyMinY;
				maxX = polyMaxX;
				maxY = polyMaxY;

				//Find the new number of cols, rows, Xll and Yll values.
				int lastCol, lastRow;
				Globals.ProjToCell(minX, maxY, out firstCol, out firstRow, xllCenter, yllCenter, cellWidth, cellHeight, numRows);
				Globals.ProjToCell(maxX, minY, out lastCol, out lastRow, xllCenter, yllCenter, cellWidth, cellHeight, numRows);
				newNumCols = (lastCol - firstCol) + 1;
				newNumRows = (lastRow - firstRow) + 1;
				Debug.WriteLine("New numRows = " + newNumRows + " New numCols = " + newNumCols);
				Globals.CellToProj(firstCol, lastRow, out newXll, out newYll, xllCenter, yllCenter, cellWidth, cellHeight, numRows);
				Globals.CellToProj(firstCol, firstRow, out firstXPt, out firstYPt, xllCenter, yllCenter, cellWidth, cellHeight, numRows);
			}

				//check if grid extents are completely inside of polygon extents
				//note: there is really no purpose in this, as the new grid is the same
				//as the orgiginal grid....but we'll do it anyway.
			else if((minX >= polyMinX && minX <= polyMaxX) && (maxX >= polyMinX && maxX <= polyMaxX)
				&&(minY >= polyMinY && minY <= polyMaxY) && (maxY >= polyMinY && maxY <= polyMaxY))
			{
				Debug.WriteLine("Grid extents are inside of polygon extents.");
				//keep min and max values the same....no need to change them.
				newNumCols = numCols;
				newNumRows = numRows;
				newXll = xllCenter;
				newYll = yllCenter;
				firstCol = 0;
				firstRow = 0;
				Globals.CellToProj(0, 0, out firstXPt, out firstYPt, xllCenter, yllCenter, cellWidth, cellHeight, numRows);
			}
			else //part of polygon lies outside of the grid, find intersecting boundary shape
			{
				Debug.WriteLine("Grid extents and polygon extents overlap.");
				//create a new shape out of the grid extents
				MapWinGIS.Shape gridEnvelope = new MapWinGIS.ShapeClass();
				gridEnvelope.Create(MapWinGIS.ShpfileType.SHP_POLYGON);
				MapWinGIS.Point pt = new MapWinGIS.PointClass();
				pt.x = minX;
				pt.y = maxY;
				int ptIndex = 0;
				gridEnvelope.InsertPoint(pt, ref ptIndex);
				pt = new MapWinGIS.PointClass();
				pt.x = maxX;
				pt.y = maxY;
				ptIndex = 1;
				gridEnvelope.InsertPoint(pt, ref ptIndex);
				pt = new MapWinGIS.PointClass();
				pt.x = maxX;
				pt.y = minY;
				ptIndex = 2;
				gridEnvelope.InsertPoint(pt, ref ptIndex);
				pt = new MapWinGIS.PointClass();
				pt.x = minX;
				pt.y = minY;
				ptIndex = 3;
				gridEnvelope.InsertPoint(pt, ref ptIndex);
				pt = new MapWinGIS.PointClass();
				pt.x = minX;
				pt.y = maxY;
				ptIndex = 4;
				gridEnvelope.InsertPoint(pt, ref ptIndex);

				//create the final bounding envelope which is
				//the intersection of the polygon and grid envelope:
				MapWinGIS.Shape envelope = new MapWinGIS.ShapeClass();
				envelope.Create(MapWinGIS.ShpfileType.SHP_POLYGON);
				envelope = SpatialOperations.Intersection(gridEnvelope, poly);
				if(envelope.numPoints == 0)
				{
					gErrorMsg = "Problem creating the bounding envelope. Aborting ClipGrid().";
					Error.SetErrorMsg(gErrorMsg);
					Debug.WriteLine(gErrorMsg);
                    MapWinUtility.Logger.Dbg(gErrorMsg);
					return false;
				}

				//calculate how many rows and columns will exist within the new grid
				//that is: how many rows/cols fit within the bounding envelope.
				minX = envelope.Extents.xMin;
				minY = envelope.Extents.yMin;
				maxX = envelope.Extents.xMax;
				maxY = envelope.Extents.yMax;

				newNumCols = (int)(((maxX - minX)/cellWidth) + 0.5);
				newNumRows = (int)(((maxY - minY)/cellHeight) + 0.5);
				newXll = minX + (cellWidth/2);
				newYll = minY + (cellHeight/2);
				firstXPt = newXll;
				firstYPt = newYll + (cellHeight * (newNumRows-1));
				Globals.ProjToCell(firstXPt, firstYPt, out firstCol, out firstRow, xllCenter, yllCenter, cellWidth, cellHeight, numRows);			
			
				//done using COM objects, release them
				while(Marshal.ReleaseComObject(pt)!= 0);
				pt = null;
				while(Marshal.ReleaseComObject(gridEnvelope) != 0);
				gridEnvelope = null;
				while(Marshal.ReleaseComObject(envelope) != 0);
				envelope = null;
			}

            // Chris M 12/13/2006 for BugZilla 377
            // Below code:
            // The grid header cannot be copied right across like that! The first line creates 
            // a new grid header; the second line deletes the newly created grid header and 
            // copies a reference to the original grid's header. Both grids then are using
            // the same header; and when the last lines set the XllCenter and YllCenter,
            // BOTH grids are updated with that information! A classic example of pointers gone wrong.
            //MapWinGIS.GridHeader resultHeader = new MapWinGIS.GridHeaderClass();
            //resultHeader = grid.Header;
            //resultHeader.NodataValue = grid.Header.NodataValue;
            //resultHeader.NumberCols = newNumCols;
            //resultHeader.NumberRows = newNumRows;
            //resultHeader.XllCenter = newXll;
            //resultHeader.YllCenter = newYll;
            // The right way to do it:
            MapWinGIS.GridHeader resultHeader = new MapWinGIS.GridHeaderClass();
            resultHeader.CopyFrom(grid.Header);
            // Not really needed due to CopyFrom: resultHeader.NodataValue = grid.Header.NodataValue;
            resultHeader.NumberCols = newNumCols;
            resultHeader.NumberRows = newNumRows;
            resultHeader.XllCenter = newXll;
            resultHeader.YllCenter = newYll;
            // Not really needed due to CopyFrom: resultHeader.dX = grid.Header.dX;
            // Not really needed due to CopyFrom: resultHeader.dY = grid.Header.dY;
            // Not really needed due to CopyFrom: resultHeader.Projection = grid.Header.Projection;
            
            //create the new grid object
			MapWinGIS.Grid resultGrid = new MapWinGIS.GridClass();
			DataManagement.DeleteGrid(ref resultGF);

			//check memory availability
			//			availableRAM = ramCounter.NextValue();//amount of RAM in bytes
			//			Debug.WriteLine("available RAM: " + availableRAM.ToString() + " bytes");
					
			long resultGFSize = newNumCols * newNumRows * 8; //projected size of grid in bytes
			//			if(resultGFSize * 2 < availableRAM)
			//			{//go ahead and load grid into memory
			//				inRAM = true;
			//			}
			//			else
			//			{
			//				inRAM = false;
			//			}

			if(resultGrid.CreateNew(resultGF, resultHeader, grid.DataType, grid.Header.NodataValue, inRAM, MapWinGIS.GridFileType.UseExtension, null) == false)
			{
				gErrorMsg = "Problem creating the result grid: " + resultGrid.get_ErrorMsg(resultGrid.LastErrorCode);
				Debug.WriteLine(gErrorMsg);
				Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
				return false;
			}
			//close the grids, we need to use the wrapper class now due to memory issues
			resultGrid.Save(resultGF, MapWinGIS.GridFileType.UseExtension, null);
			resultGrid.Close();
			while(Marshal.ReleaseComObject(resultGrid) != 0);
			resultGrid = null;
			grid.Close();
			while(Marshal.ReleaseComObject(grid) != 0);
			grid = null;

			//fill the result grid with values from the original grid
			try
			{
				Debug.WriteLine("newNumRows = " + newNumRows + " newNumCols = " + newNumCols);

				int rowClearCount = Globals.DetermineRowClearCount(newNumRows, newNumCols);			

				Debug.WriteLine("Clearing COM resources every " + rowClearCount + " rows.");

				if(FillGrid(ref inputGF, ref resultGF, ref poly, newNumRows, newNumCols, rowClearCount, firstCol, firstRow, firstXPt, firstYPt, clipToExtents) == false)
				{
                    MapWinUtility.Logger.Dbg("Error running FillGrid\n");
					return false;
				}

			}//end of try block
			catch(Exception e)
			{
				gErrorMsg = e.Message + e.ToString();
				Debug.WriteLine(gErrorMsg);
				Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
				return false;
			}
			

			//NOTE: The need for trimGrid has been removed from this function.
			//It will always return the smallest possible grid because we
			//build it based on the intersection boundary.
			
            DataManagement.CopyGridLegend(inputGF, resultGF);
            MapWinUtility.Logger.Dbg("Finished ClipGridWithPolygon");
			return true;	
		}
		#endregion

		#region private FillGrid() -- used by ClipGridWithPoly()
		/// <summary>
		/// Fills the result grid with values from the input grid.
		/// </summary>
		/// <param name="inputGF">The path to the input grid.</param>
		/// <param name="resultGF">The path to the result grid.</param>
		/// <param name="poly">The polygon used in clipping.</param>
		/// <param name="newNumRows">The number of rows in the result grid.</param>
		/// <param name="newNumCols">The number of cols in the result grid.</param>
		/// <param name="rowClearCount">The number of rows that should be filled before
		/// the unmanaged resources are disposed of.</param>
		/// <param name="firstCol">The first column of the original grid that corresponds to the first column of the result grid.</param>
		/// <param name="firstRow">The first row of the original grid that corresponds to the first row of the result grid.</param>
		/// <param name="firstXPt">The X value (minX) of the first point in the result grid.</param>
		/// <param name="firstYPt">The Y value (maxY) of the first point in the result grid.(</param>
		/// <param name="clipToExtents">True if clipping to extents rather than polygon shape.</param>
		/// <returns>False if an error was encountered, true otherwise.</returns>
		private static bool FillGrid(ref string inputGF, ref string resultGF, ref MapWinGIS.Shape poly, int newNumRows, int newNumCols, int rowClearCount, int firstCol, int firstRow, double firstXPt, double firstYPt, bool clipToExtents)
		{
			//			System.Diagnostics.PerformanceCounter ramCounter;
			//			ramCounter = new PerformanceCounter("Memory", "Available Bytes");
			//			float availableRAM = ramCounter.NextValue();
			bool inRAM = true;
			bool status = true;
			int startRow = 0;
			int lastRow = newNumRows - 1;
			GridWrapper inputGW = new GridWrapper();
			GridWrapper resultGW = new GridWrapper();
			//variables associated with input grid:
			int oldNumCols = 0;
			double cellWidth = 0;
			double cellHeight = 0;
			double yPt = 0;

			int numParts = poly.NumParts;
			if(numParts == 0)
			{
				numParts = 1;
			}
			Globals.Vertex[][] polyVertArray = new Globals.Vertex[numParts][];
			Globals.ConvertPolyToVertexArray(ref poly, out polyVertArray);

			for(int row = startRow; row <= lastRow; row++)
			{
				if(row == startRow)
				{
					inputGW = new GridWrapper();
					if(inputGW.Open(inputGF, inRAM) == false)
					{
						status = false;
						break;
					}
								
					resultGW = new GridWrapper();
					if(resultGW.Open(resultGF, inRAM) == false)
					{
						status = false;
						break;
					}

					if(row == 0)
					{
						//initialize variables
						cellWidth = inputGW.GetCellWidth();
						cellHeight = inputGW.GetCellHeight();
						oldNumCols = inputGW.GetNumCols();
					}
					
					yPt = firstYPt - (cellHeight * row);

					if(FillRow(inputGW, resultGW, ref polyVertArray, row, firstXPt, yPt, firstCol, firstRow, cellWidth, newNumCols, oldNumCols, clipToExtents) == false)
					{
						status = false;
						break;
					}
                    
				}
					//dispose of COM objects every "rowClearCount" iterations to give memory a chance to be released by GC
					//TODO: Calculate how often we should dispose of resources (expensive) based on
					//amount of RAM available and size of grid being created.
				else if(row == startRow + rowClearCount)
				{
					if(resultGW.Save(resultGF) == false)
					{
						status = false;
						break;
					}
					startRow += rowClearCount;
					inputGW.Dispose();
					inputGW = null;
					resultGW.Dispose();
					resultGW = null;
					row = startRow - 1;
					continue;
				}
				else
				{
					yPt = firstYPt - (cellHeight * row);//adjust y value according to current row

					if(FillRow(inputGW, resultGW, ref polyVertArray, row, firstXPt, yPt, firstCol, firstRow, cellWidth, newNumCols, oldNumCols, clipToExtents) == false)
					{
						status = false;
						break;
					}
				}

			}//end of looping through rows

			if(inputGW != null)
			{
				inputGW.Dispose();
				inputGW = null;
			}
			if(resultGW != null)
			{
				if(resultGW.Save(resultGF) == false)
				{
					status = false;
				}
				resultGW.Dispose();
				resultGW = null;
			}
			return status;
		}
		#endregion

		#region private FillRow() -- used by FillGrid()
		//NOTE: Some may wonder why I am calling this as a separate function,
		//after several time tests, it was found that it is actually faster to
		//fill the columns in an outside function than by putting this same code inside
		//of the fill row function. Also, the Garbage Collector is faster at releasing
		//resources by having this as a separate routine. -- Angela Hillier 2/14/06
		/// <summary>
		/// Fills a single row in the result grid with values from the input grid
		/// that fall within the polygon shape (or extents, if clipToExtents == true).
		/// </summary>
		/// <param name="inputGW">The wrapper object for the input grid.</param>
		/// <param name="resultGW">The wrapper object for the result grid.</param>
		/// <param name="polyVertArray">Array[numParts][numPointsPerPart] containing the polygon vertices.</param>
		/// <param name="row">The row to be filled.</param>
		/// <param name="firstXPt">The starting x position of the initial row.</param>
		/// <param name="yPt">The starting y position of the row.</param>
		/// <param name="firstCol">The first column of the input grid that will be used for filling.</param>
		/// <param name="firstRow">The row of the input grid that corresponds to the current row of the result grid.</param>
		/// <param name="cellWidth">dX value of the result grid.</param>
		/// <param name="newNumCols">The number of columns in the result grid.</param>
		/// <param name="oldNumCols">The number of columns in the input grid.</param>
		/// <param name="clipToExtents">True if clipping to polygon extents rather than actual polygon shape.</param>
		/// <returns></returns>
		private static bool FillRow(GridWrapper inputGW, GridWrapper resultGW, ref Globals.Vertex[][] polyVertArray, int row, double firstXPt, double yPt, int firstCol, int firstRow, double cellWidth, int newNumCols, int oldNumCols, bool clipToExtents)
		{
            //MapWinUtility.Logger.Dbg("FillRow(inputGW: " + Macro.ParamName(inputGW, inputGW. , GridWrapper resultGW, ref Globals.Vertex[][] polyVertArray, int row, double firstXPt, double yPt, int firstCol, int firstRow, double cellWidth, int newNumCols, int oldNumCols, bool clipToExtents)
			int oldCol = firstCol;
			int oldRow = firstRow + row;			
			double xPt = firstXPt;
			float noDataValue = float.Parse(inputGW.GetNodataValue().ToString());
			
			float[] oldRowArray = new float[oldNumCols];
			if(inputGW.get_Row(oldRow, ref oldRowArray) == false)
			{
				gErrorMsg = "Failed to get row " + oldRow + " from input grid.";
				Debug.WriteLine(gErrorMsg);
				Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
				return false;
			}
			
			float[] newRowArray = new float[newNumCols];
			Array.Copy(oldRowArray, firstCol, newRowArray, 0, newNumCols);
			if(clipToExtents == false)
			{
				int lastNewCol = newNumCols - 1;
				for(int col = 0; col <= lastNewCol; col++)
				{
					oldCol = firstCol + col;
					xPt = firstXPt + (cellWidth * col);
					if(Utils.PointInPoly(ref polyVertArray, xPt, yPt) == false)
					{
						newRowArray[col] = noDataValue;
					}
				}
			}
			resultGW.set_Row(row, ref newRowArray);
            // This produces excessive output in real runs -> MapWinUtility.Logger.Dbg("Finished FillRow");
			return true;
		}
		#endregion
	}

}