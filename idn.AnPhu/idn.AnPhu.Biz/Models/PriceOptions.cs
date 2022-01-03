using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
    public class PriceOptions : EntityBase
    {
        [DataColum]
        public int PriceOptionId { get; set; }

        [DataColum]
        public string PriceOptionTitle { get; set; }

        [DataColum]
        public decimal PriceOptionValue { get; set; }

        [DataColum]
        public bool IsActive { get; set; }

        [DataColum]
        public DateTime CreateDate { get; set; }

        [DataColum]
        public int OrderNo { get; set; }

        [DataColum]
        public string CreateBy { get; set; }
    }
}
