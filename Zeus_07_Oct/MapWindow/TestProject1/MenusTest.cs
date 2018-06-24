using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// // using MapWindow.Interfaces;
using System.Windows.Forms;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for MenusTest and is intended
    ///to contain all MenusTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MenusTest
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
        ///A test for Item
        ///</summary>
        [TestMethod()]
        public void ItemTest()
        {
            MapWindow.Menus target = new MapWindow.Menus(); // TODO: Initialize to an appropriate value
            string MenuName = string.Empty; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.MenuItem actual;
            actual = target[MenuName];
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RemoveSubMenusFromMenuTable
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void RemoveSubMenusFromMenuTableTest()
        {
            Menus_Accessor target = new Menus_Accessor(); // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem ParentToolStripMenuItem = null; // TODO: Initialize to an appropriate value
            target.RemoveSubMenusFromMenuTable(ParentToolStripMenuItem);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Remove
        ///</summary>
        [TestMethod()]
        public void RemoveTest()
        {
            MapWindow.Interfaces.Menus target = new Menus(); // TODO: Initialize to an appropriate value
            string Name = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Remove(Name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MenuTrackerRemoveIfLastOwner
        ///</summary>
        [TestMethod()]
        public void MenuTrackerRemoveIfLastOwnerTest()
        {
            MapWindow.Menus target = new Menus(); // TODO: Initialize to an appropriate value
            string plugin = string.Empty; // TODO: Initialize to an appropriate value
            target.MenuTrackerRemoveIfLastOwner(plugin);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MenuTrackerRemove
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void MenuTrackerRemoveTest()
        {
            Menus_Accessor target = new Menus_Accessor(); // TODO: Initialize to an appropriate value
            string item = string.Empty; // TODO: Initialize to an appropriate value
            string Plugin = string.Empty; // TODO: Initialize to an appropriate value
            target.MenuTrackerRemove(item, Plugin);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MenuTrackerAdd
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void MenuTrackerAddTest()
        {
            Menus_Accessor target = new Menus_Accessor(); // TODO: Initialize to an appropriate value
            string item = string.Empty; // TODO: Initialize to an appropriate value
            string Plugin = string.Empty; // TODO: Initialize to an appropriate value
            target.MenuTrackerAdd(item, Plugin);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MenuTableKey
        ///</summary>
        [TestMethod()]
        public void MenuTableKeyTest()
        {
            MapWindow.Menus target = new Menus(); // TODO: Initialize to an appropriate value
            string Name = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.MenuTableKey(Name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MenuTableItem
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void MenuTableItemTest()
        {
            Menus_Accessor target = new Menus_Accessor(); // TODO: Initialize to an appropriate value
            string Name = string.Empty; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem expected = null; // TODO: Initialize to an appropriate value
            System.Windows.Forms.ToolStripMenuItem actual;
            actual = target.MenuTableItem(Name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MenuTableAdd
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void MenuTableAddTest()
        {
            Menus_Accessor target = new Menus_Accessor(); // TODO: Initialize to an appropriate value
            string Name = string.Empty; // TODO: Initialize to an appropriate value
            ToolStripItem NewMenu = null; // TODO: Initialize to an appropriate value
            target.MenuTableAdd(Name, NewMenu);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for FindPluginKey
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MapWindow.exe")]
        public void FindPluginKeyTest()
        {
            Menus_Accessor target = new Menus_Accessor(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.FindPluginKey();
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
            Menus_Accessor target = new Menus_Accessor(); // TODO: Initialize to an appropriate value
            target.Finalize();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for EnsureHelpItemLast
        ///</summary>
        [TestMethod()]
        public void EnsureHelpItemLastTest()
        {
            MapWindow.Menus target = new Menus(); // TODO: Initialize to an appropriate value
            target.EnsureHelpItemLast();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Contains
        ///</summary>
        [TestMethod()]
        public void ContainsTest()
        {
            MapWindow.Menus target = new Menus(); // TODO: Initialize to an appropriate value
            object key = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Contains(key);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddMenu
        ///</summary>
        [TestMethod()]
        public void AddMenuTest8()
        {
            MapWindow.Interfaces.Menus target = new Menus(); // TODO: Initialize to an appropriate value
            string Name = string.Empty; // TODO: Initialize to an appropriate value
            string ParentMenu = string.Empty; // TODO: Initialize to an appropriate value
            object Picture = null; // TODO: Initialize to an appropriate value
            string Text = string.Empty; // TODO: Initialize to an appropriate value
            string After = string.Empty; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.MenuItem expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.MenuItem actual;
            actual = target.AddMenu(Name, ParentMenu, Picture, Text, After);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddMenu
        ///</summary>
        [TestMethod()]
        public void AddMenuTest7()
        {
            MapWindow.Interfaces.Menus target = new Menus(); // TODO: Initialize to an appropriate value
            string Name = string.Empty; // TODO: Initialize to an appropriate value
            string ParentMenu = string.Empty; // TODO: Initialize to an appropriate value
            string Text = string.Empty; // TODO: Initialize to an appropriate value
            string Before = string.Empty; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.MenuItem expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.MenuItem actual;
            actual = target.AddMenu(Name, ParentMenu, Text, Before);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddMenu
        ///</summary>
        [TestMethod()]
        public void AddMenuTest6()
        {
            MapWindow.Interfaces.Menus target = new Menus(); // TODO: Initialize to an appropriate value
            string Name = string.Empty; // TODO: Initialize to an appropriate value
            object Picture = null; // TODO: Initialize to an appropriate value
            string Text = string.Empty; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.MenuItem expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.MenuItem actual;
            actual = target.AddMenu(Name, Picture, Text);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddMenu
        ///</summary>
        [TestMethod()]
        public void AddMenuTest5()
        {
            MapWindow.Menus target = new Menus(); // TODO: Initialize to an appropriate value
            string MenuName = string.Empty; // TODO: Initialize to an appropriate value
            string ParentMenu = string.Empty; // TODO: Initialize to an appropriate value
            object Picture = null; // TODO: Initialize to an appropriate value
            string Text = string.Empty; // TODO: Initialize to an appropriate value
            string After = string.Empty; // TODO: Initialize to an appropriate value
            string Before = string.Empty; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.MenuItem expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.MenuItem actual;
            actual = target.AddMenu(MenuName, ParentMenu, Picture, Text, After, Before);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddMenu
        ///</summary>
        [TestMethod()]
        public void AddMenuTest4()
        {
            MapWindow.Interfaces.Menus target = new Menus(); // TODO: Initialize to an appropriate value
            string Name = string.Empty; // TODO: Initialize to an appropriate value
            string ParentMenu = string.Empty; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.MenuItem expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.MenuItem actual;
            actual = target.AddMenu(Name, ParentMenu);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddMenu
        ///</summary>
        [TestMethod()]
        public void AddMenuTest3()
        {
            MapWindow.Interfaces.Menus target = new Menus(); // TODO: Initialize to an appropriate value
            string Name = string.Empty; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.MenuItem expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.MenuItem actual;
            actual = target.AddMenu(Name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddMenu
        ///</summary>
        [TestMethod()]
        public void AddMenuTest2()
        {
            MapWindow.Interfaces.Menus target = new Menus(); // TODO: Initialize to an appropriate value
            string Name = string.Empty; // TODO: Initialize to an appropriate value
            object Picture = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.MenuItem expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.MenuItem actual;
            actual = target.AddMenu(Name, Picture);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddMenu
        ///</summary>
        [TestMethod()]
        public void AddMenuTest1()
        {
            MapWindow.Interfaces.Menus target = new Menus(); // TODO: Initialize to an appropriate value
            string Name = string.Empty; // TODO: Initialize to an appropriate value
            string ParentMenu = string.Empty; // TODO: Initialize to an appropriate value
            object Picture = null; // TODO: Initialize to an appropriate value
            string Text = string.Empty; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.MenuItem expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.MenuItem actual;
            actual = target.AddMenu(Name, ParentMenu, Picture, Text);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddMenu
        ///</summary>
        [TestMethod()]
        public void AddMenuTest()
        {
            MapWindow.Interfaces.Menus target = new Menus(); // TODO: Initialize to an appropriate value
            string Name = string.Empty; // TODO: Initialize to an appropriate value
            string ParentMenu = string.Empty; // TODO: Initialize to an appropriate value
            object Picture = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.MenuItem expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.MenuItem actual;
            actual = target.AddMenu(Name, ParentMenu, Picture);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MapWindow.Interfaces.Menus Constructor
        ///</summary>
        [TestMethod()]
        public void MenusConstructorTest()
        {
            MapWindow.Interfaces.Menus target = new Menus();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
