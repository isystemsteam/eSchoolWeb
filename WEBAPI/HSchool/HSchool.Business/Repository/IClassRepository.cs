using HSchool.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Repository
{
    public interface IClassRepository
    {
        int? SaveClass(Classes classes);

        List<Classes> GetAllClasses(bool? visibleOnly);

        Classes GetClassById(int classId);

        int SaveClassSectionTeacher(ClassSectionTeacher csTeacher);

        int? SaveSubject(Subject subject);

        List<Subject> GetAllSubjects();

        Subject GetSubjectById(int? id);
    }
}
