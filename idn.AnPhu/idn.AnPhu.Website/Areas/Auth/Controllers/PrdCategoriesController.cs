using Client.Core.Data.Entities.Paging;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Services;
using idn.AnPhu.Utils;
using idn.AnPhu.Website.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace idn.AnPhu.Website.Areas.Auth.Controllers
{
    public class PrdCategoriesController : AdministratorController
    {
        private PrdCategoriesManager PrdCategoriesManager
        {
            get { return ServiceFactory.PrdCategoriesManager; }
        }

        #region["List thuộc tính xe"]
        // GET: Auth/PrdCategories
        public ActionResult Index(int? page, int? pageSize, string txtSearch = "")
        {
            var pageInfo = new PageInfo<PrdCategories>(0, PageSizeAdminConfig);
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

            pageInfo = PrdCategoriesManager.Search(txtSearch, pageInfo.PageIndex, pageInfo.PageSize);

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

        #region["Tạo mới loại xe"]
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Title = "Tạo mới thuộc tính";
            ViewBag.Today = Today;
            ViewBag.message = "";
            ViewBag.ListPrdCategories = PrdCategoriesManager.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult Create(PrdCategories model)
        {
            var createBy = "";
            if (UserState != null && !CUtils.IsNullOrEmpty(UserState.UserName))
            {
                createBy = CUtils.StrTrim(UserState.UserName);
            }
            model.CreateBy = createBy;

            try
            {
                PrdCategoriesManager.Add(model);
                ViewBag.message = "Thêm mới loại xe thành công";
                ViewBag.ListPrdCategories = PrdCategoriesManager.GetAll();
                return View(model);
            } catch
            {
                ViewBag.message = "Đã có lỗi trong quá trình thêm mới loại xe";
                ViewBag.ListPrdCategories = PrdCategoriesManager.GetAll();
                return View(model);
            }

        }
        #endregion

        #region["Thay đổi thông tin loại xe"]
        [HttpGet]
        public ActionResult Update(int prdCategoryId)
        {
            if (CUtils.IsNullOrEmpty(prdCategoryId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var prdCategory = PrdCategoriesManager.Get(new PrdCategories() { PrdCategoryId = prdCategoryId });

            if (prdCategory != null)
            {
                ViewBag.ListPrdCategories = PrdCategoriesManager.GetAll();
                ViewBag.message = "";
                ViewBag.IsEdit = true;
                return View(prdCategory);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(PrdCategories model)
        {
            var message = "";
            if (model != null && !CUtils.IsNullOrEmpty(model.PrdCategoryId))
            {
                var prdCategories = PrdCategoriesManager.Get(new PrdCategories() { PrdCategoryId = model.PrdCategoryId });
                if (prdCategories != null)
                {
                    PrdCategoriesManager.Update(model, prdCategories);
                    message = "Cập nhật thông tin loại xe thành công!";
                }
                else
                {
                    message = "Mã loại xe '" + model.PrdCategoryId + "' không có trong hệ thống!";
                }
            }
            else
            {
                message = "Mã loại xe trống!";
            }
            ViewBag.message = message;
            ViewBag.ListPrdCategories = PrdCategoriesManager.GetAll();
            ViewBag.IsEdit = true;
            return View(model);


        }

        #endregion
    }
}