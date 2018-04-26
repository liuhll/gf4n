using Kamo.Web.WebApi.Result;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Web.Http;

namespace Kamo.Web.WebApi.Configration
{
    public class KamoApiConfiguration : IKamoApiConfiguration
    {
        private readonly HttpConfiguration _httpConfiguration;

        public KamoApiConfiguration(HttpConfiguration httpConfiguration)
        {
            _httpConfiguration = httpConfiguration;
            SetNoCacheForAjaxResponses = true;
            SetNoCacheForAllResponses = true;
        }

        public WrapResultAttribute DefaultWrapResultAttribute => new WrapResultAttribute();

        public bool SetDefaultWrapResult
        {
            get
            {
                return true;
            }
        }

        public bool SetNoCacheForAjaxResponses { get; set; }
        public bool SetNoCacheForAllResponses { get; set; }

        public bool SetCamelCaseForAllResponses
        {
            get { return true; }
        }

        public bool ClearHistroyCache
        {
            get { return true; }
        }

        public List<string> ResultWrappingIgnoreUrls
        {
            get
            {
                var ignoreUrls = new List<string> { "/swagger" };
                return ignoreUrls;
            }
        }

        public HttpConfiguration HttpConfiguration
        {
            get
            {
                if (SetCamelCaseForAllResponses)
                {
                    _httpConfiguration.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                }
                return _httpConfiguration;
            }
        }
    }
}