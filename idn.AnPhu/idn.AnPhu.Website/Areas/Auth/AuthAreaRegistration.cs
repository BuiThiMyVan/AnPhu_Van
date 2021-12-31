using System.Web.Mvc;

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

            context.MapRoute(
              name: "auth_product",
              url: "{culture}/quan-tri/danh-sach-san-pham/danh-sach",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "Product",
                  action = "Index",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
              name: "auth_product_create",
              url: "{culture}/quan-tri/danh-sach-san-pham/tao-moi",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "Product",
                  action = "Create",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
              name: "auth_product_update",
              url: "{culture}/quan-tri/danh-sach-san-pham/cap-nhat",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "Product",
                  action = "Update",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
              name: "auth_product_delete",
              url: "{culture}/quan-tri/danh-sach-san-pham/xoa",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "Product",
                  action = "Delete",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
              name: "auth_productreviews",
              url: "{culture}/quan-tri/danh-sach-review/danh-sach",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "ProductReviews",
                  action = "Index",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
              name: "auth_productreviews_create",
              url: "{culture}/quan-tri/danh-sach-review/tao-moi",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "ProductReviews",
                  action = "Create",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
              name: "auth_productreviews_update",
              url: "{culture}/quan-tri/danh-sach-review/cap-nhat",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "ProductReviews",
                  action = "Update",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
              name: "auth_productreviews_delete",
              url: "{culture}/quan-tri/danh-sach-review/xoa",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "ProductReviews",
                  action = "Delete",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
              name: "auth_productproperties",
              url: "{culture}/quan-tri/danh-sach-thuoc-tinh/danh-sach",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "ProductProperties",
                  action = "Index",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
              name: "auth_productproperties_create",
              url: "{culture}/quan-tri/danh-sach-thuoc-tinh/tao-moi",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "ProductProperties",
                  action = "Create",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
              name: "auth_productproperties_update",
              url: "{culture}/quan-tri/danh-sach-thuoc-tinh/cap-nhat",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "ProductProperties",
                  action = "Update",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
              name: "auth_productproperties_delete",
              url: "{culture}/quan-tri/danh-sach-thuoc-tinh/xoa",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "ProductProperties",
                  action = "Delete",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
              name: "auth_productversion",
              url: "{culture}/quan-tri/danh-sach-version/danh-sach",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "ProductVersions",
                  action = "Index",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
              name: "auth_productversion_create",
              url: "{culture}/quan-tri/danh-sach-version/tao-moi",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "ProductVersions",
                  action = "Create",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
              name: "auth_productversion_update",
              url: "{culture}/quan-tri/danh-sach-version/cap-nhat",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "ProductVersions",
                  action = "Update",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
              name: "auth_productversion_delete",
              url: "{culture}/quan-tri/danh-sach-version/xoa",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "ProductVersions",
                  action = "Delete",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
              name: "auth_users",
              url: "{culture}/quan-tri/danh-sach-user/danh-sach",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "Users",
                  action = "Index",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
              name: "auth_users_promote",
              url: "{culture}/quan-tri/danh-sach-user/promote",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "Users",
                  action = "Promote",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
              name: "auth_users_demote",
              url: "{culture}/quan-tri/danh-sach-user/demote",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "Users",
                  action = "Demote",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
              name: "auth_users_update",
              url: "{culture}/quan-tri/danh-sach-user/cap-nhat",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "Users",
                  action = "Update",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
              name: "auth_users_xoa",
              url: "{culture}/quan-tri/danh-sach-user/xoa",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "Users",
                  action = "Delete",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
              name: "auth_users_active",
              url: "{culture}/quan-tri/danh-sach-user/active",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "Users",
                  action = "Active",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
              name: "auth_htmpagecate",
              url: "{culture}/quan-tri/danh-muc-trang-tinh/danh-sach",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "HtmlPageCategories",
                  action = "Index",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
              name: "auth_htmpagecate_create",
              url: "{culture}/quan-tri/danh-muc-trang-tinh/tao-moi",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "HtmlPageCategories",
                  action = "Create",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
              name: "auth_htmpagecate_update",
              url: "{culture}/quan-tri/danh-muc-trang-tinh/cap-nhat",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "HtmlPageCategories",
                  action = "Update",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );
            //context.MapRoute(
            //    "Auth_default",
            //    "Auth/{controller}/{action}/{id}",
            //    new { action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}