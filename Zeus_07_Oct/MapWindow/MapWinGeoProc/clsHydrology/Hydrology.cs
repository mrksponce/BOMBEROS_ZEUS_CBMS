//********************************************************************************************************
//File name: Hydrology.cs
//Description: Public class, provides methods for watershed delineation.
//********************************************************************************************************
//The contents of this file are subject to the Mozilla Public License Version 1.1 (the "License"); 
//you may not use this file except in compliance with the License. You may obtain a copy of the License at 
//http://www.mozilla.org/MPL/ 
//Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF 
//ANY KIND, either express or implied. See the License for the specific language governing rights and 
//limitations under the License. 
//
//The Original Code is MapWindow Open Source Hydrology, including the Fill algorithm that was
//developed by Ted Dunsford at Idaho State University.  This algorithm is currently being
//prepared for publication in Computers and Geosciences.
//
//Contributor(s): (Open source contributors should list themselves and their modifications here). 
//7/7/2006 Ted Dunsford established this new environment for an improved hydrology toolkit.						
//********************************************************************************************************

using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Diagnostics;
using MapWinGeoProc.Dialogs;
using MapWinGeoProc.Pitfill;
using System.IO;

namespace MapWinGeoProc
{
    /// <summary>
    /// The Hydrology algorithms are especially designed for working with DEMs in the context
    /// of modeling hydrological processes.  
    /// </summary>
    public class Hydrology
    {
        //Class level variables.  These variables are shared by the functions, or can be used
        //to preserve information between function calls, in the event of future dependency.
        //To indicate that they are class level, I will mark them with m_

        private class Times
        {
            DateTime t_StartTime;
            DateTime t_StartOfLast;
            TimeSpan t_TotalSpan;
            TimeSpan t_LastSpan;
            public DateTime StartTime
            {
                get
                {
                    return t_StartTime;
                }
                set
                {
                    t_StartTime = value;
                }
            }//End StartTime
            public DateTime StartOfLast
            {
                get
                {
                    return t_StartOfLast;
                }
                set
                {
                    t_StartOfLast = value;
                }
            }//End StartOfLast
            //Returns a statuslike string showing the timespan
            public string TotalSpan
            {
                get
                {
                    t_TotalSpan = System.DateTime.Now - t_StartTime;
                    return t_TotalSpan.ToString();
                }
            }
            public string LastTime
            {
                get
                {
                    t_LastSpan = System.DateTime.Now - t_StartOfLast;
                    return t_LastSpan.ToString();
                }
            }
        }//End of Times class
        
        
        /// <summary>
        /// This is a dataformat to hold some strings with error information
        /// </summary>
        public struct ErrorLog
        {
            /// <summary>
            /// A stringbuilder with log of errors
            /// </summary>
            public System.Text.StringBuilder log;
            /// <summary>
            /// The last error thrown in Hydrology
            /// </summary>
            public string LastErrorMessage;
            /// <summary>
            /// The last function called
            /// </summary>
            public string LastFunctionCalled;
            /// <summary>
            /// The last progress message before the error
            /// </summary>
            public string LastLocation;
            /// <summary>
            /// Clears the local error information
            /// </summary>
            public void clear()
            {
                log = new System.Text.StringBuilder();
                LastErrorMessage = String.Empty;
                LastFunctionCalled = String.Empty;
                LastLocation = String.Empty;
            }
        }
        ErrorLog m_ErrorLog;


        // These are some properties for Hydrology that I plan for other functions to use as well.
        #region Shared Properties

        /// <summary>
        /// A string holding the last error generated in this class
        /// </summary>
        public ErrorLog LastErrorInfo
        {
            get
            {
                return m_ErrorLog;
            }
        }

        #endregion

        #region  --------- Fill ---------------

        /// <summary>
        /// An overload of the Fill function which will generate a GeoprocDialog for the Fill function
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static void Fill(MapWinGIS.ICallback callback)
        {
            MapWinUtility.Logger.Dbg("Fill(ICallback) -> doFillDiag");
            doFillDiag(false, callback);
        }

        /// <summary>
        /// An overload of the Fill function which will generate a GeoprocDialog for the Fill function
        /// </summary>
        /// <returns></returns>
        public static void Fill()
        {
            MapWinUtility.Logger.Dbg("Fill() -> doFillDiag");
            doFillDiag(false, null);
        }

        /// <summary>
        /// This overload does not take a callback, but allows the user to show the progress dialog.
        /// </summary>
        /// <param name="ShowProgressDialog">Boolean, true will display the progress dialog.</param>
        public static void Fill(bool ShowProgressDialog)
        {
            MapWinUtility.Logger.Dbg("Fill(ShowProgressDialog: " + ShowProgressDialog.ToString() + ") -> doFillDiag");
            doFillDiag(ShowProgressDialog, null);
        }

        private static void doFillDiag(bool ShowProgressDialog, MapWinGIS.ICallback callback)
        {
            MapWinUtility.Logger.Dbg("doFillDiag(showProgressDialog: " + ShowProgressDialog.ToString() + ", ICallback)");
            GeoProcDialog fillDiag = new GeoProcDialog();
            FileElement demElem = fillDiag.Add_FileElement(GeoProcDialog.ElementTypes.OpenGridFile);
            FileElement fillResElem = fillDiag.Add_FileElement(GeoProcDialog.ElementTypes.SaveGridFile);

            fillDiag.Text = "Sub-basins to Shapefile Conversion";
            fillDiag.DialogHelpTitle = "Sub-basins to Shapefile Conversion";
            fillDiag.DialogHelpText = "This function will generate a polygon shapefile of sub-basins from a sub-basin grid and D8 grid.";
            fillDiag.Height = 200;
            fillDiag.HelpPanelVisible = false;

            demElem.Caption = "Digital Elevation Model Grid Path";
            demElem.HelpButtonVisible = false;
            

            fillResElem.Caption = "Pit-Filled DEM Grid Path";
            fillResElem.HelpButtonVisible = false;
            




            if (fillDiag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                // Defaults to Overwriting silently (not showing a messagebox for overwriting destination.)
                // Defaults to NOT showing the progress dialog
                // Default Width = 10,000
                // Default Height = 2,000
                
                File_Fill(demElem.Filename, fillResElem.Filename, true, ShowProgressDialog, 10000, 2000, callback);
            }
            return;
        }
      

            //         |------------------------- FILE NAMES | DEFAULT FRAMES -----------------------------|
            /// <summary>
            /// Fills depressions in an image
            /// - Files specified by parameters
            /// - Progress and status messages will be sent back via ICallBack
            /// - Frames will be sized to default values
            /// </summary>
            /// <param name="SourceFile">String filename of unfilled DEM</param>
            /// <param name="DestFile">String filename of output file</param>
            /// <param name="ICallBack">
            /// A MapWinGIS ICallback parameter for progress or status messages
            /// </param>
            /// <remarks>
            /// Images too large to process all at once are broken down into a framework.
            /// A frame represents what will be loaded into memory at any given time.
            /// </remarks>
            static public void Fill(string SourceFile, string DestFile, MapWinGIS.ICallback ICallBack)
            {
                // 2000 width
                // 1000 height
                MapWinUtility.Logger.Dbg("Fill(SourceFile: " + SourceFile + ",\n" +
                                         "     DestFile: " + DestFile + ",\n" +
                                         "     ICallback");
                File_Fill(SourceFile, DestFile, true, false, 10000, 2000, ICallBack);
            }
            /// <summary>
            /// Fills depressions in an image.
            /// - File names obtained through parameters
            /// - Progress will be shown through a dialog if ShowProgress is true
            /// - Frames will be sized to default values
            /// </summary>
            /// <param name="SourceFile">String the full path of a source DEM to fill</param>
            /// <param name="DestFile">String, the full path of the output filled dem</param>
            /// <param name="ShowProgressDialog">
            /// Boolean.  Function will display a dialog depicting progress if true.
            /// </param>
            /// 
            /// <remarks>
            /// Images too large to process all at once are broken down into a framework.
            /// A frame represents what will be loaded into memory at any given time.
            /// </remarks>
            static public void Fill(string SourceFile, string DestFile, bool ShowProgressDialog)
            {
                MapWinUtility.Logger.Dbg("Fill(SourceFile: " + SourceFile + ",\n" +
                                        "     DestFile: " + DestFile + ",\n" +
                                        "     ShowProgressDialog: " + ShowProgressDialog.ToString());
                // 2000 width
                // 1000 height
                File_Fill(SourceFile, DestFile, true, ShowProgressDialog, 10000, 2000, null);
            }
            /// <summary>
            /// Fills the depressions in the SourceFile and saves the output to DestFile
            /// </summary>
            /// <param name="SourceFile">String filename: Input file</param>
            /// <param name="DestFile">String filename: Output file</param>
            /// <param name="Overwrite">Boolean, true to overwrite destfile and associated files silently, false to show a messagebox.</param>
            /// <param name="ShowProgressDialog">Boolean, True to display the progress dialog with status grid</param>
            /// <param name="FrameWidth">Integer, The width of the smaller grids to use</param>
            /// <param name="FrameHeight">Integer, The height of the sub-images to use</param>
            /// <param name="ICallBack">A MapWinGIS.ICallback for status messages</param>
            static public void Fill(string SourceFile, string DestFile, bool Overwrite, bool ShowProgressDialog, int FrameWidth, int FrameHeight, MapWinGIS.ICallback ICallBack)
            {
                MapWinUtility.Logger.Dbg("Fill(SourceFile: " + SourceFile + ",\n" +
                                        "     DestFile: " + DestFile + ",\n" +
                                        "     Overwrite: " + Overwrite.ToString() + ",\n" +
                                        "     ShowProgressDialog: " + ShowProgressDialog.ToString() + ",\n" +
                                        "     FrameWidth: " + FrameWidth.ToString() + ",\n" +
                                        "     FrameHeight: " + FrameHeight.ToString() + ",\n" +
                                        "     ICallBack)");
                File_Fill(SourceFile, DestFile, Overwrite, ShowProgressDialog, FrameWidth, FrameHeight, ICallBack);
            }
            //         |------------------------- GRIDS | DEFAULT FRAMES -----------------------------|
            /// <summary>
            /// /// Fills depressions in an image.
            /// - Grids obtained through parameters
            /// - Progress and status messages will be sent back via ICallBack
            /// - Frames will be sized to default values
            /// </summary>
            /// <param name="mwSourceGrid">MapWinGIS.Grid object to Fill</param>
            /// <param name="mwDestGrid">
            /// MapWinGIS.Grid object Output.
            /// Specifies output filename and extents.  Everything else will be obtained from original grid.
            /// </param>
            /// <param name="ICallBack">A MapWinGIS ICallback to receive errors and status messages</param>
            /// /// <remarks>
            /// Images too large to process all at once are broken down into a framework.
            /// A frame represents what will be loaded into memory at any given time.
            /// </remarks>
            static public void Fill(MapWinGIS.Grid mwSourceGrid, ref MapWinGIS.Grid mwDestGrid, MapWinGIS.ICallback ICallBack)
            {
                // 10000 Frame Width
                // 2000 Frame Height
                MapWinUtility.Logger.Dbg("Fill(mwSourceGrid: " + mwSourceGrid.Filename + ",\n" +
                                        "      mwDestGrid: " + mwDestGrid.Filename + ",\n" +
                                        "      ICallback");
                do_Fill(mwSourceGrid, ref mwDestGrid, false, 10000, 2000, ICallBack);
            }
            /// <summary>
            /// /// Fills depressions in an image.
            /// - Grids obtained through parameters
            /// - Progress will be shown through a dialog if ShowProgress is true
            /// - Frames will be sized to default values
            /// </summary>
            /// <param name="mwSourceGrid">MapWinGIS.Grid object to Fill</param>
            /// <param name="mwDestGrid">
            /// MapWinGIS.Grid object Output.
            /// Specifies output filename and extents.  Everything else will be obtained from original grid.
            /// </param>
            /// <param name="ShowProgressDialog">
            /// Boolean.  Function will display a dialog depicting progress if true.
            /// </param>
            /// /// <remarks>
            /// Images too large to process all at once are broken down into a framework.
            /// A frame represents what will be loaded into memory at any given time.
            /// </remarks>
            static public void Fill(MapWinGIS.Grid mwSourceGrid, ref MapWinGIS.Grid mwDestGrid, bool ShowProgressDialog)
            {
                // 10000 width
                // 2000 height
                MapWinUtility.Logger.Dbg("Fill(mwSourceGrid: " + mwSourceGrid.Filename + ",\n" +
                                        "      mwDestGrid: " + mwDestGrid.Filename + ",\n" +
                                        "      ShowProgressDialog: " + ShowProgressDialog.ToString());
                do_Fill(mwSourceGrid, ref mwDestGrid, ShowProgressDialog, 10000, 2000, null);
            }


            /// <summary>
            ///  Internal File handling
            /// </summary>
            static private void File_Fill(string SourceFile, string DestFile, bool Overwrite, bool ShowProgressDialog, int FrameWidth, int FrameHeight, MapWinGIS.ICallback ICallBack)
            {
                MapWinUtility.Logger.Dbg("Fill(mwSourceGrid: " + SourceFile.ToString() + ",\n" +
                                         "     mwDestFile: " + DestFile.ToString() + ",\n" +
                                         "     Overwrite: " + Overwrite + ",\n" +
                                         "     ShowProgressDialog: " + ShowProgressDialog + ",\n" +
                                         "     FrameWidth: " + FrameWidth.ToString() + ", \n" +
                                         "     FrameHeight: " + FrameHeight.ToString() + ", \n" +
                                         "     ICallback");
                MapWinGIS.Grid mwSourceGrid = new MapWinGIS.Grid();
                MapWinGIS.Grid mwDestGrid = new MapWinGIS.Grid();
                bool res;
                if (ICallBack != null) ICallBack.Progress("Status", 0, "Opening Files...");
                res = mwSourceGrid.Open(SourceFile, MapWinGIS.GridDataType.UnknownDataType, false, MapWinGIS.GridFileType.UseExtension, ICallBack);
                if (res == false)
                {
                    // I am not going to bother with ICallBack for errors.  I just use it for progress.
                    throw new ArgumentException(mwSourceGrid.get_ErrorMsg(mwSourceGrid.LastErrorCode));
                }
                // Delete any existing files for our output grid
                if (System.IO.File.Exists(DestFile))
                {
                    string bmp = System.IO.Path.ChangeExtension(DestFile, "bmp");
                    string bpw = System.IO.Path.ChangeExtension(DestFile, "bpw");
                    string prj = System.IO.Path.ChangeExtension(DestFile, "prj");
                    string mwleg = System.IO.Path.ChangeExtension(DestFile, "mwleg");
                    if (Overwrite == false)
                    {
                        if (System.IO.File.Exists(bmp) || System.IO.File.Exists(bpw) ||
                            System.IO.File.Exists(prj) || System.IO.File.Exists(mwleg))
                        {
                            if (MapWinUtility.Logger.Message("The output file exists, or associated files of the same name exist.  Do you wish to delete the existing files?\n", "Output Files Exist", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning, System.Windows.Forms.DialogResult.No) == System.Windows.Forms.DialogResult.No)
                            {
                                return;
                            }
                            // This ensures mapwindow will recognize the new image as a new file.
                            if (System.IO.File.Exists(bmp)) System.IO.File.Delete(bmp);
                            if (System.IO.File.Exists(bpw)) System.IO.File.Delete(bpw);
                            if (System.IO.File.Exists(prj)) System.IO.File.Delete(prj);
                            if (System.IO.File.Exists(mwleg)) System.IO.File.Delete(mwleg);
                        }
                        else
                        {
                            if (MapWinUtility.Logger.Message("The output file already exists.  Do you wish to delete it?", "Destination File Already Exists",
                                System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning, System.Windows.Forms.DialogResult.No)
                                == System.Windows.Forms.DialogResult.No) return;
                        }
                    }
                    else
                    {
                        if (System.IO.File.Exists(bmp)) System.IO.File.Delete(bmp);
                    }
                    System.IO.File.Delete(DestFile);
                }
                if (ICallBack != null) ICallBack.Progress("Status", 0, "Creating Output File...");
                MapWinGIS.GridHeader NewHeader = new MapWinGIS.GridHeader();
                NewHeader.CopyFrom(mwSourceGrid.Header);
                // Trying something new... Copy first and only edit a few cells: 2-12-07
                if (NewHeader.NumberCols * NewHeader.NumberRows > 64000000)
                {
                    if (System.IO.Path.GetExtension(SourceFile) != System.IO.Path.GetExtension(DestFile))
                    {
                        throw new ArgumentException("Images this large must have an output type that matches the input type.");
                    }
                    System.IO.File.Copy(SourceFile, DestFile);
                    mwDestGrid.Open(DestFile, MapWinGIS.GridDataType.FloatDataType, true, MapWinGIS.GridFileType.UseExtension, ICallBack);

                }
                else
                {
                    // This allows for more versitile file types, but tends to lock up if the file is too large.
                    res = mwDestGrid.CreateNew(DestFile, NewHeader, MapWinGIS.GridDataType.FloatDataType, float.MaxValue, true, MapWinGIS.GridFileType.UseExtension, ICallBack);
                }
                if (res == false)
                {
                    // I am not going to bother with ICallBack for errors.  I just use it for progress.
                    throw new ArgumentException(mwDestGrid.get_ErrorMsg(mwSourceGrid.LastErrorCode));
                }
                //mwDestGrid.Open(DestFile, MapWinGIS.GridDataType.FloatDataType, false, MapWinGIS.GridFileType.UseExtension, ICallBack);
                
               
                do_Fill(mwSourceGrid, ref mwDestGrid, ShowProgressDialog, FrameWidth, FrameHeight, ICallBack);
       
                res = mwDestGrid.Save(DestFile, MapWinGIS.GridFileType.UseExtension, ICallBack);
                if (res == false) throw new ArgumentException(mwDestGrid.get_ErrorMsg(mwDestGrid.LastErrorCode));
                
                mwSourceGrid.Close();
                mwDestGrid.Close();
            }


            const int UP = 1;
            const int DOWN = 2;
            const int LEFT = 3;
            const int RIGHT = 4;
            /// <summary>
            /// Performs a Pitfill.  Returns true unless the operation was canceled by the dialog
            /// </summary>
            private static void do_Fill(MapWinGIS.Grid mwSourceGrid, ref MapWinGIS.Grid mwDestGrid, bool ShowProgressDialog, int FrameWidth, int FrameHeight, MapWinGIS.ICallback ICallBack)
            {
                MapWinUtility.Logger.Dbg("do_Fill(mwSourceGrid: '" + mwSourceGrid.Filename + "\n" +
                    "', mwDestGrid: '" + mwDestGrid.Filename + "\n" +
                    "', ShowProgressDialog: " + ShowProgressDialog.ToString() + "\n" +
                    ", FrameWidth: " + FrameWidth.ToString() + "\n" +
                    ", FrameHeight: " + FrameHeight.ToString() + ", ICallback);\n");

                int numRows, numCols;
                numRows = mwSourceGrid.Header.NumberRows;
                numCols = mwSourceGrid.Header.NumberCols;
                Framework myFramework = new Framework(numCols, numRows, FrameWidth, FrameHeight);
                ProgressDialog myProgressDialog = new ProgressDialog();
                myProgressDialog.init(mwSourceGrid.Filename, mwDestGrid.Filename, myFramework);
                if (ShowProgressDialog == true)
                {
                    myProgressDialog.Show(); // Show but not modal... we will just use it to report progress.
                    myProgressDialog.DoEvents();
                }// Otherwise, we will use the dialog to relay messages, but we won't be drawing anything.

                myProgressDialog.CallBack = ICallBack; // from here on, ICallBack will be called from the dialog
                myProgressDialog.WriteMessage("Assigning Edges...\n");

                // We only need to do this if we are using the "create new" strategy
                if (numRows * numCols < 64000000)
                {
                    // assume that we can store at least one whole row in memory at once
                    float[] RowVals = new float[numCols];
                    float[] ColVals = new float[numRows];
                    // Copy first row
                    mwSourceGrid.GetFloatWindow(0, 0, 0, numCols - 1, ref RowVals[0]);
                    mwDestGrid.PutFloatWindow(0, 0, 0, numCols - 1, ref RowVals[0]);

                    // Copy last row 
                    mwSourceGrid.GetFloatWindow(numRows - 1, numRows - 1, 0, numCols - 1, ref RowVals[0]);
                    mwDestGrid.PutFloatWindow(numRows - 1, numRows - 1, 0, numCols - 1, ref RowVals[0]);
                    myProgressDialog.WriteMessage("Left Edge...\n");
                    mwSourceGrid.GetFloatWindow(1, numRows - 2, 0, 0, ref ColVals[0]);
                    mwDestGrid.PutFloatWindow(1, numRows - 2, 0, 0, ref ColVals[0]);

                    //Copy last column
                    myProgressDialog.WriteMessage("Right Edge...\n");
                    mwSourceGrid.GetFloatWindow(1, numRows - 2, numCols - 1, numCols - 1, ref ColVals[0]);
                    mwDestGrid.PutFloatWindow(1, numRows - 2, numCols - 1, numCols - 1, ref ColVals[0]);
                }
                myFramework.InitDependencyFiles(mwDestGrid.Filename);
                //mwDestGrid.Close();

                myProgressDialog.WriteMessage("Beginning Algorithm...\n");

                Frame myFrame = myFramework.First_Frame();
                int Total = myFramework.NumFramesTall * myFramework.NumFramesWide;
                int Count = 0;
                TimeSpan AlgTime = new TimeSpan();
                do
                {
                    List<Frame.Loc> Dependencies = new List<Frame.Loc>();
                   
                    if (myFrame.HasDependencies)
                    {
                        Dependencies = myFrame.get_Dependencies();

                        bool[] DepsExist = new bool[5];
                        myFrame.Status = Frame.StatusType.tkBeingEvaluated1;
                        myProgressDialog.ReDraw();
                        if (myProgressDialog.IsCanceled == true)
                        {
                            myFramework.DeleteFiles();
                            throw new ApplicationException("User Interrupt.");
                        }
                        if (myProgressDialog.IsPaused == true)
                        {
                            while (myProgressDialog.IsPaused == true)
                            {
                                System.Windows.Forms.Application.DoEvents();
                            }
                        }
                        myProgressDialog.WriteMessage("Frame: [" + myFrame.X.ToString() + "][" + myFrame.Y.ToString() + "] - ");
                        AlgTime += Algorithm.FloodDependencies(mwSourceGrid, mwDestGrid, Dependencies, myFrame, DepsExist, myProgressDialog);
                        myFrame.Status = Frame.StatusType.tkEvaluatedNoDependencies;
                    }
                    myFrame = myFramework.Next_Frame();
                    Count += 1;
                    myProgressDialog.Progress = (int)(Count * 100 / Total);
                } while (myFramework.HasDependencies == true);
                myProgressDialog.WriteMessage("TIME: " + AlgTime.Hours.ToString() + ", " + AlgTime.Minutes.ToString() + ", " + AlgTime.Seconds.ToString() + ", " + AlgTime.Milliseconds.ToString());
                myProgressDialog.ReDraw();
                myFramework.DeleteFiles();
                myProgressDialog.Hide();
                System.Windows.Forms.Application.DoEvents();
                MapWinUtility.Logger.Dbg("Finished do_Fill");
            } // End Fill 

            #endregion
       

        #region General Support Functions

        private void ReportProgress(string KeyOfSender, int Percent, string Message, MapWinGIS.ICallback ICallBack)
        {
            m_ErrorLog.LastLocation = Message;
            if (ICallBack == null) return; // ICallBack is where we are sending progress
            if (Percent < 0) Percent = 0;
            if (Percent > 100) Percent = 100; //ProgressBars don't like overflow percentages
            ICallBack.Progress(KeyOfSender, Percent, Message);

        }//End Report Progress


        // Handles ICallback as well as taking advantage of the Global Error object
        private void SetError(string Message)
        {
            Error.SetErrorMsg(Message);
            m_ErrorLog.LastErrorMessage = Message;
            m_ErrorLog.log.Append(Message);
            // ICallBack.Error("Error", Message);
        }//End SetError

        // Clears errors from both error tracking systems
        private void ClearErrors()
        {
            m_ErrorLog.clear();
            Error.ClearErrorLog();
        }

        #endregion

        #region Taudem and Custom Hydrology

        #region "Focus Mask"
        /// <summary>
        /// A hydrology function to clip by a mask grid
        /// </summary>
        /// <param name="DEMPath">Path to the DEM to clip</param>
        /// <param name="MaskGridPath">Path of the mask grid</param>
        /// <param name="MaskResultPath">Result grid</param>
        /// <param name="callback">Icallback for progress</param>
        /// <returns></returns>
        public static int Mask(string DEMPath, string MaskGridPath, string MaskResultPath, MapWinGIS.ICallback callback)
        {
            MapWinUtility.Logger.Dbg("Mask( DEMPath: " + DEMPath + ", \n" +
                                     "      MaskGridPath: " + MaskGridPath + ",\n" +
                                     "      MaskResultPath: " + MaskResultPath + ",\n" +
                                     "      ICallBack);\n");
            int result = -1;
            MapWinGIS.Shape tmpShape;
            MapWinGIS.Shapefile sf = new MapWinGIS.Shapefile();
            MapWinGIS.Grid g = new MapWinGIS.Grid();
            MapWinGIS.Grid gMasked = new MapWinGIS.Grid();
            MapWinGIS.GridHeader maskHead;
            MapWinGIS.GridHeader maskedHead;
            MapWinGIS.Utils u = new MapWinGIS.Utils();
            double currX;
            double currY;
            int currCol;
            int currRow;
            int newperc;
            int oldperc;
            newperc = 0;
            oldperc = 0;
            if (callback != null) callback.Progress("Status", 0, "Masking Grid");

            DataManagement.DeleteGrid(ref MaskResultPath);
                        
            g = new MapWinGIS.Grid();
            g.Open(MaskGridPath, MapWinGIS.GridDataType.UnknownDataType,true, MapWinGIS.GridFileType.UseExtension,callback);
            // This is OK for speed, but don't do something like make a new grid with this "reference copied" header.
            maskHead = g.Header;
            tmpShape = getShapeFromExtents(getGridExtents(g));
            if (SpatialOperations.ClipGridWithPolygon(ref DEMPath, ref tmpShape, ref MaskResultPath))
            {
                gMasked.Open(MaskResultPath, MapWinGIS.GridDataType.UnknownDataType, true, MapWinGIS.GridFileType.UseExtension, null);
                // This is OK for speed, but don't do something like make a new grid with this "reference copied" header.
                maskedHead = gMasked.Header;
                for (int row = 0; row <= maskHead.NumberRows - 1; row++)
                {
                    if (maskHead.NumberRows > 0)
                    {
                        newperc = Convert.ToInt32((Convert.ToDouble(row) / Convert.ToDouble(maskHead.NumberRows)) * 100);
                        if (newperc > oldperc)
                        {
                            callback.Progress("Status", newperc, "Masking Grid");
                            oldperc = newperc;
                        }
                    }
                    for (int col = 0; col <= maskHead.NumberCols - 1; col++)
                    {
                        g.CellToProj(col, row, out currX, out currY);
                        gMasked.ProjToCell(currX, currY, out currCol, out currRow);
                        if (double.Parse(g.get_Value(col, row).ToString()) == double.Parse(maskHead.NodataValue.ToString()))
                        {
                            gMasked.set_Value(currCol, currRow,maskedHead.NodataValue);
                        }
                    }
                }
                gMasked.Save(MaskResultPath,MapWinGIS.GridFileType.Binary,callback);
                gMasked.Close();
            }
            g.Close();
            result = 0;
            if (callback != null) callback.Progress("Status", 0, "");
            MapWinUtility.Logger.Dbg("Finished Mask");
            return result;
        }

        /// <summary>
        /// A hydrology function to clip by shapefile
        /// </summary>
        /// <param name="DEMPath">Path to the dem to clip</param>
        /// <param name="MaskShapePath">path to the shape path</param>
        /// <param name="SelectedIndexesList">Arraylist of selected integer indexes from shapefile</param>
        /// <param name="MaskResultPath">Result of the masking</param>
        /// <param name="callback">Icallback for progress</param>
        /// <returns></returns>
        public static int Mask(string DEMPath, string MaskShapePath, ArrayList SelectedIndexesList, string MaskResultPath, MapWinGIS.ICallback callback)
        {
            MapWinUtility.Logger.Dbg("Mask( DEMPath: " + DEMPath + ", \n" + 
                                     "      MaskShapePath: " + MaskShapePath + ",\n" +  
                                     "      MaskResultPath: " + MaskResultPath + ",\n" +
                                     "      ICallBack);\n");
            int result = -1;
            string maskclipPath;
            string tmpPath;
            MapWinGIS.Shape tmpShape;
            MapWinGIS.Shapefile sf = new MapWinGIS.Shapefile();
            MapWinGIS.Grid g = new MapWinGIS.Grid();
            MapWinGIS.Grid gMasked = new MapWinGIS.Grid();
            MapWinGIS.Grid[] grids;
            MapWinGIS.Utils u = new MapWinGIS.Utils();
            int newperc;
            int oldperc;
            oldperc = 0;
            newperc = 0;

            if (SelectedIndexesList.Count > 0)
            {
                if (callback != null) callback.Progress("Status", 0, "Masking Grid");
                DataManagement.DeleteGrid(ref MaskResultPath);
                MapWinGIS.Grid demGrid = new MapWinGIS.Grid();
                demGrid.Open(DEMPath, MapWinGIS.GridDataType.UnknownDataType, true, MapWinGIS.GridFileType.UseExtension, callback);
                string projStr = demGrid.Header.Projection;
                demGrid.Close();

                sf.Open(MaskShapePath, null);
                if (SelectedIndexesList.Count == 1)
                {
                    tmpShape = sf.get_Shape((int)SelectedIndexesList[0]);
                    if (SpatialOperations.ClipGridWithPolygon(ref DEMPath, ref tmpShape, ref MaskResultPath))
                    {
                        result = 0;
                    }
                }
                else if (SelectedIndexesList.Count > 1)
                {
                    grids = new MapWinGIS.Grid[SelectedIndexesList.Count];
                    for (int i = 0; i <= SelectedIndexesList.Count - 1; i++)
                    {
                        if (SelectedIndexesList.Count > 0)
                        {
                            newperc = Convert.ToInt32((Convert.ToDouble(i) / Convert.ToDouble(SelectedIndexesList.Count)) * 100);
                            if (newperc > oldperc)
                            {
                                callback.Progress("Status", newperc, "Masking Grid");
                                oldperc = newperc;
                            }
                        }
                        maskclipPath = System.IO.Path.GetDirectoryName(MaskResultPath) + System.IO.Path.DirectorySeparatorChar + System.IO.Path.GetFileNameWithoutExtension(MaskResultPath) + "_" + i.ToString() + ".bgd";
                        tmpShape = sf.get_Shape((int)SelectedIndexesList[i]);
                        if (SpatialOperations.ClipGridWithPolygon(ref DEMPath, ref tmpShape, ref maskclipPath))
                        {
                            g = new MapWinGIS.Grid();
                            g.Open(maskclipPath, MapWinGIS.GridDataType.UnknownDataType, true, MapWinGIS.GridFileType.UseExtension, callback);
                            g.Header.Projection = projStr;
                            grids[i] = g;
                        }
                    }
                    g = u.GridMerge(grids, MaskResultPath, true, MapWinGIS.GridFileType.UseExtension, null);
                    g.Save(MaskResultPath, MapWinGIS.GridFileType.UseExtension, callback);
                    g.Close();
                    for (int i = 0; i <= SelectedIndexesList.Count - 1; i++)
                    {
                        tmpPath = grids[i].Filename;
                        grids[i].Close();
                        DataManagement.DeleteGrid(ref tmpPath);
                    }
                }
                sf.Close();
                result = 0;
                if (callback != null) callback.Progress("Status", 0, "");
            }
            MapWinUtility.Logger.Dbg("Finished Mask");
            return result;
        }

        /// <summary>
        /// A hydrology function to clip by extents
        /// </summary>
        /// <param name="DEMPath">Path to the grid to mask</param>
        /// <param name="MaskExtents">Path to the extents to mask by</param>
        /// <param name="MaskResultPath">Path to the Resulting masked file</param>
        /// <param name="callback">Icallback for progress</param>
        /// <returns>0 on success, -1 on fail</returns>
        public static int Mask(string DEMPath, MapWinGIS.Extents MaskExtents, string MaskResultPath, MapWinGIS.ICallback callback)
        {
            MapWinUtility.Logger.Dbg("Mask( DEMPath: " + DEMPath + ", \n" +
                                     "      MaskExtents: " + MaskExtents + ",\n" +
                                     "      MaskResultPath: " + MaskResultPath + ",\n" +
                                     "      ICallBack);\n");
            int result = -1;
            MapWinGIS.Shape tmpShape;
            if (callback != null) callback.Progress("Status", 0, "Masking Grid");
            DataManagement.DeleteGrid(ref MaskResultPath);

            tmpShape = getShapeFromExtents(MaskExtents);
            if (MapWinGeoProc.SpatialOperations.ClipGridWithPolygon(ref DEMPath, ref tmpShape, ref MaskResultPath))
            {
                result = 0;
            }
            if (callback != null) callback.Progress("Status", 0, "");
            MapWinUtility.Logger.Dbg("Finished Mask");
            return result;
        }
        #endregion

