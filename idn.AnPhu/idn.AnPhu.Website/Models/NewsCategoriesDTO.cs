using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace idn.AnPhu.Website.Models
{
    public class NewsCategoriesDTO
    {
        private NewsCategoriesManager NewsCategoriesManager
        {
            get { return ServiceFactory.NewsCategoriesManager; }
        }
        

    }
}