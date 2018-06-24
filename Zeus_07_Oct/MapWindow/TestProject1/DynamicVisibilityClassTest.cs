using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MapWinGIS;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for DynamicVisibilityClassTest and is intended
    ///to contain all DynamicVisibilityClassTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DynamicVisibilityClassTest
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
        ///A test for Item
        ///</summary>
        [TestMethod()]
        public void ItemTest()
        {
            DynamicVisibilityClass target = new DynamicVisibilityClass(); // TODO: Initialize to an appropriate value
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            DynamicVisibilityClass.DVInfo expected = null; // TODO: Initialize to an appropriate value
            DynamicVisibilityClass.DVInfo actual;
            target[LayerHandle] = expected;
            actual = target[LayerHandle];
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TestLayerZoomExtents
        ///</summary>
        [TestMethod()]
        public void TestLayerZoomExtentsTest()
        {
            DynamicVisibilityClass target = new DynamicVisibilityClass(); // TODO: Initialize to an appropriate value
            target.TestLayerZoomExtents();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Remove
        ///</summary>
        [TestMethod()]
        public void RemoveTest()
        {
            DynamicVisibilityClass target = new DynamicVisibilityClass(); // TODO: Initialize to an appropriate value
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            target.Remove(LayerHandle);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Contains
        ///</summary>
        [TestMethod()]
        public void ContainsTest()
        {
            DynamicVisibilityClass target = new DynamicVisibilityClass(); // TODO: Initialize to an appropriate value
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Contains(LayerHandle);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Clear
        ///</summary>
        [TestMethod()]
        public void ClearTest()
        {
            DynamicVisibilityClass target = new DynamicVisibilityClass(); // TODO: Initialize to an appropriate value
            target.Clear();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest()
        {
            DynamicVisibilityClass target = new DynamicVisibilityClass(); // TODO: Initialize to an appropriate value
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            Extents Extents = null; // TODO: Initialize to an appropriate value
            bool FeatureEnabled = false; // TODO: Initialize to an appropriate value
            target.Add(LayerHandle, Extents, FeatureEnabled);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DynamicVisibilityClass Constructor
        ///</summary>
        [TestMethod()]
        public void DynamicVisibilityClassConstructorTest()
        {
            DynamicVisibilityClass target = new DynamicVisibilityClass();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
