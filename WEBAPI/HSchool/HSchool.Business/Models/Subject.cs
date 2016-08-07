using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }

        [DisplayName("Subject")]
        public string SubjectName { get; set; }

        public bool IsSelected { get; set; }
        
    }
}
