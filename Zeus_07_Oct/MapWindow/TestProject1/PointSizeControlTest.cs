using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms.Design;
using MapWinGIS;
using System.Windows.Forms;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for PointSizeControlTest and is intended
    ///to contain all PointSizeControlTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PointSizeControlTest
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
        ///A test for SelectedSize
        ///</summary>
        [TestMethod()]
        public void SelectedSizeTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            tkPointType pointType = new tkPointType(); // TODO: Initialize to an appropriate value
            double InitialValue = 0F; // TODO: Initialize to an appropriate value
            PointSizeControl target = new PointSizeControl(DialogProvider, pointType, InitialValue); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.SelectedSize;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LineWidthControl_Paint
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void LineWidthControl_PaintTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            PointSizeControl_Accessor target = new PointSizeControl_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            PaintEventArgs e = null; // TODO: Initialize to an appropriate value
            target.LineWidthControl_Paint(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LineWidthControl_MouseUp
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void LineWidthControl_MouseUpTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            PointSizeControl_Accessor target = new PointSizeControl_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            MouseEventArgs e = null; // TODO: Initialize to an appropriate value
            target.LineWidthControl_MouseUp(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LineWidthControl_MouseMove
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void LineWidthControl_MouseMoveTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            PointSizeControl_Accessor target = new PointSizeControl_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            MouseEventArgs e = null; // TODO: Initialize to an appropriate value
            target.LineWidthControl_MouseMove(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void InitializeComponentTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            PointSizeControl_Accessor target = new PointSizeControl_Accessor(param0); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DisposeTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            PointSizeControl_Accessor target = new PointSizeControl_Accessor(param0); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PointSizeControl Constructor
        ///</summary>
        [TestMethod()]
        public void PointSizeControlConstructorTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            tkPointType pointType = new tkPointType(); // TODO: Initialize to an appropriate value
            double InitialValue = 0F; // TODO: Initialize to an appropriate value
            PointSizeControl target = new PointSizeControl(DialogProvider, pointType, InitialValue);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
