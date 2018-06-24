using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using System;
using System.Drawing;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for RangeBarTest and is intended
    ///to contain all RangeBarTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RangeBarTest
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
        ///A test for HistogramMaxPerBin
        ///</summary>
        [TestMethod()]
        public void HistogramMaxPerBinTest()
        {
            RangeBar target = new RangeBar(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.HistogramMaxPerBin;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Histogram
        ///</summary>
        [TestMethod()]
        public void HistogramTest()
        {
            RangeBar target = new RangeBar(); // TODO: Initialize to an appropriate value
            int[] expected = null; // TODO: Initialize to an appropriate value
            int[] actual;
            target.Histogram = expected;
            actual = target.Histogram;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HandleValue
        ///</summary>
        [TestMethod()]
        public void HandleValueTest()
        {
            RangeBar target = new RangeBar(); // TODO: Initialize to an appropriate value
            int aIndex = 0; // TODO: Initialize to an appropriate value
            double actual;
            actual = target.get_HandleValue(aIndex);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HandleColor
        ///</summary>
        [TestMethod()]
        public void HandleColorTest()
        {
            RangeBar target = new RangeBar(); // TODO: Initialize to an appropriate value
            int aIndex = 0; // TODO: Initialize to an appropriate value
            Color actual;
            actual = target.get_HandleColor(aIndex);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SetHandles
        ///</summary>
        [TestMethod()]
        public void SetHandlesTest()
        {
            RangeBar target = new RangeBar(); // TODO: Initialize to an appropriate value
            double[] aValues = null; // TODO: Initialize to an appropriate value
            Color[] aColors = null; // TODO: Initialize to an appropriate value
            target.SetHandles(aValues, aColors);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for RenderHistogram
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void RenderHistogramTest()
        {
            RangeBar_Accessor target = new RangeBar_Accessor(); // TODO: Initialize to an appropriate value
            Graphics g = null; // TODO: Initialize to an appropriate value
            target.RenderHistogram(g);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Render
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void RenderTest()
        {
            RangeBar_Accessor target = new RangeBar_Accessor(); // TODO: Initialize to an appropriate value
            Graphics g = null; // TODO: Initialize to an appropriate value
            target.Render(g);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for RangeBar_Resize
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void RangeBar_ResizeTest()
        {
            RangeBar_Accessor target = new RangeBar_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.RangeBar_Resize(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for RangeBar_Paint
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void RangeBar_PaintTest()
        {
            RangeBar_Accessor target = new RangeBar_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            PaintEventArgs e = null; // TODO: Initialize to an appropriate value
            target.RangeBar_Paint(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnMouseUp
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void OnMouseUpTest()
        {
            RangeBar_Accessor target = new RangeBar_Accessor(); // TODO: Initialize to an appropriate value
            MouseEventArgs e = null; // TODO: Initialize to an appropriate value
            target.OnMouseUp(e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnMouseMove
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void OnMouseMoveTest()
        {
            RangeBar_Accessor target = new RangeBar_Accessor(); // TODO: Initialize to an appropriate value
            MouseEventArgs e = null; // TODO: Initialize to an appropriate value
            target.OnMouseMove(e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnMouseDown
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void OnMouseDownTest()
        {
            RangeBar_Accessor target = new RangeBar_Accessor(); // TODO: Initialize to an appropriate value
            MouseEventArgs e = null; // TODO: Initialize to an appropriate value
            target.OnMouseDown(e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void InitializeComponentTest()
        {
            RangeBar_Accessor target = new RangeBar_Accessor(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for HistogramFromValues
        ///</summary>
        [TestMethod()]
        public void HistogramFromValuesTest()
        {
            RangeBar target = new RangeBar(); // TODO: Initialize to an appropriate value
            double[] aValues = null; // TODO: Initialize to an appropriate value
            double aMinValue = 0F; // TODO: Initialize to an appropriate value
            double aMaxValue = 0F; // TODO: Initialize to an appropriate value
            target.HistogramFromValues(aValues, aMinValue, aMaxValue);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for HandleToDrag
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void HandleToDragTest()
        {
            RangeBar_Accessor target = new RangeBar_Accessor(); // TODO: Initialize to an appropriate value
            int X = 0; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.HandleToDrag(X);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HandleBelow
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void HandleBelowTest()
        {
            RangeBar_Accessor target = new RangeBar_Accessor(); // TODO: Initialize to an appropriate value
            int X = 0; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.HandleBelow(X);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FindHistogramMaxPerBin
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void FindHistogramMaxPerBinTest()
        {
            RangeBar_Accessor target = new RangeBar_Accessor(); // TODO: Initialize to an appropriate value
            target.FindHistogramMaxPerBin();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DisposeTest()
        {
            RangeBar_Accessor target = new RangeBar_Accessor(); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for RangeBar Constructor
        ///</summary>
        [TestMethod()]
        public void RangeBarConstructorTest()
        {
            RangeBar target = new RangeBar();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
