using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AxMapWinGIS;
using System.ComponentModel;
using System.Windows.Forms;
using System;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for LegendEditorFormTest and is intended
    ///to contain all LegendEditorFormTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LegendEditorFormTest
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
        ///A test for PropertyGrid1
        ///</summary>
        [TestMethod()]
        public void PropertyGrid1Test()
        {
            int Handle = 0; // TODO: Initialize to an appropriate value
            bool IsLayer = false; // TODO: Initialize to an appropriate value
            AxMap axmap = null; // TODO: Initialize to an appropriate value
            LegendEditorForm target = new LegendEditorForm(Handle, IsLayer, axmap); // TODO: Initialize to an appropriate value
            PropertyGrid expected = null; // TODO: Initialize to an appropriate value
            PropertyGrid actual;
            target.PropertyGrid1 = expected;
            actual = target.PropertyGrid1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ResizeHandle
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ResizeHandleTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            LegendEditorForm_Accessor target = new LegendEditorForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.ResizeHandle(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadProperties
        ///</summary>
        [TestMethod()]
        public void LoadPropertiesTest()
        {
            int Handle = 0; // TODO: Initialize to an appropriate value
            bool IsLayer = false; // TODO: Initialize to an appropriate value
            AxMap axmap = null; // TODO: Initialize to an appropriate value
            LegendEditorForm target = new LegendEditorForm(Handle, IsLayer, axmap); // TODO: Initialize to an appropriate value
            int Handle1 = 0; // TODO: Initialize to an appropriate value
            bool IsLayer1 = false; // TODO: Initialize to an appropriate value
            target.LoadProperties(Handle1, IsLayer1);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LegendEditorForm_KeyDown
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void LegendEditorForm_KeyDownTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            LegendEditorForm_Accessor target = new LegendEditorForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            KeyEventArgs e = null; // TODO: Initialize to an appropriate value
            target.LegendEditorForm_KeyDown(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LegendEditorForm_FormClosed
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void LegendEditorForm_FormClosedTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            LegendEditorForm_Accessor target = new LegendEditorForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            FormClosedEventArgs e = null; // TODO: Initialize to an appropriate value
            target.LegendEditorForm_FormClosed(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LegendEditorForm_Closing
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void LegendEditorForm_ClosingTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            LegendEditorForm_Accessor target = new LegendEditorForm_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            CancelEventArgs e = null; // TODO: Initialize to an appropriate value
            target.LegendEditorForm_Closing(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void InitializeComponentTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            LegendEditorForm_Accessor target = new LegendEditorForm_Accessor(param0); // TODO: Initialize to an appropriate value
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
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            LegendEditorForm_Accessor target = new LegendEditorForm_Accessor(param0); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CreateAndShowLYR
        ///</summary>
        [TestMethod()]
        public void CreateAndShowLYRTest()
        {
            LegendEditorForm expected = null; // TODO: Initialize to an appropriate value
            LegendEditorForm actual;
            actual = LegendEditorForm.CreateAndShowLYR();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CreateAndShowGRP
        ///</summary>
        [TestMethod()]
        public void CreateAndShowGRPTest()
        {
            int GroupHandle = 0; // TODO: Initialize to an appropriate value
            LegendEditorForm expected = null; // TODO: Initialize to an appropriate value
            LegendEditorForm actual;
            actual = LegendEditorForm.CreateAndShowGRP(GroupHandle);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LegendEditorForm Constructor
        ///</summary>
        [TestMethod()]
        public void LegendEditorFormConstructorTest()
        {
            int Handle = 0; // TODO: Initialize to an appropriate value
            bool IsLayer = false; // TODO: Initialize to an appropriate value
            AxMap axmap = null; // TODO: Initialize to an appropriate value
            LegendEditorForm target = new LegendEditorForm(Handle, IsLayer, axmap);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
