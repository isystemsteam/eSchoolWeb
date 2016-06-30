CREATE PROCEDURE [dbo].[SaveCommunity]
	@CommunityId int output,
	@CommunityName varchar(20)
AS
	BEGIN TRY
		-- TO INSERT CLASSES
		IF NOT EXISTS(SELECT 1 FROM dbo.CommunityMaster WHERE CommunityId=@CommunityId)
			BEGIN
				INSERT INTO dbo.CommunityMaster (CommunityName) VALUES (@CommunityName)

				SET @CommunityId=@@IDENTITY
			END
		ELSE
			BEGIN
				UPDATE dbo.CommunityMaster SET  CommunityName=@CommunityName WHERE CommunityId=@CommunityId 
			END
	END TRY
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR (@ErrorMessage, @ErrorSeverity,@ErrorState) 
	END CATCH
RETURN @CommunityId
