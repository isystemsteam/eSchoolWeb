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
        private static ILoginRepository _loginRepository;
        public LoginHelper(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public static bool ValidateUser(UserCredential credential)
        {
            LogHelper.Info(string.Format("LoginHelper.ValidateUser - Begin. Username:{0}", credential.UserName));
            if (_loginRepository.ValidateUser(credential))
            {
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private static string GenerateUserPassword(string password)
        {
            LogHelper.Info(string.Format("LoginHelper.ReadUserInfo - Begin."));
            try
            {
                string securityKey = CommonHelper.GetWebConfigValue<string>(WebConstants.AppSecurityKey);

                LogHelper.Info(string.Format("LoginHelper.ReadUserInfo - End."));
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("LoginHelper.ReadUserInfo - Exception:{0}", ex.Message));
            }
            return string.Empty;
        }        
    }
}