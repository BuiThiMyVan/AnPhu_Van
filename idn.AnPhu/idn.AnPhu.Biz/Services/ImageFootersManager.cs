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
    public class ImageFootersManager : DataManagerBase<ImageFooters>
    {
        public ImageFootersManager(IDataProvider<ImageFooters> provider)
          : base(provider)
        {
        }

        IImageFootersProvider ImageFootersProvider
        {
            get
            {
                return (IImageFootersProvider)Provider;
            }
        }

        public List<ImageFooters> GetAll()
        {
            int total = 0;
            return Provider.GetAll(0, 0, ref total);
        }

        public override void Add(ImageFooters item)
        {
            item.IsActive = true;
            base.Add(item);
        }

        public PageInfo<ImageFooters> Search(string txtSearch, int pageIndex, int pageSize)
        {
            int totalItems = 0;
            var pageInfo = new PageInfo<ImageFooters>(pageIndex, pageSize);
            var startIndex = (pageIndex - 1) * pageSize;
            pageInfo.DataList = ImageFootersProvider.Search(txtSearch, startIndex, pageSize, ref totalItems);
            pageInfo.ItemCount = totalItems;
            return pageInfo;
        }
    }
}
