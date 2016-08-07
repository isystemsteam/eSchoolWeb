using HSchool.Business.Models;
using HSchool.Business.Repository;
using HSchool.Common;
using HSchool.Logging;
using HSchool.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

using HttpStatusCode = System.Net.HttpStatusCode;

namespace HSchool.Web.Controllers
{

    // GET: Application
    public class ApplicationController : Controller
    {
        #region Fields
        private readonly IAdminRepository _adminRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IApplicationRepository _applicationRepository;
        private readonly IClassRepository _classRepository;
        private ApplicationUserManager _userManager;
        #endregion

        #region Properties
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        #endregion

        #region Ctor
        /// <summary>
        /// 
        /// </summary>
        //public ApplicationController()
        //{

        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="adminRepository"></param>
        /// <param name="studentRepository"></param>
        /// <param name="applicationRepository"></param>
        public ApplicationController(ApplicationUserManager userManager, IAdminRepository adminRepository, IStudentRepository studentRepository, IApplicationRepository applicationRepository, IClassRepository classRepository)
        {
            _adminRepository = adminRepository;
            _studentRepository = studentRepository;
            _applicationRepository = applicationRepository;
            _classRepository = classRepository;
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
            try
            {
                var applicationForm = CreateApplicationForm(null, true);
                applicationForm.IsOfficeFormEnabled = false;
                applicationForm.IsStudentAddressUpdate = true;
                applicationForm.IsStudentGuardianUpdate = true;
                applicationForm.IsEditable = true;
                LogHelper.Info(string.Format("ApplicationController.Index - End"));
                return View(applicationForm);
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("ApplicationController.Index - Exception:{0}", ex.Message));
                return View("Error", ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [CustomAuthentication]
        public ActionResult Details(int id)
        {
            LogHelper.Info(string.Format("ApplicationController.Details - Begin"));
            try
            {
                var applicationForm = _applicationRepository.GetApplicationById(id);
                applicationForm.IsEditable = false;
                LogHelper.Info(string.Format("ApplicationController.Details - End"));
                return View(applicationForm);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        /// <summary>
        /// To edit student information
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>        
        [HttpGet]
        public ActionResult Edit(int id)
        {
            LogHelper.Info(string.Format("ApplicationController.Edit - Begin"));
            try
            {
                var applicationForm = _applicationRepository.GetApplicationById(id);
                applicationForm.IsEditable = true;
                applicationForm.IsOfficeFormEnabled = false;
                LogHelper.Info(string.Format("ApplicationController.Edit - End"));
                return View(applicationForm);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        /// <summary>
        /// To edit office form only
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult OfficeForm(int id)
        {
            LogHelper.Info(string.Format("ApplicationController.EditOfficeForm - Begin"));
            try
            {
                var applicationForm = _applicationRepository.GetApplicationById(id);
                applicationForm.IsEditable = false;
                applicationForm.IsOfficeFormEnabled = true;
                LogHelper.Info(string.Format("ApplicationController.EditOfficeForm - End"));
                return View("Edit", applicationForm);
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
                model.VisibleMark = false;
                model.ApplicationStatus = (int)ApplicationStatus.Submitted;
                model.IsTransportRequired = collection.GetFormValue<bool>("IsTransportRequired");
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditOfficeForm(ApplicationForm model, FormCollection collection)
        {
            LogHelper.Info(string.Format("ApplicationController.EditOfficeForm - Begin"));
            MessageResponse response = null;
            string responseMessage = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    bool userLoginEnabled = collection.GetFormValue<bool>("LoginEnabled");
                    //bool guardianLoginEnabled = collection.GetFormValue<bool>("GuardianLoginEnabled");                    
                    model.IsStudentUpdate = false;
                    //user details
                    if (userLoginEnabled)
                    {
                        model.Email = model.StudentGuardians.FirstOrDefault().Email;
                        model.Password = CommonHelper.CreateDefaultPassword(model.UserName, model.StudentGuardians.FirstOrDefault().DateOfBirth);
                        var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
                        var result = await UserManager.CreateAsync(user, model.Password);
                        if (result.Succeeded)
                        {
                            responseMessage = string.Format("{0}", "Login Enabled successfully.");
                        }
                    }
                    var applicationId = _applicationRepository.SaveApplication(model);
                    response = new MessageResponse<string>(responseMessage, WebConstants.StatusSuccess, (int)HttpStatusCode.OK, string.Empty);
                }
                LogHelper.Info(string.Format("ApplicationController.EditOfficeForm - End"));
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
        /// <returns></returns>
        [HttpGet]
        [CustomAuthentication]
        public ActionResult Search()
        {
            LogHelper.Info(string.Format("ApplicationController.Search - Begin"));
            try
            {
                var applicationSearch = new ApplicationFormSearch();
                applicationSearch.ListApplicationStatus = CommonHelper.ConvertEnumToListItem<ApplicationStatus>("Application Status");
                applicationSearch.ListClasses = CommonHelper.ConvertListToSelectList<Classes>(_classRepository.GetAllClasses(false), "Class", "ClassId", "ClassName");
                return View(applicationSearch);
            }
            catch (Exception ex)
            {
                LogHelper.Info(string.Format("ApplicationController.Search - Exception:{0}", ex.Message));
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
                        new GridColumn { ColumnName = "Class" },
                        new GridColumn { ColumnName = "Edit" },
                        new GridColumn { ColumnName = "Office Use" }
                    },
                    Rows = new List<GridViewRow> { }
                };

                var rows = new List<GridViewRow>();
                foreach (var item in result)
                {
                    var cells = new List<GridViewCell>();
                    string id = Convert.ToString(item.ApplicationId);
                    cells.Add(new GridViewCell { Value = CreateApplicationDetailsTag(id, id, "Details", "View Application Details") });
                    cells.Add(new GridViewCell { Value = Convert.ToString(item.ApplicationStatus) });
                    cells.Add(new GridViewCell { Value = Convert.ToString(item.AppliedDate) });
                    cells.Add(new GridViewCell { Value = Convert.ToString(item.FirstName) });
                    cells.Add(new GridViewCell { Value = Convert.ToString(item.LastName) });
                    cells.Add(new GridViewCell { Value = Convert.ToString(item.ClassName) });
                    cells.Add(new GridViewCell { Value = CreateApplicationDetailsTag("<i class='fa fa-pencil-square-o'></i>", id, "Edit", "Edit Application") });
                    cells.Add(new GridViewCell { Value = CreateApplicationDetailsTag("<i class='fa fa-pencil-square-o'></i>", id, "OfficeForm", "Edit Office Use") });
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
        /// <param name="account"></param>
        /// <returns></returns>

        public async Task<IdentityResult> CreateUser(UserAccount model)
        {
            LogHelper.Info(string.Format("ApplicationController.CreateUser-Begin"));
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await UserManager.CreateAsync(user, model.Password);
            LogHelper.Info(string.Format("ApplicationController.CreateUser-Begin"));
            return result;
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
                    System.Threading.Tasks.Parallel.Invoke(
                        () => { applicationForm.FormClasses = _classRepository.GetAllClasses(false); },
                        () => { applicationForm.Communities = _adminRepository.GetCommunities(); },
                        () => { applicationForm.RelationShips = _adminRepository.GetRelationships(); },
                        () => { applicationForm.ListTitles = CommonHelper.ConvertEnumToListItem<Titles>("Titles"); },
                        () => { applicationForm.ListGender = CommonHelper.ConvertEnumToListItem<Gender>("Gender"); },
                        () => { applicationForm.Languages = _adminRepository.GetMotherLanguages(); }
                    );
                }
                return applicationForm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="innerText"></param>
        /// <param name="id"></param>
        /// <param name="actionName"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        private string CreateApplicationDetailsTag(string innerText, string id, string actionName, string title)
        {
            var tagBuilder = new TagBuilder("a");
            tagBuilder.MergeAttribute("id", id);
            tagBuilder.MergeAttribute("href", Url.Action(actionName, "Application", new { id }));
            tagBuilder.MergeAttribute("class", "");
            tagBuilder.MergeAttribute("title", title);
            tagBuilder.InnerHtml = innerText;
            return tagBuilder.ToString();
        }
        #endregion
    }
}
