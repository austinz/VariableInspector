using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace MemoryDumper
{
    public class ReflectionHelper
    {
        public static RootObject Reflect(object obj)
        {
            var rootType = obj.GetType();

            var root = new RootObject();
            root.FieldList = (from info in rootType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                              select new Field { FieldName = info.Name, FieldType = info.FieldType, FieldInstance = info.GetValue(obj) }).ToList();

            return root;

        }
    }
}
