using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Models
{
    public class Student : UserAccount
    {
        public Int32 StudentId { get; set; }

        [DisplayName("Fluency In Others")]
        public string FluencyinOthers { get; set; }

        [DisplayName("Transport Facility Required")]
        public bool IsTransportRequired { get; set; }

        public string RollNumber { get; set; }

        public bool LoginEnabled { get; set; }

        public bool GuardianLoginEnabled { get; set; }

        public List<StudentClass> StudentClass { get; set; }

        [DisplayName("Visible Mark")]
        public bool VisibleMark { get; set; }

        [JsonProperty("userGuardians")]
        public List<StudentGuardian> StudentGuardians { get; set; }

        public List<Address> Addresses { get; set; }
        
    }
}
