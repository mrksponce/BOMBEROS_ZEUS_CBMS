using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for frmProjectionDialogTest and is intended
    ///to contain all frmProjectionDialogTest Unit Tests
    ///</summary>
    [TestClass()]
    public class frmProjectionDialogTest
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
        ///A test for Panel1
        ///</summary>
        [TestMethod()]
        public void Panel1Test()
        {
            frmProjectionDialog target = new frmProjectionDialog(); // TODO: Initialize to an appropriate value
            Panel expected = null; // TODO: Initialize to an appropriate value
            Panel actual;
            target.Panel1 = expected;
            actual = target.Panel1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for lblName
        ///</summary>
        [TestMethod()]
        public void lblNameTest()
        {
            frmProjectionDialog target = new frmProjectionDialog(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.lblName = expected;
            actual = target.lblName;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for lblCategory
        ///</summary>
        [TestMethod()]
        public void lblCategoryTest()
        {
            frmProjectionDialog target = new frmProjectionDialog(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.lblCategory = expected;
            actual = target.lblCategory;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for lblCaption
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void lblCaptionTest()
        {
            frmProjectionDialog_Accessor target = new frmProjectionDialog_Accessor(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.lblCaption = expected;
            actual = target.lblCaption;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Label4
        ///</summary>
        [TestMethod()]
        public void Label4Test()
        {
            frmProjectionDialog target = new frmProjectionDialog(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.Label4 = expected;
            actual = target.Label4;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for cboName
        ///</summary>
        [TestMethod()]
        public void cboNameTest()
        {
            frmProjectionDialog target = new frmProjectionDialog(); // TODO: Initialize to an appropriate value
            ComboBox expected = null; // TODO: Initialize to an appropriate value
            ComboBox actual;
            target.cboName = expected;
            actual = target.cboName;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for cboMainCateg
        ///</summary>
        [TestMethod()]
        public void cboMainCategTest()
        {
            frmProjectionDialog target = new frmProjectionDialog(); // TODO: Initialize to an appropriate value
            ComboBox expected = null; // TODO: Initialize to an appropriate value
            ComboBox actual;
            target.cboMainCateg = expected;
            actual = target.cboMainCateg;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for cboCategory
        ///</summary>
        [TestMethod()]
        public void cboCategoryTest()
        {
            frmProjectionDialog target = new frmProjectionDialog(); // TODO: Initialize to an appropriate value
            ComboBox expected = null; // TODO: Initialize to an appropriate value
            ComboBox actual;
            target.cboCategory = expected;
            actual = target.cboCategory;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for btnOK
        ///</summary>
        [TestMethod()]
        public void btnOKTest()
        {
            frmProjectionDialog target = new frmProjectionDialog(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.btnOK = expected;
            actual = target.btnOK;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for btnCancel
        ///</summary>
        [TestMethod()]
        public void btnCancelTest()
        {
            frmProjectionDialog target = new frmProjectionDialog(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.btnCancel = expected;
            actual = target.btnCancel;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SetProjection
        ///</summary>
        [TestMethod()]
        public void SetProjectionTest()
        {
            frmProjectionDialog target = new frmProjectionDialog(); // TODO: Initialize to an appropriate value
            string inproj = string.Empty; // TODO: Initialize to an appropriate value
            target.SetProjection(inproj);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetCaptionText
        ///</summary>
        [TestMethod()]
        public void SetCaptionTextTest()
        {
            frmProjectionDialog target = new frmProjectionDialog(); // TODO: Initialize to an appropriate value
            string captionText = string.Empty; // TODO: Initialize to an appropriate value
            target.SetCaptionText(captionText);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void InitializeComponentTest()
        {
            frmProjectionDialog_Accessor target = new frmProjectionDialog_Accessor(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetProjection
        ///</summary>
        [TestMethod()]
        public void GetProjectionTest()
        {
            frmProjectionDialog target = new frmProjectionDialog(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetProjection();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for frmProjectionDialog_Load
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void frmProjectionDialog_LoadTest()
        {
            frmProjectionDialog_Accessor target = new frmProjectionDialog_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.frmProjectionDialog_Load(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Finalize
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void FinalizeTest()
        {
            frmProjectionDialog_Accessor target = new frmProjectionDialog_Accessor(); // TODO: Initialize to an appropriate value
            target.Finalize();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DisposeTest()
        {
            frmProjectionDialog_Accessor target = new frmProjectionDialog_Accessor(); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for cboMainCateg_SelectedIndexChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void cboMainCateg_SelectedIndexChangedTest()
        {
            frmProjectionDialog_Accessor target = new frmProjectionDialog_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.cboMainCateg_SelectedIndexChanged(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for cboCategory_SelectedIndexChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void cboCategory_SelectedIndexChangedTest()
        {
            frmProjectionDialog_Accessor target = new frmProjectionDialog_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.cboCategory_SelectedIndexChanged(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Button1_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void Button1_ClickTest()
        {
            frmProjectionDialog_Accessor target = new frmProjectionDialog_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.Button1_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for btnOK_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void btnOK_ClickTest()
        {
            frmProjectionDialog_Accessor target = new frmProjectionDialog_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.btnOK_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for frmProjectionDialog Constructor
        ///</summary>
        [TestMethod()]
        public void frmProjectionDialogConstructorTest()
        {
            frmProjectionDialog target = new frmProjectionDialog();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
