using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
    public class HtmlPageCategories : EntityBase
    {
        [DataColum]
        public int HtmlPageCategoryId { get; set; }

        [DataColum]
        public int ParentId { get; set; }

        [DataColum]
        public string HtmlPageCategoryTitle {get; set;}

        [DataColum]
        public string HtmlPageCategoryTilteParent { get; set; }

        [DataColum]
        public string HtmlPageCategoryShortName { get; set; }

        [DataColum]
        public string HtmlPageCategorySummary { get; set; }

        [DataColum]
        public string HtmlPageCategoryDescription { get; set; }

        [DataColum]
        public string HtmlPageCategoryKeyword { get; set; }

        [DataColum]
        public DateTime CreateDate { get; set; }

        [DataColum]
        public string CreateBy { get; set; }

        [DataColum]
        public bool IsActive { get; set; }

        [DataColum]
        public int OrderNo { get; set; }

        [DataColum]
        public string Culture { get; set; }

        public int HLevel
        {
            get;
            set;
        }
        public string HlevelTitle
        {
            get
            {
                if (HLevel > 0)
                {
                    var l = "";
                    for (var i = 1; i <= HLevel; ++i)
                    {
                        l += "|--";
                    }
                    return string.Format("{0}{1}", l, HtmlPageCategoryTitle);

                }

                return HtmlPageCategoryTitle;
            }
        }

    }
}
