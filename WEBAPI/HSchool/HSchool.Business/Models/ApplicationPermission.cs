using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Models
{
    public class ApplicationPermission
    {
        public int ApplicationPermissionId { get; set; }

        public int RoleId { get; set; }

        public int ModuleId { get; set; }

        [DisplayName("Role Name")]
        public string RoleName { get; set; }

        [DisplayName("Module Name")]
        public string ModuleName { get; set; }

        public List<ApplicationRole> Roles { get; set; }

        public List<ApplicationPrivilege> Privileges { get; set; }
    }
}
