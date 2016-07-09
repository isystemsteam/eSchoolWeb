using HSchool.Business.Models;
using HSchool.Business.Repository;
using HSchool.Common;
using HSchool.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace HSchool.WebApi.Helpers
{
    public class LoginHelper
    {
        private static string initVector = "";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="credential"></param>
        /// <param name="security"></param>
        /// <returns></returns>
        public static bool ValidateUser(UserCredential credential, UserSecurity security)
        {
            LogHelper.Info(string.Format("LoginHelper.ValidateUser - Begin. Username:{0}", credential.UserName));
            if (credential != null && security != null)
            {
                LogHelper.Info(string.Format("LoginHelper.ValidateUser - Details Available"));
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static UserSecurity CreateUserSecurity(UserCredential credential, bool isDefault)
        {
            LogHelper.Info(string.Format("LoginHelper.CreateUserSecurity - Begin."));
            var userSecurity = new UserSecurity();
            try
            {
                string initVector = CommonHelper.GetWebConfigValue<string>(WebConstants.AppSecurityKey);
                credential.Password = CommonHelper.GetWebConfigValue<string>(WebConstants.AppSecurityKey);
                if (string.IsNullOrWhiteSpace(credential.UserName) && string.IsNullOrWhiteSpace(credential.Password))
                {
                    string passwordPlanText = CommonHelper.RandomString(credential.UserName.Length);
                    userSecurity.SecurityKey = passwordPlanText;
                    userSecurity.Password = CommonHelper.EncryptString(passwordPlanText, credential.Password, initVector);
                }
                LogHelper.Info(string.Format("LoginHelper.CreateUserSecurity - End."));
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("LoginHelper.ReadUserInfo - Exception:{0}", ex.Message));
            }
            return userSecurity;
        }

        public static UserCredential GetUserCredential(string userName, UserSecurity userSecurity)
        {
            return new UserCredential();
        }
    }
}