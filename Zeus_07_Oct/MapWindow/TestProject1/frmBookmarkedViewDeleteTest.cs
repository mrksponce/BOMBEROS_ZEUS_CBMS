using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for frmBookmarkedViewDeleteTest and is intended
    ///to contain all frmBookmarkedViewDeleteTest Unit Tests
    ///</summary>
    [TestClass()]
    public class frmBookmarkedViewDeleteTest
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
            frmBookmarkedViewDelete target = new frmBookmarkedViewDelete(); // TODO: Initialize to an appropriate value
            ListBox expected = null; // TODO: Initialize to an appropriate value
            ListBox actual;
            target.ListBox1 = expected;
            actual = target.ListBox1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Label1
        ///</summary>
        [TestMethod()]
        public void Label1Test()
        {
            frmBookmarkedViewDelete target = new frmBookmarkedViewDelete(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.Label1 = expected;
            actual = target.Label1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for btnDelete
        ///</summary>
        [TestMethod()]
        public void btnDeleteTest()
        {
            frmBookmarkedViewDelete target = new frmBookmarkedViewDelete(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.btnDelete = expected;
            actual = target.btnDelete;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for btnClose
        ///</summary>
        [TestMethod()]
        public void btnCloseTest()
        {
            frmBookmarkedViewDelete target = new frmBookmarkedViewDelete(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.btnClose = expected;
            actual = target.btnClose;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UpdateList
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void UpdateListTest()
        {
            frmBookmarkedViewDelete_Accessor target = new frmBookmarkedViewDelete_Accessor(); // TODO: Initialize to an appropriate value
            target.UpdateList();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void InitializeComponentTest()
        {
            frmBookmarkedViewDelete_Accessor target = new frmBookmarkedViewDelete_Accessor(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for frmBookmarkedViewDelete_Load
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void frmBookmarkedViewDelete_LoadTest()
        {
            frmBookmarkedViewDelete_Accessor target = new frmBookmarkedViewDelete_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.frmBookmarkedViewDelete_Load(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DisposeTest()
        {
            frmBookmarkedViewDelete_Accessor target = new frmBookmarkedViewDelete_Accessor(); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for btnDelete_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void btnDelete_ClickTest()
        {
            frmBookmarkedViewDelete_Accessor target = new frmBookmarkedViewDelete_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.btnDelete_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for btnClose_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void btnClose_ClickTest()
        {
            frmBookmarkedViewDelete_Accessor target = new frmBookmarkedViewDelete_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.btnClose_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for frmBookmarkedViewDelete Constructor
        ///</summary>
        [TestMethod()]
        public void frmBookmarkedViewDeleteConstructorTest()
        {
            frmBookmarkedViewDelete target = new frmBookmarkedViewDelete();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
