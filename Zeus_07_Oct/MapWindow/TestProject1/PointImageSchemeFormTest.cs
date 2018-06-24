using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms.Design;
using System;
using System.Windows.Forms;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for PointImageSchemeFormTest and is intended
    ///to contain all PointImageSchemeFormTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PointImageSchemeFormTest
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
        ///A test for WizardMenu
        ///</summary>
        [TestMethod()]
        public void WizardMenuTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            PointImageScheme Scheme = null; // TODO: Initialize to an appropriate value
            PointImageSchemeForm target = new PointImageSchemeForm(DialogProvider, Scheme); // TODO: Initialize to an appropriate value
            ContextMenuStrip expected = null; // TODO: Initialize to an appropriate value
            ContextMenuStrip actual;
            target.WizardMenu = expected;
            actual = target.WizardMenu;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Retval
        ///</summary>
        [TestMethod()]
        public void RetvalTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            PointImageScheme Scheme = null; // TODO: Initialize to an appropriate value
            PointImageSchemeForm target = new PointImageSchemeForm(DialogProvider, Scheme); // TODO: Initialize to an appropriate value
            PointImageScheme actual;
            actual = target.Retval;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuUniqueValues
        ///</summary>
        [TestMethod()]
        public void mnuUniqueValuesTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            PointImageScheme Scheme = null; // TODO: Initialize to an appropriate value
            PointImageSchemeForm target = new PointImageSchemeForm(DialogProvider, Scheme); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.mnuUniqueValues = expected;
            actual = target.mnuUniqueValues;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuEqualBreaks
        ///</summary>
        [TestMethod()]
        public void mnuEqualBreaksTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            PointImageScheme Scheme = null; // TODO: Initialize to an appropriate value
            PointImageSchemeForm target = new PointImageSchemeForm(DialogProvider, Scheme); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.mnuEqualBreaks = expected;
            actual = target.mnuEqualBreaks;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuContinuousRamp
        ///</summary>
        [TestMethod()]
        public void mnuContinuousRampTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            PointImageScheme Scheme = null; // TODO: Initialize to an appropriate value
            PointImageSchemeForm target = new PointImageSchemeForm(DialogProvider, Scheme); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.mnuContinuousRamp = expected;
            actual = target.mnuContinuousRamp;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for lblField
        ///</summary>
        [TestMethod()]
        public void lblFieldTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            PointImageScheme Scheme = null; // TODO: Initialize to an appropriate value
            PointImageSchemeForm target = new PointImageSchemeForm(DialogProvider, Scheme); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.lblField = expected;
            actual = target.lblField;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Label1
        ///</summary>
        [TestMethod()]
        public void Label1Test()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            PointImageScheme Scheme = null; // TODO: Initialize to an appropriate value
            PointImageSchemeForm target = new PointImageSchemeForm(DialogProvider, Scheme); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.Label1 = expected;
            actual = target.Label1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for itms
        ///</summary>
        [TestMethod()]
        public void itmsTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            PointImageScheme Scheme = null; // TODO: Initialize to an appropriate value
            PointImageSchemeForm target = new PointImageSchemeForm(DialogProvider, Scheme); // TODO: Initialize to an appropriate value
            TableLayoutPanel expected = null; // TODO: Initialize to an appropriate value
            TableLayoutPanel actual;
            target.itms = expected;
            actual = target.itms;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for System.Drawing.ImageList1
        ///</summary>
        [TestMethod()]
        public void ImageList1Test()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            PointImageScheme Scheme = null; // TODO: Initialize to an appropriate value
            PointImageSchemeForm target = new PointImageSchemeForm(DialogProvider, Scheme); // TODO: Initialize to an appropriate value
            ImageList expected = null; // TODO: Initialize to an appropriate value
            ImageList actual;
            target.ImageList1 = expected;
            actual = target.ImageList1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for cmdOK
        ///</summary>
        [TestMethod()]
        public void cmdOKTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            PointImageScheme Scheme = null; // TODO: Initialize to an appropriate value
            PointImageSchemeForm target = new PointImageSchemeForm(DialogProvider, Scheme); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.cmdOK = expected;
            actual = target.cmdOK;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for cmdClear
        ///</summary>
        [TestMethod()]
        public void cmdClearTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            PointImageScheme Scheme = null; // TODO: Initialize to an appropriate value
            PointImageSchemeForm target = new PointImageSchemeForm(DialogProvider, Scheme); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.cmdClear = expected;
            actual = target.cmdClear;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for cmdCancel
        ///</summary>
        [TestMethod()]
        public void cmdCancelTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            PointImageScheme Scheme = null; // TODO: Initialize to an appropriate value
            PointImageSchemeForm target = new PointImageSchemeForm(DialogProvider, Scheme); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.cmdCancel = expected;
            actual = target.cmdCancel;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for cmbField
        ///</summary>
        [TestMethod()]
        public void cmbFieldTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            PointImageScheme Scheme = null; // TODO: Initialize to an appropriate value
            PointImageSchemeForm target = new PointImageSchemeForm(DialogProvider, Scheme); // TODO: Initialize to an appropriate value
            ComboBox expected = null; // TODO: Initialize to an appropriate value
            ComboBox actual;
            target.cmbField = expected;
            actual = target.cmbField;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SelectItem
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void SelectItemTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            PointImageSchemeForm_Accessor target = new PointImageSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.SelectItem(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PopulateComboBoxes
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void PopulateComboBoxesTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            PointImageSchemeForm_Accessor target = new PointImageSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            target.PopulateComboBoxes();
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
            PointImageSchemeForm_Accessor target = new PointImageSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
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
            PointImageSchemeForm_Accessor target = new PointImageSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ColoringSchemeForm_Load
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ColoringSchemeForm_LoadTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            PointImageSchemeForm_Accessor target = new PointImageSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.ColoringSchemeForm_Load(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for cmdOK_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void cmdOK_ClickTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            PointImageSchemeForm_Accessor target = new PointImageSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.cmdOK_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for cmbField_SelectedIndexChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void cmbField_SelectedIndexChangedTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            PointImageSchemeForm_Accessor target = new PointImageSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.cmbField_SelectedIndexChanged(sender, e);
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
            PointImageSchemeForm_Accessor target = new PointImageSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.Button1_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PointImageSchemeForm Constructor
        ///</summary>
        [TestMethod()]
        public void PointImageSchemeFormConstructorTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            PointImageScheme Scheme = null; // TODO: Initialize to an appropriate value
            PointImageSchemeForm target = new PointImageSchemeForm(DialogProvider, Scheme);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
