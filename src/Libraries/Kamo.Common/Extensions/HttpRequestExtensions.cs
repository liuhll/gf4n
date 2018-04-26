using System.Net.Http;
using System.Web;

namespace Kamo.Common.Extensions
{
    public static class HttpRequestExtensions
    {
        public static string UserHostAddress(this HttpRequestMessage request)
        {
            var userHostAddress = ((HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
            return userHostAddress;
        }
    }
}