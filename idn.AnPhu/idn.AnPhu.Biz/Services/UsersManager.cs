using Client.Core.Data;
using Client.Core.Data.Entities.Paging;
using Client.Core.Utils;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Services
{
    public class UsersManager : DataManagerBase<Users>
    {
        public UsersManager(IDataProvider<Users> provider)
           : base(provider)
        {
        }

        IUsersProvider UsersProvider
        {
            get
            {
                return (IUsersProvider)Provider;
            }
        }

        public List<Users> GetAll()
        {
            int total = 0;
            return UsersProvider.GetAll(0, 0, ref total);
        }

        public void Promote(string userId)
        {
            UsersProvider.Promote(userId);
        }

        public void Demote(string userId)
        {
            UsersProvider.Demote(userId);
        }

        public void Active(string userId)
        {
            UsersProvider.Active(userId);
        }

        public void ChangePass(string userName, string pass)
        {
            var passSalt = EncryptUtils.GenerateSalt();
            pass = EncryptUtils.EncryptPassword(pass, passSalt);
            UsersProvider.ChangePass(userName, pass, passSalt);
        }


        public PageInfo<Users> Search(string txtSearch, int pageIndex, int pageSize)
        {
            int totalItems = 0;
            var pageInfo = new PageInfo<Users>(pageIndex, pageSize);
            var startIndex = (pageIndex - 1) * pageSize;
            pageInfo.DataList = UsersProvider.Search(txtSearch, startIndex, pageSize, ref totalItems);
            pageInfo.ItemCount = totalItems;
            return pageInfo;
        }
    }
}
