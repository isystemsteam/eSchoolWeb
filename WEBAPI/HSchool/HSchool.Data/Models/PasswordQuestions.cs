using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Data.Models
{
    public class PasswordQuestions
    {
        public int QuestionId { get; set; }

        public string Question { get; set; }

        public bool IsActive { get; set; }
    }
}
