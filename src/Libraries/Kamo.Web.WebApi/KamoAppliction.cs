using Kamo.Core.Configurations;
using Kamo.Web.WebApi.Configration;
using Kamo.Web.WebApi.Extensions;
using System.Web.Http;

namespace Kamo.Web.WebApi
{
    public abstract class KamoAppliction : System.Web.HttpApplication
    {
        protected readonly KamoConfiguration _kamoConfiguration;
        protected readonly IKamoApiConfiguration _kamoApiConfiguration;

        protected KamoAppliction()
        {
            _kamoConfiguration = KamoConfiguration.Create();
            _kamoApiConfiguration = new KamoApiConfiguration(GlobalConfiguration.Configuration);

            
        }    

        protected virtual void Application_Start()
        {
            InitFramework();
        }

        protected virtual void InitFramework()
        {
            _kamoConfiguration
                .UserDefaultSwaggerConfig(_kamoApiConfiguration)
                .SetResultWrapper(_kamoApiConfiguration);
            // .UseAutofac();
        }
    }
}