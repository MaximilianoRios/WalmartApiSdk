using DenDream.Marketplace.Walmart.SDK.Exceptions;
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

        public WalmartSearchOperation LinkSharePublisherId(string lsPublisherId)
        {
            base.AddOrReplace("lsPublisherId", lsPublisherId);
            return this;
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

        public WalmartSearchOperation Format(ResponseFormat format)
        {
            base.AddOrReplace("format", Enum.GetName(typeof(ResponseFormat), format).ToLower());
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

        /// <summary>
        /// Facet filters are filters from the list of available facets returned by the service.
        /// It is not necessary to obtain them in advance but filters are not guaranteed to exist
        /// </summary>
        /// <param name="fieldName">Name of the facet</param>
        /// <param name="value">Value to filter (from the available list)</param>
        /// <returns></returns>
        public WalmartSearchOperation AddFacetFilter(string fieldName, object value)
        {
            var key = $"facet.filter";
            var currentValue = string.Empty;
            if (ParameterValue(key) != null)
            {
                currentValue += ",";
            }
            currentValue += $"{fieldName}:{value}";
            base.AddOrReplace(key, currentValue);
            return this;
        }

        public WalmartSearchOperation AddFacetRange(string fieldName, object rangeFrom, object rangeTo)
        {
            var key = $"facet.range";
            var currentValue = string.Empty;
            if (ParameterValue(key) != null)
            {
                currentValue += ",";
            }
            currentValue += $"{fieldName}:[{rangeFrom} TO {rangeTo}]";
            base.AddOrReplace(key, currentValue);
            return this;
        }

        public WalmartSearchOperation Category(string categoryId)
        {
            base.AddOrReplace("categoryId", categoryId);
            return this;
        }

        public WalmartSearchOperation Start(int start)
        {
            base.AddOrReplace("start", start);
            return this;
        }

        public WalmartSearchOperation Sort(SortCriteria criteria)
        {
            var value = Char.ToLowerInvariant(criteria.ToString()[0]) + criteria.ToString().Substring(1);
            base.AddOrReplace("sort", value);
            return this;
        }

        public WalmartSearchOperation Order(SortOrder order)
        {
            var value = Char.ToLowerInvariant(order.ToString()[0]) + order.ToString().Substring(1);
            base.AddOrReplace("order", value);
            return this;
        }

        public WalmartSearchOperation NumItems(int numItems)
        {
            base.AddOrReplace("numItems", numItems);
            return this;
        }
        public WalmartSearchOperation ResponseGroup(ResponseGroup group)
        {
            var value = Char.ToLowerInvariant(group.ToString()[0]) + group.ToString().Substring(1);
            base.AddOrReplace("responseGroup", value);
            return this;
        }

    }
}
