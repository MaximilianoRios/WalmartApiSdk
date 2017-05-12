using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DenDream.Marketplace.Walmart.SDK
{
    public static class XmlHelper
    {
        public class NamespaceIgnorantXmlTextReader : XmlTextReader
        {
            public NamespaceIgnorantXmlTextReader(TextReader reader) : base(reader) { }

            public override string NamespaceURI
            {
                get { return String.Empty; }
            }
        }

        public static T ParseXml<T>(string xml)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                using (var reader = new StringReader(xml))
                {
                    using (var xmlTextReader = new NamespaceIgnorantXmlTextReader(reader))
                    {
                        return (T)(serializer.Deserialize(xmlTextReader));
                    }
                }
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    }
}
