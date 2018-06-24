using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// using MapWindow.Interfaces;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for clsUIPanelTest and is intended
    ///to contain all clsUIPanelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class clsUIPanelTest
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
        ///A test for SimplifyDockstate
        ///</summary>
        [TestMethod()]
        public void SimplifyDockstateTest1()
        {
            DockStyle DockStyle = new DockStyle(); // TODO: Initialize to an appropriate value
            DockState expected = new DockState(); // TODO: Initialize to an appropriate value
            DockState actual;
            actual = clsUIPanel.SimplifyDockstate(DockStyle);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SimplifyDockstate
        ///</summary>
        [TestMethod()]
        public void SimplifyDockstateTest()
        {
            MapWindow.Interfaces.MapWindowDockStyle DockStyle = new MapWindow.Interfaces.MapWindowDockStyle(); // TODO: Initialize to an appropriate value
            DockState expected = new DockState(); // TODO: Initialize to an appropriate value
            DockState actual;
            actual = clsUIPanel.SimplifyDockstate(DockStyle);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SetPanelVisible
        ///</summary>
        [TestMethod()]
        public void SetPanelVisibleTest()
        {
            MapWindow.Interfaces.UIPanel target = new clsUIPanel(); // TODO: Initialize to an appropriate value
            string Caption = string.Empty; // TODO: Initialize to an appropriate value
            bool Visible = false; // TODO: Initialize to an appropriate value
            target.SetPanelVisible(Caption, Visible);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MarkClosed
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void MarkClosedTest()
        {
            clsUIPanel_Accessor target = new clsUIPanel_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            FormClosingEventArgs e = null; // TODO: Initialize to an appropriate value
            target.MarkClosed(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DeletePanel
        ///</summary>
        [TestMethod()]
        public void DeletePanelTest()
        {
            MapWindow.Interfaces.UIPanel target = new clsUIPanel(); // TODO: Initialize to an appropriate value
            string Caption = string.Empty; // TODO: Initialize to an appropriate value
            target.DeletePanel(Caption);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CreatePanel
        ///</summary>
        [TestMethod()]
        public void CreatePanelTest1()
        {
            MapWindow.Interfaces.UIPanel target = new clsUIPanel(); // TODO: Initialize to an appropriate value
            string Caption = string.Empty; // TODO: Initialize to an appropriate value
            DockStyle DockStyle = new DockStyle(); // TODO: Initialize to an appropriate value
            Panel expected = null; // TODO: Initialize to an appropriate value
            Panel actual;
            actual = target.CreatePanel(Caption, DockStyle);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CreatePanel
        ///</summary>
        [TestMethod()]
        public void CreatePanelTest()
        {
            MapWindow.Interfaces.UIPanel target = new clsUIPanel(); // TODO: Initialize to an appropriate value
            string Caption = string.Empty; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.MapWindowDockStyle DockStyle = new MapWindow.Interfaces.MapWindowDockStyle(); // TODO: Initialize to an appropriate value
            Panel expected = null; // TODO: Initialize to an appropriate value
            Panel actual;
            actual = target.CreatePanel(Caption, DockStyle);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddOnCloseHandler
        ///</summary>
        [TestMethod()]
        public void AddOnCloseHandlerTest()
        {
            MapWindow.Interfaces.UIPanel target = new clsUIPanel(); // TODO: Initialize to an appropriate value
            string Caption = string.Empty; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.OnPanelClose OnCloseFunction = null; // TODO: Initialize to an appropriate value
            target.AddOnCloseHandler(Caption, OnCloseFunction);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for clsUIPanel Constructor
        ///</summary>
        [TestMethod()]
        public void clsUIPanelConstructorTest()
        {
            clsUIPanel target = new clsUIPanel();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
