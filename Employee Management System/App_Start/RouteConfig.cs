using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Employee_Management_System
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Login",
               url: "login",
               defaults: new { controller = "Users", action = "Login", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "About",
               url: "about",
               defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "Contact",
               url: "contact",
               defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "Signup",
               url: "signup",
               defaults: new { controller = "Users", action = "Signup", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Default",
                url: "{Controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
