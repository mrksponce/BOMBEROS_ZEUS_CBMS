//********************************************************************************************************
//File name: Globals.cs
//Description: Internal class, provides methods for checking bounds, calculating intersect points, deleting shapefiles, etc.
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
//10-17-05 ah - Angela Hillier - Created original class and functions. 							
// 4-14-06 mg - Mark Gray - new algorithm for DetermineRowClearCount, optimizations in TrimGrid
// 7-04-07 sb - Simon Batson - Refactored CopyFields to include renaming of duplicate fieldnames
//                           - Declared FindField as static so it could be used in CopyFields
//********************************************************************************************************
using System;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MapWinGeoProc
{
	/// <summary>
	/// Internal class that provides methods common to several members of MapWinGeoProc.
	/// </summary>
	internal class Globals
	{
		private static string gErrorMsg = "";

		#region RemoveDuplicatePts()
		public static void RemoveDuplicatePts(ref MapWinGIS.Shape shape)
		{
			int numPts = shape.numPoints;
			int ptIndex = 0;
			MapWinGIS.ShpfileType sfType = shape.ShapeType;
			MapWinGIS.Shape resultShp = new MapWinGIS.ShapeClass();
			resultShp.Create(sfType);
			MapWinGIS.Point prevPt = new MapWinGIS.PointClass();
			
			for(int i = 0; i <= numPts-2; i++)
			{				
				MapWinGIS.Point currPt = new MapWinGIS.PointClass();
				currPt = shape.get_Point(i);
				if(i == 0)
				{
					resultShp.InsertPoint(currPt, ref ptIndex);
					prevPt = currPt;
				}
				else
				{
					if(prevPt.x == currPt.x && prevPt.y == currPt.y)
					{
						//don't add this point to the result shape, it is a duplicate point!
					}
					else
					{
						ptIndex = resultShp.numPoints;
						resultShp.InsertPoint(currPt, ref ptIndex);
						prevPt = currPt;
					}
				}
			}

			ptIndex = resultShp.numPoints;
			resultShp.InsertPoint(shape.get_Point(numPts-1), ref ptIndex);
			shape = resultShp;
		}
		#endregion

		#region RemoveColinearPts()
		public static void RemoveColinearPts(ref MapWinGIS.Shape shape)
		{
			int numPts = shape.numPoints;
			int ptIndex = 0;
			MapWinGIS.ShpfileType sfType = shape.ShapeType;
			MapWinGIS.Shape resultShp = new MapWinGIS.ShapeClass();
			resultShp.Create(sfType);

			for(int i = 0; i <= numPts-2; i++)
			{
				MapWinGIS.Point prevPt = new MapWinGIS.PointClass();
				MapWinGIS.Point currPt = new MapWinGIS.PointClass();
				MapWinGIS.Point nextPt = new MapWinGIS.PointClass();
				currPt = shape.get_Point(i);
				nextPt = shape.get_Point(i+1);
				double xDiff = nextPt.x - currPt.x;
				double yDiff = nextPt.y - currPt.y;
				double slope = 0;
				if(xDiff != 0)
				{
					slope = Math.Abs(yDiff/xDiff);
				}
				if(i == 0)
				{
					resultShp.InsertPoint(currPt, ref ptIndex);
					prevPt = currPt;
					ptIndex++;
				}
				else
				{
					double xDiff1 = currPt.x - prevPt.x;
					double yDiff1 = currPt.y - prevPt.y;
					double xDiff2 = nextPt.x - currPt.x;
					double yDiff2 = nextPt.y - currPt.y;
					double slope1 = yDiff1 / xDiff1;
					double slope2 = yDiff2 / xDiff2;
					
					if(xDiff1 == 0 && xDiff2 == 0)//both are vertical
					{
					}
					else if(yDiff1 == 0 && yDiff2 == 0) //both are horizontal
					{
					}
					else if((xDiff1 == 0 && yDiff2 == 0) || (yDiff1 == 0 && xDiff2 == 0))//one is horizontal, the other vertical
					{
						if(currPt.x != prevPt.x || currPt.y != prevPt.y)
						{
							resultShp.InsertPoint(currPt, ref ptIndex);
							prevPt = currPt;
							ptIndex++;
						}
					}
					else if(Math.Abs(slope1) != Math.Abs(slope2)) //the segments do not have the same slope
					{
						if(currPt.x != prevPt.x || currPt.y != prevPt.y)
						{
							resultShp.InsertPoint(currPt, ref ptIndex);
							prevPt = currPt;
							ptIndex++;
						}
					}
				}
				
				if(i+1 == numPts-1)//on last segment
				{
					resultShp.InsertPoint(nextPt, ref ptIndex);
				}
			}
			shape = resultShp;
		}
		#endregion

		#region ReverseSimplePoly()
		/// <summary>
		/// Reverses the orientation of a single-part polgyon.
		/// </summary>
		/// <param name="polygon">Single-part polygon.</param>
		public static void ReverseSimplePoly(ref MapWinGIS.Shape polygon)
		{
			MapWinGIS.Shape reverseShp = new MapWinGIS.ShapeClass();
			reverseShp.Create(polygon.ShapeType);
			int ptIndex = 0;
			int numPoints = polygon.numPoints;
			for(int i = numPoints-1; i >= 0; i--)
			{
				ptIndex = reverseShp.numPoints;
				reverseShp.InsertPoint(polygon.get_Point(i), ref ptIndex);
			}
			polygon = reverseShp;
		}
		#endregion

		#region FixMultiPartPoly()
		/// <summary>
		/// Determines which shapes are holes and which shapes are islands in
		/// a multi-part polygon and fixes their orientations accordingly.
		/// </summary>
		/// <param name="polygon">The multi-part polygon whose parts need to be checked.</param>
		public static void FixMultiPartPoly(ref MapWinGIS.Shape polygon)
		{
			int numParts = polygon.NumParts;
			if(numParts == 0)
			{
				numParts = 1;
			}

			if(numParts == 1)//This isn't really a multiPart polygon, but there is some checking we can do...
			{
				//just make sure it's clockwise
				if(IsClockwise(ref polygon))
				{
					return;
				}
				else
				{
					ReverseSimplePoly(ref polygon);
					return;
				} 
			}
			
			else//Multiple parts exist
			{
				MapWinGIS.Shape[] parts = new MapWinGIS.Shape[numParts];
				SeparateParts(ref polygon, out parts);

				for(int i = 0; i <= numParts-1; i++)
				{
					bool currIsClockwise = IsClockwise(ref parts[i]);
					bool reverse = false;
					bool partIsHole = false;
					
					//Decide if the current part is an island or a hole.
					//Properties of Holes:
					//1) Extents are inside the extents of another part.
					//2) All points are inside the above part.		
					for(int j = 0; j <= numParts-1; j++)
					{
						if(j != i)
						{
							if(ExtentsInside(parts[j].Extents, parts[i].Extents) == true)
							{
								//found a potential hole, do further checking
								MapWinGIS.Point pt = new MapWinGIS.PointClass();
								pt = parts[i].get_Point(0);
								bool ptInside = Utils.PointInPolygon(ref parts[j], ref pt);
								while(Marshal.ReleaseComObject(pt)!= 0);
								pt = null;
								if(ptInside == false)//not a hole of this outer part
								{
									partIsHole = false;
								}
								else//part is a hole
								{
									partIsHole = true;
									break;								
								}
							}
						}
					}//done checking current part against all other parts
					if(partIsHole && currIsClockwise)
					{
						//Hole, make sure it's in counter-clockwise order
						reverse = true;
					}
					else if(!partIsHole && !currIsClockwise)
					{
						//Island, make sure it's in clockwise order
						reverse = true;
					}
					
					if(reverse == true)
					{
						ReverseSimplePoly(ref parts[i]);
					}					
				}//done looping through parts and correcting orientation (if necessary)
			
				MapWinGIS.Shape resultShp = new MapWinGIS.ShapeClass();
				resultShp.Create(polygon.ShapeType);
				CombineParts(ref parts, out resultShp);
				polygon = resultShp;
			}//done with multiple parts
		}
		#endregion

		#region CombineParts()
		/// <summary>
		/// Takes an array of simple polygons and combines them into one multi-part shape.
		/// </summary>
		/// <param name="parts">The array of polygons.</param>
		/// <param name="resultShp">The resulting multi-part shape.</param>
		public static void CombineParts(ref MapWinGIS.Shape[] parts, out MapWinGIS.Shape resultShp)
		{
			int numParts = parts.Length;
			int ptIndex = 0;
			resultShp = new MapWinGIS.ShapeClass();
			resultShp.Create(parts[0].ShapeType);
			for(int i = 0; i <= numParts-1; i++)
			{
				ptIndex = resultShp.numPoints;
				resultShp.InsertPart(ptIndex, ref i);
				
				int numPts = parts[i].numPoints;				
				for(int j = 0; j <= numPts-1; j++)
				{
					ptIndex = resultShp.numPoints;
					resultShp.InsertPoint(parts[i].get_Point(j), ref ptIndex);
				}
			}
		}
		#endregion

		#region ExtentsInside()
		/// <summary>
		/// Finds if the testExtents lie completely inside of the 'outerExtents.'
		/// </summary>
		/// <param name="outerExtents">The extents belonging to the surrounding shape.</param>
		/// <param name="testExtents">The extents belonging to the inner shape.</param>
		/// <returns>True if the test extents are completely inside of the outer extents, false otherwise.</returns>
		public static bool ExtentsInside(MapWinGIS.Extents outerExtents, MapWinGIS.Extents testExtents)
		{
			if((testExtents.xMin >= outerExtents.xMin && testExtents.xMin <= outerExtents.xMax) && (testExtents.xMax >= outerExtents.xMin && testExtents.xMax <= outerExtents.xMax) 
				&& (testExtents.yMin >= outerExtents.yMin && testExtents.yMin <= outerExtents.yMax) && (testExtents.yMax >= outerExtents.yMin && testExtents.yMax <= outerExtents.yMax))
			{
				return true; //testExtents are inside of outerExtents
			}
			return false;
		}
		#endregion

		#region SeparateParts()
		/// <summary>
		/// Separates all parts of a multi-part polygon.
		/// </summary>
		/// <param name="poly">The mulit-part polygon to be separated.</param>
		/// <param name="polyParts">The array that will hold each separated polygon part.</param>
		public static void SeparateParts(ref MapWinGIS.Shape poly, out MapWinGIS.Shape[] polyParts)
		{
			int numParts = poly.NumParts;
			if(numParts == 0)
			{
				numParts = 1;
			}
			int numPoints = poly.numPoints;
			MapWinGIS.Shape[] parts = new MapWinGIS.Shape[numParts];

			if(numParts > 1)
			{
				int begPart, endPart;
				//separate parts of polygon
				for(int i = 0; i <= numParts-1; i++)
				{
					parts[i] = new MapWinGIS.ShapeClass();
					parts[i].Create(poly.ShapeType);
					
					begPart = poly.get_Part(i);
					//Debug.WriteLine("beginning point in part " + i + ": " + begPart);
					if(i < numParts-1)
					{
						endPart = poly.get_Part(i+1);
					}
					else
						endPart = numPoints;

					int ptIndex = 0;
					for(int j = begPart; j <= endPart-1; j++)
					{
						ptIndex = parts[i].numPoints;
						parts[i].InsertPoint(poly.get_Point(j), ref ptIndex);
					}
				}
				polyParts = parts;
			}
			else
			{
				parts[0] = new MapWinGIS.ShapeClass();
				parts[0].Create(poly.ShapeType);
				parts[0] = poly;
				polyParts = parts;
			}
		}
		#endregion

		#region ConvertPolyToVertexArray()
		/// <summary>
		/// Takes a MapWinGIS polygon shape and stores all x/y coordinates into a vertex array.
		/// </summary>
		/// <param name="poly">The polygon to be converted.</param>
		/// <param name="polyVertArray">The array[numParts][] that will contain the polygon vertices.</param>
		public static void ConvertPolyToVertexArray(ref MapWinGIS.Shape poly, out Vertex[][] polyVertArray)
		{
			int numParts = poly.NumParts;
			if(numParts == 0)
			{
				numParts = 1;
			}
			int numPoints = poly.numPoints;
			Globals.Vertex[][] vertArray = new Vertex[numParts][];

			if(numParts > 1)
			{
				int begPart, endPart;
				//separate parts of polygon
				for(int i = 0; i <= numParts-1; i++)
				{
					begPart = poly.get_Part(i);
					//Debug.WriteLine("beginning point in part " + i + ": " + begPart);
					if(i < numParts-1)
					{
						endPart = poly.get_Part(i+1);
					}
					else
						endPart = numPoints;

					int numPtsInPart = endPart - begPart;
					vertArray[i] = new Vertex[numPtsInPart];
					int ptIndex = begPart;
					for(int j = 0; j <= numPtsInPart-2; j++)
					{
						vertArray[i][j] = new Vertex(poly.get_Point(ptIndex).x, poly.get_Point(ptIndex).y);
						ptIndex++;
					}
					//be sure to 'close' the polygon in the vertex array!
					vertArray[i][numPtsInPart-1] = vertArray[i][0];
				}
			}
			else
			{
				//all points in polygon go into same vertex array
				vertArray[0] = new Vertex[numPoints];
				for(int i = 0; i <= numPoints-1; i++)
				{
					vertArray[0][i] = new Vertex(poly.get_Point(i).x, poly.get_Point(i).y);
				}

			}
			polyVertArray = vertArray;
		}
		#endregion

		#region PrepareResultSF()
		/// <summary>
		/// Deletes any file located at resultSFPath and creates a new one (resultSF).
		/// </summary>
		/// <param name="resultSFPath">Full path to where the result file should be saved.</param>
		/// <param name="resultSF">The result shapefile.</param>
		/// <param name="sfType">The MapWinGIS shapefile type.</param>
		/// <returns>False if an error was encountered, true otherwise.</returns>
		public static bool PrepareResultSF(ref string resultSFPath, ref MapWinGIS.Shapefile resultSF, MapWinGIS.ShpfileType sfType)
		{
            return PrepareResultSF(ref resultSFPath, ref resultSF, sfType, false);
		}

        /// <summary>
        /// Deletes any file located at resultSFPath and creates a new one (resultSF).
        /// </summary>
        /// <param name="resultSFPath">Full path to where the result file should be saved.</param>
        /// <param name="resultSF">The result shapefile.</param>
        /// <param name="sfType">The MapWinGIS shapefile type.</param>
        /// <param name="SkipMWShapeIDField">Do not create the MWShapeID field.</param>
        /// <returns>False if an error was encountered, true otherwise.</returns>
        public static bool PrepareResultSF(ref string resultSFPath, ref MapWinGIS.Shapefile resultSF, MapWinGIS.ShpfileType sfType, bool SkipMWShapeIDField)
        {
            DataManagement.DeleteShapefile(ref resultSFPath);
            //create the result shapeFile
            if (resultSF.CreateNew(resultSFPath, sfType) == false)
            {
                gErrorMsg = "Problem creating the result shapeFile: " + resultSF.get_ErrorMsg(resultSF.LastErrorCode);
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                return false;
            }

            if (!SkipMWShapeIDField)
            {
                // Insert the ID field so that it's a valid file:
                MapWinGIS.Field newfld = new MapWinGIS.Field();
                newfld.Key = "MWShapeID";
                newfld.Name = "MWShapeID";
                newfld.Precision = 10;
                newfld.Type = MapWinGIS.FieldType.INTEGER_FIELD;
                int fldIdx = resultSF.NumFields;
                resultSF.EditInsertField(newfld, ref fldIdx, null);
            }

            return true;
        }
        
		#endregion

		#region CheckBounds()
		//Angela Hillier 10/05
		/// <summary>
		/// Checks if two shape boundaries overlap.
		/// </summary>
		/// <param name="shp1">First shape.</param>
		/// <param name="shp2">Second shape.</param>
		/// <returns>True if the boundaries overlap, false otherwise.</returns>
		public static bool CheckBounds(ref MapWinGIS.Shape shp1, ref MapWinGIS.Shape shp2)
		{
			double xMin1, xMax1, yMin1, yMax1, zMin1, zMax1, xMin2, xMax2, yMin2, yMax2, zMin2, zMax2;
			shp1.Extents.GetBounds(out xMin1, out yMin1, out zMin1, out xMax1, out yMax1, out zMax1);
			shp2.Extents.GetBounds(out xMin2, out yMin2, out zMin2, out xMax2, out yMax2, out zMax2);

			if(xMin1 > xMax2 || xMax1 < xMin2 || yMin1 > yMax2 || yMax1 < yMin2)
			{
				return false;
			}
			else
			{
				return true;
			}			
		}

		/// <summary>
		/// Checks if two shape boundaries overlap.
		/// </summary>
		/// <param name="xMin1">Minimum x-value for bounding box 1.</param>
		/// <param name="xMax1">Maximum x-value for bounding box 1.</param>
		/// <param name="yMin1">Minimum y-value for bounding box 1.</param>
		/// <param name="yMax1">Maximum y-value for bounding box 1.</param>
		/// <param name="xMin2">Minimum x-value for bounding box 2.</param>
		/// <param name="xMax2">Maximum x-value for bounding box 2.</param>
		/// <param name="yMin2">Minimum y-value for bounding box 2.</param>
		/// <param name="yMax2">Maximum y-value for bounding box 2.</param>
		/// <returns></returns>
		public static bool CheckBounds(double xMin1, double xMax1, double yMin1, double yMax1,
			double xMin2, double xMax2, double yMin2, double yMax2)
		{
			if(xMin1 > xMax2 || xMax1 < xMin2 || yMin1 > yMax2 || yMax1 < yMin2)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		#endregion

		#region Vertex struct
		/// <summary>
		/// A coordinate point (x, y)
		/// </summary>
		public struct Vertex
		{
			public double x;
			public double y;
			
			public Vertex(double x, double y)
			{
				this.x = x;
				this.y = y;
			}
			public Vertex(ref MapWinGIS.Point pt)
			{
				this.x = pt.x;
				this.y = pt.y;
			}
		}
		#endregion

		#region Line struct
		/// <summary>
		/// Defines a 2pt line segment that begins at point p0 and ends at point p1.
		/// </summary>
		public struct Line
		{
			public MapWinGIS.Point p0;
			public MapWinGIS.Point p1;
		
			public Line(MapWinGIS.Point initialPoint, MapWinGIS.Point terminalPoint)
			{
				p0 = new MapWinGIS.PointClass();
				p1 = new MapWinGIS.PointClass();
				p0 = initialPoint;
				p1 = terminalPoint;
			}
		}   
		#endregion

		#region SimpleIntersect()
		/// <summary>
		/// Finds if two INFINITE lines will intersect, and if so, computes the intersect point.
		/// </summary>
		/// <param name="line1">The first infinite line</param>
		/// <param name="line2">The second infinite line</param>
		/// <param name="intersectPoint">The point of intersection</param>
		/// <returns>True if one intersect point exists, false otherwise.</returns>
		public static bool SimpleIntersect(Line line1, Line line2, out MapWinGIS.Point intersectPoint)
		{
			MapWinGIS.Point intPoint = new MapWinGIS.PointClass();

			//put line in the General form: y = a + bx
			double xDiff1 = line1.p1.x - line1.p0.x;
			double yDiff1 = line1.p1.y - line1.p0.y;
			double b1 = 0;
			if(xDiff1 != 0)
			{
				b1 = yDiff1/xDiff1;
			}
			//solve for a1 (a1 = y1 - b1*x1)
			double a1 = line1.p0.y - (b1 * line1.p0.x);

			double xDiff2 = line2.p1.x - line2.p0.x;
			double yDiff2 = line2.p1.y - line2.p0.y;
			double b2 = 0;
			if(xDiff2 != 0)
			{
				b2 = yDiff2/xDiff2;
			}
			//solve for a2 (a2 = y2 - b2*x2)
			double a2 = line2.p0.y - (b2 * line2.p0.x);

			if(b1 == b2)
			{
				//lines have the same slope (parallel or coincident)
				intersectPoint = intPoint;
				return false;
			}

			//in general, the two lines (y = a1 + b1x and y = a2 + b2x) 
			//intersect at xi = - (a1 - a2) / (b1 - b2) yi = a1 + b1xi 
			intPoint.x = -(a1 - a2)/(b1 - b2);
			intPoint.y = a1 + (b1 * intPoint.x);
			intersectPoint = intPoint;
			return true;
		}
		#endregion

		#region LinesIntersect2D()
		//Ideas for this function were found here http://softsurfer.com/Archive/algorithm_0104/algorithm_0104B.htm
		//and may fall under the following copyright:
		// Copyright 2001, softSurfer (www.softsurfer.com)
		// This code may be freely used and modified for any purpose
		// providing that this copyright notice is included with it.
		// SoftSurfer makes no warranty for this code, and cannot be held
		// liable for any real or imagined damage resulting from its use.
		// Users of this code must verify correctness for their application.
		//However, the code below is original and written by Angela Hillier.
		/// <summary>
		/// Calculates the intersection point between two lines.
		/// </summary>
		/// <param name="S1">First line segment.</param>
		/// <param name="S1_isRay">True if line 1 is a ray, false if it's a finite segment.</param>
		/// <param name="S2">Second line segment.</param>
		/// <param name="S2_isRay">True if line 2 is a ray, false if it's a finite segment.</param>
		/// <param name="intersectPoint">The intersection point between segments 1 and 2.</param>
		/// <returns>True if a valid intersect point exists, false if the lines do not cross.</returns>
		public static bool LinesIntersect2D(Line S1, bool S1_isRay, Line S2, bool S2_isRay, out MapWinGIS.Point intersectPoint)
		{
			bool intersect = false;
			MapWinGIS.Point iPoint = new MapWinGIS.PointClass();
			//find direction vector <u> for S1
			MapWinGIS.Vector u = new MapWinGIS.VectorClass(); //direction vector for S1
			double xDiff = S1.p1.x - S1.p0.x;
			double yDiff = S1.p1.y - S1.p0.y;
			double magnitude = Math.Sqrt((xDiff*xDiff)+(yDiff*yDiff));
			u.i = xDiff / magnitude;
			u.j = yDiff / magnitude;

			//find direction vector <v> for S2
			MapWinGIS.Vector v = new MapWinGIS.VectorClass(); //direction vector for S2
			xDiff = S2.p1.x - S2.p0.x;
			yDiff = S2.p1.y - S2.p0.y;
			magnitude = Math.Sqrt((xDiff*xDiff)+(yDiff*yDiff));
			v.i = xDiff / magnitude;
			v.j = yDiff / magnitude;

			//now the lines can be put into their parametric form:
			//S1 = P(s) = P0 + s(P1-P0) = P0 + s<u>, where P0 is a point on the line and <u> is the direction vector
			//S2 = Q(t) = Q0 + t(Q1-Q0) = Q0 + t<w> where Q0 is a point on the line and <w> is the direction vector
			//These lines are parallel when and only when their directions are collinear
			//that is, when the perpendicular product of the two vectors <u> and <w> equals zero
			double perp = PerpProduct(u, v);		
			if(perp == 0)
			{
				//The lines are parallel, 
				//if they are not coincident, they will never intersect
				//if coincident, they share more than one point.
				//We only want to return a single point of intersection for now
				//but later it might be a good to extend this code to return
				//the segment of intersection for coincident lines.
				intersect = false;
			}
			else
			{ 
				//lines are not parallel so might intersect at a unique point
				//To determine sI, we have the vector equality 
				//P(s)-Q0 = <w> + s<u>  where <w>=P0-Q0
				MapWinGIS.Vector w = new MapWinGIS.VectorClass();
				xDiff = S1.p0.x - S2.p0.x;
				yDiff = S1.p0.y - S2.p0.y;
				//note: w is not a direction (unit) vector, so do not divide by magnitude
				w.i = xDiff;
				w.j = yDiff; 

				//At the intersection point, the vector P(s)-Q0 is perpendicular 
				//to v^, and this is equivalent to the perp product condition that v^·(w+su) = 0
				//after solving, we can now get s and t at the point of intersection:
				//double sI = (((v.j * w.i) - (v.i* w.j))/((v.i*u.j) - (v.j*u.i)));
				//double tI = (((u.i * w.j) - (u.j * w.i))/((u.i*v.j) - (u.j*v.i)));
				double sI = PerpProduct(v, w) / perp;
				double tI = PerpProduct(u, w) / perp;

				//if the first line is a ray but the second is not
				//intersection only occurs when sI >= 0
				if(S1_isRay == true && sI >= 0 && S2_isRay == false)
				{
					//our second line is finite, 
					//find its bounds and check if the intersection pt 
					//is valid.
					double xMinSeg, yMinSeg, xMaxSeg, yMaxSeg;
					if(S2.p0.x < S2.p1.x)
					{
						xMinSeg = S2.p0.x;
						xMaxSeg = S2.p1.x;
					}
					else
					{
						xMinSeg = S2.p1.x;
						xMaxSeg = S2.p0.x;
					}
					if(S2.p0.y < S2.p1.y)
					{
						yMinSeg = S2.p0.y;
						yMaxSeg = S2.p1.y;
					}
					else
					{
						yMinSeg = S2.p1.y;
						yMaxSeg = S2.p0.y;
					}
					//compute the intersect point
					//I = S2.Q0 + tI * v
					double xValue = S2.p0.x + tI*v.i;
					double yValue = S2.p0.y + tI*v.j;

					//if the intersect point is valid, save the point to iPoint
					if(xValue <= xMaxSeg && xValue >= xMinSeg && yValue <= yMaxSeg && yValue >= yMinSeg)
					{					
						iPoint.x = xValue;
						iPoint.y = yValue;
						intersect = true;
					}					
					else
					{
						intersect = false;
					}
				}
				else
				{
					//if our second line is a ray but the first is not
					//intersection only occurs when tI >= 0
					if(S2_isRay == true && tI >= 0 && S1_isRay == false)
					{
						//our first line is finite, 
						//find its bounds and check if the intersection point 
						//is valid.
						double xMinSeg, yMinSeg, xMaxSeg, yMaxSeg;
						if(S1.p0.x < S1.p1.x)
						{
							xMinSeg = S1.p0.x;
							xMaxSeg = S1.p1.x;
						}
						else
						{
							xMinSeg = S1.p1.x;
							xMaxSeg = S1.p0.x;
						}
						if(S1.p0.y < S1.p1.y)
						{
							yMinSeg = S1.p0.y;
							yMaxSeg = S1.p1.y;
						}
						else
						{
							yMinSeg = S1.p1.y;
							yMaxSeg = S1.p0.y;
						}
						//compute the intersect point
						//I = S1.Q0 + sI * u
						double xValue = S1.p0.x + sI*u.i;
						double yValue = S1.p0.y + sI*u.j;

						//if the intersect point is valid, save the point to iPoint
						if(xValue <= xMaxSeg && xValue >= xMinSeg && yValue <= yMaxSeg && yValue >= yMinSeg)
						{					
							iPoint.x = xValue;
							iPoint.y = yValue;
							intersect = true;
						}					
						else
						{
							intersect = false;
						}
					}
					else
					{
						//if both lines are rays they should cross as long
						//as both tI and sI are >= 0
						if(S1_isRay == true && S2_isRay == true && tI >= 0 && sI >= 0)
						{
							//compute the intersect point
							//I = S1.Q0 + sI * u
							iPoint.x = S1.p0.x + sI*u.i;
							iPoint.y = S1.p0.y + sI*u.j;
							intersect = true;
						}
						else
						{
							//if both lines are segments,
							//they intersect when tI and sI >= 0 and the intersect point is within
							//the segment boundaries.
							if(S1_isRay == false && S2_isRay == false && tI >= 0 && sI >= 0)
							{
								//compute the intersect point
								//I = S1.Q0 + sI * u
								double xValue = S1.p0.x + sI*u.i;
								double yValue = S1.p0.y + sI*u.j;

								//both of the lines are finite, find each of their
								//bounds and check if the intersection point 
								//falls within both.
								
								//Find bounds for segment #1:
								double xMin1, yMin1, xMax1, yMax1;
								if(S1.p0.x < S1.p1.x)
								{
									xMin1 = S1.p0.x;
									xMax1 = S1.p1.x;
								}
								else
								{
									xMin1 = S1.p1.x;
									xMax1 = S1.p0.x;
								}
								if(S1.p0.y < S1.p1.y)
								{
									yMin1 = S1.p0.y;
									yMax1 = S1.p1.y;
								}
								else
								{
									yMin1 = S1.p1.y;
									yMax1 = S1.p0.y;
								}
								
								//Find segment #2's bounds
								double xMin2, yMin2, xMax2, yMax2;
								if(S2.p0.x < S2.p1.x)
								{
									xMin2 = S2.p0.x;
									xMax2 = S2.p1.x;
								}
								else
								{
									xMin2 = S2.p1.x;
									xMax2 = S2.p0.x;
								}
								if(S2.p0.y < S2.p1.y)
								{
									yMin2 = S2.p0.y;
									yMax2 = S2.p1.y;
								}
								else
								{
									yMin2 = S2.p1.y;
									yMax2 = S2.p0.y;
								}

								//check the intersect point against both segment boundaries
								if((xValue <= xMax1 && xValue >= xMin1 && yValue <= yMax1 && yValue >= yMin1)
									&&(xValue <= xMax2 && xValue >= xMin2 && yValue <= yMax2 && yValue >= yMin2))																
								{	
									//intersect point lies within the boundaries of both segments
									//save the point to iPoint
									iPoint.x = xValue;
									iPoint.y = yValue;
									intersect = true;
								}					
								else
								{
									intersect = false;
								}
							}
							else
							{
								intersect = false;
							}
						}
					}
				}
			}
			intersectPoint = iPoint;
			return intersect;			
		}
		#endregion

		#region private PerpProduct() -- used by LinesIntersect2D()
		/// <summary>
		/// Computes the perpendicular product of two 2D vectors.
		/// </summary>
		/// <param name="v1">vector 1</param>
		/// <param name="v2">vector 2</param>
		/// <returns>Perpedicular product; if == 0, v1 and v2 are parallel.</returns>
		private static double PerpProduct(MapWinGIS.Vector v1, MapWinGIS.Vector v2)
		{
			return ((v1.i * v2.j) - (v1.j * v2.i));
		}
		#endregion

		#region CalcSiDeterm()
		//Ideas for this algorithm were taken by a similar function found
		//in John Theal's 2002 class: CPolygonClip. Which was found here
		//http://www.codeproject.com/cpp/2dpolyclip.asp. It has been changed
		//to work with MapWinGIS shapes, as well as to calculate the accurate
		//number of intersection points for finite segments (original version
		//treated the line segments as rays).
		/// <summary>
		/// Calculates the determinants for line segments with a polygon
		/// to see if any intersections will occur. -- Angela Hillier 10/05
		/// </summary>
		/// <param name="lineSF">A line shapefile of 2pt segments.</param>
		/// <param name="polygon">The polygon to test for intersections with.</param>
		/// <param name="intersectsPerLineSeg">Out parameter: an array of numbers representing how many
		/// intersections will occur for each line segment.</param>
		/// <param name="intersectionPts">Out parameter: an array of points, if the point is != (0,0) then
		/// it represents a valid intersection point at the corresponding location in the polygon.</param>
		/// <param name="polyIntersectLocs">Out paramter: an array of indicies corresponding to where in the polygon
		/// an intersection point is found.</param>
		/// <returns>The total number of intersections found for the line shapefile.</returns>
        public static int CalcSiDeterm(ref MapWinGIS.Shapefile lineSF, ref MapWinGIS.Shape polygon, out int[] intersectsPerLineSeg, out MapWinGIS.Point[][] intersectionPts, out int[][] polyIntersectLocs)
		{
			int numSignChanges = 0; //tracks number of determinant sign changes
			int numChangesPerLine= 0;
			int numLines = lineSF.NumShapes;
			int numVerticies = polygon.numPoints;
			int[][] detSigns = new int[numLines][];
			bool[][] signChanges = new bool[numLines][]; //keeps track of where sign changes occur
			int[][] changeLocations = new int[numLines][];
			int[] intersectsPerLine = new int[numLines];
			MapWinGIS.Point[][] intersectPts = new MapWinGIS.Point[numLines][];

			for(int lineNo = 0; lineNo <= numLines-1; lineNo++)
			{
				MapWinGIS.Shape line;
				line = lineSF.get_Shape(lineNo);
				numChangesPerLine = 0;
				detSigns[lineNo] = new int[numVerticies];
				signChanges[lineNo] = new bool[numVerticies];
				intersectPts[lineNo] = new MapWinGIS.Point[numVerticies];
				changeLocations[lineNo] = new int[numVerticies];
				
				for(int vertNo = 0; vertNo <= numVerticies-1; vertNo++)
				{
					intersectPts[lineNo][vertNo] = new MapWinGIS.PointClass();
					MapWinGIS.Point intersectPt = new MapWinGIS.PointClass();
					// Calculate the determinant (3x3 square matrix)
					double S_i = TurboDeterm(polygon.get_Point(vertNo).x, line.get_Point(0).x, line.get_Point(1).x,
						polygon.get_Point(vertNo).y, line.get_Point(0).y, line.get_Point(1).y);

					// Check the determinant result
					switch (vertNo) 
					{
						case 0:
							if (S_i == 0)		
							{
								detSigns[lineNo][vertNo] = 0; // we have hit a vertex
							}
							else if (S_i > 0)
							{
								detSigns[lineNo][vertNo] = 1; // +'ve
							}
							else if (S_i < 0)
							{
								detSigns[lineNo][vertNo] = -1; // -'ve
							}
							signChanges[lineNo][0] = false;		// First element will NEVER be a sign change
							break;
						default:
							if (S_i == 0)
							{
								detSigns[lineNo][vertNo] = 0;
							}
							else if (S_i > 0)
							{
								detSigns[lineNo][vertNo] = 1;
							}
							else if (S_i < 0)
							{
								detSigns[lineNo][vertNo] = -1;
							}

							// Check for sign change
							if (detSigns[lineNo][vertNo - 1] != detSigns[lineNo][vertNo])
							{	
								//calculate the actual intercept point								
								Line polyTestLine = new Line(polygon.get_Point(vertNo-1), polygon.get_Point(vertNo));
								Line lineSeg = new Line(line.get_Point(0), line.get_Point(1));
								bool validIntersect = LinesIntersect2D(lineSeg, false, polyTestLine, false, out intersectPt);
								if(validIntersect == true)
								{
									signChanges[lineNo][vertNo] = true;
									numSignChanges+=1;
									numChangesPerLine+=1;
									intersectsPerLine[lineNo] = numChangesPerLine;
									//we want to store the valid intersect pts at the
									//beginning of the array so we don't have to search for them
									intersectPts[lineNo][numChangesPerLine-1] = intersectPt;
									//keep track of where the intersect occurs in reference to polygon
									changeLocations[lineNo][numChangesPerLine-1] = vertNo; //intersect pt occurs between vertNo-1 and vertNo
								}
								else
								{
									signChanges[lineNo][vertNo] = false;
								}
								
							}
							else
							{
								signChanges[lineNo][vertNo] = false;
							}
							break;
					}//end of switch
				}
			}
			polyIntersectLocs = changeLocations;
			intersectionPts = intersectPts;
			intersectsPerLineSeg = intersectsPerLine;
			return numSignChanges;			
		}
		public static int CalcSiDeterm(ref MapWinGIS.Shape line, ref MapWinGIS.Shape polygon, out int[] intersectsPerLineSeg, out MapWinGIS.Point[][] intersectionPts, out int[][] polyIntersectLocs)
		{
			int numSignChanges = 0; //tracks number of determinant sign changes
			int numChangesPerLine= 0;
			int numLines = 1;
			int numVerticies = polygon.numPoints;
			int[][] detSigns = new int[numLines][];
			bool[][] signChanges = new bool[numLines][]; //keeps track of where sign changes occur
			int[][] changeLocations = new int[numLines][];
			int[] intersectsPerLine = new int[numLines];
			MapWinGIS.Point[][] intersectPts = new MapWinGIS.Point[numLines][];

			for(int lineNo = 0; lineNo <= numLines-1; lineNo++)
			{
				numChangesPerLine = 0;
				detSigns[lineNo] = new int[numVerticies];
				signChanges[lineNo] = new bool[numVerticies];
				intersectPts[lineNo] = new MapWinGIS.Point[numVerticies];
				changeLocations[lineNo] = new int[numVerticies];
				
				for(int vertNo = 0; vertNo <= numVerticies-1; vertNo++)
				{
					intersectPts[lineNo][vertNo] = new MapWinGIS.PointClass();
					MapWinGIS.Point intersectPt = new MapWinGIS.PointClass();
					// Calculate the determinant (3x3 square matrix)
					double S_i = TurboDeterm(polygon.get_Point(vertNo).x, line.get_Point(0).x, line.get_Point(1).x,
						polygon.get_Point(vertNo).y, line.get_Point(0).y, line.get_Point(1).y);

					// Check the determinant result
					switch (vertNo) 
					{
						case 0:
							if (S_i == 0)		
							{
								detSigns[lineNo][vertNo] = 0; // we have hit a vertex
							}
							else if (S_i > 0)
							{
								detSigns[lineNo][vertNo] = 1; // +'ve
							}
							else if (S_i < 0)
							{
								detSigns[lineNo][vertNo] = -1; // -'ve
							}
							signChanges[lineNo][0] = false;		// First element will NEVER be a sign change
							break;
						default:
							if (S_i == 0)
							{
								detSigns[lineNo][vertNo] = 0;
							}
							else if (S_i > 0)
							{
								detSigns[lineNo][vertNo] = 1;
							}
							else if (S_i < 0)
							{
								detSigns[lineNo][vertNo] = -1;
							}

							// Check for sign change
							if (detSigns[lineNo][vertNo - 1] != detSigns[lineNo][vertNo])
							{	
								//calculate the actual intercept point								
								Line polyTestLine = new Line(polygon.get_Point(vertNo-1), polygon.get_Point(vertNo));
								Line lineSeg = new Line(line.get_Point(0), line.get_Point(1));
								bool validIntersect = LinesIntersect2D(lineSeg, false, polyTestLine, false, out intersectPt);
								if(validIntersect == true)
								{
									signChanges[lineNo][vertNo] = true;
									numSignChanges+=1;
									numChangesPerLine+=1;
									intersectsPerLine[lineNo] = numChangesPerLine;
									//we want to store the valid intersect pts at the
									//beginning of the array so we don't have to search for them
									intersectPts[lineNo][numChangesPerLine-1] = intersectPt;
									//keep track of where the intersect occurs in reference to polygon
									changeLocations[lineNo][numChangesPerLine-1] = vertNo; //intersect pt occurs between vertNo-1 and vertNo
								}
								else
								{
									signChanges[lineNo][vertNo] = false;
								}
								
							}
							else
							{
								signChanges[lineNo][vertNo] = false;
							}
							break;
					}//end of switch
				}
			}
			polyIntersectLocs = changeLocations;
			intersectionPts = intersectPts;
			intersectsPerLineSeg = intersectsPerLine;
			return numSignChanges;			
		}

		//overloaded version that only returns the number of intersections
		public static int CalcSiDeterm(ref MapWinGIS.Shapefile lineSF, ref MapWinGIS.Shape polygon)
		{
			int numSignChanges = 0; //tracks number of determinant sign changes
			int numChangesPerLine= 0;
			int numLines = lineSF.NumShapes;
			int numVerticies = polygon.numPoints;
			int[][] detSigns = new int[numLines][];
			bool[][] signChanges = new bool[numLines][]; //keeps track of where sign changes occur
			int[][] changeLocations = new int[numLines][];
			int[] intersectsPerLine = new int[numLines];
			MapWinGIS.Point[][] intersectPts = new MapWinGIS.Point[numLines][];

			for(int lineNo = 0; lineNo <= numLines-1; lineNo++)
			{
				MapWinGIS.Shape line = new MapWinGIS.ShapeClass();
				line = lineSF.get_Shape(lineNo);
				numChangesPerLine = 0;
				detSigns[lineNo] = new int[numVerticies];
				signChanges[lineNo] = new bool[numVerticies];
				intersectPts[lineNo] = new MapWinGIS.Point[numVerticies];
				changeLocations[lineNo] = new int[numVerticies];
				
				for(int vertNo = 0; vertNo <= numVerticies-1; vertNo++)
				{
					intersectPts[lineNo][vertNo] = new MapWinGIS.PointClass();
					MapWinGIS.Point intersectPt = new MapWinGIS.PointClass();
					// Calculate the determinant (3x3 square matrix)
					double S_i = TurboDeterm(polygon.get_Point(vertNo).x, line.get_Point(0).x, line.get_Point(1).x,
						polygon.get_Point(vertNo).y, line.get_Point(0).y, line.get_Point(1).y);

					// Check the determinant result
					switch (vertNo) 
					{
						case 0:
							if (S_i == 0)		
							{
								detSigns[lineNo][vertNo] = 0; // we have hit a vertex
							}
							else if (S_i > 0)
							{
								detSigns[lineNo][vertNo] = 1; // +'ve
							}
							else if (S_i < 0)
							{
								detSigns[lineNo][vertNo] = -1; // -'ve
							}
							signChanges[lineNo][0] = false;		// First element will NEVER be a sign change
							break;
						default:
							if (S_i == 0)
							{
								detSigns[lineNo][vertNo] = 0;
							}
							else if (S_i > 0)
							{
								detSigns[lineNo][vertNo] = 1;
							}
							else if (S_i < 0)
							{
								detSigns[lineNo][vertNo] = -1;
							}

							// Check for sign change
							if (detSigns[lineNo][vertNo - 1] != detSigns[lineNo][vertNo])
							{	
								//calculate the actual intercept point								
								Line polyTestLine = new Line(polygon.get_Point(vertNo-1), polygon.get_Point(vertNo));
								Line lineSeg = new Line(line.get_Point(0), line.get_Point(1));
								bool validIntersect = LinesIntersect2D(lineSeg, false, polyTestLine, false, out intersectPt);
								if(validIntersect == true)
								{
									signChanges[lineNo][vertNo] = true;
									numSignChanges+=1;
									numChangesPerLine+=1;
									intersectsPerLine[lineNo] = numChangesPerLine;
									//we want to store the valid intersect pts at the
									//beginning of the array so we don't have to search for them
									intersectPts[lineNo][numChangesPerLine-1] = intersectPt;
									//keep track of where the intersect occurs in reference to polygon
									changeLocations[lineNo][numChangesPerLine-1] = vertNo; //intersect pt occurs between vertNo-1 and vertNo
								}
								else
								{
									signChanges[lineNo][vertNo] = false;
								}
								
							}
							else
							{
								signChanges[lineNo][vertNo] = false;
							}
							break;
					}//end of switch
				}
			}
			return numSignChanges;			
		}

		#endregion

		#region private TurboDeterm() -- used by CalcSiDeterm()
		//Original function found in John Theal's 2002 class: CPolygonClip.
		///http://www.codeproject.com/cpp/2dpolyclip.asp
		/// <summary>
		/// Calculates the determinant of a 3X3 matrix, where the first two rows
		/// represent the x,y values of two lines, and the third row is (1 1 1).
		/// </summary>
		/// <param name="Elem11">The first element of the first row in the matrix.</param>
		/// <param name="Elem12">The second element of the first row in the matrix.</param>
		/// <param name="Elem13">The third element of the first row in the matrix.</param>
		/// <param name="Elem21">The first element of the second row in the matrix.</param>
		/// <param name="Elem22">The second element of the second row in the matrix.</param>
		/// <param name="Elem23">The third element of the second row in the matrix.</param>
		/// <returns>The determinant of the matrix.</returns>
		private static double TurboDeterm(double Elem11, double Elem12, double Elem13, 
			double Elem21, double Elem22, double Elem23)
		{
			// The third row of the 3x3 matrix is (1,1,1)
			return   Elem11 * (Elem22 - Elem23)
				- Elem12 * (Elem21 - Elem23)
				+ Elem13 * (Elem21 - Elem22);	
		}
		#endregion

		#region SortPointsArray()
		//Angela Hillier 10/05
		/// <summary>
		/// Given a reference point to the line, and an array of points that
		/// lie along the line, this method sorts the array of points from the point
		/// closest to the reference pt to the pt farthest away.
		/// </summary>
		/// <param name="startPt">Point in line segment used as reference.</param>
		/// <param name="intersectPts">Array of points that lie on the same line as startPt.</param>
		private static void SortPointsArray(ref MapWinGIS.Point startPt, ref MapWinGIS.Point[] intersectPts)
		{
			double dist1, dist2;
			int numIntersectPts = intersectPts.Length;
			if(numIntersectPts == 2) //if 0 or 1 the points don't need to be sorted
			{
				//do a brute sort
				//just compare distances of each pt to the start pt.
				dist1 = PtDistance(ref startPt, ref intersectPts[0]);
				dist2 = PtDistance(ref startPt, ref intersectPts[1]);
				if(dist1 > dist2) //need to swap locations
				{
					MapWinGIS.Point tempPt =  new MapWinGIS.PointClass();
					tempPt = intersectPts[0];
					intersectPts[0] = intersectPts[1];
					intersectPts[1] = tempPt;
				}
			}
			else if(numIntersectPts > 2 /*&& numintersectPts <= 10*/)
			{
				//use insertion sort for small arrays
				int c;
				for(int i=0; i<= numIntersectPts-1; i++)
				{
					MapWinGIS.Point compPt1 = new MapWinGIS.PointClass();
					compPt1 = intersectPts[i];
					dist1 = PtDistance(ref startPt, ref compPt1);
					c = i;
					MapWinGIS.Point compPt2 = new MapWinGIS.PointClass();
					if(c != 0)
					{
						compPt2 = intersectPts[c-1];
					}
					else
					{
						compPt2 = intersectPts[0];
					}
					while( c>0 && (PtDistance(ref startPt, ref compPt2)) > dist1)
					{
						intersectPts[c] = intersectPts[c-1];
						c--;
						if(c != 0)
						{
							compPt2 = new MapWinGIS.PointClass();
							compPt2 = intersectPts[c-1];
						}
					}
					if(c != i)
					{
						intersectPts[c] = compPt1;
					}
				}
			}
			//			else if(numIntersectPts > 10)
			//			{
			//TO DO: write a quick-sort function to aid in time
			//haven't done this because it is rare to have
			//a large number of intersect pts for a small line segment
			//quick-sort performs poorly on small lists, that's why insertion
			//sort is used above.
			//			}
		}
		#endregion
		
		#region private SortIntersectAndLocationArrays()
		/// <summary>
		/// Given a reference point to the line, and an array of points that
		/// lie along the line, this method sorts the array of points from the point
		/// closest to the reference pt to the pt farthest away. It also sorts the corresponding
		/// polygon location array so that the indicies refer to the correct intersection point.
		/// </summary>
		/// <param name="startPt">Point in line segment used as reference.</param>
		/// <param name="intersectPts">Array of points that lie on the same line as startPt.</param>
		/// <param name="polyLoc">Array indexing where in polygon an intersect occurs.</param>
		private static void SortIntersectAndLocationArrays(ref MapWinGIS.Point startPt, ref MapWinGIS.Point[] intersectPts, ref int[] polyLoc)
		{
			double dist1, dist2;
			int numIntersectPts = intersectPts.Length;
			if(numIntersectPts == 2) //if 0 or 1 the points don't need to be sorted
			{
				//do a brute sort
				//just compare distances of each pt to the start pt.
				dist1 = PtDistance(ref startPt, ref intersectPts[0]);
				dist2 = PtDistance(ref startPt, ref intersectPts[1]);
				if(dist1 > dist2) //need to swap locations
				{
					MapWinGIS.Point tempPt =  new MapWinGIS.PointClass();
					tempPt = intersectPts[0];
					intersectPts[0] = intersectPts[1];
					intersectPts[1] = tempPt;
					//move poly location so it corresponds to correct intersect point
					int tempLoc = polyLoc[0];
					polyLoc[0] = polyLoc[1];
					polyLoc[1] = tempLoc;
				}
			}
			else if(numIntersectPts > 2 /*&& numintersectPts <= 10*/)
			{
				//use insertion sort for small arrays
				int c;
				for(int i=0; i<= numIntersectPts-1; i++)
				{
					MapWinGIS.Point compPt1 = new MapWinGIS.PointClass();
					compPt1 = intersectPts[i];
					int tempLoc1 = polyLoc[i];
					dist1 = PtDistance(ref startPt, ref compPt1);
					c = i;
					MapWinGIS.Point compPt2 = new MapWinGIS.PointClass();
					if(c != 0)
					{
						compPt2 = intersectPts[c-1];
					}
					else
					{
						compPt2 = intersectPts[0];
					}
					while( c>0 && (PtDistance(ref startPt, ref compPt2)) > dist1)
					{
						intersectPts[c] = intersectPts[c-1];
						polyLoc[c] = polyLoc[c-1];
						c--;
						if(c != 0)
						{
							compPt2 = new MapWinGIS.PointClass();
							compPt2 = intersectPts[c-1];
						}
					}
					if(c != i)
					{
						intersectPts[c] = compPt1;
						polyLoc[c] = tempLoc1;
					}
				}
			}
			//			else if(numIntersectPts > 10)
			//			{
			//TO DO: write a quick-sort function to aid in time
			//haven't done this because it is rare to have
			//a large number of intersect pts for a small line segment
			//quick-sort performs poorly on small lists, that's why insertion
			//sort is used above.
			//			}
		}
		#endregion

		#region FindAndSortValidIntersects()
		//Angela Hillier 10/05
		/// <summary>
		/// Sorts all valid intersects in the array intersectPts.
		/// </summary>
		/// <param name="numIntersects">Expected number of valid intersects.</param>
		/// <param name="intersectPts">Array of all possible intersect points.</param>
		/// <param name="validIntersects">Array that will contain only the valid intersect points in sorted order.</param>
		/// <param name="startPt">The reference point to sort the valid intersect points by.</param>
		public static void FindAndSortValidIntersects(int numIntersects, ref MapWinGIS.Point[] intersectPts, ref MapWinGIS.Point[] validIntersects, ref MapWinGIS.Point startPt)
		{
			for(int i = 0; i <= numIntersects-1; i++)
			{
				validIntersects[i] = intersectPts[i];
			}
			
			SortPointsArray(ref startPt, ref validIntersects);
		}

		/// <summary>
		/// Sorts all valid intersects in the array intersectPts, along with corresponding polygon locations in array polyLoc.
		/// </summary>
		/// <param name="numIntersects">Expected number of valid intersects.</param>
		/// <param name="intersectPts">Array of all possible intersect points.</param>
		/// <param name="validIntersects">Array that will contain only the valid intersect points in sorted order.</param>
		/// <param name="startPt">The reference point to sort the valid intersect points by.</param>
		/// <param name="polyLoc">Array with corresponding indicies to where an intersect pt occurs in polygon.</param>
		public static void FindAndSortValidIntersects(int numIntersects, ref MapWinGIS.Point[] intersectPts, ref MapWinGIS.Point[] validIntersects, ref MapWinGIS.Point startPt, ref int[] polyLoc)
		{
			for(int i= 0; i <= numIntersects-1; i++)
			{
				validIntersects[i] = intersectPts[i];
			}
			SortIntersectAndLocationArrays(ref startPt, ref validIntersects, ref polyLoc);
		}
		#endregion

		#region PtDistance() -- used by SortPointsArray()
		//Angela Hillier 10/05
		/// <summary>
		/// Calculates the distance between two points.
		/// </summary>
		/// <param name="pt0">The first point.</param>
		/// <param name="pt1">The second point.</param>
		/// <returns>The distance between pt0 and pt1.</returns>
		public static double PtDistance(ref MapWinGIS.Point pt0, ref MapWinGIS.Point pt1)
		{
			double xDiff = pt1.x - pt0.x;
			double yDiff = pt1.y - pt0.y;
			double distance = Math.Sqrt((xDiff*xDiff)+(yDiff*yDiff));
			return distance;
		}
		public static double PtDistance(MapWinGIS.Point pt0, MapWinGIS.Point pt1)
		{
			double xDiff = pt1.x - pt0.x;
			double yDiff = pt1.y - pt0.y;
			double distance = Math.Sqrt((xDiff*xDiff) + (yDiff*yDiff));
			return distance;
		}
		#endregion

		#region DetermineRowClearCount()
		/// <summary>
		/// Determines how many rows can be filled before unmanaged resources should
		/// be released.
		/// </summary>
		/// <param name="newNumRows">The total number of rows in the grid that's being filled.</param>
		/// <param name="newNumCols">The total number of cols in the grid that's being filled.</param>
		/// <returns>The number of rows that can be filled before COM objects need to be released.</returns>
		public static int DetermineRowClearCount(int newNumRows, int newNumCols)
		{
			//TODO: Determine optimal time based on available memory, newNumRows
			//and newNumCols to dispose of COM objects.
			int rowClearCount = 500;
			if (newNumCols > 100)
			{
				rowClearCount = 4000000 / newNumCols;
			}
			if(rowClearCount < 1)
			{
				rowClearCount = 1;
			}
			return rowClearCount;
		}
		#endregion

		#region TrimGrid
		/// <summary>
		/// Removes rows and columns that contain only NoData values from the edges of the grid.
		/// </summary>
		/// <param name="inputGFPath">The full path to the input grid.</param>
		/// <param name="resultGFPath">The full path to where the result grid should be saved.</param>
		/// <returns>False if an error occurs, true otherwise.</returns>
		public static bool TrimGrid(ref string inputGFPath, ref string resultGFPath)
		{
			using(GridWrapper inputGW = new GridWrapper())
			{
				if(inputGW.Open(inputGFPath, true) == false)
				{
					inputGW.Dispose();
					return false;
				}
				double noData = (double)inputGW.GetNodataValue();
				int numRows = inputGW.GetNumRows();
				int numCols = inputGW.GetNumCols();
				int firstRowLoc = 0;
				int lastRowLoc = numRows-1;
				int firstColLoc = 0;
				int lastColLoc = numCols-1;
				bool found = false;

				if(numRows <= 0 || numCols <= 0)
				{
					gErrorMsg = "The grid has 0 rows or columns. Aborting TrimGrid()";
					Debug.WriteLine(gErrorMsg);
					Error.SetErrorMsg(gErrorMsg);
					inputGW.Dispose();
					return false;
				}
				//Find which row contains the first valid Y points (yMax).
				for(int row = 0; row <= numRows-1; row++)
				{
					for(int col = 0; col <= numCols-1; col++)
					{
						if(Convert.ToDouble(inputGW.get_Value(col, row)) == noData)
						{
							continue;
						}
						else
						{
							firstRowLoc = row;
							found = true;
							break;
						}
					}
					if(found == true)
					{
						break;
					}
				}
				//Find which row contains the last valid Y points (yMin)
				found = false;
				for(int row = numRows-1; row >=0; row--)
				{
					for(int col = 0; col <= numCols-1; col++)
					{
						if(Convert.ToDouble(inputGW.get_Value(col, row)) == noData)
						{
							continue;
						}
						else
						{
							lastRowLoc = row;
							found = true;
							break;
						}
					}
					if(found == true)
					{
						break;
					}
				}
				//find the column containing the first valid point (xMin)
				found = false;
				for(int col = 0; col <= numCols-1; col++)
				{
					for(int row = 0; row <= numRows-1; row++)
					{
						if(Convert.ToDouble(inputGW.get_Value(col, row)) == noData)
						{
							continue;
						}
						else
						{
							firstColLoc = col;
							found = true;
							break;
						}
					}
					if(found == true)
					{
						break;
					}
				}
				//find the column containing the last valid point (xMax)
				found = false;
				for(int col = numCols-1; col >= 0; col--)
				{
					for(int row = 0; row <= numRows-1; row++)
					{
						if(Convert.ToDouble(inputGW.get_Value(col, row)) == noData)
						{
							continue;
						}
						else
						{
							lastColLoc = col;
							found = true;
							break;
						}
					}
					if(found == true)
					{
						break;
					}
				}

				//if there are no rows or cols in need of trimming, don't trim, just save to the result path!
				if(firstColLoc == 0 && firstRowLoc == 0 && lastColLoc == numCols-1 && lastRowLoc == numRows-1)
				{
					inputGW.Save(resultGFPath);
					inputGW.Close();
					inputGW.Dispose();
					return true;
				}

				//now make a new grid with the adjusted dimensions

                // No... bad idea --> rHeader = inputGW.GetHeader();
                MapWinGIS.GridHeader rHeader = inputGW.GetHeaderCopy();
				
				int newColNum = (numCols - firstColLoc) - (numCols - lastColLoc) + 1;
				int newRowNum = (numRows - firstRowLoc) - (numRows - lastRowLoc) + 1;
				rHeader.NumberCols = newColNum;
				rHeader.NumberRows = newRowNum;
				double cellSize = rHeader.dX;
				rHeader.XllCenter += (firstColLoc*cellSize);
				rHeader.YllCenter += ((numRows -1 - lastRowLoc)*cellSize);
				rHeader.NodataValue = inputGW.GetNodataValue();
                //Debug.WriteLine("new XllCenter: " + x + " new YllCenter: " + y );
				//Debug.WriteLine("Should have: " + newColNum + " cols and " + newRowNum + " rows.");
				
				//create the result grid
				MapWinGIS.Grid resultGF = new MapWinGIS.GridClass();
				DataManagement.DeleteGrid(ref resultGFPath);
				if(resultGF.CreateNew(resultGFPath, rHeader, MapWinGIS.GridDataType.UnknownDataType, inputGW.GetNodataValue(), true, MapWinGIS.GridFileType.UseExtension, null) == false)
				{
					gErrorMsg = "Error creating result file while trimming grid: " + resultGF.get_ErrorMsg(resultGF.LastErrorCode);
					Debug.WriteLine(gErrorMsg);
					Error.SetErrorMsg(gErrorMsg);
					//free unmanaged resources
					inputGW.Dispose();
					while(Marshal.ReleaseComObject(resultGF) != 0);
					resultGF = null;
					while(Marshal.ReleaseComObject(rHeader) != 0);
					rHeader = null;
					
					return false;
				}
				resultGF.Save(resultGFPath, MapWinGIS.GridFileType.UseExtension, null);
				resultGF.Close();
				while(Marshal.ReleaseComObject(resultGF) != 0);
				resultGF = null;
				while(Marshal.ReleaseComObject(rHeader) != 0);
				rHeader = null;

				using(GridWrapper resultGW = new GridWrapper())
				{
					if(resultGW.Open(resultGFPath, true) == false)
					{
						resultGW.Dispose();
						inputGW.Dispose();
						return false;
					}

					//fill in the new grid with values from original grid
					int rowPosition = firstRowLoc;
					float[] rowVals = new float[numCols];
					float[] rowCopy = new float[newColNum];
					for(int row = 0; row < newRowNum; row++)
					{
						inputGW.get_Row(rowPosition, ref rowVals);
						System.Array.Copy(rowVals, firstColLoc, rowCopy, 0, newColNum);
						resultGW.set_Row(row, ref rowCopy);
						rowPosition++;
					}
					resultGW.Save(resultGFPath);

				}//end of using resultGW, will be disposed of by GC			
			
			}//end of using inputGW, will be disposed of by GC
			return true;
		}

		
		/// <summary>
		/// Removes excess rows and columns contianing only "NoData" values from the grid's edges.
		/// </summary>
		/// <param name="grid">Grid in need of trimming.</param>
		/// <returns>False if an error was encountered, true otherwise.</returns>
		public static bool TrimGrid(ref MapWinGIS.Grid grid)
		{
			string tempPath = System.IO.Path.GetTempPath();
			double noData = Convert.ToDouble(grid.Header.NodataValue);
			int numRows = grid.Header.NumberRows;
			int numCols = grid.Header.NumberCols;
			int firstRowLoc = 0;
			int lastRowLoc = numRows-1;
			int firstColLoc = 0;
			int lastColLoc = numCols-1;
			bool found = false;

			if(numCols <= 0 || numRows <= 0)
			{
				gErrorMsg = "The grid has 0 rows or columns. Aborting TrimGrid()";
				Debug.WriteLine(gErrorMsg);
				Error.SetErrorMsg(gErrorMsg);
				return false;
			}
			//Find which row contains the first valid Y points (yMax).
			for(int row = 0; row <= numRows-1; row++)
			{
				for(int col = 0; col <= numCols-1; col++)
				{
					if(Convert.ToDouble(grid.get_Value(col, row)) == noData)
					{
						continue;
					}
					else
					{
						firstRowLoc = row;
						found = true;
						break;
					}
				}
				if(found == true)
				{
					break;
				}
			}
			//Find which row contains the last valid Y points (yMin)
			found = false;
			for(int row = numRows-1; row >=0; row--)
			{
				for(int col = 0; col <= numCols-1; col++)
				{
					if(Convert.ToDouble(grid.get_Value(col, row)) == noData)
					{
						continue;
					}
					else
					{
						lastRowLoc = row;
						found = true;
						break;
					}
				}
				if(found == true)
				{
					break;
				}
			}
			//find the column containing the first valid point (xMin)
			found = false;
			for(int col = 0; col <= numCols-1; col++)
			{
				for(int row = 0; row <= numRows-1; row++)
				{
					if(Convert.ToDouble(grid.get_Value(col, row)) == noData)
					{
						continue;
					}
					else
					{
						firstColLoc = col;
						found = true;
						break;
					}
				}
				if(found == true)
				{
					break;
				}
			}
			//find the column containing the last valid point (xMax)
			found = false;
			for(int col = numCols-1; col >= 0; col--)
			{
				for(int row = 0; row <= numRows-1; row++)
				{
					if(Convert.ToDouble(grid.get_Value(col, row)) == noData)
					{
						continue;
					}
					else
					{
						lastColLoc = col;
						found = true;
						break;
					}
				}
				if(found == true)
				{
					break;
				}
			}
			//if there are no rows or cols in need of trimming, don't trim, just save to the result path!
			if(firstColLoc == 0 && firstRowLoc == 0 && lastColLoc == numCols-1 && lastRowLoc == numRows-1)
			{
				//no need to change the original grid.
				return true;
			}
			//now make a new grid with the adjusted dimensions
            MapWinGIS.GridHeader rHeader = new MapWinGIS.GridHeaderClass();
			int newColNum = lastColLoc - firstColLoc + 1;
			int newRowNum = lastRowLoc - firstRowLoc + 1;
			rHeader.NumberCols = newColNum;
			rHeader.NumberRows = newRowNum;
			double cellSize = grid.Header.dX;
			rHeader.XllCenter = grid.Header.XllCenter + (firstColLoc*cellSize);
			rHeader.YllCenter = grid.Header.YllCenter + ((numRows -1 - lastRowLoc)*cellSize);
			//Debug.WriteLine("new XllCenter: " + x + " new YllCenter: " + y );
			//Debug.WriteLine("Should have: " + newColNum + " cols and " + newRowNum + " rows.");
            rHeader.dX = grid.Header.dX;
            rHeader.dY = grid.Header.dY;
            rHeader.Projection = grid.Header.Projection;

			//create a new grid
			MapWinGIS.Grid result = new MapWinGIS.GridClass();
			string resultGrid = tempPath + "tempGrid.bgd";
			if(System.IO.File.Exists(resultGrid) == false)
			{
				if(result.CreateNew(resultGrid, rHeader, grid.DataType, grid.Header.NodataValue, true, MapWinGIS.GridFileType.UseExtension, null) == false)
				{
					gErrorMsg = "Problem creating the result grid: " + result.get_ErrorMsg(result.LastErrorCode);
					Debug.WriteLine(gErrorMsg);
					MapWinGeoProc.Error.SetErrorMsg(gErrorMsg);
					return false;
				}
			}
			else
			{
				//delete the old grid files of the same name
				int length = resultGrid.IndexOf(".", 0);
				string gridFileName = resultGrid.Substring(0, length);
				System.IO.File.Delete(resultGrid);
				System.IO.File.Delete(gridFileName + ".bmp");
				System.IO.File.Delete(gridFileName + ".bpw");
				System.IO.File.Delete(gridFileName + ".mwleg");

				if(result.CreateNew(resultGrid, rHeader, grid.DataType, grid.Header.NodataValue, true, MapWinGIS.GridFileType.UseExtension, null) == false)
				{
					gErrorMsg = "Problem creating the result grid: " + result.get_ErrorMsg(result.LastErrorCode);
					Debug.WriteLine(gErrorMsg);
					MapWinGeoProc.Error.SetErrorMsg(gErrorMsg);
					return false;
				}
			}
		
			//fill in the new grid with values from original grid
			int rowPosition = lastRowLoc;
			int colPosition = firstColLoc;
			for(int row = newRowNum-1; row >= 0; row--)
			{
				for(int col = 0; col <= newColNum-1; col++)
				{
					result.set_Value(col, row, grid.get_Value(colPosition, rowPosition));

					if(col == newColNum-1)
					{
						colPosition = firstColLoc;
					}
					else
					{
						colPosition++;
					}
				}
				rowPosition--;
			}
			//assign the new grid to the original reference grid:
			grid = result;
			return true;
		}
		#endregion

		#region ProjToCell()
		/// <summary>
		/// Takes an x/y coordinate and finds what row/col the point exists in within the grid.
		/// </summary>
		/// <param name="x">X value of the coordinate point.</param>
		/// <param name="y">Y value of the coordinate point.</param>
		/// <param name="col">The resulting column.</param>
		/// <param name="row">The resulting row.</param>
		/// <param name="XllCenter">The X value of the center point of the lower-left corner of the grid.</param>
		/// <param name="YllCenter">The Y value of the center point of the lower-left corner of the grid.</param>
		/// <param name="dX">The width of a cell in the grid.</param>
		/// <param name="dY">The height of a cell in the grid.</param>
		/// <param name="numRows">The total number of rows in the grid.</param>
		public static void ProjToCell(double x, double y, out int col, out int row, double XllCenter, double YllCenter, double dX, double dY, int numRows)
		{
			if(dX != 0.0 && dY != 0.0)
			{
				col = (int)(Math.Round((x - XllCenter)/dX));
				row = (int)(numRows - Math.Round((y-YllCenter)/dY) - 1);
			}
			else
			{
				col = -1;
				row = -1;
			}
		}
		#endregion

		#region CellToProj()
		/// <summary>
		/// Finds the center point of a grid cell that corresponds to the row/col provided.
		/// </summary>
		/// <param name="col">The column to be considered.</param>
		/// <param name="row">The row to be considered.</param>
		/// <param name="x">The resulting X value of the point that is in the center of the grid's cell.</param>
		/// <param name="y">The resulting Y value of the point that is in the center of the grid's cell.</param>
		/// <param name="XllCenter">The X value of the center point of the lower-left corner of the grid.</param>
		/// <param name="YllCenter">The Y value of the center point of the lower-left corner of the grid.</param>
		/// <param name="dX">The width of a cell in the grid.</param>
		/// <param name="dY">The height of a cell in the grid.</param>
		/// <param name="numRows">The total number of rows in the grid.</param>
		public static void CellToProj(int col, int row, out double x, out double y, double XllCenter, double YllCenter, double dX, double dY, int numRows)
		{
			x = XllCenter + (col * dX);
			y = YllCenter + ((numRows - row - 1)*dY);
		}
		#endregion

		#region IsClockwise()
		/// <summary>
		/// Calculates the Area to find if a simple convex or
		/// concave polyon is ordered clockwise or counter-clockwise.
		/// </summary>
		/// <param name="poly">Polygon to check for clockwiseness.</param>
		/// <returns>True if polygon is clockwise, false otherwise.</returns>
		public static bool IsClockwise(ref MapWinGIS.Shape poly)
		{
			int numPoints = poly.numPoints;
			double area = 0;
			//loop through all edges of the polygon
			for(int i = 0; i <= numPoints-2; i++)
			{
				double oneX = poly.get_Point(i).x;
				double oneY = poly.get_Point(i).y;
				double twoX = poly.get_Point(i+1).x;
				double twoY = poly.get_Point(i+1).y;

				double trapArea = ((oneX * twoY) - (twoX * oneY));
				area += trapArea;
			}
			if(area > 0)
			{
				//polygon vertices are ordered counter-clockwise about the normal
				return false;
			}
			else
			{
				return true;
			}			
		}

		/// <summary>
		/// Calculates the Area to find if a simple convex or
		/// concave polyon is ordered clockwise or counter-clockwise.
		/// </summary>
		/// <param name="V">Array of vertices from the polygon whose orientation
		/// is being determined.</param>
		/// <returns>True if polygon vertices are oriented clockwise about 
		/// the normal, false otherwise.</returns>
		public static bool IsClockwise(ref Vertex[] V)
		{
			int numPoints = V.Length;
			double area = 0;
			//loop through all edges of the polygon
			for(int i = 0; i <= numPoints-2; i++)
			{
				double oneX = V[i].x;
				double oneY = V[i].y;
				double twoX = V[i+1].x;
				double twoY = V[i+1].y;

				double trapArea = ((oneX * twoY) - (twoX * oneY));
				area += trapArea;
			}
			if(area > 0)
			{
				//if area is positive, then
				//vertices are ordered counter-clockwise about the normal
				return false;
			}
			else
			{
				//vertices are ordered clockwise about the normal
				return true;
			}
		}
		#endregion

		#region CopyFields()
        // Refactored by Simon Batson to allow renaming of duplicate fields
		/// <summary>
		/// Copies all fields from the inputSF .dbf table to the resultSF table.
		/// </summary>
		/// <param name="inputSF">The shapefile with fields to be copied.</param>
		/// <param name="resultSF">The result shapefile that will inherit the fields.</param>
		/// <returns>False if an error was encountered, true otherwise.</returns>
		public static bool CopyFields(ref MapWinGIS.Shapefile inputSF, ref MapWinGIS.Shapefile resultSF)
		{
            return CopyFields(ref inputSF, ref resultSF, false);
		}

        /// <summary>
        /// Copies all fields from the inputSF .dbf table to the resultSF table.
        /// </summary>
        /// <param name="inputSF">The shapefile with fields to be copied.</param>
        /// <param name="resultSF">The result shapefile that will inherit the fields.</param>
        /// <param name="renameDuplicates">Instructs function to rename duplicate fields, used when merging two shape files.</param>
        /// <returns>False if an error was encountered, true otherwise.</returns>
        public static bool CopyFields(ref MapWinGIS.Shapefile inputSF, ref MapWinGIS.Shapefile resultSF, bool renameDuplicates)
        {
			int fieldIndex = 0;
			int numFields = inputSF.NumFields;
            for (int i = 0; i <= numFields - 1; i++)
			{
				MapWinGIS.Field field = new MapWinGIS.FieldClass();
				field.Name = inputSF.get_Field(i).Name;
				field.Type = inputSF.get_Field(i).Type;
                if (field.Type == MapWinGIS.FieldType.STRING_FIELD)
				{
					field.Width = inputSF.get_Field(i).Width;
				}
                else if (field.Type == MapWinGIS.FieldType.DOUBLE_FIELD)
				{
					field.Precision = inputSF.get_Field(i).Precision;
				}
				fieldIndex = resultSF.NumFields;
				
                if (!renameDuplicates)
                {
                    if (FindField(field.Name, ref resultSF) > -1)
                    {
                        if (field.Name.Length < 10)
                            field.Name = field.Name + "1";
                        else
                            field.Name = field.Name.Substring(0, 9) + "1";
                    }
                }

                if (resultSF.EditInsertField(field, ref fieldIndex, null) == false)
				{
					gErrorMsg = "Problem inserting field into result DBF table: " + resultSF.get_ErrorMsg(resultSF.LastErrorCode);
					Debug.WriteLine(gErrorMsg);
					Error.SetErrorMsg(gErrorMsg);
					return false;
				}
			}//end of inserting fields
			return true;
		}
		#endregion

        // Find the specified field in a shapefile. CDM 1/17/2007
        public static int FindField(string FieldName, ref MapWinGIS.Shapefile sf)
        {
            if (sf == null) return -1;

            for (int i = 0; i < sf.NumFields; i++)
                if (sf.get_Field(i).Name.ToLower().Trim() == FieldName.ToLower().Trim()) return i;

            return -1;
        }

		#region InsertIDs()
		/// <summary>
		/// Inserts the field 'ID' into the .dbf table along with the corresponding
		/// value for each shape in the input shapefile.
		/// </summary>
		/// <param name="sf">The input shapefile.</param>
		/// <returns>False if an error was encountered, true otherwise.</returns>
		public static bool DoInsertIDs(ref MapWinGIS.Shapefile sf)
		{
			//add ID field to the .dbf table
			MapWinGIS.Field ID = new MapWinGIS.FieldClass();
			ID.Name = "MWShapeID";
			ID.Type = MapWinGIS.FieldType.INTEGER_FIELD;
			int fieldIndex = 0;
			if(sf.EditInsertField(ID, ref fieldIndex, null)==false)
			{
				gErrorMsg = "Problem inserting field into .dbf table: " + sf.get_ErrorMsg(sf.LastErrorCode);
				Debug.WriteLine(gErrorMsg);
				Error.SetErrorMsg(gErrorMsg);
				return false;
			}
			//add id values to the dbf table
			int numIDs = sf.NumShapes;
			for(int i = 0; i<= numIDs-1; i++)
			{
				if(sf.EditCellValue(0, i, i) == false)
				{
					gErrorMsg = "Problem inserting value into .dbf table for shape " + i + ": " + sf.get_ErrorMsg(sf.LastErrorCode);
					Debug.WriteLine(gErrorMsg);
					Error.SetErrorMsg(gErrorMsg);
					return false;
				}
			}
			return true;
		}
		#endregion
	}
}
