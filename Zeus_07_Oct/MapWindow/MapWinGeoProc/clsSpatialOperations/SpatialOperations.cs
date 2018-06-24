//********************************************************************************************************
//File name: SpatialOperations.cs
//Description: Public class, provides methods for clipping grids and shapefiles and selecting shapes with a polygon.
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
//9-1-05 ah - Angela Hillier - Created clipping methods and support functions.
//12-6-05 ah - Angela Hillier - added selection method
//1-12-06 ah - Angela Hilleir - provided initial API and parameter descriptions for unimplemented functions	
//2-27-06 ah - Angela Hillier - added MergeShapes()
//3-29-06 ah - Angela Hillier - added Buffer routines 							
//4-14-06 mg - Mark Gray - simplified and moved error checking in ClipGridWithPolygon wrappers
//6-04-06 ah - Angela Hillier - altered ClipPolygonWithLine and ClipLineWithPolygon to handle multi-part polygons.					
//8-06-06 aa - Allen Anselmo - altered clips to add a copyAttribute parameter
//7-04-07 sb - Simon Batson - added Identity processing
//********************************************************************************************************
using System;
using System.Diagnostics;
using System.IO;
using MapWindow.Interfaces.Geometries;
namespace MapWinGeoProc
{
    /// <summary>
    /// An enumeration which is intended to eventually contain a list of spatial join types (only nearest is supported)
    /// </summary>
    public enum SpatialJoinTypes
    {
        /// <summary>
        /// An enum element representing the Nearest topology operation
        /// </summary>
        Nearest
    };

	/// <summary>
	/// Contains public methods for users to clip grids and shapes with.
	/// </summary>
	public class SpatialOperations
	{
		//All methods are static so that no instance of the class is required.
		//If changes are made to a function, be sure to make similar changes in the overloaded versions.
		
		//When clipping polygons with polygons, we can make use of the GPC library in MapWinGIS.Utils

		private static string gErrorMsg = "";

		#region ClipGridWithPolygon()
		/// <summary>
		/// Creates a new grid containing data from the input grid that
		/// falls within the polygon shape.
		/// </summary>
		/// <param name="inputGFPath">Full path to the input grid file.</param>
		/// <param name="polygon">The 2D polygon used for clipping the input grid.</param>
		/// <param name="resultGFPath">Full path to where the resulting grid will be saved.</param>
		/// <returns>True if clipping was successful, false otherwise.</returns>
		public static bool ClipGridWithPolygon(ref string inputGFPath, ref MapWinGIS.Shape polygon, ref string resultGFPath)
		{

            MapWinUtility.Logger.Dbg("ClipGridWithPolygon(intputGFPath: " + inputGFPath + ",\n" +
                                     "                    polygon: " + Macro.ParamName(polygon) + ",\n" +
                                     "                    resultGFPath: " + resultGFPath + ")");

			return ClipGridWithPolygon(ref inputGFPath, ref polygon, ref resultGFPath, false);

		}

		/// <summary>
		/// Creates a new grid containing data from the input grid that
		/// falls within the polygon shape or within the polygon extents.
		/// </summary>
		/// <param name="inputGFPath">Full path to the input grid file.</param>
		/// <param name="polygon">The 2D polygon used for clipping the input grid.</param>
		/// <param name="resultGFPath">Full path to where the resulting grid will be saved.</param>
		/// <param name="clipToExtents">True if clipping to polygon extents rather than actual polygon shape.</param>
		/// <returns>True if clipping was successful, false otherwise.</returns>
		public static bool ClipGridWithPolygon(ref string inputGFPath, ref MapWinGIS.Shape polygon, ref string resultGFPath, bool clipToExtents)
		{
            MapWinUtility.Logger.Dbg("ClipGridWithPolygon(inputGFPath: " + inputGFPath + ",\n" +
                                     "                    polygon: " + polygon + ",\n" +
                                     "                    resultGFPath: " + resultGFPath + ",\n" +
                                     "                    clipToExtents: " + clipToExtents);
			Error.ClearErrorLog();

			if(!File.Exists(inputGFPath) || polygon.numPoints == 0 || resultGFPath.Equals(""))
			{
				gErrorMsg = "One parameter is invalid. Aborting call to ClipGridWithPolygon().";
				Debug.WriteLine(gErrorMsg);
				Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
				return false;
			}
			else
			{
                MapWinUtility.Logger.Dbg("Finished ClipGridWithPolygon");
				return ClipGridWithPoly.ClipGridWithPolygon(ref inputGFPath, ref polygon, ref resultGFPath, clipToExtents);
			}
           
		}
		#endregion

		#region SelectWithPolygon()
        		/// <summary>
		/// Selects all points/lines/polygons in the input shapefile that intersect the polygon shape.
		/// Returns the selected shapes in a new shapefile.
		/// </summary>
		/// <param name="inputSFPath">The full path to the shapefile containing shapes for selection.</param>
		/// <param name="polygon">The polygon used for selecting shapes from the shapefile.</param>
		/// <param name="resultSFPath">The full path to where the selected shapes should be saved.</param>
		/// <returns>False if an error was encountered or no shapes selected, true otherwise.</returns>
        public static bool SelectWithPolygon(ref string inputSFPath, ref MapWinGIS.Shape polygon, ref string resultSFPath)
        {
            MapWinUtility.Logger.Dbg("SelectWithPolygon(inputSFPath: " + inputSFPath + ",\n" +
                                     "                  polygon: " + Macro.ParamName(polygon) + ",\n" +
                                     "                  resultSFPath: " + resultSFPath + ")");
            return SelectWithPolygon(ref inputSFPath, ref polygon, ref resultSFPath, false);
            
        }
		/// <summary>
		/// Selects all points/lines/polygons in the input shapefile that intersect the polygon shape.
		/// Returns the selected shapes in a new shapefile.
		/// </summary>
		/// <param name="inputSFPath">The full path to the shapefile containing shapes for selection.</param>
		/// <param name="polygon">The polygon used for selecting shapes from the shapefile.</param>
		/// <param name="resultSFPath">The full path to where the selected shapes should be saved.</param>
        /// <param name="SkipMWShapeID">Indicates whether to skip creating an MWShapeID field in the result.</param>
		/// <returns>False if an error was encountered or no shapes selected, true otherwise.</returns>
		public static bool SelectWithPolygon(ref string inputSFPath, ref MapWinGIS.Shape polygon, ref string resultSFPath, bool SkipMWShapeID)
		{
            MapWinUtility.Logger.Dbg("SelectWithPolygon(inputSFPath: " + inputSFPath + ",\n" +
                                     "                  polygon: " + Macro.ParamName(polygon) + ",\n" +
                                     "                  resultSFPath: " + resultSFPath + ",\n" +
                                     "                  SkipMWShapeID: " + SkipMWShapeID.ToString() + ")");
			Error.ClearErrorLog();
			bool status = false;
			MapWinGIS.Shapefile inputSF = new MapWinGIS.ShapefileClass();
			inputSF.Open(inputSFPath, null);
			MapWinGIS.ShpfileType sfType = inputSF.ShapefileType;
			MapWinGIS.Shapefile resultSF = new MapWinGIS.ShapefileClass();
			//create the result file
			if(Globals.PrepareResultSF(ref resultSFPath, ref resultSF, sfType, true) == false)
			{
                // I think this already logged the error in PrepareResultSF
				return false;
			}
			
			if(sfType != MapWinGIS.ShpfileType.SHP_NULLSHAPE)
			{
				if(sfType == MapWinGIS.ShpfileType.SHP_POLYGON || sfType == MapWinGIS.ShpfileType.SHP_POLYGONM || sfType == MapWinGIS.ShpfileType.SHP_POLYGONZ)
				{					
					status = Selection.SelectPolygonsWithPolygon(ref inputSF, ref polygon, ref resultSF, SkipMWShapeID);
				}
				else if(sfType == MapWinGIS.ShpfileType.SHP_POINT || sfType == MapWinGIS.ShpfileType.SHP_POINTM || sfType == MapWinGIS.ShpfileType.SHP_POINTZ)
				{
                    status = Selection.SelectPointsWithPolygon(ref inputSF, ref polygon, ref resultSF, SkipMWShapeID);
				}
				else if(sfType == MapWinGIS.ShpfileType.SHP_POLYLINE || sfType == MapWinGIS.ShpfileType.SHP_POLYLINEM || sfType == MapWinGIS.ShpfileType.SHP_POLYLINEZ)
				{
                    status = Selection.SelectLinesWithPolygon(ref inputSF, ref polygon, ref resultSF, SkipMWShapeID);
				}
				else
				{
					gErrorMsg = "Not a valid shapefile type.";
					Debug.WriteLine(gErrorMsg);
					Error.SetErrorMsg(gErrorMsg);
                    MapWinUtility.Logger.Dbg(gErrorMsg);
					return false;
				}
			}
			else
			{
				gErrorMsg = "The shapefile is NULL, it must contain at least one shape.";
				Debug.WriteLine(gErrorMsg);
				Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
				return false;
			}

			//save the result file
			if(resultSF.NumShapes > 0 && status == true)
			{
				resultSF.StopEditingShapes(true, true, null);
				resultSF.SaveAs(resultSFPath, null);
				resultSF.Close();
				inputSF.Close();
                MapWinUtility.Logger.Dbg("Finished SelectWithPolygon");
				return true;
			}
			else
			{
                MapWinUtility.Logger.Dbg("Finished SelectWithPolygon");
				return false;
			}

		}

        /// <summary>
        /// Selects all points/lines/polygons in the input shapefile that intersect the polygon shape.
        /// Returns the indexes of the shapes that are found to fall in or cross the polygon.
        /// </summary>
        /// <param name="inputSFPath">The full path to the shapefile containing shapes for selection.</param>
        /// <param name="polygon">The polygon used for selecting shapes from the shapefile.</param>
        /// <param name="results">An arraylist of the resulting shape indices.</param>
        /// <returns>False if no shapes were found, true otherwise.</returns>
        public static bool SelectWithPolygon(ref string inputSFPath, ref MapWinGIS.Shape polygon, ref System.Collections.ArrayList results)
        {
            MapWinUtility.Logger.Dbg("SelectWithPolygon(inputSFPath: " + inputSFPath + ",\n" +
                                     "                  polygon: " + Macro.ParamName(polygon) + ",\n" +
                                     "                  results: out)"); 
            Error.ClearErrorLog();
            bool status = false;
            MapWinGIS.Shapefile inputSF = new MapWinGIS.ShapefileClass();
            inputSF.Open(inputSFPath, null);
            MapWinGIS.ShpfileType sfType = inputSF.ShapefileType;

            if (sfType != MapWinGIS.ShpfileType.SHP_NULLSHAPE)
            {
                if (sfType == MapWinGIS.ShpfileType.SHP_POLYGON || sfType == MapWinGIS.ShpfileType.SHP_POLYGONM || sfType == MapWinGIS.ShpfileType.SHP_POLYGONZ)
                {
                    status = Selection.SelectPolygonsWithPolygon(ref inputSF, ref polygon, ref results);
                }
                else if (sfType == MapWinGIS.ShpfileType.SHP_POINT || sfType == MapWinGIS.ShpfileType.SHP_POINTM || sfType == MapWinGIS.ShpfileType.SHP_POINTZ)
                {
                    status = Selection.SelectPointsWithPolygon(ref inputSF, ref polygon, ref results);
                }
                else if (sfType == MapWinGIS.ShpfileType.SHP_POLYLINE || sfType == MapWinGIS.ShpfileType.SHP_POLYLINEM || sfType == MapWinGIS.ShpfileType.SHP_POLYLINEZ)
                {
                    status = Selection.SelectLinesWithPolygon(ref inputSF, ref polygon, ref results);
                }
                else
                {
                    gErrorMsg = "Not a valid shapefile type.";
                    Debug.WriteLine(gErrorMsg);
                    Error.SetErrorMsg(gErrorMsg);
                    MapWinUtility.Logger.Dbg(gErrorMsg);
                    return false;
                }
            }
            else
            {
                gErrorMsg = "The shapefile is NULL, it must contain at least one shape.";
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                return false;
            }
            MapWinUtility.Logger.Dbg("Finished SelectWithPolygon");
            return status;
        }

