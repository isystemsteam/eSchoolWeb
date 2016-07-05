using HSchool.Business.Models;
using HSchool.Business.Repository;
using HSchool.Common;
using HSchool.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HSchool.WebApi.Controllers
{
    public class AdminController : Controller
    {
        #region Fields
        private readonly IAdminRepository _adminRepository;
        #endregion

        #region Ctor
        public AdminController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
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
                allClasses = _adminRepository.GetAllClasses((bool?)null);
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
                hClass = _adminRepository.GetClassById(id);
            }
            LogHelper.Info(string.Format("AdminController.EditClass - End"));
            return PartialView("_EditClass", hClass);
        }

        [HttpPost]
        public JsonResult EditClass(Classes mClass)
        {
            LogHelper.Info(string.Format("AdminController.EditClass [POST] - Begin"));
            var response = new Response();
            try
            {
                _adminRepository.SaveClass(mClass);
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
                allSections = _adminRepository.GetAllSections(true);
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
                hSection = _adminRepository.GetSectionById(id);
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
                _adminRepository.SaveSections(section);
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
        public ActionResult EditClassSection(int id)
        {
            LogHelper.Info(string.Format("AdminController.EditClassSection - Begin"));
            var hClassSection = new ClassSection();
            if (id != 0)
            {
                hClassSection = _adminRepository.GetClassSectionById(id);
            }
            LogHelper.Info(string.Format("AdminController.EditClassSection - End"));
            return PartialView("_EditClassSection", hClassSection);
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
                form.Modules = _adminRepository.GetAllModules();
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
        public JsonResult PrivilegesForModule(int moduleId)
        {
            LogHelper.Info(string.Format("AdminController.PrivilegesForModule - Begin"));
            try
            {
                ModuleRolePrivilege modulePrivileges = new ModuleRolePrivilege();
                modulePrivileges.Privileges = _adminRepository.GetApplicationPrivileges();
                modulePrivileges.Roles = _adminRepository.GetAllRoles(false);
                modulePrivileges.RolePrivileges = _adminRepository.GetApplicationPermissionByModuleId(moduleId);
                var response = new MessageResponse<ModuleRolePrivilege>(modulePrivileges, ApiConstants.StatusSuccess, (int)HttpStatusCode.OK, string.Empty);
                LogHelper.Info(string.Format("AdminController.PrivilegesForModule - End"));
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var response = new MessageResponse(ApiConstants.StatusFailure, (int)HttpStatusCode.ExpectationFailed, ex.Message);
                LogHelper.Error(string.Format("AdminController.EditPrivileges - Exception:{0}", ex.Message));
                return Json(response, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}
