using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for frmExportTest and is intended
    ///to contain all frmExportTest Unit Tests
    ///</summary>
    [TestClass()]
    public class frmExportTest
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
        ///A test for txtOutFileWidth
        ///</summary>
        [TestMethod()]
        public void txtOutFileWidthTest()
        {
            frmExport target = new frmExport(); // TODO: Initialize to an appropriate value
            TextBox expected = null; // TODO: Initialize to an appropriate value
            TextBox actual;
            target.txtOutFileWidth = expected;
            actual = target.txtOutFileWidth;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for txtExportFile
        ///</summary>
        [TestMethod()]
        public void txtExportFileTest()
        {
            frmExport target = new frmExport(); // TODO: Initialize to an appropriate value
            TextBox expected = null; // TODO: Initialize to an appropriate value
            TextBox actual;
            target.txtExportFile = expected;
            actual = target.txtExportFile;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TableLayoutPanel1
        ///</summary>
        [TestMethod()]
        public void TableLayoutPanel1Test()
        {
            frmExport target = new frmExport(); // TODO: Initialize to an appropriate value
            TableLayoutPanel expected = null; // TODO: Initialize to an appropriate value
            TableLayoutPanel actual;
            target.TableLayoutPanel1 = expected;
            actual = target.TableLayoutPanel1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SelectedLayer
        ///</summary>
        [TestMethod()]
        public void SelectedLayerTest()
        {
            frmExport target = new frmExport(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.SelectedLayer;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for pcCommittedBytes
        ///</summary>
        [TestMethod()]
        public void pcCommittedBytesTest()
        {
            frmExport target = new frmExport(); // TODO: Initialize to an appropriate value
            PerformanceCounter expected = null; // TODO: Initialize to an appropriate value
            PerformanceCounter actual;
            target.pcCommittedBytes = expected;
            actual = target.pcCommittedBytes;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for pcCommitLimit
        ///</summary>
        [TestMethod()]
        public void pcCommitLimitTest()
        {
            frmExport target = new frmExport(); // TODO: Initialize to an appropriate value
            PerformanceCounter expected = null; // TODO: Initialize to an appropriate value
            PerformanceCounter actual;
            target.pcCommitLimit = expected;
            actual = target.pcCommitLimit;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for pbSaveExport
        ///</summary>
        [TestMethod()]
        public void pbSaveExportTest()
        {
            frmExport target = new frmExport(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.pbSaveExport = expected;
            actual = target.pbSaveExport;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OK_Button
        ///</summary>
        [TestMethod()]
        public void OK_ButtonTest()
        {
            frmExport target = new frmExport(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.OK_Button = expected;
            actual = target.OK_Button;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MainForm
        ///</summary>
        [TestMethod()]
        public void MainFormTest()
        {
            frmExport target = new frmExport(); // TODO: Initialize to an appropriate value
            MapWindowForm expected = null; // TODO: Initialize to an appropriate value
            MapWindowForm actual;
            target.MainForm = expected;
            actual = target.MainForm;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for lblZoom
        ///</summary>
        [TestMethod()]
        public void lblZoomTest()
        {
            frmExport target = new frmExport(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.lblZoom = expected;
            actual = target.lblZoom;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for lblWidth
        ///</summary>
        [TestMethod()]
        public void lblWidthTest()
        {
            frmExport target = new frmExport(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.lblWidth = expected;
            actual = target.lblWidth;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for lblSize
        ///</summary>
        [TestMethod()]
        public void lblSizeTest()
        {
            frmExport target = new frmExport(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.lblSize = expected;
            actual = target.lblSize;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Label3
        ///</summary>
        [TestMethod()]
        public void Label3Test()
        {
            frmExport target = new frmExport(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.Label3 = expected;
            actual = target.Label3;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Label1
        ///</summary>
        [TestMethod()]
        public void Label1Test()
        {
            frmExport target = new frmExport(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.Label1 = expected;
            actual = target.Label1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for System.Drawing.ImageZoom
        ///</summary>
        [TestMethod()]
        public void ImageZoomTest()
        {
            frmExport target = new frmExport(); // TODO: Initialize to an appropriate value
            double actual;
            actual = target.ImageZoom;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for System.Drawing.ImageWidth
        ///</summary>
        [TestMethod()]
        public void ImageWidthTest()
        {
            frmExport target = new frmExport(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.ImageWidth;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GroupBox1
        ///</summary>
        [TestMethod()]
        public void GroupBox1Test()
        {
            frmExport target = new frmExport(); // TODO: Initialize to an appropriate value
            GroupBox expected = null; // TODO: Initialize to an appropriate value
            GroupBox actual;
            target.GroupBox1 = expected;
            actual = target.GroupBox1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for cbClipToLayer
        ///</summary>
        [TestMethod()]
        public void cbClipToLayerTest()
        {
            frmExport target = new frmExport(); // TODO: Initialize to an appropriate value
            ComboBox expected = null; // TODO: Initialize to an appropriate value
            ComboBox actual;
            target.cbClipToLayer = expected;
            actual = target.cbClipToLayer;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Cancel_Button
        ///</summary>
        [TestMethod()]
        public void Cancel_ButtonTest()
        {
            frmExport target = new frmExport(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.Cancel_Button = expected;
            actual = target.Cancel_Button;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for workingWidth
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void workingWidthTest()
        {
            frmExport_Accessor target = new frmExport_Accessor(); // TODO: Initialize to an appropriate value
            long expected = 0; // TODO: Initialize to an appropriate value
            long actual;
            actual = target.workingWidth();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for workingHeight
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void workingHeightTest()
        {
            frmExport_Accessor target = new frmExport_Accessor(); // TODO: Initialize to an appropriate value
            long expected = 0; // TODO: Initialize to an appropriate value
            long actual;
            actual = target.workingHeight();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for txtOutFileWidth_TextChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void txtOutFileWidth_TextChangedTest()
        {
            frmExport_Accessor target = new frmExport_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.txtOutFileWidth_TextChanged(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for showSize
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void showSizeTest()
        {
            frmExport_Accessor target = new frmExport_Accessor(); // TODO: Initialize to an appropriate value
            target.showSize();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for pbSaveExport_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void pbSaveExport_ClickTest()
        {
            frmExport_Accessor target = new frmExport_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.pbSaveExport_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OK_Button_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void OK_Button_ClickTest()
        {
            frmExport_Accessor target = new frmExport_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.OK_Button_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void InitializeComponentTest()
        {
            frmExport_Accessor target = new frmExport_Accessor(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for init
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void initTest()
        {
            frmExport_Accessor target = new frmExport_Accessor(); // TODO: Initialize to an appropriate value
            target.init();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for frmExport_Load
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void frmExport_LoadTest()
        {
            frmExport_Accessor target = new frmExport_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.frmExport_Load(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DisposeTest()
        {
            frmExport_Accessor target = new frmExport_Accessor(); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for checkAvailableMemory
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void checkAvailableMemoryTest()
        {
            frmExport_Accessor target = new frmExport_Accessor(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.checkAvailableMemory();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for cbClipToLayer_SelectedIndexChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void cbClipToLayer_SelectedIndexChangedTest()
        {
            frmExport_Accessor target = new frmExport_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.cbClipToLayer_SelectedIndexChanged(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Cancel_Button_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void Cancel_Button_ClickTest()
        {
            frmExport_Accessor target = new frmExport_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.Cancel_Button_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for frmExport Constructor
        ///</summary>
        [TestMethod()]
        public void frmExportConstructorTest()
        {
            frmExport target = new frmExport();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
