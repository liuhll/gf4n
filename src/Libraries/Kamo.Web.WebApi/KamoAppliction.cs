using Kamo.Autofac;
using Kamo.Core.Configurations;
using Kamo.Web.WebApi.Configration;
using Kamo.Web.WebApi.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace Kamo.Web.WebApi
{
    public abstract class KamoAppliction : System.Web.HttpApplication
    {
        protected readonly KamoConfiguration _kamoConfiguration;
        protected readonly IKamoApiConfiguration _kamoApiConfiguration;

        protected KamoAppliction()
        {
            _kamoConfiguration = KamoConfiguration.Create();
            _kamoApiConfiguration = new KamoApiConfiguration(GlobalConfiguration.Configuration);
            
        }    

        protected virtual void InitFramework()
        {
            _kamoConfiguration
                .UserDefaultSwaggerConfig(_kamoApiConfiguration)
                .SetResultWrapper(_kamoApiConfiguration)
                .UseAutofac()
                .RegisterCommonBussnessComponents()               
                .BuildContainer()
                .RegisterControllers(GetWebApiAssemblies().ToArray())
                ;
        }

        private ICollection<Assembly> GetWebApiAssemblies()
        {
            var webapiAssemblies = new List<Assembly>();
            var childTypes = new List<Type>();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var thisType = this.GetType();
            foreach (var assembly in assemblies) {
                var assemblytypes = assembly.GetTypes();
                foreach (var assemblytype in assemblytypes)
                {
                    if (assemblytype.BaseType == thisType && !assemblytype.IsAbstract)
                    {
                        childTypes.Add(assemblytype);
                    }
                }
            }
            //if (!childTypes.Any())
            //{
            //    throw new Exception("框架初始化失败,原因:不存在webapi项目");
            //}
            foreach (var childType in childTypes)
            {
                webapiAssemblies.Add(childType.Assembly);
            }
            return webapiAssemblies;

        }
    }
}