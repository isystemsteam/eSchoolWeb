CREATE TABLE [dbo].[Student]
(
	[StudentId] INT NOT NULL PRIMARY KEY identity,
	[StudentRollNumber] varchar(20) null,
	[UserId] int not null foreign key references dbo.UserAccounts(UserId),	
	IsTransportRequired bit not null,
	FluencyinOthers VARCHAR(120),
	[VisibleMark] bit
)
