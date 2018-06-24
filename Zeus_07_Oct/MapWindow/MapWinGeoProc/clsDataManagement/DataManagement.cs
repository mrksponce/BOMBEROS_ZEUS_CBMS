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
//1-12-06 - Angela Hillier - Provided initial API and parameter descriptions
//6-03-06 - Angela Hillier - Added copy, delete, and rename functions						
//********************************************************************************************************
using System;
using System.IO;
using System.Diagnostics;
using MapWinUtility;

namespace MapWinGeoProc
{
	/// <summary>
	/// The DataManagement namespace will contain basic file handling routines 
	/// such as copy and delete, as well as some more complex methods for appending and merging..
	/// </summary>
	public class DataManagement
	{
		private static string gErrorMsg = "";

		#region RenameGrid()
		/// <summary>
		/// Rename a grid (or move it's path) and all associated files.
		/// </summary>
		/// <param name="oldGridPath">The full path to the original grid file (including extension).</param>
		/// <param name="newGridPath">The full path to the new grid file (including extension).</param>
		/// <returns>False if an error was encountered, true otherwise.</returns>
		public static bool RenameGrid(ref string oldGridPath, ref string newGridPath)
		{
            MapWinUtility.Logger.Dbg("RenameGrid(oldGridPath: " + oldGridPath + ",\n" +
                                     "           newGridPath: " + newGridPath + ")");
			if(CopyGrid(ref oldGridPath, ref newGridPath) == true)
			{
				DeleteGrid(ref oldGridPath);
                MapWinUtility.Logger.Dbg("Finished RenameGrid");
				return true;
			}
			else
			{
                MapWinUtility.Logger.Dbg("CopyGrid returned false; Rename " + oldGridPath + " failed.");
				return false;

			}
		}
		#endregion

		#region RenameShapefile()
		/// <summary>
		/// Rename a shapefile and all associated files.
		/// </summary>
		/// <param name="oldShapefilePath">Full path to the original shapefile (including the .shp extension).</param>
		/// <param name="newShapefilePath">New path to the shapefile (including the .shp extension).</param>
		/// <returns>False if an error was encountered, true otherwise.</returns>
		public static bool RenameShapefile(ref string oldShapefilePath, ref string newShapefilePath)
		{
            MapWinUtility.Logger.Dbg("RenameShapefile(oldShapefilePath: " + oldShapefilePath + ",\n" +
                                     "                newSahpefilePath: " + newShapefilePath + ")");
			if(CopyShapefile(ref oldShapefilePath, ref newShapefilePath) == true)
			{
				DeleteShapefile(ref oldShapefilePath);
                MapWinUtility.Logger.Dbg("Finished RenameShapefile");
				return true;
			}
			else
			{
                MapWinUtility.Logger.Dbg("CopyShapefile returned false; RenameShapefile failed.");
				return false;
			}
		}
		#endregion

