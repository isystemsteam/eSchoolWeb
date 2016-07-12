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
    public class StudentController : Controller
    {
        #region Fields
        private readonly IAdminRepository _adminRepository;
        private readonly IStudentRepository _studentRepository;
        #endregion

        #region Actions
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Application()
        {
            LogHelper.Info(string.Format("ApplicationController.Index - Begin"));
            var admissionForm = new AdmissionForm();
            admissionForm.Student = new Student();
            admissionForm.Student.StudentGuardians = new List<StudentGuardian>();
            int guardianCount = CommonHelper.GetWebConfigValue<int>(WebConstants.GuardianCount);
            for (int studentGurCounter = 0; studentGurCounter < guardianCount; studentGurCounter++)
            {
                admissionForm.Student.StudentGuardians.Add(new StudentGuardian());
            }
            admissionForm.FormClasses = _adminRepository.GetAllClasses(true);
            LogHelper.Info(string.Format("ApplicationController.Index - End"));
            return View(admissionForm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Application(AdmissionForm model)
        {
            LogHelper.Info(string.Format("ApplicationController.Application - Begin"));
            try
            {
                var id = _studentRepository.SaveStudentInformation(model.Student);
                var response = new MessageResponse<string>(id.HasValue ? id.ToString() : string.Empty, WebConstants.StatusSuccess, (int)HttpStatusCode.OK, string.Empty);
                LogHelper.Info(string.Format("ApplicationController.Application - End"));
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogHelper.Info(string.Format("ApplicationController.Application - Exception:{0}", ex.Message));
                var response = new MessageResponse<string>(string.Empty, WebConstants.StatusSuccess, (int)HttpStatusCode.OK, ex.Message);
                return Json(response, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}