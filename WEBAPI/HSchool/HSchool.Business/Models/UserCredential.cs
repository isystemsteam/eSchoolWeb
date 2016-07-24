using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HSchool.Business.Models
{
    public class UserCredential
    {
        [JsonProperty("userName")]
        [DisplayName("UserName")]
        public string UserName { get; set; }

        [JsonProperty("password")]
        [DisplayName("Password")]
        public string Password { get; set; }

        public int RoleId { get; set; }

        public List<SelectListItem> Roles { get; set; }
    }
}
