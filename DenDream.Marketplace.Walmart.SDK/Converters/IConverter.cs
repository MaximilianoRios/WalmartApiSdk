using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenDream.Marketplace.Walmart.SDK.Converters
{
    public interface IConverter
    {
        T Convert<T>(string sourceString);
    }
}
