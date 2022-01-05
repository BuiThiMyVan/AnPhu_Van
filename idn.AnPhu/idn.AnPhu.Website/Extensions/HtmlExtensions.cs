using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using Client.Core.Extensions;
using Client.Core.Localization;
using idn.AnPhu.Constants;
using idn.AnPhu.Utils;

namespace idn.AnPhu.Website.Extensions
{
    public static class HtmlExtensions
    {
        #region Views
        public static string RenderPartialViewToString(Controller controller, string viewName, object model)
        {

            controller.ViewData.Model = model;
            try
            {
                using (StringWriter sw = new StringWriter())
                {
                    ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
                    ViewContext viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
                    viewResult.View.Render(viewContext, sw);

                    return sw.GetStringBuilder().ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public static string RenderPartialViewToString(ControllerContext context, string viewName, object model, ViewDataDictionary viewdata)
        {
            try
            {
                using (StringWriter sw = new StringWriter())
                {
                    ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(context, viewName);
                    ViewContext viewContext = new ViewContext(context, viewResult.View, viewdata, context.Controller.TempData, sw);
                    viewResult.View.Render(viewContext, sw);

                    return sw.GetStringBuilder().ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        #endregion

        #region ActionLink Localized
        /// <summary>
        /// Returns an anchor element (a element) that contains the virtual path of the specified action, with localized anchor text.
        /// </summary>
        public static MvcHtmlString ActionLinkLocalized(this HtmlHelper htmlHelper, string neutralLinkText, string actionName, string controllerName)
        {
            string cultureName = System.Globalization.CultureInfo.CurrentCulture.ToString();
            var linkText = Localizer.GetCurrent(cultureName).Get(neutralLinkText);
            return htmlHelper.ActionLink(linkText, actionName, controllerName);
        }

        /// <summary>
        /// Returns an anchor element (a element) that contains the virtual path of the specified action, with localized anchortext.
        /// </summary>
        public static MvcHtmlString ActionLinkLocalized(this HtmlHelper htmlHelper, string neutralLinkText, string actionName)
        {
            string cultureName = System.Globalization.CultureInfo.CurrentCulture.ToString();
            var linkText = Localizer.GetCurrent(cultureName).Get(neutralLinkText);
            return htmlHelper.ActionLink(linkText, actionName);
        }

        /// <summary>
        /// Returns an anchor element (a element) that contains the virtual path of the specified action, with localized anchor text.
        /// </summary>
        public static MvcHtmlString ActionLinkLocalized(this HtmlHelper htmlHelper, string neutralLinkText, string actionName, object routeValues)
        {
            string cultureName = System.Globalization.CultureInfo.CurrentCulture.ToString();
            var linkText = Localizer.GetCurrent(cultureName).Get(neutralLinkText);
            return htmlHelper.ActionLink(linkText, actionName, routeValues);
        }

        /// <summary>
        /// Returns an anchor element (a element) that contains the virtual path of the specified action, with localized anchor text.
        /// </summary>
        public static MvcHtmlString ActionLinkLocalized(this HtmlHelper htmlHelper, string neutralLinkText, string actionName, string controllerName, object routeValues, object htmlAttributes)
        {
            string cultureName = System.Globalization.CultureInfo.CurrentCulture.ToString();
            var linkText = Localizer.GetCurrent(cultureName).Get(neutralLinkText);
            return htmlHelper.ActionLink(linkText, actionName, controllerName, routeValues, htmlAttributes);
        }

        /// <summary>
        /// Returns an anchor element (a element) that contains the virtual path of the specified action, with localized anchor text.
        /// </summary>
        public static MvcHtmlString ActionLinkLocalized(this HtmlHelper htmlHelper, string neutralLinkText, string actionName, object routeValues, object htmlAttributes)
        {
            string cultureName = System.Globalization.CultureInfo.CurrentCulture.ToString();
            var linkText = Localizer.GetCurrent(cultureName).Get(neutralLinkText);
            return htmlHelper.ActionLink(linkText, actionName, routeValues, htmlAttributes);
        }
        #endregion

        public static MvcHtmlString DropDownListDefault(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, object defaultValue, string defaultText, object htmAttribute = null)
        {
            List<SelectListItem> list = new List<SelectListItem>(selectList);
            SelectListItem item = new SelectListItem();
            item.Text = defaultText;
            item.Value = defaultValue.ToString();
            list.Insert(0, item);
            return htmlHelper.DropDownList(name, list, htmAttribute);
        }

        public static MvcHtmlString CanonicalUrl(this HtmlHelper html, string path)
        {
            if (String.IsNullOrWhiteSpace(path))
            {
                var rawUrl = html.ViewContext.RequestContext.HttpContext.Request.Url;
                path = String.Format("{0}://{1}{2}", rawUrl.Scheme, rawUrl.Host, rawUrl.AbsolutePath);
            }

            path = path.ToLower();

            if (path.Count(c => c == '/') > 3)
            {
                path = path.TrimEnd('/');
            }

            if (path.EndsWith("/index"))
            {
                path = path.Substring(0, path.Length - 6);
            }

            var canonical = new TagBuilder("link");
            canonical.MergeAttribute("rel", "canonical");
            canonical.MergeAttribute("href", path);
            return new MvcHtmlString(canonical.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString CanonicalUrl(this HtmlHelper html)
        {
            var rawUrl = html.ViewContext.RequestContext.HttpContext.Request.Url;
            if (rawUrl.Host.Contains("www"))
            {
                return CanonicalUrl(html, String.Format("{0}://{1}{2}", rawUrl.Scheme, rawUrl.Host.Substring(4), rawUrl.AbsolutePath));
            }
            else
            {
                return CanonicalUrl(html, String.Format("{0}://{1}{2}", rawUrl.Scheme, rawUrl.Host, rawUrl.AbsolutePath));
            }
        }
    }
}