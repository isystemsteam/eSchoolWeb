CREATE PROCEDURE [dbo].[SaveStudentClass]
(
	@StudentClassId INT,
	@StudentId int,
	@ClassId int,
	@SectionId int,
	@AcademicYear int,
	@IsActive bit
)
AS
	BEGIN

		IF EXISTS(SELECT 1 FROM dbo.StudentClass WHERE ClassId!=ClassId AND SectionId!=SectionId AND AcademicYear!=AcademicYear)
			BEGIN
				UPDATE dbo.StudentClass 
						SET IsActive=@IsActive FROM 
							dbo.StudentClass WHERE ClassId!=ClassId AND SectionId!=SectionId AND AcademicYear!=AcademicYear
			END
		ELSE
			BEGIN
				INSERT INTO dbo.StudentClass 
					(
						StudentId,
						ClassId,
						SectionId,
						AcademicYear,
						IsActive
					)
					VALUES (@StudentId,@ClassId,@SectionId,@AcademicYear,@IsActive)	
			END	
	END
