using Dapper.Extensions.Linq.Core.Configuration;
using Dapper.Extensions.Linq.MySql;
using Kamo.Core.Dependency;
using Kamo.Dapper.Container;
using Kamo.Dapper.Extension;
using Kamo.Dapper.Mapper;

namespace Kamo.Dapper
{
    public class DapperContext
    {
        public static void Initialize(string dbConn, string entityAssembly)
        {
            DapperConfiguration
           .Use()
           .UseClassMapper(typeof(KamoClassMapper<>))
           .UseSqlDialect(new MySqlDialect())
           .FromAssembly(entityAssembly)
           .WithDefaultConnectionStringNamed(dbConn)
           .UseContainer<ContainerForAutofac>(c => c.UseExisting(ObjectContainer.Current))
           .Build();
        }
    }
}