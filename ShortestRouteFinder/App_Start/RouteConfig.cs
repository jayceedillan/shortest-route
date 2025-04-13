using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShortestRouteFinder
{
    //public class RouteConfig
    //{
    //    public static void RegisterRoutes(RouteCollection routes)
    //    {
    //        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

    //        // Default route for the application to use the ShortestPath area
    //        routes.MapRoute(
    //            name: "Default",
    //            url: "{area}/{controller}/{action}/{id}",
    //            defaults: new { area = "ShortestPath", controller = "ShortestPath", action = "Index", id = UrlParameter.Optional }
    //        );
    //    }
    //}

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Default route to jQueryShortestPath in the ShortestPath area
            routes.MapRoute(
                name: "Default",
                url: "{area}/{controller}/{action}/{id}",
                defaults: new { area = "ShortestPath", controller = "jQueryShortestPath", action = "Index", id = UrlParameter.Optional }
            );
        }
    }

}
