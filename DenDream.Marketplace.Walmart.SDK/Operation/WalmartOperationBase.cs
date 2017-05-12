using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DenDream.Marketplace.Walmart.SDK.Operation
{
    public abstract class WalmartOperationBase
    {
        public Dictionary<string, object> ParameterDictionary;

        public WalmartOperationBase(string apiKey)
        {
            this.ParameterDictionary = new Dictionary<string, object>();
            ApiKey(apiKey);
        }

        public void ApiKey(string apiKey)
        {
            this.AddOrReplace("apiKey", apiKey);
        }

        protected void AddOrReplace(string param, object value)
        {
            if (this.ParameterDictionary.ContainsKey(param))
            {
                this.ParameterDictionary[param] = value.ToString();
            }
            else
            {
                this.ParameterDictionary.Add(param, value.ToString());
            }
        }

        public string QueryParams
        {
            get
            {
                // Build query params
                string queryString = string.Empty;
                foreach(var key in ParameterDictionary.Keys)
                {
                    queryString += queryString.Length != 0 ? "&" : "";
                    queryString += $"{key}=";
                    if(ParameterDictionary[key] is string)
                    {
                        queryString += WebUtility.UrlEncode(ParameterDictionary[key].ToString());
                    }
                    else
                    {
                        queryString += ParameterDictionary[key];
                    }
                }
                return queryString;
            }
        }

        public abstract string UriTemplate { get; }
    }
}
