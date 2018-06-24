using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// using MapWindow.Interfaces;
using System.Windows.Forms;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for StatusBarTest and is intended
    ///to contain all StatusBarTest Unit Tests
    ///</summary>
    [TestClass()]
    public class StatusBarTest
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
        ///A test for ShowProgressBar
        ///</summary>
        [TestMethod()]
        public void ShowProgressBarTest()
        {
            MapWindow.StatusBar target = new MapWindow.StatusBar(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.ShowProgressBar = expected;
            actual = target.ShowProgressBar;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ProgressBarValue
        ///</summary>
        [TestMethod()]
        public void ProgressBarValueTest()
        {
            MapWindow.StatusBar target = new MapWindow.StatusBar(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.ProgressBarValue = expected;
            actual = target.ProgressBarValue;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for NumPanels
        ///</summary>
        [TestMethod()]
        public void NumPanelsTest()
        {
            MapWindow.StatusBar target = new MapWindow.StatusBar(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.NumPanels;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Item
        ///</summary>
        [TestMethod()]
        public void ItemTest()
        {
            MapWindow.Interfaces.StatusBar target = new MapWindow.StatusBar(); // TODO: Initialize to an appropriate value
            int index = 0; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.StatusBarItem actual;
            actual = target[index];
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Enabled
        ///</summary>
        [TestMethod()]
        public void EnabledTest()
        {
            MapWindow.Interfaces.StatusBar target = new MapWindow.StatusBar(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.Enabled = expected;
            actual = target.Enabled;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ResizeProgressBar
        ///</summary>
        [TestMethod()]
        public void ResizeProgressBarTest()
        {
            MapWindow.Interfaces.StatusBar target = new MapWindow.StatusBar(); // TODO: Initialize to an appropriate value
            target.ResizeProgressBar();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for RemovePanel
        ///</summary>
        [TestMethod()]
        public void RemovePanelTest1()
        {
            MapWindow.Interfaces.StatusBar target = new MapWindow.StatusBar(); // TODO: Initialize to an appropriate value
            int Index = 0; // TODO: Initialize to an appropriate value
            target.RemovePanel(Index);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for RemovePanel
        ///</summary>
        [TestMethod()]
        public void RemovePanelTest()
        {
            MapWindow.Interfaces.StatusBar target = new MapWindow.StatusBar(); // TODO: Initialize to an appropriate value
            StatusBarPanel Panel = null; // TODO: Initialize to an appropriate value
            StatusBarPanel PanelExpected = null; // TODO: Initialize to an appropriate value
            target.RemovePanel(ref Panel);
            Assert.AreEqual(PanelExpected, Panel);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddPanel
        ///</summary>
        [TestMethod()]
        public void AddPanelTest2()
        {
            MapWindow.Interfaces.StatusBar target = new MapWindow.StatusBar(); // TODO: Initialize to an appropriate value
            int InsertAt = 0; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.StatusBarItem expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.StatusBarItem actual;
            actual = target.AddPanel(InsertAt);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddPanel
        ///</summary>
        [TestMethod()]
        public void AddPanelTest1()
        {
            MapWindow.Interfaces.StatusBar target = new MapWindow.StatusBar(); // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.StatusBarItem expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.StatusBarItem actual;
            actual = target.AddPanel();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddPanel
        ///</summary>
        [TestMethod()]
        public void AddPanelTest()
        {
            MapWindow.Interfaces.StatusBar target = new MapWindow.StatusBar(); // TODO: Initialize to an appropriate value
            string Text = string.Empty; // TODO: Initialize to an appropriate value
            int Position = 0; // TODO: Initialize to an appropriate value
            int Width = 0; // TODO: Initialize to an appropriate value
            StatusBarPanelAutoSize AutoSize = new StatusBarPanelAutoSize(); // TODO: Initialize to an appropriate value
            StatusBarPanel expected = null; // TODO: Initialize to an appropriate value
            StatusBarPanel actual;
            actual = target.AddPanel(Text, Position, Width, AutoSize);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for StatusBar Constructor
        ///</summary>
        [TestMethod()]
        public void StatusBarConstructorTest()
        {
            MapWindow.Interfaces.StatusBar target = new MapWindow.StatusBar();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
