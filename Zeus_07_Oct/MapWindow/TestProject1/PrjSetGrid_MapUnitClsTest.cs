﻿using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for PrjSetGrid_MapUnitClsTest and is intended
    ///to contain all PrjSetGrid_MapUnitClsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PrjSetGrid_MapUnitClsTest
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
        ///A test for GetStandardValuesSupported
        ///</summary>
        [TestMethod()]
        public void GetStandardValuesSupportedTest()
        {
            PrjSetGrid.MapUnitCls target = new PrjSetGrid.MapUnitCls(); // TODO: Initialize to an appropriate value
            ITypeDescriptorContext context = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.GetStandardValuesSupported(context);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetStandardValuesExclusive
        ///</summary>
        [TestMethod()]
        public void GetStandardValuesExclusiveTest()
        {
            PrjSetGrid.MapUnitCls target = new PrjSetGrid.MapUnitCls(); // TODO: Initialize to an appropriate value
            ITypeDescriptorContext context = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.GetStandardValuesExclusive(context);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetStandardValues
        ///</summary>
        [TestMethod()]
        public void GetStandardValuesTest()
        {
            PrjSetGrid.MapUnitCls target = new PrjSetGrid.MapUnitCls(); // TODO: Initialize to an appropriate value
            ITypeDescriptorContext context = null; // TODO: Initialize to an appropriate value
            TypeConverter.StandardValuesCollection expected = null; // TODO: Initialize to an appropriate value
            TypeConverter.StandardValuesCollection actual;
            actual = target.GetStandardValues(context);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MapUnitCls Constructor
        ///</summary>
        [TestMethod()]
        public void PrjSetGrid_MapUnitClsConstructorTest()
        {
            PrjSetGrid.MapUnitCls target = new PrjSetGrid.MapUnitCls();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
