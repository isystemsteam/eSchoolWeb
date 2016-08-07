using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Data
{
    public class DataConstants
    {

    }

    public class Procedures
    {
        #region User
        public const string GetUserDetailsById = "GetUserDetailsById";

        public const string SaveUserInformation = "SaveUserInformation";

        public const string SaveInternalUser = "SaveInternalUser";
        #endregion

        public const string SaveStudentInformation = "SaveStudentInformation";

        public const string SaveApplication = "SaveApplication";

        public const string SaveSettings = "SaveSettings";

        #region Classes
        public const string SaveClasses = "SaveClasses";

        public const string GetAllClasses = "GetAllClasses";

        public const string GetClassById = "GetClassById";
        #endregion

        #region Class & Subject
        public const string SaveClassSubject = "SaveClassSubject";
        public const string SaveSubjects = "SaveSubjects";
        public const string GetSubjects = "GetSubjects";
        public const string GetSubjectById = "GetSubjectById";
        public const string GetClassSubjects = "GetClassSubjects";
        #endregion

        public const string SaveSections = "SaveSections";

        public const string GetAllSections = "GetAllSections";

        public const string GetSectionById = "GetSectionById";

        public const string GetAllClassSections = "GetAllClassSections";

        public const string SaveClassSections = "SaveClassSections";

        public const string GetClassSectionById = "GetClassSectionById";

        public const string GetAllRoles = "GetAllRoles";

        public const string SaveApplicationRole = "SaveApplicationRole";

        public const string GetRoleById = "GetRoleById";

        public const string GetApplicationModules = "GetApplicationModules";

        public const string GetApplicationPrivileges = "GetApplicationPrivileges";

        public const string GetRolePrivileges = "GetRolePrivileges";


        public const string SaveRolePrivileges = "SaveRolePrivileges";

        public const string GetRolePrivilegesByModuleId = "GetRolePrivilegesByModuleId";

        public const string SaveAcademicYear = "SaveAcademicYear";

        public const string GetActiveAcademicYear = "GetActiveAcademicYear";

        public const string GetAcademicYearById = "GetAcademicYearById";

        public const string GetAcademicYears = "GetAcademicYears";

        public const string GetCommunities = "GetCommunities";

        public const string GetMotherLanguages = "GetMotherLanguages";

        public const string GetRelationships = "GetRelationships";

        public const string SearchApplications = "SearchApplications";

        public const string GetApplicationStatus = "GetApplicationStatus";

        public const string GetApplicationById = "GetApplicationById";

        public const string SearchStudents = "SearchStudents";

        #region Privilege
        public const string GetModulePrivilegesByRoleId = "GetModulePrivilegesByRoleId";
        #endregion
    }
}
