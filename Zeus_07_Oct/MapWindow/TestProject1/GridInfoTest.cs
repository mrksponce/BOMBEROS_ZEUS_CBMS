using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for GridInfoTest and is intended
    ///to contain all GridInfoTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GridInfoTest
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
        ///A test for UseTransparency
        ///</summary>
        [TestMethod()]
        public void UseTransparencyTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            GridInfo target = new GridInfo(LayerHandle); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.UseTransparency = expected;
            actual = target.UseTransparency;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TransparentColor
        ///</summary>
        [TestMethod()]
        public void TransparentColorTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            GridInfo target = new GridInfo(LayerHandle); // TODO: Initialize to an appropriate value
            Color expected = new Color(); // TODO: Initialize to an appropriate value
            Color actual;
            target.TransparentColor = expected;
            actual = target.TransparentColor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Tag
        ///</summary>
        [TestMethod()]
        public void TagTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            GridInfo target = new GridInfo(LayerHandle); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Tag = expected;
            actual = target.Tag;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Rows
        ///</summary>
        [TestMethod()]
        public void RowsTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            GridInfo target = new GridInfo(LayerHandle); // TODO: Initialize to an appropriate value
            long actual;
            actual = target.Rows;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Projection
        ///</summary>
        [TestMethod()]
        public void ProjectionTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            GridInfo target = new GridInfo(LayerHandle); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Projection;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for NodataValue
        ///</summary>
        [TestMethod()]
        public void NodataValueTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            GridInfo target = new GridInfo(LayerHandle); // TODO: Initialize to an appropriate value
            double actual;
            actual = target.NodataValue;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            GridInfo target = new GridInfo(LayerHandle); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Name = expected;
            actual = target.Name;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MinVal
        ///</summary>
        [TestMethod()]
        public void MinValTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            GridInfo target = new GridInfo(LayerHandle); // TODO: Initialize to an appropriate value
            double actual;
            actual = target.MinVal;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MaxVal
        ///</summary>
        [TestMethod()]
        public void MaxValTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            GridInfo target = new GridInfo(LayerHandle); // TODO: Initialize to an appropriate value
            double actual;
            actual = target.MaxVal;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LegendPicture
        ///</summary>
        [TestMethod()]
        public void LegendPictureTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            GridInfo target = new GridInfo(LayerHandle); // TODO: Initialize to an appropriate value
            Icon expected = null; // TODO: Initialize to an appropriate value
            Icon actual;
            target.LegendPicture = expected;
            actual = target.LegendPicture;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Handle
        ///</summary>
        [TestMethod()]
        public void HandleTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            GridInfo target = new GridInfo(LayerHandle); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.Handle;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GridDataType
        ///</summary>
        [TestMethod()]
        public void GridDataTypeTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            GridInfo target = new GridInfo(LayerHandle); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GridDataType;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Filename
        ///</summary>
        [TestMethod()]
        public void FilenameTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            GridInfo target = new GridInfo(LayerHandle); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Filename;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DynamicVisibility
        ///</summary>
        [TestMethod()]
        public void DynamicVisibilityTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            GridInfo target = new GridInfo(LayerHandle); // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            target.DynamicVisibility = expected;
            actual = target.DynamicVisibility;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Cols
        ///</summary>
        [TestMethod()]
        public void ColsTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            GridInfo target = new GridInfo(LayerHandle); // TODO: Initialize to an appropriate value
            long actual;
            actual = target.Cols;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ColoringScheme
        ///</summary>
        [TestMethod()]
        public void ColoringSchemeTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            GridInfo target = new GridInfo(LayerHandle); // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            target.ColoringScheme = expected;
            actual = target.ColoringScheme;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CellSizeY
        ///</summary>
        [TestMethod()]
        public void CellSizeYTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            GridInfo target = new GridInfo(LayerHandle); // TODO: Initialize to an appropriate value
            double actual;
            actual = target.CellSizeY;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CellSizeX
        ///</summary>
        [TestMethod()]
        public void CellSizeXTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            GridInfo target = new GridInfo(LayerHandle); // TODO: Initialize to an appropriate value
            double actual;
            actual = target.CellSizeX;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BoundingBoxZ
        ///</summary>
        [TestMethod()]
        public void BoundingBoxZTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            GridInfo target = new GridInfo(LayerHandle); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.BoundingBoxZ;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BoundingBoxY
        ///</summary>
        [TestMethod()]
        public void BoundingBoxYTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            GridInfo target = new GridInfo(LayerHandle); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.BoundingBoxY;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BoundingBoxX
        ///</summary>
        [TestMethod()]
        public void BoundingBoxXTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            GridInfo target = new GridInfo(LayerHandle); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.BoundingBoxX;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GridInfo Constructor
        ///</summary>
        [TestMethod()]
        public void GridInfoConstructorTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            GridInfo target = new GridInfo(LayerHandle);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
