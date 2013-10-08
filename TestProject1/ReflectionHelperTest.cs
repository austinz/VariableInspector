using MemoryDumper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;


namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for ReflectionHelperTest and is intended
    ///to contain all ReflectionHelperTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ReflectionHelperTest
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
        ///A test for Reflect
        ///</summary>
        [TestMethod()]
        public void ReflectTest()
        {
            var obj = new A();
            
            var actual = ReflectionHelper.Reflect(obj);

            var json = new JavaScriptSerializer().Serialize(obj);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }

    class A
    {
        private B _inner = new B { Name = "foo", Age = 20 };

        private List<String> _documents = new List<string>() { "this", "is", "test" };
    }

    class B
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
