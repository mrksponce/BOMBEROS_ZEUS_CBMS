using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for ErrorDialogTest and is intended
    ///to contain all ErrorDialogTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ErrorDialogTest
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
        ///A test for txtEMail
        ///</summary>
        [TestMethod()]
        public void txtEMailTest()
        {
            Exception ex = null; // TODO: Initialize to an appropriate value
            string SendNextToEmail = string.Empty; // TODO: Initialize to an appropriate value
            ErrorDialog target = new ErrorDialog(ex, SendNextToEmail); // TODO: Initialize to an appropriate value
            TextBox expected = null; // TODO: Initialize to an appropriate value
            TextBox actual;
            target.txtEMail = expected;
            actual = target.txtEMail;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for txtComments
        ///</summary>
        [TestMethod()]
        public void txtCommentsTest()
        {
            Exception ex = null; // TODO: Initialize to an appropriate value
            string SendNextToEmail = string.Empty; // TODO: Initialize to an appropriate value
            ErrorDialog target = new ErrorDialog(ex, SendNextToEmail); // TODO: Initialize to an appropriate value
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
            string SendNextToEmail = string.Empty; // TODO: Initialize to an appropriate value
            ErrorDialog target = new ErrorDialog(ex, SendNextToEmail); // TODO: Initialize to an appropriate value
            PictureBox expected = null; // TODO: Initialize to an appropriate value
            PictureBox actual;
            target.PictureBox1 = expected;
            actual = target.PictureBox1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LinkLabel1
        ///</summary>
        [TestMethod()]
        public void LinkLabel1Test()
        {
            Exception ex = null; // TODO: Initialize to an appropriate value
            string SendNextToEmail = string.Empty; // TODO: Initialize to an appropriate value
            ErrorDialog target = new ErrorDialog(ex, SendNextToEmail); // TODO: Initialize to an appropriate value
            LinkLabel expected = null; // TODO: Initialize to an appropriate value
            LinkLabel actual;
            target.LinkLabel1 = expected;
            actual = target.LinkLabel1;
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
            string SendNextToEmail = string.Empty; // TODO: Initialize to an appropriate value
            ErrorDialog target = new ErrorDialog(ex, SendNextToEmail); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.lblErr = expected;
            actual = target.lblErr;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for lblComments
        ///</summary>
        [TestMethod()]
        public void lblCommentsTest()
        {
            Exception ex = null; // TODO: Initialize to an appropriate value
            string SendNextToEmail = string.Empty; // TODO: Initialize to an appropriate value
            ErrorDialog target = new ErrorDialog(ex, SendNextToEmail); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.lblComments = expected;
            actual = target.lblComments;
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
            string SendNextToEmail = string.Empty; // TODO: Initialize to an appropriate value
            ErrorDialog target = new ErrorDialog(ex, SendNextToEmail); // TODO: Initialize to an appropriate value
            LinkLabel expected = null; // TODO: Initialize to an appropriate value
            LinkLabel actual;
            target.lblAltLink = expected;
            actual = target.lblAltLink;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Label1
        ///</summary>
        [TestMethod()]
        public void Label1Test()
        {
            Exception ex = null; // TODO: Initialize to an appropriate value
            string SendNextToEmail = string.Empty; // TODO: Initialize to an appropriate value
            ErrorDialog target = new ErrorDialog(ex, SendNextToEmail); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.Label1 = expected;
            actual = target.Label1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for chkNoReport
        ///</summary>
        [TestMethod()]
        public void chkNoReportTest()
        {
            Exception ex = null; // TODO: Initialize to an appropriate value
            string SendNextToEmail = string.Empty; // TODO: Initialize to an appropriate value
            ErrorDialog target = new ErrorDialog(ex, SendNextToEmail); // TODO: Initialize to an appropriate value
            CheckBox expected = null; // TODO: Initialize to an appropriate value
            CheckBox actual;
            target.chkNoReport = expected;
            actual = target.chkNoReport;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Button1
        ///</summary>
        [TestMethod()]
        public void Button1Test()
        {
            Exception ex = null; // TODO: Initialize to an appropriate value
            string SendNextToEmail = string.Empty; // TODO: Initialize to an appropriate value
            ErrorDialog target = new ErrorDialog(ex, SendNextToEmail); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.Button1 = expected;
            actual = target.Button1;
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
            string SendNextToEmail = string.Empty; // TODO: Initialize to an appropriate value
            ErrorDialog target = new ErrorDialog(ex, SendNextToEmail); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.btnSend = expected;
            actual = target.btnSend;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LinkLabel1_LinkClicked
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void LinkLabel1_LinkClickedTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ErrorDialog_Accessor target = new ErrorDialog_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            LinkLabelLinkClickedEventArgs e = null; // TODO: Initialize to an appropriate value
            target.LinkLabel1_LinkClicked(sender, e);
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
            ErrorDialog_Accessor target = new ErrorDialog_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            LinkLabelLinkClickedEventArgs e = null; // TODO: Initialize to an appropriate value
            target.lblReportError_LinkClicked(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Label1_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void Label1_ClickTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ErrorDialog_Accessor target = new ErrorDialog_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.Label1_Click(sender, e);
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
            ErrorDialog_Accessor target = new ErrorDialog_Accessor(param0); // TODO: Initialize to an appropriate value
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
            ErrorDialog_Accessor target = new ErrorDialog_Accessor(param0); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for chkNoReport_CheckedChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void chkNoReport_CheckedChangedTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ErrorDialog_Accessor target = new ErrorDialog_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.chkNoReport_CheckedChanged(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Button1_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void Button1_ClickTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ErrorDialog_Accessor target = new ErrorDialog_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.Button1_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for btnSend_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void btnSend_ClickTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ErrorDialog_Accessor target = new ErrorDialog_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.btnSend_Click(sender, e);
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
            ErrorDialog_Accessor target = new ErrorDialog_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.btnClose_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ErrorDialog Constructor
        ///</summary>
        [TestMethod()]
        public void ErrorDialogConstructorTest()
        {
            Exception ex = null; // TODO: Initialize to an appropriate value
            string SendNextToEmail = string.Empty; // TODO: Initialize to an appropriate value
            ErrorDialog target = new ErrorDialog(ex, SendNextToEmail);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
