using System;
using Kamo.Core.Dependency;

namespace Kamo.Core.Configurations
{
    public class KamoConfiguration
    {
        /// <summary>Provides the singleton access instance.
        /// </summary>
        public static KamoConfiguration Instance { get; private set; }

        private KamoConfiguration()
        {
        }

        public static KamoConfiguration Create()
        {
            Instance = new KamoConfiguration();
            return Instance;
        }

        public KamoConfiguration SetDefault<TService, TImplementer>(string serviceName = null, LifeStyle life = LifeStyle.Singleton)
            where TService : class
            where TImplementer : class, TService
        {
            ObjectContainer.Register<TService, TImplementer>(serviceName, life);
            return this;
        }


        public KamoConfiguration SetDefault<TService, TImplementer>(TImplementer instance, string serviceName = null)
            where TService : class
            where TImplementer : class, TService
        {
            ObjectContainer.RegisterInstance<TService, TImplementer>(instance, serviceName);
            return this;
        }

        public KamoConfiguration BuildContainer()
        {
            ObjectContainer.Build();
            return this;
        }
    }
}