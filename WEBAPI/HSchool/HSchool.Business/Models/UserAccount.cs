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
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Email")]
        [JsonProperty("email")]
        public string Email { get; set; }

        [DisplayName("Gender")]
        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("age")]
        public int? Age { get; set; }

        [JsonProperty("dateOfBirth")]
        [DisplayName("Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [DisplayName("Place Of Birth")]
        public string PlaceOfBirth { get; set; }

        [JsonProperty("bloodGroup")]
        [DisplayName("Place Of Birth")]
        public string BloodGroup { get; set; }

        [JsonProperty("religion")]
        public string Religion { get; set; }

        public string Caste { get; set; }

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
        public int UserStatus { get; set; }

        [JsonProperty("isVerified")]
        public bool IsVerified { get; set; }

        [JsonProperty("isLocked")]
        public bool IsLocked { get; set; }

        [JsonProperty("smsEnabled")]
        public bool SMSEnabled { get; set; }

        [JsonProperty("emailEnabled")]
        public bool EmailEnabled { get; set; }

        [JsonProperty("notificationEnabled")]
        public bool NotificationEnabled { get; set; }

        [JsonProperty("motherLanguage")]
        public int? MotherLanguage { get; set; }

        public DateTime? UserLastLogin { get; set; }

        public int UserRole { get; set; }

        public byte[] UserImage { get; set; }

    }
}
