using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Data.Models
{
    public class ClassSection 
    {
        public int ClassId { get; set; }

        public int SectionId { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }


        public string ClassName { get; set; }

        public string SectionName { get; set; }
    }
}
