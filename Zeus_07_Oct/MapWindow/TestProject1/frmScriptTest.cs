using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;
using System.Windows.Forms;
using System;
using IntellisenseEditor;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for frmScriptTest and is intended
    ///to contain all frmScriptTest Unit Tests
    ///</summary>
    [TestClass()]
    public class frmScriptTest
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
        ///A test for txtScript
        ///</summary>
        [TestMethod()]
        public void txtScriptTest()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            IntellisenseEditor.IntellisenseEditor expected = null; // TODO: Initialize to an appropriate value
            IntellisenseEditor.IntellisenseEditor actual;
            target.txtScript = expected;
            actual = target.txtScript;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TopToolStripPanel
        ///</summary>
        [TestMethod()]
        public void TopToolStripPanelTest()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            ToolStripPanel expected = null; // TODO: Initialize to an appropriate value
            ToolStripPanel actual;
            target.TopToolStripPanel = expected;
            actual = target.TopToolStripPanel;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToolStripMenuItem6
        ///</summary>
        [TestMethod()]
        public void ToolStripMenuItem6Test()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.ToolStripMenuItem6 = expected;
            actual = target.ToolStripMenuItem6;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToolStripMenuItem2
        ///</summary>
        [TestMethod()]
        public void ToolStripMenuItem2Test()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.ToolStripMenuItem2 = expected;
            actual = target.ToolStripMenuItem2;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToolStripMenuItem1
        ///</summary>
        [TestMethod()]
        public void ToolStripMenuItem1Test()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.ToolStripMenuItem1 = expected;
            actual = target.ToolStripMenuItem1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToolStripContainer1
        ///</summary>
        [TestMethod()]
        public void ToolStripContainer1Test()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            ToolStripContainer expected = null; // TODO: Initialize to an appropriate value
            ToolStripContainer actual;
            target.ToolStripContainer1 = expected;
            actual = target.ToolStripContainer1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tools
        ///</summary>
        [TestMethod()]
        public void toolsTest()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            ToolStrip expected = null; // TODO: Initialize to an appropriate value
            ToolStrip actual;
            target.tools = expected;
            actual = target.tools;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tbbsep
        ///</summary>
        [TestMethod()]
        public void tbbsepTest()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            ToolStripSeparator expected = null; // TODO: Initialize to an appropriate value
            ToolStripSeparator actual;
            target.tbbsep = expected;
            actual = target.tbbsep;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tbbSave
        ///</summary>
        [TestMethod()]
        public void tbbSaveTest()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            ToolStripButton expected = null; // TODO: Initialize to an appropriate value
            ToolStripButton actual;
            target.tbbSave = expected;
            actual = target.tbbSave;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tbbRun
        ///</summary>
        [TestMethod()]
        public void tbbRunTest()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            ToolStripButton expected = null; // TODO: Initialize to an appropriate value
            ToolStripButton actual;
            target.tbbRun = expected;
            actual = target.tbbRun;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tbbOpen
        ///</summary>
        [TestMethod()]
        public void tbbOpenTest()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            ToolStripButton expected = null; // TODO: Initialize to an appropriate value
            ToolStripButton actual;
            target.tbbOpen = expected;
            actual = target.tbbOpen;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tbbNew
        ///</summary>
        [TestMethod()]
        public void tbbNewTest()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            ToolStripButton expected = null; // TODO: Initialize to an appropriate value
            ToolStripButton actual;
            target.tbbNew = expected;
            actual = target.tbbNew;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tbbHelp
        ///</summary>
        [TestMethod()]
        public void tbbHelpTest()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            ToolStripButton expected = null; // TODO: Initialize to an appropriate value
            ToolStripButton actual;
            target.tbbHelp = expected;
            actual = target.tbbHelp;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tbbCompile
        ///</summary>
        [TestMethod()]
        public void tbbCompileTest()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            ToolStripButton expected = null; // TODO: Initialize to an appropriate value
            ToolStripButton actual;
            target.tbbCompile = expected;
            actual = target.tbbCompile;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RightToolStripPanel
        ///</summary>
        [TestMethod()]
        public void RightToolStripPanelTest()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            ToolStripPanel expected = null; // TODO: Initialize to an appropriate value
            ToolStripPanel actual;
            target.RightToolStripPanel = expected;
            actual = target.RightToolStripPanel;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for rdVBNet
        ///</summary>
        [TestMethod()]
        public void rdVBNetTest()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            RadioButton expected = null; // TODO: Initialize to an appropriate value
            RadioButton actual;
            target.rdVBNet = expected;
            actual = target.rdVBNet;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for rdScript
        ///</summary>
        [TestMethod()]
        public void rdScriptTest()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            RadioButton expected = null; // TODO: Initialize to an appropriate value
            RadioButton actual;
            target.rdScript = expected;
            actual = target.rdScript;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for rdPlugin
        ///</summary>
        [TestMethod()]
        public void rdPluginTest()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            RadioButton expected = null; // TODO: Initialize to an appropriate value
            RadioButton actual;
            target.rdPlugin = expected;
            actual = target.rdPlugin;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for rdCS
        ///</summary>
        [TestMethod()]
        public void rdCSTest()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            RadioButton expected = null; // TODO: Initialize to an appropriate value
            RadioButton actual;
            target.rdCS = expected;
            actual = target.rdCS;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuViewRun
        ///</summary>
        [TestMethod()]
        public void mnuViewRunTest()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.mnuViewRun = expected;
            actual = target.mnuViewRun;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuSubmit
        ///</summary>
        [TestMethod()]
        public void mnuSubmitTest()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.mnuSubmit = expected;
            actual = target.mnuSubmit;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuSep
        ///</summary>
        [TestMethod()]
        public void mnuSepTest()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            ToolStripSeparator expected = null; // TODO: Initialize to an appropriate value
            ToolStripSeparator actual;
            target.mnuSep = expected;
            actual = target.mnuSep;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuSave
        ///</summary>
        [TestMethod()]
        public void mnuSaveTest()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.mnuSave = expected;
            actual = target.mnuSave;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuRun
        ///</summary>
        [TestMethod()]
        public void mnuRunTest()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.mnuRun = expected;
            actual = target.mnuRun;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuOpen
        ///</summary>
        [TestMethod()]
        public void mnuOpenTest()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.mnuOpen = expected;
            actual = target.mnuOpen;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuNew
        ///</summary>
        [TestMethod()]
        public void mnuNewTest()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.mnuNew = expected;
            actual = target.mnuNew;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuHelp
        ///</summary>
        [TestMethod()]
        public void mnuHelpTest()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.mnuHelp = expected;
            actual = target.mnuHelp;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuCompile
        ///</summary>
        [TestMethod()]
        public void mnuCompileTest()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.mnuCompile = expected;
            actual = target.mnuCompile;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuClose
        ///</summary>
        [TestMethod()]
        public void mnuCloseTest()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.mnuClose = expected;
            actual = target.mnuClose;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MenuStrip1
        ///</summary>
        [TestMethod()]
        public void MenuStrip1Test()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            MenuStrip expected = null; // TODO: Initialize to an appropriate value
            MenuStrip actual;
            target.MenuStrip1 = expected;
            actual = target.MenuStrip1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LeftToolStripPanel
        ///</summary>
        [TestMethod()]
        public void LeftToolStripPanelTest()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            ToolStripPanel expected = null; // TODO: Initialize to an appropriate value
            ToolStripPanel actual;
            target.LeftToolStripPanel = expected;
            actual = target.LeftToolStripPanel;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ImageList1
        ///</summary>
        [TestMethod()]
        public void ImageList1Test()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            ImageList expected = null; // TODO: Initialize to an appropriate value
            ImageList actual;
            target.ImageList1 = expected;
            actual = target.ImageList1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GroupBox2
        ///</summary>
        [TestMethod()]
        public void GroupBox2Test()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            GroupBox expected = null; // TODO: Initialize to an appropriate value
            GroupBox actual;
            target.GroupBox2 = expected;
            actual = target.GroupBox2;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GroupBox1
        ///</summary>
        [TestMethod()]
        public void GroupBox1Test()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            GroupBox expected = null; // TODO: Initialize to an appropriate value
            GroupBox actual;
            target.GroupBox1 = expected;
            actual = target.GroupBox1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ContentPanel
        ///</summary>
        [TestMethod()]
        public void ContentPanelTest()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            ToolStripContentPanel expected = null; // TODO: Initialize to an appropriate value
            ToolStripContentPanel actual;
            target.ContentPanel = expected;
            actual = target.ContentPanel;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BottomToolStripPanel
        ///</summary>
        [TestMethod()]
        public void BottomToolStripPanelTest()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            ToolStripPanel expected = null; // TODO: Initialize to an appropriate value
            ToolStripPanel actual;
            target.BottomToolStripPanel = expected;
            actual = target.BottomToolStripPanel;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for txtScript_TextChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void txtScript_TextChangedTest()
        {
            frmScript_Accessor target = new frmScript_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.txtScript_TextChanged(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for txtScript_KeyDown
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void txtScript_KeyDownTest()
        {
            frmScript_Accessor target = new frmScript_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            KeyEventArgs e = null; // TODO: Initialize to an appropriate value
            target.txtScript_KeyDown(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ToolStripMenuItem4_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ToolStripMenuItem4_ClickTest()
        {
            frmScript_Accessor target = new frmScript_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.ToolStripMenuItem4_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ToolStripMenuItem3_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ToolStripMenuItem3_ClickTest()
        {
            frmScript_Accessor target = new frmScript_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.ToolStripMenuItem3_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ToolStripMenuItem_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ToolStripMenuItem_ClickTest()
        {
            frmScript_Accessor target = new frmScript_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.ToolStripMenuItem_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for tools_ButtonClick
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void tools_ButtonClickTest()
        {
            frmScript_Accessor target = new frmScript_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            ToolStripItemClickedEventArgs e = null; // TODO: Initialize to an appropriate value
            target.tools_ButtonClick(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for RunSavedScript
        ///</summary>
        [TestMethod()]
        public void RunSavedScriptTest()
        {
            frmScript target = new frmScript(); // TODO: Initialize to an appropriate value
            target.RunSavedScript();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for rdLangOrOutput_CheckedChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void rdLangOrOutput_CheckedChangedTest()
        {
            frmScript_Accessor target = new frmScript_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.rdLangOrOutput_CheckedChanged(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PerformAction
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void PerformActionTest()
        {
            frmScript_Accessor target = new frmScript_Accessor(); // TODO: Initialize to an appropriate value
            string action = string.Empty; // TODO: Initialize to an appropriate value
            target.PerformAction(action);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LockWindowUpdate
        ///</summary>
        [TestMethod()]
        public void LockWindowUpdateTest()
        {
            int hWnd = 0; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = frmScript.LockWindowUpdate(hWnd);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Language
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void LanguageTest()
        {
            frmScript_Accessor target = new frmScript_Accessor(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Language();
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
            frmScript_Accessor target = new frmScript_Accessor(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for frmScript_LocationChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void frmScript_LocationChangedTest()
        {
            frmScript_Accessor target = new frmScript_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.frmScript_LocationChanged(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for frmScript_Load
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void frmScript_LoadTest()
        {
            frmScript_Accessor target = new frmScript_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.frmScript_Load(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for frmScript_FormClosing
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void frmScript_FormClosingTest()
        {
            frmScript_Accessor target = new frmScript_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            FormClosingEventArgs e = null; // TODO: Initialize to an appropriate value
            target.frmScript_FormClosing(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for frmScript_DragEnter
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void frmScript_DragEnterTest()
        {
            frmScript_Accessor target = new frmScript_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            DragEventArgs e = null; // TODO: Initialize to an appropriate value
            target.frmScript_DragEnter(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for frmScript_DragDrop
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void frmScript_DragDropTest()
        {
            frmScript_Accessor target = new frmScript_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            DragEventArgs e = null; // TODO: Initialize to an appropriate value
            target.frmScript_DragDrop(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for frmScript_Closing
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void frmScript_ClosingTest()
        {
            frmScript_Accessor target = new frmScript_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            CancelEventArgs e = null; // TODO: Initialize to an appropriate value
            target.frmScript_Closing(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DisposeTest()
        {
            frmScript_Accessor target = new frmScript_Accessor(); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for frmScript Constructor
        ///</summary>
        [TestMethod()]
        public void frmScriptConstructorTest()
        {
            frmScript target = new frmScript();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
