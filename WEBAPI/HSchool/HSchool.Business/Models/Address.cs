using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        [DisplayName("Door No")]
        public string DoorNo { get; set; }

        [DisplayName("AddressLine 1")]
        public string AddressLine1 { get; set; }

        [DisplayName("AddressLine 2")]
        public string AddressLine2 { get; set; }

        [DisplayName("Taluk")]
        public string Taluk { get; set; }

        [DisplayName("District")]
        public string District { get; set; }

        [DisplayName("Pincode")]
        public string PinCode { get; set; }


    }
}
