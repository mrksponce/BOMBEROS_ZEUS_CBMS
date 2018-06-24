using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for frmSetScaleTest and is intended
    ///to contain all frmSetScaleTest Unit Tests
    ///</summary>
    [TestClass()]
    public class frmSetScaleTest
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
        ///A test for txtOldScale
        ///</summary>
        [TestMethod()]
        public void txtOldScaleTest()
        {
            string CurrentScale = string.Empty; // TODO: Initialize to an appropriate value
            frmSetScale target = new frmSetScale(CurrentScale); // TODO: Initialize to an appropriate value
            TextBox expected = null; // TODO: Initialize to an appropriate value
            TextBox actual;
            target.txtOldScale = expected;
            actual = target.txtOldScale;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for txtNewScale
        ///</summary>
        [TestMethod()]
        public void txtNewScaleTest()
        {
            string CurrentScale = string.Empty; // TODO: Initialize to an appropriate value
            frmSetScale target = new frmSetScale(CurrentScale); // TODO: Initialize to an appropriate value
            TextBox expected = null; // TODO: Initialize to an appropriate value
            TextBox actual;
            target.txtNewScale = expected;
            actual = target.txtNewScale;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Label5
        ///</summary>
        [TestMethod()]
        public void Label5Test()
        {
            string CurrentScale = string.Empty; // TODO: Initialize to an appropriate value
            frmSetScale target = new frmSetScale(CurrentScale); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.Label5 = expected;
            actual = target.Label5;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Label4
        ///</summary>
        [TestMethod()]
        public void Label4Test()
        {
            string CurrentScale = string.Empty; // TODO: Initialize to an appropriate value
            frmSetScale target = new frmSetScale(CurrentScale); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.Label4 = expected;
            actual = target.Label4;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Label3
        ///</summary>
        [TestMethod()]
        public void Label3Test()
        {
            string CurrentScale = string.Empty; // TODO: Initialize to an appropriate value
            frmSetScale target = new frmSetScale(CurrentScale); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.Label3 = expected;
            actual = target.Label3;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Label2
        ///</summary>
        [TestMethod()]
        public void Label2Test()
        {
            string CurrentScale = string.Empty; // TODO: Initialize to an appropriate value
            frmSetScale target = new frmSetScale(CurrentScale); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.Label2 = expected;
            actual = target.Label2;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GroupBox1
        ///</summary>
        [TestMethod()]
        public void GroupBox1Test()
        {
            string CurrentScale = string.Empty; // TODO: Initialize to an appropriate value
            frmSetScale target = new frmSetScale(CurrentScale); // TODO: Initialize to an appropriate value
            GroupBox expected = null; // TODO: Initialize to an appropriate value
            GroupBox actual;
            target.GroupBox1 = expected;
            actual = target.GroupBox1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for btnOk
        ///</summary>
        [TestMethod()]
        public void btnOkTest()
        {
            string CurrentScale = string.Empty; // TODO: Initialize to an appropriate value
            frmSetScale target = new frmSetScale(CurrentScale); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.btnOk = expected;
            actual = target.btnOk;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for btnCancel
        ///</summary>
        [TestMethod()]
        public void btnCancelTest()
        {
            string CurrentScale = string.Empty; // TODO: Initialize to an appropriate value
            frmSetScale target = new frmSetScale(CurrentScale); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.btnCancel = expected;
            actual = target.btnCancel;
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
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            frmSetScale_Accessor target = new frmSetScale_Accessor(param0); // TODO: Initialize to an appropriate value
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
            frmSetScale_Accessor target = new frmSetScale_Accessor(param0); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Button2_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void Button2_ClickTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            frmSetScale_Accessor target = new frmSetScale_Accessor(param0); // TODO: Initialize to an appropriate value
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
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            frmSetScale_Accessor target = new frmSetScale_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.Button1_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for frmSetScale Constructor
        ///</summary>
        [TestMethod()]
        public void frmSetScaleConstructorTest()
        {
            string CurrentScale = string.Empty; // TODO: Initialize to an appropriate value
            frmSetScale target = new frmSetScale(CurrentScale);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
