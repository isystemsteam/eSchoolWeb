CREATE PROCEDURE [dbo].[GetRoleById]
	@RoleId int = 0	
AS
BEGIN
	SELECT RoleId,RoleName,IsActive,CreatedDate,ModifiedDate from dbo.ApplicationRoles where RoleId=@RoleId
END
	

