using Client.Core.Data.Entities.Paging;
using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.Interface
{
    interface INewsCategoriesProvider : IImportableDataProvider<NewsCategories>
    {
        List<NewsCategories> Search(string txtSearch, int startIndex, int pageCount, ref int totalItems);

        List<NewsCategories> GetAllActive();
    }
}
