﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Data.Models
{
    public class StudentSearch
    {
        public int StartRow { get; set; }

        public int EndRow { get; set; }

        public string SortOrder { get; set; }

        public string SortOn { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string RollNumber { get; set; }

        public int? ClassId { get; set; }

        public int? SectionId { get; set; }

        public string Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }
}
