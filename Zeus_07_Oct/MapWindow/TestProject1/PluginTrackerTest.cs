using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualBasic;
// using MapWindow.Interfaces;
using System.Collections;
using System.Drawing;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for PluginTrackerTest and is intended
    ///to contain all PluginTrackerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PluginTrackerTest
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
        ///A test for UnloadApplicationPlugins
        ///</summary>
        [TestMethod()]
        public void UnloadApplicationPluginsTest()
        {
            MapWindow.PluginTracker target = new PluginTracker(); // TODO: Initialize to an appropriate value
            target.UnloadApplicationPlugins();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UnloadAll
        ///</summary>
        [TestMethod()]
        public void UnloadAllTest()
        {
            MapWindow.PluginTracker target = new PluginTracker(); // TODO: Initialize to an appropriate value
            target.UnloadAll();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for StopPlugin
        ///</summary>
        [TestMethod()]
        public void StopPluginTest()
        {
            MapWindow.PluginTracker target = new PluginTracker(); // TODO: Initialize to an appropriate value            
            string Key = string.Empty; // TODO: Initialize to an appropriate value
            target.StopPlugin(Key);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for StartPlugin
        ///</summary>
        [TestMethod()]
        public void StartPluginTest()
        {
            MapWindow.PluginTracker target = new PluginTracker(); // TODO: Initialize to an appropriate value
            string Key = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.StartPlugin(Key);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ShowPluginDialog
        ///</summary>
        [TestMethod()]
        public void ShowPluginDialogTest()
        {
            MapWindow.PluginTracker target = new PluginTracker(); // TODO: Initialize to an appropriate value
            target.ShowPluginDialog();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ShapesSelected
        ///</summary>
        [TestMethod()]
        public void ShapesSelectedTest()
        {
            MapWindow.PluginTracker target = new PluginTracker(); // TODO: Initialize to an appropriate value
            int Handle = 0; // TODO: Initialize to an appropriate value
            SelectInfo SelectInfo = null; // TODO: Initialize to an appropriate value
            target.ShapesSelected(Handle, SelectInfo);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ProjectSaving
        ///</summary>
        [TestMethod()]
        public void ProjectSavingTest()
        {
            MapWindow.PluginTracker target = new PluginTracker(); // TODO: Initialize to an appropriate value
            string Key = string.Empty; // TODO: Initialize to an appropriate value
            string ProjectFile = string.Empty; // TODO: Initialize to an appropriate value
            string SettingsString = string.Empty; // TODO: Initialize to an appropriate value
            target.ProjectSaving(Key, ProjectFile, SettingsString);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ProjectLoading
        ///</summary>
        [TestMethod()]
        public void ProjectLoadingTest()
        {
            MapWindow.PluginTracker target = new PluginTracker(); // TODO: Initialize to an appropriate value
            string Key = string.Empty; // TODO: Initialize to an appropriate value
            string ProjectFile = string.Empty; // TODO: Initialize to an appropriate value
            string SettingsString = string.Empty; // TODO: Initialize to an appropriate value
            target.ProjectLoading(Key, ProjectFile, SettingsString);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PluginsList
        ///</summary>
        [TestMethod()]
        public void PluginsListTest()
        {
            MapWindow.PluginTracker target = new PluginTracker(); // TODO: Initialize to an appropriate value
            Hashtable expected = null; // TODO: Initialize to an appropriate value
            Hashtable actual;
            actual = target.PluginsList();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PluginIsLoaded
        ///</summary>
        [TestMethod()]
        public void PluginIsLoadedTest()
        {
            MapWindow.PluginTracker target = new PluginTracker(); // TODO: Initialize to an appropriate value
            string Key = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.PluginIsLoaded(Key);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MapMouseUp
        ///</summary>
        [TestMethod()]
        public void MapMouseUpTest()
        {
            MapWindow.PluginTracker target = new PluginTracker(); // TODO: Initialize to an appropriate value
            int Button = 0; // TODO: Initialize to an appropriate value
            int Shift = 0; // TODO: Initialize to an appropriate value
            int X = 0; // TODO: Initialize to an appropriate value
            int Y = 0; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.MapMouseUp(Button, Shift, X, Y);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MapMouseMove
        ///</summary>
        [TestMethod()]
        public void MapMouseMoveTest()
        {
            MapWindow.PluginTracker target = new PluginTracker(); // TODO: Initialize to an appropriate value
            int ScreenX = 0; // TODO: Initialize to an appropriate value
            int ScreenY = 0; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.MapMouseMove(ScreenX, ScreenY);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MapMouseDown
        ///</summary>
        [TestMethod()]
        public void MapMouseDownTest()
        {
            MapWindow.PluginTracker target = new PluginTracker(); // TODO: Initialize to an appropriate value
            int Button = 0; // TODO: Initialize to an appropriate value
            int Shift = 0; // TODO: Initialize to an appropriate value
            int X = 0; // TODO: Initialize to an appropriate value
            int Y = 0; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.MapMouseDown(Button, Shift, X, Y);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MapExtentsChanged
        ///</summary>
        [TestMethod()]
        public void MapExtentsChangedTest()
        {
            MapWindow.PluginTracker target = new PluginTracker(); // TODO: Initialize to an appropriate value
            target.MapExtentsChanged();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MapDragFinished
        ///</summary>
        [TestMethod()]
        public void MapDragFinishedTest()
        {
            MapWindow.PluginTracker target = new PluginTracker(); // TODO: Initialize to an appropriate value
            Rectangle Bounds = new Rectangle(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.MapDragFinished(Bounds);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for m_ApplicationPlugins
        ///</summary>
        [TestMethod()]
        public void m_ApplicationPluginsTest()
        {
            MapWindow.PluginTracker target = new PluginTracker(); // TODO: Initialize to an appropriate value
            Hashtable expected = null; // TODO: Initialize to an appropriate value
            Hashtable actual;
            actual = target.m_ApplicationPlugins();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LoadPlugins
        ///</summary>
        [TestMethod()]
        public void LoadPluginsTest()
        {
            MapWindow.PluginTracker target = new PluginTracker(); // TODO: Initialize to an appropriate value
            target.LoadPlugins();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadedPlugins
        ///</summary>
        [TestMethod()]
        public void LoadedPluginsTest()
        {
            MapWindow.PluginTracker target = new PluginTracker(); // TODO: Initialize to an appropriate value
            Collection expected = null; // TODO: Initialize to an appropriate value
            Collection actual;
            actual = target.LoadedPlugins();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LoadApplicationPlugins
        ///</summary>
        [TestMethod()]
        public void LoadApplicationPluginsTest()
        {
            MapWindow.PluginTracker target = new PluginTracker(); // TODO: Initialize to an appropriate value
            string ApplicationPluginPath = string.Empty; // TODO: Initialize to an appropriate value
            target.LoadApplicationPlugins(ApplicationPluginPath);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LegendMouseUp
        ///</summary>
        [TestMethod()]
        public void LegendMouseUpTest()
        {
            MapWindow.PluginTracker target = new PluginTracker(); // TODO: Initialize to an appropriate value
            int Handle = 0; // TODO: Initialize to an appropriate value
            int Button = 0; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ClickLocation Location = new MapWindow.Interfaces.ClickLocation(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.LegendMouseUp(Handle, Button, Location);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LegendMouseDown
        ///</summary>
        [TestMethod()]
        public void LegendMouseDownTest()
        {
            MapWindow.PluginTracker target = new PluginTracker(); // TODO: Initialize to an appropriate value
            int Handle = 0; // TODO: Initialize to an appropriate value
            int Button = 0; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ClickLocation Location = new MapWindow.Interfaces.ClickLocation(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.LegendMouseDown(Handle, Button, Location);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LegendDoubleClick
        ///</summary>
        [TestMethod()]
        public void LegendDoubleClickTest()
        {
            MapWindow.PluginTracker target = new PluginTracker(); // TODO: Initialize to an appropriate value
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ClickLocation Location = new MapWindow.Interfaces.ClickLocation(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.LegendDoubleClick(LayerHandle, Location);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LayerSelected
        ///</summary>
        [TestMethod()]
        public void LayerSelectedTest()
        {
            MapWindow.PluginTracker target = new PluginTracker(); // TODO: Initialize to an appropriate value
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            target.LayerSelected(LayerHandle);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LayersCleared
        ///</summary>
        [TestMethod()]
        public void LayersClearedTest()
        {
            MapWindow.PluginTracker target = new PluginTracker(); // TODO: Initialize to an appropriate value
            target.LayersCleared();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LayersAdded
        ///</summary>
        [TestMethod()]
        public void LayersAddedTest()
        {
            MapWindow.PluginTracker target = new PluginTracker(); // TODO: Initialize to an appropriate value
            Layer[] Handle = null; // TODO: Initialize to an appropriate value
            target.LayersAdded(Handle);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LayerRemoved
        ///</summary>
        [TestMethod()]
        public void LayerRemovedTest()
        {
            MapWindow.PluginTracker target = new PluginTracker(); // TODO: Initialize to an appropriate value
            int LayerHandle = 0; // TODO: Initialize to an appropriate value
            target.LayerRemoved(LayerHandle);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ItemClicked
        ///</summary>
        [TestMethod()]
        public void ItemClickedTest()
        {
            MapWindow.PluginTracker target = new PluginTracker(); // TODO: Initialize to an appropriate value
            string ItemName = string.Empty; // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            actual = target.ItemClicked(ItemName);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ContainsKey
        ///</summary>
        [TestMethod()]
        public void ContainsKeyTest()
        {
            MapWindow.PluginTracker target = new MapWindow.PluginTracker(); // TODO: Initialize to an appropriate value
            Collection c = null; // TODO: Initialize to an appropriate value
            string key = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.ContainsKey(c, key);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddFromFile
        ///</summary>
        [TestMethod()]
        public void AddFromFileTest()
        {
            MapWindow.PluginTracker target = new PluginTracker(); // TODO: Initialize to an appropriate value
            string File = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.AddFromFile(File);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MapWindow.PluginInterfaces.PluginTracker Constructor
        ///</summary>
        [TestMethod()]
        public void PluginTrackerConstructorTest()
        {
            MapWindow.PluginTracker target = new PluginTracker();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
