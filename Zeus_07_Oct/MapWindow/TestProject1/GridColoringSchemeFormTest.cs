using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms.Design;
using MapWinGIS;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for GridColoringSchemeFormTest and is intended
    ///to contain all GridColoringSchemeFormTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GridColoringSchemeFormTest
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
        ///A test for ValleyFires
        ///</summary>
        [TestMethod()]
        public void ValleyFiresTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm target = new GridColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.ValleyFires = expected;
            actual = target.ValleyFires;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UniqueValuesToolStripMenuItem
        ///</summary>
        [TestMethod()]
        public void UniqueValuesToolStripMenuItemTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm target = new GridColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.UniqueValuesToolStripMenuItem = expected;
            actual = target.UniqueValuesToolStripMenuItem;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToolStripMenuItem4
        ///</summary>
        [TestMethod()]
        public void ToolStripMenuItem4Test()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm target = new GridColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.ToolStripMenuItem4 = expected;
            actual = target.ToolStripMenuItem4;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToolStrip1
        ///</summary>
        [TestMethod()]
        public void ToolStrip1Test()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm target = new GridColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            ToolStrip expected = null; // TODO: Initialize to an appropriate value
            ToolStrip actual;
            target.ToolStrip1 = expected;
            actual = target.ToolStrip1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tbWizard
        ///</summary>
        [TestMethod()]
        public void tbWizardTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm target = new GridColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            ToolStripDropDownButton expected = null; // TODO: Initialize to an appropriate value
            ToolStripDropDownButton actual;
            target.tbWizard = expected;
            actual = target.tbWizard;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tbRemove
        ///</summary>
        [TestMethod()]
        public void tbRemoveTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm target = new GridColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            ToolStripButton expected = null; // TODO: Initialize to an appropriate value
            ToolStripButton actual;
            target.tbRemove = expected;
            actual = target.tbRemove;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tbMoveUp
        ///</summary>
        [TestMethod()]
        public void tbMoveUpTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm target = new GridColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            ToolStripButton expected = null; // TODO: Initialize to an appropriate value
            ToolStripButton actual;
            target.tbMoveUp = expected;
            actual = target.tbMoveUp;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tbMoveDown
        ///</summary>
        [TestMethod()]
        public void tbMoveDownTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm target = new GridColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            ToolStripButton expected = null; // TODO: Initialize to an appropriate value
            ToolStripButton actual;
            target.tbMoveDown = expected;
            actual = target.tbMoveDown;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tbImport
        ///</summary>
        [TestMethod()]
        public void tbImportTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm target = new GridColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            ToolStripButton expected = null; // TODO: Initialize to an appropriate value
            ToolStripButton actual;
            target.tbImport = expected;
            actual = target.tbImport;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tbExport
        ///</summary>
        [TestMethod()]
        public void tbExportTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm target = new GridColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            ToolStripButton expected = null; // TODO: Initialize to an appropriate value
            ToolStripButton actual;
            target.tbExport = expected;
            actual = target.tbExport;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tbAdd
        ///</summary>
        [TestMethod()]
        public void tbAddTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm target = new GridColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            ToolStripButton expected = null; // TODO: Initialize to an appropriate value
            ToolStripButton actual;
            target.tbAdd = expected;
            actual = target.tbAdd;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SummerMountains
        ///</summary>
        [TestMethod()]
        public void SummerMountainsTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm target = new GridColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.SummerMountains = expected;
            actual = target.SummerMountains;
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
            GridColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm target = new GridColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            GridColorScheme actual;
            actual = target.Retval;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Meadow
        ///</summary>
        [TestMethod()]
        public void MeadowTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm target = new GridColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.Meadow = expected;
            actual = target.Meadow;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for lblGradientStyle
        ///</summary>
        [TestMethod()]
        public void lblGradientStyleTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm target = new GridColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.lblGradientStyle = expected;
            actual = target.lblGradientStyle;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Label2
        ///</summary>
        [TestMethod()]
        public void Label2Test()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm target = new GridColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
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
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm target = new GridColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.Label1 = expected;
            actual = target.Label1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ImageList1
        ///</summary>
        [TestMethod()]
        public void ImageList1Test()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm target = new GridColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            ImageList expected = null; // TODO: Initialize to an appropriate value
            ImageList actual;
            target.ImageList1 = expected;
            actual = target.ImageList1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Highway
        ///</summary>
        [TestMethod()]
        public void HighwayTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm target = new GridColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.Highway = expected;
            actual = target.Highway;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Glaciers
        ///</summary>
        [TestMethod()]
        public void GlaciersTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm target = new GridColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.Glaciers = expected;
            actual = target.Glaciers;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FallLeaves
        ///</summary>
        [TestMethod()]
        public void FallLeavesTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm target = new GridColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.FallLeaves = expected;
            actual = target.FallLeaves;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EqualBreaksToolStripMenuItem
        ///</summary>
        [TestMethod()]
        public void EqualBreaksToolStripMenuItemTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm target = new GridColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.EqualBreaksToolStripMenuItem = expected;
            actual = target.EqualBreaksToolStripMenuItem;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Desert
        ///</summary>
        [TestMethod()]
        public void DesertTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm target = new GridColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.Desert = expected;
            actual = target.Desert;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DeadSea
        ///</summary>
        [TestMethod()]
        public void DeadSeaTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm target = new GridColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.DeadSea = expected;
            actual = target.DeadSea;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ContinuousRampToolStripMenuItem
        ///</summary>
        [TestMethod()]
        public void ContinuousRampToolStripMenuItemTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm target = new GridColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.ContinuousRampToolStripMenuItem = expected;
            actual = target.ContinuousRampToolStripMenuItem;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ColoringSchemeViewer1
        ///</summary>
        [TestMethod()]
        public void ColoringSchemeViewer1Test()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm target = new GridColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            ColoringSchemeViewer expected = null; // TODO: Initialize to an appropriate value
            ColoringSchemeViewer actual;
            target.ColoringSchemeViewer1 = expected;
            actual = target.ColoringSchemeViewer1;
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
            GridColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm target = new GridColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
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
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm target = new GridColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
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
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm target = new GridColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.cmdApply = expected;
            actual = target.cmdApply;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for cmbNumberFormat
        ///</summary>
        [TestMethod()]
        public void cmbNumberFormatTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm target = new GridColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            ComboBox expected = null; // TODO: Initialize to an appropriate value
            ComboBox actual;
            target.cmbNumberFormat = expected;
            actual = target.cmbNumberFormat;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for cmbGradientStyle
        ///</summary>
        [TestMethod()]
        public void cmbGradientStyleTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm target = new GridColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            ComboBox expected = null; // TODO: Initialize to an appropriate value
            ComboBox actual;
            target.cmbGradientStyle = expected;
            actual = target.cmbGradientStyle;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for chkComputeHillshade
        ///</summary>
        [TestMethod()]
        public void chkComputeHillshadeTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm target = new GridColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            CheckBox expected = null; // TODO: Initialize to an appropriate value
            CheckBox actual;
            target.chkComputeHillshade = expected;
            actual = target.chkComputeHillshade;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for btnAdvanced
        ///</summary>
        [TestMethod()]
        public void btnAdvancedTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm target = new GridColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.btnAdvanced = expected;
            actual = target.btnAdvanced;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ValleyFires_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ValleyFires_ClickTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm_Accessor target = new GridColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.ValleyFires_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ToolStrip1_ButtonClick
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ToolStrip1_ButtonClickTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm_Accessor target = new GridColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            ToolStripItemClickedEventArgs e = null; // TODO: Initialize to an appropriate value
            target.ToolStrip1_ButtonClick(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for tbbMoveUp_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void tbbMoveUp_ClickTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm_Accessor target = new GridColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.tbbMoveUp_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for tbbMoveDown_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void tbbMoveDown_ClickTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm_Accessor target = new GridColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.tbbMoveDown_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SummerMountains_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void SummerMountains_ClickTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm_Accessor target = new GridColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.SummerMountains_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetDefaultScheme
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void SetDefaultSchemeTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm_Accessor target = new GridColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            PredefinedColorScheme Value = new PredefinedColorScheme(); // TODO: Initialize to an appropriate value
            target.SetDefaultScheme(Value);
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
            GridColoringSchemeForm_Accessor target = new GridColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            target.PopulateComboBoxes();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Meadow_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void Meadow_ClickTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm_Accessor target = new GridColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.Meadow_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MakeEqualBreaks
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void MakeEqualBreaksTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm_Accessor target = new GridColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            int numDesired = 0; // TODO: Initialize to an appropriate value
            target.MakeEqualBreaks(numDesired);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MakeContinuousRamp
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void MakeContinuousRampTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm_Accessor target = new GridColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            int numDesired = 0; // TODO: Initialize to an appropriate value
            Color StartColor = new Color(); // TODO: Initialize to an appropriate value
            Color EndColor = new Color(); // TODO: Initialize to an appropriate value
            target.MakeContinuousRamp(numDesired, StartColor, EndColor);
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
            GridColoringSchemeForm_Accessor target = new GridColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Highway_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void Highway_ClickTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm_Accessor target = new GridColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.Highway_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Glaciers_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void Glaciers_ClickTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm_Accessor target = new GridColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.Glaciers_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetUniqueBreaks
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void GetUniqueBreaksTest1()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm_Accessor target = new GridColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.GetUniqueBreaks();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetUniqueBreaks
        ///</summary>
        [TestMethod()]
        public void GetUniqueBreaksTest()
        {
            Grid grd = null; // TODO: Initialize to an appropriate value
            Grid grdExpected = null; // TODO: Initialize to an appropriate value
            bool Silent = false; // TODO: Initialize to an appropriate value
            GridColorScheme ColorScheme = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColorSchemeExpected = null; // TODO: Initialize to an appropriate value
            GradientModel gradientModel = new GradientModel(); // TODO: Initialize to an appropriate value
            ColoringType coloringType = new ColoringType(); // TODO: Initialize to an appropriate value
            string NumberFormat = string.Empty; // TODO: Initialize to an appropriate value
            int Precision = 0; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = GridColoringSchemeForm.GetUniqueBreaks(ref grd, Silent, ref ColorScheme, gradientModel, coloringType, NumberFormat, Precision);
            Assert.AreEqual(grdExpected, grd);
            Assert.AreEqual(ColorSchemeExpected, ColorScheme);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FallLeaves_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void FallLeaves_ClickTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm_Accessor target = new GridColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.FallLeaves_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for EqualValues_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void EqualValues_ClickTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm_Accessor target = new GridColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.EqualValues_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for EqualBreaks_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void EqualBreaks_ClickTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm_Accessor target = new GridColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.EqualBreaks_Click(sender, e);
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
            GridColoringSchemeForm_Accessor target = new GridColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Desert_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void Desert_ClickTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm_Accessor target = new GridColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.Desert_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DeadSea_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DeadSea_ClickTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm_Accessor target = new GridColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.DeadSea_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DataChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DataChangedTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm_Accessor target = new GridColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            target.DataChanged();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CopyScheme
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void CopySchemeTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm_Accessor target = new GridColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            GridColorScheme Original = null; // TODO: Initialize to an appropriate value
            GridColorScheme NewScheme = null; // TODO: Initialize to an appropriate value
            GridColorScheme NewSchemeExpected = null; // TODO: Initialize to an appropriate value
            target.CopyScheme(Original, ref NewScheme);
            Assert.AreEqual(NewSchemeExpected, NewScheme);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ContinuousRamp_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ContinuousRamp_ClickTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm_Accessor target = new GridColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.ContinuousRamp_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ColoringSchemeViewer1_DataChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ColoringSchemeViewer1_DataChangedTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm_Accessor target = new GridColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            target.ColoringSchemeViewer1_DataChanged();
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
            GridColoringSchemeForm_Accessor target = new GridColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
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
            GridColoringSchemeForm_Accessor target = new GridColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
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
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm_Accessor target = new GridColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.cmdCancel_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for cmdApply_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void cmdApply_ClickTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm_Accessor target = new GridColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.cmdApply_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for cmbNumberFormat_SelectedIndexChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void cmbNumberFormat_SelectedIndexChangedTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm_Accessor target = new GridColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.cmbNumberFormat_SelectedIndexChanged(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for cmbGradientStyle_SelectedIndexChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void cmbGradientStyle_SelectedIndexChangedTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm_Accessor target = new GridColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.cmbGradientStyle_SelectedIndexChanged(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for chkComputeHillshade_CheckedChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void chkComputeHillshade_CheckedChangedTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm_Accessor target = new GridColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.chkComputeHillshade_CheckedChanged(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ApplyChanges
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ApplyChangesTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm_Accessor target = new GridColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            target.ApplyChanges();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GridColoringSchemeForm Constructor
        ///</summary>
        [TestMethod()]
        public void GridColoringSchemeFormConstructorTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            GridColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            GridColoringSchemeForm target = new GridColoringSchemeForm(DialogProvider, ColoringScheme);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
