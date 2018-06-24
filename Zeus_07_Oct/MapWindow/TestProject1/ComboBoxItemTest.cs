using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
// using MapWindow.Interfaces;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for ComboBoxItemTest and is intended
    ///to contain all ComboBoxItemTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ComboBoxItemTest
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
        ///A test for Width
        ///</summary>
        [TestMethod()]
        public void WidthTest()
        {
            ToolStripComboBox ComboBox = null; // TODO: Initialize to an appropriate value
            ComboBoxItem target = new ComboBoxItem(ComboBox); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.Width = expected;
            actual = target.Width;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Tooltip
        ///</summary>
        [TestMethod()]
        public void TooltipTest()
        {
            ToolStripComboBox ComboBox = null; // TODO: Initialize to an appropriate value
            ComboBoxItem target = new ComboBoxItem(ComboBox); // TODO: Initialize to an appropriate value
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
            ToolStripComboBox ComboBox = null; // TODO: Initialize to an appropriate value
            ComboBoxItem target = new ComboBoxItem(ComboBox); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Text = expected;
            actual = target.Text;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SelectionStart
        ///</summary>
        [TestMethod()]
        public void SelectionStartTest()
        {
            ToolStripComboBox ComboBox = null; // TODO: Initialize to an appropriate value
            ComboBoxItem target = new ComboBoxItem(ComboBox); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.SelectionStart = expected;
            actual = target.SelectionStart;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SelectionLength
        ///</summary>
        [TestMethod()]
        public void SelectionLengthTest()
        {
            ToolStripComboBox ComboBox = null; // TODO: Initialize to an appropriate value
            ComboBoxItem target = new ComboBoxItem(ComboBox); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.SelectionLength = expected;
            actual = target.SelectionLength;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SelectedText
        ///</summary>
        [TestMethod()]
        public void SelectedTextTest()
        {
            ToolStripComboBox ComboBox = null; // TODO: Initialize to an appropriate value
            ComboBoxItem target = new ComboBoxItem(ComboBox); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.SelectedText = expected;
            actual = target.SelectedText;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SelectedItem
        ///</summary>
        [TestMethod()]
        public void SelectedItemTest()
        {
            ToolStripComboBox ComboBox = null; // TODO: Initialize to an appropriate value
            ComboBoxItem target = new ComboBoxItem(ComboBox); // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            target.SelectedItem = expected;
            actual = target.SelectedItem;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SelectedIndex
        ///</summary>
        [TestMethod()]
        public void SelectedIndexTest()
        {
            ToolStripComboBox ComboBox = null; // TODO: Initialize to an appropriate value
            ComboBoxItem target = new ComboBoxItem(ComboBox); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.SelectedIndex = expected;
            actual = target.SelectedIndex;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            ToolStripComboBox ComboBox = null; // TODO: Initialize to an appropriate value
            ComboBoxItem target = new ComboBoxItem(ComboBox); // TODO: Initialize to an appropriate value
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
            ToolStripComboBox ComboBox = null; // TODO: Initialize to an appropriate value
            ComboBoxItem target = new ComboBoxItem(ComboBox); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.Enabled = expected;
            actual = target.Enabled;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DropDownStyle
        ///</summary>
        [TestMethod()]
        public void DropDownStyleTest()
        {
            ToolStripComboBox ComboBox = null; // TODO: Initialize to an appropriate value
            ComboBoxItem target = new ComboBoxItem(ComboBox); // TODO: Initialize to an appropriate value
            ComboBoxStyle expected = new ComboBoxStyle(); // TODO: Initialize to an appropriate value
            ComboBoxStyle actual;
            target.DropDownStyle = expected;
            actual = target.DropDownStyle;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Description
        ///</summary>
        [TestMethod()]
        public void DescriptionTest()
        {
            ToolStripComboBox ComboBox = null; // TODO: Initialize to an appropriate value
            ComboBoxItem target = new ComboBoxItem(ComboBox); // TODO: Initialize to an appropriate value
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
            ToolStripComboBox ComboBox = null; // TODO: Initialize to an appropriate value
            ComboBoxItem target = new ComboBoxItem(ComboBox); // TODO: Initialize to an appropriate value
            Cursor expected = null; // TODO: Initialize to an appropriate value
            Cursor actual;
            target.Cursor = expected;
            actual = target.Cursor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Items
        ///</summary>
        [TestMethod()]
        public void ItemsTest()
        {
            ToolStripComboBox ComboBox = null; // TODO: Initialize to an appropriate value
            ComboBoxItem target = new ComboBoxItem(ComboBox); // TODO: Initialize to an appropriate value
            ComboBox.ObjectCollection expected = null; // TODO: Initialize to an appropriate value
            ComboBox.ObjectCollection actual;
            actual = target.Items();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ComboBoxItem Constructor
        ///</summary>
        [TestMethod()]
        public void ComboBoxItemConstructorTest()
        {
            ToolStripComboBox ComboBox = null; // TODO: Initialize to an appropriate value
            ComboBoxItem target = new ComboBoxItem(ComboBox);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
