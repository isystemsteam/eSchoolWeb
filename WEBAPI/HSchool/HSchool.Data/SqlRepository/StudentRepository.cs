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
using StudentSearch = HSchool.Business.Models.StudentSearch;
using StudentSearchResponse = HSchool.Business.Models.StudentSearchResponse;

namespace HSchool.Data.SqlRepository
{
    public class StudentRepository : IStudentRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<StudentSearchResponse> SearchStudents(StudentSearch search)
        {
            LogHelper.Info(string.Format("StudentRepository.SearchStudents - Begin"));
            try
            {
                using (var connection = SqlDataConnection.GetSqlConnection())
                {
                    var dStudentSearch = Mapper.Map<StudentSearch, Models.StudentSearch>(search);
                    var results = connection.Query<Models.StudentSearchResponse>(Procedures.SearchStudents, dStudentSearch);
                    var dStudentResponse = Mapper.Map<IEnumerable<Models.StudentSearchResponse>, IEnumerable<StudentSearchResponse>>(results);
                    LogHelper.Info(string.Format("StudentRepository.SearchStudents - End"));
                    return dStudentResponse != null ? dStudentResponse.ToList() : new List<StudentSearchResponse>();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("StudentRepository.SearchStudents - Exception:{0}", ex.Message));
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
