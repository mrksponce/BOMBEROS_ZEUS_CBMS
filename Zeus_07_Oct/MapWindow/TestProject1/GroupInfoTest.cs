using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for GroupInfoTest and is intended
    ///to contain all GroupInfoTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GroupInfoTest
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
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            int GroupHandle = 0; // TODO: Initialize to an appropriate value
            GroupInfo target = new GroupInfo(GroupHandle); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Name = expected;
            actual = target.Name;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LegendPicture
        ///</summary>
        [TestMethod()]
        public void LegendPictureTest()
        {
            int GroupHandle = 0; // TODO: Initialize to an appropriate value
            GroupInfo target = new GroupInfo(GroupHandle); // TODO: Initialize to an appropriate value
            Icon expected = null; // TODO: Initialize to an appropriate value
            Icon actual;
            target.LegendPicture = expected;
            actual = target.LegendPicture;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GroupInfo Constructor
        ///</summary>
        [TestMethod()]
        public void GroupInfoConstructorTest()
        {
            int GroupHandle = 0; // TODO: Initialize to an appropriate value
            GroupInfo target = new GroupInfo(GroupHandle);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
