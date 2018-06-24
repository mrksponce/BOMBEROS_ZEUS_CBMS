using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for clsATCTableDBFTest and is intended
    ///to contain all clsATCTableDBFTest Unit Tests
    ///</summary>
    [TestClass()]
    public class clsATCTableDBFTest
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
        ///A test for Value
        ///</summary>
        [TestMethod()]
        public void ValueTest()
        {
            clsATCTableDBF target = new clsATCTableDBF(); // TODO: Initialize to an appropriate value
            int aFieldNumber = 0; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.set_Value(aFieldNumber, expected);
            actual = target.get_Value(aFieldNumber);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for NumRecords
        ///</summary>
        [TestMethod()]
        public void NumRecordsTest()
        {
            clsATCTableDBF target = new clsATCTableDBF(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.NumRecords = expected;
            actual = target.NumRecords;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for NumFields
        ///</summary>
        [TestMethod()]
        public void NumFieldsTest()
        {
            clsATCTableDBF target = new clsATCTableDBF(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.NumFields = expected;
            actual = target.NumFields;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FieldType
        ///</summary>
        [TestMethod()]
        public void FieldTypeTest()
        {
            clsATCTableDBF target = new clsATCTableDBF(); // TODO: Initialize to an appropriate value
            int aFieldNumber = 0; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.set_FieldType(aFieldNumber, expected);
            actual = target.get_FieldType(aFieldNumber);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FieldName
        ///</summary>
        [TestMethod()]
        public void FieldNameTest()
        {
            clsATCTableDBF target = new clsATCTableDBF(); // TODO: Initialize to an appropriate value
            int aFieldNumber = 0; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.set_FieldName(aFieldNumber, expected);
            actual = target.get_FieldName(aFieldNumber);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FieldLength
        ///</summary>
        [TestMethod()]
        public void FieldLengthTest()
        {
            clsATCTableDBF target = new clsATCTableDBF(); // TODO: Initialize to an appropriate value
            int aFieldNumber = 0; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.set_FieldLength(aFieldNumber, expected);
            actual = target.get_FieldLength(aFieldNumber);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FieldDecimalCount
        ///</summary>
        [TestMethod()]
        public void FieldDecimalCountTest()
        {
            clsATCTableDBF target = new clsATCTableDBF(); // TODO: Initialize to an appropriate value
            int aFieldNumber = 0; // TODO: Initialize to an appropriate value
            byte expected = 0; // TODO: Initialize to an appropriate value
            byte actual;
            target.set_FieldDecimalCount(aFieldNumber, expected);
            actual = target.get_FieldDecimalCount(aFieldNumber);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CurrentRecord
        ///</summary>
        [TestMethod()]
        public void CurrentRecordTest()
        {
            clsATCTableDBF target = new clsATCTableDBF(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.CurrentRecord = expected;
            actual = target.CurrentRecord;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for WriteFile
        ///</summary>
        [TestMethod()]
        public void WriteFileTest()
        {
            clsATCTableDBF target = new clsATCTableDBF(); // TODO: Initialize to an appropriate value
            string aFilename = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.WriteFile(aFilename);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TrimNull
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void TrimNullTest()
        {
            clsATCTableDBF_Accessor target = new clsATCTableDBF_Accessor(); // TODO: Initialize to an appropriate value
            string Value = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.TrimNull(Value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SummaryFile
        ///</summary>
        [TestMethod()]
        public void SummaryFileTest()
        {
            clsATCTableDBF target = new clsATCTableDBF(); // TODO: Initialize to an appropriate value
            string aFormat = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.SummaryFile(aFormat);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SummaryFields
        ///</summary>
        [TestMethod()]
        public void SummaryFieldsTest()
        {
            clsATCTableDBF target = new clsATCTableDBF(); // TODO: Initialize to an appropriate value
            string aFormat = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.SummaryFields(aFormat);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SetDataAddresses
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void SetDataAddressesTest()
        {
            clsATCTableDBF_Accessor target = new clsATCTableDBF_Accessor(); // TODO: Initialize to an appropriate value
            target.SetDataAddresses();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OpenFile
        ///</summary>
        [TestMethod()]
        public void OpenFileTest()
        {
            clsATCTableDBF target = new clsATCTableDBF(); // TODO: Initialize to an appropriate value
            string aFilename = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.OpenFile(aFilename);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for InitData
        ///</summary>
        [TestMethod()]
        public void InitDataTest()
        {
            clsATCTableDBF target = new clsATCTableDBF(); // TODO: Initialize to an appropriate value
            target.InitData();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for FindMatch
        ///</summary>
        [TestMethod()]
        public void FindMatchTest()
        {
            clsATCTableDBF target = new clsATCTableDBF(); // TODO: Initialize to an appropriate value
            int[] aFieldNum = null; // TODO: Initialize to an appropriate value
            string[] aOperation = null; // TODO: Initialize to an appropriate value
            object[] aFieldVal = null; // TODO: Initialize to an appropriate value
            bool aMatchAny = false; // TODO: Initialize to an appropriate value
            int aStartRecord = 0; // TODO: Initialize to an appropriate value
            int aEndRecord = 0; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.FindMatch(aFieldNum, aOperation, aFieldVal, aMatchAny, aStartRecord, aEndRecord);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FieldNumber
        ///</summary>
        [TestMethod()]
        public void FieldNumberTest()
        {
            clsATCTableDBF target = new clsATCTableDBF(); // TODO: Initialize to an appropriate value
            string aFieldName = string.Empty; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.FieldNumber(aFieldName);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CreationCode
        ///</summary>
        [TestMethod()]
        public void CreationCodeTest()
        {
            clsATCTableDBF target = new clsATCTableDBF(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.CreationCode();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Cousin
        ///</summary>
        [TestMethod()]
        public void CousinTest()
        {
            clsATCTableDBF target = new clsATCTableDBF(); // TODO: Initialize to an appropriate value
            IATCTable expected = null; // TODO: Initialize to an appropriate value
            IATCTable actual;
            actual = target.Cousin();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ClearData
        ///</summary>
        [TestMethod()]
        public void ClearDataTest()
        {
            clsATCTableDBF target = new clsATCTableDBF(); // TODO: Initialize to an appropriate value
            target.ClearData();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Clear
        ///</summary>
        [TestMethod()]
        public void ClearTest()
        {
            clsATCTableDBF target = new clsATCTableDBF(); // TODO: Initialize to an appropriate value
            target.Clear();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for clsATCTableDBF Constructor
        ///</summary>
        [TestMethod()]
        public void clsATCTableDBFConstructorTest()
        {
            clsATCTableDBF target = new clsATCTableDBF();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
