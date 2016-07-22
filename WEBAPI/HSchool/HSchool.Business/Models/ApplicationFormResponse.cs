using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Models
{
    public class ApplicationFormResponse
    {
        public int ApplicationId { get; set; }

        public int UserId { get; set; }

        public string ApplicationStatus { get; set; }

        public DateTime? AppliedDate { get; set; }

        public DateTime? ApprovedDate { get; set; }

        public string ApprovedBy { get; set; }

        public bool IsVerified { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ClassName { get; set; }
    }
}
