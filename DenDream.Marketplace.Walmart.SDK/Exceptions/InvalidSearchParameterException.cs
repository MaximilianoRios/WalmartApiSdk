using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenDream.Marketplace.Walmart.SDK.Exceptions
{
    public class InvalidSearchParameterException : System.Exception
    {
        public InvalidSearchParameterException(string message) : base(message) { }
    }
}
