using System;
using System.Collections.Generic;
using System.Text;
using MapWinGeoProc.Dialogs;
namespace MapWinGeoProc
{
    /// <summary>
    /// Contains static functions for image transforms, especially filters
    /// </summary>
    public static class ImageAnalysis
    {
        #region "Apply Filter"

        #region ------- APPLY FILTER --- OVERLOADS

        #region ----------- FILE BASED

        /// <summary>
        /// Will convolve the 2-D filter with the source image, producing the output image.
        /// This overload assumes that you are working with files.
        /// </summary>
        /// <param name="SourceFile">A string representing the image file to open.</param>
        /// <param name="DestFile">A string representing the image file to save to.</param>
        /// <param name="filter">A 2D array of floats, row major.  Filter must be smaller than image.</param>
        /// <param name="ShowProgressDialog">Boolean, true to have the function automatically show a dialog.</param>
        /// <param name="ICallBack">A MapWinGIS.ICallback for handling errors and progress messages</param>
        /// <returns>Boolean, false if the process was canceled.</returns>
        public static bool ApplyFilter(string SourceFile, string DestFile, float[,] filter, bool ShowProgressDialog, MapWinGIS.ICallback ICallBack)
        {
            MapWinUtility.Logger.Dbg("ApplyFilter(SourceFile: " + SourceFile + ",\n" +
                                     "            DestFile: " + DestFile + ",\n" +
                                     "            filter: [" + filter.GetUpperBound(0) + ", " + filter.GetUpperBound(1) + "],\n" +
                                     "            ShowProgressDialog: " + ShowProgressDialog.ToString() + ",\n" +
                                     "            ICallback)");
            bool res;
            // Argument checks
            if (SourceFile == null)
            {
                MapWinUtility.Logger.Dbg("Argument Exception: SourceFile cannot be null.");
                throw new ArgumentException("SourceFile cannot be null.");
            }
            if (System.IO.File.Exists(SourceFile) == false)
            {
                MapWinUtility.Logger.Dbg("Argument Exception: SourceFile not found.");
                throw new ArgumentException("SourceFile not found.");
            }
            if (DestFile == null)
            {
                MapWinUtility.Logger.Dbg("Argument Exception: DestFile cannot be null.");
                throw new ArgumentException("DestFile cannot be null.");
            }
            if (System.IO.File.Exists(SourceFile) == true) System.IO.File.Delete(DestFile);
            if (filter.GetUpperBound(0) == 0 || filter.GetUpperBound(1) == 0)
            {
                MapWinUtility.Logger.Dbg("Argument Exception: Filter must have values.");
                throw new ArgumentException("Filter must have values.");
            }

            // Check image object
            MapWinGIS.Image SourceImage = new MapWinGIS.Image();
            res = SourceImage.Open(SourceFile, MapWinGIS.ImageType.USE_FILE_EXTENSION, true, null);
            if (res == false)
            {
                MapWinUtility.Logger.Dbg("Application Exception: " + "Attempting to open " + SourceFile + " produced the following error:\n" + SourceImage.get_ErrorMsg(SourceImage.LastErrorCode));
                throw new ApplicationException("Attempting to open " + SourceFile + " produced the following error:\n" + SourceImage.get_ErrorMsg(SourceImage.LastErrorCode));
            }
            // Try to create the output image
            MapWinGIS.Image DestImage = new MapWinGIS.Image();
            res = DestImage.CreateNew(SourceImage.Width, SourceImage.Height);
            if (res == false)
            {
                MapWinUtility.Logger.Dbg("Application Exception: " + "Attempting to create " + DestFile + " produced the following error:\n" + DestImage.get_ErrorMsg(DestImage.LastErrorCode));
                throw new ApplicationException("Attempting to create " + DestFile + " produced the following error:\n" + DestImage.get_ErrorMsg(DestImage.LastErrorCode));
            }
            DestImage.Save(DestFile, false, MapWinGIS.ImageType.USE_FILE_EXTENSION, ICallBack);
            res = Do_ApplyFilter(SourceImage, ref DestImage, filter, ShowProgressDialog, ICallBack);
            DestImage.Close();
            SourceImage.Close();
            MapWinUtility.Logger.Dbg("Finished ApplyFilter");
            return res;
        }
        /// <summary>
        /// Will convolve the 2-D filter with the source image, producing the output image.
        /// This overload assumes that you are working with files.
        /// </summary>
        ///<param name="SourceFile">A string representing the image file to open.</param>
        /// <param name="DestFile">A string representing the image file to save to.</param>
        /// <param name="filter">A 2D array of floats, row major.  Filter must be smaller than image.</param>
        /// <returns>Boolean, false if the process was canceled.</returns>
        public static bool ApplyFilter(string SourceFile, string DestFile, float[,] filter)
        {
            MapWinUtility.Logger.Dbg("ApplyFilter(SourceFile: " + SourceFile + ",\n" +
                                     "            DestFile: " + DestFile + ",\n" +
                                     "            filter: [" + filter.GetUpperBound(0) + ", " + filter.GetUpperBound(1) + "])");
            // The default for show dialog is true, the default for icallback is null.
            MapWinUtility.Logger.Dbg("Finsihed ApplyFilter");
            return ApplyFilter(SourceFile, DestFile, filter, true, null);
            
        }
        #endregion

