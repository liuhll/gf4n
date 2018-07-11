using Autofac;
using Autofac.Integration.WebApi;
using Kamo.Autofac;
using Kamo.Core.Configurations;
using Kamo.Core.Dependency;
using Kamo.Web.WebApi.Configration;
using Kamo.Web.WebApi.Handlers;
using Kamo.Web.WebApi.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;

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

        public static KamoConfiguration RegisterControllers(this KamoConfiguration kamoConfiguration, params Assembly[] webapiAssembly)
        {
            var container = (ObjectContainer.Current as AutofacObjectContainer).Container;
            if (container == null)
            {
                throw new Exception("应用启动失败，IOC容器注册失败，仅支持Autofac");
            }

            var builder = new ContainerBuilder();
            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.Load("Kamo.Gf4n.WebApi"));

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();

            builder.Update(container);

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            return kamoConfiguration;
        }
    }
}