using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// using MapWindow.Interfaces;
using System.Drawing;
using MapWinGIS;
using stdole;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for ReportsTest and is intended
    ///to contain all ReportsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ReportsTest
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
        ///A test for StringToUOM
        ///</summary>
        [TestMethod()]
        public void StringToUOMTest()
        {
            string inStr = string.Empty; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.UnitOfMeasure expected = new MapWindow.Interfaces.UnitOfMeasure(); // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.UnitOfMeasure actual;
            actual = Reports.StringToUOM(inStr);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IPictureDispToImage
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void IPictureDispToImageTest()
        {
            Reports_Accessor target = new Reports_Accessor(); // TODO: Initialize to an appropriate value
            IPictureDisp img = null; // TODO: Initialize to an appropriate value
            System.Drawing.Image expected = null; // TODO: Initialize to an appropriate value
            System.Drawing.Image actual;
            actual = target.IPictureDispToImage(img);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetScreenPicture
        ///</summary>
        [TestMethod()]
        public void GetScreenPictureTest()
        {
            Reports target = new Reports(); // TODO: Initialize to an appropriate value
            Extents BoundBox = null; // TODO: Initialize to an appropriate value
            MapWinGIS.Image expected = null; // TODO: Initialize to an appropriate value
            MapWinGIS.Image actual;
            actual = target.GetScreenPicture(BoundBox);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetScaleBar
        ///</summary>
        [TestMethod()]
        public void GetScaleBarTest1()
        {
            MapWindow.Interfaces.Reports target = new MapWindow.Reports(); // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.UnitOfMeasure MapUnits = new MapWindow.Interfaces.UnitOfMeasure(); // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.UnitOfMeasure ScaleBarUnits = new MapWindow.Interfaces.UnitOfMeasure(); // TODO: Initialize to an appropriate value
            int MaxWidth = 0; // TODO: Initialize to an appropriate value
            System.Drawing.Image expected = null; // TODO: Initialize to an appropriate value
            System.Drawing.Image actual;
            actual = target.GetScaleBar(MapUnits, ScaleBarUnits, MaxWidth);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetScaleBar
        ///</summary>
        [TestMethod()]
        public void GetScaleBarTest()
        {
            Reports target = new Reports(); // TODO: Initialize to an appropriate value
            string MapUnits = string.Empty; // TODO: Initialize to an appropriate value
            string ScalebarUnits = string.Empty; // TODO: Initialize to an appropriate value
            int MaxWidth = 0; // TODO: Initialize to an appropriate value
            System.Drawing.Image expected = null; // TODO: Initialize to an appropriate value
            System.Drawing.Image actual;
            actual = target.GetScaleBar(MapUnits, ScalebarUnits, MaxWidth);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetNorthArrow
        ///</summary>
        [TestMethod()]
        public void GetNorthArrowTest()
        {
            Reports target = new Reports(); // TODO: Initialize to an appropriate value
            System.Drawing.Image expected = null; // TODO: Initialize to an appropriate value
            System.Drawing.Image actual;
            actual = target.GetNorthArrow();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetLegendSnapshot2
        ///</summary>
        [TestMethod()]
        public void GetLegendSnapshotTest()
        {
            MapWindow.Reports target = new Reports(); // TODO: Initialize to an appropriate value
            int VisibleLayersOnly = 0; // TODO: Initialize to an appropriate value
            int imgWidth = 0; // TODO: Initialize to an appropriate value
            System.Drawing.Image expected = null; // TODO: Initialize to an appropriate value
            System.Drawing.Image actual;
            actual = target.GetLegendSnapshot(VisibleLayersOnly, imgWidth);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetLegendSnapshot
        ///</summary>
        [TestMethod()]
        public void GetLegendLayerSnapshotTest()
        {
            MapWindow.Interfaces.Reports target = new Reports(); // TODO: Initialize to an appropriate value
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            int imgWidth = 0; // TODO: Initialize to an appropriate value
            System.Drawing.Image expected = null; // TODO: Initialize to an appropriate value
            System.Drawing.Image actual;
            actual = target.GetLegendLayerSnapshot(LayerHandle, imgWidth);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Reports Constructor
        ///</summary>
        [TestMethod()]
        public void ReportsConstructorTest()
        {
            Reports target = new Reports();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
