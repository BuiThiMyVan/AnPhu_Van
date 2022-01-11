using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace idn.AnPhu.Website.Controllers
{
    public class HomeController : Controller
    {
        private ProductManager ProductManager
        {
            get { return ServiceFactory.ProductManager; }
        }

        private PrdCategoriesManager PrdCategoriesManager
        {
            get { return ServiceFactory.PrdCategoriesManager; }
        }

        private NewsManager NewsManager
        {
            get { return ServiceFactory.NewsManager; }
        }

        // GET: Home
        public ActionResult Index()
        {
            //var listProduct = new List<Product>();
            //if(shortName == "")
            //{
            //    var listProduct = ProductManager.GetAll();
            //}
           //var cate = PrdCategoriesManager.GetByShortName(shortName);
           //var listProduct = ProductManager.GetByCateId(cate.PrdCategoryId);
           //ViewBag.ListProductCategory = PrdCategoriesManager.GetAllActive();
            ViewBag.NewsHot = NewsManager.GetHot(4);
            ViewBag.ListProductCategory = PrdCategoriesManager.GetAllActive();
            return View();
        }
    }
}