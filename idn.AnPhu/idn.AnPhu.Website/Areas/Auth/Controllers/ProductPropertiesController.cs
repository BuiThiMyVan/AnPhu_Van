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
    public class ProductPropertiesController : AdministratorController
    {
        private ProductPropertiesManager ProductPropertiesManager
        {
            get { return ServiceFactory.ProductPropertiesManager; }
        }

        #region["List danh sách review"]
        public ActionResult Index(int productId, int? page, int? pageSize, string txtSearch = "")
        {
            var pageInfo = new PageInfo<ProductProperties>(0, PageSizeAdminConfig);
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

            pageInfo = ProductPropertiesManager.Search(productId, txtSearch, pageInfo.PageIndex, pageInfo.PageSize);

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
        public ActionResult Create(ProductProperties model)
        {
            try
            {
                ProductPropertiesManager.Add(model);
                ViewBag.message = "Thêm mới thuộc tính thành công";
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
        public ActionResult Update(int productId, int productPropertyId)
        {
            if (CUtils.IsNullOrEmpty(productPropertyId) || CUtils.IsNullOrEmpty(productId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var property = ProductPropertiesManager.Get(new ProductProperties() { ProductPropertyId = productPropertyId, ProductId = productId });

            if (property != null)
            {
                ViewBag.message = "";
                ViewBag.IsEdit = true;
                return View(property);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ProductProperties model)
        {
            var message = "";
            if (model != null && !CUtils.IsNullOrEmpty(model.ProductPropertyId))
            {
                var property = ProductPropertiesManager.Get(new ProductProperties() { ProductPropertyId = model.ProductPropertyId });
                if (property != null)
                {
                    ProductPropertiesManager.Update(model, property);
                    message = "Cập nhật thông tin thuộc tính thành công!";
                }
                else
                {
                    message = "Mã thuộc tính '" + model.ProductPropertyId + "' không có trong hệ thống!";
                }
            }
            else
            {
                message = "Mã thuộc tính xe trống!";
            }
            ViewBag.message = message;
            ViewBag.IsEdit = true;
            return View(model);
        }

        #endregion

        #region["Xóa bài review"]
        [HttpGet]
        public ActionResult Delete(int propertyId)
        {
            if (CUtils.IsNullOrEmpty(propertyId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                ProductPropertiesManager.Remove(new ProductProperties() { ProductPropertyId = propertyId });
                ViewBag.message = "Xóa thuộc tính mã " + propertyId + "thành công";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.message = "Xóa thuộc tính mã " + propertyId + "thất bại";
                return RedirectToAction("Index");
            }
        }
        #endregion
    }
}