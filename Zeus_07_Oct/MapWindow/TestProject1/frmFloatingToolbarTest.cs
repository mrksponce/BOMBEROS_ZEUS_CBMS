using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for frmFloatingToolbarTest and is intended
    ///to contain all frmFloatingToolbarTest Unit Tests
    ///</summary>
    [TestClass()]
    public class frmFloatingToolbarTest
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
        ///A test for tsc
        ///</summary>
        [TestMethod()]
        public void tscTest()
        {
            frmFloatingToolbar target = new frmFloatingToolbar(); // TODO: Initialize to an appropriate value
            ToolStripContainer expected = null; // TODO: Initialize to an appropriate value
            ToolStripContainer actual;
            target.tsc = expected;
            actual = target.tsc;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void InitializeComponentTest()
        {
            frmFloatingToolbar_Accessor target = new frmFloatingToolbar_Accessor(); // TODO: Initialize to an appropriate value
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
            frmFloatingToolbar_Accessor target = new frmFloatingToolbar_Accessor(); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for frmFloatingToolbar Constructor
        ///</summary>
        [TestMethod()]
        public void frmFloatingToolbarConstructorTest()
        {
            frmFloatingToolbar target = new frmFloatingToolbar();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
