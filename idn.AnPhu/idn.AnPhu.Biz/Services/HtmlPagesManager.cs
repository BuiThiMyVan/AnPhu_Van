﻿using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Services
{
    public class HtmlPagesManager : DataManagerBase<HtmlPages>
    {
        public HtmlPagesManager(IDataProvider<HtmlPages> provider)
           : base(provider)
        {
        }

        IHtmlPagesProvider HtmlPagesProvider
        {
            get
            {
                return (IHtmlPagesProvider)Provider;
            }
        }

        public List<HtmlPages> GetAll()
        {
            int total = 0;
            return HtmlPagesProvider.GetAll(0, 0, ref total);
        }

        public override void Add(HtmlPages item)
        {
            base.Add(item);
        }
    }
}