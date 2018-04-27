using Autofac;
using Kamo.Core.Configurations;
using Kamo.Core.Dependency;
using Kamo.Core.Reflection;
using System;
using System.Linq;

namespace Kamo.Autofac
{
    /// <summary>ENode configuration class Autofac extensions.
    /// </summary>
    public static class ConfigurationExtensions
    {
        /// <summary>Use Autofac as the object container.
        /// </summary>
        /// <returns></returns>
        public static KamoConfiguration UseAutofac(this KamoConfiguration configuration)
        {
            return UseAutofac(configuration, new ContainerBuilder());
        }

        /// <summary>Use Autofac as the object container.
        /// </summary>
        /// <returns></returns>
        public static KamoConfiguration UseAutofac(this KamoConfiguration configuration, ContainerBuilder containerBuilder)
        {
            ObjectContainer.SetContainer(new AutofacObjectContainer(containerBuilder));
            return configuration;
        }

        public static KamoConfiguration RegisterCommonBussnessComponents(this KamoConfiguration eCommon)
        {
            var typeFinder = new TypeFinder();
            var registeredSingletonTypes = typeFinder.Find(p => p.GetInterfaces().Contains(typeof(ISingletonDependency)) && p.IsClass && !p.IsAbstract);
            var registeredTransientTypes = typeFinder.Find(p => p.GetInterfaces().Contains(typeof(ITransientDependency)) && p.IsClass && !p.IsAbstract);

            foreach (var type in registeredSingletonTypes)
            {
                RegisterComponentType(type, LifeStyle.Singleton);
            }

            foreach (var type in registeredTransientTypes)
            {
                RegisterComponentType(type, LifeStyle.Transient);
            }
            return eCommon;
        }

        private static void RegisterComponentType(Type type, LifeStyle life)
        {
            foreach (var interfaceType in type.GetInterfaces())
            {
                if (interfaceType != typeof(ISingletonDependency) && interfaceType != typeof(ITransientDependency))
                {
                    ObjectContainer.RegisterType(interfaceType, type, null, life);
                }
            }
        }

    }
}