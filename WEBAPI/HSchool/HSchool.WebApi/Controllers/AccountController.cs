using HSchool.Authentication;
using HSchool.Business.Models;
using HSchool.Common;
using HSchool.Logging;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HSchool.WebApi.Controllers
{
    public class AccountController : Controller
    {

        #region Private
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;
        #endregion

        #region Properties
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().Get<ApplicationUserManager>("dev");
            }
            private set
            {
                _userManager = value;
            }
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>("dev");
            }
            private set { _signInManager = value; }
        }
        #endregion

        #region Ctor
        /// <summary>
        /// 
        /// </summary>
        public AccountController()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="signInManager"></param>
        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        #endregion

        #region Actions       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public ActionResult Login(string returnUrl)
        {
            var loginModel = new LoginViewModelTest();
            ViewBag.ReturnUrl = returnUrl;
            return View(loginModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModelTest model, string returnUrl)
        {
            LogHelper.Info(string.Format("AccountController.Login - Begin. UserName:{0}", model.UserName));
            MessageResponse response = null;
            try
            {
                LoginResponse loginResponse = null;
                if (!ModelState.IsValid)
                {
                    response = new MessageResponse<string>(string.Empty, WebConstants.StatusFailure, (int)HttpStatusCode.BadRequest, WebConstants.LoginInvalidMessage);
                    LogHelper.Info(string.Format("AccountController.Login - End. Invalid Model submit:{0}", model.UserName));
                }
                else
                {
                    var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, shouldLockout: false);
                    switch (result)
                    {
                        case SignInStatus.Success:
                            loginResponse = new LoginResponse { ReturnUrl = ValidateReturnUrl(returnUrl) };
                            break;
                        case SignInStatus.LockedOut:
                            loginResponse = new LoginResponse { ReturnUrl = string.Empty, Message = WebConstants.AccountLocked };
                            break;
                        case SignInStatus.RequiresVerification:
                            loginResponse = new LoginResponse { ReturnUrl = string.Empty, Message = WebConstants.LoginFailed };
                            break;
                        case SignInStatus.Failure:
                            loginResponse = new LoginResponse { ReturnUrl = string.Empty, Message = WebConstants.LoginFailed };
                            break;
                        default:
                            loginResponse = new LoginResponse { ReturnUrl = string.Empty, Message = WebConstants.LoginFailed };
                            break;
                    }
                    response = new MessageResponse<LoginResponse>(loginResponse, WebConstants.StatusSuccess, (int)HttpStatusCode.OK, string.Empty);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format(""));
                response = new MessageResponse<string>(ex.Message, WebConstants.StatusFailure, (int)HttpStatusCode.ExpectationFailed, WebConstants.LoginInvalidMessage);
            }
            LogHelper.Info(string.Format("AccountController.Login - End. UserName:{0}", model.UserName));
            return Json(response, JsonRequestBehavior.AllowGet);
           

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        private string ValidateReturnUrl(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return returnUrl;
            }
            return Url.Action("Index", "Home");
        }
        #endregion
    }
}