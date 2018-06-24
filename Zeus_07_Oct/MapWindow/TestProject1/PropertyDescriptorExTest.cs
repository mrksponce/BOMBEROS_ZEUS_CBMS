using MapWindow.PropertyGridUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;
using System;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for PropertyDescriptorExTest and is intended
    ///to contain all PropertyDescriptorExTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PropertyDescriptorExTest
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
        ///A test for PropertyType
        ///</summary>
        [TestMethod()]
        public void PropertyTypeTest()
        {
            PropertyDescriptor basePropertyDescriptor = null; // TODO: Initialize to an appropriate value
            PropertyAttributes propertyAttributes = null; // TODO: Initialize to an appropriate value
            PropertyDescriptorEx target = new PropertyDescriptorEx(basePropertyDescriptor, propertyAttributes); // TODO: Initialize to an appropriate value
            Type actual;
            actual = target.PropertyType;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            PropertyDescriptor basePropertyDescriptor = null; // TODO: Initialize to an appropriate value
            PropertyAttributes propertyAttributes = null; // TODO: Initialize to an appropriate value
            PropertyDescriptorEx target = new PropertyDescriptorEx(basePropertyDescriptor, propertyAttributes); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Name;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsReadOnly
        ///</summary>
        [TestMethod()]
        public void IsReadOnlyTest()
        {
            PropertyDescriptor basePropertyDescriptor = null; // TODO: Initialize to an appropriate value
            PropertyAttributes propertyAttributes = null; // TODO: Initialize to an appropriate value
            PropertyDescriptorEx target = new PropertyDescriptorEx(basePropertyDescriptor, propertyAttributes); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsReadOnly;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsBrowsable
        ///</summary>
        [TestMethod()]
        public void IsBrowsableTest()
        {
            PropertyDescriptor basePropertyDescriptor = null; // TODO: Initialize to an appropriate value
            PropertyAttributes propertyAttributes = null; // TODO: Initialize to an appropriate value
            PropertyDescriptorEx target = new PropertyDescriptorEx(basePropertyDescriptor, propertyAttributes); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsBrowsable;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DisplayName
        ///</summary>
        [TestMethod()]
        public void DisplayNameTest()
        {
            PropertyDescriptor basePropertyDescriptor = null; // TODO: Initialize to an appropriate value
            PropertyAttributes propertyAttributes = null; // TODO: Initialize to an appropriate value
            PropertyDescriptorEx target = new PropertyDescriptorEx(basePropertyDescriptor, propertyAttributes); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.DisplayName;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Description
        ///</summary>
        [TestMethod()]
        public void DescriptionTest()
        {
            PropertyDescriptor basePropertyDescriptor = null; // TODO: Initialize to an appropriate value
            PropertyAttributes propertyAttributes = null; // TODO: Initialize to an appropriate value
            PropertyDescriptorEx target = new PropertyDescriptorEx(basePropertyDescriptor, propertyAttributes); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Description;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ComponentType
        ///</summary>
        [TestMethod()]
        public void ComponentTypeTest()
        {
            PropertyDescriptor basePropertyDescriptor = null; // TODO: Initialize to an appropriate value
            PropertyAttributes propertyAttributes = null; // TODO: Initialize to an appropriate value
            PropertyDescriptorEx target = new PropertyDescriptorEx(basePropertyDescriptor, propertyAttributes); // TODO: Initialize to an appropriate value
            Type actual;
            actual = target.ComponentType;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Category
        ///</summary>
        [TestMethod()]
        public void CategoryTest()
        {
            PropertyDescriptor basePropertyDescriptor = null; // TODO: Initialize to an appropriate value
            PropertyAttributes propertyAttributes = null; // TODO: Initialize to an appropriate value
            PropertyDescriptorEx target = new PropertyDescriptorEx(basePropertyDescriptor, propertyAttributes); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Category;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ShouldSerializeValue
        ///</summary>
        [TestMethod()]
        public void ShouldSerializeValueTest()
        {
            PropertyDescriptor basePropertyDescriptor = null; // TODO: Initialize to an appropriate value
            PropertyAttributes propertyAttributes = null; // TODO: Initialize to an appropriate value
            PropertyDescriptorEx target = new PropertyDescriptorEx(basePropertyDescriptor, propertyAttributes); // TODO: Initialize to an appropriate value
            object component = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.ShouldSerializeValue(component);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SetValue
        ///</summary>
        [TestMethod()]
        public void SetValueTest()
        {
            PropertyDescriptor basePropertyDescriptor = null; // TODO: Initialize to an appropriate value
            PropertyAttributes propertyAttributes = null; // TODO: Initialize to an appropriate value
            PropertyDescriptorEx target = new PropertyDescriptorEx(basePropertyDescriptor, propertyAttributes); // TODO: Initialize to an appropriate value
            object component = null; // TODO: Initialize to an appropriate value
            object value = null; // TODO: Initialize to an appropriate value
            target.SetValue(component, value);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ResetValue
        ///</summary>
        [TestMethod()]
        public void ResetValueTest()
        {
            PropertyDescriptor basePropertyDescriptor = null; // TODO: Initialize to an appropriate value
            PropertyAttributes propertyAttributes = null; // TODO: Initialize to an appropriate value
            PropertyDescriptorEx target = new PropertyDescriptorEx(basePropertyDescriptor, propertyAttributes); // TODO: Initialize to an appropriate value
            object component = null; // TODO: Initialize to an appropriate value
            target.ResetValue(component);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetValue
        ///</summary>
        [TestMethod()]
        public void GetValueTest()
        {
            PropertyDescriptor basePropertyDescriptor = null; // TODO: Initialize to an appropriate value
            PropertyAttributes propertyAttributes = null; // TODO: Initialize to an appropriate value
            PropertyDescriptorEx target = new PropertyDescriptorEx(basePropertyDescriptor, propertyAttributes); // TODO: Initialize to an appropriate value
            object component = null; // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            actual = target.GetValue(component);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CanResetValue
        ///</summary>
        [TestMethod()]
        public void CanResetValueTest()
        {
            PropertyDescriptor basePropertyDescriptor = null; // TODO: Initialize to an appropriate value
            PropertyAttributes propertyAttributes = null; // TODO: Initialize to an appropriate value
            PropertyDescriptorEx target = new PropertyDescriptorEx(basePropertyDescriptor, propertyAttributes); // TODO: Initialize to an appropriate value
            object component = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.CanResetValue(component);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PropertyDescriptorEx Constructor
        ///</summary>
        [TestMethod()]
        public void PropertyDescriptorExConstructorTest()
        {
            PropertyDescriptor basePropertyDescriptor = null; // TODO: Initialize to an appropriate value
            PropertyAttributes propertyAttributes = null; // TODO: Initialize to an appropriate value
            PropertyDescriptorEx target = new PropertyDescriptorEx(basePropertyDescriptor, propertyAttributes);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
