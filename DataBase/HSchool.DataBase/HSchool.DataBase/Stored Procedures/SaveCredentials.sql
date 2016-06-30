CREATE PROCEDURE [dbo].[SaveCredentials]
	@UserId int,
	@SecurityKey varchar,
	@Password varchar(255),
	@GuardianPassword varchar(255),
	@PasswordFormat varchar(12),
	@PasswordQuestion int,
	@PasswordAnswer varchar(20)
AS
BEGIN
	BEGIN TRY
		OPEN SYMMETRIC KEY 	HSCHOOLSYMKEY DECRYPTION BY CERTIFICATE HSCHOOLCERT

		IF NOT EXISTS(SELECT 1 FROM dbo.UserSecurity WHERE UserId=@UserId)
			BEGIN
				INSERT INTO dbo.UserSecurity (UserId,
					SecurityKey,
					[Password],
					GuardianPassword,
					PasswordFormat,
					PasswordQuestion,
					PasswordAnswer) 
					VALUES 
					(@UserId,
						ENCRYPTBYKEY(KEY_GUID('HSCHOOLSYMKEY'),@SecurityKey),
						ENCRYPTBYKEY(KEY_GUID('HSCHOOLSYMKEY'),@Password),
						ENCRYPTBYKEY(KEY_GUID('HSCHOOLSYMKEY'),@GuardianPassword),
						ENCRYPTBYKEY(KEY_GUID('HSCHOOLSYMKEY'),@PasswordFormat),
						@PasswordQuestion,
						@PasswordAnswer)
			END
		ELSE
			BEGIN
				UPDATE dbo.UserSecurity SET 
					SecurityKey=ENCRYPTBYKEY(KEY_GUID('HSCHOOLSYMKEY'),@SecurityKey),
					[Password]=ENCRYPTBYKEY(KEY_GUID('HSCHOOLSYMKEY'),@Password),
					GuardianPassword=ENCRYPTBYKEY(KEY_GUID('HSCHOOLSYMKEY'),@GuardianPassword),
					PasswordFormat=ENCRYPTBYKEY(KEY_GUID('HSCHOOLSYMKEY'),@PasswordFormat),
					PasswordQuestion=@PasswordQuestion,
					PasswordAnswer=@PasswordAnswer
				WHERE UserId=@UserId
			END
		CLOSE SYMMETRIC KEY HSCHOOLSYMKEY
	END TRY
	BEGIN CATCH
	END CATCH
END
RETURN 0
