CREATE PROCEDURE [dbo].[GetActiveAcademicYear]	
AS
BEGIN
	SELECT StartDate,EndDate,IsActive,AcademicYearId FROM dbo.AcademicYears where IsActive=1	
END
	

