using Client.Core.Data.Entities.Paging;
using Client.Core.Utils;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Services;
using idn.AnPhu.Utils;
using idn.AnPhu.Website.Controllers;
using idn.AnPhu.Website.Models;
using idn.AnPhu.Website.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace idn.AnPhu.Website.Areas.Auth.Controllers
{
    public class CategoriesNewsController : AdministratorController
    {
        private NewsCategoriesManager NewsCategoriesManager
        {
            get { return ServiceFactory.NewsCategoriesManager; }
        }

        // GET: Auth/CategoriesNews
        public ActionResult Index(string txtSearch = "", string init = "init", int page = 0)
        {
            var startCount = "0";
            var pageInfo = new PageInfo<NewsCategories>(0, PageSizeAdminConfig);
            if (init != "init")
            {
                //pageInfo = NewsCategoriesManager.Search(txtSearch, );
                if (pageInfo != null && pageInfo.DataList != null && pageInfo.DataList.Count > 0)
                {
                    startCount = (page * PageSizeAdminConfig).ToString();
                }
            }
            else
            {
                //createdtimefrom = CUtils.GetDateToSearch(DateTime.Now.ToString("yyyy-MM-dd"));
            }


            ViewBag.StartCount = startCount;
            return View(pageInfo);
        }

        #region["Tạo mới danh mục tin tức"]
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Title = "Tạo mới danh mục tin tức";
            ViewBag.Today = Today;
            ViewBag.ListCategoriesNews = NewsCategoriesManager.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewsCategories model)
        {
            var resultEntry = new JsonResultEntry() { Success = false };

            var createBy = "";
            if (UserState != null && !CUtils.IsNullOrEmpty(UserState.UserName))
            {
                createBy = CUtils.StrTrim(UserState.UserName);
            }
            model.CreateBy = createBy;
            NewsCategoriesManager.Add(model);
            resultEntry.Success = true;
            resultEntry.AddMessage("Tạo mới danh mục tin tức thành công!");

            return RedirectToAction("Index");
        }
        #endregion

        #region["Thay đổi thông tin danh mục tin tức"]
        [HttpGet]
        public ActionResult Update(int newsCategoryId)
        {
            if (CUtils.IsNullOrEmpty(newsCategoryId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var newsCategory = NewsCategoriesManager.Get(new NewsCategories() { NewsCategoryId = newsCategoryId });

            if (newsCategory != null)
            {
                ViewBag.ListCategoriesNews = NewsCategoriesManager.GetAll();
                ViewBag.message = "";
                return View(newsCategory);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(NewsCategories model)
        {
            var message = "";
            if(ModelState.IsValid)
            {
                if (model != null && !CUtils.IsNullOrEmpty(model.NewsCategoryId))
                {
                    var newsCategories = NewsCategoriesManager.Get(new NewsCategories() { NewsCategoryId = model.NewsCategoryId });
                    if (newsCategories != null)
                    {
                        NewsCategoriesManager.Update(model, newsCategories);
                        message = "Cập nhật thông tin danh mục thành công!";
                    }
                    else
                    {
                        message = "Mã danh mục tin tức '" + model.NewsCategoryId + "' không có trong hệ thống!";
                    }
                }
                else
                {
                    message = "Mã danh mục tin tức trống!";
                }
                ViewBag.message = message;
                return RedirectToAction("Index");
            }
            return View();
            
        }

        #endregion
    }
}