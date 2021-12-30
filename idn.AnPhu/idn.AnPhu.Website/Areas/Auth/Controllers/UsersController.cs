using Client.Core.Data.Entities.Paging;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Services;
using idn.AnPhu.Utils;
using idn.AnPhu.Website.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace idn.AnPhu.Website.Areas.Auth.Controllers
{
    public class UsersController : AdministratorController
    {
        private UsersManager UsersManager
        {
            get { return ServiceFactory.UsersManager; }
        }


        #region["List người dùng"]
        public ActionResult Index(int? page, int? pageSize, string txtSearch = "")
        {
            var pageInfo = new PageInfo<Users>(0, PageSizeAdminConfig);
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

            pageInfo = UsersManager.Search(txtSearch, pageInfo.PageIndex, pageInfo.PageSize);

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
            return View(pageInfo);
        }
        #endregion

        #region["Promote"]
        public ActionResult Promote(string userId)
        {
            try
            {
                UsersManager.Promote(userId);
                return View("Index");
            } catch (Exception e)
            {
                return RedirectToAction("Index");
            }
            
        }
        #endregion

        #region["Demote"]
        public ActionResult Demote(string userId)
        {
            try
            {
                UsersManager.Demote(userId);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }

        }
        #endregion

        #region["Delete"]
        public ActionResult Delete(string userId)
        {
            try
            {
                UsersManager.Remove( new Users { UserId = userId });
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }

        }
        #endregion

        #region["Active"]
        public ActionResult Active(string userId)
        {
            try
            {
                UsersManager.Active(userId);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }

        }
        #endregion

        [HttpPost]
        public ActionResult ChangePass(string userName, string pass)
        {
            try
            {
                UsersManager.ChangePass(userName, pass);
                return RedirectToAction("Index");
            } catch(Exception e)
            {
                return RedirectToAction("Index");
            }
            
        }
    }
}