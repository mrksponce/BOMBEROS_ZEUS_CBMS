using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualBasic;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for modNonModalMessageBoxTest and is intended
    ///to contain all modNonModalMessageBoxTest Unit Tests
    ///</summary>
    [TestClass()]
    public class modNonModalMessageBoxTest
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
        ///A test for doNonModalMessageBox__
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void doNonModalMessageBox__Test()
        {
            modNonModalMessageBox_Accessor.doNonModalMessageBox__();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for doNonModalMessageBox
        ///</summary>
        [TestMethod()]
        public void doNonModalMessageBoxTest()
        {
            string Message = string.Empty; // TODO: Initialize to an appropriate value
            MsgBoxStyle msgboxStyle = new MsgBoxStyle(); // TODO: Initialize to an appropriate value
            string Caption = string.Empty; // TODO: Initialize to an appropriate value
            modNonModalMessageBox.doNonModalMessageBox(Message, msgboxStyle, Caption);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
