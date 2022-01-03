using Client.Core.Data.DataAccess;
using Client.Core.Data.Entities;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using idn.AnPhu.Constants;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.SqlServer
{
    public class NewBannerLeftsProvider : DataAccessBase, INewBannerLeftsProvider
    {
        public NewBannerLefts Get(NewBannerLefts dummy)
        {
            DbCommand comm = this.GetCommand("Sp_NewBannerLefts_GetById");

            comm.AddParameter<int>(this.Factory, "NewLeftId", dummy.NewLeftId);

            var table = this.GetTable(comm);
            table.TableName = TableName.NewBannerLefts;
            return EntityBase.ParseListFromTable<NewBannerLefts>(table).FirstOrDefault();
        }

        public List<NewBannerLefts> GetAll(int startIndex, int count, ref int totalItems)
        {
            DbCommand comm = this.GetCommand("Sp_NewBannerLefts_GetAll");

            var table = this.GetTable(comm);
            table.TableName = TableName.NewBannerLefts;

            return EntityBase.ParseListFromTable<NewBannerLefts>(table);
        }

        public List<NewBannerLefts> Search(string txtSearch, int startIndex, int pageSize, ref int totalItems)
        {
            return null;
        }

        public void Add(NewBannerLefts item)
        {
        }

        public void Update(NewBannerLefts @new, NewBannerLefts old)
        {
            var item = @new;
            item.NewLeftId = old.NewLeftId;
            var comm = this.GetCommand("Sp_NewBannerLefts_Update");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "NewLeftId", item.NewLeftId);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "NewLeftName", (item.NewLeftName != null && item.NewLeftName.Trim().Length > 0) ? item.NewLeftName.Trim() : "");
            comm.AddParameter<string>(this.Factory, "NewLeftImage", (item.NewLeftImage != null && item.NewLeftImage.Trim().Length > 0) ? item.NewLeftImage.Trim() : null);
            comm.AddParameter<string>(this.Factory, "NewLeftLink", (item.NewLeftLink != null && item.NewLeftLink.Trim().Length > 0) ? item.NewLeftLink.Trim() : null);
            comm.AddParameter<string>(this.Factory, "Culture", (item.Culture != null && item.Culture.Trim().Length > 0) ? item.Culture.Trim() : null);
            this.SafeExecuteNonQuery(comm);
        }

        public void Remove(NewBannerLefts item)
        {
        }

        public void Import(List<NewBannerLefts> list, bool deleteExist)
        {
        }
    }
}
