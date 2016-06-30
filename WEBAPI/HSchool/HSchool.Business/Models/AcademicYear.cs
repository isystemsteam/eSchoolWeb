using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Models
{
    public class AcademicYear
    {
        public int AcademicYearId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }

        public string AcademicYearDisplay
        {
            get
            {
                return string.Format("{0}-{1}", StartDate.Year, EndDate.Year);
            }
        }
    }
}
