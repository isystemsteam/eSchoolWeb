using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HSchool.Business.Models
{
    public class AdmissionForm
    {
        public Student Student { get; set; }

        public StudentClass StudentClass { get; set; }

        public List<Classes> FormClasses { get; set; }

        public List<SelectListItem> ListClasses
        {
            get
            {
                List<SelectListItem> items = new List<SelectListItem>();
                if (this.FormClasses != null && this.FormClasses.Count > 0)
                {
                    items.AddRange(this.FormClasses.Select(s => new SelectListItem { Text = s.ClassName, Value = s.ClassId.ToString() }));
                }
                return items;
            }
        }

    }
}
