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
    public class ProductController : AdministratorController
    {
        private ProductManager ProductManager
        {
            get { return ServiceFactory.ProductManager; }
        }

        private PrdCategoriesManager PrdCategoriesManager
        {
            get { return ServiceFactory.PrdCategoriesManager; }
        }

        #region["List sản phẩm"]
        // GET: Auth/Product
        public ActionResult Index(int? page, int? pageSize, string txtSearch = "")
        {
            var pageInfo = new PageInfo<Product>(0, PageSizeAdminConfig);
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

            pageInfo = ProductManager.Search(txtSearch, pageInfo.PageIndex, pageInfo.PageSize);

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

        #region["Tạo mới sản phẩm"]
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Title = "Tạo mới danh mục tin tức";
            ViewBag.Today = Today;
            ViewBag.ListPrdCategories = PrdCategoriesManager.GetAll();
            ViewBag.message = "";
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product model)
        {
            var createBy = "";
            if (UserState != null && !CUtils.IsNullOrEmpty(UserState.UserName))
            {
                createBy = CUtils.StrTrim(UserState.UserName);
            }
            model.CreateBy = createBy;
            var productName = model.ProductName;
            model.ProductCode = productName.Trim().Replace(" ", "-").ToLower();
            try
            {
                ProductManager.Add(model);
                ViewBag.message = "Thêm mới sản phẩm thành công";
                ViewBag.ListPrdCategories = PrdCategoriesManager.GetAll();
                return View(model);
            }
            catch
            {
                ViewBag.message = "Đã có lỗi trong quá trình thêm mới sản phẩm";
                ViewBag.ListPrdCategories = PrdCategoriesManager.GetAll();
                return View(model);
            }

        }
        #endregion

        #region["Thay đổi thông tin sản phẩm"]
        [HttpGet]
        public ActionResult Update(int productId)
        {
            if (CUtils.IsNullOrEmpty(productId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = ProductManager.Get(new Product() { ProductId = productId });

            if (product != null)
            {
                ViewBag.message = "";
                ViewBag.IsEdit = true;
                ViewBag.ListPrdCategories = PrdCategoriesManager.GetAll();
                return View(product);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Product model)
        {
            var message = "";
            if (model != null && !CUtils.IsNullOrEmpty(model.PrdCategoryId))
            {
                var product = ProductManager.Get(new Product() { ProductId = model.ProductId });
                if (product != null)
                {
                    ProductManager.Update(model, product);
                    message = "Cập nhật thông tin sản phẩm thành công!";
                }
                else
                {
                    message = "Mã sản phẩm '" + model.ProductId + "' không có trong hệ thống!";
                }
            }
            else
            {
                message = "Mã sản phẩm trống!";
            }
            ViewBag.message = message;
            ViewBag.IsEdit = true;
            ViewBag.ListPrdCategories = PrdCategoriesManager.GetAll();
            return View(model);


        }

        #endregion
    }
}