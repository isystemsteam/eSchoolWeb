﻿using AutoMapper;
using HSchool.Business.Repository;
using HSchool.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Database;

using Settings = HSchool.Business.Models.Settings;
using Classes = HSchool.Business.Models.Classes;
using Section = HSchool.Business.Models.Section;
using ClassSection = HSchool.Business.Models.ClassSection;
using ApplicationRole = HSchool.Business.Models.ApplicationRole;
using ApplicationPermission = HSchool.Business.Models.ApplicationPermission;
using ApplicationModule = HSchool.Business.Models.ApplicationModule;
using RolePrivilege = HSchool.Business.Models.RolePrivilege;
using ApplicationPrivilege = HSchool.Business.Models.ApplicationPrivilege;
using AcademicYear = HSchool.Business.Models.AcademicYear;
using CommunityMaster = HSchool.Business.Models.CommunityMaster;
using MotherLanguages = HSchool.Business.Models.MotherLanguages;
using UserRelationship = HSchool.Business.Models.UserRelationship;

namespace HSchool.Data.SqlRepository
{
    public class AdminRepository : IAdminRepository
    {
        #region Settings
        /// <summary>
        /// to save settings
        /// </summary>
        /// <param name="setting"></param>
        public void SaveSettings(Settings setting)
        {
            LogHelper.Info(string.Format("AdminRepository.SaveSettings - Begin"));
            try
            {
                Models.Settings dSettings = Mapper.Map<Settings, Models.Settings>(setting);
                SqlConnection connection = SqlDataConnection.GetSqlConnection();
                var result = connection.Query<int>(Procedures.SaveSettings, new { dSettings });
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("AdminRepository.SaveSettings - SqlException:{0}", ex.Message), ex);
                throw;

            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminRepository.SaveSettings - Exception:{0}", ex.Message), ex);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationName"></param>
        /// <returns></returns>
        public List<Settings> GetSettingsByName(string applicationName)
        {
            LogHelper.Info(string.Format("AdminRepository.GetSettingsByName - Begin"));
            try
            {
                SqlConnection connection = SqlDataConnection.GetSqlConnection();
                var result = connection.Query<Data.Models.Settings>(Procedures.SaveSettings, new { applicationName });
                IEnumerable<Settings> settings = Mapper.Map<IEnumerable<Models.Settings>, IEnumerable<Settings>>(result);
                return settings.ToList();
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetSettingsByName - SqlException:{0}", ex.Message), ex);
                throw;
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetSettingsByName - Exception:{0}", ex.Message), ex);
                throw;
            }
        }

        /// <summary>
        /// to get all application settings
        /// </summary>
        /// <returns></returns>
        public List<Settings> GetAllSettings()
        {
            LogHelper.Info(string.Format("AdminRepository.GetAllSettings - Begin"));
            try
            {
                return new List<Settings>();
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetAllSettings - SqlException:{0}", ex.Message), ex);
                throw;

            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetAllSettings - Exception:{0}", ex.Message), ex);
                throw;
            }
        }
        #endregion

        #region ClassSections
        /// <summary>
        /// 
        /// </summary>
        /// <param name="classSection"></param>
        /// <returns></returns>
        public void SaveClassSection(List<ClassSection> classSections)
        {
            LogHelper.Info(string.Format("AdminRepository.SaveClassSection - Begin"));
            try
            {
                List<Models.ClassSection> dClassSection = Mapper.Map<List<ClassSection>, List<Models.ClassSection>>(classSections);
                SqlConnection connection = SqlDataConnection.GetSqlConnection();
                var result = connection.Query<int>(Procedures.SaveClassSections, dClassSection);
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("AdminRepository.SaveClassSection - SqlException:{0}", ex.Message), ex);
                throw;
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminRepository.SaveClassSection - Exception:{0}", ex.Message), ex);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="classSectionId"></param>
        /// <returns></returns>
        public ClassSection GetClassSectionById(int classSectionId)
        {
            LogHelper.Info(string.Format("AdminRepository.GetClassSectionById - Begin"));
            try
            {
                SqlConnection connection = SqlDataConnection.GetSqlConnection();
                var result = connection.Query<Models.ClassSection>(Procedures.GetClassSectionById, new { @Id = classSectionId });
                var businessResults = Mapper.Map<IEnumerable<Models.ClassSection>, IEnumerable<ClassSection>>(result);
                return businessResults != null && businessResults.Any() ? businessResults.FirstOrDefault() : new ClassSection();
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetClassSectionById - SqlException:{0}", ex.Message), ex);
                throw;
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetClassSectionById - Exception:{0}", ex.Message), ex);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public List<ClassSection> GetClassSectionsByClassId(int classId)
        {
            LogHelper.Info(string.Format("AdminRepository.GetAllClassSections - Begin"));
            return GetAllClassSections(classId, true);
        }

        /// <summary>
        /// To get all classe sections
        /// </summary>
        /// <param name="visibleOnly"></param>
        /// <returns></returns>
        public List<ClassSection> GetAllClassSections(bool isAll)
        {
            LogHelper.Info(string.Format("AdminRepository.GetAllClassSections - Begin"));
            return GetAllClassSections(0, isAll);
        }

        /// <summary>
        /// To get all classe sections
        /// </summary>
        /// <param name="visibleOnly"></param>
        /// <returns></returns>
        private List<ClassSection> GetAllClassSections(int classId, bool isAll)
        {
            LogHelper.Info(string.Format("AdminRepository.GetAllClassSections - Begin"));
            try
            {
                SqlConnection connection = SqlDataConnection.GetSqlConnection();
                var result = connection.Query<Models.ClassSection>(Procedures.GetAllClassSections, new { @ClassId = classId, @IsAll = isAll });
                var businessResults = Mapper.Map<IEnumerable<Models.ClassSection>, IEnumerable<ClassSection>>(result);
                return businessResults != null && businessResults.Any() ? businessResults.ToList() : new List<ClassSection>();
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetAllClassSections - SqlException:{0}", ex.Message), ex);
                throw;
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetAllClassSections - Exception:{0}", ex.Message), ex);
                throw;
            }
        }
        #endregion

        #region Roles
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public ApplicationRole GetRoleById(int roleId)
        {
            LogHelper.Info(string.Format("AdminRepository.GetRoleById - Begin"));
            try
            {
                SqlConnection connection = SqlDataConnection.GetSqlConnection();
                var result = connection.Query<Models.ApplicationRole>(Procedures.GetRoleById, new { @RoleId = roleId });
                var businessResults = Mapper.Map<IEnumerable<Models.ApplicationRole>, IEnumerable<ApplicationRole>>(result);
                return businessResults != null && businessResults.Any() ? businessResults.FirstOrDefault() : new ApplicationRole();
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetRoleById - SqlException:{0}", ex.Message), ex);
                throw;
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetRoleById - Exception:{0}", ex.Message), ex);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="visibleToLogin"></param>
        /// <returns></returns>
        public List<ApplicationRole> GetAllRoles(bool visibleToLogin)
        {
            LogHelper.Info(string.Format("AdminRepository.GetAllRoles - Begin"));
            try
            {
                SqlConnection connection = SqlDataConnection.GetSqlConnection();
                var result = connection.Query<Models.ApplicationRole>(Procedures.GetAllRoles, new { @VisibleToLogin = visibleToLogin });
                var businessResults = Mapper.Map<IEnumerable<Models.ApplicationRole>, IEnumerable<ApplicationRole>>(result);
                return businessResults != null && businessResults.Any() ? businessResults.ToList() : new List<ApplicationRole>();
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetAllSections - SqlException:{0}", ex.Message), ex);
                throw;
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetAllSections - Exception:{0}", ex.Message), ex);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public int? SaveApplicationRole(ApplicationRole role)
        {
            LogHelper.Info(string.Format("AdminRepository.SaveApplicationRole - Begin"));
            try
            {
                Models.ApplicationRole dRole = Mapper.Map<ApplicationRole, Models.ApplicationRole>(role);
                SqlConnection connection = SqlDataConnection.GetSqlConnection();
                var result = connection.Query<int>(Procedures.SaveApplicationRole, dRole);
                return result != null && result.Any() ? result.First() : (int?)null;
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("AdminRepository.SaveApplicationRole - SqlException:{0}", ex.Message), ex);
                throw;

            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminRepository.SaveApplicationRole - Exception:{0}", ex.Message), ex);
                throw;
            }
        }
        #endregion

        #region Roles&Privilege
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ApplicationPermission GetApplicationPermissionById(int id)
        {
            LogHelper.Info(string.Format("AdminRepository.GetApplicationPermissionById - Begin"));
            try
            {
                SqlConnection connection = SqlDataConnection.GetSqlConnection();
                var result = connection.Query<Models.ApplicationPermission>(Procedures.GetRoleById, new { @Id = id });
                var businessResults = Mapper.Map<IEnumerable<Models.ApplicationPermission>, IEnumerable<ApplicationPermission>>(result);
                return businessResults != null && businessResults.Any() ? businessResults.FirstOrDefault() : new ApplicationPermission();
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetApplicationPermissionById - SqlException:{0}", ex.Message), ex);
                throw;
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetApplicationPermissionById - Exception:{0}", ex.Message), ex);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<ApplicationPermission> GetApplicationPermissionByRoleId(int roleId)
        {
            LogHelper.Info(string.Format("AdminRepository.GetApplicationPermissionByRoleId - Begin"));
            try
            {
                SqlConnection connection = SqlDataConnection.GetSqlConnection();
                var result = connection.Query<Models.ApplicationPermission>(Procedures.GetRoleById, new { @Id = roleId });
                var businessResults = Mapper.Map<IEnumerable<Models.ApplicationPermission>, IEnumerable<ApplicationPermission>>(result);
                return businessResults != null && businessResults.Any() ? businessResults.ToList() : new List<ApplicationPermission>();
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetApplicationPermissionByRoleId - SqlException:{0}", ex.Message), ex);
                throw;
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetApplicationPermissionByRoleId - Exception:{0}", ex.Message), ex);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<RolePrivilege> GetRolePrivilegesByModuleId(int moduleId)
        {
            LogHelper.Info(string.Format("AdminRepository.GetRolePrivilegesByModuleId - Begin"));
            try
            {
                SqlConnection connection = SqlDataConnection.GetSqlConnection();
                var result = connection.Query<Models.RolePrivilege>(Procedures.GetRolePrivilegesByModuleId, new { @ModuleId = moduleId });
                var businessResults = Mapper.Map<IEnumerable<Models.RolePrivilege>, IEnumerable<RolePrivilege>>(result);
                return businessResults != null && businessResults.Any() ? businessResults.ToList() : new List<RolePrivilege>();
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetRolePrivilegesByModuleId - SqlException:{0}", ex.Message), ex);
                throw;
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetRolePrivilegesByModuleId - Exception:{0}", ex.Message), ex);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<RolePrivilege> GetAllApplicationPermission()
        {
            LogHelper.Info(string.Format("AdminRepository.GetAllApplicationPermission - Begin"));
            try
            {
                SqlConnection connection = SqlDataConnection.GetSqlConnection();
                var result = connection.Query<Models.RolePrivilege>(Procedures.GetRoleById);
                var businessResults = Mapper.Map<IEnumerable<Models.RolePrivilege>, IEnumerable<RolePrivilege>>(result);
                return businessResults != null && businessResults.Any() ? businessResults.ToList() : new List<RolePrivilege>();
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetAllApplicationPermission - SqlException:{0}", ex.Message), ex);
                throw;
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetAllApplicationPermission - Exception:{0}", ex.Message), ex);
                throw;
            }
        }

        public List<ApplicationModule> GetAllModules()
        {
            LogHelper.Info(string.Format("AdminRepository.GetAllModules - Begin"));
            try
            {
                SqlConnection connection = SqlDataConnection.GetSqlConnection();
                var result = connection.Query<Models.ApplicationModule>(Procedures.GetApplicationModules);
                var businessResults = Mapper.Map<IEnumerable<Models.ApplicationModule>, IEnumerable<ApplicationModule>>(result);
                return businessResults != null && businessResults.Any() ? businessResults.ToList() : new List<ApplicationModule>();
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetAllModules - SqlException:{0}", ex.Message), ex);
                throw;
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetAllModules - Exception:{0}", ex.Message), ex);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ApplicationPrivilege> GetApplicationPrivileges()
        {
            LogHelper.Info(string.Format("AdminRepository.GetApplicationPrivileges - Begin"));
            try
            {
                SqlConnection connection = SqlDataConnection.GetSqlConnection();
                var result = connection.Query<Models.ApplicationPrivilege>(Procedures.GetApplicationPrivileges);
                var businessResults = Mapper.Map<IEnumerable<Models.ApplicationPrivilege>, IEnumerable<ApplicationPrivilege>>(result);
                return businessResults != null && businessResults.Any() ? businessResults.ToList() : new List<ApplicationPrivilege>();
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetApplicationPrivileges - SqlException:{0}", ex.Message), ex);
                throw;
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetApplicationPrivileges - Exception:{0}", ex.Message), ex);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rolePrivileges"></param>
        public void SaveRolePrivileges(List<RolePrivilege> rolePrivileges)
        {
            LogHelper.Info(string.Format("AdminRepository.SaveRolePrivileges - Begin"));
            try
            {
                List<Models.RolePrivilege> dRolePrivileges = Mapper.Map<List<RolePrivilege>, List<Models.RolePrivilege>>(rolePrivileges);
                SqlConnection connection = SqlDataConnection.GetSqlConnection();
                var result = connection.Query<int>(Procedures.SaveRolePrivileges, dRolePrivileges);
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("AdminRepository.SaveRolePrivileges - SqlException:{0}", ex.Message), ex);
                throw;
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminRepository.SaveRolePrivileges - Exception:{0}", ex.Message), ex);
                throw;
            }
        }
        #endregion

        #region Years
        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public int? SaveAcademicYear(AcademicYear year)
        {
            LogHelper.Info(string.Format("AdminRepository.SaveAcademicYear - Begin"));
            try
            {
                Models.AcademicYear dYear = Mapper.Map<AcademicYear, Models.AcademicYear>(year);
                SqlConnection connection = SqlDataConnection.GetSqlConnection();
                var result = connection.Query<int>(Procedures.SaveAcademicYear, year);
                return result != null ? result.FirstOrDefault() : (int?)null;
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("AdminRepository.SaveAcademicYear - SqlException:{0}", ex.Message), ex);
                throw;
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminRepository.SaveAcademicYear - Exception:{0}", ex.Message), ex);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="academicYearId"></param>
        /// <returns></returns>
        public AcademicYear GetAcademicYearById(int academicYearId)
        {
            LogHelper.Info(string.Format("AdminRepository.GetApplicationPermissionById - Begin"));
            try
            {
                SqlConnection connection = SqlDataConnection.GetSqlConnection();
                var result = connection.Query<Models.AcademicYear>(Procedures.GetAcademicYearById, new { academicYearId });
                var businessResults = Mapper.Map<IEnumerable<Models.AcademicYear>, IEnumerable<AcademicYear>>(result);
                return businessResults != null && businessResults.Any() ? businessResults.FirstOrDefault() : new AcademicYear();
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetApplicationPermissionById - SqlException:{0}", ex.Message), ex);
                throw;
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetApplicationPermissionById - Exception:{0}", ex.Message), ex);
                throw;
            }
        }

        public AcademicYear GetActiveAcademicYear()
        {
            LogHelper.Info(string.Format("AdminRepository.GetApplicationPermissionById - Begin"));
            try
            {
                SqlConnection connection = SqlDataConnection.GetSqlConnection();
                var result = connection.Query<Models.AcademicYear>(Procedures.GetActiveAcademicYear);
                var businessResults = Mapper.Map<IEnumerable<Models.AcademicYear>, IEnumerable<AcademicYear>>(result);
                return businessResults != null && businessResults.Any() ? businessResults.FirstOrDefault() : new AcademicYear();
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetApplicationPermissionById - SqlException:{0}", ex.Message), ex);
                throw;
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetApplicationPermissionById - Exception:{0}", ex.Message), ex);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<AcademicYear> GetAcademicYears()
        {
            LogHelper.Info(string.Format("AdminRepository.GetAcademicYears - Begin"));
            try
            {
                SqlConnection connection = SqlDataConnection.GetSqlConnection();
                var result = connection.Query<Models.AcademicYear>(Procedures.GetAcademicYears);
                var businessResults = Mapper.Map<IEnumerable<Models.AcademicYear>, IEnumerable<AcademicYear>>(result);
                return businessResults != null && businessResults.Any() ? businessResults.ToList() : new List<AcademicYear>();
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetAcademicYears - SqlException:{0}", ex.Message), ex);
                throw;
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetAcademicYears - Exception:{0}", ex.Message), ex);
                throw;
            }
        }
        #endregion

        #region Community
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CommunityMaster> GetCommunities()
        {
            LogHelper.Info(string.Format("AdminRepository.GetCommunities - Begin"));
            try
            {
                SqlConnection connection = SqlDataConnection.GetSqlConnection();
                var result = connection.Query<Models.CommunityMaster>(Procedures.GetCommunities);
                var businessResults = Mapper.Map<IEnumerable<Models.CommunityMaster>, IEnumerable<CommunityMaster>>(result);
                return businessResults != null && businessResults.Any() ? businessResults.ToList() : new List<CommunityMaster>();
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetCommunities - SqlException:{0}", ex.Message), ex);
                throw;
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetCommunities - Exception:{0}", ex.Message), ex);
                throw;
            }
        }
        #endregion

        #region MotherLanguages
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<MotherLanguages> GetMotherLanguages()
        {
            LogHelper.Info(string.Format("AdminRepository.GetMotherLanguages - Begin"));
            try
            {
                SqlConnection connection = SqlDataConnection.GetSqlConnection();
                var result = connection.Query<Models.MotherLanguages>(Procedures.GetMotherLanguages);
                var businessResults = Mapper.Map<IEnumerable<Models.MotherLanguages>, IEnumerable<MotherLanguages>>(result);
                return businessResults != null && businessResults.Any() ? businessResults.ToList() : new List<MotherLanguages>();
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetMotherLanguages - SqlException:{0}", ex.Message), ex);
                throw;
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetMotherLanguages - Exception:{0}", ex.Message), ex);
                throw;
            }
        }
        #endregion

        #region Relationships
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<UserRelationship> GetRelationships()
        {
            LogHelper.Info(string.Format("AdminRepository.GetRelationships - Begin"));
            try
            {
                SqlConnection connection = SqlDataConnection.GetSqlConnection();
                var result = connection.Query<Models.UserRelationship>(Procedures.GetRelationships);
                var businessResults = Mapper.Map<IEnumerable<Models.UserRelationship>, IEnumerable<UserRelationship>>(result);
                return businessResults != null && businessResults.Any() ? businessResults.ToList() : new List<UserRelationship>();
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetRelationships - SqlException:{0}", ex.Message), ex);
                throw;
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("AdminRepository.GetRelationships - Exception:{0}", ex.Message), ex);
                throw;
            }
        }
        #endregion
    }
}
