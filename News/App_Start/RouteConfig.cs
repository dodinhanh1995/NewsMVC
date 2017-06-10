using System.Web.Mvc;
using System.Web.Routing;

namespace News
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Detail News",
               url: "tin-tuc/{metatitle}-{id}",
               defaults: new { controller = "Details", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "News.Controllers" }
           );

            routes.MapRoute(
                name: "Genre News",
                url: "loai-tin/{metatitle}-{genreID}",
                defaults: new { controller = "Genre", action = "Index", genreID = UrlParameter.Optional },
                namespaces: new[] { "News.Controllers" }
            );

            routes.MapRoute(
                name: "Search News",
                url: "tim-kiem/{s}",
                defaults: new { controller = "Search", action = "Index", s = UrlParameter.Optional },
                namespaces: new[] { "News.Controllers" }
            );

            routes.MapRoute(
                name: "Login",
                url: "dang-nhap",
                defaults: new { controller = "Login", action = "Index" },
                namespaces: new[] { "News.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Index", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
