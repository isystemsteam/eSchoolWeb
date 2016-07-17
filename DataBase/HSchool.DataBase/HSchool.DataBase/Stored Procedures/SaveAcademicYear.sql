CREATE PROCEDURE [dbo].[SaveAcademicYear]
	@AcademicYearId int = 0,
	@StartDate datetime,
	@EndDate datetime,
	@IsActive bit
AS
BEGIN
	BEGIN TRY
	IF EXISTS(SELECT 1 FROM dbo.AcademicYears where AcademicYearId=@AcademicYearId)
		BEGIN
			update dbo.AcademicYears set StartDate=@StartDate,EndDate=@EndDate,IsActive=@IsActive where AcademicYearId=@AcademicYearId
		END
	ELSE
		BEGIN
			INSERT INTO dbo.AcademicYears (StartDate,EndDate,IsActive) values (@StartDate,@EndDate,@IsActive)
		END
	END TRY
	BEGIN CATCH
			DECLARE @ErrorMessage NVARCHAR(4000);
			DECLARE @ErrorSeverity INT;
			DECLARE @ErrorState INT;

			SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
			RAISERROR (@ErrorMessage, @ErrorSeverity,@ErrorState)
	END CATCH
END

