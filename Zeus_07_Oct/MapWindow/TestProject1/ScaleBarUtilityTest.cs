using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MapWinGIS;
// using MapWindow.Interfaces;
using System.Drawing;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for ScaleBarUtilityTest and is intended
    ///to contain all ScaleBarUtilityTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ScaleBarUtilityTest
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
        ///A test for TextWidth
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void TextWidthTest()
        {
            ScaleBarUtility_Accessor target = new ScaleBarUtility_Accessor(); // TODO: Initialize to an appropriate value
            string Text = string.Empty; // TODO: Initialize to an appropriate value
            Font font = null; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.TextWidth(Text, font);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TextHeight
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void TextHeightTest()
        {
            ScaleBarUtility_Accessor target = new ScaleBarUtility_Accessor(); // TODO: Initialize to an appropriate value
            string Text = string.Empty; // TODO: Initialize to an appropriate value
            Font font = null; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.TextHeight(Text, font);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GenerateScaleBarSolid
        ///</summary>
        [TestMethod()]
        public void GenerateScaleBarSolidTest()
        {
            ScaleBarUtility target = new ScaleBarUtility(); // TODO: Initialize to an appropriate value
            Extents MapExtents = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.UnitOfMeasure MapUnits = new MapWindow.Interfaces.UnitOfMeasure(); // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.UnitOfMeasure ScaleBarUnits = new MapWindow.Interfaces.UnitOfMeasure(); // TODO: Initialize to an appropriate value
            int MaxWidth = 0; // TODO: Initialize to an appropriate value
            int Height = 0; // TODO: Initialize to an appropriate value
            Color BackColor = new Color(); // TODO: Initialize to an appropriate value
            Color ForeColor = new Color(); // TODO: Initialize to an appropriate value
            string FontFamily = string.Empty; // TODO: Initialize to an appropriate value
            System.Drawing.Image expected = null; // TODO: Initialize to an appropriate value
            System.Drawing.Image actual;
            actual = target.GenerateScaleBarSolid(MapExtents, MapUnits, ScaleBarUnits, MaxWidth, Height, BackColor, ForeColor, FontFamily);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GenerateScaleBar
        ///</summary>
        [TestMethod()]
        public void GenerateScaleBarTest()
        {
            ScaleBarUtility target = new ScaleBarUtility(); // TODO: Initialize to an appropriate value
            Extents MapExtents = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.UnitOfMeasure MapUnits = new MapWindow.Interfaces.UnitOfMeasure(); // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.UnitOfMeasure ScaleBarUnits = new MapWindow.Interfaces.UnitOfMeasure(); // TODO: Initialize to an appropriate value
            int MaxWidth = 0; // TODO: Initialize to an appropriate value
            Color BackColor = new Color(); // TODO: Initialize to an appropriate value
            Color ForeColor = new Color(); // TODO: Initialize to an appropriate value
            System.Drawing.Image expected = null; // TODO: Initialize to an appropriate value
            System.Drawing.Image actual;
            actual = target.GenerateScaleBar(MapExtents, MapUnits, ScaleBarUnits, MaxWidth, BackColor, ForeColor);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FindSignificantDigits
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void FindSignificantDigitsTest()
        {
            ScaleBarUtility_Accessor target = new ScaleBarUtility_Accessor(); // TODO: Initialize to an appropriate value
            double value = 0F; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.FindSignificantDigits(value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FindNaturalBreak
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void FindNaturalBreakTest()
        {
            ScaleBarUtility_Accessor target = new ScaleBarUtility_Accessor(); // TODO: Initialize to an appropriate value
            double range = 0F; // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            actual = target.FindNaturalBreak(range);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Distance
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DistanceTest1()
        {
            ScaleBarUtility_Accessor target = new ScaleBarUtility_Accessor(); // TODO: Initialize to an appropriate value
            double x1 = 0F; // TODO: Initialize to an appropriate value
            double y1 = 0F; // TODO: Initialize to an appropriate value
            double x2 = 0F; // TODO: Initialize to an appropriate value
            double y2 = 0F; // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            actual = target.Distance(x1, y1, x2, y2);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Distance
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DistanceTest()
        {
            ScaleBarUtility_Accessor target = new ScaleBarUtility_Accessor(); // TODO: Initialize to an appropriate value
            double Lat1 = 0F; // TODO: Initialize to an appropriate value
            double Long1 = 0F; // TODO: Initialize to an appropriate value
            double Lat2 = 0F; // TODO: Initialize to an appropriate value
            double Long2 = 0F; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.UnitOfMeasure DesiredUnits = new MapWindow.Interfaces.UnitOfMeasure(); // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            actual = target.Distance(Lat1, Long1, Lat2, Long2, DesiredUnits);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ConvertUnits
        ///</summary>
        [TestMethod()]
        public void ConvertUnitsTest()
        {
            ScaleBarUtility target = new ScaleBarUtility(); // TODO: Initialize to an appropriate value
            double val = 0F; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.UnitOfMeasure srcUnits = new MapWindow.Interfaces.UnitOfMeasure(); // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.UnitOfMeasure destUnits = new MapWindow.Interfaces.UnitOfMeasure(); // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            actual = target.ConvertUnits(val, srcUnits, destUnits);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ComputeValues
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ComputeValuesTest()
        {
            ScaleBarUtility_Accessor target = new ScaleBarUtility_Accessor(); // TODO: Initialize to an appropriate value
            double Range = 0F; // TODO: Initialize to an appropriate value
            double[] expected = null; // TODO: Initialize to an appropriate value
            double[] actual;
            actual = target.ComputeValues(Range);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CalcRange
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void CalcRangeTest()
        {
            ScaleBarUtility_Accessor target = new ScaleBarUtility_Accessor(); // TODO: Initialize to an appropriate value
            Extents MapExtents = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.UnitOfMeasure MapUnits = new MapWindow.Interfaces.UnitOfMeasure(); // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.UnitOfMeasure ScaleBarUnits = new MapWindow.Interfaces.UnitOfMeasure(); // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.UnitOfMeasure ScaleBarUnitsExpected = new MapWindow.Interfaces.UnitOfMeasure(); // TODO: Initialize to an appropriate value
            int width = 0; // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            actual = target.CalcRange(MapExtents, MapUnits, ref ScaleBarUnits, width);
            Assert.AreEqual(ScaleBarUnitsExpected, ScaleBarUnits);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ScaleBarUtility Constructor
        ///</summary>
        [TestMethod()]
        public void ScaleBarUtilityConstructorTest()
        {
            ScaleBarUtility target = new ScaleBarUtility();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
