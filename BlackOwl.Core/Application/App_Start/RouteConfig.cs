using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BlackOwl.Core.Application
{
    public class RouteConfig:BlackCogs.Application.RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            //MultiPlex Wiki
            routes.MapRoute(
                "History",
                "{wikiname}/{id}/{slug}/v{version}",
                new { controller = "HomeWiki", action = "ViewContentVersion" },
                new { id = @"\d+", version = @"\d+" }
                );

            routes.MapRoute(
                "Source",
                "{wikiname}/{id}/{slug}/source/v{version}",
                new { controller = "HomeWiki", action = "GetWikiSource" },
                new { id = @"\d+", version = @"\d+" }
                );

            routes.MapRoute(
                "Act",
                "{id}/{slug}/{action}",
                new { controller = "HomeWiki", action = "ViewContent" },
                new { id = @"\d+", action = @"\w+" }
                );
        }
    }
}
