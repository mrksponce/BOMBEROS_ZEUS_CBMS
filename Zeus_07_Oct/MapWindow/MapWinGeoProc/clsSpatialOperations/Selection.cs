//********************************************************************************************************
//File name: Selection.cs
//Description: Internal class, provides methods for selecting lines/points/polygons that intersect with any given polygon.
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
//12-6-05 ah - Angela Hillier - added selection methods 							
//7-04-07 sb - Simon Batson - added ExportShapesWithPolygons to perform Identity processing.
//********************************************************************************************************
using System;
using System.Diagnostics;
using System.Collections;
using MapWinGeoProc.NTS.Topology;
using MapWinGeoProc.NTS.Topology.Geometries;
using MapWinGeoProc.NTS.Topology.Index;
using MapWindow.Interfaces.Geometries;
namespace MapWinGeoProc
{
	/// <summary>
	/// Provides functions for selecting lines/points/polygons from
	/// a shapefile that intersect with any given polygon.
	/// </summary>
	public class Selection
	{
		private static string gErrorMsg = "";

        #region ExportSelectedShapes
        // Chris Michaelis August 15 2006
        /// <summary>
        /// Exports the shapes that are selected in the MapWindow view to a new shapefile.
        /// </summary>
        /// <param name="MapWin">A reference to the running MapWindow.</param>
        /// <param name="ExportToSFPath">The full path to where the result shapefile should be saved.</param>
        /// <returns>False if an error occurs, true otherwise.</returns>
        public static bool ExportSelectedMWViewShapes(MapWindow.Interfaces.IMapWin MapWin, string ExportToSFPath)
        {
            return ExportSelectedMWViewShapes(MapWin, ExportToSFPath, false);
        }
        /// <summary>
        /// Exports the shapes that are selected in the MapWindow view to a new shapefile.
        /// </summary>
        /// <param name="MapWin">A reference to the running MapWindow.</param>
        /// <param name="ExportToSFPath">The full path to where the result shapefile should be saved.</param>
        /// <param name="AddToMap">Indicates that the output should be added to the map view immediately.</param>
        /// <returns>False if an error occurs, true otherwise.</returns>
        public static bool ExportSelectedMWViewShapes(MapWindow.Interfaces.IMapWin MapWin, string ExportToSFPath, bool AddToMap)
        {
            MapWinUtility.Logger.Dbg("ExportSelectedMWViewShapes(MapWin: IMapWin,\n" +
                                     "                           ExportToSFPath: " + ExportToSFPath + ",\n" +
                                     "                           AddToMap: " + AddToMap.ToString() + ")");

            if (MapWin.Layers.NumLayers == 0)
            {
                gErrorMsg = "Please select a layer first.";
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                return false;
            }
            if (MapWin.View.SelectedShapes.NumSelected == 0)
            {
                gErrorMsg = "There are no selected features to export. Please select a feature first.";
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                return false;
            }
            MapWinGIS.Shapefile sf = new MapWinGIS.Shapefile();
            MapWinGIS.Shapefile tollSF = new MapWinGIS.Shapefile();
            MapWinGIS.Field fld = new MapWinGIS.Field();
            MapWinGIS.Shape seg = new MapWinGIS.Shape();
            int Segments;
            bool Status;
            Status = sf.Open(MapWin.Layers[MapWin.Layers.CurrentLayer].FileName, null);
            if (Status == false)
            {
                gErrorMsg = sf.get_ErrorMsg(sf.LastErrorCode);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                return false;
            }

            if (System.IO.File.Exists(ExportToSFPath))
            {
                try
                {
                    DataManagement.DeleteShapefile(ref ExportToSFPath);
                }
                catch
                {
                    gErrorMsg = "The destination file already exists, but could not be deleted. Please check to make sure the file isn't in use.";
                    Error.SetErrorMsg(gErrorMsg);
                    MapWinUtility.Logger.Dbg(gErrorMsg);
                    return false;
                }
            }

            Status = tollSF.CreateNew(ExportToSFPath, sf.ShapefileType);

            if (Status == false)
            {
                gErrorMsg = tollSF.get_ErrorMsg(tollSF.LastErrorCode);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                return false;
            }

            try
            {
                tollSF.Projection = sf.Projection;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }

            Status = tollSF.StartEditingShapes(true, null);
            if (Status == false)
            {
                gErrorMsg = tollSF.get_ErrorMsg(tollSF.LastErrorCode);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                return false;
            }
            fld.Name = "MWShapeID";
            fld.Type = MapWinGIS.FieldType.INTEGER_FIELD;
            fld.Width = 12;
            Segments = 0;
            
            // Chris M -- This is already opened above, why open
            // it again here?
            // sf.Open(MapWin.Layers[MapWin.Layers.CurrentLayer].FileName, null);

            for (int j = 0; j <= sf.NumFields - 1; j++)
            {
                tollSF.EditInsertField(sf.get_Field(j), ref j, null);
            }
            MapWin.View.MapCursor = MapWinGIS.tkCursor.crsrWait;
            try
            {
                for (int i = 0; i <= MapWin.View.SelectedShapes.NumSelected - 1; i++)
                {
                    seg = sf.get_Shape(MapWin.View.SelectedShapes[i].ShapeIndex);
                    Status = tollSF.EditInsertShape(seg, ref Segments);
                    if (Status == false)
                    {
                        gErrorMsg = tollSF.get_ErrorMsg(tollSF.LastErrorCode);
                        Error.SetErrorMsg(gErrorMsg);
                        MapWinUtility.Logger.Dbg(gErrorMsg);
                        return false;
                    }
                    for (int h = 0; h <= sf.NumFields - 1; h++)
                    {
                        tollSF.EditCellValue(h, i, sf.get_CellValue(h, MapWin.View.SelectedShapes[i].ShapeIndex));
                    }
                    Segments = Segments + 1;
                }
                sf.Close();
                tollSF.StopEditingShapes(true, true, null);
            }
            catch (Exception ex)
            {
                gErrorMsg = ex.Message;
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
            }
            MapWin.View.MapCursor = MapWinGIS.tkCursor.crsrArrow;
            tollSF.Close();
            if (AddToMap)
            {
                MapWin.View.LockMap();
                MapWindow.Interfaces.Layer thelayer;
                thelayer = MapWin.Layers.Add(ExportToSFPath, System.IO.Path.GetFileNameWithoutExtension(ExportToSFPath), true);
                thelayer.ClearLabels();
                MapWin.View.UnlockMap();
            }
            MapWinUtility.Logger.Dbg("Finished ExportSelectedMWViewShapes");
            return true;
        }

