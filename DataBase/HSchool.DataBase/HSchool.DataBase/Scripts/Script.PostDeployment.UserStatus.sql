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
insert into dbo.UserStatus (UserStatus) values ('Active');
insert into dbo.UserStatus (UserStatus) values ('InActive');
insert into dbo.UserStatus (UserStatus) values ('InActiveByAdmin');
insert into dbo.UserStatus (UserStatus) values ('InActiveByTeacher');
insert into dbo.UserStatus (UserStatus) values ('InActiveByGovernment');
insert into dbo.UserStatus (UserStatus) values ('Invited');
insert into dbo.UserStatus (UserStatus) values ('Suspended');
insert into dbo.UserStatus (UserStatus) values ('Deferred')

