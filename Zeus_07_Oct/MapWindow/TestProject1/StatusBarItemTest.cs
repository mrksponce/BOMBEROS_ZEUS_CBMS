using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// using MapWindow.Interfaces;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for StatusBarItemTest and is intended
    ///to contain all StatusBarItemTest Unit Tests
    ///</summary>
    [TestClass()]
    public class StatusBarItemTest
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
        ///A test for Width
        ///</summary>
        [TestMethod()]
        public void WidthTest()
        {
            MapWindow.StatusBarItem target = new MapWindow.StatusBarItem(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.Width = expected;
            actual = target.Width;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Text
        ///</summary>
        [TestMethod()]
        public void TextTest()
        {
            StatusBarItem target = new StatusBarItem(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Text = expected;
            actual = target.Text;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MinWidth
        ///</summary>
        [TestMethod()]
        public void MinWidthTest()
        {
            StatusBarItem target = new StatusBarItem(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.MinWidth = expected;
            actual = target.MinWidth;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AutoSize
        ///</summary>
        [TestMethod()]
        public void AutoSizeTest()
        {
            StatusBarItem target = new StatusBarItem(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.AutoSize = expected;
            actual = target.AutoSize;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Alignment
        ///</summary>
        [TestMethod()]
        public void AlignmentTest()
        {
            StatusBarItem target = new StatusBarItem(); // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.eAlignment expected = new MapWindow.Interfaces.eAlignment(); // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.eAlignment actual;
            target.Alignment = expected;
            actual = target.Alignment;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for StatusBarItem Constructor
        ///</summary>
        [TestMethod()]
        public void StatusBarItemConstructorTest1()
        {
            int Index = 0; // TODO: Initialize to an appropriate value
            StatusBarItem target = new StatusBarItem(Index);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for StatusBarItem Constructor
        ///</summary>
        [TestMethod()]
        public void StatusBarItemConstructorTest()
        {
            StatusBarItem target = new StatusBarItem();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