        #region ----------- OBJECT BASED
        /// <summary>
        /// Will convolve the SourceImage specified using the filter specified, returning the result in a new image
        /// as the ref parameter DestImage.  
        /// </summary>
        /// <param name="SourceImage">A MapWinGIS.Image object to be processed</param>
        /// <param name="DestImage">The output MapWinGIS.Image object from this process</param>
        /// <param name="filter">The 2D float array of filter coefficients to use (Row Major)</param>
        /// <param name="ShowProgressDialog">If true, will show progress in a typical dialog form</param>
        /// <param name="ICallBack">If specified, will return data as a MapWinGIS.ICallBack object</param>
        /// <returns>Boolean, false if the process was canceled.</returns>
        public static bool ApplyFilter(MapWinGIS.Image SourceImage, ref MapWinGIS.Image DestImage, float[,] filter, bool ShowProgressDialog, MapWinGIS.ICallback ICallBack)
        {
            // Report unnamed as differently from null
            string SourceFile = "null";
            string DestFile = "null";
            
            if (SourceImage != null)
            {
                SourceFile = SourceImage.Filename;
                if (SourceFile == null)SourceFile = "Unnamed";
            }
            if (DestImage != null)
            {
                DestFile = SourceImage.Filename;
                if (DestFile == null) DestFile = "Unnamed";
            }
            MapWinUtility.Logger.Dbg("ApplyFilter(SourceImage: " + SourceFile + ",\n" +
                                     "            DestImage: " + DestFile + ",\n" +
                                     "            filter: [" + filter.GetUpperBound(0) + ", " + filter.GetUpperBound(1) + "],\n" +
                                     "            ShowProgressDialog: " + ShowProgressDialog.ToString() + ",\n" +
                                     "            ICallback)");

            return Do_ApplyFilter(SourceImage, ref DestImage, filter, ShowProgressDialog, ICallBack);
        }
        /// <summary>
        /// Will convolve the SourceImage specified using the filter specified, returning the result in a new image
        /// as the ref parameter DestImage.  
        /// </summary>
        /// <param name="SourceImage">A MapWinGIS.Image object to be processed</param>
        /// <param name="DestImage">The output MapWinGIS.Image object from this process</param>
        /// <param name="filter">The 2D float array of filter coefficients to use (Row Major)</param>
        /// <returns>Boolean, false if the process was canceled.</returns>
        public static bool ApplyFilter(MapWinGIS.Image SourceImage, ref MapWinGIS.Image DestImage, float[,] filter)
        {
            // Report unnamed as differently from null
            string SourceFile = "null";
            string DestFile = "null";

            if (SourceImage != null)
            {
                SourceFile = SourceImage.Filename;
                if (SourceFile == null) SourceFile = "Unnamed";
            }
            if (DestImage != null)
            {
                DestFile = SourceImage.Filename;
                if (DestFile == null) DestFile = "Unnamed";
            }
            MapWinUtility.Logger.Dbg("ApplyFilter(SourceImage: " + SourceFile + ",\n" +
                                     "            DestImage: " + DestFile + ",\n" +
                                     "            filter: [" + filter.GetUpperBound(0) + ", " + filter.GetUpperBound(1) + "])");
            
           
            return Do_ApplyFilter(SourceImage, ref DestImage, filter, true, null);
            
        }

        #endregion

