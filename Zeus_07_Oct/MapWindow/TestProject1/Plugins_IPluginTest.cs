using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// using MapWindow.Interfaces;
using Microsoft.VisualBasic;
using System.Collections;
using System.Drawing;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for Plugins_IPluginTest and is intended
    ///to contain all Plugins_IPluginTest Unit Tests
    ///</summary>
    [TestClass()]
    public class Plugins_IPluginTest
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
        ///A test for PluginsList
        ///</summary>
        [TestMethod()]
        public void PluginsListTest()
        {
            Plugins_IPlugin target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
            Hashtable actual;
            actual = target.PluginsList;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PluginFolder
        ///</summary>
        [TestMethod()]
        public void PluginFolderTest()
        {
            MapWindow.Interfaces.Plugins target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.PluginFolder = expected;
            actual = target.PluginFolder;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LoadedPlugins
        ///</summary>
        [TestMethod()]
        public void LoadedPluginsTest()
        {
            Plugins_IPlugin target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
            Collection actual;
            actual = target.LoadedPlugins;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Item
        ///</summary>
        [TestMethod()]
        public void ItemTest()
        {
            MapWindow.Interfaces.Plugins target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
            int Index = 0; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.IPlugin actual;
            actual = target[Index];
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Count
        ///</summary>
        [TestMethod()]
        public void CountTest()
        {
            MapWindow.Interfaces.Plugins target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.Count;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UnloadApplicationPlugins
        ///</summary>
        [TestMethod()]
        public void UnloadApplicationPluginsTest()
        {
            Plugins_IPlugin target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
            target.UnloadApplicationPlugins();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UnloadAll
        ///</summary>
        [TestMethod()]
        public void UnloadAllTest()
        {
            Plugins_IPlugin target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
            target.UnloadAll();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for StopPlugin
        ///</summary>
        [TestMethod()]
        public void StopPluginTest()
        {
            MapWindow.Interfaces.Plugins target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
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
            MapWindow.Interfaces.Plugins target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
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
            MapWindow.Interfaces.Plugins target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
            target.ShowPluginDialog();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ShapesSelected
        ///</summary>
        [TestMethod()]
        public void ShapesSelectedTest()
        {
            Plugins_IPlugin target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
            int Handle = 0; // TODO: Initialize to an appropriate value
            SelectInfo SelectInfo = null; // TODO: Initialize to an appropriate value
            target.ShapesSelected(Handle, SelectInfo);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Remove
        ///</summary>
        [TestMethod()]
        public void RemoveTest()
        {
            MapWindow.Interfaces.Plugins target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
            object IndexOrKey = null; // TODO: Initialize to an appropriate value
            target.Remove(IndexOrKey);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ProjectSaving
        ///</summary>
        [TestMethod()]
        public void ProjectSavingTest()
        {
            Plugins_IPlugin target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
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
            Plugins_IPlugin target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
            string Key = string.Empty; // TODO: Initialize to an appropriate value
            string ProjectFile = string.Empty; // TODO: Initialize to an appropriate value
            string SettingsString = string.Empty; // TODO: Initialize to an appropriate value
            target.ProjectLoading(Key, ProjectFile, SettingsString);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PluginIsLoaded
        ///</summary>
        [TestMethod()]
        public void PluginIsLoadedTest()
        {
            MapWindow.Interfaces.Plugins target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
            string Key = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.PluginIsLoaded(Key);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Message
        ///</summary>
        [TestMethod()]
        public void MessageTest()
        {
            Plugins_IPlugin target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
            string msg = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Message(msg);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MapMouseUp
        ///</summary>
        [TestMethod()]
        public void MapMouseUpTest()
        {
            Plugins_IPlugin target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
            int Button = 0; // TODO: Initialize to an appropriate value
            int Shift = 0; // TODO: Initialize to an appropriate value
            int x = 0; // TODO: Initialize to an appropriate value
            int y = 0; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.MapMouseUp(Button, Shift, x, y);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MapMouseMove
        ///</summary>
        [TestMethod()]
        public void MapMouseMoveTest()
        {
            Plugins_IPlugin target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
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
            Plugins_IPlugin target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
            int Button = 0; // TODO: Initialize to an appropriate value
            int Shift = 0; // TODO: Initialize to an appropriate value
            int x = 0; // TODO: Initialize to an appropriate value
            int y = 0; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.MapMouseDown(Button, Shift, x, y);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MapExtentsChanged
        ///</summary>
        [TestMethod()]
        public void MapExtentsChangedTest()
        {
            Plugins_IPlugin target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
            target.MapExtentsChanged();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MapDragFinished
        ///</summary>
        [TestMethod()]
        public void MapDragFinishedTest()
        {
            Plugins_IPlugin target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
            Rectangle Bounds = new Rectangle(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.MapDragFinished(Bounds);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LoadPlugins
        ///</summary>
        [TestMethod()]
        public void LoadPluginsTest()
        {
            Plugins_IPlugin target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.LoadPlugins();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LoadFromObject
        ///</summary>
        [TestMethod()]
        public void LoadFromObjectTest1()
        {
            MapWindow.Interfaces.Plugins target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.IPlugin Plugin = null; // TODO: Initialize to an appropriate value
            string PluginKey = string.Empty; // TODO: Initialize to an appropriate value
            string SettingsString = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.LoadFromObject(Plugin, PluginKey, SettingsString);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LoadFromObject
        ///</summary>
        [TestMethod()]
        public void LoadFromObjectTest()
        {
            MapWindow.Interfaces.Plugins target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.IPlugin Plugin = null; // TODO: Initialize to an appropriate value
            string PluginKey = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.LoadFromObject(Plugin, PluginKey);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LoadApplicationPlugins
        ///</summary>
        [TestMethod()]
        public void LoadApplicationPluginsTest()
        {
            Plugins_IPlugin target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
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
            Plugins_IPlugin target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
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
            Plugins_IPlugin target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
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
            Plugins_IPlugin target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
            int Handle = 0; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ClickLocation Location = new MapWindow.Interfaces.ClickLocation(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.LegendDoubleClick(Handle, Location);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LayerSelected
        ///</summary>
        [TestMethod()]
        public void LayerSelectedTest()
        {
            Plugins_IPlugin target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
            int Handle = 0; // TODO: Initialize to an appropriate value
            target.LayerSelected(Handle);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LayersCleared
        ///</summary>
        [TestMethod()]
        public void LayersClearedTest()
        {
            Plugins_IPlugin target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
            target.LayersCleared();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LayersAdded
        ///</summary>
        [TestMethod()]
        public void LayersAddedTest()
        {
            Plugins_IPlugin target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
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
            Plugins_IPlugin target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
            int Handle = 0; // TODO: Initialize to an appropriate value
            target.LayerRemoved(Handle);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ItemClicked
        ///</summary>
        [TestMethod()]
        public void ItemClickedTest()
        {
            Plugins_IPlugin target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
            string ItemName = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.ItemClicked(ItemName);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetPluginKey
        ///</summary>
        [TestMethod()]
        public void GetPluginKeyTest()
        {
            MapWindow.Interfaces.Plugins target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
            string PluginName = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetPluginKey(PluginName);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetEnumerator
        ///</summary>
        [TestMethod()]
        public void GetEnumeratorTest()
        {
            IEnumerable target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
            IEnumerator expected = null; // TODO: Initialize to an appropriate value
            IEnumerator actual;
            actual = target.GetEnumerator();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FormatCoords
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void FormatCoordsTest()
        {
            Plugins_IPlugin_Accessor target = new Plugins_IPlugin_Accessor(); // TODO: Initialize to an appropriate value
            double x = 0F; // TODO: Initialize to an appropriate value
            double y = 0F; // TODO: Initialize to an appropriate value
            int decimals = 0; // TODO: Initialize to an appropriate value
            string useCommas = string.Empty; // TODO: Initialize to an appropriate value
            string units = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.FormatCoords(x, y, decimals, useCommas, units);
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
            Plugins_IPlugin_Accessor target = new Plugins_IPlugin_Accessor(); // TODO: Initialize to an appropriate value
            target.Finalize();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ContainsKey
        ///</summary>
        [TestMethod()]
        public void ContainsKeyTest()
        {
            Plugins_IPlugin target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
            Collection c = null; // TODO: Initialize to an appropriate value
            object key = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.ContainsKey(c, key);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Contains
        ///</summary>
        [TestMethod()]
        public void ContainsTest()
        {
            Plugins_IPlugin target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
            string Key = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Contains(Key);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Clear
        ///</summary>
        [TestMethod()]
        public void ClearTest()
        {
            MapWindow.Interfaces.Plugins target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
            target.Clear();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for BroadcastMessage
        ///</summary>
        [TestMethod()]
        public void BroadcastMessageTest()
        {
            MapWindow.Interfaces.Plugins target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
            string Message = string.Empty; // TODO: Initialize to an appropriate value
            target.BroadcastMessage(Message);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddFromFile
        ///</summary>
        [TestMethod()]
        public void AddFromFileTest()
        {
            MapWindow.Interfaces.Plugins target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
            string Path = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.AddFromFile(Path);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddFromDir
        ///</summary>
        [TestMethod()]
        public void AddFromDirTest()
        {
            MapWindow.Interfaces.Plugins target = new Plugins_IPlugin(); // TODO: Initialize to an appropriate value
            string Path = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.AddFromDir(Path);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Plugins_IPlugin Constructor
        ///</summary>
        [TestMethod()]
        public void Plugins_IPluginConstructorTest()
        {
            Plugins_IPlugin target = new Plugins_IPlugin();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
