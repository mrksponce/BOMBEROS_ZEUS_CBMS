using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AxMapWinGIS;
using System;
using MapWinGIS;
using System.Drawing;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for PolygonSFInfoTest and is intended
    ///to contain all PolygonSFInfoTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PolygonSFInfoTest
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
        ///A test for VerticesVisible
        ///</summary>
        [TestMethod()]
        public void VerticesVisibleTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            AxMap map = null; // TODO: Initialize to an appropriate value
            PolygonSFInfo target = new PolygonSFInfo(LayerHandle, map); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.VerticesVisible = expected;
            actual = target.VerticesVisible;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for VertexSize
        ///</summary>
        [TestMethod()]
        public void VertexSizeTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            AxMap map = null; // TODO: Initialize to an appropriate value
            PolygonSFInfo target = new PolygonSFInfo(LayerHandle, map); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.VertexSize = expected;
            actual = target.VertexSize;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for VertexColor
        ///</summary>
        [TestMethod()]
        public void VertexColorTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            AxMap map = null; // TODO: Initialize to an appropriate value
            PolygonSFInfo target = new PolygonSFInfo(LayerHandle, map); // TODO: Initialize to an appropriate value
            Color expected = new Color(); // TODO: Initialize to an appropriate value
            Color actual;
            target.VertexColor = expected;
            actual = target.VertexColor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Transparency
        ///</summary>
        [TestMethod()]
        public void TransparencyTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            AxMap map = null; // TODO: Initialize to an appropriate value
            PolygonSFInfo target = new PolygonSFInfo(LayerHandle, map); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.Transparency = expected;
            actual = target.Transparency;
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
            AxMap map = null; // TODO: Initialize to an appropriate value
            PolygonSFInfo target = new PolygonSFInfo(LayerHandle, map); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Tag = expected;
            actual = target.Tag;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ShowFill
        ///</summary>
        [TestMethod()]
        public void ShowFillTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            AxMap map = null; // TODO: Initialize to an appropriate value
            PolygonSFInfo target = new PolygonSFInfo(LayerHandle, map); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.ShowFill = expected;
            actual = target.ShowFill;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Projection
        ///</summary>
        [TestMethod()]
        public void ProjectionTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            AxMap map = null; // TODO: Initialize to an appropriate value
            PolygonSFInfo target = new PolygonSFInfo(LayerHandle, map); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Projection;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OutlineWidth
        ///</summary>
        [TestMethod()]
        public void OutlineWidthTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            AxMap map = null; // TODO: Initialize to an appropriate value
            PolygonSFInfo target = new PolygonSFInfo(LayerHandle, map); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.OutlineWidth = expected;
            actual = target.OutlineWidth;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OutlineColor
        ///</summary>
        [TestMethod()]
        public void OutlineColorTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            AxMap map = null; // TODO: Initialize to an appropriate value
            PolygonSFInfo target = new PolygonSFInfo(LayerHandle, map); // TODO: Initialize to an appropriate value
            Color expected = new Color(); // TODO: Initialize to an appropriate value
            Color actual;
            target.OutlineColor = expected;
            actual = target.OutlineColor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            AxMap map = null; // TODO: Initialize to an appropriate value
            PolygonSFInfo target = new PolygonSFInfo(LayerHandle, map); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Name = expected;
            actual = target.Name;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MapTooltipsEnabled
        ///</summary>
        [TestMethod()]
        public void MapTooltipsEnabledTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            AxMap map = null; // TODO: Initialize to an appropriate value
            PolygonSFInfo target = new PolygonSFInfo(LayerHandle, map); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.MapTooltipsEnabled = expected;
            actual = target.MapTooltipsEnabled;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MapTooltipField
        ///</summary>
        [TestMethod()]
        public void MapTooltipFieldTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            AxMap map = null; // TODO: Initialize to an appropriate value
            PolygonSFInfo target = new PolygonSFInfo(LayerHandle, map); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.MapTooltipField = expected;
            actual = target.MapTooltipField;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LineStyle
        ///</summary>
        [TestMethod()]
        public void LineStyleTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            AxMap map = null; // TODO: Initialize to an appropriate value
            PolygonSFInfo target = new PolygonSFInfo(LayerHandle, map); // TODO: Initialize to an appropriate value
            tkLineStipple expected = new tkLineStipple(); // TODO: Initialize to an appropriate value
            tkLineStipple actual;
            target.LineStyle = expected;
            actual = target.LineStyle;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LegendPicture
        ///</summary>
        [TestMethod()]
        public void LegendPictureTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            AxMap map = null; // TODO: Initialize to an appropriate value
            PolygonSFInfo target = new PolygonSFInfo(LayerHandle, map); // TODO: Initialize to an appropriate value
            Icon expected = null; // TODO: Initialize to an appropriate value
            Icon actual;
            target.LegendPicture = expected;
            actual = target.LegendPicture;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LabelsVisible
        ///</summary>
        [TestMethod()]
        public void LabelsVisibleTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            AxMap map = null; // TODO: Initialize to an appropriate value
            PolygonSFInfo target = new PolygonSFInfo(LayerHandle, map); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.LabelsVisible = expected;
            actual = target.LabelsVisible;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LabelingSetup
        ///</summary>
        [TestMethod()]
        public void LabelingSetupTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            AxMap map = null; // TODO: Initialize to an appropriate value
            PolygonSFInfo target = new PolygonSFInfo(LayerHandle, map); // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            target.LabelingSetup = expected;
            actual = target.LabelingSetup;
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
            AxMap map = null; // TODO: Initialize to an appropriate value
            PolygonSFInfo target = new PolygonSFInfo(LayerHandle, map); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.Handle;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FillStyle
        ///</summary>
        [TestMethod()]
        public void FillStyleTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            AxMap map = null; // TODO: Initialize to an appropriate value
            PolygonSFInfo target = new PolygonSFInfo(LayerHandle, map); // TODO: Initialize to an appropriate value
            tkFillStipple expected = new tkFillStipple(); // TODO: Initialize to an appropriate value
            tkFillStipple actual;
            target.FillStyle = expected;
            actual = target.FillStyle;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FillColor
        ///</summary>
        [TestMethod()]
        public void FillColorTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            AxMap map = null; // TODO: Initialize to an appropriate value
            PolygonSFInfo target = new PolygonSFInfo(LayerHandle, map); // TODO: Initialize to an appropriate value
            Color expected = new Color(); // TODO: Initialize to an appropriate value
            Color actual;
            target.FillColor = expected;
            actual = target.FillColor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Filename
        ///</summary>
        [TestMethod()]
        public void FilenameTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            AxMap map = null; // TODO: Initialize to an appropriate value
            PolygonSFInfo target = new PolygonSFInfo(LayerHandle, map); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Filename;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Expanded
        ///</summary>
        [TestMethod()]
        public void ExpandedTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            AxMap map = null; // TODO: Initialize to an appropriate value
            PolygonSFInfo target = new PolygonSFInfo(LayerHandle, map); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.Expanded = expected;
            actual = target.Expanded;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DynamicVisibility
        ///</summary>
        [TestMethod()]
        public void DynamicVisibilityTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            AxMap map = null; // TODO: Initialize to an appropriate value
            PolygonSFInfo target = new PolygonSFInfo(LayerHandle, map); // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            target.DynamicVisibility = expected;
            actual = target.DynamicVisibility;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ColoringScheme
        ///</summary>
        [TestMethod()]
        public void ColoringSchemeTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            AxMap map = null; // TODO: Initialize to an appropriate value
            PolygonSFInfo target = new PolygonSFInfo(LayerHandle, map); // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            target.ColoringScheme = expected;
            actual = target.ColoringScheme;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BoundingBoxZ
        ///</summary>
        [TestMethod()]
        public void BoundingBoxZTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            AxMap map = null; // TODO: Initialize to an appropriate value
            PolygonSFInfo target = new PolygonSFInfo(LayerHandle, map); // TODO: Initialize to an appropriate value
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
            AxMap map = null; // TODO: Initialize to an appropriate value
            PolygonSFInfo target = new PolygonSFInfo(LayerHandle, map); // TODO: Initialize to an appropriate value
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
            AxMap map = null; // TODO: Initialize to an appropriate value
            PolygonSFInfo target = new PolygonSFInfo(LayerHandle, map); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.BoundingBoxX;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OpenLabelingInfo
        ///</summary>
        [TestMethod()]
        public void OpenLabelingInfoTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            AxMap map = null; // TODO: Initialize to an appropriate value
            PolygonSFInfo target = new PolygonSFInfo(LayerHandle, map); // TODO: Initialize to an appropriate value
            target.OpenLabelingInfo();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for FindXYValues
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void FindXYValuesTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            PolygonSFInfo_Accessor target = new PolygonSFInfo_Accessor(param0); // TODO: Initialize to an appropriate value
            Shapefile shpFile = null; // TODO: Initialize to an appropriate value
            int shapeIndex = 0; // TODO: Initialize to an appropriate value
            double x = 0F; // TODO: Initialize to an appropriate value
            double xExpected = 0F; // TODO: Initialize to an appropriate value
            double y = 0F; // TODO: Initialize to an appropriate value
            double yExpected = 0F; // TODO: Initialize to an appropriate value
            target.FindXYValues(shpFile, shapeIndex, ref x, ref y);
            Assert.AreEqual(xExpected, x);
            Assert.AreEqual(yExpected, y);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        public void DisposeTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            AxMap map = null; // TODO: Initialize to an appropriate value
            IDisposable target = new PolygonSFInfo(LayerHandle, map); // TODO: Initialize to an appropriate value
            target.Dispose();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ApplyStyleChanges
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ApplyStyleChangesTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            PolygonSFInfo_Accessor target = new PolygonSFInfo_Accessor(param0); // TODO: Initialize to an appropriate value
            string type = string.Empty; // TODO: Initialize to an appropriate value
            target.ApplyStyleChanges(type);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PolygonSFInfo Constructor
        ///</summary>
        [TestMethod()]
        public void PolygonSFInfoConstructorTest()
        {
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            AxMap map = null; // TODO: Initialize to an appropriate value
            PolygonSFInfo target = new PolygonSFInfo(LayerHandle, map);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
