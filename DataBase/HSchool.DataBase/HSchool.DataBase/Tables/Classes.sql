CREATE TABLE [dbo].[Classes]
(
	[ClassId] INT NOT NULL PRIMARY KEY identity,
	[ClassName] varchar(20),
	[NameInLetter] varchar(50),
	[IsVisibleToApplication] bit
)
