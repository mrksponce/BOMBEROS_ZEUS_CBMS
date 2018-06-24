﻿using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for Layers_LayerEnumeratorTest and is intended
    ///to contain all Layers_LayerEnumeratorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class Layers_LayerEnumeratorTest
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
        ///A test for Current
        ///</summary>
        [TestMethod()]
        public void CurrentTest()
        {
            Layers lyrs = null; // TODO: Initialize to an appropriate value
            IEnumerator target = new Layers.LayerEnumerator(lyrs); // TODO: Initialize to an appropriate value
            object actual;
            actual = target.Current;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Reset
        ///</summary>
        [TestMethod()]
        public void ResetTest()
        {
            Layers lyrs = null; // TODO: Initialize to an appropriate value
            IEnumerator target = new Layers.LayerEnumerator(lyrs); // TODO: Initialize to an appropriate value
            target.Reset();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MoveNext
        ///</summary>
        [TestMethod()]
        public void MoveNextTest()
        {
            Layers lyrs = null; // TODO: Initialize to an appropriate value
            IEnumerator target = new Layers.LayerEnumerator(lyrs); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.MoveNext();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LayerEnumerator Constructor
        ///</summary>
        [TestMethod()]
        public void Layers_LayerEnumeratorConstructorTest()
        {
            Layers lyrs = null; // TODO: Initialize to an appropriate value
            Layers.LayerEnumerator target = new Layers.LayerEnumerator(lyrs);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
