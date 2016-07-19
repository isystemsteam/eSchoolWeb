using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Models
{
    public class ApplicationFormSearch
    {
        public int? ApplicationFormId { get; set; }

        public DateTime AppliedDate { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ClassName { get; set; }
    }
}
