//********************************************************************************************************
//File name: PointExporter.cs
//Description: Public class for exporting an array of [x,y,z] coordinates to a shapefile or a text file
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
//1/22/08 - Jiri Kadlec - Provided initial implementation					
//********************************************************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using MapWindow.Interfaces;
using MapWindow.Interfaces.Geometries;
using MapWinGeoProc.NTS.Topology.Geometries;

namespace MapWinGeoProc
{
    /// <summary>
    /// This class converts an array of [x,y,z] coordinates to a shapefile or text file
    /// </summary>
    public class PointExporter
    {
        private List<ICoordinate> _points;
        
        /// <summary>
        /// Creates a new class for exporting points
        /// </summary>
        /// <param name="points">Array of [x,y,z] points to be exported</param>
        public PointExporter(ICoordinate[] points)
        {
            _points = new List<ICoordinate>(points);
        }

        /// <summary>
        /// Creates a new PointExporter object for exporting points
        /// </summary>
        /// <param name="points"></param>
        public PointExporter(List<ICoordinate> points)
        {
            _points = points;
        }

        /// <summary>
        /// creates a point exporter to export a list of points
        /// </summary>
        /// <param name="points"></param>
        public PointExporter(IEnumerable<ICoordinate> points)
        {
            _points = new List<ICoordinate>(points);
        }

        /// <summary>
        /// creates a point exporter from an array of MapWinGIS points
        /// </summary>
        /// <param name="mwPoints"></param>
        public PointExporter(MapWinGIS.Point[] mwPoints)
        {
            int numPoints = mwPoints.Length;
            _points = new List<ICoordinate>(numPoints);
            for(int i=0; i < numPoints; ++i)
            {
                _points[i].X = mwPoints[i].x;
                _points[i].Y = mwPoints[i].y;
                _points[i].Z = mwPoints[i].Z;
            }
        }

        /// <summary>
        /// Converts an x, y, z point to a formatted text string
        /// </summary>
        /// <param name="point">An [x,y,z] point</param>
        /// <param name="separator">the separator character (typically space, comma, semicolon)</param>
        /// <returns>A formatted string with coordinates divided by the separator character</returns>
        private string PointToText(ICoordinate point, string separator)
        {
            return string.Format("{0}{1}{2}{3}{4}",
            point.X.ToString("0.00"), separator, point.Y.ToString("0.00"),
                                    separator, point.Z.ToString("0.00"));
        }
        
        
        /// <summary>
        /// Converts an array of x,y,z points to a text file.
        /// The separator can be specified (use comma or semicolon for CSV files)
        /// </summary>
        /// <param name="textFileName">name of output text file</param>
        /// <param name="separator">separator character (" ", "," ";" etc.)</param>
        public void ToTextFile(string textFileName, string separator)
        {
            using (System.IO.StreamWriter w = new System.IO.StreamWriter(textFileName))
            {
                w.WriteLine("X" + separator + "Y" + separator + "Z");
                foreach (ICoordinate pt in _points)
                {
                    w.WriteLine(PointToText(pt, separator));
                }
                w.Flush();
            }
        }

        /// <summary>
        /// Converts a list of 3d-points to a point shapefile with z-value field.
        /// This function creates a new shapefile. The shapefile has two fields:
        /// a 'MWShapeId' field and a field which contains the z-value.
        /// </summary>
        /// <param name="ShpFileName">Name of the resulting point shapefile</param>
        /// <param name="ZFieldName">Name of the z-field in the shapefile</param>
        public void ToShapefile(string ShpFileName, string ZFieldName)
        {
            MapWinGIS.Shapefile newSF = new MapWinGIS.Shapefile();
            try
            {
                Hashtable FieldIndices = new Hashtable();

                MapWinGIS.ShpfileType sftype;
                sftype = MapWinGIS.ShpfileType.SHP_POINT;
                int fldIdx = 0;

                // if shapefile exists - open it and clear all shapes
                if (System.IO.File.Exists(ShpFileName))
                {
                    newSF.Open(ShpFileName, null);
                    newSF.StartEditingShapes(true, null);
                    newSF.EditClear();
                }
                else //else, create a new shapefile
                {
                    if (!newSF.CreateNew(ShpFileName, sftype))
                    {
                        throw new InvalidOperationException
                            ("Error creating shapefile " + newSF.get_ErrorMsg(newSF.LastErrorCode));
                    }
                    newSF.StartEditingShapes(true, null);
                }

                //check existing fields:
                for (int i = 0; i < newSF.NumFields; ++i)
                {
                    MapWinGIS.Field fl = newSF.get_Field(i);
                    if (fl.Name == "MWShapeID")
                    {
                        FieldIndices.Add("MWShapeID", i);
                    }
                    if (fl.Name == ZFieldName)
                    {
                        FieldIndices.Add(ZFieldName, i);
                    }
                }

                //Add the fields:
                if (!FieldIndices.ContainsKey("MWShapeID"))
                {
                    //First an ID field
                    MapWinGIS.Field idFld = new MapWinGIS.Field();
                    idFld.Name = "MWShapeID";
                    idFld.Type = MapWinGIS.FieldType.INTEGER_FIELD;
                    fldIdx = newSF.NumFields;
                    
                    if (newSF.EditInsertField(idFld, ref fldIdx, null) == false)
                    {
                        throw new InvalidOperationException("error inserting field " + 
                            newSF.get_ErrorMsg(newSF.LastErrorCode));
                    }
                    FieldIndices.Add("MWShapeID", fldIdx);
                }

                if (!FieldIndices.ContainsKey(ZFieldName))
                {
                    //Second add a Z-field
                    MapWinGIS.Field zFld = new MapWinGIS.Field();
                    zFld.Name = "Z";
                    zFld.Type = MapWinGIS.FieldType.DOUBLE_FIELD;
                    fldIdx = newSF.NumFields;

                    if (newSF.EditInsertField(zFld, ref fldIdx, null) == false)
                    {
                        throw new InvalidOperationException("error inserting field " + 
                            newSF.get_ErrorMsg(newSF.LastErrorCode));
                    }
                    FieldIndices.Add("Z", fldIdx);
                }

                foreach (ICoordinate pt in _points)
                {
                    //first, add a point shape (geometry)
                    MapWinGIS.Shape newShp = new MapWinGIS.Shape();
                    newShp.Create(MapWinGIS.ShpfileType.SHP_POINT);
                    MapWinGIS.Point newPt = new MapWinGIS.Point();
                    newPt.x = pt.X;
                    newPt.y = pt.Y;
                    int ptIdx = 0;
                    newShp.InsertPoint(newPt, ref ptIdx);
                    int shpIdx = newSF.NumShapes;
                    newSF.EditInsertShape(newShp, ref shpIdx);

                    //second add the z-value
                    newSF.EditCellValue(fldIdx, shpIdx, pt.Z);
                }
            }
            finally
            {
                //finally stop editing and close the shapefile
                newSF.StopEditingShapes(true, true, null);
                if (newSF.Close() == false)
                {
                    throw new InvalidOperationException("error closing shapefile " + 
                            newSF.get_ErrorMsg(newSF.LastErrorCode));
                }
            }
        }
    }
}
