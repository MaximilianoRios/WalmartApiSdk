using DenDream.Marketplace.Walmart.SDK.Model;
using DenDream.Marketplace.Walmart.SDK.Operation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DenDream.Marketplace.Walmart.SDK
{
    public partial class WalmartWrapper : IWalmartWrapper
    {
        public event Action<string> XmlReceived;
        public event Action<string> JsonReceived;
        private string _userAgent;

        public event Action<WalmartErrorResponse> ErrorReceived;

        public string ApiKey { get; internal set;  }

        public WalmartWrapper(string apiKey)
        {
            ApiKey = apiKey;
        }

        public void SetUserAgent(string userAgent)
        {
            this._userAgent = userAgent;
        }

        public async Task<WalmartSearchResponse> SearchAsync(string query, int? categoryId = null, WalmartResponseFormat format = WalmartResponseFormat.Xml, bool facet = false, string facetFilter = null, string facetRange = null)
        {
            var operation = this.SearchOperation(query, categoryId, format, facet);

            var webResponse = await this.RequestAsync(operation);
            if(webResponse.StatusCode == HttpStatusCode.OK)
            {
                return XmlHelper.ParseXml<WalmartSearchResponse>(webResponse.Content);
            }
            else
            {
                var errorResponse = XmlHelper.ParseXml<WalmartErrorResponse>(webResponse.Content);
                this.ErrorReceived?.Invoke(errorResponse);
            }
            return null;
        }

        private WalmartSearchOperation SearchOperation(string query, int? categoryId, WalmartResponseFormat format, bool facet)
        {
            var operation = new WalmartSearchOperation(ApiKey);
            operation.Query(query)
                .Facet(facet)
                .Format(format);
            if(categoryId != null)
            {
                operation.Category((int)categoryId);
            }
            return operation;
        }

        public async Task<ExtendedWebResponse> RequestAsync(WalmartOperationBase walmartOperation)
        {
            var uri = WalmartUriBuilder.BuildUri(walmartOperation);
            return await SendRequestAsync(uri);
        }

        private async Task<ExtendedWebResponse> SendRequestAsync(string uri)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.UserAgent = this._userAgent ?? "DenDream.Marketplace.Walmart";

            try
            {
                using (var response = await request.GetResponseAsync())
                {
                    using (var streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        var xml = await streamReader.ReadToEndAsync();
                        this.XmlReceived?.Invoke(xml);

                        return new ExtendedWebResponse(HttpStatusCode.OK, xml);
                    }
                }
            }
            catch (WebException exception)
            {
                if (exception.Response == null)
                {
                    return new ExtendedWebResponse(HttpStatusCode.SeeOther, exception.Message);
                }

                using (var response = (HttpWebResponse)exception.Response)
                {
                    using (var streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        var xml = await streamReader.ReadToEndAsync();
                        this.XmlReceived?.Invoke(xml);

                        return new ExtendedWebResponse(response.StatusCode, xml);
                    }
                }
            }
            catch (Exception exception)
            {
                return new ExtendedWebResponse(HttpStatusCode.SeeOther, exception.Message);
            }
        }
    }
}
