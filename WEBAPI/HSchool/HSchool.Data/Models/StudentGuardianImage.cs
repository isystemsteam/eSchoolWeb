using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Data.Models
{
    public class StudentGuardianImage
    {
        public int StudentGuardianImageId { get; set; }

        public int GuardianId { get; set; }

        public int ImageId { get; set; }
    }
}
