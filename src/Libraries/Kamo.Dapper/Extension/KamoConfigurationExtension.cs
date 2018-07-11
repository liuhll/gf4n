using Kamo.Core.Configurations;

namespace Kamo.Dapper.Extension
{
    public static class KamoConfigurationExtension
    {
        public static KamoConfiguration UseDapperContext(this KamoConfiguration kamoConfiguration, string dbConn, string entityAssembly)
        {
            DapperContext.Initialize(dbConn,entityAssembly);
            return kamoConfiguration;
        }
    }
}
