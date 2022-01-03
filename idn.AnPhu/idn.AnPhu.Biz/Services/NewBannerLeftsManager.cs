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
    public class NewBannerLeftsManager : DataManagerBase<NewBannerLefts>
    {
        public NewBannerLeftsManager(IDataProvider<NewBannerLefts> provider)
         : base(provider)
        {
        }

        INewBannerLeftsProvider NewBannerLeftsProvider
        {
            get
            {
                return (INewBannerLeftsProvider)Provider;
            }
        }

        public List<NewBannerLefts> GetAll()
        {
            int total = 0;
            return Provider.GetAll(0, 0, ref total);
        }
    }
}
