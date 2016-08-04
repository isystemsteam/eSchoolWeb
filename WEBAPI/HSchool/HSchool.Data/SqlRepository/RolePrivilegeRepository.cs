using AutoMapper;
using HSchool.Business.Repository;
using HSchool.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Database;

using RolePrivilege = HSchool.Business.Models.RolePrivilege;

namespace HSchool.Data.SqlRepository
{
    public class RolePrivilegeRepository : IRolePrivilegeRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<RolePrivilege> GetModulePrivilegesByRoleId(int roleId)
        {
            LogHelper.Info(string.Format("RolePrivilegeRepository.GetRolePrivilegesByModuleId - Begin"));
            try
            {
                SqlConnection connection = SqlDataConnection.GetSqlConnection();
                var result = connection.Query<Models.RolePrivilege>(Procedures.GetModulePrivilegesByRoleId, new { @RoleId = roleId });
                var businessResults = Mapper.Map<IEnumerable<Models.RolePrivilege>, IEnumerable<RolePrivilege>>(result);
                return businessResults != null && businessResults.Any() ? businessResults.ToList() : new List<RolePrivilege>();
            }
            catch (SqlException ex)
            {
                LogHelper.Error(string.Format("RolePrivilegeRepository.GetRolePrivilegesByModuleId - SqlException:{0}", ex.Message), ex);
                throw;
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("RolePrivilegeRepository.GetRolePrivilegesByModuleId - Exception:{0}", ex.Message), ex);
                throw;
            }
        }
    }
}
