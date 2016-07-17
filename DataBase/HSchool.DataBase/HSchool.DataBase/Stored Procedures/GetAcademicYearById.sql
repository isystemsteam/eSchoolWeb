CREATE PROCEDURE [dbo].[GetAcademicYearById]	
(
	@AcademicYearId int
)
AS
BEGIN
	SELECT StartDate,EndDate,IsActive,AcademicYearId FROM dbo.AcademicYears where AcademicYearId=@AcademicYearId
END
