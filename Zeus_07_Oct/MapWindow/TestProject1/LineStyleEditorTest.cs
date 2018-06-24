using MapWindow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;
using System;
using System.Drawing.Design;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for LineStyleEditorTest and is intended
    ///to contain all LineStyleEditorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LineStyleEditorTest
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
        ///A test for PaintValue
        ///</summary>
        [TestMethod()]
        public void PaintValueTest()
        {
            LineStyleEditor target = new LineStyleEditor(); // TODO: Initialize to an appropriate value
            PaintValueEventArgs e = null; // TODO: Initialize to an appropriate value
            target.PaintValue(e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetPaintValueSupported
        ///</summary>
        [TestMethod()]
        public void GetPaintValueSupportedTest()
        {
            LineStyleEditor target = new LineStyleEditor(); // TODO: Initialize to an appropriate value
            ITypeDescriptorContext context = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.GetPaintValueSupported(context);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetEditStyle
        ///</summary>
        [TestMethod()]
        public void GetEditStyleTest()
        {
            LineStyleEditor target = new LineStyleEditor(); // TODO: Initialize to an appropriate value
            ITypeDescriptorContext context = null; // TODO: Initialize to an appropriate value
            UITypeEditorEditStyle expected = new UITypeEditorEditStyle(); // TODO: Initialize to an appropriate value
            UITypeEditorEditStyle actual;
            actual = target.GetEditStyle(context);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EditValue
        ///</summary>
        [TestMethod()]
        public void EditValueTest()
        {
            LineStyleEditor target = new LineStyleEditor(); // TODO: Initialize to an appropriate value
            ITypeDescriptorContext context = null; // TODO: Initialize to an appropriate value
            IServiceProvider provider = null; // TODO: Initialize to an appropriate value
            object value = null; // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            actual = target.EditValue(context, provider, value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LineStyleEditor Constructor
        ///</summary>
        [TestMethod()]
        public void LineStyleEditorConstructorTest()
        {
            LineStyleEditor target = new LineStyleEditor();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
