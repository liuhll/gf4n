using Kamo.Web.WebApi;
using System.Web.Http;

namespace Kamo.Gf4n.WebApi
{
    public class WebApiApplication : KamoAppliction
    {
        public WebApiApplication()
        {

        }

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}