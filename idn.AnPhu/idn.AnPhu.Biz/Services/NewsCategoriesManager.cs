﻿using Client.Core.Data;
using Client.Core.Data.Entities.Paging;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Services
{
    public class NewsCategoriesManager : DataManagerBase<NewsCategories>
    {
        public NewsCategoriesManager(IDataProvider<NewsCategories> provider)
           : base(provider)
        {
        }

        INewsCategoriesProvider NewsCategoriesProvider
        {
            get
            {
                return (INewsCategoriesProvider)Provider;
            }
        }

        public List<NewsCategories> GetAll()
        {
            int total = 0;
            return Provider.GetAll(0, 0, ref total);
        }

        public override void Add(NewsCategories item)
        {
            item.IsActive = true;
            base.Add(item);
        }
    }
}
