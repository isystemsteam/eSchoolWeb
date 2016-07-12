using HSchool.Business.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using HSchool.Logging;
using AutoMapper;
using Insight.Database;

using UserCredential = HSchool.Business.Models.UserCredential;
using UserAccount = HSchool.Business.Models.UserAccount;
using UserSecurity = HSchool.Business.Models.UserSecurity;

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
            LogHelper.Info(string.Format("UserRepository.ValidateUser - Begin. UserName:{0}", credential.UserName));
            var loginResult = false;
            try
            {
                using (SqlConnection connection = SqlDataConnection.GetSqlConnection())
                {
                    var dSecurity = connection.Query<Models.UserSecurity>(Procedures.GetUserDetailsById, new { credential.UserName });
                    var dUserCredential = Mapper.Map<UserCredential, Models.UserCredential>(credential);
                    
                }
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("UserRepository.ValidateUser- SqlException:{0}", ex.Message), ex);
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("UserRepository.ValidateUser- SqlException:{0}", ex.Message), ex); ;
            }
            LogHelper.Info(string.Format("UserRepository.ValidateUser - End. UserName:{0} - LoginResult", credential.UserName, loginResult));
            return loginResult;
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
