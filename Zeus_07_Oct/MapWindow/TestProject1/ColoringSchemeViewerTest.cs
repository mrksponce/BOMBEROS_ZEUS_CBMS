using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using MapWinGIS;
using System.Drawing;
using System.ComponentModel;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for ColoringSchemeViewerTest and is intended
    ///to contain all ColoringSchemeViewerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ColoringSchemeViewerTest
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
        ///A test for txtBox
        ///</summary>
        [TestMethod()]
        public void txtBoxTest()
        {
            ColoringSchemeViewer target = new ColoringSchemeViewer(); // TODO: Initialize to an appropriate value
            TextBox expected = null; // TODO: Initialize to an appropriate value
            TextBox actual;
            target.txtBox = expected;
            actual = target.txtBox;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SelectedBreaks
        ///</summary>
        [TestMethod()]
        public void SelectedBreaksTest()
        {
            ColoringSchemeViewer target = new ColoringSchemeViewer(); // TODO: Initialize to an appropriate value
            bool[] actual;
            actual = target.SelectedBreaks;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for sBar
        ///</summary>
        [TestMethod()]
        public void sBarTest()
        {
            ColoringSchemeViewer target = new ColoringSchemeViewer(); // TODO: Initialize to an appropriate value
            VScrollBar expected = null; // TODO: Initialize to an appropriate value
            VScrollBar actual;
            target.sBar = expected;
            actual = target.sBar;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UpdateScrollBar
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void UpdateScrollBarTest()
        {
            ColoringSchemeViewer_Accessor target = new ColoringSchemeViewer_Accessor(); // TODO: Initialize to an appropriate value
            target.UpdateScrollBar();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UpdateBreakValues
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void UpdateBreakValuesTest()
        {
            ColoringSchemeViewer_Accessor target = new ColoringSchemeViewer_Accessor(); // TODO: Initialize to an appropriate value
            target.UpdateBreakValues();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for txtBox_Validating
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void txtBox_ValidatingTest()
        {
            ColoringSchemeViewer_Accessor target = new ColoringSchemeViewer_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            CancelEventArgs e = null; // TODO: Initialize to an appropriate value
            target.txtBox_Validating(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for txtBox_TextChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void txtBox_TextChangedTest()
        {
            ColoringSchemeViewer_Accessor target = new ColoringSchemeViewer_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.txtBox_TextChanged(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetSelectedBreak
        ///</summary>
        [TestMethod()]
        public void SetSelectedBreakTest()
        {
            ColoringSchemeViewer target = new ColoringSchemeViewer(); // TODO: Initialize to an appropriate value
            int brk = 0; // TODO: Initialize to an appropriate value
            bool selected = false; // TODO: Initialize to an appropriate value
            target.SetSelectedBreak(brk, selected);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for sBar_Scroll
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void sBar_ScrollTest()
        {
            ColoringSchemeViewer_Accessor target = new ColoringSchemeViewer_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            ScrollEventArgs e = null; // TODO: Initialize to an appropriate value
            target.sBar_Scroll(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnPaintBackground
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void OnPaintBackgroundTest()
        {
            ColoringSchemeViewer_Accessor target = new ColoringSchemeViewer_Accessor(); // TODO: Initialize to an appropriate value
            PaintEventArgs pevent = null; // TODO: Initialize to an appropriate value
            target.OnPaintBackground(pevent);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnPaint
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void OnPaintTest()
        {
            ColoringSchemeViewer_Accessor target = new ColoringSchemeViewer_Accessor(); // TODO: Initialize to an appropriate value
            PaintEventArgs e = null; // TODO: Initialize to an appropriate value
            target.OnPaint(e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitializeControl
        ///</summary>
        [TestMethod()]
        public void InitializeControlTest1()
        {
            ColoringSchemeViewer target = new ColoringSchemeViewer(); // TODO: Initialize to an appropriate value
            ShapefileColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            target.InitializeControl(ColoringScheme);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitializeControl
        ///</summary>
        [TestMethod()]
        public void InitializeControlTest()
        {
            ColoringSchemeViewer target = new ColoringSchemeViewer(); // TODO: Initialize to an appropriate value
            GridColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            target.InitializeControl(ColoringScheme);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void InitializeComponentTest()
        {
            ColoringSchemeViewer_Accessor target = new ColoringSchemeViewer_Accessor(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetBreakIndexAtPosition
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void GetBreakIndexAtPositionTest()
        {
            ColoringSchemeViewer_Accessor target = new ColoringSchemeViewer_Accessor(); // TODO: Initialize to an appropriate value
            int yPos = 0; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetBreakIndexAtPosition(yPos);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DrawHeader
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DrawHeaderTest()
        {
            ColoringSchemeViewer_Accessor target = new ColoringSchemeViewer_Accessor(); // TODO: Initialize to an appropriate value
            Graphics g = null; // TODO: Initialize to an appropriate value
            target.DrawHeader(g);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DrawBreak
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DrawBreakTest1()
        {
            ColoringSchemeViewer_Accessor target = new ColoringSchemeViewer_Accessor(); // TODO: Initialize to an appropriate value
            GridColorBreak brk = null; // TODO: Initialize to an appropriate value
            Rectangle rect = new Rectangle(); // TODO: Initialize to an appropriate value
            Graphics g = null; // TODO: Initialize to an appropriate value
            bool FillRect = false; // TODO: Initialize to an appropriate value
            target.DrawBreak(brk, rect, g, FillRect);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DrawBreak
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DrawBreakTest()
        {
            ColoringSchemeViewer_Accessor target = new ColoringSchemeViewer_Accessor(); // TODO: Initialize to an appropriate value
            ShapefileColorBreak brk = null; // TODO: Initialize to an appropriate value
            Rectangle rect = new Rectangle(); // TODO: Initialize to an appropriate value
            Graphics g = null; // TODO: Initialize to an appropriate value
            bool FillRect = false; // TODO: Initialize to an appropriate value
            target.DrawBreak(brk, rect, g, FillRect);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DisposeTest()
        {
            ColoringSchemeViewer_Accessor target = new ColoringSchemeViewer_Accessor(); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ColoringSchemeViewer_Resize
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ColoringSchemeViewer_ResizeTest()
        {
            ColoringSchemeViewer_Accessor target = new ColoringSchemeViewer_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.ColoringSchemeViewer_Resize(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ColoringSchemeViewer_MouseDown
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ColoringSchemeViewer_MouseDownTest()
        {
            ColoringSchemeViewer_Accessor target = new ColoringSchemeViewer_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            MouseEventArgs e = null; // TODO: Initialize to an appropriate value
            target.ColoringSchemeViewer_MouseDown(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ColoringSchemeViewer_Load
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ColoringSchemeViewer_LoadTest()
        {
            ColoringSchemeViewer_Accessor target = new ColoringSchemeViewer_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.ColoringSchemeViewer_Load(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ColoringSchemeViewer_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ColoringSchemeViewer_ClickTest()
        {
            ColoringSchemeViewer_Accessor target = new ColoringSchemeViewer_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.ColoringSchemeViewer_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ClearSelectedBreaks
        ///</summary>
        [TestMethod()]
        public void ClearSelectedBreaksTest()
        {
            ColoringSchemeViewer target = new ColoringSchemeViewer(); // TODO: Initialize to an appropriate value
            target.ClearSelectedBreaks();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ColoringSchemeViewer Constructor
        ///</summary>
        [TestMethod()]
        public void ColoringSchemeViewerConstructorTest()
        {
            ColoringSchemeViewer target = new ColoringSchemeViewer();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
