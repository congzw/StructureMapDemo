using System.Web.Mvc;

namespace Demos.Web.Controllers
{
    public class EmptyController : Controller
    {
        public ActionResult Index()
        {
            return Content("Foo");
        }
    }
}