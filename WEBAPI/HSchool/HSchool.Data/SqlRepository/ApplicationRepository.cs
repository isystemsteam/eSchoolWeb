using AutoMapper;
using HSchool.Business.Repository;
using HSchool.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Database;
using System.Data.SqlClient;

using ApplicationForm = HSchool.Business.Models.ApplicationForm;
using ApplicationFormSearch = HSchool.Business.Models.ApplicationFormSearch;
using ApplicationFormResponse = HSchool.Business.Models.ApplicationFormResponse;

namespace HSchool.Data.SqlRepository
{
    public class ApplicationRepository : IApplicationRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public int? SaveApplication(ApplicationForm form)
        {
            LogHelper.Info(string.Format("ApplicationRepository.SaveApplication - Begin"));
            try
            {
                using (var connection = SqlDataConnection.GetSqlConnection())
                {
                    var dStudent = Mapper.Map<ApplicationForm, Models.ApplicationForm>(form);
                    var results = connection.Query<int>(Procedures.SaveApplication, dStudent);
                    LogHelper.Info(string.Format("ApplicationRepository.SaveApplication - End"));
                    return results != null && results.Any() ? results.First() : (int?)null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("ApplicationRepository.SaveApplication - Exception:{0}", ex.Message));
                throw ex;
            }
        }

        /// <summary>
        /// Search applications
        /// </summary>
        /// <param name="formSearch"></param>
        /// <returns></returns>
        public List<ApplicationFormResponse> SearchApplications(ApplicationFormSearch formSearch)
        {
            LogHelper.Info(string.Format("ApplicationRepository.SearchApplications - Begin"));
            try
            {
                using (var connection = SqlDataConnection.GetSqlConnection())
                {
                    LogHelper.Info(string.Format("ApplicationRepository.SearchApplications - End"));
                    Models.ApplicationFormSearch dFormSearch = Mapper.Map<ApplicationFormSearch, Models.ApplicationFormSearch>(formSearch);
                    var result = connection.Query<Models.ApplicationFormResponse>(Procedures.SearchApplications, dFormSearch);
                    var businessResults = Mapper.Map<IEnumerable<Models.ApplicationFormResponse>, IEnumerable<ApplicationFormResponse>>(result);
                    return businessResults != null && businessResults.Any() ? businessResults.ToList() : new List<ApplicationFormResponse>();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("ApplicationRepository.SearchApplications - Exception:{0}", ex.Message));
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ApplicationForm GetApplicationById(int id)
        {
            LogHelper.Info(string.Format("ApplicationRepository.GetApplicationById - Begin"));
            try
            {
                using (var connection = SqlDataConnection.GetSqlConnection())
                {
                    LogHelper.Info(string.Format("ApplicationRepository.GetApplicationById - End"));
                    return new ApplicationForm();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("ApplicationRepository.GetApplicationById - Exception:{0}", ex.Message));
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dateOfBirth"></param>
        /// <returns></returns>
        public int? GetApplicationStatus(int id, DateTime? dateOfBirth)
        {
            LogHelper.Info(string.Format("ApplicationRepository.GetApplicationById - Begin"));
            try
            {
                using (var connection = SqlDataConnection.GetSqlConnection())
                {
                    LogHelper.Info(string.Format("ApplicationRepository.GetApplicationById - End"));
                    var result = connection.Query<int>(Procedures.GetApplicationStatus, new { @ApplicationId = id, @dateofbirth = dateOfBirth });
                    return result != null && result.Any() ? result.First() : (int?)null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("ApplicationRepository.GetApplicationById - Exception:{0}", ex.Message));
                throw ex;
            }
        }
    }
}
