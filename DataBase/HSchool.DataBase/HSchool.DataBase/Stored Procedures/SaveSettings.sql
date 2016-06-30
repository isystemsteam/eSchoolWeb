CREATE PROCEDURE [dbo].[SaveSettings]	
	@SettingKey varchar(60),
	@Value varchar(120),
	@ApplicationName varchar(120),
	@IsActive bit,
	@IsValueEncrypted bit
AS
	BEGIN TRY
		-- TO INSERT CLASSES
		IF NOT EXISTS(SELECT 1 FROM dbo.Settings WHERE SettingKey=@SettingKey)
			BEGIN
				INSERT INTO dbo.Settings (SettingKey,Value,ApplicationName,IsActive,IsValueEncrypted) VALUES (@SettingKey,@Value,@ApplicationName,@IsActive,@IsValueEncrypted)
				
			END
		ELSE
			BEGIN
				UPDATE dbo.Settings SET 
					Value=@Value,
					ApplicationName=@ApplicationName,
					IsActive=@IsActive,
					IsValueEncrypted=@IsValueEncrypted
				WHERE SettingKey=@SettingKey 
			END
	END TRY
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR (@ErrorMessage, @ErrorSeverity,@ErrorState) 
	END CATCH
RETURN 0
