using MapWindow.PropertyGridUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for PropertyAttributesTest and is intended
    ///to contain all PropertyAttributesTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PropertyAttributesTest
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
        ///A test for Order
        ///</summary>
        [TestMethod()]
        public void OrderTest()
        {
            string name = string.Empty; // TODO: Initialize to an appropriate value
            PropertyAttributes target = new PropertyAttributes(name); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.Order = expected;
            actual = target.Order;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            string name = string.Empty; // TODO: Initialize to an appropriate value
            PropertyAttributes target = new PropertyAttributes(name); // TODO: Initialize to an appropriate value
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
            string name = string.Empty; // TODO: Initialize to an appropriate value
            PropertyAttributes target = new PropertyAttributes(name); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.IsReadOnly = expected;
            actual = target.IsReadOnly;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsBrowsable
        ///</summary>
        [TestMethod()]
        public void IsBrowsableTest()
        {
            string name = string.Empty; // TODO: Initialize to an appropriate value
            PropertyAttributes target = new PropertyAttributes(name); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.IsBrowsable = expected;
            actual = target.IsBrowsable;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DisplayName
        ///</summary>
        [TestMethod()]
        public void DisplayNameTest()
        {
            string name = string.Empty; // TODO: Initialize to an appropriate value
            PropertyAttributes target = new PropertyAttributes(name); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.DisplayName = expected;
            actual = target.DisplayName;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Description
        ///</summary>
        [TestMethod()]
        public void DescriptionTest()
        {
            string name = string.Empty; // TODO: Initialize to an appropriate value
            PropertyAttributes target = new PropertyAttributes(name); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Description = expected;
            actual = target.Description;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Category
        ///</summary>
        [TestMethod()]
        public void CategoryTest()
        {
            string name = string.Empty; // TODO: Initialize to an appropriate value
            PropertyAttributes target = new PropertyAttributes(name); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Category = expected;
            actual = target.Category;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CompareTo
        ///</summary>
        [TestMethod()]
        public void CompareToTest()
        {
            string name = string.Empty; // TODO: Initialize to an appropriate value
            IComparable target = new PropertyAttributes(name); // TODO: Initialize to an appropriate value
            object obj = null; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.CompareTo(obj);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PropertyAttributes Constructor
        ///</summary>
        [TestMethod()]
        public void PropertyAttributesConstructorTest()
        {
            string name = string.Empty; // TODO: Initialize to an appropriate value
            PropertyAttributes target = new PropertyAttributes(name);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
