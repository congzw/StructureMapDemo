using System;
using System.Collections.Generic;
using System.Web.Http;
using Demos.Domains.Foos;

namespace Demos.Web.Controllers
{
    public class FooApiController : ApiController
    {
        private readonly IFooService _fooService;

        public FooApiController(IFooService fooService)
        {
            _fooService = fooService;
        }

        [Route("api/foo")]
        public IEnumerable<string> Get()
        {
            for (int i = 0; i < 3; i++)
            {
                yield return _fooService.GetFooInfo() + i;
            }
        }

        [Route("api/fooEx")]
        public string GetEx()
        {
            throw new ApplicationException("shit happens!");
        }
    }
}