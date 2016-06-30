using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Models
{
    public class Section
    {
        [JsonProperty("sectionId")]
        public int SectionId { get; set; }

        [JsonProperty("sectionName")]
        [DisplayName("Section Name")]
        public string SectionName { get; set; }
    }
}
