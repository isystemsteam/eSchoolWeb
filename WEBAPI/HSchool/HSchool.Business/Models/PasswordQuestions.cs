using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Models
{
    public class PasswordQuestions
    {
        [JsonProperty("questionId")]
        public int QuestionId { get; set; }

        [JsonProperty("question")]
        public string Question { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
    }    
}
