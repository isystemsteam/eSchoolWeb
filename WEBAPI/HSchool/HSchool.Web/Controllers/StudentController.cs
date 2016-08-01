using HSchool.Business.Models;
using HSchool.Business.Repository;
using HSchool.Common;
using HSchool.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HSchool.Web.Controllers
{
    public class StudentController : Controller
    {
        #region Variables
        private readonly IAdminRepository _adminRepository;
        private readonly IStudentRepository _studentRepository;
        #endregion

        #region Ctor
        public StudentController(IAdminRepository adminRepository, IStudentRepository studentRepository)
        {
            _adminRepository = adminRepository;
            _studentRepository = studentRepository;
        }
        #endregion

        #region Actions
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [CustomAuthentication]
        public ActionResult Index()
        {
            LogHelper.Info(string.Format("StudentController.Index - Begin"));
            var studentSearch = new StudentSearch();
            studentSearch.ListClasses = CommonHelper.ConvertListToSelectList<Classes>(_adminRepository.GetAllClasses(false), "Classes", "ClassId", "ClassName");
            studentSearch.ListSections = CommonHelper.ConvertListToSelectList<Section>(new List<Section>(), "Sections", "SectionId", "SectionName");
            studentSearch.ListGender = CommonHelper.ConvertEnumToListItem<Gender>("Gender");
            LogHelper.Info(string.Format("StudentController.Index - End"));
            return View(studentSearch);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SearchStudents(StudentSearch search)
        {
            LogHelper.Info(string.Format("ApplicationController.SearchStudents - Begin"));
            try
            {
                search.StartRow = 0;
                search.EndRow = 10;
                var result = _studentRepository.SearchStudents(search);
                var response = new GridViewTable
                {
                    Columns = new List<GridColumn> { 
                        new GridColumn { ColumnName = "Roll Number" }, 
                        new GridColumn { ColumnName = "First Name" }, 
                        new GridColumn { ColumnName = "Last Name" },
                        new GridColumn { ColumnName = "Gender" },
                        new GridColumn { ColumnName = "DOB" },
                        new GridColumn { ColumnName = "Class" },
                        new GridColumn { ColumnName = "Section" },
                        new GridColumn { ColumnName = "Transport Required" },
                        new GridColumn { ColumnName = "Guardian Name" }                        
                    },
                    Rows = new List<GridViewRow> { }
                };

                var rows = new List<GridViewRow>();
                foreach (var item in result)
                {
                    var cells = new List<GridViewCell>();
                    string id = Convert.ToString(item.StudentId);
                    cells.Add(new GridViewCell { Value = CreateApplicationDetailsTag(id, item.RollNumber, "Details", "View Student Details") });
                    cells.Add(new GridViewCell { Value = Convert.ToString(item.RollNumber) });
                    cells.Add(new GridViewCell { Value = Convert.ToString(item.FirstName) });
                    cells.Add(new GridViewCell { Value = Convert.ToString(item.LastName) });
                    cells.Add(new GridViewCell { Value = Convert.ToString(item.ClassName) });
                    cells.Add(new GridViewCell { Value = Convert.ToString(item.ClassName) });
                    cells.Add(new GridViewCell { Value = Convert.ToString(item.ClassName) });
                    cells.Add(new GridViewCell { Value = Convert.ToString(item.SectionName) });
                    cells.Add(new GridViewCell { Value = Convert.ToString(item.GuardianName) });
                    rows.Add(new GridViewRow { Cells = cells });
                }
                response.Rows = rows;
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogHelper.Info(string.Format("ApplicationController.SearchStudents - Exception:{0}", ex.Message));
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Private
        private string CreateApplicationDetailsTag(string innerText, string id, string actionName, string title)
        {
            var tagBuilder = new TagBuilder("a");
            tagBuilder.MergeAttribute("id", id);
            tagBuilder.MergeAttribute("href", Url.Action(actionName, "Student", new { id }));
            tagBuilder.MergeAttribute("class", "");
            tagBuilder.MergeAttribute("title", title);
            tagBuilder.InnerHtml = innerText;
            return tagBuilder.ToString();
        }
        #endregion
    }
}