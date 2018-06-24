using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MapWinGIS;
// using MapWindow.Interfaces;
using System.Xml;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for ColoringSchemeToolsTest and is intended
    ///to contain all ColoringSchemeToolsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ColoringSchemeToolsTest
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
        ///A test for ImportScheme
        ///</summary>
        [TestMethod()]
        public void ImportSchemeTest3()
        {
            Layer lyr = null; // TODO: Initialize to an appropriate value
            string Filename = string.Empty; // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            actual = ColoringSchemeTools.ImportScheme(lyr, Filename);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ImportScheme
        ///</summary>
        [TestMethod()]
        public void ImportSchemeTest2()
        {
            GridColorScheme sch = null; // TODO: Initialize to an appropriate value
            GridColorScheme schExpected = null; // TODO: Initialize to an appropriate value
            XmlElement e = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = ColoringSchemeTools.ImportScheme(ref sch, e);
            Assert.AreEqual(schExpected, sch);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ImportScheme
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ImportSchemeTest1()
        {
            ShapefileColorScheme sch = null; // TODO: Initialize to an appropriate value
            ShapefileColorScheme schExpected = null; // TODO: Initialize to an appropriate value
            Shapefile sf = null; // TODO: Initialize to an appropriate value
            Shapefile sfExpected = null; // TODO: Initialize to an appropriate value
            XmlElement e = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = ColoringSchemeTools_Accessor.ImportScheme(ref sch, ref sf, e);
            Assert.AreEqual(schExpected, sch);
            Assert.AreEqual(sfExpected, sf);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ImportScheme
        ///</summary>
        [TestMethod()]
        public void ImportSchemeTest()
        {
            GridColorScheme gsh = null; // TODO: Initialize to an appropriate value
            GridColorScheme gshExpected = null; // TODO: Initialize to an appropriate value
            string Filename = string.Empty; // TODO: Initialize to an appropriate value
            string GridName = string.Empty; // TODO: Initialize to an appropriate value
            string GridNameExpected = string.Empty; // TODO: Initialize to an appropriate value
            string GroupName = string.Empty; // TODO: Initialize to an appropriate value
            string GroupNameExpected = string.Empty; // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            actual = ColoringSchemeTools.ImportScheme(ref gsh, Filename, ref GridName, ref GroupName);
            Assert.AreEqual(gshExpected, gsh);
            Assert.AreEqual(GridNameExpected, GridName);
            Assert.AreEqual(GroupNameExpected, GroupName);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ExportScheme
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ExportSchemeTest2()
        {
            GridColorScheme Scheme = null; // TODO: Initialize to an appropriate value
            XmlDocument RootDoc = null; // TODO: Initialize to an appropriate value
            XmlElement Parent = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = ColoringSchemeTools_Accessor.ExportScheme(Scheme, RootDoc, Parent);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ExportScheme
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ExportSchemeTest1()
        {
            ShapefileColorScheme Scheme = null; // TODO: Initialize to an appropriate value
            XmlDocument RootDoc = null; // TODO: Initialize to an appropriate value
            XmlElement Parent = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = ColoringSchemeTools_Accessor.ExportScheme(Scheme, RootDoc, Parent);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ExportScheme
        ///</summary>
        [TestMethod()]
        public void ExportSchemeTest()
        {
            MapWindow.Interfaces.Layer lyr = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.Layer lyrExpected = null; // TODO: Initialize to an appropriate value
            string Path = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = MapWindow.ColoringSchemeTools.ExportScheme(ref lyr, Path);
            Assert.AreEqual(lyrExpected, lyr);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ColoringSchemesAreEqual
        ///</summary>
        [TestMethod()]
        public void ColoringSchemesAreEqualTest()
        {
            GridColorScheme LoadedScheme = null; // TODO: Initialize to an appropriate value
            string DiskScheme = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = ColoringSchemeTools.ColoringSchemesAreEqual(LoadedScheme, DiskScheme);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ColoringSchemeTools Constructor
        ///</summary>
        [TestMethod()]
        public void ColoringSchemeToolsConstructorTest()
        {
            ColoringSchemeTools target = new ColoringSchemeTools();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
