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
    public class ProductReviewsProvider : DataAccessBase, IProductReviewsProvider
    {
        public ProductReviews Get(ProductReviews dummy)
        {
            DbCommand comm = this.GetCommand("Sp_ProductReviews_GetById");

            comm.AddParameter<int>(this.Factory, "productId", dummy.ProductId);
            comm.AddParameter<int>(this.Factory, "reviewId", dummy.ReviewId);

            var table = this.GetTable(comm);
            table.TableName = TableName.ProductReviews;
            var test = EntityBase.ParseListFromTable<ProductReviews>(table).FirstOrDefault();
            return EntityBase.ParseListFromTable<ProductReviews>(table).FirstOrDefault();
        }

        public List<ProductReviews> GetAllReview(int productId, int startIndex, int count, ref int totalItems)
        {
            DbCommand comm = this.GetCommand("Sp_ProductReviews_GetAll");
            comm.AddParameter<int>(this.Factory, "productId", productId);
            var table = this.GetTable(comm);
            table.TableName = TableName.ProductReviews;
            return EntityBase.ParseListFromTable<ProductReviews>(table);
        }

        public List<ProductReviews> GetAllActive(int productId)
        {
            DbCommand comm = this.GetCommand("Sp_ProductReviews_GetAllActive");
            comm.AddParameter<int>(this.Factory, "productId", productId);
            var table = this.GetTable(comm);
            table.TableName = TableName.ProductReviews;
            return EntityBase.ParseListFromTable<ProductReviews>(table);
        }

        public List<ProductReviews> Search(int productId, string txtSearch, int startIndex, int pageSize, ref int totalItems)
        {
            DbCommand comm = this.GetCommand("Sp_ProductReviews_Search");
            comm.AddParameter<int>(this.Factory, "productId", productId);
            comm.AddParameter<string>(this.Factory, "txtSearch", (txtSearch != null && txtSearch.Trim().Length > 0) ? txtSearch : null);
            comm.AddParameter<int>(this.Factory, "startIndex", startIndex);
            comm.AddParameter<int>(this.Factory, "count", pageSize);

            DbParameter totalItemsParam = comm.AddParameter(this.Factory, "totalItems", DbType.Int32, null);
            totalItemsParam.Direction = ParameterDirection.Output;

            var table = this.GetTable(comm);
            table.TableName = TableName.ProductReviews;

            if (totalItemsParam.Value != DBNull.Value)
            {
                totalItems = Convert.ToInt32(totalItemsParam.Value);
            }
            return EntityBase.ParseListFromTable<ProductReviews>(table);
        }

        public void Add(ProductReviews item)
        {
            DbCommand comm = this.GetCommand("Sp_ProductReviews_Create");

            comm.AddParameter<int>(this.Factory, "ProductId", item.ProductId);
            comm.AddParameter<string>(this.Factory, "ReviewTitle", (item.ReviewTitle != null && item.ReviewTitle.Trim().Length > 0) ? item.ReviewTitle.Trim() : null);
            comm.AddParameter<string>(this.Factory, "ReviewLogo", (item.ReviewLogo != null && item.ReviewLogo.Trim().Length > 0) ? item.ReviewLogo.Trim() : null);
            comm.AddParameter<string>(this.Factory, "ReviewKeyword", (item.ReviewKeyword != null && item.ReviewKeyword.Trim().Length > 0) ? item.ReviewKeyword.Trim() : null);
            comm.AddParameter<string>(this.Factory, "ReviewDescription", (item.ReviewDescription != null && item.ReviewDescription.Trim().Length > 0) ? item.ReviewDescription.Trim() : null);
            comm.AddParameter<string>(this.Factory, "ReviewBody", (item.ReviewBody != null && item.ReviewBody.Trim().Length > 0) ? item.ReviewBody.Trim() : null);
            comm.AddParameter<string>(this.Factory, "ReviewSource", (item.ReviewSource != null && item.ReviewSource.Trim().Length > 0) ? item.ReviewSource.Trim() : null);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<string>(this.Factory, "Culture", (item.Culture != null && item.Culture.Trim().Length > 0) ? item.Culture.Trim() : null);

            this.SafeExecuteNonQuery(comm);
        }

        public void Update(ProductReviews @new, ProductReviews old)
        {
            var item = @new;
            item.ReviewId = old.ReviewId;
            var comm = this.GetCommand("Sp_ProductReviews_Update");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "ReviewId", item.ReviewId);
            comm.AddParameter<string>(this.Factory, "ReviewTitle", (item.ReviewTitle != null && item.ReviewTitle.Trim().Length > 0) ? item.ReviewTitle.Trim() : null);
            comm.AddParameter<string>(this.Factory, "ReviewLogo", (item.ReviewLogo != null && item.ReviewLogo.Trim().Length > 0) ? item.ReviewLogo.Trim() : null);
            comm.AddParameter<string>(this.Factory, "ReviewKeyword", (item.ReviewKeyword != null && item.ReviewKeyword.Trim().Length > 0) ? item.ReviewKeyword.Trim() : null);
            comm.AddParameter<string>(this.Factory, "ReviewDescription", (item.ReviewDescription != null && item.ReviewDescription.Trim().Length > 0) ? item.ReviewDescription.Trim() : null);
            comm.AddParameter<string>(this.Factory, "ReviewBody", (item.ReviewBody != null && item.ReviewBody.Trim().Length > 0) ? item.ReviewBody.Trim() : null);
            comm.AddParameter<string>(this.Factory, "ReviewSource", (item.ReviewSource != null && item.ReviewSource.Trim().Length > 0) ? item.ReviewSource.Trim() : null);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<string>(this.Factory, "Culture", (item.Culture != null && item.Culture.Trim().Length > 0) ? item.Culture.Trim() : null);

            this.SafeExecuteNonQuery(comm);
        }

        public List<ProductReviews> GetAll(int startIndex, int count, ref int totalItems)
        {
            var result = new List<ProductReviews>();
            return result;
        }

        public List<ProductReviews> Search(int startIndex, int count, ref int totalItems)
        {
            var result = new List<ProductReviews>();
            return result;
        }

        public void Remove(ProductReviews item)
        {
            var comm = this.GetCommand("Sp_ProductReviews_Delete");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "ReviewId", item.ReviewId);
            this.SafeExecuteNonQuery(comm);
        }

        public void Import(List<ProductReviews> list, bool deleteExist)
        {
        }
    }
}
