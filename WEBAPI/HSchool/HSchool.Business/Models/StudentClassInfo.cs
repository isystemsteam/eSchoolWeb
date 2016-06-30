using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Models
{
    public class StudentClassInfo
    {
        [DisplayName("Standard to which admission in applied for")]
        public int ClassId { get; set; }

        public string ClassName { get; set; }

        public int SectionId { get; set; }

        public string SectionName { get; set; }

        [DisplayName("Academic Year")]
        public string AcademicYear { get; set; }
    }
}
