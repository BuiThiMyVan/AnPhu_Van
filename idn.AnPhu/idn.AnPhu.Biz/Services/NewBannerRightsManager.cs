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
    public class NewBannerRightsManager : DataManagerBase<NewBannerRights>
    {
        public NewBannerRightsManager(IDataProvider<NewBannerRights> provider)
         : base(provider)
        {
        }

        INewBannerRightsProvider NewBannerRightsProvider
        {
            get
            {
                return (INewBannerRightsProvider)Provider;
            }
        }

        public List<NewBannerRights> GetAll()
        {
            int total = 0;
            return Provider.GetAll(0, 0, ref total);
        }
    }
}
