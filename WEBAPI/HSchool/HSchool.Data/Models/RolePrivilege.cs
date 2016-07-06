using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Data.Models
{
    public class RolePrivilege
    {
        public int RolePrivilegeId { get; set; }

        public int RoleId { get; set; }

        public string Privileges { get; set; }

        public int ModuleId { get; set; }

        public int RowNumber { get; set; }
    }
}
