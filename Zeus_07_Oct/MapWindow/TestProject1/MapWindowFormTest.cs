using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeifenLuo.WinFormsUI.Docking;
// using MapWindow.Interfaces;
using System;
using System.Windows.Forms;
using MapWinGIS;
using System.Drawing;
using AxMapWinGIS;
using System.ComponentModel;
using Microsoft.VisualBasic;
using LegendControl;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for MapWindowFormTest and is intended
    ///to contain all MapWindowFormTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MapWindowFormTest
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
        ///A test for View
        ///</summary>
        [TestMethod()]
        public void ViewTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.View actual;
            actual = target.View;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UserInteraction
        ///</summary>
        [TestMethod()]
        public void UserInteractionTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.UserInteraction actual;
            actual = target.UserInteraction;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UIPanel
        ///</summary>
        [TestMethod()]
        public void UIPanelTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.UIPanel actual;
            actual = target.UIPanel;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToolTip
        ///</summary>
        [TestMethod()]
        public void ToolTipTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            ToolTip expected = null; // TODO: Initialize to an appropriate value
            ToolTip actual;
            target.ToolTip = expected;
            actual = target.ToolTip;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToolStripMenuRelabel
        ///</summary>
        [TestMethod()]
        public void ToolStripMenuRelabelTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.ToolStripMenuRelabel = expected;
            actual = target.ToolStripMenuRelabel;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToolStripMenuLabelSetup
        ///</summary>
        [TestMethod()]
        public void ToolStripMenuLabelSetupTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.ToolStripMenuLabelSetup = expected;
            actual = target.ToolStripMenuLabelSetup;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToolStripMenuItem9
        ///</summary>
        [TestMethod()]
        public void ToolStripMenuItem9Test()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            ToolStripSeparator expected = null; // TODO: Initialize to an appropriate value
            ToolStripSeparator actual;
            target.ToolStripMenuItem9 = expected;
            actual = target.ToolStripMenuItem9;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToolStripMenuItem8
        ///</summary>
        [TestMethod()]
        public void ToolStripMenuItem8Test()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.ToolStripMenuItem8 = expected;
            actual = target.ToolStripMenuItem8;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToolStripMenuItem6
        ///</summary>
        [TestMethod()]
        public void ToolStripMenuItem6Test()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.ToolStripMenuItem6 = expected;
            actual = target.ToolStripMenuItem6;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToolStripMenuItem5
        ///</summary>
        [TestMethod()]
        public void ToolStripMenuItem5Test()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.ToolStripMenuItem5 = expected;
            actual = target.ToolStripMenuItem5;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToolStripMenuItem4
        ///</summary>
        [TestMethod()]
        public void ToolStripMenuItem4Test()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.ToolStripMenuItem4 = expected;
            actual = target.ToolStripMenuItem4;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToolStripMenuItem30
        ///</summary>
        [TestMethod()]
        public void ToolStripMenuItem30Test()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            ToolStripSeparator expected = null; // TODO: Initialize to an appropriate value
            ToolStripSeparator actual;
            target.ToolStripMenuItem30 = expected;
            actual = target.ToolStripMenuItem30;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToolStripMenuItem3
        ///</summary>
        [TestMethod()]
        public void ToolStripMenuItem3Test()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.ToolStripMenuItem3 = expected;
            actual = target.ToolStripMenuItem3;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToolStripMenuItem2
        ///</summary>
        [TestMethod()]
        public void ToolStripMenuItem2Test()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.ToolStripMenuItem2 = expected;
            actual = target.ToolStripMenuItem2;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToolStripMenuItem16
        ///</summary>
        [TestMethod()]
        public void ToolStripMenuItem16Test()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.ToolStripMenuItem16 = expected;
            actual = target.ToolStripMenuItem16;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToolStripMenuItem14
        ///</summary>
        [TestMethod()]
        public void ToolStripMenuItem14Test()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.ToolStripMenuItem14 = expected;
            actual = target.ToolStripMenuItem14;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToolStripMenuItem13
        ///</summary>
        [TestMethod()]
        public void ToolStripMenuItem13Test()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.ToolStripMenuItem13 = expected;
            actual = target.ToolStripMenuItem13;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToolStripMenuItem12
        ///</summary>
        [TestMethod()]
        public void ToolStripMenuItem12Test()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.ToolStripMenuItem12 = expected;
            actual = target.ToolStripMenuItem12;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToolStripMenuItem11
        ///</summary>
        [TestMethod()]
        public void ToolStripMenuItem11Test()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.ToolStripMenuItem11 = expected;
            actual = target.ToolStripMenuItem11;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToolStripMenuBreak2
        ///</summary>
        [TestMethod()]
        public void ToolStripMenuBreak2Test()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            ToolStripSeparator expected = null; // TODO: Initialize to an appropriate value
            ToolStripSeparator actual;
            target.ToolStripMenuBreak2 = expected;
            actual = target.ToolStripMenuBreak2;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToolStripMenuBreak1
        ///</summary>
        [TestMethod()]
        public void ToolStripMenuBreak1Test()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            ToolStripSeparator expected = null; // TODO: Initialize to an appropriate value
            ToolStripSeparator actual;
            target.ToolStripMenuBreak1 = expected;
            actual = target.ToolStripMenuBreak1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Toolbar
        ///</summary>
        [TestMethod()]
        public void ToolbarTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Toolbar actual;
            actual = target.Toolbar;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tmrMenuTips
        ///</summary>
        [TestMethod()]
        public void tmrMenuTipsTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            Timer expected = null; // TODO: Initialize to an appropriate value
            Timer actual;
            target.tmrMenuTips = expected;
            actual = target.tmrMenuTips;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tlbMain
        ///</summary>
        [TestMethod()]
        public void tlbMainTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            ToolStrip expected = null; // TODO: Initialize to an appropriate value
            ToolStrip actual;
            target.tlbMain = expected;
            actual = target.tlbMain;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tbbZoomOut
        ///</summary>
        [TestMethod()]
        public void tbbZoomOutTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            ToolStripButton expected = null; // TODO: Initialize to an appropriate value
            ToolStripButton actual;
            target.tbbZoomOut = expected;
            actual = target.tbbZoomOut;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tbbZoomIn
        ///</summary>
        [TestMethod()]
        public void tbbZoomInTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            ToolStripButton expected = null; // TODO: Initialize to an appropriate value
            ToolStripButton actual;
            target.tbbZoomIn = expected;
            actual = target.tbbZoomIn;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tbbZoom
        ///</summary>
        [TestMethod()]
        public void tbbZoomTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            ToolStripDropDownButton expected = null; // TODO: Initialize to an appropriate value
            ToolStripDropDownButton actual;
            target.tbbZoom = expected;
            actual = target.tbbZoom;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tbbSelect
        ///</summary>
        [TestMethod()]
        public void tbbSelectTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            ToolStripButton expected = null; // TODO: Initialize to an appropriate value
            ToolStripButton actual;
            target.tbbSelect = expected;
            actual = target.tbbSelect;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tbbSave
        ///</summary>
        [TestMethod()]
        public void tbbSaveTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            ToolStripButton expected = null; // TODO: Initialize to an appropriate value
            ToolStripButton actual;
            target.tbbSave = expected;
            actual = target.tbbSave;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tbbPrint
        ///</summary>
        [TestMethod()]
        public void tbbPrintTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            ToolStripButton expected = null; // TODO: Initialize to an appropriate value
            ToolStripButton actual;
            target.tbbPrint = expected;
            actual = target.tbbPrint;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tbbPan
        ///</summary>
        [TestMethod()]
        public void tbbPanTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            ToolStripButton expected = null; // TODO: Initialize to an appropriate value
            ToolStripButton actual;
            target.tbbPan = expected;
            actual = target.tbbPan;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tbbOpen
        ///</summary>
        [TestMethod()]
        public void tbbOpenTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
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
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            ToolStripButton expected = null; // TODO: Initialize to an appropriate value
            ToolStripButton actual;
            target.tbbNew = expected;
            actual = target.tbbNew;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tbbMeasureArea
        ///</summary>
        [TestMethod()]
        public void tbbMeasureAreaTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            ToolStripButton expected = null; // TODO: Initialize to an appropriate value
            ToolStripButton actual;
            target.tbbMeasureArea = expected;
            actual = target.tbbMeasureArea;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tbbMeasure
        ///</summary>
        [TestMethod()]
        public void tbbMeasureTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            ToolStripButton expected = null; // TODO: Initialize to an appropriate value
            ToolStripButton actual;
            target.tbbMeasure = expected;
            actual = target.tbbMeasure;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tbbBreak3
        ///</summary>
        [TestMethod()]
        public void tbbBreak3Test()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            ToolStripSeparator expected = null; // TODO: Initialize to an appropriate value
            ToolStripSeparator actual;
            target.tbbBreak3 = expected;
            actual = target.tbbBreak3;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tbbBreak2
        ///</summary>
        [TestMethod()]
        public void tbbBreak2Test()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            ToolStripSeparator expected = null; // TODO: Initialize to an appropriate value
            ToolStripSeparator actual;
            target.tbbBreak2 = expected;
            actual = target.tbbBreak2;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tbbBreak1
        ///</summary>
        [TestMethod()]
        public void tbbBreak1Test()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            ToolStripSeparator expected = null; // TODO: Initialize to an appropriate value
            ToolStripSeparator actual;
            target.tbbBreak1 = expected;
            actual = target.tbbBreak1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tbbAddRemove
        ///</summary>
        [TestMethod()]
        public void tbbAddRemoveTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            ToolStripDropDownButton expected = null; // TODO: Initialize to an appropriate value
            ToolStripDropDownButton actual;
            target.tbbAddRemove = expected;
            actual = target.tbbAddRemove;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for StripDocker
        ///</summary>
        [TestMethod()]
        public void StripDockerTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            ToolStripContainer expected = null; // TODO: Initialize to an appropriate value
            ToolStripContainer actual;
            target.StripDocker = expected;
            actual = target.StripDocker;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for StatusBarPanel3
        ///</summary>
        [TestMethod()]
        public void StatusBarPanel3Test()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            StatusBarPanel expected = null; // TODO: Initialize to an appropriate value
            StatusBarPanel actual;
            target.StatusBarPanel3 = expected;
            actual = target.StatusBarPanel3;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for StatusBarPanel2
        ///</summary>
        [TestMethod()]
        public void StatusBarPanel2Test()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            StatusBarPanel expected = null; // TODO: Initialize to an appropriate value
            StatusBarPanel actual;
            target.StatusBarPanel2 = expected;
            actual = target.StatusBarPanel2;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for StatusBarPanel1
        ///</summary>
        [TestMethod()]
        public void StatusBarPanel1Test()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            StatusBarPanel expected = null; // TODO: Initialize to an appropriate value
            StatusBarPanel actual;
            target.StatusBarPanel1 = expected;
            actual = target.StatusBarPanel1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for StatusBar1
        ///</summary>
        [TestMethod()]
        public void StatusBar1Test()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.StatusBar expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.StatusBar actual;
            target.StatusBar1 = expected;
            actual = target.StatusBar1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for StatusBar
        ///</summary>
        [TestMethod()]
        public void StatusBarTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.StatusBar actual;
            actual = target.StatusBar;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Reports
        ///</summary>
        [TestMethod()]
        public void ReportsTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Reports actual;
            actual = target.Reports;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Project
        ///</summary>
        [TestMethod()]
        public void ProjectTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Project actual;
            actual = target.Project;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ProgressBar1
        ///</summary>
        [TestMethod()]
        public void ProgressBar1Test()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            ProgressBar expected = null; // TODO: Initialize to an appropriate value
            ProgressBar actual;
            target.ProgressBar1 = expected;
            actual = target.ProgressBar1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PreviewMap
        ///</summary>
        [TestMethod()]
        public void PreviewMapTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.PreviewMap actual;
            actual = target.PreviewMap;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Plugins
        ///</summary>
        [TestMethod()]
        public void PluginsTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Plugins actual;
            actual = target.Plugins;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for panel1
        ///</summary>
        [TestMethod()]
        public void panel1Test()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            Panel expected = null; // TODO: Initialize to an appropriate value
            Panel actual;
            target.panel1 = expected;
            actual = target.panel1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuZoomShape
        ///</summary>
        [TestMethod()]
        public void mnuZoomShapeTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.mnuZoomShape = expected;
            actual = target.mnuZoomShape;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuZoomSelected
        ///</summary>
        [TestMethod()]
        public void mnuZoomSelectedTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.mnuZoomSelected = expected;
            actual = target.mnuZoomSelected;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuZoomPrevious
        ///</summary>
        [TestMethod()]
        public void mnuZoomPreviousTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.mnuZoomPrevious = expected;
            actual = target.mnuZoomPrevious;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuZoomPreviewMap
        ///</summary>
        [TestMethod()]
        public void mnuZoomPreviewMapTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.mnuZoomPreviewMap = expected;
            actual = target.mnuZoomPreviewMap;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuZoomNext
        ///</summary>
        [TestMethod()]
        public void mnuZoomNextTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.mnuZoomNext = expected;
            actual = target.mnuZoomNext;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuZoomMax
        ///</summary>
        [TestMethod()]
        public void mnuZoomMaxTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.mnuZoomMax = expected;
            actual = target.mnuZoomMax;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuZoomLayer
        ///</summary>
        [TestMethod()]
        public void mnuZoomLayerTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.mnuZoomLayer = expected;
            actual = target.mnuZoomLayer;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuZoom
        ///</summary>
        [TestMethod()]
        public void mnuZoomTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            ContextMenuStrip expected = null; // TODO: Initialize to an appropriate value
            ContextMenuStrip actual;
            target.mnuZoom = expected;
            actual = target.mnuZoom;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuTableEditorLaunch
        ///</summary>
        [TestMethod()]
        public void mnuTableEditorLaunchTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.mnuTableEditorLaunch = expected;
            actual = target.mnuTableEditorLaunch;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuLegend
        ///</summary>
        [TestMethod()]
        public void mnuLegendTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            ContextMenuStrip expected = null; // TODO: Initialize to an appropriate value
            ContextMenuStrip actual;
            target.mnuLegend = expected;
            actual = target.mnuLegend;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuLayerButton
        ///</summary>
        [TestMethod()]
        public void mnuLayerButtonTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            ContextMenuStrip expected = null; // TODO: Initialize to an appropriate value
            ContextMenuStrip actual;
            target.mnuLayerButton = expected;
            actual = target.mnuLayerButton;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuBtnRemove
        ///</summary>
        [TestMethod()]
        public void mnuBtnRemoveTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.mnuBtnRemove = expected;
            actual = target.mnuBtnRemove;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuBtnClear
        ///</summary>
        [TestMethod()]
        public void mnuBtnClearTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.mnuBtnClear = expected;
            actual = target.mnuBtnClear;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuBtnAdd
        ///</summary>
        [TestMethod()]
        public void mnuBtnAddTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            target.mnuBtnAdd = expected;
            actual = target.mnuBtnAdd;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MenuStrip1
        ///</summary>
        [TestMethod()]
        public void MenuStrip1Test()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            MenuStrip expected = null; // TODO: Initialize to an appropriate value
            MenuStrip actual;
            target.MenuStrip1 = expected;
            actual = target.MenuStrip1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Menus
        ///</summary>
        [TestMethod()]
        public void MenusTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Menus actual;
            actual = target.Menus;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MapToolTipTimer
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void MapToolTipTimerTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            Timer expected = null; // TODO: Initialize to an appropriate value
            Timer actual;
            target.MapToolTipTimer = expected;
            actual = target.MapToolTipTimer;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MapTooltipsAtLeastOneLayer
        ///</summary>
        [TestMethod()]
        public void MapTooltipsAtLeastOneLayerTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.MapTooltipsAtLeastOneLayer = expected;
            actual = target.MapTooltipsAtLeastOneLayer;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MapPreview
        ///</summary>
        [TestMethod()]
        public void MapPreviewTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            AxMap expected = null; // TODO: Initialize to an appropriate value
            AxMap actual;
            target.MapPreview = expected;
            actual = target.MapPreview;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MapMain
        ///</summary>
        [TestMethod()]
        public void MapMainTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            AxMap expected = null; // TODO: Initialize to an appropriate value
            AxMap actual;
            target.MapMain = expected;
            actual = target.MapMain;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for m_legendEditor
        ///</summary>
        [TestMethod()]
        public void m_legendEditorTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            LegendEditorForm expected = null; // TODO: Initialize to an appropriate value
            LegendEditorForm actual;
            target.m_legendEditor = expected;
            actual = target.m_legendEditor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for m_FloatingScalebar_ContextMenu_UR
        ///</summary>
        [TestMethod()]
        public void m_FloatingScalebar_ContextMenu_URTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            MenuItem expected = null; // TODO: Initialize to an appropriate value
            MenuItem actual;
            target.m_FloatingScalebar_ContextMenu_UR = expected;
            actual = target.m_FloatingScalebar_ContextMenu_UR;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for m_FloatingScalebar_ContextMenu_UL
        ///</summary>
        [TestMethod()]
        public void m_FloatingScalebar_ContextMenu_ULTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            MenuItem expected = null; // TODO: Initialize to an appropriate value
            MenuItem actual;
            target.m_FloatingScalebar_ContextMenu_UL = expected;
            actual = target.m_FloatingScalebar_ContextMenu_UL;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for m_FloatingScalebar_ContextMenu_LR
        ///</summary>
        [TestMethod()]
        public void m_FloatingScalebar_ContextMenu_LRTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            MenuItem expected = null; // TODO: Initialize to an appropriate value
            MenuItem actual;
            target.m_FloatingScalebar_ContextMenu_LR = expected;
            actual = target.m_FloatingScalebar_ContextMenu_LR;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for m_FloatingScalebar_ContextMenu_LL
        ///</summary>
        [TestMethod()]
        public void m_FloatingScalebar_ContextMenu_LLTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            MenuItem expected = null; // TODO: Initialize to an appropriate value
            MenuItem actual;
            target.m_FloatingScalebar_ContextMenu_LL = expected;
            actual = target.m_FloatingScalebar_ContextMenu_LL;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for m_FloatingScalebar_ContextMenu_FC
        ///</summary>
        [TestMethod()]
        public void m_FloatingScalebar_ContextMenu_FCTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            MenuItem expected = null; // TODO: Initialize to an appropriate value
            MenuItem actual;
            target.m_FloatingScalebar_ContextMenu_FC = expected;
            actual = target.m_FloatingScalebar_ContextMenu_FC;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for m_FloatingScalebar_ContextMenu_CU
        ///</summary>
        [TestMethod()]
        public void m_FloatingScalebar_ContextMenu_CUTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            MenuItem expected = null; // TODO: Initialize to an appropriate value
            MenuItem actual;
            target.m_FloatingScalebar_ContextMenu_CU = expected;
            actual = target.m_FloatingScalebar_ContextMenu_CU;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for m_FloatingScalebar_ContextMenu_BC
        ///</summary>
        [TestMethod()]
        public void m_FloatingScalebar_ContextMenu_BCTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            MenuItem expected = null; // TODO: Initialize to an appropriate value
            MenuItem actual;
            target.m_FloatingScalebar_ContextMenu_BC = expected;
            actual = target.m_FloatingScalebar_ContextMenu_BC;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for m_FloatingScalebar_ContextMenu
        ///</summary>
        [TestMethod()]
        public void m_FloatingScalebar_ContextMenuTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            ContextMenu expected = null; // TODO: Initialize to an appropriate value
            ContextMenu actual;
            target.m_FloatingScalebar_ContextMenu = expected;
            actual = target.m_FloatingScalebar_ContextMenu;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Legend
        ///</summary>
        [TestMethod()]
        public void LegendTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            Legend expected = null; // TODO: Initialize to an appropriate value
            Legend actual;
            target.Legend = expected;
            actual = target.Legend;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Layers
        ///</summary>
        [TestMethod()]
        public void LayersTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Layers actual;
            actual = target.Layers;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LastError
        ///</summary>
        [TestMethod()]
        public void LastErrorTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.LastError;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ilsToolbar
        ///</summary>
        [TestMethod()]
        public void ilsToolbarTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            ImageList expected = null; // TODO: Initialize to an appropriate value
            ImageList actual;
            target.ilsToolbar = expected;
            actual = target.ilsToolbar;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetOCX
        ///</summary>
        [TestMethod()]
        public void GetOCXTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            object actual;
            actual = target.GetOCX;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DisplayFullProjectPath
        ///</summary>
        [TestMethod()]
        public void DisplayFullProjectPathTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            target.DisplayFullProjectPath = expected;
            Assert.Inconclusive("Write-only properties cannot be verified.");
        }

        /// <summary>
        ///A test for ApplicationInfo
        ///</summary>
        [TestMethod()]
        public void ApplicationInfoTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.AppInfo actual;
            actual = target.ApplicationInfo;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UpdateZoomButtons
        ///</summary>
        [TestMethod()]
        public void UpdateZoomButtonsTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            target.UpdateZoomButtons();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UpdateMapToolTipsAtLeastOneLayer
        ///</summary>
        [TestMethod()]
        public void UpdateMapToolTipsAtLeastOneLayerTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            target.UpdateMapToolTipsAtLeastOneLayer();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UpdateFloatingScalebar
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void UpdateFloatingScalebarTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.UpdateFloatingScalebar();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UndockableToolstrip_EndDrag
        ///</summary>
        [TestMethod()]
        public void UndockableToolstrip_EndDragTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.UndockableToolstrip_EndDrag(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ToolStripMenuRelabel_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ToolStripMenuRelabel_ClickTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.ToolStripMenuRelabel_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ToolStripMenuLabelSetup_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ToolStripMenuLabelSetup_ClickTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.ToolStripMenuLabelSetup_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ToolStripMenuItem8_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ToolStripMenuItem8_ClickTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.ToolStripMenuItem8_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ToolStripMenuItem6_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ToolStripMenuItem6_ClickTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.ToolStripMenuItem6_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ToolStripMenuItem5_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ToolStripMenuItem5_ClickTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.ToolStripMenuItem5_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ToolStripMenuItem4_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ToolStripMenuItem4_ClickTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
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
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.ToolStripMenuItem3_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ToolStripMenuItem2_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ToolStripMenuItem2_ClickTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.ToolStripMenuItem2_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ToolStripMenuItem16_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ToolStripMenuItem16_ClickTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.ToolStripMenuItem16_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ToolStripMenuItem14_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ToolStripMenuItem14_ClickTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.ToolStripMenuItem14_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ToolStripMenuItem13_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ToolStripMenuItem13_ClickTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.ToolStripMenuItem13_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ToolStripMenuItem12_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ToolStripMenuItem12_ClickTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.ToolStripMenuItem12_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ToolStripMenuItem11_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ToolStripMenuItem11_ClickTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.ToolStripMenuItem11_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for tlbMain_ButtonClick
        ///</summary>
        [TestMethod()]
        public void tlbMain_ButtonClickTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            ToolStripItemClickedEventArgs e = null; // TODO: Initialize to an appropriate value
            target.tlbMain_ButtonClick(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SynchPluginMenu
        ///</summary>
        [TestMethod()]
        public void SynchPluginMenuTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            target.SynchPluginMenu();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ShowErrorDialog
        ///</summary>
        [TestMethod()]
        public void ShowErrorDialogTest1()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            Exception ex = null; // TODO: Initialize to an appropriate value
            target.ShowErrorDialog(ex);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ShowErrorDialog
        ///</summary>
        [TestMethod()]
        public void ShowErrorDialogTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            Exception ex = null; // TODO: Initialize to an appropriate value
            string SendEmailTo = string.Empty; // TODO: Initialize to an appropriate value
            target.ShowErrorDialog(ex, SendEmailTo);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetUpMenus
        ///</summary>
        [TestMethod()]
        public void SetUpMenusTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            target.SetUpMenus();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetScale
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void SetScaleTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            string NewScale = string.Empty; // TODO: Initialize to an appropriate value
            target.SetScale(NewScale);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetModified
        ///</summary>
        [TestMethod()]
        public void SetModifiedTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            bool Status = false; // TODO: Initialize to an appropriate value
            target.SetModified(Status);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetCustomWindowTitle
        ///</summary>
        [TestMethod()]
        public void SetCustomWindowTitleTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            string NewTitleText = string.Empty; // TODO: Initialize to an appropriate value
            target.SetCustomWindowTitle(NewTitleText);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SaveShapeLayerProps
        ///</summary>
        [TestMethod()]
        public void SaveShapeLayerPropsTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            int handle = 0; // TODO: Initialize to an appropriate value
            string filename = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.SaveShapeLayerProps(handle, filename);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SaveCustomColors
        ///</summary>
        [TestMethod()]
        public void SaveCustomColorsTest()
        {
            ColorDialog dlg = null; // TODO: Initialize to an appropriate value
            ColorDialog dlgExpected = null; // TODO: Initialize to an appropriate value
            MapWindowForm.SaveCustomColors(ref dlg);
            Assert.AreEqual(dlgExpected, dlg);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ResetViewState
        ///</summary>
        [TestMethod()]
        public void ResetViewStateTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            bool LeaveFloatingScalebar = false; // TODO: Initialize to an appropriate value
            target.ResetViewState(LeaveFloatingScalebar);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for RefreshMap
        ///</summary>
        [TestMethod()]
        public void RefreshTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            target.Refresh();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for rad2deg
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void rad2degTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            double rad = 0F; // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            actual = target.rad2deg(rad);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PromptToSaveProject
        ///</summary>
        [TestMethod()]
        public void PromptToSaveProjectTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            MsgBoxResult expected = new MsgBoxResult(); // TODO: Initialize to an appropriate value
            MsgBoxResult actual;
            actual = target.PromptToSaveProject();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ProcessCmdKey
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ProcessCmdKeyTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            Message msg = new Message(); // TODO: Initialize to an appropriate value
            Message msgExpected = new Message(); // TODO: Initialize to an appropriate value
            Keys keyData = new Keys(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.ProcessCmdKey(ref msg, keyData);
            Assert.AreEqual(msgExpected, msg);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PreviewMapExtentsValid
        ///</summary>
        [TestMethod()]
        public void PreviewMapExtentsValidTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.PreviewMapExtentsValid();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PreviewMapContextMenuStrip_UpdatePreviewFull
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void PreviewMapContextMenuStrip_UpdatePreviewFullTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.PreviewMapContextMenuStrip_UpdatePreviewFull(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PreviewMapContextMenuStrip_UpdatePreview
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void PreviewMapContextMenuStrip_UpdatePreviewTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.PreviewMapContextMenuStrip_UpdatePreview(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PreviewMapContextMenuStrip_ClearPreview
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void PreviewMapContextMenuStrip_ClearPreviewTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.PreviewMapContextMenuStrip_ClearPreview(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnMouseWheel
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void OnMouseWheelTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            MouseEventArgs e = null; // TODO: Initialize to an appropriate value
            target.OnMouseWheel(e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mnuZoomButtons_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void mnuZoomButtons_ClickTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.mnuZoomButtons_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mnuTableEditorLaunch_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void mnuTableEditorLaunch_ClickTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.mnuTableEditorLaunch_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mnuBtnRemove_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void mnuBtnRemove_ClickTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.mnuBtnRemove_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mnuBtnClear_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void mnuBtnClear_ClickTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.mnuBtnClear_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mnuBtnAdd_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void mnuBtnAdd_ClickTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.mnuBtnAdd_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MeasuringStop
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void MeasuringStopTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.MeasuringStop();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MeasuringDrawPreviousSegments
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void MeasuringDrawPreviousSegmentsTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.MeasuringDrawPreviousSegments();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MeasuringBegin
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void MeasuringBeginTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.MeasuringBegin();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MapWindowForm_Resize
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void MapWindowForm_ResizeTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.MapWindowForm_Resize(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MapWindowForm_Load
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void MapWindowForm_LoadTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.MapWindowForm_Load(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MapWindowForm_Closing
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void MapWindowForm_ClosingTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            CancelEventArgs e = null; // TODO: Initialize to an appropriate value
            target.MapWindowForm_Closing(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MapWindowForm_Activated
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void MapWindowForm_ActivatedTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.MapWindowForm_Activated(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MapToolTipTimer_Tick
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void MapToolTipTimer_TickTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.MapToolTipTimer_Tick(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MapPreview_Resize
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void MapPreview_ResizeTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.MapPreview_Resize(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MapPreview_MouseUpEvent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void MapPreview_MouseUpEventTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            _DMapEvents_MouseUpEvent e = null; // TODO: Initialize to an appropriate value
            target.MapPreview_MouseUpEvent(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MapPreview_MouseMoveEvent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void MapPreview_MouseMoveEventTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            _DMapEvents_MouseMoveEvent e = null; // TODO: Initialize to an appropriate value
            target.MapPreview_MouseMoveEvent(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MapPreview_MouseDownEvent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void MapPreview_MouseDownEventTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            _DMapEvents_MouseDownEvent e = null; // TODO: Initialize to an appropriate value
            target.MapPreview_MouseDownEvent(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MapMain_SelectBoxFinal
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void MapMain_SelectBoxFinalTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            _DMapEvents_SelectBoxFinalEvent e = null; // TODO: Initialize to an appropriate value
            target.MapMain_SelectBoxFinal(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MapMain_MouseUpEvent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void MapMain_MouseUpEventTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            _DMapEvents_MouseUpEvent e = null; // TODO: Initialize to an appropriate value
            target.MapMain_MouseUpEvent(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MapMain_MouseMoveEvent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void MapMain_MouseMoveEventTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            _DMapEvents_MouseMoveEvent e = null; // TODO: Initialize to an appropriate value
            target.MapMain_MouseMoveEvent(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MapMain_MouseDownEvent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void MapMain_MouseDownEventTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            _DMapEvents_MouseDownEvent e = null; // TODO: Initialize to an appropriate value
            target.MapMain_MouseDownEvent(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MapMain_FileDropped
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void MapMain_FileDroppedTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            _DMapEvents_FileDroppedEvent e = null; // TODO: Initialize to an appropriate value
            target.MapMain_FileDropped(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MapMain_ExtentsChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void MapMain_ExtentsChangedTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.MapMain_ExtentsChanged(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for m_legendEditor_Closed
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void m_legendEditor_ClosedTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.m_legendEditor_Closed(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadShapeLayerProps
        ///</summary>
        [TestMethod()]
        public void LoadShapeLayerPropsTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            int handle = 0; // TODO: Initialize to an appropriate value
            string filename = string.Empty; // TODO: Initialize to an appropriate value
            bool PluginCall = false; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.LoadShapeLayerProps(handle, filename, PluginCall);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LoadCustomColors
        ///</summary>
        [TestMethod()]
        public void LoadCustomColorsTest()
        {
            ColorDialog dlg = null; // TODO: Initialize to an appropriate value
            ColorDialog dlgExpected = null; // TODO: Initialize to an appropriate value
            MapWindowForm.LoadCustomColors(ref dlg);
            Assert.AreEqual(dlgExpected, dlg);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LLDistance
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void LLDistanceTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            double p1lat = 0F; // TODO: Initialize to an appropriate value
            double p1lon = 0F; // TODO: Initialize to an appropriate value
            double p2lat = 0F; // TODO: Initialize to an appropriate value
            double p2lon = 0F; // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            actual = target.LLDistance(p1lat, p1lon, p2lat, p2lon);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Legend_Load
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void Legend_LoadTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.Legend_Load(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Legend_LegendClick
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void Legend_LegendClickTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            MouseButtons button = new MouseButtons(); // TODO: Initialize to an appropriate value
            System.Drawing.Point Location = new System.Drawing.Point(); // TODO: Initialize to an appropriate value
            target.Legend_LegendClick(button, Location);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Legend_LayerVisibleChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void Legend_LayerVisibleChangedTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            int Handle = 0; // TODO: Initialize to an appropriate value
            bool NewState = false; // TODO: Initialize to an appropriate value
            bool Cancel = false; // TODO: Initialize to an appropriate value
            bool CancelExpected = false; // TODO: Initialize to an appropriate value
            target.Legend_LayerVisibleChanged(Handle, NewState, ref Cancel);
            Assert.AreEqual(CancelExpected, Cancel);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Legend_LayerSelected
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void Legend_LayerSelectedTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            int Handle = 0; // TODO: Initialize to an appropriate value
            target.Legend_LayerSelected(Handle);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Legend_LayerPositionChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void Legend_LayerPositionChangedTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            int Handle = 0; // TODO: Initialize to an appropriate value
            target.Legend_LayerPositionChanged(Handle);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Legend_LayerMouseUp
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void Legend_LayerMouseUpTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            int Handle = 0; // TODO: Initialize to an appropriate value
            MouseButtons button = new MouseButtons(); // TODO: Initialize to an appropriate value
            target.Legend_LayerMouseUp(Handle, button);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Legend_LayerMouseDown
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void Legend_LayerMouseDownTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            int Handle = 0; // TODO: Initialize to an appropriate value
            MouseButtons button = new MouseButtons(); // TODO: Initialize to an appropriate value
            target.Legend_LayerMouseDown(Handle, button);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Legend_LayerDoubleClick
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void Legend_LayerDoubleClickTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            int Handle = 0; // TODO: Initialize to an appropriate value
            target.Legend_LayerDoubleClick(Handle);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Legend_GroupPositionChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void Legend_GroupPositionChangedTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            int Handle = 0; // TODO: Initialize to an appropriate value
            target.Legend_GroupPositionChanged(Handle);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Legend_GroupMouseUp
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void Legend_GroupMouseUpTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            int Handle = 0; // TODO: Initialize to an appropriate value
            MouseButtons button = new MouseButtons(); // TODO: Initialize to an appropriate value
            target.Legend_GroupMouseUp(Handle, button);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Legend_GroupMouseDown
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void Legend_GroupMouseDownTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            int Handle = 0; // TODO: Initialize to an appropriate value
            MouseButtons button = new MouseButtons(); // TODO: Initialize to an appropriate value
            target.Legend_GroupMouseDown(Handle, button);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Legend_GroupExpandedChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void Legend_GroupExpandedChangedTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            int Handle = 0; // TODO: Initialize to an appropriate value
            bool Expanded = false; // TODO: Initialize to an appropriate value
            target.Legend_GroupExpandedChanged(Handle, Expanded);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Legend_GroupDoubleClick
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void Legend_GroupDoubleClickTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            int Handle = 0; // TODO: Initialize to an appropriate value
            target.Legend_GroupDoubleClick(Handle);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InMyFormBounds
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void InMyFormBoundsTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            System.Drawing.Point pt = new System.Drawing.Point(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.InMyFormBounds(pt);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for InitializeVars
        ///</summary>
        [TestMethod()]
        public void InitializeVarsTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            target.InitializeVars();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitializeMapsAndLegends
        ///</summary>
        [TestMethod()]
        public void InitializeMapsAndLegendsTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            target.InitializeMapsAndLegends();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void InitializeComponentTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InBox
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void InBoxTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            Rectangle rect = new Rectangle(); // TODO: Initialize to an appropriate value
            double x = 0F; // TODO: Initialize to an appropriate value
            double y = 0F; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.InBox(rect, x, y);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HandleShortcutKeys
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void HandleShortcutKeysTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            Keys e = new Keys(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.HandleShortcutKeys(e);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HandleClickedMenu
        ///</summary>
        [TestMethod()]
        public void HandleClickedMenuTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            string MenuName = string.Empty; // TODO: Initialize to an appropriate value
            target.HandleClickedMenu(MenuName);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for HandleButtonClick
        ///</summary>
        [TestMethod()]
        public void HandleButtonClickTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            string BtnName = string.Empty; // TODO: Initialize to an appropriate value
            ToolStripItem Btn = null; // TODO: Initialize to an appropriate value
            target.HandleButtonClick(BtnName, Btn);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetWindowDC
        ///</summary>
        [TestMethod()]
        public void GetWindowDCTest()
        {
            int hwnd = 0; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = MapWindowForm.GetWindowDC(hwnd);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetScaleUnit
        ///</summary>
        [TestMethod()]
        public void GetScaleUnitTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.UnitOfMeasure expected = new MapWindow.Interfaces.UnitOfMeasure(); // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.UnitOfMeasure actual;
            actual = target.GetScaleUnit();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetProjectionFromUser
        ///</summary>
        [TestMethod()]
        public void GetProjectionFromUserTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            string DialogCaption = string.Empty; // TODO: Initialize to an appropriate value
            string DefaultProjection = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetProjectionFromUser(DialogCaption, DefaultProjection);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetOrRemovePanel
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void GetOrRemovePanelTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            string psStartText = string.Empty; // TODO: Initialize to an appropriate value
            bool pbRemove = false; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetOrRemovePanel(psStartText, pbRemove);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetLayerPrettyProjection
        ///</summary>
        [TestMethod()]
        public void GetLayerPrettyProjectionTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            long Handle = 0; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetLayerPrettyProjection(Handle);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetDeviceCaps
        ///</summary>
        [TestMethod()]
        public void GetDeviceCapsTest()
        {
            int hDC = 0; // TODO: Initialize to an appropriate value
            int nIndex = 0; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = MapWindowForm.GetDeviceCaps(hDC, nIndex);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetCursorPos
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void GetCursorPosTest()
        {
            // Private Accessor for GetCursorPos is not found. Please rebuild the containing project or run the Publicize.exe manually.
            Assert.Inconclusive("Private Accessor for GetCursorPos is not found. Please rebuild the containing pro" +
                    "ject or run the Publicize.exe manually.");
        }

        /// <summary>
        ///A test for GetCursorLocation
        ///</summary>
        [TestMethod()]
        public void GetCursorLocationTest()
        {
            System.Drawing.Point expected = new System.Drawing.Point(); // TODO: Initialize to an appropriate value
            System.Drawing.Point actual;
            actual = MapWindowForm.GetCursorLocation();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetCurrentScale
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void GetCurrentScaleTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetCurrentScale();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetAsyncKeyState
        ///</summary>
        [TestMethod()]
        public void GetAsyncKeyStateTest()
        {
            int vKey = 0; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = MapWindowForm.GetAsyncKeyState(vKey);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for formatDistance
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void formatDistanceTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            double dist = 0F; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.formatDistance(dist);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FlushForwardHistory
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void FlushForwardHistoryTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.FlushForwardHistory();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for FloatingScalebarClick
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void FloatingScalebarClickTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.FloatingScalebarClick(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for FloatingScalebar_UpperRight_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void FloatingScalebar_UpperRight_ClickTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.FloatingScalebar_UpperRight_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for FloatingScalebar_UpperLeft_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void FloatingScalebar_UpperLeft_ClickTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.FloatingScalebar_UpperLeft_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for FloatingScalebar_LowerRight_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void FloatingScalebar_LowerRight_ClickTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.FloatingScalebar_LowerRight_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for FloatingScalebar_LowerLeft_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void FloatingScalebar_LowerLeft_ClickTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.FloatingScalebar_LowerLeft_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for FloatingScalebar_ChooseForecolor_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void FloatingScalebar_ChooseForecolor_ClickTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.FloatingScalebar_ChooseForecolor_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for FloatingScalebar_ChooseBackcolor_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void FloatingScalebar_ChooseBackcolor_ClickTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.FloatingScalebar_ChooseBackcolor_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for FloatingScalebar_ChangeUnits_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void FloatingScalebar_ChangeUnits_ClickTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.FloatingScalebar_ChangeUnits_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for FloatingBar_Move
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void FloatingBar_MoveTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.FloatingBar_Move(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for FindMaxVisibleExtents
        ///</summary>
        [TestMethod()]
        public void FindMaxVisibleExtentsTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            Extents expected = null; // TODO: Initialize to an appropriate value
            Extents actual;
            actual = target.FindMaxVisibleExtents();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for doZoomToPreview
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void doZoomToPreviewTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.doZoomToPreview();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DoZoomToLayer
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DoZoomToLayerTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.DoZoomToLayer();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DoZoomToGroup
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DoZoomToGroupTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.DoZoomToGroup();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for doZoomToFullExtents
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void doZoomToFullExtentsTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.doZoomToFullExtents();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DoZoomShape
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DoZoomShapeTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.DoZoomShape();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DoZoomSelected
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DoZoomSelectedTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.DoZoomSelected();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DoZoomPrevious
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DoZoomPreviousTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.DoZoomPrevious();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for doZoomOut
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void doZoomOutTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.doZoomOut();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DoZoomNext
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DoZoomNextTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.DoZoomNext();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DoZoomMax
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DoZoomMaxTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.DoZoomMax();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DoZoomLayer
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DoZoomLayerTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.DoZoomLayer();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for doZoomIn
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void doZoomInTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.doZoomIn();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DoViewMetaData
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DoViewMetaDataTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.DoViewMetaData();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for doUpdatePreview
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void doUpdatePreviewTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            bool FullExtents = false; // TODO: Initialize to an appropriate value
            target.doUpdatePreview(FullExtents);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DoToggleScalebar
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DoToggleScalebarTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.DoToggleScalebar();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for doSetScale
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void doSetScaleTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.doSetScale();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for doSaveScaleBarImage
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void doSaveScaleBarImageTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.doSaveScaleBarImage();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for doSaveNorthArrow
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void doSaveNorthArrowTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.doSaveNorthArrow();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for doSaveMapImage
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void doSaveMapImageTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.doSaveMapImage();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for doSaveLegend
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void doSaveLegendTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.doSaveLegend();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for doSaveGeoreferenced
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void doSaveGeoreferencedTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.doSaveGeoreferenced();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DoSaveAs
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DoSaveAsTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.DoSaveAs();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DoSave
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DoSaveTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.DoSave();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DoRemoveLayer
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DoRemoveLayerTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.DoRemoveLayer();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DoRemoveGroup
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DoRemoveGroupTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.DoRemoveGroup();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for doProjectSettings
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void doProjectSettingsTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.doProjectSettings();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DoPrint
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DoPrintTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.DoPrint();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for doPreviousZoom
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void doPreviousZoomTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.doPreviousZoom();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for doPluginNameClick
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void doPluginNameClickTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            string PluginKey = string.Empty; // TODO: Initialize to an appropriate value
            target.doPluginNameClick(PluginKey);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DoOpenIntoCurrent
        ///</summary>
        [TestMethod()]
        public void DoOpenIntoCurrentTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            string Filename = string.Empty; // TODO: Initialize to an appropriate value
            target.DoOpenIntoCurrent(Filename);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DoOpen
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DoOpenTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.DoOpen();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for doNextZoom
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void doNextZoomTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.doNextZoom();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DoNew
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DoNewTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.DoNew();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for doMapWindowDotCom
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void doMapWindowDotComTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.doMapWindowDotCom();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DoLabelsRelabel
        ///</summary>
        [TestMethod()]
        public void DoLabelsRelabelTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            int handle = 0; // TODO: Initialize to an appropriate value
            target.DoLabelsRelabel(handle);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DoLabelsEdit
        ///</summary>
        [TestMethod()]
        public void DoLabelsEditTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            int Handle = 0; // TODO: Initialize to an appropriate value
            target.DoLabelsEdit(Handle);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DoExpandGroups
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DoExpandGroupsTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.DoExpandGroups();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DoExpandAll
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DoExpandAllTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.DoExpandAll();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for doExit
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void doExitTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.doExit();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DoEditProperties
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DoEditPropertiesTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.DoEditProperties();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for doEditPlugins
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void doEditPluginsTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.doEditPlugins();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for doCopyScaleBar
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void doCopyScaleBarTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.doCopyScaleBar();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for doCopyNorthArrow
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void doCopyNorthArrowTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.doCopyNorthArrow();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for doCopyMap
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void doCopyMapTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.doCopyMap();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for doCopyLegend
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void doCopyLegendTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.doCopyLegend();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for doContents
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void doContentsTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.doContents();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DoCollapseGroups
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DoCollapseGroupsTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.DoCollapseGroups();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DoCollapseAll
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DoCollapseAllTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.DoCollapseAll();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for doClose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void doCloseTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.doClose();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DoClearSelection
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DoClearSelectionTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.DoClearSelection();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for doClearPreview
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void doClearPreviewTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.doClearPreview();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DoClearLayers
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DoClearLayersTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.DoClearLayers();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DockedPanelClosing
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DockedPanelClosingTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            FormClosingEventArgs e = null; // TODO: Initialize to an appropriate value
            target.DockedPanelClosing(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DoAddLayer
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DoAddLayerTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.DoAddLayer();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DoAddGroup
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DoAddGroupTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.DoAddGroup();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for doAboutMapWindow
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void doAboutMapWindowTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.doAboutMapWindow();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for distance
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void distanceTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            double x1 = 0F; // TODO: Initialize to an appropriate value
            double y1 = 0F; // TODO: Initialize to an appropriate value
            double x2 = 0F; // TODO: Initialize to an appropriate value
            double y2 = 0F; // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            actual = target.distance(x1, y1, x2, y2);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Dist
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DistTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            double x1 = 0F; // TODO: Initialize to an appropriate value
            double y1 = 0F; // TODO: Initialize to an appropriate value
            double x2 = 0F; // TODO: Initialize to an appropriate value
            double y2 = 0F; // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            actual = target.Dist(x1, y1, x2, y2);
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
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for deg2rad
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void deg2radTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            double deg = 0F; // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            actual = target.deg2rad(deg);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CustomMenu_Click
        ///</summary>
        [TestMethod()]
        public void CustomMenu_ClickTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.CustomMenu_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CustomCombo_SelectedIndexChanged
        ///</summary>
        [TestMethod()]
        public void CustomCombo_SelectedIndexChangedTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.CustomCombo_SelectedIndexChanged(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CreatePreviewPanel
        ///</summary>
        [TestMethod()]
        public void CreatePreviewPanelTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            DockContent expected = null; // TODO: Initialize to an appropriate value
            DockContent actual;
            actual = target.CreatePreviewPanel();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CreateMapPanel
        ///</summary>
        [TestMethod()]
        public void CreateMapPanelTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            DockContent expected = null; // TODO: Initialize to an appropriate value
            DockContent actual;
            actual = target.CreateMapPanel();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CreateLegendPanel
        ///</summary>
        [TestMethod()]
        public void CreateLegendPanelTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            DockContent expected = null; // TODO: Initialize to an appropriate value
            DockContent actual;
            actual = target.CreateLegendPanel();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ClearPreview
        ///</summary>
        [TestMethod()]
        public void ClearPreviewTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            target.ClearPreview();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ClearCustomWindowTitle
        ///</summary>
        [TestMethod()]
        public void ClearCustomWindowTitleTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            target.ClearCustomWindowTitle();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CheckForUpdates
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void CheckForUpdatesTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.CheckForUpdates();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for BuildRecentProjectsMenu
        ///</summary>
        [TestMethod()]
        public void BuildRecentProjectsMenuTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            target.BuildRecentProjectsMenu();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for BuildDockContent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void BuildDockContentTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            string persistString = string.Empty; // TODO: Initialize to an appropriate value
            IDockContent expected = null; // TODO: Initialize to an appropriate value
            IDockContent actual;
            actual = target.BuildDockContent(persistString);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuildBookmarkedViewsMenu
        ///</summary>
        [TestMethod()]
        public void BuildBookmarkedViewsMenuTest()
        {
            MapWindowForm target = new MapWindowForm(); // TODO: Initialize to an appropriate value
            target.BuildBookmarkedViewsMenu();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AreaMeasuringStop
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void AreaMeasuringStopTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.AreaMeasuringStop();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AreaMeasuringClearTempLines
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void AreaMeasuringClearTempLinesTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.AreaMeasuringClearTempLines();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AreaMeasuringBegin
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void AreaMeasuringBeginTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.AreaMeasuringBegin();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AreaMeasuringAddPolyToShapefile
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void AreaMeasuringAddPolyToShapefileTest()
        {
            MapWindowForm_Accessor target = new MapWindowForm_Accessor(); // TODO: Initialize to an appropriate value
            target.AreaMeasuringAddPolyToShapefile();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MapWindowForm Constructor
        ///</summary>
        [TestMethod()]
        public void MapWindowFormConstructorTest()
        {
            MapWindowForm target = new MapWindowForm();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
