using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for ColorPickerSingleTest and is intended
    ///to contain all ColorPickerSingleTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ColorPickerSingleTest
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
        ///A test for LinkLabel1
        ///</summary>
        [TestMethod()]
        public void LinkLabel1Test()
        {
            ColorPickerSingle target = new ColorPickerSingle(); // TODO: Initialize to an appropriate value
            LinkLabel expected = null; // TODO: Initialize to an appropriate value
            LinkLabel actual;
            target.LinkLabel1 = expected;
            actual = target.LinkLabel1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for lblEndColor
        ///</summary>
        [TestMethod()]
        public void lblEndColorTest()
        {
            ColorPickerSingle target = new ColorPickerSingle(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.lblEndColor = expected;
            actual = target.lblEndColor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GroupBox1
        ///</summary>
        [TestMethod()]
        public void GroupBox1Test()
        {
            ColorPickerSingle target = new ColorPickerSingle(); // TODO: Initialize to an appropriate value
            GroupBox expected = null; // TODO: Initialize to an appropriate value
            GroupBox actual;
            target.GroupBox1 = expected;
            actual = target.GroupBox1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for cmbStart
        ///</summary>
        [TestMethod()]
        public void cmbStartTest()
        {
            ColorPickerSingle target = new ColorPickerSingle(); // TODO: Initialize to an appropriate value
            ComboBox expected = null; // TODO: Initialize to an appropriate value
            ComboBox actual;
            target.cmbStart = expected;
            actual = target.cmbStart;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for btnStartColor
        ///</summary>
        [TestMethod()]
        public void btnStartColorTest()
        {
            ColorPickerSingle target = new ColorPickerSingle(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.btnStartColor = expected;
            actual = target.btnStartColor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for btnOk
        ///</summary>
        [TestMethod()]
        public void btnOkTest()
        {
            ColorPickerSingle target = new ColorPickerSingle(); // TODO: Initialize to an appropriate value
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
            ColorPickerSingle target = new ColorPickerSingle(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.btnCancel = expected;
            actual = target.btnCancel;
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
            ColorPickerSingle_Accessor target = new ColorPickerSingle_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            LinkLabelLinkClickedEventArgs e = null; // TODO: Initialize to an appropriate value
            target.LinkLabel1_LinkClicked(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void InitializeComponentTest()
        {
            ColorPickerSingle_Accessor target = new ColorPickerSingle_Accessor(); // TODO: Initialize to an appropriate value
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
            ColorPickerSingle_Accessor target = new ColorPickerSingle_Accessor(); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ColorPicker_Load
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ColorPicker_LoadTest()
        {
            ColorPickerSingle_Accessor target = new ColorPickerSingle_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.ColorPicker_Load(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for cmbStart_SelectedIndexChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void cmbStart_SelectedIndexChangedTest()
        {
            ColorPickerSingle_Accessor target = new ColorPickerSingle_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.cmbStart_SelectedIndexChanged(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for btnStartColor_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void btnStartColor_ClickTest()
        {
            ColorPickerSingle_Accessor target = new ColorPickerSingle_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.btnStartColor_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for btnOk_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void btnOk_ClickTest()
        {
            ColorPickerSingle_Accessor target = new ColorPickerSingle_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.btnOk_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for btnCancel_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void btnCancel_ClickTest()
        {
            ColorPickerSingle_Accessor target = new ColorPickerSingle_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.btnCancel_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ColorPickerSingle Constructor
        ///</summary>
        [TestMethod()]
        public void ColorPickerSingleConstructorTest()
        {
            ColorPickerSingle target = new ColorPickerSingle();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