        /// <summary>
        /// This is used by the Identity process to export all shapes intesecting all polygons passed in.
        /// Each identity polygon is used to select and clip input shapes. The new clipped shape is written
        /// to the result shapefile. The attribute fields from both input and identity shapefiles are copied
        /// to the result shapefile.
        /// This process uses a QuadTree index to speed up the selection of overlapping geometries.
        /// </summary>
        /// <param name="inputSF">The shapefile, of any geometry type, to be clipped and exported.</param>
        /// <param name="identitySF">The polygon shapefile used to clip the inputSF.</param>
        /// <param name="resultSF">The result shapefile that will contain the results.</param>
        /// <returns>False if an error occurs, true otherwise.</returns>
        public static bool ExportShapesWithPolygons(ref MapWinGIS.Shapefile inputSF, ref MapWinGIS.Shapefile identitySF, ref MapWinGIS.Shapefile resultSF)
        {
            try
            {
                // Boundary intersection test variables
                double xMin1, xMax1, yMin1, yMax1, zMin1, zMax1, xMin2, xMax2, yMin2, yMax2, zMin2, zMax2;

                // Build Quadtree index for inputSF
                MapWinGeoProc.NTS.Topology.Index.Quadtree.Quadtree myQuadTree = new MapWinGeoProc.NTS.Topology.Index.Quadtree.Quadtree();

                MapWinGIS.Shape currGeom;
                for (int i = 0; i < inputSF.NumShapes; i++)
                {
                    currGeom = inputSF.get_Shape(i);
                    currGeom.Extents.GetBounds(out xMin1, out yMin1, out zMin1, out xMax1, out yMax1, out zMax1);
                    Envelope myItemEnv = new Envelope(xMin1, xMax1, yMin1, yMax1);
                    myQuadTree.Insert(myItemEnv, i);

                }//end of looping through lines

                // Copy inputSf and identitySF fields to resultSF, renaming duplicate fields
                if (Globals.CopyFields(ref inputSF, ref resultSF) == false)
                {
                    return false;
                }
                if (Globals.CopyFields(ref identitySF, ref resultSF, true) == false)
                {
                    return false;
                }

                int resultNumFields = resultSF.NumFields;
                int inputNumFields = inputSF.NumFields;
                int identityNumFields = identitySF.NumFields;
                int shpIndex = 0;
                Envelope myQueryEnv = null;
                Geometry queryPoly = null;
                Geometry inputGeom = null;
                IGeometry intersectGeom = null;
                MapWinGIS.Shape identityShape = null;
                MapWinGIS.Shape intersectShape = null;
                IList results = null;
                string progressmessage = "";
                int inputShapesForIdentityShape = 0;

                // Loop through identitySF and get inputSF geometries that intersect
                for (int identityIndex = 0; identityIndex < identitySF.NumShapes; identityIndex++)
                {
                    identityShape = identitySF.get_Shape(identityIndex);
                    queryPoly = NTS_Adapter.ShapeToGeometry(identityShape);
                    identityShape.Extents.GetBounds(out xMin2, out yMin2, out zMin2, out xMax2, out yMax2, out zMax2);
                    myQueryEnv = new Envelope(xMin2, xMax2, yMin2, yMax2);

                    //use quadtree index to find geometries that may intersect
                    results = myQuadTree.Query(myQueryEnv);
                    int intersectIndex = 0;
                    for (int i = 0; i < results.Count; i++)
                    {
                        intersectIndex = Convert.ToInt32(results[i]);   // Get input id from quadtree results
                        currGeom = inputSF.get_Shape(intersectIndex);   // Get input geometry
                        inputGeom = NTS_Adapter.ShapeToGeometry(currGeom);   // Convert to NTS Geometry
                        for (int inputGoemIndex = 0; inputGoemIndex < inputGeom.NumGeometries; inputGoemIndex++)    //use each part of the geometry
                        {
                            if (inputGeom.GetGeometryN(inputGoemIndex).Intersects(queryPoly))   // check for intersection
                            {
                                intersectGeom = MapWinGeoProc.NTS.Topology.Operation.Overlay.OverlayOp.Overlay(queryPoly, inputGeom.GetGeometryN(inputGoemIndex), MapWinGeoProc.NTS.Topology.Operation.Overlay.SpatialFunctions.Intersection); // create intersect geometry
                                if (!intersectGeom.IsEmpty)
                                {
                                    for (int geomIndex = 0; geomIndex < intersectGeom.NumGeometries; geomIndex++)   // process each part of intersect result
                                    {
                                        if (inputGeom.GetGeometryN(inputGoemIndex).GetType().Name == intersectGeom.GetGeometryN(geomIndex).GetType().Name) // only used geometries of the same type as the input.
                                        {
                                            // Write shape geometry
                                            intersectShape = NTS_Adapter.GeometryToShape(intersectGeom.GetGeometryN(geomIndex));
                                            shpIndex = resultSF.NumShapes;
                                            if (resultSF.EditInsertShape(intersectShape, ref shpIndex) == false)
                                            {
                                                gErrorMsg = string.Format("Problem inserting shape into result file: {0}, Input Id: {1}, IdentityId: {2}", resultSF.get_ErrorMsg(resultSF.LastErrorCode), intersectIndex, identityIndex);
                                                Debug.WriteLine(gErrorMsg);
                                                Error.SetErrorMsg(gErrorMsg);
                                                return false;
                                            }
                                            inputShapesForIdentityShape++;
                                            intersectShape = null;
                                            //add the table values from input SF
                                            for (int j = 0; j <= inputNumFields - 1; j++)
                                            {
                                                if (resultSF.EditCellValue(j, shpIndex, inputSF.get_CellValue(j, intersectIndex)) == false)
                                                {
                                                    gErrorMsg = "Problem inserting value into DBF table: " + resultSF.get_ErrorMsg(resultSF.LastErrorCode);
                                                    Debug.WriteLine(gErrorMsg);
                                                    Error.SetErrorMsg(gErrorMsg);
                                                    return false;
                                                }
                                            }//end of looping through table
                                            //add the table values from identity SF
                                            for (int j = 0; j <= identityNumFields - 1; j++)
                                            {
                                                if (resultSF.EditCellValue(j + inputNumFields, shpIndex, identitySF.get_CellValue(j, identityIndex)) == false)
                                                {
                                                    gErrorMsg = "Problem inserting value into DBF table: " + resultSF.get_ErrorMsg(resultSF.LastErrorCode);
                                                    Debug.WriteLine(gErrorMsg);
                                                    Error.SetErrorMsg(gErrorMsg);
                                                    return false;
                                                }
                                            }//end of looping through table
                                        }
                                    }
                                }
                            }
                        }
                        inputGeom = null;
                    }
                    progressmessage = string.Format("{3}: Identity Index:{0}, Quadtree Results:{1}, Shapes added:{2}", identityIndex, results.Count, inputShapesForIdentityShape, DateTime.Now.ToShortTimeString());
                    results.Clear();
                    Debug.WriteLine(progressmessage);
                    inputShapesForIdentityShape = 0;
                    resultSF.StopEditingShapes(true, true, null);
                    resultSF.StartEditingShapes(true, null);
                }
                return (resultSF.NumShapes > 0);
            }
            catch (Exception E)
            {
                System.Windows.Forms.MessageBox.Show(E.ToString());
                return false;
            }
        }
        #endregion

