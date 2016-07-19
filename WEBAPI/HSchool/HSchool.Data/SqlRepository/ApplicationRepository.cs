using AutoMapper;
using HSchool.Business.Repository;
using HSchool.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Database;

using ApplicationForm = HSchool.Business.Models.ApplicationForm;
using ApplicationFormSearch = HSchool.Business.Models.ApplicationFormSearch;

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
                    return results != null ? results.First() : (int?)null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("ApplicationRepository.SaveApplication - Exception:{0}", ex.Message));
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formSearch"></param>
        /// <returns></returns>
        public List<ApplicationForm> GetApplications(ApplicationFormSearch formSearch)
        {
            LogHelper.Info(string.Format("ApplicationRepository.GetApplications - Begin"));
            try
            {
                using (var connection = SqlDataConnection.GetSqlConnection())
                {
                    LogHelper.Info(string.Format("ApplicationRepository.GetApplications - End"));
                    return new List<ApplicationForm>();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("ApplicationRepository.GetApplications - Exception:{0}", ex.Message));
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
    }
}
