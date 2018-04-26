using Kamo.Common.Enums;
using Kamo.Common.Extensions;
using Kamo.Web.WebApi.Configration;
using Kamo.Web.WebApi.Helper;
using Kamo.Web.WebApi.Result.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Kamo.Web.WebApi.Handlers
{
    internal class ResultWrapperHandler : DelegatingHandler
    {
        private readonly IKamoApiConfiguration _configuration;

        public ResultWrapperHandler(IKamoApiConfiguration kamoApiConfiguration)
        {
            _configuration = kamoApiConfiguration;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri.AbsolutePath.Contains("swagger"))
            {
                return await base.SendAsync(request, cancellationToken);
            }

            var result = await base.SendAsync(request, cancellationToken);

            IEnumerable<string> contentType = new List<string>();
            if (result.Content.Headers.TryGetValues("ContentType", out contentType))
            {
                if (contentType.Any(p => p == "application/octet-stream"))
                {
                    return result;
                }
            }

            WrapResultIfNeeded(request, result);
            return result;
        }

        private void WrapResultIfNeeded(HttpRequestMessage request, HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                return;
            }

            if (_configuration.SetNoCacheForAllResponses)
            {
                //Based on Http://stackoverflow.com/questions/49547/making-sure-a-web-page-is-not-cached-across-all-browsers
                response.Headers.CacheControl = new CacheControlHeaderValue
                {
                    NoCache = true,
                    NoStore = true,
                    MaxAge = TimeSpan.Zero,
                    MustRevalidate = true
                };
            }

            var wrapAttr = HttpActionDescriptorHelper.GetWrapResultAttributeOrNull(request.GetActionDescriptor())
                           ?? _configuration.DefaultWrapResultAttribute;

            if (!wrapAttr.WrapOnSuccess)
            {
                return;
            }

            if (IsIgnoredUrl(request.RequestUri))
            {
                return;
            }

            object resultObject;
            if (!response.TryGetContentValue(out resultObject) || resultObject == null)
            {
                response.StatusCode = HttpStatusCode.OK;
                // 未返回数据
                response.Content = new ObjectContent<ResponseMessage>(
                    new ResponseMessage((int)ActionResultCode.Success, ""),
                    _configuration.HttpConfiguration.Formatters.JsonFormatter
                );
                return;
            }

            if (resultObject is ResponseMessage)
            {
                return;
            }

            response.Content = new ObjectContent<ResponseMessage>(
                new ResponseMessage(resultObject),
                _configuration.HttpConfiguration.Formatters.JsonFormatter
            );
        }

        private bool IsIgnoredUrl(Uri uri)
        {
            if (uri == null || uri.AbsolutePath.IsNullOrEmpty())
            {
                return false;
            }

            return _configuration.ResultWrappingIgnoreUrls.Any(url => uri.AbsolutePath.StartsWith(url));
        }
    }
}