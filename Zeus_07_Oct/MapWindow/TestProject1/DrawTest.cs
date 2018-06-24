using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// using MapWindow.Interfaces;
using System.Drawing;
using MapWinGIS;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for DrawTest and is intended
    ///to contain all DrawTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DrawTest
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
        ///A test for DoubleBuffer
        ///</summary>
        [TestMethod()]
        public void DoubleBufferTest()
        {
            Draw target = new Draw(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.DoubleBuffer = expected;
            actual = target.DoubleBuffer;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for NewDrawing
        ///</summary>
        [TestMethod()]
        public void NewDrawingTest()
        {
            Draw target = new Draw(); // TODO: Initialize to an appropriate value
            tkDrawReferenceList Projection = new tkDrawReferenceList(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.NewDrawing(Projection);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DrawPolygon
        ///</summary>
        [TestMethod()]
        public void DrawPolygonTest()
        {
            Draw target = new Draw(); // TODO: Initialize to an appropriate value
            double[] x = null; // TODO: Initialize to an appropriate value
            double[] y = null; // TODO: Initialize to an appropriate value
            Color Color = new Color(); // TODO: Initialize to an appropriate value
            bool FillPolygon = false; // TODO: Initialize to an appropriate value
            target.DrawPolygon(x, y, Color, FillPolygon);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DrawPoint
        ///</summary>
        [TestMethod()]
        public void DrawPointTest()
        {
            Draw target = new Draw(); // TODO: Initialize to an appropriate value
            double x = 0F; // TODO: Initialize to an appropriate value
            double y = 0F; // TODO: Initialize to an appropriate value
            int PixelSize = 0; // TODO: Initialize to an appropriate value
            Color Color = new Color(); // TODO: Initialize to an appropriate value
            target.DrawPoint(x, y, PixelSize, Color);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DrawLine
        ///</summary>
        [TestMethod()]
        public void DrawLineTest()
        {
            Draw target = new Draw(); // TODO: Initialize to an appropriate value
            double X1 = 0F; // TODO: Initialize to an appropriate value
            double Y1 = 0F; // TODO: Initialize to an appropriate value
            double X2 = 0F; // TODO: Initialize to an appropriate value
            double Y2 = 0F; // TODO: Initialize to an appropriate value
            int PixelWidth = 0; // TODO: Initialize to an appropriate value
            Color Color = new Color(); // TODO: Initialize to an appropriate value
            target.DrawLine(X1, Y1, X2, Y2, PixelWidth, Color);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DrawCircle
        ///</summary>
        [TestMethod()]
        public void DrawCircleTest()
        {
            Draw target = new Draw(); // TODO: Initialize to an appropriate value
            double x = 0F; // TODO: Initialize to an appropriate value
            double y = 0F; // TODO: Initialize to an appropriate value
            double PixelRadius = 0F; // TODO: Initialize to an appropriate value
            Color Color = new Color(); // TODO: Initialize to an appropriate value
            bool FillCircle = false; // TODO: Initialize to an appropriate value
            target.DrawCircle(x, y, PixelRadius, Color, FillCircle);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ClearDrawings
        ///</summary>
        [TestMethod()]
        public void ClearDrawingsTest()
        {
            Draw target = new Draw(); // TODO: Initialize to an appropriate value
            target.ClearDrawings();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ClearDrawing
        ///</summary>
        [TestMethod()]
        public void ClearDrawingTest()
        {
            Draw target = new Draw(); // TODO: Initialize to an appropriate value
            int DrawHandle = 0; // TODO: Initialize to an appropriate value
            target.ClearDrawing(DrawHandle);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Draw Constructor
        ///</summary>
        [TestMethod()]
        public void DrawConstructorTest()
        {
            Draw target = new Draw();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
