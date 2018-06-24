using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for TableOpenerTest and is intended
    ///to contain all TableOpenerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TableOpenerTest
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
        ///A test for OpenAnyTable
        ///</summary>
        [TestMethod()]
        public void OpenAnyTableTest()
        {
            string aFilename = string.Empty; // TODO: Initialize to an appropriate value
            IATCTable expected = null; // TODO: Initialize to an appropriate value
            IATCTable actual;
            actual = TableOpener.OpenAnyTable(aFilename);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TableOpener Constructor
        ///</summary>
        [TestMethod()]
        public void TableOpenerConstructorTest()
        {
            TableOpener target = new TableOpener();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
