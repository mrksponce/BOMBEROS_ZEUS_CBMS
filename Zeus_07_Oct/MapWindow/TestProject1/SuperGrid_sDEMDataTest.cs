using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for SuperGrid_sDEMDataTest and is intended
    ///to contain all SuperGrid_sDEMDataTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SuperGrid_sDEMDataTest
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
        ///A test for MinY
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void MinYTest()
        {
            SuperGrid_Accessor.sDEMData target = new SuperGrid_Accessor.sDEMData(); // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            actual = target.MinY();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MinX
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void MinXTest()
        {
            SuperGrid_Accessor.sDEMData target = new SuperGrid_Accessor.sDEMData(); // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            actual = target.MinX();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MaxY
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void MaxYTest()
        {
            SuperGrid_Accessor.sDEMData target = new SuperGrid_Accessor.sDEMData(); // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            actual = target.MaxY();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MaxX
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void MaxXTest()
        {
            SuperGrid_Accessor.sDEMData target = new SuperGrid_Accessor.sDEMData(); // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            actual = target.MaxX();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
