using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Mood_Food
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            name: "ProductDescription",
            url: "Item/{id}",
            defaults: new { controller = "Product", action = "Description" }
        );

            routes.MapRoute(
             name: "Menu",
             url: "Menu/{category}",
             defaults: new { controller = "Product", action = "Products", category = UrlParameter.Optional }
         );


            routes.MapRoute(
             name: "Static",
             url: "Info/{name}",
             defaults: new { controller = "Info", action = "StaticSite" }
         );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
