using System;
using System.Web.Mvc;
using Demos.Domains.Foos;

namespace Demos.Web.Controllers
{
    public class FooController : Controller
    {
        private readonly IFooService _fooService;

        public FooController(IFooService fooService)
        {
            _fooService = fooService;
        }

        public ActionResult Index()
        {
            return Content(_fooService.GetFooInfo());
        }
        public ActionResult IndexEx()
        {
            throw new ApplicationException("shit happens!");
        }
    }
}