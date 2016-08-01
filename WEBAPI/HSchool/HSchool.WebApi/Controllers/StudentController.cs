using HSchool.Authentication;
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

        #region Ctor
        public StudentController(IAdminRepository adminRepository, IStudentRepository studentRepository)
        {
            _adminRepository = adminRepository;
            _studentRepository = studentRepository;
        }
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
            var admissionForm = new ApplicationForm();
            
            LogHelper.Info(string.Format("ApplicationController.Index - End"));
            return View(admissionForm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Application(ApplicationForm model)
        {
            LogHelper.Info(string.Format("ApplicationController.Application - Begin"));
            try
            {
                int? id = null;
                if (ModelState.IsValid)
                {
                    //model.ApplicationType = 1;
                    id = 1;
                }
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ApplicationAdmit(ApplicationForm model)
        {
            LogHelper.Info(string.Format("ApplicationController.Application - Begin"));
            try
            {
                int? id = null;
                if (ModelState.IsValid)
                {
                    if (AuthenticationHelper.CreateUser(model.Email, model.UserName, string.Empty, string.Empty, string.Empty))
                    {
                        //model.ApplicationType = 1;
                        id = 1; //_studentRepository.SaveApplication(model);
                    }
                }
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