using VariableInspector;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for ExtensionsTest and is intended
    ///to contain all ExtensionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ExtensionsTest
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
        ///A test for Dump
        ///</summary>
        public void DumpTestHelper<T>()
        {
            IEnumerable<T> list = null; // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            string description = string.Empty; // TODO: Initialize to an appropriate value
            IEnumerable<T> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<T> actual;
            actual = Extensions.Dump<T>(list, name, description);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void IntDumpTest()
       { 
            IEnumerable<int> listA = new List<int>() { 1, 7, 6, 49 };
            var listB = listA.Dump<int>("test", "this is the first dump");
            Assert.IsNotNull(listB);
        }

        /// <summary>
        ///A test for Dump
        ///</summary>
        [TestMethod()]
        public void ObjectDumpTest()
        {
            var obj = new D();
            obj.Dump("object dump","object dump test");

            Assert.IsNotNull(obj);
            
        }
    }

    class C
    {
        private string _name = "i'm C";

    }

    class D
    {
        private C _inner = new C();

        private string _name = "i'm D";
    }
}
