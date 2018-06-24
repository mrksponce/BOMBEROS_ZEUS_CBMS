using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
// using MapWindow.Interfaces;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for PreviewMapTest and is intended
    ///to contain all PreviewMapTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PreviewMapTest
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
        ///A test for Picture
        ///</summary>
        [TestMethod()]
        public void PictureTest()
        {
            MapWindow.PreviewMap target = new MapWindow.PreviewMap(); // TODO: Initialize to an appropriate value
            System.Drawing.Image expected = null; // TODO: Initialize to an appropriate value
            System.Drawing.Image actual;
            target.Picture = expected;
            actual = target.Picture;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LocatorBoxColor
        ///</summary>
        [TestMethod()]
        public void LocatorBoxColorTest()
        {
            MapWindow.PreviewMap target = new MapWindow.PreviewMap(); // TODO: Initialize to an appropriate value
            Color expected = new Color(); // TODO: Initialize to an appropriate value
            Color actual;
            target.LocatorBoxColor = expected;
            actual = target.LocatorBoxColor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BackColor
        ///</summary>
        [TestMethod()]
        public void BackColorTest()
        {
            PreviewMap target = new PreviewMap(); // TODO: Initialize to an appropriate value
            Color expected = new Color(); // TODO: Initialize to an appropriate value
            Color actual;
            target.BackColor = expected;
            actual = target.BackColor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UpdatePreview
        ///</summary>
        [TestMethod()]
        public void UpdateTest1()
        {
            MapWindow.Interfaces.PreviewMap target = new PreviewMap(); // TODO: Initialize to an appropriate value
            target.Update();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UpdatePreview
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            MapWindow.Interfaces.PreviewMap target = new PreviewMap(); // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ePreviewUpdateExtents UpdateExtents = new MapWindow.Interfaces.ePreviewUpdateExtents(); // TODO: Initialize to an appropriate value
            target.Update(UpdateExtents);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UpdateLocatorBox
        ///</summary>
        [TestMethod()]
        public void UpdateLocatorBoxTest()
        {
            PreviewMap target = new PreviewMap(); // TODO: Initialize to an appropriate value
            target.UpdateLocatorBox();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetPictureFromMap
        ///</summary>
        [TestMethod()]
        public void GetPictureFromMapTest1()
        {
            PreviewMap target = new PreviewMap(); // TODO: Initialize to an appropriate value
            bool FullExtents = false; // TODO: Initialize to an appropriate value
            target.GetPictureFromMap(FullExtents);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetPictureFromMap
        ///</summary>
        [TestMethod()]
        public void GetPictureFromMapTest()
        {
            PreviewMap target = new PreviewMap(); // TODO: Initialize to an appropriate value
            target.GetPictureFromMap();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetPictureFromFile
        ///</summary>
        [TestMethod()]
        public void GetPictureFromFileTest()
        {
            PreviewMap target = new PreviewMap(); // TODO: Initialize to an appropriate value
            string Filename = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.GetPictureFromFile(Filename);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DrawBox
        ///</summary>
        [TestMethod()]
        public void DrawBoxTest()
        {
            PreviewMap target = new PreviewMap(); // TODO: Initialize to an appropriate value
            Rectangle rect = new Rectangle(); // TODO: Initialize to an appropriate value
            target.DrawBox(rect);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PreviewMap Constructor
        ///</summary>
        [TestMethod()]
        public void PreviewMapConstructorTest()
        {
            PreviewMap target = new PreviewMap();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
