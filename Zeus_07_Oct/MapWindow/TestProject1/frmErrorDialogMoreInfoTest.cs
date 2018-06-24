using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for frmErrorDialogMoreInfoTest and is intended
    ///to contain all frmErrorDialogMoreInfoTest Unit Tests
    ///</summary>
    [TestClass()]
    public class frmErrorDialogMoreInfoTest
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
        ///A test for txtFullText
        ///</summary>
        [TestMethod()]
        public void txtFullTextTest()
        {
            frmErrorDialogMoreInfo target = new frmErrorDialogMoreInfo(); // TODO: Initialize to an appropriate value
            TextBox expected = null; // TODO: Initialize to an appropriate value
            TextBox actual;
            target.txtFullText = expected;
            actual = target.txtFullText;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for lblErr
        ///</summary>
        [TestMethod()]
        public void lblErrTest()
        {
            frmErrorDialogMoreInfo target = new frmErrorDialogMoreInfo(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.lblErr = expected;
            actual = target.lblErr;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for btnSend
        ///</summary>
        [TestMethod()]
        public void btnSendTest()
        {
            frmErrorDialogMoreInfo target = new frmErrorDialogMoreInfo(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.btnSend = expected;
            actual = target.btnSend;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for btnCopy
        ///</summary>
        [TestMethod()]
        public void btnCopyTest()
        {
            frmErrorDialogMoreInfo target = new frmErrorDialogMoreInfo(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.btnCopy = expected;
            actual = target.btnCopy;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for txtFullText_KeyDown
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void txtFullText_KeyDownTest()
        {
            frmErrorDialogMoreInfo_Accessor target = new frmErrorDialogMoreInfo_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            KeyEventArgs e = null; // TODO: Initialize to an appropriate value
            target.txtFullText_KeyDown(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void InitializeComponentTest()
        {
            frmErrorDialogMoreInfo_Accessor target = new frmErrorDialogMoreInfo_Accessor(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for frmErrorDialogMoreInfo_Load
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void frmErrorDialogMoreInfo_LoadTest()
        {
            frmErrorDialogMoreInfo_Accessor target = new frmErrorDialogMoreInfo_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.frmErrorDialogMoreInfo_Load(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DisposeTest()
        {
            frmErrorDialogMoreInfo_Accessor target = new frmErrorDialogMoreInfo_Accessor(); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for btnSend_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void btnSend_ClickTest()
        {
            frmErrorDialogMoreInfo_Accessor target = new frmErrorDialogMoreInfo_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.btnSend_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for btnCopy_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void btnCopy_ClickTest()
        {
            frmErrorDialogMoreInfo_Accessor target = new frmErrorDialogMoreInfo_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.btnCopy_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for frmErrorDialogMoreInfo Constructor
        ///</summary>
        [TestMethod()]
        public void frmErrorDialogMoreInfoConstructorTest()
        {
            frmErrorDialogMoreInfo target = new frmErrorDialogMoreInfo();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
