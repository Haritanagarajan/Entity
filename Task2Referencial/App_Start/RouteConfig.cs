using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Task2Referencial
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute(url: "Trainee/Index");
            routes.IgnoreRoute(url: "Training/Index");
            routes.IgnoreRoute(url: "Trainee/Create");
            routes.IgnoreRoute(url: "Trainee/Edit");
            routes.IgnoreRoute(url: "Trainee/Delete");
            routes.IgnoreRoute(url: "Trainee/Details");
            routes.IgnoreRoute(url: "Training/Create");
            routes.IgnoreRoute(url: "Training/Edit");
            routes.IgnoreRoute(url: "Training/Delete");
            routes.IgnoreRoute(url: "Training/Details");
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "LoginForm", id = UrlParameter.Optional }
            );
        }
    }
}
