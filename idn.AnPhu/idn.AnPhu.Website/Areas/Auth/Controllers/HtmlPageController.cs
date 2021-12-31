using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace idn.AnPhu.Website.Areas.Auth.Controllers
{
    public class HtmlPageController : Controller
    {
        // GET: Auth/HtmlPage
        public ActionResult Index()
        {
            return View();
        }
    }
}