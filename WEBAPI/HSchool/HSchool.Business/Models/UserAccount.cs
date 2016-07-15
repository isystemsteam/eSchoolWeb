using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Models
{
    public class UserAccount
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("First Name")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("age")]
        public int? Age { get; set; }

        [JsonProperty("dateOfBirth")]
        public DateTime? DateOfBirth { get; set; }

        public string PlaceOfBirth { get; set; }

        [JsonProperty("bloodGroup")]
        public string BloodGroup { get; set; }

        [JsonProperty("religion")]
        public string Religion { get; set; }

        [JsonProperty("nationality")]
        public string Nationality { get; set; }

        [JsonProperty("community")]
        public int? Community { get; set; }

        [JsonProperty("mobileNumber")]
        public string MobileNumber { get; set; }

        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("modifiedDate")]
        public DateTime ModifiedDate { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("userStatusId")]
        public int UserStatusId { get; set; }

        [JsonProperty("isVerified")]
        public bool IsVerified { get; set; }

        [JsonProperty("isLocked")]
        public bool IsLocked { get; set; }

        [JsonProperty("smsEnabled")]
        public bool SMSEnabled { get; set; }

        [JsonProperty("emailEnabled")]
        public bool EmailEnabled { get; set; }

        [JsonProperty("notoficationEnabled")]
        public bool NotoficationEnabled { get; set; }

        [JsonProperty("motherLanguage")]
        public int? MotherLanguage { get; set; }

        public DateTime? UserLastLogin { get; set; }

        [JsonProperty("userStatus")]
        public UserStatusEnum UserStatus { get; set; }

        public int UserRole { get; set; }
        
    }
}