		#region CopyGrid()
		/// <summary>
		/// Copies a grid and all associated files from one destination path to another.
		/// </summary>
		/// <param name="oldGridPath">The original path to the grid (including extension).</param>
		/// <param name="newGridPath">The path to where the grid copy should be (including extension).</param>
		/// <returns>False if an error was encountered, true otherwise.</returns>
        /// <remarks>Won't work for Grid formats that are directory names like an ESRI grid format yet</remarks>
		public static bool CopyGrid(ref string oldGridPath, ref string newGridPath)
		{
            string OldName, NewName;
            bool Result = true;

            MapWinUtility.Logger.Dbg("CopyGrid(oldGridPath" + oldGridPath + ",\n" +
                                     "         newGridPath" + newGridPath + ")");
            if (oldGridPath == null)
            {
                gErrorMsg = "Argument Exception: oldGridPath cannot be null.";
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                return false;
            }
            if (newGridPath == null)
            {
                gErrorMsg = "Arguemnt Exception: newGridPath cannot be null.";
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                return false;
            }

            if (System.IO.File.Exists(oldGridPath) == false)
            {
                if (System.IO.Path.GetExtension(oldGridPath) == "")
                {
                    if (System.IO.Directory.Exists(oldGridPath))
                    {
                        // TO DO: ESRI GRID format handling.

                        gErrorMsg = "Argument Exception: ESRI grids that are directories are not currently supported.";
                        Debug.WriteLine(gErrorMsg);
                        Error.SetErrorMsg(gErrorMsg);
                        MapWinUtility.Logger.Dbg(gErrorMsg);
                        return false;
                    }
                }
            }
            
           
			
		    DeleteGrid(ref newGridPath);


            System.IO.FileInfo fl;
            OldName = oldGridPath;
            NewName = newGridPath;
            Result = true;
		    try
		    {
                if (File.Exists(OldName))
			    {
                    System.IO.File.Copy(OldName, NewName);
                    fl = new System.IO.FileInfo(NewName);
                    fl.Attributes = fl.Attributes & (System.IO.FileAttributes.Archive & System.IO.FileAttributes.ReadOnly);
                }
            }
            catch(Exception Ex)
            { 
                gErrorMsg = "Exception thrown while copying " + OldName + " to " + NewName + ":\n" + Ex.ToString();
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                Result = false;
            }
            OldName = System.IO.Path.ChangeExtension(oldGridPath, ".bmp");
            NewName = System.IO.Path.ChangeExtension(newGridPath, ".bmp");
            try
            {
                if (File.Exists(OldName))
                {
                    System.IO.File.Copy(OldName, NewName);
                    fl = new System.IO.FileInfo(NewName);
                    fl.Attributes = fl.Attributes & (System.IO.FileAttributes.Archive & System.IO.FileAttributes.ReadOnly);
                }
            }
            catch (Exception Ex)
            {
                gErrorMsg = "Exception thrown while copying " + OldName + " to " + NewName + ":\n" + Ex.ToString();
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                Result = false;
            }


            OldName = System.IO.Path.ChangeExtension(oldGridPath, ".bpw");
            NewName = System.IO.Path.ChangeExtension(newGridPath, ".bpw");
            try
            {
                if (File.Exists(OldName))
                {
                    System.IO.File.Copy(OldName, NewName);
                    fl = new System.IO.FileInfo(NewName);
                    fl.Attributes = fl.Attributes & (System.IO.FileAttributes.Archive & System.IO.FileAttributes.ReadOnly);
                }
            }
            catch (Exception Ex)
            {
                gErrorMsg = "Exception thrown while copying " + OldName + " to " + NewName + ":\n" + Ex.ToString();
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                Result = false;
            }

            OldName = System.IO.Path.ChangeExtension(oldGridPath, ".mwleg");
            NewName = System.IO.Path.ChangeExtension(newGridPath, ".mwleg");
            try
            {
                if (File.Exists(OldName))
                {
                    System.IO.File.Copy(OldName, NewName);
                    fl = new System.IO.FileInfo(NewName);
                    fl.Attributes = fl.Attributes & (System.IO.FileAttributes.Archive & System.IO.FileAttributes.ReadOnly);
                }
            }
            catch (Exception Ex)
            {
                gErrorMsg = "Exception thrown while copying " + OldName + " to " + NewName + ":\n" + Ex.ToString();
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                Result = false;
            }

            OldName = System.IO.Path.ChangeExtension(oldGridPath, ".prj");
            NewName = System.IO.Path.ChangeExtension(newGridPath, ".prj");
            try
            {
                if (File.Exists(OldName))
                {
                    System.IO.File.Copy(OldName, NewName);
                    fl = new System.IO.FileInfo(NewName);
                    fl.Attributes = fl.Attributes & (System.IO.FileAttributes.Archive & System.IO.FileAttributes.ReadOnly);
                }
            }
            catch (Exception Ex)
            {
                gErrorMsg = "Exception thrown while copying " + OldName + " to " + NewName + ":\n" + Ex.ToString();
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                Result = false;
            }

            OldName = System.IO.Path.ChangeExtension(oldGridPath, ".aux");
            NewName = System.IO.Path.ChangeExtension(newGridPath, ".aux");
            try
            {
                if (File.Exists(OldName))
                {
                    System.IO.File.Copy(OldName, NewName);
                    fl = new System.IO.FileInfo(NewName);
                    fl.Attributes = fl.Attributes & (System.IO.FileAttributes.Archive & System.IO.FileAttributes.ReadOnly);
                }
            }
            catch (Exception Ex)
            {
                gErrorMsg = "Exception thrown while copying " + OldName + " to " + NewName + ":\n" + Ex.ToString();
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                Result = false;
            }
            OldName = System.IO.Path.ChangeExtension(oldGridPath, ".rrd");
            NewName = System.IO.Path.ChangeExtension(newGridPath, ".rrd");
            try
            {
                if (File.Exists(OldName))
                {
                    System.IO.File.Copy(OldName, NewName);
                    fl = new System.IO.FileInfo(NewName);
                    fl.Attributes = fl.Attributes & (System.IO.FileAttributes.Archive & System.IO.FileAttributes.ReadOnly);
                }
            }
            catch (Exception Ex)
            {
                gErrorMsg = "Exception thrown while copying " + OldName + " to " + NewName + ":\n" + Ex.ToString();
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                Result = false;
            }

           
            MapWinUtility.Logger.Dbg("Finished CopyGrid");
			return Result;
		}
		#endregion

