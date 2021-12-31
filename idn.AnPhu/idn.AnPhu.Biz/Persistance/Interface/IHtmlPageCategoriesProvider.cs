﻿using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.Interface
{
    interface IHtmlPageCategoriesProvider : IImportableDataProvider<HtmlPageCategories>
    {
        List<HtmlPageCategories> Search(string txtSearch, int startIndex, int pageCount, ref int totalItems);
    }
}
