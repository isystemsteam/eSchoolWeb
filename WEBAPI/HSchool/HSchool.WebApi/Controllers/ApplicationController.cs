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
        #endregion

        #region Ctor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="adminRepository"></param>
        public ApplicationController(IAdminRepository adminRepository, IStudentRepository studentRepository)
        {
            _adminRepository = adminRepository;
            _studentRepository = studentRepository;
        }
        #endregion

        #region Actions
        public ActionResult Index()
        {
            LogHelper.Info(string.Format("ApplicationController.Index - Begin"));
            var admissionForm = new ApplicationForm();
            admissionForm.FormClasses = _adminRepository.GetAllClasses(true);
            LogHelper.Info(string.Format("ApplicationController.Index - End"));
            return View(admissionForm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult StudentRegister(ApplicationForm model)
        {
            LogHelper.Info(string.Format("ApplicationController.StudentRegister - Begin"));
            try
            {
                var id = _studentRepository.SaveStudentInformation(model.Student);
                var response = new MessageResponse<string>(id.HasValue ? id.ToString() : string.Empty, WebConstants.StatusSuccess, (int)HttpStatusCode.OK, string.Empty);
                LogHelper.Info(string.Format("ApplicationController.StudentRegister - End"));
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogHelper.Info(string.Format("ApplicationController.StudentRegister - Exception:{0}", ex.Message));
                var response = new MessageResponse<string>(string.Empty, WebConstants.StatusSuccess, (int)HttpStatusCode.OK, ex.Message);
                return Json(response, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion
    }
}