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
SET IDENTITY_INSERT dbo.ApplicationStatus ON
INSERT INTO dbo.ApplicationStatus(ApplicationStatusId,ApplicationStatus) values (1,'Submitted')
INSERT INTO dbo.ApplicationStatus(ApplicationStatusId,ApplicationStatus) values (2,'Pending')
INSERT INTO dbo.ApplicationStatus(ApplicationStatusId,ApplicationStatus) values (3,'InProgress')
INSERT INTO dbo.ApplicationStatus(ApplicationStatusId,ApplicationStatus) values (4,'Rejected')
INSERT INTO dbo.ApplicationStatus(ApplicationStatusId,ApplicationStatus) values (5,'Approved')
SET IDENTITY_INSERT dbo.ApplicationStatus OFF


  
