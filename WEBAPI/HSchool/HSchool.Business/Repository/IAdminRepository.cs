using HSchool.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Repository
{
    public interface IAdminRepository
    {
        void SaveSettings(Settings setting);

        List<Settings> GetSettingsByName(string applicationName);

        List<Settings> GetAllSettings();

        //void SaveCommunity(CommunityMaster community);

        //CommunityMaster GetCommunityById(int communityId);

        //List<CommunityMaster> GetAllCommunities();        

        

        void SaveClassSection(List<ClassSection> classSection);

        ClassSection GetClassSectionById(int classSectionId);

        List<ClassSection> GetClassSectionsByClassId(int classId);

        List<ClassSection> GetAllClassSections(bool isAll);

        ApplicationRole GetRoleById(int id);

        List<ApplicationRole> GetAllRoles(bool visibleToLogin);

        int? SaveApplicationRole(ApplicationRole role);

        ApplicationPermission GetApplicationPermissionById(int id);

        List<ApplicationPermission> GetApplicationPermissionByRoleId(int roleId);

        List<RolePrivilege> GetRolePrivilegesByModuleId(int moduleId);

        List<RolePrivilege> GetAllApplicationPermission();

        List<ApplicationModule> GetAllModules();

        List<ApplicationPrivilege> GetApplicationPrivileges();

        void SaveRolePrivileges(List<RolePrivilege> rolePrivileges);

        int? SaveAcademicYear(AcademicYear year);

        AcademicYear GetAcademicYearById(int academicYearId);

        AcademicYear GetActiveAcademicYear();

        List<AcademicYear> GetAcademicYears();

        List<CommunityMaster> GetCommunities();

        List<MotherLanguages> GetMotherLanguages();

        List<UserRelationship> GetRelationships();

    }
}
