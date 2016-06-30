CREATE PROCEDURE [dbo].[GetAllRoles]
	@visibleToLogin bit = 0	
AS
BEGIN
	IF(@visibleToLogin=1)
		BEGIN
			SELECT RoleId,RoleName,IsActive,VisibleToLogin,CreatedDate,ModifiedDate 
				FROM dbo.ApplicationRoles WHERE VisibleToLogin=1
		END
	ELSE
		BEGIN
			SELECT RoleId,RoleName,IsActive,VisibleToLogin,CreatedDate,ModifiedDate 
				FROM dbo.ApplicationRoles
		END
END
	