using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Models
{
    public class StudentGuardian
    {
        public int StudentId { get; set; }
        
        [JsonProperty("guardianId")]
        public int GuardianId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        [DisplayName("Email")]
        public string Email { get; set; }

        public int? Gender { get; set; }

        [JsonProperty("releationShip")]
        public int? ReleationShip { get; set; }

        [JsonProperty("occupation")]
        public string Occupation { get; set; }

        [JsonProperty("age")]
        public int? Age { get; set; }

        [JsonProperty("annualIncome")]
        public double? AnnualIncome { get; set; }        

        [JsonProperty("mobileNumber")]
        public string MobileNumber { get; set; }

        [JsonProperty("officeNumber")]
        public string OfficeNumber { get; set; }  

        [JsonProperty("primaryGuardian")]
        public bool PrimaryGuardian { get; set; }

        [JsonProperty("smsEnabled")]
        public bool SMSEnabled { get; set; }

        [JsonProperty("notificationEnabled")]
        public bool NotificationEnabled { get; set; }

        [JsonProperty("isSameAsUserAddress")]
        public bool IsSameAsUserAddress { get; set; }

        public string HighestQualification { get; set; }

        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("modifiedDate")]
        public DateTime ModifiedDate { get; set; }

        [JsonProperty("isDeleted")]
        public bool IsDeleted { get; set; }

        public int Role { get; set; }
    }
}
