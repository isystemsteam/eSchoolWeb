CREATE PROCEDURE [dbo].[SaveClassSections]
(
	@TableClassSection TypeClassSections Readonly
)
AS
BEGIN
	DECLARE @ClassSectionId AS INT;
	DECLARE @ClassId AS INT;
	DECLARE @SectionId AS INT;
	DECLARE @IsActive AS BIT;
	DECLARE @TempRowNum AS INT =1;
	DECLARE @TotalRowCount AS INT;

	BEGIN TRY
		BEGIN TRANSACTION H_CLASSSECTIONINSERTUPDATE
		SELECT @TotalRowCount=COUNT(1) FROM @TableClassSection
		WHILE (@TempRowNum <= @TotalRowCount)
			BEGIN
				--
				SELECT @ClassId=ClassId,@SectionId=SectionId,@IsActive=IsActive FROM @TableClassSection WHERE RowNumber=@TempRowNum

				-- TO INSERT UPDATE CLASSES & SECTIONS
				IF NOT EXISTS(SELECT 1 FROM dbo.ClassSections WHERE ClassId=@ClassId AND SectionId=@SectionId)
					BEGIN
						INSERT INTO dbo.ClassSections (ClassId,SectionId,IsActive,IsDeleted) VALUES (@ClassId,@SectionId,@IsActive,0)						
					END
				ELSE					
					BEGIN
						UPDATE dbo.ClassSections SET  IsActive=@IsActive WHERE ClassId=@ClassId AND SectionId=@SectionId
					END
				-- TO INCREASE COUNTER
				SET @TempRowNum=@TempRowNum+1;
			END		
		COMMIT TRANSACTION H_CLASSSECTIONINSERTUPDATE
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION H_CLASSSECTIONINSERTUPDATE
		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR (@ErrorMessage, @ErrorSeverity,@ErrorState) 
	END CATCH
	
END