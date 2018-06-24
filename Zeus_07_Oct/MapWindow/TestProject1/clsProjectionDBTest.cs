using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for clsProjectionDBTest and is intended
    ///to contain all clsProjectionDBTest Unit Tests
    ///</summary>
    [TestClass()]
    public class clsProjectionDBTest
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
        ///A test for StandardProjections
        ///</summary>
        [TestMethod()]
        public void StandardProjectionsTest()
        {
            clsProjectionDB target = new clsProjectionDB(); // TODO: Initialize to an appropriate value
            Hashtable actual;
            actual = target.StandardProjections;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Ellipsoids
        ///</summary>
        [TestMethod()]
        public void EllipsoidsTest()
        {
            clsProjectionDB target = new clsProjectionDB(); // TODO: Initialize to an appropriate value
            Hashtable actual;
            actual = target.Ellipsoids;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BaseProjections
        ///</summary>
        [TestMethod()]
        public void BaseProjectionsTest()
        {
            clsProjectionDB target = new clsProjectionDB(); // TODO: Initialize to an appropriate value
            Hashtable actual;
            actual = target.BaseProjections;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ReadProjectionDatabase
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ReadProjectionDatabaseTest()
        {
            clsProjectionDB_Accessor target = new clsProjectionDB_Accessor(); // TODO: Initialize to an appropriate value
            target.ReadProjectionDatabase();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OpenProjectionDatabase
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void OpenProjectionDatabaseTest()
        {
            clsProjectionDB_Accessor target = new clsProjectionDB_Accessor(); // TODO: Initialize to an appropriate value
            IATCTable expected = null; // TODO: Initialize to an appropriate value
            IATCTable actual;
            actual = target.OpenProjectionDatabase();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddCustomProjection
        ///</summary>
        [TestMethod()]
        public void AddCustomProjectionTest()
        {
            clsProjectionDB target = new clsProjectionDB(); // TODO: Initialize to an appropriate value
            string aName = string.Empty; // TODO: Initialize to an appropriate value
            string aProjectionClass = string.Empty; // TODO: Initialize to an appropriate value
            string aZone = string.Empty; // TODO: Initialize to an appropriate value
            string aSpheroid = string.Empty; // TODO: Initialize to an appropriate value
            string D1 = string.Empty; // TODO: Initialize to an appropriate value
            string D2 = string.Empty; // TODO: Initialize to an appropriate value
            string D3 = string.Empty; // TODO: Initialize to an appropriate value
            string D4 = string.Empty; // TODO: Initialize to an appropriate value
            string D5 = string.Empty; // TODO: Initialize to an appropriate value
            string D6 = string.Empty; // TODO: Initialize to an appropriate value
            target.AddCustomProjection(aName, aProjectionClass, aZone, aSpheroid, D1, D2, D3, D4, D5, D6);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for clsProjectionDB Constructor
        ///</summary>
        [TestMethod()]
        public void clsProjectionDBConstructorTest()
        {
            clsProjectionDB target = new clsProjectionDB();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
