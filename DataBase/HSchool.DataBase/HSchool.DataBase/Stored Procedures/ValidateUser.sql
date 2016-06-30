CREATE PROCEDURE [dbo].[ValidateUser]
	@UserName varchar(255)
AS
	BEGIN TRY
	
		IF (@UserName IS NOT NULL)
			BEGIN
				SELECT 
					US.SecurityKey,
					US.Password,
					US.GuardianPassword,
					US.PasswordFormat
				FROM dbo.UserSecurity US INNER JOIN dbo.UserAccounts UA ON US.UserId=UA.UserId WHERE UA.UserName= @UserName
			END
		ELSE 
			BEGIN
				SELECT 
					US.SecurityKey,
					US.Password,
					US.GuardianPassword,
					US.PasswordFormat
				FROM dbo.UserSecurity US INNER JOIN dbo.UserAccounts UA ON US.UserId=UA.UserId WHERE UA.UserName= @UserName
			END
			
	END TRY
	BEGIN CATCH
	
		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState)
	
	END CATCH

