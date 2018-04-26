using Kamo.Core.Configurations;
using Kamo.Web.WebApi.Configration;
using Kamo.Web.WebApi.Handlers;
using Kamo.Web.WebApi.Swagger;

namespace Kamo.Web.WebApi.Extensions
{
    public static class ConfigrationExtension
    {
        public static KamoConfiguration SetResultWrapper(this KamoConfiguration kamoConfiguration, IKamoApiConfiguration kamoApiConfiguration)
        {
            kamoApiConfiguration.HttpConfiguration.MessageHandlers.Add(new ResultWrapperHandler(kamoApiConfiguration));
            return kamoConfiguration;
        }

        
        public static KamoConfiguration UserDefaultSwaggerConfig(this KamoConfiguration kamoConfiguration, IKamoApiConfiguration kamoApiConfiguration)
        {
            if (kamoApiConfiguration.UseSwagger)
            {
                // :todo 可以重构为用户自定义的 SwaggerConfig.Register
                SwaggerConfig.Register(kamoApiConfiguration);
            }
            return kamoConfiguration;
        }
    }
}