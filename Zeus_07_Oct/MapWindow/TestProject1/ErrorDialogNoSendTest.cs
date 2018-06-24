using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for ErrorDialogNoSendTest and is intended
    ///to contain all ErrorDialogNoSendTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ErrorDialogNoSendTest
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
        ///A test for txtComments
        ///</summary>
        [TestMethod()]
        public void txtCommentsTest()
        {
            Exception ex = null; // TODO: Initialize to an appropriate value
            ErrorDialogNoSend target = new ErrorDialogNoSend(ex); // TODO: Initialize to an appropriate value
            TextBox expected = null; // TODO: Initialize to an appropriate value
            TextBox actual;
            target.txtComments = expected;
            actual = target.txtComments;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PictureBox1
        ///</summary>
        [TestMethod()]
        public void PictureBox1Test()
        {
            Exception ex = null; // TODO: Initialize to an appropriate value
            ErrorDialogNoSend target = new ErrorDialogNoSend(ex); // TODO: Initialize to an appropriate value
            PictureBox expected = null; // TODO: Initialize to an appropriate value
            PictureBox actual;
            target.PictureBox1 = expected;
            actual = target.PictureBox1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for lblErr
        ///</summary>
        [TestMethod()]
        public void lblErrTest()
        {
            Exception ex = null; // TODO: Initialize to an appropriate value
            ErrorDialogNoSend target = new ErrorDialogNoSend(ex); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.lblErr = expected;
            actual = target.lblErr;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for lblAltLink
        ///</summary>
        [TestMethod()]
        public void lblAltLinkTest()
        {
            Exception ex = null; // TODO: Initialize to an appropriate value
            ErrorDialogNoSend target = new ErrorDialogNoSend(ex); // TODO: Initialize to an appropriate value
            LinkLabel expected = null; // TODO: Initialize to an appropriate value
            LinkLabel actual;
            target.lblAltLink = expected;
            actual = target.lblAltLink;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for btnSend
        ///</summary>
        [TestMethod()]
        public void btnSendTest()
        {
            Exception ex = null; // TODO: Initialize to an appropriate value
            ErrorDialogNoSend target = new ErrorDialogNoSend(ex); // TODO: Initialize to an appropriate value
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
            Exception ex = null; // TODO: Initialize to an appropriate value
            ErrorDialogNoSend target = new ErrorDialogNoSend(ex); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.btnCopy = expected;
            actual = target.btnCopy;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for txtComments_KeyDown
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void txtComments_KeyDownTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ErrorDialogNoSend_Accessor target = new ErrorDialogNoSend_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            KeyEventArgs e = null; // TODO: Initialize to an appropriate value
            target.txtComments_KeyDown(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for lblReportError_LinkClicked
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void lblReportError_LinkClickedTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ErrorDialogNoSend_Accessor target = new ErrorDialogNoSend_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            LinkLabelLinkClickedEventArgs e = null; // TODO: Initialize to an appropriate value
            target.lblReportError_LinkClicked(sender, e);
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
            ErrorDialogNoSend_Accessor target = new ErrorDialogNoSend_Accessor(param0); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ErrorDialogNoSend_Load
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ErrorDialogNoSend_LoadTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ErrorDialogNoSend_Accessor target = new ErrorDialogNoSend_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.ErrorDialogNoSend_Load(sender, e);
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
            ErrorDialogNoSend_Accessor target = new ErrorDialogNoSend_Accessor(param0); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for btnCopy_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void btnCopy_ClickTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ErrorDialogNoSend_Accessor target = new ErrorDialogNoSend_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.btnCopy_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for btnClose_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void btnClose_ClickTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ErrorDialogNoSend_Accessor target = new ErrorDialogNoSend_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.btnClose_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ErrorDialogNoSend Constructor
        ///</summary>
        [TestMethod()]
        public void ErrorDialogNoSendConstructorTest()
        {
            Exception ex = null; // TODO: Initialize to an appropriate value
            ErrorDialogNoSend target = new ErrorDialogNoSend(ex);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
