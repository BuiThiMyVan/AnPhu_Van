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
    public class NewBannerRightsController : AdministratorController
    {
        private NewBannerRightsManager NewBannerRightsManager
        {
            get { return ServiceFactory.NewBannerRightsManager; }
        }
        // GET: Auth/PopupAdvertisement
        public ActionResult Index()
        {
            try
            {
                List<NewBannerRights> model = new List<NewBannerRights>();
                model = NewBannerRightsManager.GetAll();
                ViewBag.message = "";
                return View(model);
            }
            catch (Exception e)
            {
                ViewBag.message = e.Message;
                return View();
            }
        }

        #region["Thay đổi thông tin popup quảng cáo"]
        [HttpGet]
        public ActionResult Update(int id)
        {
            if (CUtils.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var banner = NewBannerRightsManager.Get(new NewBannerRights() { NewRightId = id });

            if (banner != null)
            {
                ViewBag.message = "";
                return View(banner);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(NewBannerRights model)
        {
            var message = "";
            if (model != null && !CUtils.IsNullOrEmpty(model.NewRightId))
            {
                var popup = NewBannerRightsManager.Get(new NewBannerRights() { NewRightId = model.NewRightId });
                if (popup != null)
                {
                    NewBannerRightsManager.Update(model, popup);
                    message = "Cập nhật New Banner Right thành công!";
                }
                else
                {
                    message = "New Banner Right không có trong hệ thống!";
                }
            }
            else
            {
                message = "New Banner Right trống!";
            }
            ViewBag.message = message;
            return View(model);
        }

        #endregion
    }
}