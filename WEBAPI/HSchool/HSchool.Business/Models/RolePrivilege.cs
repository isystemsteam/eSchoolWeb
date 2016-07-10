using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Models
{
    public class RolePrivilege
    {
        public int RolePrivilegeId { get; set; }

        public int ModuleId { get; set; }

        public int RoleId { get; set; }

        private string _privileges;
        public string Privileges
        {
            get
            {

                if (PrivilgeIds != null)
                {
                    _privileges = string.Join(",", PrivilgeIds);
                }
                return _privileges;
            }
            set
            {
                _privileges = value;
            }
        }


        public List<int> PrivilgeIds
        {
            get;
            set;
        }

        private List<int> _privilegeIds;
        public List<int> PrivilegeCollection
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Privileges))
                {
                    _privilegeIds = Privileges.Split(',').Select(int.Parse).ToList();
                }
                return _privilegeIds;
            }
            set
            {
                _privilegeIds = value;
            }
        }

        public int RowNumber { get; set; }
    }
}
