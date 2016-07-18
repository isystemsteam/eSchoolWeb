using HSchool.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HSchool.Business.Models
{
    public class ApplicationForm
    {
        public int ApplicationId { get; set; }

        public int ApplicationStatus { get; set; }

        public DateTime? AppliedDate { get; set; }

        public DateTime? ApprovalDate { get; set; }

        public int ApplicationType { get; set; }

        public int? ApprovedBy { get; set; }

        public string ApprovedByText { get; set; }

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

        /// <summary>
        /// 
        /// </summary>
        public List<SelectListItem> ApplicationStatuses
        {
            get
            {
                return CommonHelper.ConvertEnumToListItem<ApplicationStatus>();
            }
        }

        public bool IsOfficeFormEnabled { get; set; }

        public string ActionName { get; set; }

        public AcademicYear AcademicYear { get; set; }

        public List<CommunityMaster> Communities { get; set; }

        public List<SelectListItem> ListCommunities
        {
            get
            {
                List<SelectListItem> items = new List<SelectListItem>();
                if (this.Communities != null && this.Communities.Count > 0)
                {
                    items.AddRange(this.Communities.Select(s => new SelectListItem { Text = s.CommunityName, Value = s.CommunityId.ToString() }));
                }
                return items;
            }
        }

    }
}
