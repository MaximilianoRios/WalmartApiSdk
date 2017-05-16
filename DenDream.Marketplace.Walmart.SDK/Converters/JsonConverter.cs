using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenDream.Marketplace.Walmart.SDK.Converters
{
    public class JsonConverter : IConverter
    {
        public T Convert<T>(string sourceString)
        {
            try
            {
                var jsonObject = JsonConvert.DeserializeObject<T>(sourceString);
                return jsonObject;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    }
}
