using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
// using MapWindow.Interfaces;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for ShapesTest and is intended
    ///to contain all ShapesTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ShapesTest
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
        ///A test for NumShapes
        ///</summary>
        [TestMethod()]
        public void NumShapesTest()
        {
            MapWindow.Shapes target = new MapWindow.Shapes(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.NumShapes;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LayerHandle
        ///</summary>
        [TestMethod()]
        public void LayerHandleTest()
        {
            Shapes target = new Shapes(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.LayerHandle = expected;
            actual = target.LayerHandle;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Item
        ///</summary>
        [TestMethod()]
        public void ItemTest()
        {
            MapWindow.Interfaces.Shapes target = new MapWindow.Shapes(); // TODO: Initialize to an appropriate value
            int Index = 0; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Shape actual;
            actual = target[Index];
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetEnumerator
        ///</summary>
        [TestMethod()]
        public void GetEnumeratorTest()
        {
            IEnumerable target = new Shapes(); // TODO: Initialize to an appropriate value
            IEnumerator expected = null; // TODO: Initialize to an appropriate value
            IEnumerator actual;
            actual = target.GetEnumerator();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Shapes Constructor
        ///</summary>
        [TestMethod()]
        public void ShapesConstructorTest()
        {
            Shapes target = new Shapes();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
