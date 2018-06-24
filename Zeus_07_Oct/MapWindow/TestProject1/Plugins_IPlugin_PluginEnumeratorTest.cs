using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// using MapWindow.Interfaces;
using System.Collections;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for Plugins_IPlugin_PluginEnumeratorTest and is intended
    ///to contain all Plugins_IPlugin_PluginEnumeratorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class Plugins_IPlugin_PluginEnumeratorTest
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
            MapWindow.Interfaces.Plugins inp = null; // TODO: Initialize to an appropriate value
            IEnumerator target = new Plugins_IPlugin.PluginEnumerator(inp); // TODO: Initialize to an appropriate value
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
            MapWindow.Interfaces.Plugins inp = null; // TODO: Initialize to an appropriate value
            IEnumerator target = new Plugins_IPlugin.PluginEnumerator(inp); // TODO: Initialize to an appropriate value
            target.Reset();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MoveNext
        ///</summary>
        [TestMethod()]
        public void MoveNextTest()
        {
            MapWindow.Interfaces.Plugins inp = null; // TODO: Initialize to an appropriate value
            IEnumerator target = new Plugins_IPlugin.PluginEnumerator(inp); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.MoveNext();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PluginEnumerator Constructor
        ///</summary>
        [TestMethod()]
        public void Plugins_IPlugin_PluginEnumeratorConstructorTest()
        {
            MapWindow.Interfaces.Plugins inp = null; // TODO: Initialize to an appropriate value
            Plugins_IPlugin.PluginEnumerator target = new Plugins_IPlugin.PluginEnumerator(inp);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
