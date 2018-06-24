using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for frmPaletteEditorTest and is intended
    ///to contain all frmPaletteEditorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class frmPaletteEditorTest
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
        ///A test for ListBox1
        ///</summary>
        [TestMethod()]
        public void ListBox1Test()
        {
            frmPaletteEditor target = new frmPaletteEditor(); // TODO: Initialize to an appropriate value
            ListBox expected = null; // TODO: Initialize to an appropriate value
            ListBox actual;
            target.ListBox1 = expected;
            actual = target.ListBox1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ListBox1_DrawItem
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ListBox1_DrawItemTest()
        {
            frmPaletteEditor_Accessor target = new frmPaletteEditor_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            DrawItemEventArgs e = null; // TODO: Initialize to an appropriate value
            target.ListBox1_DrawItem(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void InitializeComponentTest()
        {
            frmPaletteEditor_Accessor target = new frmPaletteEditor_Accessor(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for frmPaletteEditor_Load
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void frmPaletteEditor_LoadTest()
        {
            frmPaletteEditor_Accessor target = new frmPaletteEditor_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.frmPaletteEditor_Load(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DisposeTest()
        {
            frmPaletteEditor_Accessor target = new frmPaletteEditor_Accessor(); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for frmPaletteEditor Constructor
        ///</summary>
        [TestMethod()]
        public void frmPaletteEditorConstructorTest()
        {
            frmPaletteEditor target = new frmPaletteEditor();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
