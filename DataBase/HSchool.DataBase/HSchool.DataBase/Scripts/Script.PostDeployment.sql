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
GO
SET IDENTITY_INSERT dbo.ApplicationModules ON
INSERT INTO dbo.ApplicationModules(ModuleId,ModuleName) values (1,'Admin');
INSERT INTO dbo.ApplicationModules(ModuleId,ModuleName) values (2,'Admin Settings');
INSERT INTO dbo.ApplicationModules(ModuleId,ModuleName) values (3,'School Settings');
INSERT INTO dbo.ApplicationModules(ModuleId,ModuleName) values (4,'Applications');
INSERT INTO dbo.ApplicationModules(ModuleId,ModuleName) values (5,'Mark Management');
SET IDENTITY_INSERT dbo.ApplicationModules OFF
GO
SET IDENTITY_INSERT dbo.ApplicationStatus ON
INSERT INTO dbo.ApplicationStatus(ApplicationStatusId,ApplicationStatus) values (1,'Submitted')
INSERT INTO dbo.ApplicationStatus(ApplicationStatusId,ApplicationStatus) values (2,'Pending')
INSERT INTO dbo.ApplicationStatus(ApplicationStatusId,ApplicationStatus) values (3,'InProgress')
INSERT INTO dbo.ApplicationStatus(ApplicationStatusId,ApplicationStatus) values (4,'Rejected')
INSERT INTO dbo.ApplicationStatus(ApplicationStatusId,ApplicationStatus) values (5,'Approved')
SET IDENTITY_INSERT dbo.ApplicationStatus OFF
GO
SET IDENTITY_INSERT dbo.CommunityMaster ON;
INSERT INTO dbo.CommunityMaster(CommunityId,CommunityName) values (1,'OC');
INSERT INTO dbo.CommunityMaster(CommunityId,CommunityName) values (2,'BC');
INSERT INTO dbo.CommunityMaster(CommunityId,CommunityName) values (3,'MBC');
INSERT INTO dbo.CommunityMaster(CommunityId,CommunityName) values (4,'SC');
INSERT INTO dbo.CommunityMaster(CommunityId,CommunityName) values (5,'ST');
INSERT INTO dbo.CommunityMaster(CommunityId,CommunityName) values (6,'Others');
SET IDENTITY_INSERT dbo.CommunityMaster OFF
GO
SET IDENTITY_INSERT dbo.MotherLanguages ON
insert into dbo.MotherLanguages (LanguageId,Name) values (1,'Tamil');
insert into dbo.MotherLanguages (LanguageId,Name) values (2,'English');
insert into dbo.MotherLanguages (LanguageId,Name) values (3,'Hindhi');
SET IDENTITY_INSERT dbo.MotherLanguages OFF
GO
insert into dbo.UserStatus (UserStatus) values ('Registered');
insert into dbo.UserStatus (UserStatus) values ('Active');
insert into dbo.UserStatus (UserStatus) values ('InActive');
insert into dbo.UserStatus (UserStatus) values ('InActiveByAdmin');
insert into dbo.UserStatus (UserStatus) values ('InActiveByTeacher');
insert into dbo.UserStatus (UserStatus) values ('InActiveByGovernment');
insert into dbo.UserStatus (UserStatus) values ('Invited');
insert into dbo.UserStatus (UserStatus) values ('Suspended');
insert into dbo.UserStatus (UserStatus) values ('Deferred')
GO
SET IDENTITY_INSERT dbo.ApplicationPrivilege ON
INSERT INTO dbo.ApplicationPrivilege(PrivilegeId,PrivilegeName) values (1,'All')
INSERT INTO dbo.ApplicationPrivilege(PrivilegeId,PrivilegeName) values (2,'Create')
INSERT INTO dbo.ApplicationPrivilege(PrivilegeId,PrivilegeName) values (3,'Edit')
INSERT INTO dbo.ApplicationPrivilege(PrivilegeId,PrivilegeName) values (4,'View')
INSERT INTO dbo.ApplicationPrivilege(PrivilegeId,PrivilegeName) values (5,'Delete')
INSERT INTO dbo.ApplicationPrivilege(PrivilegeId,PrivilegeName) values (6,'Approval')
SET IDENTITY_INSERT dbo.ApplicationPrivilege OFF
GO
SET IDENTITY_INSERT dbo.UserRelationship ON
INSERT INTO dbo.UserRelationship(RelationshipId,Name,IsActive) values (1,'Father',1)
INSERT INTO dbo.UserRelationship(RelationshipId,Name,IsActive) values (2,'Mother',1)
INSERT INTO dbo.UserRelationship(RelationshipId,Name,IsActive) values (3,'Guardian',1)
INSERT INTO dbo.UserRelationship(RelationshipId,Name,IsActive) values (4,'Brother',1)
INSERT INTO dbo.UserRelationship(RelationshipId,Name,IsActive) values (5,'Sister',1)
INSERT INTO dbo.UserRelationship(RelationshipId,Name,IsActive) values (6,'Others',1)
SET IDENTITY_INSERT dbo.UserRelationship OFF
GO
SET IDENTITY_INSERT dbo.UserTitles ON
INSERT INTO dbo.UserTitles(UserTitleId,UserTitleName) values (1,'Mr')
INSERT INTO dbo.UserTitles(UserTitleId,UserTitleName) values (2,'Miss')
INSERT INTO dbo.UserTitles(UserTitleId,UserTitleName) values (3,'Mrs')
SET IDENTITY_INSERT dbo.UserTitles OFF
GO


