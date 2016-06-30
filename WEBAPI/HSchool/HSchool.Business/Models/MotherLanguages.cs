using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Models
{
    public class MotherLanguages
    {
        [JsonProperty("languageId")]
        public int LanguageId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
