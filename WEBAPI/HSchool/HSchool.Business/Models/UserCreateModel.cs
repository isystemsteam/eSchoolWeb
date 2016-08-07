using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HSchool.Business.Models
{
    public class UserCreateModel : UserAccount
    {
        public bool IsEditable { get; set; }

        public List<SelectListItem> ListTitles { get; set; }

        public List<SelectListItem> ListGender { get; set; }

        public List<SelectListItem> ListLanguages { get; set; }

        public List<SelectListItem> ListCommunities { get; set; }

        public List<SelectListItem> ListRoles { get; set; }

        public List<SelectListItem> ListProofTypes { get; set; }
    }
}
