using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// using MapWindow.Interfaces;
using MapWinGIS;
using System.Collections;
// using LegendControl;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for LayersTest and is intended
    ///to contain all LayersTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LayersTest
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
        ///A test for NumLayers
        ///</summary>
        [TestMethod()]
        public void NumLayersTest()
        {
            Layers target = new Layers(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.NumLayers;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Item
        ///</summary>
        [TestMethod()]
        public void ItemTest()
        {
            MapWindow.Interfaces.Layers target = new Layers(); // TODO: Initialize to an appropriate value
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Layer actual;
            actual = target[LayerHandle];
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Groups
        ///</summary>
        [TestMethod()]
        public void GroupsTest()
        {
            MapWindow.Layers target = new MapWindow.Layers(); // TODO: Initialize to an appropriate value
            LegendControl.Groups actual;
            actual = target.Groups;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CurrentLayer
        ///</summary>
        [TestMethod()]
        public void CurrentLayerTest()
        {
            Layers target = new Layers(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.CurrentLayer = expected;
            actual = target.CurrentLayer;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TryCloseObject
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void TryCloseObjectTest()
        {
            Layers_Accessor target = new Layers_Accessor(); // TODO: Initialize to an appropriate value
            object newObject = null; // TODO: Initialize to an appropriate value
            target.TryCloseObject(newObject);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for TestShapefile
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void TestShapefileTest()
        {
            Layers_Accessor target = new Layers_Accessor(); // TODO: Initialize to an appropriate value
            Shapefile sf = null; // TODO: Initialize to an appropriate value
            Shapefile sfExpected = null; // TODO: Initialize to an appropriate value
            bool abort = false; // TODO: Initialize to an appropriate value
            bool abortExpected = false; // TODO: Initialize to an appropriate value
            target.TestShapefile(ref sf, ref abort);
            Assert.AreEqual(sfExpected, sf);
            Assert.AreEqual(abortExpected, abort);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ReportProgress
        ///</summary>
        [TestMethod()]
        public void ProgressTest()
        {
            ICallback target = new Layers(); // TODO: Initialize to an appropriate value
            string KeyOfSender = string.Empty; // TODO: Initialize to an appropriate value
            int Percent = 0; // TODO: Initialize to an appropriate value
            string Message = string.Empty; // TODO: Initialize to an appropriate value
            target.Progress(KeyOfSender, Percent, Message);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ReportError
        ///</summary>
        [TestMethod()]
        public void ErrorTest()
        {
            ICallback target = new Layers(); // TODO: Initialize to an appropriate value
            string KeyOfSender = string.Empty; // TODO: Initialize to an appropriate value
            string ErrorMsg = string.Empty; // TODO: Initialize to an appropriate value
            target.Error(KeyOfSender, ErrorMsg);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Remove
        ///</summary>
        [TestMethod()]
        public void RemoveTest()
        {
            Layers target = new Layers(); // TODO: Initialize to an appropriate value
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            target.Remove(LayerHandle);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for RebuildGridLayer
        ///</summary>
        [TestMethod()]
        public void RebuildGridLayerTest()
        {
            Layers target = new Layers(); // TODO: Initialize to an appropriate value
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            Grid GridObject = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColorScheme = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.RebuildGridLayer(LayerHandle, GridObject, ColorScheme);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MoveLayer
        ///</summary>
        [TestMethod()]
        public void MoveLayerTest()
        {
            Layers target = new Layers(); // TODO: Initialize to an appropriate value
            int Handle = 0; // TODO: Initialize to an appropriate value
            int NewPosition = 0; // TODO: Initialize to an appropriate value
            int TargetGroup = 0; // TODO: Initialize to an appropriate value
            target.MoveLayer(Handle, NewPosition, TargetGroup);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MakeRandomColor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void MakeRandomColorTest()
        {
            Layers_Accessor target = new Layers_Accessor(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.MakeRandomColor();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LoadingTIForIMGasGrid
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void LoadingTIForIMGasGridTest()
        {
            Layers_Accessor target = new Layers_Accessor(); // TODO: Initialize to an appropriate value
            string fn = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.LoadingTIForIMGasGrid(fn);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsValidHandle
        ///</summary>
        [TestMethod()]
        public void IsValidHandleTest()
        {
            Layers target = new Layers(); // TODO: Initialize to an appropriate value
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsValidHandle(LayerHandle);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetSupportedFormats
        ///</summary>
        [TestMethod()]
        public void GetSupportedFormatsTest()
        {
            Layers target = new Layers(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetSupportedFormats();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetImageRep
        ///</summary>
        [TestMethod()]
        public void GetImageRepTest()
        {
            Layers target = new Layers(); // TODO: Initialize to an appropriate value
            string filename = string.Empty; // TODO: Initialize to an appropriate value
            MapWinGIS.Image newImage = null; // TODO: Initialize to an appropriate value
            MapWinGIS.Image newImageExpected = null; // TODO: Initialize to an appropriate value
            Grid newGrid = null; // TODO: Initialize to an appropriate value
            Grid newGridExpected = null; // TODO: Initialize to an appropriate value
            GridColorScheme GrdColorScheme = null; // TODO: Initialize to an appropriate value
            GridColorScheme GrdColorSchemeExpected = null; // TODO: Initialize to an appropriate value
            ICallback cb = null; // TODO: Initialize to an appropriate value
            ICallback cbExpected = null; // TODO: Initialize to an appropriate value
            target.GetImageRep(filename, ref newImage, ref newGrid, ref GrdColorScheme, ref cb);
            Assert.AreEqual(newImageExpected, newImage);
            Assert.AreEqual(newGridExpected, newGrid);
            Assert.AreEqual(GrdColorSchemeExpected, GrdColorScheme);
            Assert.AreEqual(cbExpected, cb);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetHandle
        ///</summary>
        [TestMethod()]
        public void GetHandleTest()
        {
            Layers target = new Layers(); // TODO: Initialize to an appropriate value
            int GlobalPosition = 0; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetHandle(GlobalPosition);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetEnumerator
        ///</summary>
        [TestMethod()]
        public void GetEnumeratorTest()
        {
            IEnumerable target = new Layers(); // TODO: Initialize to an appropriate value
            IEnumerator expected = null; // TODO: Initialize to an appropriate value
            IEnumerator actual;
            actual = target.GetEnumerator();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetDefaultLayerVis
        ///</summary>
        [TestMethod()]
        public void GetDefaultLayerVisTest()
        {
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            actual = Layers.GetDefaultLayerVis();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GenerateGridColorScheme
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void GenerateGridColorSchemeTest()
        {
            Layers_Accessor target = new Layers_Accessor(); // TODO: Initialize to an appropriate value
            Grid newGrid = null; // TODO: Initialize to an appropriate value
            Grid newGridExpected = null; // TODO: Initialize to an appropriate value
            GridColorScheme GrdColorScheme = null; // TODO: Initialize to an appropriate value
            GridColorScheme GrdColorSchemeExpected = null; // TODO: Initialize to an appropriate value
            target.GenerateGridColorScheme(ref newGrid, ref GrdColorScheme);
            Assert.AreEqual(newGridExpected, newGrid);
            Assert.AreEqual(GrdColorSchemeExpected, GrdColorScheme);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Finalize
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void FinalizeTest()
        {
            Layers_Accessor target = new Layers_Accessor(); // TODO: Initialize to an appropriate value
            target.Finalize();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Clear
        ///</summary>
        [TestMethod()]
        public void ClearTest()
        {
            Layers target = new Layers(); // TODO: Initialize to an appropriate value
            target.Clear();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddLayer
        ///</summary>
        [TestMethod()]
        public void AddLayerTest()
        {
            MapWindow.Layers target = new MapWindow.Layers(); // TODO: Initialize to an appropriate value
            object ObjectOrFilename = null; // TODO: Initialize to an appropriate value
            string LayerName = string.Empty; // TODO: Initialize to an appropriate value
            int Group = 0; // TODO: Initialize to an appropriate value
            bool LayerVisible = false; // TODO: Initialize to an appropriate value
            int Color = 0; // TODO: Initialize to an appropriate value
            int OutlineColor = 0; // TODO: Initialize to an appropriate value
            bool DrawFill = false; // TODO: Initialize to an appropriate value
            float LineOrPointSize = 0F; // TODO: Initialize to an appropriate value
            tkPointType PointType = new tkPointType(); // TODO: Initialize to an appropriate value
            GridColorScheme GrdColorScheme = null; // TODO: Initialize to an appropriate value
            bool LegendVisible = false; // TODO: Initialize to an appropriate value
            bool PositionFromSelected = false; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Layer[] expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Layer[] actual;
            actual = target.AddLayer(ObjectOrFilename, LayerName, Group, LayerVisible, Color, OutlineColor, DrawFill, LineOrPointSize, PointType, GrdColorScheme, LegendVisible, PositionFromSelected);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest14()
        {
            MapWindow.Interfaces.Layers target = new Layers(); // TODO: Initialize to an appropriate value
            string Filename = string.Empty; // TODO: Initialize to an appropriate value
            string LayerName = string.Empty; // TODO: Initialize to an appropriate value
            bool Visible = false; // TODO: Initialize to an appropriate value
            bool PlaceAboveCurrentlySelected = false; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Layer expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Layer actual;
            actual = target.Add(Filename, LayerName, Visible, PlaceAboveCurrentlySelected);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest13()
        {
            MapWindow.Interfaces.Layers target = new Layers(); // TODO: Initialize to an appropriate value
            string Filename = string.Empty; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Layer expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Layer actual;
            actual = target.Add(Filename);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest12()
        {
            MapWindow.Interfaces.Layers target = new Layers(); // TODO: Initialize to an appropriate value
            MapWinGIS.Grid GridObject = null; // TODO: Initialize to an appropriate value
            MapWinGIS.Grid GridObjectExpected = null; // TODO: Initialize to an appropriate value
            string LayerName = string.Empty; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Layer expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Layer actual;
            actual = target.Add(ref GridObject, LayerName);
            Assert.AreEqual(GridObjectExpected, GridObject);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest11()
        {
            MapWindow.Layers target = new MapWindow.Layers(); // TODO: Initialize to an appropriate value
            Shapefile ShapefileObject = null; // TODO: Initialize to an appropriate value
            Shapefile ShapefileObjectExpected = null; // TODO: Initialize to an appropriate value
            string LayerName = string.Empty; // TODO: Initialize to an appropriate value
            int Color = 0; // TODO: Initialize to an appropriate value
            int OutlineColor = 0; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Layer expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Layer actual;
            actual = target.Add(ref ShapefileObject, LayerName, Color, OutlineColor);
            Assert.AreEqual(ShapefileObjectExpected, ShapefileObject);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest10()
        {
            MapWindow.Layers target = new MapWindow.Layers(); // TODO: Initialize to an appropriate value
            Shapefile ShapefileObject = null; // TODO: Initialize to an appropriate value
            Shapefile ShapefileObjectExpected = null; // TODO: Initialize to an appropriate value
            string LayerName = string.Empty; // TODO: Initialize to an appropriate value
            int Color = 0; // TODO: Initialize to an appropriate value
            int OutlineColor = 0; // TODO: Initialize to an appropriate value
            int LineOrPointSize = 0; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Layer expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Layer actual;
            actual = target.Add(ref ShapefileObject, LayerName, Color, OutlineColor, LineOrPointSize);
            Assert.AreEqual(ShapefileObjectExpected, ShapefileObject);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest9()
        {
            Layers target = new Layers(); // TODO: Initialize to an appropriate value
            string Filename = string.Empty; // TODO: Initialize to an appropriate value
            string LayerName = string.Empty; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Layer expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Layer actual;
            actual = target.Add(Filename, LayerName);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest8()
        {
            Layers target = new Layers(); // TODO: Initialize to an appropriate value
            Grid GridObject = null; // TODO: Initialize to an appropriate value
            Grid GridObjectExpected = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColorScheme = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Layer expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Layer actual;
            actual = target.Add(ref GridObject, ColorScheme);
            Assert.AreEqual(GridObjectExpected, GridObject);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest7()
        {
            Layers target = new Layers(); // TODO: Initialize to an appropriate value
            Grid GridObject = null; // TODO: Initialize to an appropriate value
            Grid GridObjectExpected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Layer expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Layer actual;
            actual = target.Add(ref GridObject);
            Assert.AreEqual(GridObjectExpected, GridObject);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest6()
        {
            Layers target = new Layers(); // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Layer[] expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Layer[] actual;
            actual = target.Add();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest5()
        {
            Layers target = new Layers(); // TODO: Initialize to an appropriate value
            Grid GridObject = null; // TODO: Initialize to an appropriate value
            Grid GridObjectExpected = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColorScheme = null; // TODO: Initialize to an appropriate value
            string LayerName = string.Empty; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Layer expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Layer actual;
            actual = target.Add(ref GridObject, ColorScheme, LayerName);
            Assert.AreEqual(GridObjectExpected, GridObject);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest4()
        {
            Layers target = new Layers(); // TODO: Initialize to an appropriate value
            Shapefile ShapefileObject = null; // TODO: Initialize to an appropriate value
            Shapefile ShapefileObjectExpected = null; // TODO: Initialize to an appropriate value
            string LayerName = string.Empty; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Layer expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Layer actual;
            actual = target.Add(ref ShapefileObject, LayerName);
            Assert.AreEqual(ShapefileObjectExpected, ShapefileObject);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest3()
        {
            MapWindow.Interfaces.Layers target = new MapWindow.Layers(); // TODO: Initialize to an appropriate value
            MapWinGIS.Image ImageObject = null; // TODO: Initialize to an appropriate value
            MapWinGIS.Image ImageObjectExpected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Layer expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Layer actual;
            actual = target.Add(ref ImageObject);
            Assert.AreEqual(ImageObjectExpected, ImageObject);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest2()
        {
            MapWindow.Interfaces.Layers target = new MapWindow.Layers(); // TODO: Initialize to an appropriate value
            string Filename = string.Empty; // TODO: Initialize to an appropriate value
            string LayerName = string.Empty; // TODO: Initialize to an appropriate value
            bool VisibleInLegend = false; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Layer expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Layer actual;
            actual = target.Add(Filename, LayerName, VisibleInLegend);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest1()
        {
            MapWindow.Interfaces.Layers target = new MapWindow.Layers(); // TODO: Initialize to an appropriate value
            Shapefile ShapefileObject = null; // TODO: Initialize to an appropriate value
            Shapefile ShapefileObjectExpected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Layer expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Layer actual;
            actual = target.Add(ref ShapefileObject);
            Assert.AreEqual(ShapefileObjectExpected, ShapefileObject);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest()
        {
            MapWindow.Layers target = new MapWindow.Layers(); // TODO: Initialize to an appropriate value
            MapWinGIS.Image ImageObject = null; // TODO: Initialize to an appropriate value
            MapWinGIS.Image ImageObjectExpected = null; // TODO: Initialize to an appropriate value
            string LayerName = string.Empty; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Layer expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Layer actual;
            actual = target.Add(ref ImageObject, LayerName);
            Assert.AreEqual(ImageObjectExpected, ImageObject);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Layers Constructor
        ///</summary>
        [TestMethod()]
        public void LayersConstructorTest()
        {
            Layers target = new Layers();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
