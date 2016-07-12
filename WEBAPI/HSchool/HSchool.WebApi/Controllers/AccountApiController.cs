using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using HSchool.WebApi.Models;
using HSchool.WebApi.Providers;
using HSchool.WebApi.Results;
using HSchool.Logging;
using HSchool.Business.Repository;
using HSchool.Business.Models;
using HSchool.Business;
using System.Net;
using HSchool.Common;

namespace HSchool.WebApi.Controllers
{

    [RoutePrefix("Account")]
    public class AccountApiController : BaseApiController
    {
        private readonly IUserRepository _userRepository;

        public AccountApiController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //[HttpPost]
        //[ActionName("Authenticate")]
        //public HttpResponseMessage Authenticate(UserCredential credential)
        //{
        //    LogHelper.Info(string.Format("AccountController.Authenticate - Begin"));
        //    try
        //    {
        //        AuthenticationResult authenticateResult = new AuthenticationResult
        //        {
        //            IsAuthorized = _userRepository.ValidateUser(credential)
        //        };

        //        if (authenticateResult.IsAuthorized)
        //        {
        //            authenticateResult.AuthorizationToken = AuthenticationProvider.EncodeUserCredentials(credential.UserName, credential.Password);
        //            authenticateResult.UserInfo = new UserAccount();
        //        }
        //        return ResponseMessage(authenticateResult, new ApiResponse { StatusCode = HttpStatusCode.OK, StatusText = ApiConstants.StatusSuccess });
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error(string.Format("AccountController.Authenticate - Exception:{0}", ex.Message));
        //    }
        //    LogHelper.Info(string.Format("AccountController.Authenticate - End"));
        //    return new HttpResponseMessage();
        //}       


        #region Helpers



        #endregion
    }
}
