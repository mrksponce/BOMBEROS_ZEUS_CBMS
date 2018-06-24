using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for LabelClassTest and is intended
    ///to contain all LabelClassTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LabelClassTest
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
        ///A test for TestLabelZoomExtents
        ///</summary>
        [TestMethod()]
        public void TestLabelZoomExtentsTest()
        {
            LabelClass target = new LabelClass(); // TODO: Initialize to an appropriate value
            target.TestLabelZoomExtents();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadLabelInfo
        ///</summary>
        [TestMethod()]
        public void LoadLabelInfoTest()
        {
            LabelClass target = new LabelClass(); // TODO: Initialize to an appropriate value
            Layer layer = null; // TODO: Initialize to an appropriate value
            Form owner = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.LoadLabelInfo(layer, owner);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LabelClass Constructor
        ///</summary>
        [TestMethod()]
        public void LabelClassConstructorTest()
        {
            LabelClass target = new LabelClass();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
