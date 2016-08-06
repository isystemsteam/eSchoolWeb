CREATE PROCEDURE [dbo].[GetSubjects]	
AS
	BEGIN
		SELECT SubjectId,SubjectName FROM dbo.Subjects
	END

