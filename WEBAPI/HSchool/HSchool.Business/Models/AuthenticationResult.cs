using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Models
{
    public class AuthenticationResult
    {
        [JsonProperty("authorizationToken")]
        public String AuthorizationToken { get; set; }

        [JsonProperty("isAuthorized")]
        public Boolean IsAuthorized { get; set; }

        [JsonProperty("userInfo")]
        public UserInfo UserInfo { get; set; }
    }
}