        #region SelectPolygonsWithPolygon()
        /// <summary>
        /// Exports the shapes from the inputSF which fall within the given polygon, saving to the resultSF provided.
        /// </summary>
        /// <returns>False if an error occurs, true otherwise.</returns>
        public static bool SelectPolygonsWithPolygon(ref MapWinGIS.Shapefile inputSF, ref MapWinGIS.Shape polygon, ref MapWinGIS.Shapefile resultSF)
        {
            return SelectPolygonsWithPolygon(ref inputSF, ref polygon, ref resultSF, false);
        }
        /// <summary>
        /// Exports the shapes from the inputSF which fall within the given polygon, saving to the resultSF provided.
        /// </summary>
        /// <returns>False if an error occurs, true otherwise.</returns>
        public static bool SelectPolygonsWithPolygon(ref MapWinGIS.Shapefile inputSF, ref MapWinGIS.Shape polygon, ref MapWinGIS.Shapefile resultSF, bool SkipMWShapeID)
		{
            MapWinUtility.Logger.Dbg("SelectPolygonsWithPolygon(inputSF: " + Macro.ParamName(inputSF) + ",\n" +
                                     "                          polygon: " + Macro.ParamName(polygon) + ",\n" +
                                     "                          resultSF: ref " + Macro.ParamName(resultSF) + ",\n" +
                                     "                          SkipMWShapeID: " + SkipMWShapeID.ToString() + ")");
			int numShapes = inputSF.NumShapes;
			int shpIndex = 0;

			if(Globals.CopyFields(ref inputSF, ref resultSF) == false)
			{
				return false;
			}

			for(int i = 0; i<= numShapes-1; i++)
			{
				MapWinGIS.Shape currShape = new MapWinGIS.ShapeClass();
				currShape = inputSF.get_Shape(i);
				bool boundsIntersect = Globals.CheckBounds(ref currShape, ref polygon);
				if(boundsIntersect)
				{
					//check that actual intersection occurs
					MapWinGIS.Shape intersectShp = new MapWinGIS.ShapeClass();
					intersectShp = SpatialOperations.Intersection(currShape, polygon);
					if(intersectShp != null && intersectShp.numPoints > 0)
					{
						//shape has at least a small portion inside polygon
						shpIndex = resultSF.NumShapes;
						if(resultSF.EditInsertShape(currShape, ref shpIndex) == false)
						{
							gErrorMsg = "Problem inserting shape into result file: " + resultSF.get_ErrorMsg(resultSF.LastErrorCode);
							Debug.WriteLine(gErrorMsg);
							Error.SetErrorMsg(gErrorMsg);
                            MapWinUtility.Logger.Dbg(gErrorMsg);
							return false;
						}
						//add the table values
						int numFields = resultSF.NumFields;
						for(int j= 0; j <= numFields-1; j++)
						{
							if(resultSF.EditCellValue(j, shpIndex, inputSF.get_CellValue(j, i)) == false)
							{
								gErrorMsg = "Problem inserting value into DBF table: " + resultSF.get_ErrorMsg(resultSF.LastErrorCode);
								Debug.WriteLine(gErrorMsg);
								Error.SetErrorMsg(gErrorMsg);
                                MapWinUtility.Logger.Dbg(gErrorMsg);
								return false;
							}
						}//end of looping through table
					}//end of checking for intersection
				}//end of checking bounds
			}//end of looping through shapes
			if(resultSF.NumShapes > 0)
			{
                if (resultSF.NumFields == 0 || !SkipMWShapeID)
				{
					//add the ID field and values
					if(Globals.DoInsertIDs(ref resultSF)==false)
					{
						return false;
					}
				}
                MapWinUtility.Logger.Dbg("Finished SelectPolygonsWithPolygon");
				return true;
			}
			else
			{
                MapWinUtility.Logger.Dbg("Finished SelectPolygonsWithPolygon");
				return false;
			}
            
        }
        /// <summary>
        /// Returns the shape indexes of the polygons falling in the specified polygon.
        /// </summary>
        /// <returns>True if some are found.</returns>
        public static bool SelectPolygonsWithPolygon(ref MapWinGIS.Shapefile inputSF, ref MapWinGIS.Shape polygon, ref System.Collections.ArrayList results)
        {
            MapWinUtility.Logger.Dbg("SelectPolygonsWithPolygon(inputSF: " + Macro.ParamName(inputSF) + ", \n" +
                                     "                          polygon: " + Macro.ParamName(polygon) + ", \n" +
                                     "                          results: " + results.ToString() + ")" );
            int numShapes = inputSF.NumShapes;
            results = new System.Collections.ArrayList();

            for (int i = 0; i <= numShapes - 1; i++)
            {
                MapWinGIS.Shape currShape = new MapWinGIS.ShapeClass();
                currShape = inputSF.get_Shape(i);
                bool boundsIntersect = Globals.CheckBounds(ref currShape, ref polygon);
                if (boundsIntersect)
                {
                    //check that actual intersection occurs
                    MapWinGIS.Shape intersectShp = new MapWinGIS.ShapeClass();
                    intersectShp = SpatialOperations.Intersection(currShape, polygon);
                    if (intersectShp.numPoints > 0)
                    {
                        //shape has at least a small portion inside polygon
                        results.Add(i);
                    }//end of checking for intersection
                }//end of checking bounds
            }//end of looping through shapes
            MapWinUtility.Logger.Dbg("Finished SelectPolygonWithPolygon");
            return (results.Count > 0);
        }
		#endregion

