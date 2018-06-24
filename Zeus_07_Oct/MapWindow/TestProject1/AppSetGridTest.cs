using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using MapWinGIS;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for AppSetGridTest and is intended
    ///to contain all AppSetGridTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AppSetGridTest
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
        ///A test for ResizeBehavior
        ///</summary>
        [TestMethod()]
        public void ResizeBehaviorTest()
        {
            AppSetGrid target = new AppSetGrid(); // TODO: Initialize to an appropriate value
            tkResizeBehavior expected = new tkResizeBehavior(); // TODO: Initialize to an appropriate value
            tkResizeBehavior actual;
            target.ResizeBehavior = expected;
            actual = target.ResizeBehavior;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OverrideSystemLocale
        ///</summary>
        [TestMethod()]
        public void OverrideSystemLocaleTest()
        {
            AppSetGrid target = new AppSetGrid(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.OverrideSystemLocale = expected;
            actual = target.OverrideSystemLocale;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MouseWheelZoom
        ///</summary>
        [TestMethod()]
        public void MouseWheelZoomTest()
        {
            AppSetGrid target = new AppSetGrid(); // TODO: Initialize to an appropriate value
            MouseWheelZoomDir expected = new MouseWheelZoomDir(); // TODO: Initialize to an appropriate value
            MouseWheelZoomDir actual;
            target.MouseWheelZoom = expected;
            actual = target.MouseWheelZoom;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Locale
        ///</summary>
        [TestMethod()]
        public void LocaleTest()
        {
            AppSetGrid target = new AppSetGrid(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Locale = expected;
            actual = target.Locale;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LabelsUseProjectLevel
        ///</summary>
        [TestMethod()]
        public void LabelsUseProjectLevelTest()
        {
            AppSetGrid target = new AppSetGrid(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.LabelsUseProjectLevel = expected;
            actual = target.LabelsUseProjectLevel;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GeoTIFFAndImgBehavior
        ///</summary>
        [TestMethod()]
        public void GeoTIFFAndImgBehaviorTest()
        {
            AppSetGrid target = new AppSetGrid(); // TODO: Initialize to an appropriate value
            GeoTIFFAndImgBehavior expected = new GeoTIFFAndImgBehavior(); // TODO: Initialize to an appropriate value
            GeoTIFFAndImgBehavior actual;
            target.GeoTIFFAndImgBehavior = expected;
            actual = target.GeoTIFFAndImgBehavior;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ESRIBehavior
        ///</summary>
        [TestMethod()]
        public void ESRIBehaviorTest()
        {
            AppSetGrid target = new AppSetGrid(); // TODO: Initialize to an appropriate value
            ESRIBehavior expected = new ESRIBehavior(); // TODO: Initialize to an appropriate value
            ESRIBehavior actual;
            target.ESRIBehavior = expected;
            actual = target.ESRIBehavior;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DisplayWelcome
        ///</summary>
        [TestMethod()]
        public void DisplayWelcomeTest()
        {
            AppSetGrid target = new AppSetGrid(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.DisplayWelcome = expected;
            actual = target.DisplayWelcome;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DebugLog
        ///</summary>
        [TestMethod()]
        public void DebugLogTest()
        {
            AppSetGrid target = new AppSetGrid(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.DebugLog = expected;
            actual = target.DebugLog;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BackgroundColor
        ///</summary>
        [TestMethod()]
        public void BackgroundColorTest()
        {
            AppSetGrid target = new AppSetGrid(); // TODO: Initialize to an appropriate value
            Color expected = new Color(); // TODO: Initialize to an appropriate value
            Color actual;
            target.BackgroundColor = expected;
            actual = target.BackgroundColor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AppSetGrid Constructor
        ///</summary>
        [TestMethod()]
        public void AppSetGridConstructorTest()
        {
            AppSetGrid target = new AppSetGrid();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