        #endregion
        // False if the user canceled, true otherwise
        private static bool Do_ApplyFilter(MapWinGIS.Image SourceImage, ref MapWinGIS.Image DestImage, float[,] filter, bool ShowProgressDialog, MapWinGIS.ICallback ICallBack)
        {
            int Prog = 0;
            int OldProg = 0;
            

            // Report unnamed as differently from null
            string SourceFile = "null";
            string DestFile = "null";

            if (SourceImage != null)
            {
                SourceFile = SourceImage.Filename;
                if (SourceFile == null) SourceFile = "Unnamed";
            }
            else
            {
                MapWinUtility.Logger.Dbg("Argument Exception: SourceImage cannot be null.");
                throw new ArgumentException("SourceImage cannot be null.");
            }
            if (DestImage != null)
            {
                DestFile = SourceImage.Filename;
                if (DestFile == null) DestFile = "Unnamed";
            }
            else
            {
                MapWinUtility.Logger.Dbg("Argument Exception: DestImage cannot be null.");
                throw new ArgumentException("DestImage cannot be null.");
            }
            
            MapWinUtility.Logger.Dbg("Do_ApplyFilter(SourceImage: " + SourceImage.Filename + ",\n" +
                                     "            DestImage: " + DestImage.Filename + ",\n" +
                                     "            filter: [" + filter.GetUpperBound(0) + ", " + filter.GetUpperBound(1) + "],\n" +
                                     "            ShowProgressDialog: " + ShowProgressDialog.ToString() + ",\n" +
                                     "            ICallback)");
            
            ProgressDialog MyProgress = new ProgressDialog();


            if (filter.GetUpperBound(0) == 0 || filter.GetUpperBound(1) == 0)
            {
                MapWinUtility.Logger.Dbg("Argument Exception: Filter must have values.");
                throw new ArgumentException("Filter must have values.");
            }
          
            // Ensure the filter is smaller than the image.
            if (filter.GetUpperBound(0) > SourceImage.Height || filter.GetUpperBound(1) > SourceImage.Width)
            {
                throw new ArgumentException("The filter is too large for this image.  In order for convolution to work, the image must be larger than the filter.");
            }
            
            // We are going to assume mirror handling of edges
            ExtHandler LocHandler = new ExtHandler(SourceImage.Height, SourceImage.Width);
            
            // convolve
            int R, G, B, color;
            int Xcor = 0, Ycor = 0; // Corrected X and Y locations to take into account mirror
            int fH, fW; // stores the values of half the height and width of the filter
            fH = (int)filter.GetUpperBound(0) / 2;
            fW = (int)filter.GetUpperBound(1) / 2;

            if (ICallBack == null)
            {
                MyProgress.Show();
                MyProgress.WriteMessage("Applying Filter...");
                MapWinUtility.Logger.Progress("Applying Filter...", Prog, OldProg);
            }
            for (int row = 0; row < SourceImage.Height; row++)
            {
                for (int col = 0; col < SourceImage.Width; col++)
                {
                    float fR = 0;
                    float fG = 0;
                    float fB = 0;
                   
                    for (int Y = 0; Y <= filter.GetUpperBound(0); Y++)
                    {
                        for (int X = 0; X <= filter.GetUpperBound(1); X++)
                        {
                            // Read the color for this spot
                            LocHandler.CorrectLocation(col + X - fW, row + Y - fH, ref Xcor, ref Ycor);
                            color = SourceImage.get_Value(Ycor, Xcor);
                            R = color % 256;
                            G = (int)(color / 256) % 256;
                            B = (int)(color / (256*256));

                            // convolve the values with the filter and add them to the accumulators
                            fR += filter[Y, X] * R;
                            fG += filter[Y, X] * G;
                            fB += filter[Y, X] * B;
                        }
                    }
                    // After convolution, write the combined value to the file
                    R = (int)fR;
                    if (R > 255) R = 255;
                    G = (int)fG;
                    if (G > 255) G = 255;
                    B = (int)fB;
                    if (B > 255) B = 255;
                    color = (256 * 256) * B + 256 * G + R;
                    DestImage.set_Value(row, col, color);
                }
                Prog = (100 * row) / SourceImage.Height;
                if (Prog > OldProg)
                {
                    if (ICallBack != null)
                    {
                        ICallBack.Progress("Status", Prog, "Filtering Image...");
                    }

                    
                    if (ShowProgressDialog == true)
                    {
                        MyProgress.Progress = Prog;

                        if (MyProgress.IsCanceled == true)
                        {
                            MapWinUtility.Logger.Message("Apply Filter was canceled.", "Process Canceled", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.DialogResult.OK);
                            return false;
                        }
                    }

                    MapWinUtility.Logger.Progress("Filtering Image..." + Prog.ToString() + "%Complete", Prog, OldProg);
                    OldProg = Prog;
                }
            }
            MyProgress.Hide();
            DestImage.dX = SourceImage.dX;
            DestImage.dY = SourceImage.dY;
            DestImage.SetProjection(SourceImage.GetProjection());
            DestImage.Save(DestImage.Filename, true, MapWinGIS.ImageType.USE_FILE_EXTENSION, null);
            MapWinUtility.Logger.Dbg("Finsihed ApplyFilter");
            return true;
        }

