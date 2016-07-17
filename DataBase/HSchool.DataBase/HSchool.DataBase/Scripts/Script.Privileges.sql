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
SET IDENTITY_INSERT dbo.ApplicationPrivilege ON;  
GO  
INSERT INTO dbo.ApplicationPrivilege(PrivilegeId,PrivilegeName) values (1,'All')
INSERT INTO dbo.ApplicationPrivilege(PrivilegeId,PrivilegeName) values (2,'Create')
INSERT INTO dbo.ApplicationPrivilege(PrivilegeId,PrivilegeName) values (3,'Edit')
INSERT INTO dbo.ApplicationPrivilege(PrivilegeId,PrivilegeName) values (4,'View')
INSERT INTO dbo.ApplicationPrivilege(PrivilegeId,PrivilegeName) values (5,'Delete')
INSERT INTO dbo.ApplicationPrivilege(PrivilegeId,PrivilegeName) values (6,'Approval')
GO
SET IDENTITY_INSERT dbo.ApplicationPrivilege OFF;  