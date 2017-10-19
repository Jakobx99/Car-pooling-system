using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Car_with_database
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
                defaults: new { controller = "Account", action = "CreateAccount", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "EditAccount",
                url: "{controller}/{action}",
                defaults: new { controller = "Account", action = "EditAccount", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "SearchTrip",
                url: "{controller}/{action}",
                defaults: new { controller = "FindTrip", action = "SearchTrip", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "SpecificTrip",
                url: "{controller}/{action}",
                defaults: new { controller = "FindTrip", action = "SpecificTrip", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "TripList",
                url: "{controller}/{action}",
                defaults: new { controller = "FindTrip", action = "TripList", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PlanTrip",
                url: "{controller}/{action}",
                defaults: new { controller = "PlanTrip", action = "PlanTrip", id = UrlParameter.Optional }
            );


        }
    }
}