		#region CopyShapefile()
		/// <summary>
		/// Copies a shapefile and all associated files.
		/// </summary>
		/// <param name="oldShapefilePath">Full path to the original shapefile (including .shp extension).</param>
		/// <param name="newShapefilePath">Full path to where the copy should be saved (including .shp extension).</param>
		/// <returns>False if an error was encoutered, true otherwise.</returns>
		public static bool CopyShapefile(ref string oldShapefilePath, ref string newShapefilePath)
		{
            MapWinUtility.Logger.Dbg("CopyShapefile(oldShapefilePath" + oldShapefilePath + ",\n" +
                                     "         newShapefilePath" + newShapefilePath + ")");
            if (oldShapefilePath == null)
            {
                gErrorMsg = "Argument Exception: oldShapefilePath cannot be null.";
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                return false;

            }
            if (newShapefilePath == null)
            {
                gErrorMsg = "Arguemnt Exception: newShapefilePath cannot be null.";
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                return false;
            }

            DeleteShapefile(ref newShapefilePath);
            
			try
			{
                System.IO.FileInfo fl;
                string oldShapefileName = System.IO.Path.GetDirectoryName(oldShapefilePath) + "\\" + System.IO.Path.GetFileNameWithoutExtension(oldShapefilePath);
                string newShapefileName = System.IO.Path.GetDirectoryName(newShapefilePath) + "\\" + System.IO.Path.GetFileNameWithoutExtension(newShapefilePath);
                if(File.Exists(oldShapefilePath))
				{
					System.IO.File.Copy(oldShapefilePath, newShapefilePath);
                    fl = new System.IO.FileInfo(newShapefilePath);
                    fl.Attributes = fl.Attributes & (System.IO.FileAttributes.Archive & System.IO.FileAttributes.ReadOnly);
				}
				if(File.Exists(oldShapefileName  + ".shx"))
				{
					System.IO.File.Copy(oldShapefileName + ".shx", newShapefileName + ".shx");
                    fl = new System.IO.FileInfo(newShapefileName + ".shx");
                    fl.Attributes = fl.Attributes & (System.IO.FileAttributes.Archive & System.IO.FileAttributes.ReadOnly);
				}
				if(File.Exists(oldShapefileName + ".dbf"))
				{
					System.IO.File.Copy(oldShapefileName + ".dbf", newShapefileName + ".dbf");
                    fl = new System.IO.FileInfo(newShapefileName + ".dbf");
                    fl.Attributes = fl.Attributes & (System.IO.FileAttributes.Archive & System.IO.FileAttributes.ReadOnly);
                }
				if(File.Exists(oldShapefileName + ".spx"))
				{
					System.IO.File.Copy(oldShapefileName + ".spx", newShapefileName + ".spx");
                    fl = new System.IO.FileInfo(newShapefileName + ".spx");
                    fl.Attributes = fl.Attributes & (System.IO.FileAttributes.Archive & System.IO.FileAttributes.ReadOnly);
                }
				if(File.Exists(oldShapefileName + ".prj"))
				{
					System.IO.File.Copy(oldShapefileName + ".prj", newShapefileName + ".prj");
                    fl = new System.IO.FileInfo(newShapefileName + ".prj");
                    fl.Attributes = fl.Attributes & (System.IO.FileAttributes.Archive & System.IO.FileAttributes.ReadOnly);
                }
				if(File.Exists(oldShapefileName + ".sbn"))
				{
					System.IO.File.Copy(oldShapefileName + ".sbn", newShapefileName + ".sbn");
                    fl = new System.IO.FileInfo(newShapefileName + ".sbn");
                    fl.Attributes = fl.Attributes & (System.IO.FileAttributes.Archive & System.IO.FileAttributes.ReadOnly);
                }
				if(File.Exists(oldShapefileName + ".xml"))
				{
                    fl = new System.IO.FileInfo(newShapefileName + ".xml");
                    fl.Attributes = fl.Attributes & (System.IO.FileAttributes.Archive & System.IO.FileAttributes.ReadOnly);
                    System.IO.File.Copy(oldShapefileName + ".xml", newShapefileName + ".xml");
				}
				if(File.Exists(oldShapefileName + ".shp.xml"))
				{
					System.IO.File.Copy(oldShapefileName + ".shp.xml", newShapefileName + ".shp.xml");
                    fl = new System.IO.FileInfo(newShapefileName + ".shp.xml");
                    fl.Attributes = fl.Attributes & (System.IO.FileAttributes.Archive & System.IO.FileAttributes.ReadOnly);
                }
			}
			catch(Exception e)
			{
				gErrorMsg = e.Message + e.ToString();
				Debug.WriteLine(gErrorMsg);
				Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(e.Message);
				return false;
			}
            MapWinUtility.Logger.Dbg("Finished CopyShapefile");
	
			return true;
		}
		#endregion

