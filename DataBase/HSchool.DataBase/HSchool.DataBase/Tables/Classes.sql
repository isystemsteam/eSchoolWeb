CREATE TABLE [dbo].[Classes]
(
	[ClassId] INT NOT NULL PRIMARY KEY identity,
	[ClassName] varchar(20),
	[NameInDigit] int,
	[IsVisibleToApplication] bit
)
