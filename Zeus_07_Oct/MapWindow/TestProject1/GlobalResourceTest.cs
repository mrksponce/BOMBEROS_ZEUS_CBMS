using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using System.Resources;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for GlobalResourceTest and is intended
    ///to contain all GlobalResourceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GlobalResourceTest
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
        ///A test for WarningProjectionMismatch_Text
        ///</summary>
        [TestMethod()]
        public void WarningProjectionMismatch_TextTest()
        {
            string actual;
            actual = GlobalResource.WarningProjectionMismatch_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for WarningNoProjectionOnLayer_Text
        ///</summary>
        [TestMethod()]
        public void WarningNoProjectionOnLayer_TextTest()
        {
            string actual;
            actual = GlobalResource.WarningNoProjectionOnLayer_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UserDefined_Text
        ///</summary>
        [TestMethod()]
        public void UserDefined_TextTest()
        {
            string actual;
            actual = GlobalResource.UserDefined_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToolStripMenuItem6_Text
        ///</summary>
        [TestMethod()]
        public void ToolStripMenuItem6_TextTest()
        {
            string actual;
            actual = GlobalResource.ToolStripMenuItem6_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for titleRemoveGroup_Text
        ///</summary>
        [TestMethod()]
        public void titleRemoveGroup_TextTest()
        {
            string actual;
            actual = GlobalResource.titleRemoveGroup_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for titleNoConnection_Text
        ///</summary>
        [TestMethod()]
        public void titleNoConnection_TextTest()
        {
            string actual;
            actual = GlobalResource.titleNoConnection_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for titleClearLayers_Text
        ///</summary>
        [TestMethod()]
        public void titleClearLayers_TextTest()
        {
            string actual;
            actual = GlobalResource.titleClearLayers_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for sbContextMenu_UpperRight_Text
        ///</summary>
        [TestMethod()]
        public void sbContextMenu_UpperRight_TextTest()
        {
            string actual;
            actual = GlobalResource.sbContextMenu_UpperRight_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for sbContextMenu_UpperLeft_Text
        ///</summary>
        [TestMethod()]
        public void sbContextMenu_UpperLeft_TextTest()
        {
            string actual;
            actual = GlobalResource.sbContextMenu_UpperLeft_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for sbContextMenu_LowerRight_Text
        ///</summary>
        [TestMethod()]
        public void sbContextMenu_LowerRight_TextTest()
        {
            string actual;
            actual = GlobalResource.sbContextMenu_LowerRight_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for sbContextMenu_LowerLeft_Text
        ///</summary>
        [TestMethod()]
        public void sbContextMenu_LowerLeft_TextTest()
        {
            string actual;
            actual = GlobalResource.sbContextMenu_LowerLeft_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for sbContextMenu_ChooseForecolor_Text
        ///</summary>
        [TestMethod()]
        public void sbContextMenu_ChooseForecolor_TextTest()
        {
            string actual;
            actual = GlobalResource.sbContextMenu_ChooseForecolor_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for sbContextMenu_ChooseBackcolor_Text
        ///</summary>
        [TestMethod()]
        public void sbContextMenu_ChooseBackcolor_TextTest()
        {
            string actual;
            actual = GlobalResource.sbContextMenu_ChooseBackcolor_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for sbContextMenu_ChangeUnits_Text
        ///</summary>
        [TestMethod()]
        public void sbContextMenu_ChangeUnits_TextTest()
        {
            string actual;
            actual = GlobalResource.sbContextMenu_ChangeUnits_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ResourceManager
        ///</summary>
        [TestMethod()]
        public void ResourceManagerTest()
        {
            ResourceManager actual;
            actual = GlobalResource.ResourceManager;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PluginPropertyVersion_Text
        ///</summary>
        [TestMethod()]
        public void PluginPropertyVersion_TextTest()
        {
            string actual;
            actual = GlobalResource.PluginPropertyVersion_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PluginPropertyName_Text
        ///</summary>
        [TestMethod()]
        public void PluginPropertyName_TextTest()
        {
            string actual;
            actual = GlobalResource.PluginPropertyName_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PluginPropertyDescription_Text
        ///</summary>
        [TestMethod()]
        public void PluginPropertyDescription_TextTest()
        {
            string actual;
            actual = GlobalResource.PluginPropertyDescription_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PluginPropertyBuildDate_Text
        ///</summary>
        [TestMethod()]
        public void PluginPropertyBuildDate_TextTest()
        {
            string actual;
            actual = GlobalResource.PluginPropertyBuildDate_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PluginPropertyAuthor_Text
        ///</summary>
        [TestMethod()]
        public void PluginPropertyAuthor_TextTest()
        {
            string actual;
            actual = GlobalResource.PluginPropertyAuthor_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgVirtualMemory_Text
        ///</summary>
        [TestMethod()]
        public void msgVirtualMemory_TextTest()
        {
            string actual;
            actual = GlobalResource.msgVirtualMemory_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgVersion_Text
        ///</summary>
        [TestMethod()]
        public void msgVersion_TextTest()
        {
            string actual;
            actual = GlobalResource.msgVersion_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgUpdateToolNotFound_Text
        ///</summary>
        [TestMethod()]
        public void msgUpdateToolNotFound_TextTest()
        {
            string actual;
            actual = GlobalResource.msgUpdateToolNotFound_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgTotalUserModeCpuTime_Text
        ///</summary>
        [TestMethod()]
        public void msgTotalUserModeCpuTime_TextTest()
        {
            string actual;
            actual = GlobalResource.msgTotalUserModeCpuTime_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgTotalCpuTime_Text
        ///</summary>
        [TestMethod()]
        public void msgTotalCpuTime_TextTest()
        {
            string actual;
            actual = GlobalResource.msgTotalCpuTime_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgSubmittedSuccessfully_Text
        ///</summary>
        [TestMethod()]
        public void msgSubmittedSuccessfully_TextTest()
        {
            string actual;
            actual = GlobalResource.msgSubmittedSuccessfully_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgShortcutsTitle_Text
        ///</summary>
        [TestMethod()]
        public void msgShortcutsTitle_TextTest()
        {
            string actual;
            actual = GlobalResource.msgShortcutsTitle_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgShortcutsPlus_Text
        ///</summary>
        [TestMethod()]
        public void msgShortcutsPlus_TextTest()
        {
            string actual;
            actual = GlobalResource.msgShortcutsPlus_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgShortcutsPageUp_Text
        ///</summary>
        [TestMethod()]
        public void msgShortcutsPageUp_TextTest()
        {
            string actual;
            actual = GlobalResource.msgShortcutsPageUp_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgShortcutsPageDown_Text
        ///</summary>
        [TestMethod()]
        public void msgShortcutsPageDown_TextTest()
        {
            string actual;
            actual = GlobalResource.msgShortcutsPageDown_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgShortcutsMinus_Text
        ///</summary>
        [TestMethod()]
        public void msgShortcutsMinus_TextTest()
        {
            string actual;
            actual = GlobalResource.msgShortcutsMinus_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgShortcutsIns_Text
        ///</summary>
        [TestMethod()]
        public void msgShortcutsIns_TextTest()
        {
            string actual;
            actual = GlobalResource.msgShortcutsIns_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgShortcutsHome_Text
        ///</summary>
        [TestMethod()]
        public void msgShortcutsHome_TextTest()
        {
            string actual;
            actual = GlobalResource.msgShortcutsHome_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgShortcutsDel_Text
        ///</summary>
        [TestMethod()]
        public void msgShortcutsDel_TextTest()
        {
            string actual;
            actual = GlobalResource.msgShortcutsDel_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgShortcutsCtrlSpace_Text
        ///</summary>
        [TestMethod()]
        public void msgShortcutsCtrlSpace_TextTest()
        {
            string actual;
            actual = GlobalResource.msgShortcutsCtrlSpace_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgShortcutsCtrlShiftP_Text
        ///</summary>
        [TestMethod()]
        public void msgShortcutsCtrlShiftP_TextTest()
        {
            string actual;
            actual = GlobalResource.msgShortcutsCtrlShiftP_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgShortcutsCtrlShiftO_Text
        ///</summary>
        [TestMethod()]
        public void msgShortcutsCtrlShiftO_TextTest()
        {
            string actual;
            actual = GlobalResource.msgShortcutsCtrlShiftO_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgShortcutsCtrlShiftI_Text
        ///</summary>
        [TestMethod()]
        public void msgShortcutsCtrlShiftI_TextTest()
        {
            string actual;
            actual = GlobalResource.msgShortcutsCtrlShiftI_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgShortcutsCtrlS_Text
        ///</summary>
        [TestMethod()]
        public void msgShortcutsCtrlS_TextTest()
        {
            string actual;
            actual = GlobalResource.msgShortcutsCtrlS_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgShortcutsCtrlP_Text
        ///</summary>
        [TestMethod()]
        public void msgShortcutsCtrlP_TextTest()
        {
            string actual;
            actual = GlobalResource.msgShortcutsCtrlP_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgShortcutsCtrlO_Text
        ///</summary>
        [TestMethod()]
        public void msgShortcutsCtrlO_TextTest()
        {
            string actual;
            actual = GlobalResource.msgShortcutsCtrlO_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgShortcutsCtrlI_Text
        ///</summary>
        [TestMethod()]
        public void msgShortcutsCtrlI_TextTest()
        {
            string actual;
            actual = GlobalResource.msgShortcutsCtrlI_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgShortcutsCtrlHome_Text
        ///</summary>
        [TestMethod()]
        public void msgShortcutsCtrlHome_TextTest()
        {
            string actual;
            actual = GlobalResource.msgShortcutsCtrlHome_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgShortcutsCtrlH_Text
        ///</summary>
        [TestMethod()]
        public void msgShortcutsCtrlH_TextTest()
        {
            string actual;
            actual = GlobalResource.msgShortcutsCtrlH_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgShortcutsCtrlF4_Text
        ///</summary>
        [TestMethod()]
        public void msgShortcutsCtrlF4_TextTest()
        {
            string actual;
            actual = GlobalResource.msgShortcutsCtrlF4_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgShortcutsCtrlEnter_Text
        ///</summary>
        [TestMethod()]
        public void msgShortcutsCtrlEnter_TextTest()
        {
            string actual;
            actual = GlobalResource.msgShortcutsCtrlEnter_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgShortcutsCtrlC_Text
        ///</summary>
        [TestMethod()]
        public void msgShortcutsCtrlC_TextTest()
        {
            string actual;
            actual = GlobalResource.msgShortcutsCtrlC_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgShortcutsCtrlArrows_Text
        ///</summary>
        [TestMethod()]
        public void msgShortcutsCtrlArrows_TextTest()
        {
            string actual;
            actual = GlobalResource.msgShortcutsCtrlArrows_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgShortcutsArrowUp_Text
        ///</summary>
        [TestMethod()]
        public void msgShortcutsArrowUp_TextTest()
        {
            string actual;
            actual = GlobalResource.msgShortcutsArrowUp_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgShortcutsArrowRight_Text
        ///</summary>
        [TestMethod()]
        public void msgShortcutsArrowRight_TextTest()
        {
            string actual;
            actual = GlobalResource.msgShortcutsArrowRight_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgShortcutsArrowLeft_Text
        ///</summary>
        [TestMethod()]
        public void msgShortcutsArrowLeft_TextTest()
        {
            string actual;
            actual = GlobalResource.msgShortcutsArrowLeft_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgShortcutsArrowDown_Text
        ///</summary>
        [TestMethod()]
        public void msgShortcutsArrowDown_TextTest()
        {
            string actual;
            actual = GlobalResource.msgShortcutsArrowDown_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgScriptNotExists_Text
        ///</summary>
        [TestMethod()]
        public void msgScriptNotExists_TextTest()
        {
            string actual;
            actual = GlobalResource.msgScriptNotExists_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgScriptError_Text
        ///</summary>
        [TestMethod()]
        public void msgScriptError_TextTest()
        {
            string actual;
            actual = GlobalResource.msgScriptError_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgSaveProject2_Text
        ///</summary>
        [TestMethod()]
        public void msgSaveProject2_TextTest()
        {
            string actual;
            actual = GlobalResource.msgSaveProject2_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgSaveProject1_Text
        ///</summary>
        [TestMethod()]
        public void msgSaveProject1_TextTest()
        {
            string actual;
            actual = GlobalResource.msgSaveProject1_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgSaveCurrentScript_Text
        ///</summary>
        [TestMethod()]
        public void msgSaveCurrentScript_TextTest()
        {
            string actual;
            actual = GlobalResource.msgSaveCurrentScript_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgReprojectedGridDoesNotExists_Text
        ///</summary>
        [TestMethod()]
        public void msgReprojectedGridDoesNotExists_TextTest()
        {
            string actual;
            actual = GlobalResource.msgReprojectedGridDoesNotExists_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgRemoveGroup_Text
        ///</summary>
        [TestMethod()]
        public void msgRemoveGroup_TextTest()
        {
            string actual;
            actual = GlobalResource.msgRemoveGroup_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgProjectProjection_Text
        ///</summary>
        [TestMethod()]
        public void msgProjectProjection_TextTest()
        {
            string actual;
            actual = GlobalResource.msgProjectProjection_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgProjection_Text
        ///</summary>
        [TestMethod()]
        public void msgProjection_TextTest()
        {
            string actual;
            actual = GlobalResource.msgProjection_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgPrivateMemory_Text
        ///</summary>
        [TestMethod()]
        public void msgPrivateMemory_TextTest()
        {
            string actual;
            actual = GlobalResource.msgPrivateMemory_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgPerformanceInfo_Text
        ///</summary>
        [TestMethod()]
        public void msgPerformanceInfo_TextTest()
        {
            string actual;
            actual = GlobalResource.msgPerformanceInfo_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgPath_Text
        ///</summary>
        [TestMethod()]
        public void msgPath_TextTest()
        {
            string actual;
            actual = GlobalResource.msgPath_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgPanelDistance_Text
        ///</summary>
        [TestMethod()]
        public void msgPanelDistance_TextTest()
        {
            string actual;
            actual = GlobalResource.msgPanelDistance_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgPanelArea_Text
        ///</summary>
        [TestMethod()]
        public void msgPanelArea_TextTest()
        {
            string actual;
            actual = GlobalResource.msgPanelArea_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgOverwriteCurrentlyLoadedScript_Text
        ///</summary>
        [TestMethod()]
        public void msgOverwriteCurrentlyLoadedScript_TextTest()
        {
            string actual;
            actual = GlobalResource.msgOverwriteCurrentlyLoadedScript_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgNoConnection_Text
        ///</summary>
        [TestMethod()]
        public void msgNoConnection_TextTest()
        {
            string actual;
            actual = GlobalResource.msgNoConnection_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgNewLayerProjection_Text
        ///</summary>
        [TestMethod()]
        public void msgNewLayerProjection_TextTest()
        {
            string actual;
            actual = GlobalResource.msgNewLayerProjection_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgModulesInfo_Text
        ///</summary>
        [TestMethod()]
        public void msgModulesInfo_TextTest()
        {
            string actual;
            actual = GlobalResource.msgModulesInfo_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgModuleName_Text
        ///</summary>
        [TestMethod()]
        public void msgModuleName_TextTest()
        {
            string actual;
            actual = GlobalResource.msgModuleName_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgLegendLayerDoubleClick_Text
        ///</summary>
        [TestMethod()]
        public void msgLegendLayerDoubleClick_TextTest()
        {
            string actual;
            actual = GlobalResource.msgLegendLayerDoubleClick_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgIncomplete_Text
        ///</summary>
        [TestMethod()]
        public void msgIncomplete_TextTest()
        {
            string actual;
            actual = GlobalResource.msgIncomplete_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgIgnoreScript_Text
        ///</summary>
        [TestMethod()]
        public void msgIgnoreScript_TextTest()
        {
            string actual;
            actual = GlobalResource.msgIgnoreScript_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgHttpStatusCodeRedirect_Text
        ///</summary>
        [TestMethod()]
        public void msgHttpStatusCodeRedirect_TextTest()
        {
            string actual;
            actual = GlobalResource.msgHttpStatusCodeRedirect_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgHttpStatusCodeNotFound_Text
        ///</summary>
        [TestMethod()]
        public void msgHttpStatusCodeNotFound_TextTest()
        {
            string actual;
            actual = GlobalResource.msgHttpStatusCodeNotFound_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgHttpStatusCodeElse_Text
        ///</summary>
        [TestMethod()]
        public void msgHttpStatusCodeElse_TextTest()
        {
            string actual;
            actual = GlobalResource.msgHttpStatusCodeElse_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgHelpfileDoesNotExist_Text
        ///</summary>
        [TestMethod()]
        public void msgHelpfileDoesNotExist_TextTest()
        {
            string actual;
            actual = GlobalResource.msgHelpfileDoesNotExist_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgHandleShortcutKeys_Text
        ///</summary>
        [TestMethod()]
        public void msgHandleShortcutKeys_TextTest()
        {
            string actual;
            actual = GlobalResource.msgHandleShortcutKeys_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgGarbledServerResponse_Text
        ///</summary>
        [TestMethod()]
        public void msgGarbledServerResponse_TextTest()
        {
            string actual;
            actual = GlobalResource.msgGarbledServerResponse_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgFindTutorials_Text
        ///</summary>
        [TestMethod()]
        public void msgFindTutorials_TextTest()
        {
            string actual;
            actual = GlobalResource.msgFindTutorials_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgFindDocumentation_Text
        ///</summary>
        [TestMethod()]
        public void msgFindDocumentation_TextTest()
        {
            string actual;
            actual = GlobalResource.msgFindDocumentation_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgFileName_Text
        ///</summary>
        [TestMethod()]
        public void msgFileName_TextTest()
        {
            string actual;
            actual = GlobalResource.msgFileName_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgErrorSavingImage_Text
        ///</summary>
        [TestMethod()]
        public void msgErrorSavingImage_TextTest()
        {
            string actual;
            actual = GlobalResource.msgErrorSavingImage_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgError_Text
        ///</summary>
        [TestMethod()]
        public void msgError_TextTest()
        {
            string actual;
            actual = GlobalResource.msgError_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgDistanceStartOver_Text
        ///</summary>
        [TestMethod()]
        public void msgDistanceStartOver_TextTest()
        {
            string actual;
            actual = GlobalResource.msgDistanceStartOver_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgDataSubmitted_Text
        ///</summary>
        [TestMethod()]
        public void msgDataSubmitted_TextTest()
        {
            string actual;
            actual = GlobalResource.msgDataSubmitted_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgCustomProjection_Text
        ///</summary>
        [TestMethod()]
        public void msgCustomProjection_TextTest()
        {
            string actual;
            actual = GlobalResource.msgCustomProjection_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgClickNextPoint_Text
        ///</summary>
        [TestMethod()]
        public void msgClickNextPoint_TextTest()
        {
            string actual;
            actual = GlobalResource.msgClickNextPoint_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgClearLayers_Text
        ///</summary>
        [TestMethod()]
        public void msgClearLayers_TextTest()
        {
            string actual;
            actual = GlobalResource.msgClearLayers_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgChangeLanguage_Title
        ///</summary>
        [TestMethod()]
        public void msgChangeLanguage_TitleTest()
        {
            string actual;
            actual = GlobalResource.msgChangeLanguage_Title;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgChangeLanguage_Text
        ///</summary>
        [TestMethod()]
        public void msgChangeLanguage_TextTest()
        {
            string actual;
            actual = GlobalResource.msgChangeLanguage_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgBadUsernamePassword_Text
        ///</summary>
        [TestMethod()]
        public void msgBadUsernamePassword_TextTest()
        {
            string actual;
            actual = GlobalResource.msgBadUsernamePassword_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for msgAreaDrawnPolygon_Text
        ///</summary>
        [TestMethod()]
        public void msgAreaDrawnPolygon_TextTest()
        {
            string actual;
            actual = GlobalResource.msgAreaDrawnPolygon_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuZoomToPreviewExtents_Text
        ///</summary>
        [TestMethod()]
        public void mnuZoomToPreviewExtents_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuZoomToPreviewExtents_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuZoomToLayer_Text
        ///</summary>
        [TestMethod()]
        public void mnuZoomToLayer_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuZoomToLayer_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuZoomToGroup_Text
        ///</summary>
        [TestMethod()]
        public void mnuZoomToGroup_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuZoomToGroup_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuZoomToFullExtents_Text
        ///</summary>
        [TestMethod()]
        public void mnuZoomToFullExtents_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuZoomToFullExtents_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuZoomOut_Text
        ///</summary>
        [TestMethod()]
        public void mnuZoomOut_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuZoomOut_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuZoomIn_Text
        ///</summary>
        [TestMethod()]
        public void mnuZoomIn_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuZoomIn_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuWelcomeScreen_Text
        ///</summary>
        [TestMethod()]
        public void mnuWelcomeScreen_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuWelcomeScreen_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuView_Text
        ///</summary>
        [TestMethod()]
        public void mnuView_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuView_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuUpdatePreviewFull_Text
        ///</summary>
        [TestMethod()]
        public void mnuUpdatePreviewFull_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuUpdatePreviewFull_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuUpdatePreviewCurr_Text
        ///</summary>
        [TestMethod()]
        public void mnuUpdatePreviewCurr_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuUpdatePreviewCurr_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuShowScaleBar_Text
        ///</summary>
        [TestMethod()]
        public void mnuShowScaleBar_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuShowScaleBar_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuShowPreviewMap_Text
        ///</summary>
        [TestMethod()]
        public void mnuShowPreviewMap_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuShowPreviewMap_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuShowLegend_Text
        ///</summary>
        [TestMethod()]
        public void mnuShowLegend_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuShowLegend_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuShortcuts_Text
        ///</summary>
        [TestMethod()]
        public void mnuShortcuts_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuShortcuts_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuSetScale_Text
        ///</summary>
        [TestMethod()]
        public void mnuSetScale_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuSetScale_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuScript_Text
        ///</summary>
        [TestMethod()]
        public void mnuScript_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuScript_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuSaveScaleBar_Text
        ///</summary>
        [TestMethod()]
        public void mnuSaveScaleBar_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuSaveScaleBar_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuSaveNorthArrow_Text
        ///</summary>
        [TestMethod()]
        public void mnuSaveNorthArrow_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuSaveNorthArrow_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuSaveMapImage_Text
        ///</summary>
        [TestMethod()]
        public void mnuSaveMapImage_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuSaveMapImage_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuSaveLegend_Text
        ///</summary>
        [TestMethod()]
        public void mnuSaveLegend_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuSaveLegend_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuSaveGeorefMapImage_Text
        ///</summary>
        [TestMethod()]
        public void mnuSaveGeorefMapImage_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuSaveGeorefMapImage_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuSaveAs_Text
        ///</summary>
        [TestMethod()]
        public void mnuSaveAs_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuSaveAs_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuSave_Text
        ///</summary>
        [TestMethod()]
        public void mnuSave_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuSave_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuRestoreMenu_Text
        ///</summary>
        [TestMethod()]
        public void mnuRestoreMenu_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuRestoreMenu_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuRemoveLayer_Text
        ///</summary>
        [TestMethod()]
        public void mnuRemoveLayer_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuRemoveLayer_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuRemoveGroup_Text
        ///</summary>
        [TestMethod()]
        public void mnuRemoveGroup_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuRemoveGroup_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuRecentProjects_Text
        ///</summary>
        [TestMethod()]
        public void mnuRecentProjects_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuRecentProjects_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuProjectSettings_Text
        ///</summary>
        [TestMethod()]
        public void mnuProjectSettings_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuProjectSettings_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuPrint_Text
        ///</summary>
        [TestMethod()]
        public void mnuPrint_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuPrint_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuPreviousZoom_Text
        ///</summary>
        [TestMethod()]
        public void mnuPreviousZoom_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuPreviousZoom_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuPreview_Text
        ///</summary>
        [TestMethod()]
        public void mnuPreview_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuPreview_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuPlugins_Text
        ///</summary>
        [TestMethod()]
        public void mnuPlugins_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuPlugins_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuPanels_Text
        ///</summary>
        [TestMethod()]
        public void mnuPanels_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuPanels_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuOpenProjectIntoGroup_Text
        ///</summary>
        [TestMethod()]
        public void mnuOpenProjectIntoGroup_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuOpenProjectIntoGroup_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuOpen_Text
        ///</summary>
        [TestMethod()]
        public void mnuOpen_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuOpen_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuOnlineDocs_Text
        ///</summary>
        [TestMethod()]
        public void mnuOnlineDocs_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuOnlineDocs_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuOfflineDocs_Text
        ///</summary>
        [TestMethod()]
        public void mnuOfflineDocs_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuOfflineDocs_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuNextZoom_Text
        ///</summary>
        [TestMethod()]
        public void mnuNextZoom_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuNextZoom_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuNew_Text
        ///</summary>
        [TestMethod()]
        public void mnuNew_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuNew_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuHelp_Text
        ///</summary>
        [TestMethod()]
        public void mnuHelp_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuHelp_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuFile_Text
        ///</summary>
        [TestMethod()]
        public void mnuFile_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuFile_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuExport_Text
        ///</summary>
        [TestMethod()]
        public void mnuExport_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuExport_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuExit_Text
        ///</summary>
        [TestMethod()]
        public void mnuExit_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuExit_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuEditPlugins_Text
        ///</summary>
        [TestMethod()]
        public void mnuEditPlugins_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuEditPlugins_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuEdit_Text
        ///</summary>
        [TestMethod()]
        public void mnuEdit_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuEdit_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuCopyScaleBar_Text
        ///</summary>
        [TestMethod()]
        public void mnuCopyScaleBar_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuCopyScaleBar_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuCopyNorthArrow_Text
        ///</summary>
        [TestMethod()]
        public void mnuCopyNorthArrow_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuCopyNorthArrow_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuCopyMap_Text
        ///</summary>
        [TestMethod()]
        public void mnuCopyMap_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuCopyMap_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuCopyLegend_Text
        ///</summary>
        [TestMethod()]
        public void mnuCopyLegend_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuCopyLegend_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuCopy_Text
        ///</summary>
        [TestMethod()]
        public void mnuCopy_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuCopy_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuContents_Text
        ///</summary>
        [TestMethod()]
        public void mnuContents_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuContents_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuClose_Text
        ///</summary>
        [TestMethod()]
        public void mnuClose_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuClose_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuClearSelectedShapes_Text
        ///</summary>
        [TestMethod()]
        public void mnuClearSelectedShapes_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuClearSelectedShapes_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuClearPreview_Text
        ///</summary>
        [TestMethod()]
        public void mnuClearPreview_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuClearPreview_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuClearLayer_Text
        ///</summary>
        [TestMethod()]
        public void mnuClearLayer_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuClearLayer_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuCheckUpdates_Text
        ///</summary>
        [TestMethod()]
        public void mnuCheckUpdates_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuCheckUpdates_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuBookmarkView_Text
        ///</summary>
        [TestMethod()]
        public void mnuBookmarkView_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuBookmarkView_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuBookmarkedViews_Text
        ///</summary>
        [TestMethod()]
        public void mnuBookmarkedViews_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuBookmarkedViews_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuBookmarkDelete_Text
        ///</summary>
        [TestMethod()]
        public void mnuBookmarkDelete_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuBookmarkDelete_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuAddLayer_Text
        ///</summary>
        [TestMethod()]
        public void mnuAddLayer_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuAddLayer_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for mnuAboutMapWindow_Text
        ///</summary>
        [TestMethod()]
        public void mnuAboutMapWindow_TextTest()
        {
            string actual;
            actual = GlobalResource.mnuAboutMapWindow_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LegendName_Text
        ///</summary>
        [TestMethod()]
        public void LegendName_TextTest()
        {
            string actual;
            actual = GlobalResource.LegendName_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DisableDynamicVis_Text
        ///</summary>
        [TestMethod()]
        public void DisableDynamicVis_TextTest()
        {
            string actual;
            actual = GlobalResource.DisableDynamicVis_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CustomProjection_Text
        ///</summary>
        [TestMethod()]
        public void CustomProjection_TextTest()
        {
            string actual;
            actual = GlobalResource.CustomProjection_Text;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Culture
        ///</summary>
        [TestMethod()]
        public void CultureTest()
        {
            CultureInfo expected = null; // TODO: Initialize to an appropriate value
            CultureInfo actual;
            GlobalResource.Culture = expected;
            actual = GlobalResource.Culture;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GlobalResource Constructor
        ///</summary>
        [TestMethod()]
        public void GlobalResourceConstructorTest()
        {
            GlobalResource target = new GlobalResource();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
