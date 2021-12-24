﻿using System.Web.Mvc;

namespace idn.AnPhu.Website.Areas.Auth
{
    public class AuthAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Auth";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            context.MapRoute(
                "auth_login",
                "{culture}/dang-nhap",
                new { culture = "vi", controller = "Account", action = "Login" },
                new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
                "auth_home",
                "{culture}/quan-tri",
                new { culture = "vi", controller = "Home", action = "Index" },
                new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
                "auth_sys_user",
                "{culture}/quan-tri/nguoi-dung",
                new { culture = "vi", controller = "Sys_User", action = "Index" },
                new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );
            context.MapRoute(
                name: "auth_sys_user_create",
                url: "{culture}/quan-tri/nguoi-dung/tao-moi",
                defaults: new
                {
                    culture = "vi",
                    area = "Auth",
                    controller = "Sys_User",
                    action = "Create",
                },
                namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
               name: "auth_sys_user_update",
               url: "{culture}/quan-tri/nguoi-dung/cap-nhat",
               defaults: new
               {
                   culture = "vi",
                   area = "Auth",
                   controller = "Sys_User",
                   action = "Update",
               },
               namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
           );
            context.MapRoute(
              name: "auth_sys_user_detail",
              url: "{culture}/quan-tri/nguoi-dung/chi-tiet",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "Sys_User",
                  action = "Detail",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
          );

            context.MapRoute(
              name: "auth_categoriesnews",
              url: "{culture}/quan-tri/danh-muc-tin-tuc/danh-sach",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "CategoriesNews",
                  action = "Index",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
          );

            context.MapRoute(
              name: "auth_categoriesnews_create",
              url: "{culture}/quan-tri/danh-muc-tin-tuc/tao-moi",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "CategoriesNews",
                  action = "Create",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
          );

            context.MapRoute(
              name: "auth_categoriesnews_update",
              url: "{culture}/quan-tri/danh-muc-tin-tuc/cap-nhat",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "CategoriesNews",
                  action = "Update",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
          );

            context.MapRoute(
              name: "auth_news",
              url: "{culture}/quan-tri/danh-sach-tin-tuc/danh-sach",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "News",
                  action = "Index",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
          );

            context.MapRoute(
              name: "auth_news_create",
              url: "{culture}/quan-tri/danh-sach-tin-tuc/tao-moi",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "News",
                  action = "Create",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
          );

            context.MapRoute(
              name: "auth_news_update",
              url: "{culture}/quan-tri/danh-sach-tin-tuc/cap-nhat",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "News",
                  action = "Update",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
          );

            context.MapRoute(
              name: "auth_news_delete",
              url: "{culture}/quan-tri/danh-sach-tin-tuc/xoa",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "News",
                  action = "Delete",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
              name: "auth_prdcategories",
              url: "{culture}/quan-tri/danh-muc-san-pham/danh-sach",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "PrdCategories",
                  action = "Index",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
              name: "auth_prdcategories_create",
              url: "{culture}/quan-tri/danh-muc-san-pham/tao-moi",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "PrdCategories",
                  action = "Create",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
              name: "auth_prdcategories_update",
              url: "{culture}/quan-tri/danh-muc-san-pham/cap-nhat",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "PrdCategories",
                  action = "Update",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
                "Auth_default",
                "{culture}/Auth/{controller}/{action}/{id}",
                new { culture = "vi", controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );



            //context.MapRoute(
            //    "Auth_default",
            //    "Auth/{controller}/{action}/{id}",
            //    new { action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}