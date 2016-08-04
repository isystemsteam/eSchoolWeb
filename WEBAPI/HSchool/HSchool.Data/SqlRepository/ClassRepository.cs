using HSchool.Business.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClassSectionTeacher = HSchool.Business.Models.ClassSectionTeacher;

namespace HSchool.Data.SqlRepository
{
    public class ClassRepository : IClassRepository
    {
        ///
        public int SaveClassSectionTeacher(ClassSectionTeacher csTeacher)
        {
            return Int32.MinValue;
        }
    }
}
