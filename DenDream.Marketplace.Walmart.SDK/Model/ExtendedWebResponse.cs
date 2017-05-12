using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DenDream.Marketplace.Walmart.SDK.Model
{
    public class ExtendedWebResponse
    {
        public HttpStatusCode StatusCode;
        public string Content;

        public ExtendedWebResponse(HttpStatusCode statusCode, string content)
        {
            this.StatusCode = statusCode;
            this.Content = content;
        }
    }
}