        /// <summary>
        /// Attempts to delete a file.
        /// </summary>
        /// <returns>Boolean, false if the file is null or the directory doesn't exist or the file doesn't exist</returns>
        public static bool TryDelete(string file)
        {
            string Directory;
            MapWinUtility.Logger.Dbg("TryDelete(file: " + file + ")");
            if (file == null)
            {
                gErrorMsg = "File Cannot be null.\nTryDelete = false";
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                return false;
            }
            Directory = System.IO.Path.GetDirectoryName(file);
            if (System.IO.Directory.Exists(Directory) == false)
            {
                gErrorMsg = "Specified Directory: " + Directory + " did not exist.\nTryDelete = false";
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                return false;
            }
            if (System.IO.File.Exists(file) == false)
            {
                if (System.IO.Directory.Exists(Directory) == false)
                {
                    gErrorMsg = "Specified File: " + file + " did not exist.\nTryDelete = false";
                    Debug.WriteLine(gErrorMsg);
                    Error.SetErrorMsg(gErrorMsg);
                    MapWinUtility.Logger.Dbg(gErrorMsg);
                    return false;
                }
            }
            try
            {
                System.IO.File.Delete(file);       
            }
            catch(Exception Ex)
            {
                gErrorMsg = "Error trying to delete " + file + ":\n" + 
                            Ex.ToString() + ".\nTryDelete = false";
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                return false;
            }
            MapWinUtility.Logger.Dbg("Finished TryDelete.");
            return true;
            
        }

        /// <summary>
        /// Copies the .mwleg file from the input grid to the output grid.
        /// </summary>
        public static bool CopyGridLegend(string inputGF, string resultGF)
        {
            MapWinUtility.Logger.Dbg("CopyGridLegend(inputGF: " + inputGF + ", resultGF:" + resultGF);
            if (System.IO.File.Exists(System.IO.Path.ChangeExtension(inputGF, ".mwleg")))
            {
                try
                {
                    System.IO.File.Copy(System.IO.Path.ChangeExtension(inputGF, ".mwleg"), System.IO.Path.ChangeExtension(resultGF, ".mwleg"));
                    System.IO.FileInfo fl = new System.IO.FileInfo(System.IO.Path.ChangeExtension(resultGF, ".mwleg"));
                    fl.Attributes = fl.Attributes & (System.IO.FileAttributes.Archive & System.IO.FileAttributes.ReadOnly);
                    MapWinUtility.Logger.Dbg("Finished CopyGridLegend");
                    return true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    MapWinUtility.Logger.Dbg("Exception Thrown: " + ex.Message);
                }
            }

            return false;
        }
        
