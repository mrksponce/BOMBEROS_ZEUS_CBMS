using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for clsProjections_clsProjectionTest and is intended
    ///to contain all clsProjections_clsProjectionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class clsProjections_clsProjectionTest
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
        ///A test for clsProjection Constructor
        ///</summary>
        [TestMethod()]
        public void clsProjections_clsProjectionConstructorTest1()
        {
            string iMainCateg = string.Empty; // TODO: Initialize to an appropriate value
            string iCategory = string.Empty; // TODO: Initialize to an appropriate value
            string iName = string.Empty; // TODO: Initialize to an appropriate value
            string iPROJ4 = string.Empty; // TODO: Initialize to an appropriate value
            string iESRIWKT = string.Empty; // TODO: Initialize to an appropriate value
            string iSTDWKT = string.Empty; // TODO: Initialize to an appropriate value
            clsProjections.clsProjection target = new clsProjections.clsProjection(iMainCateg, iCategory, iName, iPROJ4, iESRIWKT, iSTDWKT);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for clsProjection Constructor
        ///</summary>
        [TestMethod()]
        public void clsProjections_clsProjectionConstructorTest()
        {
            clsProjections.clsProjection target = new clsProjections.clsProjection();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
