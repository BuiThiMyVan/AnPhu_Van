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
    public class ProductPropertiesManager : DataManagerBase<ProductProperties>
    {
        public ProductPropertiesManager(IDataProvider<ProductProperties> provider)
         : base(provider)
        {
        }

        public ProductPropertiesManager(ProductPropertiesManager productPropertiesManager)
        {
        }

        public ProductPropertiesManager()
        {
        }

        IProductPropertiesProvider ProductPropertiesProvider
        {
            get
            {
                return (IProductPropertiesProvider)Provider;
            }
        }

        public List<ProductProperties> GetAll(int productId)
        {
            int total = 0;
            return ProductPropertiesProvider.GetAllProperties(productId, 0, 0, ref total);
        }

        public override void Add(ProductProperties item)
        {
            base.Add(item);
        }

        public PageInfo<ProductProperties> Search(int productId, string txtSearch, int pageIndex, int pageSize)
        {
            int totalItems = 0;
            var pageInfo = new PageInfo<ProductProperties>(pageIndex, pageSize);
            var startIndex = (pageIndex - 1) * pageSize;
            pageInfo.DataList = ProductPropertiesProvider.Search(productId, txtSearch, startIndex, pageSize, ref totalItems);
            pageInfo.ItemCount = totalItems;
            return pageInfo;
        }
    }
}