		#region DeleteGrid()
		/// <summary>
		/// Deletes the grid and associated  files (.bmp, .bpw, .mwleg, .prj).
		/// </summary>
		/// <param name="gridPath">Full path to the grid file, including extension.</param>
        /// <returns>Boolean, False if gridPath is null, the directory doesn't exist, or any of the files exist but could not be deleted.</returns>
		public static bool DeleteGrid(ref string gridPath)
		{
            string Filename, Directory;
            bool Result = true;
            MapWinUtility.Logger.Dbg("DeleteGrid(gridPath" + gridPath + ",\n");
            if (gridPath == null)
            {
                gErrorMsg = "gridPath cannot be null.";
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                MapWinUtility.Logger.Dbg("DeleteGrid = false");
                return false;
            }
            Directory = System.IO.Path.GetDirectoryName(gridPath);
            if(System.IO.Directory.Exists(Directory)==false)
            {
                gErrorMsg = "The specified directory: " + Directory + " does not exist.";
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                MapWinUtility.Logger.Dbg("DeleteGrid = false");
                return false;
            }
            Filename = gridPath;
            try
            {
                if (System.IO.File.Exists(Filename)) System.IO.File.Delete(Filename);     
            }
            catch (Exception Ex)
            {
                gErrorMsg = "Error trying to delete " + Filename + ":\n" +
                           Ex.ToString() + ".\nTryDelete = false";
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                Result = false;
            }

            Filename = System.IO.Path.ChangeExtension(Filename, ".bmp");
            try
            {
                if (System.IO.File.Exists(Filename)) System.IO.File.Delete(Filename);
            }
            catch (Exception Ex)
            {
                gErrorMsg = "Error trying to delete " + Filename + ":\n" +
                           Ex.ToString() + ".\nTryDelete = false";
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                Result = false;
            }

           
            Filename = System.IO.Path.ChangeExtension(Filename, ".bpw");
            try
            {
                if (System.IO.File.Exists(Filename)) System.IO.File.Delete(Filename);
            }
            catch (Exception Ex)
            {
                gErrorMsg = "Error trying to delete " + Filename + ":\n" +
                           Ex.ToString() + ".\nTryDelete = false";
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                Result = false;
            }

            Filename = System.IO.Path.ChangeExtension(Filename, ".mwleg");
            try
            {
                if (System.IO.File.Exists(Filename)) System.IO.File.Delete(Filename);
            }
            catch (Exception Ex)
            {
                gErrorMsg = "Error trying to delete " + Filename + ":\n" +
                           Ex.ToString() + ".\nTryDelete = false";
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                Result = false;
            }

           
            Filename = System.IO.Path.ChangeExtension(Filename, ".prj");
            try
            {
                if (System.IO.File.Exists(Filename)) System.IO.File.Delete(Filename);
            }
            catch (Exception Ex)
            {
                gErrorMsg = "Error trying to delete " + Filename + ":\n" +
                           Ex.ToString() + ".\nTryDelete = false";
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                Result = false;
            }
            
            Filename = System.IO.Path.ChangeExtension(Filename, ".aux");
            try
            {
                if (System.IO.File.Exists(Filename)) System.IO.File.Delete(Filename);
            }
            catch (Exception Ex)
            {
                gErrorMsg = "Error trying to delete " + Filename + ":\n" +
                           Ex.ToString() + ".\nTryDelete = false";
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                Result = false;
            }
            
            Filename = System.IO.Path.ChangeExtension(Filename, ".rrd");
            try
            {
                if (System.IO.File.Exists(Filename)) System.IO.File.Delete(Filename);
            }
            catch (Exception Ex)
            {
                gErrorMsg = "Error trying to delete " + Filename + ":\n" +
                           Ex.ToString() + ".\nTryDelete = false";
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                Result = false;
            }

			return Result;
		}
		#endregion

