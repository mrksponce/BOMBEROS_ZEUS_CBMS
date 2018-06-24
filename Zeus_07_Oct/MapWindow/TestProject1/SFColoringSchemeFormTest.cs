using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms.Design;
using MapWinGIS;
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for SFColoringSchemeFormTest and is intended
    ///to contain all SFColoringSchemeFormTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SFColoringSchemeFormTest
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
            ShapefileColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm target = new SFColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            ContextMenuStrip expected = null; // TODO: Initialize to an appropriate value
            ContextMenuStrip actual;
            target.WizardMenu = expected;
            actual = target.WizardMenu;
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
            ShapefileColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm target = new SFColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
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
            ShapefileColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm target = new SFColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            ToolStripDropDownButton expected = null; // TODO: Initialize to an appropriate value
            ToolStripDropDownButton actual;
            target.tbWizard = expected;
            actual = target.tbWizard;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tbSub
        ///</summary>
        [TestMethod()]
        public void tbSubTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            ShapefileColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm target = new SFColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            ToolStripButton expected = null; // TODO: Initialize to an appropriate value
            ToolStripButton actual;
            target.tbSub = expected;
            actual = target.tbSub;
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
            ShapefileColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm target = new SFColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
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
            ShapefileColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm target = new SFColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            ToolStripButton expected = null; // TODO: Initialize to an appropriate value
            ToolStripButton actual;
            target.tbExport = expected;
            actual = target.tbExport;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tbbMoveUp
        ///</summary>
        [TestMethod()]
        public void tbbMoveUpTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            ShapefileColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm target = new SFColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            ToolStripButton expected = null; // TODO: Initialize to an appropriate value
            ToolStripButton actual;
            target.tbbMoveUp = expected;
            actual = target.tbbMoveUp;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tbbMoveDown
        ///</summary>
        [TestMethod()]
        public void tbbMoveDownTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            ShapefileColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm target = new SFColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            ToolStripButton expected = null; // TODO: Initialize to an appropriate value
            ToolStripButton actual;
            target.tbbMoveDown = expected;
            actual = target.tbbMoveDown;
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
            ShapefileColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm target = new SFColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            ToolStripButton expected = null; // TODO: Initialize to an appropriate value
            ToolStripButton actual;
            target.tbAdd = expected;
            actual = target.tbAdd;
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
            ShapefileColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm target = new SFColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            ShapefileColorScheme actual;
            actual = target.Retval;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RangeColors
        ///</summary>
        [TestMethod()]
        public void RangeColorsTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            ShapefileColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm target = new SFColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            RangeBar expected = null; // TODO: Initialize to an appropriate value
            RangeBar actual;
            target.RangeColors = expected;
            actual = target.RangeColors;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PanelRange
        ///</summary>
        [TestMethod()]
        public void PanelRangeTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            ShapefileColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm target = new SFColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            Panel expected = null; // TODO: Initialize to an appropriate value
            Panel actual;
            target.PanelRange = expected;
            actual = target.PanelRange;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuUniqueValues
        ///</summary>
        [TestMethod()]
        public void mnuUniqueValuesTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            ShapefileColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm target = new SFColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
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
            ShapefileColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm target = new SFColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
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
            ShapefileColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm target = new SFColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
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
            ShapefileColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm target = new SFColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
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
            ShapefileColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm target = new SFColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.Label1 = expected;
            actual = target.Label1;
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
            ShapefileColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm target = new SFColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            ImageList expected = null; // TODO: Initialize to an appropriate value
            ImageList actual;
            target.ImageList1 = expected;
            actual = target.ImageList1;
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
            ShapefileColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm target = new SFColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
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
            ShapefileColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm target = new SFColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
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
            ShapefileColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm target = new SFColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
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
            ShapefileColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm target = new SFColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
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
            ShapefileColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm target = new SFColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            ComboBox expected = null; // TODO: Initialize to an appropriate value
            ComboBox actual;
            target.cmbNumberFormat = expected;
            actual = target.cmbNumberFormat;
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
            ShapefileColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm target = new SFColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            ComboBox expected = null; // TODO: Initialize to an appropriate value
            ComboBox actual;
            target.cmbField = expected;
            actual = target.cmbField;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for chkPreview
        ///</summary>
        [TestMethod()]
        public void chkPreviewTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            ShapefileColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm target = new SFColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            CheckBox expected = null; // TODO: Initialize to an appropriate value
            CheckBox actual;
            target.chkPreview = expected;
            actual = target.chkPreview;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for btnClearBreaks
        ///</summary>
        [TestMethod()]
        public void btnClearBreaksTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            ShapefileColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm target = new SFColoringSchemeForm(DialogProvider, ColoringScheme); // TODO: Initialize to an appropriate value
            ToolStripButton expected = null; // TODO: Initialize to an appropriate value
            ToolStripButton actual;
            target.btnClearBreaks = expected;
            actual = target.btnClearBreaks;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToolStrip1_ButtonClick
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ToolStrip1_ButtonClickTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm_Accessor target = new SFColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
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
            SFColoringSchemeForm_Accessor target = new SFColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
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
            SFColoringSchemeForm_Accessor target = new SFColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.tbbMoveDown_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for RangeFromScheme
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void RangeFromSchemeTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm_Accessor target = new SFColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            target.RangeFromScheme();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for RangeColors_UserDraggingHandle
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void RangeColors_UserDraggingHandleTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm_Accessor target = new SFColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            int aHandle = 0; // TODO: Initialize to an appropriate value
            double aValue = 0F; // TODO: Initialize to an appropriate value
            target.RangeColors_UserDraggingHandle(aHandle, aValue);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for RangeColors_UserDraggedHandle
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void RangeColors_UserDraggedHandleTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm_Accessor target = new SFColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            int aHandle = 0; // TODO: Initialize to an appropriate value
            double aValue = 0F; // TODO: Initialize to an appropriate value
            target.RangeColors_UserDraggedHandle(aHandle, aValue);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Preview
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void PreviewTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm_Accessor target = new SFColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            target.Preview();
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
            SFColoringSchemeForm_Accessor target = new SFColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            target.PopulateComboBoxes();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mnuUniqueValues_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void mnuUniqueValues_ClickTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm_Accessor target = new SFColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.mnuUniqueValues_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mnuEqualBreaks_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void mnuEqualBreaks_ClickTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm_Accessor target = new SFColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.mnuEqualBreaks_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mnuContinuousRamp_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void mnuContinuousRamp_ClickTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm_Accessor target = new SFColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.mnuContinuousRamp_Click(sender, e);
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
            SFColoringSchemeForm_Accessor target = new SFColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
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
            SFColoringSchemeForm_Accessor target = new SFColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
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
            SFColoringSchemeForm_Accessor target = new SFColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetUniqueBreaks
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void GetUniqueBreaksTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm_Accessor target = new SFColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.GetUniqueBreaks();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for getRandomColor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void getRandomColorTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm_Accessor target = new SFColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            Hashtable usedColors = null; // TODO: Initialize to an appropriate value
            Hashtable usedColorsExpected = null; // TODO: Initialize to an appropriate value
            uint expected = 0; // TODO: Initialize to an appropriate value
            uint actual;
            actual = target.getRandomColor(ref usedColors);
            Assert.AreEqual(usedColorsExpected, usedColors);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetFieldValues
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void GetFieldValuesTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm_Accessor target = new SFColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            double[] expected = null; // TODO: Initialize to an appropriate value
            double[] actual;
            actual = target.GetFieldValues();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetFieldMinMax
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void GetFieldMinMaxTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm_Accessor target = new SFColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object Min = null; // TODO: Initialize to an appropriate value
            object MinExpected = null; // TODO: Initialize to an appropriate value
            object Max = null; // TODO: Initialize to an appropriate value
            object MaxExpected = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.GetFieldMinMax(ref Min, ref Max);
            Assert.AreEqual(MinExpected, Min);
            Assert.AreEqual(MaxExpected, Max);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DisposeTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm_Accessor target = new SFColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
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
            SFColoringSchemeForm_Accessor target = new SFColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
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
            SFColoringSchemeForm_Accessor target = new SFColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            ShapefileColorScheme Original = null; // TODO: Initialize to an appropriate value
            ShapefileColorScheme NewScheme = null; // TODO: Initialize to an appropriate value
            ShapefileColorScheme NewSchemeExpected = null; // TODO: Initialize to an appropriate value
            target.CopyScheme(Original, ref NewScheme);
            Assert.AreEqual(NewSchemeExpected, NewScheme);
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
            SFColoringSchemeForm_Accessor target = new SFColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
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
            SFColoringSchemeForm_Accessor target = new SFColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
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
            SFColoringSchemeForm_Accessor target = new SFColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.cmdOK_Click(sender, e);
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
            SFColoringSchemeForm_Accessor target = new SFColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
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
            SFColoringSchemeForm_Accessor target = new SFColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.cmbNumberFormat_SelectedIndexChanged(sender, e);
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
            SFColoringSchemeForm_Accessor target = new SFColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.cmbField_SelectedIndexChanged(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for chkPreview_CheckedChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void chkPreview_CheckedChangedTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm_Accessor target = new SFColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.chkPreview_CheckedChanged(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for btnClearBreaks_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void btnClearBreaks_ClickTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm_Accessor target = new SFColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.btnClearBreaks_Click(sender, e);
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
            SFColoringSchemeForm_Accessor target = new SFColoringSchemeForm_Accessor(param0); // TODO: Initialize to an appropriate value
            target.ApplyChanges();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SFColoringSchemeForm Constructor
        ///</summary>
        [TestMethod()]
        public void SFColoringSchemeFormConstructorTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            ShapefileColorScheme ColoringScheme = null; // TODO: Initialize to an appropriate value
            SFColoringSchemeForm target = new SFColoringSchemeForm(DialogProvider, ColoringScheme);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
