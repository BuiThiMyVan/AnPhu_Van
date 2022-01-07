using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Services
{
    public class AppDicDomainManager : DataManagerBase<AppDicDomain>
    {
        public AppDicDomainManager(IDataProvider<AppDicDomain> provider)
         : base(provider)
        {
        }

        IAppDicDomainProvider AppDicDomainProvider
        {
            get
            {
                return (IAppDicDomainProvider)Provider;
            }
        }

        public List<AppDicDomain> GetAll()
        {
            int total = 0;
            return Provider.GetAll(0, 0, ref total);
        }

        public List<AppDicDomain> GetListAppDicDomainByItemCode(string itemCode)
        {
            return AppDicDomainProvider.GetListAppDicDomainByItemCode(itemCode);
        }
    }
}
