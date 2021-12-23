using Client.Core.Data;
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

        //private INewsCategoriesProvider NewsCategoryProvider        //{        //    get { return (INewsCategoriesProvider)Provider; }        //}
        public List<NewsCategories> GetAll()
        {
            int total = 0;
            return NewsCategoriesProvider.GetAll(0, 0, ref total);
        }

        public override void Add(NewsCategories item)
        {
            item.IsActive = true;
            base.Add(item);
        }

        public PageInfo<NewsCategories> Search(string txtSearch, int pageIndex, int pageSize)
        {
            int totalItems = 0;
            var pageInfo = new PageInfo<NewsCategories>(pageIndex, pageSize);
            var startIndex = (pageIndex - 1) * pageSize;            
            pageInfo.DataList = NewsCategoriesProvider.Search(txtSearch, startIndex, pageSize, ref totalItems);
            pageInfo.ItemCount = totalItems;
            return pageInfo;
        }
    }
}
