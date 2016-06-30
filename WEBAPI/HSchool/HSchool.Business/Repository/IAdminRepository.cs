﻿using HSchool.Business.Models;
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

        int? SaveClass(Classes classes);

        List<Classes> GetAllClasses(bool? visibleOnly);

        Classes GetClassById(int classId);

        int? SaveSections(Section section);

        List<Section> GetAllSections(bool isGetAll);

        Section GetSectionById(int sectionId);

        int? SaveClassSection(ClassSection classSection);

        ClassSection GetClassSectionById(int classSectionId);

        List<ClassSection> GetClassSectionsByClassId(int classId);

        List<ClassSection> GetAllClassSections(bool isAll);

        ApplicationRole GetRoleById(int id);

        List<ApplicationRole> GetAllRoles(bool visibleToLogin);

        int? SaveApplicationRole(ApplicationRole role);

        ApplicationPermission GetApplicationPermissionById(int id);

        List<ApplicationPermission> GetApplicationPermissionByRoleId(int roleId);

        List<ApplicationPermission> GetApplicationPermissionByModuleId(int moduleId);

        List<ApplicationPermission> GetAllApplicationPermission();

        List<ApplicationModule> GetAllModules();
    }
}
