using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for frmAboutTest and is intended
    ///to contain all frmAboutTest Unit Tests
    ///</summary>
    [TestClass()]
    public class frmAboutTest
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
        ///A test for Version
        ///</summary>
        [TestMethod()]
        public void VersionTest()
        {
            frmAbout target = new frmAbout(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.Version = expected;
            actual = target.Version;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TextBox1
        ///</summary>
        [TestMethod()]
        public void TextBox1Test()
        {
            frmAbout target = new frmAbout(); // TODO: Initialize to an appropriate value
            TextBox expected = null; // TODO: Initialize to an appropriate value
            TextBox actual;
            target.TextBox1 = expected;
            actual = target.TextBox1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for picMapWindow
        ///</summary>
        [TestMethod()]
        public void picMapWindowTest()
        {
            frmAbout target = new frmAbout(); // TODO: Initialize to an appropriate value
            PictureBox expected = null; // TODO: Initialize to an appropriate value
            PictureBox actual;
            target.picMapWindow = expected;
            actual = target.picMapWindow;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for notes
        ///</summary>
        [TestMethod()]
        public void notesTest()
        {
            frmAbout target = new frmAbout(); // TODO: Initialize to an appropriate value
            RichTextBox expected = null; // TODO: Initialize to an appropriate value
            RichTextBox actual;
            target.notes = expected;
            actual = target.notes;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MapwinVersion
        ///</summary>
        [TestMethod()]
        public void MapwinVersionTest()
        {
            frmAbout target = new frmAbout(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.MapwinVersion = expected;
            actual = target.MapwinVersion;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LinkLabel2
        ///</summary>
        [TestMethod()]
        public void LinkLabel2Test()
        {
            frmAbout target = new frmAbout(); // TODO: Initialize to an appropriate value
            LinkLabel expected = null; // TODO: Initialize to an appropriate value
            LinkLabel actual;
            target.LinkLabel2 = expected;
            actual = target.LinkLabel2;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LinkLabel1
        ///</summary>
        [TestMethod()]
        public void LinkLabel1Test()
        {
            frmAbout target = new frmAbout(); // TODO: Initialize to an appropriate value
            LinkLabel expected = null; // TODO: Initialize to an appropriate value
            LinkLabel actual;
            target.LinkLabel1 = expected;
            actual = target.LinkLabel1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for lbURL
        ///</summary>
        [TestMethod()]
        public void lbURLTest()
        {
            frmAbout target = new frmAbout(); // TODO: Initialize to an appropriate value
            LinkLabel expected = null; // TODO: Initialize to an appropriate value
            LinkLabel actual;
            target.lbURL = expected;
            actual = target.lbURL;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for lbName
        ///</summary>
        [TestMethod()]
        public void lbNameTest()
        {
            frmAbout target = new frmAbout(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.lbName = expected;
            actual = target.lbName;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for lblProjFile
        ///</summary>
        [TestMethod()]
        public void lblProjFileTest()
        {
            frmAbout target = new frmAbout(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.lblProjFile = expected;
            actual = target.lblProjFile;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for lblConfigFile
        ///</summary>
        [TestMethod()]
        public void lblConfigFileTest()
        {
            frmAbout target = new frmAbout(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.lblConfigFile = expected;
            actual = target.lblConfigFile;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Label5
        ///</summary>
        [TestMethod()]
        public void Label5Test()
        {
            frmAbout target = new frmAbout(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.Label5 = expected;
            actual = target.Label5;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Label3
        ///</summary>
        [TestMethod()]
        public void Label3Test()
        {
            frmAbout target = new frmAbout(); // TODO: Initialize to an appropriate value
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
            frmAbout target = new frmAbout(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.Label2 = expected;
            actual = target.Label2;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Label1
        ///</summary>
        [TestMethod()]
        public void Label1Test()
        {
            frmAbout target = new frmAbout(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.Label1 = expected;
            actual = target.Label1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GroupBox1
        ///</summary>
        [TestMethod()]
        public void GroupBox1Test()
        {
            frmAbout target = new frmAbout(); // TODO: Initialize to an appropriate value
            GroupBox expected = null; // TODO: Initialize to an appropriate value
            GroupBox actual;
            target.GroupBox1 = expected;
            actual = target.GroupBox1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Developer
        ///</summary>
        [TestMethod()]
        public void DeveloperTest()
        {
            frmAbout target = new frmAbout(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.Developer = expected;
            actual = target.Developer;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuildDate
        ///</summary>
        [TestMethod()]
        public void BuildDateTest()
        {
            frmAbout target = new frmAbout(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.BuildDate = expected;
            actual = target.BuildDate;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for btnProcInfo
        ///</summary>
        [TestMethod()]
        public void btnProcInfoTest()
        {
            frmAbout target = new frmAbout(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.btnProcInfo = expected;
            actual = target.btnProcInfo;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for btnOk
        ///</summary>
        [TestMethod()]
        public void btnOkTest()
        {
            frmAbout target = new frmAbout(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.btnOk = expected;
            actual = target.btnOk;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ShowAbout
        ///</summary>
        [TestMethod()]
        public void ShowAboutTest()
        {
            frmAbout target = new frmAbout(); // TODO: Initialize to an appropriate value
            Form frm = null; // TODO: Initialize to an appropriate value
            target.ShowAbout(frm);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PicMapWin_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void PicMapWin_ClickTest()
        {
            frmAbout_Accessor target = new frmAbout_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.PicMapWin_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Pic_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void Pic_ClickTest()
        {
            frmAbout_Accessor target = new frmAbout_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.Pic_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LinkLabel2_LinkClicked
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void LinkLabel2_LinkClickedTest()
        {
            frmAbout_Accessor target = new frmAbout_Accessor(); // TODO: Initialize to an appropriate value
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
            frmAbout_Accessor target = new frmAbout_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            LinkLabelLinkClickedEventArgs e = null; // TODO: Initialize to an appropriate value
            target.LinkLabel1_LinkClicked(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for lbURL_LinkClicked
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void lbURL_LinkClickedTest()
        {
            frmAbout_Accessor target = new frmAbout_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            LinkLabelLinkClickedEventArgs e = null; // TODO: Initialize to an appropriate value
            target.lbURL_LinkClicked(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void InitializeComponentTest()
        {
            frmAbout_Accessor target = new frmAbout_Accessor(); // TODO: Initialize to an appropriate value
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
            frmAbout_Accessor target = new frmAbout_Accessor(); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for btnProcInfo_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void btnProcInfo_ClickTest()
        {
            frmAbout_Accessor target = new frmAbout_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.btnProcInfo_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for btnOk_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void btnOk_ClickTest()
        {
            frmAbout_Accessor target = new frmAbout_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.btnOk_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for frmAbout Constructor
        ///</summary>
        [TestMethod()]
        public void frmAboutConstructorTest()
        {
            frmAbout target = new frmAbout();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
