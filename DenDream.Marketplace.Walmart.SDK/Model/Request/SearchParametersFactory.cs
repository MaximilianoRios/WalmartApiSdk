using DenDream.Marketplace.Walmart.SDK.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenDream.Marketplace.Walmart.SDK.Model.Request
{
    /// <summary>
    /// Builds a search parameters object validating the input and reinforcing default values
    /// </summary>
    public class SearchParametersFactory
    {
        public const SortCriteria DefaultSortCriteria = SortCriteria.Relevance;
        public const SortOrder DefaultSortOrder = SortOrder.Asc;
        public const ResponseFormat DefaultResponseFormat = ResponseFormat.Json;
        public const ResponseGroup DefaultResponseGroup = ResponseGroup.Base;

        public SearchParameters Get(string query, string categoryId = null, int? numItems = null, int? start = null, bool facets = false, Dictionary<string, object> facetFilters = null, Dictionary<string, FacetRangeValues> facetRanges = null, SortCriteria sortCriteria = DefaultSortCriteria, SortOrder sortOrder = DefaultSortOrder, ResponseFormat format = DefaultResponseFormat, ResponseGroup group = DefaultResponseGroup)
        {
            if (start != null)
            {
                if ((int)start <= 0)
                {
                    throw new InvalidSearchParameterException("Start must be greater than one");
                }
            }

            if (numItems != null)
            {
                if ((int)numItems <= 1  || (int)numItems > 25)
                {
                    throw new InvalidSearchParameterException("Num items must be a number in between 1 and 25");
                }
            }

            var searchParameters = new SearchParameters()
            {
                Query = query,
                Sort = sortCriteria,
                Order = sortOrder,
                Format = DefaultResponseFormat,
                ResponseGroup = DefaultResponseGroup,
                Start = start,
                NumItems = numItems
            };

            return searchParameters;
        }

    }
}
