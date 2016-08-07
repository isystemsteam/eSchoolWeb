using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Models
{
    public class ClassSubject
    {
        public int ClassSubjectId { get; set; }
        public int ClassId { get; set; }
        public int SectionId { get; set; }
        public string SubjectId { get; set; }
        public int AcademicYear { get; set; }
        public DateTime CreatedDate { get; set; }

        public List<int> SubjectIds { get; set; }

    }
}
