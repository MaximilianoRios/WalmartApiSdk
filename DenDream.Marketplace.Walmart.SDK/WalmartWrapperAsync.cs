using DenDream.Marketplace.Walmart.SDK.Converters;
using DenDream.Marketplace.Walmart.SDK.Exceptions;
using DenDream.Marketplace.Walmart.SDK.Model;
using DenDream.Marketplace.Walmart.SDK.Model.Json;
using DenDream.Marketplace.Walmart.SDK.Model.Xml;
using DenDream.Marketplace.Walmart.SDK.Operation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DenDream.Marketplace.Walmart.SDK.Model.Contract;
using DenDream.Marketplace.Walmart.SDK.Model.Request;

namespace DenDream.Marketplace.Walmart.SDK
{
    public partial class WalmartWrapper : IWalmartWrapper
    {
        private string _userAgent;

        public string ApiKey { get; internal set; }

        public WalmartWrapper(string apiKey)
        {
            ApiKey = apiKey;
        }

        public void SetUserAgent(string userAgent)
        {
            this._userAgent = userAgent;
        }

        public async Task<IWalmartSearchResponse> SearchAsync(SearchParameters searchParameters)
        {
            var operation = this.SearchOperation(searchParameters);
            var converter = ConverterFactory.GetConverter(searchParameters.Format);

            var webResponse = await this.RequestAsync(operation);
            if (webResponse.StatusCode == HttpStatusCode.OK)
            {
                if (searchParameters.Format == ResponseFormat.Xml)
                {
                    return converter.Convert<WalmartXmlSearchResponse>(webResponse.Content) as IWalmartSearchResponse;
                }
                else
                {
                    return converter.Convert<WalmartJsonSearchResponse>(webResponse.Content) as IWalmartSearchResponse;
                }
            }
            var errorResponse = converter.Convert<WalmartErrorResponse>(webResponse.Content);
            throw (new WalmartOperationException("Search operation failed", errorResponse));
        }

        private WalmartSearchOperation SearchOperation(SearchParameters searchParameters)
        {
            var operation = new WalmartSearchOperation(ApiKey);
            operation.Query(searchParameters.Query)
                .Facet(searchParameters.Facets)
                .Format(searchParameters.Format)
                .ResponseGroup(searchParameters.ResponseGroup)
                .Sort(searchParameters.Sort)
                .Order(searchParameters.Order);
            if(searchParameters.FacetFilters != null)
            {
                foreach(var filterKey in searchParameters.FacetFilters.Keys)
                {
                    operation.AddFacetFilter(filterKey, searchParameters.FacetFilters[filterKey]);
                }
            }
            if(searchParameters.FacetRanges != null)
            {
                foreach (var filterKey in searchParameters.FacetRanges.Keys)
                {
                    operation.AddFacetRange(filterKey, searchParameters.FacetRanges[filterKey].RangeFrom, searchParameters.FacetRanges[filterKey].RangeTo);
                }
            }

            if (!string.IsNullOrEmpty(searchParameters.CategoryId))
            {
                operation.Category(searchParameters.CategoryId);
            }
            if(searchParameters.NumItems != null)
            {
                operation.NumItems((int)searchParameters.NumItems);
            }
            if (searchParameters.Start != null)
            {
                operation.Start((int)searchParameters.Start);
            }
            if (!string.IsNullOrEmpty(searchParameters.LinkSharePublisherId))
            {
                operation.LinkSharePublisherId(searchParameters.LinkSharePublisherId);
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
                        var stringResponse = await streamReader.ReadToEndAsync();
                        // this.XmlReceived?.Invoke(stringResponse);

                        return new ExtendedWebResponse(HttpStatusCode.OK, stringResponse);
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
                        var stringResponse = await streamReader.ReadToEndAsync();

                        return new ExtendedWebResponse(response.StatusCode, stringResponse);
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