        // Ensures that we use mirror edges when a filter extends beyond the end of the image
        private class ExtHandler
        {
            int m_Height;
            int m_Width;
            public ExtHandler(int Height, int Width)
            {
                m_Height = Height;
                m_Width = Width;
            }
            public void CorrectLocation(int X, int Y, ref int Xcor, ref int Ycor)
            {
                Xcor = X;
                Ycor = Y;
                if (X > m_Width - 1) Xcor = m_Width - (X - (m_Width - 1));
                if (Y > m_Height - 1) Ycor = m_Height - (Y - (m_Height - 1));
                if (X < 0) Xcor = Math.Abs(X) - 1;
                if (Y < 0) Ycor = Math.Abs(Y) - 1;
            }
        }

        #endregion

        // This is not a full fledged map algebra function!  This cannot deal with
        // images of different sizes or cell spacings.  This is only a quick function
        // that can tell if, for instance, a pitfilled image is different from the
        // version created in Arcview.  It simply takes each cell and finds the difference
        // in values.
        #region "Difference"
       
        /// <summary>
        /// Calculates the difference values and stores them in the Dest grid.  This only works if the grids
        /// have the same number of rows and columns.
        /// </summary>
        /// <param name="Source1">MapWinGIS.Grid representing one source grid</param>
        /// <param name="Source2">MapWinGIS.Grid to compare Source1 against</param>
        /// <param name="Dest">MapWinGIS.Grid where the output is to be saved</param>
        /// <param name="ICallBack">A MapWinGIS.ICallBack</param>
        /// <remarks>Uses ArgumentExceptions if the grids are different sizes</remarks>
        public static void Difference(MapWinGIS.Grid Source1, MapWinGIS.Grid Source2, MapWinGIS.Grid Dest, MapWinGIS.ICallback ICallBack)
        {

            // Log entrance as best as possible while preventing errors from a null reference
            string Source1File = "null";
            string Source2File = "null";
            string DestFile = "null";
            if(Source1 != null)
            {
                Source1File = Source1.Filename;
                if(Source1File == null)Source1File = "Unnamed";
            }
            if(Source2 != null)
            {
                Source2File = Source2.Filename;
                if(Source2File == null)Source2File = "Unnamed";
            }
            if(Dest != null)
            {
                DestFile = Dest.Filename;
                if(DestFile == null)DestFile = "Unnamed";
            }
            MapWinUtility.Logger.Dbg("Difference(Source1: " + Source1File + ",\n" +
                                     "           Source2: " + Source2File + ",\n" +
                                     "           Dest: " + DestFile + ",\n" +
                                     "           ICallback");

            if (Source1 == null)
            {
                MapWinUtility.Logger.Dbg("Argument Exception: Source1 cannot be null.");
                throw new ArgumentException("Source1 cannot be null.");
            }
            if (Source2 == null)
            {
                MapWinUtility.Logger.Dbg("Argument Exception: Source2 cannot be null.");
                throw new ArgumentException("Source2 cannot be null.");
            }
            if (Dest == null)
            {
                MapWinUtility.Logger.Dbg("Argument Exception: Dest cannot be null.");
                throw new ArgumentException("Dest cannot be null.");
            }
            int nX, nY;
            nX = Source1.Header.NumberCols;
            nY = Source1.Header.NumberRows;
            if (Source2.Header.NumberRows != nY)
            {
                MapWinUtility.Logger.Dbg("Argument Exception: The grids are not the same height.");
                throw new ArgumentException("The grids are not the same height.");
            }
            if (Source2.Header.NumberCols != nX)
            {
                MapWinUtility.Logger.Dbg("Argument Exception: The grids are not the same width!");
                throw new ArgumentException("The grids are not the same width!");
            }
            if (Dest.Header.NumberRows != nY)
            {
                MapWinUtility.Logger.Dbg("Argument Exception: The output grid is not the same height!");
                throw new ArgumentException("The output grid is not the same height!");
            }
            if (Dest.Header.NumberCols != nX)
            {
                MapWinUtility.Logger.Dbg("Argument Exception: The output grid is not the same width!");
                throw new ArgumentException("The output grid is not the same width!");
            }

            int OldProg = 0;
            int Prog = 0;
            if (ICallBack != null) ICallBack.Progress("Status", 0, "Difference...0% Complete");
            MapWinUtility.Logger.Progress("Difference...0% Complete", Prog, OldProg);
            if (Source1.DataType != MapWinGIS.GridDataType.FloatDataType)
            {
                switch(Source1.DataType)
                {
                    case MapWinGIS.GridDataType.DoubleDataType:
                        for (int Y = 0; Y < nY; Y++)
                        {
                            for (int X = 0; X < nX; X++)
                            {
                                double val = (double)Source1.get_Value(X, Y) - (double)Source2.get_Value(X, Y);
                                Dest.set_Value(X, Y, val);
                            }
                            if (ICallBack != null)
                            {
                                Prog = (int)(Y * 100 / nY);
                                if (Prog  > OldProg)
                                {
                                    ICallBack.Progress("Status", Prog, "Difference..." + Prog.ToString() + "% Complete");
                                    MapWinUtility.Logger.Progress("Difference..." + Prog.ToString() + "% Complete", Prog, OldProg);
                                    OldProg = Prog;
                                }
                            }
                        }
                        break;
                    case MapWinGIS.GridDataType.UnknownDataType:
                        for (int Y = 0; Y < nY; Y++)
                        {
                            for (int X = 0; X < nX; X++)
                            {
                                double val = (double)Source1.get_Value(X, Y) - (double)Source2.get_Value(X, Y);
                                Dest.set_Value(X, Y, val);
                            }
                            if (ICallBack != null)
                            {
                                Prog = (int)(Y * 100 / nY);
                                if (Prog > OldProg)
                                {
                                    
                                    ICallBack.Progress("Status", Prog, "Difference..." + Prog.ToString() + "% Complete");
                                    MapWinUtility.Logger.Progress("Difference..." + Prog.ToString() + "% Complete", Prog, OldProg);
                                    OldProg = Prog;
                                }
                            }
                        }
                        break;
                    case MapWinGIS.GridDataType.LongDataType:
                        for (int Y = 0; Y < nY; Y++)
                        {
                            for (int X = 0; X < nX; X++)
                            {
                                long val = (long)Source1.get_Value(X, Y) - (long)Source2.get_Value(X, Y);
                                Dest.set_Value(X, Y, val);
                            }
                            if (ICallBack != null)
                            {
                                Prog = (int)(Y * 100 / nY);
                                if (Prog > OldProg)
                                {
                                    MapWinUtility.Logger.Progress("Difference..." + Prog.ToString() + "% Complete", Prog, OldProg);
                                    ICallBack.Progress("Status", Prog, "Difference..." + Prog.ToString() + "% Complete");
                                    OldProg = Prog;
                                }
                            }
                        }
                        break;
                    case MapWinGIS.GridDataType.ShortDataType:
                        for (int Y = 0; Y < nY; Y++)
                        {
                            for (int X = 0; X < nX; X++)
                            {
                                int val = (int)Source1.get_Value(X, Y) - (int)Source2.get_Value(X, Y);
                                Dest.set_Value(X, Y, val);
                            }
                            if (ICallBack != null)
                            {
                                Prog = (int)(Y * 100 / nY);
                                if (Prog > OldProg)
                                {
                                    MapWinUtility.Logger.Progress("Difference..." + Prog.ToString() + "% Complete", Prog, OldProg);
                                    ICallBack.Progress("Status", Prog, "Difference..." + Prog.ToString() + "% Complete");
                                    OldProg = Prog;
                                }
                            }
                        }
                        break;
                    default:
                        MapWinUtility.Logger.Progress("The Datatype was not a valid numeric type.", Prog, OldProg);
                        throw new ArgumentException("The Datatype was not a valid numeric type.");
                }
            }
            else
            {
                for (int Y = 0; Y < nY; Y++)
                {
                    float[] Vals1 = new float[nX];
                    float[] Vals2 = new float[nX];
                    float[] Diff = new float[nX];
                    Source1.GetRow(Y, ref Vals1[0]);
                    Source2.GetRow(Y, ref Vals2[0]);
                    for (int X = 0; X < nX; X++)
                    {
                        Diff[X] = Vals1[X] - Vals2[X];
                    }
                    Dest.PutRow(Y, ref Diff[0]);
                    if (ICallBack != null)
                    {
                        Prog = (int)(Y * 100 / nY);
                        if (Prog > OldProg)
                        {
                            MapWinUtility.Logger.Progress("Difference..." + Prog.ToString() + "% Complete", Prog, OldProg);
                            ICallBack.Progress("Status", Prog, "Difference..." + Prog.ToString() + "% Complete");
                            OldProg = Prog;
                        }
                    }
                }
                
            }
            MapWinUtility.Logger.Dbg("Finished Difference");
            if (ICallBack != null) ICallBack.Progress("Status", 0, "Done.");
        }
        /// <summary>
        /// This overload calculates the difference between files.  THe number of rows and columns should be the same.
        /// </summary>
        /// <param name="SourceFile1">String filename of one grid to compare</param>
        /// <param name="SourceFile2">String filename of another grid to compare</param>
        /// <param name="DestFile">String filename of the output difference file</param>
        /// <param name="Overwrite">Boolean, true if you wish to overwrite an existing output 
        /// file and delete the associated .bmp file.  False raises a messagebox if the files exist.</param>
        /// <param name="ICallBack">A MapWinGIS.ICallBack for status messages</param>
        public static void Difference(string SourceFile1, string SourceFile2, string DestFile, bool Overwrite, MapWinGIS.ICallback ICallBack)
        {
            MapWinGIS.Grid Source1 = new MapWinGIS.Grid();
            MapWinGIS.Grid Source2 = new MapWinGIS.Grid();
            MapWinGIS.Grid Dest = new MapWinGIS.Grid();
            bool res;

            // Open the source grids
            if (ICallBack != null) ICallBack.Progress("Status", 0, "Opening Files...");
            res = Source1.Open(SourceFile1, MapWinGIS.GridDataType.UnknownDataType, true, MapWinGIS.GridFileType.UseExtension, ICallBack);
            if (res == false)
            {
                MapWinUtility.Logger.Dbg("Argument Exception: " + Source1.get_ErrorMsg(Source1.LastErrorCode));
                throw new ArgumentException(Source1.get_ErrorMsg(Source1.LastErrorCode));
            }
            res = Source2.Open(SourceFile2, MapWinGIS.GridDataType.UnknownDataType, true, MapWinGIS.GridFileType.UseExtension, ICallBack);
            if (res == false) throw new ArgumentException(Source2.get_ErrorMsg(Source2.LastErrorCode));
            
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
                    if (System.IO.File.Exists(bpw)) System.IO.File.Delete(bpw);
                    if (System.IO.File.Exists(prj)) System.IO.File.Delete(prj);
                    if (System.IO.File.Exists(mwleg)) System.IO.File.Delete(mwleg);
                }
                System.IO.File.Delete(DestFile);
            }

