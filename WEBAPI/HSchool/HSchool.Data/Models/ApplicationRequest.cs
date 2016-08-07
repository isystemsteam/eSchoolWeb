using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Data.Models
{
    public class ApplicationRequest
    {
        public string MobileNumber { get; set; }

        public string Email { get; set; }

        public string OneTimePassword { get; set; }

        public bool IsStudentAlreadyAvailable { get; set; }        
    }
}
