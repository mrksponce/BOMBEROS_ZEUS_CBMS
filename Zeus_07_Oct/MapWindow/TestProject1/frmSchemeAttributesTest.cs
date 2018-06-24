using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for frmSchemeAttributesTest and is intended
    ///to contain all frmSchemeAttributesTest Unit Tests
    ///</summary>
    [TestClass()]
    public class frmSchemeAttributesTest
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
        ///A test for udPrecision
        ///</summary>
        [TestMethod()]
        public void udPrecisionTest()
        {
            frmSchemeAttributes target = new frmSchemeAttributes(); // TODO: Initialize to an appropriate value
            NumericUpDown expected = null; // TODO: Initialize to an appropriate value
            NumericUpDown actual;
            target.udPrecision = expected;
            actual = target.udPrecision;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for udNumBreaks1
        ///</summary>
        [TestMethod()]
        public void udNumBreaks1Test()
        {
            frmSchemeAttributes target = new frmSchemeAttributes(); // TODO: Initialize to an appropriate value
            NumericUpDown expected = null; // TODO: Initialize to an appropriate value
            NumericUpDown actual;
            target.udNumBreaks1 = expected;
            actual = target.udNumBreaks1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for pnlContinuousRamp
        ///</summary>
        [TestMethod()]
        public void pnlContinuousRampTest()
        {
            frmSchemeAttributes target = new frmSchemeAttributes(); // TODO: Initialize to an appropriate value
            Panel expected = null; // TODO: Initialize to an appropriate value
            Panel actual;
            target.pnlContinuousRamp = expected;
            actual = target.pnlContinuousRamp;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for lblSchemeType
        ///</summary>
        [TestMethod()]
        public void lblSchemeTypeTest()
        {
            frmSchemeAttributes target = new frmSchemeAttributes(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.lblSchemeType = expected;
            actual = target.lblSchemeType;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for lblPrecision1
        ///</summary>
        [TestMethod()]
        public void lblPrecision1Test()
        {
            frmSchemeAttributes target = new frmSchemeAttributes(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.lblPrecision1 = expected;
            actual = target.lblPrecision1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for lblNumBreaks
        ///</summary>
        [TestMethod()]
        public void lblNumBreaksTest()
        {
            frmSchemeAttributes target = new frmSchemeAttributes(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.lblNumBreaks = expected;
            actual = target.lblNumBreaks;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for lblColorBy1
        ///</summary>
        [TestMethod()]
        public void lblColorBy1Test()
        {
            frmSchemeAttributes target = new frmSchemeAttributes(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.lblColorBy1 = expected;
            actual = target.lblColorBy1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Label2
        ///</summary>
        [TestMethod()]
        public void Label2Test()
        {
            frmSchemeAttributes target = new frmSchemeAttributes(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.Label2 = expected;
            actual = target.Label2;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Label1
        ///</summary>
        [TestMethod()]
        public void Label1Test()
        {
            frmSchemeAttributes target = new frmSchemeAttributes(); // TODO: Initialize to an appropriate value
            Label expected = null; // TODO: Initialize to an appropriate value
            Label actual;
            target.Label1 = expected;
            actual = target.Label1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ComboBox2
        ///</summary>
        [TestMethod()]
        public void ComboBox2Test()
        {
            frmSchemeAttributes target = new frmSchemeAttributes(); // TODO: Initialize to an appropriate value
            ComboBox expected = null; // TODO: Initialize to an appropriate value
            ComboBox actual;
            target.ComboBox2 = expected;
            actual = target.ComboBox2;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ComboBox1
        ///</summary>
        [TestMethod()]
        public void ComboBox1Test()
        {
            frmSchemeAttributes target = new frmSchemeAttributes(); // TODO: Initialize to an appropriate value
            ComboBox expected = null; // TODO: Initialize to an appropriate value
            ComboBox actual;
            target.ComboBox1 = expected;
            actual = target.ComboBox1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for cmbSchemeType
        ///</summary>
        [TestMethod()]
        public void cmbSchemeTypeTest()
        {
            frmSchemeAttributes target = new frmSchemeAttributes(); // TODO: Initialize to an appropriate value
            ComboBox expected = null; // TODO: Initialize to an appropriate value
            ComboBox actual;
            target.cmbSchemeType = expected;
            actual = target.cmbSchemeType;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for cmbField1
        ///</summary>
        [TestMethod()]
        public void cmbField1Test()
        {
            frmSchemeAttributes target = new frmSchemeAttributes(); // TODO: Initialize to an appropriate value
            ComboBox expected = null; // TODO: Initialize to an appropriate value
            ComboBox actual;
            target.cmbField1 = expected;
            actual = target.cmbField1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for btnOK
        ///</summary>
        [TestMethod()]
        public void btnOKTest()
        {
            frmSchemeAttributes target = new frmSchemeAttributes(); // TODO: Initialize to an appropriate value
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
            frmSchemeAttributes target = new frmSchemeAttributes(); // TODO: Initialize to an appropriate value
            Button expected = null; // TODO: Initialize to an appropriate value
            Button actual;
            target.btnCancel = expected;
            actual = target.btnCancel;
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
            frmSchemeAttributes_Accessor target = new frmSchemeAttributes_Accessor(); // TODO: Initialize to an appropriate value
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
            frmSchemeAttributes_Accessor target = new frmSchemeAttributes_Accessor(); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for frmSchemeAttributes Constructor
        ///</summary>
        [TestMethod()]
        public void frmSchemeAttributesConstructorTest()
        {
            frmSchemeAttributes target = new frmSchemeAttributes();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
