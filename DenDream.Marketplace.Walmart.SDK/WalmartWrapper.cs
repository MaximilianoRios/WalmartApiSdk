using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DenDream.Marketplace.Walmart.SDK.Model;
using DenDream.Marketplace.Walmart.SDK.Model.Contract;
using DenDream.Marketplace.Walmart.SDK.Model.Request;

namespace DenDream.Marketplace.Walmart.SDK
{
    public partial class WalmartWrapper : IWalmartWrapper
    {
        public IWalmartSearchResponse Search(SearchParameters searchParameters)
        {
            return this.SearchAsync(searchParameters).Result;
        }

    }
}
