using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
// using MapWindow.Interfaces;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for PluginInfoTest and is intended
    ///to contain all PluginInfoTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PluginInfoTest
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
        ///A test for Version
        ///</summary>
        [TestMethod()]
        public void VersionTest()
        {
            MapWindow.PluginInfo target = new MapWindow.PluginInfo(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Version;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            MapWindow.PluginInfo target = new MapWindow.PluginInfo(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Name;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Key
        ///</summary>
        [TestMethod()]
        public void KeyTest()
        {
            PluginInfo target = new PluginInfo(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Key;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GUID
        ///</summary>
        [TestMethod()]
        public void GUIDTest()
        {
            PluginInfo target = new PluginInfo(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GUID;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FileName
        ///</summary>
        [TestMethod()]
        public void FileNameTest()
        {
            PluginInfo target = new PluginInfo(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.FileName;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Description
        ///</summary>
        [TestMethod()]
        public void DescriptionTest()
        {
            PluginInfo target = new PluginInfo(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Description;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CreateString
        ///</summary>
        [TestMethod()]
        public void CreateStringTest()
        {
            PluginInfo target = new PluginInfo(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.CreateString;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CoClassName
        ///</summary>
        [TestMethod()]
        public void CoClassNameTest()
        {
            PluginInfo target = new PluginInfo(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.CoClassName;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuildDate
        ///</summary>
        [TestMethod()]
        public void BuildDateTest()
        {
            PluginInfo target = new PluginInfo(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.BuildDate;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Author
        ///</summary>
        [TestMethod()]
        public void AuthorTest()
        {
            PluginInfo target = new PluginInfo(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Author;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for InitAssembly
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void InitAssemblyTest()
        {
            PluginInfo_Accessor target = new PluginInfo_Accessor(); // TODO: Initialize to an appropriate value
            Type AssemblyInfo = null; // TODO: Initialize to an appropriate value
            Type AssemblyInfoExpected = null; // TODO: Initialize to an appropriate value
            string PathToFile = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.InitAssembly(ref AssemblyInfo, PathToFile);
            Assert.AreEqual(AssemblyInfoExpected, AssemblyInfo);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Init
        ///</summary>
        [TestMethod()]
        public void InitTest()
        {
            PluginInfo target = new PluginInfo(); // TODO: Initialize to an appropriate value
            string Path = string.Empty; // TODO: Initialize to an appropriate value
            Guid SearchingGUID = new Guid(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Init(Path, SearchingGUID);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Finalize
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void FinalizeTest()
        {
            PluginInfo_Accessor target = new PluginInfo_Accessor(); // TODO: Initialize to an appropriate value
            target.Finalize();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddFromFileDotNetAssembly
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void AddFromFileDotNetAssemblyTest()
        {
            PluginInfo_Accessor target = new PluginInfo_Accessor(); // TODO: Initialize to an appropriate value
            string PathToFile = string.Empty; // TODO: Initialize to an appropriate value
            Guid SearchingGUID = new Guid(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.AddFromFileDotNetAssembly(PathToFile, SearchingGUID);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PluginInfo Constructor
        ///</summary>
        [TestMethod()]
        public void PluginInfoConstructorTest()
        {
            PluginInfo target = new PluginInfo();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
