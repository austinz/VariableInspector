using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Web.Script.Serialization;
using System.Diagnostics;
using System.Threading;


namespace VariableInspector
{
    public static class Extensions
    {
        public static IEnumerable<T> Dump<T>(this IEnumerable<T> list, string name, string description)
        {
            string result = string.Empty;
            if (list == null)
            {
                result = Statics.NullValue;
                return list;

            }

            result = String.Join(",", list.ToArray());

            Save(name, description, result);

            return list;
        }

        public static IDictionary<T, K> Dump<T, K>(this IDictionary<T, K> dict, string name, string description)
        {
            if (dict == null)
            {
                Save(name, description, Statics.NullValue);
                return dict;
            }

            var query = from item in dict
                        select item.Key + ":" + item.Value;
            var result = String.Join(",", query.ToArray());

            Save(name, description, result);

            return dict;

        }

        public static Nullable<T> Dump<T>(this Nullable<T> nullable, string name, string description)
            where T : struct
        {
            string result;

            if (!nullable.HasValue)
            {
                result = Statics.NullValue;
            }
            else
            {
                result = nullable.Value.ToString();
            }

            Save(name, description, result);

            return nullable;
        }

        public static String Dump(this String str, string name, string description)
        {
            string result = string.Empty;
            if (str == null)
            {
                result = Statics.NullValue;
            }
            if (str != null && str.Length == 0)
            {
                result = Statics.Empty;
            }
            if (str != null && str.Length > 0 && string.IsNullOrWhiteSpace(str))
            {
                result = Statics.WhiteSpace;

            }

            Save(name, description, result);
            return str;
        }

        public static int Dump(this int integer, string name, string description)
        {
            Save(name, description, integer.ToString());
            return integer;
        }

        public static decimal Dump(this decimal decimalValue, string name, string description)
        {
            Save(name, description, decimalValue.ToString());
            return decimalValue;
        }

        public static long Dump(this long longValue, string name, string description)
        {
            Save(name, description, longValue.ToString());
            return longValue;
        }

        public static object Dump(this object obj, string name, string description)
        {
            if (obj == null)
            {
                Save(name, description, Statics.NullValue);
                return obj;
            }
            Save(name, description, new JavaScriptSerializer().Serialize(obj));
            return obj;
        }

        public static string DefaultIfNull(this string x, string defaultValue)
        {
            if (x == null)
            {
                return defaultValue;
            }

            return x;
        }

        private static void Save(string name, string description, string result)
        {

            var dumpInfo = new DumpInformation { Name = name, Description = description, InsertTime = DateTime.Now, Value = result };
            ThreadPool.QueueUserWorkItem(_ =>
            {
                try
                {
                    ElasticWrapper.Instance.Index(dumpInfo);
                }
                catch (Exception ex)
                {
                    Log(ex.Message);
                }
            });



        }

        private static void Log(string sEvent)
        {
            var sSource = "Variable Inspector";
            var sLog = "Application";
            if (!EventLog.SourceExists(sSource))
            {
                EventLog.CreateEventSource(sSource, sLog);
            }
            EventLog.WriteEntry(sSource, sEvent, EventLogEntryType.Error);
        }



    }
}
