using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace car
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "CreateAccount",
                url: "{controller}/{action}",
                defaults: new { controller = "Account", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "EditAccount",
                url: "{controller}/{action}",
                defaults: new { controller = "Account", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "FindTrip",
                url: "{controller}/{action}",
                defaults: new { controller = "FindTrip", action = "FindTrip", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "SpecificTrip",
                url: "{controller}/{action}",
                defaults: new { controller = "FindTrip", action = "SpecificTrip", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PlanTrip",
                url: "{controller}/{action}",
                defaults: new { controller = "PlanTrip", action = "Plantrip", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "SearchTrip",
                url: "{controller}/{action}",
                defaults: new { controller = "FindTrip", action = "SearchTrip", id = UrlParameter.Optional }
            );


        }
    }
}
