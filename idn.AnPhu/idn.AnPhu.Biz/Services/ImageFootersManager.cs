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
    public class ImageFootersManager : DataManagerBase<ImageFooters>
    {
        public ImageFootersManager(IDataProvider<ImageFooters> provider)
          : base(provider)
        {
        }

        IImageFootersProvider ImageFootersProvider
        {
            get
            {
                return (IImageFootersProvider)Provider;
            }
        }

        public List<ImageFooters> GetAll()
        {
            int total = 0;
            return Provider.GetAll(0, 0, ref total);
        }

        public List<ImageFooters> GetTop(int top)
        {
            return ImageFootersProvider.GetTop(top);
        }

        public override void Add(ImageFooters item)
        {
            item.IsActive = true;
            base.Add(item);
        }
    }
}
