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

        #region["List danh mục tin tức"]
        // GET: Auth/CategoriesNews
        public ActionResult Index(int? page, int? pageSize, string txtSearch = "")
        {
            var pageInfo = new PageInfo<NewsCategories>(0, PageSizeAdminConfig);
            if(page != null && pageSize != null)
            {
                pageInfo.PageIndex = (int)page;
                pageInfo.PageSize = (int)pageSize;
            } else
            {
                pageInfo.PageIndex = 1;
                pageInfo.PageSize = 10;
            }
            
            var pageView = "";
            var lastRecord = 0;

            pageInfo = NewsCategoriesManager.Search(txtSearch, pageInfo.PageIndex, pageInfo.PageSize);
            
            if (pageInfo != null && pageInfo.DataList != null && pageInfo.DataList.Count > 0)
            {
                if((pageInfo.PageIndex * pageInfo.PageSize) > pageInfo.ItemCount)
                {
                    lastRecord = pageInfo.ItemCount;
                } else
                {
                    lastRecord = pageInfo.PageIndex * pageInfo.PageSize;
                }
                pageView = "Showing " + ((pageInfo.PageIndex - 1) * pageInfo.PageSize + 1) + " to " + lastRecord + " of " + pageInfo.ItemCount + " entries";
            }

            ViewBag.pageView = pageView;
            var listPageSize = new int[3] { 10, 15, 20 };
            ViewBag.listPageSize = listPageSize;
            return View(pageInfo);
        }
        #endregion

        #region["Tạo mới danh mục tin tức"]
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Title = "Tạo mới danh mục tin tức";
            ViewBag.Today = Today;
            ViewBag.message = "";
            ViewBag.ListCategoriesNews = NewsCategoriesManager.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult Create(NewsCategories model)
        {
            try
            {
                var createBy = "";
                if (UserState != null && !CUtils.IsNullOrEmpty(UserState.UserName))
                {
                    createBy = CUtils.StrTrim(UserState.UserName);
                }
                model.CreateBy = createBy;
                NewsCategoriesManager.Add(model);
                ViewBag.ListCategoriesNews = NewsCategoriesManager.GetAll();
                ViewBag.message = "Tạo mới danh mục tin tức thành công!";
                return View(model);
            } catch (Exception e)
            {
                ViewBag.message = "Tạo mới danh mục tin tức thất bại!";
                return View(model);
            }

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
                ViewBag.IsEdit = true;
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
            ViewBag.ListCategoriesNews = NewsCategoriesManager.GetAll();
            ViewBag.IsEdit = true;
            return View(model);

            
        }

        #endregion
    }
}