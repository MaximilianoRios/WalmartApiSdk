using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenDream.Marketplace.Walmart.SDK.Model.Contract
{
    public interface IFacet
    {
        string Name { get; set; }
        string DisplayName { get; set; }
        IFacetProperty Properties { get; set; }
        IEnumerable<IFacetValue> Values { get; set; }
    }

    public interface IFacetProperty
    {
        string Multi { get; set; }
        string NullCount { get; set; }
    }

    public interface IFacetValue
    {
        string Name { get; set; }
        int Count { get; set; }
    }
}
