using Client.Core.Data.Entities.Paging;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Services;
using idn.AnPhu.Utils;
using idn.AnPhu.Website.Controllers;
using System;
using System.Net;
using System.Web.Mvc;

namespace idn.AnPhu.Website.Areas.Auth.Controllers
{
    public class HtmlPageCategoriesController : AdministratorController
    {
        private HtmlPageCategoriesManager HtmlPageCategoriesManager
        {
            get { return ServiceFactory.HtmlPageCategoriesManager; }
        }

        #region["List danh mục trang tĩnh"]
        // GET: Auth/CategoriesNews
        public ActionResult Index(int? page, int? pageSize, string txtSearch = "")
        {
            var pageInfo = new PageInfo<HtmlPageCategories>(0, PageSizeAdminConfig);
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

            pageInfo = HtmlPageCategoriesManager.Search(txtSearch, pageInfo.PageIndex, pageInfo.PageSize);

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
            return View(pageInfo);
        }
        #endregion

        #region["Tạo mới danh mục trang tĩnh"]
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Title = "Tạo mới danh mục trang tĩnh";
            ViewBag.Today = Today;
            ViewBag.message = "";
            var categories = HtmlPageCategoriesManager.GetAll();
            ViewBag.Categories = new SelectList(categories, "HtmlPageCategoryId", "HlevelTitle");
            return View();
        }

        [HttpPost]
        public ActionResult Create(HtmlPageCategories model)
        {
            try
            {
                var createBy = "";
                if (UserState != null && !CUtils.IsNullOrEmpty(UserState.UserName))
                {
                    createBy = CUtils.StrTrim(UserState.UserName);
                }
                model.CreateBy = createBy;
                HtmlPageCategoriesManager.Add(model);
                var categories = HtmlPageCategoriesManager.GetAll();
                ViewBag.Categories = new SelectList(categories, "HtmlPageCategoryId", "HlevelTitle");
                ViewBag.message = "Tạo mới danh mục trang tĩnh thành công!";
                return View(model);
            }
            catch (Exception e)
            {
                ViewBag.message = "Tạo mới danh mục trang tĩnh thất bại!";
                return View(model);
            }

        }
        #endregion

        #region["Thay đổi thông tin danh mục trang tĩnh"]
        [HttpGet]
        public ActionResult Update(int htmlPageCategoryId)
        {
            if (CUtils.IsNullOrEmpty(htmlPageCategoryId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var newsCategory = HtmlPageCategoriesManager.Get(new HtmlPageCategories() { HtmlPageCategoryId = htmlPageCategoryId });

            if (newsCategory != null)
            {
                var categories = HtmlPageCategoriesManager.GetAll();
                ViewBag.Categories = new SelectList(categories, "HtmlPageCategoryId", "HlevelTitle");
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
        public ActionResult Update(HtmlPageCategories model)
        {
            var message = "";
            if (model != null && !CUtils.IsNullOrEmpty(model.HtmlPageCategoryId))
            {
                var htmlPageCategory = HtmlPageCategoriesManager.Get(new HtmlPageCategories() { HtmlPageCategoryId = model.HtmlPageCategoryId });
                if (htmlPageCategory != null)
                {
                    HtmlPageCategoriesManager.Update(model, htmlPageCategory);
                    message = "Cập nhật thông tin danh mục thành công!";
                }
                else
                {
                    message = "Mã danh mục trang tĩnh '" + model.HtmlPageCategoryId + "' không có trong hệ thống!";
                }
            }
            else
            {
                message = "Mã danh mục trang tĩnh trống!";
            }
            ViewBag.message = message;
            var categories = HtmlPageCategoriesManager.GetAll();
            ViewBag.Categories = new SelectList(categories, "HtmlPageCategoryId", "HlevelTitle");
            ViewBag.IsEdit = true;
            return View(model);


        }

        #endregion
    }
}