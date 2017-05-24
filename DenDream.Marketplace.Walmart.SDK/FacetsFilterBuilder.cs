using DenDream.Marketplace.Walmart.SDK.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenDream.Marketplace.Walmart.SDK
{
    public class FacetsFilterBuilder
    {
        private Dictionary<string, FacetRangeValues> _facetRanges;
        private Dictionary<string, object> _facets;

        public FacetsFilterBuilder()
        {
        }

        public FacetsFilterBuilder AddFilter(string fieldName, object value)
        {
            fieldName = fieldName.Trim();
            if (string.IsNullOrEmpty(fieldName))
            {
                throw new InvalidFacetFilterException($"Filter name cannot be null");
            }
            if (value == null)
            {
                throw new InvalidFacetFilterException($"Filter value cannot be null");
            }
            if (_facets == null)
            {
                _facets = new Dictionary<string, object>();
            }
            if (_facets.ContainsKey(fieldName))
            {
                _facets[fieldName] = value;
            }
            else
            {
                _facets.Add(fieldName, value);
            }
            return this;
        }

        public FacetsFilterBuilder AddRange(string fieldName, object rangeFrom, object rangeTo)
        {
            fieldName = fieldName.Trim();
            if (string.IsNullOrEmpty(fieldName))
            {
                throw new InvalidFacetFilterException($"Filter name cannot be null");
            }
            if (rangeFrom == null || rangeTo == null)
            {
                throw new InvalidFacetFilterException($"From/To range cannot be null");
            }
            if (_facetRanges == null)
            {
                _facetRanges = new Dictionary<string, FacetRangeValues>();
            }
            if (_facetRanges.ContainsKey(fieldName))
            {
                _facetRanges[fieldName] = new FacetRangeValues(rangeFrom, rangeTo);
            }
            else
            {
                _facetRanges.Add(fieldName, new FacetRangeValues(rangeFrom, rangeTo));
            }
            return this;
        }

        public Dictionary<string, object> Filters
        {
            get
            {
                return _facets;
            }
        }

        public Dictionary<string, FacetRangeValues> Ranges
        {
            get
            {
                return _facetRanges;
            }
        }
    }

    public class FacetRangeValues
    {
        public object RangeFrom { get; }
        public object RangeTo { get; }
        public FacetRangeValues(object from, object to)
        {
            RangeFrom = from;
            RangeTo = to;
        }
    }
}
