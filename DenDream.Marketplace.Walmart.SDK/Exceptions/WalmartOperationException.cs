using DenDream.Marketplace.Walmart.SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenDream.Marketplace.Walmart.SDK.Exceptions
{
    public class WalmartOperationException : Exception
    {
        public WalmartErrorResponse ErrorResponse { get; private set; }

        public WalmartOperationException(string message) : base(message) { }

        public WalmartOperationException(string message, WalmartErrorResponse errorResponse) : base(message)
        {
            ErrorResponse = errorResponse;
        }

    }
}
