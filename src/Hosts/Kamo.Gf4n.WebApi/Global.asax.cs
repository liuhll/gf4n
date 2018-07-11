using Kamo.Dapper.Extension;
using Kamo.Web.WebApi;
using System.Web.Http;

namespace Kamo.Gf4n.WebApi
{
    public class WebApiApplication : KamoAppliction
    {
        public WebApiApplication()
        {

        }

        protected virtual void Application_Start()
        {
            
            InitFramework();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            _kamoConfiguration
                .UseDapperContext("testDb1", "Kamo.Demo.Entities");
        }
    }
}