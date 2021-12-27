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
    public class ProductVersionsController : AdministratorController
    {
        private ProductVersionsManager ProductVersionsManager
        {
            get { return ServiceFactory.ProductVersionsManager; }
        }

        #region["List danh sách review"]
        public ActionResult Index(int productId, int? page, int? pageSize, string txtSearch = "")
        {
            var pageInfo = new PageInfo<ProductVersions>(0, PageSizeAdminConfig);
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

            pageInfo = ProductVersionsManager.Search(productId, txtSearch, pageInfo.PageIndex, pageInfo.PageSize);

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

        #region["Tạo mới bài review"]
        [HttpGet]
        public ActionResult Create(int productId)
        {
            ViewBag.Today = Today;
            ViewBag.ProductId = productId;
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductVersions model)
        {
            var createBy = "";
            if (UserState != null && !CUtils.IsNullOrEmpty(UserState.UserName))
            {
                createBy = CUtils.StrTrim(UserState.UserName);
                model.CreateBy = createBy;
            }
            try
            {
                ProductVersionsManager.Add(model);
                ViewBag.message = "Thêm mới bài đánh giá thành công";
                ViewBag.ProductId = model.ProductId;
                return View(model);
            }
            catch (Exception e)
            {
                ViewBag.message = "Đã xảy ra lỗi khi thêm mới bài đánh giá";
                ViewBag.ProductId = model.ProductId;
                return View(model);
            }


        }
        #endregion

        #region["Thay đổi thông tin bài review"]
        [HttpGet]
        public ActionResult Update(int productId, int versionId)
        {
            if (CUtils.IsNullOrEmpty(versionId) || CUtils.IsNullOrEmpty(productId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var review = ProductVersionsManager.Get(new ProductVersions() { VersionId = versionId, ProductId = productId });

            if (review != null)
            {
                ViewBag.message = "";
                ViewBag.IsEdit = true;
                return View(review);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ProductVersions model)
        {
            var message = "";
            if (model != null && !CUtils.IsNullOrEmpty(model.VersionId))
            {
                var review = ProductVersionsManager.Get(new ProductVersions() { VersionId = model.VersionId });
                if (review != null)
                {
                    ProductVersionsManager.Update(model, review);
                    message = "Cập nhật thông tin phiên bản thành công!";
                }
                else
                {
                    message = "Mã phiên bản '" + model.VersionId + "' không có trong hệ thống!";
                }
            }
            else
            {
                message = "Mã phiên bản trống!";
            }
            ViewBag.message = message;
            ViewBag.IsEdit = true;
            return View(model);
        }

        #endregion

        #region["Xóa bài review"]
        [HttpGet]
        public ActionResult Delete(int versionId)
        {
            if (CUtils.IsNullOrEmpty(versionId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                ProductVersionsManager.Remove(new ProductVersions() { VersionId = versionId });
                ViewBag.message = "Xóa phiên bản mã " + versionId + "thành công";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.message = "Xóa phiên bản mã " + versionId + "thất bại";
                return RedirectToAction("Index");
            }
        }
        #endregion
    }
}