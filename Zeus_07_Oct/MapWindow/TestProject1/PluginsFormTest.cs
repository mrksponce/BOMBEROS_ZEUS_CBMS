using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for PluginsFormTest and is intended
    ///to contain all PluginsFormTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PluginsFormTest
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
        ///A test for rtbPluginInfo
        ///</summary>
        [TestMethod()]
        public void rtbPluginInfoTest()
        {
            PluginsForm target = new PluginsForm(); // TODO: Initialize to an appropriate value
            RichTextBox expected = null; // TODO: Initialize to an appropriate value
            RichTextBox actual;
            target.rtbPluginInfo = expected;
            actual = target.rtbPluginInfo;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for lstPlugins
        ///</summary>
        [TestMethod()]
        public void lstPluginsTest()
        {
            PluginsForm target = new PluginsForm(); // TODO: Initialize to an appropriate value
            CheckedListBox expected = null; // TODO: Initialize to an appropriate value
            CheckedListBox actual;
            target.lstPlugins = expected;
            actual = target.lstPlugins;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Label3
        ///</summary>
        [TestMethod()]
        public void Label3Test()
        {
            PluginsForm target = new PluginsForm(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.Label3 = expected;
            actual = target.Label3;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GroupBox1
        ///</summary>
        [TestMethod()]
        public void GroupBox1Test()
        {
            PluginsForm target = new PluginsForm(); // TODO: Initialize to an appropriate value
            GroupBox expected = null; // TODO: Initialize to an appropriate value
            GroupBox actual;
            target.GroupBox1 = expected;
            actual = target.GroupBox1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for cmdOK
        ///</summary>
        [TestMethod()]
        public void cmdOKTest()
        {
            PluginsForm target = new PluginsForm(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.cmdOK = expected;
            actual = target.cmdOK;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for cmdCancel
        ///</summary>
        [TestMethod()]
        public void cmdCancelTest()
        {
            PluginsForm target = new PluginsForm(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.cmdCancel = expected;
            actual = target.cmdCancel;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for cmdApply
        ///</summary>
        [TestMethod()]
        public void cmdApplyTest()
        {
            PluginsForm target = new PluginsForm(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.cmdApply = expected;
            actual = target.cmdApply;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for chkRemember
        ///</summary>
        [TestMethod()]
        public void chkRememberTest()
        {
            PluginsForm target = new PluginsForm(); // TODO: Initialize to an appropriate value
            CheckBox expected = null; // TODO: Initialize to an appropriate value
            CheckBox actual;
            target.chkRemember = expected;
            actual = target.chkRemember;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for cDlg
        ///</summary>
        [TestMethod()]
        public void cDlgTest()
        {
            PluginsForm target = new PluginsForm(); // TODO: Initialize to an appropriate value
            OpenFileDialog expected = null; // TODO: Initialize to an appropriate value
            OpenFileDialog actual;
            target.cDlg = expected;
            actual = target.cDlg;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for btnTurnAllOn
        ///</summary>
        [TestMethod()]
        public void btnTurnAllOnTest()
        {
            PluginsForm target = new PluginsForm(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.btnTurnAllOn = expected;
            actual = target.btnTurnAllOn;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for btnTurnAllOff
        ///</summary>
        [TestMethod()]
        public void btnTurnAllOffTest()
        {
            PluginsForm target = new PluginsForm(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.btnTurnAllOff = expected;
            actual = target.btnTurnAllOff;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for btnRefreshList
        ///</summary>
        [TestMethod()]
        public void btnRefreshListTest()
        {
            PluginsForm target = new PluginsForm(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.btnRefreshList = expected;
            actual = target.btnRefreshList;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for txtPluginFile_KeyDown
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void txtPluginFile_KeyDownTest()
        {
            PluginsForm_Accessor target = new PluginsForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            KeyEventArgs e = null; // TODO: Initialize to an appropriate value
            target.txtPluginFile_KeyDown(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PluginsForm_Load
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void PluginsForm_LoadTest()
        {
            PluginsForm_Accessor target = new PluginsForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.PluginsForm_Load(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for lstPlugins_SelectedIndexChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void lstPlugins_SelectedIndexChangedTest()
        {
            PluginsForm_Accessor target = new PluginsForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.lstPlugins_SelectedIndexChanged(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for lstPlugins_ItemCheck
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void lstPlugins_ItemCheckTest()
        {
            PluginsForm_Accessor target = new PluginsForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            ItemCheckEventArgs e = null; // TODO: Initialize to an appropriate value
            target.lstPlugins_ItemCheck(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadListBox
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void LoadListBoxTest()
        {
            PluginsForm_Accessor target = new PluginsForm_Accessor(); // TODO: Initialize to an appropriate value
            target.LoadListBox();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadForm
        ///</summary>
        [TestMethod()]
        public void LoadFormTest()
        {
            PluginsForm target = new PluginsForm(); // TODO: Initialize to an appropriate value
            target.LoadForm();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void InitializeComponentTest()
        {
            PluginsForm_Accessor target = new PluginsForm_Accessor(); // TODO: Initialize to an appropriate value
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
            PluginsForm_Accessor target = new PluginsForm_Accessor(); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DisplayPluginProperty
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DisplayPluginPropertyTest()
        {
            PluginsForm_Accessor target = new PluginsForm_Accessor(); // TODO: Initialize to an appropriate value
            string PropertyName = string.Empty; // TODO: Initialize to an appropriate value
            string PropertyValue = string.Empty; // TODO: Initialize to an appropriate value
            target.DisplayPluginProperty(PropertyName, PropertyValue);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DisplayPluginInfo
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DisplayPluginInfoTest()
        {
            PluginsForm_Accessor target = new PluginsForm_Accessor(); // TODO: Initialize to an appropriate value
            int PluginIndex = 0; // TODO: Initialize to an appropriate value
            target.DisplayPluginInfo(PluginIndex);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for cmdOK_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void cmdOK_ClickTest()
        {
            PluginsForm_Accessor target = new PluginsForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.cmdOK_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for cmdCancel_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void cmdCancel_ClickTest()
        {
            PluginsForm_Accessor target = new PluginsForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.cmdCancel_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for cmdBrowseFile_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void cmdBrowseFile_ClickTest()
        {
            PluginsForm_Accessor target = new PluginsForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.cmdBrowseFile_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for cmdApply_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void cmdApply_ClickTest()
        {
            PluginsForm_Accessor target = new PluginsForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.cmdApply_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for btnTurnAllOn_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void btnTurnAllOn_ClickTest()
        {
            PluginsForm_Accessor target = new PluginsForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.btnTurnAllOn_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for btnTurnAllOff_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void btnTurnAllOff_ClickTest()
        {
            PluginsForm_Accessor target = new PluginsForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.btnTurnAllOff_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for btnRefreshList_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void btnRefreshList_ClickTest()
        {
            PluginsForm_Accessor target = new PluginsForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.btnRefreshList_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PluginsForm Constructor
        ///</summary>
        [TestMethod()]
        public void PluginsFormConstructorTest()
        {
            PluginsForm target = new PluginsForm();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
