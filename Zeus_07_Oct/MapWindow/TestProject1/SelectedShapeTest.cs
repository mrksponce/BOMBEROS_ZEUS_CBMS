using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// using MapWindow.Interfaces;
using System.Drawing;
using MapWinGIS;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for SelectedShapeTest and is intended
    ///to contain all SelectedShapeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SelectedShapeTest
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
        ///A test for ShapeIndex
        ///</summary>
        [TestMethod()]
        public void ShapeIndexTest()
        {
            SelectedShape target = new SelectedShape(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.ShapeIndex;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OriginalTransparency
        ///</summary>
        [TestMethod()]
        public void OriginalTransparencyTest()
        {
            SelectedShape target = new SelectedShape(); // TODO: Initialize to an appropriate value
            float actual;
            actual = target.OriginalTransparency;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OriginalOutlineColor
        ///</summary>
        [TestMethod()]
        public void OriginalOutlineColorTest()
        {
            SelectedShape target = new SelectedShape(); // TODO: Initialize to an appropriate value
            uint actual;
            actual = target.OriginalOutlineColor;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OriginalDrawFill
        ///</summary>
        [TestMethod()]
        public void OriginalDrawFillTest()
        {
            SelectedShape target = new SelectedShape(); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.OriginalDrawFill;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OriginalColor
        ///</summary>
        [TestMethod()]
        public void OriginalColorTest()
        {
            SelectedShape target = new SelectedShape(); // TODO: Initialize to an appropriate value
            uint actual;
            actual = target.OriginalColor;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Extents
        ///</summary>
        [TestMethod()]
        public void ExtentsTest()
        {
            SelectedShape target = new SelectedShape(); // TODO: Initialize to an appropriate value
            Extents actual;
            actual = target.Extents;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest()
        {
            SelectedShape target = new SelectedShape(); // TODO: Initialize to an appropriate value
            int ShapeIndex = 0; // TODO: Initialize to an appropriate value
            Color SelectColor = new Color(); // TODO: Initialize to an appropriate value
            target.Add(ShapeIndex, SelectColor);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SelectedShape Constructor
        ///</summary>
        [TestMethod()]
        public void SelectedShapeConstructorTest()
        {
            SelectedShape target = new SelectedShape();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
