using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Models
{
    public class Address
    {
        public int AddressId { get; set; }

        public string DoorNo { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string Taluk { get; set; }

        public string District { get; set; }

        public string PinCode { get; set; }


    }
}
