using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for DynamicVisibilityClass_PointTest and is intended
    ///to contain all DynamicVisibilityClass_PointTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DynamicVisibilityClass_PointTest
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
        ///A test for Dist
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DistTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DynamicVisibilityClass_Accessor.Point target = new DynamicVisibilityClass_Accessor.Point(param0); // TODO: Initialize to an appropriate value
            DynamicVisibilityClass_Accessor.Point p = null; // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            actual = target.Dist(p);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Point Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DynamicVisibilityClass_PointConstructorTest()
        {
            double newX = 0F; // TODO: Initialize to an appropriate value
            double newY = 0F; // TODO: Initialize to an appropriate value
            DynamicVisibilityClass_Accessor.Point target = new DynamicVisibilityClass_Accessor.Point(newX, newY);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