		#region DeleteShapefile()
		/// <summary>
		/// Deletes shapefile and associated files (.shx, .dbf, .prj).
		/// </summary>
		/// <param name="shapefilePath">Full path to shapefile, including .shp extension</param>
		public static bool DeleteShapefile(ref string shapefilePath)
		{
            string Filename, Directory;
            bool Result = true;

            MapWinUtility.Logger.Dbg("bool DeleteShapefile(shapefilePath: " + shapefilePath + ")");
            if (shapefilePath == null)
            {
                gErrorMsg = "Shapefile path cannot be null.";
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                MapWinUtility.Logger.Dbg("DeleteShapefile = false");
                return false;
            }
            Directory = System.IO.Path.GetDirectoryName(shapefilePath);
            
            if (System.IO.Directory.Exists(Directory) == false)
            {
                gErrorMsg = "The specified directory: " + Directory + " does not exist.";
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                MapWinUtility.Logger.Dbg("DeleteShapefile = false");
                return false;
            }
            Filename = shapefilePath;

            try
            {
                if (System.IO.File.Exists(Filename)) System.IO.File.Delete(Filename);
            }
            catch (Exception Ex)
            {
                gErrorMsg = "Error trying to delete " + Filename + ":\n" +
                           Ex.ToString() + ".\nTryDelete = false";
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                Result = false;
            }

            Filename = System.IO.Path.ChangeExtension(Filename, ".shx");
           
            try
            {
                if (System.IO.File.Exists(Filename)) System.IO.File.Delete(Filename);
            }
            catch (Exception Ex)
            {
                gErrorMsg = "Error trying to delete " + Filename + ":\n" +
                           Ex.ToString() + ".\nTryDelete = false";
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                Result = false;
            }

            Filename = System.IO.Path.ChangeExtension(Filename, ".dbf");
            
            try
            {
                if (System.IO.File.Exists(Filename)) System.IO.File.Delete(Filename);
            }
            catch (Exception Ex)
            {
                gErrorMsg = "Error trying to delete " + Filename + ":\n" +
                           Ex.ToString() + ".\nTryDelete = false";
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                Result = false;
            }

            Filename = System.IO.Path.ChangeExtension(Filename, ".prj");

            try
            {
                if (System.IO.File.Exists(Filename)) System.IO.File.Delete(Filename);
            }
            catch (Exception Ex)
            {
                gErrorMsg = "Error trying to delete " + Filename + ":\n" +
                           Ex.ToString() + ".\nTryDelete = false";
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                Result = false;
            }

            Filename = System.IO.Path.ChangeExtension(Filename, ".spx");
            
            try
            {
                if (System.IO.File.Exists(Filename)) System.IO.File.Delete(Filename);
            }
            catch (Exception Ex)
            {
                gErrorMsg = "Error trying to delete " + Filename + ":\n" +
                           Ex.ToString() + ".\nTryDelete = false";
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                Result = false;
            }

            Filename = System.IO.Path.ChangeExtension(Filename, ".sbn");
           
            try
            {
                if (System.IO.File.Exists(Filename)) System.IO.File.Delete(Filename);
            }
            catch (Exception Ex)
            {
                gErrorMsg = "Error trying to delete " + Filename + ":\n" +
                           Ex.ToString() + ".\nTryDelete = false";
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                Result = false;
            }
            
            Filename = System.IO.Path.ChangeExtension(Filename, ".mwsr");

            try
            {
                if (System.IO.File.Exists(Filename)) System.IO.File.Delete(Filename);
            }
            catch (Exception Ex)
            {
                gErrorMsg = "Error trying to delete " + Filename + ":\n" +
                           Ex.ToString() + ".\nTryDelete = false";
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                Result = false;
            }

            Filename = System.IO.Path.ChangeExtension(Filename, ".lbl");

            try
            {
                if (System.IO.File.Exists(Filename)) System.IO.File.Delete(Filename);
            }
            catch (Exception Ex)
            {
                gErrorMsg = "Error trying to delete " + Filename + ":\n" +
                           Ex.ToString() + ".\nTryDelete = false";
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                Result = false;
            }

            Filename = System.IO.Path.ChangeExtension(Filename, ".xml");
           
            try
            {
                if (System.IO.File.Exists(Filename)) System.IO.File.Delete(Filename);
            }
            catch (Exception Ex)
            {
                gErrorMsg = "Error trying to delete " + Filename + ":\n" +
                           Ex.ToString() + ".\nTryDelete = false";
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                Result = false;
            }
            Filename = System.IO.Path.ChangeExtension(Filename, ".shp.xml");
            
            try
            {
                if (System.IO.File.Exists(Filename)) System.IO.File.Delete(Filename);
            }
            catch (Exception Ex)
            {
                gErrorMsg = "Error trying to delete " + Filename + ":\n" +
                           Ex.ToString() + ".\nTryDelete = false";
                Debug.WriteLine(gErrorMsg);
                Error.SetErrorMsg(gErrorMsg);
                MapWinUtility.Logger.Dbg(gErrorMsg);
                Result = false;
            }


            MapWinUtility.Logger.Dbg("Finished DeleteShapefile");
			return Result;
		}
		#endregion

