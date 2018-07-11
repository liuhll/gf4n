using Kamo.Common.Extensions;
using Kamo.Common.Tools;
using Kamo.Core;
using Kamo.Core.Common;
using Kamo.Web.WebApi.Result;
using Newtonsoft.Json.Serialization;
using System;
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

        public string ProjectName {
            get {
                var projectName = ConfigHelper.Value("ProjectName");
                if (UseSwagger && projectName.IsNullOrEmpty()) {
                    projectName = KamoConstants.ProjectDefaultName;
                }
                return projectName;
            }
        }

        public string AppVersion {
            get {
                var appVersion = ConfigHelper.Value("AppVersion");
                if (UseSwagger && appVersion.IsNullOrEmpty())
                {
                    appVersion = KamoConstants.AppDefaultVersion;
                }
                return appVersion;
            }
        }

        public ICollection<string> XmlComments
        {
            get {

                var xmlComments = ConfigHelper.Value("XmlComments");
                if (UseSwagger && xmlComments.IsNullOrEmpty()) {
                    return new List<string>();
                }
                return xmlComments.Split(',');               
                
            }
        }

        public bool UseSwagger {
            get {
                try
                {
                    return ConfigHelper.ValueBool("UseSwagger");
                }
                catch {
                    return false;
                }
               
            }
        }

        public ICollection<Tuple<string, string>> AuthenticationWhiteList {
            get
            {
                var authenticationWhiteList = new List<Tuple<string, string>>();
                var authenticationWhiteListStr = ConfigHelper.Value("AuthenticationWhiteList");
                if (UseSwagger && authenticationWhiteListStr.IsNullOrEmpty()) {
                    return new List<Tuple<string, string>>();
                }
                var authenticationWhiteListStrList = authenticationWhiteListStr.Split('|');

                foreach (var item in authenticationWhiteListStrList) {
                    var apiInfo = item.Split(',');
                    authenticationWhiteList.Add(new Tuple<string, string>(apiInfo[0], apiInfo[1]));
                }
                return authenticationWhiteList;
            }
        }
    }
}