		#region SelectPointsWithPolygon()
        /// <summary>
        /// Exports the shapes from the inputSF which fall within the given polygon, saving to the resultSF provided.
        /// </summary>
        /// <returns>False if an error occurs, true otherwise.</returns>
        public static bool SelectPointsWithPolygon(ref MapWinGIS.Shapefile inputSF, ref MapWinGIS.Shape polygon, ref MapWinGIS.Shapefile resultSF)
        {
            return SelectPointsWithPolygon(ref inputSF, ref polygon, ref resultSF, false);
        }
        /// <summary>
        /// Exports the shapes from the inputSF which fall within the given polygon, saving to the resultSF provided.
        /// </summary>
        /// <returns>False if an error occurs, true otherwise.</returns>
		public static bool SelectPointsWithPolygon(ref MapWinGIS.Shapefile inputSF, ref MapWinGIS.Shape polygon, ref MapWinGIS.Shapefile resultSF, bool SkipMWShapeID)
		{
			MapWinGIS.Utils utils = new MapWinGIS.UtilsClass();
			int numPoints = inputSF.NumShapes;
			int shpIndex = 0;

			if(Globals.CopyFields(ref inputSF, ref resultSF) == false)
			{
				return false;
			}

			for(int i = 0; i <= numPoints-1; i++)
			{
				MapWinGIS.Point currPt = new MapWinGIS.PointClass();
				currPt = inputSF.QuickPoint(i, 0);
				if(utils.PointInPolygon(polygon, currPt))
				{
					shpIndex = resultSF.NumShapes;
					if(resultSF.EditInsertShape(inputSF.get_Shape(i), ref shpIndex) == false)
					{
						gErrorMsg = "Problem inserting shape into result file: " + resultSF.get_ErrorMsg(resultSF.LastErrorCode);
						Debug.WriteLine(gErrorMsg);
						Error.SetErrorMsg(gErrorMsg);
						return false;
					}
					//add the table values
					int numFields = resultSF.NumFields;
					for(int j= 0; j <= numFields-1; j++)
					{
						if(resultSF.EditCellValue(j, shpIndex, inputSF.get_CellValue(j, i)) == false)
						{
							gErrorMsg = "Problem inserting value into DBF table: " + resultSF.get_ErrorMsg(resultSF.LastErrorCode);
							Debug.WriteLine(gErrorMsg);
							Error.SetErrorMsg(gErrorMsg);
							return false;
						}
					}//end of looping through table
				}//end of checking if point is inside polygon				
			}//end of looping through points

			if(resultSF.NumShapes > 0)
			{
                if (resultSF.NumFields == 0 || !SkipMWShapeID)
				{
					//add the ID field and values
					if(Globals.DoInsertIDs(ref resultSF)==false)
					{
						return false;
					}
				}
				return true;
			}
			else
			{
				return false;
			}
		}

