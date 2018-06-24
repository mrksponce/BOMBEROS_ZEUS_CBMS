using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using MapWinGIS;
// using MapWindow.Interfaces;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for XmlProjectFileTest and is intended
    ///to contain all XmlProjectFileTest Unit Tests
    ///</summary>
    [TestClass()]
    public class XmlProjectFileTest
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
        ///A test for UserConfigFile
        ///</summary>
        [TestMethod()]
        public void UserConfigFileTest()
        {
            XmlProjectFile target = new XmlProjectFile(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.UserConfigFile;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DefaultConfigFile
        ///</summary>
        [TestMethod()]
        public void DefaultConfigFileTest()
        {
            XmlProjectFile target = new XmlProjectFile(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.DefaultConfigFile;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SerializePointImageScheme
        ///</summary>
        [TestMethod()]
        public void SerializePointImageSchemeTest()
        {
            XmlProjectFile target = new XmlProjectFile(); // TODO: Initialize to an appropriate value
            PointImageScheme PointImgScheme = null; // TODO: Initialize to an appropriate value
            PointImageScheme PointImgSchemeExpected = null; // TODO: Initialize to an appropriate value
            XmlDocument doc = null; // TODO: Initialize to an appropriate value
            XmlDocument docExpected = null; // TODO: Initialize to an appropriate value
            XmlElement root = null; // TODO: Initialize to an appropriate value
            XmlElement rootExpected = null; // TODO: Initialize to an appropriate value
            target.SerializePointImageScheme(ref PointImgScheme, ref doc, ref root);
            Assert.AreEqual(PointImgSchemeExpected, PointImgScheme);
            Assert.AreEqual(docExpected, doc);
            Assert.AreEqual(rootExpected, root);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SaveProject
        ///</summary>
        [TestMethod()]
        public void SaveProjectTest()
        {
            XmlProjectFile target = new XmlProjectFile(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.SaveProject();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SaveMapImage
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void SaveMapImageTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlDocument m_Doc = null; // TODO: Initialize to an appropriate value
            XmlDocument m_DocExpected = null; // TODO: Initialize to an appropriate value
            object img = null; // TODO: Initialize to an appropriate value
            XmlElement parent = null; // TODO: Initialize to an appropriate value
            target.SaveMapImage(ref m_Doc, img, parent);
            Assert.AreEqual(m_DocExpected, m_Doc);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SaveMainToolbarButtons
        ///</summary>
        [TestMethod()]
        public void SaveMainToolbarButtonsTest()
        {
            XmlProjectFile.SaveMainToolbarButtons();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SaveLayer
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void SaveLayerTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            object layer = null; // TODO: Initialize to an appropriate value
            int handle = 0; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.eLayerType layerType = new MapWindow.Interfaces.eLayerType(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.SaveLayer(layer, handle, layerType);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SaveImage
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void SaveImageTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlDocument m_Doc = null; // TODO: Initialize to an appropriate value
            XmlDocument m_DocExpected = null; // TODO: Initialize to an appropriate value
            object img = null; // TODO: Initialize to an appropriate value
            XmlElement parent = null; // TODO: Initialize to an appropriate value
            target.SaveImage(ref m_Doc, img, parent);
            Assert.AreEqual(m_DocExpected, m_Doc);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SaveCulture
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void SaveCultureTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            target.SaveCulture();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SaveConfig
        ///</summary>
        [TestMethod()]
        public void SaveConfigTest()
        {
            XmlProjectFile target = new XmlProjectFile(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.SaveConfig();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RestorePreviewMap
        ///</summary>
        [TestMethod()]
        public void RestorePreviewMapTest()
        {
            XmlProjectFile target = new XmlProjectFile(); // TODO: Initialize to an appropriate value
            MapWinGIS.Image Image = null; // TODO: Initialize to an appropriate value
            MapWinGIS.Image ImageExpected = null; // TODO: Initialize to an appropriate value
            target.RestorePreviewMap(ref Image);
            Assert.AreEqual(ImageExpected, Image);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PromptToBrowse
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void PromptToBrowseTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            string filePath = string.Empty; // TODO: Initialize to an appropriate value
            string filePathExpected = string.Empty; // TODO: Initialize to an appropriate value
            string displayName = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.PromptToBrowse(ref filePath, displayName);
            Assert.AreEqual(filePathExpected, filePath);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LoadView
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void LoadViewTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlElement view = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.LoadView(view);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LoadShpFileColoringScheme
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void LoadShpFileColoringSchemeTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlElement legend = null; // TODO: Initialize to an appropriate value
            int handle = 0; // TODO: Initialize to an appropriate value
            target.LoadShpFileColoringScheme(legend, handle);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadShapePropertiesList
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void LoadShapePropertiesListTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlElement propList = null; // TODO: Initialize to an appropriate value
            int handle = 0; // TODO: Initialize to an appropriate value
            target.LoadShapePropertiesList(propList, handle);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadRecentProjects
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void LoadRecentProjectsTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlElement RecentFiles = null; // TODO: Initialize to an appropriate value
            target.LoadRecentProjects(RecentFiles);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadProject
        ///</summary>
        [TestMethod()]
        public void LoadProjectTest()
        {
            XmlProjectFile target = new XmlProjectFile(); // TODO: Initialize to an appropriate value
            string Filename = string.Empty; // TODO: Initialize to an appropriate value
            bool LayersOnly = false; // TODO: Initialize to an appropriate value
            string LayersIntoGroup = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.LoadProject(Filename, LayersOnly, LayersIntoGroup);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LoadPreviewMap
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void LoadPreviewMapTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlElement previewMap = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.LoadPreviewMap(previewMap);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LoadPlugins
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void LoadPluginsTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlElement plugins = null; // TODO: Initialize to an appropriate value
            bool loadingConfig = false; // TODO: Initialize to an appropriate value
            target.LoadPlugins(plugins, loadingConfig);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadPlugin
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void LoadPluginTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlNode plugin = null; // TODO: Initialize to an appropriate value
            bool loadingConfig = false; // TODO: Initialize to an appropriate value
            bool loadingApplictionPlugins = false; // TODO: Initialize to an appropriate value
            target.LoadPlugin(plugin, loadingConfig, loadingApplictionPlugins);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadLayers
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void LoadLayersTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlElement layers = null; // TODO: Initialize to an appropriate value
            int totNumLayers = 0; // TODO: Initialize to an appropriate value
            int index = 0; // TODO: Initialize to an appropriate value
            int indexExpected = 0; // TODO: Initialize to an appropriate value
            target.LoadLayers(layers, totNumLayers, ref index);
            Assert.AreEqual(indexExpected, index);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadLayerProperties
        ///</summary>
        [TestMethod()]
        public void LoadLayerPropertiesTest()
        {
            XmlProjectFile target = new XmlProjectFile(); // TODO: Initialize to an appropriate value
            XmlNode layer = null; // TODO: Initialize to an appropriate value
            int ExistingLayerHandle = 0; // TODO: Initialize to an appropriate value
            bool PluginCall = false; // TODO: Initialize to an appropriate value
            target.LoadLayerProperties(layer, ExistingLayerHandle, PluginCall);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadGroups
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void LoadGroupsTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlElement groups = null; // TODO: Initialize to an appropriate value
            bool LayersOnly = false; // TODO: Initialize to an appropriate value
            string LayersIntoGroup = string.Empty; // TODO: Initialize to an appropriate value
            target.LoadGroups(groups, LayersOnly, LayersIntoGroup);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadGridFileColoringScheme
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void LoadGridFileColoringSchemeTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlElement legend = null; // TODO: Initialize to an appropriate value
            GridColorScheme expected = null; // TODO: Initialize to an appropriate value
            GridColorScheme actual;
            actual = target.LoadGridFileColoringScheme(legend);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LoadExtents
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void LoadExtentsTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlElement ext = null; // TODO: Initialize to an appropriate value
            target.LoadExtents(ext);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadDynamicVisibility
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void LoadDynamicVisibilityTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            Layer mapWinLayer = null; // TODO: Initialize to an appropriate value
            XmlNode node = null; // TODO: Initialize to an appropriate value
            target.LoadDynamicVisibility(mapWinLayer, node);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadConfig
        ///</summary>
        [TestMethod()]
        public void LoadConfigTest()
        {
            XmlProjectFile target = new XmlProjectFile(); // TODO: Initialize to an appropriate value
            bool Load_Plugins = false; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.LoadConfig(Load_Plugins);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LoadColorPalettes
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void LoadColorPalettesTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlElement colorPalettes = null; // TODO: Initialize to an appropriate value
            target.LoadColorPalettes(colorPalettes);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadBookmarks
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void LoadBookmarksTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlElement view = null; // TODO: Initialize to an appropriate value
            target.LoadBookmarks(view);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadApplicationPlugins
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void LoadApplicationPluginsTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlElement plugins = null; // TODO: Initialize to an appropriate value
            bool loadingConfig = false; // TODO: Initialize to an appropriate value
            target.LoadApplicationPlugins(plugins, loadingConfig);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadAppInfo
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void LoadAppInfoTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlElement AppInfoXML = null; // TODO: Initialize to an appropriate value
            target.LoadAppInfo(AppInfoXML);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetSplashInfo
        ///</summary>
        [TestMethod()]
        public void GetSplashInfoTest()
        {
            XmlProjectFile target = new XmlProjectFile(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.GetSplashInfo();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetRelativePath
        ///</summary>
        [TestMethod()]
        public void GetRelativePathTest()
        {
            XmlProjectFile target = new XmlProjectFile(); // TODO: Initialize to an appropriate value
            string Filename = string.Empty; // TODO: Initialize to an appropriate value
            string ProjectFile = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetRelativePath(Filename, ProjectFile);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetApplicationDataDir
        ///</summary>
        [TestMethod()]
        public void GetApplicationDataDirTest()
        {
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = XmlProjectFile.GetApplicationDataDir();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DeserializePointImageScheme
        ///</summary>
        [TestMethod()]
        public void DeserializePointImageSchemeTest()
        {
            XmlProjectFile target = new XmlProjectFile(); // TODO: Initialize to an appropriate value
            long newHandle = 0; // TODO: Initialize to an appropriate value
            XmlElement root = null; // TODO: Initialize to an appropriate value
            XmlElement rootExpected = null; // TODO: Initialize to an appropriate value
            target.DeserializePointImageScheme(newHandle, ref root);
            Assert.AreEqual(rootExpected, root);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DeleteShapeFile
        ///</summary>
        [TestMethod()]
        public void DeleteShapeFileTest()
        {
            XmlProjectFile target = new XmlProjectFile(); // TODO: Initialize to an appropriate value
            string fileName = string.Empty; // TODO: Initialize to an appropriate value
            target.DeleteShapeFile(fileName);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CreateConfigFileFromDefault
        ///</summary>
        [TestMethod()]
        public void CreateConfigFileFromDefaultTest()
        {
            XmlProjectFile target = new XmlProjectFile(); // TODO: Initialize to an appropriate value
            string NewConfigFile = string.Empty; // TODO: Initialize to an appropriate value
            target.CreateConfigFileFromDefault(NewConfigFile);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ConvertStringToImage
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ConvertStringToImageTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            string image = string.Empty; // TODO: Initialize to an appropriate value
            string type = string.Empty; // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            actual = target.ConvertStringToImage(image, type);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ConvertImageToString
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void ConvertImageToStringTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            object img = null; // TODO: Initialize to an appropriate value
            string type = string.Empty; // TODO: Initialize to an appropriate value
            string typeExpected = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.ConvertImageToString(img, ref type);
            Assert.AreEqual(typeExpected, type);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CompareFilesByTime
        ///</summary>
        [TestMethod()]
        public void CompareFilesByTimeTest()
        {
            XmlProjectFile target = new XmlProjectFile(); // TODO: Initialize to an appropriate value
            string file1 = string.Empty; // TODO: Initialize to an appropriate value
            string file2 = string.Empty; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.CompareFilesByTime(file1, file2);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddViewElement
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void AddViewElementTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlDocument m_Doc = null; // TODO: Initialize to an appropriate value
            XmlDocument m_DocExpected = null; // TODO: Initialize to an appropriate value
            XmlElement Parent = null; // TODO: Initialize to an appropriate value
            target.AddViewElement(ref m_Doc, Parent);
            Assert.AreEqual(m_DocExpected, m_Doc);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddToRecentProjects
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void AddToRecentProjectsTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            string ProjectName = string.Empty; // TODO: Initialize to an appropriate value
            target.AddToRecentProjects(ProjectName);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddShapeListElement
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void AddShapeListElementTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlDocument m_Doc = null; // TODO: Initialize to an appropriate value
            XmlDocument m_DocExpected = null; // TODO: Initialize to an appropriate value
            Layer sfl = null; // TODO: Initialize to an appropriate value
            XmlNode parent = null; // TODO: Initialize to an appropriate value
            target.AddShapeListElement(ref m_Doc, sfl, parent);
            Assert.AreEqual(m_DocExpected, m_Doc);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddShapeFileElement
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void AddShapeFileElementTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlDocument m_Doc = null; // TODO: Initialize to an appropriate value
            XmlDocument m_DocExpected = null; // TODO: Initialize to an appropriate value
            Layer shpFileLayer = null; // TODO: Initialize to an appropriate value
            XmlNode parent = null; // TODO: Initialize to an appropriate value
            target.AddShapeFileElement(ref m_Doc, shpFileLayer, parent);
            Assert.AreEqual(m_DocExpected, m_Doc);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddRecentProjects
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void AddRecentProjectsTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlDocument m_Doc = null; // TODO: Initialize to an appropriate value
            XmlDocument m_DocExpected = null; // TODO: Initialize to an appropriate value
            XmlElement Parent = null; // TODO: Initialize to an appropriate value
            target.AddRecentProjects(ref m_Doc, Parent);
            Assert.AreEqual(m_DocExpected, m_Doc);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddPreViewMapElement
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void AddPreViewMapElementTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlDocument m_Doc = null; // TODO: Initialize to an appropriate value
            XmlDocument m_DocExpected = null; // TODO: Initialize to an appropriate value
            XmlElement Parent = null; // TODO: Initialize to an appropriate value
            target.AddPreViewMapElement(ref m_Doc, Parent);
            Assert.AreEqual(m_DocExpected, m_Doc);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddPluginsElement
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void AddPluginsElementTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlDocument m_Doc = null; // TODO: Initialize to an appropriate value
            XmlDocument m_DocExpected = null; // TODO: Initialize to an appropriate value
            XmlElement Parent = null; // TODO: Initialize to an appropriate value
            bool LoadingConfig = false; // TODO: Initialize to an appropriate value
            target.AddPluginsElement(ref m_Doc, Parent, LoadingConfig);
            Assert.AreEqual(m_DocExpected, m_Doc);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddPluginElement
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void AddPluginElementTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlDocument m_Doc = null; // TODO: Initialize to an appropriate value
            XmlDocument m_DocExpected = null; // TODO: Initialize to an appropriate value
            object Plugin = null; // TODO: Initialize to an appropriate value
            string PluginKey = string.Empty; // TODO: Initialize to an appropriate value
            XmlElement Parent = null; // TODO: Initialize to an appropriate value
            bool LoadingConfig = false; // TODO: Initialize to an appropriate value
            target.AddPluginElement(ref m_Doc, Plugin, PluginKey, Parent, LoadingConfig);
            Assert.AreEqual(m_DocExpected, m_Doc);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddLegendElement
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void AddLegendElementTest1()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlDocument m_Doc = null; // TODO: Initialize to an appropriate value
            XmlDocument m_DocExpected = null; // TODO: Initialize to an appropriate value
            GridColorScheme legend = null; // TODO: Initialize to an appropriate value
            XmlElement parent = null; // TODO: Initialize to an appropriate value
            target.AddLegendElement(ref m_Doc, legend, parent);
            Assert.AreEqual(m_DocExpected, m_Doc);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddLegendElement
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void AddLegendElementTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlDocument m_Doc = null; // TODO: Initialize to an appropriate value
            XmlDocument m_DocExpected = null; // TODO: Initialize to an appropriate value
            ShapefileColorScheme legend = null; // TODO: Initialize to an appropriate value
            XmlElement parent = null; // TODO: Initialize to an appropriate value
            target.AddLegendElement(ref m_Doc, legend, parent);
            Assert.AreEqual(m_DocExpected, m_Doc);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddLayers
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void AddLayersTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlDocument m_Doc = null; // TODO: Initialize to an appropriate value
            XmlDocument m_DocExpected = null; // TODO: Initialize to an appropriate value
            XmlElement Parent = null; // TODO: Initialize to an appropriate value
            target.AddLayers(ref m_Doc, Parent);
            Assert.AreEqual(m_DocExpected, m_Doc);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddLayerElement
        ///</summary>
        [TestMethod()]
        public void AddLayerElementTest()
        {
            XmlProjectFile target = new XmlProjectFile(); // TODO: Initialize to an appropriate value
            XmlDocument m_doc = null; // TODO: Initialize to an appropriate value
            XmlDocument m_docExpected = null; // TODO: Initialize to an appropriate value
            Layer mapWinLayer = null; // TODO: Initialize to an appropriate value
            XmlNode parent = null; // TODO: Initialize to an appropriate value
            target.AddLayerElement(ref m_doc, mapWinLayer, parent);
            Assert.AreEqual(m_docExpected, m_doc);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddGridElement
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void AddGridElementTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlDocument m_Doc = null; // TODO: Initialize to an appropriate value
            XmlDocument m_DocExpected = null; // TODO: Initialize to an appropriate value
            Layer gridFileLayer = null; // TODO: Initialize to an appropriate value
            XmlNode parent = null; // TODO: Initialize to an appropriate value
            target.AddGridElement(ref m_Doc, gridFileLayer, parent);
            Assert.AreEqual(m_DocExpected, m_Doc);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddExtentsElement
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void AddExtentsElementTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlDocument m_Doc = null; // TODO: Initialize to an appropriate value
            XmlDocument m_DocExpected = null; // TODO: Initialize to an appropriate value
            XmlElement Parent = null; // TODO: Initialize to an appropriate value
            Extents Exts = null; // TODO: Initialize to an appropriate value
            target.AddExtentsElement(ref m_Doc, Parent, Exts);
            Assert.AreEqual(m_DocExpected, m_Doc);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddDynamicVisibility
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void AddDynamicVisibilityTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlDocument m_Doc = null; // TODO: Initialize to an appropriate value
            XmlDocument m_DocExpected = null; // TODO: Initialize to an appropriate value
            Layer mapWinLayer = null; // TODO: Initialize to an appropriate value
            XmlNode parent = null; // TODO: Initialize to an appropriate value
            target.AddDynamicVisibility(ref m_Doc, mapWinLayer, parent);
            Assert.AreEqual(m_DocExpected, m_Doc);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddColorPalettes
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void AddColorPalettesTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlDocument m_Doc = null; // TODO: Initialize to an appropriate value
            XmlDocument m_DocExpected = null; // TODO: Initialize to an appropriate value
            XmlElement Parent = null; // TODO: Initialize to an appropriate value
            target.AddColorPalettes(ref m_Doc, Parent);
            Assert.AreEqual(m_DocExpected, m_Doc);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddColorBreaksElement
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void AddColorBreaksElementTest1()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlDocument m_Doc = null; // TODO: Initialize to an appropriate value
            XmlDocument m_DocExpected = null; // TODO: Initialize to an appropriate value
            GridColorBreak colorBreak = null; // TODO: Initialize to an appropriate value
            XmlElement parent = null; // TODO: Initialize to an appropriate value
            target.AddColorBreaksElement(ref m_Doc, colorBreak, parent);
            Assert.AreEqual(m_DocExpected, m_Doc);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddColorBreaksElement
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void AddColorBreaksElementTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlDocument m_Doc = null; // TODO: Initialize to an appropriate value
            XmlDocument m_DocExpected = null; // TODO: Initialize to an appropriate value
            ShapefileColorBreak colorBreak = null; // TODO: Initialize to an appropriate value
            XmlElement parent = null; // TODO: Initialize to an appropriate value
            target.AddColorBreaksElement(ref m_Doc, colorBreak, parent);
            Assert.AreEqual(m_DocExpected, m_Doc);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddBookmarks
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void AddBookmarksTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlDocument m_Doc = null; // TODO: Initialize to an appropriate value
            XmlDocument m_DocExpected = null; // TODO: Initialize to an appropriate value
            XmlElement Parent = null; // TODO: Initialize to an appropriate value
            target.AddBookmarks(ref m_Doc, Parent);
            Assert.AreEqual(m_DocExpected, m_Doc);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddApplicationPluginsElement
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void AddApplicationPluginsElementTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlDocument m_Doc = null; // TODO: Initialize to an appropriate value
            XmlDocument m_DocExpected = null; // TODO: Initialize to an appropriate value
            XmlElement Parent = null; // TODO: Initialize to an appropriate value
            bool LoadingConfig = false; // TODO: Initialize to an appropriate value
            target.AddApplicationPluginsElement(ref m_Doc, Parent, LoadingConfig);
            Assert.AreEqual(m_DocExpected, m_Doc);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddAppInfo
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void AddAppInfoTest()
        {
            XmlProjectFile_Accessor target = new XmlProjectFile_Accessor(); // TODO: Initialize to an appropriate value
            XmlDocument m_Doc = null; // TODO: Initialize to an appropriate value
            XmlDocument m_DocExpected = null; // TODO: Initialize to an appropriate value
            XmlElement Parent = null; // TODO: Initialize to an appropriate value
            target.AddAppInfo(ref m_Doc, Parent);
            Assert.AreEqual(m_DocExpected, m_Doc);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for XmlProjectFile Constructor
        ///</summary>
        [TestMethod()]
        public void XmlProjectFileConstructorTest()
        {
            XmlProjectFile target = new XmlProjectFile();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
