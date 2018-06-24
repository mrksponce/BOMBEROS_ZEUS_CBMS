using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for frmProjMismatchTest and is intended
    ///to contain all frmProjMismatchTest Unit Tests
    ///</summary>
    [TestClass()]
    public class frmProjMismatchTest
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
        ///A test for rdSetLayerToMap
        ///</summary>
        [TestMethod()]
        public void rdSetLayerToMapTest()
        {
            frmProjMismatch target = new frmProjMismatch(); // TODO: Initialize to an appropriate value
            RadioButton expected = null; // TODO: Initialize to an appropriate value
            RadioButton actual;
            target.rdSetLayerToMap = expected;
            actual = target.rdSetLayerToMap;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for rdReproject
        ///</summary>
        [TestMethod()]
        public void rdReprojectTest()
        {
            frmProjMismatch target = new frmProjMismatch(); // TODO: Initialize to an appropriate value
            RadioButton expected = null; // TODO: Initialize to an appropriate value
            RadioButton actual;
            target.rdReproject = expected;
            actual = target.rdReproject;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for rdOverwrite
        ///</summary>
        [TestMethod()]
        public void rdOverwriteTest()
        {
            frmProjMismatch target = new frmProjMismatch(); // TODO: Initialize to an appropriate value
            RadioButton expected = null; // TODO: Initialize to an appropriate value
            RadioButton actual;
            target.rdOverwrite = expected;
            actual = target.rdOverwrite;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for rdNothing_2
        ///</summary>
        [TestMethod()]
        public void rdNothing_2Test()
        {
            frmProjMismatch target = new frmProjMismatch(); // TODO: Initialize to an appropriate value
            RadioButton expected = null; // TODO: Initialize to an appropriate value
            RadioButton actual;
            target.rdNothing_2 = expected;
            actual = target.rdNothing_2;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for rdNothing
        ///</summary>
        [TestMethod()]
        public void rdNothingTest()
        {
            frmProjMismatch target = new frmProjMismatch(); // TODO: Initialize to an appropriate value
            RadioButton expected = null; // TODO: Initialize to an appropriate value
            RadioButton actual;
            target.rdNothing = expected;
            actual = target.rdNothing;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for rdNewFile
        ///</summary>
        [TestMethod()]
        public void rdNewFileTest()
        {
            frmProjMismatch target = new frmProjMismatch(); // TODO: Initialize to an appropriate value
            RadioButton expected = null; // TODO: Initialize to an appropriate value
            RadioButton actual;
            target.rdNewFile = expected;
            actual = target.rdNewFile;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for rdAbort
        ///</summary>
        [TestMethod()]
        public void rdAbortTest()
        {
            frmProjMismatch target = new frmProjMismatch(); // TODO: Initialize to an appropriate value
            RadioButton expected = null; // TODO: Initialize to an appropriate value
            RadioButton actual;
            target.rdAbort = expected;
            actual = target.rdAbort;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for pnlReprojectOptions
        ///</summary>
        [TestMethod()]
        public void pnlReprojectOptionsTest()
        {
            frmProjMismatch target = new frmProjMismatch(); // TODO: Initialize to an appropriate value
            Panel expected = null; // TODO: Initialize to an appropriate value
            Panel actual;
            target.pnlReprojectOptions = expected;
            actual = target.pnlReprojectOptions;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for NoProjectionLabel
        ///</summary>
        [TestMethod()]
        public void NoProjectionLabelTest()
        {
            frmProjMismatch target = new frmProjMismatch(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.NoProjectionLabel = expected;
            actual = target.NoProjectionLabel;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Label5
        ///</summary>
        [TestMethod()]
        public void Label5Test()
        {
            frmProjMismatch target = new frmProjMismatch(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.Label5 = expected;
            actual = target.Label5;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Label3
        ///</summary>
        [TestMethod()]
        public void Label3Test()
        {
            frmProjMismatch target = new frmProjMismatch(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.Label3 = expected;
            actual = target.Label3;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Label2
        ///</summary>
        [TestMethod()]
        public void Label2Test()
        {
            frmProjMismatch target = new frmProjMismatch(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.Label2 = expected;
            actual = target.Label2;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for grpProjectionMismatch
        ///</summary>
        [TestMethod()]
        public void grpProjectionMismatchTest()
        {
            frmProjMismatch target = new frmProjMismatch(); // TODO: Initialize to an appropriate value
            GroupBox expected = null; // TODO: Initialize to an appropriate value
            GroupBox actual;
            target.grpProjectionMismatch = expected;
            actual = target.grpProjectionMismatch;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for grpNoLayerProjection
        ///</summary>
        [TestMethod()]
        public void grpNoLayerProjectionTest()
        {
            frmProjMismatch target = new frmProjMismatch(); // TODO: Initialize to an appropriate value
            GroupBox expected = null; // TODO: Initialize to an appropriate value
            GroupBox actual;
            target.grpNoLayerProjection = expected;
            actual = target.grpNoLayerProjection;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DiffProjectionLabel
        ///</summary>
        [TestMethod()]
        public void DiffProjectionLabelTest()
        {
            frmProjMismatch target = new frmProjMismatch(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.DiffProjectionLabel = expected;
            actual = target.DiffProjectionLabel;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for chbNoProj_UseForSession
        ///</summary>
        [TestMethod()]
        public void chbNoProj_UseForSessionTest()
        {
            frmProjMismatch target = new frmProjMismatch(); // TODO: Initialize to an appropriate value
            CheckBox expected = null; // TODO: Initialize to an appropriate value
            CheckBox actual;
            target.chbNoProj_UseForSession = expected;
            actual = target.chbNoProj_UseForSession;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for chbDoNothing
        ///</summary>
        [TestMethod()]
        public void chbDoNothingTest()
        {
            frmProjMismatch target = new frmProjMismatch(); // TODO: Initialize to an appropriate value
            CheckBox expected = null; // TODO: Initialize to an appropriate value
            CheckBox actual;
            target.chbDoNothing = expected;
            actual = target.chbDoNothing;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for chbDifferingProj_UseForSession
        ///</summary>
        [TestMethod()]
        public void chbDifferingProj_UseForSessionTest()
        {
            frmProjMismatch target = new frmProjMismatch(); // TODO: Initialize to an appropriate value
            CheckBox expected = null; // TODO: Initialize to an appropriate value
            CheckBox actual;
            target.chbDifferingProj_UseForSession = expected;
            actual = target.chbDifferingProj_UseForSession;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for btnOK
        ///</summary>
        [TestMethod()]
        public void btnOKTest()
        {
            frmProjMismatch target = new frmProjMismatch(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.btnOK = expected;
            actual = target.btnOK;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for btnCancel
        ///</summary>
        [TestMethod()]
        public void btnCancelTest()
        {
            frmProjMismatch target = new frmProjMismatch(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.btnCancel = expected;
            actual = target.btnCancel;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TestProjection
        ///</summary>
        [TestMethod()]
        public void TestProjectionTest()
        {
            frmProjMismatch target = new frmProjMismatch(); // TODO: Initialize to an appropriate value
            object newLayer = null; // TODO: Initialize to an appropriate value
            object newLayerExpected = null; // TODO: Initialize to an appropriate value
            bool abort = false; // TODO: Initialize to an appropriate value
            bool abortExpected = false; // TODO: Initialize to an appropriate value
            string lyrFilename = string.Empty; // TODO: Initialize to an appropriate value
            string lyrFilenameExpected = string.Empty; // TODO: Initialize to an appropriate value
            target.TestProjection(ref newLayer, ref abort, ref lyrFilename);
            Assert.AreEqual(newLayerExpected, newLayer);
            Assert.AreEqual(abortExpected, abort);
            Assert.AreEqual(lyrFilenameExpected, lyrFilename);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SavePreviousNoProjAnswer
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void SavePreviousNoProjAnswerTest()
        {
            frmProjMismatch_Accessor target = new frmProjMismatch_Accessor(); // TODO: Initialize to an appropriate value
            string PreviousNoProjAnswer = string.Empty; // TODO: Initialize to an appropriate value
            string PreviousNoProjAnswerExpected = string.Empty; // TODO: Initialize to an appropriate value
            target.SavePreviousNoProjAnswer(ref PreviousNoProjAnswer);
            Assert.AreEqual(PreviousNoProjAnswerExpected, PreviousNoProjAnswer);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SavePreviousMismatchAnswer
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void SavePreviousMismatchAnswerTest()
        {
            frmProjMismatch_Accessor target = new frmProjMismatch_Accessor(); // TODO: Initialize to an appropriate value
            string PreviousMismatchAnswer = string.Empty; // TODO: Initialize to an appropriate value
            string PreviousMismatchAnswerExpected = string.Empty; // TODO: Initialize to an appropriate value
            target.SavePreviousMismatchAnswer(ref PreviousMismatchAnswer);
            Assert.AreEqual(PreviousMismatchAnswerExpected, PreviousMismatchAnswer);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for rdReproject_CheckedChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void rdReproject_CheckedChangedTest()
        {
            frmProjMismatch_Accessor target = new frmProjMismatch_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.rdReproject_CheckedChanged(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadPreviousAnswer
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void LoadPreviousAnswerTest()
        {
            frmProjMismatch_Accessor target = new frmProjMismatch_Accessor(); // TODO: Initialize to an appropriate value
            string PreviousAnswer = string.Empty; // TODO: Initialize to an appropriate value
            target.LoadPreviousAnswer(PreviousAnswer);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for IsSameProjectionAsProject
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void IsSameProjectionAsProjectTest()
        {
            frmProjMismatch_Accessor target = new frmProjMismatch_Accessor(); // TODO: Initialize to an appropriate value
            string proj = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsSameProjectionAsProject(proj);
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
            frmProjMismatch_Accessor target = new frmProjMismatch_Accessor(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GoAway
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void GoAwayTest()
        {
            frmProjMismatch_Accessor target = new frmProjMismatch_Accessor(); // TODO: Initialize to an appropriate value
            target.GoAway();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for frmProjMismatch_Load
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void frmProjMismatch_LoadTest()
        {
            frmProjMismatch_Accessor target = new frmProjMismatch_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.frmProjMismatch_Load(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void DisposeTest()
        {
            frmProjMismatch_Accessor target = new frmProjMismatch_Accessor(); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for chbDoNothing_CheckedChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void chbDoNothing_CheckedChangedTest()
        {
            frmProjMismatch_Accessor target = new frmProjMismatch_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.chbDoNothing_CheckedChanged(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Button1_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void Button1_ClickTest()
        {
            frmProjMismatch_Accessor target = new frmProjMismatch_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.Button1_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for btnCancel_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void btnCancel_ClickTest()
        {
            frmProjMismatch_Accessor target = new frmProjMismatch_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.btnCancel_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for frmProjMismatch Constructor
        ///</summary>
        [TestMethod()]
        public void frmProjMismatchConstructorTest()
        {
            frmProjMismatch target = new frmProjMismatch();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
