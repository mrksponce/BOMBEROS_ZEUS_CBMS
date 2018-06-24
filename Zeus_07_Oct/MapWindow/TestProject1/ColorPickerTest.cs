using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using MapWinGIS;
using System;
using System.Windows.Forms;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for ColorPickerTest and is intended
    ///to contain all ColorPickerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ColorPickerTest
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
        ///A test for pnlPreview
        ///</summary>
        [TestMethod()]
        public void pnlPreviewTest()
        {
            ShapefileColorBreak Break = null; // TODO: Initialize to an appropriate value
            ShapefileColorBreak BreakExpected = null; // TODO: Initialize to an appropriate value
            ColorPicker target = new ColorPicker(ref Break); // TODO: Initialize to an appropriate value
            Panel expected = null; // TODO: Initialize to an appropriate value
            Panel actual;
            target.pnlPreview = expected;
            actual = target.pnlPreview;
            Assert.AreEqual(BreakExpected, Break);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LinkLabel2
        ///</summary>
        [TestMethod()]
        public void LinkLabel2Test()
        {
            ShapefileColorBreak Break = null; // TODO: Initialize to an appropriate value
            ShapefileColorBreak BreakExpected = null; // TODO: Initialize to an appropriate value
            ColorPicker target = new ColorPicker(ref Break); // TODO: Initialize to an appropriate value
            LinkLabel expected = null; // TODO: Initialize to an appropriate value
            LinkLabel actual;
            target.LinkLabel2 = expected;
            actual = target.LinkLabel2;
            Assert.AreEqual(BreakExpected, Break);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LinkLabel1
        ///</summary>
        [TestMethod()]
        public void LinkLabel1Test()
        {
            ShapefileColorBreak Break = null; // TODO: Initialize to an appropriate value
            ShapefileColorBreak BreakExpected = null; // TODO: Initialize to an appropriate value
            ColorPicker target = new ColorPicker(ref Break); // TODO: Initialize to an appropriate value
            LinkLabel expected = null; // TODO: Initialize to an appropriate value
            LinkLabel actual;
            target.LinkLabel1 = expected;
            actual = target.LinkLabel1;
            Assert.AreEqual(BreakExpected, Break);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for lblEndColor
        ///</summary>
        [TestMethod()]
        public void lblEndColorTest()
        {
            ShapefileColorBreak Break = null; // TODO: Initialize to an appropriate value
            ShapefileColorBreak BreakExpected = null; // TODO: Initialize to an appropriate value
            ColorPicker target = new ColorPicker(ref Break); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.lblEndColor = expected;
            actual = target.lblEndColor;
            Assert.AreEqual(BreakExpected, Break);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Label1
        ///</summary>
        [TestMethod()]
        public void Label1Test()
        {
            ShapefileColorBreak Break = null; // TODO: Initialize to an appropriate value
            ShapefileColorBreak BreakExpected = null; // TODO: Initialize to an appropriate value
            ColorPicker target = new ColorPicker(ref Break); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.Label1 = expected;
            actual = target.Label1;
            Assert.AreEqual(BreakExpected, Break);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GroupBox3
        ///</summary>
        [TestMethod()]
        public void GroupBox3Test()
        {
            ShapefileColorBreak Break = null; // TODO: Initialize to an appropriate value
            ShapefileColorBreak BreakExpected = null; // TODO: Initialize to an appropriate value
            ColorPicker target = new ColorPicker(ref Break); // TODO: Initialize to an appropriate value
            GroupBox expected = null; // TODO: Initialize to an appropriate value
            GroupBox actual;
            target.GroupBox3 = expected;
            actual = target.GroupBox3;
            Assert.AreEqual(BreakExpected, Break);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GroupBox2
        ///</summary>
        [TestMethod()]
        public void GroupBox2Test()
        {
            ShapefileColorBreak Break = null; // TODO: Initialize to an appropriate value
            ShapefileColorBreak BreakExpected = null; // TODO: Initialize to an appropriate value
            ColorPicker target = new ColorPicker(ref Break); // TODO: Initialize to an appropriate value
            GroupBox expected = null; // TODO: Initialize to an appropriate value
            GroupBox actual;
            target.GroupBox2 = expected;
            actual = target.GroupBox2;
            Assert.AreEqual(BreakExpected, Break);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GroupBox1
        ///</summary>
        [TestMethod()]
        public void GroupBox1Test()
        {
            ShapefileColorBreak Break = null; // TODO: Initialize to an appropriate value
            ShapefileColorBreak BreakExpected = null; // TODO: Initialize to an appropriate value
            ColorPicker target = new ColorPicker(ref Break); // TODO: Initialize to an appropriate value
            GroupBox expected = null; // TODO: Initialize to an appropriate value
            GroupBox actual;
            target.GroupBox1 = expected;
            actual = target.GroupBox1;
            Assert.AreEqual(BreakExpected, Break);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for cmbStart
        ///</summary>
        [TestMethod()]
        public void cmbStartTest()
        {
            ShapefileColorBreak Break = null; // TODO: Initialize to an appropriate value
            ShapefileColorBreak BreakExpected = null; // TODO: Initialize to an appropriate value
            ColorPicker target = new ColorPicker(ref Break); // TODO: Initialize to an appropriate value
            ComboBox expected = null; // TODO: Initialize to an appropriate value
            ComboBox actual;
            target.cmbStart = expected;
            actual = target.cmbStart;
            Assert.AreEqual(BreakExpected, Break);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for cmbEnd
        ///</summary>
        [TestMethod()]
        public void cmbEndTest()
        {
            ShapefileColorBreak Break = null; // TODO: Initialize to an appropriate value
            ShapefileColorBreak BreakExpected = null; // TODO: Initialize to an appropriate value
            ColorPicker target = new ColorPicker(ref Break); // TODO: Initialize to an appropriate value
            ComboBox expected = null; // TODO: Initialize to an appropriate value
            ComboBox actual;
            target.cmbEnd = expected;
            actual = target.cmbEnd;
            Assert.AreEqual(BreakExpected, Break);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for btnStartColor
        ///</summary>
        [TestMethod()]
        public void btnStartColorTest()
        {
            ShapefileColorBreak Break = null; // TODO: Initialize to an appropriate value
            ShapefileColorBreak BreakExpected = null; // TODO: Initialize to an appropriate value
            ColorPicker target = new ColorPicker(ref Break); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.btnStartColor = expected;
            actual = target.btnStartColor;
            Assert.AreEqual(BreakExpected, Break);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for btnOk
        ///</summary>
        [TestMethod()]
        public void btnOkTest()
        {
            ShapefileColorBreak Break = null; // TODO: Initialize to an appropriate value
            ShapefileColorBreak BreakExpected = null; // TODO: Initialize to an appropriate value
            ColorPicker target = new ColorPicker(ref Break); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.btnOk = expected;
            actual = target.btnOk;
            Assert.AreEqual(BreakExpected, Break);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for btnEndColor
        ///</summary>
        [TestMethod()]
        public void btnEndColorTest()
        {
            ShapefileColorBreak Break = null; // TODO: Initialize to an appropriate value
            ShapefileColorBreak BreakExpected = null; // TODO: Initialize to an appropriate value
            ColorPicker target = new ColorPicker(ref Break); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.btnEndColor = expected;
            actual = target.btnEndColor;
            Assert.AreEqual(BreakExpected, Break);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for btnCancel
        ///</summary>
        [TestMethod()]
        public void btnCancelTest()
        {
            ShapefileColorBreak Break = null; // TODO: Initialize to an appropriate value
            ShapefileColorBreak BreakExpected = null; // TODO: Initialize to an appropriate value
            ColorPicker target = new ColorPicker(ref Break); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.btnCancel = expected;
            actual = target.btnCancel;
            Assert.AreEqual(BreakExpected, Break);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UpdatePreview
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void UpdatePreviewTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ColorPicker_Accessor target = new ColorPicker_Accessor(param0); // TODO: Initialize to an appropriate value
            target.UpdatePreview();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for pnlPreview_Paint
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void pnlPreview_PaintTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ColorPicker_Accessor target = new ColorPicker_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            PaintEventArgs e = null; // TODO: Initialize to an appropriate value
            target.pnlPreview_Paint(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LinkLabel2_LinkClicked
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void LinkLabel2_LinkClickedTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ColorPicker_Accessor target = new ColorPicker_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            LinkLabelLinkClickedEventArgs e = null; // TODO: Initialize to an appropriate value
            target.LinkLabel2_LinkClicked(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LinkLabel1_LinkClicked
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void LinkLabel1_LinkClickedTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ColorPicker_Accessor target = new ColorPicker_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            LinkLabelLinkClickedEventArgs e = null; // TODO: Initialize to an appropriate value
            target.LinkLabel1_LinkClicked(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for lblEndColor_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void lblEndColor_ClickTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ColorPicker_Accessor target = new ColorPicker_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.lblEndColor_Click(sender, e);
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
            ColorPicker_Accessor target = new ColorPicker_Accessor(param0); // TODO: Initialize to an appropriate value
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
            ColorPicker_Accessor target = new ColorPicker_Accessor(param0); // TODO: Initialize to an appropriate value
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
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ColorPicker_Accessor target = new ColorPicker_Accessor(param0); // TODO: Initialize to an appropriate value
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
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ColorPicker_Accessor target = new ColorPicker_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.cmbStart_SelectedIndexChanged(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for cmbEnd_SelectedIndexChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void cmbEnd_SelectedIndexChangedTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ColorPicker_Accessor target = new ColorPicker_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.cmbEnd_SelectedIndexChanged(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for btnStartColor_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void btnStartColor_ClickTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ColorPicker_Accessor target = new ColorPicker_Accessor(param0); // TODO: Initialize to an appropriate value
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
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ColorPicker_Accessor target = new ColorPicker_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.btnOk_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for btnEndColor_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void btnEndColor_ClickTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ColorPicker_Accessor target = new ColorPicker_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.btnEndColor_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for btnCancel_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void btnCancel_ClickTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ColorPicker_Accessor target = new ColorPicker_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.btnCancel_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ColorPicker Constructor
        ///</summary>
        [TestMethod()]
        public void ColorPickerConstructorTest2()
        {
            ShapefileColorBreak Break = null; // TODO: Initialize to an appropriate value
            ShapefileColorBreak BreakExpected = null; // TODO: Initialize to an appropriate value
            ColorPicker target = new ColorPicker(ref Break);
            Assert.AreEqual(BreakExpected, Break);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ColorPicker Constructor
        ///</summary>
        [TestMethod()]
        public void ColorPickerConstructorTest1()
        {
            GridColorBreak Break = null; // TODO: Initialize to an appropriate value
            GridColorBreak BreakExpected = null; // TODO: Initialize to an appropriate value
            ColorPicker target = new ColorPicker(ref Break);
            Assert.AreEqual(BreakExpected, Break);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ColorPicker Constructor
        ///</summary>
        [TestMethod()]
        public void ColorPickerConstructorTest()
        {
            Color startc = new Color(); // TODO: Initialize to an appropriate value
            Color endc = new Color(); // TODO: Initialize to an appropriate value
            ColorPicker target = new ColorPicker(startc, endc);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
