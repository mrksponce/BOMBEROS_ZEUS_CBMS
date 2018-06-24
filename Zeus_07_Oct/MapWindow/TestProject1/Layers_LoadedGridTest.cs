﻿using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MapWinGIS;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for Layers_LoadedGridTest and is intended
    ///to contain all Layers_LoadedGridTest Unit Tests
    ///</summary>
    [TestClass()]
    public class Layers_LoadedGridTest
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
        ///A test for Finalize
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void FinalizeTest()
        {
            Layers_Accessor.LoadedGrid target = new Layers_Accessor.LoadedGrid(); // TODO: Initialize to an appropriate value
            target.Finalize();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadedGrid Constructor
        ///</summary>
        [TestMethod()]
        public void Layers_LoadedGridConstructorTest1()
        {
            Layers.LoadedGrid target = new Layers.LoadedGrid();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for LoadedGrid Constructor
        ///</summary>
        [TestMethod()]
        public void Layers_LoadedGridConstructorTest()
        {
            GridColorScheme ColorScheme = null; // TODO: Initialize to an appropriate value
            Grid Object = null; // TODO: Initialize to an appropriate value
            Layers.LoadedGrid target = new Layers.LoadedGrid(ColorScheme, Object);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}