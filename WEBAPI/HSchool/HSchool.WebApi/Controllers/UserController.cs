using HSchool.Business.Models;
using HSchool.Business.Repository;
using HSchool.Common;
using HSchool.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HSchool.WebApi.Controllers
{
    public class UserController : BaseApiController
    {
        #region Readonly Variables
        private readonly IUserRepository _userRepository;
        #endregion

        #region Ctor
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion

        #region Actions
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("getuser")]
        public HttpResponseMessage GetUserDetails(int id)
        {
            LogHelper.Info(string.Format("UserController.GetUserDetails - Begin. UserId:{0}", id));
            try
            {
                UserInfo userInfo = _userRepository.GetUserDetailsById(id);
                LogHelper.Info(string.Format("UserController.GetUserDetails - End. UserId:{0}", id));
                return ResponseMessage(userInfo, new ApiResponse { StatusCode = HttpStatusCode.OK, StatusText = ApiConstants.StatusSuccess });
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("UserController.GetUserDetails - UserId:{0}, Exception:{1}", id, ex.Message), ex);
                return ResponseMessage(new UserInfo(), new ApiResponse { StatusCode = HttpStatusCode.ExpectationFailed, Reason = ex.Message, StatusText = ApiConstants.StatusFailure });
            }
        }

        
        #endregion
    }
}
