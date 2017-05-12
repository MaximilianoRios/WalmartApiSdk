using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DenDream.Marketplace.Walmart.SDK.Model
{
    [XmlRoot("searchresponse")]
    public class WalmartSearchResponse
    {
        [XmlElement("query")]
        public string Query { get; set; }
        [XmlElement("sort")]
        public string Sort { get; set; }
        [XmlElement("responseGroup")]
        public string ResponseGroup { get; set; }
        [XmlElement("totalResults")]
        public int TotalResults { get; set; }
        [XmlElement("start")]
        public int Start { get; set; }
        [XmlElement("numItems")]
        public int NumItems { get; set; }

    }
}
