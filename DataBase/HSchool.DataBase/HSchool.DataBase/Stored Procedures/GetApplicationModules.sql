CREATE PROCEDURE [dbo].[GetApplicationModules]	
AS
BEGIN
	SELECT [ModuleId],[ModuleName] FROM [dbo].[ApplicationModules]
END

