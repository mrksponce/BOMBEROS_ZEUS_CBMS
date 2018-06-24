using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// // using MapWindow.Interfaces;
using System.Drawing;
using MapWinGIS;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for LayerTest and is intended
    ///to contain all LayerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LayerTest
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
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.Visible = expected;
            actual = target.Visible;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for VerticesVisible
        ///</summary>
        [TestMethod()]
        public void VerticesVisibleTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.VerticesVisible = expected;
            actual = target.VerticesVisible;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UseTransparentColor
        ///</summary>
        [TestMethod()]
        public void UseTransparentColorTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.UseTransparentColor = expected;
            actual = target.UseTransparentColor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UserPointType
        ///</summary>
        [TestMethod()]
        public void UserPointTypeTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            MapWinGIS.Image expected = null; // TODO: Initialize to an appropriate value
            MapWinGIS.Image actual;
            target.UserPointType = expected;
            actual = target.UserPointType;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UserLineStipple
        ///</summary>
        [TestMethod()]
        public void UserLineStippleTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.UserLineStipple = expected;
            actual = target.UserLineStipple;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UseLabelCollision
        ///</summary>
        [TestMethod()]
        public void UseLabelCollisionTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.UseLabelCollision = expected;
            actual = target.UseLabelCollision;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UseDynamicVisibility
        ///</summary>
        [TestMethod()]
        public void UseDynamicVisibilityTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.UseDynamicVisibility = expected;
            actual = target.UseDynamicVisibility;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Tag
        ///</summary>
        [TestMethod()]
        public void TagTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Tag = expected;
            actual = target.Tag;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for StandardViewWidth
        ///</summary>
        [TestMethod()]
        public void StandardViewWidthTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            target.StandardViewWidth = expected;
            actual = target.StandardViewWidth;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SkipOverDuringSave
        ///</summary>
        [TestMethod()]
        public void SkipOverDuringSaveTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.SkipOverDuringSave = expected;
            actual = target.SkipOverDuringSave;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Shapes
        ///</summary>
        [TestMethod()]
        public void ShapesTest()
        {
            MapWindow.Interfaces.Layer target = new Layer(); // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Shapes actual;
            actual = target.Shapes;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ShapeLayerFillTransparency
        ///</summary>
        [TestMethod()]
        public void ShapeLayerFillTransparencyTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.ShapeLayerFillTransparency = expected;
            actual = target.ShapeLayerFillTransparency;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Projection
        ///</summary>
        [TestMethod()]
        public void ProjectionTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Projection = expected;
            actual = target.Projection;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PointType
        ///</summary>
        [TestMethod()]
        public void PointTypeTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            tkPointType expected = new tkPointType(); // TODO: Initialize to an appropriate value
            tkPointType actual;
            target.PointType = expected;
            actual = target.PointType;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PointImageScheme
        ///</summary>
        [TestMethod()]
        public void PointImageSchemeTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            target.PointImageScheme = expected;
            actual = target.PointImageScheme;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OutlineColor
        ///</summary>
        [TestMethod()]
        public void OutlineColorTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
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
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Name = expected;
            actual = target.Name;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LineStipple
        ///</summary>
        [TestMethod()]
        public void LineStippleTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            tkLineStipple expected = new tkLineStipple(); // TODO: Initialize to an appropriate value
            tkLineStipple actual;
            target.LineStipple = expected;
            actual = target.LineStipple;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LineSeparationFactor
        ///</summary>
        [TestMethod()]
        public void LineSeparationFactorTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.LineSeparationFactor = expected;
            actual = target.LineSeparationFactor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LineOrPointSize
        ///</summary>
        [TestMethod()]
        public void LineOrPointSizeTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.LineOrPointSize = expected;
            actual = target.LineOrPointSize;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LayerType
        ///</summary>
        [TestMethod()]
        public void LayerTypeTest()
        {
            MapWindow.Interfaces.Layer target = new Layer(); // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.eLayerType actual;
            actual = target.LayerType;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LabelsVisible
        ///</summary>
        [TestMethod()]
        public void LabelsVisibleTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.LabelsVisible = expected;
            actual = target.LabelsVisible;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LabelsShadowColor
        ///</summary>
        [TestMethod()]
        public void LabelsShadowColorTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            Color expected = new Color(); // TODO: Initialize to an appropriate value
            Color actual;
            target.LabelsShadowColor = expected;
            actual = target.LabelsShadowColor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LabelsShadow
        ///</summary>
        [TestMethod()]
        public void LabelsShadowTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.LabelsShadow = expected;
            actual = target.LabelsShadow;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LabelsScale
        ///</summary>
        [TestMethod()]
        public void LabelsScaleTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.LabelsScale = expected;
            actual = target.LabelsScale;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LabelsOffset
        ///</summary>
        [TestMethod()]
        public void LabelsOffsetTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.LabelsOffset = expected;
            actual = target.LabelsOffset;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for System.Drawing.ImageTransparentColor
        ///</summary>
        [TestMethod()]
        public void ImageTransparentColorTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            Color expected = new Color(); // TODO: Initialize to an appropriate value
            Color actual;
            target.ImageTransparentColor = expected;
            actual = target.ImageTransparentColor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Icon
        ///</summary>
        [TestMethod()]
        public void IconTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            target.Icon = expected;
            actual = target.Icon;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HideFromLegend
        ///</summary>
        [TestMethod()]
        public void HideFromLegendTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.HideFromLegend = expected;
            actual = target.HideFromLegend;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Handle
        ///</summary>
        [TestMethod()]
        public void HandleTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.Handle = expected;
            actual = target.Handle;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GroupPosition
        ///</summary>
        [TestMethod()]
        public void GroupPositionTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.GroupPosition = expected;
            actual = target.GroupPosition;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GroupHandle
        ///</summary>
        [TestMethod()]
        public void GroupHandleTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.GroupHandle = expected;
            actual = target.GroupHandle;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GlobalPosition
        ///</summary>
        [TestMethod()]
        public void GlobalPositionTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.GlobalPosition = expected;
            actual = target.GlobalPosition;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetGridObject
        ///</summary>
        [TestMethod()]
        public void GetGridObjectTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            Grid actual;
            actual = target.GetGridObject;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FillStipple
        ///</summary>
        [TestMethod()]
        public void FillStippleTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            tkFillStipple expected = new tkFillStipple(); // TODO: Initialize to an appropriate value
            tkFillStipple actual;
            target.FillStipple = expected;
            actual = target.FillStipple;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FileName
        ///</summary>
        [TestMethod()]
        public void FileNameTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.FileName;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Extents
        ///</summary>
        [TestMethod()]
        public void ExtentsTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            Extents actual;
            actual = target.Extents;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Expanded
        ///</summary>
        [TestMethod()]
        public void ExpandedTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.Expanded = expected;
            actual = target.Expanded;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DynamicVisibilityExtents
        ///</summary>
        [TestMethod()]
        public void DynamicVisibilityExtentsTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            Extents expected = null; // TODO: Initialize to an appropriate value
            Extents actual;
            target.DynamicVisibilityExtents = expected;
            actual = target.DynamicVisibilityExtents;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DrawFill
        ///</summary>
        [TestMethod()]
        public void DrawFillTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.DrawFill = expected;
            actual = target.DrawFill;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ColoringScheme
        ///</summary>
        [TestMethod()]
        public void ColoringSchemeTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            target.ColoringScheme = expected;
            actual = target.ColoringScheme;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Color
        ///</summary>
        [TestMethod()]
        public void ColorTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            Color expected = new Color(); // TODO: Initialize to an appropriate value
            Color actual;
            target.Color = expected;
            actual = target.Color;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ZoomTo
        ///</summary>
        [TestMethod()]
        public void ZoomToTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            target.ZoomTo();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UserPointImageListItem
        ///</summary>
        [TestMethod()]
        public void UserPointImageListItemTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            long imageIndex = 0; // TODO: Initialize to an appropriate value
            MapWinGIS.Image expected = null; // TODO: Initialize to an appropriate value
            MapWinGIS.Image actual;
            actual = target.UserPointImageListItem(imageIndex);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UserPointImageListCount
        ///</summary>
        [TestMethod()]
        public void UserPointImageListCountTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            long expected = 0; // TODO: Initialize to an appropriate value
            long actual;
            actual = target.UserPointImageListCount();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UserPointImageListAdd
        ///</summary>
        [TestMethod()]
        public void UserPointImageListAddTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            MapWinGIS.Image newValue = null; // TODO: Initialize to an appropriate value
            long expected = 0; // TODO: Initialize to an appropriate value
            long actual;
            actual = target.UserPointImageListAdd(newValue);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UpdateLabelInfo
        ///</summary>
        [TestMethod()]
        public void UpdateLabelInfoTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            target.UpdateLabelInfo();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ShowVertices
        ///</summary>
        [TestMethod()]
        public void ShowVerticesTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            Color color = new Color(); // TODO: Initialize to an appropriate value
            int vertexSize = 0; // TODO: Initialize to an appropriate value
            target.ShowVertices(color, vertexSize);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetUserFillStipple
        ///</summary>
        [TestMethod()]
        public void SetUserFillStippleTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            int Row = 0; // TODO: Initialize to an appropriate value
            int Value = 0; // TODO: Initialize to an appropriate value
            target.SetUserFillStipple(Row, Value);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SaveShapeLayerProps
        ///</summary>
        [TestMethod()]
        public void SaveShapeLayerPropsTest1()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            string saveToFilename = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.SaveShapeLayerProps(saveToFilename);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SaveShapeLayerProps
        ///</summary>
        [TestMethod()]
        public void SaveShapeLayerPropsTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.SaveShapeLayerProps();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MoveTo
        ///</summary>
        [TestMethod()]
        public void MoveToTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            int NewPosition = 0; // TODO: Initialize to an appropriate value
            int TargetGroup = 0; // TODO: Initialize to an appropriate value
            target.MoveTo(NewPosition, TargetGroup);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadShapeLayerProps
        ///</summary>
        [TestMethod()]
        public void LoadShapeLayerPropsTest1()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.LoadShapeLayerProps();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LoadShapeLayerProps
        ///</summary>
        [TestMethod()]
        public void LoadShapeLayerPropsTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            string loadFromFilename = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.LoadShapeLayerProps(loadFromFilename);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LabelColor
        ///</summary>
        [TestMethod()]
        public void LabelColorTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            Color labelColor = new Color(); // TODO: Initialize to an appropriate value
            target.LabelColor(labelColor);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for HideVertices
        ///</summary>
        [TestMethod()]
        public void HideVerticesTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            target.HideVertices();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetUserFillStipple
        ///</summary>
        [TestMethod()]
        public void GetUserFillStippleTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            int Row = 0; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetUserFillStipple(Row);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetObject
        ///</summary>
        [TestMethod()]
        public void GetObjectTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            actual = target.GetObject();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetLayerType
        ///</summary>
        [TestMethod()]
        public void GetLayerTypeTest()
        {
            MapWindow.Layer target = new Layer(); // TODO: Initialize to an appropriate value
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.eLayerType expected = new MapWindow.Interfaces.eLayerType(); // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.eLayerType actual;
            actual = target.GetLayerType(LayerHandle);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Font
        ///</summary>
        [TestMethod()]
        public void FontTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            string FontName = string.Empty; // TODO: Initialize to an appropriate value
            int FontSize = 0; // TODO: Initialize to an appropriate value
            target.Font(FontName, FontSize);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ClearUDPointImageList
        ///</summary>
        [TestMethod()]
        public void ClearUDPointImageListTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            target.ClearUDPointImageList();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ClearLabels
        ///</summary>
        [TestMethod()]
        public void ClearLabelsTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            target.ClearLabels();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddLabelEx
        ///</summary>
        [TestMethod()]
        public void AddLabelExTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            string Text = string.Empty; // TODO: Initialize to an appropriate value
            Color TextColor = new Color(); // TODO: Initialize to an appropriate value
            double xPos = 0F; // TODO: Initialize to an appropriate value
            double yPos = 0F; // TODO: Initialize to an appropriate value
            tkHJustification Justification = new tkHJustification(); // TODO: Initialize to an appropriate value
            double Rotation = 0F; // TODO: Initialize to an appropriate value
            target.AddLabelEx(Text, TextColor, xPos, yPos, Justification, Rotation);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddLabel
        ///</summary>
        [TestMethod()]
        public void AddLabelTest()
        {
            Layer target = new Layer(); // TODO: Initialize to an appropriate value
            string Text = string.Empty; // TODO: Initialize to an appropriate value
            Color TextColor = new Color(); // TODO: Initialize to an appropriate value
            double xPos = 0F; // TODO: Initialize to an appropriate value
            double yPos = 0F; // TODO: Initialize to an appropriate value
            tkHJustification Justification = new tkHJustification(); // TODO: Initialize to an appropriate value
            target.AddLabel(Text, TextColor, xPos, yPos, Justification);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Layer Constructor
        ///</summary>
        [TestMethod()]
        public void LayerConstructorTest()
        {
            Layer target = new Layer();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
