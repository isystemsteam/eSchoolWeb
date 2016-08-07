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

namespace HSchool.Web.Controllers
{
    [CustomAuthentication]
    public class AdminController : Controller
    {

        #region Fields
        private readonly IAdminRepository _adminRepository;
        private readonly IRolePrivilegeRepository _rolePrivilegeRepository;
        public readonly IClassRepository _classRepository;
        public readonly ISectionRepository _sectionRepository;
        #endregion

        #region Ctor
        public AdminController(IAdminRepository adminRepository, IRolePrivilegeRepository rolePrivilegeRepository, IClassRepository classRepository, ISectionRepository sectionRepository)
        {
            _adminRepository = adminRepository;
            _rolePrivilegeRepository = rolePrivilegeRepository;
            _classRepository = classRepository;
            _sectionRepository = sectionRepository;
        }
        #endregion

        #region Index
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region Classes
        /// <summary>
        /// To view classes list
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewClass()
        {
            LogHelper.Info(string.Format("AdminController.ViewClass - Begin"));
            var allClasses = new List<Classes>();
            try
            {
                allClasses = _classRepository.GetAllClasses((bool?)null);
            }
            catch (Exception ex)
            {
                LogHelper.Info(string.Format("AdminController.ViewClass - Exception:{0}", ex.Message));
                throw;
            }
            LogHelper.Info(string.Format("AdminController.ViewClass - End"));
            return PartialView("_ViewClass", allClasses);
        }

        /// <summary>
        /// To edit 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditClass(int id)
        {
            LogHelper.Info(string.Format("AdminController.EditClass - Begin"));
            var hClass = new Classes();
            if (id != 0)
            {
                hClass = _classRepository.GetClassById(id);
            }
            LogHelper.Info(string.Format("AdminController.EditClass - End"));
            return PartialView("_EditClass", hClass);
        }

