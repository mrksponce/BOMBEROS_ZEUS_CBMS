using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// // using MapWindow.Interfaces;
using System.Drawing;
using MapWinGIS;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for ShapeTest and is intended
    ///to contain all ShapeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ShapeTest
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
        ///A test for Visible
        ///</summary>
        [TestMethod()]
        public void VisibleTest()
        {
            MapWindow.Interfaces.Shape target = new MapWindow.Shape(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.Visible = expected;
            actual = target.Visible;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ShapePointImageListID
        ///</summary>
        [TestMethod()]
        public void ShapePointImageListIDTest()
        {
            MapWindow.Interfaces.Shape target = new MapWindow.Shape(); // TODO: Initialize to an appropriate value
            long expected = 0; // TODO: Initialize to an appropriate value
            long actual;
            target.ShapePointImageListID = expected;
            actual = target.ShapePointImageListID;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ShapeIndex
        ///</summary>
        [TestMethod()]
        public void ShapeIndexTest()
        {
            MapWindow.Shape target = new MapWindow.Shape(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.ShapeIndex = expected;
            actual = target.ShapeIndex;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ShapeFillTransparency
        ///</summary>
        [TestMethod()]
        public void ShapeFillTransparencyTest()
        {
            MapWindow.Interfaces.Shape target = new MapWindow.Shape(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.ShapeFillTransparency = expected;
            actual = target.ShapeFillTransparency;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PointType
        ///</summary>
        [TestMethod()]
        public void PointTypeTest()
        {
            MapWindow.Interfaces.Shape target = new MapWindow.Shape(); // TODO: Initialize to an appropriate value
            tkPointType expected = new tkPointType(); // TODO: Initialize to an appropriate value
            tkPointType actual;
            target.PointType = expected;
            actual = target.PointType;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OutlineColor
        ///</summary>
        [TestMethod()]
        public void OutlineColorTest()
        {
            MapWindow.Interfaces.Shape target = new MapWindow.Shape(); // TODO: Initialize to an appropriate value
            Color expected = new Color(); // TODO: Initialize to an appropriate value
            Color actual;
            target.OutlineColor = expected;
            actual = target.OutlineColor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LineStipple
        ///</summary>
        [TestMethod()]
        public void LineStippleTest()
        {
            MapWindow.Interfaces.Shape target = new MapWindow.Shape(); // TODO: Initialize to an appropriate value
            tkLineStipple expected = new tkLineStipple(); // TODO: Initialize to an appropriate value
            tkLineStipple actual;
            target.LineStipple = expected;
            actual = target.LineStipple;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LineOrPointSize
        ///</summary>
        [TestMethod()]
        public void LineOrPointSizeTest()
        {
            MapWindow.Interfaces.Shape target = new MapWindow.Shape(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.LineOrPointSize = expected;
            actual = target.LineOrPointSize;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LayerHandle
        ///</summary>
        [TestMethod()]
        public void LayerHandleTest()
        {
            MapWindow.Shape target = new MapWindow.Shape(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.LayerHandle = expected;
            actual = target.LayerHandle;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FillStipple
        ///</summary>
        [TestMethod()]
        public void FillStippleTest()
        {
            MapWindow.Interfaces.Shape target = new MapWindow.Shape(); // TODO: Initialize to an appropriate value
            tkFillStipple expected = new tkFillStipple(); // TODO: Initialize to an appropriate value
            tkFillStipple actual;
            target.FillStipple = expected;
            actual = target.FillStipple;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DrawFill
        ///</summary>
        [TestMethod()]
        public void DrawFillTest()
        {
            MapWindow.Interfaces.Shape target = new MapWindow.Shape(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.DrawFill = expected;
            actual = target.DrawFill;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Color
        ///</summary>
        [TestMethod()]
        public void ColorTest()
        {
            MapWindow.Interfaces.Shape target = new MapWindow.Shape(); // TODO: Initialize to an appropriate value
            Color expected = new Color(); // TODO: Initialize to an appropriate value
            Color actual;
            target.Color = expected;
            actual = target.Color;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ZoomTo
        ///</summary>
        [TestMethod()]
        public void ZoomToTest()
        {
            MapWindow.Interfaces.Shape target = new MapWindow.Shape(); // TODO: Initialize to an appropriate value
            target.ZoomTo();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ShowVertices
        ///</summary>
        [TestMethod()]
        public void ShowVerticesTest()
        {
            MapWindow.Interfaces.Shape target = new MapWindow.Shape(); // TODO: Initialize to an appropriate value
            Color color = new Color(); // TODO: Initialize to an appropriate value
            int vertexSize = 0; // TODO: Initialize to an appropriate value
            target.ShowVertices(color, vertexSize);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for HideVertices
        ///</summary>
        [TestMethod()]
        public void HideVerticesTest()
        {
            MapWindow.Interfaces.Shape target = new MapWindow.Shape(); // TODO: Initialize to an appropriate value
            target.HideVertices();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Shape Constructor
        ///</summary>
        [TestMethod()]
        public void ShapeConstructorTest1()
        {
            MapWindow.Interfaces.Shape target = new MapWindow.Shape();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Shape Constructor
        ///</summary>
        [TestMethod()]
        public void ShapeConstructorTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            int ShapeIndex = 0; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Shape target = new MapWindow.Shape(LayerHandle, ShapeIndex);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
