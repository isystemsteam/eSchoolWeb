﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Models
{
    public class StudentSearchResponse
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string RollNumber { get; set; }

        public string StudentName { get; set; }

        public string ClassName { get; set; }

        public string SectionName { get; set; }

        public string GuardianName { get; set; }

        public DateTime? DOB { get; set; }

        public string IsTransportRequired { get; set; }

        public bool LoginEnabled { get; set; }

        
    }
}
