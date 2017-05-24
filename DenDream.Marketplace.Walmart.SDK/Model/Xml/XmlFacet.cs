using DenDream.Marketplace.Walmart.SDK.Model.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DenDream.Marketplace.Walmart.SDK.Model.Xml
{
    public class XmlFacets
    {
        [XmlElement("facets")]
        public List<XmlFacet> Facets { get; set; }
    }

    public class XmlFacet : IFacet
    {
        [XmlElement("displayName")]
        public string DisplayName { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("properties")]
        public XmlFacetProperty XmlProperties { get; set; }

        [XmlIgnore]
        public IFacetProperty Properties
        {
            get
            {
                return XmlProperties;
            }
            set { }
        }

        [XmlElement("facetValues")]
        public XmlFacetValues XmlFacetValues { get; set; }

        [XmlIgnore]
        public IEnumerable<IFacetValue> Values
        {
            get
            {
                if (XmlFacetValues != null)
                {
                    return XmlFacetValues.FacetValues;
                }
                return null;
            }
            set { }
        }
    }

    public class XmlFacetProperty : IFacetProperty
    {
        [XmlElement("multi")]
        public string Multi { get; set; }

        [XmlElement("nullCount")]
        public string NullCount { get; set; }
    }

    public class XmlFacetValues
    {
        [XmlElement("facetValues")]
        public List<XmlFacetValue> FacetValues { get; set; }
    }

    public class XmlFacetValue : IFacetValue
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }
    }
}
