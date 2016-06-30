using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Models
{
    public class UserSecurity
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("securityKey")]
        public string SecurityKey { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("guardianPassword")]
        public string GuardianPassword { get; set; }

        [JsonProperty("passwordFormat")]
        public string PasswordFormat { get; set; }

        [JsonProperty("passwordQuestion")]
        public int PasswordQuestion { get; set; }

        [JsonProperty("passwordAnswer")]
        public string PasswordAnswer { get; set; }

        [JsonProperty("userLastLogin")]
        public DateTime? UserLastLogin { get; set; }

        [JsonProperty("guardianLastLogin")]
        public DateTime? GuardianLastLogin { get; set; }
    }
}
