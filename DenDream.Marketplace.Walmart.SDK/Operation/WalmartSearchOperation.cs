using DenDream.Marketplace.Walmart.SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenDream.Marketplace.Walmart.SDK.Operation
{
    public class WalmartSearchOperation : WalmartOperationBase
    {
        public WalmartSearchOperation(string apiKey) : base(apiKey)
        {
        }

        public override string UriTemplate
        {
            get
            {
                return "v1/search";
            }
        }

        /// <summary>
        /// Fluent Api behavior. Query parameter
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public WalmartSearchOperation Query(string query)
        {
            base.AddOrReplace("query", query);
            return this;
        }

        public WalmartSearchOperation Format(WalmartResponseFormat format)
        {
            base.AddOrReplace("format", Enum.GetName(typeof(WalmartResponseFormat), format).ToLower());
            return this;
        }

        public WalmartSearchOperation Facet(bool facetOn)
        {
            if (facetOn)
            {
                base.AddOrReplace("facet", "on");
            }
            return this;
        }

        public WalmartSearchOperation Category(int categoryId)
        {
            base.AddOrReplace("categoryId", categoryId);
            return this;
        }
    }
}
