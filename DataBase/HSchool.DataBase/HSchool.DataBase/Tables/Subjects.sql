CREATE TABLE [dbo].[Subjects]
(
	[SubjectId] INT NOT NULL PRIMARY KEY identity,
	[SubjectName] varchar(250) not null,
	[IsActive] bit
)
