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
            var applicationForm = new ApplicationForm();
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
            applicationForm.FormClasses = _adminRepository.GetAllClasses(false);
            applicationForm.Communities = _adminRepository.GetCommunities();
            applicationForm.RelationShips = _adminRepository.GetRelationships();
            applicationForm.ListTitles = CommonHelper.ConvertEnumToListItem<Titles>("Titles");
            applicationForm.ListGender = CommonHelper.ConvertEnumToListItem<Gender>("Gender");
            applicationForm.Languages = _adminRepository.GetMotherLanguages();
            applicationForm.IsOfficeFormEnabled = false;
            applicationForm.ActionName = string.Format("{0}", "Application");
            LogHelper.Info(string.Format("ApplicationController.Index - End"));
            return View(applicationForm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(ApplicationForm model)
        {
            LogHelper.Info(string.Format("ApplicationController.StudentRegister - Begin"));
            try
            {
                if (ModelState.IsValid)
                {
                    model.IsStudentUpdate = true;
                    model.UserStatus = (int)UserStatusEnum.Registered;
                    model.RollNumber = "123456";
                }
                var id = _applicationRepository.SaveApplication(model);
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