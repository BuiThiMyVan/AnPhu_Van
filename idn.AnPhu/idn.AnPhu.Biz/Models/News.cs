using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
    class News : EntityBase
    {
        [DataColum]
        //[DataColumEx("UserCode")]
        public int NewsCategoryId { get; set; }

        [DataColum]
        public string NewsTitle { get; set; }

        [DataColum]
        public string NewsSummary { get; set; }

        [DataColum]
        public string NewsBody { get; set; }

        [DataColum]
        public string NewsDescription { get; set; }

        [DataColum]
        public string NewsKeyword { get; set; }

        [DataColum]
        public string CreateBy { get; set; }

        [DataColum]
        public bool IsActive { get; set; }

        [DataColum]
        public int OrderNo { get; set; }

        [DataColum]
        public string Culture { get; set; }

        [DataColum]
        public string NewsOther { get; set; }

        [DataColum]
        public string ProductTag { get; set; }

        [DataColum]
        public int Count { get; set; }

        [DataColum]
        public bool IsHotNews { get; set; }

        [DataColum]
        public string NewsShortName { get; set; }

        [DataColum]
        public string NewsImage { get; set; }

        [DataColum]
        public bool IsAdsNews { get; set; }
    }
}
