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
    public class LoginController : Controller
    {
        #region Fields
        private readonly IAdminRepository _adminRepository;
        #endregion
        public LoginController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        /// <summary>
        /// Login View
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

            LogHelper.Info(string.Format("LoginController.Index - Begin"));
            try
            {
                var loginModel = new LoginViewModel();
                loginModel.Roles = _adminRepository.GetAllRoles(true);
                LogHelper.Info(string.Format("LoginController.Index - End"));
                return View(loginModel);
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("LoginController.Index - Exception:{0}", ex.Message));
                return View();
            }
        }

        /// <summary>
        /// To login
        /// </summary>
        /// <param name="credential"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Login(LoginViewModel model, string returnUrl)
        {
            LogHelper.Info(string.Format("LoginController.Login - Begin"));
            LogHelper.Info(string.Format("LoginController.Login - End"));
            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}