using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Models
{
    public class SchoolHistory
    {
        public int SchoolHistoryId { get; set; }

        public int UserId { get; set; }

        public string SchoolName { get; set; }

        public string Location { get; set; }

        public string Telephone { get; set; }

        public DateTime YearEntered { get; set; }

        public DateTime YearLeft { get; set; }

        public string ReasonForLeaving { get; set; }

        public Decimal FinalMarksAverage { get; set; }

        public bool IsRecentSchool { get; set; }

    }
}
