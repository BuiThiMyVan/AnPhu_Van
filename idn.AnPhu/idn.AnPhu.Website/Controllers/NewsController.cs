using Client.Core.Data.Entities.Paging;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace idn.AnPhu.Website.Controllers
{
    public class NewsController : Controller
    {
        private NewsManager NewsManager
        {
            get { return ServiceFactory.NewsManager; }
        }

        private NewsCategoriesManager NewsCategoriesManager
        {
            get { return ServiceFactory.NewsCategoriesManager; }
        }
        // GET: News
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowCateNews(string shortName, int page)
        {
            try
            {
                var pageInfo = new PageInfo<News>(0, 6);
                var newsCategory = NewsCategoriesManager.GetByShortName(shortName);
                pageInfo = NewsManager.SearchUsersSide(newsCategory.NewsCategoryId, page);
                ViewBag.NewsCategoryTitle = newsCategory.NewsCategoryTitle;
                ViewBag.NewsCategoryShortName = newsCategory.NewsCategoryShortName;
                ViewBag.NewsHot = NewsManager.GetHot(4);
                return View(pageInfo);
            } catch
            {
                return HttpNotFound();
            }
            
        }

        public ActionResult Details(int id)
        {
            var model = NewsManager.Get(new News { NewsId = id });
            var category = NewsCategoriesManager.Get(new NewsCategories { NewsCategoryId = model.NewsCategoryId });
            ViewBag.NewsCategoryTitle = category.NewsCategoryTitle;
            ViewBag.NewsHot = NewsManager.GetHot(4);
            return View(model);
        }
    }
}