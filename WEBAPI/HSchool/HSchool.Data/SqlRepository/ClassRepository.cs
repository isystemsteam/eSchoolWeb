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

using Classes = HSchool.Business.Models.Classes;
using ClassSectionTeacher = HSchool.Business.Models.ClassSectionTeacher;
using Subject = HSchool.Business.Models.Subject;

namespace HSchool.Data.SqlRepository
{
    public class ClassRepository : IClassRepository
    {
        #region Classes
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bClass"></param>
        /// <returns></returns>
        public int? SaveClass(Classes bClass)
        {
            LogHelper.Info(string.Format("AdminRepository.SaveClass - Begin"));
            try
            {
                Models.Classes dClass = Mapper.Map<Classes, Models.Classes>(bClass);
                SqlConnection connection = SqlDataConnection.GetSqlConnection();
                var result = connection.Query<int>(Procedures.SaveClasses, dClass);
                return result != null && result.Any() ? result.First() : (int?)null;
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("AdminRepository.SaveClass - SqlException:{0}", ex.Message), ex);
                throw;

            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminRepository.SaveClass - Exception:{0}", ex.Message), ex);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public Classes GetClassById(int classId)
        {
            LogHelper.Info(string.Format("AdminRepository.GetClassById - Begin"));
            try
            {
                SqlConnection connection = SqlDataConnection.GetSqlConnection();
                var result = connection.Query<Models.Classes>(Procedures.GetClassById, new { @Id = classId });
                var businessResults = Mapper.Map<IEnumerable<Models.Classes>, IEnumerable<Classes>>(result);
                return businessResults != null && businessResults.Any() ? businessResults.FirstOrDefault() : new Classes();
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetClassById - SqlException:{0}", ex.Message), ex);
                throw;
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetClassById - Exception:{0}", ex.Message), ex);
                throw;
            }
        }

        /// <summary>
        /// To get all classes
        /// </summary>
        /// <param name="visibleOnly"></param>
        /// <returns></returns>
        public List<Classes> GetAllClasses(bool? visibleOnly)
        {
            LogHelper.Info(string.Format("AdminRepository.GetAllClasses - Begin"));
            try
            {
                SqlConnection connection = SqlDataConnection.GetSqlConnection();
                var result = connection.Query<Models.Classes>(Procedures.GetAllClasses, visibleOnly);
                var businessResults = Mapper.Map<IEnumerable<Models.Classes>, IEnumerable<Classes>>(result);
                return businessResults != null && businessResults.Any() ? businessResults.ToList() : new List<Classes>();
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetAllClasses - SqlException:{0}", ex.Message), ex);
                throw;
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetAllClasses - Exception:{0}", ex.Message), ex);
                throw;
            }
        }
        #endregion

        ///
        public int SaveClassSectionTeacher(ClassSectionTeacher csTeacher)
        {
            return Int32.MinValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        public int? SaveSubject(Subject subject)
        {
            LogHelper.Info(string.Format("ClassRepository.SaveSubject - Begin"));
            try
            {
                Models.Subject dSubject = Mapper.Map<Subject, Models.Subject>(subject);
                SqlConnection connection = SqlDataConnection.GetSqlConnection();
                var result = connection.Query<int>(Procedures.SaveSubjects, dSubject);
                return result != null && result.Any() ? result.First() : (int?)null;
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("ClassRepository.SaveSubject - SqlException:{0}", ex.Message), ex);
                throw;

            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("ClassRepository.SaveSubject - Exception:{0}", ex.Message), ex);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Subject> GetAllSubjects()
        {
            LogHelper.Info(string.Format("ClassRepository.GetAllSubjects - Begin"));
            try
            {
                SqlConnection connection = SqlDataConnection.GetSqlConnection();
                var result = connection.Query<Models.Subject>(Procedures.GetSubjects);
                var businessResults = Mapper.Map<IEnumerable<Models.Subject>, IEnumerable<Subject>>(result);
                return businessResults != null && businessResults.Any() ? businessResults.ToList() : new List<Subject>();
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("ClassRepository.GetAllSubjects - SqlException:{0}", ex.Message), ex);
                throw;
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("ClassRepository.GetAllSubjects - Exception:{0}", ex.Message), ex);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Subject GetSubjectById(int? id)
        {
            LogHelper.Info(string.Format("ClassRepository.GetSubjectById - Begin"));
            try
            {
                SqlConnection connection = SqlDataConnection.GetSqlConnection();
                var result = connection.Query<Models.Subject>(Procedures.GetSubjectById, new { @Id = id });
                var businessResults = Mapper.Map<IEnumerable<Models.Subject>, IEnumerable<Subject>>(result);
                return businessResults != null && businessResults.Any() ? businessResults.FirstOrDefault() : new Subject();
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("ClassRepository.GetSubjectById - SqlException:{0}", ex.Message), ex);
                throw;
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("ClassRepository.GetSubjectById - Exception:{0}", ex.Message), ex);
                throw;
            }
        }
    }
}
