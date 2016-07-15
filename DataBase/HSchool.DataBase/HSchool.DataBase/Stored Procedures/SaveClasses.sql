CREATE PROCEDURE [dbo].[SaveClasses]
	@ClassId int output,
	@ClassName varchar(20),
	@NameInDigit varchar(50)
AS
BEGIN

	BEGIN TRY
		-- TO INSERT CLASSES
		IF NOT EXISTS(SELECT 1 FROM dbo.Classes WHERE ClassId=@ClassId)
			BEGIN
				INSERT INTO dbo.Classes (ClassName,NameInDigit) VALUES (@ClassName,@NameInDigit)

				SET @ClassId=@@IDENTITY
			END
		ELSE
			BEGIN
				UPDATE dbo.Classes SET  ClassName=@ClassName,NameInDigit=@NameInDigit WHERE ClassId=@ClassId 
			END
	END TRY
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR (@ErrorMessage, @ErrorSeverity,@ErrorState) 
	END CATCH
RETURN @ClassId	
END

