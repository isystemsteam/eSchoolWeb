﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Models
{
    public class StudentClass
    {
        public int StudentClassId { get; set; }

        public int StudentId { get; set; }
        [DisplayName("Class Name")]
        public int ClassId { get; set; }

        public string ClassName { get; set; }

        public Int32 SectionId { get; set; }

        public string SectionName { get; set; }

        [DisplayName("Academic Year")]
        public int AcademicYear { get; set; }

        public DateTime? StartDateYear { get; set; }

        public DateTime? EndDateYear { get; set; }
    }
}
