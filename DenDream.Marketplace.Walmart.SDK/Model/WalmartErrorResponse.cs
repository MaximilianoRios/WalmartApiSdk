using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DenDream.Marketplace.Walmart.SDK.Model
{
    [XmlRoot("errors")]
    public class WalmartErrorResponse
    {
        [XmlElement("error")]
        public List<WalmartError> Errors { get; set; }
    }

    public class WalmartError
    {
        [XmlElement("code")]
        public int Code { get; set; }

        [XmlElement("message")]
        public string Message { get; set; }
    }

}
