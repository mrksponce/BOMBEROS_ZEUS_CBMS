using MapWindow.PropertyGridUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for PropertyAttributesProviderAttributeTest and is intended
    ///to contain all PropertyAttributesProviderAttributeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PropertyAttributesProviderAttributeTest
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
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            string propertyAttributesProviderName = string.Empty; // TODO: Initialize to an appropriate value
            PropertyAttributesProviderAttribute target = new PropertyAttributesProviderAttribute(propertyAttributesProviderName); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Name;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetPropertyAttributesProvider
        ///</summary>
        [TestMethod()]
        public void GetPropertyAttributesProviderTest()
        {
            string propertyAttributesProviderName = string.Empty; // TODO: Initialize to an appropriate value
            PropertyAttributesProviderAttribute target = new PropertyAttributesProviderAttribute(propertyAttributesProviderName); // TODO: Initialize to an appropriate value
            object target1 = null; // TODO: Initialize to an appropriate value
            MethodInfo expected = null; // TODO: Initialize to an appropriate value
            MethodInfo actual;
            actual = target.GetPropertyAttributesProvider(target1);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PropertyAttributesProviderAttribute Constructor
        ///</summary>
        [TestMethod()]
        public void PropertyAttributesProviderAttributeConstructorTest()
        {
            string propertyAttributesProviderName = string.Empty; // TODO: Initialize to an appropriate value
            PropertyAttributesProviderAttribute target = new PropertyAttributesProviderAttribute(propertyAttributesProviderName);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
