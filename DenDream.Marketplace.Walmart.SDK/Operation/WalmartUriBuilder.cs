using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenDream.Marketplace.Walmart.SDK.Operation
{
    /// <summary>
    /// Build Walmart Api urls
    /// </summary>
    public class WalmartUriBuilder
    {
        private static string rootUrl = "http://api.walmartlabs.com";

        public static string BuildUri(WalmartOperationBase walmartOperation)
        {
            var template = walmartOperation.UriTemplate;
            var queryParams = walmartOperation.QueryParams;
            string uri = $"{rootUrl}/{template}?{queryParams}";
            return uri;
        }
    }
}
