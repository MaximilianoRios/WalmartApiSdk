using DenDream.Marketplace.Walmart.SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenDream.Marketplace.Walmart.SDK.Converters
{
    public class ConverterFactory
    {
        public static IConverter GetConverter(WalmartResponseFormat format)
        {
            if(format == WalmartResponseFormat.Json)
            {
                return new JsonConverter();
            }
            return new XmlConverter();
        }
    }
}
