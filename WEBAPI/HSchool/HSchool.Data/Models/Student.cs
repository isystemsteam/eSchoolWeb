using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Data.Models
{
    public class Student:UserAccount
    {
        public Int32 StudentId { get; set; }        

        public string StudentRollNumber { get; set; }        

        public string FluencyinOthers { get; set; }

        public bool IsTransportRequired { get; set; }

        public StudentClass StudentClassInfo { get; set; }

        public List<StudentGuardian> StudentGuardians { get; set; }
    }
}
