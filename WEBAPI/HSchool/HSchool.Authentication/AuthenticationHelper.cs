using HSchool.Logging;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Authentication
{
    public class AuthenticationHelper
    {

        private readonly UserManager<ApplicationUser> _userManager;
        public AuthenticationHelper(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public static bool CreateUser(string userName, string password)
        {
            try
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                userManager.PasswordValidator = new PasswordValidator
                {
                    RequireDigit = true,
                    RequiredLength = 8,
                    RequireLowercase = true,
                    RequireUppercase = true
                };
                var applicationUser = new ApplicationUser
                {
                    Email = userName
                };
                var result = userManager.Create(applicationUser, password);
                if (result.Succeeded)
                {
                    return true;
                }
                else
                {
                    foreach (string error in result.Errors)
                    {

                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AuthenticationHelper.CreateUser - Exception:{0}", ex.Message));
                throw;
            }
        }
    }
}
