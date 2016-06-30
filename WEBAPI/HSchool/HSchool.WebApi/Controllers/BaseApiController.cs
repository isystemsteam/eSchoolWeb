using HSchool.Business;
using HSchool.Business.Models;
using HSchool.Common;
using HSchool.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace HSchool.WebApi.Controllers
{
    public class BaseApiController : ApiController
    {
        /// <summary>
        /// options
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="sResponse"></param>
        /// <returns></returns>
        public HttpResponseMessage ResponseMessage<T>(T source, ApiResponse sResponse) where T : class
        {
            LogHelper.Info(string.Format("BaseApiController.ResponseMessage - Begin. Code:{0}, Text:{1} and Reason:{0}", sResponse.StatusCode, sResponse.StatusText, sResponse.Reason));
            var authorizationToken = Request.Headers.Contains(ApiConstants.AuthorizationToken) ? Request.Headers.GetValues(ApiConstants.AuthorizationToken).ToList() : new List<string>();
            LogHelper.Debug(string.Format("BaseApiController.ResponseMessage - authorizationToken count:{0}", authorizationToken.Count));
            var response = Request.CreateResponse(sResponse.StatusCode, new MessageResponse<T>(source, sResponse.StatusText, (int)sResponse.StatusCode, sResponse.Reason));
            if (authorizationToken.Count > 0)
            {
                LogHelper.Debug(string.Format("AuthorizationToken:{0} and AuthorizationTokenCount:{1}", authorizationToken[0], authorizationToken.Count));
                response.Headers.Add(ApiConstants.AuthorizationToken, Authentication.RefreshAuthorizationToken(authorizationToken[0]));
                LogHelper.Debug(string.Format("BaseApiController.AotsHttpResponse - Refresh Token"));
            }
            LogHelper.Info(string.Format("BaseApiController.ResponseMessage - End"));
            return response;
        }
    }
}