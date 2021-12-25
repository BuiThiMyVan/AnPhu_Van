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
    public class PrdCategoriesProvider : DataAccessBase, IPrdCategoriesProvider
    {
        public PrdCategories Get(PrdCategories dummy)
        {
            DbCommand comm = this.GetCommand("Sp_PrdCategories_GetById");

            comm.AddParameter<int>(this.Factory, "prdCategoryId", dummy.PrdCategoryId);

            var table = this.GetTable(comm);
            table.TableName = TableName.PrdCategories;
            return EntityBase.ParseListFromTable<PrdCategories>(table).FirstOrDefault();
        }

        public List<PrdCategories> GetAll(int startIndex, int count, ref int totalItems)
        {
            DbCommand comm = this.GetCommand("Sp_PrdCategories_GetAll");

            var table = this.GetTable(comm);
            table.TableName = TableName.PrdCategories;

            return EntityBase.ParseListFromTable<PrdCategories>(table);
        }

        public List<PrdCategories> Search(string txtSearch, int startIndex, int pageSize, ref int totalItems)
        {
            DbCommand comm = this.GetCommand("Sp_PrdCategories_Search");
            comm.AddParameter<string>(this.Factory, "txtSearch", (txtSearch != null && txtSearch.Trim().Length > 0) ? txtSearch : null);
            comm.AddParameter<int>(this.Factory, "startIndex", startIndex);
            comm.AddParameter<int>(this.Factory, "count", pageSize);

            DbParameter totalItemsParam = comm.AddParameter(this.Factory, "totalItems", DbType.Int32, null);
            totalItemsParam.Direction = ParameterDirection.Output;

            var table = this.GetTable(comm);
            table.TableName = TableName.PrdCategories;

            if (totalItemsParam.Value != DBNull.Value)
            {
                totalItems = Convert.ToInt32(totalItemsParam.Value);
            }
            return EntityBase.ParseListFromTable<PrdCategories>(table);
        }

        public void Add(PrdCategories item)
        {
            DbCommand comm = this.GetCommand("Sp_PrdCategories_Create");

            comm.AddParameter<int>(this.Factory, "ParentId", item.ParentId);
            comm.AddParameter<string>(this.Factory, "PrdCategoryTitle", (item.PrdCategoryTitle != null && item.PrdCategoryTitle.Trim().Length > 0) ? item.PrdCategoryTitle.Trim() : null);
            comm.AddParameter<string>(this.Factory, "PrdCategorySummary", (item.PrdCategorySummary != null && item.PrdCategorySummary.Trim().Length > 0) ? item.PrdCategorySummary.Trim() : null);
            comm.AddParameter<string>(this.Factory, "PrdCategoryDescription", (item.PrdCategoryDescription != null && item.PrdCategoryDescription.Trim().Length > 0) ? item.PrdCategoryDescription.Trim() : null);
            comm.AddParameter<string>(this.Factory, "PrdCategoryKeyword", (item.PrdCategoryKeyword != null && item.PrdCategoryKeyword.Trim().Length > 0) ? item.PrdCategoryKeyword.Trim() : null);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<string>(this.Factory, "Culture", (item.Culture != null && item.Culture.Trim().Length > 0) ? item.Culture.Trim() : null);

            this.SafeExecuteNonQuery(comm);
        }

        public void Update(PrdCategories @new, PrdCategories old)
        {
            var item = @new;
            item.PrdCategoryId = old.PrdCategoryId;
            var comm = this.GetCommand("Sp_PrdCategories_Update");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "PrdCategoryId", item.PrdCategoryId);
            comm.AddParameter<int>(this.Factory, "ParentId", item.ParentId);
            comm.AddParameter<string>(this.Factory, "PrdCategoryTitle", (item.PrdCategoryTitle != null && item.PrdCategoryTitle.Trim().Length > 0) ? item.PrdCategoryTitle.Trim() : null);
            comm.AddParameter<string>(this.Factory, "PrdCategorySummary", (item.PrdCategorySummary != null && item.PrdCategorySummary.Trim().Length > 0) ? item.PrdCategorySummary.Trim() : null);
            comm.AddParameter<string>(this.Factory, "PrdCategoryDescription", (item.PrdCategoryDescription != null && item.PrdCategoryDescription.Trim().Length > 0) ? item.PrdCategoryDescription.Trim() : null);
            comm.AddParameter<string>(this.Factory, "PrdCategoryKeyword", (item.PrdCategoryKeyword != null && item.PrdCategoryKeyword.Trim().Length > 0) ? item.PrdCategoryKeyword.Trim() : null);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<string>(this.Factory, "Culture", (item.Culture != null && item.Culture.Trim().Length > 0) ? item.Culture.Trim() : null);

            this.SafeExecuteNonQuery(comm);
        }

        public void Remove(PrdCategories item)
        {

        }

        public void Import(List<PrdCategories> list, bool deleteExist)
        {
        }
    }
}
