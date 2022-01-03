using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
    public class HtmlPageCategoriesBase : EntityBase
    {
        [DataColum]
        public int HtmlPageCategoryId { get; set; }

        [DataColum]
        public int ParentId { get; set; }

        [DataColum]
        public string HtmlPageCategoryTitle { get; set; }

        private HtmlPageCategoriesBase _parent;
        public HtmlPageCategoriesBase Parent
        {
            get
            {
                _parent = new HtmlPageCategoriesBase()
                {
                    HtmlPageCategoryId = ParentId
                };
                return ParentId == 0 ? null : _parent;
            }
            set { _parent = value; }
        }

        public List<HtmlPageCategoriesBase> Children { get; set; }

        private int hLevel
        {
            get
            {
                return -1;
            }
            set
            {
                this.hLevel = value;
            }
        }


        public int HLevel
        {
            get
            {
                if (hLevel > 0) return hLevel;
                if (Parent != null) return Parent.HLevel + 1;
                return 0;
            }
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