        #region ChangeGridFormat

        /// <summary>
        /// Er... Changes a grid format?
        /// </summary>
        /// <param name="origFilename">Original Grid Filename</param>
        /// <param name="newFilename">Output Grid Filename</param>
        /// <param name="newFileType">Specifies the original file format of the grid</param>
        /// <param name="newFileFormat">Specifies the new file format</param>
        /// <param name="multFactor">Like Extrusion, this multiplies the Z value</param>
        /// <returns>Boolean, false if there was an error</returns>
        public static bool ChangeGridFormat(string origFilename, string newFilename, MapWinGIS.GridFileType newFileType, MapWinGIS.GridDataType newFileFormat, float multFactor)
        {
            bool Errors = false;

            MapWinGIS.Grid tGrd = new MapWinGIS.Grid();
            tGrd.Open(origFilename, MapWinGIS.GridDataType.UnknownDataType, true, MapWinGIS.GridFileType.UseExtension, null);
            
            Logger.Status("Writing Grid to New Format");

            //If we're multiplying by a factor, must
            //create the new grid and actually do it ourselves.
            //Otherwise, can save directly
            //Jiri Kadlec 1-28-2009 we still neet to create a new grid when the data or file type is different.
            if (multFactor == 1 && newFileFormat == tGrd.DataType)
            {
                Logger.Dbg("Saving directly to new format");
                tGrd.Save(newFilename, newFileType, null);
                // ProgressForm)
            }
            else
            {
                Logger.Dbg("Saving to new format with mult. factor: " + multFactor.ToString());

                MapWinGIS.GridHeader hdr = new MapWinGIS.GridHeader();
                hdr.CopyFrom(tGrd.Header);

                MapWinGIS.Grid newgrid = new MapWinGIS.Grid();
                if (!newgrid.CreateNew(newFilename, hdr, newFileFormat, hdr.NodataValue, true, newFileType, null))
                {
                    Logger.Message("Unable to create new grid!", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.DialogResult.OK);
                    Errors = true;
                }
                else
                {
                    int ncols = tGrd.Header.NumberCols;
                    int nrows = tGrd.Header.NumberRows;
                    float[] oneRow = new float[ncols + 1];
                    for (int i = 0; i <= nrows - 1; i++)
                    {
                        tGrd.GetFloatWindow(i, i, 0, ncols, ref oneRow[0]);
                        for (int z = 0; z <= ncols - 1; z++)
                        {
                            oneRow[z] *= multFactor;
                        }
                        newgrid.PutFloatWindow(i, i, 0, ncols, ref oneRow[0]);
                    }
                    newgrid.Save(newFilename, newFileType, null);
                    newgrid.Close();
                }
            }

            return !Errors;
        }
        #endregion

