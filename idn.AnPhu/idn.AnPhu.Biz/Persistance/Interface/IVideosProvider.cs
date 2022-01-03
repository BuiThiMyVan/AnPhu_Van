﻿using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.Interface
{
    interface IVideosProvider : IImportableDataProvider<Videos>
    {
        List<Videos> Search(string txtSearch, int startIndex, int pageCount, ref int totalItems);
    }
}
