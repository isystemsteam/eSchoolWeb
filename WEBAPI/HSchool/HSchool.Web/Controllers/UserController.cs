using HSchool.Business.Models;
using HSchool.Business.Repository;
using HSchool.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using HSchool.Common;
using System.Threading.Tasks;
using HSchool.Web.Models;
using HttpStatusCode = System.Net.HttpStatusCode;

namespace HSchool.Web.Controllers
{
    [CustomAuthentication]
    public class UserController : Controller
    {
        #region Fields
        private readonly IAdminRepository _adminRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IApplicationRepository _applicationRepository;
        private ApplicationUserManager _userManager;
        private readonly IUserRepository _userRepository;
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
        /// <param name="userManager"></param>
        /// <param name="adminRepository"></param>
        /// <param name="studentRepository"></param>
        /// <param name="applicationRepository"></param>
        public UserController(IAdminRepository adminRepository, IStudentRepository studentRepository, IApplicationRepository applicationRepository, IUserRepository userRepository)
        {
            _adminRepository = adminRepository;
            _studentRepository = studentRepository;
            _applicationRepository = applicationRepository;
            _userRepository = userRepository;
        }
        #endregion

        #region Actions
        // GET: User
        public ActionResult Index()
        {
            LogHelper.Info(string.Format("UserController.Index - Begin."));
            var model = new UserSearch();
            try
            {
                System.Threading.Tasks.Parallel.Invoke(
            () => { model.ListRoles = CommonHelper.ConvertListToSelectList<ApplicationRole>(_adminRepository.GetAllRoles(false), "Roles", "RoleId", "RoleName"); },
            () => { model.ListGender = CommonHelper.ConvertEnumToListItem<Gender>("Gender"); }
                );

            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("UserController.Index - Exception.{0}", ex.Message));
            }
            LogHelper.Info(string.Format("UserController.Index - End."));
            return View(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            LogHelper.Info(string.Format("UserController.Edit - Begin. Id:{0}", id));
            var model = new UserCreateModel();
            try
            {
                System.Threading.Tasks.Parallel.Invoke(
                () => { model.ListCommunities = CommonHelper.ConvertListToSelectList<CommunityMaster>(_adminRepository.GetCommunities(), "Community", "CommunityId", "CommunityName"); },
            () => { model.ListLanguages = CommonHelper.ConvertListToSelectList<MotherLanguages>(_adminRepository.GetMotherLanguages(), "Mother Language", "LanguageId", "Name"); },
            () => { model.ListRoles = CommonHelper.ConvertListToSelectList<ApplicationRole>(_adminRepository.GetAllRoles(false), "Roles", "RoleId", "RoleName"); },
            () => { model.ListGender = CommonHelper.ConvertEnumToListItem<Gender>("Gender"); },
            () => { model.ListTitles = CommonHelper.ConvertEnumToListItem<Titles>("Titles"); },
            () => { model.ListProofTypes = CommonHelper.ConvertEnumToListItem<ProofTypes>("Proof Type"); }
                );
                model.Addresses = new List<Address> { new Address() };
                model.IsEditable = true;
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("UserController.Edit - Exception.{0}", ex.Message));
            }
            LogHelper.Info(string.Format("UserController.Edit - End. Id:{0}", id));
            return View(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserCreateModel model)
        {
            LogHelper.Info(string.Format("UserController.Edit[HTTPPOST] - Begin."));
            MessageResponse response;
            string message = string.Empty;
            try
            {
                var id = _userRepository.SaveUser(model);

                if (model.UserId == 0 && model.LoginEnabled)
                {
                    model.UserName = CommonHelper.CreateDefaultUserName(model.UserRoleText, id, model.FirstName, model.LastName);
                    model.Password = CommonHelper.CreateDefaultPassword(model.UserName, model.DateOfBirth);
                    var result = CreateUser(model);
                    if (result.IsCompleted)
                    {
                        if (result.Result.Succeeded)
                        {
                            message = string.Format("User created succesfully, UserName:{1}", model.UserName);
                            response = new MessageResponse<string>(message, ApiConstants.StatusSuccess, (int)HttpStatusCode.OK, string.Empty);
                        }
                    }
                }
                message = string.Format("User created succesfully, UserName:{1}", model.UserName);
                response = new MessageResponse<string>(message, ApiConstants.StatusSuccess, (int)HttpStatusCode.OK, string.Empty);
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("UserController.Edit[HTTPPOST] - Exception.{0}", ex.Message));
                response = new MessageResponse<string>(ex.Message, ApiConstants.StatusSuccess, (int)HttpStatusCode.OK, string.Empty);
            }
            LogHelper.Info(string.Format("UserController.Edit[HTTPPOST] - End."));
            return View(model);
        }

        public async Task<IdentityResult> CreateUser(UserAccount model)
        {
            LogHelper.Info(string.Format("ApplicationController.CreateUser-Begin"));
            var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
            var result = await UserManager.CreateAsync(user, model.Password);
            LogHelper.Info(string.Format("ApplicationController.CreateUser-Begin"));
            return result;
        }
        #endregion
    }
}