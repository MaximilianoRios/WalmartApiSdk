using DenDream.Marketplace.Walmart.SDK.Model.Contract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenDream.Marketplace.Walmart.SDK.Model.Json
{
    public class JsonFacet : IFacet
    {
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("properties")]
        public JsonFacetProperty JsonProperties { get; set; }

        public IFacetProperty Properties
        {
            get
            {
                return JsonProperties;
            }
            set { }
        }

        [JsonProperty("facetValues")]
        public List<JsonFacetValue> JsonValues { get; set; }

        public IEnumerable<IFacetValue> Values
        {
            get
            {
                return JsonValues;
            }
            set { }
        }
    }

    public class JsonFacetProperty : IFacetProperty
    {
        [JsonProperty("multi")]
        public string Multi { get; set; }

        [JsonProperty("nullCount")]
        public string NullCount { get; set; }
    }

    public class JsonFacetValue : IFacetValue
    {
        [JsonProperty("count")]
        public int Count { get; set;  }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
