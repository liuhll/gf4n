using Dapper.Extensions.Linq.Core.Configuration;
using Kamo.Core.Dependency;
using Kamo.Dapper.Extension;

namespace Kamo.Dapper.Container
{
    public class ContainerForAutofac : ObjectContainer, IContainer
    {
        public void Build(DapperConfiguration dapperConfiguration)
        {
            Current.RegisterDapperComponents(dapperConfiguration);
        }
    }
}