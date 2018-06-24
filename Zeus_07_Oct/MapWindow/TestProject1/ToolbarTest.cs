using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// using MapWindow.Interfaces;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for ToolbarTest and is intended
    ///to contain all ToolbarTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ToolbarTest
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
        ///A test for RemoveToolbar
        ///</summary>
        [TestMethod()]
        public void RemoveToolbarTest()
        {
            MapWindow.Toolbar target = new MapWindow.Toolbar(); // TODO: Initialize to an appropriate value
            string Name = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.RemoveToolbar(Name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RemoveComboBox
        ///</summary>
        [TestMethod()]
        public void RemoveComboBoxTest()
        {
            Toolbar target = new Toolbar(); // TODO: Initialize to an appropriate value
            string Name = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.RemoveComboBox(Name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RemoveButton
        ///</summary>
        [TestMethod()]
        public void RemoveButtonTest()
        {
            Toolbar target = new Toolbar(); // TODO: Initialize to an appropriate value
            string Name = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.RemoveButton(Name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PressToolbarButton
        ///</summary>
        [TestMethod()]
        public void PressToolbarButtonTest()
        {
            Toolbar target = new Toolbar(); // TODO: Initialize to an appropriate value
            string Name = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.PressToolbarButton(Name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for NumButtons
        ///</summary>
        [TestMethod()]
        public void NumToolbarButtonsTest()
        {
            MapWindow.Toolbar target = new MapWindow.Toolbar(); // TODO: Initialize to an appropriate value
            string ToolbarName = string.Empty; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.NumButtons(ToolbarName);
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
            Toolbar_Accessor target = new Toolbar_Accessor(); // TODO: Initialize to an appropriate value
            target.Finalize();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DropDownButtonItem
        ///</summary>
        [TestMethod()]
        public void DropDownButtonItemTest()
        {
            MapWindow.Toolbar target = new MapWindow.Toolbar(); // TODO: Initialize to an appropriate value
            string Name = string.Empty; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton actual;
            actual = target.DropDownButtonItem(Name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Contains
        ///</summary>
        [TestMethod()]
        public void ContainsTest()
        {
            Toolbar target = new Toolbar(); // TODO: Initialize to an appropriate value
            object key = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Contains(key);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ComboBoxItem
        ///</summary>
        [TestMethod()]
        public void ComboBoxItemTest()
        {
            Toolbar target = new Toolbar(); // TODO: Initialize to an appropriate value
            string Name = string.Empty; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ComboBoxItem expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ComboBoxItem actual;
            actual = target.ComboBoxItem(Name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ButtonItem
        ///</summary>
        [TestMethod()]
        public void ButtonItemTest()
        {
            Toolbar target = new Toolbar(); // TODO: Initialize to an appropriate value
            string Name = string.Empty; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton actual;
            actual = target.ButtonItem(Name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddToolbar
        ///</summary>
        [TestMethod()]
        public void AddToolbarTest()
        {
            Toolbar target = new Toolbar(); // TODO: Initialize to an appropriate value
            string Name = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.AddToolbar(Name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddComboBox
        ///</summary>
        [TestMethod()]
        public void AddComboBoxTest()
        {
            Toolbar target = new Toolbar(); // TODO: Initialize to an appropriate value
            string Name = string.Empty; // TODO: Initialize to an appropriate value
            string Toolbar = string.Empty; // TODO: Initialize to an appropriate value
            string After = string.Empty; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ComboBoxItem expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ComboBoxItem actual;
            actual = target.AddComboBox(Name, Toolbar, After);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddButtonDropDownSeparator
        ///</summary>
        [TestMethod()]
        public void AddButtonDropDownSeparatorTest()
        {
            Toolbar target = new Toolbar(); // TODO: Initialize to an appropriate value
            string Name = string.Empty; // TODO: Initialize to an appropriate value
            string Toolbar = string.Empty; // TODO: Initialize to an appropriate value
            string ParentButton = string.Empty; // TODO: Initialize to an appropriate value
            target.AddButtonDropDownSeparator(Name, Toolbar, ParentButton);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddButton
        ///</summary>
        [TestMethod()]
        public void AddButtonTest5()
        {
            Toolbar target = new Toolbar(); // TODO: Initialize to an appropriate value
            string Name = string.Empty; // TODO: Initialize to an appropriate value
            object Picture = null; // TODO: Initialize to an appropriate value
            string Text = string.Empty; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton actual;
            actual = target.AddButton(Name, Picture, Text);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddButton
        ///</summary>
        [TestMethod()]
        public void AddButtonTest4()
        {
            Toolbar target = new Toolbar(); // TODO: Initialize to an appropriate value
            string Name = string.Empty; // TODO: Initialize to an appropriate value
            string Toolbar = string.Empty; // TODO: Initialize to an appropriate value
            string ParentButton = string.Empty; // TODO: Initialize to an appropriate value
            string After = string.Empty; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton actual;
            actual = target.AddButton(Name, Toolbar, ParentButton, After);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddButton
        ///</summary>
        [TestMethod()]
        public void AddButtonTest3()
        {
            Toolbar target = new Toolbar(); // TODO: Initialize to an appropriate value
            string Name = string.Empty; // TODO: Initialize to an appropriate value
            bool IsDropDown = false; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton actual;
            actual = target.AddButton(Name, IsDropDown);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddButton
        ///</summary>
        [TestMethod()]
        public void AddButtonTest2()
        {
            Toolbar target = new Toolbar(); // TODO: Initialize to an appropriate value
            string Name = string.Empty; // TODO: Initialize to an appropriate value
            string Toolbar = string.Empty; // TODO: Initialize to an appropriate value
            bool IsDropDown = false; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton actual;
            actual = target.AddButton(Name, Toolbar, IsDropDown);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddButton
        ///</summary>
        [TestMethod()]
        public void AddButtonTest1()
        {
            Toolbar target = new Toolbar(); // TODO: Initialize to an appropriate value
            string Name = string.Empty; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton actual;
            actual = target.AddButton(Name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddButton
        ///</summary>
        [TestMethod()]
        public void AddButtonTest()
        {
            Toolbar target = new Toolbar(); // TODO: Initialize to an appropriate value
            string Name = string.Empty; // TODO: Initialize to an appropriate value
            object Picture = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton actual;
            actual = target.AddButton(Name, Picture);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Toolbar Constructor
        ///</summary>
        [TestMethod()]
        public void ToolbarConstructorTest()
        {
            Toolbar target = new Toolbar();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
