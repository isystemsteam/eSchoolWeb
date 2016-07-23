using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Data.Models
{
    public class ApplicationFormSearch
    {
        public int? ApplicationId { get; set; }

        public DateTime? AppliedDate { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? ClassId { get; set; }

        public int AcademicYear { get; set; }

        public int? ApplicationStatus { get; set; }

        public int StartRow { get; set; }

        public int EndRow { get; set; }

        public string SortOn { get; set; }

        public string SortOrder { get; set; }
    }
}
