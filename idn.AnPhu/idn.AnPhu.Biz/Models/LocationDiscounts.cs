using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
    public class LocationDiscounts : EntityBase
    {
        [DataColum]
        public int LocationDiscountId { get; set; }

        [DataColum]
        public string LocationDiscountName { get; set; }

        [DataColum]
        public int LocationDiscountValue { get; set; }

        [DataColum]
        public int LocationValue { get; set; }


        [DataColum]
        public bool IsActive { get; set; }

        [DataColum]
        public DateTime CreateDate { get; set; }

        [DataColum]
        public int OrderNo { get; set; }

        [DataColum]
        public string CreateBy { get; set; }

        public string CreateDateFormat
        {
            get
            {
                return CreateDate == null ? "" : CreateDate.ToString("dd/MM/yyyy");
            }
        }

        [DataColum]
        public string Culture { get; set; }
    }
}
