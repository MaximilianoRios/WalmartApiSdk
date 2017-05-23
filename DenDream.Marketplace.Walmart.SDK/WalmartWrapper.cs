using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DenDream.Marketplace.Walmart.SDK.Model;

namespace DenDream.Marketplace.Walmart.SDK
{
    public partial class WalmartWrapper : IWalmartWrapper
    {
        public IWalmartSearchResponse Search(string query, int? categoryId, WalmartResponseFormat format = WalmartResponseFormat.Json, bool facet = false, Dictionary<string, object> facetFilters = null, string[] facetRanges = null)
        {
            return this.SearchAsync(query, categoryId, format, facet, facetFilters, facetRanges).Result;
        }

    }
}