		#endregion

		#region ClipShapesWithPolygon(): save-to-disk versions
		/// <summary>
		/// Saves all points/lines/polygons within the polygon's border to a new shapefile.
		/// </summary>
		/// <param name="inputSFPath">Full path to the input shapefile that will be clipped.</param>
		/// <param name="polygon">2D polygon used for clipping objects in inputSF.</param>
		/// <param name="resultSFPath">Full path to where the resulting shapefile should be saved.</param>
		/// <returns>True if clipping was successful, false if an error was encountered.</returns>
		public static bool ClipShapesWithPolygon(ref string inputSFPath, ref MapWinGIS.Shape polygon, ref string resultSFPath)
		{
            MapWinUtility.Logger.Dbg("ClipShapesWithPolygon(inputSFPath: " + inputSFPath + ",\n" +
                                     "                      polygon: " + Macro.ParamName(polygon) + ",\n" +
                                     "                      resultsSFPath: " + resultSFPath + ",\n");
			Error.ClearErrorLog();
			MapWinGIS.Shapefile sf = new MapWinGIS.ShapefileClass();
			sf.Open(inputSFPath, null);
			MapWinGIS.ShpfileType sfType = sf.ShapefileType;
			sf.Close();
			if(sfType != MapWinGIS.ShpfileType.SHP_NULLSHAPE)
			{
				if(sfType == MapWinGIS.ShpfileType.SHP_POLYGON || sfType == MapWinGIS.ShpfileType.SHP_POLYGONM || sfType == MapWinGIS.ShpfileType.SHP_POLYGONZ)
				{
                    return ClipPolySFWithPoly.ClipPolygonSFWithPolygon(ref inputSFPath, ref polygon, ref resultSFPath, false);
				}
				else if(sfType == MapWinGIS.ShpfileType.SHP_POINT || sfType == MapWinGIS.ShpfileType.SHP_POINTM || sfType == MapWinGIS.ShpfileType.SHP_POINTZ)
				{
                    return ClipPointSFWithPoly.ClipPointSFWithPolygon(ref inputSFPath, ref polygon, ref resultSFPath, false);
				}
				else if(sfType == MapWinGIS.ShpfileType.SHP_POLYLINE || sfType == MapWinGIS.ShpfileType.SHP_POLYLINEM || sfType == MapWinGIS.ShpfileType.SHP_POLYLINEZ)
				{
					//always call the "accurate" version for this overloaded method
					if(polygon.NumParts > 1)//multi-part polygon
					{
                        return ClipLineSFWithPoly.ClipLineSFWithMultiPartPolygon(ref inputSFPath, ref polygon, ref resultSFPath, false, false);
					}
					else //single-part polygon
					{
                        return ClipLineSFWithPoly.Accurate_ClipLineSFWithPolygon(ref inputSFPath, ref polygon, ref resultSFPath, false);
					}
				}
				else
				{
					gErrorMsg = "Not a valid shapefile type.";
					Debug.WriteLine(gErrorMsg);
					Error.SetErrorMsg(gErrorMsg);
                    MapWinUtility.Logger.Dbg(gErrorMsg);
					return false;
				}
			}
			else
			{
				gErrorMsg = "The shapefile is NULL, it must contain at least one shape.";
				Debug.WriteLine(gErrorMsg);
				Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
				return false;
			}
            
		}

		/// <summary>Saves all points/lines/polygons within the polygon's border to a new shapefile.</summary>
		/// <param name="inputSFPath">Full path to the input shapefile that will be clipped.</param>
		/// <param name="polygon">2D polygon used for clipping objects in inputSF.</param>
		/// <param name="resultSFPath">Full path to where the resulting shapefile should be saved.</param>
		/// <param name="speedOptimized">True if speed of computation is more important than accuracy when dealing with line shapefiles.</param>
		/// <returns>True if clipping was successful, false if an error was encountered.</returns>
		public static bool ClipShapesWithPolygon(ref string inputSFPath, ref MapWinGIS.Shape polygon, ref string resultSFPath, bool speedOptimized)
		{
            MapWinUtility.Logger.Dbg("ClipShapesWithPolygon(inputSFPath: " + inputSFPath + ",\n" +
                                     "                      polygon: " + Macro.ParamName(polygon) + ",\n" +
                                     "                      resultSFPath: " +resultSFPath + ",\n" +
                                     "                      sppedOptimized: " + speedOptimized + ")");

			Error.ClearErrorLog();
			MapWinGIS.Shapefile sf = new MapWinGIS.ShapefileClass();
			sf.Open(inputSFPath, null);
			MapWinGIS.ShpfileType sfType = sf.ShapefileType;
			sf.Close();
			if(sfType != MapWinGIS.ShpfileType.SHP_NULLSHAPE)
			{
				if(sfType == MapWinGIS.ShpfileType.SHP_POLYGON || sfType == MapWinGIS.ShpfileType.SHP_POLYGONM || sfType == MapWinGIS.ShpfileType.SHP_POLYGONZ)
				{
                    return ClipPolySFWithPoly.ClipPolygonSFWithPolygon(ref inputSFPath, ref polygon, ref resultSFPath, false);
				}
				else if(sfType == MapWinGIS.ShpfileType.SHP_POINT || sfType == MapWinGIS.ShpfileType.SHP_POINTM || sfType == MapWinGIS.ShpfileType.SHP_POINTZ)
				{
                    return ClipPointSFWithPoly.ClipPointSFWithPolygon(ref inputSFPath, ref polygon, ref resultSFPath, false);
				}
				else if(sfType == MapWinGIS.ShpfileType.SHP_POLYLINE || sfType == MapWinGIS.ShpfileType.SHP_POLYLINEM || sfType == MapWinGIS.ShpfileType.SHP_POLYLINEZ)
				{
					if(polygon.NumParts > 1) //multi-part polygon
					{
                        return ClipLineSFWithPoly.ClipLineSFWithMultiPartPolygon(ref inputSFPath, ref polygon, ref resultSFPath, speedOptimized, false);
					}
					else //single-part polygon
					{
						if(speedOptimized == true)
						{
                            return ClipLineSFWithPoly.Fast_ClipLineSFWithPolygon(ref inputSFPath, ref polygon, ref resultSFPath, false);
						}
						else
						{
							return ClipLineSFWithPoly.Accurate_ClipLineSFWithPolygon(ref inputSFPath, ref polygon, ref resultSFPath, false);
						}
					}
				}
				else
				{
					gErrorMsg = "Not a valid shapefile type.";
					Debug.WriteLine(gErrorMsg);
					Error.SetErrorMsg(gErrorMsg);
                    MapWinUtility.Logger.Dbg(gErrorMsg);
					return false;
				}
			}
			else
			{
				gErrorMsg = "The shapefile is NULL, it must contain at least one shape.";
				Debug.WriteLine(gErrorMsg);
				Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
				return false;
			}
		}


        /// <summary>Saves all points/lines/polygons within the polygon's border to a new shapefile.</summary>
        /// <param name="inputSFPath">Full path to the input shapefile that will be clipped.</param>
        /// <param name="polygon">2D polygon used for clipping objects in inputSF.</param>
        /// <param name="resultSFPath">Full path to where the resulting shapefile should be saved.</param>
        /// <param name="speedOptimized">True if speed of computation is more important than accuracy when dealing with line shapefiles.</param>
        /// <param name="copyAttributes">True if copying Attributes</param>
        /// <returns>True if clipping was successful, false if an error was encountered.</returns>
        public static bool ClipShapesWithPolygon(ref string inputSFPath, ref MapWinGIS.Shape polygon, ref string resultSFPath, bool speedOptimized, bool copyAttributes)
        {
            MapWinUtility.Logger.Dbg("ClipShapesWithPolygon(inputSFPath: " + inputSFPath + ",\n" +
                                     "                      polygon: " + Macro.ParamName(polygon) + ",\n" +
                                     "                      resultsSFPath: " + resultSFPath + ",\n" +
                                     "                      speedOptimized: " + speedOptimized.ToString() + ",\n" +
                                     "                      copyAttributes: " + copyAttributes.ToString() + ")");
            Error.ClearErrorLog();
            MapWinGIS.Shapefile sf = new MapWinGIS.ShapefileClass();
            sf.Open(inputSFPath, null);
            MapWinGIS.ShpfileType sfType = sf.ShapefileType;
            sf.Close();
            if (sfType != MapWinGIS.ShpfileType.SHP_NULLSHAPE)
            {
                if (sfType == MapWinGIS.ShpfileType.SHP_POLYGON || sfType == MapWinGIS.ShpfileType.SHP_POLYGONM || sfType == MapWinGIS.ShpfileType.SHP_POLYGONZ)
                {
                    return ClipPolySFWithPoly.ClipPolygonSFWithPolygon(ref inputSFPath, ref polygon, ref resultSFPath, copyAttributes);
                }
                else if (sfType == MapWinGIS.ShpfileType.SHP_POINT || sfType == MapWinGIS.ShpfileType.SHP_POINTM || sfType == MapWinGIS.ShpfileType.SHP_POINTZ)
                {
                    return ClipPointSFWithPoly.ClipPointSFWithPolygon(ref inputSFPath, ref polygon, ref resultSFPath, copyAttributes);
                }
                else if (sfType == MapWinGIS.ShpfileType.SHP_POLYLINE || sfType == MapWinGIS.ShpfileType.SHP_POLYLINEM || sfType == MapWinGIS.ShpfileType.SHP_POLYLINEZ)
                {
                    if (polygon.NumParts > 1) //multi-part polygon
                    {
                        return ClipLineSFWithPoly.ClipLineSFWithMultiPartPolygon(ref inputSFPath, ref polygon, ref resultSFPath, speedOptimized, copyAttributes);
                    }
                    else //single-part polygon
                    {
                        if (speedOptimized == true)
                        {
                            return ClipLineSFWithPoly.Fast_ClipLineSFWithPolygon(ref inputSFPath, ref polygon, ref resultSFPath, copyAttributes);
                        }
                        else
                        {
                            return ClipLineSFWithPoly.Accurate_ClipLineSFWithPolygon(ref inputSFPath, ref polygon, ref resultSFPath, copyAttributes);
                        }
                    }
                }
                else
                {
                    gErrorMsg = "Not a valid shapefile type.";
                    Debug.WriteLine(gErrorMsg);
                    Error.SetErrorMsg(gErrorMsg);
                    MapWinUtility.Logger.Dbg(gErrorMsg);
                    return false;
                }
            }
            else
            {
                gErrorMsg = "The shapefile is NULL, it must contain at least one shape.";
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                return false;
            }
        }

		#endregion

