using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HSchool.Business.Models
{
    public class ClassSectionForm
    {
        public List<SelectListItem> ListClasses { get; set; }

        public List<Classes> ClassCollection { get; set; }

        public List<Section> SectionCollection { get; set; }
    }
}
