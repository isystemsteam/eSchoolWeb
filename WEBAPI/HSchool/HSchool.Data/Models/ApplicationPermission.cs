using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Data.Models
{
    public class ApplicationPermission
    {

        public int ApplicationPermissionId { get; set; }

        public int RoleId { get; set; }

        public int ModuleId { get; set; }
        
        public string RoleName { get; set; }
        
        public string ModuleName { get; set; }

        public string Privileges { get; set; }
    }
}
