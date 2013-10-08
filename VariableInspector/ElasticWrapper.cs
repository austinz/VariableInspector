using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nest;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;

namespace VariableInspector
{
    class ElasticWrapper
    {
        private static ElasticClient _client;
        private static ElasticWrapper _clientWrapper;
        private string _defaultIndex="varialbeinspector";
        private string index;

        private ElasticWrapper()
        {
            var serverPath = ConfigurationManager.AppSettings["VIServerPath"].DefaultIfNull("127.0.0.1:9200");
            index = ConfigurationManager.AppSettings["VIDefaultIndex"].DefaultIfNull(_defaultIndex);

            var setting = new ConnectionSettings(new Uri(serverPath));
            setting.SetDefaultIndex(index);
            _client = new ElasticClient(setting);
            
        }

        public static ElasticWrapper Instance
        {
            get 
            {
                if (_clientWrapper == null)
                {
                    _clientWrapper = new ElasticWrapper();
                }

                return _clientWrapper;

            }
        }

        public void Index(DumpInformation doc)
        {
            if (!IsIndexExist)
            {
                CreateIndex();
            }

            if (!IsMappingExist)
            {
                CreateMap();
            }
            _client.Index(doc);
        }

        public void CreateIndex()
        {
            _client.CreateIndex(index, new IndexSettings());
        }

        public void CreateMap()
        {
            _client.MapFromAttributes(typeof(DumpInformation));
        }

        public void Remap()
        {
            _client.DeleteMapping<DumpInformation>();
            CreateMap();
        }

        public bool IsMappingExist
        {
            get
            {
                var map = _client.GetMapping<DumpInformation>();
                return !(map == null);
            }
        }

        public bool IsIndexExist
        {
            get
            {
                object result;
                if (!_client.GetIndexSettings().Settings.TryGetValue(index, out result))
                {
                    return false;
                }

                return true;
            }
        }
    }

    [ElasticType]
    class DumpInformation
    {
        [ElasticProperty(Name="name",Type=FieldType.string_type,Analyzer="lowercase")]
        public string Name { get; set; }

        [ElasticProperty(Name = "value", Type = FieldType.string_type,Analyzer="standard")]
        public string Value { get; set; }

        [ElasticProperty(Name = "description", Type = FieldType.string_type,Analyzer="whitespace")]
        public string Description { get; set; }

        [ElasticProperty(Name = "insertTime", Type = FieldType.date_type,Analyzer="keyword")]
        public DateTime InsertTime { get; set; }
    }

    
}
