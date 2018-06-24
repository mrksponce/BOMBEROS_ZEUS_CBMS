using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MapWinUtility;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for MWProgressStatusTest and is intended
    ///to contain all MWProgressStatusTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MWProgressStatusTest
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
        ///A test for Status
        ///</summary>
        [TestMethod()]
        public void StatusTest()
        {
            IProgressStatus target = new MWProgressStatus(); // TODO: Initialize to an appropriate value
            string StatusMessage = string.Empty; // TODO: Initialize to an appropriate value
            target.Status(StatusMessage);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Progress
        ///</summary>
        [TestMethod()]
        public void ProgressTest()
        {
            IProgressStatus target = new MWProgressStatus(); // TODO: Initialize to an appropriate value
            int CurrentPosition = 0; // TODO: Initialize to an appropriate value
            int LastPosition = 0; // TODO: Initialize to an appropriate value
            target.Progress(CurrentPosition, LastPosition);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MWProgressStatus Constructor
        ///</summary>
        [TestMethod()]
        public void MWProgressStatusConstructorTest()
        {
            MWProgressStatus target = new MWProgressStatus();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
