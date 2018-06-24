using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for ProjectSettingsTest and is intended
    ///to contain all ProjectSettingsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProjectSettingsTest
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
        ///A test for TabPage2
        ///</summary>
        [TestMethod()]
        public void TabPage2Test()
        {
            ProjectSettings target = new ProjectSettings(); // TODO: Initialize to an appropriate value
            TabPage expected = null; // TODO: Initialize to an appropriate value
            TabPage actual;
            target.TabPage2 = expected;
            actual = target.TabPage2;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TabPage1
        ///</summary>
        [TestMethod()]
        public void TabPage1Test()
        {
            ProjectSettings target = new ProjectSettings(); // TODO: Initialize to an appropriate value
            TabPage expected = null; // TODO: Initialize to an appropriate value
            TabPage actual;
            target.TabPage1 = expected;
            actual = target.TabPage1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TabControl1
        ///</summary>
        [TestMethod()]
        public void TabControl1Test()
        {
            ProjectSettings target = new ProjectSettings(); // TODO: Initialize to an appropriate value
            TabControl expected = null; // TODO: Initialize to an appropriate value
            TabControl actual;
            target.TabControl1 = expected;
            actual = target.TabControl1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PropertyGrid2
        ///</summary>
        [TestMethod()]
        public void PropertyGrid2Test()
        {
            ProjectSettings target = new ProjectSettings(); // TODO: Initialize to an appropriate value
            PropertyGrid expected = null; // TODO: Initialize to an appropriate value
            PropertyGrid actual;
            target.PropertyGrid2 = expected;
            actual = target.PropertyGrid2;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PropertyGrid1
        ///</summary>
        [TestMethod()]
        public void PropertyGrid1Test()
        {
            ProjectSettings target = new ProjectSettings(); // TODO: Initialize to an appropriate value
            PropertyGrid expected = null; // TODO: Initialize to an appropriate value
            PropertyGrid actual;
            target.PropertyGrid1 = expected;
            actual = target.PropertyGrid1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for btnClose
        ///</summary>
        [TestMethod()]
        public void btnCloseTest()
        {
            ProjectSettings target = new ProjectSettings(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.btnClose = expected;
            actual = target.btnClose;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ProjectSettings_Resize
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ProjectSettings_ResizeTest()
        {
            ProjectSettings_Accessor target = new ProjectSettings_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.ProjectSettings_Resize(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ProjectSettings_Move
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ProjectSettings_MoveTest()
        {
            ProjectSettings_Accessor target = new ProjectSettings_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.ProjectSettings_Move(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ProjectSettings_Load
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ProjectSettings_LoadTest()
        {
            ProjectSettings_Accessor target = new ProjectSettings_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.ProjectSettings_Load(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void InitializeComponentTest()
        {
            ProjectSettings_Accessor target = new ProjectSettings_Accessor(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DisposeTest()
        {
            ProjectSettings_Accessor target = new ProjectSettings_Accessor(); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for btnClose_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void btnClose_ClickTest()
        {
            ProjectSettings_Accessor target = new ProjectSettings_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.btnClose_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ProjectSettings Constructor
        ///</summary>
        [TestMethod()]
        public void ProjectSettingsConstructorTest()
        {
            ProjectSettings target = new ProjectSettings();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
