using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for PointImageSchemeTest and is intended
    ///to contain all PointImageSchemeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PointImageSchemeTest
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
        ///A test for Visible
        ///</summary>
        [TestMethod()]
        public void VisibleTest()
        {
            long lyrHandle = 0; // TODO: Initialize to an appropriate value
            PointImageScheme target = new PointImageScheme(lyrHandle); // TODO: Initialize to an appropriate value
            string FieldValue = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.set_Visible(FieldValue, expected);
            actual = target.get_Visible(FieldValue);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for NumberItems
        ///</summary>
        [TestMethod()]
        public void NumberItemsTest()
        {
            long lyrHandle = 0; // TODO: Initialize to an appropriate value
            PointImageScheme target = new PointImageScheme(lyrHandle); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.NumberItems;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LastKnownLayerHandle
        ///</summary>
        [TestMethod()]
        public void LastKnownLayerHandleTest()
        {
            long lyrHandle = 0; // TODO: Initialize to an appropriate value
            PointImageScheme target = new PointImageScheme(lyrHandle); // TODO: Initialize to an appropriate value
            long expected = 0; // TODO: Initialize to an appropriate value
            long actual;
            target.LastKnownLayerHandle = expected;
            actual = target.LastKnownLayerHandle;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ImageIndex
        ///</summary>
        [TestMethod()]
        public void ImageIndexTest()
        {
            long lyrHandle = 0; // TODO: Initialize to an appropriate value
            PointImageScheme target = new PointImageScheme(lyrHandle); // TODO: Initialize to an appropriate value
            string FieldValue = string.Empty; // TODO: Initialize to an appropriate value
            long expected = 0; // TODO: Initialize to an appropriate value
            long actual;
            target.set_ImageIndex(FieldValue, expected);
            actual = target.get_ImageIndex(FieldValue);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FieldIndex
        ///</summary>
        [TestMethod()]
        public void FieldIndexTest()
        {
            long lyrHandle = 0; // TODO: Initialize to an appropriate value
            PointImageScheme target = new PointImageScheme(lyrHandle); // TODO: Initialize to an appropriate value
            long expected = 0; // TODO: Initialize to an appropriate value
            long actual;
            target.FieldIndex = expected;
            actual = target.FieldIndex;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Clear
        ///</summary>
        [TestMethod()]
        public void ClearTest()
        {
            long lyrHandle = 0; // TODO: Initialize to an appropriate value
            PointImageScheme target = new PointImageScheme(lyrHandle); // TODO: Initialize to an appropriate value
            target.Clear();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PointImageScheme Constructor
        ///</summary>
        [TestMethod()]
        public void PointImageSchemeConstructorTest()
        {
            long lyrHandle = 0; // TODO: Initialize to an appropriate value
            PointImageScheme target = new PointImageScheme(lyrHandle);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
