CREATE TABLE [dbo].[ApplicationRoles]
(
	[RoleId] INT NOT NULL PRIMARY KEY identity,
	RoleName varchar(50),
	IsActive bit,
	VisibleToLogin bit,
	CreatedDate datetime,
	ModifiedDate datetime
)
