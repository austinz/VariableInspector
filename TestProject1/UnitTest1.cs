using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var dict = new Dictionary<string,string>();
            var type = dict.GetType();

            var genericArguments = type.GetGenericArguments();

            if (type.IsGenericType)
            {
                string genericName = type.GetGenericTypeDefinition().Name;

                if (genericName.ToLower().StartsWith("dictionary"))
                {
 
                }
            }

            Debug.WriteLine(type.IsAssignableFrom(typeof(Dictionary<,>).GetGenericTypeDefinition()));
            Assert.IsNotNull(type);
        }
    }
}
