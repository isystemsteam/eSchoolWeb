﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Data.Models
{
    public class ClassSubject
    {
        public int ClassSubjectId { get; set; }
        public int ClassId { get; set; }
        public int SectionId { get; set; }
        public int SubjectId { get; set; }
        public int AcademicYear { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
