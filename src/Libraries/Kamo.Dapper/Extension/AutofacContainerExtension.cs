using Autofac;
using Dapper.Extensions.Linq.Core.Configuration;
using Dapper.Extensions.Linq.Core.Repositories;
using Dapper.Extensions.Linq.Core.Sessions;
using Dapper.Extensions.Linq.Repositories;
using Kamo.Autofac;
using Kamo.Core.Dependency;
using Kamo.Core.Domain.Repositories;
using Kamo.Dapper.Repositories;

namespace Kamo.Dapper.Extension
{
    public static class AutofacContainerExtension
    {
        public static void RegisterDapperComponents(this IObjectContainer container, DapperConfiguration dapperConfiguration)
        {
            var autofacContainer = (container as AutofacObjectContainer).Container;

            var builder = new ContainerBuilder();

            builder.RegisterInstance(new DapperSessionFactory(dapperConfiguration)).As<IDapperSessionFactory>();
            builder.RegisterType<DapperSessionContext>()
                    .As<IDapperSessionContext>().AsSelf()
                    .InstancePerDependency();

            builder.RegisterGeneric(typeof(DapperRepository<>))
                    .As(typeof(IRepository<>))
                    .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(KamoDapperRepository<>))
                   .As(typeof(IKamoRepository<>))
                   .InstancePerLifetimeScope();
            builder.Update(autofacContainer);
        }
    }
}