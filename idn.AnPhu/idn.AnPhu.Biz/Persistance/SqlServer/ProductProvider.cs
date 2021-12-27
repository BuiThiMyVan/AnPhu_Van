using Client.Core.Data.DataAccess;
using Client.Core.Data.Entities;
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

namespace idn.AnPhu.Biz.Persistance.SqlServer
{
    public class ProductProvider : DataAccessBase, IProductProvider
    {
        public Product Get(Product dummy)
        {
            DbCommand comm = this.GetCommand("Sp_Product_GetById");

            comm.AddParameter<int>(this.Factory, "productId", dummy.ProductId);

            var table = this.GetTable(comm);
            table.TableName = TableName.Product;
            var test = EntityBase.ParseListFromTable<Product>(table).FirstOrDefault();
            return EntityBase.ParseListFromTable<Product>(table).FirstOrDefault();
        }

        public List<Product> GetAll(int startIndex, int count, ref int totalItems)
        {
            DbCommand comm = this.GetCommand("Sp_Product_GetAll");

            var table = this.GetTable(comm);
            table.TableName = TableName.Product;
            return EntityBase.ParseListFromTable<Product>(table);
        }

        public List<Product> Search(string txtSearch, int startIndex, int pageSize, ref int totalItems)
        {
            DbCommand comm = this.GetCommand("Sp_Product_Search");
            comm.AddParameter<string>(this.Factory, "txtSearch", (txtSearch != null && txtSearch.Trim().Length > 0) ? txtSearch : null);
            comm.AddParameter<int>(this.Factory, "startIndex", startIndex);
            comm.AddParameter<int>(this.Factory, "count", pageSize);

            DbParameter totalItemsParam = comm.AddParameter(this.Factory, "totalItems", DbType.Int32, null);
            totalItemsParam.Direction = ParameterDirection.Output;

            var table = this.GetTable(comm);
            table.TableName = TableName.Product;

            if (totalItemsParam.Value != DBNull.Value)
            {
                totalItems = Convert.ToInt32(totalItemsParam.Value);
            }
            return EntityBase.ParseListFromTable<Product>(table);
        }

        public void Add(Product item)
        {
            DbCommand comm = this.GetCommand("Sp_Product_Create");

            comm.AddParameter<int>(this.Factory, "PrdCategoryId", item.PrdCategoryId);
            comm.AddParameter<string>(this.Factory, "ProductName", (item.ProductName != null && item.ProductName.Trim().Length > 0) ? item.ProductName.Trim() : null);
            comm.AddParameter<string>(this.Factory, "ProductTitle", (item.ProductTilte != null && item.ProductTilte.Trim().Length > 0) ? item.ProductTilte.Trim() : null);
            comm.AddParameter<string>(this.Factory, "ProductSummary", (item.ProductSummary != null && item.ProductSummary.Trim().Length > 0) ? item.ProductSummary.Trim() : null);
            comm.AddParameter<string>(this.Factory, "ProductKeyword", (item.ProductKeyword != null && item.ProductKeyword.Trim().Length > 0) ? item.ProductKeyword.Trim() : null);
            comm.AddParameter<string>(this.Factory, "ProductDescription", (item.ProductDescription != null && item.ProductDescription.Trim().Length > 0) ? item.ProductDescription.Trim() : null);
            comm.AddParameter<string>(this.Factory, "ProductImage", (item.ProductImage != null && item.ProductImage.Trim().Length > 0) ? item.ProductImage.Trim() : null);
            comm.AddParameter<string>(this.Factory, "ProductCode", (item.ProductCode != null && item.ProductCode.Trim().Length > 0) ? item.ProductCode.Trim() : null);
            comm.AddParameter<double>(this.Factory, "ProductPrice", item.ProductPrice);
            comm.AddParameter<string>(this.Factory, "ProductSlogan", (item.ProductSlogan != null && item.ProductSlogan.Trim().Length > 0) ? item.ProductSlogan.Trim() : null);
            comm.AddParameter<bool>(this.Factory, "IsHotProduct", item.IsHotProduct);
            comm.AddParameter<bool>(this.Factory, "IsNewProduct", item.IsNewProduct);
            comm.AddParameter<bool>(this.Factory, "IsSaleProduct", item.IsSaleProduct);
            comm.AddParameter<string>(this.Factory, "ProductVideo", (item.ProductVideo != null && item.ProductVideo.Trim().Length > 0) ? item.ProductVideo.Trim() : null);
            comm.AddParameter<string>(this.Factory, "ProductBrochure", (item.ProductBrochure != null && item.ProductBrochure.Trim().Length > 0) ? item.ProductBrochure.Trim() : null);
            comm.AddParameter<string>(this.Factory, "ProductBackground", (item.ProductBackground != null && item.ProductBackground.Trim().Length > 0) ? item.ProductBackground.Trim() : null);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<string>(this.Factory, "Culture", (item.Culture != null && item.Culture.Trim().Length > 0) ? item.Culture.Trim() : null);

            this.SafeExecuteNonQuery(comm);
        }

