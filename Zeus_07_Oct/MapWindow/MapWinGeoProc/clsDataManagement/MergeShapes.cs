//********************************************************************************************************
//File name: DataManagement.cs
//Description: Public class, provides basic file handling methods as well as merge and append.
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
//12-03-2008 Ted Dunsford (Shade1974) posted this code to implement merge shapes.					
//********************************************************************************************************
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MapWinGeoProc.Dialogs;
namespace MapWinGeoProc
{
    public class clsMergeShapefiles
    {
        #region Variables

        private MapWinGIS.Shapefile _inSF1;
        private MapWinGIS.Shapefile _inSF2;
        private MapWinGIS.Shapefile _outSF;

        private string _inFile1;
        private string _inFile2;
        private string _outFile;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the AppendShapes class
        /// </summary>
        /// <param name="inMap">The map to add the merged shape to</param>
        public clsMergeShapefiles()
        {
          
        }
        #endregion

        #region Methods

        /// <summary>
        /// Actually engages the append shapes process
        /// </summary>
        public void DoMergeShapefiles()
        {
            MapWinUtility.Logger.Dbg("DoMergeShapefiles()");
            string errorMessage;
            _inSF1 = new MapWinGIS.Shapefile();
            _inSF2 = new MapWinGIS.Shapefile();
            _outSF = new MapWinGIS.Shapefile();

            GetFilenames();

            if (OpenFiles(out errorMessage) == false)
            {
                MapWinUtility.Logger.Message(errorMessage, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error, DialogResult.OK);
                return;
            }


            if (_outSF.StartEditingShapes(true, null) == false)
            {
                CloseMessage(_outSF.get_ErrorMsg(_outSF.LastErrorCode));
                return;
            }

            // Determine a list of unique fields to add to the output shapefile.
            if (CombineFields(out errorMessage) == false)
            {
                CloseMessage(errorMessage);
                return;
            }

            if (AddShapes(_inSF1, out errorMessage) == false)
            {
                CloseMessage(errorMessage);
                return;
            }

            if (AddShapes(_inSF2, out errorMessage) == false)
            {
                CloseMessage(errorMessage);
                return;
            }

            _inSF2.Close();
            _inSF1.Close();
            if (_outSF.StopEditingShapes(true, true, null) == false)
            {
                MapWinUtility.Logger.Message(_outSF.get_ErrorMsg(_outSF.LastErrorCode), "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error, DialogResult.OK);
                return;
            }

            _outSF.Close();
            MapWinUtility.Logger.Message("Finished Merging Shapes", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Information, DialogResult.OK);

           
        }

        // Close files and show an error message
        private void CloseMessage(string message)
        {
            if(_outSF != null) _outSF.Close();
            if (_inSF1 != null) _inSF1.Close();
            if (_inSF2 != null) _inSF2.Close();
            MapWinUtility.Logger.Message(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, DialogResult.OK);
        }


        // Use a file dialog to obtain the filenames
        private void GetFilenames()
        {
            GeoProcDialog dialog = new MapWinGeoProc.Dialogs.GeoProcDialog();

            //
            // File Element 1
            //
            FileElement file1 = dialog.Add_FileElement(MapWinGeoProc.Dialogs.GeoProcDialog.ElementTypes.OpenShapefile);
            file1.Caption = "First input shapefile";
            file1.HelpButtonVisible = false;
            //
            // File Element 2
            //
            FileElement file2 = dialog.Add_FileElement(MapWinGeoProc.Dialogs.GeoProcDialog.ElementTypes.OpenShapefile);
            file2.Caption = "Second input shapefile";
            file2.HelpButtonVisible = false;
            //
            // Out File Element
            //
            FileElement outFile = dialog.Add_FileElement(MapWinGeoProc.Dialogs.GeoProcDialog.ElementTypes.SaveShapefile);
            outFile.Caption = "Output Shapefile";
            outFile.HelpButtonVisible = false;

            // Show a dialog to get the filenames to work with
            if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            _inFile1 = file1.Filename;
            _inFile2 = file2.Filename;
            _outFile = outFile.Filename;
            MapWinUtility.Logger.Dbg("input file 1: " + _inFile1);
            MapWinUtility.Logger.Dbg("input file 2: " + _inFile2);
            MapWinUtility.Logger.Dbg("output file: " + _outFile);
        }

        // Try to open the shapefiles, return false if there was a problem 
        private bool OpenFiles(out string errorMessage)
        {
            errorMessage = "No Error";

            // Try to open the filenames and test that they are the same type of shapefile
            if (_inSF1.Open(_inFile1, null) == false)
            {
                errorMessage = _inSF1.get_ErrorMsg(_inSF1.LastErrorCode);
                return false;
            }
            if (_inSF2.Open(_inFile2, null) == false)
            {
                _inSF1.Close();
                errorMessage = _inSF2.get_ErrorMsg(_inSF1.LastErrorCode);
                return false;
            }
            if (_inSF1.ShapefileType != _inSF2.ShapefileType)
            {
                _inSF1.Close();
                _inSF2.Close();
                errorMessage = "Shape types were incompatible: " + _inSF1.ShapefileType.ToString() + " != " + _inSF2.ShapefileType.ToString();
                return false;
            }

            // Create the output shapefile and prepare it for editing
            if (_outSF.CreateNew(_outFile, _inSF1.ShapefileType) == false)
            {
                _inSF1.Close();
                _inSF2.Close();
                errorMessage = _outSF.get_ErrorMsg(_outSF.LastErrorCode);
                return false;
            }
            return true;
        }

        // Build a list of unique fields for the output file
        private bool CombineFields(out string errorMessage)
        {
            errorMessage = "No Error";
            List<MapWinGIS.Field> fields = new List<MapWinGIS.Field>();
            List<string> names = new List<string>();
            for (int fld = 0; fld < _inSF1.NumFields; fld++)
            {
                MapWinGIS.Field field = _inSF1.get_Field(fld);
                fields.Add(field);
                names.Add(field.Name);
            }
            for (int fld = 0; fld < _inSF2.NumFields; fld++)
            {
                MapWinGIS.Field field = _inSF2.get_Field(fld);
                string name = field.Name;
                if (names.Contains(name) == false)
                {
                    fields.Add(field);
                    names.Add(name);
                }
                else
                {
                    if (fields[names.IndexOf(name)].Type != field.Type)
                    {
                        errorMessage = "Fields with a common name [" + name + "] did not share the same type.";
                        return false;
                    }
                }
            }

            int fi = 0;
            foreach (MapWinGIS.Field field in fields)
            {
                if (_outSF.EditInsertField(field, ref fi, null) == false)
                {
                    errorMessage = _outSF.get_ErrorMsg(_outSF.LastErrorCode);
                    return false;
                }
                fi++;
            }
            return true;
        }

        // Add the shapes one by one
        private bool AddShapes(MapWinGIS.Shapefile inSF, out string errorMessage)
        {
            errorMessage = "No Error.";
            int outShp = _outSF.NumShapes;
            // Add all the shapes and attributes from the first shapefile
            for (int shp = 0; shp < inSF.NumShapes; shp++)
            {
                MapWinGIS.Shape shape = inSF.get_Shape(shp);
                _outSF.EditInsertShape(shape, ref outShp);
                for (int fld = 0; fld < inSF.NumFields; fld++)
                {
                    string name = inSF.get_Field(fld).Name;
                    int index = IndexOf(name);
                    if (index == -1)
                    {
                        errorMessage = "Could not find a field in the output shapefile: [" + name + "]";
                        return false;
                    }
                    if (_outSF.EditCellValue(index, outShp, inSF.get_CellValue(fld, shp))==false)
                    {
                        errorMessage = _outSF.get_ErrorMsg(_outSF.LastErrorCode);
                        return false;
                    }
                }
                outShp++;
            }
            return true;
           
        }

        // Use the string name to test each field in the output shapefile to determine the correct index
        private int IndexOf(string fieldName)
        {
            for (int fld = 0; fld < _outSF.NumFields; fld++)
            {
                if (_outSF.get_Field(fld).Name == fieldName) return fld;
            }
            return -1;
        }

        #endregion

    }
}
