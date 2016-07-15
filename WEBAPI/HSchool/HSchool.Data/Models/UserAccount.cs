using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Data.Models
{
    public class UserAccount 
    {
        public int UserId { get; set; }

        public string Title { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public int? Age { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string PlaceOfBirth { get; set; }

        public string BloodGroup { get; set; }

        public string Religion { get; set; }

        public string Nationality { get; set; }

        public int? Community { get; set; }

        public string MobileNumber { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }        

        public int UserStatus { get; set; }

        public bool IsVerified { get; set; }

        public bool IsLocked { get; set; }

        public bool SMSEnabled { get; set; }

        public bool EmailEnabled { get; set; }

        public bool NotoficationEnabled { get; set; }

        public int? MotherLanguage { get; set; }        

        public DateTime? UserLastLogin { get; set; }

        public int UserRole { get; set; }
    }
}
