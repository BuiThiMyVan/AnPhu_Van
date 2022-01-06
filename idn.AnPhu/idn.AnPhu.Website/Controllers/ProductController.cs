using idn.AnPhu.Biz.Services;
using System;
using System.Collections.Generic;
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
            return View(product);
        }
    }
}