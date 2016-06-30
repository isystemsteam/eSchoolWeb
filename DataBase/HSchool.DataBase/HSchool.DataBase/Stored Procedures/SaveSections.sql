CREATE PROCEDURE [dbo].[SaveSections]
	@SectionId int output,
	@SectionName varchar(20)
	
AS
BEGIN

	BEGIN TRY
		-- TO INSERT CLASSES
		IF NOT EXISTS(SELECT 1 FROM dbo.Sections WHERE SectionId=@SectionId)
			BEGIN
				INSERT INTO dbo.Sections (SectionName) VALUES (@SectionName)

				SET @SectionId=@@IDENTITY
			END
		ELSE
			BEGIN
				UPDATE dbo.Sections SET  SectionName=@SectionName WHERE SectionId=@SectionId 
			END
	END TRY
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR (@ErrorMessage, @ErrorSeverity,@ErrorState) 
	END CATCH
RETURN @SectionId	
END

