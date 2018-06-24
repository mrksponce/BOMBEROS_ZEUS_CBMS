using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MapWinGIS;
using System.IO;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for SuperGridTest and is intended
    ///to contain all SuperGridTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SuperGridTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Value
        ///</summary>
        [TestMethod()]
        public void ValueTest()
        {
            SuperGrid target = new SuperGrid(); // TODO: Initialize to an appropriate value
            int Column = 0; // TODO: Initialize to an appropriate value
            int Row = 0; // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            target.set_Value(Column, Row, expected);
            actual = target.get_Value(Column, Row);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RasterColorTableColoringScheme
        ///</summary>
        [TestMethod()]
        public void RasterColorTableColoringSchemeTest()
        {
            SuperGrid target = new SuperGrid(); // TODO: Initialize to an appropriate value
            GridColorScheme actual;
            actual = target.RasterColorTableColoringScheme;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Minimum
        ///</summary>
        [TestMethod()]
        public void MinimumTest()
        {
            SuperGrid target = new SuperGrid(); // TODO: Initialize to an appropriate value
            object actual;
            actual = target.Minimum;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Maximum
        ///</summary>
        [TestMethod()]
        public void MaximumTest()
        {
            SuperGrid target = new SuperGrid(); // TODO: Initialize to an appropriate value
            object actual;
            actual = target.Maximum;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LastErrorCode
        ///</summary>
        [TestMethod()]
        public void LastErrorCodeTest()
        {
            SuperGrid target = new SuperGrid(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.LastErrorCode;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Key
        ///</summary>
        [TestMethod()]
        public void KeyTest()
        {
            SuperGrid target = new SuperGrid(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Key = expected;
            actual = target.Key;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for InRam
        ///</summary>
        [TestMethod()]
        public void InRamTest()
        {
            SuperGrid target = new SuperGrid(); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.InRam;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Header
        ///</summary>
        [TestMethod()]
        public void HeaderTest()
        {
            SuperGrid target = new SuperGrid(); // TODO: Initialize to an appropriate value
            GridHeader actual;
            actual = target.Header;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GlobalCallback
        ///</summary>
        [TestMethod()]
        public void GlobalCallbackTest()
        {
            SuperGrid target = new SuperGrid(); // TODO: Initialize to an appropriate value
            ICallback expected = null; // TODO: Initialize to an appropriate value
            ICallback actual;
            target.GlobalCallback = expected;
            actual = target.GlobalCallback;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Filename
        ///</summary>
        [TestMethod()]
        public void FilenameTest()
        {
            SuperGrid target = new SuperGrid(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Filename;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ErrorMsg
        ///</summary>
        [TestMethod()]
        public void ErrorMsgTest()
        {
            SuperGrid target = new SuperGrid(); // TODO: Initialize to an appropriate value
            int ErrorCode = 0; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.get_ErrorMsg(ErrorCode);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DataType
        ///</summary>
        [TestMethod()]
        public void DataTypeTest()
        {
            SuperGrid target = new SuperGrid(); // TODO: Initialize to an appropriate value
            GridDataType actual;
            actual = target.DataType;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CdlgFilter
        ///</summary>
        [TestMethod()]
        public void CdlgFilterTest()
        {
            SuperGrid target = new SuperGrid(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.CdlgFilter;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            SuperGrid target = new SuperGrid(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SetInvalidValuesToNodata
        ///</summary>
        [TestMethod()]
        public void SetInvalidValuesToNodataTest()
        {
            SuperGrid target = new SuperGrid(); // TODO: Initialize to an appropriate value
            double MinThresholdValue = 0F; // TODO: Initialize to an appropriate value
            double MaxThresholdValue = 0F; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.SetInvalidValuesToNodata(MinThresholdValue, MaxThresholdValue);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Save
        ///</summary>
        [TestMethod()]
        public void SaveTest()
        {
            SuperGrid target = new SuperGrid(); // TODO: Initialize to an appropriate value
            string Filename = string.Empty; // TODO: Initialize to an appropriate value
            GridFileType GridFileType = new GridFileType(); // TODO: Initialize to an appropriate value
            ICallback cBack = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Save(Filename, GridFileType, cBack);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ReadHDRFile
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ReadHDRFileTest()
        {
            SuperGrid_Accessor target = new SuperGrid_Accessor(); // TODO: Initialize to an appropriate value
            SuperGrid.sFLTData FLTData = new SuperGrid.sFLTData(); // TODO: Initialize to an appropriate value
            SuperGrid.sFLTData FLTDataExpected = new SuperGrid.sFLTData(); // TODO: Initialize to an appropriate value
            string HeaderFile = string.Empty; // TODO: Initialize to an appropriate value
            target.ReadHDRFile(ref FLTData, HeaderFile);
            Assert.AreEqual(FLTDataExpected, FLTData);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ReadFLTData
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ReadFLTDataTest()
        {
            SuperGrid_Accessor target = new SuperGrid_Accessor(); // TODO: Initialize to an appropriate value
            SuperGrid.sFLTData FLTData = new SuperGrid.sFLTData(); // TODO: Initialize to an appropriate value
            SuperGrid.sFLTData FLTDataExpected = new SuperGrid.sFLTData(); // TODO: Initialize to an appropriate value
            string DataFile = string.Empty; // TODO: Initialize to an appropriate value
            ICallback Callback = null; // TODO: Initialize to an appropriate value
            ICallback CallbackExpected = null; // TODO: Initialize to an appropriate value
            target.ReadFLTData(ref FLTData, DataFile, ref Callback);
            Assert.AreEqual(FLTDataExpected, FLTData);
            Assert.AreEqual(CallbackExpected, Callback);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ReadDEMData
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ReadDEMDataTest()
        {
            SuperGrid_Accessor target = new SuperGrid_Accessor(); // TODO: Initialize to an appropriate value
            Stream St = null; // TODO: Initialize to an appropriate value
            ICallback Callback = null; // TODO: Initialize to an appropriate value
            ICallback CallbackExpected = null; // TODO: Initialize to an appropriate value
            SuperGrid_Accessor.sDEMData expected = null; // TODO: Initialize to an appropriate value
            SuperGrid_Accessor.sDEMData actual;
            actual = target.ReadDEMData(St, ref Callback);
            Assert.AreEqual(CallbackExpected, Callback);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PutRow
        ///</summary>
        [TestMethod()]
        public void PutRowTest()
        {
            SuperGrid target = new SuperGrid(); // TODO: Initialize to an appropriate value
            int Row = 0; // TODO: Initialize to an appropriate value
            float Vals = 0F; // TODO: Initialize to an appropriate value
            float ValsExpected = 0F; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.PutRow(Row, ref Vals);
            Assert.AreEqual(ValsExpected, Vals);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PutFloatWindow
        ///</summary>
        [TestMethod()]
        public void PutFloatWindowTest()
        {
            SuperGrid target = new SuperGrid(); // TODO: Initialize to an appropriate value
            int StartRow = 0; // TODO: Initialize to an appropriate value
            int EndRow = 0; // TODO: Initialize to an appropriate value
            int StartCol = 0; // TODO: Initialize to an appropriate value
            int EndCol = 0; // TODO: Initialize to an appropriate value
            float Vals = 0F; // TODO: Initialize to an appropriate value
            float ValsExpected = 0F; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.PutFloatWindow(StartRow, EndRow, StartCol, EndCol, ref Vals);
            Assert.AreEqual(ValsExpected, Vals);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ProjToCell
        ///</summary>
        [TestMethod()]
        public void ProjToCellTest()
        {
            SuperGrid target = new SuperGrid(); // TODO: Initialize to an appropriate value
            double x = 0F; // TODO: Initialize to an appropriate value
            double y = 0F; // TODO: Initialize to an appropriate value
            int Column = 0; // TODO: Initialize to an appropriate value
            int ColumnExpected = 0; // TODO: Initialize to an appropriate value
            int Row = 0; // TODO: Initialize to an appropriate value
            int RowExpected = 0; // TODO: Initialize to an appropriate value
            target.ProjToCell(x, y, ref Column, ref Row);
            Assert.AreEqual(ColumnExpected, Column);
            Assert.AreEqual(RowExpected, Row);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Open
        ///</summary>
        [TestMethod()]
        public void OpenTest()
        {
            SuperGrid target = new SuperGrid(); // TODO: Initialize to an appropriate value
            string Filename = string.Empty; // TODO: Initialize to an appropriate value
            GridDataType DataType = new GridDataType(); // TODO: Initialize to an appropriate value
            bool InRam = false; // TODO: Initialize to an appropriate value
            GridFileType FileType = new GridFileType(); // TODO: Initialize to an appropriate value
            ICallback cBack = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Open(Filename, DataType, InRam, FileType, cBack);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MakeGrid
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void MakeGridTest1()
        {
            SuperGrid_Accessor target = new SuperGrid_Accessor(); // TODO: Initialize to an appropriate value
            SuperGrid_Accessor.sDEMData DEMData = null; // TODO: Initialize to an appropriate value
            ICallback Callback = null; // TODO: Initialize to an appropriate value
            ICallback CallbackExpected = null; // TODO: Initialize to an appropriate value
            target.MakeGrid(DEMData, ref Callback);
            Assert.AreEqual(CallbackExpected, Callback);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MakeGrid
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void MakeGridTest()
        {
            SuperGrid_Accessor target = new SuperGrid_Accessor(); // TODO: Initialize to an appropriate value
            SuperGrid.sFLTData FLTData = new SuperGrid.sFLTData(); // TODO: Initialize to an appropriate value
            string InitialFile = string.Empty; // TODO: Initialize to an appropriate value
            ICallback Callback = null; // TODO: Initialize to an appropriate value
            ICallback CallbackExpected = null; // TODO: Initialize to an appropriate value
            target.MakeGrid(FLTData, InitialFile, ref Callback);
            Assert.AreEqual(CallbackExpected, Callback);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ImportSURFERFormat
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ImportSURFERFormatTest()
        {
            SuperGrid_Accessor target = new SuperGrid_Accessor(); // TODO: Initialize to an appropriate value
            string InFile = string.Empty; // TODO: Initialize to an appropriate value
            ICallback Callback = null; // TODO: Initialize to an appropriate value
            ICallback CallbackExpected = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.ImportSURFERFormat(InFile, ref Callback);
            Assert.AreEqual(CallbackExpected, Callback);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ImportFLTFormat
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ImportFLTFormatTest()
        {
            SuperGrid_Accessor target = new SuperGrid_Accessor(); // TODO: Initialize to an appropriate value
            string InFile = string.Empty; // TODO: Initialize to an appropriate value
            ICallback Callback = null; // TODO: Initialize to an appropriate value
            ICallback CallbackExpected = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.ImportFLTFormat(InFile, ref Callback);
            Assert.AreEqual(CallbackExpected, Callback);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ImportDEMFormat
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ImportDEMFormatTest()
        {
            SuperGrid_Accessor target = new SuperGrid_Accessor(); // TODO: Initialize to an appropriate value
            string InFile = string.Empty; // TODO: Initialize to an appropriate value
            ICallback Callback = null; // TODO: Initialize to an appropriate value
            ICallback CallbackExpected = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.ImportDEMFormat(InFile, ref Callback);
            Assert.AreEqual(CallbackExpected, Callback);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for grd2asc
        ///</summary>
        [TestMethod()]
        public void grd2ascTest()
        {
            SuperGrid target = new SuperGrid(); // TODO: Initialize to an appropriate value
            string sGridfile = string.Empty; // TODO: Initialize to an appropriate value
            string sGridfileExpected = string.Empty; // TODO: Initialize to an appropriate value
            string sAscfile = string.Empty; // TODO: Initialize to an appropriate value
            string sAscfileExpected = string.Empty; // TODO: Initialize to an appropriate value
            string errMsg = string.Empty; // TODO: Initialize to an appropriate value
            string errMsgExpected = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.grd2asc(ref sGridfile, ref sAscfile, ref errMsg);
            Assert.AreEqual(sGridfileExpected, sGridfile);
            Assert.AreEqual(sAscfileExpected, sAscfile);
            Assert.AreEqual(errMsgExpected, errMsg);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetRow
        ///</summary>
        [TestMethod()]
        public void GetRowTest()
        {
            SuperGrid target = new SuperGrid(); // TODO: Initialize to an appropriate value
            int Row = 0; // TODO: Initialize to an appropriate value
            float Vals = 0F; // TODO: Initialize to an appropriate value
            float ValsExpected = 0F; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.GetRow(Row, ref Vals);
            Assert.AreEqual(ValsExpected, Vals);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetHashCode
        ///</summary>
        [TestMethod()]
        public void GetHashCodeTest()
        {
            SuperGrid target = new SuperGrid(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetHashCode();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetFloatWindow
        ///</summary>
        [TestMethod()]
        public void GetFloatWindowTest()
        {
            SuperGrid target = new SuperGrid(); // TODO: Initialize to an appropriate value
            int StartRow = 0; // TODO: Initialize to an appropriate value
            int EndRow = 0; // TODO: Initialize to an appropriate value
            int StartCol = 0; // TODO: Initialize to an appropriate value
            int EndCol = 0; // TODO: Initialize to an appropriate value
            float Vals = 0F; // TODO: Initialize to an appropriate value
            float ValsExpected = 0F; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.GetFloatWindow(StartRow, EndRow, StartCol, EndCol, ref Vals);
            Assert.AreEqual(ValsExpected, Vals);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetChunk
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void GetChunkTest()
        {
            SuperGrid_Accessor target = new SuperGrid_Accessor(); // TODO: Initialize to an appropriate value
            Stream St = null; // TODO: Initialize to an appropriate value
            int Offset = 0; // TODO: Initialize to an appropriate value
            int Count = 0; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetChunk(St, Offset, Count);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Finalize
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void FinalizeTest()
        {
            SuperGrid_Accessor target = new SuperGrid_Accessor(); // TODO: Initialize to an appropriate value
            target.Finalize();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Fdbl
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void FdblTest()
        {
            SuperGrid_Accessor target = new SuperGrid_Accessor(); // TODO: Initialize to an appropriate value
            string s = string.Empty; // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            actual = target.Fdbl(s);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod()]
        public void EqualsTest()
        {
            SuperGrid target = new SuperGrid(); // TODO: Initialize to an appropriate value
            object obj = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Equals(obj);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CreateNew
        ///</summary>
        [TestMethod()]
        public void CreateNewTest()
        {
            SuperGrid target = new SuperGrid(); // TODO: Initialize to an appropriate value
            string Filename = string.Empty; // TODO: Initialize to an appropriate value
            GridHeader Header = null; // TODO: Initialize to an appropriate value
            GridDataType DataType = new GridDataType(); // TODO: Initialize to an appropriate value
            object InitialValue = null; // TODO: Initialize to an appropriate value
            bool InRam = false; // TODO: Initialize to an appropriate value
            GridFileType FileType = new GridFileType(); // TODO: Initialize to an appropriate value
            ICallback cBack = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.CreateNew(Filename, Header, DataType, InitialValue, InRam, FileType, cBack);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Close
        ///</summary>
        [TestMethod()]
        public void CloseTest()
        {
            SuperGrid target = new SuperGrid(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Close();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Clear
        ///</summary>
        [TestMethod()]
        public void ClearTest()
        {
            SuperGrid target = new SuperGrid(); // TODO: Initialize to an appropriate value
            object ClearValue = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Clear(ClearValue);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CellToProj
        ///</summary>
        [TestMethod()]
        public void CellToProjTest()
        {
            SuperGrid target = new SuperGrid(); // TODO: Initialize to an appropriate value
            int Column = 0; // TODO: Initialize to an appropriate value
            int Row = 0; // TODO: Initialize to an appropriate value
            double x = 0F; // TODO: Initialize to an appropriate value
            double xExpected = 0F; // TODO: Initialize to an appropriate value
            double y = 0F; // TODO: Initialize to an appropriate value
            double yExpected = 0F; // TODO: Initialize to an appropriate value
            target.CellToProj(Column, Row, ref x, ref y);
            Assert.AreEqual(xExpected, x);
            Assert.AreEqual(yExpected, y);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AssignNewProjection
        ///</summary>
        [TestMethod()]
        public void AssignNewProjectionTest()
        {
            SuperGrid target = new SuperGrid(); // TODO: Initialize to an appropriate value
            string Projection = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.AssignNewProjection(Projection);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SuperGrid Constructor
        ///</summary>
        [TestMethod()]
        public void SuperGridConstructorTest()
        {
            SuperGrid target = new SuperGrid();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
