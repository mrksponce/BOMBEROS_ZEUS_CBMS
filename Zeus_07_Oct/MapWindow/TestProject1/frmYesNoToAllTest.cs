using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for frmYesNoToAllTest and is intended
    ///to contain all frmYesNoToAllTest Unit Tests
    ///</summary>
    [TestClass()]
    public class frmYesNoToAllTest
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
        ///A test for Label1
        ///</summary>
        [TestMethod()]
        public void Label1Test()
        {
            frmYesNoToAll target = new frmYesNoToAll(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.Label1 = expected;
            actual = target.Label1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Button4
        ///</summary>
        [TestMethod()]
        public void Button4Test()
        {
            frmYesNoToAll target = new frmYesNoToAll(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.Button4 = expected;
            actual = target.Button4;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Button3
        ///</summary>
        [TestMethod()]
        public void Button3Test()
        {
            frmYesNoToAll target = new frmYesNoToAll(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.Button3 = expected;
            actual = target.Button3;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Button2
        ///</summary>
        [TestMethod()]
        public void Button2Test()
        {
            frmYesNoToAll target = new frmYesNoToAll(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.Button2 = expected;
            actual = target.Button2;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Button1
        ///</summary>
        [TestMethod()]
        public void Button1Test()
        {
            frmYesNoToAll target = new frmYesNoToAll(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.Button1 = expected;
            actual = target.Button1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ShowPrompt
        ///</summary>
        [TestMethod()]
        public void ShowPromptTest()
        {
            string Message = string.Empty; // TODO: Initialize to an appropriate value
            string Title = string.Empty; // TODO: Initialize to an appropriate value
            frmYesNoToAll.DialogResult expected = new frmYesNoToAll.DialogResult(); // TODO: Initialize to an appropriate value
            frmYesNoToAll.DialogResult actual;
            actual = frmYesNoToAll.ShowPrompt(Message, Title);
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
            frmYesNoToAll_Accessor target = new frmYesNoToAll_Accessor(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for frmYesNoToAll_FormClosing
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void frmYesNoToAll_FormClosingTest()
        {
            frmYesNoToAll_Accessor target = new frmYesNoToAll_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            FormClosingEventArgs e = null; // TODO: Initialize to an appropriate value
            target.frmYesNoToAll_FormClosing(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DisposeTest()
        {
            frmYesNoToAll_Accessor target = new frmYesNoToAll_Accessor(); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Button4_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void Button4_ClickTest()
        {
            frmYesNoToAll_Accessor target = new frmYesNoToAll_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.Button4_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Button3_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void Button3_ClickTest()
        {
            frmYesNoToAll_Accessor target = new frmYesNoToAll_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.Button3_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Button2_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void Button2_ClickTest()
        {
            frmYesNoToAll_Accessor target = new frmYesNoToAll_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.Button2_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Button1_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void Button1_ClickTest()
        {
            frmYesNoToAll_Accessor target = new frmYesNoToAll_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.Button1_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for frmYesNoToAll Constructor
        ///</summary>
        [TestMethod()]
        public void frmYesNoToAllConstructorTest()
        {
            frmYesNoToAll target = new frmYesNoToAll();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
