using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Data.Models
{
    public class ClassSectionTeacher
    {
        public int ClassSectionTeacherId { get; set; }
        public int UserId { get; set; }
        public int ClassId { get; set; }
        public int SectionId { get; set; }
        public int AcademicYearId { get; set; }
    }
}
