using HSchool.Business.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCredential = HSchool.Business.Models.UserCredential;
using UserAccount = HSchool.Business.Models.UserAccount;

namespace HSchool.Data.SqlRepository
{
    public class LoginRepository : ILoginRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="credential"></param>
        /// <returns></returns>
        public bool ValidateUser(UserCredential credential)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserAccount GetLoggedInUserDetails(int userId)
        {
            return new UserAccount();
        }
    }
}
