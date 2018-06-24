using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for clsProjectionsTest and is intended
    ///to contain all clsProjectionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class clsProjectionsTest
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
        ///A test for PartsCompare
        ///</summary>
        [TestMethod()]
        public void PartsCompareTest()
        {
            string instr1 = string.Empty; // TODO: Initialize to an appropriate value
            string instr2 = string.Empty; // TODO: Initialize to an appropriate value
            bool tolerant = false; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = clsProjections.PartsCompare(instr1, instr2, tolerant);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LoadNamesComboBox
        ///</summary>
        [TestMethod()]
        public void LoadNamesComboBoxTest()
        {
            clsProjections target = new clsProjections(); // TODO: Initialize to an appropriate value
            string LoadingforMainCateg = string.Empty; // TODO: Initialize to an appropriate value
            string LoadingForCategory = string.Empty; // TODO: Initialize to an appropriate value
            ComboBox cboNames = null; // TODO: Initialize to an appropriate value
            ComboBox cboNamesExpected = null; // TODO: Initialize to an appropriate value
            target.LoadNamesComboBox(LoadingforMainCateg, LoadingForCategory, ref cboNames);
            Assert.AreEqual(cboNamesExpected, cboNames);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadMainCategComboBox
        ///</summary>
        [TestMethod()]
        public void LoadMainCategComboBoxTest()
        {
            clsProjections target = new clsProjections(); // TODO: Initialize to an appropriate value
            ComboBox cboCategories = null; // TODO: Initialize to an appropriate value
            ComboBox cboCategoriesExpected = null; // TODO: Initialize to an appropriate value
            target.LoadMainCategComboBox(ref cboCategories);
            Assert.AreEqual(cboCategoriesExpected, cboCategories);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadCategComboBox
        ///</summary>
        [TestMethod()]
        public void LoadCategComboBoxTest()
        {
            clsProjections target = new clsProjections(); // TODO: Initialize to an appropriate value
            string LoadingforMainCateg = string.Empty; // TODO: Initialize to an appropriate value
            ComboBox cboCateg = null; // TODO: Initialize to an appropriate value
            ComboBox cboCategExpected = null; // TODO: Initialize to an appropriate value
            target.LoadCategComboBox(LoadingforMainCateg, ref cboCateg);
            Assert.AreEqual(cboCategExpected, cboCateg);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetOrSetLastCustomProj4
        ///</summary>
        [TestMethod()]
        public void GetOrSetLastCustomProj4Test()
        {
            clsProjections target = new clsProjections(); // TODO: Initialize to an appropriate value
            string inout = string.Empty; // TODO: Initialize to an appropriate value
            string inoutExpected = string.Empty; // TODO: Initialize to an appropriate value
            bool setting = false; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetOrSetLastCustomProj4(ref inout, setting);
            Assert.AreEqual(inoutExpected, inout);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FindProjectionByPROJ4
        ///</summary>
        [TestMethod()]
        public void FindProjectionByPROJ4Test()
        {
            clsProjections target = new clsProjections(); // TODO: Initialize to an appropriate value
            string proj4 = string.Empty; // TODO: Initialize to an appropriate value
            bool Tolerant = false; // TODO: Initialize to an appropriate value
            clsProjections.clsProjection expected = null; // TODO: Initialize to an appropriate value
            clsProjections.clsProjection actual;
            actual = target.FindProjectionByPROJ4(proj4, Tolerant);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FindProjectionByCatAndName
        ///</summary>
        [TestMethod()]
        public void FindProjectionByCatAndNameTest()
        {
            clsProjections target = new clsProjections(); // TODO: Initialize to an appropriate value
            string MainCateg = string.Empty; // TODO: Initialize to an appropriate value
            string Category = string.Empty; // TODO: Initialize to an appropriate value
            string Name = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.FindProjectionByCatAndName(MainCateg, Category, Name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for clsProjections Constructor
        ///</summary>
        [TestMethod()]
        public void clsProjectionsConstructorTest()
        {
            clsProjections target = new clsProjections();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
