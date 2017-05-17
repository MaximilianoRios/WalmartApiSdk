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
        //private Dictionary<string, Type> AvailableFilters;
        //private Dictionary<string, object> _facets;

        public FacetsFilterBuilder()
        {
            //AvailableFilters = new Dictionary<string, Type>();
            //AvailableFilters.Add("upc", typeof(string));
            //AvailableFilters.Add("marketplace", typeof(bool));
            //AvailableFilters.Add("bundle", typeof(bool));
            //AvailableFilters.Add("stock", typeof(string));
            //AvailableFilters.Add("offerType", typeof(string));
            //AvailableFilters.Add("availableOnline", typeof(bool));
        }

        //public FacetsFilterBuilder AddFacet(string fieldName, object value)
        //{
        //    if (!AvailableFilters.ContainsKey(fieldName))
        //    {
        //        throw new InvalidFacetFilterException($"{fieldName} is not a valid facet filter");
        //    }
        //    if (AvailableFilters[fieldName] != value.GetType())
        //    {
        //        throw new InvalidFacetFilterException($"{fieldName} must be of type {value.GetType()}");
        //    }
        //    if (_facets == null)
        //    {
        //        _facets = new Dictionary<string, object>();
        //    }
        //    if(_facets.ContainsKey(fieldName))
        //    {
        //        _facets[fieldName] = value;
        //    }
        //    else
        //    {
        //        _facets.Add(fieldName, value);
        //    }
        //    return this;
        //}

        //public Dictionary<string, object> Facets
        //{
        //    get
        //    {
        //        return _facets;
        //    }
        //}
    }
}
