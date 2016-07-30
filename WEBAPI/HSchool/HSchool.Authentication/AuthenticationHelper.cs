using HSchool.Authentication.Models;
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
        #region Fields
        private static UserManager<ApplicationUser> _userManager;
        #endregion

        #region Init
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
            //make email as unique
            _userManager.UserValidator = new UserValidator<ApplicationUser>(_userManager) { RequireUniqueEmail = true };
        }
        #endregion

        #region Authentication
        /// <summary>
        /// To create user
        /// </summary>
        /// <param name="email">email</param>
        /// <param name="userName">user name</param>
        /// <param name="password">password</param>
        /// <returns></returns>
        public static bool CreateUser(string email, string userName, string password, string passwordQuestion, string passwordAnswer)
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
                    Email = email,
                    UserName = userName
                };
                var result = _userManager.Create(applicationUser, password);
                if (result.Errors != null && result.Errors.Any())
                {
                    string error = result.Errors.FirstOrDefault();
                    throw new LoginException(error);
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
        /// validate user name & password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool ValidateUser(string userName, string password)
        {
            LogHelper.Info(string.Format("AuthenticationHelper.ValidateUser - Begin. UserName:{0}", userName));
            try
            {
                //to initialize user manager
                if (_userManager == null)
                {
                    InitializeManager();
                }
                var applicationUser = _userManager.Find(userName, password);
                if(applicationUser!=null)
                {

                }
                LogHelper.Info(string.Format("AuthenticationHelper.ValidateUser - End. UserName:{0}", userName));
                return applicationUser != null;
            }
            catch (Exception ex)
            {
                LogHelper.Info(string.Format("AuthenticationHelper.ValidateUser - Exception. UserName:{0}", userName));
                throw ex;
            }
        }
        #endregion
    }
}
