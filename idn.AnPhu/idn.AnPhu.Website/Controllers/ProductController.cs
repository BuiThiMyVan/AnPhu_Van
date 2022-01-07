using idn.AnPhu.Biz.Services;
using idn.AnPhu.Website.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace idn.AnPhu.Website.Controllers
{
    public class ProductController : Controller
    {
        private ProductManager ProductManager
        {
            get { return ServiceFactory.ProductManager; }
        }

        private ProductPropertiesManager ProductPropertiesManager
        {
            get { return ServiceFactory.ProductPropertiesManager; }
        }

        private PrdCategoriesManager PrdCategoriesManager
        {
            get { return ServiceFactory.PrdCategoriesManager; }
        }

        private ProductReviewsManager ProductReviewsManager
        {
            get { return ServiceFactory.ProductReviewsManager; }
        }

        // GET: Product
        public ActionResult Index(string shortName)
        {
            var cate = PrdCategoriesManager.GetByShortName(shortName);
            var listProduct = ProductManager.GetByCateId(cate.PrdCategoryId);
            ViewBag.ListProductCategory = PrdCategoriesManager.GetAllActive();
            ViewBag.PrdCategoryId = cate.PrdCategoryId;
            return View(listProduct);
        }

        public ActionResult Details(string productCode)
        {
            var product = ProductManager.GetByCode(productCode);
            ViewBag.ProductProperties = ProductPropertiesManager.GetAllActiveByProductId(product.ProductId);
            ViewBag.ListProductReviews = ProductReviewsManager.GetAllActive(product.ProductId);
            #region["Gallery Products"]

            var sRootGallery = "/UploadFiles/images/products/gallery/" + productCode + "/gallery/";
            if (!Directory.Exists(Server.MapPath(sRootGallery)))
                sRootGallery = "/UploadFiles/images/products/gallery/" + productCode + "/";
            var gaCat = "";
            var gaCatItem = "";
            var galleryCat = ServiceFactory.AppDicDomainManager.GetListAppDicDomainByItemCode("GALLERY_CAT");
            if (galleryCat != null && galleryCat.Count > 0)
            {
                foreach (var gaItem in galleryCat)
                {
                    gaCat += "<li class=\"col-xs-6\">";
                    if (gaItem.Item_Order == 0)
                    {
                        gaCat += "<a href=#" + gaItem.Item_Code + " class=\"nav-link active\" role=\"tab\" data-bs-toggle=\"tab\">" + gaItem.Item_Value + "</a>";
                        gaCatItem += "<div role='tabpanel' class='tab-pane active' id=#" + gaItem.Item_Code + "><div class='row'>" + StringUtils.galleryItemMB(sRootGallery, gaItem.Item_Code.ToLower(), gaItem.Item_Value) + "</div><div class='text-align-center mt16'>1 of 1</div></div>";
                    }
                    else
                    {
                        gaCat += "<a href=\"#" + gaItem.Item_Code + " class=\"nav-link\" role=\"tab\" data-bs-toggle=\"tab\">" + gaItem.Item_Value + "</a>";
                        gaCatItem += "<div role='tabpanel' class='tab-pane' id=#" + gaItem.Item_Code + "><div class='row'>" + StringUtils.galleryItemMB(sRootGallery, gaItem.Item_Code.ToLower(), gaItem.Item_Value) + "</div><div class='text-align-center mt16'>1 of 1</div></div>";
                    }
                    gaCat += "</li>";
                    //var test = StringUtils.galleryItemMB(sRootGallery, gaItem.Item_Code.ToLower(), gaItem.Item_Value);
                    
                }
            }
            ViewBag.gaCat = gaCat;
            ViewBag.gaCatItem = gaCatItem;
            #endregion
            return View(product);
        }
    }
}