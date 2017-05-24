using DenDream.Marketplace.Walmart.SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DenDream.Marketplace.Walmart.SDK.Model.Contract;


namespace DenDream.Marketplace.Walmart.SDK
{
    public interface IWalmartWrapper
    {
        /// <summary>
        /// Allows text search on the Walmart.com catalogue and returns matching items available for sale online
        /// </summary>
        /// <param name="query">Search text - whitespace separated sequence of keywords to search for</param>
        /// <param name="format">Format of the output in either JSON or XML</param>
        /// <param name="categoryId">Category id of the category for search within a category. This should match the id field from Taxonomy API</param>
        /// <param name="facet">Parameter to enable facets.</param>
        /// <param name="facetFilter">Filter to apply on the facet attribute values to narrow down the search.</param>
        /// <param name="facetRange">Range filter for facets which take range values, like price.</param>
        /// <returns></returns>
        IWalmartSearchResponse Search(string query, int? categoryId, WalmartResponseFormat format = WalmartResponseFormat.Json, bool facet = false, Dictionary<string, object> facetFilters = null, string[] facetRanges = null);
        Task<IWalmartSearchResponse> SearchAsync(string query, int? categoryId, WalmartResponseFormat format = WalmartResponseFormat.Json, bool facet = false, Dictionary<string, object> facetFilters = null, string[] facetRanges = null);


    }
}
