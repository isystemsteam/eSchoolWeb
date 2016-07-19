using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Data.Models
{
    public class ApplicationForm : Student
    {
        public int ApplicationId { get; set; }

        public int ApplicationStatus { get; set; }

        public DateTime? AppliedDate { get; set; }

        public DateTime? ApprovedDate { get; set; }

        public int? ApplicationType { get; set; }

        public int ApprovedBy { get; set; }

        public string ApprovedByText { get; set; }

        public Student Student { get; set; }

        public bool IsStudentUpdate { get; set; }
    }
}
