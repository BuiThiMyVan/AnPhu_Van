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
    public class UsersProvider : DataAccessBase, IUsersProvider
    {
        public Users Get(Users dummy)
        {
            DbCommand comm = this.GetCommand("Sp_Users_GetById");

            comm.AddParameter<string>(this.Factory, "userId", dummy.UserId);

            var table = this.GetTable(comm);
            table.TableName = TableName.News;
            return EntityBase.ParseListFromTable<Users>(table).FirstOrDefault();
        }

        public List<Users> GetAll(int startIndex, int count, ref int totalItems)
        {
            return null;
        }

        public List<Users> Search(string txtSearch, int startIndex, int pageSize, ref int totalItems)
        {
            DbCommand comm = this.GetCommand("Sp_Users_Search");
            comm.AddParameter<string>(this.Factory, "txtSearch", (txtSearch != null && txtSearch.Trim().Length > 0) ? txtSearch : null);
            comm.AddParameter<int>(this.Factory, "startIndex", startIndex);
            comm.AddParameter<int>(this.Factory, "count", pageSize);

            DbParameter totalItemsParam = comm.AddParameter(this.Factory, "totalItems", DbType.Int32, null);
            totalItemsParam.Direction = ParameterDirection.Output;

            var table = this.GetTable(comm);
            table.TableName = TableName.Users;

            if (totalItemsParam.Value != DBNull.Value)
            {
                totalItems = Convert.ToInt32(totalItemsParam.Value);
            }
            return EntityBase.ParseListFromTable<Users>(table);
        }

        public void Update(Users @new, Users old)
        {
            var item = @new;
            item.UserId = old.UserId;
            var comm = this.GetCommand("Sp_Users_Update");
            if (comm == null) return;
            //comm.AddParameter<int>(this.Factory, "newsId", item.NewsId);
            //comm.AddParameter<int>(this.Factory, "newsCategoryId", item.NewsCategoryId);
            this.SafeExecuteNonQuery(comm);
        }

        public void Promote(string userId)
        {
            var comm = this.GetCommand("Sp_Users_Promote");
            if (comm == null) return;
            comm.AddParameter<string>(this.Factory, "UserId", userId);
            this.SafeExecuteNonQuery(comm);
        }

        public void Demote(string userId)
        {
            var comm = this.GetCommand("Sp_Users_Demote");
            if (comm == null) return;
            comm.AddParameter<string>(this.Factory, "UserId", userId);
            this.SafeExecuteNonQuery(comm);
        }

        public void Remove(Users item)
        {
            var comm = this.GetCommand("Sp_Users_Delete");
            if (comm == null) return;
            comm.AddParameter<string>(this.Factory, "UserId", item.UserId);
            this.SafeExecuteNonQuery(comm);
        }

        public void Active(string userId)
        {
            var comm = this.GetCommand("Sp_Users_Active");
            if (comm == null) return;
            comm.AddParameter<string>(this.Factory, "UserId", userId);
            this.SafeExecuteNonQuery(comm);
        }

        public void Add(Users item)
        {
        }



        public void Import(List<Users> list, bool deleteExist)
        {
        }
    }
}
