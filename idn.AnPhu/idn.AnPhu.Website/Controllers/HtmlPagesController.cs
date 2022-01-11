using idn.AnPhu.Biz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace idn.AnPhu.Website.Controllers
{
    public class HtmlPagesController : Controller
    {
        private HtmlPagesManager HtmlPagesManager
        {
            get { return ServiceFactory.HtmlPagesManager; }
        }
        // GET: HtmlPages
        public ActionResult Index(string shortName)
        {
            try
            {
                var model = HtmlPagesManager.GetByShortName(shortName);
                return View(model);
            } catch
            {
                return HttpNotFound();
            }
            
        }
    }
}