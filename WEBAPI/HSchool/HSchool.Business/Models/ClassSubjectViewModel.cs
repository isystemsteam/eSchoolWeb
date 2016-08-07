using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HSchool.Business.Models
{
    public class ClassSubjectViewModel
    {
        public List<Classes> Classes { get; set; }

        public List<SelectListItem> ListClasses { get; set; }

        public List<Section> Sections { get; set; }

        public List<SelectListItem> ListSections { get; set; }

        public List<Subject> Subjects { get; set; }
    }
}
