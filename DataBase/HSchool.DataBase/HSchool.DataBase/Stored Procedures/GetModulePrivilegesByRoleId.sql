CREATE PROCEDURE [dbo].[GetModulePrivilegesByRoleId]
(
	@RoleId int
)
AS
BEGIN	
	SELECT [RolePrivilegeId],[RoleId],[ModuleId],[Privileges],[CreatedDate],[ModifiedDate] FROM [dbo].[RolePrivileges] WHERE RoleId=@RoleId
END
