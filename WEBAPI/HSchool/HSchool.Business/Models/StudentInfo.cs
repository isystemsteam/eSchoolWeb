using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Models
{
    public class StudentInfo : UserInfo
    {
        [DisplayName("Fluency In Others")]
        public string FluencyinOthers { get; set; }

        [DisplayName("Transport Facility Required")]
        public bool IsTransportRequired { get; set; }

        [DisplayName("Place Of Birth")]
        public string PlaceOfBirth { get; set; } 
    }
}
