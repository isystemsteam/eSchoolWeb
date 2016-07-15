using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Models
{
    public class Classes
    {
        [JsonProperty("classId")]
        [DisplayName("Class Id")]
        public int ClassId { get; set; }

        [JsonProperty("className")]
        [DisplayName("Class Name")]
        public string ClassName { get; set; }

        [JsonProperty("nameInLetter")]
        [DisplayName("Name In Letter")]
        public int NameInDigit { get; set; }

        [JsonProperty("isVisibleToApplication")]
        [DisplayName("Visible In Application")]
        public bool IsVisibleToApplication { get; set; }
    }
}
