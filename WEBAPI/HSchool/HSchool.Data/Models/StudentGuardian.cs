using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Data.Models
{
    public class StudentGuardian
    {
        public int StudentId { get; set; }
        public int GuardianId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? ReleationShip { get; set; }
        public string Occupation { get; set; }

        public string HighestQualification { get; set; }

        public string Email { get; set; }

        public int? Age { get; set; }
        public double? AnnualIncome { get; set; }
        public bool IsSameAsUserAddress { get; set; }
        public string MobileNumber { get; set; }
        public string OfficeNumber { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool PrimaryGuardian { get; set; }
        public bool SMSEnabled { get; set; }
        public bool NotificationEnabled { get; set; }

        public int Role { get; set; }

    }
}
