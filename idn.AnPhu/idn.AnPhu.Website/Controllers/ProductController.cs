using idn.AnPhu.Biz.Services;
using idn.AnPhu.Website.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace idn.AnPhu.Website.Controllers
{
    public class ProductController : Controller
    {
        private ProductManager ProductManager
        {
            get { return ServiceFactory.ProductManager; }
        }

        private ProductPropertiesManager ProductPropertiesManager
        {
            get { return ServiceFactory.ProductPropertiesManager; }
        }

        private PrdCategoriesManager PrdCategoriesManager
        {
            get { return ServiceFactory.PrdCategoriesManager; }
        }

        private ProductReviewsManager ProductReviewsManager
        {
            get { return ServiceFactory.ProductReviewsManager; }
        }

        // GET: Product
        public ActionResult Index(string shortName)
        {
            var cate = PrdCategoriesManager.GetByShortName(shortName);
            var listProduct = ProductManager.GetByCateId(cate.PrdCategoryId);
            ViewBag.ListProductCategory = PrdCategoriesManager.GetAllActive();
            ViewBag.PrdCategoryId = cate.PrdCategoryId;
            return View(listProduct);
        }

        public ActionResult Details(string productCode)
        {
            var product = ProductManager.GetByCode(productCode);
            ViewBag.ProductProperties = ProductPropertiesManager.GetAllActiveByProductId(product.ProductId);
            ViewBag.ListProductReviews = ProductReviewsManager.GetAllActive(product.ProductId);
            #region["Gallery Products"]

            var sRootGallery = "/UploadFiles/images/products/gallery/" + productCode + "/gallery/";
            if (!Directory.Exists(Server.MapPath(sRootGallery)))
                sRootGallery = "/UploadFiles/images/products/gallery/" + productCode + "/";
            var gaCat = "";
            var gaCatItem = "";
            var galleryCat = ServiceFactory.AppDicDomainManager.GetListAppDicDomainByItemCode("GALLERY_CAT");
            if (galleryCat != null && galleryCat.Count > 0)
            {
                foreach (var gaItem in galleryCat)
                {
                    gaCat += "<li class=\"col-xs-6\">";
                    if (gaItem.Item_Order == 0)
                    {
                        gaCat += "<a href='#" + gaItem.Item_Code + "' class='nav-link active' role='tab' data-bs-toggle='tab'>" + gaItem.Item_Value + "</a>";
                        gaCatItem += "<div role='tabpanel' class='tab-pane active' id=" + gaItem.Item_Code + "><div class='row'>" + StringUtils.galleryItemMB(sRootGallery, gaItem.Item_Code.ToLower(), gaItem.Item_Value) + "</div><div class='text-align-center mt16'>1 of 1</div></div>";
                    }
                    else
                    {
                        gaCat += "<a href='#" + gaItem.Item_Code + "' class='nav-link' role='tab' data-bs-toggle='tab'>" + gaItem.Item_Value + "</a>";
                        gaCatItem += "<div role='tabpanel' class='tab-pane' id=" + gaItem.Item_Code + "><div class='row'>" + StringUtils.galleryItemMB(sRootGallery, gaItem.Item_Code.ToLower(), gaItem.Item_Value) + "</div><div class='text-align-center mt16'>1 of 1</div></div>";
                    }
                    gaCat += "</li>";
                    //var test = StringUtils.galleryItemMB(sRootGallery, gaItem.Item_Code.ToLower(), gaItem.Item_Value);
                    
                }
            }
            ViewBag.gaCat = gaCat;
            ViewBag.gaCatItem = gaCatItem;
            #endregion
            #region["360"]
            var variablesScript = "";
            var sRootExperience = "~/UploadFiles/images/products/360/" + productCode;
            var sRootColor = "~/UploadFiles/images/products/360";
            string[] arrExDir = null;
            string[] arrInDir = null;
            if (Directory.Exists(Server.MapPath(sRootExperience + "/experience")))
            {
                sRootExperience = sRootExperience + "/experience";
                arrExDir = Directory.GetDirectories(Server.MapPath(sRootExperience), "ex_*");
                arrInDir = Directory.GetDirectories(Server.MapPath(sRootExperience), "i*");
                //
                sRootColor += "/experience";
            }
            else if (Directory.Exists(Server.MapPath(sRootExperience + "")))
            {
                arrExDir = Directory.GetDirectories(Server.MapPath(sRootExperience), "ex_*");
                arrInDir = Directory.GetDirectories(Server.MapPath(sRootExperience), "i*");
            }
            if (arrExDir != null && arrInDir != null)
            {
                String exScript = "";
                foreach (String sDir in arrExDir)
                {
                    if (exScript.Length > 0) exScript += ",";
                    exScript += "{";
                    exScript += "Code:'" + Path.GetFileName(sDir) + "'";
                    String[] arrColor = System.IO.File.ReadAllLines(sDir + "//" + Path.GetFileName(sDir) + ".txt");
                    if (arrColor.Length > 0)
                        exScript += ",NameVN:'" + arrColor[0] + "'";
                    else
                        exScript += ",NameVN:''";
                    if (arrColor.Length > 1)
                        exScript += ",NameEN:'" + arrColor[1] + "'";
                    else
                        exScript += ",NameEN:''";
                    exScript += "}";
                }
                String inScript = "";
                foreach (String sDir in arrInDir)
                {
                    if (inScript.Length > 0) inScript += ",";
                    inScript += "{";
                    inScript += "Code:'" + Path.GetFileName(sDir) + "'";
                    String[] arrColor = System.IO.File.ReadAllLines(sDir + "//" + Path.GetFileName(sDir) + ".txt");
                    if (arrColor.Length > 0)
                        inScript += ",NameVN:'" + arrColor[0] + "'";
                    else
                        inScript += ",NameVN:''";
                    if (arrColor.Length > 1)
                        inScript += ",NameEN:'" + arrColor[1] + "'";
                    else
                        inScript += ",NameEN:''";
                    inScript += "}";
                }

                //variablesScript = "<script type=\"text/javascript\">  //<![CDATA[";
                variablesScript += "var iExtCount= " + arrExDir.Length + "; var iIntCount=" + arrInDir.Length + "; var expRoot= '" + Url.Content(sRootExperience) + "'; var colorRoot = '" + Url.Content(sRootColor) + "'; var arrExt = [" + exScript + "]; var arrInt = [" + inScript + "];";
                //variablesScript += "//]]></script>";

            }
            ViewBag.variablesScript = variablesScript;
            if (arrInDir == null)
            {
                ViewBag.isInterior = false;
            }
            else
            {
                if (arrInDir.Length == 0)
                {
                    ViewBag.isInterior = false;
                }
                else
                {
                    ViewBag.isInterior = true;
                }
            }
            if (arrExDir == null)
            {
                ViewBag.isExterior = false;
            }
            else
            {
                if (arrExDir.Length == 0)
                {
                    ViewBag.isExterior = false;
                }
                else
                {
                    ViewBag.isExterior = true;
                }
            }


            #endregion
            #region["Thong so ky thuat"]
            var sFile = string.Format("~/tempfiles/uploads/products/html/{0}_{1}.htm", product.ProductCode.Replace('-', '_'), "spec");
            var contentFile = StringUtils.File_Read(sFile);
            ViewBag.contentFile = !String.IsNullOrEmpty(contentFile) ? contentFile : "";
            #endregion
            return View(product);
        }
    }
}