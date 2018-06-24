using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms.Design;
using System.Windows.Forms;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for FillStyleControlTest and is intended
    ///to contain all FillStyleControlTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FillStyleControlTest
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
        ///A test for SelectedValue
        ///</summary>
        [TestMethod()]
        public void SelectedValueTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            FillStyleControl target = new FillStyleControl(DialogProvider); // TODO: Initialize to an appropriate value
            FillSyles actual;
            actual = target.SelectedValue;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void InitializeComponentTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            FillStyleControl_Accessor target = new FillStyleControl_Accessor(param0); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for FillStyleControl_Paint
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void FillStyleControl_PaintTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            FillStyleControl_Accessor target = new FillStyleControl_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            PaintEventArgs e = null; // TODO: Initialize to an appropriate value
            target.FillStyleControl_Paint(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for FillStyleControl_MouseUp
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void FillStyleControl_MouseUpTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            FillStyleControl_Accessor target = new FillStyleControl_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            MouseEventArgs e = null; // TODO: Initialize to an appropriate value
            target.FillStyleControl_MouseUp(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for FillStyleControl_MouseMove
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void FillStyleControl_MouseMoveTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            FillStyleControl_Accessor target = new FillStyleControl_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            MouseEventArgs e = null; // TODO: Initialize to an appropriate value
            target.FillStyleControl_MouseMove(sender, e);
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
            FillStyleControl_Accessor target = new FillStyleControl_Accessor(param0); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for FillStyleControl Constructor
        ///</summary>
        [TestMethod()]
        public void FillStyleControlConstructorTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            FillStyleControl target = new FillStyleControl(DialogProvider);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
