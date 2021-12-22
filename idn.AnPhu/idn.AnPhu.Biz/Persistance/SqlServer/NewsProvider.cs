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
    public class NewsProvider : DataAccessBase, INewsProvider
    {
        public News Get(News dummy)
        {
            DbCommand comm = this.GetCommand("Sp_News_GetById");

            comm.AddParameter<int>(this.Factory, "newsId", dummy.NewsCategoryId);

            var table = this.GetTable(comm);
            table.TableName = TableName.News;
            return EntityBase.ParseListFromTable<News>(table).FirstOrDefault();
        }

        public List<News> GetAll(int startIndex, int count, ref int totalItems)
        {
            DbCommand comm = this.GetCommand("Sp_News_GetAll");

            var table = this.GetTable(comm);
            table.TableName = TableName.News;

            return EntityBase.ParseListFromTable<News>(table);
        }

        public List<News> Search(string txtSearch, int startIndex, int pageSize, ref int totalItems)
        {
            DbCommand comm = this.GetCommand("Sp_News_Search");
            comm.AddParameter<string>(this.Factory, "txtSearch", (txtSearch != null && txtSearch.Trim().Length > 0) ? txtSearch : null);
            comm.AddParameter<int>(this.Factory, "startIndex", startIndex);
            comm.AddParameter<int>(this.Factory, "count", pageSize);

            DbParameter totalItemsParam = comm.AddParameter(this.Factory, "totalItems", DbType.Int32, null);
            totalItemsParam.Direction = ParameterDirection.Output;

            var table = this.GetTable(comm);
            table.TableName = TableName.News;

            if (totalItemsParam.Value != DBNull.Value)
            {
                totalItems = Convert.ToInt32(totalItemsParam.Value);
            }
            return EntityBase.ParseListFromTable<News>(table);
        }

        public void Add(News item)
        {
            DbCommand comm = this.GetCommand("Sp_News_Create");
            comm.AddParameter<int>(this.Factory, "newsCategoryId", item.NewsCategoryId);
            comm.AddParameter<string>(this.Factory, "newsTitle", (item.NewsTitle != null && item.NewsTitle.Trim().Length > 0) ? item.NewsTitle.Trim() : "");
            comm.AddParameter<string>(this.Factory, "newsSummary", (item.NewsSummary != null && item.NewsSummary.Trim().Length > 0) ? item.NewsSummary.Trim() : null);
            comm.AddParameter<string>(this.Factory, "newsBody", (item.NewsBody != null && item.NewsBody.Trim().Length > 0) ? item.NewsBody.Trim() : null);
            comm.AddParameter<string>(this.Factory, "newsDescription", (item.NewsDescription != null && item.NewsDescription.Trim().Length > 0) ? item.NewsDescription.Trim() : null);
            comm.AddParameter<string>(this.Factory, "newsKeyword", (item.NewsKeyword != null && item.NewsKeyword.Trim().Length > 0) ? item.NewsKeyword.Trim() : null);
            comm.AddParameter<string>(this.Factory, "createBy", (item.CreateBy != null && item.CreateBy.Trim().Length > 0) ? item.CreateBy.Trim() : null);
            comm.AddParameter<bool>(this.Factory, "isActive", item.IsActive);
            comm.AddParameter<int>(this.Factory, "orderNo", item.OrderNo);
            comm.AddParameter<string>(this.Factory, "culture", (item.Culture != null && item.Culture.Trim().Length > 0) ? item.Culture.Trim() : null);
            comm.AddParameter<string>(this.Factory, "newsOther", (item.NewsOther != null && item.NewsOther.Trim().Length > 0) ? item.NewsOther.Trim() : null);
            comm.AddParameter<string>(this.Factory, "productTag", (item.ProductTag != null && item.ProductTag.Trim().Length > 0) ? item.ProductTag.Trim() : null);

            comm.AddParameter<bool>(this.Factory, "isHotNews", item.IsHotNews);
            comm.AddParameter<string>(this.Factory, "newsImage", (item.NewsImage != null && item.NewsImage.Trim().Length > 0) ? item.NewsImage.Trim() : null);
            comm.AddParameter<bool>(this.Factory, "isAdsNews", item.IsAdsNews);

            this.SafeExecuteNonQuery(comm);
        }

        public void Update(News @new, News old)
        {
            var item = @new;
            item.NewsId = old.NewsId;
            var comm = this.GetCommand("Sp_News_Update");
            if (comm == null) return;

            this.SafeExecuteNonQuery(comm);
        }

        public void Remove(News item)
        {

        }

        public void Import(List<News> list, bool deleteExist)
        {
        }
    }
}
