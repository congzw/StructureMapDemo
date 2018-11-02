using System.Collections.Generic;
using System.Web.Http;

namespace Demos.Web.Controllers
{
    public class EmptyApiController : ApiController
    {
        public IEnumerable<string> Get()
        {
            for (int i = 0; i < 3; i++)
            {
                yield return "Foo" + i;
            }
        }
    }
}