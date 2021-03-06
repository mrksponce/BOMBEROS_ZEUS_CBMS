﻿using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for StringPairSorterTest and is intended
    ///to contain all StringPairSorterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class StringPairSorterTest
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
        ///A test for Compare
        ///</summary>
        [TestMethod()]
        public void CompareTest()
        {
            IComparer target = new StringPairSorter(); // TODO: Initialize to an appropriate value
            object x = null; // TODO: Initialize to an appropriate value
            object y = null; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.Compare(x, y);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for StringPairSorter Constructor
        ///</summary>
        [TestMethod()]
        public void StringPairSorterConstructorTest()
        {
            StringPairSorter target = new StringPairSorter();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
