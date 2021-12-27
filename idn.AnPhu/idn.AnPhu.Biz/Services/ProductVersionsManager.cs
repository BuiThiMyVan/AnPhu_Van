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
    public class ProductVersionsManager : DataManagerBase<ProductVersions>
    {
        public ProductVersionsManager(IDataProvider<ProductVersions> provider)
          : base(provider)
        {
        }

        IProductVersionsProvider ProductVersionsProvider
        {
            get
            {
                return (IProductVersionsProvider)Provider;
            }
        }

        public List<ProductVersions> GetAll(int productId)
        {
            int total = 0;
            return ProductVersionsProvider.GetAllVersions(productId, 0, 0, ref total);
        }

        public override void Add(ProductVersions item)
        {
            base.Add(item);
        }

        public PageInfo<ProductVersions> Search(int productId, string txtSearch, int pageIndex, int pageSize)
        {
            int totalItems = 0;
            var pageInfo = new PageInfo<ProductVersions>(pageIndex, pageSize);
            var startIndex = (pageIndex - 1) * pageSize;
            pageInfo.DataList = ProductVersionsProvider.Search(productId, txtSearch, startIndex, pageSize, ref totalItems);
            pageInfo.ItemCount = totalItems;
            return pageInfo;
        }
    }
}
