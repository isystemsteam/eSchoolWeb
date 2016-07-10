CREATE TABLE [dbo].[RolePrivileges]
(
	[RolePrivilegeId] INT NOT NULL PRIMARY KEY identity, 
    [RoleId] INT NOT NULL foreign key references dbo.ApplicationRoles (RoleId), 
    [ModuleId] INT NOT NULL foreign key references dbo.ApplicationModules (ModuleId), 
    [Privileges] NVARCHAR(50) NOT NULL, 
    [CreatedDate] DATETIME NULL, 
    [ModifiedDate] DATETIME NULL
)
