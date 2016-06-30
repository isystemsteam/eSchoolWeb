CREATE TABLE [dbo].[PasswordQuestions]
(
	[QuestionId] INT NOT NULL PRIMARY KEY identity,
	[Question] varchar(500),
	IsActive bit
)
