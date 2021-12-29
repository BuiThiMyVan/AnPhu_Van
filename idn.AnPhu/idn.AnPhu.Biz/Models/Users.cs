using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
    public class Users : EntityBase
    {
        [DataColum]
        public string UserId { get; set; }

        [DataColum]
        public string UserName { get; set; }

        [DataColum]
        public string Email { get; set; }

        [DataColum]
        public bool IsActive { get; set; }

        [DataColum]
        public DateTime CreateDate { get; set; }

        [DataColum]
        public int UserRole { get; set; }

        [DataColum]
        public string GroupRoleName { get; set; }

        [DataColum]
        public string GroupRoleCode { get; set; }
    }
}