        /// <summary>
        /// Returns the shape indexes of the shapes falling within the specified polygon.
        /// </summary>
        /// <returns>False if an error occurs, true otherwise.</returns>
        public static bool SelectPointsWithPolygon(ref MapWinGIS.Shapefile inputSF, ref MapWinGIS.Shape polygon, ref System.Collections.ArrayList results)
        {
            results = new System.Collections.ArrayList();
            MapWinGIS.Utils utils = new MapWinGIS.UtilsClass();
            int numPoints = inputSF.NumShapes;

            for (int i = 0; i <= numPoints - 1; i++)
            {
                MapWinGIS.Point currPt = new MapWinGIS.PointClass();
                currPt = inputSF.QuickPoint(i, 0);
                if (utils.PointInPolygon(polygon, currPt))
                {
                    results.Add(i);
                }//end of checking if point is inside polygon				
            }//end of looping through points

            return (results.Count > 0);
        }

		#endregion

		#region SelectLinesWithPolygon()
        /// <summary>
        /// Exports the shapes from the inputSF which fall within the given polygon, saving to the resultSF provided.
        /// </summary>
        /// <returns>False if an error occurs, true otherwise.</returns>
        public static bool SelectLinesWithPolygon(ref MapWinGIS.Shapefile inputSF, ref MapWinGIS.Shape polygon, ref MapWinGIS.Shapefile resultSF)
        {
            return SelectLinesWithPolygon(ref inputSF, ref polygon, ref resultSF, false);
        }
        /// <summary>
        /// Exports the shapes from the inputSF which fall within the given polygon, saving to the resultSF provided.
        /// </summary>
        /// <returns>False if an error occurs, true otherwise.</returns>
		public static bool SelectLinesWithPolygon(ref MapWinGIS.Shapefile inputSF, ref MapWinGIS.Shape polygon, ref MapWinGIS.Shapefile resultSF, bool SkipMWShapeID)
		{
			int numLines = inputSF.NumShapes;
			int shpIndex = 0;

            // Boundary intersection test variables
            double xMin1, xMax1, yMin1, yMax1, zMin1, zMax1, xMin2, xMax2, yMin2, yMax2, zMin2, zMax2;
            // Get the masking polygon's boundaries only once:
            polygon.Extents.GetBounds(out xMin2, out yMin2, out zMin2, out xMax2, out yMax2, out zMax2);

			if(Globals.CopyFields(ref inputSF, ref resultSF) == false)
			{
				return false;
			}

			MapWinGIS.Shape currLine;
			MapWinGIS.Point currPt;
			for(int i = 0; i<= numLines-1; i++)
			{
				currLine = inputSF.get_Shape(i);
                currLine.Extents.GetBounds(out xMin1, out yMin1, out zMin1, out xMax1, out yMax1, out zMax1);

                // Are the boundaries intersecting?
                if (!(xMin1 > xMax2 || xMax1 < xMin2 || yMin1 > yMax2 || yMax1 < yMin2))
                {
					//lines are nasty, just because the boundaries intersect it
					//doesn't mean the line enters the polygon
					//do a quick point check before doing a more thorough investigation
					
					int numPoints = currLine.numPoints;
					bool ptInside = false;
					for(int j = 0; j<= numPoints-1; j++)
					{
						currPt = currLine.get_Point(j);
                        if (polygon.PointInThisPoly(currPt))
						{
							ptInside = true;
							break;						
						}
					}
					if(ptInside)
					{
						//we know part of the line is inside the polygon so add line to result file
						shpIndex = resultSF.NumShapes;
						if(resultSF.EditInsertShape(currLine, ref shpIndex) == false)
						{
							gErrorMsg = "Problem inserting shape into result file: " + resultSF.get_ErrorMsg(resultSF.LastErrorCode);
							Debug.WriteLine(gErrorMsg);
							Error.SetErrorMsg(gErrorMsg);
							return false;
						}
						//add the table values
						int numFields = resultSF.NumFields;
						for(int j= 0; j <= numFields-1; j++)
						{
							if(resultSF.EditCellValue(j, shpIndex, inputSF.get_CellValue(j, i)) == false)
							{
								gErrorMsg = "Problem inserting value into DBF table: " + resultSF.get_ErrorMsg(resultSF.LastErrorCode);
								Debug.WriteLine(gErrorMsg);
								Error.SetErrorMsg(gErrorMsg);
								return false;
							}
						}//end of looping through table

					}//end of ptInside check
					else
					{
                        // Avoid using a temp file to test each individual file;
                        // instead, just see if the line crosses the polygon
                        if(LineCrossesPoly(ref currLine, ref polygon))
						{
							//part of the line lies within the polygon, add to result file
							shpIndex = resultSF.NumShapes;
							if(resultSF.EditInsertShape(currLine, ref shpIndex) == false)
							{
								gErrorMsg = "Problem inserting shape into result file: " + resultSF.get_ErrorMsg(resultSF.LastErrorCode);
								Debug.WriteLine(gErrorMsg);
								Error.SetErrorMsg(gErrorMsg);
								return false;
							}
							//add the table values
							int numFields = resultSF.NumFields;
							for(int j= 0; j <= numFields-1; j++)
							{
								if(resultSF.EditCellValue(j, shpIndex, inputSF.get_CellValue(j, i)) == false)
								{
									gErrorMsg = "Problem inserting value into DBF table: " + resultSF.get_ErrorMsg(resultSF.LastErrorCode);
									Debug.WriteLine(gErrorMsg);
									Error.SetErrorMsg(gErrorMsg);
									return false;
								}
							}//end of looping through table
						}//end of successful cross
					}//end of else no points were found inside polygon
				}//end of checking bounds
			}//end of looping through lines

			if(resultSF.NumShapes > 0)
			{
                if (resultSF.NumFields == 0 || !SkipMWShapeID)
				{
					//add the ID field and values
					if(Globals.DoInsertIDs(ref resultSF)==false)
					{
						return false;
					}
				}
				return true;
			}
			else
			{
				return false;
			}
		}

