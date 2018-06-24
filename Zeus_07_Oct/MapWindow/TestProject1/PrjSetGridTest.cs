using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for PrjSetGridTest and is intended
    ///to contain all PrjSetGridTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PrjSetGridTest
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
        ///A test for UseSpecifyProjection
        ///</summary>
        [TestMethod()]
        public void UseSpecifyProjectionTest()
        {
            PrjSetGrid target = new PrjSetGrid(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.UseSpecifyProjection = expected;
            actual = target.UseSpecifyProjection;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TransparentSelection
        ///</summary>
        [TestMethod()]
        public void TransparentSelectionTest()
        {
            PrjSetGrid target = new PrjSetGrid(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.TransparentSelection = expected;
            actual = target.TransparentSelection;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for StatusCoordsRounding
        ///</summary>
        [TestMethod()]
        public void StatusCoordsRoundingTest()
        {
            PrjSetGrid target = new PrjSetGrid(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.StatusCoordsRounding = expected;
            actual = target.StatusCoordsRounding;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for StatusCoordsCommas
        ///</summary>
        [TestMethod()]
        public void StatusCoordsCommasTest()
        {
            PrjSetGrid target = new PrjSetGrid(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.StatusCoordsCommas = expected;
            actual = target.StatusCoordsCommas;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for StatusAlternateCoordsRounding
        ///</summary>
        [TestMethod()]
        public void StatusAlternateCoordsRoundingTest()
        {
            PrjSetGrid target = new PrjSetGrid(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.StatusAlternateCoordsRounding = expected;
            actual = target.StatusAlternateCoordsRounding;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for StatusAlternateCoordsCommas
        ///</summary>
        [TestMethod()]
        public void StatusAlternateCoordsCommasTest()
        {
            PrjSetGrid target = new PrjSetGrid(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.StatusAlternateCoordsCommas = expected;
            actual = target.StatusAlternateCoordsCommas;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ShowProjectionMismatchWarnings
        ///</summary>
        [TestMethod()]
        public void ShowProjectionMismatchWarningsTest()
        {
            PrjSetGrid target = new PrjSetGrid(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.ShowProjectionMismatchWarnings = expected;
            actual = target.ShowProjectionMismatchWarnings;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ShowDataUnits
        ///</summary>
        [TestMethod()]
        public void ShowDataUnitsTest()
        {
            PrjSetGrid target = new PrjSetGrid(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.ShowDataUnits = expected;
            actual = target.ShowDataUnits;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ShowAdditionalUnits
        ///</summary>
        [TestMethod()]
        public void ShowAdditionalUnitsTest()
        {
            PrjSetGrid target = new PrjSetGrid(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.ShowAdditionalUnits = expected;
            actual = target.ShowAdditionalUnits;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SaveShapeSettings
        ///</summary>
        [TestMethod()]
        public void SaveShapeSettingsTest()
        {
            PrjSetGrid target = new PrjSetGrid(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.SaveShapeSettings = expected;
            actual = target.SaveShapeSettings;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            PrjSetGrid target = new PrjSetGrid(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Name = expected;
            actual = target.Name;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MwConfigFileName
        ///</summary>
        [TestMethod()]
        public void MwConfigFileNameTest()
        {
            PrjSetGrid target = new PrjSetGrid(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.MwConfigFileName = expected;
            actual = target.MwConfigFileName;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Group
        ///</summary>
        [TestMethod()]
        public void GroupTest()
        {
            PrjSetGrid target = new PrjSetGrid(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Group = expected;
            actual = target.Group;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DataUnits
        ///</summary>
        [TestMethod()]
        public void DataUnitsTest()
        {
            PrjSetGrid target = new PrjSetGrid(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.DataUnits = expected;
            actual = target.DataUnits;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Category
        ///</summary>
        [TestMethod()]
        public void CategoryTest()
        {
            PrjSetGrid target = new PrjSetGrid(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Category = expected;
            actual = target.Category;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BackgroundColor_UseDefault
        ///</summary>
        [TestMethod()]
        public void BackgroundColor_UseDefaultTest()
        {
            PrjSetGrid target = new PrjSetGrid(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.BackgroundColor_UseDefault = expected;
            actual = target.BackgroundColor_UseDefault;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BackgroundColor
        ///</summary>
        [TestMethod()]
        public void BackgroundColorTest()
        {
            PrjSetGrid target = new PrjSetGrid(); // TODO: Initialize to an appropriate value
            Color expected = new Color(); // TODO: Initialize to an appropriate value
            Color actual;
            target.BackgroundColor = expected;
            actual = target.BackgroundColor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UpdateProjectionSelection
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void UpdateProjectionSelectionTest()
        {
            PrjSetGrid_Accessor target = new PrjSetGrid_Accessor(); // TODO: Initialize to an appropriate value
            target.UpdateProjectionSelection();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetCustomProjection
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void GetCustomProjectionTest()
        {
            PrjSetGrid_Accessor target = new PrjSetGrid_Accessor(); // TODO: Initialize to an appropriate value
            target.GetCustomProjection();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PrjSetGrid Constructor
        ///</summary>
        [TestMethod()]
        public void PrjSetGridConstructorTest()
        {
            PrjSetGrid target = new PrjSetGrid();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
