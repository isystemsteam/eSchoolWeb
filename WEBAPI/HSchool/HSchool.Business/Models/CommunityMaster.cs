using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Models
{
    public class CommunityMaster
    {
        [JsonProperty("communityId")]
        public int CommunityId { get; set; }

        [JsonProperty("communityName")]
        public string CommunityName { get; set; }
    }
}
