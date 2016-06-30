using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Models
{
    public class ApplicationRole
    {
        [JsonProperty("roleId")]
        public int RoleId { get; set; }

        [JsonProperty("roleName")]
        [DisplayName("Role")]
        public string RoleName { get; set; }

        [JsonProperty("isActive")]
        [DisplayName("Role")]
        public bool IsActive { get; set; }

        [JsonProperty("visibleToLogin")]
        public bool VisibleToLogin { get; set; }

        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("modifiedDate")]
        public DateTime ModifiedDate { get; set; }
    }
}
