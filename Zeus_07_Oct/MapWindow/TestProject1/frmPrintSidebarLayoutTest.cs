using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for frmPrintSidebarLayoutTest and is intended
    ///to contain all frmPrintSidebarLayoutTest Unit Tests
    ///</summary>
    [TestClass()]
    public class frmPrintSidebarLayoutTest
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
        ///A test for txtTitle
        ///</summary>
        [TestMethod()]
        public void txtTitleTest()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            TextBox expected = null; // TODO: Initialize to an appropriate value
            TextBox actual;
            target.txtTitle = expected;
            actual = target.txtTitle;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TextBox1
        ///</summary>
        [TestMethod()]
        public void TextBox1Test()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            TextBox expected = null; // TODO: Initialize to an appropriate value
            TextBox actual;
            target.TextBox1 = expected;
            actual = target.TextBox1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PrintPreviewDialog1
        ///</summary>
        [TestMethod()]
        public void PrintPreviewDialog1Test()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            PrintPreviewDialog expected = null; // TODO: Initialize to an appropriate value
            PrintPreviewDialog actual;
            target.PrintPreviewDialog1 = expected;
            actual = target.PrintPreviewDialog1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PrintPreviewDialog
        ///</summary>
        [TestMethod()]
        public void PrintPreviewDialogTest()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            PrintPreviewDialog expected = null; // TODO: Initialize to an appropriate value
            PrintPreviewDialog actual;
            target.PrintPreviewDialog = expected;
            actual = target.PrintPreviewDialog;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PrintDocument1
        ///</summary>
        [TestMethod()]
        public void PrintDocument1Test()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            PrintDocument expected = null; // TODO: Initialize to an appropriate value
            PrintDocument actual;
            target.PrintDocument1 = expected;
            actual = target.PrintDocument1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PrintDialog
        ///</summary>
        [TestMethod()]
        public void PrintDialogTest()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            PrintDialog expected = null; // TODO: Initialize to an appropriate value
            PrintDialog actual;
            target.PrintDialog = expected;
            actual = target.PrintDialog;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for pnlSbForeColor
        ///</summary>
        [TestMethod()]
        public void pnlSbForeColorTest()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            Panel expected = null; // TODO: Initialize to an appropriate value
            Panel actual;
            target.pnlSbForeColor = expected;
            actual = target.pnlSbForeColor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for pnlSbBackColor
        ///</summary>
        [TestMethod()]
        public void pnlSbBackColorTest()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            Panel expected = null; // TODO: Initialize to an appropriate value
            Panel actual;
            target.pnlSbBackColor = expected;
            actual = target.pnlSbBackColor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for nudTotalSections
        ///</summary>
        [TestMethod()]
        public void nudTotalSectionsTest()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            NumericUpDown expected = null; // TODO: Initialize to an appropriate value
            NumericUpDown actual;
            target.nudTotalSections = expected;
            actual = target.nudTotalSections;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for nudSbSections
        ///</summary>
        [TestMethod()]
        public void nudSbSectionsTest()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            NumericUpDown expected = null; // TODO: Initialize to an appropriate value
            NumericUpDown actual;
            target.nudSbSections = expected;
            actual = target.nudSbSections;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for nudSbHeight
        ///</summary>
        [TestMethod()]
        public void nudSbHeightTest()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            NumericUpDown expected = null; // TODO: Initialize to an appropriate value
            NumericUpDown actual;
            target.nudSbHeight = expected;
            actual = target.nudSbHeight;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for nudMapSections
        ///</summary>
        [TestMethod()]
        public void nudMapSectionsTest()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            NumericUpDown expected = null; // TODO: Initialize to an appropriate value
            NumericUpDown actual;
            target.nudMapSections = expected;
            actual = target.nudMapSections;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for nudLegendSections
        ///</summary>
        [TestMethod()]
        public void nudLegendSectionsTest()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            NumericUpDown expected = null; // TODO: Initialize to an appropriate value
            NumericUpDown actual;
            target.nudLegendSections = expected;
            actual = target.nudLegendSections;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for nudLegendColumns
        ///</summary>
        [TestMethod()]
        public void nudLegendColumnsTest()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            NumericUpDown expected = null; // TODO: Initialize to an appropriate value
            NumericUpDown actual;
            target.nudLegendColumns = expected;
            actual = target.nudLegendColumns;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Label8
        ///</summary>
        [TestMethod()]
        public void Label8Test()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.Label8 = expected;
            actual = target.Label8;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Label7
        ///</summary>
        [TestMethod()]
        public void Label7Test()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.Label7 = expected;
            actual = target.Label7;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Label6
        ///</summary>
        [TestMethod()]
        public void Label6Test()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.Label6 = expected;
            actual = target.Label6;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Label5
        ///</summary>
        [TestMethod()]
        public void Label5Test()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
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
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
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
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
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
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
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
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.Label1 = expected;
            actual = target.Label1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for grpboxLegend
        ///</summary>
        [TestMethod()]
        public void grpboxLegendTest()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            GroupBox expected = null; // TODO: Initialize to an appropriate value
            GroupBox actual;
            target.grpboxLegend = expected;
            actual = target.grpboxLegend;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GroupBox3
        ///</summary>
        [TestMethod()]
        public void GroupBox3Test()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            GroupBox expected = null; // TODO: Initialize to an appropriate value
            GroupBox actual;
            target.GroupBox3 = expected;
            actual = target.GroupBox3;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GroupBox2
        ///</summary>
        [TestMethod()]
        public void GroupBox2Test()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            GroupBox expected = null; // TODO: Initialize to an appropriate value
            GroupBox actual;
            target.GroupBox2 = expected;
            actual = target.GroupBox2;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FontDialog
        ///</summary>
        [TestMethod()]
        public void FontDialogTest()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            FontDialog expected = null; // TODO: Initialize to an appropriate value
            FontDialog actual;
            target.FontDialog = expected;
            actual = target.FontDialog;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for chkVisOnly
        ///</summary>
        [TestMethod()]
        public void chkVisOnlyTest()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            CheckBox expected = null; // TODO: Initialize to an appropriate value
            CheckBox actual;
            target.chkVisOnly = expected;
            actual = target.chkVisOnly;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for chkTitle
        ///</summary>
        [TestMethod()]
        public void chkTitleTest()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            CheckBox expected = null; // TODO: Initialize to an appropriate value
            CheckBox actual;
            target.chkTitle = expected;
            actual = target.chkTitle;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for chkScaleBar
        ///</summary>
        [TestMethod()]
        public void chkScaleBarTest()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            CheckBox expected = null; // TODO: Initialize to an appropriate value
            CheckBox actual;
            target.chkScaleBar = expected;
            actual = target.chkScaleBar;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for chkSbTransparent
        ///</summary>
        [TestMethod()]
        public void chkSbTransparentTest()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            CheckBox expected = null; // TODO: Initialize to an appropriate value
            CheckBox actual;
            target.chkSbTransparent = expected;
            actual = target.chkSbTransparent;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for chkNorth
        ///</summary>
        [TestMethod()]
        public void chkNorthTest()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            CheckBox expected = null; // TODO: Initialize to an appropriate value
            CheckBox actual;
            target.chkNorth = expected;
            actual = target.chkNorth;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for chkLegend
        ///</summary>
        [TestMethod()]
        public void chkLegendTest()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            CheckBox expected = null; // TODO: Initialize to an appropriate value
            CheckBox actual;
            target.chkLegend = expected;
            actual = target.chkLegend;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for chkInclRaster
        ///</summary>
        [TestMethod()]
        public void chkInclRasterTest()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            CheckBox expected = null; // TODO: Initialize to an appropriate value
            CheckBox actual;
            target.chkInclRaster = expected;
            actual = target.chkInclRaster;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for chkInclImages
        ///</summary>
        [TestMethod()]
        public void chkInclImagesTest()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            CheckBox expected = null; // TODO: Initialize to an appropriate value
            CheckBox actual;
            target.chkInclImages = expected;
            actual = target.chkInclImages;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Button3
        ///</summary>
        [TestMethod()]
        public void Button3Test()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.Button3 = expected;
            actual = target.Button3;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Button2
        ///</summary>
        [TestMethod()]
        public void Button2Test()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.Button2 = expected;
            actual = target.Button2;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Button1
        ///</summary>
        [TestMethod()]
        public void Button1Test()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.Button1 = expected;
            actual = target.Button1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for btnPrint
        ///</summary>
        [TestMethod()]
        public void btnPrintTest()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.btnPrint = expected;
            actual = target.btnPrint;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for btnPreview
        ///</summary>
        [TestMethod()]
        public void btnPreviewTest()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.btnPreview = expected;
            actual = target.btnPreview;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for btnFontTitle
        ///</summary>
        [TestMethod()]
        public void btnFontTitleTest()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.btnFontTitle = expected;
            actual = target.btnFontTitle;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for btnFontScalebar
        ///</summary>
        [TestMethod()]
        public void btnFontScalebarTest()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.btnFontScalebar = expected;
            actual = target.btnFontScalebar;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for btnFontLegend
        ///</summary>
        [TestMethod()]
        public void btnFontLegendTest()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.btnFontLegend = expected;
            actual = target.btnFontLegend;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for btnCancel
        ///</summary>
        [TestMethod()]
        public void btnCancelTest()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.btnCancel = expected;
            actual = target.btnCancel;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ValidateOptions
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ValidateOptionsTest()
        {
            frmPrintSidebarLayout_Accessor target = new frmPrintSidebarLayout_Accessor(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.ValidateOptions();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ShrinkMapIfNeeded
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ShrinkMapIfNeededTest()
        {
            frmPrintSidebarLayout_Accessor target = new frmPrintSidebarLayout_Accessor(); // TODO: Initialize to an appropriate value
            Bitmap MapImage = null; // TODO: Initialize to an appropriate value
            Bitmap MapImageExpected = null; // TODO: Initialize to an appropriate value
            int MaxLegendItemHeight = 0; // TODO: Initialize to an appropriate value
            int sectionWidth = 0; // TODO: Initialize to an appropriate value
            int PrintAreaHeight = 0; // TODO: Initialize to an appropriate value
            int MapImageWidth = 0; // TODO: Initialize to an appropriate value
            int MapImageWidthExpected = 0; // TODO: Initialize to an appropriate value
            int MapImageHeight = 0; // TODO: Initialize to an appropriate value
            int MapImageHeightExpected = 0; // TODO: Initialize to an appropriate value
            double rescaleX = 0F; // TODO: Initialize to an appropriate value
            double rescaleXExpected = 0F; // TODO: Initialize to an appropriate value
            double rescaleY = 0F; // TODO: Initialize to an appropriate value
            double rescaleYExpected = 0F; // TODO: Initialize to an appropriate value
            target.ShrinkMapIfNeeded(ref MapImage, MaxLegendItemHeight, sectionWidth, PrintAreaHeight, ref MapImageWidth, ref MapImageHeight, ref rescaleX, ref rescaleY);
            Assert.AreEqual(MapImageExpected, MapImage);
            Assert.AreEqual(MapImageWidthExpected, MapImageWidth);
            Assert.AreEqual(MapImageHeightExpected, MapImageHeight);
            Assert.AreEqual(rescaleXExpected, rescaleX);
            Assert.AreEqual(rescaleYExpected, rescaleY);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SaveLastSettings
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void SaveLastSettingsTest()
        {
            frmPrintSidebarLayout_Accessor target = new frmPrintSidebarLayout_Accessor(); // TODO: Initialize to an appropriate value
            target.SaveLastSettings();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for RestoreLastSettings
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void RestoreLastSettingsTest()
        {
            frmPrintSidebarLayout_Accessor target = new frmPrintSidebarLayout_Accessor(); // TODO: Initialize to an appropriate value
            target.RestoreLastSettings();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PrintDocument1_PrintPage
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void PrintDocument1_PrintPageTest()
        {
            frmPrintSidebarLayout_Accessor target = new frmPrintSidebarLayout_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            PrintPageEventArgs e = null; // TODO: Initialize to an appropriate value
            target.PrintDocument1_PrintPage(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for pnlSbForeColor_MouseDown
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void pnlSbForeColor_MouseDownTest()
        {
            frmPrintSidebarLayout_Accessor target = new frmPrintSidebarLayout_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            MouseEventArgs e = null; // TODO: Initialize to an appropriate value
            target.pnlSbForeColor_MouseDown(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for pnlSbBackColor_MouseDown
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void pnlSbBackColor_MouseDownTest()
        {
            frmPrintSidebarLayout_Accessor target = new frmPrintSidebarLayout_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            MouseEventArgs e = null; // TODO: Initialize to an appropriate value
            target.pnlSbBackColor_MouseDown(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void InitializeComponentTest()
        {
            frmPrintSidebarLayout_Accessor target = new frmPrintSidebarLayout_Accessor(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for frmPrint_Load
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void frmPrint_LoadTest()
        {
            frmPrintSidebarLayout_Accessor target = new frmPrintSidebarLayout_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.frmPrint_Load(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DisposeTest()
        {
            frmPrintSidebarLayout_Accessor target = new frmPrintSidebarLayout_Accessor(); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for cbTitle_CheckedChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void cbTitle_CheckedChangedTest()
        {
            frmPrintSidebarLayout_Accessor target = new frmPrintSidebarLayout_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.cbTitle_CheckedChanged(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Button2_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void Button2_ClickTest()
        {
            frmPrintSidebarLayout_Accessor target = new frmPrintSidebarLayout_Accessor(); // TODO: Initialize to an appropriate value
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
            frmPrintSidebarLayout_Accessor target = new frmPrintSidebarLayout_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.Button1_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for btnPrintProperties_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void btnPrintProperties_ClickTest()
        {
            frmPrintSidebarLayout_Accessor target = new frmPrintSidebarLayout_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.btnPrintProperties_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for btnPrint_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void btnPrint_ClickTest()
        {
            frmPrintSidebarLayout_Accessor target = new frmPrintSidebarLayout_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.btnPrint_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for btnPreview_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void btnPreview_ClickTest()
        {
            frmPrintSidebarLayout_Accessor target = new frmPrintSidebarLayout_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.btnPreview_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for btnFontTitle_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void btnFontTitle_ClickTest()
        {
            frmPrintSidebarLayout_Accessor target = new frmPrintSidebarLayout_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.btnFontTitle_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for btnFontScalebar_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void btnFontScalebar_ClickTest()
        {
            frmPrintSidebarLayout_Accessor target = new frmPrintSidebarLayout_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.btnFontScalebar_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for btnFontLegend_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void btnFontLegend_ClickTest()
        {
            frmPrintSidebarLayout_Accessor target = new frmPrintSidebarLayout_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.btnFontLegend_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for btnCancel_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void btnCancel_ClickTest()
        {
            frmPrintSidebarLayout_Accessor target = new frmPrintSidebarLayout_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.btnCancel_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for frmPrintSidebarLayout Constructor
        ///</summary>
        [TestMethod()]
        public void frmPrintSidebarLayoutConstructorTest()
        {
            frmPrintSidebarLayout target = new frmPrintSidebarLayout();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
