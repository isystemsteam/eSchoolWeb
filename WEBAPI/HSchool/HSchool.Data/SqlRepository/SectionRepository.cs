using AutoMapper;
using HSchool.Business.Repository;
using HSchool.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Database;

using Section = HSchool.Business.Models.Section;

namespace HSchool.Data.SqlRepository
{
    public class SectionRepository : ISectionRepository
    {
        #region Sections
        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public int? SaveSections(Section section)
        {
            LogHelper.Info(string.Format("AdminRepository.SaveSections - Begin"));
            try
            {
                Models.Section dSection = Mapper.Map<Section, Models.Section>(section);
                SqlConnection connection = SqlDataConnection.GetSqlConnection();
                var result = connection.Query<int>(Procedures.SaveSections, dSection);
                return result != null && result.Any() ? result.First() : (int?)null;
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("AdminRepository.SaveSections - SqlException:{0}", ex.Message), ex);
                throw;

            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminRepository.SaveSections - Exception:{0}", ex.Message), ex);
                throw;
            }
        }

        /// <summary>
        /// To get section by id
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public Section GetSectionById(int sectionId)
        {
            LogHelper.Info(string.Format("AdminRepository.GetSectionById - Begin"));
            try
            {
                SqlConnection connection = SqlDataConnection.GetSqlConnection();
                var result = connection.Query<Models.Section>(Procedures.GetSectionById, new { @Id = sectionId });
                var businessResults = Mapper.Map<IEnumerable<Models.Section>, IEnumerable<Section>>(result);
                return businessResults != null && businessResults.Any() ? businessResults.FirstOrDefault() : new Section();
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetSectionById - SqlException:{0}", ex.Message), ex);
                throw;
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetSectionById - Exception:{0}", ex.Message), ex);
                throw;
            }
        }

        /// <summary>
        /// To get all section
        /// </summary>
        /// <param name="visibleOnly"></param>
        /// <returns></returns>
        public List<Section> GetAllSections(bool isGetAll)
        {
            LogHelper.Info(string.Format("AdminRepository.GetAllSections - Begin"));
            try
            {
                SqlConnection connection = SqlDataConnection.GetSqlConnection();
                var result = connection.Query<Models.Section>(Procedures.GetAllSections, new { @ALL = isGetAll });
                var businessResults = Mapper.Map<IEnumerable<Models.Section>, IEnumerable<Section>>(result);
                return businessResults != null && businessResults.Any() ? businessResults.ToList() : new List<Section>();
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetAllSections - SqlException:{0}", ex.Message), ex);
                throw;
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetAllSections - Exception:{0}", ex.Message), ex);
                throw;
            }
        }
        #endregion
    }
}
