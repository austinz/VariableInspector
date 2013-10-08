using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VariableInspector;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = "hello world";
            a.Dump("name:a", "description: this is in Main()");
            Console.Read();
        }
    }
}
