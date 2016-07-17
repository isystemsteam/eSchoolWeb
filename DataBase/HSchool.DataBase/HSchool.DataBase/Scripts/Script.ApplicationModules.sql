/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
SET IDENTITY_INSERT dbo.ApplicationModules ON;  
GO  
INSERT INTO dbo.ApplicationModules(ModuleId,ModuleName) values (1,'Admin')
INSERT INTO dbo.ApplicationModules(ModuleId,ModuleName) values (2,'Admin Settings')
INSERT INTO dbo.ApplicationModules(ModuleId,ModuleName) values (3,'School Settings')
INSERT INTO dbo.ApplicationModules(ModuleId,ModuleName) values (4,'Applications')
INSERT INTO dbo.ApplicationModules(ModuleId,ModuleName) values (5,'Mark Management')
GO
SET IDENTITY_INSERT dbo.ApplicationModules OFF;  