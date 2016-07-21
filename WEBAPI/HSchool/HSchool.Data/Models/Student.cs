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

        public bool VisibleMark { get; set; }

        public string RollNumber { get; set; }

        public bool LoginEnabled { get; set; }

        public List<StudentClass> StudentClass { get; set; }

        public byte[] StudentImage { get; set; }

        public List<StudentGuardian> StudentGuardians { get; set; }

        public List<Address> Addresses { get; set; }
    }
}
