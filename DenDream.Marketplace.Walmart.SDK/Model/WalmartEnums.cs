using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenDream.Marketplace.Walmart.SDK.Model
{
    public enum ResponseFormat { Json = 0, Xml }

    public enum SortCriteria { Relevance, Price, Title, Bestseller, CustomerRating, New }

    public enum SortOrder { Asc, Desc }

    public enum ResponseGroup {  Base, Full }

}
