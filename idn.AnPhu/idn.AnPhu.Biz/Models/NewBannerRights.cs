using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
    public class NewBannerRights : EntityBase
    {
        [DataColum]
        public int NewRightId { get; set; }
        [DataColum]
        public string NewRightName { get; set; }
        [DataColum]
        public string NewRightImage { get; set; }
        [DataColum]
        public string NewRightLink { get; set; }
        [DataColum]
        public bool IsActive { get; set; }
        [DataColum]
        public string Culture { get; set; }

    }
}
