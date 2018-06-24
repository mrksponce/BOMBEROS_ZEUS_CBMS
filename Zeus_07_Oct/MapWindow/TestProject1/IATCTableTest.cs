using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for IATCTableTest and is intended
    ///to contain all IATCTableTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IATCTableTest
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
            IATCTable target = CreateIATCTable(); // TODO: Initialize to an appropriate value
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
            IATCTable target = CreateIATCTable(); // TODO: Initialize to an appropriate value
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
            IATCTable target = CreateIATCTable(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.NumFields = expected;
            actual = target.NumFields;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FileName
        ///</summary>
        [TestMethod()]
        public void FileNameTest()
        {
            IATCTable target = CreateIATCTable(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.FileName = expected;
            actual = target.FileName;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FieldType
        ///</summary>
        [TestMethod()]
        public void FieldTypeTest()
        {
            IATCTable target = CreateIATCTable(); // TODO: Initialize to an appropriate value
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
            IATCTable target = CreateIATCTable(); // TODO: Initialize to an appropriate value
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
            IATCTable target = CreateIATCTable(); // TODO: Initialize to an appropriate value
            int aFieldNumber = 0; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.set_FieldLength(aFieldNumber, expected);
            actual = target.get_FieldLength(aFieldNumber);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CurrentRecord
        ///</summary>
        [TestMethod()]
        public void CurrentRecordTest()
        {
            IATCTable target = CreateIATCTable(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.CurrentRecord = expected;
            actual = target.CurrentRecord;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for atEOF
        ///</summary>
        [TestMethod()]
        public void atEOFTest()
        {
            IATCTable target = CreateIATCTable(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.atEOF = expected;
            actual = target.atEOF;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for atBOF
        ///</summary>
        [TestMethod()]
        public void atBOFTest()
        {
            IATCTable target = CreateIATCTable(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.atBOF = expected;
            actual = target.atBOF;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for WriteFile
        ///</summary>
        [TestMethod()]
        public void WriteFileTest()
        {
            IATCTable target = CreateIATCTable(); // TODO: Initialize to an appropriate value
            string aFilename = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.WriteFile(aFilename);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SummaryFile
        ///</summary>
        [TestMethod()]
        public void SummaryFileTest()
        {
            IATCTable target = CreateIATCTable(); // TODO: Initialize to an appropriate value
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
            IATCTable target = CreateIATCTable(); // TODO: Initialize to an appropriate value
            string aFormat = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.SummaryFields(aFormat);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Summary
        ///</summary>
        [TestMethod()]
        public void SummaryTest()
        {
            IATCTable target = CreateIATCTable(); // TODO: Initialize to an appropriate value
            string aFormat = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Summary(aFormat);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OpenFile
        ///</summary>
        [TestMethod()]
        public void OpenFileTest()
        {
            IATCTable target = CreateIATCTable(); // TODO: Initialize to an appropriate value
            string aFilename = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.OpenFile(aFilename);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MovePrevious
        ///</summary>
        [TestMethod()]
        public void MovePreviousTest()
        {
            IATCTable target = CreateIATCTable(); // TODO: Initialize to an appropriate value
            target.MovePrevious();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MoveNext
        ///</summary>
        [TestMethod()]
        public void MoveNextTest()
        {
            IATCTable target = CreateIATCTable(); // TODO: Initialize to an appropriate value
            target.MoveNext();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MoveLast
        ///</summary>
        [TestMethod()]
        public void MoveLastTest()
        {
            IATCTable target = CreateIATCTable(); // TODO: Initialize to an appropriate value
            target.MoveLast();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MoveFirst
        ///</summary>
        [TestMethod()]
        public void MoveFirstTest()
        {
            IATCTable target = CreateIATCTable(); // TODO: Initialize to an appropriate value
            target.MoveFirst();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for FindNext
        ///</summary>
        [TestMethod()]
        public void FindNextTest()
        {
            IATCTable target = CreateIATCTable(); // TODO: Initialize to an appropriate value
            int aFieldNumber = 0; // TODO: Initialize to an appropriate value
            string aFindValue = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.FindNext(aFieldNumber, aFindValue);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FindFirst
        ///</summary>
        [TestMethod()]
        public void FindFirstTest()
        {
            IATCTable target = CreateIATCTable(); // TODO: Initialize to an appropriate value
            int aFieldNumber = 0; // TODO: Initialize to an appropriate value
            string aFindValue = string.Empty; // TODO: Initialize to an appropriate value
            int aStartRecord = 0; // TODO: Initialize to an appropriate value
            int aEndRecord = 0; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.FindFirst(aFieldNumber, aFindValue, aStartRecord, aEndRecord);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FieldNumber
        ///</summary>
        [TestMethod()]
        public void FieldNumberTest()
        {
            IATCTable target = CreateIATCTable(); // TODO: Initialize to an appropriate value
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
            IATCTable target = CreateIATCTable(); // TODO: Initialize to an appropriate value
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
            IATCTable target = CreateIATCTable(); // TODO: Initialize to an appropriate value
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
            IATCTable target = CreateIATCTable(); // TODO: Initialize to an appropriate value
            target.ClearData();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        internal virtual IATCTable CreateIATCTable()
        {
            // TODO: Instantiate an appropriate concrete class.
            IATCTable target = null;
            return target;
        }

        /// <summary>
        ///A test for Clear
        ///</summary>
        [TestMethod()]
        public void ClearTest()
        {
            IATCTable target = CreateIATCTable(); // TODO: Initialize to an appropriate value
            target.Clear();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
