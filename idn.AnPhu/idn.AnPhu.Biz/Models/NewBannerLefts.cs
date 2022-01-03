using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
    public class NewBannerLefts : EntityBase
    {
        [DataColum]
        public int NewLeftId { get; set; }
        [DataColum]
        public string NewLeftName { get; set; }
        [DataColum]
        public string NewLeftImage { get; set; }
        [DataColum]
        public string NewLeftLink { get; set; }
        [DataColum]
        public bool IsActive { get; set; }
        [DataColum]
        public string Culture { get; set; }

    }
}
