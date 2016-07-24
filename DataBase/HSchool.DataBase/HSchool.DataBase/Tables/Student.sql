CREATE TABLE [dbo].[Student]
(
	[StudentId] INT NOT NULL PRIMARY KEY identity,
	[RollNumber] varchar(20) NOT null,
	[UserId] int not null foreign key references dbo.UserAccounts(UserId),	
	IsTransportRequired bit not null,
	FluencyinOthers VARCHAR(120),
	[VisibleMark] bit, 
    [LoginEnabled] BIT NOT NULL, 
    [GuardianLoginEnabled] BIT NOT NULL
)