		#region ClipShapesWithPolygon(): save-to-memory versions
		/// <summary>Returns all points/lines/polygons inside the polygon's border as a new shapefile (in memory).</summary>
		/// <param name="inputSF">Input shapefile of lines, points, or polygons in need of clipping.</param>
		/// <param name="polygon">2D polygon shape used for clipping the shapefile.</param>
		/// <param name="resultSF">Output polygon shapefile which will contain all shapes that fall inside the boundaries of poly.</param>
		/// <returns>True if clipping was successful, false if an error occured. </returns> 
		public static bool ClipShapesWithPolygon(ref MapWinGIS.Shapefile inputSF, ref MapWinGIS.Shape polygon, out MapWinGIS.Shapefile resultSF)
		{
            MapWinUtility.Logger.Dbg("ClipShapesWithPolygon(inputSF: " + Macro.ParamName(inputSF) + ",\n" + 
                                     "                      polygon: " + Macro.ParamName(polygon) + ",\n" + 
                                     "                      resultSF: out)");
			MapWinGeoProc.Error.ClearErrorLog();
			MapWinGIS.ShpfileType sfType = inputSF.ShapefileType;
			MapWinGIS.Shapefile resultFile = new MapWinGIS.ShapefileClass();
			bool status;
					
			if(sfType != MapWinGIS.ShpfileType.SHP_NULLSHAPE)
			{
				if(sfType == MapWinGIS.ShpfileType.SHP_POLYGON || sfType == MapWinGIS.ShpfileType.SHP_POLYGONM || sfType == MapWinGIS.ShpfileType.SHP_POLYGONZ)
				{
					status = ClipPolySFWithPoly.ClipPolygonSFWithPolygon(ref inputSF, ref polygon, out resultFile, false);
				}
				else if(sfType == MapWinGIS.ShpfileType.SHP_POINT || sfType == MapWinGIS.ShpfileType.SHP_POINTM || sfType == MapWinGIS.ShpfileType.SHP_POINTZ)
				{
                    status = ClipPointSFWithPoly.ClipPointSFWithPolygon(ref inputSF, ref polygon, out resultFile, false);
				}
				else if(sfType == MapWinGIS.ShpfileType.SHP_POLYLINE || sfType == MapWinGIS.ShpfileType.SHP_POLYLINEM || sfType == MapWinGIS.ShpfileType.SHP_POLYLINEZ)
				{
					if(polygon.NumParts > 1)
					{
                        status = ClipLineSFWithPoly.ClipLineSFWithMultiPartPolygon(ref inputSF, ref polygon, out resultFile, false, false);
					}
					else
					{
                        status = ClipLineSFWithPoly.Accurate_ClipLineSFWithPolygon(ref inputSF, ref polygon, out resultFile, false);
					}
				}
				else
				{
					gErrorMsg = "Not a valid Shapefile type.";
					Debug.WriteLine(gErrorMsg);
					MapWinGeoProc.Error.SetErrorMsg(gErrorMsg);
					resultSF = resultFile;
                    MapWinUtility.Logger.Dbg(gErrorMsg);
					return false;
				}
			}
			else
			{
				gErrorMsg = "NullShape is not a valid type.";
				Debug.WriteLine(gErrorMsg);
				MapWinGeoProc.Error.SetErrorMsg(gErrorMsg);
				resultSF = resultFile;
                MapWinUtility.Logger.Dbg(gErrorMsg);
				return false;
			}
			resultSF = resultFile;
            MapWinUtility.Logger.Dbg("Finsihed ClipShapesWithPolygon");
			return status;			
		}
		
		//Overloaded version for fast processing of line shapefiles
		/// <summary>Returns all points/lines/polygons inside the polygon's border as a new shapefile (in memory).</summary>
		/// <param name="inputSF">Input shapefile of lines, points, or polygons in need of clipping.</param>
		/// <param name="polygon">2D polygon shape used for clipping the shapefile.</param>
		/// <param name="resultSF">Output polygon shapefile which will contain all shapes that fall inside the boundaries of poly.</param>
		/// <param name="speedOptimized">True if speed of computation is more important than accuracy when dealing with line shapefiles.</param>
		/// <returns>True if clipping was successful, false if an error occured. </returns> 
		public static bool ClipShapesWithPolygon(ref MapWinGIS.Shapefile inputSF, ref MapWinGIS.Shape polygon, out MapWinGIS.Shapefile resultSF, bool speedOptimized)
		{
            MapWinUtility.Logger.Dbg("ClipShapesWithPolygon(inputSF: " + Macro.ParamName(inputSF) + ",\n" +
                                     "                      polygon: " + Macro.ParamName(polygon) + ",\n" +
                                     "                      resultSF: out,\n" +
                                     "                      speedOptimized: " + speedOptimized.ToString() + ")");
			MapWinGeoProc.Error.ClearErrorLog();
			MapWinGIS.ShpfileType sfType = inputSF.ShapefileType;
			MapWinGIS.Shapefile resultFile = new MapWinGIS.ShapefileClass();
			bool status;
					
			if(sfType != MapWinGIS.ShpfileType.SHP_NULLSHAPE)
			{
				if(sfType == MapWinGIS.ShpfileType.SHP_POLYGON || sfType == MapWinGIS.ShpfileType.SHP_POLYGONM || sfType == MapWinGIS.ShpfileType.SHP_POLYGONZ)
				{
                    status = ClipPolySFWithPoly.ClipPolygonSFWithPolygon(ref inputSF, ref polygon, out resultFile, false);
				}
				else if(sfType == MapWinGIS.ShpfileType.SHP_POINT || sfType == MapWinGIS.ShpfileType.SHP_POINTM || sfType == MapWinGIS.ShpfileType.SHP_POINTZ)
				{
					status = ClipPointSFWithPoly.ClipPointSFWithPolygon(ref inputSF, ref polygon, out resultFile, false);
				}
				else if(sfType == MapWinGIS.ShpfileType.SHP_POLYLINE || sfType == MapWinGIS.ShpfileType.SHP_POLYLINEM || sfType == MapWinGIS.ShpfileType.SHP_POLYLINEZ)
				{
					if(polygon.NumParts > 1)
					{
                        status = ClipLineSFWithPoly.ClipLineSFWithMultiPartPolygon(ref inputSF, ref polygon, out resultFile, speedOptimized, false);
					}
					else
					{
						if(speedOptimized == true)
						{
                            status = ClipLineSFWithPoly.Fast_ClipLineSFWithPolygon(ref inputSF, ref polygon, out resultFile, false);
						}
						else
						{
							status = ClipLineSFWithPoly.Accurate_ClipLineSFWithPolygon(ref inputSF, ref polygon, out resultFile, false);
						}
					}
				}
				else
				{
					gErrorMsg = "Not a valid Shapefile type.";
					Debug.WriteLine(gErrorMsg);
					MapWinGeoProc.Error.SetErrorMsg(gErrorMsg);
					resultSF = resultFile;
                    MapWinUtility.Logger.Dbg(gErrorMsg);
					return false;
				}
			}
			else
			{
				gErrorMsg = "NullShape is not a valid type.";
				Debug.WriteLine(gErrorMsg);
				MapWinGeoProc.Error.SetErrorMsg(gErrorMsg);
				resultSF = resultFile;
                MapWinUtility.Logger.Dbg(gErrorMsg);
				return false;
			}
			resultSF = resultFile;
            MapWinUtility.Logger.Dbg("Finished CLipShapesWithPolygon");
			return status;			
		}

        //Overloaded version for fast processing of line shapefiles and copy attributes overload
        /// <summary>Returns all points/lines/polygons inside the polygon's border as a new shapefile (in memory).</summary>
        /// <param name="inputSF">Input shapefile of lines, points, or polygons in need of clipping.</param>
        /// <param name="polygon">2D polygon shape used for clipping the shapefile.</param>
        /// <param name="resultSF">Output polygon shapefile which will contain all shapes that fall inside the boundaries of poly.</param>
        /// <param name="speedOptimized">True if speed of computation is more important than accuracy when dealing with line shapefiles.</param>
        /// <param name="copyAttributes">True if copying attributes over</param>
        /// <returns>True if clipping was successful, false if an error occured. </returns> 
        public static bool ClipShapesWithPolygon(ref MapWinGIS.Shapefile inputSF, ref MapWinGIS.Shape polygon, out MapWinGIS.Shapefile resultSF, bool speedOptimized, bool copyAttributes)
        {
            MapWinUtility.Logger.Dbg("ClipShapesWithPolygon(inputSF: " + Macro.ParamName(inputSF) + ",\n" +
                                     "                      polygon: " + Macro.ParamName(polygon) + ",\n" +
                                     "                      resultSF: out,\n" +
                                     "                      speedOptimized: " + speedOptimized.ToString() + ",\n" +
                                     "                      copyAttributes: " + copyAttributes.ToString() + ",\n");
            MapWinGeoProc.Error.ClearErrorLog();
            MapWinGIS.ShpfileType sfType = inputSF.ShapefileType;
            MapWinGIS.Shapefile resultFile = new MapWinGIS.ShapefileClass();
            bool status;

            if (sfType != MapWinGIS.ShpfileType.SHP_NULLSHAPE)
            {
                if (sfType == MapWinGIS.ShpfileType.SHP_POLYGON || sfType == MapWinGIS.ShpfileType.SHP_POLYGONM || sfType == MapWinGIS.ShpfileType.SHP_POLYGONZ)
                {
                    status = ClipPolySFWithPoly.ClipPolygonSFWithPolygon(ref inputSF, ref polygon, out resultFile, copyAttributes);
                }
                else if (sfType == MapWinGIS.ShpfileType.SHP_POINT || sfType == MapWinGIS.ShpfileType.SHP_POINTM || sfType == MapWinGIS.ShpfileType.SHP_POINTZ)
                {
                    status = ClipPointSFWithPoly.ClipPointSFWithPolygon(ref inputSF, ref polygon, out resultFile, copyAttributes);
                }
                else if (sfType == MapWinGIS.ShpfileType.SHP_POLYLINE || sfType == MapWinGIS.ShpfileType.SHP_POLYLINEM || sfType == MapWinGIS.ShpfileType.SHP_POLYLINEZ)
                {
                    if (polygon.NumParts > 1)
                    {
                        status = ClipLineSFWithPoly.ClipLineSFWithMultiPartPolygon(ref inputSF, ref polygon, out resultFile, speedOptimized, copyAttributes);
                    }
                    else
                    {
                        if (speedOptimized == true)
                        {
                            status = ClipLineSFWithPoly.Fast_ClipLineSFWithPolygon(ref inputSF, ref polygon, out resultFile, copyAttributes);
                        }
                        else
                        {
                            status = ClipLineSFWithPoly.Accurate_ClipLineSFWithPolygon(ref inputSF, ref polygon, out resultFile, copyAttributes);
                        }
                    }
                }
                else
                {
                    gErrorMsg = "Not a valid Shapefile type.";
                    Debug.WriteLine(gErrorMsg);
                    MapWinGeoProc.Error.SetErrorMsg(gErrorMsg);
                    resultSF = resultFile;
                    MapWinUtility.Logger.Dbg(gErrorMsg);
                    return false;
                }
            }
            else
            {
                gErrorMsg = "NullShape is not a valid type.";
                Debug.WriteLine(gErrorMsg);
                MapWinGeoProc.Error.SetErrorMsg(gErrorMsg);
                resultSF = resultFile;
                MapWinUtility.Logger.Dbg(gErrorMsg);
                return false;
            }
            resultSF = resultFile;
            MapWinUtility.Logger.Dbg("Finished ClipShapesWithPolygon");
            return status;
        }

		#endregion
        
