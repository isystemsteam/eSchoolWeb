CREATE TABLE [dbo].[Applications]
(
	[ApplicationId] INT NOT NULL PRIMARY KEY identity,
	[UserId] int foreign key references dbo.UserAccounts (UserId),
	[ApplicationStatus] int foreign key references dbo.ApplicationStatus (ApplicationStatusId),
	[AppliedDate] datetime,
	[ApprovedDate] datetime,
	[ApplicationType] datetime,
	[ApprovedBy] INT foreign key references dbo.UserAccounts (UserId),
	IsVerified bit,
	[CreatedDate] datetime,
	[ModifiedDate] datetime,
	[IsDeleted] bit,
)
