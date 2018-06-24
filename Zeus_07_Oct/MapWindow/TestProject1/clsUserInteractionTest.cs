using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// using MapWindow.Interfaces;
using System.Drawing;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for clsUserInteractionTest and is intended
    ///to contain all clsUserInteractionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class clsUserInteractionTest
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
        ///A test for GetProjectionFromUser
        ///</summary>
        [TestMethod()]
        public void GetProjectionFromUserTest()
        {
            MapWindow.Interfaces.UserInteraction target = new clsUserInteraction(); // TODO: Initialize to an appropriate value
            string DialogCaption = string.Empty; // TODO: Initialize to an appropriate value
            string DefaultProjection = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetProjectionFromUser(DialogCaption, DefaultProjection);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetColorRamp
        ///</summary>
        [TestMethod()]
        public void GetColorRampTest()
        {
            MapWindow.Interfaces.UserInteraction target = new clsUserInteraction(); // TODO: Initialize to an appropriate value
            Color suggestedStart = new Color(); // TODO: Initialize to an appropriate value
            Color suggestedEnd = new Color(); // TODO: Initialize to an appropriate value
            Color selectedStart = new Color(); // TODO: Initialize to an appropriate value
            Color selectedStartExpected = new Color(); // TODO: Initialize to an appropriate value
            Color selectedEnd = new Color(); // TODO: Initialize to an appropriate value
            Color selectedEndExpected = new Color(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.GetColorRamp(suggestedStart, suggestedEnd, out selectedStart, out selectedEnd);
            Assert.AreEqual(selectedStartExpected, selectedStart);
            Assert.AreEqual(selectedEndExpected, selectedEnd);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for clsUserInteraction Constructor
        ///</summary>
        [TestMethod()]
        public void clsUserInteractionConstructorTest()
        {
            clsUserInteraction target = new clsUserInteraction();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
