using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Data.Models
{
    public class StudentImage
    {
        public int StudentImageId { get; set; }

        public int StudentId { get; set; }

        public int ImageId { get; set; }
    }
}