		#region ClipPolygonSFWithLineSF
		/// <summary>
		/// In Development: Prone to errors! 
		/// For clipping multiple polygons with multiple lines.
		/// </summary>
		/// <param name="polySF">The polygon shapefile.</param>
		/// <param name="lineSF">The line shapefile.</param>
		/// <param name="resultSF">The result shapefile containing the polygon sections.</param>
		/// <returns>False if an error was encountered, true otherwise.</returns>
		public static bool ClipPolygonSFWithLineSF(ref MapWinGIS.Shapefile polySF, ref MapWinGIS.Shapefile lineSF, out MapWinGIS.Shapefile resultSF)
		{
            MapWinUtility.Logger.Dbg("ClipPolygonSFWithLineSF(polySF: " + polySF.ToString() + ",\n" +
                                     "                        lineSF: " + lineSF.ToString() + ",\n" +
                                     "                        resultSF: out");
			Error.ClearErrorLog();
			return ClipPolyWithLine.ClipPolySFWithLineSF(ref polySF, ref lineSF, out resultSF);
		}
		#endregion

		#region ClipPolygonWithLine()
		/// <summary>
		/// Divides a polygon into multiple sections depending on where a line crosses it. Saves the resulting
		/// polygon sections to a new polygon shapefile.
		/// </summary>
		/// <param name="polygon">The polygon to be divided.</param>
		/// <param name="line">The line that will be used to divide the polgyon.</param>
		/// <param name="resultSFPath">The full path to where the resulting polygons should be saved.</param>
		/// <returns>False if an error was encountered, true otherwise.</returns>
		public static bool ClipPolygonWithLine(ref MapWinGIS.Shape polygon, ref MapWinGIS.Shape line, ref string resultSFPath)
		{
            MapWinUtility.Logger.Dbg("ClipPolygonWithLine(polygon: " + Macro.ParamName(polygon) + ",\n" +
                                     "                    line: " + Macro.ParamName(line) + ",\n" +
                                     "                    resultsSFPath: " + resultSFPath + ")");
			//save-to-disk, accurate form
			Error.ClearErrorLog();
			//always call the accurate version for this overload
			if(polygon.NumParts > 1)
			{
				return ClipPolyWithLine.ClipMultiPartPolyWithLine(ref polygon, ref line, ref resultSFPath, false);
			}
			else
			{
				return ClipPolyWithLine.Accurate_ClipPolygonWithLine(ref polygon, ref line, ref resultSFPath);
			}
		}
		/// <summary>
		/// Divides a polygon into multiple sections depending on where a line crosses it. Saves the resulting
		/// polygon sections to a new polygon shapefile.
		/// </summary>
		/// <param name="polygon">The polygon to be divided.</param>
		/// <param name="line">The line that will be used to divide the polgyon.</param>
		/// <param name="resultSF">The in-memory shapefile where resulting polygons should be saved.</param>
		/// <returns>False if an error was encountered, true otherwise.</returns>
		public static bool ClipPolygonWithLine(ref MapWinGIS.Shape polygon, ref MapWinGIS.Shape line, out MapWinGIS.Shapefile resultSF)
		{
            MapWinUtility.Logger.Dbg("ClipPolygonWithLine(polygon: " + Macro.ParamName(polygon) + ",\n" +
                                     "                    line: " + Macro.ParamName(line) + ",\n" +
                                     "                    resultSF: out)");
			//in-memory, accurate form
			Error.ClearErrorLog();
			//always call accurate verion
			if(polygon.NumParts > 1)
			{
				return ClipPolyWithLine.ClipMultiPartPolyWithLine(ref polygon, ref line, out resultSF, false);
			}
			else
			{
				return ClipPolyWithLine.Accurate_ClipPolygonWithLine(ref polygon, ref line, out resultSF);
			}
		}

		/// <summary>
		/// Divides a polygon into multiple sections depending on where a line crosses it. Saves the resulting
		/// polygon sections to a new polygon shapefile.
		/// </summary>
		/// <param name="polygon">The polygon to be divided.</param>
		/// <param name="line">The line that will be used to divide the polgyon.</param>
		/// <param name="resultSFPath">The full path to where the resulting polygons should be saved.</param>
		/// <param name="speedOptimized">True if a line follows the assumption that only one intersection
		/// occurs for any 2pt segment. And only 2pt segments that have a point inside->outside or outside->inside
		/// will be tested for interesection.</param>
		/// <returns>False if an error was encountered, true otherwise.</returns>
		public static bool ClipPolygonWithLine(ref MapWinGIS.Shape polygon, ref MapWinGIS.Shape line, ref string resultSFPath, bool speedOptimized)
		{
            MapWinUtility.Logger.Dbg("CLipPolygonWithLIne(polygon: " + Macro.ParamName(polygon) + ",\n" +
                                     "                    line: " + resultSFPath + ",\n" +
                                     "                    resultSFPath: " + resultSFPath + ",\n" +
                                     "                    speedOptimized: " + speedOptimized.ToString() + ")");
			//save-to-disk form
			Error.ClearErrorLog();			
			if(polygon.NumParts > 1)
			{
				return ClipPolyWithLine.ClipMultiPartPolyWithLine(ref polygon, ref line, ref resultSFPath, speedOptimized);
			}
			else
			{
				if(speedOptimized == true)
				{
					return ClipPolyWithLine.Fast_ClipPolygonWithLine(ref polygon, ref line, ref resultSFPath);
				}
				else
				{
					return ClipPolyWithLine.Accurate_ClipPolygonWithLine(ref polygon, ref line, ref resultSFPath);
				}
			}
		}
		/// <summary>
		/// Divides a polygon into multiple sections depending on where a line crosses it. Saves the resulting
		/// polygon sections to a new polygon shapefile.
		/// </summary>
		/// <param name="polygon">The polygon to be divided.</param>
		/// <param name="line">The line that will be used to divide the polgyon.</param>
		/// <param name="resultSF">The in-memory shapefile where resulting polygons should be saved.</param>
		/// <param name="speedOptimized">True if a line follows the assumption that only one intersection
		/// occurs for any 2pt segment. And only 2pt segments that have a point inside->outside or outside->inside
		/// will be tested for interesection.</param>
		/// <returns>False if an error was encountered, true otherwise.</returns>
		public static bool ClipPolygonWithLine(ref MapWinGIS.Shape polygon, ref MapWinGIS.Shape line, out MapWinGIS.Shapefile resultSF, bool speedOptimized)
		{
            MapWinUtility.Logger.Dbg("ClipPolygonWithLine(polygon: " + Macro.ParamName(polygon) + ",\n" +
                                     "                    line: " + Macro.ParamName(line) + ",\n" +
                                     "                    resultSF: out,\n" +
                                     "                    speedOptimized: " + speedOptimized.ToString() + ")");
			//in-memory form
			Error.ClearErrorLog();
			if(polygon.NumParts > 1)
			{
				return ClipPolyWithLine.ClipMultiPartPolyWithLine(ref polygon, ref line, out resultSF, speedOptimized);
			}
			if(speedOptimized == true)
			{
				return ClipPolyWithLine.Fast_ClipPolygonWithLine(ref polygon, ref line, out resultSF);
			}
			else
			{
				return ClipPolyWithLine.Accurate_ClipPolygonWithLine(ref polygon, ref line, out resultSF);
			}
		}
		#endregion

		#region Difference()
		/// <summary>Returns a new polygon representing the point set difference of poly1 with poly2.</summary>
		/// <param name="poly1">The 2D polygon in need of clipping.</param>
		/// <param name="poly2">The 2D polygon used for clipping poly1.</param>
		/// <returns>Shape containing all points in poly1 that are not in poly2.</returns> 
		public static MapWinGIS.Shape Difference(MapWinGIS.Shape poly1, MapWinGIS.Shape poly2)
		{
            MapWinUtility.Logger.Dbg("Difference(poly1: " + Macro.ParamName(poly1) + ",\n" +
                                     "           poly2: " + Macro.ParamName(poly2) + ")");
			MapWinGIS.Shape resultShp = new MapWinGIS.ShapeClass();
			MapWinGIS.Utils utils = new MapWinGIS.UtilsClass();
			resultShp = utils.ClipPolygon(MapWinGIS.PolygonOperation.DIFFERENCE_OPERATION, poly1, poly2);
			//Fix any orientation errors that may have arisen through GPC call
			if(resultShp.NumParts > 1)
			{
				Globals.FixMultiPartPoly(ref resultShp);
			}
            MapWinUtility.Logger.Dbg("Finished Difference");
			return resultShp;
		}
		#endregion

		#region Union()
		/// <summary>Returns a new polygon representing the point set combination of polygon1 with polygon2.</summary>
		/// <param name="poly1">The 2D polygon in need of clipping.</param>
		/// <param name="poly2">The 2D polygon used for clipping poly1.</param>
		/// <returns>Shape containing all points in poly1 and poly2.</returns> 
		public static MapWinGIS.Shape Union(MapWinGIS.Shape poly1, MapWinGIS.Shape poly2)
		{
            MapWinUtility.Logger.Dbg("Union(poly1: " + Macro.ParamName(poly1) + ",\n" + 
                                     "      poly2: " + Macro.ParamName(poly2) + ")");


            // There were potentially errors pertaining to the clockwise/counter-clockwise state
            // during the union method from utils.ClipPolygon.  This should provide an alternative that
            // should may be slightly slower, but might be more accurate. 
            // code added by Ted Dunsford 2/28/09
      
            IGeometry p1 = NTS_Adapter.ShapeToGeometry(poly1);
            IGeometry p2 = NTS_Adapter.ShapeToGeometry(poly2);
            IGeometry union = p1.Union(p2);
            MapWinGIS.Shape resultShp = NTS_Adapter.GeometryToShape(union);
      
            // This was the old code block that was commented out 2/28/2009 by Ted Dunsford to try the NTS method
            //MapWinGIS.Shape resultShp = new MapWinGIS.ShapeClass();
            //MapWinGIS.Utils utils = new MapWinGIS.UtilsClass();
            //resultShp = utils.ClipPolygon(MapWinGIS.PolygonOperation.UNION_OPERATION, poly1, poly2);
			//Fix any orientation errors that may have arisen through GPC call
            //if(resultShp.NumParts > 1)
            //{
            //    Globals.FixMultiPartPoly(ref resultShp);
            //}


            MapWinUtility.Logger.Dbg("Finished Union");
			return resultShp;

		}
		#endregion

		#region Intersection()
		/// <summary>Returns a new polygon representing the point set intersection of polygon1 with polygon2.</summary>
		/// <param name="poly1">The 2D polygon in need of clipping.</param>
		/// <param name="poly2">The 2D polygon used for clipping poly1.</param>
		/// <returns>Shape containing all points in poly1 that are also in poly2.</returns> 
		public static MapWinGIS.Shape Intersection(MapWinGIS.Shape poly1, MapWinGIS.Shape poly2)
		{
            MapWinUtility.Logger.Dbg("Intersection(poly1: " + Macro.ParamName(poly1) + ",\n" +
                                     "             poly2: " + Macro.ParamName(poly2) + ")");
			MapWinGIS.Shape resultShp = new MapWinGIS.ShapeClass();
			MapWinGIS.Utils utils = new MapWinGIS.UtilsClass();
			resultShp = utils.ClipPolygon(MapWinGIS.PolygonOperation.INTERSECTION_OPERATION, poly1, poly2);
			//Fix any orientation errors that may have arisen through GPC call
			if(resultShp != null && resultShp.NumParts > 1)
			{
				Globals.FixMultiPartPoly(ref resultShp);
			}
            MapWinUtility.Logger.Dbg("Finished Intersection");
			return resultShp;
		}

