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
    public class ImageFootersController : AdministratorController
    {
        private ImageFootersManager ImageFootersManager
        {
            get { return ServiceFactory.ImageFootersManager; }
        }

        #region["List danh mục footer"]
        // GET: Auth/ImageFooters
        public ActionResult Index()
        {
            var model = ImageFootersManager.GetAll();
            return View(model);
        }
        #endregion

        #region["Tạo mới footer"]
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Title = "Tạo mới danh mục footer";
            ViewBag.message = "";
            return View();
        }

        [HttpPost]
        public ActionResult Create(ImageFooters model)
        {
            var createBy = "";
            if (UserState != null && !CUtils.IsNullOrEmpty(UserState.UserName))
            {
                createBy = CUtils.StrTrim(UserState.UserName);
                model.CreateBy = createBy;
            }
            try
            {
                ImageFootersManager.Add(model);
                ViewBag.message = "Thêm mới footer thành công";
                return View(model);
            }
            catch (Exception e)
            {
                ViewBag.message = "Thêm mới footer thất bại";
                ViewBag.ListCategoriesImageFooters = ImageFootersManager.GetAll();
                return View(model);

            }


        }
        #endregion

        #region["Thay đổi thông tin footer"]
        [HttpGet]
        public ActionResult Update(int id)
        {
            if (CUtils.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ImageFooters = ImageFootersManager.Get(new ImageFooters() { ID = id });

            if (ImageFooters != null)
            {
                ViewBag.message = "";
                ViewBag.IsEdit = true;
                return View(ImageFooters);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ImageFooters model)
        {
            var message = "";
            if (model != null && !CUtils.IsNullOrEmpty(model.ID))
            {
                var ImageFooters = ImageFootersManager.Get(new ImageFooters() { ID = model.ID });
                if (ImageFooters != null)
                {
                    ImageFootersManager.Update(model, ImageFooters);
                    message = "Cập nhật footer thành công!";
                }
                else
                {
                    message = "Mã footer '" + model.ID + "' không có trong hệ thống!";
                }
            }
            else
            {
                message = "Mã footer trống!";
            }
            ViewBag.message = message;
            ViewBag.IsEdit = true;
            return View(model);
        }

        #endregion

        #region["Xóa footer"]
        [HttpGet]
        public ActionResult Delete(int ID)
        {
            if (CUtils.IsNullOrEmpty(ID))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                ImageFootersManager.Remove(new ImageFooters() { ID = ID });
                //ViewBag.message = "Xóa footer mã " + ImageFootersId + "thành công";
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