using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace TecBits_Knockout_Bootstrap_Mvc_Sample
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
            config.Routes.MapHttpRoute(
name: "DefaultApi",
routeTemplate: "api/{namespace}/{controller}/{id}",
defaults: new { id = RouteParameter.Optional });
        }
    }
}
