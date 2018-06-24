using MapWindow.PropertyGridUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;
using System;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for GlobalizedTypeConverterTest and is intended
    ///to contain all GlobalizedTypeConverterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GlobalizedTypeConverterTest
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
        ///A test for GetPropertyAttributes
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void GetPropertyAttributesTest()
        {
            GlobalizedTypeConverter_Accessor target = new GlobalizedTypeConverter_Accessor(); // TODO: Initialize to an appropriate value
            PropertyDescriptor propertyDescriptor = null; // TODO: Initialize to an appropriate value
            object target1 = null; // TODO: Initialize to an appropriate value
            PropertyAttributes expected = null; // TODO: Initialize to an appropriate value
            PropertyAttributes actual;
            actual = target.GetPropertyAttributes(propertyDescriptor, target1);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetProperties
        ///</summary>
        [TestMethod()]
        public void GetPropertiesTest()
        {
            GlobalizedTypeConverter target = new GlobalizedTypeConverter(); // TODO: Initialize to an appropriate value
            ITypeDescriptorContext context = null; // TODO: Initialize to an appropriate value
            object value = null; // TODO: Initialize to an appropriate value
            Attribute[] attributes = null; // TODO: Initialize to an appropriate value
            PropertyDescriptorCollection expected = null; // TODO: Initialize to an appropriate value
            PropertyDescriptorCollection actual;
            actual = target.GetProperties(context, value, attributes);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GlobalizedTypeConverter Constructor
        ///</summary>
        [TestMethod()]
        public void GlobalizedTypeConverterConstructorTest()
        {
            GlobalizedTypeConverter target = new GlobalizedTypeConverter();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
