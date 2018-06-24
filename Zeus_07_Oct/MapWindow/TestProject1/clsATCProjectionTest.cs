using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for clsATCProjectionTest and is intended
    ///to contain all clsATCProjectionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class clsATCProjectionTest
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
        ///A test for Zone
        ///</summary>
        [TestMethod()]
        public void ZoneTest()
        {
            clsATCProjection target = new clsATCProjection(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Zone = expected;
            actual = target.Zone;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ProjectionClass
        ///</summary>
        [TestMethod()]
        public void ProjectionClassTest()
        {
            clsATCProjection target = new clsATCProjection(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.ProjectionClass = expected;
            actual = target.ProjectionClass;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            clsATCProjection target = new clsATCProjection(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Name = expected;
            actual = target.Name;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Fieldnames
        ///</summary>
        [TestMethod()]
        public void FieldnamesTest()
        {
            clsATCProjection target = new clsATCProjection(); // TODO: Initialize to an appropriate value
            clsATCProjection expected = null; // TODO: Initialize to an appropriate value
            clsATCProjection actual;
            target.Fieldnames = expected;
            actual = target.Fieldnames;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Ellipsoid
        ///</summary>
        [TestMethod()]
        public void EllipsoidTest()
        {
            clsATCProjection target = new clsATCProjection(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Ellipsoid = expected;
            actual = target.Ellipsoid;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Defaults
        ///</summary>
        [TestMethod()]
        public void DefaultsTest()
        {
            clsATCProjection target = new clsATCProjection(); // TODO: Initialize to an appropriate value
            clsATCProjection expected = null; // TODO: Initialize to an appropriate value
            clsATCProjection actual;
            target.Defaults = expected;
            actual = target.Defaults;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for d
        ///</summary>
        [TestMethod()]
        public void dTest()
        {
            clsATCProjection target = new clsATCProjection(); // TODO: Initialize to an appropriate value
            int Index = 0; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.set_d(Index, expected);
            actual = target.get_d(Index);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Category
        ///</summary>
        [TestMethod()]
        public void CategoryTest()
        {
            clsATCProjection target = new clsATCProjection(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Category = expected;
            actual = target.Category;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            clsATCProjection target = new clsATCProjection(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for clsATCProjection Constructor
        ///</summary>
        [TestMethod()]
        public void clsATCProjectionConstructorTest()
        {
            clsATCProjection target = new clsATCProjection();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
