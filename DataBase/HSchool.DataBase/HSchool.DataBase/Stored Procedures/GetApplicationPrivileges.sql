CREATE PROCEDURE [dbo].[GetApplicationPrivileges]
AS
BEGIN
	SELECT [PrivilegeId]
      ,[PrivilegeName]
  FROM [dbo].[ApplicationPrivilege]
END
