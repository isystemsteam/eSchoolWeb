using HSchool.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Repository
{
    public interface IStudentRepository
    {

        List<StudentSearchResponse> SearchStudents(StudentSearch search);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        int? SaveStudentInformation(Student student);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        Student GetStudnetById(int studentId);
    }
}
