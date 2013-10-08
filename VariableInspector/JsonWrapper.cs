using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoryDumper
{
    [Serializable]
    public class RootObject
    {
        public string Render() { throw new NotImplementedException();}

        public List<Field> FieldList { get; set; }


    }

    public class Field
    {
        public string FieldName { get; set; }
        public Type FieldType { get; set; }
        public Object FieldInstance { get; set; }

        public string Render() { throw new NotImplementedException(); }
        
    }

    class Entity
    {
        public List<Field> FileList { get; set; }
    }
}
