using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MapWinGIS;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for DynamicVisibilityClass_DVInfoTest and is intended
    ///to contain all DynamicVisibilityClass_DVInfoTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DynamicVisibilityClass_DVInfoTest
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
        ///A test for UseDynamicExtents
        ///</summary>
        [TestMethod()]
        public void UseDynamicExtentsTest()
        {
            Extents Exts = null; // TODO: Initialize to an appropriate value
            bool UseExts = false; // TODO: Initialize to an appropriate value
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            DynamicVisibilityClass.DVInfo target = new DynamicVisibilityClass.DVInfo(Exts, UseExts, LayerHandle); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.UseDynamicExtents = expected;
            actual = target.UseDynamicExtents;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DynamicExtents
        ///</summary>
        [TestMethod()]
        public void DynamicExtentsTest()
        {
            Extents Exts = null; // TODO: Initialize to an appropriate value
            bool UseExts = false; // TODO: Initialize to an appropriate value
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            DynamicVisibilityClass.DVInfo target = new DynamicVisibilityClass.DVInfo(Exts, UseExts, LayerHandle); // TODO: Initialize to an appropriate value
            Extents expected = null; // TODO: Initialize to an appropriate value
            Extents actual;
            target.DynamicExtents = expected;
            actual = target.DynamicExtents;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DVInfo Constructor
        ///</summary>
        [TestMethod()]
        public void DynamicVisibilityClass_DVInfoConstructorTest()
        {
            Extents Exts = null; // TODO: Initialize to an appropriate value
            bool UseExts = false; // TODO: Initialize to an appropriate value
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            DynamicVisibilityClass.DVInfo target = new DynamicVisibilityClass.DVInfo(Exts, UseExts, LayerHandle);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
