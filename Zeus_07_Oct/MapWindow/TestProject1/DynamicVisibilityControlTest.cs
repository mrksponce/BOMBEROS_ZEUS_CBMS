using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms.Design;
using System;
using System.Windows.Forms;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for DynamicVisibilityControlTest and is intended
    ///to contain all DynamicVisibilityControlTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DynamicVisibilityControlTest
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
        ///A test for chkUseDynamicVisibility
        ///</summary>
        [TestMethod()]
        public void chkUseDynamicVisibilityTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            DynamicVisibilityControl target = new DynamicVisibilityControl(DialogProvider, LayerHandle); // TODO: Initialize to an appropriate value
            CheckBox expected = null; // TODO: Initialize to an appropriate value
            CheckBox actual;
            target.chkUseDynamicVisibility = expected;
            actual = target.chkUseDynamicVisibility;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for btnGrabExtents
        ///</summary>
        [TestMethod()]
        public void btnGrabExtentsTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            DynamicVisibilityControl target = new DynamicVisibilityControl(DialogProvider, LayerHandle); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.btnGrabExtents = expected;
            actual = target.btnGrabExtents;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void InitializeComponentTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DynamicVisibilityControl_Accessor target = new DynamicVisibilityControl_Accessor(param0); // TODO: Initialize to an appropriate value
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
            DynamicVisibilityControl_Accessor target = new DynamicVisibilityControl_Accessor(param0); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for chkUseDynamicVisibility_CheckedChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void chkUseDynamicVisibility_CheckedChangedTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DynamicVisibilityControl_Accessor target = new DynamicVisibilityControl_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.chkUseDynamicVisibility_CheckedChanged(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for btnGrabExtents_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void btnGrabExtents_ClickTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DynamicVisibilityControl_Accessor target = new DynamicVisibilityControl_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.btnGrabExtents_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DynamicVisibilityControl Constructor
        ///</summary>
        [TestMethod()]
        public void DynamicVisibilityControlConstructorTest()
        {
            IWindowsFormsEditorService DialogProvider = null; // TODO: Initialize to an appropriate value
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            DynamicVisibilityControl target = new DynamicVisibilityControl(DialogProvider, LayerHandle);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
