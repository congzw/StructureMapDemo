﻿using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Demos.Web
{
    public class MainEntry
    {
        public static void Init()
        {
            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(WebApiConfig.RegisterGlobalFilters);

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