        /// <summary>
        /// Tests to see if there is an intersection between two polygons
        /// </summary>
        /// <param name="poly1">A MapWinGIS.Shape to test</param>
        /// <param name="poly2">A Second MapWinGIS.Shape to compare the first shape against</param>
        /// <returns>Boolean, true if the polygons intersect</returns>
        public static bool Intersects(MapWinGIS.Shape poly1, MapWinGIS.Shape poly2)
        {
            MapWinUtility.Logger.Dbg("Intersects(poly1: " + Macro.ParamName(poly1) + ",\n" +
                                     "           poly2: " + Macro.ParamName(poly2) + ")");
            MapWinGIS.Shape resultShp = new MapWinGIS.ShapeClass();
            MapWinGIS.Utils utils = new MapWinGIS.UtilsClass();
            resultShp = utils.ClipPolygon(MapWinGIS.PolygonOperation.INTERSECTION_OPERATION, poly1, poly2);
            //If the shape is null, no intersections occured
            if (resultShp != null) return false;
            MapWinUtility.Logger.Dbg("Finished Intersects");
            return true;
        }
		#endregion

		#region SymmetricDifference()
		/// <summary>Returns a new polygon representing the point set exclusive OR of polygon1 with polygon2.</summary>
		/// <param name="poly1">The 2D polygon in need of clipping.</param>
		/// <param name="poly2">The 2D polygon used for clipping poly1.</param>
		/// <returns>Shape containing all points in poly1 and poly2, but not both.</returns> 
		public static MapWinGIS.Shape SymmetricDifference(MapWinGIS.Shape poly1, MapWinGIS.Shape poly2)
		{
            MapWinUtility.Logger.Dbg("SymmetricDifference(poly1: " + Macro.ParamName(poly1) + ",\n" +
                                     "                    poly2: " + Macro.ParamName(poly2) + ")");
			MapWinGIS.Shape resultShp = new MapWinGIS.ShapeClass();
			MapWinGIS.Utils utils = new MapWinGIS.UtilsClass();
            
			resultShp = utils.ClipPolygon(MapWinGIS.PolygonOperation.EXCLUSIVEOR_OPERATION, poly1, poly2);
			//Fix any orientation errors that may have arisen through GPC call
			if(resultShp.NumParts > 1)
			{
				Globals.FixMultiPartPoly(ref resultShp);
			}
            MapWinUtility.Logger.Dbg("Finished SymmetricDifference");
			return resultShp;
		}
		#endregion

		#region MergeShapes()
		/// <summary>
		/// Merges two lines (at matching end points) or two polygons (along common border) to make one result shape.
		/// </summary>
		/// <param name="shp1">First shape.</param>
		/// <param name="shp2">Second shape.</param>
		/// <param name="resultShp">The result of merging shp1 and shp2.</param>
		/// <returns>True if shapes were merged, false otherwise.</returns>
		public static bool MergeShapes(ref MapWinGIS.Shape shp1, ref MapWinGIS.Shape shp2, out MapWinGIS.Shape resultShp)
		{
            MapWinUtility.Logger.Dbg("MergeShapes(shp1: " + Macro.ParamName(shp1) + ",\n" +
                                     "            shp2: " + Macro.ParamName(shp2) + ",\n" +
                                     "            resultShp: out)");
			MapWinGIS.Shapefile tempSF = new MapWinGIS.ShapefileClass();
			string tempPath = System.IO.Path.GetTempPath() + "tempSF.shp";
			DataManagement.DeleteShapefile(ref tempPath);
			//CDM 8/4/2006 tempSF.CreateNew(tempPath, shp1.ShapeType);
            Globals.PrepareResultSF(ref tempPath, ref tempSF, shp1.ShapeType);
			tempSF.StartEditingShapes(true, null);
			int shpIndex = 0;
			tempSF.EditInsertShape(shp1, ref shpIndex);
			shpIndex = 1;
			tempSF.EditInsertShape(shp2, ref shpIndex);
            MapWinUtility.Logger.Dbg("Finished MergeShapes");
			return Merge.MergeShapes(ref tempSF, 0, 1, out resultShp);
		}
		/// <summary>
		/// Merges two shapes within the same shapefile together.
		/// If lines, merging occurs at endpoints. If polygons, union is taken.
		/// </summary>
		/// <param name="sf">The shapefile containing the shapes to be merged.</param>
		/// <param name="indexOne">The index to the first shape.</param>
		/// <param name="indexTwo">The index to the second shape.</param>
		/// <param name="resultShp">The merged result shape.</param>
		/// <returns>True if the shapes were mereged, false otherwise.</returns>
		public static bool MergeShapes(ref MapWinGIS.Shapefile sf, int indexOne, int indexTwo, out MapWinGIS.Shape resultShp)
		{
            MapWinUtility.Logger.Dbg("MergeShapes(sf: " + Macro.ParamName(sf) + ",\n" +
                                     "            indexOne: " + indexOne.ToString() + ",\n" +
                                     "            indexTwo: " + indexTwo.ToString() + ",\n" +
                                     "            resultShp: out)");
			return Merge.MergeShapes(ref sf, indexOne, indexTwo, out resultShp);
		}
		#endregion

		#region BufferShape()
		//Angela Hillier 3/29/06
		/// <summary>
		/// Creates a buffer around the input shape at the distance specified.
		/// </summary>
		/// <param name="shape">The shape to be buffered.</param>
		/// <param name="distance">Distance from shape's border that the buffer should be created.</param>
		/// <param name="resultShp">The resulting buffer shape.</param>
		/// <returns>False if an error was encountered, true otherwise.</returns>
		public static bool BufferShape(ref MapWinGIS.Shape shape, double distance, out MapWinGIS.Shape resultShp)
		{
            MapWinUtility.Logger.Dbg("BufferShape(shape: " + Macro.ParamName(shape) + ",\n" +
                                     "            distance: " + distance.ToString() + ",\n" +
                                     "            resultShp: out)");
			Error.ClearErrorLog();
			MapWinGIS.Shape result = new MapWinGIS.ShapeClass();
			if(shape == null)
			{
				gErrorMsg = "Invalid shape, aborting BufferShape().";
				Error.SetErrorMsg(gErrorMsg);
				Debug.WriteLine(gErrorMsg);
				resultShp = result;
                MapWinUtility.Logger.Dbg(gErrorMsg);
				return false;
			}
			MapWinGIS.ShpfileType sfType = shape.ShapeType;
			if(sfType == MapWinGIS.ShpfileType.SHP_POINT || sfType == MapWinGIS.ShpfileType.SHP_POINTM || sfType == MapWinGIS.ShpfileType.SHP_POINTZ)
			{
				MapWinGIS.Point point = new MapWinGIS.PointClass();
				point = shape.get_Point(0);
				return Buffer.BufferPoint(ref point, distance, 8, out resultShp);
			}
			else if(sfType == MapWinGIS.ShpfileType.SHP_POLYLINE || sfType == MapWinGIS.ShpfileType.SHP_POLYLINEM || sfType == MapWinGIS.ShpfileType.SHP_POLYLINEZ)
			{
				//buffer both sides with rounded caps
				return Buffer.BufferLine(ref shape, distance, Enumerations.Buffer_LineSide.Both, Enumerations.Buffer_CapStyle.Rounded, Enumerations.Buffer_EndCapStyle.Rounded, 8, out resultShp);
			}
			else if(sfType == MapWinGIS.ShpfileType.SHP_POLYGON || sfType == MapWinGIS.ShpfileType.SHP_POLYGONM || sfType == MapWinGIS.ShpfileType.SHP_POLYGONZ)
			{
				//holeTreatment == opposite. If polygon grows, hole shrinks.
				//use rounded caps
				return Buffer.BufferPolygon(ref shape, distance, Enumerations.Buffer_HoleTreatment.Opposite, Enumerations.Buffer_CapStyle.Rounded, 8, out resultShp);
			}
			else
			{
				gErrorMsg = "The shape does not have a recognizable type. Aborting BufferShape().";
				Error.SetErrorMsg(gErrorMsg);
				Debug.WriteLine(gErrorMsg);
				resultShp = result;
                MapWinUtility.Logger.Dbg(gErrorMsg);
				return false;
			}			
		}
		#endregion

