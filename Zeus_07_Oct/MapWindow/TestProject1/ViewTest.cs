using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// using MapWindow.Interfaces;
using System.Drawing;
using MapWinGIS;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for ViewTest and is intended
    ///to contain all ViewTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ViewTest
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
        ///A test for ZoomPercent
        ///</summary>
        [TestMethod()]
        public void ZoomPercentTest()
        {
            View target = new View(); // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            target.ZoomPercent = expected;
            actual = target.ZoomPercent;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UserCursorHandle
        ///</summary>
        [TestMethod()]
        public void UserCursorHandleTest()
        {
            View target = new View(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.UserCursorHandle = expected;
            actual = target.UserCursorHandle;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Tag
        ///</summary>
        [TestMethod()]
        public void TagTest()
        {
            View target = new View(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Tag = expected;
            actual = target.Tag;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SelectMethod
        ///</summary>
        [TestMethod()]
        public void SelectMethodTest()
        {
            View target = new View(); // TODO: Initialize to an appropriate value
            SelectMode expected = new SelectMode(); // TODO: Initialize to an appropriate value
            SelectMode actual;
            target.SelectMethod = expected;
            actual = target.SelectMethod;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SelectionTolerance
        ///</summary>
        [TestMethod()]
        public void SelectionToleranceTest()
        {
            View target = new View(); // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            target.SelectionTolerance = expected;
            actual = target.SelectionTolerance;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SelectionPersistence
        ///</summary>
        [TestMethod()]
        public void SelectionPersistenceTest()
        {
            View target = new View(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.SelectionPersistence = expected;
            actual = target.SelectionPersistence;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SelectedShapes
        ///</summary>
        [TestMethod()]
        public void SelectedShapesTest()
        {
            MapWindow.Interfaces.View target = new View(); // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.SelectInfo actual;
            actual = target.SelectedShapes;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SelectColor
        ///</summary>
        [TestMethod()]
        public void SelectColorTest()
        {
            View target = new View(); // TODO: Initialize to an appropriate value
            Color expected = new Color(); // TODO: Initialize to an appropriate value
            Color actual;
            target.SelectColor = expected;
            actual = target.SelectColor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PreviewVisible
        ///</summary>
        [TestMethod()]
        public void PreviewVisibleTest()
        {
            View target = new View(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.PreviewVisible = expected;
            actual = target.PreviewVisible;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MapState
        ///</summary>
        [TestMethod()]
        public void MapStateTest()
        {
            View target = new View(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.MapState = expected;
            actual = target.MapState;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MapCursor
        ///</summary>
        [TestMethod()]
        public void MapCursorTest()
        {
            View target = new View(); // TODO: Initialize to an appropriate value
            tkCursor expected = new tkCursor(); // TODO: Initialize to an appropriate value
            tkCursor actual;
            target.MapCursor = expected;
            actual = target.MapCursor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LegendVisible
        ///</summary>
        [TestMethod()]
        public void LegendVisibleTest()
        {
            View target = new View(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.LegendVisible = expected;
            actual = target.LegendVisible;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LabelsUseProjectLevel
        ///</summary>
        [TestMethod()]
        public void LabelsUseProjectLevelTest()
        {
            View target = new View(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.LabelsUseProjectLevel = expected;
            actual = target.LabelsUseProjectLevel;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HandleFileDrop
        ///</summary>
        [TestMethod()]
        public void HandleFileDropTest()
        {
            View target = new View(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.HandleFileDrop = expected;
            actual = target.HandleFileDrop;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Extents
        ///</summary>
        [TestMethod()]
        public void ExtentsTest()
        {
            View target = new View(); // TODO: Initialize to an appropriate value
            Extents expected = null; // TODO: Initialize to an appropriate value
            Extents actual;
            target.Extents = expected;
            actual = target.Extents;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ExtentPad
        ///</summary>
        [TestMethod()]
        public void ExtentPadTest()
        {
            View target = new View(); // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            target.ExtentPad = expected;
            actual = target.ExtentPad;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Draw
        ///</summary>
        [TestMethod()]
        public void DrawTest()
        {
            MapWindow.Interfaces.View target = new View(); // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Draw actual;
            actual = target.Draw;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CursorMode
        ///</summary>
        [TestMethod()]
        public void CursorModeTest()
        {
            View target = new View(); // TODO: Initialize to an appropriate value
            tkCursorMode expected = new tkCursorMode(); // TODO: Initialize to an appropriate value
            tkCursorMode actual;
            target.CursorMode = expected;
            actual = target.CursorMode;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BackColor
        ///</summary>
        [TestMethod()]
        public void BackColorTest()
        {
            View target = new View(); // TODO: Initialize to an appropriate value
            Color expected = new Color(); // TODO: Initialize to an appropriate value
            Color actual;
            target.BackColor = expected;
            actual = target.BackColor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ZoomToPrev
        ///</summary>
        [TestMethod()]
        public void ZoomToPrevTest()
        {
            View target = new View(); // TODO: Initialize to an appropriate value
            target.ZoomToPrev();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ZoomToMaxExtents
        ///</summary>
        [TestMethod()]
        public void ZoomToMaxExtentsTest()
        {
            View target = new View(); // TODO: Initialize to an appropriate value
            target.ZoomToMaxExtents();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ZoomOut
        ///</summary>
        [TestMethod()]
        public void ZoomOutTest()
        {
            View target = new View(); // TODO: Initialize to an appropriate value
            double Percent = 0F; // TODO: Initialize to an appropriate value
            target.ZoomOut(Percent);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ZoomIn
        ///</summary>
        [TestMethod()]
        public void ZoomInTest()
        {
            View target = new View(); // TODO: Initialize to an appropriate value
            double Percent = 0F; // TODO: Initialize to an appropriate value
            target.ZoomIn(Percent);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UnlockMap
        ///</summary>
        [TestMethod()]
        public void UnlockMapTest()
        {
            View target = new View(); // TODO: Initialize to an appropriate value
            target.UnlockMap();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UnlockLegend
        ///</summary>
        [TestMethod()]
        public void UnlockLegendTest()
        {
            View target = new View(); // TODO: Initialize to an appropriate value
            target.UnlockLegend();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Snapshot
        ///</summary>
        [TestMethod()]
        public void SnapshotTest()
        {
            MapWindow.Interfaces.View target = new View(); // TODO: Initialize to an appropriate value
            MapWinGIS.Extents Bounds = null; // TODO: Initialize to an appropriate value
            MapWinGIS.Image expected = null; // TODO: Initialize to an appropriate value
            MapWinGIS.Image actual;
            actual = target.Snapshot(Bounds);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ShowToolTip
        ///</summary>
        [TestMethod()]
        public void ShowToolTipTest()
        {
            View target = new View(); // TODO: Initialize to an appropriate value
            string Text = string.Empty; // TODO: Initialize to an appropriate value
            int Milliseconds = 0; // TODO: Initialize to an appropriate value
            target.ShowToolTip(Text, Milliseconds);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SelectShapesByRectangle
        ///</summary>
        [TestMethod()]
        public void SelectShapesByRectangleTest()
        {
            View target = new View(); // TODO: Initialize to an appropriate value
            int ScreenLeft = 0; // TODO: Initialize to an appropriate value
            int ScreenRight = 0; // TODO: Initialize to an appropriate value
            int ScreenTop = 0; // TODO: Initialize to an appropriate value
            int ScreenBottom = 0; // TODO: Initialize to an appropriate value
            bool ctrlDown = false; // TODO: Initialize to an appropriate value
            SelectInfo expected = null; // TODO: Initialize to an appropriate value
            SelectInfo actual;
            actual = target.SelectShapesByRectangle(ScreenLeft, ScreenRight, ScreenTop, ScreenBottom, ctrlDown);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SelectShapesByPoint
        ///</summary>
        [TestMethod()]
        public void SelectShapesByPointTest()
        {
            View target = new View(); // TODO: Initialize to an appropriate value
            int ScreenX = 0; // TODO: Initialize to an appropriate value
            int ScreenY = 0; // TODO: Initialize to an appropriate value
            bool ctrlDown = false; // TODO: Initialize to an appropriate value
            SelectInfo expected = null; // TODO: Initialize to an appropriate value
            SelectInfo actual;
            actual = target.SelectShapesByPoint(ScreenX, ScreenY, ctrlDown);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Select
        ///</summary>
        [TestMethod()]
        public void SelectTest1()
        {
            MapWindow.Interfaces.View target = new View(); // TODO: Initialize to an appropriate value
            Rectangle ScreenBounds = new Rectangle(); // TODO: Initialize to an appropriate value
            bool ClearOldSelection = false; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.SelectInfo expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.SelectInfo actual;
            actual = target.Select(ScreenBounds, ClearOldSelection);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Select
        ///</summary>
        [TestMethod()]
        public void SelectTest()
        {
            MapWindow.Interfaces.View target = new View(); // TODO: Initialize to an appropriate value
            int ScreenX = 0; // TODO: Initialize to an appropriate value
            int ScreenY = 0; // TODO: Initialize to an appropriate value
            bool ClearOldSelection = false; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.SelectInfo expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.SelectInfo actual;
            actual = target.Select(ScreenX, ScreenY, ClearOldSelection);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Redraw
        ///</summary>
        [TestMethod()]
        public void RedrawTest()
        {
            View target = new View(); // TODO: Initialize to an appropriate value
            target.Redraw();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ProjToPixel
        ///</summary>
        [TestMethod()]
        public void ProjToPixelTest()
        {
            View target = new View(); // TODO: Initialize to an appropriate value
            double ProjX = 0F; // TODO: Initialize to an appropriate value
            double ProjY = 0F; // TODO: Initialize to an appropriate value
            double PixelX = 0F; // TODO: Initialize to an appropriate value
            double PixelXExpected = 0F; // TODO: Initialize to an appropriate value
            double PixelY = 0F; // TODO: Initialize to an appropriate value
            double PixelYExpected = 0F; // TODO: Initialize to an appropriate value
            target.ProjToPixel(ProjX, ProjY, ref PixelX, ref PixelY);
            Assert.AreEqual(PixelXExpected, PixelX);
            Assert.AreEqual(PixelYExpected, PixelY);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PixelToProj
        ///</summary>
        [TestMethod()]
        public void PixelToProjTest()
        {
            View target = new View(); // TODO: Initialize to an appropriate value
            double PixelX = 0F; // TODO: Initialize to an appropriate value
            double PixelY = 0F; // TODO: Initialize to an appropriate value
            double ProjX = 0F; // TODO: Initialize to an appropriate value
            double ProjXExpected = 0F; // TODO: Initialize to an appropriate value
            double ProjY = 0F; // TODO: Initialize to an appropriate value
            double ProjYExpected = 0F; // TODO: Initialize to an appropriate value
            target.PixelToProj(PixelX, PixelY, ref ProjX, ref ProjY);
            Assert.AreEqual(ProjXExpected, ProjX);
            Assert.AreEqual(ProjYExpected, ProjY);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LockMap
        ///</summary>
        [TestMethod()]
        public void LockMapTest()
        {
            View target = new View(); // TODO: Initialize to an appropriate value
            target.LockMap();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LockLegend
        ///</summary>
        [TestMethod()]
        public void LockLegendTest()
        {
            View target = new View(); // TODO: Initialize to an appropriate value
            target.LockLegend();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LabelsRelabel
        ///</summary>
        [TestMethod()]
        public void LabelsRelabelTest()
        {
            View target = new View(); // TODO: Initialize to an appropriate value
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            target.LabelsRelabel(LayerHandle);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LabelsEdit
        ///</summary>
        [TestMethod()]
        public void LabelsEditTest()
        {
            View target = new View(); // TODO: Initialize to an appropriate value
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            target.LabelsEdit(LayerHandle);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for IsSelected
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void IsSelectedTest()
        {
            View_Accessor target = new View_Accessor(); // TODO: Initialize to an appropriate value
            int MapLayerIndex = 0; // TODO: Initialize to an appropriate value
            int ShapeIndex = 0; // TODO: Initialize to an appropriate value
            int outListIndex = 0; // TODO: Initialize to an appropriate value
            int outListIndexExpected = 0; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsSelected(MapLayerIndex, ShapeIndex, ref outListIndex);
            Assert.AreEqual(outListIndexExpected, outListIndex);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Identify
        ///</summary>
        [TestMethod()]
        public void IdentifyTest()
        {
            MapWindow.Interfaces.View target = new View(); // TODO: Initialize to an appropriate value
            double ProjX = 0F; // TODO: Initialize to an appropriate value
            double ProjY = 0F; // TODO: Initialize to an appropriate value
            double Tolerance = 0F; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.IdentifiedLayers expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.IdentifiedLayers actual;
            actual = target.Identify(ProjX, ProjY, Tolerance);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ClearSelectedShapes
        ///</summary>
        [TestMethod()]
        public void ClearSelectedShapesTest()
        {
            View target = new View(); // TODO: Initialize to an appropriate value
            target.ClearSelectedShapes();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddToSelectList
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void AddToSelectListTest()
        {
            View_Accessor target = new View_Accessor(); // TODO: Initialize to an appropriate value
            int MapLayerHandle = 0; // TODO: Initialize to an appropriate value
            int[] lSelectedShapes = null; // TODO: Initialize to an appropriate value
            target.AddToSelectList(MapLayerHandle, lSelectedShapes);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for View Constructor
        ///</summary>
        [TestMethod()]
        public void ViewConstructorTest()
        {
            View target = new View();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
