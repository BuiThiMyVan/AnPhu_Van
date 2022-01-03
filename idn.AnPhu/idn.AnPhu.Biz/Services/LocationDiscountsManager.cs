using Client.Core.Data;
using Client.Core.Data.Entities.Paging;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Services
{
    public class LocationDiscountsManager : DataManagerBase<LocationDiscounts>
    {
        public LocationDiscountsManager(IDataProvider<LocationDiscounts> provider)
          : base(provider)
        {
        }

        ILocationDiscountsProvider LocationDiscountsProvider
        {
            get
            {
                return (ILocationDiscountsProvider)Provider;
            }
        }

        public List<LocationDiscounts> GetAll()
        {
            int total = 0;
            return Provider.GetAll(0, 0, ref total);
        }

        public override void Add(LocationDiscounts item)
        {
            item.IsActive = true;
            base.Add(item);
        }
    }
}
