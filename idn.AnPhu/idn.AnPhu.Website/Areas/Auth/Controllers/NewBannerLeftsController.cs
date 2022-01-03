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
    public class NewBannerLeftsController : AdministratorController
    {
        private NewBannerLeftsManager NewBannerLeftsManager
        {
            get { return ServiceFactory.NewBannerLeftsManager; }
        }
        public ActionResult Index()
        {
            try
            {
                List<NewBannerLefts> model = new List<NewBannerLefts>();
                model = NewBannerLeftsManager.GetAll();
                ViewBag.message = "";
                return View(model);
            }
            catch (Exception e)
            {
                ViewBag.message = e.Message;
                return View();
            }
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            if (CUtils.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var banner = NewBannerLeftsManager.Get(new NewBannerLefts() { NewLeftId = id });

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
        public ActionResult Update(NewBannerLefts model)
        {
            var message = "";
            if (model != null && !CUtils.IsNullOrEmpty(model.NewLeftId))
            {
                var popup = NewBannerLeftsManager.Get(new NewBannerLefts() { NewLeftId = model.NewLeftId });
                if (popup != null)
                {
                    NewBannerLeftsManager.Update(model, popup);
                    message = "Cập nhật New Banner Left thành công!";
                }
                else
                {
                    message = "New Banner Left không có trong hệ thống!";
                }
            }
            else
            {
                message = "New Banner Left trống!";
            }
            ViewBag.message = message;
            return View(model);
        }

    }
}