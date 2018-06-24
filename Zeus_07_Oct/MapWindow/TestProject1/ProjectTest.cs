using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// using MapWindow.Interfaces;
using System.Collections;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for ProjectTest and is intended
    ///to contain all ProjectTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProjectTest
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
        ///A test for SaveShapeSettings
        ///</summary>
        [TestMethod()]
        public void SaveShapeSettingsTest()
        {
            MapWindow.Interfaces.Project target = new MapWindow.Project(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.SaveShapeSettings = expected;
            actual = target.SaveShapeSettings;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RecentProjects
        ///</summary>
        [TestMethod()]
        public void RecentProjectsTest()
        {
            Project target = new Project(); // TODO: Initialize to an appropriate value
            ArrayList actual;
            actual = target.RecentProjects;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ProjectProjection
        ///</summary>
        [TestMethod()]
        public void ProjectProjectionTest()
        {
            Project target = new Project(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.ProjectProjection = expected;
            actual = target.ProjectProjection;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Modified
        ///</summary>
        [TestMethod()]
        public void ModifiedTest()
        {
            Project target = new Project(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.Modified = expected;
            actual = target.Modified;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MapUnitsAlternate
        ///</summary>
        [TestMethod()]
        public void MapUnitsAlternateTest()
        {
            Project target = new Project(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.MapUnitsAlternate = expected;
            actual = target.MapUnitsAlternate;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MapUnits
        ///</summary>
        [TestMethod()]
        public void MapUnitsTest()
        {
            Project target = new Project(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.MapUnits = expected;
            actual = target.MapUnits;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FileName
        ///</summary>
        [TestMethod()]
        public void FileNameTest()
        {
            Project target = new Project(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.FileName;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ConfigLoaded
        ///</summary>
        [TestMethod()]
        public void ConfigLoadedTest()
        {
            Project target = new Project(); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.ConfigLoaded;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ConfigFileName
        ///</summary>
        [TestMethod()]
        public void ConfigFileNameTest()
        {
            Project target = new Project(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.ConfigFileName;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SaveConfig
        ///</summary>
        [TestMethod()]
        public void SaveConfigTest()
        {
            Project target = new Project(); // TODO: Initialize to an appropriate value
            string Filename = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.SaveConfig(Filename);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Save
        ///</summary>
        [TestMethod()]
        public void SaveTest()
        {
            Project target = new Project(); // TODO: Initialize to an appropriate value
            string Filename = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Save(Filename);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OpenIntoCurrent
        ///</summary>
        [TestMethod()]
        public void LoadIntoCurrentProjectTest()
        {
            MapWindow.Interfaces.Project target = new MapWindow.Project(); // TODO: Initialize to an appropriate value
            string Filename = string.Empty; // TODO: Initialize to an appropriate value
            target.LoadIntoCurrentProject(Filename);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Load
        ///</summary>
        [TestMethod()]
        public void LoadTest()
        {
            Project target = new Project(); // TODO: Initialize to an appropriate value
            string Filename = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Load(Filename);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Project Constructor
        ///</summary>
        [TestMethod()]
        public void ProjectConstructorTest()
        {
            Project target = new Project();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
