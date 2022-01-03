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
    public class NewBannerRightsProvider : DataAccessBase, INewBannerRightsProvider
    {
        public NewBannerRights Get(NewBannerRights dummy)
        {
            DbCommand comm = this.GetCommand("Sp_NewBannerRights_GetById");

            comm.AddParameter<int>(this.Factory, "NewRightId", dummy.NewRightId);

            var table = this.GetTable(comm);
            table.TableName = TableName.NewBannerRights;
            return EntityBase.ParseListFromTable<NewBannerRights>(table).FirstOrDefault();
        }

        public List<NewBannerRights> GetAll(int startIndex, int count, ref int totalItems)
        {
            DbCommand comm = this.GetCommand("Sp_NewBannerRights_GetAll");

            var table = this.GetTable(comm);
            table.TableName = TableName.NewBannerRights;

            return EntityBase.ParseListFromTable<NewBannerRights>(table);
        }

        public List<NewBannerRights> Search(string txtSearch, int startIndex, int pageSize, ref int totalItems)
        {
            return null;
        }

        public void Add(NewBannerRights item)
        {
        }

        public void Update(NewBannerRights @new, NewBannerRights old)
        {
            var item = @new;
            item.NewRightId = old.NewRightId;
            var comm = this.GetCommand("Sp_NewBannerRights_Update");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "NewRightId", item.NewRightId);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "NewRightName", (item.NewRightName != null && item.NewRightName.Trim().Length > 0) ? item.NewRightName.Trim() : "");
            comm.AddParameter<string>(this.Factory, "NewRightImage", (item.NewRightImage != null && item.NewRightImage.Trim().Length > 0) ? item.NewRightImage.Trim() : null);
            comm.AddParameter<string>(this.Factory, "NewRightLink", (item.NewRightLink != null && item.NewRightLink.Trim().Length > 0) ? item.NewRightLink.Trim() : null);
            comm.AddParameter<string>(this.Factory, "Culture", (item.Culture != null && item.Culture.Trim().Length > 0) ? item.Culture.Trim() : null);
            this.SafeExecuteNonQuery(comm);
        }

        public void Remove(NewBannerRights item)
        {
        }

        public void Import(List<NewBannerRights> list, bool deleteExist)
        {
        }
    }
}
