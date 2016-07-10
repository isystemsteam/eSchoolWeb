using HSchool.Business.Models;
using HSchool.Business.Repository;
using HSchool.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HSchool.WebApi.Controllers
{
    public class ApplicationController : Controller
    {
        #region Fields
        private readonly IAdminRepository _adminRepository;
        #endregion

        #region Ctor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="adminRepository"></param>
        public ApplicationController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        #endregion

        #region Actions
        public ActionResult Index()
        {
            LogHelper.Info(string.Format("ApplicationController.Index - Begin"));
            var admissionForm = new AdmissionForm();
            admissionForm.FormClasses = _adminRepository.GetAllClasses(true);
            LogHelper.Info(string.Format("ApplicationController.Index - End"));
            return View(admissionForm);
        }
               
        #endregion
    }
}