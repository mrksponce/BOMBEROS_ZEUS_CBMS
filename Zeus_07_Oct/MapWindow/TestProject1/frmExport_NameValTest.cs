﻿using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for frmExport_NameValTest and is intended
    ///to contain all frmExport_NameValTest Unit Tests
    ///</summary>
    [TestClass()]
    public class frmExport_NameValTest
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
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            string pName = string.Empty; // TODO: Initialize to an appropriate value
            int pVal = 0; // TODO: Initialize to an appropriate value
            frmExport.NameVal target = new frmExport.NameVal(pName, pVal); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for NameVal Constructor
        ///</summary>
        [TestMethod()]
        public void frmExport_NameValConstructorTest()
        {
            string pName = string.Empty; // TODO: Initialize to an appropriate value
            int pVal = 0; // TODO: Initialize to an appropriate value
            frmExport.NameVal target = new frmExport.NameVal(pName, pVal);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
