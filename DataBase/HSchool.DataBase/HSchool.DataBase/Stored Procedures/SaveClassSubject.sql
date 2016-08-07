CREATE PROCEDURE [dbo].[SaveClassSubject]
(
	@ClassSubjectId INT,
	@ClassId int,
	@SectionId int,
	@SubjectId nvarchar(255),
	@AcademicYear int
)
AS
	BEGIN
		IF EXISTS(SELECT 1 FROM dbo.ClassSubject WHERE ClassId=@ClassId AND SubjectId=@SubjectId AND AcademicYear=@AcademicYear)
			BEGIN
				UPDATE dbo.ClassSubject SET 					
					SectionId=@SectionId					
					 WHERE ClassId=@ClassId AND SubjectId=@SubjectId AND AcademicYear=@AcademicYear
			END
		ELSE
			BEGIN
				INSERT INTO dbo.ClassSubject (ClassId,SectionId,SubjectId,AcademicYear,CreatedDate) 
					VALUES 
						(@ClassId,@SectionId,@SubjectId,@AcademicYear,GETDATE())
					SET @ClassSubjectId=@@IDENTITY
			END
			RETURN @ClassSubjectId
	END

