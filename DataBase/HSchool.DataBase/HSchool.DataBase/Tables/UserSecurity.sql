CREATE TABLE [dbo].[UserSecurity]
(
	[UserId] int foreign key references dbo.UserAccounts (UserId) NOT NULL,
	[SecurityKey] nvarchar(255),
	[Password] nvarchar(255),
	[GuardianPassword] nvarchar(255),
	[PasswordFormat] varchar(12),
	[PasswordQuestion] int,
	[PasswordAnswer] varchar(20), 
    [LoggedInTryCount] INT NULL, 
	[GuardianLoggedInTryCount] INT NULL,
    [UserLastLogin] DATETIME NULL, 
    [GuardianLastLogin] DATETIME NULL, 
    CONSTRAINT [PK_UserSecurity] PRIMARY KEY ([UserId])	
)
