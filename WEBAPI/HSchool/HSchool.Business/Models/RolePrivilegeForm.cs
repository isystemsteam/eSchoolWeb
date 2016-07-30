using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HSchool.Business.Models
{
    public class RolePrivilegeForm
    {

        public List<SelectListItem> ListRoles { get; set; }

        public List<ApplicationModule> Modules { get; set; }
    }
}
