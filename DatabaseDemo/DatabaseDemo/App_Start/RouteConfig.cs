using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DatabaseDemo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.MapRoute(
                name: "Home",
                url: "",
                defaults: new { controller = "Home", action = "Index", preventCookies = false });

            routes.MapRoute(
                name: "TryAgain",
                url: "TryAgain",
                defaults: new { controller = "Home", action = "Index", preventCookies = true });

            routes.MapRoute(
                name: "CalculateRetry",
                url: "Calculate/{a}_{operator}_{b}",
                defaults: new { controller = "Home", action = "Calculate" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" });
        }
    }
}