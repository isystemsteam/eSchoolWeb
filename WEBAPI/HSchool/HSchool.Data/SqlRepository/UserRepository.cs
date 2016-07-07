using HSchool.Business.Repository;
using HSchool.Data.Models;
using HSchool.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Insight.Database;

using Models = HSchool.Business.Models;
using UserCredential = HSchool.Business.Models.UserCredential;
using UserAccount = HSchool.Business.Models.UserAccount;
using AutoMapper;
using System.Security.Cryptography;
using HSchool.Data.Helper;

namespace HSchool.Data.SqlRepository
{
    public class UserRepository : IUserRepository
    {
        #region Public Methods
        /// <summary>
        /// to validate user
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
                    loginResult = UserAuthentication.ValidateUserCredential(dSecurity.Any() ? dSecurity.FirstOrDefault() : new UserSecurity(), dUserCredential);
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
        /// To save user information
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public int InsertUpdateUser(UserAccount userInfo)
        {
            LogHelper.Info(string.Format("UserRepository.InsertUpdateUser - Begin."));
            int userId = 0;
            try
            {
                SqlConnection connection = SqlDataConnection.GetSqlConnection();
                Models.UserAccount dUserInfo = Mapper.Map<UserAccount, Models.UserAccount>(userInfo);
                var results = connection.Query<int>(Procedures.SaveUserInformation, dUserInfo);
                userId = results.Any() ? results.FirstOrDefault() : 0;
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("UserRepository.InsertUpdateUser - Exception:{0}", ex.Message), ex);
                throw;
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("UserRepository.InsertUpdateUser - SqlException:{0}", ex.Message), ex);
                throw;
            }
            LogHelper.Info(string.Format("UserRepository.InsertUpdateUser - End. UserId:{0}", userId));
            return userId;
        }

        /// <summary>
        /// To get user information by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserAccount GetUserDetailsById(int userId)
        {
            LogHelper.Info(string.Format("UserRepository.GetUserDetailsById - Begin. UserId:{0}", userId));
            UserAccount userInfo = null;
            try
            {
                SqlConnection connection = SqlDataConnection.GetSqlConnection();
                var results = connection.Query<Models.UserAccount>(Procedures.GetUserDetailsById, new { @userId = userId });
                IEnumerable<UserAccount> userCollection = Mapper.Map<IEnumerable<Models.UserAccount>, IEnumerable<UserAccount>>(results);
                userInfo = userCollection.Any() ? userCollection.FirstOrDefault() : null;
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("UserRepository.GetUserDetailsById - Exception:{0}", ex.Message), ex);
                throw;
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("UserRepository.GetUserDetailsById - SqlException:{0}", ex.Message), ex);
                throw;
            }
            LogHelper.Info(string.Format("UserRepository.GetUserDetailsById - End. UserId:{0}", userId));
            return userInfo;
        }
        #endregion

        #region Private Methods


        #endregion
    }
}
