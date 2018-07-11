using Kamo.Demo.Service.Demo;
using System;
using System.Web.Http;

namespace Kamo.Gf4n.WebApi.Controllers
{
    [RoutePrefix("demo")]
    public class DemoController : ApiController
    {
        private readonly IDemoService _demoService;

        public DemoController(IDemoService demoService)
        {
            _demoService = demoService;
        }

        [Route("testdi")]
        [HttpGet]
        public string TestDi()
        {
            
            return _demoService.TestDiMethod();
        }

    }
}