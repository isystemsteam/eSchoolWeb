using HSchool.Common;
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
        public int Title { get; set; }

        [DisplayName("Title")]
        public string TitleDisplay
        {
            get
            {
                return CommonHelper.GetEnumText<Titles>(this.Title);
            }
        }

        [DisplayName("First Name")]
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        [DisplayName("Email")]
        public string Email { get; set; }

        public int? Gender { get; set; }

        [DisplayName("Gender")]
        public string GenderDisplay
        {
            get
            {
                return CommonHelper.GetEnumText<Gender>(this.Gender);
            }
        }

        [JsonProperty("releationShip")]
        public int? ReleationShip { get; set; }

        [DisplayName("ReleationShip")]
        public string ReleationShipName { get; set; }

        [JsonProperty("occupation")]
        public string Occupation { get; set; }

        [JsonProperty("Date Of Birth")]
        [DisplayName("Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [DisplayName("Annual Income")]
        [JsonProperty("annualIncome")]
        public double? AnnualIncome { get; set; }

        [DisplayName("Mobile Number")]
        [JsonProperty("mobileNumber")]
        public string MobileNumber { get; set; }

        [JsonProperty("officeNumber")]
        [DisplayName("Office Number")]
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
