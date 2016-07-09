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

namespace HSchool.Data.SqlRepository
{
    public class StudentRepository : IStudentRepository
    {
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
                    var results = connection.Query<int>(Procedures.SaveStudentInformation, dStudent);
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
