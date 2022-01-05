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
    public class ImageFootersProvider : DataAccessBase, IImageFootersProvider
    {
        public ImageFooters Get(ImageFooters dummy)
        {
            DbCommand comm = this.GetCommand("Sp_ImageFooters_GetById");

            comm.AddParameter<int>(this.Factory, "ID", dummy.ID);

            var table = this.GetTable(comm);
            table.TableName = TableName.ImageFooters;
            return EntityBase.ParseListFromTable<ImageFooters>(table).FirstOrDefault();
        }

        public List<ImageFooters> GetAll(int startIndex, int count, ref int totalItems)
        {
            DbCommand comm = this.GetCommand("Sp_ImageFooters_GetAll");

            var table = this.GetTable(comm);
            table.TableName = TableName.ImageFooters;

            return EntityBase.ParseListFromTable<ImageFooters>(table);
        }

        public List<ImageFooters> GetTop(int top)
        {
            DbCommand comm = this.GetCommand("Sp_ImageFooters_GetTop");
            comm.AddParameter<int>(this.Factory, "top", top);

            var table = this.GetTable(comm);
            table.TableName = TableName.ImageFooters;

            return EntityBase.ParseListFromTable<ImageFooters>(table);
        }

        public void Add(ImageFooters item)
        {
            DbCommand comm = this.GetCommand("Sp_ImageFooters_Create");
            comm.AddParameter<string>(this.Factory, "Url", (item.Url != null && item.Url.Trim().Length > 0) ? item.Url.Trim() : "");
            comm.AddParameter<string>(this.Factory, "Image", (item.Image != null && item.Image.Trim().Length > 0) ? item.Image.Trim() : "");
            comm.AddParameter<string>(this.Factory, "CreateBy", (item.CreateBy != null && item.CreateBy.Trim().Length > 0) ? item.CreateBy.Trim() : null);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<string>(this.Factory, "Culture", (item.Culture != null && item.Culture.Trim().Length > 0) ? item.Culture.Trim() : null);

            this.SafeExecuteNonQuery(comm);
        }

        public void Update(ImageFooters @new, ImageFooters old)
        {
            var item = @new;
            item.ID = old.ID;
            var comm = this.GetCommand("Sp_ImageFooters_Update");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "ID", item.ID);
            comm.AddParameter<string>(this.Factory, "Url", (item.Url != null && item.Url.Trim().Length > 0) ? item.Url.Trim() : "");
            comm.AddParameter<string>(this.Factory, "Image", (item.Image != null && item.Image.Trim().Length > 0) ? item.Image.Trim() : "");
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            this.SafeExecuteNonQuery(comm);
        }

        public void Remove(ImageFooters item)
        {
            var comm = this.GetCommand("Sp_ImageFooters_Delete");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "ID", item.ID);
            this.SafeExecuteNonQuery(comm);
        }

        public void Import(List<ImageFooters> list, bool deleteExist)
        {
        }
    }
}
