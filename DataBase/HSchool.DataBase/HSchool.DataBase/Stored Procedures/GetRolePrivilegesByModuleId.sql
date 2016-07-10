CREATE PROCEDURE [dbo].[GetRolePrivilegesByModuleId]
(
	@ModuleId int
)
AS
BEGIN	
	SELECT [RolePrivilegeId],[RoleId],[ModuleId],[Privileges],[CreatedDate],[ModifiedDate] FROM [dbo].[RolePrivileges] WHERE ModuleId=@ModuleId
END

