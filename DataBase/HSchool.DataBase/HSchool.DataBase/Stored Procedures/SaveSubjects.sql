CREATE PROCEDURE [dbo].[SaveSubjects]
	@SubjectId int,
	@SubjectName varchar(250),
	@IsActive bit
AS
	BEGIN
		IF EXISTS(SELECT 1 FROM dbo.Subjects WHERE SubjectId=@SubjectId)
			BEGIN
				UPDATE dbo.Subjects SET SubjectName=@SubjectName WHERE SubjectId=@SubjectId
			END
		ELSE
			BEGIN
				INSERT INTO dbo.Subjects (SubjectName) values (@SubjectName)
				SET @SubjectId=@@IDENTITY
			END
		RETURN @SubjectId
	END

