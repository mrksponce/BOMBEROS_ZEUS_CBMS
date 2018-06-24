using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for PointImageSelectTest and is intended
    ///to contain all PointImageSelectTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PointImageSelectTest
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
        ///A test for Label1
        ///</summary>
        [TestMethod()]
        public void Label1Test()
        {
            PointImageSelect target = new PointImageSelect(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.Label1 = expected;
            actual = target.Label1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for flp1
        ///</summary>
        [TestMethod()]
        public void flp1Test()
        {
            PointImageSelect target = new PointImageSelect(); // TODO: Initialize to an appropriate value
            FlowLayoutPanel expected = null; // TODO: Initialize to an appropriate value
            FlowLayoutPanel actual;
            target.flp1 = expected;
            actual = target.flp1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for cmdCancel
        ///</summary>
        [TestMethod()]
        public void cmdCancelTest()
        {
            PointImageSelect target = new PointImageSelect(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.cmdCancel = expected;
            actual = target.cmdCancel;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for cmdBrowse
        ///</summary>
        [TestMethod()]
        public void cmdBrowseTest()
        {
            PointImageSelect target = new PointImageSelect(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.cmdBrowse = expected;
            actual = target.cmdBrowse;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for chbHidePoint
        ///</summary>
        [TestMethod()]
        public void chbHidePointTest()
        {
            PointImageSelect target = new PointImageSelect(); // TODO: Initialize to an appropriate value
            CheckBox expected = null; // TODO: Initialize to an appropriate value
            CheckBox actual;
            target.chbHidePoint = expected;
            actual = target.chbHidePoint;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PopulateImageCombo
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void PopulateImageComboTest()
        {
            PointImageSelect_Accessor target = new PointImageSelect_Accessor(); // TODO: Initialize to an appropriate value
            target.PopulateImageCombo();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PointImageSelect_Load
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void PointImageSelect_LoadTest()
        {
            PointImageSelect_Accessor target = new PointImageSelect_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.PointImageSelect_Load(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void InitializeComponentTest()
        {
            PointImageSelect_Accessor target = new PointImageSelect_Accessor(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for IconClicked
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void IconClickedTest()
        {
            PointImageSelect_Accessor target = new PointImageSelect_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.IconClicked(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DisposeTest()
        {
            PointImageSelect_Accessor target = new PointImageSelect_Accessor(); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for chbHidePoint_CheckedChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void chbHidePoint_CheckedChangedTest()
        {
            PointImageSelect_Accessor target = new PointImageSelect_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.chbHidePoint_CheckedChanged(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Button2_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void Button2_ClickTest()
        {
            PointImageSelect_Accessor target = new PointImageSelect_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.Button2_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Button1_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void Button1_ClickTest()
        {
            PointImageSelect_Accessor target = new PointImageSelect_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.Button1_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PointImageSelect Constructor
        ///</summary>
        [TestMethod()]
        public void PointImageSelectConstructorTest()
        {
            PointImageSelect target = new PointImageSelect();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
