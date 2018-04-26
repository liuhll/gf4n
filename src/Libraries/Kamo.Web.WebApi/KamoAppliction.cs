using Kamo.Core.Configurations;
using Kamo.Web.WebApi.Configration;
using Kamo.Web.WebApi.Extensions;
using System.Web.Http;

namespace Kamo.Web.WebApi
{
    public class KamoAppliction : System.Web.HttpApplication
    {
        protected readonly KamoConfiguration _kamoConfiguration;
        protected readonly IKamoApiConfiguration _kamoApiConfiguration;

        public KamoAppliction()
        {
            _kamoConfiguration = KamoConfiguration.Create();
            _kamoApiConfiguration = new KamoApiConfiguration(GlobalConfiguration.Configuration);

            InitFramework();
        }

        protected virtual void InitFramework()
        {
            _kamoConfiguration
                .SetResultWrapper(_kamoApiConfiguration);
            // .UseAutofac();
        }

        protected virtual void Application_Start()
        {
        }
    }
}