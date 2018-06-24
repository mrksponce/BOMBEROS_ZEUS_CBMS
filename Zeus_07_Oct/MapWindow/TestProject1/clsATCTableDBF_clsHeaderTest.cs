using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for clsATCTableDBF_clsHeaderTest and is intended
    ///to contain all clsATCTableDBF_clsHeaderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class clsATCTableDBF_clsHeaderTest
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
        ///A test for WriteToFile
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void WriteToFileTest()
        {
            clsATCTableDBF_Accessor.clsHeader target = new clsATCTableDBF_Accessor.clsHeader(); // TODO: Initialize to an appropriate value
            short outFile = 0; // TODO: Initialize to an appropriate value
            target.WriteToFile(outFile);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ReadFromFile
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ReadFromFileTest()
        {
            clsATCTableDBF_Accessor.clsHeader target = new clsATCTableDBF_Accessor.clsHeader(); // TODO: Initialize to an appropriate value
            short inFile = 0; // TODO: Initialize to an appropriate value
            target.ReadFromFile(inFile);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for clsHeader Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void clsATCTableDBF_clsHeaderConstructorTest()
        {
            clsATCTableDBF_Accessor.clsHeader target = new clsATCTableDBF_Accessor.clsHeader();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
