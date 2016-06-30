using HSchool.Business.Models;
using HSchool.Business.Repository;
using HSchool.Common;
using HSchool.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace HSchool.Business
{
    public static class Authentication
    {
        #region Methods

        /// <summary>
        /// to validate user credentials with remedy wrapper
        /// </summary>
        /// <param name="userRepository">user repository object </param>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns></returns>
        public static bool ValidateUserCredential(IUserRepository userRepository, string username, string password)
        {
            LogHelper.Info(string.Format("Authentication.ValidateUserCredential - Begin. Username: {0}", username));
            return userRepository.ValidateUser(new UserCredential { UserName = username, Password = password });
        }

        /// <summary>
        /// to get user credentials from token
        /// </summary>
        /// <param name="authHeaderValue">header value from request</param>
        /// <returns>returns user credential. User name only</returns>
        public static UserCredential GetUserCredentialFromToken(string authHeaderValue)
        {
            var ticket = DecodeUserCredentials(authHeaderValue);
            return new UserCredential
            {
                UserName = ticket.Name,
                Password = ReadPassword(ticket)
            };
        }

        /// <summary>
        /// to encode user credentials
        /// </summary>
        /// <param name="username"> username</param>
        /// <param name="password"> password</param>
        /// <returns></returns>
        public static string EncodeUserCredentials(string username, string password)
        {
            LogHelper.Info(string.Format("Authentication.EncodeUserCredentials - Begin & End. UserName:{0}", username));
            return FormsAuthentication.Encrypt(new FormsAuthenticationTicket(
                CommonHelper.GetWebConfigValue<Int32>(ApiConstants.ApiVersion),
                username,
                DateTime.Now,
                DateTime.Now.AddMinutes(CommonHelper.GetWebConfigValue<Int32>(ApiConstants.ExpiryMinutes)),
                false,
                string.Format("{0}:{1}-{2}:{3}", ApiConstants.Username, username, ApiConstants.Password, password)));
        }

        /// <summary>
        /// to decode user credentials
        /// </summary>
        /// <param name="authorizeToken">token</param>
        /// <returns>returns forms authenticate</returns>
        public static FormsAuthenticationTicket DecodeUserCredentials(string authorizeToken)
        {
            LogHelper.Info(string.Format("Authentication.DecodeUserCredentials -Begin & End. authorizeToken:{0}", authorizeToken));
            return FormsAuthentication.Decrypt(authorizeToken);
        }

        /// <summary>
        /// to refresh authorization token
        /// </summary>
        /// <param name="authToken">auth token which was send in request header</param>
        /// <returns>returns encrypted string</returns>
        public static string RefreshAuthorizationToken(string authToken)
        {
            LogHelper.Debug(string.Format("Authentication.RefreshAuthorizationToken - Begin"));
            var authTicket = DecodeUserCredentials(authToken);
            var password = authTicket.UserData.Split(ApiConstants.CharHyphen)[1].Split(ApiConstants.CharColon)[1];
            LogHelper.Debug(string.Format("Authentication.RefreshAuthorizationToken - End"));
            return EncodeUserCredentials(authTicket.Name, password);
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// to read password from token
        /// </summary>
        /// <param name="formsAuthenticationTicket">form authenticate</param>
        /// <returns></returns>
        private static string ReadPassword(FormsAuthenticationTicket formsAuthenticationTicket)
        {
            LogHelper.Info(string.Format("Authentication.ReadPassword- Begin & End"));
            return formsAuthenticationTicket.UserData.Split(ApiConstants.CharHyphen)[1].Split(ApiConstants.CharColon)[1];
        }

        #endregion
    }
}