        [HttpPost]
        public JsonResult EditClass(Classes mClass, FormCollection collection)
        {
            LogHelper.Info(string.Format("AdminController.EditClass [POST] - Begin"));
            var response = new Response();
            try
            {
                mClass.IsVisibleToApplication = collection.GetFormValue<bool>("IsVisibleToApplication");
                _classRepository.SaveClass(mClass);
                response.IsSuccess = true;
                LogHelper.Info(string.Format("AdminController.EditClass [POST] - End"));
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminController.EditClass [POST] - Exception:{0}", ex.Message), ex);
                response = new Response { IsSuccess = false, Message = ex.Message, StatusCode = 503 };
            }
            return Json(response, JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region Section
        /// <summary>
        /// To view sections
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewSection()
        {
            LogHelper.Info(string.Format("AdminController.ViewClass - Begin"));
            var allSections = new List<Section>();
            try
            {
                allSections = _sectionRepository.GetAllSections(true);
            }
            catch (Exception ex)
            {
                LogHelper.Info(string.Format("AdminController.ViewClass - Exception:{0}", ex.Message));
                throw;
            }
            LogHelper.Info(string.Format("AdminController.ViewClass - End"));
            return PartialView("_ViewSection", allSections);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditSection(int id)
        {
            LogHelper.Info(string.Format("AdminController.EditSection - Begin"));
            var hSection = new Section();
            if (id != 0)
            {
                hSection = _sectionRepository.GetSectionById(id);
            }
            LogHelper.Info(string.Format("AdminController.EditSection - End"));
            return PartialView("_EditSection", hSection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult EditSection(Section section)
        {
            LogHelper.Info(string.Format("AdminController.EditSection [POST] - Begin"));
            var response = new Response();
            try
            {
                _sectionRepository.SaveSections(section);
                response.IsSuccess = true;
                LogHelper.Info(string.Format("AdminController.EditSection [POST] - End"));
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminController.EditSection [POST] - Exception:{0}", ex.Message), ex);
                response = new Response { IsSuccess = false, Message = ex.Message, StatusCode = 503 };
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region ClassSections
        public ActionResult EditClassSection()
        {
            LogHelper.Info(string.Format("AdminController.EditClassSection - Begin"));
            try
            {
                var hClassSectionForm = new ClassSectionForm();
                hClassSectionForm.ListClasses = CommonHelper.ConvertListToSelectList<Classes>(_classRepository.GetAllClasses(false), "Classes", "ClassId", "ClassName");
                //hClassSectionForm.ClassCollection = _classRepository.GetAllClasses(false);
                LogHelper.Info(string.Format("AdminController.EditClassSection - End"));
                return PartialView("_EditClassSection", hClassSectionForm);
            }
            catch (Exception ex)
            {
                return PartialView("_Error", ex.Message);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public JsonResult ViewClassSections(int classId)
        {
            LogHelper.Info(string.Format("AdminController.ViewClassSections - Begin"));
            try
            {
                var classSections = _adminRepository.GetClassSectionsByClassId(classId);
                var sections = _sectionRepository.GetAllSections(true);
                foreach (Section section in sections)
                {
                    var item = classSections.Where(sec => sec.SectionId == section.SectionId);
                    if (item != null && item.Any())
                    {
                        section.IsSelected = item.FirstOrDefault().IsActive;
                    }
                }
                var classSectionForm = new ClassSectionForm();
                classSectionForm.SectionCollection = sections;
                var response = new MessageResponse<ClassSectionForm>(classSectionForm, ApiConstants.StatusSuccess, (int)HttpStatusCode.OK, string.Empty);
                LogHelper.Info(string.Format("AdminController.ViewClassSections - End"));
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var response = new MessageResponse<ClassSectionForm>(null, ApiConstants.StatusFailure, (int)HttpStatusCode.ExpectationFailed, ex.Message);
                return Json(response, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="classSections"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveClassSections(List<ClassSection> classSections)
        {
            LogHelper.Info(string.Format("AdminController.ViewClassSections - Begin"));
            try
            {
                _adminRepository.SaveClassSection(classSections);
                var response = new MessageResponse<string>(null, ApiConstants.StatusSuccess, (int)HttpStatusCode.OK, string.Empty);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var response = new MessageResponse<string>(null, ApiConstants.StatusFailure, (int)HttpStatusCode.ExpectationFailed, ex.Message);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Subjects
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewSubject()
        {
            LogHelper.Info(string.Format("AdminController.ViewSubject - Begin"));
            var subjects = new List<Subject>();
            try
            {
                subjects = _classRepository.GetAllSubjects();
            }
            catch (Exception ex)
            {
                LogHelper.Info(string.Format("AdminController.ViewSubject - Exception:{0}", ex.Message));
                throw;
            }
            LogHelper.Info(string.Format("AdminController.ViewSubject - End"));
            return PartialView("_ViewSubject", subjects);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditSubject(int? id)
        {
            LogHelper.Info(string.Format("AdminController.EditSubject - Begin"));
            var subject = new Subject();
            if (id != 0)
            {
                subject = _classRepository.GetSubjectById(id);
            }
            LogHelper.Info(string.Format("AdminController.EditSubject - End"));
            return PartialView("_EditSubject", subject);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSubject(Subject model)
        {
            LogHelper.Info(string.Format("AdminController.EditSubject [POST] - Begin"));
            var response = new Response();
            try
            {
                _classRepository.SaveSubject(model);
                response.IsSuccess = true;
                LogHelper.Info(string.Format("AdminController.EditSubject [POST] - End"));
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminController.EditSubject [POST] - Exception:{0}", ex.Message), ex);
                response = new Response { IsSuccess = false, Message = ex.Message, StatusCode = 503 };
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Class&Subjects
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewClassSubject()
        {
            LogHelper.Info(string.Format("AdminController.ViewClassSubject - Begin"));
            try
            {
                var classSubjectViewModel = new ClassSubjectViewModel();
                System.Threading.Tasks.Parallel.Invoke(
                    () => { classSubjectViewModel.Classes = _classRepository.GetAllClasses(false); },
                    () => { classSubjectViewModel.Sections = _sectionRepository.GetAllSections(true); });

                LogHelper.Info(string.Format("AdminController.ViewClassSubject - End"));
                return PartialView("_ViewClassSubject", classSubjectViewModel);
            }
            catch (Exception ex)
            {
                LogHelper.Info(string.Format("AdminController.ViewClassSubject - Exception:{0}", ex.Message));
                return PartialView("_Error", ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="sectionId"></param>
        /// <returns></returns>
        public JsonResult ViewSubjectsForClass(int classId, int sectionId)
        {
            LogHelper.Info(string.Format("AdminController.ViewSubjectsForClass - Begin"));
            MessageResponse response;
            var subjects = new List<Subject>();
            try
            {
                subjects = _classRepository.GetAllSubjects();
                response = new MessageResponse<List<Subject>>(subjects, ApiConstants.StatusSuccess, (int)HttpStatusCode.OK, string.Empty);
                LogHelper.Info(string.Format("AdminController.ViewSubjectsForClass - End"));
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogHelper.Info(string.Format("AdminController.ViewSubjectsForClass - Exception:{0}", ex.Message));
                response = new MessageResponse<string>(ex.Message, ApiConstants.StatusFailure, (int)HttpStatusCode.ExpectationFailed, string.Empty);
                return Json(response, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sectionId"></param>
        /// <returns></returns>
        public ActionResult EditClassSubject(int id, int sectionId)
        {
            LogHelper.Info(string.Format("AdminController.EditClassSubject - Begin"));
            try
            {
                var classSubjectViewModel = new ClassSubjectViewModel();
                //Parallel Process
                System.Threading.Tasks.Parallel.Invoke(
                    () => { classSubjectViewModel.ListClasses = CommonHelper.ConvertListToSelectList<Classes>(_classRepository.GetAllClasses(false), "Class", "ClassId", "ClassName"); },
                    () => { classSubjectViewModel.ListSections = CommonHelper.ConvertListToSelectList<Section>(_sectionRepository.GetAllSections(true), "Section", "SectionId", "SectionName"); },
                    () => { classSubjectViewModel.Subjects = _classRepository.GetAllSubjects(); });
                LogHelper.Info(string.Format("AdminController.EditClassSubject - End"));
                return PartialView("_EditClassSubject", classSubjectViewModel);
            }
            catch (Exception ex)
            {
                LogHelper.Info(string.Format("AdminController.EditClassSubject - Exception:{0}", ex.Message));
                return PartialView("_Error", ex.Message);
            }
        }
        #endregion

        #region Roles & Privileges
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditRole(int id)
        {
            LogHelper.Info(string.Format("AdminController.EditRole - Begin"));
            try
            {
                var applicationRole = new ApplicationRole();
                if (id != 0)
                {
                    applicationRole = _adminRepository.GetRoleById(id);
                }
                LogHelper.Info(string.Format("AdminController.EditRole - End"));
                return PartialView("_EditRole", applicationRole);
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminController.EditRole - Exception:{0}", ex.Message));
                return PartialView("_Error");
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult EditRole(ApplicationRole role)
        {
            LogHelper.Info(string.Format("AdminController.EditRole [POST] - Begin"));
            var response = new Response();
            try
            {
                _adminRepository.SaveApplicationRole(role);
                response.IsSuccess = true;
                LogHelper.Info(string.Format("AdminController.EditRole [POST] - End"));
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminController.EditRole [POST] - Exception:{0}", ex.Message), ex);
                response = new Response { IsSuccess = false, Message = ex.Message, StatusCode = 503 };
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewRole()
        {
            LogHelper.Info(string.Format("AdminController.ViewRole - Begin"));
            var applicationRoles = new List<ApplicationRole>();
            try
            {
                applicationRoles = _adminRepository.GetAllRoles(false);
            }
            catch (Exception ex)
            {
                LogHelper.Info(string.Format("AdminController.ViewRole - Exception:{0}", ex.Message));
                throw;
            }
            LogHelper.Info(string.Format("AdminController.ViewRole - End"));
            return PartialView("_ViewRoles", applicationRoles);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult EditPrivileges()
        {
            LogHelper.Info(string.Format("AdminController.EditPrivileges - Begin"));
            try
            {
                var form = new RolePrivilegeForm();
                form.ListRoles = CommonHelper.ConvertListToSelectList<ApplicationRole>(_adminRepository.GetAllRoles(false), "Roles", "RoleId", "RoleName");
                LogHelper.Info(string.Format("AdminController.EditPrivileges - End"));
                return PartialView("_RolesPrivileges", form);
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminController.EditPrivileges - Exception:{0}", ex.Message));
                return PartialView("_Error");
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public JsonResult RolePrivilegesForModule(int roleId)
        {
            LogHelper.Info(string.Format("AdminController.RolePrivilegesForModule - Begin"));
            try
            {
                ModuleRolePrivilege modulePrivileges = new ModuleRolePrivilege();
                var privileges = _adminRepository.GetApplicationPrivileges();
                var rolePrivileges = _rolePrivilegeRepository.GetModulePrivilegesByRoleId(roleId);
                modulePrivileges.Roles = _adminRepository.GetAllRoles(false);
                modulePrivileges.Privileges = privileges;
                modulePrivileges.Modules = _adminRepository.GetAllModules();
                foreach (ApplicationModule moduleItem in modulePrivileges.Modules)
                {
                    moduleItem.Privileges = new List<ApplicationPrivilege>();
                    foreach (var pItem in privileges)
                    {
                        moduleItem.Privileges.Add(new ApplicationPrivilege { PrivilegeId = pItem.PrivilegeId, PrivilegeName = pItem.PrivilegeName });
                    }

                    if (privileges != null && rolePrivileges != null)
                    {
                        var rolePrivilege = rolePrivileges.Where(rp => rp.ModuleId == moduleItem.ModuleId).FirstOrDefault();
                        if (rolePrivilege != null)
                        {
                            foreach (var privilegeId in rolePrivilege.PrivilegeCollection)
                            {
                                var item = moduleItem.Privileges.Where(p => p.PrivilegeId == privilegeId).FirstOrDefault();
                                if (item != null)
                                {
                                    item.IsChecked = true;
                                }
                            }
                        }
                    }
                }

                var response = new MessageResponse<ModuleRolePrivilege>(modulePrivileges, ApiConstants.StatusSuccess, (int)HttpStatusCode.OK, string.Empty);
                LogHelper.Info(string.Format("AdminController.RolePrivilegesForModule - End"));
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var response = new MessageResponse(ApiConstants.StatusFailure, (int)HttpStatusCode.ExpectationFailed, ex.Message);
                LogHelper.Error(string.Format("AdminController.RolePrivilegesForModule - Exception:{0}", ex.Message));
                return Json(response, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveRolesPrivileges(List<RolePrivilege> rolesPrivileges)
        {
            LogHelper.Info(string.Format("AdminController.SaveRolesPrivileges - Begin"));
            try
            {
                _adminRepository.SaveRolePrivileges(rolesPrivileges);
                var response = new MessageResponse<string>(null, ApiConstants.StatusSuccess, (int)HttpStatusCode.OK, string.Empty);
                LogHelper.Info(string.Format("AdminController.SaveRolesPrivileges - End"));
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminController.SaveRolesPrivileges - Exception:{0}", ex.Message));
                var response = new MessageResponse<string>(null, ApiConstants.StatusFailure, (int)HttpStatusCode.ExpectationFailed, ex.Message);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Years

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditAcademicYear(int id)
        {
            LogHelper.Info(string.Format("AdminController.EditAcademicYear[HttpGet] - Begin. Id:{0}", id));
            var academicYear = new AcademicYear();
            try
            {
                if (id != 0)
                {
                    academicYear = _adminRepository.GetAcademicYearById(id);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminController.EditAcademicYear[HttpGet] - Exception:{0}", ex.Message), ex);
                return PartialView("_Error", ex.Message);
            }
            LogHelper.Info(string.Format("AdminController.EditAcademicYear[HttpGet] - End. Id:{0}", id));
            return PartialView("_EditAcademicYear", academicYear);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult EditAcademicYear(AcademicYear year)
        {
            LogHelper.Info(string.Format("AdminController.EditAcademicYear[HttpPost] - Begin"));
            var response = new Response();
            try
            {
                _adminRepository.SaveAcademicYear(year);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminController.EditAcademicYear[HttpPost] - Exception:{0}", ex.Message), ex);
                response = new Response { IsSuccess = false, Message = ex.Message, StatusCode = 503 };
            }
            LogHelper.Info(string.Format("AdminController.EditAcademicYear[HttpPost] - End"));
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewAcademicYear()
        {
            LogHelper.Info(string.Format("AdminController.ViewAcademicYear - Begin"));
            var allYears = new List<AcademicYear>();
            try
            {
                allYears = _adminRepository.GetAcademicYears();
            }
            catch (Exception ex)
            {
                LogHelper.Info(string.Format("AdminController.ViewAcademicYear - Exception:{0}", ex.Message));
                return PartialView("_Error", ex.Message);
            }
            LogHelper.Info(string.Format("AdminController.ViewAcademicYear - End"));
            return PartialView("_ViewAcademicYear", allYears);
        }
        #endregion

        #region Manage
        public ActionResult Management()
        {
            return View();
        }
        #endregion
    }
}
