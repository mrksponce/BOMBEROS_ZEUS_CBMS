using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
// // using MapWindow.Interfaces;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for ToolbarButtonTest and is intended
    ///to contain all ToolbarButtonTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ToolbarButtonTest
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
        ///A test for Visible
        ///</summary>
        [TestMethod()]
        public void VisibleTest()
        {
            ToolStripButton Button = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton target = new ToolbarButton(Button); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.Visible = expected;
            actual = target.Visible;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Tooltip
        ///</summary>
        [TestMethod()]
        public void TooltipTest()
        {
            ToolStripButton Button = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton target = new ToolbarButton(Button); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Tooltip = expected;
            actual = target.Tooltip;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Text
        ///</summary>
        [TestMethod()]
        public void TextTest()
        {
            ToolStripButton Button = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton target = new ToolbarButton(Button); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Text = expected;
            actual = target.Text;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Pressed
        ///</summary>
        [TestMethod()]
        public void PressedTest()
        {
            ToolStripButton Button = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton target = new ToolbarButton(Button); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.Pressed = expected;
            actual = target.Pressed;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Picture
        ///</summary>
        [TestMethod()]
        public void PictureTest()
        {
            ToolStripButton Button = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton target = new ToolbarButton(Button); // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            target.Picture = expected;
            actual = target.Picture;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for NumSubItems
        ///</summary>
        [TestMethod()]
        public void NumSubItemsTest()
        {
            ToolStripButton Button = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton target = new ToolbarButton(Button); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.NumSubItems;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            ToolStripButton Button = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton target = new ToolbarButton(Button); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Name;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Enabled
        ///</summary>
        [TestMethod()]
        public void EnabledTest()
        {
            ToolStripButton Button = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton target = new ToolbarButton(Button); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.Enabled = expected;
            actual = target.Enabled;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Displayed
        ///</summary>
        [TestMethod()]
        public void DisplayedTest()
        {
            ToolStripButton Button = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton target = new ToolbarButton(Button); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.Displayed = expected;
            actual = target.Displayed;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Description
        ///</summary>
        [TestMethod()]
        public void DescriptionTest()
        {
            ToolStripButton Button = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton target = new ToolbarButton(Button); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Description = expected;
            actual = target.Description;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Cursor
        ///</summary>
        [TestMethod()]
        public void CursorTest()
        {
            ToolStripButton Button = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton target = new ToolbarButton(Button); // TODO: Initialize to an appropriate value
            Cursor expected = null; // TODO: Initialize to an appropriate value
            Cursor actual;
            target.Cursor = expected;
            actual = target.Cursor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Category
        ///</summary>
        [TestMethod()]
        public void CategoryTest()
        {
            ToolStripButton Button = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton target = new ToolbarButton(Button); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Category = expected;
            actual = target.Category;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BeginsGroup
        ///</summary>
        [TestMethod()]
        public void BeginsGroupTest()
        {
            ToolStripButton Button = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton target = new ToolbarButton(Button); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.BeginsGroup = expected;
            actual = target.BeginsGroup;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SubItem
        ///</summary>
        [TestMethod()]
        public void SubItemTest1()
        {
            ToolStripButton Button = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton target = new ToolbarButton(Button); // TODO: Initialize to an appropriate value
            int Index = 0; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton actual;
            actual = target.SubItem(Index);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SubItem
        ///</summary>
        [TestMethod()]
        public void SubItemTest()
        {
            ToolStripButton Button = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton target = new ToolbarButton(Button); // TODO: Initialize to an appropriate value
            string Name = string.Empty; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton expected = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton actual;
            actual = target.SubItem(Name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MapWindow.Interfaces.ToolbarButton Constructor
        ///</summary>
        [TestMethod()]
        public void ToolbarButtonConstructorTest2()
        {
            ToolStripButton Button = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton target = new ToolbarButton(Button);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for MapWindow.Interfaces.ToolbarButton Constructor
        ///</summary>
        [TestMethod()]
        public void ToolbarButtonConstructorTest1()
        {
            ToolStripDropDownButton Button = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton target = new ToolbarButton(Button);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for MapWindow.Interfaces.ToolbarButton Constructor
        ///</summary>
        [TestMethod()]
        public void ToolbarButtonConstructorTest()
        {
            ToolStripItem Button = null; // TODO: Initialize to an appropriate value
            MapWindow.Interfaces.ToolbarButton target = new ToolbarButton(Button);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
