using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HSchool.Business.Models
{
    public class ApplicationFormSearch
    {
        [DisplayName("Application #")]
        public int? ApplicationId { get; set; }

        [DisplayName("Applied Date")]
        public DateTime? AppliedDate { get; set; }

        [DisplayName("User Name")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DisplayName("Class")]
        public int? ClassId { get; set; }

        [DisplayName("Academic Year")]
        public int AcademicYear { get; set; }

        [DisplayName("Application Status")]
        public int? ApplicationStatus { get; set; }

        public int StartRow { get; set; }

        public int EndRow { get; set; }

        public string SortOn { get; set; }

        public string SortOrder { get; set; }

        public List<SelectListItem> ListClasses { get; set; }

        public List<SelectListItem> ListApplicationStatus { get; set; }


    }
}
