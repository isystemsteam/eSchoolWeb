using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Models
{
    public class ModuleRolePrivilege
    {
        public List<RolePrivilege> RolePrivileges { get; set; }

        public List<ApplicationRole> Roles { get; set; }

        public List<ApplicationPrivilege> Privileges { get; set; }
    }
}
