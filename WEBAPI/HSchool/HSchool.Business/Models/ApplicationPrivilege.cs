using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Models
{
    public class ApplicationPrivilege
    {
        public int PrivilegeId { get; set; }

        public string PrivilegeName { get; set; }

        public bool IsChecked { get; set; }
    }
}
