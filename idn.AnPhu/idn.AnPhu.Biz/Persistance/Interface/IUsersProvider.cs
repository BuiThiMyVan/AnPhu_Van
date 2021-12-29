using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.Interface
{
    interface IUsersProvider : IImportableDataProvider<Users>
    {
        List<Users> Search(string txtSearch, int startIndex, int pageCount, ref int totalItems);
        void Promote(string userId);

        void Demote(string userId);

        void Active(string userId);
    }
}
