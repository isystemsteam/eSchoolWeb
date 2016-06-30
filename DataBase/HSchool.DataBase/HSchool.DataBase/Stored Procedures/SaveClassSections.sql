CREATE PROCEDURE [dbo].[SaveClassSections]
	@ClassSectionId int output,
	@ClassId int,
	@SectionId int,
	@IsActive bit,
	@IsDeleted bit
AS
BEGIN

	BEGIN TRY
		-- TO INSERT CLASSES
		IF NOT EXISTS(SELECT 1 FROM dbo.ClassSections WHERE ClassSectionId=@ClassSectionId)
			BEGIN
				INSERT INTO dbo.ClassSections (ClassId,SectionId,IsActive,IsDeleted) VALUES (@ClassId,@SectionId,@IsActive,@IsDeleted)

				SET @ClassSectionId=@@IDENTITY
			END
		ELSE
			BEGIN
				UPDATE dbo.ClassSections SET  ClassId=@ClassId,SectionId=@SectionId,IsActive=@IsActive,IsDeleted=@IsDeleted WHERE ClassSectionId=@ClassSectionId 
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