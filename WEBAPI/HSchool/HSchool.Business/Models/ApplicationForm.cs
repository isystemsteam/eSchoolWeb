using HSchool.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HSchool.Business.Models
{
    public class ApplicationForm : Student
    {
        public int ApplicationId { get; set; }

        [DisplayName("Application Status")]
        public int ApplicationStatus { get; set; }

        [DisplayName("Applied Date")]
        public DateTime? AppliedDate { get; set; }

        [DisplayName("Approved Date")]
        public DateTime? ApprovedDate { get; set; }

        public int ApplicationType { get; set; }

        public int? ApprovedBy { get; set; }

        [DisplayName("Approved By")]
        public string ApprovedByText { get; set; }        

        public bool IsOfficeFormEnabled { get; set; }

        public string ActionName { get; set; }

        public AcademicYear AcademicYear { get; set; }

        public bool IsStudentUpdate { get; set; }

        public IEnumerable<Classes> FormClasses { get; set; }

        public IEnumerable<MotherLanguages> Languages { get; set; }

        public IEnumerable<UserRelationship> RelationShips { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<SelectListItem> ApplicationStatuses
        {
            get
            {
                return CommonHelper.ConvertEnumToListItem<ApplicationStatus>();
            }
        }

        public IEnumerable<CommunityMaster> Communities { get; set; }        

        public List<SelectListItem> ListClasses
        {
            get
            {
                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(CommonHelper.GetFirstListItem());
                if (this.FormClasses != null && this.FormClasses.Count() > 0)
                {
                    items.AddRange(this.FormClasses.Select(s => new SelectListItem { Text = s.ClassName, Value = s.ClassId.ToString() }));
                }
                return items;
            }
        }

        public List<SelectListItem> ListCommunities
        {
            get
            {
                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(CommonHelper.GetFirstListItem());
                if (this.Communities != null && this.Communities.Count() > 0)
                {
                    items.AddRange(this.Communities.Select(s => new SelectListItem { Text = s.CommunityName, Value = s.CommunityId.ToString() }));
                }
                return items;
            }
        }

        public List<SelectListItem> ListTitles { get; set; }

        public List<SelectListItem> ListLanguages
        {
            get
            {
                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(CommonHelper.GetFirstListItem());
                if (this.Languages != null && this.Languages.Count() > 0)
                {
                    items.AddRange(this.Languages.Select(s => new SelectListItem { Text = s.Name, Value = s.LanguageId.ToString() }));
                }
                return items;
            }
        }

        public List<SelectListItem> ListRelationShips
        {
            get
            {
                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(CommonHelper.GetFirstListItem());
                if (this.RelationShips != null && this.RelationShips.Count() > 0)
                {
                    items.AddRange(this.RelationShips.Select(s => new SelectListItem { Text = s.Name, Value = s.RelationshipId.ToString() }));
                }
                return items;
            }
        }

        public List<SelectListItem> ListGender { get; set; }

    }
}