        /// <summary>
        /// Returns the indexes of shapes that fall within the specified polygon.
        /// </summary>
        /// <returns>False if an error occurs, true otherwise.</returns>
        public static bool SelectLinesWithPolygon(ref MapWinGIS.Shapefile inputSF, ref MapWinGIS.Shape polygon, ref System.Collections.ArrayList results)
        {
            int numLines = inputSF.NumShapes;
            results = new System.Collections.ArrayList();

            // Boundary intersection test variables
            double xMin1, xMax1, yMin1, yMax1, zMin1, zMax1, xMin2, xMax2, yMin2, yMax2, zMin2, zMax2;
            // Get the masking polygon's boundaries only once:
            polygon.Extents.GetBounds(out xMin2, out yMin2, out zMin2, out xMax2, out yMax2, out zMax2);

            MapWinGIS.Shape currLine;
            MapWinGIS.Point currPt;
            for (int i = 0; i <= numLines - 1; i++)
            {
                currLine = inputSF.get_Shape(i);
                currLine.Extents.GetBounds(out xMin1, out yMin1, out zMin1, out xMax1, out yMax1, out zMax1);

                // Are the boundaries intersecting?
                if (!(xMin1 > xMax2 || xMax1 < xMin2 || yMin1 > yMax2 || yMax1 < yMin2))
                {
                    //lines are nasty, just because the boundaries intersect it
                    //doesn't mean the line enters the polygon
                    //do a quick point check before doing a more thorough investigation

                    int numPoints = currLine.numPoints;
                    bool ptInside = false;
                    for (int j = 0; j <= numPoints - 1; j++)
                    {
                        currPt = currLine.get_Point(j);
                        if (polygon.PointInThisPoly(currPt))
                        {
                            ptInside = true;
                            break;
                        }
                    }
                    if (ptInside)
                    {
                        results.Add(i);
                    }//end of ptInside check
                    else
                    {
                        // Avoid using a temp file to test each individual file;
                        // instead, just see if the line crosses the polygon
                        if (LineCrossesPoly(ref currLine, ref polygon))
                        {
                            //part of the line lies within the polygon, add to result file
                            results.Add(i);
                        }//end of successful cross
                    }//end of else no points were found inside polygon
                }//end of checking bounds
            }//end of looping through lines

            return (results.Count > 0);
        }

        private static bool LineCrossesPoly(ref MapWinGIS.Shape line, ref MapWinGIS.Shape polygon)
        {
            int numLineSegs = line.numPoints - 1;
            int numPolyPts = polygon.numPoints;
            int[] intersectsPerSeg = new int[numLineSegs];
            MapWinGIS.Point[][] intersectPts = new MapWinGIS.Point[numLineSegs][];
            int[][] polyIntLocs = new int[numLineSegs][];

            for (int i = 0; i <= numLineSegs - 1; i++)
            {
                intersectPts[i] = new MapWinGIS.Point[numPolyPts];
                polyIntLocs[i] = new int[numPolyPts];
            }

            int numIntersects = Globals.CalcSiDeterm(ref line, ref polygon, out intersectsPerSeg, out intersectPts, out polyIntLocs);

            return (numIntersects != 0);
        }
		#endregion
	}
}
