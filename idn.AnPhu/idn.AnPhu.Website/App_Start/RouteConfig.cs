using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace idn.AnPhu.Website
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //Routes are registered using: Portal.Web.Extensions.RoutingHelper
            //Routes are configured at: Config\Routes.config

            //RoutingHelper.RegisterRoutes(RouteTable.Routes, RouteMappingConfiguration.Current);

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    "front_end_gioi_thieu",
            //    "{culture}/gioi-thieu",
            //    new { culture = "vi", controller = "Home", action = "About", id = UrlParameter.Optional },
            //    new[] { "idn.AnPhu.Website.Controllers" }
            //);

            //routes.MapRoute(
            //    "front_end_lien_he",
            //    "{culture}/lien-he",
            //    new { culture = "vi", controller = "Home", action = "Contact", id = UrlParameter.Optional },
            //    new[] { "idn.AnPhu.Website.Controllers" }
            //);

            //routes.MapRoute(
            //    "Default",
            //    "{culture}/{controller}/{action}/{id}",
            //    new { culture = "vi", controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    new[] { "idn.AnPhu.Website.Controllers" }
            //);

            routes.MapRoute(
                "listprd",
                "{culture}/danh-sach-san-pham/{shortname}",
                new { culture = "vi", controller = "Product", action = "Index", shortname = UrlParameter.Optional },
                new[] { "idn.AnPhu.Website.Controllers" }
            );

            routes.MapRoute(
                "product",
                "{culture}/san-pham/{productcode}",
                new { culture = "vi", controller = "Product", action = "Details", productcode = UrlParameter.Optional },
                new[] { "idn.AnPhu.Website.Controllers" }
            );

            routes.MapRoute(
                "news-cate",
                "{culture}/tin-tuc/{shortname}/{page}",
                new { culture = "vi", controller = "News", action = "ShowCateNews", shortname = UrlParameter.Optional, page = UrlParameter.Optional },
                new[] { "idn.AnPhu.Website.Controllers" }
            );

            routes.MapRoute(
                "news-details",
                "{culture}/tin-tuc-chi-tiet/{id}",
                new { culture = "vi", controller = "News", action = "Details", id = UrlParameter.Optional },
                new[] { "idn.AnPhu.Website.Controllers" }
            );

            routes.MapRoute(
                "html-pages",
                "{culture}/trang-tinh/{shortname}",
                new { culture = "vi", controller = "HtmlPages", action = "Index", shortname = UrlParameter.Optional },
                new[] { "idn.AnPhu.Website.Controllers" }
            );

            routes.MapRoute(
             "NetAdvImage",
             "{scriptPath}/tinymce/plugins/netadvimage/{action}",
             new { controller = "NetAdvImage" }
            );

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "idn.AnPhu.Website.Controllers" }
            );
        }
    }
}
