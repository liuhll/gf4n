using Kamo.Web.WebApi.Result;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Kamo.Web.WebApi.Configration
{
    public interface IKamoApiConfiguration
    {
        WrapResultAttribute DefaultWrapResultAttribute { get; }

        bool SetDefaultWrapResult { get; }

        bool SetNoCacheForAjaxResponses { get; set; }

        bool SetNoCacheForAllResponses { get; set; }

        bool SetCamelCaseForAllResponses { get; }

        bool ClearHistroyCache { get; }

        List<string> ResultWrappingIgnoreUrls { get; }

        HttpConfiguration HttpConfiguration { get; }

        string ProjectName { get; }

        string AppVersion { get; }

        ICollection<string> XmlComments { get; }

        bool UseSwagger { get; }

        ICollection<Tuple<string,string>> AuthenticationWhiteList { get; }
    }
}