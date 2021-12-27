using Client.Core.Data;
using Client.Core.Data.DataAccess;
using Client.Core.Data.Entities;
using Client.Core.Data.Entities.Paging;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using idn.AnPhu.Constants;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Services
{
    public class ProductReviewsManager : DataManagerBase<ProductReviews>
    {
        public ProductReviewsManager(IDataProvider<ProductReviews> provider)
         : base(provider)
        {
        }

        IProductReviewsProvider ProductReviewsProvider
        {
            get
            {
                return (IProductReviewsProvider)Provider;
            }
        }

        public List<ProductReviews> GetAll(int productId)
        {
            int total = 0;
            return ProductReviewsProvider.GetAllReview(productId, 0, 0, ref total);
        }

        public override void Add(ProductReviews item)
        {
            base.Add(item);
        }

        public PageInfo<ProductReviews> Search(int productId, string txtSearch, int pageIndex, int pageSize)
        {
            int totalItems = 0;
            var pageInfo = new PageInfo<ProductReviews>(pageIndex, pageSize);
            var startIndex = (pageIndex - 1) * pageSize;
            pageInfo.DataList = ProductReviewsProvider.Search(productId, txtSearch, startIndex, pageSize, ref totalItems);
            pageInfo.ItemCount = totalItems;
            return pageInfo;
        }
    }
}
