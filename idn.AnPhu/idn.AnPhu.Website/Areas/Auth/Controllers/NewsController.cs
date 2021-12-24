﻿using Client.Core.Data.Entities.Paging;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Services;
using idn.AnPhu.Utils;
using idn.AnPhu.Website.Controllers;
using idn.AnPhu.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace idn.AnPhu.Website.Areas.Auth.Controllers
{
    public class NewsController : AdministratorController
    {
        private NewsManager NewsManager
        {
            get { return ServiceFactory.NewsManager; }
        }

        private NewsCategoriesManager NewsCategoriesManager
        {
            get { return ServiceFactory.NewsCategoriesManager; }
        }

        #region["List danh mục tin tức"]
        // GET: Auth/CategoriesNews
        public ActionResult Index(int? page, int? pageSize, string txtSearch = "")
        {
            var pageInfo = new PageInfo<News>(0, PageSizeAdminConfig);
            if (page != null && pageSize != null)
            {
                pageInfo.PageIndex = (int)page;
                pageInfo.PageSize = (int)pageSize;
            }
            else
            {
                pageInfo.PageIndex = 1;
                pageInfo.PageSize = 10;
            }

            var pageView = "";
            var lastRecord = 0;

            pageInfo = NewsManager.Search(txtSearch, pageInfo.PageIndex, pageInfo.PageSize);

            if (pageInfo != null && pageInfo.DataList != null && pageInfo.DataList.Count > 0)
            {
                if ((pageInfo.PageIndex * pageInfo.PageSize) > pageInfo.ItemCount)
                {
                    lastRecord = pageInfo.ItemCount;
                }
                else
                {
                    lastRecord = pageInfo.PageIndex * pageInfo.PageSize;
                }
                pageView = "Showing " + ((pageInfo.PageIndex - 1) * pageInfo.PageSize + 1) + " to " + lastRecord + " of " + pageInfo.ItemCount + " entries";
            }

            ViewBag.pageView = pageView;
            var listPageSize = new int[3] { 10, 15, 20 };
            ViewBag.listPageSize = listPageSize;
            ViewBag.txtSearch = txtSearch;
            ViewBag.message = "";
            return View(pageInfo);
        }
        #endregion

        #region["Tạo mới tin tức"]
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Title = "Tạo mới danh mục tin tức";
            ViewBag.Today = Today;
            ViewBag.ListCategoriesNews = NewsCategoriesManager.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult Create(News model)
        {
            var createBy = "";
            if (UserState != null && !CUtils.IsNullOrEmpty(UserState.UserName))
            {
                createBy = CUtils.StrTrim(UserState.UserName);
                model.CreateBy = createBy;
            }
            try
            {
                NewsManager.Add(model);
                //ViewBag.message = "Thêm mới tin tức thành công";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction("Index");
            }


        }
        #endregion

        #region["Thay đổi thông tin tin tức"]
        [HttpGet]
        public ActionResult Update(int newsId)
        {
            if (CUtils.IsNullOrEmpty(newsId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var news = NewsManager.Get(new News() { NewsId = newsId });

            if (news != null)
            {
                //ViewBag.Categories = new SelectList(NewsCategoriesManager.GetAll(), "NewsCategoryId", "HlevelTitle");
                ViewBag.ListCategoriesNews = NewsCategoriesManager.GetAll();
                ViewBag.message = "";
                ViewBag.IsEdit = true;
                return View(news);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(News model)
        {
            var message = "";
            if (model != null && !CUtils.IsNullOrEmpty(model.NewsCategoryId))
            {
                var news = NewsManager.Get(new News() { NewsId = model.NewsId });
                if (news != null)
                {
                    NewsManager.Update(model, news);
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

        #region["Xóa tin tức"]
        [HttpGet]
        public ActionResult Delete(int newsId)
        {
            if (CUtils.IsNullOrEmpty(newsId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            try
            {
                NewsManager.Remove(new News() { NewsId = newsId });
                //ViewBag.message = "Xóa tin tức mã " + newsId + "thành công";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction("Index");
            }
        }
        #endregion
    }
}