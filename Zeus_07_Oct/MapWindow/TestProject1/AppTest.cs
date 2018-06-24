using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for AppTest and is intended
    ///to contain all AppTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AppTest
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
        ///A test for VersionString
        ///</summary>
        [TestMethod()]
        public void VersionStringTest()
        {
            string actual;
            actual = App.VersionString;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Revision
        ///</summary>
        [TestMethod()]
        public void RevisionTest()
        {
            int actual;
            actual = App.Revision;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Path
        ///</summary>
        [TestMethod()]
        public void PathTest()
        {
            string actual;
            actual = App.Path;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Minor
        ///</summary>
        [TestMethod()]
        public void MinorTest()
        {
            int actual;
            actual = App.Minor;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Major
        ///</summary>
        [TestMethod()]
        public void MajorTest()
        {
            int actual;
            actual = App.Major;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
