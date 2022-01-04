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
    public class NewsManager : DataManagerBase<News>
    {
        public NewsManager(IDataProvider<News> provider)
          : base(provider)
        {
        }

        INewsProvider NewsProvider
        {
            get
            {
                return (INewsProvider)Provider;
            }
        }

        public List<News> GetAll()
        {
            int total = 0;
            return Provider.GetAll(0, 0, ref total);
        }

        public override void Add(News item)
        {
            item.IsActive = true;
            base.Add(item);
        }

        public PageInfo<News> Search(string txtSearch, int pageIndex, int pageSize)
        {
            int totalItems = 0;
            var pageInfo = new PageInfo<News>(pageIndex, pageSize);
            var startIndex = (pageIndex - 1) * pageSize;
            pageInfo.DataList = NewsProvider.Search(txtSearch, startIndex, pageSize, ref totalItems);
            pageInfo.ItemCount = totalItems;
            return pageInfo;
        }

        public List<News> SearchNewsOther(string search)
        {
            return NewsProvider.SearchNewsOther(search);
        }
    }
}
