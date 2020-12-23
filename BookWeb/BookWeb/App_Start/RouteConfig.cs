using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Category",
                url: "san-pham/{metatitle}-{cateid}",
                defaults: new { controller = "Book", action = "Category", id = UrlParameter.Optional },
                namespaces: new[] { "BookWeb.Controllers" }
            );

            routes.MapRoute(
                name: "Detail",
                url: "chi-tiet/{metatitle}-{id}",
                defaults: new { controller = "Book", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "BookWeb.Controllers" }
            );

            routes.MapRoute(
                name: "Cart",
                url: "gio-hang",
                defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "BookWeb.Controllers" }
            );

            routes.MapRoute(
                name: "Payment",
                url: "thanh-toan",
                defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
                namespaces: new[] { "BookWeb.Controllers" }
            );

            routes.MapRoute(
                name: "Payment Success",
                url: "hoan-thanh",
                defaults: new { controller = "Cart", action = "Succses", id = UrlParameter.Optional },
                namespaces: new[] { "BookWeb.Controllers" }
            );

            routes.MapRoute(
                name: "Shopig Cart",
                url: "them-gio-hang",
                defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
                namespaces: new[] { "BookWeb.Controllers" }
            );

            routes.MapRoute(
                name: "Login",
                url: "dang-nhap",
                defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional },
                namespaces: new[] { "BookWeb.Controllers" }
            );

            routes.MapRoute(
                name: "Register",
                url: "dang-ky",
                defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional },
                namespaces: new[] { "BookWeb.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces : new [] {"BookWeb.Controllers"}
            );
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          