		#region BufferSF()
		//Angela Hillier 3/29/06
		/// <summary>
		/// Buffers all shapes in the input shapefile.
		/// </summary>
		/// <param name="inputSFPath">Full path to the input shapefile.</param>
		/// <param name="resultSFPath">Full path to the resulting buffer shapefile.</param>
		/// <param name="distance">Distance from a shape's border at which the corresponding buffer should be created.</param>
		/// <param name="uniteOverlaps">True if overlapping shapes should be combined.</param>
		/// <returns>False if an error occured, true otherwise.</returns>
		public static bool BufferSF(ref string inputSFPath, ref string resultSFPath, double distance, bool uniteOverlaps)
		{
            MapWinUtility.Logger.Dbg("BufferSF(inputSFPath: " + inputSFPath + ",\n" +
                                     "         resultSFPath: " + resultSFPath + ",\n" +
                                     "         distance: " + distance.ToString() + ",\n" +
                                     "         uniteOverlaps: " + uniteOverlaps.ToString());
			Error.ClearErrorLog();
			MapWinGIS.Shapefile inputSF = new MapWinGIS.ShapefileClass();
			inputSF.Open(inputSFPath, null);
			MapWinGIS.ShpfileType sfType = inputSF.ShapefileType;
			inputSF.Close();
			if(sfType == MapWinGIS.ShpfileType.SHP_POINT || sfType == MapWinGIS.ShpfileType.SHP_POINTM || sfType == MapWinGIS.ShpfileType.SHP_POINTZ)
			{
				return Buffer.BufferPointSF(ref inputSFPath, ref resultSFPath, distance, uniteOverlaps, 8);
			}
			else if(sfType == MapWinGIS.ShpfileType.SHP_POLYLINE || sfType == MapWinGIS.ShpfileType.SHP_POLYLINEM || sfType == MapWinGIS.ShpfileType.SHP_POLYLINEZ)
			{
				return Buffer.BufferLineSF(ref inputSFPath, ref resultSFPath, distance, uniteOverlaps, Enumerations.Buffer_LineSide.Both, Enumerations.Buffer_CapStyle.Rounded, Enumerations.Buffer_EndCapStyle.Rounded, 8);
			}
			else if(sfType == MapWinGIS.ShpfileType.SHP_POLYGON || sfType == MapWinGIS.ShpfileType.SHP_POLYGONM || sfType == MapWinGIS.ShpfileType.SHP_POLYGONZ)
			{
				return Buffer.BufferPolygonSF(ref inputSFPath, ref resultSFPath, distance, uniteOverlaps, Enumerations.Buffer_HoleTreatment.Opposite, Enumerations.Buffer_CapStyle.Rounded, 8);
			}
			else
			{
				gErrorMsg = "The input shapefile does not have a recognizable type. Aborting BufferSF().";
				Error.SetErrorMsg(gErrorMsg);
				Debug.WriteLine(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
				return false;
			}
		}
		#endregion

		#region BufferLine()

        //  This function is obsolete and buggy, use BufferSegments instead
        //
		//Angela Hillier 3/29/06
		/// <summary>
		/// Creates a polygon buffer around the line at the distance specified.
		/// </summary>
		/// <param name="line">The line to be buffered.</param>
		/// <param name="distance">The distance from the line that the buffer should be created.
		/// Only positive values are allowed.</param>
		/// <param name="side">The side of the line that should be buffered.</param>
		/// <param name="capStyle">Edge treatment - pointed or rounded caps.</param>
		/// <param name="resultShp">The resulting buffer shape.</param>
		/// <returns>False if an error was encountered, true otherwise.</returns>
		public static bool BufferLine(ref MapWinGIS.Shape line, double distance, Enumerations.Buffer_LineSide side, Enumerations.Buffer_CapStyle capStyle, out MapWinGIS.Shape resultShp)
		{
            MapWinUtility.Logger.Dbg("BufferLine(line: " + Macro.ParamName(line) + ",\n" +
                                     "           side: " + side.ToString() + ",\n" +
                                     "           capStyle: " + capStyle.ToString() + ",\n" +
                                     "           resultShp: out)");
			Error.ClearErrorLog();

			Enumerations.Buffer_EndCapStyle endCapStyle;
			if((int)capStyle == 0)
			{
				endCapStyle = Enumerations.Buffer_EndCapStyle.Pointed;
			}
			else
			{
				endCapStyle = Enumerations.Buffer_EndCapStyle.Rounded;
			}

			MapWinGIS.ShpfileType sfType = new MapWinGIS.ShpfileType();
			sfType = line.ShapeType;
			//line, distance, buffSide (0 = both, 1 = left, 2 = right), capStyle (0 = pointed, 1 = round),
			//endCapStyle(0 = pointed, 1 = round), numQuadrants, shape
			if(sfType == MapWinGIS.ShpfileType.SHP_POLYLINE || sfType == MapWinGIS.ShpfileType.SHP_POLYLINEM || sfType == MapWinGIS.ShpfileType.SHP_POLYLINEZ)
			{
				return Buffer.BufferLine(ref line, distance, side, capStyle, endCapStyle, 8, out resultShp);
			}
			else
			{
				gErrorMsg = "Shape is invalid. Must be of type LINE.";
				Error.SetErrorMsg(gErrorMsg);
				Debug.WriteLine(gErrorMsg);
				MapWinGIS.Shape result = new MapWinGIS.ShapeClass();
				resultShp = result;
                MapWinUtility.Logger.Dbg(gErrorMsg);
				return false;
			}
			
		}
		#endregion

        #region BufferSegments()
        

       
        #endregion

        #region BufferLineSF()
        //Angela Hillier 3/29/06
		/// <summary>
		/// Creates a buffer around each line in the input shapefile.
		/// </summary>
		/// <param name="inputSFPath">Full path to the line shapefile.</param>
		/// <param name="resultSFPath">Full path to the resulting buffer shapefile. </param>
		/// <param name="distance">Distance from line at which buffer shape should be created.</param>
		/// <param name="uniteOverlaps">True if overlapping shapes should be combined.</param>
		/// <param name="side">Specifies which side of the line should be buffered.</param>
		/// <param name="capStyle">Edge treatment (Pointed or Rounded caps);</param>
		/// <returns>False if an error was encountered, true otherwise.</returns>
		public static bool BufferLineSF(ref string inputSFPath, ref string resultSFPath, double distance, bool uniteOverlaps, Enumerations.Buffer_LineSide side, Enumerations.Buffer_CapStyle capStyle)
		{
            MapWinUtility.Logger.Dbg("BufferLineSF(inputSFPath: " + inputSFPath + ",\n" +
                                     "             resultSFPath: " + resultSFPath + ",\n" +
                                     "             distance: " + distance.ToString() + ",\n" +
                                     "             uniteOverlaps: " + uniteOverlaps.ToString() + ",\n" +
                                     "             side: " + side.ToString() + ",\n" +
                                     "             capStyle: " + capStyle.ToString() + ")");
			Error.ClearErrorLog();
			
			Enumerations.Buffer_EndCapStyle endCapStyle;
			if((int)capStyle == 0)
			{
				endCapStyle = Enumerations.Buffer_EndCapStyle.Pointed;
			}
			else
			{
				endCapStyle = Enumerations.Buffer_EndCapStyle.Rounded;
			}
			
			MapWinGIS.Shapefile inputSF = new MapWinGIS.ShapefileClass();
			inputSF.Open(inputSFPath, null);
			MapWinGIS.ShpfileType sfType = inputSF.ShapefileType;
			inputSF.Close();
			if(sfType == MapWinGIS.ShpfileType.SHP_POLYLINE || sfType == MapWinGIS.ShpfileType.SHP_POLYLINEM || sfType == MapWinGIS.ShpfileType.SHP_POLYLINEZ)
			{
				return Buffer.BufferLineSF(ref inputSFPath, ref resultSFPath, distance, uniteOverlaps, side, capStyle, endCapStyle, 8);
			}
			else
			{
				gErrorMsg = "Not a valid type. The input shapefile should be of type LINE.";
				Error.SetErrorMsg(gErrorMsg);
				Debug.WriteLine(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
				return false;
			}
		}
		#endregion

		#region BufferPolygon()
		//Angela Hillier 3/29/06
		/// <summary>
		/// Creates a buffer around (or inside of) the input polygon at the distance specified.
		/// </summary>
		/// <param name="polygon">The polygon shape to be buffered.</param>
		/// <param name="distance">The distance from the polygon's border that the buffer should be created.
		/// Positive or Negative values are allowed.</param>
		/// <param name="holeTreatment">For multiPart polygons with holes, specifies what should be done with holes.
		/// 0 = ignore (no holes will be included in result buffer), 1 = opposite (if distance is positive, hole will shrink),
		/// 2 = same (if distance is positive, hole will grow), 3 = keep original (the hole will not be buffered but will still exist inside of the buffer shape).</param>
		/// <param name="capStyle">Edge treatment. 0 = pointed, 1 = rounded.</param>
		/// <param name="resultShp">The resulting buffer shape.</param>
		/// <returns>False if an error was encountered, true otherwise.</returns>
		public static bool BufferPolygon(ref MapWinGIS.Shape polygon, double distance, Enumerations.Buffer_HoleTreatment holeTreatment, Enumerations.Buffer_CapStyle capStyle, out MapWinGIS.Shape resultShp)
		{
            MapWinUtility.Logger.Dbg("BufferPolygon(polygon: " + Macro.ParamName(polygon) + ",\n" +
                                     "              distance: " + distance.ToString() + ",\n" +
                                     "              holeTreatment: " + holeTreatment.ToString() + ",\n" +
                                     "              capStyle: " + capStyle.ToString() + ",\n" +
                                     "              resultShp: out)");
			Error.ClearErrorLog();

			MapWinGIS.ShpfileType sfType = new MapWinGIS.ShpfileType();
			sfType = polygon.ShapeType;
			if(sfType == MapWinGIS.ShpfileType.SHP_POLYGON || sfType == MapWinGIS.ShpfileType.SHP_POLYGONM || sfType == MapWinGIS.ShpfileType.SHP_POLYGONZ)
			{
				return Buffer.BufferPolygon(ref polygon, distance, holeTreatment, capStyle, 8, out resultShp);
			}
			else
			{
				gErrorMsg = "Shape is invalid. Must be of type POLYGON.";
				Error.SetErrorMsg(gErrorMsg);
				Debug.WriteLine(gErrorMsg);
				MapWinGIS.Shape result = new MapWinGIS.ShapeClass();
				resultShp = result;
                MapWinUtility.Logger.Dbg(gErrorMsg);
				return false;
			}
		}
		#endregion

		#region BufferPolygonSF()
		//Angela Hillier 3/29/06
		/// <summary>
		/// Creates a buffer around each polygon in the input shapefile.
		/// </summary>
		/// <param name="inputSFPath">Full path to the polygon shapefile.</param>
		/// <param name="resultSFPath">Full path to the resulting buffer shapefile.</param>
		/// <param name="distance">Distance from polygon border at which the corresponding buffer should be created.</param>
		/// <param name="uniteOverlaps">True if overlapping buffers should be combined.</param>
		/// <param name="holeTreatment">For multiPart polygons with holes, specifies what should be done with holes.
		/// Ignore (no holes will be included in result buffer), Opposite (if distance is positive, hole will shrink),
		/// Same (if distance is positive, hole will grow), Original (the hole will not be buffered but will still exist inside of the buffer shape).</param>
		/// <param name="capStyle">Edge treatment (Pointed or Rounded caps).</param>
		/// <returns>False if an error was encountered, true otherwise.</returns>
		public static bool BufferPolygonSF(ref string inputSFPath, ref string resultSFPath, double distance, bool uniteOverlaps, Enumerations.Buffer_HoleTreatment holeTreatment, Enumerations.Buffer_CapStyle capStyle)
		{
            MapWinUtility.Logger.Dbg("BufferPolygonSF(inputSFPath: " + inputSFPath + ",\n" +
                                     "                resultsSFPath: " + resultSFPath + ",\n" +
                                     "                distance: " + distance.ToString() + ",\n" +
                                     "                uniteOverlaps: " + uniteOverlaps.ToString() + ",\n" +
                                     "                holeTreatment: " + holeTreatment.ToString() + ",\n" +
                                     "                capStyle: " + capStyle.ToString() + ")");
			Error.ClearErrorLog();

			MapWinGIS.Shapefile inputSF = new MapWinGIS.ShapefileClass();
			inputSF.Open(inputSFPath, null);
			MapWinGIS.ShpfileType sfType = inputSF.ShapefileType;
			inputSF.Close();
			if(sfType == MapWinGIS.ShpfileType.SHP_POLYGON || sfType == MapWinGIS.ShpfileType.SHP_POLYGONM || sfType == MapWinGIS.ShpfileType.SHP_POLYGONZ)
			{
				return Buffer.BufferPolygonSF(ref inputSFPath, ref resultSFPath, distance, uniteOverlaps, holeTreatment, capStyle, 8);
			}
			else
			{
				gErrorMsg = "Not a valid type. The input shapefile should be of type POLYGON.";
				Error.SetErrorMsg(gErrorMsg);
				Debug.WriteLine(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
				return false;
			}
		}
		#endregion

		#region Erase()
		/// <summary>
		/// Removes portions of the input shapefile that fall within the polygon's border.
		/// </summary>
		/// <param name="inputSFPath">The full path to the input shapefile.</param>
		/// <param name="polygon">The overlay polygon.</param>
		/// <param name="resultSFPath">The full path to the resulting shapefile.</param>
        /// <returns>False if an error was encountered, true otherwise.</returns>
        public static bool Erase(ref string inputSFPath, ref MapWinGIS.Shape polygon, ref string resultSFPath)
        {
            MapWinUtility.Logger.Dbg("Erase(inputSFPath: " + inputSFPath + ",\n" +
                                     "      polygon: " + Macro.ParamName(polygon) + ",\n" +
                                     "      resultSFPath: " + resultSFPath + ")");
            return Erase(ref inputSFPath, ref polygon, ref resultSFPath, false, false);
        }
       
        /// <summary>
        /// Removes portions of the input shapefile that fall within the polygon's border.
        /// </summary>
        /// <param name="inputSFPath">The full path to the input shapefile.</param>
        /// <param name="polygon">The overlay polygon.</param>
        /// <param name="resultSFPath">The full path to the resulting shapefile.</param>
        /// <param name="SkipMWShapeID">Indicates whether to skip creating an MWShapeID field in the result.</param>
        /// <returns>False if an error was encountered, true otherwise.</returns>
        /// 
        public static bool Erase(ref string inputSFPath, ref MapWinGIS.Shape polygon, ref string resultSFPath, bool SkipMWShapeID)
        {
            MapWinUtility.Logger.Dbg("Erase(inputSFPath: " + inputSFPath + ",\n" +
                                        "      polygon: " + Macro.ParamName(polygon) + ",\n" +
                                        "      resultSFPath: " + resultSFPath + ",\n" +
                                        "      SkipMWShapeID: " + SkipMWShapeID.ToString() + ")");

            return Erase(ref inputSFPath, ref polygon, ref resultSFPath, SkipMWShapeID, false);
        }

        /// <summary>
        /// Removes portions of the input shapefile that fall within the polygon's border.
        /// </summary>
        /// <param name="inputSFPath">The full path to the input shapefile.</param>
        /// <param name="polygon">The overlay polygon.</param>
        /// <param name="resultSFPath">The full path to the resulting shapefile.</param>
        /// <param name="SkipMWShapeID">Indicates whether to skip creating an MWShapeID field in the result.</param>
        /// <param name="CopyAttributes">Indicates whether to copy attributes or not.</param>
        /// <returns>False if an error was encountered, true otherwise.</returns>
        /// 
        public static bool Erase(ref string inputSFPath, ref MapWinGIS.Shape polygon, ref string resultSFPath, bool SkipMWShapeID, bool CopyAttributes)
        {
            MapWinUtility.Logger.Dbg("Erase(intputSFPath: " + inputSFPath + ",\n" +
                                     "      polygon: " + Macro.ParamName(polygon) + ",\n" +
                                     "      resultSFPath: " + resultSFPath + ",\n" +
                                     "      SkipWMShapeID: " + SkipMWShapeID.ToString() + ",\n" +
                                     "      CopyAttributes: " + CopyAttributes.ToString() + ")");
            Error.ClearErrorLog();
            bool status = false;

            if (CopyAttributes)
            {   //we want to skip the MWShapeID and assume there will be one on the input shapefile
                SkipMWShapeID = true;
            }

            MapWinGIS.Shapefile inputSF = new MapWinGIS.ShapefileClass();
            inputSF.Open(inputSFPath, null);
            if (inputSF.NumShapes > 0 && polygon.numPoints > 0)
            {
                MapWinGIS.ShpfileType sfType = new MapWinGIS.ShpfileType();
                sfType = inputSF.ShapefileType;
                MapWinGIS.Shapefile resultSF = new MapWinGIS.ShapefileClass();
                //create the result shapefile if it does not already exist
                if (Globals.PrepareResultSF(ref resultSFPath, ref resultSF, sfType, true) == false)
                {
                    return false;
                }

                if (sfType == MapWinGIS.ShpfileType.SHP_POLYGON || sfType == MapWinGIS.ShpfileType.SHP_POLYGONM || sfType == MapWinGIS.ShpfileType.SHP_POLYGONZ)
                {
                    status = MapWinGeoProc.Erase.ErasePolySFWithPoly(ref inputSF, ref polygon, ref resultSF, CopyAttributes);
                }
                else if (sfType == MapWinGIS.ShpfileType.SHP_POINT || sfType == MapWinGIS.ShpfileType.SHP_POINTM || sfType == MapWinGIS.ShpfileType.SHP_POINTZ)
                {
                    status = MapWinGeoProc.Erase.ErasePointSFWithPoly(ref inputSF, ref polygon, ref resultSF, CopyAttributes);
                }
                else if (sfType == MapWinGIS.ShpfileType.SHP_POLYLINE || sfType == MapWinGIS.ShpfileType.SHP_POLYLINEM || sfType == MapWinGIS.ShpfileType.SHP_POLYLINEZ)
                {
                    status = MapWinGeoProc.Erase.EraseLineSFWithPoly(ref inputSF, ref polygon, ref resultSF, CopyAttributes);
                }
                else
                {
                    status = false;
                    gErrorMsg = "The shapefile type is invalid.";
                    Error.SetErrorMsg(gErrorMsg);
                    Debug.WriteLine(gErrorMsg);
                    MapWinUtility.Logger.Dbg(gErrorMsg);
                }
                if (status == true && !SkipMWShapeID)
                {
                    //insert shape ID's into the result table
                    Globals.DoInsertIDs(ref resultSF);
                }
                resultSF.StopEditingShapes(true, true, null);
                resultSF.Close();
            }
            else
            {
                gErrorMsg = "Either the inputSF or the polygon shape is invalid.";
                Error.SetErrorMsg(gErrorMsg);
                Debug.WriteLine(gErrorMsg);
                status = false;
                MapWinUtility.Logger.Dbg(gErrorMsg);
            }
            inputSF.Close();
            MapWinUtility.Logger.Dbg("Finished Erase");
            return status;
        }
        
        /// <summary>
		/// Removes portions of the input shapefile that fall within the erase polygons.
		/// </summary>
		/// <param name="inputSFPath">Full path to input shapefile.</param>
		/// <param name="polySFPath">Full path to the erase polygon shapefile.</param>
		/// <param name="resultSFPath">Full path to where the result shapefile should be saved.</param>
        /// <returns>Fals if an error was encountered, true otherwise.</returns>
        public static bool Erase(ref string inputSFPath, ref string polySFPath, ref string resultSFPath)
        {
            MapWinUtility.Logger.Dbg("Erase(inputSFPath: " + inputSFPath + ",\n" +
                                     "      polySFPath: " + polySFPath + ",\n" +
                                     "      resultSFPath: " + resultSFPath + ")");
            return Erase(ref inputSFPath, ref polySFPath, ref resultSFPath, false);
        }
		/// <summary>
		/// Removes portions of the input shapefile that fall within the erase polygons.
		/// </summary>
		/// <param name="inputSFPath">Full path to input shapefile.</param>
		/// <param name="polySFPath">Full path to the erase polygon shapefile.</param>
		/// <param name="resultSFPath">Full path to where the result shapefile should be saved.</param>
        /// <param name="SkipMWShapeID">Indicates whether to skip creating an MWShapeID field in the result.</param>
		/// <returns>Fals if an error was encountered, true otherwise.</returns>
		public static bool Erase(ref string inputSFPath, ref string polySFPath, ref string resultSFPath, bool SkipMWShapeID)
		{
            MapWinUtility.Logger.Dbg("Erase(inputSFPath: " + inputSFPath + ",\n" +
                                     "      polySFPath: " + polySFPath + ",\n" +
                                     "      resultSFPath: " + resultSFPath + ",\n" +
                                     "      SkipMWShapeID: " + SkipMWShapeID.ToString() + ")");
			Error.ClearErrorLog();
			bool status = false;
			MapWinGIS.Shapefile inputSF = new MapWinGIS.ShapefileClass();
			inputSF.Open(inputSFPath, null);
			MapWinGIS.Shapefile polySF = new MapWinGIS.ShapefileClass();
			polySF.Open(polySFPath, null);

			if(inputSF.NumShapes > 0 && polySF.NumShapes > 0)
			{
				MapWinGIS.ShpfileType sfType = new MapWinGIS.ShpfileType();
				sfType = inputSF.ShapefileType;
				MapWinGIS.Shapefile resultSF = new MapWinGIS.ShapefileClass();
				//create the result shapefile if it does not already exist
				if(Globals.PrepareResultSF(ref resultSFPath, ref resultSF, sfType,true)== false)
				{
					return false;
				}

				if(sfType == MapWinGIS.ShpfileType.SHP_POLYGON || sfType == MapWinGIS.ShpfileType.SHP_POLYGONM || sfType == MapWinGIS.ShpfileType.SHP_POLYGONZ)
				{
					status = MapWinGeoProc.Erase.ErasePolySFWithPolySF(ref inputSF, ref polySF, ref resultSF);			
				}
				else if(sfType == MapWinGIS.ShpfileType.SHP_POINT || sfType == MapWinGIS.ShpfileType.SHP_POINTM || sfType == MapWinGIS.ShpfileType.SHP_POINTZ)
				{
					status = MapWinGeoProc.Erase.ErasePointSFWithPolySF(ref inputSF, ref polySF, ref resultSF);
				}
				else if(sfType == MapWinGIS.ShpfileType.SHP_POLYLINE || sfType == MapWinGIS.ShpfileType.SHP_POLYLINEM || sfType == MapWinGIS.ShpfileType.SHP_POLYLINEZ)
				{
					status = MapWinGeoProc.Erase.EraseLineSFWithPolySF(ref inputSF, ref polySF, ref resultSF);
				}
				else
				{
					status = false;
					gErrorMsg = "The shapefile type is invalid.";
					Error.SetErrorMsg(gErrorMsg);
					Debug.WriteLine(gErrorMsg);
                    MapWinUtility.Logger.Dbg(gErrorMsg);
				}
                if (status == true && !SkipMWShapeID)
				{
					//insert shape ID's into the result table
					Globals.DoInsertIDs(ref resultSF);
				}
				resultSF.StopEditingShapes(true, true, null);
				resultSF.Close();
			}
			else
			{
				gErrorMsg = "Either the inputSF or the polygon shape is invalid.";
				Error.SetErrorMsg(gErrorMsg);
				Debug.WriteLine(gErrorMsg);
				status = false;
                MapWinUtility.Logger.Dbg(gErrorMsg);
			}
			inputSF.Close();
			polySF.Close();
			return status;
		}
		#endregion

        #region Identity
        /// <summary>
        /// Computes a geometric intersection of the input shapes and the indentity shapes.
        /// The input shapes, or portions thereof that overlap the identity shapes, will get
        /// the attributes of those identity shapes.
        /// </summary>
        /// <param name="inputSFPath">The full path to the input shapefile.</param>
        /// <param name="identitySFPath">The full path to the identity shapefile.</param>
        /// <param name="resultSFPath">The full path to the result shapefile.</param>
        /// <returns>False if an error was encountered, true otherwise.</returns>
        public static bool Identity(ref string inputSFPath, ref string identitySFPath, ref string resultSFPath)
        {
            MapWinGIS.Shapefile inputSF = new MapWinGIS.ShapefileClass();
            inputSF.Open(inputSFPath, null);
            MapWinGIS.ShpfileType inputSFType = inputSF.ShapefileType;

            MapWinGIS.Shapefile identitySF = new MapWinGIS.ShapefileClass();
            identitySF.Open(identitySFPath, null);

            MapWinGIS.Shapefile resultSF = new MapWinGIS.ShapefileClass();
            resultSF.CreateNew(resultSFPath, inputSFType);
            resultSF.Projection = inputSF.Projection;

            bool status = MapWinGeoProc.Selection.ExportShapesWithPolygons(ref inputSF, ref identitySF, ref resultSF);

            inputSF.Close();
            identitySF.Close();
            resultSF.StopEditingShapes(true, true, null);
            resultSF.Close();
            return status;
        }

        #region DeleteShapeFile()
        //this function is used to delete temporary shapefiles that were
        //saved to disk. There are three files for every one shapefile, so
        //all three must be deleted.
        private void DeleteShapeFile(string shapeFilePath)
        {
            System.IO.File.Delete(shapeFilePath + ".shp");
            System.IO.File.Delete(shapeFilePath + ".dbf");
            System.IO.File.Delete(shapeFilePath + ".shx");
        }
        #endregion

        #endregion Identity


        #region GetShapeNearestToPoint
        /// <summary>
        /// Function which will output the index and distance to the nearest shape in the provided shapefile to the provided point. -1 will be returned if nothing is found
        /// </summary>
        /// <param name="InputSF"></param>
        /// <param name="InputPoint"></param>
        /// <param name="OutIndex"></param>
        /// <param name="OutDistance"></param>
        public static void GetShapeNearestToPoint(ref MapWinGIS.Shapefile InputSF, ref MapWinGIS.Point InputPoint, out int OutIndex, out double OutDistance)
        {
            MapWinGIS.Extents lim = InputSF.Extents;
            object retShapes = null;
            InputSF.SelectShapes(lim, 0.0, MapWinGIS.SelectMode.INTERSECTION, ref retShapes);
            int[] shapes = (int[])retShapes;
            doGetShapeNearestToPoint(ref InputSF, ref InputPoint, ref shapes,out OutIndex, out OutDistance);
        }

        /// <summary>
        /// Function which will output the index and distance to the nearest shape in the provided shapefile to the provided point, limited by the extents box inputted such that any values outside of it will not be included. -1 will be returned if nothing is found
        /// </summary>
        /// <param name="InputSF"></param>
        /// <param name="InputPoint"></param>
        /// <param name="LimitBox"></param>
        /// <param name="OutIndex"></param>
        /// <param name="OutDistance"></param>
        public static void GetShapeNearestToPoint(ref MapWinGIS.Shapefile InputSF, ref MapWinGIS.Point InputPoint, ref MapWinGIS.Extents LimitBox, out int OutIndex, out double OutDistance)
        {
            object retShapes = null;
            InputSF.SelectShapes(LimitBox, 0.0, MapWinGIS.SelectMode.INTERSECTION, ref retShapes);
            int[] shapes = (int[])retShapes;
            doGetShapeNearestToPoint(ref InputSF, ref InputPoint, ref shapes,out OutIndex, out OutDistance);
        }
        
        /// <summary>
        /// Function which will output the index and distance to the nearest shape in the provided shapefile to the provided point, limited by an extents generated by the size inputted such that any values outside of it will not be included. -1 will be returned if nothing is found
        /// </summary>
        /// <param name="InputSF"></param>
        /// <param name="InputPoint"></param>
        /// <param name="ExtentSize"></param>
        /// <param name="OutIndex"></param>
        /// <param name="OutDistance"></param>
        public static void GetShapeNearestToPoint(ref MapWinGIS.Shapefile InputSF, ref MapWinGIS.Point InputPoint, double ExtentSize, out int OutIndex, out double OutDistance)
        {
            MapWinGIS.Extents ext = new MapWinGIS.Extents();
            ext.SetBounds(InputPoint.x, InputPoint.y, 0, InputPoint.x, InputPoint.y, 0);
            object retShapes = null;
            InputSF.SelectShapes(ext, ExtentSize*2, MapWinGIS.SelectMode.INTERSECTION, ref retShapes);
            int[] shapes = (int[])retShapes;

            doGetShapeNearestToPoint(ref InputSF, ref InputPoint, ref shapes, out OutIndex, out OutDistance);
        }

        /// <summary>
        /// Function which will output the index and distance to the nearest shape in the provided shapefile to the provided point, limited by index list inputted such that any values outside of it will not be included. -1 will be returned if nothing is found
        /// </summary>
        /// <param name="InputSF"></param>
        /// <param name="InputPoint"></param>
        /// <param name="IndexList"></param>
        /// <param name="OutIndex"></param>
        /// <param name="OutDistance"></param>
        public static void GetShapeNearestToPoint(ref MapWinGIS.Shapefile InputSF, ref MapWinGIS.Point InputPoint, ref int[] IndexList, out int OutIndex, out double OutDistance)
        {
            doGetShapeNearestToPoint(ref InputSF, ref InputPoint, ref IndexList, out OutIndex, out OutDistance);
        }

        private static void doGetShapeNearestToPoint(ref MapWinGIS.Shapefile InputSF, ref MapWinGIS.Point InputPoint, ref int[] IndexList, out int OutIndex, out double OutDistance)
        {
            MapWinGIS.Shape tmpShape;
            int minIndex = -1;
            double tmpDist;
            double minDist = 10000000.0;
            string proj = InputSF.Projection;
            string units;
            if (proj != null)
            {
                units = proj.Substring(proj.IndexOf("units=") + 6);
                units = units.Substring(0, units.IndexOf("+")).Trim();
            }
            else
            {
                double tmpX = InputSF.Extents.xMax;
                string tmpstr = Math.Floor(tmpX).ToString();
               
                if (tmpstr.Length > 4)
                {
                    units = "";
                }
                else
                {
                    units = "lat/long";
                }
            }

            for (int i = 0; i < IndexList.Length; i++)
            {
                tmpShape = InputSF.get_Shape(IndexList[i]);
                for (int j = 0; j < tmpShape.numPoints; j++)
                {
                    tmpDist = Distance(InputPoint.x, InputPoint.y, tmpShape.get_Point(j).x, tmpShape.get_Point(j).y, units);
                    if (tmpDist < minDist)
                    {
                        minIndex = IndexList[i];
                        minDist = tmpDist;
                    }
                }
            }

            OutIndex = minIndex;
            OutDistance = minDist;
        }

        /// <summary>
        /// Gives the distance between two projected points
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="Units"></param>
        /// <returns></returns>
        public static double Distance(double x1, double y1, double x2, double y2, string Units)
        {
            if ((Units.ToLower().Trim() == "lat/long"))
            {
                return LLDistance(y1, x1, y2, x2);
            }
            else
            {
                return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            }
        }

        /// <summary>
        /// Gives the distance between two lat/long points
        /// </summary>
        /// <param name="Lat1"></param>
        /// <param name="Long1"></param>
        /// <param name="Lat2"></param>
        /// <param name="Long2"></param>
        /// <returns></returns>
        public static double LLDistance(double Lat1, double Long1, double Lat2, double Long2)
        {
            double DegToRadians = (2 * Math.PI) / 360;
            double RadiusEarth = 3963; //in miles

            double result = RadiusEarth * Math.Acos(Math.Sin(Lat1 * DegToRadians)
                * Math.Sin(Lat2 * DegToRadians)
                + Math.Cos(Lat1 * DegToRadians)
                * Math.Cos(Lat2 * DegToRadians)
                * Math.Cos(Long2 * DegToRadians - Long1 * DegToRadians));
            result = result * 1609.344;
            return result;
        }
        #endregion

        #region Spatial Join
        /// <summary>
        /// A spatial join function which will append the attributes of the Join shapefile to the attributes of the Target shapefile according to a Join type (Only nearest supported so far).
        /// </summary>
        /// <param name="TargetSFPath"></param>
        /// <param name="JoinSFPath"></param>
        /// <param name="OutputSFPath"></param>
        /// <param name="JoinType"></param>
        public static void SpatialJoin(string TargetSFPath, string JoinSFPath, string OutputSFPath, SpatialJoinTypes JoinType)
        {
            doSpatialJoinPreProc(TargetSFPath, JoinSFPath, OutputSFPath, JoinType, -1);            
        }

        /// <summary>
        /// A spatial join function which will append the attributes of the Join shapefile to the attributes of the Target shapefile according to a Join type (Only nearest supported so far). The nearest operation will be limited by the search radius provided.
        /// </summary>
        /// <param name="TargetSFPath"></param>
        /// <param name="JoinSFPath"></param>
        /// <param name="OutputSFPath"></param>
        /// <param name="JoinType"></param>
        /// <param name="SearchRadius"></param>
        public static void SpatialJoin(string TargetSFPath, string JoinSFPath, string OutputSFPath, SpatialJoinTypes JoinType, double SearchRadius)
        {
            doSpatialJoinPreProc(TargetSFPath, JoinSFPath, OutputSFPath, JoinType, SearchRadius);
        }

        private static void doSpatialJoinPreProc(string TargetSFPath, string JoinSFPath, string OutputSFPath, SpatialJoinTypes JoinType, double SearchRadius)
        {
            MapWinGIS.Shapefile JoinSF = new MapWinGIS.Shapefile();
            MapWinGIS.Shapefile OutputSF = new MapWinGIS.Shapefile();
            if (File.Exists(OutputSFPath))
            {
                DataManagement.DeleteShapefile(ref OutputSFPath);
            }
            OutputSF.Open(TargetSFPath, null);
            OutputSF.SaveAs(OutputSFPath, null);
            JoinSF.Open(JoinSFPath, null);

            if (JoinType == SpatialJoinTypes.Nearest)
            {
                doSpatialJoinNearest(ref JoinSF, ref OutputSF, JoinType, SearchRadius);
            }

            JoinSF.Close();
            OutputSF.Close();
        }

        private static void doSpatialJoinNearest(ref MapWinGIS.Shapefile JoinSF, ref MapWinGIS.Shapefile OutputSF, SpatialJoinTypes JoinType, double SearchRadius)
        {
            MapWinGIS.Shape baseShape;
            MapWinGIS.Point basePoint; 
            int newFieldIdxStart = OutputSF.NumFields;
            int fieldIdx;
            int outIndex;
            double outDist;
            
            OutputSF.StartEditingShapes(true, null);

            for (int i = 0; i < JoinSF.NumFields; i++)
            {
                MapWinGIS.Field newField = new MapWinGIS.Field();
                MapWinGIS.Field currField = JoinSF.get_Field(i);
                if ((currField.Name == "ID") || (currField.Name == "MWShapeID"))
                {
                    newField.Name = currField.Name + "1";
                }
                else
                {
                    newField.Name = currField.Name;
                }
                newField.Type = currField.Type;
                newField.Precision = currField.Precision;
                newField.Width = currField.Width;
                fieldIdx = OutputSF.NumFields;
                OutputSF.EditInsertField(newField, ref fieldIdx, null);
            }

            for (int i = 0; i < OutputSF.NumShapes; i++)
            {
                baseShape = OutputSF.get_Shape(i);
                basePoint = new MapWinGIS.Point();
                basePoint.x = baseShape.get_Point(0).x;
                basePoint.y = baseShape.get_Point(0).y;

                for (int j = 0; j < JoinSF.NumShapes; j++)
                {
                    if (SearchRadius != -1.0)
                    {
                        GetShapeNearestToPoint(ref JoinSF, ref basePoint, SearchRadius, out outIndex, out outDist);
                    }
                    else
                    {
                        GetShapeNearestToPoint(ref JoinSF, ref basePoint, out outIndex, out outDist);
                    }
                    if (outIndex != -1)
                    {
                        for (int z = 0; z < JoinSF.NumFields; z++)
                        {
                            OutputSF.EditCellValue(newFieldIdxStart + z, i, JoinSF.get_CellValue(z, outIndex));
                        }
                    }
                }
            }
            OutputSF.StopEditingShapes(true, true, null);
        }
        
        #endregion



        #region Functions Not Implemented

        /// <summary>
		/// Not Implemented
		/// Computes the convex hull of a polygon. 
		/// The convex hull is the smallest convex polygon that contains all the points in the input polgyon. 
		/// Uses the Graham Scan algorithm. 
		/// </summary>
		/// <param name="polygon">The input polygon shape.</param>
		/// <param name="resultShp">The resulting convex hull of the input polygon.</param>
		/// <returns>False if an error was encountered, true otherwise.</returns>
		public static bool ConvexHull(ref MapWinGIS.Shape polygon, ref MapWinGIS.Shape resultShp)
		{
			//TODO: Implement this function
			Error.ClearErrorLog();
			gErrorMsg = "This function is not yet implemented.";
			Error.SetErrorMsg(gErrorMsg);
			Debug.WriteLine(gErrorMsg);

			return false;
		}

		/// <summary>
		/// Selects all shapes in the input shapefile based on a field value.
		/// </summary>
		/// <param name="inputSFPath">The full path to the input shapefile.</param>
		/// <param name="fieldID">The table ID of the field used for selection.</param>
		/// <param name="testValLoc">The location of a value used for comparison purposes.</param>
		/// <param name="compType">The type of comparison to be performed (==, >=, !=, etc)</param>
		/// <param name="resultSFPath">The full path to the result shapefile.</param>
		/// <returns>False if an error was encountered, true otherwise.</returns>
		public static bool SelectByAttribute(ref string inputSFPath, int fieldID, int testValLoc, int compType, ref string resultSFPath)
		{
			//TODO: Implement this function
			Error.ClearErrorLog();
			gErrorMsg = "This function is not yet implemented.";
			Error.SetErrorMsg(gErrorMsg);
			Debug.WriteLine(gErrorMsg);

			return false;
		}

		#endregion

	}
}
