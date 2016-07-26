using HSchool.Business.Models;
using HSchool.Business.Repository;
using HSchool.Common;
using HSchool.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HSchool.WebApi.Controllers
{
    public class ApplicationController : Controller
    {
        #region Fields
        private readonly IAdminRepository _adminRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IApplicationRepository _applicationRepository;
        #endregion

        #region Ctor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="adminRepository"></param>
        public ApplicationController(IAdminRepository adminRepository, IStudentRepository studentRepository, IApplicationRepository applicationRepository)
        {
            _adminRepository = adminRepository;
            _studentRepository = studentRepository;
            _applicationRepository = applicationRepository;
        }
        #endregion

        #region Actions
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            LogHelper.Info(string.Format("ApplicationController.Index - Begin"));
            var applicationForm = CreateApplicationForm(null, true);
            applicationForm.IsOfficeFormEnabled = false;
            applicationForm.IsStudentAddressUpdate = true;
            applicationForm.IsStudentGuardianUpdate = true;
            applicationForm.IsEditable = true;
            LogHelper.Info(string.Format("ApplicationController.Index - End"));
            return View(applicationForm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Details(int id)
        {
            LogHelper.Info(string.Format("ApplicationController.OfficeForm - Begin"));
            try
            {
                var applicationForm = _applicationRepository.GetApplicationById(id);
                applicationForm.IsEditable = false;
                LogHelper.Info(string.Format("ApplicationController.OfficeForm - End"));
                return View(applicationForm);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ApplicationForm model, FormCollection collection)
        {
            LogHelper.Info(string.Format("ApplicationController.Edit - Begin"));
            try
            {
                int? id = null;
                MessageResponse response = null;
                //if (ModelState.IsValid)
                //{
                model.IsStudentUpdate = true;
                model.UserStatus = (int)UserStatusEnum.Registered;
                model.RollNumber = "123456";
                model.VisibleMark = false;
                model.ApplicationStatus = (int)ApplicationStatus.Submitted;
                id = _applicationRepository.SaveApplication(model);
                response = new MessageResponse<string>(id.HasValue ? id.ToString() : string.Empty, WebConstants.StatusSuccess, (int)HttpStatusCode.OK, string.Empty);
                //}
                //else
                //{
                //    response = new MessageResponse<string>(id.HasValue ? id.ToString() : string.Empty, WebConstants.StatusFailure, (int)HttpStatusCode.ExpectationFailed, "Invalid Request. Please validate the mandatory fields.");
                //}
                LogHelper.Info(string.Format("ApplicationController.Edit - End"));
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogHelper.Info(string.Format("ApplicationController.Edit - Exception:{0}", ex.Message));
                var response = new MessageResponse<string>(string.Empty, WebConstants.StatusFailure, (int)HttpStatusCode.ExpectationFailed, ex.Message);
                return Json(response, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult EditOfficeForm(int id)
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditOfficeForm(ApplicationForm model, FormCollection collection)
        {
            LogHelper.Info(string.Format("ApplicationController.Edit - Begin"));
            MessageResponse response = null;
            try
            {
                int? id = null;
                if (ModelState.IsValid)
                {
                    model.IsStudentUpdate = true;
                    model.UserStatus = (int)UserStatusEnum.Registered;
                    model.RollNumber = "123456";
                    model.VisibleMark = false;
                    model.ApplicationStatus = (int)ApplicationStatus.Submitted;
                    id = _applicationRepository.SaveApplication(model);
                    response = new MessageResponse<string>(id.HasValue ? id.ToString() : string.Empty, WebConstants.StatusSuccess, (int)HttpStatusCode.OK, string.Empty);
                }
                else
                {
                    response = new MessageResponse<string>(id.HasValue ? id.ToString() : string.Empty, WebConstants.StatusFailure, (int)HttpStatusCode.ExpectationFailed, "Invalid Request. Please validate the mandatory fields.");
                }
                LogHelper.Info(string.Format("ApplicationController.Edit - End"));
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                response = new MessageResponse<string>(ex.Message, WebConstants.StatusFailure, (int)HttpStatusCode.ExpectationFailed, ex.Message);
                return Json(response, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Success(int id)
        {
            LogHelper.Info(string.Format("ApplicationController.Success - Begin"));
            try
            {
                return View(id);
            }
            catch (Exception ex)
            {
                LogHelper.Info(string.Format("ApplicationController.Success - Exception:{0}", ex.Message));
                return View();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Status()
        {
            LogHelper.Info(string.Format("ApplicationController.Status - Begin"));
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dateOfBirth"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetOnlineApplicationStatus(int id, DateTime dateOfBirth)
        {
            LogHelper.Info(string.Format("ApplicationController.Status - Begin"));
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                LogHelper.Info(string.Format("ApplicationController.Status - Exception:{0}", ex.Message));
                return View();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formSearch"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SearchApplications(ApplicationFormSearch formSearch)
        {
            LogHelper.Info(string.Format("ApplicationController.SearchApplications - Begin"));
            try
            {
                formSearch.StartRow = 0;
                formSearch.EndRow = 10;
                var result = _applicationRepository.SearchApplications(formSearch);
                var response = new GridViewTable
                {
                    Columns = new List<GridColumn> { 
                        new GridColumn { ColumnName = "Application Id" }, 
                        new GridColumn { ColumnName = "Application Status" }, 
                        new GridColumn { ColumnName = "Applied Date" },
                        new GridColumn { ColumnName = "First Name" },
                        new GridColumn { ColumnName = "Last Name" },
                        new GridColumn { ColumnName = "Class" } 
                    },
                    Rows = new List<GridViewRow> { }
                };

                var rows = new List<GridViewRow>();
                foreach (var item in result)
                {
                    var cells = new List<GridViewCell>();
                    string id = Convert.ToString(item.ApplicationId);
                    cells.Add(new GridViewCell { Value = CreateApplicationDetailsTag(id, id) });
                    cells.Add(new GridViewCell { Value = Convert.ToString(item.ApplicationStatus) });
                    cells.Add(new GridViewCell { Value = Convert.ToString(item.AppliedDate) });
                    cells.Add(new GridViewCell { Value = Convert.ToString(item.FirstName) });
                    cells.Add(new GridViewCell { Value = Convert.ToString(item.LastName) });
                    cells.Add(new GridViewCell { Value = Convert.ToString(item.ClassName) });
                    rows.Add(new GridViewRow { Cells = cells });
                }
                response.Rows = rows;
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogHelper.Info(string.Format("ApplicationController.SearchApplications - Exception:{0}", ex.Message));
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Search()
        {
            LogHelper.Info(string.Format("ApplicationController.Search - Begin"));
            try
            {
                var applicationSearch = new ApplicationFormSearch();
                applicationSearch.ListApplicationStatus = CommonHelper.ConvertEnumToListItem<ApplicationStatus>("Application Status");
                applicationSearch.ListClasses = CommonHelper.ConvertListToSelectList<Classes>(_adminRepository.GetAllClasses(false), "Class", "ClassId", "ClassName");
                return View(applicationSearch);
            }
            catch (Exception ex)
            {
                LogHelper.Info(string.Format("ApplicationController.Search - Exception:{0}", ex.Message));
                return View();
            }
        }

        #endregion

        #region Private

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isEditable"></param>
        /// <returns></returns>
        private ApplicationForm CreateApplicationForm(int? id, bool isEditable)
        {
            LogHelper.Info(string.Format("ApplicationController.CreateApplicationForm - Begin - Id.{0}", id));
            try
            {
                var applicationForm = new ApplicationForm();
                if (id != null)
                {
                    applicationForm = _applicationRepository.GetApplicationById(id.Value);
                }
                else
                {
                    applicationForm.StudentClass = new List<StudentClass> { new StudentClass() };
                    applicationForm.StudentGuardians = new List<StudentGuardian>();
                    applicationForm.Addresses = new List<Address> { new Address() };

                    int guardianCount = CommonHelper.GetWebConfigValue<int>(WebConstants.GuardianCount);
                    for (int studentGurCounter = 0; studentGurCounter < guardianCount; studentGurCounter++)
                    {
                        applicationForm.StudentGuardians.Add(new StudentGuardian());
                    }

                    applicationForm.AcademicYear = _adminRepository.GetActiveAcademicYear();
                    if (applicationForm.AcademicYear != null)
                    {
                        applicationForm.StudentClass[0].AcademicYear = applicationForm.AcademicYear.AcademicYearId;
                    }
                }
                if (isEditable)
                {
                    applicationForm.FormClasses = _adminRepository.GetAllClasses(false);
                    applicationForm.Communities = _adminRepository.GetCommunities();
                    applicationForm.RelationShips = _adminRepository.GetRelationships();
                    applicationForm.ListTitles = CommonHelper.ConvertEnumToListItem<Titles>("Titles");
                    applicationForm.ListGender = CommonHelper.ConvertEnumToListItem<Gender>("Gender");
                    applicationForm.Languages = _adminRepository.GetMotherLanguages();
                }
                return applicationForm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string CreateApplicationDetailsTag(string innerText, string id)
        {
            var tagBuilder = new TagBuilder("a");
            tagBuilder.MergeAttribute("id", id);
            tagBuilder.MergeAttribute("href", Url.Action("Details", "Application", new { id }));
            tagBuilder.MergeAttribute("class", "");
            tagBuilder.MergeAttribute("title", "Click here to view application");
            tagBuilder.SetInnerText(innerText);
            return tagBuilder.ToString();
        }
        #endregion
    }
}