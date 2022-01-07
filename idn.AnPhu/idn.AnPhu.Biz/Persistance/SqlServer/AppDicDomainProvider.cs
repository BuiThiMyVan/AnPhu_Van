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
    public class AppDicDomainProvider : DataAccessBase, IAppDicDomainProvider
    {
        public AppDicDomain Get(AppDicDomain dummy)
        {
            return null;
        }

        public List<AppDicDomain> GetAll(int startIndex, int count, ref int totalItems)
        {
            return null;
        }

        public List<AppDicDomain> GetListAppDicDomainByItemCode(string itemCode)
        {
            DbCommand comm = this.GetCommand("Sp_AppDicDomain_GetListAppDicDomainByItemCode");

            comm.AddParameter<string>(this.Factory, "DomainCode", itemCode);

            var table = this.GetTable(comm);
            table.TableName = TableName.AppDicDomain;

            return EntityBase.ParseListFromTable<AppDicDomain>(table);
        }

        public List<AppDicDomain> Search(string txtSearch, int startIndex, int pageSize, ref int totalItems)
        {
            return null;
        }

        public void Add(AppDicDomain item)
        {
        }

        public void Update(AppDicDomain @new, AppDicDomain old)
        {            
        }

        public void Remove(AppDicDomain item)
        {
        }

        public void Import(List<AppDicDomain> list, bool deleteExist)
        {
        }
    }
}
