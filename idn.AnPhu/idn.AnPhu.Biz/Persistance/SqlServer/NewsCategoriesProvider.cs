using Client.Core.Data.DataAccess;
using Client.Core.Data.Entities;
using Client.Core.Data.Entities.Paging;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using idn.AnPhu.Constants;
using idn.AnPhu.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.SqlServer
{
    public class NewsCategoriesProvider : DataAccessBase, INewsCategoriesProvider
    {
        public NewsCategories Get(NewsCategories dummy)
        {
            DbCommand comm = this.GetCommand("Sp_NewsCategories_GetById");

            comm.AddParameter<int>(this.Factory, "newsCategoryId", dummy.NewsCategoryId);

            var table = this.GetTable(comm);
            table.TableName = TableName.NewsCategories;           
            return EntityBase.ParseListFromTable<NewsCategories>(table).FirstOrDefault();
        }

        public List<NewsCategories> GetAll(int startIndex, int count, ref int totalItems)
        {
            DbCommand comm = this.GetCommand("Sp_NewsCategories_GetAll");

            var table = this.GetTable(comm);
            table.TableName = TableName.NewsCategories;

            return EntityBase.ParseListFromTable<NewsCategories>(table);
        }

        public List<NewsCategories> Search(PageInfo<NewsCategories> pageInfoSearch)
        {
            var newsCategories = pageInfoSearch.DataList[0];
            var pageIndex = CUtils.ConvertToInt32(CUtils.StrTrim(pageInfoSearch.PageIndex));
            var pageSize = CUtils.ConvertToInt32(CUtils.StrTrim(pageInfoSearch.PageSize));
            var comm = this.GetCommand("Sp_NewsCategories_Search");
            comm.AddParameter<string>(this.Factory, "newsCategoryTitle", CUtils.StrTrim(newsCategories.NewsCategoryTitle));
            comm.AddParameter<string>(this.Factory, "newsCategoryShortName", CUtils.StrTrim(newsCategories.NewsCategoryShortName));
            comm.AddParameter<string>(this.Factory, "newsCategoryDescription", CUtils.StrTrim(newsCategories.NewsCategoryShortName));
            comm.AddParameter<string>(this.Factory, "newsCategoryKeyword", CUtils.StrTrim(newsCategories.NewsCategoryKeyword));
            comm.AddParameter<int>(this.Factory, "startIndex", pageIndex);
            comm.AddParameter<int>(this.Factory, "count", pageSize);

            DbParameter totalItemsParam = comm.AddParameter(this.Factory, "totalItems", DbType.Int32, null);
            totalItemsParam.Direction = ParameterDirection.Output;

            var table = this.GetTable(comm);
            table.TableName = TableName.NewsCategories;

            if (totalItemsParam.Value != DBNull.Value)
            {
                pageInfoSearch.ItemCount = Convert.ToInt32(totalItemsParam.Value);
            }
            return EntityBase.ParseListFromTable<NewsCategories>(table);

        }

        public void Add(NewsCategories item)
        {
            DbCommand comm = this.GetCommand("Sp_NewsCategories_Create");

            comm.AddParameter<int>(this.Factory, "parentId", item.ParentId);
            comm.AddParameter<string>(this.Factory, "newsCategoryTitle", (item.NewsCategoryTitle != null && item.NewsCategoryTitle.Trim().Length > 0) ? item.NewsCategoryTitle.Trim() : null);
            comm.AddParameter<string>(this.Factory, "newsCategoryShortName", (item.NewsCategoryShortName != null && item.NewsCategoryShortName.Trim().Length > 0) ? item.NewsCategoryShortName.Trim() : null);
            comm.AddParameter<string>(this.Factory, "newsCategorySummary", (item.NewsCategorySummary != null && item.NewsCategorySummary.Trim().Length > 0) ? item.NewsCategorySummary.Trim() : null);
            comm.AddParameter<string>(this.Factory, "newsCategoryDescription", (item.NewsCategoryDescription != null && item.NewsCategoryDescription.Trim().Length > 0) ? item.NewsCategoryDescription.Trim() : null);
            comm.AddParameter<string>(this.Factory, "newsCategoryKeyword", (item.NewsCategoryKeyword != null && item.NewsCategoryKeyword.Trim().Length > 0) ? item.NewsCategoryKeyword.Trim() : null);
            comm.AddParameter<string>(this.Factory, "createBy", item.CreateBy);
            comm.AddParameter<bool>(this.Factory, "isActive", item.IsActive);
            comm.AddParameter<int>(this.Factory, "orderNo", item.OrderNo);
            comm.AddParameter<string>(this.Factory, "culture", (item.Culture != null && item.Culture.Trim().Length > 0) ? item.Culture.Trim() : null);
            
            this.SafeExecuteNonQuery(comm);
        }

        public void Update(NewsCategories @new, NewsCategories old)
        {
            var item = @new;
            item.NewsCategoryId = old.NewsCategoryId;
            var comm = this.GetCommand("Sp_NewsCategories_Update");            
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "newsCategoryId", item.NewsCategoryId);

            this.SafeExecuteNonQuery(comm);
        }

        public void Remove(NewsCategories item)
        {

        }

        public void Import(List<NewsCategories> list, bool deleteExist)
        {
        }


    }
}
