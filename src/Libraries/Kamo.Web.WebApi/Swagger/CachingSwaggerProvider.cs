using Kamo.Common.Extensions;
using Swashbuckle.Swagger;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Kamo.Web.WebApi.Swagger
{
    public class CachingSwaggerProvider : ISwaggerProvider
    {
        private static ConcurrentDictionary<string, SwaggerDocument> _cache =
           new ConcurrentDictionary<string, SwaggerDocument>();

        private ISwaggerProvider _swaggerProvider;

        public CachingSwaggerProvider(ISwaggerProvider defaultProvider)
        {
            this._swaggerProvider = defaultProvider;
        }

        public SwaggerDocument GetSwagger(string rootUrl, string apiVersion)
        {
            var cacheKey = string.Format("{0}_{1}", rootUrl, apiVersion);
            SwaggerDocument srcDoc = null;

            //只读取一次
            if (!_cache.TryGetValue(cacheKey, out srcDoc))
            {
                srcDoc = _swaggerProvider.GetSwagger(rootUrl, apiVersion);
                srcDoc.paths = PathToLower(srcDoc.paths);
              //  srcDoc.vendorExtensions = new Dictionary<string, object> { { "ControllerDesc", GetControllerDesc() } };
                _cache.TryAdd(cacheKey, srcDoc);
            }
            return srcDoc;
        }

        private IDictionary<string, PathItem> PathToLower(IDictionary<string, PathItem> paths)
        {
            var newPaths = new Dictionary<string, PathItem>();
            paths.ForEach(item =>
            {
                newPaths.Add(item.Key.ToLower(), item.Value);
            });
            return newPaths;
        }

        /// <summary>
        ///  从API文档中读取控制器描述
        /// </summary>
        /// <returns>所有控制器描述</returns>
        public static ConcurrentDictionary<string, string> GetControllerDesc()
        {
           // :todo 存在bug
            string xmlpath = string.Format("{0}/bin/Kamo.Lhp.WebApi.XML", System.AppDomain.CurrentDomain.BaseDirectory);
            ConcurrentDictionary<string, string> controllerDescDict = new ConcurrentDictionary<string, string>();
            if (File.Exists(xmlpath))
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(xmlpath);
                string type = string.Empty, path = string.Empty, controllerName = string.Empty;

                string[] arrPath;
                int length = -1, cCount = "Controller".Length;
                XmlNode summaryNode = null;
                foreach (XmlNode node in xmldoc.SelectNodes("//member"))
                {
                    type = node.Attributes["name"].Value;
                    if (type.StartsWith("T:"))
                    {
                        //控制器
                        arrPath = type.Split('.');
                        length = arrPath.Length;
                        controllerName = arrPath[length - 1];
                        if (controllerName.EndsWith("Controller"))
                        {
                            //获取控制器注释
                            summaryNode = node.SelectSingleNode("summary");
                            string key = controllerName.Remove(controllerName.Length - cCount, cCount);
                            if (summaryNode != null && !string.IsNullOrEmpty(summaryNode.InnerText) && !controllerDescDict.ContainsKey(key))
                            {
                                controllerDescDict.TryAdd(key, summaryNode.InnerText.Trim());
                            }
                        }
                    }
                }
            }
            return controllerDescDict;
        }
    }
}
