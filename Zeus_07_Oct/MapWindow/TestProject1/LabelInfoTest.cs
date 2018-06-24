using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MapWinGIS;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for LabelInfoTest and is intended
    ///to contain all LabelInfoTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LabelInfoTest
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
        ///A test for LabelInfo Constructor
        ///</summary>
        [TestMethod()]
        public void LabelInfoConstructorTest1()
        {
            bool UseZoomLevel = false; // TODO: Initialize to an appropriate value
            Extents ex = null; // TODO: Initialize to an appropriate value
            LabelInfo target = new LabelInfo(UseZoomLevel, ex);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for LabelInfo Constructor
        ///</summary>
        [TestMethod()]
        public void LabelInfoConstructorTest()
        {
            bool UseZoomLevel = false; // TODO: Initialize to an appropriate value
            double xMin = 0F; // TODO: Initialize to an appropriate value
            double yMin = 0F; // TODO: Initialize to an appropriate value
            double xMax = 0F; // TODO: Initialize to an appropriate value
            double yMax = 0F; // TODO: Initialize to an appropriate value
            LabelInfo target = new LabelInfo(UseZoomLevel, xMin, yMin, xMax, yMax);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
