using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for modMainTest and is intended
    ///to contain all modMainTest Unit Tests
    ///</summary>
    [TestClass()]
    public class modMainTest
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
        ///A test for ShowWelcomeScreen
        ///</summary>
        [TestMethod()]
        public void ShowWelcomeScreenTest()
        {
            modMain.ShowWelcomeScreen();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ShowError
        ///</summary>
        [TestMethod()]
        public void ShowErrorTest()
        {
            Exception ex = null; // TODO: Initialize to an appropriate value
            string email = string.Empty; // TODO: Initialize to an appropriate value
            modMain.ShowError(ex, email);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SaveFormPosition
        ///</summary>
        [TestMethod()]
        public void SaveFormPositionTest()
        {
            Form Fo = null; // TODO: Initialize to an appropriate value
            modMain.SaveFormPosition(Fo);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for RunProjectCommandLine
        ///</summary>
        [TestMethod()]
        public void RunProjectCommandLineTest()
        {
            string CommandLine = string.Empty; // TODO: Initialize to an appropriate value
            bool broadcastCmdLine = false; // TODO: Initialize to an appropriate value
            bool broadcastCmdLineExpected = false; // TODO: Initialize to an appropriate value
            modMain.RunProjectCommandLine(CommandLine, ref broadcastCmdLine);
            Assert.AreEqual(broadcastCmdLineExpected, broadcastCmdLine);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for RunConfigCommandLine
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void RunConfigCommandLineTest()
        {
            bool broadcastCmdLine = false; // TODO: Initialize to an appropriate value
            bool broadcastCmdLineExpected = false; // TODO: Initialize to an appropriate value
            modMain_Accessor.RunConfigCommandLine(ref broadcastCmdLine);
            Assert.AreEqual(broadcastCmdLineExpected, broadcastCmdLine);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Main
        ///</summary>
        [TestMethod()]
        public void MainTest()
        {
            modMain.Main();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadMainForm
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void LoadMainFormTest()
        {
            modMain_Accessor.LoadMainForm();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadFormPosition
        ///</summary>
        [TestMethod()]
        public void LoadFormPositionTest()
        {
            Form Fo = null; // TODO: Initialize to an appropriate value
            modMain.LoadFormPosition(Fo);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadCulture
        ///</summary>
        [TestMethod()]
        public void LoadCultureTest()
        {
            modMain.LoadCulture();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadConfig
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void LoadConfigTest()
        {
            modMain_Accessor.LoadConfig();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for FindSafeWindowLocation
        ///</summary>
        [TestMethod()]
        public void FindSafeWindowLocationTest()
        {
            int W = 0; // TODO: Initialize to an appropriate value
            int WExpected = 0; // TODO: Initialize to an appropriate value
            int H = 0; // TODO: Initialize to an appropriate value
            int HExpected = 0; // TODO: Initialize to an appropriate value
            Point Location = new Point(); // TODO: Initialize to an appropriate value
            Point LocationExpected = new Point(); // TODO: Initialize to an appropriate value
            modMain.FindSafeWindowLocation(ref W, ref H, ref Location);
            Assert.AreEqual(WExpected, W);
            Assert.AreEqual(HExpected, H);
            Assert.AreEqual(LocationExpected, Location);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CheckPROJNAD
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void CheckPROJNADTest()
        {
            modMain_Accessor.CheckPROJNAD();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
