using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Shop.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Register",
               url: "dang-ky.html",
               defaults: new { controller = "Account", action = "Register" },
               namespaces: new string[] { "Shop.Web.Controllers" }
            );
            routes.MapRoute(
               name: "Login",
               url: "dang-nhap.html",
               defaults: new { controller = "Account", action = "Login" },
               namespaces: new string[] { "Shop.Web.Controllers" }
            );
            routes.MapRoute(
               name: "Product Category",
               url: "{alias}.pc-{id}.html",
               defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "Shop.Web.Controllers" }
            );

        }
        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }
    }
}