        #region "Canyon Burn-in"
        /// <summary>
        /// Hydrology burnin function to lower DEM cell values along a given stream polyline
        /// </summary>
        /// <param name="StreamNetShapePath">Path to the stream polyline</param>
        /// <param name="DEMPath">Path to the DEM to burn</param>
        /// <param name="BurnedDEMResultPath">Resultant burned DEM</param>
        /// <param name="callback">Icallback for progress</param>
        /// <returns>0 on success -1 on fail</returns>
        public static int CanyonBurnin(string StreamNetShapePath, string DEMPath, string BurnedDEMResultPath, MapWinGIS.ICallback callback)
        {
            MapWinUtility.Logger.Dbg("CanyonBurnin( StreamNetShapePath: " + StreamNetShapePath + ", \n" +
                                    "      DEMPath: " + DEMPath + ",\n" +
                                    "      BurnedDEMResultPath: " + BurnedDEMResultPath + ",\n" +
                                    "      ICallBack);\n");
            int result = -1;
            MapWinGIS.Shapefile lineShape = new MapWinGIS.Shapefile();
            MapWinGIS.Grid gridDem = new MapWinGIS.Grid();
            MapWinGIS.Grid gridTrack = new MapWinGIS.Grid();
            MapWinGIS.Utils u = new MapWinGIS.Utils();
            int y0;
            int y1;
            int x0;
            int x1;
            int swap;
            int deltax;
            int deltay;
            int err;
            int deltaerr;
            int x;
            int y;
            int ystep;
            double setVal;
            double nodata;
            double currVal;
            bool steep;
            bool subval;
            int i;
            int j;
            MapWinGIS.Shape tmpShape;
            int newperc;
            int oldperc;
            string strGridTrack;

            newperc = 0;
            oldperc = 0;
            
            //Used if assigning a flat value or subtracting 
            subval = true;
            if (subval)
            {
                setVal = 50;
            }
            else
            {
                setVal = double.Parse(gridDem.Minimum.ToString()) - 1;
            }
            gridDem.Open(DEMPath,MapWinGIS.GridDataType.UnknownDataType,true, MapWinGIS.GridFileType.UseExtension,callback);
            gridDem.Save(BurnedDEMResultPath, MapWinGIS.GridFileType.UseExtension, null);
            nodata = double.Parse(gridDem.Header.NodataValue.ToString());
            strGridTrack = System.IO.Path.GetDirectoryName(DEMPath) + System.IO.Path.DirectorySeparatorChar + System.IO.Path.GetFileNameWithoutExtension(DEMPath) + "_track.bgd";

            // Chris M 12/14/2006 -- do not create a new grid with a direct reference to an old grid's header
            // gridTrack.CreateNew(strGridTrack, gridDem.Header, MapWinGIS.GridDataType.DoubleDataType, nodata,true, MapWinGIS.GridFileType.UseExtension,callback);
            MapWinGIS.GridHeader newHeader = new MapWinGIS.GridHeader();
            newHeader.CopyFrom(gridDem.Header);
            gridTrack.CreateNew(strGridTrack, newHeader, MapWinGIS.GridDataType.DoubleDataType, nodata, true, MapWinGIS.GridFileType.UseExtension, callback);

            MapWinGIS.Extents ext = getGridExtents(gridDem);
            Topology2D.Envelope gridExt = new Topology2D.Envelope(ext);
            Topology2D.Envelope shapeExt;
            lineShape.Open(StreamNetShapePath, callback);

            //tmpShape = getShapeFromExtents(ext);
            //string tmpClipLinePath = System.IO.Path.GetDirectoryName(StreamNetShapePath) + System.IO.Path.DirectorySeparatorChar + System.IO.Path.GetFileNameWithoutExtension(StreamNetShapePath) + "_tmpclip.shp";
            //SpatialOperations.ClipShapesWithPolygon(ref StreamNetShapePath, ref tmpShape, ref tmpClipLinePath,true);
            //lineShape.Open(tmpClipLinePath, callback);
                        
            for (i = 0; i <= lineShape.NumShapes - 1; i++)
            {
                if (lineShape.NumShapes > 1)
                {
                    newperc = Convert.ToInt32((Convert.ToDouble(i) / Convert.ToDouble(lineShape.NumShapes)) * 100);
                    if (newperc > oldperc)
                    {
                        callback.Progress("Status", newperc, "Burn-in");
                        oldperc = newperc;
                    }
                }
                tmpShape = lineShape.get_Shape(i);
                shapeExt = new Topology2D.Envelope(tmpShape.Extents);

                if (gridExt.Intersects(shapeExt))
                {
                    for (j = 1; j <= tmpShape.numPoints - 1; j++)
                    {
                        gridDem.ProjToCell(tmpShape.get_Point(j - 1).x, tmpShape.get_Point(j - 1).y, out x0, out y0);
                        gridDem.ProjToCell(tmpShape.get_Point(j).x, tmpShape.get_Point(j).y, out x1, out y1);
                        steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
                        if (steep)
                        {
                            swap = x0;
                            x0 = y0;
                            y0 = swap;
                            swap = x1;
                            x1 = y1;
                            y1 = swap;
                        }
                        if (x0 > x1)
                        {
                            swap = x0;
                            x0 = x1;
                            x1 = swap;
                            swap = y0;
                            y0 = y1;
                            y1 = swap;
                        }
                        deltax = x1 - x0;
                        deltay = Math.Abs(y1 - y0);
                        err = 0;
                        deltaerr = deltay;
                        y = y0;
                        if (y0 < y1)
                        {
                            ystep = 1;
                        }
                        else
                        {
                            ystep = -1;
                        }
                        for (x = x0; x <= x1; x++)
                        {
                            if (steep)
                            {
                                if (double.Parse(gridTrack.get_Value(y, x).ToString()) != 1.0)
                                {
                                    currVal = double.Parse(gridDem.get_Value(y, x).ToString());
                                    if (nodata < 0)
                                    {
                                        if (currVal > nodata)
                                        {
                                            gridTrack.set_Value(y, x, 1);
                                            if (subval)
                                            {
                                                gridDem.set_Value(y, x, currVal - setVal);
                                            }
                                            else
                                            {
                                                gridDem.set_Value(y, x, setVal);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (currVal < nodata)
                                        {
                                            gridTrack.set_Value(y, x, 1);
                                            if (subval)
                                            {
                                                gridDem.set_Value(y, x, currVal - setVal);
                                            }
                                            else
                                            {
                                                gridDem.set_Value(y, x, setVal);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (double.Parse(gridTrack.get_Value(x, y).ToString()) != 1.0)
                                {
                                    currVal = double.Parse(gridDem.get_Value(x, y).ToString());
                                    if (nodata < 0)
                                    {
                                        if (currVal > nodata)
                                        {
                                            gridTrack.set_Value(x, y, 1);
                                            if (subval)
                                            {
                                                gridDem.set_Value(x, y, currVal - setVal);
                                            }
                                            else
                                            {
                                                gridDem.set_Value(x, y, setVal);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (currVal < nodata)
                                        {
                                            gridTrack.set_Value(y, x, 1);
                                            if (subval)
                                            {
                                                gridDem.set_Value(y, x, currVal - setVal);
                                            }
                                            else
                                            {
                                                gridDem.set_Value(y, x, setVal);
                                            }
                                        }
                                    }
                                }
                            }
                            err = err + deltaerr;
                            if (2 * err >= deltax)
                            {
                                y = y + ystep;
                                err = err - deltax;
                            }
                        }
                    }
                }
                MapWinUtility.Logger.Dbg("Finished Mask");
            }
            gridDem.Save(BurnedDEMResultPath,MapWinGIS.GridFileType.UseExtension,null);
            result = 0;
            lineShape.Close();
            //DataManagement.DeleteShapefile(ref tmpClipLinePath);
            gridDem.Close();
            gridTrack.Close();
            callback.Progress("Status", 0, "");
            DataManagement.DeleteGrid(ref strGridTrack);
            MapWinUtility.Logger.Dbg("Finished CanyonBurnin");
            return result;
        }
        #endregion

        #region "D8"
        /// <summary>
        /// Not Implemented
        /// Generates a D8 directional grid by assigning a number from 1 to 8 (0 to 7 in some algorithms) based on a direction to the lowest elevation cell surrounding that cell.
        /// </summary>
        /// <param name="PitFillPath">Path of a pit-filled DEM.</param>
        /// <param name="D8ResultPath">Output result file of a D8 directional grid.</param>
        /// <param name="D8SlopeResultPath">Path to an output grid containing the slope from the cell to the lowest elevation surrounding cell.</param>
        /// <param name="tauCallback"> A taudem callback object for internal status messages</param>
        /// <returns>Integer representing successful creation on 0 or some error state otherwise.</returns>
        public static int D8(string PitFillPath, string D8ResultPath, string D8SlopeResultPath, TKTAUDEMLib.ItkCallback tauCallback)
        {
            MapWinUtility.Logger.Dbg("D8(PitFillPath: " + PitFillPath + "\n" +
                                     "   D8ResultPath: " + D8ResultPath + "\n" +
                                     "   D8SlopeResultPath: " + D8SlopeResultPath + "\n" +
                                     "   tauCallback)");
            int result = -1;
            short usefdrfile = 0;
            bool inRam = true;
            
            DataManagement.DeleteGrid(ref D8ResultPath);
            DataManagement.DeleteGrid(ref D8SlopeResultPath);

            TKTAUDEMLib.TauDEM TaudemLib = new TKTAUDEMLib.TauDEM();
            if (tauCallback != null) TaudemLib.Callback = tauCallback;
            result = TaudemLib.D8(PitFillPath, D8ResultPath, D8SlopeResultPath, "", usefdrfile, inRam);
            if (result != 0)
            {
                MapWinUtility.Logger.Message(TaudemLib.getErrorMsg(result), "TauDEM Error " + result, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.DialogResult.OK);
            }
            CopyProjectionFromGrid(PitFillPath, D8ResultPath);
            CopyProjectionFromGrid(PitFillPath, D8SlopeResultPath);
            if (tauCallback != null) tauCallback.Progress("Status", 0, "");
            MapWinUtility.Logger.Dbg("Finished D8");
            return result;
        }

        /// <summary>
        /// An overload of D8 which will generate a GeoprocDialog and execute the d8 from that.
        /// </summary>
        /// <param name="tauCallback"></param>
        /// <returns></returns>
        public static int D8(TKTAUDEMLib.ItkCallback tauCallback)
        {
            return doD8Diag(tauCallback);
        }

        /// <summary>
        /// An overload of D8 which will generate a GeoprocDialog and execute the d8 from that.
        /// </summary>
        /// <returns></returns>
        public static int D8()
        {
            return doD8Diag(null);
        }

        private static int doD8Diag(TKTAUDEMLib.ItkCallback tauCallback)
        {
            MapWinUtility.Logger.Dbg("doD8Diag(tauCallback)");
            GeoProcDialog d8Diag = new GeoProcDialog();
            FileElement pitFillElem = d8Diag.Add_FileElement(GeoProcDialog.ElementTypes.OpenGridFile);
            FileElement d8ResElem = d8Diag.Add_FileElement(GeoProcDialog.ElementTypes.SaveGridFile);
            FileElement d8SlopeResElem = d8Diag.Add_FileElement(GeoProcDialog.ElementTypes.SaveGridFile);

            d8Diag.Text = "D8 Flow Directions and Slopes";
            d8Diag.HelpTitle = "D8 Flow Directions and Slopes";
            d8Diag.HelpText = "This function will generate a grid of D8 flow directions and a grid of slopes, given a pit-filled DEM.";
            d8Diag.Height = 250;
            d8Diag.HelpPanelVisible = false;

            pitFillElem.Caption = "Pit Filled DEM Path";
            pitFillElem.HelpButtonVisible = false;

            d8ResElem.Caption = "D8 Flow Direction Grid Result Path";
            d8ResElem.HelpButtonVisible = false;

            d8SlopeResElem.Caption = "D8 Slope Grid Result Path";
            d8SlopeResElem.HelpButtonVisible = false;

            if (d8Diag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return Hydrology.D8(pitFillElem.Filename, d8ResElem.Filename, d8SlopeResElem.Filename, tauCallback);
            }
            MapWinUtility.Logger.Dbg("Finished doD8Diag");
            return -2;
        }
        #endregion

        #region "AreaD8"
        /// <summary>
        /// Not Implemented
        /// Generates an area D8 grid which shows the paths of highest flow and can be used to delineate stream networks.
        /// </summary>
        /// <param name="D8Path">Path to a D8 grid to be converted into an area D8 grid.</param>
        /// <param name="OutletsPath">Optional path to a point shape file which is used to designate outlet points on a grid. If this path is given, the resulting area D8 grid will only include values for those areas of the grid which flow into the outlet points given. All other portions of the grid will be set to 0.</param>
        /// <param name="AreaD8ResultPath">Path to an area D8 output grid, </param>
        /// <param name="UseOutlets">Boolean true for using outlets in delineation d8 areas</param>
        /// <param name="UseEdgeContamCheck">Boolean true to ignore off-grid contributing area</param>
        /// <param name="tauCallback"> A taudem callback object for internal status messages</param>
        /// <returns>Integer representing successful creation on 0 or some error state otherwise.</returns>
        public static int AreaD8(string D8Path, string OutletsPath, string AreaD8ResultPath, bool UseOutlets, bool UseEdgeContamCheck, TKTAUDEMLib.ItkCallback tauCallback)
        {
            MapWinUtility.Logger.Dbg("AreaD8(D8Path: " + D8Path + ",\n" +
                                     "       OutletsPath: " + OutletsPath + ",\n" +
                                     "       AreaD8ResultPath: " + AreaD8ResultPath + ",\n" +
                                     "       UseOutlets: " + UseOutlets.ToString() + ",\n" +
                                     "       UseEdgeContamCheck: " + UseEdgeContamCheck.ToString() + "\n" +
                                     "       tauCallback)");
            double[] X = { 0.0 };
            double[] Y = { 0.0 };
            int ArraySize = 0;
            int result = -1;
            int contcheck = 0;
            if (UseEdgeContamCheck) contcheck = 1;
            DataManagement.DeleteGrid(ref AreaD8ResultPath);

            TKTAUDEMLib.TauDEM TaudemLib = new TKTAUDEMLib.TauDEM();
            if (tauCallback != null) TaudemLib.Callback = tauCallback;

            if (UseOutlets)
            {
                if (ShapefileToArrays(OutletsPath, ref X, ref Y, ref ArraySize) == false)
                {
                    return -1;
                }
                result = TaudemLib.Aread8(D8Path, AreaD8ResultPath, ref X[0], ref Y[0], ArraySize, 0, D8Path, 0, contcheck);
            }
            else
            {

                result = TaudemLib.Aread8(D8Path, AreaD8ResultPath, ref X[0], ref Y[0], 0, 1, D8Path, 0, contcheck);
            }


            if (result != 0)
            {
                MapWinUtility.Logger.Message(TaudemLib.getErrorMsg(result), "TauDEM Error " + result, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.DialogResult.OK);
            }
            CopyProjectionFromGrid(D8Path, AreaD8ResultPath);
            if (tauCallback != null) tauCallback.Progress("Status", 0, "");
            MapWinUtility.Logger.Dbg("Finished AreaD8");
            return result;
        }

        /// <summary>
        /// An overload of the AreaD8 function which will generate a GeoprocDialog for the AreaD8 function
        /// </summary>
        /// <param name="tauCallback"></param>
        /// <returns></returns>
        public static int AreaD8(TKTAUDEMLib.ItkCallback tauCallback)
        {
            return doAreaD8Diag(tauCallback);
        }

        /// <summary>
        /// An overload of the AreaD8 function which will generate a GeoprocDialog for the AreaD8 function
        /// </summary>
        /// <returns></returns>
        public static int AreaD8()
        {
            return doAreaD8Diag(null);
        }

        private static int doAreaD8Diag(TKTAUDEMLib.ItkCallback tauCallback)
        {
            MapWinUtility.Logger.Dbg("doAreaD8Diag(tauCallback)");
            GeoProcDialog ad8Diag = new GeoProcDialog();
            FileElement d8Elem = ad8Diag.Add_FileElement(GeoProcDialog.ElementTypes.OpenGridFile);
            BooleanElement useOutletsElem = ad8Diag.Add_BooleanElement();
            FileElement outletsElem = ad8Diag.Add_FileElement(GeoProcDialog.ElementTypes.OpenShapefile);
            BooleanElement useEdgeElem = ad8Diag.Add_BooleanElement();
            FileElement ad8ResElem = ad8Diag.Add_FileElement(GeoProcDialog.ElementTypes.SaveGridFile);

            ad8Diag.Text = "D8 Flow Accumulation/Contributing Area";
            ad8Diag.HelpTitle = "D8 Flow Accumulation/Contributing Area";
            ad8Diag.HelpText = "This function will generate a grid of flow accumulations from a given D8 flow direction grid.";
            ad8Diag.Height = 350;
            ad8Diag.HelpPanelVisible = false;

            d8Elem.Caption = "D8 Flow Direction Grid Path";
            d8Elem.HelpButtonVisible = false;

            useOutletsElem.Caption = "Use Outlets/Inlets Shapefile";
            useOutletsElem.Text = "Use Outlets/Inlets";
            useOutletsElem.HelpButtonVisible = false;

            outletsElem.Caption = "Outlets/Inlets Point Shapefile Path (optional)";
            outletsElem.HelpButtonVisible = false;
            outletsElem.HaltOnEmpty = false;

            useEdgeElem.Caption = "Check for Edge Contamination";
            useEdgeElem.Text = "Use Edge Contamination Check";
            useEdgeElem.HelpButtonVisible = false;

            ad8ResElem.Caption = "D8 Contributing Area Grid Result Path";
            ad8ResElem.HelpButtonVisible = false;


            if (ad8Diag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return Hydrology.AreaD8(d8Elem.Filename, outletsElem.Filename, ad8ResElem.Filename, useOutletsElem.Value, useEdgeElem.Value, tauCallback);
            }
            MapWinUtility.Logger.Dbg("Finished doAreaD8Diag");
            return -2;
            
        }
        #endregion

        #region "Dinf"
        /// <summary>
        /// A function to call the Taudem d-infinity calculations
        /// </summary>
        /// <param name="PitFillPath"></param>
        /// <param name="DInfResultPath"></param>
        /// <param name="DInfSlopeResultPath"></param>
        /// <param name="tauCallback"></param>
        /// <returns></returns>
        public static int DInf(string PitFillPath, string DInfResultPath, string DInfSlopeResultPath, TKTAUDEMLib.ItkCallback tauCallback)
        {

            MapWinUtility.Logger.Dbg("Dinf(PitFillPath: " + PitFillPath + ",\n" +
                                    "       DInfResultPath: " + DInfResultPath + ",\n" +
                                    "       DInfSlopeResultPath: " + DInfSlopeResultPath + ",\n" +
                                    "       tauCallback)");
            int result = -1;
            short usefdrfile = 0;
            bool inRam = true;

            DataManagement.DeleteGrid(ref DInfResultPath);
            DataManagement.DeleteGrid(ref DInfSlopeResultPath);

            TKTAUDEMLib.TauDEM TaudemLib = new TKTAUDEMLib.TauDEM();
            if (tauCallback != null) TaudemLib.Callback = tauCallback;
            result = TaudemLib.Dinf(PitFillPath, DInfResultPath, DInfSlopeResultPath, "", usefdrfile, inRam);
            if (result != 0)
            {
                
                MapWinUtility.Logger.Message(TaudemLib.getErrorMsg(result), "TauDEM Error " + result, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.DialogResult.OK);
            }
            CopyProjectionFromGrid(PitFillPath, DInfResultPath);
            CopyProjectionFromGrid(PitFillPath, DInfSlopeResultPath);
            if (tauCallback != null) tauCallback.Progress("Status", 0, "");
            MapWinUtility.Logger.Dbg("Finished DInf");
            return result;
        }
 
        /// <summary>
        /// An overload of Dinf which will generate a GeoprocDialog and execute the dinf from that.
        /// </summary>
        /// <param name="tauCallback"></param>
        /// <returns></returns>
        public static int DInf(TKTAUDEMLib.ItkCallback tauCallback)
        {
            return doDInfDiag(tauCallback);
        }

        /// <summary>
        /// An overload of Dinf which will generate a GeoprocDialog and execute the dinf from that.
        /// </summary>
        /// <returns></returns>
        public static int DInf()
        {
            return doDInfDiag(null);
        }

        private static int doDInfDiag(TKTAUDEMLib.ItkCallback tauCallback)
        {
            GeoProcDialog dinfDiag = new GeoProcDialog();
            FileElement pitFillElem = dinfDiag.Add_FileElement(GeoProcDialog.ElementTypes.OpenGridFile);
            FileElement dinfResElem = dinfDiag.Add_FileElement(GeoProcDialog.ElementTypes.SaveGridFile);
            FileElement dinfSlopeResElem = dinfDiag.Add_FileElement(GeoProcDialog.ElementTypes.SaveGridFile);

            dinfDiag.Text = "D-Infinity Flow Directions and Slopes";
            dinfDiag.HelpTitle = "D-Infinity Flow Directions and Slopes";
            dinfDiag.HelpText = "This function will generate a grid of D-infinity flow directions and a grid of slopes, given a pit-filled DEM.";
            dinfDiag.Height = 250;
            dinfDiag.HelpPanelVisible = false;

            pitFillElem.Caption = "Pit Filled DEM Path";
            pitFillElem.HelpButtonVisible = false;

            dinfResElem.Caption = "D-Infinity Flow Direction Grid Result Path";
            dinfResElem.HelpButtonVisible = false;

            dinfSlopeResElem.Caption = "D-Infinity Slope Grid Result Path";
            dinfSlopeResElem.HelpButtonVisible = false;

            if (dinfDiag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return Hydrology.DInf(pitFillElem.Filename, dinfResElem.Filename, dinfSlopeResElem.Filename, tauCallback);
            }
            return -2;
        }
        #endregion

        #region "AreaDinf"
        /// <summary>
        /// Function to call the Taudem AreaDinfDecay function
        /// </summary>
        /// <param name="DInfPath"></param>
        /// <param name="OutletsPath"></param>
        /// <param name="AreaDInfResultPath"></param>
        /// <param name="UseOutlets"></param>
        /// <param name="UseEdgeContamCheck"></param>
        /// <param name="tauCallback"></param>
        /// <returns></returns>
        public static int AreaDInf(string DInfPath, string OutletsPath, string AreaDInfResultPath, bool UseOutlets, bool UseEdgeContamCheck, TKTAUDEMLib.ItkCallback tauCallback)
        {
            MapWinUtility.Logger.Dbg("AreaDInf(DInfPath: " + DInfPath + "\n " +
                                     "OutletsPath: " + OutletsPath + "\n" +
                                     "AreaDInfResultPath: " + AreaDInfResultPath + "\n" + 
                                     "UseOutlets: " + UseOutlets.ToString() + "\n" +
                                     "UseEdgeContamCheck: " + UseEdgeContamCheck.ToString() + "\n" +
                                     "tauCallback)");
            double[] X = { 0.0 };
            double[] Y = { 0.0 };
            int ArraySize = 0;
            int result = -1;
            int contcheck = 0;
            if (UseEdgeContamCheck) contcheck = 1;
            DataManagement.DeleteGrid(ref AreaDInfResultPath);

            TKTAUDEMLib.TauDEM TaudemLib = new TKTAUDEMLib.TauDEM();
            if (tauCallback != null) TaudemLib.Callback = tauCallback;

            if (UseOutlets)
            {
                if (ShapefileToArrays(OutletsPath, ref X, ref Y, ref ArraySize) == false)
                {
                    return -1;
                }
                result = TaudemLib.Areadinf(DInfPath, AreaDInfResultPath, ref X[0], ref Y[0], ArraySize, 0, "", 0, contcheck);
            }
            else
            {

                result = TaudemLib.Areadinf(DInfPath, AreaDInfResultPath, ref X[0], ref Y[0], 0, 1, "", 0, contcheck);
            }

            if (result != 0)
            {
                
                MapWinUtility.Logger.Message(TaudemLib.getErrorMsg(result), "TauDEM Error " + result, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.DialogResult.OK);
            }
            CopyProjectionFromGrid(DInfPath, AreaDInfResultPath);
            if (tauCallback != null) tauCallback.Progress("Status", 0, "");
            MapWinUtility.Logger.Dbg("Finsihed AreaDInf");
            return result;
        }

        /// <summary>
        /// An overload of the AreaDInf function which will generate a GeoprocDialog for the AreaDInf function
        /// </summary>
        /// <param name="tauCallback"></param>
        /// <returns></returns>
        public static int AreaDInf(TKTAUDEMLib.ItkCallback tauCallback)
        {
            return doAreaDInfDiag(tauCallback);
        }

        /// <summary>
        /// An overload of the AreaDInf function which will generate a GeoprocDialog for the AreaDInf function
        /// </summary>
        /// <returns></returns>
        public static int AreaDInf()
        {
            return doAreaDInfDiag(null);
        }

        private static int doAreaDInfDiag(TKTAUDEMLib.ItkCallback tauCallback)
        {
            GeoProcDialog adinfDiag = new GeoProcDialog();
            FileElement dinfElem = adinfDiag.Add_FileElement(GeoProcDialog.ElementTypes.OpenGridFile);
            BooleanElement useOutletsElem = adinfDiag.Add_BooleanElement();
            FileElement outletsElem = adinfDiag.Add_FileElement(GeoProcDialog.ElementTypes.OpenShapefile);
            BooleanElement useEdgeElem = adinfDiag.Add_BooleanElement();
            FileElement adinfResElem = adinfDiag.Add_FileElement(GeoProcDialog.ElementTypes.SaveGridFile);

            adinfDiag.Text = "D-Infinity Flow Accumulation/Contributing Area";
            adinfDiag.HelpTitle = "D-Infinity Flow Accumulation/Contributing Area";
            adinfDiag.HelpText = "This function will generate a grid of flow accumulations from a given D-Infinity flow direction grid.";
            adinfDiag.Height = 350;
            adinfDiag.HelpPanelVisible = false;

            dinfElem.Caption = "D-Infinity Flow Direction Grid Path";
            dinfElem.HelpButtonVisible = false;

            useOutletsElem.Caption = "Use Outlets/Inlets Shapefile";
            useOutletsElem.Text = "Use Outlets/Inlets";
            useOutletsElem.HelpButtonVisible = false;

            outletsElem.Caption = "Outlets/Inlets Point Shapefile Path (optional)";
            outletsElem.HelpButtonVisible = false;
            outletsElem.HaltOnEmpty = false;

            useEdgeElem.Caption = "Check for Edge Contamination";
            useEdgeElem.Text = "Use Edge Contamination Check";
            useEdgeElem.HelpButtonVisible = false;

            adinfResElem.Caption = "D-Infinity Contributing Area Grid Result Path";
            adinfResElem.HelpButtonVisible = false;


            if (adinfDiag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return Hydrology.AreaDInf(dinfElem.Filename, outletsElem.Filename, adinfResElem.Filename, useOutletsElem.Value, useEdgeElem.Value, tauCallback);
            }
            return -2;
        }
        #endregion

        #region "Delin Stream Grids"
        /// <summary>
        /// A function which will make appropriate calls to Taudem in order to form the network grids used in delineation
        /// </summary>
        /// <param name="DemGridPath"></param>
        /// <param name="PitFillPath"></param>
        /// <param name="D8Path"></param>
        /// <param name="D8SlopePath"></param>
        /// <param name="AreaD8Path"></param>
        /// <param name="OutletsPath"></param>
        /// <param name="StrahlOrdResultPath"></param>
        /// <param name="LongestUpslopeResultPath"></param>
        /// <param name="TotalUpslopeResultPath"></param>
        /// <param name="StreamGridResultPath"></param>
        /// <param name="StreamOrdResultPath"></param>
        /// <param name="TreeDatResultPath"></param>
        /// <param name="CoordDatResultPath"></param>
        /// <param name="Threshold"></param>
        /// <param name="UseOutlets"></param>
        /// <param name="UseEdgeContamCheck"></param>
        /// <param name="tauCallback"></param>
        /// <returns></returns>
        public static int DelinStreamGrids(string DemGridPath, string PitFillPath, string D8Path, string D8SlopePath, string AreaD8Path, string OutletsPath, string StrahlOrdResultPath, string LongestUpslopeResultPath, string TotalUpslopeResultPath, string StreamGridResultPath, string StreamOrdResultPath, string TreeDatResultPath, string CoordDatResultPath, int Threshold, bool UseOutlets, bool UseEdgeContamCheck, TKTAUDEMLib.ItkCallback tauCallback)
        {
            return runDelinStreamGrids(DemGridPath, PitFillPath, D8Path, D8SlopePath, AreaD8Path, "", OutletsPath, StrahlOrdResultPath, LongestUpslopeResultPath, TotalUpslopeResultPath, StreamGridResultPath, StreamOrdResultPath, TreeDatResultPath, CoordDatResultPath, Threshold, UseOutlets, UseEdgeContamCheck, false, tauCallback);
        }

        /// <summary>
        /// An overload of delinStreamGrids which allows the use of Dinf in the delineation
        /// </summary>
        /// <param name="DemGridPath"></param>
        /// <param name="PitFillPath"></param>
        /// <param name="D8Path"></param>
        /// <param name="D8SlopePath"></param>
        /// <param name="AreaD8Path"></param>
        /// <param name="AreaDInfPath"></param>
        /// <param name="OutletsPath"></param>
        /// <param name="StrahlOrdResultPath"></param>
        /// <param name="LongestUpslopeResultPath"></param>
        /// <param name="TotalUpslopeResultPath"></param>
        /// <param name="StreamGridResultPath"></param>
        /// <param name="StreamOrdResultPath"></param>
        /// <param name="TreeDatResultPath"></param>
        /// <param name="CoordDatResultPath"></param>
        /// <param name="Threshold"></param>
        /// <param name="UseOutlets"></param>
        /// <param name="UseEdgeContamCheck"></param>
        /// <param name="UseDinf"></param>
        /// <param name="tauCallback"></param>
        /// <returns></returns>
        public static int DelinStreamGrids(string DemGridPath, string PitFillPath, string D8Path, string D8SlopePath, string AreaD8Path, string AreaDInfPath, string OutletsPath, string StrahlOrdResultPath, string LongestUpslopeResultPath, string TotalUpslopeResultPath, string StreamGridResultPath, string StreamOrdResultPath, string TreeDatResultPath, string CoordDatResultPath, int Threshold, bool UseOutlets, bool UseEdgeContamCheck, bool UseDinf, TKTAUDEMLib.ItkCallback tauCallback)
        {
            return runDelinStreamGrids(DemGridPath, PitFillPath, D8Path, D8SlopePath, AreaD8Path, AreaDInfPath, OutletsPath, StrahlOrdResultPath, LongestUpslopeResultPath, TotalUpslopeResultPath, StreamGridResultPath, StreamOrdResultPath, TreeDatResultPath, CoordDatResultPath, Threshold, UseOutlets, UseEdgeContamCheck, UseDinf, tauCallback);
        }

        /// <summary>
        /// An overload of the DelinStreamGrids function which will generate a GeoprocDialog for the DelinStreamGrids function
        /// </summary>
        /// <param name="tauCallback"></param>
        /// <returns></returns>
        public static int DelinStreamGrids(TKTAUDEMLib.ItkCallback tauCallback)
        {
            return doDelinStreamGridsDiag(tauCallback);
        }

        /// <summary>
        /// An overload of the DelinStreamGrids function which will generate a GeoprocDialog for the DelinStreamGrids function
        /// </summary>
        /// <returns></returns>
        public static int DelinStreamGrids()
        {
            return doDelinStreamGridsDiag(null);
        }

        private static int doDelinStreamGridsDiag(TKTAUDEMLib.ItkCallback tauCallback)
        {
            GeoProcDialog delinstreamDiag = new GeoProcDialog();
            FileElement demElem = delinstreamDiag.Add_FileElement(GeoProcDialog.ElementTypes.OpenGridFile);
            FileElement fillElem = delinstreamDiag.Add_FileElement(GeoProcDialog.ElementTypes.OpenGridFile);
            FileElement d8Elem = delinstreamDiag.Add_FileElement(GeoProcDialog.ElementTypes.OpenGridFile);
            FileElement d8slpElem = delinstreamDiag.Add_FileElement(GeoProcDialog.ElementTypes.OpenGridFile);
            FileElement aread8Elem = delinstreamDiag.Add_FileElement(GeoProcDialog.ElementTypes.OpenGridFile);
            BooleanElement usedinfElem = delinstreamDiag.Add_BooleanElement();
            FileElement areadinfElem = delinstreamDiag.Add_FileElement(GeoProcDialog.ElementTypes.OpenGridFile);
            BooleanElement useOutletsElem = delinstreamDiag.Add_BooleanElement();
            FileElement outletsElem = delinstreamDiag.Add_FileElement(GeoProcDialog.ElementTypes.OpenGridFile);
            BooleanElement useEdgeElem = delinstreamDiag.Add_BooleanElement();
            TextElement threshElem = delinstreamDiag.Add_TextElement();
            FileElement strahlResElem = delinstreamDiag.Add_FileElement(GeoProcDialog.ElementTypes.SaveGridFile);
            FileElement longestResElem = delinstreamDiag.Add_FileElement(GeoProcDialog.ElementTypes.SaveGridFile);
            FileElement totalResElem = delinstreamDiag.Add_FileElement(GeoProcDialog.ElementTypes.SaveGridFile);
            FileElement streamGridResElem = delinstreamDiag.Add_FileElement(GeoProcDialog.ElementTypes.SaveGridFile);
            FileElement streamOrdResElem = delinstreamDiag.Add_FileElement(GeoProcDialog.ElementTypes.SaveGridFile);
            FileElement treeDatResElem = delinstreamDiag.Add_FileElement(GeoProcDialog.ElementTypes.SaveFile);
            FileElement coordDatResElem = delinstreamDiag.Add_FileElement(GeoProcDialog.ElementTypes.SaveFile);

            delinstreamDiag.Text = "Delineate TauDEM Stream Grids and Network";
            delinstreamDiag.HelpTitle = "Delineate TauDEM Stream Grids and Network";
            delinstreamDiag.HelpText = "This function will generate stream grids and network data from the given inputs.";
            delinstreamDiag.Height = 550;
            delinstreamDiag.HelpPanelVisible = false;

            demElem.Caption = "Digital Elevation Model Grid Path";
            demElem.HelpButtonVisible = false;

            fillElem.Caption = "Pit-Filled DEM Grid Path";
            fillElem.HelpButtonVisible = false;

            d8Elem.Caption = "D8 Flow Direction Grid Path";
            d8Elem.HelpButtonVisible = false;

            d8slpElem.Caption = "D8 Slope Grid Path";
            d8slpElem.HelpButtonVisible = false;

            aread8Elem.Caption = "D8 Contributing Area Grid Path";
            aread8Elem.HelpButtonVisible = false;

            usedinfElem.Caption = "Use D-Infinity Contributing Area Mask";
            usedinfElem.Text = "Use D-Infinity Mask";
            usedinfElem.HelpButtonVisible = false;

            areadinfElem.Caption = "Area D-Infinity Grid Path (optional)";
            areadinfElem.HelpButtonVisible = false;
            areadinfElem.HaltOnEmpty = false;

            useOutletsElem.Caption = "Use Outlets/Inlets Shapefile";
            useOutletsElem.Text = "Use Outlets/Inlets";
            useOutletsElem.HelpButtonVisible = false;

            outletsElem.Caption = "Outlets/Inlets Point Shapefile Path (optional)";
            outletsElem.HelpButtonVisible = false;
            outletsElem.HaltOnEmpty = false;

            useEdgeElem.Caption = "Check for Edge Contamination";
            useEdgeElem.Text = "Use Edge Contamination Check";
            useEdgeElem.HelpButtonVisible = false;

            threshElem.Caption = "# of Cells to Use for Accumulation Threshold";
            threshElem.Text = "1000";
            threshElem.HelpButtonVisible = false;

            strahlResElem.Caption = "Strahler Network Order Grid Result Path";
            strahlResElem.HelpButtonVisible = false;

            longestResElem.Caption = "Longest Upslope Length Grid Result Path";
            longestResElem.HelpButtonVisible = false;

            totalResElem.Caption = "Total Upslope Length Grid Result Path";
            totalResElem.HelpButtonVisible = false;

            streamOrdResElem.Caption = "Stream Order Grid Result Path";
            streamOrdResElem.HelpButtonVisible = false;


            streamGridResElem.Caption = "Stream Raster Grid Result Path";
            streamGridResElem.HelpButtonVisible = false;

            treeDatResElem.Caption = "Network Tree Result Data File Path";
            treeDatResElem.Filter = "Data Files (*.dat)|*.dat";
            treeDatResElem.HelpButtonVisible = false;

            coordDatResElem.Caption = "Network Coordinates Result Data File Path";
            coordDatResElem.Filter = "Data Files (*.dat)|*.dat";
            coordDatResElem.HelpButtonVisible = false;

            if (delinstreamDiag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return Hydrology.DelinStreamGrids(demElem.Filename, fillElem.Filename, d8Elem.Filename, d8slpElem.Filename, aread8Elem.Filename, areadinfElem.Filename, outletsElem.Filename, strahlResElem.Filename, longestResElem.Filename, totalResElem.Filename, streamGridResElem.Filename, streamOrdResElem.Filename, treeDatResElem.Filename, coordDatResElem.Filename, int.Parse(threshElem.Value), useOutletsElem.Value, useEdgeElem.Value, usedinfElem.Value, tauCallback);
            }
            return -2;
        }



        private static int runDelinStreamGrids(string DemGridPath, string PitFillPath, string D8Path, string D8SlopePath, string AreaD8Path, string AreaDInfPath, string OutletsPath, string StrahlOrdResultPath, string LongestUpslopeResultPath, string TotalUpslopeResultPath, string StreamGridResultPath, string StreamOrdResultPath, string TreeDatResultPath, string CoordDatResultPath, int Threshold, bool UseOutlets, bool UseEdgeContamCheck, bool UseDinf, TKTAUDEMLib.ItkCallback tauCallback)
        {
            MapWinUtility.Logger.Dbg("runDelinStreamGrids(DemGridPath: " + DemGridPath + "\n " +
                                    "PitFillPath: " + PitFillPath + "\n" +
                                    "D8Path: " + D8Path + "\n" +
                                    "D8SlopePath: " + D8SlopePath + "\n" +
                                    "AreaD8Path: " + AreaD8Path + "\n" +
                                    "AreaDInfPath: " + AreaDInfPath + "\n" +
                                    "OutletsPath: " + OutletsPath + "\n" +
                                    "StrahlOrdResultPath: " + StrahlOrdResultPath + "\n" +
                                    "LongestUpslopeResultPath: " + LongestUpslopeResultPath + "\n" +
                                    "TotalUpslopeResultPath: " + TotalUpslopeResultPath + "\n" +
                                    "StreamGridResultPath: " + StreamGridResultPath + "\n" +
                                    "StreamOrdResultPath: " + StreamOrdResultPath + "\n" +
                                    "TreeDatResultPath: " + TreeDatResultPath + "\n" +
                                    "CoordDatResultPath: " + CoordDatResultPath + "\n" +
                                    "Threshold: " + Threshold.ToString() + "\n" +
                                    "UseOutlets: " + UseOutlets + "\n" +
                                    "UseEdgeContamCheck: " + UseEdgeContamCheck + "\n" +
                                    "UseDinf: " + UseDinf + "\n" +
                                    "tauCallback)");
            int result = -1;
            int iUseOutlets;
            double[] X = new double[1];
            double[] Y = new double[1];
            System.Collections.ArrayList xsel = new System.Collections.ArrayList();
            System.Collections.ArrayList ysel = new System.Collections.ArrayList();
            int ArraySize = 0;
            int useMask = 0;
            int Method;
            float[] thresh = new float[5];
            int nxy;
            int masksca = 0;
            if (UseDinf) masksca = 1;
            int contcheck = 0;
            if (UseEdgeContamCheck) contcheck = 1;

            TKTAUDEMLib.TauDEM TaudemLib = new TKTAUDEMLib.TauDEM();
            if (tauCallback != null) TaudemLib.Callback = tauCallback;

            DataManagement.DeleteGrid(ref StrahlOrdResultPath);
            DataManagement.DeleteGrid(ref LongestUpslopeResultPath);
            DataManagement.DeleteGrid(ref TotalUpslopeResultPath);
            DataManagement.DeleteGrid(ref StreamGridResultPath);
            DataManagement.DeleteGrid(ref StreamOrdResultPath);

            if (tauCallback != null) tauCallback.Progress("Status", 0, "Grid Network");

            if (UseOutlets)
            {
                iUseOutlets = 1;
                if (ShapefileToArrays(OutletsPath, ref X, ref Y, ref ArraySize) == false)
                {
                    return -1;
                }
                for (int i = 0; i <= ArraySize - 1; i++)
                {
                    xsel.Add(X[i]);
                    ysel.Add(Y[i]);
                }
                ArraySize = xsel.Count;
                result = TaudemLib.Gridnet(D8Path, LongestUpslopeResultPath, TotalUpslopeResultPath, StrahlOrdResultPath, AreaD8Path, ref X[0], ref Y[0], ArraySize, useMask, iUseOutlets, 0);
                //result = GridNet(D8Path, LongestUpslopeResultPath, TotalUpslopeResultPath, StrahlOrdResultPath, AreaD8Path, ref X, ref Y, ArraySize, useMask, iUseOutlets, 0, null);
            }
            else
            {
                iUseOutlets = 0;
                result = TaudemLib.Gridnet(D8Path, LongestUpslopeResultPath, TotalUpslopeResultPath, StrahlOrdResultPath, AreaD8Path, ref X[0], ref Y[0], 0, useMask, iUseOutlets, 0);
                //result = GridNet(D8Path, LongestUpslopeResultPath, TotalUpslopeResultPath, StrahlOrdResultPath, AreaD8Path, ref X, ref Y, 0, useMask, iUseOutlets, 0, null);
            }
            if (result != 0)
            {
                MapWinUtility.Logger.Message(TaudemLib.getErrorMsg(result), "TauDEM Error " + result, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.DialogResult.OK);

                return result;
            }


            if (tauCallback != null) tauCallback.Progress("Status", 0, "All Stream Delineation");
            MapWinUtility.Logger.Dbg("All Stream Delineation");
            if (ArraySize == 0)
            {
                nxy = 0;
                X = new double[2];
                Y = new double[2];
                X[1] = 0;
                Y[1] = 0;
            }
            else
            {
                if (ArraySize > 0)
                {
                    nxy = ArraySize + 1;
                    X = new double[nxy];
                    Y = new double[nxy];
                    for (int i = 1; i <= ArraySize; i++)
                    {
                        X[i] = System.Convert.ToDouble(xsel[i - 1]);
                        Y[i] = System.Convert.ToDouble(ysel[i - 1]);
                    }
                }
                else
                {
                    return -1;
                }
            }
            Method = 1;
            thresh[1] = Threshold;

            result = TaudemLib.Sourcedef(AreaD8Path, D8SlopePath, LongestUpslopeResultPath, D8Path, StreamGridResultPath, PitFillPath, StrahlOrdResultPath, AreaDInfPath, "", Method, ref thresh[1], nxy, ref X[1], ref Y[1], contcheck, masksca);
            //result = SourceDef(AreaD8Path, D8SlopePath, LongestUpslopeResultPath, D8Path, StreamGridResultPath, PitFillPath, StrahlOrdResultPath, AreaDInfPath, "", Method, thresh, nxy, X, Y, contcheck, 0, masksca, null);
            if (result != 0)
            {
                MapWinUtility.Logger.Message(TaudemLib.getErrorMsg(result), "TauDEM Error " + result, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.DialogResult.OK);
                return result;
            }

            X = new double[1];
            Y = new double[1];
            int[] idNodes = new int[1];
            int useTrace = 0;
            MapWinUtility.Logger.Dbg("Stream Order Grid and Raster");
            if (tauCallback != null) tauCallback.Progress("Status", 0, "Stream Order Grid and Raster");
            System.IO.File.Delete(CoordDatResultPath);
            System.IO.File.Delete(TreeDatResultPath);
            if (UseOutlets)
            {
                if (ShapefileToArraysWithIDs(OutletsPath, ref X, ref Y, ref nxy, ref idNodes) == false)
                {
                    return -2;
                }
            }
            try
            {
                //DateTime start = DateTime.Now;

                //result = TaudemLib.Netsetup(DemGridPath, D8Path, StreamGridResultPath, StreamOrdResultPath, AreaD8Path, PitFillPath, TreeDatResultPath, CoordDatResultPath, ref X[0], ref Y[0], nxy, useTrace, ref idNodes[0]);
                result = NetSetup(DemGridPath, D8Path, StreamGridResultPath, StreamOrdResultPath, AreaD8Path, PitFillPath, TreeDatResultPath, CoordDatResultPath, X, Y, nxy, useTrace, idNodes, null);

                //TimeSpan time = DateTime.Now.Subtract(start);
                //System.Windows.Forms.MessageBox.Show(time.TotalMilliseconds.ToString());
            }
            catch
            {
            }
            if (result == -1)
            {
                if (!(System.IO.File.Exists(StreamOrdResultPath)))
                {
                    MapWinUtility.Logger.Message("Automatic Watershed Delineation encountered an error which generally occurs from too many outlets/inlets being delineated, especially ones close together. Please lower the snap threshold and rerun to minimize outlets/inlets not direclty on the streams.", "Application Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.DialogResult.OK);

                }
            }
            else
            {
                if (result != 0)
                {
                    MapWinUtility.Logger.Message(TaudemLib.getErrorMsg(result), "TauDEM Error " + result, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.DialogResult.OK);

                }
            }

            CopyProjectionFromGrid(DemGridPath, StrahlOrdResultPath);
            CopyProjectionFromGrid(DemGridPath, LongestUpslopeResultPath);
            CopyProjectionFromGrid(DemGridPath, TotalUpslopeResultPath);
            CopyProjectionFromGrid(DemGridPath, StreamGridResultPath);
            CopyProjectionFromGrid(DemGridPath, StreamOrdResultPath);
            if (tauCallback != null) tauCallback.Progress("Status", 0, "");
            return result;
        }



        #region "     Grid Net conversion"

        private static int GridNet(string pfile, string plenfile, string tlenfile, string gordfile, string afile, ref double[] x, ref double[] y, long nxy, int useMask, int useOutlets, int thresh, TKTAUDEMLib.ItkCallback callback)
        {
            int row, col;
            double dx, dy, nx, ny;
            int err = 0;
            int[] d1 = new int[9];
            int[] d2 = new int[9];
            double[] dist = new double[9];
            
            /* define directions */
            d1[1] = 0; d1[2] = -1; d1[3] = -1; d1[4] = -1; d1[5] = 0; d1[6] = 1; d1[7] = 1; d1[8] = 1;
            d2[1] = 1; d2[2] = 1; d2[3] = 0; d2[4] = -1; d2[5] = -1; d2[6] = -1; d2[7] = 0; d2[8] = 1;


            MapWinGIS.Grid sdir = new MapWinGIS.Grid();
            if (sdir.Open(pfile, MapWinGIS.GridDataType.UnknownDataType, true, MapWinGIS.GridFileType.UseExtension, null))
            {
                err = 0;
            }
            else
            {
                err = 1; //TD_FAILED_GRID_OPEN
            }
            if (err != 0) return err;
            dx = sdir.Header.dX;
            dy = sdir.Header.dY;
            nx = sdir.Header.NumberCols;
            ny = sdir.Header.NumberRows;

            MapWinGIS.Grid laag = new MapWinGIS.Grid();
            if (useMask == 1)
            {
                /*   read mask  */                
                if (laag.Open(afile, MapWinGIS.GridDataType.UnknownDataType, true, MapWinGIS.GridFileType.UseExtension, null))
                {
                    err = 0;
                }
                else
                {
                    err = 1; //TD_FAILED_GRID_OPEN
                }
                if (err != 0) return err;
            }
            else
            {
                MapWinGIS.GridHeader laagHead = new MapWinGIS.GridHeader();
                laagHead.CopyFrom(sdir.Header);
                laag.CreateNew(afile, laagHead, MapWinGIS.GridDataType.LongDataType, 0, true, MapWinGIS.GridFileType.UseExtension, null);
            }

            MapWinGIS.GridHeader sordgHead = new MapWinGIS.GridHeader();
            sordgHead.CopyFrom(sdir.Header);
            sordgHead.NodataValue = -1;
            MapWinGIS.Grid sordg = new MapWinGIS.Grid();
            sordg.CreateNew(gordfile, sordgHead, MapWinGIS.GridDataType.ShortDataType, sordgHead.NodataValue, true, MapWinGIS.GridFileType.UseExtension, null);
            
            MapWinGIS.GridHeader fltpgHead = new MapWinGIS.GridHeader();
            fltpgHead.CopyFrom(sdir.Header);
            fltpgHead.NodataValue = -1;
            MapWinGIS.Grid fltpg = new MapWinGIS.Grid();
            fltpg.CreateNew(tlenfile, fltpgHead, MapWinGIS.GridDataType.FloatDataType, fltpgHead.NodataValue, true, MapWinGIS.GridFileType.UseExtension, null);

            MapWinGIS.GridHeader flengHead = new MapWinGIS.GridHeader();
            flengHead.CopyFrom(sdir.Header);
            flengHead.NodataValue = -1;
            MapWinGIS.Grid fleng = new MapWinGIS.Grid();
            fleng.CreateNew(plenfile, flengHead, MapWinGIS.GridDataType.FloatDataType, flengHead.NodataValue, true, MapWinGIS.GridFileType.UseExtension, null);

            /*  Calculate Distances  */
            for (int i = 1; i <= 8; i++)
            {
                dist[i] = Math.Sqrt(d1[i] * d1[i] * dy * dy + d2[i] * d2[i] * dx * dx);
            }

            if (useOutlets == 1)  /*  Only compute area's for designated locations  */
            {
                for (int curXY = 0; curXY < nxy; curXY++)
                {
                    sdir.ProjToCell(x[curXY], y[curXY], out col, out row);
                    if (row < 0 || row > ny || col < 0 || col > nx)
                    {
                        row = 0; col = 0;
                    }
                    d2area(row, col, nx, ny, d1, d2, dist, thresh, ref sdir, ref laag, ref sordg, ref fltpg, ref fleng);
                }
            }
            else
            {
                for (int i = 0; i < ny; i++)
                    for (int j = 0; j < nx; j++)
                        d2area(i, j, nx, ny, d1, d2, dist, thresh, ref sdir, ref laag, ref sordg, ref fltpg, ref fleng);
            }


            if (fleng.Save(plenfile, MapWinGIS.GridFileType.UseExtension, null))
            {
                err = 0;
            }
            else
            {
                err = 2; //TD_FAILED_GRID_SAVE
                return err;
            }

            if (fltpg.Save(tlenfile, MapWinGIS.GridFileType.UseExtension, null))
            {
                err = 0;
            }
            else
            {
                err = 2; //TD_FAILED_GRID_SAVE
                return err;
            }

            if (sordg.Save(gordfile, MapWinGIS.GridFileType.UseExtension, null))
            {
                err = 0;
            }
            else
            {
                err = 2; //TD_FAILED_GRID_SAVE
                return err;
            }

            sordg.Close();
            laag.Close();
            fltpg.Close();
            fleng.Close();

            return err;
        }

        private static void d2area(int i, int j, double nx, double ny, int[] d1, int[] d2, double[] dist, int thresh, ref MapWinGIS.Grid sdir, ref MapWinGIS.Grid laag, ref MapWinGIS.Grid sordg, ref MapWinGIS.Grid fltpg, ref MapWinGIS.Grid fleng)
        {
            int ni, nj;
            short a1, a2;
            double ld;

            if ((short) sordg.get_Value(j, i) <= 0)
            {
                if (i != 0 && i != ny - 1 && j != nx - 1 && (short)sdir.get_Value(j, i) != -32767)
                {
                    sordg.set_Value(j, i, 1);
                    fltpg.set_Value(j, i, 0);
                    fleng.set_Value(j, i, 0);
                    a1 = 0;
                    a2 = 0;

                    for (int k = 1; k <= 8; k++)
                    {
                        ni = i + d1[k];
                        nj = j + d2[k];
                        
                        /* test if neighbor drains towards cell excluding boundaries */
                        if ((short)sdir.get_Value(nj, ni) >= 0)
                        {
                            if ((int)laag.get_Value(nj, ni) >= thresh && ((short)sdir.get_Value(nj, ni) - k == 4 || (short)sdir.get_Value(nj, ni) - k == -4))
                            {
                                d2area(ni, nj, nx, ny, d1, d2, dist, thresh, ref sdir, ref laag, ref sordg, ref fltpg, ref fleng);
                                if ((short)sordg.get_Value(nj, ni) >= a1)
                                {
                                    a2 = a1;
                                    a1 = (short)sordg.get_Value(nj, ni);
                                }
                                else if ((short)sordg.get_Value(nj, ni) > a2)
                                {
                                    a2 = (short)sordg.get_Value(nj, ni);
                                }

                                ld = (float)fleng.get_Value(nj, ni) + dist[(short)sdir.get_Value(nj, ni)];
                                fltpg.set_Value(j, i, (float)fltpg.get_Value(j, i) + (float)fltpg.get_Value(nj, ni) + dist[(short)sdir.get_Value(nj, ni)]);
                                if (ld > (float)fleng.get_Value(j, i))
                                {
                                    fleng.set_Value(j, i, ld);
                                }
                            }
                        }
                    }
                    if (a2 + 1 > a1)
                    {
                        sordg.set_Value(j, i, a2 + 1);
                    }
                    else
                    {
                        sordg.set_Value(j, i, a1);
                    }
                }
            }
        }

        #endregion //GridNet conversion


        #region "     Source Def conversion"

        private static int SourceDef(string areafile, string slopefile, string plenfile, string dirfile, string srcfile, string elvfile, string gordfile, string scafile, string fdrfile, int ipar, float[] p, int nxy, double[] x, double[] y, int contcheck, int dropan, int masksca, TKTAUDEMLib.ItkCallback callback)
        {
            int err = 0;

//    float ndvs,ndvp,ndvd,emax,ndve,ndvo,wsum,val;

//    float **selev ;

//    /**********Grid Declarations*************/
//    fgrid faagrid;
//    fgrid fplengrid;
//    sgrid sgordgrid;
//    //=============================
//    int row, col, i,j,iomax,jomax,bound,ik,jk,k,itresh;
//    err = TD_NO_ERROR;
//    int rcgood=1;
//    ccheck=contcheck;



//    /* define directions */
//    d1[1]=0; d1[2]= -1; d1[3]= -1; d1[4]= -1; d1[5]=0; d1[6]=1; d1[7]=1; d1[8]=1;
//    d2[1]=1; d2[2]=1; d2[3]=0; d2[4]= -1; d2[5]= -1; d2[6]= -1; d2[7]=0; d2[8]=1;


//    /* read grid files */
//    if(ipar == 1)
//    {


//        if(gridread(areafile,&faagrid,&filetype)==0)
//            err=TD_NO_ERROR;
//        else
//        {
//            err=TD_FAILED_GRID_OPEN;
//        }


//        nx = faagrid.head.nx;
//        ny = faagrid.head.ny;
//        dx = faagrid.head.dx;
//        dy = faagrid.head.dy;
//        csize = dx;
//        ndva = faagrid.nodata;
//        for(i=0;i<4;i++) bndbox[i]=faagrid.head.bndbox[i];


//        if(err != TD_NO_ERROR)goto ERROR1;
//    }

//    if(ipar == 2)
//    {

//        if ( gridread(scafile,&faagrid,&filetype)==0)
//            err=TD_NO_ERROR;
//        else
//            err=TD_FAILED_GRID_OPEN;


//        nx =faagrid.head.nx;
//        ny = faagrid.head.ny;
//        dx = faagrid.head.dx;
//        dy = faagrid.head.dy;
//        csize = dx;
//        ndva = faagrid.nodata;
//        for(i=0;i<4;i++) bndbox[i]=faagrid.head.bndbox[i];


//        if(err != TD_NO_ERROR)goto ERROR1;


//        if ( gridread(slopefile,&fslopeg,&filetype)==0)
//            err=TD_NO_ERROR;
//        else
//            err=TD_FAILED_GRID_OPEN;

//        ndvs = fslopeg.nodata;

//        if(err != TD_NO_ERROR)goto ERROR1;
//    }
//    if(ipar == 3)
//    {
//        if ( gridread(scafile,&faagrid,&filetype)==0)
//            err=TD_NO_ERROR;
//        else
//            err=TD_FAILED_GRID_OPEN;


//        nx = faagrid.head.nx;
//        ny = faagrid.head.ny;
//        dx = faagrid.head.dx;
//        dy = faagrid.head.dy;
//        csize = dx;
//        ndva = faagrid.nodata;
//        for(i=0;i<4;i++) bndbox[i]=faagrid.head.bndbox[i];


//        if(err != TD_NO_ERROR)goto ERROR1;


//        if ( gridread(plenfile,&fplengrid,&filetype)==0)
//            err=TD_NO_ERROR;
//        else
//            err=TD_FAILED_GRID_OPEN;

//        ndvp = fplengrid.nodata;


//        if(err != TD_NO_ERROR)goto ERROR1;
//    }
//    if(ipar == 4)
//    {

//        if( gridread(elvfile,&felevg,&filetype)==0)

//            err=TD_NO_ERROR;
//        else
//            err=TD_FAILED_GRID_OPEN;


//        nx = felevg.head.nx;
//        ny = felevg.head.ny;
//        dx = felevg.head.dx;
//        dy = felevg.head.dy;
//        csize = dx;
//        ndve = felevg.nodata;
//        for(i=0;i<4;i++) bndbox[i]=felevg.head.bndbox[i];


//        if(err != TD_NO_ERROR)goto ERROR1;
//    }
//    if(ipar == 5)
//    {

//        if ( gridread(gordfile,&sgordgrid,&filetype)==0)
//            err=TD_NO_ERROR;
//        else
//            err=TD_FAILED_GRID_OPEN;


//        nx = sgordgrid.head.nx;
//        ny = sgordgrid.head.ny;
//        dx = sgordgrid.head.dx;
//        dy = sgordgrid.head.dy;
//        csize = dx;
//        ndvo = sgordgrid.nodata;
//        for(i=0;i<4;i++)bndbox[i]=sgordgrid.head.bndbox[i];

//        if(err != TD_NO_ERROR)goto ERROR1;
//    }
//    if(ipar == 6)
//    {

//        if (gridread(fdrfile,&sgordgrid,&filetype)==0)
//            err=TD_NO_ERROR;
//        else
//            err=TD_FAILED_GRID_OPEN;


//        nx = sgordgrid.head.nx;
//        ny = sgordgrid.head.ny;
//        dx = sgordgrid.head.dx;
//        dy = sgordgrid.head.dy;
//        csize = dx;
//        ndvo = sgordgrid.nodata;
//        for(i=0;i<4;i++)bndbox[i]=sgordgrid.head.bndbox[i];


//        if(err != TD_NO_ERROR)goto ERROR1;
//    }


//    if((src = (short **)matalloc(nx,ny, RPSHRDTYPE)) == NULL)
//    {
//        err=TD_FAILED_MEMORY_ALLOC;
//        //  printf("Could not allocate memory for src\n");
//        goto ERROR1;
//    }


//    /*  Flag sources  */
//    for(i=0; i < ny; i++)
//        for(j=0; j< nx; j++)
//        {
//            src[j][i] = 0;
//            if(ipar == 1)   /*  Area threshold   */
//            {
//                src[j][i] = (faagrid.d[j][i] >= p[0]) ? 1 : 0;
//            }
//            else if(ipar == 2)   /*  Slope and area combination   */
//            {
//                if( fslopeg.d[j][i] > 0.)
//                {
//                    val = (faagrid.d[j][i] * pow((double)fslopeg.d[j][i],(double)p[1])) ;
//                    src[j][i] = (val >= p[0])	  ? 1: 0;
//                }
//            }else if(ipar == 3)  /*  Slope and Length combination   */
//            {
//                if(fplengrid.d[j][i] > 0.)
//                {
//                    src[j][i] = (faagrid.d[j][i] >= p[0]* pow((double)fplengrid.d[j][i],(double)p[1]))
//                        ? 1: 0;
//                }
//            }
//            else if(ipar == 5)  /*  Grid order threshold  */
//                src[j][i] = (sgordgrid.d[j][i] >= p[0]) ? 1: 0;
//            else if(ipar == 6)  /*  Given flow directions threshold  */
//                src[j][i] = (sgordgrid.d[j][i] > 0) ? 1: 0;
//        }
//        if(ipar == 4)  /* Peuker and Douglas algorithm  */
//        {
//            /*  Initialize internal cells to 1 for Peuker and Douglas algorithm and smooth  */
//            if((selev = (float **)matalloc(nx,ny, RPFLTDTYPE)) == NULL)
//            {
//                err=TD_FAILED_MEMORY_ALLOC;
//                //  printf("Could not allocate memory for selev\n");
//                goto ERROR1;
//            }
//            for(i=0; i <ny; i++)
//                for(j=0; j<nx; j++)
//                {
//                    if (ndve > 0) //ARA 10/17/05 Fixed for possible positive nodata
//              {
//                  if(i == 0 || i == (ny-1) || j == 0 || j == (nx-1) || felevg.d[j][i] >= ndve)
//                  {
//                      selev[j][i]=felevg.d[j][i];
//                  }
//                  else
//                  {
//                      src[j][i] = 1;
//                      selev[j][i]=p[1] * felevg.d[j][i];
//                      wsum=p[1];
//                      if(p[2] > 0.)
//                          for(k=1; k<=7; k=k+2)
//                          {
//                              if(felevg.d[j+d2[k]][i+d1[k]] < ndve)
//                              {
//                                  selev[j][i] += felevg.d[j+d2[k]][i+d1[k]] *p[2];
//                                  wsum += p[2];
//                              }
//                          }
//                          if(p[3] > 0.)
//                              for(k=2; k<=8; k=k+2)
//                              {
//                                  if(felevg.d[j+d2[k]][i+d1[k]] < ndve)
//                                  {
//                                      selev[j][i] += felevg.d[j+d2[k]][i+d1[k]] *p[3];
//                                      wsum += p[3];
//                                  }
//                              }
//                  }
//              }
//                    else
//              {
//                  if(i == 0 || i == (ny-1) || j == 0 || j == (nx-1) || felevg.d[j][i] <= ndve)
//                  {
//                      selev[j][i]=felevg.d[j][i];
//                  }
//                  else
//                  {
//                      src[j][i] = 1;
//                      selev[j][i]=p[1] * felevg.d[j][i];
//                      wsum=p[1];
//                      if(p[2] > 0.)
//                          for(k=1; k<=7; k=k+2)
//                          {
//                              if(felevg.d[j+d2[k]][i+d1[k]] > ndve)
//                              {
//                                  selev[j][i] += felevg.d[j+d2[k]][i+d1[k]] *p[2];
//                                  wsum += p[2];
//                              }
//                          }
//                          if(p[3] > 0.)
//                              for(k=2; k<=8; k=k+2)
//                              {
//                                  if(felevg.d[j+d2[k]][i+d1[k]] > ndve)
//                                  {
//                                      selev[j][i] += felevg.d[j+d2[k]][i+d1[k]] *p[3];
//                                      wsum += p[3];
//                                  }
//                              }
//                  }
//              }

//                    if(i == 0 || i == (ny-1) || j == 0 || j == (nx-1) || felevg.d[j][i] <= ndve)
//              {
//                  selev[j][i]=felevg.d[j][i];
//              }
//                    else
//              {
//                  src[j][i] = 1;
//                  selev[j][i]=p[1] * felevg.d[j][i];
//                  wsum=p[1];
//                  if(p[2] > 0.)
//                      for(k=1; k<=7; k=k+2)
//                      {
//                          if(felevg.d[j+d2[k]][i+d1[k]] > ndve)
//                          {
//                              selev[j][i] += felevg.d[j+d2[k]][i+d1[k]] *p[2];
//                              wsum += p[2];
//                          }
//                      }
//                      if(p[3] > 0.)
//                          for(k=2; k<=8; k=k+2)
//                          {
//                              if(felevg.d[j+d2[k]][i+d1[k]] > ndve)
//                              {
//                                  selev[j][i] += felevg.d[j+d2[k]][i+d1[k]] *p[3];
//                                  wsum += p[3];
//                              }
//                          }
//              }
//                }

//                for (int curcol = 0; curcol < nx; curcol++)
//                    for (int currow = 0; currow < ny; currow++)

//                        felevg.d[curcol][currow]=selev[curcol][currow];

//                for(i=0; i <ny-1; i++)
//                    for(j=0; j<nx-1; j++)
//                    {
//                        emax= felevg.d[j][i];
//                        iomax=0;
//                        jomax=0;
//                        bound= 0;  /*  .false.  */
//                        /*  --FIRST PASS FLAG MAX ELEVATION IN GROUP OF FOUR  */
//                        for(ik=0; ik<2; ik++)
//                            for(jk=1-ik; jk < 2; jk++)
//                            {
//                                if(felevg.d[j+jk][i+ik] > emax)
//                                {
//                                    emax=felevg.d[j+jk][i+ik];
//                                    iomax=ik;
//                                    jomax=jk;
//                                }
//                                if( felevg.d[j+jk][i+ik] <= ndve)
//                                    bound= 1;  /*  .true.  */
//                            }
//                            /*  c---Unflag max pixel */
//                            src[j+jomax][i+iomax] = 0;
//                            /*  c---Unflag pixels where the group of 4 touches a boundary  */
//                            if(bound == 1)
//                            {
//                                for(ik=0; ik < 2; ik++)
//                                    for(jk=0; jk< 2; jk++)
//                                    {
//                                        src[j+jk][i+ik]=0;
//                                    }
//                            }
//                            /* 		  i.e. unflag flats.  */
//                            for(ik=0; ik < 2; ik++)
//                                for(jk=0; jk< 2; jk++)
//                                {
//                                    if(felevg.d[j+jk][i+ik] == emax)src[j+jk][i+ik] = 0;
//                                }
//                    }
//        }

//        if(ipar == 2){
//            free(fslopeg.d[0]); free(fslopeg.d);
//            free(faagrid.d[0]); free(faagrid.d);
//        }
//        if(ipar == 3){
//            free(fplengrid.d[0]); free(fplengrid.d);
//            free(faagrid.d[0]); free(faagrid.d);
//        }
//        if(ipar == 4){
//            free(felevg.d[0]); free(felevg.d);
//        }
//        if(ipar == 5 || ipar == 6){
//            free(sgordgrid.d[0]); free(sgordgrid.d);
//        }


//        /*  Now get directions and compute area's  */



//        if ( gridread(dirfile,&sdir,&filetype)==0)
//            err=TD_NO_ERROR;
//        else
//            err=TD_FAILED_GRID_OPEN;


//        ndvd = sdir.nodata;

//        if(err != TD_NO_ERROR)goto ERROR1;

//        //allocate memory and headers for larr
//        larr.head.dx=dx;
//        larr.head.dy=dy;
//        larr.head.nx=nx;
//        larr.head.ny=ny;
//        larr.nodata=-2;
//        for(i=0;i<4;i++) larr.head.bndbox[i]=bndbox[i];


//        larr.nodata = -2;
//        allocategrid(&larr,larr.head,larr.nodata);

//        nout=0;
//        itresh=1;
//        if(ipar == 4)itresh = p[0];
//        err=TD_CHANNEL_NETWORK_MISMATCH;   //This flag will indicate no outlet found  12/15/02  DGT moved to outside the if block
//        // so that code works for at least one outlet found
//        if(nxy >0)
//        {
//            for(i=0; i<nxy; i++)
//            {
//                col= (int)floor((x[i]-bndbox[0])/csize);
//                row= (int)floor((bndbox[3]-y[i])/csize);
//                if(row >0 && row < ny-1 && col > 0 && col < nx-1
//                    && sdir.d[col][row]>0)  // DGT* this condition added 12/15/02 to not do outlets outside the domain
//                {
//                    /* call drainage area subroutine for pixel to zero on  */
//                    srcarea(row,col);

//                    if(larr.d[col][row] >= itresh)err=TD_NO_ERROR;  // an outlet found so no error
//                }
//            }
//            if(err==TD_CHANNEL_NETWORK_MISMATCH)goto ERROR9;  //  no outlet error
//        }
//        else
//        {
//            //  Do all pixels
//            for(i=1; i < ny-1; i++)
//                for(j=1; j<nx-1; j++)srcarea(i,j);
//            rcgood=0;  // no outlet coordinates found
//        }


//        //  Now threshold the src file
//        if(dropan == 0)
//        {

//            for(i=1; i < ny-1; i++)
//                for(j=1; j<nx-1; j++)
//                {
//                    if(larr.d[j][i] >= itresh && sdir.d[j][i]>0) larr.d[j][i]=1;
//                    //  8/13/04  DGT added condition on sdir.d
//                    else larr.d[j][i]=0;
//                }
//        }
//        if(dropan == 1 && ipar == 1)  // overwrite accumulated source area with actual area
//        {
//            for(i=1; i < ny-1; i++)
//                for(j=1; j<nx-1; j++)
//                {
//                    if(larr.d[j][i] >= itresh && sdir.d[j][i]>0)larr.d[j][i]=faagrid.d[j][i];
//                    //  8/13/04  DGT added condition on sdir.d
//                    else larr.d[j][i]=0;
//                }
//        }
//        //free memory for sdir
//        free(sdir.d[0]);free(sdir.d);

//        if(ipar <= 3){free(faagrid.d[0]);free(faagrid.d);}  // Moved from below so that could reopen with sca file for sure
//        // Exclude area with specific catchment area no data
//        if(masksca == 1)
//        {
//            if(gridread(scafile,&faagrid,&filetype)==0)
//                err=TD_NO_ERROR;
//            else
//            {
//                err=TD_FAILED_GRID_OPEN;
//                return err;
//                //	AfxMessageBox( LPCTSTR(strcat( "Failed to open sca file for masking: ", scafile) ));
//            }
//            if(err != TD_NO_ERROR)goto ERROR9;
//            for(i=1; i < ny-1; i++)
//                for(j=1; j<nx-1; j++)
//                {
//                    if(faagrid.d[j][i] < 0)larr.d[j][i]=0;
//                }
//        }



//        if ( gridwrite(srcfile,larr,filetype)==0)
//            err=TD_NO_ERROR;
//        else{
//            err=TD_FAILED_GRID_SAVE;
//            //if (srcfile)
//            //	AfxMessageBox( LPCTSTR(strcat( "Failed to save file: ", srcfile) ));
//        }

//        free(src[0]); free(src);
//        free(larr.d[0]); free(larr.d);
//        return(err);
//ERROR9:
//        free(src[0]); free(src);
//        //Kiran added the following statement to clean up.
//        free(larr.d[0]); free(larr.d);
//        if(faagrid.d != NULL) free(faagrid.d[0]); free(faagrid.d);
//        if(sdir.d[0] != NULL) free(sdir.d[0]); free(sdir.d);
//        return(err);




//ERROR1:
//        free(src[0]); free(src);
//        free(larr.d[0]); free(larr.d);
//        return(err);


            return err;
        }        
       
        #endregion 'Sourcedef conversion

        
        #region "     Netsetup conversion"
        private static int NetSetup(string fnprefix, string pfile, string srcfile, string ordfile, string ad8file, string elevfile, string treefile, string coordfile, double[] xnode, double[] ynode, int nxy, long usetrace, int[] idnodes, TKTAUDEMLib.ItkCallback callback)
        {
            int err = 0;
            int itresh, icr, icend;
            
            /* define directions */
            int[] d1 = new int[9];
            int[] d2 = new int[9];
            d1[1] = 0; d1[2] = -1; d1[3] = -1; d1[4] = -1; d1[5] = 0; d1[6] = 1; d1[7] = 1; d1[8] = 1;
            d2[1] = 1; d2[2] = 1; d2[3] = 0; d2[4] = -1; d2[5] = -1; d2[6] = -1; d2[7] = 0; d2[8] = 1;
            
            itresh = 1;  // Thresholding to 1 done in source
            
            /*read dirfile   */
            MapWinGIS.Grid dirg = new MapWinGIS.Grid();
            if (dirg.Open(pfile, MapWinGIS.GridDataType.UnknownDataType, true, MapWinGIS.GridFileType.UseExtension, null))
            {
                err = 0;
            }
            else
            {
                err = 1; //TD_FAILED_GRID_OPEN
                return err;
            }
                        
            double dx = dirg.Header.dX;
            double dy = dirg.Header.dY;
            int ny = dirg.Header.NumberRows;
            int nx = dirg.Header.NumberCols;
            double[] bndbox = new double[4];
            bndbox[0] = dirg.Header.XllCenter - dx / 2;
            bndbox[1] = dirg.Header.YllCenter - dy / 2;
            bndbox[2] = dirg.Header.XllCenter + dx * nx - dx / 2;
            bndbox[3] = dirg.Header.YllCenter + dy * ny - dy / 2;

            float[] tmpRow;
            short[,] dir = new short[ny, nx];
            for (int i = 0; i < ny; i++)
            {
                tmpRow = new float[nx];
                dirg.GetRow(i, ref tmpRow[0]);
                for (int j = 0; j < nx; j++)
                {
                    dir[i, j] = Convert.ToInt16(tmpRow[j]);
                }
            }

            /*read srcfile   */
            MapWinGIS.Grid area = new MapWinGIS.Grid();
            if (area.Open(srcfile, MapWinGIS.GridDataType.UnknownDataType, true, MapWinGIS.GridFileType.UseExtension, null))
            {
                err = 0;
            }
            else
            {
                err = 1; //TD_FAILED_GRID_OPEN
                dirg.Close();
                return err;
            }
            if (area.Header.NumberCols != nx || area.Header.NumberRows != ny)
            {
                err = 27; //TD_GRID_SIZE_MISMATCH
                dirg.Close();
                area.Close();
                return 1;
            }

            int[,] aread = new int[ny, nx];
            for (int i = 0; i < ny; i++)
            {
                tmpRow = new float[nx];
                area.GetRow(i, ref tmpRow[0]);
                for (int j = 0; j < nx; j++)
                {
                    aread[i, j] = Convert.ToInt32(tmpRow[j]);
                }
            }



            /*  check for source values >= threshold else fortran crashes*/
            int n = 0;
            short dirgNoData = Convert.ToInt16(dirg.Header.NodataValue);
            for (int i = 0; i < ny; i++)
            {
                for (int j = 0; j < nx; j++)
                {
                    if (dir[i,j] == dirgNoData)
                    {
                        dir[i,j] = 0;  // set direction no data to 0. netex needs this 
                    }
                    if (aread[i, j] >= itresh)
                    {
                        n = n + 1;
                    }
                }
            }

            if (n <= 0)
            {
                err = 8; //TD_CHANNEL_NETWORK_MISMATCH
            }
            else
            {
                int[] inodes;
                int[] jnodes;

                //  If there are outlets set up inodes, jnodes arrays
                if (nxy > 0)
                {
                    inodes = new int[nxy];
                    jnodes = new int[nxy];
                }
                else
                {
                    inodes = new int[1];
                    jnodes = new int[1];
                }

                for (int inode = 0; inode < nxy; inode++)
                {
                    jnodes[inode] = (int)Math.Floor((xnode[inode] - bndbox[0]) / dx);
                    inodes[inode] = (int)Math.Floor((bndbox[3] - ynode[inode]) / dy);
                    //   Trace to raster if necessary but only for nodes that are inside the domain
                    if (usetrace == 1 && inodes[inode] > 0 && inodes[inode] < ny - 1 && jnodes[inode] > 0 && jnodes[inode] < nx - 1)
                    {
                        if ((int)aread[jnodes[inode], inodes[inode]] < itresh)  // Not on grid
                        {
                            //   Next downslope
                            short dirn = dir[jnodes[inode], inodes[inode]];
                            int nexti = inodes[inode] + d1[dirn];
                            int nextj = jnodes[inode] + d2[dirn];
                            int loopcount = 0;
                            while (nexti > 0 && nexti < ny - 1 && nextj > 0 && nextj < nx - 1 && (int)area.get_Value(jnodes[inode], inodes[inode]) < itresh)
                            {
                                inodes[inode] = nexti;
                                jnodes[inode] = nextj;
                                dirn = dir[jnodes[inode], inodes[inode]];
                                if (dirn < 1 || dirn > 8) break;   // Here have gone out of grid so terminate trace downwards
                                nexti = nexti + d1[dirn];
                                nextj = nextj + d2[dirn];
                                loopcount = loopcount + 1;
                                if (loopcount > nx && loopcount > ny) break;   // Here possible infinite loop so terminate trace downwards
                            }
                        }
                    }
                }

                Netex(dir, ref aread, treefile, coordfile, ordfile, nx, ny, itresh, out icr, out icend, dx, dy, 0, dx, 0, err, inodes, jnodes, nxy, idnodes);


                //Write any changes that were made to the area
                for (int i = 0; i < ny; i++)
                {
                    tmpRow = new float[nx];
                    for (int j = 0; j < nx; j++)
                    {
                        tmpRow[j] = aread[i, j];
                    }
                    area.PutRow(i, ref tmpRow[0]);
                }

                area.Header.NodataValue = -1;
                if (area.Save(ordfile, MapWinGIS.GridFileType.UseExtension, null))
                {
                    err = 0;
                }
                else
                {
                    err = 2; //TD_FAILED_GRID_SAVE;
                    dirg.Close();
                    area.Close();
                    return err;
                }
                area.Close();

                //Fix negative markers
                for (int i = 0; i < ny; i++)
                {
                    for (int j = 0; j < nx; j++)
                    {
                        if (dir[i, j] < 0 && dir[i, j] > -9)
                        {
                            dir[i, j] = (short)-dir[i, j];
                        }
                    }
                }

                area = new MapWinGIS.Grid();
                if (area.Open(ad8file, MapWinGIS.GridDataType.UnknownDataType, true, MapWinGIS.GridFileType.UseExtension, null))
                {
                    err = 0;
                }
                else
                {
                    err = 1; //TD_FAILED_GRID_OPEN
                    dirg.Close();
                    return err;
                }
                aread = new int[ny, nx];
                for (int i = 0; i < ny; i++)
                {
                    tmpRow = new float[nx];
                    area.GetRow(i, ref tmpRow[0]);
                    for (int j = 0; j < nx; j++)
                    {
                        aread[i, j] = Convert.ToInt32(tmpRow[j]);
                    }
                }


                /*****read elevfile   *****/
                MapWinGIS.Grid elevg = new MapWinGIS.Grid();
                if (elevg.Open(elevfile, MapWinGIS.GridDataType.UnknownDataType, true, MapWinGIS.GridFileType.UseExtension, null))
                {
                    err = 0;
                }
                else
                {
                    err = 1; //TD_FAILED_GRID_OPEN
                    dirg.Close();
                    area.Close();
                    return err;
                }
                if (elevg.Header.NumberCols != nx || elevg.Header.NumberRows != ny)
                {
                    dirg.Close();
                    area.Close();
                    elevg.Close();
                    return 1;
                }


                float[,] elevd = new float[ny, nx];
                for (int i = 0; i < ny; i++)
                {
                    tmpRow = new float[nx];
                    elevg.GetRow(i, ref tmpRow[0]);
                    for (int j = 0; j < nx; j++)
                    {
                        elevd[i, j] = tmpRow[j];
                    }
                }

                NetProp(dir, aread, elevd, coordfile, icr, icend, dx, dy, nx, ny, bndbox, err);

                elevg.Close();
            }  //  end if associated with err from source
            dirg.Close();
            area.Close();
            
            return err;
        }



        private static int Netex(short[,] dir, ref int[,] area, string treefile, string coordfile, string ordfile, int nx, int ny, int itresh, out int icr, out int icend, double dx, double dy, double bndbox, double csize, int iftype, int err, int[] inodes, int[] jnodes, int nnodes, int[] idnodes)
        {
            int i, j;
            int inodeid;
            int nodeno;
            int ics;
            int[] iordup = new int[8];
            int[] ipoint = new int[8];
            int[] d1 = new int[9];
            int[] d2 = new int[9];
            d1[1] = 0; d1[2] = -1; d1[3] = -1; d1[4] = -1; d1[5] = 0; d1[6] = 1; d1[7] = 1; d1[8] = 1;
            d2[1] = 1; d2[2] = 1; d2[3] = 0; d2[4] = -1; d2[5] = -1; d2[6] = -1; d2[7] = 0; d2[8] = 1;
            icr = 0;
            icend = 0;
            err = 0;
            
            int[] ist, jst, iord, istart, jstart, iend, jend, mag;

            
            //READ INPUT
            int igy = ny;
            int igx = nx;
            
            //
            //     MEANING OF POINTERS IS -------------
            //                            I 4 I 3 I 2 I
            //      0 = POINTS TO SELF    -------------
            //          I.E. UNRESOLVED   I 5 I 0 I 1 I
            //     -1 = BOUNDARY PIXEL    -------------
            //                            I 6 I 7 I 8 I
            //                            -------------
            //

            //-----FIRST FIND ALL START PIXELS
            int n = 0;
            for (i = 1; i < ny - 1; i++)
            {
                for (j = 1; j < nx -1; j++)
                {
                    if (strt(i,j,area,dir,nx,ny,igx,igy,itresh))
                    {
                        n=n+1;
                    }
                }
            }

            
            int nmax=n;
            int mnl = 2 * n + 1 + nnodes;   // 11/17/04  DGT added nnodes to avoid memory overflow

            //     when added nodes increase the number of links
            int[] nextl = new int[mnl+1];
            int[] prevl1 = new int[mnl + 1];
            int[] prevl2 = new int[mnl + 1];
            ist = new int[nmax + 1];
            jst = new int[nmax + 1];
            iord = new int[mnl + 1];
            istart = new int[mnl + 1];
            jstart = new int[mnl + 1];
            iend = new int[mnl + 1];
            jend = new int[mnl + 1];
            mag = new int[mnl + 1];

            n = 0;
            for (i = 1; i < ny - 1; i++)
            {
                for (j = 1; j < nx - 1; j++)
                {
                    if (strt(i, j, area, dir, nx, ny, igx, igy, itresh))
                    {
                        n = n + 1;
                        if (n <= nmax)
                        {
                            ist[n] = i;
                            jst[n] = j;
                        }
                    }
                }
            }

            if (n > nmax)
            {
                err = 2;//stop too big
                return err;
            }


            //---ZERO AREA ARRAY
            for (i = 1; i < ny - 1; i++)
            {
                for (j = 1; j < nx - 1; j++)
                {
                    area[i, j] = 0;
                }
            }

            //----TRACE STREAMS DOWNWARDS ADDING 1 TO MAGNITUDE OF EACH PIXEL (MAGNITUDE STORED IN AREA ARRAY)
            int inext;
            int jnext;
            for (int si = 1;si <= n;si++)
            {
                i = ist[si];
                j = jst[si];
                while (dir[i,j] > 0)
                {
                    area[i,j] = area[i,j] + 1;
                    inext = i + d1[dir[i,j]];
                    jnext = j + d2[dir[i,j]];
                    i = inext;
                    j = jnext;
                }
            }
            
            //----IDENTIFY LINKS BY DIFFERENT MAGNITUDES
            bool runEndPath;
            int ilink = 1;
            int mnext, intemp, jntemp, msum, iconv, itemp;
            for (int si=1; si <= n; si++)
            {
                istart[ilink] = ist[si];
                jstart[ilink] = jst[si];

                //---INITIALISE POINTERS
                prevl1[ilink] = 0;
                prevl2[ilink] = 0;
                i = ist[si];
                j = jst[si];
                mag[ilink] = area[i, j];
                iord[ilink] = 1;

                inext = i + d1[Math.Abs(dir[i, j])];
                jnext = j + d2[Math.Abs(dir[i, j])];
                runEndPath = true;
                while (dir[inext, jnext] != 0)
                {
                    mnext = area[inext, jnext];
                    i = inext;
                    j = jnext;
                    iend[ilink] = i;
                    jend[ilink] = j;

                    //mods allow insertion of nodes   DGT 7/17/02
                    if (isnode(mnext, mag[ilink], i, j, inodes, jnodes, nnodes))
                    {
                        //heck here that this is not the end of a path because then it will be a node anyway
                        intemp = i + d1[Math.Abs(dir[i, j])];
                        jntemp = j + d2[Math.Abs(dir[i, j])];
                        if (dir[intemp, jntemp] != 0)
                        {
                            ilink = ilink + 1;
                            istart[ilink] = i;
                            jstart[ilink] = j;
                            prevl1[ilink] = ilink - 1;
                            prevl2[ilink] = 0;
                            nextl[ilink-1] = ilink;
                            mag[ilink] = mag[ilink - 1];
                            iord[ilink] = iord[ilink - 1];
                            iend[ilink] = i;
                            jend[ilink] = j;
                        }
                    }
                    //end mods to allow insertion of nodes  DGT
                    if (mnext != mag[ilink])
                    {
                        //----CONTINUE HERE FOR NEW LINK
                        //----CHECK IF JUNCTION ALREADY REACHED (FLAGGED BY NEGATIVE DIRECTION)
                        if (dir[i, j] < 0)
                        {
                            //----CHECK IF ALL LINKS CONVERGING HERE HAVE BEEN DONE BY SUMMING MAGNITUDE
                            msum = 0;
                            iconv = 0;
                            for (int il = 1; il <= ilink; il++)
                            {
                                if (iend[il] == i && jend[il] == j)
                                {
                                    iconv = iconv + 1; 
                                    ipoint[iconv] = il;
                                    iordup[iconv] = iord[il];
                                    msum = msum + mag[il];
                                }
                            }

                            if (msum == mnext) //All links have been processed
                            {
                                //---SORT IORDUP,IPOINT INTO DECENDING STREAM ORDER
                                for (int ic = 1; ic <= iconv - 1; ic++)
                                {
                                    for (int iic = ic+1; iic <= iconv; iic++)
                                    {
                                        if (iordup[iic] > iordup[ic]) //switch these
                                        {
                                            itemp = iordup[iic];
                                            iordup[iic] = iordup[ic];
                                            iordup[ic] = itemp;
                                            itemp = ipoint[iic];
                                            ipoint[iic] = ipoint[ic];
                                            ipoint[ic] = itemp;
                                        }
                                    }
                                }
                                for (int ic = 1; ic <= iconv - 1; ic++)
                                {
                                    ilink = ilink + 1;
                                    istart[ilink] = i;
                                    jstart[ilink] = j;
                                    prevl1[ilink] = ipoint[ic];
                                    prevl2[ilink] = ipoint[ic + 1];
                                    nextl[ipoint[ic]] = ilink;
                                    nextl[ipoint[ic + 1]] = ilink;
                                    mag[ilink] = mag[prevl1[ilink]] + mag[prevl2[ilink]];
                                    iord[ilink] = Math.Max(iordup[1], iordup[2] + 1);
                                    ipoint[ic + 1] = ilink;
                                    iend[ilink] = i;
                                    jend[ilink] = j;
                                }
                            }
                            else
                            {
                                ilink = ilink + 1;
                                runEndPath = false;
                                break;
                            }
                        }
                        else
                        {
                            dir[i, j] = (short)(-dir[i, j]);
                            ilink = ilink + 1;
                            runEndPath = false;
                            break;
                        }
                    } //end if mnext != mag(ilink)

                    inext = i + d1[Math.Abs(dir[i, j])];
                    jnext = j + d2[Math.Abs(dir[i, j])];
                } // end while dir != 0

                if (runEndPath)
                {
                    iend[ilink] = i;
                    jend[ilink] = j;
                    nextl[ilink] = -1;
                    if (si < n)
                    {
                        ilink = ilink + 1;
                    }
                }
            } //end for (int si=1; si <= n; si++) 


            StreamWriter coord = new System.IO.StreamWriter(coordfile);
            StreamWriter tree = new System.IO.StreamWriter(treefile);
            
            //     reinitialize area array - for output it will contain order
            for (i = 0; i < ny; i++)
            {
                for (j = 0; j < nx; j++)
                {
                    area[i, j] = 0;
                }
            }

            int icord = 0;

            //---  WRITE ROOT LINK FIRST
            i = istart[ilink];
            j = jstart[ilink];
            ics = icord;

            if (i != 0 && j != 0)
            {
                coord.Write("{0,10:G} {1,10:G}\n", i+1, j+1);
                area[i, j] = Math.Max(iord[ilink], area[i, j]);
            }
            icend = icord;
            icord = icord + 1;
            while (i != iend[ilink] || j != jend[ilink] && i != 0 && j != 0)
            {
                inext = i + d1[Math.Abs(dir[i, j])];
                jnext = j + d2[Math.Abs(dir[i, j])];
                i = inext;
                j = jnext;

                if (i != 0 && j != 0)
                {
                    coord.Write("{0,10:G} {1,10:G}\n", i+1, j+1);
                    area[i, j] = Math.Max(iord[ilink], area[i, j]);
                    icend = icord;
                    icord = icord + 1;
                }
            }

            inodeid = 0; //This is the first one so it will be the most downstream
            if (isnode2(iend[ilink], jend[ilink], inodes, jnodes, nnodes, out nodeno))
            {
                if (idnodes[nodeno] >= 0)
                {
                    inodeid = idnodes[nodeno];
                    idnodes[nodeno] = -1; //This logic to pick only the first one if there are multiple at a junction
                }
            }
            tree.Write("{0,10:G} {1,10:G} {2,10:G} {3,10:G} {4,10:G} {5,10:G} {6,10:G} {7,10:G}\n", 0, ics, icend, -1, prevl1[ilink], prevl2[ilink], iord[ilink], inodeid);
            

            icr = icord;

            //---  WRITE REMAINDER OF LINKS
            for (int il = 1; il <= ilink-1; il++)
            {
                i = istart[il];
                j = jstart[il];
                ics = icord;

                if (i != 0 && j != 0)
                {
                    coord.Write("{0,10:G} {1,10:G}\n", i+1, j+1);
                    area[i, j] = Math.Max(iord[il], area[i, j]);
                }
                icend = icord;
                icord = icord + 1;
                while (i != iend[il] || j != jend[il] && i != 0 && j != 0)
                {
                    inext = i + d1[Math.Abs(dir[i, j])];
                    jnext = j + d2[Math.Abs(dir[i, j])];
                    i = inext;
                    j = jnext;

                    if (i != 0 && j != 0)
                    {
                        coord.Write("{0,10:G} {1,10:G}\n", i + 1, j + 1);
                        area[i, j] = Math.Max(iord[il], area[i, j]);
                        icend = icord;
                        icord = icord + 1;
                    }
                }

                if (nextl[il] == ilink)
                {
                    nextl[il] = 0;
                }
                inodeid = -1;

                if (nextl[il] < 0)
                {
                    inodeid = 0;
                }

                if (isnode2(iend[il], jend[il], inodes, jnodes, nnodes, out nodeno))
                {
                    if (idnodes[nodeno] >= 0)
                    {
                        inodeid = idnodes[nodeno];
                        idnodes[nodeno] = -1; //This logic to pick only the first one if there are multiple at a junction
                    }
                }

                tree.Write("{0,10:G} {1,10:G} {2,10:G} {3,10:G} {4,10:G} {5,10:G} {6,10:G} {7,10:G}\n", il, ics, icend, nextl[il], prevl1[il], prevl2[il], iord[il], inodeid);
            }

            coord.Close();
            tree.Close();

            return err;
        }

        private static bool strt(int i, int j, int[,] area, short[,] dir, int nx, int ny, int igx, int igy, int itresh)
        {
            bool result = true;
            int[] d1 = new int[9];
            int[] d2 = new int[9];
            d1[1] = 0; d1[2] = -1; d1[3] = -1; d1[4] = -1; d1[5] = 0; d1[6] = 1; d1[7] = 1; d1[8] = 1;
            d2[1] = 1; d2[2] = 1; d2[3] = 0; d2[4] = -1; d2[5] = -1; d2[6] = -1; d2[7] = 0; d2[8] = 1;

            if (area[i, j] < itresh || dir[i, j] < 0)
            {
                result = false;
                if (area[i, j] <= 0)
                {
                    dir[i, j] = 0; //ZERO DIRECTIONS OUTSIDE AREA
                }
            }
            else //CHECK UPSTREAM PIXELS
            {
                int ni, nj, ind, jnd;
                for (int k = 1; k <= 8; k++)
                {
                    ni = i + d1[k]; //neighbor pixel
                    nj = j + d2[k];
                    if (dir[ni, nj] > 0)
                    {
                        ind = ni + d1[dir[ni, nj]]; //pixel downstream from neighbor
                        jnd = nj + d2[dir[ni, nj]];
                        if (ind == i && jnd == j) //Neighbor drains into i,j
                        {
                            if (area[ni, nj] >= itresh)
                            {
                                result = false;
                            }
                        }
                    }
                }
                //Do not allow sources that drain off the raster set i.e. a link of 0 length
                ni = i + d1[dir[i, j]];
                nj = j + d2[dir[i, j]];
                if (area[ni, nj] < itresh)
                {
                    result = false;
                }
            }

            return result;
        }

        private static bool isnode(int mnext, int mag, int i, int j, int[] inodes, int[] jnodes, int nnodes)
        {
            bool result = false;
            for (int k = 0; k < nnodes; k++)
            {
                if ((inodes[k]) == i && (jnodes[k]) == j)
                {
                    result = true;
                    if (mnext != mag) //false alarm it is a junction
                    {
                        result = false;
                    }
                    return result;
                }
            }
            return result;
        }

        private static bool isnode2(int i, int j, int[] inodes, int[] jnodes, int nnodes, out int nodeno)
        {
            nodeno = -1;
            for (int k = 0; k < nnodes; k++)
            {
                if ((inodes[k]) == i && (jnodes[k]) == j)
                {
                    //+1 is because arrays came from C
                    nodeno = k;  // for return to use in indexing
                    return true;
                }
            }
            return false;
        }


        private static int NetProp(short[,] dir, int[,] area, float[,] elev, string coordfile, int icr, int icmax, double dx, double dy, int nx, int ny, double[] bndbox, int err)
        {
            int[] d1 = new int[9];
            int[] d2 = new int[9];
            d1[1] = 0; d1[2] = -1; d1[3] = -1; d1[4] = -1; d1[5] = 0; d1[6] = 1; d1[7] = 1; d1[8] = 1;
            d2[1] = 1; d2[2] = 1; d2[3] = 0; d2[4] = -1; d2[5] = -1; d2[6] = -1; d2[7] = 0; d2[8] = 1;

            int mc = icmax + 1;
            double[] rarea = new double[mc];
            double[] length = new double[mc];
            double[] elv = new double[mc];
            int[] ia = new int[mc];
            int[] ja = new int[mc];

            StreamReader coordr = new StreamReader(coordfile);

            string bufferLine;
            int n;
            for (n = 0; n <= mc; n++)
            {
                try
                {
                    bufferLine = coordr.ReadLine();
                    if (bufferLine != "")
                    {
                        ia[n] = Convert.ToInt32(bufferLine.Substring(0, 10).Trim()) - 1;
                        ja[n] = Convert.ToInt32(bufferLine.Substring(11, 10).Trim()) - 1;
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {
                    break;
                }
            }
            coordr.Close();

            n = n - 1;
            for (int ic = 0; ic <= n; ic++)
            {
                rarea[ic] = area[ia[ic], ja[ic]] * dx * dy;
                elv[ic] = elev[ia[ic], ja[ic]];
            }

            int iroot = ia[icr];
            int jroot = ja[icr];

            //----TRACE STREAMS DOWNWARDS
            int i, j, inext, jnext;
            double DXx, DYy;
            for (int ic = 0; ic <= n; ic++)
            {
                length[ic] = 0;
                i = ia[ic];
                j = ja[ic];
                inext = i + d1[dir[i, j]];
                jnext = j + d2[dir[i, j]];

                while (dir[inext, jnext] != 0) //not yet end of path
                {
                    DXx = dx * (double)(j - jnext);
                    DYy = dy * (double)(i - inext);
                    length[ic] = length[ic] + Math.Sqrt(DXx * DXx + DYy * DYy);
                    i = inext;
                    j = jnext;
                    inext = i + d1[dir[i, j]];
                    jnext = j + d2[dir[i, j]];
                }
            }

            //--WRITE OUTPUT
            StreamWriter coordw = new StreamWriter(coordfile);
            double x, y;
            for (int ic = 0; ic <= n; ic++)
            {
                x = (ja[ic]) * dx + bndbox[0] + dx * 0.5;
                y = dy * (ny - ia[ic] - 1) + bndbox[1] + dy * 0.5;
                coordw.Write("{0,15:F4} {1,15:F4} {2,15:F4} {3,15:F4} {4,15:F4}\n", x, y, length[ic], elv[ic], rarea[ic]);
            }
            coordw.Close();

            return 0;
        }
        #endregion 



        #endregion

        #region "Delin Streams Shapefile And Subbasins Grid"

        /// <summary>
        /// A function which makes calls to TauDEM to delineate streams shapefile and subbasin grid
        /// </summary>
        /// <param name="D8Path"></param>
        /// <param name="TreeDatPath"></param>
        /// <param name="CoordDatPath"></param>
        /// <param name="StreamShapeResultPath"></param>
        /// <param name="WatershedGridResultPath"></param>
        /// <param name="tauCallback"></param>
        /// <returns></returns>
        public static int DelinStreamsAndSubBasins(string D8Path, string TreeDatPath, string CoordDatPath, string StreamShapeResultPath, string WatershedGridResultPath, TKTAUDEMLib.ItkCallback tauCallback)
        {
            int result = -1;
            int ordert = 1;
            int subbno = 0;

            TKTAUDEMLib.TauDEM TaudemLib = new TKTAUDEMLib.TauDEM();
            if (tauCallback != null) TaudemLib.Callback = tauCallback;

            if (tauCallback != null) tauCallback.Progress("Status", 0, "Stream Shapefile and Watershed Grid");
            DataManagement.DeleteGrid(ref WatershedGridResultPath);
            DataManagement.DeleteShapefile(ref StreamShapeResultPath);

            try
            {
                //result = TaudemLib.Subbasinsetup(D8Path, WatershedGridResultPath, TreeDatPath, CoordDatPath, StreamShapeResultPath, ordert, subbno);
                result = CreateSubbasinGridAndNetworkShape(D8Path, TreeDatPath, CoordDatPath, ref ordert, ref subbno, WatershedGridResultPath, StreamShapeResultPath, tauCallback);
            }
            catch
            {
            }

            if (result != 0)
            {
                MapWinUtility.Logger.Message(TaudemLib.getErrorMsg(result), "TauDEM Error " + result, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.DialogResult.OK);
            }

            CopyProjectionFromGrid(D8Path, WatershedGridResultPath);
            CopyProjectionFromGrid(D8Path, StreamShapeResultPath);
            if (tauCallback != null) tauCallback.Progress("Status", 0, "");
            return result;
        }

        /// <summary>
        /// An overload of the DelinStreamsAndSubBasins function which will generate a GeoprocDialog for the DelinStreamsAndSubBasins function
        /// </summary>
        /// <param name="tauCallback"></param>
        /// <returns></returns>
        public static int DelinStreamsAndSubBasins(TKTAUDEMLib.ItkCallback tauCallback)
        {
            return doDelinStreamsAndSubBasinsDiag(tauCallback);
        }

        /// <summary>
        /// An overload of the DelinStreamsAndSubBasins function which will generate a GeoprocDialog for the DelinStreamsAndSubBasins function
        /// </summary>
        /// <returns></returns>
        public static int DelinStreamsAndSubBasins()
        {
            return doDelinStreamsAndSubBasinsDiag(null);
        }

        private static int doDelinStreamsAndSubBasinsDiag(TKTAUDEMLib.ItkCallback tauCallback)
        {
            GeoProcDialog delinstreamshedDiag = new GeoProcDialog();
            FileElement d8Elem = delinstreamshedDiag.Add_FileElement(GeoProcDialog.ElementTypes.OpenGridFile);
            FileElement treeDatElem = delinstreamshedDiag.Add_FileElement(GeoProcDialog.ElementTypes.OpenFile);
            FileElement coordDatElem = delinstreamshedDiag.Add_FileElement(GeoProcDialog.ElementTypes.OpenFile);
            FileElement streamShapeResElem = delinstreamshedDiag.Add_FileElement(GeoProcDialog.ElementTypes.SaveShapefile);
            FileElement shedGridResElem = delinstreamshedDiag.Add_FileElement(GeoProcDialog.ElementTypes.SaveGridFile);

            delinstreamshedDiag.Text = "TauDEM Stream Network Shapefile and Sub-basin Grid";
            delinstreamshedDiag.HelpTitle = "TauDEM Stream Network Shapefile and Sub-basin Grid";
            delinstreamshedDiag.HelpText = "This function will generate a stream network shapefile and sub-basin grid from the given inputs.";
            delinstreamshedDiag.Height = 350;
            delinstreamshedDiag.HelpPanelVisible = false;

            d8Elem.Caption = "D8 Flow Direction Grid Path";
            d8Elem.HelpButtonVisible = false;

            treeDatElem.Caption = "Network Tree Data File Path";
            treeDatElem.Filter = "Data Files (*.dat)|*.dat";
            treeDatElem.HelpButtonVisible = false;

            coordDatElem.Caption = "Network Coordinates Data File Path";
            coordDatElem.Filter = "Data Files (*.dat)|*.dat";
            coordDatElem.HelpButtonVisible = false;

            streamShapeResElem.Caption = "Stream Network Shapefile Result Path";
            streamShapeResElem.HelpButtonVisible = false;

            shedGridResElem.Caption = "Sub-basins Grid Result Path";
            shedGridResElem.HelpButtonVisible = false;


            if (delinstreamshedDiag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return Hydrology.DelinStreamsAndSubBasins(d8Elem.Filename, treeDatElem.Filename, coordDatElem.Filename, streamShapeResElem.Filename, shedGridResElem.Filename, tauCallback);
            }
            return -2;
        }




        #region "    Subbasinsetup conversion"

            private static int CreateSubbasinGridAndNetworkShape(string D8GridPath, string TreeDatPath, string CoordDatPath, ref int ordert, ref int subbno, string ResultBasinGridPath, string ResultNetShapePath, TKTAUDEMLib.ItkCallback tauCallback)
            {
                int newperc = 0;
                int oldperc = 0;
                if (tauCallback != null) tauCallback.Progress("Status", 0, "Stream Shapefile and Watershed Grid");
                int err = 0;
                bool success;

                int numTreeNodes = -1;
                long[] dsNodeID;
                int[,] FlowNet;
                if (ReadTreeFile(TreeDatPath, out FlowNet, out dsNodeID, ref numTreeNodes) == 1)
                {
                    return 1;
                }

                int numCoords = 0;
                float[,] CoordList;
                if (ReadCoordFile(CoordDatPath, out CoordList, ref numCoords) == 1)
                {
                    return 1;
                }

                int numBasins = 0;
                int currReach = 2 * (numTreeNodes + 1) - 1; //Initialize current reach number
                int maxReaches = 5 * (numTreeNodes + 1) - 2; //The maximum number of reaches possible in binary tree
                int[,] ReachConnections = new int[maxReaches + 1, 3];
                float[,] ReachProperties = new float[maxReaches + 1, 5];
                int[] Magnitude = new int[numTreeNodes + 2];

                MapWinGIS.Grid d8Grid = new MapWinGIS.Grid();
                success = d8Grid.Open(D8GridPath, MapWinGIS.GridDataType.UnknownDataType, true, MapWinGIS.GridFileType.UseExtension, null);
                if (success)
                {
                    err = 0;
                }
                else
                {
                    err = 1;
                }

                int numCols = d8Grid.Header.NumberCols;
                int numRows = d8Grid.Header.NumberRows;
                MapWinGIS.GridHeader BasinGridHead = new MapWinGIS.GridHeader();
                BasinGridHead.CopyFrom(d8Grid.Header);
                BasinGridHead.NodataValue = -1;

                MapWinGIS.Grid BasinGrid = new MapWinGIS.Grid();
                BasinGrid.CreateNew(ResultBasinGridPath, BasinGridHead, MapWinGIS.GridDataType.ShortDataType, BasinGridHead.NodataValue, true, MapWinGIS.GridFileType.UseExtension, null);
                //TODO: May need this to be a temp path instead of result grid

                MapWinGIS.Shapefile NetSF = new MapWinGIS.Shapefile();
                NetSF.CreateNew(ResultNetShapePath, MapWinGIS.ShpfileType.SHP_POLYLINE);
                NetSF.StartEditingShapes(true, null);
                InitializeNetFields(ref NetSF);

                Queue<int> Links = new Queue<int>();
                
                for (int i = 0; i <= numTreeNodes; i++)
                {
                    if (numTreeNodes > 0)
                    {
                        newperc = Convert.ToInt32((Convert.ToDouble(i) / Convert.ToDouble(numTreeNodes)) * 100);
                        if (newperc > oldperc)
                        {
                            if (tauCallback != null) tauCallback.Progress("Status", newperc, "Stream Shapefile and Watershed Grid");
                            oldperc = newperc;
                        }
                    }
                    
                    if (FlowNet[i, 3] == -1) //This is a root link
                    {
                        if (ordert >= 0)
                        {
                            PopulateNetworkProperties(ref numBasins, ref i, ref FlowNet, ref CoordList, ref currReach, ref ordert, ref subbno, ref Magnitude, ref dsNodeID, ref numRows, ref numCols, ref ReachConnections, ref ReachProperties, ref d8Grid, ref BasinGrid, ref NetSF, ref tauCallback);
                        }
                        else
                        {
                            subbno = subbno + 1;
                            PopulateNetworkProperties(ref numBasins, ref i, ref FlowNet, ref CoordList, ref currReach, ref ordert, ref subbno, ref Magnitude, ref dsNodeID, ref numRows, ref numCols, ref ReachConnections, ref ReachProperties, ref d8Grid, ref BasinGrid, ref NetSF, ref tauCallback);
                        }
                    }

                    if (FlowNet[i, 4] == 0 && FlowNet[i, 5] == 0) //This is a branch
                    {
                        Links.Enqueue(i);
                    }
                }

                if (Links.Count > 0)
                {
                    numBasins = 0;
                    if (ordert >= 0)
                    {
                        MarkBasinsAndNetworkStack(ref Links, ref numBasins, ref FlowNet, ref CoordList, ref currReach, ref ordert, ref subbno, ref Magnitude, ref dsNodeID, ref numRows, ref numCols, ref ReachConnections, ref ReachProperties, ref d8Grid, ref BasinGrid, ref NetSF, ref tauCallback);
                    }
                    else
                    {
                        subbno = subbno + 1;
                        MarkBasinsAndNetworkStack(ref Links, ref numBasins, ref FlowNet, ref CoordList, ref currReach, ref ordert, ref subbno, ref Magnitude, ref dsNodeID, ref numRows, ref numCols, ref ReachConnections, ref ReachProperties, ref d8Grid, ref BasinGrid, ref NetSF, ref tauCallback);
                    }
                }

                NetSF.StopEditingShapes(true, true, null);
                NetSF.Close();

                success = BasinGrid.Save(ResultBasinGridPath, MapWinGIS.GridFileType.UseExtension, null);
                if (success)
                {
                    err = 0;
                }
                else
                {
                    err = 2;
                }
                BasinGrid.Close();
                if (tauCallback != null) tauCallback.Progress("Status", 0, "Stream Shapefile and Watershed Grid");

                return err;
            }

            private static int ReadTreeFile(string TreeDatPath, out int[,] FlowNet, out long[] dsNodeID, ref int numTreeNodes)
            {
                System.IO.StreamReader tree = null;
                try
                {
                    tree = new System.IO.StreamReader(TreeDatPath);
                    string line;
                    while (!tree.EndOfStream)
                    {
                        line = tree.ReadLine();
                        numTreeNodes = numTreeNodes + 1;
                    }
                    tree.Close();
                    FlowNet = new int[numTreeNodes + 1, 7];
                    dsNodeID = new long[numTreeNodes + 1];
                    tree = new System.IO.StreamReader(TreeDatPath);
                    for (int i = 0; i <= numTreeNodes; i++)
                    {
                        line = tree.ReadLine();
                        int counter = -1;
                        string[] split = line.Split(' ');
                        for (int j = 0; j <= split.Length - 1; j++)
                        {
                            if (split[j] != "")
                            {
                                counter = counter + 1;
                                if (counter < 7)
                                {
                                    FlowNet[i, counter] = Int32.Parse(split[j]);
                                }
                                else if (counter == 7)
                                {
                                    dsNodeID[i] = Int32.Parse(split[j]);
                                    break;
                                }
                            }
                        }
                    }
                    tree.Close();
                }
                catch
                {
                    FlowNet = new int[0, 0];
                    dsNodeID = new long[0];
                    return 1;
                }
                finally
                {
                    if (tree != null)
                    {
                        tree.Close();
                    }
                }
                return 0;
            }

            private static int ReadCoordFile(string CoordDatPath, out float[,] CoordList, ref int numCoords)
            {
                System.IO.StreamReader coordSR = null;
                try
                {
                    string line;
                    coordSR = new System.IO.StreamReader(CoordDatPath);
                    while (!coordSR.EndOfStream)
                    {
                        line = coordSR.ReadLine();
                        numCoords = numCoords + 1;
                    }
                    coordSR.Close();
                    CoordList = new float[numCoords + 1, 5];
                    numCoords = numCoords - 1;
                    coordSR = new System.IO.StreamReader(CoordDatPath);
                    for (int i = 0; i <= numCoords; i++)
                    {
                        line = coordSR.ReadLine();
                        int counter = -1;
                        string[] split = line.Split(' ');
                        for (int j = 0; j <= split.Length - 1; j++)
                        {
                            if (split[j] != "")
                            {
                                counter = counter + 1;
                                if (counter < 4)
                                {
                                    CoordList[i, counter] = float.Parse(split[j]);
                                }
                                else if (counter == 4)
                                {
                                    CoordList[i, counter] = float.Parse(split[j]);
                                    break;
                                }
                            }
                        }
                    }
                    coordSR.Close();
                }
                catch
                {
                    CoordList = new float[0, 0];
                    return 1;
                }
                finally
                {
                    if (coordSR != null)
                    {
                        coordSR.Close();
                    }
                }
                return 0;
            }

            private static int PopulateNetworkProperties(ref int numBasins, ref int StartLink, ref int[,] FlowNet, ref float[,] CoordList, ref int currReach, ref int ordert, ref int subbno, ref int[] Magnitude, ref long[] dsNodeID, ref int numRows, ref int numCols, ref int[,] ReachConnections, ref float[,] ReachProperties, ref MapWinGIS.Grid d8Grid, ref MapWinGIS.Grid BasinGrid, ref MapWinGIS.Shapefile NetSF, ref TKTAUDEMLib.ItkCallback tauCallback)
            {
                int currLink;
                int currDSLink;
                int currDSFrom;
                int row;
                int UpstreamLink1;
                int UpstreamLink2;
                int col;
                int thisreach;
                int BasinID;
                int flag = 0;
                int LinkEnd;
                int LinkBegin;
                int LinkEndArea = 0;
                //  variables for CoordList positions 
                float x;
                float y;

                Stack<int> links = new Stack<int>();
                links.Push(-1);
                links.Push(-1);
                links.Push(StartLink);

                while (links.Count != 0)
                {
                    if (tauCallback != null) tauCallback.Progress("Status", 0, "Stream Shapefile and Watershed Grid");
                    flag = 0;
                    LinkEndArea = 0;

                    currLink = links.Pop();
                    currDSFrom = links.Pop();
                    currDSLink = links.Pop();

                    LinkEnd = FlowNet[currLink, 3 - 1];//*  This is CoordList of end of link */
                    LinkBegin = FlowNet[currLink, 2 - 1];//*  This is CoordList of beg of link */
                    Magnitude[currLink] = 0;// Initiaize magnitude recursion

                    if (LinkBegin < LinkEnd)
                    {
                        //has physical length
                        numBasins = numBasins + 1;
                        if (ordert < 0)
                        {
                            numBasins = subbno;
                        }

                        if (FlowNet[currLink, 4 - 1] != -1) //For anything other than a downstream end area is defined one grid cell back
                        {
                            LinkEndArea = LinkEnd - 1;
                        }
                        else
                        {
                            LinkEndArea = LinkEnd;
                        }

                        x = CoordList[LinkEndArea, 1 - 1];
                        y = CoordList[LinkEndArea, 2 - 1];
                        BasinGrid.ProjToCell(x, y, out col, out row);
                        if (row < 0 | row > numRows | col < 0 | col > numCols)
                        {
                            if (currDSLink != -1 && currDSFrom != -1)
                            {
                                ReachConnections[currDSLink, currDSFrom] = -1;
                            }
                        }
                    }
                    else
                    {
                        x = CoordList[LinkEndArea, 1 - 1];
                        y = CoordList[LinkEndArea, 2 - 1];
                        BasinGrid.ProjToCell(x, y, out col, out row);
                        if (row < 0 | row > numRows | col < 0 | col > numCols)
                        {
                            if (currDSLink != -1 && currDSFrom != -1)
                            {
                                ReachConnections[currDSLink, currDSFrom] = -2;
                            }
                        }
                        LinkEndArea = LinkEnd;
                        flag = 1;
                    }

                    if (tauCallback != null) tauCallback.Progress("Status", 50, "Stream Shapefile and Watershed Grid");

                    //Search for upstream basins
                    UpstreamLink1 = FlowNet[currLink, 5 - 1]; //pointers to upstream links
                    UpstreamLink2 = FlowNet[currLink, 6 - 1];

                    if (UpstreamLink1 > 0 | UpstreamLink2 > 0)
                    {
                        if (flag == 1)
                        {
                            //dummy 0 length reach
                            currReach = currReach + 1;
                            thisreach = currReach;
                            if (ordert <= 0)
                            {
                                BasinID = subbno;
                            }
                            else
                            {
                                BasinID = 0;
                            }

                            ReachConnections[thisreach, 1 - 1] = thisreach;
                            if (UpstreamLink1 > 0)
                            {
                                links.Push(thisreach);
                                links.Push(2 - 1);
                                links.Push(UpstreamLink1);
                                Magnitude[currLink] = Magnitude[currLink] + Magnitude[UpstreamLink1];
                            }
                            else
                            {
                                ReachConnections[thisreach, 2 - 1] = 0;
                            }
                            //AddReachShape3(ref NetSF, ref FlowNet, ref CoordList, currLink, BasinID, Magnitude[currLink], dsNodeID[currLink]);

                            //'Assign properties to dummy reach
                            ReachProperties[thisreach, 1 - 1] = 0.01f; //slope
                            ReachProperties[thisreach, 2 - 1] = CoordList[LinkEndArea, 5 - 1]; //ontributing area
                            ReachProperties[thisreach, 3 - 1] = 0; //Length
                            ReachProperties[thisreach, 4 - 1] = CoordList[LinkEndArea, 0]; //end x CoordList
                            ReachProperties[thisreach, 5 - 1] = CoordList[LinkEndArea, 1]; //end x CoordList
                        }
                        else
                        {
                            //Lower half reach
                            currReach = currReach + 1;
                            thisreach = currReach;
                            ReachConnections[thisreach, 1 - 1] = thisreach;
                            ReachConnections[thisreach, 2 - 1] = numBasins;
                            ReachConnections[thisreach, 3 - 1] = currReach + 1;
                            ReachProperties[thisreach, 3 - 1] = (CoordList[LinkBegin, 3 - 1] - CoordList[LinkEnd, 3 - 1]) / 2;
                            ReachProperties[thisreach, 2 - 1] = CoordList[LinkEndArea, 5 - 1];
                            ReachProperties[thisreach, 1 - 1] = (CoordList[LinkBegin, 4 - 1] - CoordList[LinkEnd, 4 - 1]);
                            ReachProperties[thisreach, 4 - 1] = CoordList[LinkEndArea, 0]; //end x CoordList
                            ReachProperties[thisreach, 5 - 1] = CoordList[LinkEndArea, 1]; //end y coordinate
                            if (ordert <= 0)
                            {
                                BasinID = subbno;
                            }
                            else
                            {
                                BasinID = numBasins;
                            }

                            //Upper half reach
                            currReach = currReach + 1;
                            ReachConnections[thisreach + 1, 1 - 1] = currReach;
                            if (UpstreamLink1 > 0)
                            {
                                links.Push(thisreach + 1);
                                links.Push(2 - 1);
                                links.Push(UpstreamLink1);
                                Magnitude[currLink] = Magnitude[currLink] + Magnitude[UpstreamLink1];
                            }
                            else
                            {
                                ReachConnections[thisreach + 1, 2 - 1] = 0;
                            }
                            if (UpstreamLink2 > 0)
                            {
                                links.Push(thisreach + 1);
                                links.Push(3 - 1);
                                links.Push(UpstreamLink2);
                                Magnitude[currLink] = Magnitude[currLink] + Magnitude[UpstreamLink2];
                            }
                            else
                            {
                                ReachConnections[thisreach + 1, 3 - 1] = 0;
                            }
                            //AddReachShape3(ref NetSF, ref FlowNet, ref CoordList, currLink, BasinID, Magnitude[currLink], dsNodeID[currLink]);
                            ReachProperties[thisreach + 1, 3 - 1] = ReachProperties[thisreach, 3 - 1];
                            ReachProperties[thisreach + 1, 2 - 1] = ReachProperties[thisreach, 2 - 1];
                            ReachProperties[thisreach + 1, 1 - 1] = ReachProperties[thisreach, 1 - 1];
                            ReachProperties[thisreach + 1, 4 - 1] = CoordList[(LinkEndArea + LinkBegin) / 2, 0]; //approx midpoint
                            ReachProperties[thisreach + 1, 5 - 1] = CoordList[(LinkEndArea + LinkBegin) / 2, 1];
                        }
                    }
                    else
                    {
                        //This is an external basin
                        currReach = currReach + 1;
                        thisreach = currReach;
                        ReachConnections[thisreach, 1 - 1] = currReach;
                        ReachConnections[thisreach, 2 - 1] = numBasins;
                        ReachConnections[thisreach, 3 - 1] = 0;
                        ReachProperties[thisreach, 3 - 1] = (CoordList[LinkBegin, 3 - 1] - CoordList[LinkEnd, 3 - 1]) / 2;
                        ReachProperties[thisreach, 2 - 1] = CoordList[LinkEndArea, 5 - 1];
                        if (ReachProperties[thisreach, 3 - 1] <= 0)
                        {
                            ReachProperties[thisreach, 1 - 1] = 0.01f;
                        }
                        else
                        {
                            ReachProperties[thisreach, 1 - 1] = (CoordList[LinkBegin, 4 - 1] - CoordList[LinkEnd, 4 - 1]) / (2 * ReachProperties[thisreach, 3 - 1]);
                        }
                        ReachProperties[thisreach, 4 - 1] = CoordList[LinkEndArea, 0]; //end x coordinate
                        ReachProperties[thisreach, 5 - 1] = CoordList[LinkEndArea, 1]; //end y coordinate

                        if (ordert <= 0)
                        {
                            BasinID = subbno;
                        }
                        else
                        {
                            BasinID = numBasins;
                        }
                        Magnitude[currLink] = 1;  //magnitude of external basin
                        //AddReachShape3(ref NetSF, ref FlowNet, ref CoordList, currLink, BasinID, Magnitude[currLink], dsNodeID[currLink]);
                    }
                    if (currDSLink != -1 && currDSFrom != -1)
                    {
                        ReachConnections[currDSLink, currDSFrom] = thisreach;
                    }

                    if (tauCallback != null) tauCallback.Progress("Status", 100, "Stream Shapefile and Watershed Grid");
                }
                return 0;
            }

            private static int MarkBasinsAndNetworkStack(ref Queue<int> Links, ref int numBasins, ref int[,] FlowNet, ref float[,] CoordList, ref int currReach, ref int ordert, ref int subbno, ref int[] Magnitude, ref long[] dsNodeID, ref int numRows, ref int numCols, ref int[,] ReachConnections, ref float[,] ReachProperties, ref MapWinGIS.Grid d8Grid, ref MapWinGIS.Grid BasinGrid, ref MapWinGIS.Shapefile NetSF, ref TKTAUDEMLib.ItkCallback tauCallback)
            {
                int newperc = 0;
                int oldperc = 0;
                bool alreadyMarked = false;
                int currLink, row, col, DownstreamLink, LinkEnd, LinkBegin, LinkEndArea = 0;
                //  variables for CoordList positions 
                float x, y;

                List<int> marked = new List<int>();
                List<MapWinGIS.Point> markedPoint = new List<MapWinGIS.Point>();

                int totLinks;
                while (Links.Count != 0)
                {
                    totLinks = Links.Count;
                    if (totLinks > 0)
                    {
                        newperc = Convert.ToInt32((Convert.ToDouble(Links.Count) / Convert.ToDouble(totLinks)) * 100);
                        if (newperc > oldperc)
                        {
                            if (tauCallback != null) tauCallback.Progress("Status", newperc, "Stream Shapefile and Watershed Grid");
                            oldperc = newperc;
                        }
                    }

                    
                    LinkEndArea = 0;

                    currLink = Links.Dequeue();


                    if ((FlowNet[currLink, 4] == 0 || (FlowNet[currLink, 4] != 0 && marked.Contains(FlowNet[currLink, 4]))) && (FlowNet[currLink, 5] == 0 || (FlowNet[currLink, 5] != 0 && marked.Contains(FlowNet[currLink, 5]))))
                    {
                        LinkEnd = FlowNet[currLink, 3 - 1];//*  This is CoordList of end of link */
                        LinkBegin = FlowNet[currLink, 2 - 1];//*  This is CoordList of beg of link */
                        if (LinkBegin < LinkEnd)
                        {
                            //has physical length
                            numBasins = numBasins + 1;
                            if (ordert < 0)
                            {
                                numBasins = subbno;
                            }

                            if (FlowNet[currLink, 4 - 1] != -1) //For anything other than a downstream end area is defined one grid cell back
                            {
                                LinkEndArea = LinkEnd - 1;
                            }
                            else
                            {
                                LinkEndArea = LinkEnd;
                            }

                            x = CoordList[LinkEndArea, 1 - 1];
                            y = CoordList[LinkEndArea, 2 - 1];
                            BasinGrid.ProjToCell(x, y, out col, out row);
                            alreadyMarked = false;
                            for (int i = 0; i < markedPoint.Count; i++)
                            {
                                if ((double)col == markedPoint[i].x && (double)row == markedPoint[i].y)
                                {
                                    alreadyMarked = true;
                                    break;
                                }
                            }
                            if (!alreadyMarked)
                            {
                                marked.Add(currLink);
                                MapWinGIS.Point pt = new MapWinGIS.Point();
                                pt.x = (double)col;
                                pt.y = (double)row;
                                markedPoint.Add(pt);
                                MarkBasinAreaStack(ref d8Grid, row, col, numBasins, numCols, numRows, ref BasinGrid, ref tauCallback); //Label the region that drains to this pixel
                                AddReachShape(ref NetSF, ref FlowNet, ref CoordList, currLink, numBasins, Magnitude[currLink], dsNodeID[currLink]);
                            }
                        }
                        else
                        {
                            LinkEndArea = LinkEnd;
                        }

                        DownstreamLink = FlowNet[currLink, 4 - 1];
                        if (DownstreamLink >= 0 && !Links.Contains(DownstreamLink) && !marked.Contains(DownstreamLink))
                        {
                            Links.Enqueue(DownstreamLink);
                        }
                    }
                    else
                    {
                        Links.Enqueue(currLink);
                    }                
                }

                return 0;
            }

            private static void MarkBasinAreaStack(ref MapWinGIS.Grid d8Grid, int StartRow, int StartCol, int BasinID, int numCols, int numRows, ref MapWinGIS.Grid BasinGrid, ref TKTAUDEMLib.ItkCallback tauCallback)
            {
                int row;
                int col;
                int newRow;
                int newCol;
                int[] rowMod = new int[9];
                int[] colMod = new int[9];
                rowMod[1] = 0; rowMod[2] = -1; rowMod[3] = -1; rowMod[4] = -1; rowMod[5] = 0;  rowMod[6] = 1;  rowMod[7] = 1; rowMod[8] = 1;
                colMod[1] = 1; colMod[2] = 1;  colMod[3] = 0;  colMod[4] = -1; colMod[5] = -1; colMod[6] = -1; colMod[7] = 0; colMod[8] = 1;

                Stack<int> cells = new Stack<int>();
                cells.Push(StartCol);
                cells.Push(StartRow);

                int totCells = 0, newperc = 0, oldperc = 0;
                while (cells.Count != 0)
                {
                    if (totCells > 0)
                    {
                        newperc = Convert.ToInt32((Convert.ToDouble(cells.Count) / Convert.ToDouble(totCells)) * 100);
                        if (newperc > oldperc)
                        {
                            if (tauCallback != null) tauCallback.Progress("Status", newperc, "Stream Shapefile and Watershed Grid");
                            oldperc = newperc;
                        }
                    }

                    row = cells.Pop();
                    col = cells.Pop();

                    if ((short)BasinGrid.get_Value(col, row) == -1)
                    {
                        if (row != 0 & row != numRows - 1 & col != 0 & col != numCols - 1 & (short)d8Grid.get_Value(col, row) != -1)
                        {
                            //Not on boundary
                            BasinGrid.set_Value(col, row, BasinID);
                            for (int k = 1; k <= 8; k++)
                            {
                                newRow = row + rowMod[k];
                                newCol = col + colMod[k];

                                //test if neighbor drains towards cell excluding boundaries
                                if ((short)d8Grid.get_Value(newCol, newRow) >= 0 & (((short)d8Grid.get_Value(newCol, newRow) - k) == 4 | ((short)d8Grid.get_Value(newCol, newRow) - k) == -4))
                                {
                                    cells.Push(newCol);
                                    cells.Push(newRow);
                                }
                            }
                        }
                    }
                }
            }
                            
            private static void InitializeNetFields(ref MapWinGIS.Shapefile netSF)
            {
                int zero = 0;
                MapWinGIS.Field field = new MapWinGIS.Field();
                field.Name = "DOUT_MID";
                field.Type = MapWinGIS.FieldType.DOUBLE_FIELD;
                field.Width = 16;
                field.Precision = 1;
                netSF.EditInsertField(field, ref zero, null);

                MapWinGIS.Field field2 = new MapWinGIS.Field();
                field2.Name = "DOUT_START";
                field2.Type = MapWinGIS.FieldType.DOUBLE_FIELD;
                field2.Width = 16;
                field2.Precision = 1;
                netSF.EditInsertField(field2, ref zero, null);

                MapWinGIS.Field field3 = new MapWinGIS.Field();
                field3.Name = "DOUT_END";
                field3.Type = MapWinGIS.FieldType.DOUBLE_FIELD;
                field3.Width = 16;
                field3.Precision = 1;
                netSF.EditInsertField(field3, ref zero, null);

                MapWinGIS.Field field4 = new MapWinGIS.Field();
                field4.Name = "WSNO";
                field4.Type = MapWinGIS.FieldType.INTEGER_FIELD;
                field4.Width = 6;
                field4.Precision = 0;
                netSF.EditInsertField(field4, ref zero, null);

                MapWinGIS.Field field5 = new MapWinGIS.Field();
                field5.Name = "US_Cont_Area";
                field5.Type = MapWinGIS.FieldType.DOUBLE_FIELD;
                field5.Width = 16;
                field5.Precision = 1;
                netSF.EditInsertField(field5, ref zero, null);

                MapWinGIS.Field field6 = new MapWinGIS.Field();
                field6.Name = "Straight_Length";
                field6.Type = MapWinGIS.FieldType.DOUBLE_FIELD;
                field6.Width = 16;
                field6.Precision = 0;
                netSF.EditInsertField(field6, ref zero, null);

                MapWinGIS.Field field7 = new MapWinGIS.Field();
                field7.Name = "Slope";
                field7.Type = MapWinGIS.FieldType.DOUBLE_FIELD;
                field7.Width = 16;
                field7.Precision = 12;
                netSF.EditInsertField(field7, ref zero, null);

                MapWinGIS.Field field8 = new MapWinGIS.Field();
                field8.Name = "Drop";
                field8.Type = MapWinGIS.FieldType.DOUBLE_FIELD;
                field8.Width = 16;
                field8.Precision = 2;
                netSF.EditInsertField(field8, ref zero, null);

                MapWinGIS.Field field9 = new MapWinGIS.Field();
                field9.Name = "DS_Cont_Area";
                field9.Type = MapWinGIS.FieldType.DOUBLE_FIELD;
                field9.Width = 16;
                field9.Precision = 1;
                netSF.EditInsertField(field9, ref zero, null);

                MapWinGIS.Field field10 = new MapWinGIS.Field();
                field10.Name = "Magnitude";
                field10.Type = MapWinGIS.FieldType.INTEGER_FIELD;
                field10.Width = 6;
                field10.Precision = 0;
                netSF.EditInsertField(field10, ref zero, null);

                MapWinGIS.Field field11 = new MapWinGIS.Field();
                field11.Name = "Length";
                field11.Type = MapWinGIS.FieldType.DOUBLE_FIELD;
                field11.Width = 16;
                field11.Precision = 1;
                netSF.EditInsertField(field11, ref zero, null);

                MapWinGIS.Field field12 = new MapWinGIS.Field();
                field12.Name = "Order";
                field12.Type = MapWinGIS.FieldType.INTEGER_FIELD;
                field12.Width = 6;
                field12.Precision = 0;
                netSF.EditInsertField(field12, ref zero, null);

                MapWinGIS.Field field13 = new MapWinGIS.Field();
                field13.Name = "dsNodeID";
                field13.Type = MapWinGIS.FieldType.DOUBLE_FIELD;
                field13.Width = 12;
                field13.Precision = 1;
                netSF.EditInsertField(field13, ref zero, null);

                MapWinGIS.Field field14 = new MapWinGIS.Field();
                field14.Name = "USLINKNO2";
                field14.Type = MapWinGIS.FieldType.INTEGER_FIELD;
                field14.Width = 6;
                field14.Precision = 0;
                netSF.EditInsertField(field14, ref zero, null);

                MapWinGIS.Field field15 = new MapWinGIS.Field();
                field15.Name = "USLINKNO1";
                field15.Type = MapWinGIS.FieldType.INTEGER_FIELD;
                field15.Width = 6;
                field15.Precision = 0;
                netSF.EditInsertField(field15, ref zero, null);

                MapWinGIS.Field field16 = new MapWinGIS.Field();
                field16.Name = "DSLINKNO";
                field16.Type = MapWinGIS.FieldType.INTEGER_FIELD;
                field16.Width = 6;
                field16.Precision = 0;
                netSF.EditInsertField(field16, ref zero, null);

                MapWinGIS.Field field17 = new MapWinGIS.Field();
                field17.Name = "LINKNO";
                field17.Type = MapWinGIS.FieldType.INTEGER_FIELD;
                field17.Width = 6;
                field17.Precision = 0;
                netSF.EditInsertField(field17, ref zero, null);
            }

            private static int AddReachShape(ref MapWinGIS.Shapefile NetSF, ref int[,] FlowNet, ref float[,] CoordList, int currLink, int BasinID, int Magnitude, long dsNodeID)
            {
                double x = 0;
                double y = 0;
                double length;
                double glength;
                double x1;
                double y1;
                double xlast;
                double ylast;
                double usarea;
                double dsarea;
                double dslast;
                double dl;
                double drop;
                double slope;
                int istart;
                int iend;
                int zero;

                istart = FlowNet[currLink, 1];  //start index for reach
                iend = FlowNet[currLink, 2]; //end index for reach
                x1 = CoordList[istart, 0]; //start x CoordList for reach
                y1 = CoordList[istart, 1]; //start y CoordList for reach
                length = 0;
                xlast = x1;
                ylast = y1;
                usarea = CoordList[istart, 4];
                dslast = usarea;
                dsarea = usarea;

                MapWinGIS.Shape shp = new MapWinGIS.Shape();
                shp.Create(MapWinGIS.ShpfileType.SHP_POLYLINE);
                for (int j = 0; j <= (iend - istart); j++)
                {
                    x = CoordList[j + istart, 0];
                    y = CoordList[j + istart, 1];
                    dl = Math.Sqrt((x - xlast) * (x - xlast) + (y - ylast) * (y - ylast));
                    if (dl > 0)
                    {
                        length = length + dl;
                        xlast = x;
                        ylast = y;
                        dsarea = dslast; //keeps track of last ds area
                        dslast = CoordList[j + istart, 4];
                    }
                    MapWinGIS.Point p = new MapWinGIS.Point();
                    p.x = x;
                    p.y = y;
                    zero = 0;
                    shp.InsertPoint(p, ref zero);
                }
                if (iend == istart)
                {
                    MapWinGIS.Point p = new MapWinGIS.Point();
                    p.x = x;
                    p.y = y;
                    int numpts = shp.numPoints;
                    shp.InsertPoint(p, ref numpts);
                }
                drop = CoordList[istart, 3] - CoordList[iend, 3];
                slope = 0;
                float dsdist = CoordList[iend, 2];
                float usdist = CoordList[istart, 2];
                float middist = (dsdist + usdist) * 0.5f;
                if (length > 0)
                {
                    slope = drop / length;
                }
                glength = Math.Sqrt((x - x1) * (x - x1) + (y - y1) * (y - y1));
                zero = 0;
                NetSF.EditInsertShape(shp, ref zero);
                NetSF.EditCellValue(0, 0, currLink);
                NetSF.EditCellValue(1, 0, FlowNet[currLink, 3]);
                NetSF.EditCellValue(2, 0, FlowNet[currLink, 4]);
                NetSF.EditCellValue(3, 0, FlowNet[currLink, 5]);
                NetSF.EditCellValue(4, 0, dsNodeID);
                NetSF.EditCellValue(5, 0, FlowNet[currLink, 6]);
                NetSF.EditCellValue(6, 0, length);
                NetSF.EditCellValue(7, 0, Magnitude);
                NetSF.EditCellValue(8, 0, dsarea);
                NetSF.EditCellValue(9, 0, drop);
                NetSF.EditCellValue(10, 0, slope);
                NetSF.EditCellValue(11, 0, glength);
                NetSF.EditCellValue(12, 0, usarea);
                NetSF.EditCellValue(13, 0, BasinID);
                NetSF.EditCellValue(14, 0, dsdist);
                NetSF.EditCellValue(15, 0, usdist);
                NetSF.EditCellValue(16, 0, middist);

                return 0;
            }


        #endregion //converted Subbasinsetup




        #endregion

        #region "Create Network Outlets"
        /// <summary>
        /// A function to generate a network outlets shapefile from the tree.dat and coords.dat files.
        /// </summary>
        /// <param name="TreeDatPath">The path to the tree.dat file</param>
        /// <param name="CoordDatPath">The path to the coords.dat file</param>
        /// <param name="OutletsShapeResultPath">The output path for the network outlets shapefile</param>
        /// <param name="callback">A callback for progress messages</param>
        /// <returns></returns>
        public static bool CreateNetworkOutlets(string TreeDatPath, string CoordDatPath, string OutletsShapeResultPath, MapWinGIS.ICallback callback)
        {
            int newperc = 0;
            int oldperc = 0;
            int numShps = 0, LinkEnd, LinkBegin, LinkEndArea = 0;
            float x, y;
                        
            if (callback != null) callback.Progress("Status", 0, "Create Network Outlets");
            DataManagement.DeleteShapefile(ref OutletsShapeResultPath);

            MapWinGIS.Shapefile sf = new MapWinGIS.Shapefile();
            sf.CreateNew(OutletsShapeResultPath, MapWinGIS.ShpfileType.SHP_POINT);
            sf.StartEditingShapes(true, null);
           
            int zero = 0;
            MapWinGIS.Field field = new MapWinGIS.Field();
            field.Name = "MWShapeID";
            field.Type = MapWinGIS.FieldType.INTEGER_FIELD;
            sf.EditInsertField(field, ref zero, null);
            
            int numTreeNodes = 0;
            long[] dsNodeID;
            int[,] FlowNet;
            if (ReadTreeFile(TreeDatPath, out FlowNet, out dsNodeID, ref numTreeNodes) == 1)
            {
                MapWinUtility.Logger.Message("An error occured in creating the network outlets while reading the tree.dat file.", "Creating Network Outlets Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.DialogResult.OK);
                return false;
            }

            int numCoords = 0;
            float[,] CoordList;
            if (ReadCoordFile(CoordDatPath, out CoordList, ref numCoords) == 1)
            {
                MapWinUtility.Logger.Message("An error occured in creating the network outlets while reading the coords.dat file.", "Creating Network Outlets Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.DialogResult.OK);
                return false;
            }

            for (int i = 0; i <= numTreeNodes; i++)
            {
                if (numTreeNodes > 0)
                {
                    newperc = Convert.ToInt32((Convert.ToDouble(i) / Convert.ToDouble(numTreeNodes)) * 100);
                    if (newperc > oldperc)
                    {
                        if (callback != null) callback.Progress("Status", newperc, "Create Network Outlets");
                        oldperc = newperc;
                    }
                }

                LinkEnd = FlowNet[i, 3 - 1];//*  This is CoordList of end of link */
                LinkBegin = FlowNet[i, 2 - 1];//*  This is CoordList of beg of link */
                if (LinkBegin < LinkEnd)
                {
                    //has physical length
                    if (FlowNet[i, 4 - 1] != -1) //For anything other than a downstream end area is defined one grid cell back
                    {
                        LinkEndArea = LinkEnd - 1;
                    }
                    else
                    {
                        LinkEndArea = LinkEnd;
                    }

                    x = CoordList[LinkEndArea, 1 - 1];
                    y = CoordList[LinkEndArea, 2 - 1];

                    MapWinGIS.Point pt = new MapWinGIS.Point();
                    pt.x = x;
                    pt.y = y;
                    MapWinGIS.Shape shp = new MapWinGIS.Shape();
                    shp.Create(MapWinGIS.ShpfileType.SHP_POINT);
                    shp.InsertPoint(pt, ref numShps);
                    numShps = sf.NumShapes;
                    sf.EditInsertShape(shp, ref numShps);
                    sf.EditCellValue(0, numShps, numShps);
                }                
            }
            sf.StopEditingShapes(true, true, null);
            sf.Close();
            if (callback != null) callback.Progress("Status", 0, "");
            return true;
        }

#endregion

        #region "Subbasins to Shapes"
        /// <summary>
        /// A function which uses the mapwingis utils to convert the subbasin grid to a polygon shapefile
        /// </summary>
        /// <param name="D8Path"></param>
        /// <param name="WatershedGridPath"></param>
        /// <param name="WatershedShapeResultPath"></param>
        /// <param name="callback">A MapWinGIS.ICallback used to return error messages etc.</param>
        /// <returns></returns>
        public static int SubbasinsToShape(string D8Path, string WatershedGridPath, string WatershedShapeResultPath, MapWinGIS.ICallback callback)
        {
            int result = -1;
            MapWinGIS.Grid gPF = new MapWinGIS.Grid();
            MapWinGIS.Grid gWF = new MapWinGIS.Grid();
            MapWinGIS.Shapefile sf = new MapWinGIS.Shapefile();

            MapWinGIS.Utils u = new MapWinGIS.Utils();

            if (callback != null) callback.Progress("Status", 0, "Watershed Grid to Shapefile");
            DataManagement.DeleteShapefile(ref WatershedShapeResultPath);
            gPF.Open(D8Path, MapWinGIS.GridDataType.UnknownDataType, true, MapWinGIS.GridFileType.UseExtension, callback);
            gWF.Open(WatershedGridPath, MapWinGIS.GridDataType.UnknownDataType, true, MapWinGIS.GridFileType.UseExtension, callback);
            sf = u.GridToShapefile(gWF, gPF, callback);
            if (sf.SaveAs(WatershedShapeResultPath, callback))
            {
                result = 0;
            }
            sf.Projection = gPF.Header.Projection;
            gPF.Close();
            gWF.Close();
            sf.Close();
            if (callback != null) callback.Progress("Status", 0, "");
            return result;
        }

        /// <summary>
        /// Subbasin to shape overload for backward compatibility with the tau callback usage. Actually doesn't do anything unfortunately, so useless code
        /// </summary>
        /// <param name="D8Path"></param>
        /// <param name="WatershedGridPath"></param>
        /// <param name="WatershedShapeResultPath"></param>
        /// <param name="tauCallback"></param>
        /// <param name="mwCallback"></param>
        /// <returns></returns>
        public static int SubbasinsToShape(string D8Path, string WatershedGridPath, string WatershedShapeResultPath, TKTAUDEMLib.ItkCallback tauCallback, MapWinGIS.ICallback mwCallback)
        {
            int result = -1;
            MapWinGIS.Grid gPF = new MapWinGIS.Grid();
            MapWinGIS.Grid gWF = new MapWinGIS.Grid();
            MapWinGIS.Shapefile sf = new MapWinGIS.Shapefile();

            TKTAUDEMLib.TauDEM TaudemLib = new TKTAUDEMLib.TauDEM();
            if (tauCallback != null) TaudemLib.Callback = tauCallback;

            MapWinGIS.Utils u = new MapWinGIS.Utils();

            if (tauCallback != null) tauCallback.Progress("Status", 0, "Watershed Grid to Shapefile");
            DataManagement.DeleteShapefile(ref WatershedShapeResultPath);
            gPF.Open(D8Path, MapWinGIS.GridDataType.UnknownDataType, true, MapWinGIS.GridFileType.UseExtension, null);
            gWF.Open(WatershedGridPath, MapWinGIS.GridDataType.UnknownDataType, true, MapWinGIS.GridFileType.UseExtension, null);
            sf = u.GridToShapefile(gWF, gPF, mwCallback);
            if (sf.SaveAs(WatershedShapeResultPath, null))
            {
                result = 0;
            }
            sf.Projection = gPF.Header.Projection;
            gPF.Close();
            gWF.Close();
            sf.Close();
            if (tauCallback != null) tauCallback.Progress("Status", 0, "");
            return result;
        }

        /// <summary>
        /// An overload of the SubbasinsToShape function which will generate a GeoprocDialog for the SubbasinsToShape function
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static int SubbasinsToShape(MapWinGIS.ICallback callback)
        {
            return doSubbasinsToShapeDiag(callback);
        }

        /// <summary>
        /// An overload of the SubbasinsToShape function which will generate a GeoprocDialog for the SubbasinsToShape function
        /// </summary>
        /// <returns></returns>
        public static int SubbasinsToShape()
        {
            return doSubbasinsToShapeDiag(null);
        }

        private static int doSubbasinsToShapeDiag(MapWinGIS.ICallback callback)
        {
            GeoProcDialog subtoshapeDiag = new GeoProcDialog();
            FileElement d8Elem = subtoshapeDiag.Add_FileElement(GeoProcDialog.ElementTypes.OpenGridFile);
            FileElement shedGridElem = subtoshapeDiag.Add_FileElement(GeoProcDialog.ElementTypes.OpenGridFile);
            FileElement shedShapeResElem = subtoshapeDiag.Add_FileElement(GeoProcDialog.ElementTypes.SaveShapefile);

            subtoshapeDiag.Text = "Sub-basins to Shapefile Conversion";
            subtoshapeDiag.HelpTitle = "Sub-basins to Shapefile Conversion";
            subtoshapeDiag.HelpText = "This function will generate a polygon shapefile of sub-basins from a sub-basin grid and D8 grid.";
            subtoshapeDiag.Height = 250;
            subtoshapeDiag.HelpPanelVisible = false;

            d8Elem.Caption = "D8 Flow Direction Grid Path";
            d8Elem.HelpButtonVisible = false;

            shedGridElem.Caption = "Sub-basins Grid Result Path";
            shedGridElem.HelpButtonVisible = false;

            shedShapeResElem.Caption = "Sub-basins Shapefile Result Path";
            shedShapeResElem.HelpButtonVisible = false;

            if (subtoshapeDiag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return Hydrology.SubbasinsToShape(d8Elem.Filename, shedGridElem.Filename, shedShapeResElem.Filename, callback);
            }
            return -2;
        }

       
        #endregion

        #region "Apply Stream Attributes"
        /// <summary>
        /// Hydrology function used to add to the stream shapefile attributes 
        /// </summary>
        /// <param name="StreamNetworkShapePath"></param>
        /// <param name="DEMPath"></param>
        /// <param name="SubBasinShapePath"></param>
        /// <param name="elevUnits"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static bool ApplyStreamAttributes(string StreamNetworkShapePath, string DEMPath, string SubBasinShapePath, ElevationUnits elevUnits, MapWinGIS.ICallback callback)
        {
            bool result;
            int sindx;
            int shdindx;
            MapWinGIS.Shape currShp;
            MapWinGIS.Shapefile streamShape = new MapWinGIS.Shapefile();
            MapWinGIS.Grid demGrid = new MapWinGIS.Grid();
            MapWinGIS.Shapefile shedShape = new MapWinGIS.Shapefile();
            double elevlow = 0;
            double elevhigh = 0;
            bool added;
            int IDField;
            int DSField;
            int US1Field;
            int US2Field;
            int slopeField;
            int wShedIDField;
            int DSAreaField;
            int USAreaField;
            MapWinGIS.Utils u = new MapWinGIS.Utils();
            double currArea;
            double meanWidth;
            double meanDepth;
            Int32 tmpID;
            double tmpSlope;
            int newperc = 0;
            int oldperc = 0;
            string projStr;
            double tmpDSArea;
            double tmpUSArea;
            double DSAreaAcre;
            double USAreaAcre;
            double DSAreaSqMi;
            double USAreaSqMi;
            result = false;
            IDField = 0;
            DSField = 1;
            US1Field = 2;
            US2Field = 3;
            DSAreaField = 8;
            slopeField = 10;
            USAreaField = 12;
            wShedIDField = 13;
            if (callback != null) callback.Progress("Status", 0, "Calculating Stream Parameters");
            streamShape.Open(StreamNetworkShapePath, callback);
            demGrid.Open(DEMPath, MapWinGIS.GridDataType.UnknownDataType,true, MapWinGIS.GridFileType.UseExtension,callback);
            shedShape.Open(SubBasinShapePath,callback);
            streamShape.StartEditingTable(callback);
            streamShape.BeginPointInShapefile();
            
            MapWinGIS.Field lowField = new MapWinGIS.Field();
            int lowFieldNum;
            lowField.Name = "ElevLow";
            lowField.Type = MapWinGIS.FieldType.DOUBLE_FIELD;
            lowFieldNum = streamShape.NumFields;
            streamShape.EditInsertField(lowField, ref lowFieldNum,callback);
            
            MapWinGIS.Field highField = new MapWinGIS.Field();
            int highFieldNum;
            highField.Name = "Elevhigh";
            highField.Type = MapWinGIS.FieldType.DOUBLE_FIELD;
            highFieldNum = streamShape.NumFields;
            streamShape.EditInsertField(highField, ref highFieldNum,callback);
            
            MapWinGIS.Field mwidthField = new MapWinGIS.Field();
            int mwidthFieldNum;
            mwidthField.Name = "MeanWidth";
            mwidthField.Type = MapWinGIS.FieldType.DOUBLE_FIELD;
            mwidthField.Precision = 12;
            mwidthFieldNum = streamShape.NumFields;
            streamShape.EditInsertField(mwidthField, ref mwidthFieldNum, callback);
            
            MapWinGIS.Field mdepthField = new MapWinGIS.Field();
            int mdepthFieldNum;
            mdepthField.Name = "MeanDepth";
            mdepthField.Type = MapWinGIS.FieldType.DOUBLE_FIELD;
            mdepthField.Precision = 12;
            mdepthFieldNum = streamShape.NumFields;
            streamShape.EditInsertField(mdepthField, ref mdepthFieldNum, callback);
            
            MapWinGIS.Field dsareaAcreField = new MapWinGIS.Field();
            int dsareaAcreFieldNum;
            dsareaAcreField.Name = "DSAreaAcre";
            dsareaAcreField.Type = MapWinGIS.FieldType.DOUBLE_FIELD;
            dsareaAcreField.Precision = 12;
            dsareaAcreFieldNum = streamShape.NumFields;
            streamShape.EditInsertField(dsareaAcreField, ref dsareaAcreFieldNum, callback);
            
            MapWinGIS.Field dsareaSqMiField = new MapWinGIS.Field();
            int dsareaSqMiFieldNum;
            dsareaSqMiField.Name = "DSAreaSqMi";
            dsareaSqMiField.Type = MapWinGIS.FieldType.DOUBLE_FIELD;
            dsareaSqMiField.Precision = 12;
            dsareaSqMiFieldNum = streamShape.NumFields;
            streamShape.EditInsertField(dsareaSqMiField, ref dsareaSqMiFieldNum, callback);
            
            MapWinGIS.Field usareaAcreField = new MapWinGIS.Field();
            int usareaAcreFieldNum;
            usareaAcreField.Name = "USAreaAcre";
            usareaAcreField.Type = MapWinGIS.FieldType.DOUBLE_FIELD;
            usareaAcreField.Precision = 12;
            usareaAcreFieldNum = streamShape.NumFields;
            streamShape.EditInsertField(usareaAcreField, ref usareaAcreFieldNum, callback);
            
            MapWinGIS.Field usareaSqMiField = new MapWinGIS.Field();
            int usareaSqMiFieldNum;
            usareaSqMiField.Name = "USAreaSqMi";
            usareaSqMiField.Type = MapWinGIS.FieldType.DOUBLE_FIELD;
            usareaSqMiField.Precision = 12;
            usareaSqMiFieldNum = streamShape.NumFields;
            streamShape.EditInsertField(usareaSqMiField, ref usareaSqMiFieldNum, callback);
            
            projStr = streamShape.Projection;
            
            for (sindx = 0; sindx <= streamShape.NumShapes - 1; sindx++)
            {
                if (streamShape.NumShapes > 1)
                {
                    newperc = Convert.ToInt32((Convert.ToDouble(sindx) / Convert.ToDouble(shedShape.NumShapes)) * 100);
                    if ((newperc > oldperc))
                    {
                        if (callback != null) callback.Progress("Status", newperc, "Calculating Stream Parameters");
                        oldperc = newperc;
                    }
                }
                GetStreamElevationPoints(sindx, streamShape, demGrid, out elevlow, out elevhigh);

                if (elevUnits == ElevationUnits.centimeters)
                {
                    elevlow = elevlow / 100;
                    elevhigh = elevhigh / 100;
                }
                else if (elevUnits == ElevationUnits.feet)
                {
                    elevlow = elevlow / 3.280839895;
                    elevhigh = elevhigh / 3.280839895;
                }

                added = streamShape.EditCellValue(lowFieldNum, sindx, elevlow);
                added = streamShape.EditCellValue(highFieldNum, sindx, elevhigh);
                for (shdindx = 0; shdindx <= shedShape.NumShapes - 1; shdindx++)
                {
                    if ((int)shedShape.get_CellValue(IDField, shdindx) == (int)streamShape.get_CellValue(wShedIDField, sindx))
                    {
                        currShp = shedShape.get_Shape(shdindx);
                        currArea = MapWinGeoProc.Utils.AreaOfPart(currShp, 0);
                        meanWidth = (1.29) * (Math.Pow((currArea / 1000000), (0.6)));
                        meanDepth = (0.13) * (Math.Pow((currArea / 1000000), (0.4)));
                        added = streamShape.EditCellValue(mwidthFieldNum, sindx, meanWidth);
                        added = streamShape.EditCellValue(mdepthFieldNum, sindx, meanDepth);
                        break;
                    }
                }
                tmpID = (int)streamShape.get_CellValue(IDField, sindx);
                tmpID = tmpID + 1;
                streamShape.EditCellValue(IDField, sindx, tmpID);
                tmpID = (int)streamShape.get_CellValue(DSField, sindx);
                if (tmpID > -1)
                {
                    tmpID = tmpID + 1;
                }
                streamShape.EditCellValue(DSField, sindx, tmpID);
                tmpID = (int)streamShape.get_CellValue(US1Field, sindx);
                if (tmpID > 0)
                {
                    tmpID = tmpID + 1;
                }
                else
                {
                    tmpID = -1;
                }
                streamShape.EditCellValue(US1Field, sindx, tmpID);
                tmpID = (int)streamShape.get_CellValue(US2Field, sindx);
                if (tmpID > 0)
                {
                    tmpID = tmpID + 1;
                }
                else
                {
                    tmpID = -1;
                }
                streamShape.EditCellValue(US2Field, sindx, tmpID);
                tmpSlope = (double)streamShape.get_CellValue(slopeField, sindx);

                if (projStr != null)
                {
                    if (projStr.ToUpper().Contains("UNITS=M"))
                    {
                        tmpDSArea = (double)streamShape.get_CellValue(DSAreaField, sindx);
                        tmpUSArea = (double)streamShape.get_CellValue(USAreaField, sindx);
                        DSAreaAcre = tmpDSArea * 0.000247105;
                        DSAreaSqMi = DSAreaAcre * 0.0015625;
                        USAreaAcre = tmpUSArea * 0.000247105;
                        USAreaSqMi = USAreaAcre * 0.0015625;
                        streamShape.EditCellValue(dsareaAcreFieldNum, sindx, DSAreaAcre);
                        streamShape.EditCellValue(dsareaSqMiFieldNum, sindx, DSAreaSqMi);
                        streamShape.EditCellValue(usareaAcreFieldNum, sindx, USAreaAcre);
                        streamShape.EditCellValue(usareaSqMiFieldNum, sindx, USAreaSqMi);
                        if (elevUnits == ElevationUnits.meters)
                        {
                            tmpSlope = tmpSlope * 100;
                        }
                        else if (elevUnits == ElevationUnits.centimeters)
                        {
                            //tmpSlope = tmpSlope;
                        }
                        else if (elevUnits == ElevationUnits.feet)
                        {
                            tmpSlope = (tmpSlope / 3.280839895) * 100;
                        }
                        streamShape.EditCellValue(slopeField, sindx, tmpSlope);
                    }
                    else if (projStr.ToUpper().Contains("UNITS=FT"))
                    {
                        tmpDSArea = (double)streamShape.get_CellValue(DSAreaField, sindx);
                        tmpUSArea = (double)streamShape.get_CellValue(USAreaField, sindx);
                        DSAreaAcre = tmpDSArea * 2.2957E-05;
                        DSAreaSqMi = DSAreaAcre * 0.0015625;
                        USAreaAcre = tmpUSArea * 2.2957E-05;
                        USAreaSqMi = USAreaAcre * 0.0015625;
                        streamShape.EditCellValue(dsareaAcreFieldNum, sindx, DSAreaAcre);
                        streamShape.EditCellValue(dsareaSqMiFieldNum, sindx, DSAreaSqMi);
                        streamShape.EditCellValue(usareaAcreFieldNum, sindx, USAreaAcre);
                        streamShape.EditCellValue(usareaSqMiFieldNum, sindx, USAreaSqMi);
                        if (elevUnits == ElevationUnits.meters)
                        {
                            tmpSlope = (tmpSlope * 3.280839895) * 100;
                        }
                        else if (elevUnits == ElevationUnits.centimeters)
                        {
                            tmpSlope = (tmpSlope / 30.48) * 100;
                        }
                        else if (elevUnits == ElevationUnits.feet)
                        {
                            tmpSlope = tmpSlope * 100;
                        }
                        streamShape.EditCellValue(slopeField, sindx, tmpSlope);
                    }
                }
                else
                {
                    tmpDSArea = (double)streamShape.get_CellValue(DSAreaField, sindx);
                    tmpUSArea = (double)streamShape.get_CellValue(USAreaField, sindx);
                    DSAreaAcre = tmpDSArea * 0.000247105;
                    DSAreaSqMi = DSAreaAcre * 0.0015625;
                    USAreaAcre = tmpUSArea * 0.000247105;
                    USAreaSqMi = USAreaAcre * 0.0015625;
                    streamShape.EditCellValue(dsareaAcreFieldNum, sindx, DSAreaAcre);
                    streamShape.EditCellValue(dsareaSqMiFieldNum, sindx, DSAreaSqMi);
                    streamShape.EditCellValue(usareaAcreFieldNum, sindx, USAreaAcre);
                    streamShape.EditCellValue(usareaSqMiFieldNum, sindx, USAreaSqMi);
                    if (elevUnits == ElevationUnits.meters)
                    {
                        tmpSlope = tmpSlope * 100;
                    }
                    else if (elevUnits == ElevationUnits.centimeters)
                    {
                        //tmpSlope = tmpSlope;
                    }
                    else if (elevUnits == ElevationUnits.feet)
                    {
                        tmpSlope = (tmpSlope / 3.280839895) * 100;
                    }
                    streamShape.EditCellValue(slopeField, sindx, tmpSlope);
                }
            }
            streamShape.EndPointInShapefile();
            streamShape.StopEditingTable(true,callback);
            streamShape.Close();
            demGrid.Close();
            shedShape.Close();
            
            
            result = true;
            if (callback != null) callback.Progress("Status", 0, "");
            return result;
        }
        #endregion

        #region "Apply Watershed Attributes"
        /// <summary>
        /// Hydrology function to apply the watershed link attributes copied or interpretted from the stream network
        /// </summary>
        /// <param name="SubBasinShapePath"></param>
        /// <param name="StreamNetworkShapePath"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static int ApplyWatershedLinkAttributes(string SubBasinShapePath, string StreamNetworkShapePath, MapWinGIS.ICallback callback)
        {
            MapWinGIS.Shapefile shedShape = new MapWinGIS.Shapefile();
            MapWinGIS.Shapefile streamShape = new MapWinGIS.Shapefile();
            int sindx, streamindx;

            bool added;
            int currStreamIndx;
            int currDSStreamLink, currUS1StreamLink, currUS2StreamLink, DSWSID, US1WSID, US2WSID, IDField, waterShedIDField, streamLenID, DSNodeIDField, DSIDField, US1IDField, US2IDField, newperc = 0, oldperc = 0;
            if (callback != null) callback.Progress("Status", 0, "Assigning WS Link");
            IDField = 0;
            DSIDField = 1;
            US1IDField = 2;
            US2IDField = 3;
            DSNodeIDField = 4;
            streamLenID = 6;
            waterShedIDField = 13;
            shedShape.Open(SubBasinShapePath, callback);
            streamShape.Open(StreamNetworkShapePath, callback);

            shedShape.StartEditingTable(callback);

            MapWinGIS.Field streamLinkField = new MapWinGIS.Field();
            int streamLinkFieldNum;
            streamLinkField.Name = "StreamLinkNo";
            streamLinkField.Type = MapWinGIS.FieldType.INTEGER_FIELD;
            streamLinkField.Precision = 12;
            streamLinkFieldNum = shedShape.NumFields;
            shedShape.EditInsertField(streamLinkField, ref streamLinkFieldNum, callback);

            MapWinGIS.Field streamLenField = new MapWinGIS.Field();
            int streamLenFieldNum;
            streamLenField.Name = "StreamLen";
            streamLenField.Type = MapWinGIS.FieldType.INTEGER_FIELD;
            streamLenField.Precision = 12;
            streamLenFieldNum = shedShape.NumFields;
            shedShape.EditInsertField(streamLenField, ref streamLenFieldNum, callback);

            MapWinGIS.Field dsnodeidField = new MapWinGIS.Field();
            int dsnodeidFieldNum;
            dsnodeidField.Name = "DSNodeID";
            dsnodeidField.Type = MapWinGIS.FieldType.INTEGER_FIELD;
            dsnodeidField.Precision = 16;
            dsnodeidField.Width = 10;
            dsnodeidFieldNum = shedShape.NumFields;
            shedShape.EditInsertField(dsnodeidField, ref dsnodeidFieldNum, callback);

            MapWinGIS.Field DSLinkField = new MapWinGIS.Field();
            int DSLinkFieldNum;
            DSLinkField.Name = "DSWSID";
            DSLinkField.Type = MapWinGIS.FieldType.INTEGER_FIELD;
            DSLinkFieldNum = shedShape.NumFields;
            DSLinkField.Precision = 12;
            shedShape.EditInsertField(DSLinkField, ref DSLinkFieldNum, callback);

            MapWinGIS.Field US1LinkField = new MapWinGIS.Field();
            int US1LinkFieldNum;
            US1LinkField.Name = "US1WSID";
            US1LinkField.Type = MapWinGIS.FieldType.INTEGER_FIELD;
            US1LinkFieldNum = shedShape.NumFields;
            US1LinkField.Precision = 12;
            shedShape.EditInsertField(US1LinkField, ref US1LinkFieldNum, callback);

            MapWinGIS.Field US2LinkField = new MapWinGIS.Field();
            int US2LinkFieldNum;
            US2LinkField.Name = "US2WSID";
            US2LinkField.Type = MapWinGIS.FieldType.INTEGER_FIELD;
            US2LinkFieldNum = shedShape.NumFields;
            US2LinkField.Precision = 12;
            shedShape.EditInsertField(US2LinkField, ref US2LinkFieldNum, callback);

            newperc = 0;
            oldperc = 0;
            for (sindx = 0; sindx <= shedShape.NumShapes - 1; sindx++)
            {
                if (shedShape.NumShapes > 1)
                {
                    newperc = Convert.ToInt32((Convert.ToDouble(sindx) / Convert.ToDouble(shedShape.NumShapes)) * 100);
                    if ((newperc > oldperc))
                    {
                        if (callback != null) callback.Progress("Status", newperc, "Assigning WS Link");
                        oldperc = newperc;
                    }
                }
                currStreamIndx = -1;
                for (streamindx = 0; streamindx <= streamShape.NumShapes - 1; streamindx++)
                {
                    if ((int)streamShape.get_CellValue(waterShedIDField, streamindx) == (int)shedShape.get_CellValue(IDField, sindx))
                    {
                        currStreamIndx = streamindx;
                        added = shedShape.EditCellValue(dsnodeidFieldNum, sindx, streamShape.get_CellValue(DSNodeIDField, streamindx));
                        added = shedShape.EditCellValue(streamLinkFieldNum, sindx, streamShape.get_CellValue(IDField, streamindx));
                        added = shedShape.EditCellValue(streamLenFieldNum, sindx, streamShape.get_CellValue(streamLenID, streamindx));
                        break;
                    }
                }
                if (currStreamIndx > -1)
                {
                    currDSStreamLink = (int)streamShape.get_CellValue(DSIDField, currStreamIndx);
                    currUS1StreamLink = (int)streamShape.get_CellValue(US1IDField, currStreamIndx);
                    currUS2StreamLink = (int)streamShape.get_CellValue(US2IDField, currStreamIndx);
                    if (currDSStreamLink == -1)
                    {
                        DSWSID = -1;
                    }
                    else
                    {
                        DSWSID = GetWshedFromStreamLink(currDSStreamLink, ref streamShape, ref shedShape);
                    }
                    if (currUS1StreamLink == 0 | currUS1StreamLink == -1)
                    {
                        US1WSID = -1;
                    }
                    else
                    {
                        US1WSID = GetWshedFromStreamLink(currUS1StreamLink, ref streamShape, ref shedShape);
                    }
                    if (currUS2StreamLink == 0 | currUS2StreamLink == -1)
                    {
                        US2WSID = -1;
                    }
                    else
                    {
                        US2WSID = GetWshedFromStreamLink(currUS2StreamLink, ref streamShape, ref shedShape);
                    }
                    added = shedShape.EditCellValue(DSLinkFieldNum, sindx, DSWSID);
                    added = shedShape.EditCellValue(US1LinkFieldNum, sindx, US1WSID);
                    added = shedShape.EditCellValue(US2LinkFieldNum, sindx, US2WSID);
                }
            }
            shedShape.StopEditingTable(true, callback);
            shedShape.Close();
            streamShape.Close();

            if (callback != null) callback.Progress("", 0, "");
            return 0;
        }

        /// <summary>
        /// A function to apply area attributes to a watershed polygon shapefile
        /// </summary>
        /// <param name="SubBasinShapePath"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static bool ApplyWatershedAreaAttributes(string SubBasinShapePath, MapWinGIS.ICallback callback)
        {
            MapWinGIS.Shapefile shedShape = new MapWinGIS.Shapefile();
            MapWinGIS.Shapefile streamShape = new MapWinGIS.Shapefile();
            MapWinGIS.Grid slopeGrid = new MapWinGIS.Grid();
            int sindx;
            int newperc = 0, oldperc = 0;
            
            if (callback != null) callback.Progress("Status", 0, "Calculating WS Area Parameters");
            shedShape.Open(SubBasinShapePath, callback);
            shedShape.StartEditingTable(callback);

            MapWinGIS.Field areaMField = new MapWinGIS.Field();
            int areaMFieldNum;
            areaMField.Name = "Area_M";
            areaMField.Type = MapWinGIS.FieldType.DOUBLE_FIELD;
            areaMField.Precision = 12;
            areaMFieldNum = shedShape.NumFields;
            shedShape.EditInsertField(areaMField, ref areaMFieldNum, callback);

            MapWinGIS.Field areaAcreField = new MapWinGIS.Field();
            int areaAcreFieldNum;
            areaAcreField.Name = "Area_Acre";
            areaAcreField.Type = MapWinGIS.FieldType.DOUBLE_FIELD;
            areaAcreField.Precision = 12;
            areaAcreFieldNum = shedShape.NumFields;
            shedShape.EditInsertField(areaAcreField, ref areaAcreFieldNum, callback);

            MapWinGIS.Field areaMileField = new MapWinGIS.Field();
            int areaMileFieldNum;
            areaMileField.Name = "Area_SqMi";
            areaMileField.Type = MapWinGIS.FieldType.DOUBLE_FIELD;
            areaMileField.Precision = 12;
            areaMileFieldNum = shedShape.NumFields;
            shedShape.EditInsertField(areaMileField, ref areaMileFieldNum, callback);

            string currProj = shedShape.Projection;
            double tmpArea;
            double areaM = 0;
            double areaAcre;
            double areaSqMi;
            MapWinGIS.Shape tmpShp;
            newperc = 0;
            oldperc = 0;
            for (sindx = 0; sindx <= shedShape.NumShapes - 1; sindx++)
            {
                if (shedShape.NumShapes > 1)
                {
                    newperc = Convert.ToInt32((Convert.ToDouble(sindx) / Convert.ToDouble(shedShape.NumShapes)) * 100);
                    if ((newperc > oldperc))
                    {
                        if (callback != null) callback.Progress("Status", newperc, "Calculating WS Area Parameters");
                        oldperc = newperc;
                    }
                }
                tmpShp = shedShape.get_Shape(sindx);
                tmpArea = Utils.AreaOfPart(tmpShp, 0);
                if (currProj != null && currProj != "")
                {
                    if (currProj.ToUpper().Contains("UNITS=M"))
                    {
                        areaM = tmpArea;
                    }
                    else if (currProj.ToUpper().Contains("UNITS=FT"))
                    {
                        areaM = tmpArea * 0.09290304;
                    }
                }
                else
                {
                    areaM = tmpArea;
                }
                areaAcre = areaM * 0.000247105;
                areaSqMi = areaAcre * 0.0015625;
                shedShape.EditCellValue(areaMFieldNum, sindx, areaM);
                shedShape.EditCellValue(areaAcreFieldNum, sindx, areaAcre);
                shedShape.EditCellValue(areaMileFieldNum, sindx, areaSqMi);
            }

            shedShape.StopEditingTable(true, callback);
            shedShape.Close();

            if (callback != null) callback.Progress("", 0, "");
            return true;
        }

        /// <summary>
        /// Hydrology function used to add to the subbasin shapefile average slope attribute
        /// </summary>
        /// <param name="SubBasinShapePath"></param>
        /// <param name="SlopeGridPath"></param>
        /// <param name="elevUnits"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        /// 
        public static bool ApplyWatershedSlopeAttribute(string SubBasinShapePath, string SlopeGridPath, ElevationUnits elevUnits, MapWinGIS.ICallback callback)
        {
            MapWinGIS.Shapefile shedShape = new MapWinGIS.Shapefile();
            MapWinGIS.Grid slopeGrid = new MapWinGIS.Grid();
            int sindx;
            int col, row;
            int[] countSlope;
            double[] sumSlope;
            double[] avgSlope;
            bool added;
            int newperc = 0, oldperc = 0;
            MapWinGIS.Shape tmpPoly;
            string tmpClipPath = System.IO.Path.GetDirectoryName(SlopeGridPath) + System.IO.Path.DirectorySeparatorChar + System.IO.Path.GetFileNameWithoutExtension(SlopeGridPath) + "_clip.bgd";
            MapWinGIS.Grid tmpClipGrid = new MapWinGIS.Grid();
            double currVal, nodataVal;
            int nr, nc;
            if (callback != null) callback.Progress("Status", 0, "Calculating WS Slope Parameters");
            shedShape.Open(SubBasinShapePath, callback);
            slopeGrid.Open(SlopeGridPath, MapWinGIS.GridDataType.UnknownDataType, true, MapWinGIS.GridFileType.UseExtension, callback);
            countSlope = new int[shedShape.NumShapes];
            sumSlope = new double[shedShape.NumShapes];
            avgSlope = new double[shedShape.NumShapes];

            DataManagement.DeleteGrid(ref tmpClipPath);
            for (sindx = 0; sindx <= shedShape.NumShapes - 1; sindx++)
            {
                if (shedShape.NumShapes > 1)
                {
                    newperc = Convert.ToInt32((Convert.ToDouble(sindx) / Convert.ToDouble(shedShape.NumShapes - 1)) * 100);
                    if ((newperc > oldperc))
                    {
                        callback.Progress("Status", newperc, "Calculating WS Slope Parameters");
                        oldperc = newperc;
                    }
                }
                tmpPoly = shedShape.get_Shape(sindx);
                if (SpatialOperations.ClipGridWithPolygon(ref SlopeGridPath, ref tmpPoly, ref tmpClipPath))
                {
                    tmpClipGrid.Open(tmpClipPath, MapWinGIS.GridDataType.UnknownDataType, true, MapWinGIS.GridFileType.UseExtension, null);
                    nr = tmpClipGrid.Header.NumberRows;
                    nc = tmpClipGrid.Header.NumberCols;
                    nodataVal = double.Parse(tmpClipGrid.Header.NodataValue.ToString());
                    countSlope[sindx] = 0;
                    sumSlope[sindx] = 0;
                    avgSlope[sindx] = 0;
                    for (row = 0; row <= nr - 1; row += 2)
                    {
                        for (col = 0; col <= nc - 1; col += 2)
                        {
                            currVal = double.Parse(tmpClipGrid.get_Value(col, row).ToString());
                            if (currVal != nodataVal)
                            {
                                countSlope[sindx] = countSlope[sindx] + 1;
                                sumSlope[sindx] = sumSlope[sindx] + currVal;
                            }
                        }
                    }
                    tmpClipGrid.Close();
                    DataManagement.DeleteGrid(ref tmpClipPath);
                }
            }
            if (callback != null) callback.Progress("Status", 0, "Calculating WS Slope Parameters");
            shedShape.StartEditingTable(callback);

            MapWinGIS.Field slopeField = new MapWinGIS.Field();
            int slopeFieldNum;
            slopeField.Name = "AveSlope";
            slopeField.Type = MapWinGIS.FieldType.DOUBLE_FIELD;
            slopeField.Precision = 16;
            slopeField.Width = 10;
            slopeFieldNum = shedShape.NumFields;
            shedShape.EditInsertField(slopeField, ref slopeFieldNum, callback);

            string slopeProj = slopeGrid.Header.Projection;
            newperc = 0;
            oldperc = 0;
            for (sindx = 0; sindx <= shedShape.NumShapes - 1; sindx++)
            {
                if (shedShape.NumShapes > 1)
                {
                    newperc = Convert.ToInt32((Convert.ToDouble(sindx) / Convert.ToDouble(shedShape.NumShapes)) * 100);
                    if ((newperc > oldperc))
                    {
                        if (callback != null) callback.Progress("Status", newperc, "Calculating WS Slope Parameters");
                        oldperc = newperc;
                    }
                }
                if (countSlope[sindx] > 0)
                {
                    if (slopeProj != null && slopeProj != "")
                    {
                        if (slopeProj.ToUpper().Contains("UNITS=M"))
                        {
                            if (elevUnits == ElevationUnits.meters)
                            {
                                avgSlope[sindx] = (sumSlope[sindx] / countSlope[sindx]) * 100;
                            }
                            else if (elevUnits == ElevationUnits.centimeters)
                            {
                                avgSlope[sindx] = (sumSlope[sindx] / countSlope[sindx]);
                            }
                            else if (elevUnits == ElevationUnits.feet)
                            {
                                avgSlope[sindx] = ((sumSlope[sindx] / countSlope[sindx]) / 3.280839895) * 100;
                            }
                        }
                        else if (slopeProj.ToUpper().Contains("UNITS=FT"))
                        {
                            if (elevUnits == ElevationUnits.meters)
                            {
                                avgSlope[sindx] = ((sumSlope[sindx] / countSlope[sindx]) * 3.280839895) * 100;
                            }
                            else if (elevUnits == ElevationUnits.centimeters)
                            {
                                avgSlope[sindx] = ((sumSlope[sindx] / countSlope[sindx]) / 30.48) * 100;
                            }
                            else if (elevUnits == ElevationUnits.feet)
                            {
                                avgSlope[sindx] = (sumSlope[sindx] / countSlope[sindx]) * 100;
                            }
                        }
                    }
                    else
                    {
                        if (elevUnits == ElevationUnits.meters)
                        {
                            avgSlope[sindx] = (sumSlope[sindx] / countSlope[sindx]) * 100;
                        }
                        else if (elevUnits == ElevationUnits.centimeters)
                        {
                            avgSlope[sindx] = (sumSlope[sindx] / countSlope[sindx]);
                        }
                        else if (elevUnits == ElevationUnits.feet)
                        {
                            avgSlope[sindx] = ((sumSlope[sindx] / countSlope[sindx]) / 3.280839895) * 100;
                        }
                    }
                    added = shedShape.EditCellValue(slopeFieldNum, sindx, avgSlope[sindx]);
                }
            }

            shedShape.StopEditingTable(true, callback);
            shedShape.Close();
            slopeGrid.Close();

            if (callback != null) callback.Progress("", 0, "");
            return true;
        }
        

        /// <summary>
        /// Hydrology function used to add to the subbasin shapefile average slope attribute
        /// </summary>
        /// <param name="SubBasinGridPath"></param>
        /// <param name="SubBasinShapePath"></param>
        /// <param name="SlopeGridPath"></param>
        /// <param name="elevUnits"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        /// 
        public static bool ApplyWatershedSlopeAttribute(string SubBasinGridPath, string SubBasinShapePath, string SlopeGridPath, ElevationUnits elevUnits, MapWinGIS.ICallback callback)
        {
            MapWinGIS.Shapefile shedShape = new MapWinGIS.Shapefile();
            MapWinGIS.Grid subBasinGrid = new MapWinGIS.Grid();
            MapWinGIS.Grid slopeGrid = new MapWinGIS.Grid();
            int sindx;
            int col, row;
            int[] countSlope;
            double[] sumSlope;
            double[] avgSlope;
            List<int> linkIDVals;
            List<int> linkIDMerged;
            bool added;
            int newperc = 0, oldperc = 0, currID;
            double currVal, nodataVal;
            int nr, nc;
            if (callback != null) callback.Progress("Status", 0, "Calculating WS Slope Parameters");

            shedShape.Open(SubBasinShapePath, callback);
            subBasinGrid.Open(SubBasinGridPath, MapWinGIS.GridDataType.UnknownDataType, true, MapWinGIS.GridFileType.UseExtension, callback);
            slopeGrid.Open(SlopeGridPath, MapWinGIS.GridDataType.UnknownDataType, true, MapWinGIS.GridFileType.UseExtension, callback);
            countSlope = new int[shedShape.NumShapes];
            sumSlope = new double[shedShape.NumShapes];
            avgSlope = new double[shedShape.NumShapes];

            int currPolyIDIdx = -1; 
            int currLinkIDIdx = -1;
            for (sindx = 0; sindx <= shedShape.NumFields - 1; sindx++)
            {
                if (shedShape.get_Field(sindx).Name == "PolygonID" || shedShape.get_Field(sindx).Name == "MWShapeID")
                {
                    currPolyIDIdx = sindx;
                }
                if (shedShape.get_Field(sindx).Name == "LinkIDs")
                {
                    currLinkIDIdx = sindx;
                }
            }


            string tmpLinkIDs;
            string[] tmpLinks;
            linkIDVals = new List<int>();
            linkIDMerged = new List<int>();
            if (currLinkIDIdx != -1 && currPolyIDIdx != -1)
            {
                for (sindx = 0; sindx <= shedShape.NumShapes - 1; sindx++)
                {
                    tmpLinkIDs = shedShape.get_CellValue(currLinkIDIdx, sindx).ToString();
                    tmpLinks = tmpLinkIDs.Split(',');
                    for (int i = 0; i < tmpLinks.Length; i++)
                    {
                        linkIDMerged.Add(sindx);
                        linkIDVals.Add(int.Parse(tmpLinks[i].Trim()));
                    }
                }
            }
            else
            {
                for (sindx = 0; sindx <= shedShape.NumShapes - 1; sindx++)
                {
                    linkIDMerged.Add(sindx);
                    linkIDVals.Add(int.Parse(shedShape.get_CellValue(currPolyIDIdx,sindx).ToString()));
                }
            }

            nr = slopeGrid.Header.NumberRows;
            nc = slopeGrid.Header.NumberCols;
            nodataVal = double.Parse(slopeGrid.Header.NodataValue.ToString());
            for (row = 0; row <= nr - 1; row++)
            {
                newperc = Convert.ToInt32((Convert.ToDouble(row) / Convert.ToDouble(nr - 1)) * 100);
                if ((newperc > oldperc))
                {
                    if (callback != null) callback.Progress("Status", newperc, "Calculating WS Slope Parameters");
                    oldperc = newperc;
                }

                int currBasinID = -1;
                for (col = 0; col <= nc - 1; col++)
                {
                    currVal = double.Parse(slopeGrid.get_Value(col, row).ToString());

                    if (currVal != nodataVal)
                    {
                        currBasinID = int.Parse(subBasinGrid.get_Value(col, row).ToString());
                        if (currBasinID != -1)
                        {
                            currID = linkIDMerged[linkIDVals.IndexOf(currBasinID)];

                            countSlope[currID] = countSlope[currID] + 1;
                            sumSlope[currID] = sumSlope[currID] + currVal;
                        }
                    }
                }
            }
            
            if (callback != null) callback.Progress("Status", 0, "Calculating WS Slope Parameters");
            shedShape.StartEditingTable(callback);

            MapWinGIS.Field slopeField = new MapWinGIS.Field();
            int slopeFieldNum;
            slopeField.Name = "AveSlope";
            slopeField.Type = MapWinGIS.FieldType.DOUBLE_FIELD;
            slopeField.Precision = 16;
            slopeField.Width = 10;
            slopeFieldNum = shedShape.NumFields;
            shedShape.EditInsertField(slopeField, ref slopeFieldNum, callback);

            string slopeProj = slopeGrid.Header.Projection;
            newperc = 0;
            oldperc = 0;
            for (sindx = 0; sindx <= shedShape.NumShapes - 1; sindx++)
            {
                if (shedShape.NumShapes > 1)
                {
                    newperc = Convert.ToInt32((Convert.ToDouble(sindx) / Convert.ToDouble(shedShape.NumShapes)) * 100);
                    if ((newperc > oldperc))
                    {
                        if (callback != null) callback.Progress("Status", newperc, "Calculating WS Slope Parameters");
                        oldperc = newperc;
                    }
                }
                if (countSlope[sindx] > 0)
                {
                    if (slopeProj != null && slopeProj != "")
                    {
                        if (slopeProj.ToUpper().Contains("UNITS=M"))
                        {
                            if (elevUnits == ElevationUnits.meters)
                            {
                                avgSlope[sindx] = (sumSlope[sindx] / countSlope[sindx]) * 100;
                            }
                            else if (elevUnits == ElevationUnits.centimeters)
                            {
                                avgSlope[sindx] = (sumSlope[sindx] / countSlope[sindx]);
                            }
                            else if (elevUnits == ElevationUnits.feet)
                            {
                                avgSlope[sindx] = ((sumSlope[sindx] / countSlope[sindx]) / 3.280839895) * 100;
                            }
                        }
                        else if (slopeProj.ToUpper().Contains("UNITS=FT"))
                        {
                            if (elevUnits == ElevationUnits.meters)
                            {
                                avgSlope[sindx] = ((sumSlope[sindx] / countSlope[sindx]) * 3.280839895) * 100;
                            }
                            else if (elevUnits == ElevationUnits.centimeters)
                            {
                                avgSlope[sindx] = ((sumSlope[sindx] / countSlope[sindx]) / 30.48) * 100;
                            }
                            else if (elevUnits == ElevationUnits.feet)
                            {
                                avgSlope[sindx] = (sumSlope[sindx] / countSlope[sindx]) * 100;
                            }
                        }
                    }
                    else
                    {
                        if (elevUnits == ElevationUnits.meters)
                        {
                            avgSlope[sindx] = (sumSlope[sindx] / countSlope[sindx]) * 100;
                        }
                        else if (elevUnits == ElevationUnits.centimeters)
                        {
                            avgSlope[sindx] = (sumSlope[sindx] / countSlope[sindx]);
                        }
                        else if (elevUnits == ElevationUnits.feet)
                        {
                            avgSlope[sindx] = ((sumSlope[sindx] / countSlope[sindx]) / 3.280839895) * 100;
                        }
                    }
                    added = shedShape.EditCellValue(slopeFieldNum, sindx, avgSlope[sindx]);
                }
            }

            shedShape.StopEditingTable(true, callback);
            shedShape.Close();
            slopeGrid.Close();
            subBasinGrid.Close();

            if (callback != null) callback.Progress("", 0, "");
            return true;
        }
      
        #endregion

        #region "Build Joined Basins"
        /// <summary>
        /// A function to create the joined basins from a watershed shapefile that has had the basic apply attributes set on it
        /// </summary>
        /// <param name="SubBasinShapePath"></param>
        /// <param name="JoinBasinShapeResultPath"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        static public bool BuildJoinedBasins(string SubBasinShapePath, string JoinBasinShapeResultPath, MapWinGIS.ICallback callback)
        {
            return doBuildJoinedBasins(SubBasinShapePath, "", JoinBasinShapeResultPath, callback);
        }

        /// <summary>
        /// Overload of BuildJoinedBasins that takes an outlets shape path used for Inlets resolution. If no outlets/inlets path given, it will treat all points as outlets
        /// </summary>
        /// <param name="SubBasinShapePath"></param>
        /// <param name="OutletsShapePath"></param>
        /// <param name="JoinBasinShapeResultPath"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        static public bool BuildJoinedBasins(string SubBasinShapePath, string OutletsShapePath, string JoinBasinShapeResultPath, MapWinGIS.ICallback callback)
        {
            return doBuildJoinedBasins(SubBasinShapePath, OutletsShapePath, JoinBasinShapeResultPath, callback);
        }

        static private bool doBuildJoinedBasins(string SubBasinShapePath, string OutletsShapePath, string JoinBasinShapeResultPath, MapWinGIS.ICallback callback)
        {
            MapWinGIS.Shapefile shed = new MapWinGIS.Shapefile();
            MapWinGIS.Shapefile newShed = new MapWinGIS.Shapefile();
            MapWinGIS.Shapefile outlets = new MapWinGIS.Shapefile();
            MapWinGIS.Utils u = new MapWinGIS.Utils();
            int oldperc = 0;
            int newperc = 0;
            string strLinks = "";
            int currshpidx;
            int dsNodeType = 0;
            ArrayList shapeIdxList = new ArrayList();
            MapWinGIS.Shape currShape;
            MapWinGIS.Shape tmpShape;

            if (OutletsShapePath != "")
            {
                outlets.Open(OutletsShapePath, null);
            }
            shed.Open(SubBasinShapePath, null);
            int dsNodeFieldNum = -1;
            int dsShedFieldNum = -1;
            for (int i = 0; i <= shed.NumFields - 1; i++)
            {
                if (shed.get_Field(i).Name.ToUpper() == "DSNODEID")
                {
                    dsNodeFieldNum = i;
                }
                if (shed.get_Field(i).Name.ToUpper() == "DSWSID")
                {
                    dsShedFieldNum = i;
                }
            }
            DataManagement.DeleteShapefile(ref JoinBasinShapeResultPath);
            newShed.CreateNew(JoinBasinShapeResultPath, MapWinGIS.ShpfileType.SHP_POLYGON);
            newShed.StartEditingShapes(true, null);
            
            MapWinGIS.Field idfield = new MapWinGIS.Field();
            int idfieldnum = newShed.NumFields;
            idfield.Name = "MWShapeID";
            idfield.Type = MapWinGIS.FieldType.INTEGER_FIELD;
            newShed.EditInsertField(idfield, ref idfieldnum, null);

            MapWinGIS.Field linkfield = new MapWinGIS.Field();
            int linkfieldnum = newShed.NumFields;
            linkfield.Name = "LinkIDs";
            linkfield.Type = MapWinGIS.FieldType.STRING_FIELD;
            newShed.EditInsertField(linkfield, ref linkfieldnum, null);

            MapWinGIS.Field outletfield = new MapWinGIS.Field();
            int outletfieldnum = newShed.NumFields;
            outletfield.Name = "OutletID";
            outletfield.Type = MapWinGIS.FieldType.INTEGER_FIELD;
            newShed.EditInsertField(outletfield, ref outletfieldnum, null);

            MapWinGIS.Field dswsfield = new MapWinGIS.Field();
            int dswsfieldnum = newShed.NumFields;
            dswsfield.Name = "DSWSID";
            dswsfield.Type = MapWinGIS.FieldType.INTEGER_FIELD;
            newShed.EditInsertField(dswsfield, ref dswsfieldnum, null);

            MapWinGIS.Field uswsfield1 = new MapWinGIS.Field();
            int uswsfieldnum1 = newShed.NumFields;
            uswsfield1.Name = "USWSID1";
            uswsfield1.Type = MapWinGIS.FieldType.INTEGER_FIELD;
            newShed.EditInsertField(uswsfield1, ref uswsfieldnum1, null);

            MapWinGIS.Field uswsfield2 = new MapWinGIS.Field();
            int uswsfieldnum2 = newShed.NumFields;
            uswsfield2.Name = "USWSID2";
            uswsfield2.Type = MapWinGIS.FieldType.INTEGER_FIELD;
            newShed.EditInsertField(uswsfield2, ref uswsfieldnum2, null);

            MapWinGIS.Field reservoirfield = new MapWinGIS.Field();
            int reservoirfieldnum = newShed.NumFields;
            reservoirfield.Name = "Reservoir";
            reservoirfield.Type = MapWinGIS.FieldType.INTEGER_FIELD;
            newShed.EditInsertField(reservoirfield, ref reservoirfieldnum, null);

            for (int sindx = 0; sindx <= shed.NumShapes - 1; sindx++)
            {
                if (shed.NumShapes > 1)
                {
                    newperc = Convert.ToInt32((Convert.ToDouble(sindx) / Convert.ToDouble(shed.NumShapes)) * 100);
                    if ((newperc > oldperc))
                    {
                        if (callback != null) callback.Progress("Status", newperc, "Merging Watersheds to Outlets/Inlets");
                        oldperc = newperc;
                    }
                }
                dsNodeType = 0;
                int dsNodeVal = int.Parse(shed.get_CellValue(dsNodeFieldNum, sindx).ToString());
                if (dsNodeVal != -1)
                {
                    if (OutletsShapePath == "")
                    {
                        getJoinShapesFromSubBasin(ref shed, sindx, shapeIdxList);
                    }
                    else
                    {
                        dsNodeType = getDSNodeType(ref outlets, dsNodeVal);
                        if (dsNodeType != 1)
                        {
                            if (isUpstreamOfInlet(ref shed, ref outlets, sindx))
                            {
                                shapeIdxList.Clear();
                            }
                            else
                            {
                                getJoinShapesFromSubBasin(ref shed, sindx, shapeIdxList);
                            }
                        }
                        else
                        {
                            shapeIdxList.Clear();
                        }
                    }
                    MapWinGIS.Shape mergeShape = new MapWinGIS.Shape();
                    if (shapeIdxList.Count != 0)
                    {
                        if (shapeIdxList.Count == 1)
                        {
                            mergeShape = shed.get_Shape(int.Parse(shapeIdxList[0].ToString()));
                            strLinks = shed.get_CellValue(0, int.Parse(shapeIdxList[0].ToString())).ToString();
                        }
                        else
                        {
                            strLinks = shed.get_CellValue(0, int.Parse(shapeIdxList[0].ToString())).ToString();
                            for (int i = 1; i <= shapeIdxList.Count - 1; i++)
                            {
                                strLinks = strLinks + ", " + shed.get_CellValue(0, int.Parse(shapeIdxList[i].ToString())).ToString();
                            }
                            mergeShape.Create(MapWinGIS.ShpfileType.SHP_POLYGON);
                            for (int i = 0; i <= shapeIdxList.Count - 1; i++)
                            {
                                currShape = shed.get_Shape(int.Parse(shapeIdxList[i].ToString()));
                                tmpShape = mergeShape;
                                SpatialOperations.MergeShapes(ref currShape, ref tmpShape, out mergeShape);
                            }
                        }
                        currshpidx = newShed.NumShapes;
                        newShed.EditInsertShape(mergeShape, ref currshpidx);
                        newShed.EditCellValue(idfieldnum, currshpidx, currshpidx);
                        newShed.EditCellValue(linkfieldnum, currshpidx, strLinks);
                        newShed.EditCellValue(outletfieldnum, currshpidx, dsNodeVal);
                        if (int.Parse(shed.get_CellValue(dsShedFieldNum, sindx).ToString()) != -1)
                        {
                            newShed.EditCellValue(dswsfieldnum, currshpidx, shed.get_CellValue(dsShedFieldNum, sindx));
                        }
                        else
                        {
                            newShed.EditCellValue(dswsfieldnum, currshpidx, -1);
                        }
                        newShed.EditCellValue(uswsfieldnum1, currshpidx, -1);
                        newShed.EditCellValue(uswsfieldnum2, currshpidx, -1);
                        if (dsNodeType == 2)
                        {
                            newShed.EditCellValue(reservoirfieldnum, currshpidx, 1);
                        }
                        else
                        {
                            newShed.EditCellValue(reservoirfieldnum, currshpidx, 0);
                        }
                    }                        
                }
            } //end for

            buildMergeDownstreamUpStream(ref newShed, idfieldnum, linkfieldnum, dswsfieldnum, uswsfieldnum1, uswsfieldnum2);

            newShed.Projection = shed.Projection;
            shed.StopEditingTable(true, null);
            shed.Close();
            newShed.StopEditingShapes(true, true, null);
            newShed.Close();
            if (OutletsShapePath != "")
            {
                outlets.Close();
            }
            if (callback != null) callback.Progress("", 0, "");
            return true;
        }

        static private void buildMergeDownstreamUpStream(ref MapWinGIS.Shapefile newshed, int IDFieldNum, int LinksFieldNum, int DSFieldNum, int USFieldNum1, int USFieldNum2)
        {
            for (int i = 0; i <= newshed.NumShapes - 1; i++)
            {
                string currDSField = newshed.get_CellValue(DSFieldNum, i).ToString();
                if (currDSField != "-1")
                {
                    for (int j = 0; j <= newshed.NumShapes - 1; j++)
                    {
                        string links = newshed.get_CellValue(LinksFieldNum, j).ToString();
                        string[] split = links.Split(',');
                        for (int k = 0; k <= split.Length - 1; k++)
                        {
                            if (split[k].Trim() == currDSField)
                            {
                                newshed.EditCellValue(DSFieldNum, i, newshed.get_CellValue(IDFieldNum, j));
                                string upstream1 = newshed.get_CellValue(USFieldNum1, j).ToString();
                                if (upstream1 == "-1")
                                {
                                    newshed.EditCellValue(USFieldNum1, j, newshed.get_CellValue(IDFieldNum, i));
                                }
                                else
                                {
                                    newshed.EditCellValue(USFieldNum2, j, newshed.get_CellValue(IDFieldNum, i));
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }

        static private int getDSNodeType(ref MapWinGIS.Shapefile outlets, int ID)
        {
            int idFieldNum = -1;
            int inletFieldNum = -1;
            int resFieldNum = -1;
            for (int i = 0; i <= outlets.NumFields - 1; i++)
            {
                string currname = outlets.get_Field(i).Name;
                if (currname.ToUpper() == "MWSHAPEID" || currname.ToUpper() == "ID")
                {
                    idFieldNum = i;
                }
                if (currname.ToUpper() == "INLET")
                {
                    inletFieldNum = i;
                }
                if (currname.ToUpper() == "RES")
                {
                    resFieldNum = i;
                }
            }

            if (inletFieldNum == -1 || resFieldNum == -1)
            {
                return 0;
            }

            if (idFieldNum != -1) 
            {
                for (int i = 0; i <= outlets.NumShapes - 1; i++)
                {
                    if ((int)outlets.get_CellValue(idFieldNum, i) == ID)
                    {
                        int currInlet = (int)outlets.get_CellValue(inletFieldNum, i);
                        int currRes = (int)outlets.get_CellValue(resFieldNum, i);

                        if (currInlet == 1)
                        {
                            return 1;
                        }
                        else if (currRes == 1)
                        {
                            return 2;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
            }
            else
            {
                int currInlet = (int)outlets.get_CellValue(inletFieldNum, ID-1);
                int currRes = (int)outlets.get_CellValue(resFieldNum, ID-1);

                if (currInlet == 1)
                {
                    return 1;
                }
                else if (currRes == 1)
                {
                    return 2;
                }
                else
                {
                    return 0;
                }
            }

            return 0;
        }

        static private bool isUpstreamOfInlet(ref MapWinGIS.Shapefile shed, ref MapWinGIS.Shapefile outlets, int sindx)
        {
            int dsNodeFieldNum = 3;
            int DSshedFieldnum = 4;
            int currDSID = int.Parse(shed.get_CellValue(DSshedFieldnum, sindx).ToString());
            int currIndx = -1;

            while (currDSID != -1)
            {
                currIndx = -1;
                for (int i = 0; i <= shed.NumShapes - 1; i++)
                {
                    if (int.Parse(shed.get_CellValue(0, i).ToString()) == currDSID)
                    {
                        currIndx = i;
                        break;
                    }
                }
                if (currIndx != -1)
                {
                    currDSID = int.Parse(shed.get_CellValue(DSshedFieldnum, currIndx).ToString());

                    int dsNodeVal = int.Parse(shed.get_CellValue(dsNodeFieldNum, currIndx).ToString());
                    if (dsNodeVal != -1)
                    {
                        int dsNodeType = getDSNodeType(ref outlets, dsNodeVal);
                        if (dsNodeType == 1)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        static private void getJoinShapesFromSubBasin(ref MapWinGIS.Shapefile shed, int sindx, ArrayList shapeIdxList)
        {
            int dsNodeFieldNum = 3;
            int USlink1FieldNum = 5;
            int USlink2FieldNum = 6;
            Stack currStack = new Stack();
            int currLink1ID;
            int currLink2ID;
            int currIdx;
            int currLinkIdx;
            shapeIdxList.Clear();

            shapeIdxList.Add(sindx);
            currLink1ID = int.Parse(shed.get_CellValue(USlink1FieldNum, sindx).ToString());
            currLink2ID = int.Parse(shed.get_CellValue(USlink2FieldNum, sindx).ToString());
            if (currLink1ID != -1)
            {
                currLinkIdx = getBasinIndexByID(ref shed, currLink1ID);
                if (currLinkIdx != -1)
                {
                    currStack.Push(currLinkIdx);
                }
            }
            if (currLink2ID != -1)
            {
                currLinkIdx = getBasinIndexByID(ref shed, currLink2ID);
                if (currLinkIdx != -1)
                {
                    currStack.Push(currLinkIdx);
                }
            }
            while (currStack.Count > 0)
            {
                currIdx = int.Parse(currStack.Pop().ToString());
                if (int.Parse(shed.get_CellValue(dsNodeFieldNum, currIdx).ToString()) == -1)
                {
                    shapeIdxList.Add(currIdx);
                    currLink1ID = int.Parse(shed.get_CellValue(USlink1FieldNum, currIdx).ToString());
                    currLink2ID = int.Parse(shed.get_CellValue(USlink2FieldNum, currIdx).ToString());
                    if (currLink1ID != -1)
                    {
                        currLinkIdx = getBasinIndexByID(ref shed, currLink1ID);
                        if (currLinkIdx != -1)
                        {
                            currStack.Push(currLinkIdx);
                        }
                    }
                    if (currLink2ID != -1)
                    {
                        currLinkIdx = getBasinIndexByID(ref shed, currLink2ID);
                        if (currLinkIdx != -1)
                        {
                            currStack.Push(currLinkIdx);
                        }
                    }
                }
            }
        }

        static private int getBasinIndexByID(ref MapWinGIS.Shapefile shed, int ID)
        {
            for (int i = 0; i <= shed.NumShapes - 1; i++)
            {
                if (int.Parse(shed.get_CellValue(0, i).ToString()) == ID)
                {
                    return i;
                }
            }
            return -1;
        }

        #endregion

        #region "Apply Joined Basin Attributes"
        /// <summary>
        /// A function to apply attributes to a joined basin shapefile
        /// </summary>
        /// <param name="JoinBasinShapePath"></param>
        /// <param name="elevUnits"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        static public bool ApplyJoinBasinAreaAttributes(string JoinBasinShapePath, ElevationUnits elevUnits, MapWinGIS.ICallback callback)
        {
            if (callback != null) callback.Progress("Status", 0, "Calculating Merge Shed Area Attributes");
            double currarea;
            double aream;
            double areasqmi;
            double areaacre;
            string strProj;
            int oldperc = 0;
            int newperc = 0;
            MapWinGIS.Shapefile mergeshed = new MapWinGIS.Shapefile();
            MapWinGIS.Shape currShape;
            mergeshed.Open(JoinBasinShapePath, null);
            mergeshed.StartEditingShapes(true, null);
            
            MapWinGIS.Field areamfield = new MapWinGIS.Field();
            int areamfieldnum = mergeshed.NumFields;
            areamfield.Name = "Area_M";
            areamfield.Type = MapWinGIS.FieldType.DOUBLE_FIELD;
            mergeshed.EditInsertField(areamfield, ref areamfieldnum, null);
            
            MapWinGIS.Field areaacfield = new MapWinGIS.Field();
            int areaacfieldnum = mergeshed.NumFields;
            areaacfield.Name = "Area_Acre";
            areaacfield.Type = MapWinGIS.FieldType.DOUBLE_FIELD;
            mergeshed.EditInsertField(areaacfield, ref areaacfieldnum, null);
            
            MapWinGIS.Field areasqmifield = new MapWinGIS.Field();
            int areasqmifieldnum = mergeshed.NumFields;
            areasqmifield.Name = "Area_SqMi";
            areasqmifield.Type = MapWinGIS.FieldType.DOUBLE_FIELD;
            mergeshed.EditInsertField(areasqmifield, ref areasqmifieldnum, null);
            
            strProj = mergeshed.Projection;
            for (int i = 0; i <= mergeshed.NumShapes - 1; i++)
            {
                if (mergeshed.NumShapes > 1)
                {
                    newperc = Convert.ToInt32((Convert.ToDouble(i) / Convert.ToDouble(mergeshed.NumShapes)) * 100);
                    if ((newperc > oldperc))
                    {
                        if (callback != null) callback.Progress("Status", newperc, "Calculating Merge Shed Area Attributes");
                        oldperc = newperc;
                    }
                }
                currShape = mergeshed.get_Shape(i);
                currarea = Utils.AreaOfPart(currShape, 0);
                aream = 0;
                if (strProj != null && strProj != "")
                {
                    if ((strProj.ToUpper().Contains("UNITS=M")))
                    {
                        aream = currarea;
                    }
                    else if ((strProj.ToUpper().Contains("UNITS=FT")))
                    {
                        aream = currarea * 0.09290304;
                    }
                }
                else
                {
                    aream = currarea;
                }
                areaacre = aream * 0.000247105;
                areasqmi = areaacre * 0.0015625;
                mergeshed.EditCellValue(areamfieldnum, i, aream);
                mergeshed.EditCellValue(areaacfieldnum, i, areaacre);
                mergeshed.EditCellValue(areasqmifieldnum, i, areasqmi);
            }
            mergeshed.StopEditingShapes(true, true, null);
            mergeshed.Close();

            if (callback != null) callback.Progress("", 0, "");
            return true;
        }

        /// <summary>
        /// A function that gets the mean width, mean height, length, and slope of the primary stream in the basin
        /// </summary>
        /// <param name="NetworkShapePath">The path to the streams network shapefile</param>
        /// <param name="BasinShapePath">The path to the unjoined watershed shapefile</param>
        /// <param name="JoinBasinShapePath">The path to the Joined Basins shapefile</param>
        /// <param name="callback">A mapwindow callback</param>
        /// <returns></returns>
        static public bool ApplyJoinBasinStreamAttributes(string NetworkShapePath, string BasinShapePath, string JoinBasinShapePath, MapWinGIS.ICallback callback)
        {
            if (callback != null) callback.Progress("Status", 0, "Calculating Merge Shed Area Attributes");
            int oldperc = 0;
            int newperc = 0;

            MapWinGIS.Shapefile shed = new MapWinGIS.Shapefile();
            shed.Open(BasinShapePath, null);
            int StreamLinkFieldNum = -1;
            for (int i = 0; i < shed.NumFields; i++)
            {
                if (shed.get_Field(i).Name == "StreamLink")
                {
                    StreamLinkFieldNum = i;
                    break;
                }
            }

            MapWinGIS.Shapefile net = new MapWinGIS.Shapefile();
            net.Open(NetworkShapePath, null);
            int StreamIDFN = -1, StreamLengthFN = -1, StreamSlopeFN = -1, StreamMeanWidthFN = -1, StreamMeanDepthFN = -1;
            for (int i = 0; i < net.NumFields; i++)
            {
                switch (net.get_Field(i).Name)
                {
                    case "LINKNO":
                        StreamIDFN = i;
                        break;
                    case "Length":
                        StreamLengthFN = i;
                        break;
                    case "Slope":
                        StreamSlopeFN = i;
                        break;
                    case "MeanWidth":
                        StreamMeanWidthFN = i;
                        break;
                    case "MeanDepth":
                        StreamMeanDepthFN = i;
                        break;
                }
            }

            MapWinGIS.Shapefile mergeshed = new MapWinGIS.Shapefile();
            mergeshed.Open(JoinBasinShapePath, null);
            int LinkIDsFieldNum = -1;
            for (int i = 0; i < mergeshed.NumFields; i++)
            {
                if (mergeshed.get_Field(i).Name == "LinkIDs")
                {
                        LinkIDsFieldNum = i;
                        break;
                }
            }

            mergeshed.StartEditingShapes(true, null);

            MapWinGIS.Field streamwidthfield = new MapWinGIS.Field();
            int streamwidthfieldnum = mergeshed.NumFields;
            streamwidthfield.Name = "CH_W2";
            streamwidthfield.Type = MapWinGIS.FieldType.DOUBLE_FIELD;
            mergeshed.EditInsertField(streamwidthfield, ref streamwidthfieldnum, null);

            MapWinGIS.Field streamdepthfield = new MapWinGIS.Field();
            int streamdepthfieldnum = mergeshed.NumFields;
            streamdepthfield.Name = "CH_D";
            streamdepthfield.Type = MapWinGIS.FieldType.DOUBLE_FIELD;
            mergeshed.EditInsertField(streamdepthfield, ref streamwidthfieldnum, null);

            MapWinGIS.Field streamlengthfield = new MapWinGIS.Field();
            int streamlengthfieldnum = mergeshed.NumFields;
            streamlengthfield.Name = "CH_L";
            streamlengthfield.Type = MapWinGIS.FieldType.DOUBLE_FIELD;
            mergeshed.EditInsertField(streamlengthfield, ref streamlengthfieldnum, null);

            MapWinGIS.Field streamslopefield = new MapWinGIS.Field();
            int streamslopefieldnum = mergeshed.NumFields;
            streamslopefield.Name = "CH_S";
            streamslopefield.Type = MapWinGIS.FieldType.DOUBLE_FIELD;
            mergeshed.EditInsertField(streamslopefield, ref streamslopefieldnum, null);


            string currLinkIDs, StreamLink;
            string[] Links;
            int ShedID, ShedIndex;
            for (int i = 0; i <= mergeshed.NumShapes - 1; i++)
            {
                if (mergeshed.NumShapes > 1)
                {
                    newperc = Convert.ToInt32((Convert.ToDouble(i) / Convert.ToDouble(mergeshed.NumShapes)) * 100);
                    if ((newperc > oldperc))
                    {
                        if (callback != null) callback.Progress("Status", newperc, "Calculating Merge Shed Area Attributes");
                        oldperc = newperc;
                    }
                }
                currLinkIDs = mergeshed.get_CellValue(LinkIDsFieldNum, i).ToString();
                Links = currLinkIDs.Split(',');
                ShedID = int.Parse(Links[0]);
                ShedIndex = getBasinIndexByID(ref shed, ShedID);
                StreamLink = shed.get_CellValue(StreamLinkFieldNum, ShedIndex).ToString();

                for (int j = 0; j < net.NumShapes; j++)
                {
                    if (net.get_CellValue(StreamIDFN, j).ToString() == StreamLink)
                    {
                        mergeshed.EditCellValue(streamlengthfieldnum, i, net.get_CellValue(StreamLengthFN, j));
                        mergeshed.EditCellValue(streamslopefieldnum, i, net.get_CellValue(StreamSlopeFN, j));
                        mergeshed.EditCellValue(streamdepthfieldnum, i, net.get_CellValue(StreamMeanDepthFN, j));
                        mergeshed.EditCellValue(streamwidthfieldnum, i, net.get_CellValue(StreamMeanWidthFN, j));
                    }
                }
            }

            mergeshed.StopEditingShapes(true, true, null);
            mergeshed.Close();
            net.Close();
            shed.Close();

            if (callback != null) callback.Progress("", 0, "");
            return true;

        }

        /// <summary>
        /// Hydrology function used to add to the subbasin shapefile average elevation attribute
        /// </summary>
        /// <param name="SubBasinShapePath"></param>
        /// <param name="ElevGridPath"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static bool ApplyWatershedElevationAttribute(string SubBasinShapePath, string ElevGridPath, MapWinGIS.ICallback callback)
        {
            MapWinGIS.Shapefile shedShape = new MapWinGIS.Shapefile();
            MapWinGIS.Grid elevGrid = new MapWinGIS.Grid();
            int sindx;
            int col, row;
            int[] countElev;
            double[] sumElev;
            double[] avgElev;
            bool added;
            int newperc = 0, oldperc = 0;
            MapWinGIS.Shape tmpPoly;
            string tmpClipPath = System.IO.Path.GetDirectoryName(ElevGridPath) + System.IO.Path.DirectorySeparatorChar + System.IO.Path.GetFileNameWithoutExtension(ElevGridPath) + "_clip.bgd";
            MapWinGIS.Grid tmpClipGrid = new MapWinGIS.Grid();
            double currVal, nodataVal;
            int nr, nc;
            if (callback != null) callback.Progress("Status", 0, "Calculating WS Elevation Parameters");
            shedShape.Open(SubBasinShapePath, callback);
            elevGrid.Open(ElevGridPath, MapWinGIS.GridDataType.UnknownDataType, true, MapWinGIS.GridFileType.UseExtension, callback);
            countElev = new int[shedShape.NumShapes];
            sumElev = new double[shedShape.NumShapes];
            avgElev = new double[shedShape.NumShapes];

            DataManagement.DeleteGrid(ref tmpClipPath);
            for (sindx = 0; sindx <= shedShape.NumShapes - 1; sindx++)
            {
                if (shedShape.NumShapes > 1)
                {
                    newperc = Convert.ToInt32((Convert.ToDouble(sindx) / Convert.ToDouble(shedShape.NumShapes - 1)) * 100);
                    if ((newperc > oldperc))
                    {
                        callback.Progress("Status", newperc, "Calculating WS Elevation Parameters");
                        oldperc = newperc;
                    }
                }
                tmpPoly = shedShape.get_Shape(sindx);
                if (SpatialOperations.ClipGridWithPolygon(ref ElevGridPath, ref tmpPoly, ref tmpClipPath))
                {
                    tmpClipGrid.Open(tmpClipPath, MapWinGIS.GridDataType.UnknownDataType, true, MapWinGIS.GridFileType.UseExtension, null);
                    nr = tmpClipGrid.Header.NumberRows;
                    nc = tmpClipGrid.Header.NumberCols;
                    nodataVal = double.Parse(tmpClipGrid.Header.NodataValue.ToString());
                    countElev[sindx] = 0;
                    sumElev[sindx] = 0;
                    avgElev[sindx] = 0;
                    for (row = 0; row <= nr - 1; row += 2)
                    {
                        for (col = 0; col <= nc - 1; col += 2)
                        {
                            currVal = double.Parse(tmpClipGrid.get_Value(col, row).ToString());
                            if (currVal != nodataVal)
                            {
                                countElev[sindx] = countElev[sindx] + 1;
                                sumElev[sindx] = sumElev[sindx] + currVal;
                            }
                        }
                    }
                    tmpClipGrid.Close();
                    DataManagement.DeleteGrid(ref tmpClipPath);
                }
            }
            if (callback != null) callback.Progress("Status", 0, "Calculating WS Elevation Parameters");
            shedShape.StartEditingTable(callback);

            MapWinGIS.Field slopeField = new MapWinGIS.Field();
            int slopeFieldNum;
            slopeField.Name = "AveElev";
            slopeField.Type = MapWinGIS.FieldType.DOUBLE_FIELD;
            slopeField.Precision = 16;
            slopeField.Width = 10;
            slopeFieldNum = shedShape.NumFields;
            shedShape.EditInsertField(slopeField, ref slopeFieldNum, callback);

            string slopeProj = elevGrid.Header.Projection;
            newperc = 0;
            oldperc = 0;
            for (sindx = 0; sindx <= shedShape.NumShapes - 1; sindx++)
            {
                if (shedShape.NumShapes > 1)
                {
                    newperc = Convert.ToInt32((Convert.ToDouble(sindx) / Convert.ToDouble(shedShape.NumShapes)) * 100);
                    if ((newperc > oldperc))
                    {
                        if (callback != null) callback.Progress("Status", newperc, "Calculating WS Elevation Parameters");
                        oldperc = newperc;
                    }
                }
                if (countElev[sindx] > 0)
                {                    
                    avgElev[sindx] = (sumElev[sindx] / countElev[sindx]);
                    
                    added = shedShape.EditCellValue(slopeFieldNum, sindx, avgElev[sindx]);
                }
            }

            shedShape.StopEditingTable(true, callback);
            shedShape.Close();
            elevGrid.Close();

            if (callback != null) callback.Progress("", 0, "");
            return true;
        }

        /// <summary>
        /// Hydrology function used to add to the subbasin shapefile average elevation attribute
        /// </summary>
        /// <param name="SubBasinGridPath"></param>
        /// <param name="SubBasinShapePath"></param>
        /// <param name="ElevGridPath"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static bool ApplyWatershedElevationAttribute(string SubBasinGridPath, string SubBasinShapePath, string ElevGridPath, MapWinGIS.ICallback callback)
        {
            MapWinGIS.Shapefile shedShape = new MapWinGIS.Shapefile();
            MapWinGIS.Grid elevGrid = new MapWinGIS.Grid();
            MapWinGIS.Grid subBasinGrid = new MapWinGIS.Grid();
            int sindx;
            int col, row;
            int[] countElev;
            double[] sumElev;
            double[] avgElev;
            bool added;
            int newperc = 0, oldperc = 0;
            double currVal, nodataVal;
            int nr, nc;
            if (callback != null) callback.Progress("Status", 0, "Calculating WS Elevation Parameters");
            shedShape.Open(SubBasinShapePath, callback);
            subBasinGrid.Open(SubBasinGridPath, MapWinGIS.GridDataType.UnknownDataType, true, MapWinGIS.GridFileType.UseExtension, callback);
            elevGrid.Open(ElevGridPath, MapWinGIS.GridDataType.UnknownDataType, true, MapWinGIS.GridFileType.UseExtension, callback);
            countElev = new int[shedShape.NumShapes];
            sumElev = new double[shedShape.NumShapes];
            avgElev = new double[shedShape.NumShapes];

            int currPolyIDIdx = -1;
            int currLinkIDIdx = -1;
            for (sindx = 0; sindx <= shedShape.NumFields - 1; sindx++)
            {
                if (shedShape.get_Field(sindx).Name == "PolygonID" || shedShape.get_Field(sindx).Name == "MWShapeID")
                {
                    currPolyIDIdx = sindx;
                }
                if (shedShape.get_Field(sindx).Name == "LinkIDs")
                {
                    currLinkIDIdx = sindx;
                }
            }

            string tmpLinkIDs;
            string[] tmpLinks;
            List<int> linkIDVals = new List<int>();
            List<int> linkIDMerged = new List<int>();
            if (currLinkIDIdx != -1 && currPolyIDIdx != -1)
            {
                for (sindx = 0; sindx <= shedShape.NumShapes - 1; sindx++)
                {
                    tmpLinkIDs = shedShape.get_CellValue(currLinkIDIdx, sindx).ToString();
                    tmpLinks = tmpLinkIDs.Split(',');
                    for (int i = 0; i < tmpLinks.Length; i++)
                    {
                        linkIDMerged.Add(sindx);
                        linkIDVals.Add(int.Parse(tmpLinks[i].Trim()));
                    }
                }
            }
            else
            {
                for (sindx = 0; sindx <= shedShape.NumShapes - 1; sindx++)
                {
                    linkIDMerged.Add(sindx);
                    linkIDVals.Add(int.Parse(shedShape.get_CellValue(currPolyIDIdx, sindx).ToString()));
                }
            }

            int currID = -1;
            nr = elevGrid.Header.NumberRows;
            nc = elevGrid.Header.NumberCols;
            nodataVal = double.Parse(elevGrid.Header.NodataValue.ToString());
            for (row = 0; row <= nr - 1; row++)
            {
                newperc = Convert.ToInt32((Convert.ToDouble(row) / Convert.ToDouble(nr - 1)) * 100);
                if ((newperc > oldperc))
                {
                    if (callback != null) callback.Progress("Status", newperc, "Calculating WS Elevation Parameters");
                    oldperc = newperc;
                }

                int currBasinID = -1;
                for (col = 0; col <= nc - 1; col++)
                {
                    currVal = double.Parse(elevGrid.get_Value(col, row).ToString());

                    if (currVal != nodataVal)
                    {
                        currBasinID = int.Parse(subBasinGrid.get_Value(col, row).ToString());
                        if (currBasinID != -1)
                        {
                            currID = linkIDMerged[linkIDVals.IndexOf(currBasinID)];

                            countElev[currID] = countElev[currID] + 1;
                            sumElev[currID] = sumElev[currID] + currVal;
                        }
                    }
                }
            }

            if (callback != null) callback.Progress("Status", 0, "Calculating WS Elevation Parameters");
            shedShape.StartEditingTable(callback);

            MapWinGIS.Field slopeField = new MapWinGIS.Field();
            int slopeFieldNum;
            slopeField.Name = "AveElev";
            slopeField.Type = MapWinGIS.FieldType.DOUBLE_FIELD;
            slopeField.Precision = 16;
            slopeField.Width = 10;
            slopeFieldNum = shedShape.NumFields;
            shedShape.EditInsertField(slopeField, ref slopeFieldNum, callback);

            string slopeProj = elevGrid.Header.Projection;
            newperc = 0;
            oldperc = 0;
            for (sindx = 0; sindx <= shedShape.NumShapes - 1; sindx++)
            {
                if (shedShape.NumShapes > 1)
                {
                    newperc = Convert.ToInt32((Convert.ToDouble(sindx) / Convert.ToDouble(shedShape.NumShapes)) * 100);
                    if ((newperc > oldperc))
                    {
                        if (callback != null) callback.Progress("Status", newperc, "Calculating WS Elevation Parameters");
                        oldperc = newperc;
                    }
                }
                if (countElev[sindx] > 0)
                {
                    avgElev[sindx] = (sumElev[sindx] / countElev[sindx]);

                    added = shedShape.EditCellValue(slopeFieldNum, sindx, avgElev[sindx]);
                }
            }

            shedShape.StopEditingTable(true, callback);
            shedShape.Close();
            elevGrid.Close();

            if (callback != null) callback.Progress("", 0, "");
            return true;
        }
        #endregion

        #region "Create SWAT *.Fig"
        /// <summary>
        /// A function to generate a *.fig file from joined basins for use in SWAT.
        /// </summary>
        /// <param name="JoinBasinShapePath"></param>
        /// <param name="ResultFigPath"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        static public bool CreateSWATFig(string JoinBasinShapePath,  string ResultFigPath, MapWinGIS.ICallback callback)
        {
            int OutletIDFieldNum = -1, DSWSIDFieldNum = -1, USWSIDFieldNum1 = -1, USWSIDFieldNum2 = -1, ReservoirFieldNum = -1;
            if (callback != null) callback.Progress("Status", 0, "Create SWAT *.fig");
            MapWinGIS.Shapefile sf = new MapWinGIS.Shapefile();
            
            sf.Open(JoinBasinShapePath, null);
            for (int i = 0; i < sf.NumFields; i++)
            {
                switch (sf.get_Field(i).Name)
                {
                    case "OutletID":
                        OutletIDFieldNum = i;
                        break;
                    case "DSWSID":
                        DSWSIDFieldNum = i;
                        break;
                    case "USWSID1":
                        USWSIDFieldNum1 = i;
                        break;
                    case "USWSID2":
                        USWSIDFieldNum2 = i;
                        break;
                    case "Reservoir":
                        ReservoirFieldNum = i;
                        break;
                }
            }
            if (OutletIDFieldNum == -1 || DSWSIDFieldNum == -1 || USWSIDFieldNum1 == -1 || USWSIDFieldNum2 == -1)
            {
                return false;
            }

            StreamWriter fig = new StreamWriter(ResultFigPath);

            Stack<int> substack = new Stack<int>();
            List<int> subIDs = new List<int>();
            int Hyd_Stor_Num = 0;
            int Res_Num = 0;
            int InFlow_Num1 = 0;
            int InFlow_Num2 = 0;
            int InFlow_ID = 0;
            int UpstreamCount, UpstreamFinishedCount;


            //Write subbasins
            for (int i = 0; i < sf.NumShapes; i++)
            {
                Hyd_Stor_Num++;
                fig.Write("subbasin       1{0,6:G6}{0,6:G6}                              Subbasin: {0:G}\n          {0,5:D5}0000.sub\n", Hyd_Stor_Num);
                if (sf.get_CellValue(DSWSIDFieldNum, i).ToString() == "-1")
                {
                    substack.Push(i);
                }
                subIDs.Add(-1);
            }

            //Write the rest
            int curridx;
            string currUS1, currUS2;
            int currUS1idx, currUS2idx, currUS1ID, currUS2ID;
            while (substack.Count > 0)
            {
                curridx = substack.Pop();

                currUS1 = sf.get_CellValue(USWSIDFieldNum1, curridx).ToString();
                currUS2 = sf.get_CellValue(USWSIDFieldNum2, curridx).ToString();
                if (currUS1 == "-1" && currUS2 == "-1") //then we're on an outer reach.
                {
                    if (subIDs[curridx] == -1) //then it hasn't been added yet. add a route
                    {
                        Hyd_Stor_Num++;
                        InFlow_Num1 = curridx + 1;
                        fig.Write("route          2{0,6:G6}{1,6:G6}{2,6:G6}\n          {1,5:D5}0000.rte{1,5:D5}0000.swq\n", Hyd_Stor_Num, curridx + 1, InFlow_Num1);
                        subIDs[curridx] = Hyd_Stor_Num;

                        if (sf.get_CellValue(ReservoirFieldNum, curridx).ToString() == "1") //it's a reservoir
                        {
                            Hyd_Stor_Num++;
                            Res_Num++;
                            InFlow_Num1 = Hyd_Stor_Num - 1;
                            InFlow_ID = curridx + 1;
                            fig.Write("routres        3{0,6:G6}{1,6:G6}{2,6:G6}{3,6:G6}\n          {3,5:D5}0000.res{3,5:D5}0000.lwq\n", Hyd_Stor_Num, Res_Num, InFlow_Num1, InFlow_ID);
                            subIDs[curridx] = Hyd_Stor_Num; 
                        }
                    }
                }
                else //we're on a middle or final reach
                {
                    UpstreamCount = 0;
                    UpstreamFinishedCount = 0;

                    //Get the hydro IDs and indexes of the upstream links
                    currUS1ID = -2;
                    currUS2ID = -2;
                    currUS1idx = -1;
                    currUS2idx= -1;
                    if (currUS1 != "-1")
                    {
                        UpstreamCount++;
                        currUS1idx = getBasinIndexByID(ref sf, Int32.Parse(currUS1));
                        if (currUS1idx >= 0)
                        {
                            currUS1ID = subIDs[currUS1idx];
                            if (currUS1ID != -1)
                            {
                                UpstreamFinishedCount++;
                            }
                        }
                    }
                    if (currUS2 != "-1")
                    {
                        UpstreamCount++;
                        currUS2idx = getBasinIndexByID(ref sf, Int32.Parse(currUS2));
                        if (currUS2idx >= 0)
                        {
                            currUS2ID = subIDs[currUS2idx];
                            if (currUS2ID != -1)
                            {
                                UpstreamFinishedCount++;
                            }
                        }
                    }
                    
                    if (UpstreamCount == UpstreamFinishedCount) //all upstreams finished
                    {
                        if (currUS1ID != -2 && currUS2ID != -2) //It has two upstream, have to do a double sum
                        {
                            Hyd_Stor_Num++;
                            InFlow_Num1 = currUS1ID;
                            InFlow_Num2 = curridx + 1;
                            fig.Write("add            5{0,6:G6}{1,6:G6}{2,6:G6}\n", Hyd_Stor_Num, InFlow_Num1, InFlow_Num2);

                            Hyd_Stor_Num++;
                            InFlow_Num1 = currUS2ID;
                            InFlow_Num2 = Hyd_Stor_Num - 1;
                            fig.Write("add            5{0,6:G6}{1,6:G6}{2,6:G6}\n", Hyd_Stor_Num, InFlow_Num1, InFlow_Num2);
                        }
                        else if (currUS1ID != -2) //It only has one upstream, check if it's 1
                        {
                            Hyd_Stor_Num++;
                            InFlow_Num1 = currUS1ID;
                            InFlow_Num2 = curridx + 1;
                            fig.Write("add            5{0,6:G6}{1,6:G6}{2,6:G6}\n", Hyd_Stor_Num, InFlow_Num1, InFlow_Num2);
                        }
                        else if (currUS2ID != -2) //It only has one upstream, check if it's 2
                        {
                            Hyd_Stor_Num++;
                            InFlow_Num1 = currUS2ID;
                            InFlow_Num2 = curridx + 1;
                            fig.Write("add            5{0,6:G6}{1,6:G6}{2,6:G6}\n", Hyd_Stor_Num, InFlow_Num1, InFlow_Num2);
                        }

                        //After summing, create the route and possibly reservoir
                        Hyd_Stor_Num++;
                        InFlow_Num1 = Hyd_Stor_Num - 1;
                        fig.Write("route          2{0,6:G6}{1,6:G6}{2,6:G6}\n          {1,5:D5}0000.rte{1,5:D5}0000.swq\n", Hyd_Stor_Num, curridx + 1, InFlow_Num1);
                        subIDs[curridx] = Hyd_Stor_Num;

                        if (sf.get_CellValue(ReservoirFieldNum, curridx).ToString() == "1")
                        {
                            Hyd_Stor_Num++;
                            Res_Num++;
                            InFlow_Num1 = Hyd_Stor_Num - 1;
                            InFlow_ID = curridx + 1;
                            fig.Write("routres        3{0,6:G6}{1,6:G6}{2,6:G6}{3,6:G6}\n          {3,5:D5}0000.res{3,5:D5}0000.lwq\n", Hyd_Stor_Num, Res_Num, InFlow_Num1, InFlow_ID);
                            subIDs[curridx] = Hyd_Stor_Num;
                        }
                    }
                    else //There are upstream items that need to still be processed before this one
                    {
                        substack.Push(curridx);
                        if (currUS1idx != -1 && currUS1ID == -1)
                        {
                            substack.Push(currUS1idx);
                        }
                        if (currUS2idx != -1 && currUS2ID == -1)
                        {
                            substack.Push(currUS2idx);
                        }
                    }
                }
                
            }

            //Write out the saveconc and finish commands
            int SaveFile_Num = 1;
            int Print_Freq = 0; //0 for daily, 1 for hourly
            fig.Write("saveconc      14{0,6:G6}{1,6:G6}{2,6:G6}\n          watout.dat\n", Hyd_Stor_Num, SaveFile_Num, Print_Freq);
            fig.WriteLine("finish         0");

            fig.Close();
            sf.Close();
            return true;
        }
        #endregion

        #region "Hydrology Private Helper Functions"
        /// <summary>
        /// Enum for elevation units used in DEMs
        /// </summary>
        public enum ElevationUnits
        {
            /// <summary>
            /// Meters = 0
            /// </summary>
            meters,
            /// <summary>
            /// Centimeters = 1
            /// </summary>
            centimeters,
            /// <summary>
            /// Feet = 2
            /// </summary>
            feet
        }

        private static void GetStreamElevationPoints(int sindx, MapWinGIS.Shapefile streamShape, MapWinGIS.Grid demGrid, out double elevLow, out double elevHigh)
        {
            double ptX;
            double ptY;
            int shapePoints;
            int currCol;
            int currRow;
            double currVal;
            shapePoints = streamShape.get_Shape(sindx).numPoints;
            elevLow = 10000000;
            elevHigh = -1000000;
            for (int i = 0; i <= shapePoints - 1; i += 2)
            {
                ptX = streamShape.get_Shape(sindx).get_Point(i).x;
                ptY = streamShape.get_Shape(sindx).get_Point(i).y;
                demGrid.ProjToCell(ptX, ptY, out currCol, out currRow);
                if (currCol > -1 & currRow > -1)
                {
                    currVal = double.Parse(demGrid.get_Value(currCol, currRow).ToString());
                    if (currVal < elevLow)
                    {
                        elevLow = currVal;
                    }
                    if (currVal > elevHigh)
                    {
                        elevHigh = currVal;
                    }
                }
            }
        }

        private static int GetWshedFromStreamLink(int streamLink, ref MapWinGIS.Shapefile streamShape, ref MapWinGIS.Shapefile shedShape)
        {
            int streamindx;
            int LinkIDField;
            int waterShedIDField;
            LinkIDField = 0;
            waterShedIDField = 13;
            for (streamindx = 0; streamindx <= streamShape.NumShapes - 1; streamindx++)
            {
                if (int.Parse(streamShape.get_CellValue(LinkIDField, streamindx).ToString()) == streamLink)
                {
                    return int.Parse(streamShape.get_CellValue(waterShedIDField, streamindx).ToString());
                }
            }
            return -1;
        }

        private static bool ShapefileToArrays(string shpfileName, ref double[] X, ref double[] Y, ref int PntCount)
        {
            MapWinGIS.Shapefile shpfile = new MapWinGIS.Shapefile();
            int numShapes;
            int NumPoints;
            System.Collections.ArrayList xPnts = new System.Collections.ArrayList();
            System.Collections.ArrayList yPnts = new System.Collections.ArrayList();
            MapWinGIS.ShpfileType sft;
            bool result = false;
            if (shpfile.Open(shpfileName, null) == false)
            {
                return false;
            }
            sft = shpfile.ShapefileType;
            if (sft != MapWinGIS.ShpfileType.SHP_MULTIPOINT & sft != MapWinGIS.ShpfileType.SHP_POINT & sft != MapWinGIS.ShpfileType.SHP_POINTZ & sft != MapWinGIS.ShpfileType.SHP_POINTZ & sft != MapWinGIS.ShpfileType.SHP_POINTM)
            {
                MapWinUtility.Logger.Message("Error: Invalid shapefile type selected. Must be a point shapefile", "Argument Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.DialogResult.OK );
                return false;
            }
            numShapes = shpfile.NumShapes;
            MapWinGIS.Shape shp;
            MapWinGIS.Point pnt;
            for (int curShp = 0; curShp <= numShapes - 1; curShp++)
            {
                shp = shpfile.get_Shape(curShp);
                NumPoints = shp.numPoints;
                for (int curPnt = 0; curPnt <= NumPoints - 1; curPnt++)
                {
                    pnt = shp.get_Point(curPnt);
                    xPnts.Add(pnt.x);
                    yPnts.Add(pnt.y);
                }
            }
            NumPoints = xPnts.Count;
            PntCount = NumPoints;
            if (NumPoints <= 0)
            {
                return false;
            }
            //This is what it used to do. I have NO clue why. ARA
            //X = new double[NumPoints-1];
            //Y = new double[NumPoints-1];
            //for (int curPnt = 1; curPnt < NumPoints; curPnt++)
            //{
            //    X[curPnt - 1] = System.Convert.ToDouble(xPnts[curPnt]);
            //    Y[curPnt - 1] = System.Convert.ToDouble(yPnts[curPnt]);
            //}
            X = new double[NumPoints];
            Y = new double[NumPoints];
            for (int curPnt = 0; curPnt < NumPoints; curPnt++)
            {
                X[curPnt] = System.Convert.ToDouble(xPnts[curPnt]);
                Y[curPnt] = System.Convert.ToDouble(yPnts[curPnt]);
            }
            result = true;
            return result;
        }

        private static bool ShapefileToArraysWithIDs(string shpfileName, ref double[] X, ref double[] Y, ref int PntCount, ref int[] idNodes)
        {
            MapWinGIS.Shapefile shpfile = new MapWinGIS.Shapefile();
            int numShapes;
            int NumPoints;
            int numFields;
            System.Collections.ArrayList xPnts = new System.Collections.ArrayList();
            System.Collections.ArrayList yPnts = new System.Collections.ArrayList();
            System.Collections.ArrayList idNodesLocal = new System.Collections.ArrayList();
            MapWinGIS.ShpfileType sft;

            
            if (shpfile.Open(shpfileName,null) == false)
            {
                return false;
            }
            sft = shpfile.ShapefileType;
            if (sft != MapWinGIS.ShpfileType.SHP_MULTIPOINT & sft != MapWinGIS.ShpfileType.SHP_POINT & sft != MapWinGIS.ShpfileType.SHP_POINTZ & sft != MapWinGIS.ShpfileType.SHP_POINTZ & sft != MapWinGIS.ShpfileType.SHP_POINTM)
            {
                MapWinUtility.Logger.Message("Error: Invalid shapefile type selected. Must be a point shapefile", "Argument Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.DialogResult.OK);
                return false;
            }
            numShapes = shpfile.NumShapes;
            MapWinGIS.Shape shp;
            MapWinGIS.Point pnt;
            MapWinGIS.Field Field;
            string FieldName;
            int theFieldIndex;
            numFields = shpfile.NumFields;
            theFieldIndex = -1;
            for (int theField = 0; theField <= numFields - 1; theField++)
            {
                Field = shpfile.get_Field(theField);
                FieldName = Field.Name;
                if (FieldName.ToLower() == "id" | FieldName.ToLower() == "mwshapeid")
                {
                    theFieldIndex = theField;
                    break;
                }
            }       
            
            if (theFieldIndex < 0)
            {
                MapWinGIS.Field f;
                f = new MapWinGIS.Field();
                f.Type = MapWinGIS.FieldType.INTEGER_FIELD;
                f.Name = "MWShapeID";
                shpfile.StartEditingTable(null);
                int tmpNumFields = shpfile.NumFields;
                shpfile.EditInsertField(f, ref tmpNumFields, null);
                int IDIndex;
                IDIndex = shpfile.NumFields - 1;
                for (int i = 0; i <= shpfile.NumShapes - 1; i++)
                {
                    shpfile.EditCellValue(IDIndex, i, i + 1);
                }
                shpfile.StopEditingTable(true,null);
                numFields = shpfile.NumFields;
                theFieldIndex = -1;
                for (int theField = 0; theField <= numFields - 1; theField++)
                {
                    Field = shpfile.get_Field(theField);
                    FieldName = Field.Name;
                    if (FieldName.ToLower() == "id" || FieldName.ToLower() == "mwshapeid")
                    {
                        theFieldIndex = theField;
                        break;
                    }
                }
            }
            for (int curShp = 0; curShp <= numShapes - 1; curShp++)
            {
                NumPoints = shpfile.get_Shape(curShp).numPoints;
                shp = shpfile.get_Shape(curShp);
                for (int curPnt = 0; curPnt <= NumPoints - 1; curPnt++)
                {
                    pnt = shp.get_Point(curPnt);
                    xPnts.Add(pnt.x);
                    yPnts.Add(pnt.y);
                }
                idNodesLocal.Add(shpfile.get_CellValue(theFieldIndex,curShp));
            }

            NumPoints = xPnts.Count;
            PntCount = NumPoints;
            if (NumPoints <= 0)
            {
                return false;
            }
            
            X = new double[NumPoints];
            Y = new double[NumPoints];
            idNodes = new int[NumPoints];
            for (int curPnt = 0; curPnt < NumPoints; curPnt++)
            {
                X[curPnt] = System.Convert.ToDouble(xPnts[curPnt]);
                Y[curPnt] = System.Convert.ToDouble(yPnts[curPnt]);
                idNodes[curPnt] = System.Convert.ToInt32(idNodesLocal[curPnt]);
            }
            return true;
        }

        private static void CopyProjectionFromGrid(string gridFromPath, string fileToPath)
        {
            MapWinGIS.Grid gFrom = new MapWinGIS.Grid();
            gFrom.Open(gridFromPath, MapWinGIS.GridDataType.UnknownDataType, true, MapWinGIS.GridFileType.UseExtension, null);
            
            if (fileToPath.Contains(".shp"))
            {
                MapWinGIS.Shapefile shpTo = new MapWinGIS.Shapefile();
                shpTo.Open(fileToPath,null);
                shpTo.Projection = gFrom.Header.Projection;
                shpTo.Close();
            }
            else
            {
                MapWinGIS.Grid gTo = new MapWinGIS.Grid();
                gTo.Open(fileToPath, MapWinGIS.GridDataType.UnknownDataType, true, MapWinGIS.GridFileType.UseExtension, null);
                gTo.AssignNewProjection(gFrom.Header.Projection);
                gTo.Close();
            }
            gFrom.Close();
        }

        private static MapWinGIS.Shape getShapeFromExtents(MapWinGIS.Extents ext)
        {
            int numPoints;
            MapWinGIS.Shape shp = new MapWinGIS.Shape();
            MapWinGIS.Point pt;
            shp.Create(MapWinGIS.ShpfileType.SHP_POLYGON);
            pt = new MapWinGIS.Point();
            pt.x = ext.xMin;
            pt.y = ext.yMax;
            numPoints = shp.numPoints;
            shp.InsertPoint(pt, ref numPoints);
            pt = new MapWinGIS.Point();
            pt.x = ext.xMax;
            pt.y = ext.yMax;
            numPoints = shp.numPoints;
            shp.InsertPoint(pt, ref numPoints);
            pt = new MapWinGIS.Point();
            pt.x = ext.xMax;
            pt.y = ext.yMin;
            numPoints = shp.numPoints;
            shp.InsertPoint(pt, ref numPoints);
            pt = new MapWinGIS.Point();
            pt.x = ext.xMin;
            pt.y = ext.yMin;
            numPoints = shp.numPoints;
            shp.InsertPoint(pt, ref numPoints);
            pt = new MapWinGIS.Point();
            pt.x = ext.xMin;
            pt.y = ext.yMax;
            return shp;
        }

        private static MapWinGIS.Extents getGridExtents(MapWinGIS.Grid g)
        {
            MapWinGIS.Extents ext = new MapWinGIS.Extents();
            MapWinGIS.GridHeader head;
            double centerX;
            double centerY;
            double yHalf;
            double xHalf;
            double xMin;
            double xMax;
            double yMin;
            double yMax;
            // This is fine for speed, but remember this is a reference-copied header
            head = g.Header;
            xHalf = head.dX / 2;
            yHalf = head.dY / 2;
            g.CellToProj(0, 0, out centerX, out centerY);
            xMin = centerX - xHalf;
            yMax = centerY + yHalf;
            g.CellToProj(head.NumberCols - 1, head.NumberRows - 1, out centerX, out centerY);
            xMax = centerX + xHalf;
            yMin = centerY - yHalf;
            ext.SetBounds(xMin, yMin, 0, xMax, yMax, 0);
            return ext;
        }
        #endregion

        #endregion
    }//End Of Hydrology
}