        /// <summary>
		/// Not Implemented
		/// Appends one shapefile to another. No intersection/union operation is performed
		/// on overlapping shapes. The input shapefile is overwritten.
		/// </summary>
		/// <param name="inputSFPath">Full path to the input shapefile.</param>
		/// <param name="appendSFPath">Full path to the shapefile that needs to be appended to the input shapefile.</param>
		/// <returns>False if an error was encountered, true otherwise.</returns>
		public static bool AppendShapefile(ref string inputSFPath, ref string appendSFPath)
		{
			//TODO: Implement this function
			Error.ClearErrorLog();
			gErrorMsg = "This function is not yet implemented.";
			Error.SetErrorMsg(gErrorMsg);
			Debug.WriteLine(gErrorMsg);
            MapWinUtility.Logger.Dbg(gErrorMsg);
		
			return false;
		}

		/// <summary>
		/// Not Implemented
		/// Removes shapes from the shapefile that contain a specified attribute.
		/// </summary>
		/// <param name="inputSFPath">The full path to the input shapefile.</param>
		/// <param name="resultSFPath">The full path to the resulting shapefile.</param>
		/// <param name="fieldID">The ID value for which field in the input shapefile will be considered.</param>
		/// <param name="attributeLoc">The location of an attribute value to compare against for removing shapes.</param>
		/// <param name="compOperation">The comparison method to use (==, !=, >=, etc).</param>
		/// <returns>False if an error was encountered, true otherwise.</returns>
		public static bool Dissolve(ref string inputSFPath, ref string resultSFPath, int fieldID, int attributeLoc, int compOperation)
		{
			//TODO: Implement this function
			Error.ClearErrorLog();
			gErrorMsg = "This function is not yet implemented.";
			Error.SetErrorMsg(gErrorMsg);
			Debug.WriteLine(gErrorMsg);
            MapWinUtility.Logger.Dbg(gErrorMsg);

			return false;
		}

		/// <summary>
		/// Not Implemented
		/// Combines two grids into one.
		/// </summary>
		/// <param name="grid1Path">Full path to the first grid.</param>
		/// <param name="grid2Path">Full path to the second grid.</param>
		/// <param name="resultGridPath">Full path to the result grid.</param>
		/// <returns>False if an error was encountered, true otherwise.</returns>
		public static bool MergeGrids(ref string grid1Path, ref string grid2Path, ref string resultGridPath)
		{
			//TODO: Implement this function
			Error.ClearErrorLog();
			gErrorMsg = "This function is not yet implemented.";
			Error.SetErrorMsg(gErrorMsg);
			Debug.WriteLine(gErrorMsg);
            MapWinUtility.Logger.Dbg(gErrorMsg);

			return false;
		}

		/// <summary>
		/// Not Implemented
		/// Combines two shapefiles into one.
		/// </summary>
		/// <param name="sf1Path">Full path to the first shapefile.</param>
		/// <param name="sf2Path">Full path to the second shapefile.</param>
		/// <param name="resultSFPath">Full path to the result shapefile.</param>
		/// <param name="mergeOperation">Indicates whether Union or Intersect should be performed on overlapping shapes.</param>
		/// <param name="tableOperation">Indicates how table data should be combined.</param>
		/// <returns>False if an error was encountered, true otherwise.</returns>
		public static bool MergeShapefiles(ref string sf1Path, ref string sf2Path, ref string resultSFPath, int mergeOperation, int tableOperation)
		{
			//TODO: Implement this function
			Error.ClearErrorLog();
			gErrorMsg = "This function is not yet implemented.";
			Error.SetErrorMsg(gErrorMsg);
			Debug.WriteLine(gErrorMsg);
            MapWinUtility.Logger.Dbg(gErrorMsg);

			return false;
		}

        /// <summary>
        /// Uses dialogs to obtain input and output information for processing files
        /// </summary>
        public static void MergeShapefiles()
        {
            MapWinUtility.Logger.Dbg("MergeShapefiles()");
            MapWinGeoProc.clsMergeShapefiles merger = new MapWinGeoProc.clsMergeShapefiles();
            merger.DoMergeShapefiles();
            MapWinUtility.Logger.Dbg("Exit MergeShapefiles()");  
        }

	}
}
