using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenDream.Marketplace.Walmart.SDK.Model.Request
{
    /// <summary>
    /// Entire set of parameters allowed by the API search endpoint
    /// </summary>
    public class SearchParameters
    {
        public string LinkSharePublisherId { get; set; }
        public string Query { get; set; }
        public string CategoryId { get; set; }
        public int? Start { get; set; }
        public SortCriteria Sort { get; set; }
        public SortOrder Order { get; set; }
        public int? NumItems { get; set; }
        public ResponseFormat Format { get; set; }
        public ResponseGroup ResponseGroup { get; set; }
        public bool Facets { get; set; }
        public Dictionary<string, object> FacetFilters { get; }
        public Dictionary<string, FacetRangeValues> FacetRanges { get; }
    }
}
