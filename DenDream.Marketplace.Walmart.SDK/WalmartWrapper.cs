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
        public WalmartSearchResponse Search(string query, int? categoryId, WalmartResponseFormat format = WalmartResponseFormat.Json, bool facet = false, string facetFilter = null, string facetRange = null)
        {
            throw new NotImplementedException();
        }

    }
}
