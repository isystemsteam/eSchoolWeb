using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HSchool.Business.Models
{
    public class UserSearch
    {
        public int? UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? Gender { get; set; }

        public int? ApplicationRole { get; set; }

        public int? UserStatus { get; set; }

        public List<SelectListItem> ListGender { get; set; }

        public List<SelectListItem> ListRoles { get; set; }
    }
}
