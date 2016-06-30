using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Data.Models
{
    public class Classes
    {
        public int ClassId { get; set; }

        public string ClassName { get; set; }

        public string NameInLetter { get; set; }

        public bool IsVisibleToApplication { get; set; }
    }
}
