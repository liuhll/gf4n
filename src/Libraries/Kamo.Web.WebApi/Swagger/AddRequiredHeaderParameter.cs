using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace Kamo.Web.WebApi.Swagger
{
    public class AddRequiredHeaderParameter : IOperationFilter
    {
        private readonly ICollection<Tuple<string, string>> _ignoreHeaders;
        public AddRequiredHeaderParameter(ICollection<Tuple<string, string>> ignoreHeaders)
        {
            _ignoreHeaders = ignoreHeaders;
        }

        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null)
                operation.parameters = new List<Parameter>();
            if (_ignoreHeaders.Any(p => apiDescription.RelativePath.ToLower().Contains(p.Item1) && p.Item2 == apiDescription.HttpMethod.ToString()))
            {
                return;
            }

            operation.parameters.Add(new Parameter
            {
                name = "ClientToken",
                @in = "header",
                type = "string",
                description = "Token",
                required = true
            });
        }
    }
}
