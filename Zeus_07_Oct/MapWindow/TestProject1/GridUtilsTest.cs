using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MapWinGIS;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for GridUtilsTest and is intended
    ///to contain all GridUtilsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GridUtilsTest
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
        ///A test for StopThread
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void StopThreadTest()
        {
            GridUtils_Accessor target = new GridUtils_Accessor(); // TODO: Initialize to an appropriate value
            target.StopThread();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for StartThread
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void StartThreadTest()
        {
            GridUtils_Accessor target = new GridUtils_Accessor(); // TODO: Initialize to an appropriate value
            target.StartThread();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitThread
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void InitThreadTest()
        {
            GridUtils_Accessor target = new GridUtils_Accessor(); // TODO: Initialize to an appropriate value
            target.InitThread();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GridCdlgFilter
        ///</summary>
        [TestMethod()]
        public void GridCdlgFilterTest()
        {
            GridUtils target = new GridUtils(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GridCdlgFilter();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Finalize
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void FinalizeTest()
        {
            GridUtils_Accessor target = new GridUtils_Accessor(); // TODO: Initialize to an appropriate value
            target.Finalize();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CreateSafeGrid
        ///</summary>
        [TestMethod()]
        public void CreateSafeGridTest()
        {
            GridUtils target = new GridUtils(); // TODO: Initialize to an appropriate value
            Grid expected = null; // TODO: Initialize to an appropriate value
            Grid actual;
            actual = target.CreateSafeGrid();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GridUtils Constructor
        ///</summary>
        [TestMethod()]
        public void GridUtilsConstructorTest()
        {
            GridUtils target = new GridUtils();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
