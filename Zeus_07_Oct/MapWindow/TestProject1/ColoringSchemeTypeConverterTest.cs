using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;
using System;
using System.Globalization;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for ColoringSchemeTypeConverterTest and is intended
    ///to contain all ColoringSchemeTypeConverterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ColoringSchemeTypeConverterTest
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
        ///A test for ConvertTo
        ///</summary>
        [TestMethod()]
        public void ConvertToTest()
        {
            ColoringSchemeTypeConverter target = new ColoringSchemeTypeConverter(); // TODO: Initialize to an appropriate value
            ITypeDescriptorContext context = null; // TODO: Initialize to an appropriate value
            CultureInfo culture = null; // TODO: Initialize to an appropriate value
            object value = null; // TODO: Initialize to an appropriate value
            Type destinationType = null; // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            actual = target.ConvertTo(context, culture, value, destinationType);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CanConvertTo
        ///</summary>
        [TestMethod()]
        public void CanConvertToTest()
        {
            ColoringSchemeTypeConverter target = new ColoringSchemeTypeConverter(); // TODO: Initialize to an appropriate value
            ITypeDescriptorContext context = null; // TODO: Initialize to an appropriate value
            Type destinationType = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.CanConvertTo(context, destinationType);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CanConvertFrom
        ///</summary>
        [TestMethod()]
        public void CanConvertFromTest()
        {
            ColoringSchemeTypeConverter target = new ColoringSchemeTypeConverter(); // TODO: Initialize to an appropriate value
            ITypeDescriptorContext context = null; // TODO: Initialize to an appropriate value
            Type sourceType = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.CanConvertFrom(context, sourceType);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ColoringSchemeTypeConverter Constructor
        ///</summary>
        [TestMethod()]
        public void ColoringSchemeTypeConverterConstructorTest()
        {
            ColoringSchemeTypeConverter target = new ColoringSchemeTypeConverter();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
