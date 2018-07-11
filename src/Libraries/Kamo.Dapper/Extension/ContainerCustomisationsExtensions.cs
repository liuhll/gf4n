using Dapper.Extensions.Linq.Core.Configuration;
using Kamo.Core.Dependency;

namespace Kamo.Dapper.Extension
{
    public static class ContainerCustomisationsExtensions
    {
        public static void UseExisting(this IContainerCustomisations customisations, IObjectContainer container)
        {
            customisations.Settings().Add("ExistingContainer", container);
        }
    }
}