CREATE PROCEDURE [dbo].[GetAcademicYears]	
AS
BEGIN
	SELECT StartDate,EndDate,IsActive,AcademicYearId FROM dbo.AcademicYears
END
