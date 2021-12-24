using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.Interface
{
    interface IPrdCategoriesProvider : IImportableDataProvider<PrdCategories>
    {
        List<PrdCategories> Search(string txtSearch, int startIndex, int pageCount, ref int totalItems);
    }
}