            // Create a new output grid
            MapWinGIS.GridHeader newHeader = new MapWinGIS.GridHeader();
            newHeader.CopyFrom(Source1.Header);
            if (ICallBack != null)
            {
                MapWinUtility.Logger.Dbg("Creating Output File...");
                ICallBack.Progress("Status", 0, "Creating Output File...");
            }
            res = Dest.CreateNew(DestFile, newHeader, Source1.DataType, 0, true, MapWinGIS.GridFileType.UseExtension, ICallBack);
            if (res == false)
            {
                MapWinUtility.Logger.Dbg("Argument Exception: " + Dest.get_ErrorMsg(Dest.LastErrorCode));
                throw new ArgumentException(Dest.get_ErrorMsg(Dest.LastErrorCode));
            }

            // Calculate the differences
            Difference(Source1, Source2, Dest, ICallBack);
            
            // Close Source grids
            Source1.Close();
            Source2.Close();

            // Save and close the output grid
            res = Dest.Save(DestFile, MapWinGIS.GridFileType.UseExtension, ICallBack);
            if (res == false)
            {
                MapWinUtility.Logger.Dbg("Application Exception: " + Dest.get_ErrorMsg(Dest.LastErrorCode));
                throw new ArgumentException(Dest.get_ErrorMsg(Dest.LastErrorCode));
            }
            Dest.Close();
            MapWinUtility.Logger.Dbg("Finished Difference");
        }

        #endregion


    }
}
