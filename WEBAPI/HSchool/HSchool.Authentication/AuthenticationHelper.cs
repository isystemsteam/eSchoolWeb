using HSchool.Logging;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Authentication
{
    public class AuthenticationHelper
    {

        private static UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// To initialize manager
        /// </summary>
        public static void InitializeManager()
        {
            //To reset db tables
            Database.SetInitializer<ApplicationDbContext>(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
            //intiate user manager
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            _userManager.PasswordValidator = new PasswordValidator
            {
                RequireDigit = true,
                RequiredLength = 8,
                RequireLowercase = true,
                RequireUppercase = true
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool CreateUser(string userName, string password)
        {
            LogHelper.Info(string.Format("AuthenticationHelper.CreateUser - Begin. UserName:{0}", userName));
            try
            {
                if (_userManager == null)
                {
                    InitializeManager();
                }
                var applicationUser = new ApplicationUser
                {
                    Email = userName,
                    UserName = userName,
                    UserId = 123456
                };
                var result = _userManager.Create(applicationUser, password);
                if (result.Errors != null && result.Errors.Any())
                {
                    foreach (string error in result.Errors)
                    {
                        LogHelper.Error(string.Format("AuthenticationHelper.CreateUser - IdentiyException:{0}", error));
                    }
                }
                LogHelper.Info(string.Format("AuthenticationHelper.CreateUser - End. UserName:{0}", userName));
                return result.Succeeded;
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("AuthenticationHelper.CreateUser - SqlException:{0}", ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AuthenticationHelper.CreateUser - Exception:{0}", ex.Message));
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static ApplicationUser GetUserByEmail(string email, string userName)
        {
            LogHelper.Info(string.Format("AuthenticationHelper.GetUserByEmail - Begin. UserName:{0}", email));
            try
            {
                //to initialize user manager
                if (_userManager == null)
                {
                    InitializeManager();
                }
                var result = _userManager.Find(userName, "Enter323");                
                var applicationUser = _userManager.FindByEmail(email);
                LogHelper.Info(string.Format("AuthenticationHelper.GetUserByEmail - End. UserName:{0}", email));
                return applicationUser;
            }
            catch (Exception ex)
            {
                LogHelper.Info(string.Format("AuthenticationHelper.GetUserByEmail - Exception. UserName:{0}", email));
                throw ex;
            }
        }
    }
}
