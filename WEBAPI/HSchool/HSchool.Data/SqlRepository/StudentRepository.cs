using AutoMapper;
using HSchool.Business.Repository;
using HSchool.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Database;


using Student = HSchool.Business.Models.Student;
using ApplicationForm = HSchool.Business.Models.ApplicationForm;

namespace HSchool.Data.SqlRepository
{
    public class StudentRepository : IStudentRepository
    {
        public int? SaveApplication(ApplicationForm form)
        {
            LogHelper.Info(string.Format("StudentRepository.SaveApplication - Begin"));
            try
            {
                using (var connection = SqlDataConnection.GetSqlConnection())
                {
                    var dStudent = Mapper.Map<ApplicationForm, Models.ApplicationForm>(form);
                    var results = connection.Query<int>(Procedures.SaveApplication, dStudent);
                    LogHelper.Info(string.Format("StudentRepository.SaveApplication - End"));
                    return results != null ? results.First() : (int?)null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("StudentRepository.SaveApplication - Exception:{0}", ex.Message));
                throw ex;
            }
        }

        /// <summary>
        /// To store student information
        /// </summary>
        /// <param name="student">student</param>
        /// <returns></returns>
        public int? SaveStudentInformation(Student student)
        {
            LogHelper.Info(string.Format("StudentRepository.SaveStudentInformation - Begin"));
            try
            {
                using (var connection = SqlDataConnection.GetSqlConnection())
                {
                    var dStudent = Mapper.Map<Student, Models.Student>(student);
                    var results = connection.Query<int>(Procedures.SaveApplication, dStudent);
                    LogHelper.Info(string.Format("StudentRepository.SaveStudentInformation - End"));
                    return results != null ? results.First() : (int?)null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("StudentRepository.SaveStudentInformation - Exception:{0}", ex.Message));
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public Student GetStudnetById(int studentId)
        {
            LogHelper.Info(string.Format("StudentRepository.GetStudnetById - Begin"));
            LogHelper.Info(string.Format("StudentRepository.GetStudnetById - End"));
            return new Student();
        }
    }
}
