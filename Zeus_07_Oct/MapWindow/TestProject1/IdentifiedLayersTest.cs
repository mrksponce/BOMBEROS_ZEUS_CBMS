using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// using MapWindow.Interfaces;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for IdentifiedLayersTest and is intended
    ///to contain all IdentifiedLayersTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IdentifiedLayersTest
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
            MapWindow.Interfaces.IdentifiedLayers target = new MapWindow.IdentifiedLayers(); // TODO: Initialize to an appropriate value
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.IdentifiedShapes actual;
            actual = target[LayerHandle];
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Count
        ///</summary>
        [TestMethod()]
        public void CountTest()
        {
            IdentifiedLayers target = new IdentifiedLayers(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.Count;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Remove
        ///</summary>
        [TestMethod()]
        public void RemoveTest()
        {
            IdentifiedLayers target = new IdentifiedLayers(); // TODO: Initialize to an appropriate value
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            target.Remove(LayerHandle);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest()
        {
            IdentifiedLayers target = new IdentifiedLayers(); // TODO: Initialize to an appropriate value
            IdentifiedShapes Item = null; // TODO: Initialize to an appropriate value
            int hLyr = 0; // TODO: Initialize to an appropriate value
            target.Add(Item, hLyr);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for IdentifiedLayers Constructor
        ///</summary>
        [TestMethod()]
        public void IdentifiedLayersConstructorTest()
        {
            IdentifiedLayers target = new IdentifiedLayers();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
