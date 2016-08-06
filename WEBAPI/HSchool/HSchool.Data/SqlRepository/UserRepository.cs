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
using AutoMapper;
using System.Security.Cryptography;
using HSchool.Data;

using UserCredential = HSchool.Business.Models.UserCredential;
using UserAccount = HSchool.Business.Models.UserAccount;
using UserCreateModel = HSchool.Business.Models.UserCreateModel;

namespace HSchool.Data.SqlRepository
{
    public class UserRepository : IUserRepository
    {
        #region Public Methods

        /// <summary>
        /// To save user information
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public int SaveUser(UserCreateModel userInfo)
        {
            LogHelper.Info(string.Format("UserRepository.SaveUser - Begin."));
            int userId = 0;
            try
            {
                SqlConnection connection = SqlDataConnection.GetSqlConnection();
                Models.UserAccount dUserInfo = Mapper.Map<UserCreateModel, Models.UserCreateModel>(userInfo);
                var results = connection.Query<int>(Procedures.SaveInternalUser, dUserInfo);
                userId = results.Any() ? results.FirstOrDefault() : 0;
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("UserRepository.SaveUser - Exception:{0}", ex.Message), ex);
                throw;
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("UserRepository.SaveUser - SqlException:{0}", ex.Message), ex);
                throw;
            }
            LogHelper.Info(string.Format("UserRepository.SaveUser - End. UserId:{0}", userId));
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