        public void Update(Product @new, Product old)
        {
            var item = @new;
            item.PrdCategoryId = old.PrdCategoryId;
            var comm = this.GetCommand("Sp_Product_Update");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "ProductId", item.ProductId);
            comm.AddParameter<int>(this.Factory, "PrdCategoryId", item.PrdCategoryId);
            comm.AddParameter<string>(this.Factory, "ProductName", (item.ProductName != null && item.ProductName.Trim().Length > 0) ? item.ProductName.Trim() : null);
            comm.AddParameter<string>(this.Factory, "ProductTitle", (item.ProductTilte != null && item.ProductTilte.Trim().Length > 0) ? item.ProductTilte.Trim() : null);
            comm.AddParameter<string>(this.Factory, "ProductSummary", (item.ProductSummary != null && item.ProductSummary.Trim().Length > 0) ? item.ProductSummary.Trim() : null);
            comm.AddParameter<string>(this.Factory, "ProductKeyword", (item.ProductKeyword != null && item.ProductKeyword.Trim().Length > 0) ? item.ProductKeyword.Trim() : null);
            comm.AddParameter<string>(this.Factory, "ProductDescription", (item.ProductDescription != null && item.ProductDescription.Trim().Length > 0) ? item.ProductDescription.Trim() : null);
            comm.AddParameter<string>(this.Factory, "ProductImage", (item.ProductImage != null && item.ProductImage.Trim().Length > 0) ? item.ProductImage.Trim() : null);
            comm.AddParameter<string>(this.Factory, "ProductCode", (item.ProductCode != null && item.ProductCode.Trim().Length > 0) ? item.ProductCode.Trim() : null);
            comm.AddParameter<double>(this.Factory, "ProductPrice", item.ProductPrice);
            comm.AddParameter<string>(this.Factory, "ProductSlogan", (item.ProductSlogan != null && item.ProductSlogan.Trim().Length > 0) ? item.ProductSlogan.Trim() : null);
            comm.AddParameter<bool>(this.Factory, "IsHotProduct", item.IsHotProduct);
            comm.AddParameter<bool>(this.Factory, "IsNewProduct", item.IsNewProduct);
            comm.AddParameter<bool>(this.Factory, "IsSaleProduct", item.IsSaleProduct);
            comm.AddParameter<string>(this.Factory, "ProductVideo", (item.ProductVideo != null && item.ProductVideo.Trim().Length > 0) ? item.ProductVideo.Trim() : null);
            comm.AddParameter<string>(this.Factory, "ProductBrochure", (item.ProductBrochure != null && item.ProductBrochure.Trim().Length > 0) ? item.ProductBrochure.Trim() : null);
            comm.AddParameter<string>(this.Factory, "ProductBackground", (item.ProductBackground != null && item.ProductBackground.Trim().Length > 0) ? item.ProductBackground.Trim() : null);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<string>(this.Factory, "Culture", (item.Culture != null && item.Culture.Trim().Length > 0) ? item.Culture.Trim() : null);

            this.SafeExecuteNonQuery(comm);
        }

        public void Remove(Product item)
        {

        }

        public void Import(List<Product> list, bool deleteExist)
        {
        }
    }
}
