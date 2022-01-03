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
    public class LocationDiscountsProvider : DataAccessBase, ILocationDiscountsProvider
    {
        public LocationDiscounts Get(LocationDiscounts dummy)
        {
            DbCommand comm = this.GetCommand("Sp_LocationDiscounts_GetById");

            comm.AddParameter<int>(this.Factory, "LocationDiscountId", dummy.LocationDiscountId);

            var table = this.GetTable(comm);
            table.TableName = TableName.LocationDiscounts;
            return EntityBase.ParseListFromTable<LocationDiscounts>(table).FirstOrDefault();
        }

        public List<LocationDiscounts> GetAll(int startIndex, int count, ref int totalItems)
        {
            DbCommand comm = this.GetCommand("Sp_LocationDiscounts_GetAll");

            var table = this.GetTable(comm);
            table.TableName = TableName.LocationDiscounts;

            return EntityBase.ParseListFromTable<LocationDiscounts>(table);
        }

        public void Add(LocationDiscounts item)
        {
            DbCommand comm = this.GetCommand("Sp_LocationDiscounts_Create");
            comm.AddParameter<string>(this.Factory, "LocationDiscountName", (item.LocationDiscountName != null && item.LocationDiscountName.Trim().Length > 0) ? item.LocationDiscountName.Trim() : "");
            comm.AddParameter<int>(this.Factory, "LocationDiscountValue", item.LocationDiscountValue);
            comm.AddParameter<string>(this.Factory, "CreateBy", (item.CreateBy != null && item.CreateBy.Trim().Length > 0) ? item.CreateBy.Trim() : null);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<string>(this.Factory, "Culture", (item.Culture != null && item.Culture.Trim().Length > 0) ? item.Culture.Trim() : null);
            comm.AddParameter<int>(this.Factory, "LocationValue", item.LocationValue);

            this.SafeExecuteNonQuery(comm);
        }

        public void Update(LocationDiscounts @new, LocationDiscounts old)
        {
            var item = @new;
            item.LocationDiscountId = old.LocationDiscountId;
            var comm = this.GetCommand("Sp_LocationDiscounts_Update");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "LocationDiscountId", item.LocationDiscountId);
            comm.AddParameter<string>(this.Factory, "LocationDiscountName", (item.LocationDiscountName != null && item.LocationDiscountName.Trim().Length > 0) ? item.LocationDiscountName.Trim() : "");
            comm.AddParameter<int>(this.Factory, "LocationDiscountValue", item.LocationDiscountValue);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<int>(this.Factory, "LocationValue", item.LocationValue);
            this.SafeExecuteNonQuery(comm);
        }

        public void Remove(LocationDiscounts item)
        {
            var comm = this.GetCommand("Sp_LocationDiscounts_Delete");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "LocationDiscountId", item.LocationDiscountId);
            this.SafeExecuteNonQuery(comm);
        }

        public void Import(List<LocationDiscounts> list, bool deleteExist)
        {
        }
    }
}
