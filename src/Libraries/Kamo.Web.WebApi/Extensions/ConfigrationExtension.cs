using Kamo.Core.Configurations;
using Kamo.Web.WebApi.Configration;
using Kamo.Web.WebApi.Handlers;

namespace Kamo.Web.WebApi.Extensions
{
    public static class ConfigrationExtension
    {
        public static KamoConfiguration SetResultWrapper(this KamoConfiguration kamoConfiguration, IKamoApiConfiguration kamoApiConfiguration)
        {
            kamoApiConfiguration.HttpConfiguration.MessageHandlers.Add(new ResultWrapperHandler(kamoApiConfiguration));
            return kamoConfiguration;
        }
    }
}