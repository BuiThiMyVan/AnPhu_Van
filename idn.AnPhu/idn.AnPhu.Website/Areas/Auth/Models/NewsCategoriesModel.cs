using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace idn.AnPhu.Website.Areas.Auth.Models
{
    public class NewsCategoriesModel
    {
        private NewsManager NewsManager
        {
            get { return ServiceFactory.NewsManager; }
        }

        public List<NewsCategories> GetChildCategories(List<NewsCategories> list, int parentId)
        {
            List<NewsCategories> listChild = new List<NewsCategories>();
            foreach (NewsCategories item in list)
            {
                if(item.ParentId == parentId)
                {
                    listChild.Add(item);
                }
            }

            return listChild;
        }
    }
}