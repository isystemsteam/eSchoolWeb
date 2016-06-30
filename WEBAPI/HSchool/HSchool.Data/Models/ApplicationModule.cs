using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Data.Models
{
    public class ApplicationModule
    {
        public int ModuleId { get; set; }

        public string ModuleName { get; set; }

        public bool IsActive { get; set; }
    }
}
