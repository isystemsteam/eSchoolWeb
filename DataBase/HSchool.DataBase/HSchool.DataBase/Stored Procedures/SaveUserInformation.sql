CREATE PROCEDURE [dbo].[SaveUserInformation]
(
	@UserId int OUTPUT,
	@Title varchar(10),
	@FirstName varchar(120),
	@LastName varchar(120),
	@Email varchar(255),
	@Gender varchar(10),	
	@DateOfBirth datetime,
	@PlaceOfBirth varchar(120),
	@BloodGroup varchar(12),
	@Religion varchar(50),
	@Nationality varchar(50),
	@Community int,
	@MobileNumber varchar(20),
	@UserStatus int,
	@MotherLanguage int,
	@IsVerified bit,
	@IsLocked bit,
	@SMSEnabled bit,
	@EmailEnabled bit,
	@NotificationEnabled bit	
)
AS
BEGIN
	
	BEGIN TRY	

	IF NOT EXISTS(SELECT 1 FROM dbo.UserAccounts WHERE UserId=@UserId)
		BEGIN
			INSERT INTO dbo.UserAccounts(
				Title
				,FirstName
				,LastName
				,Email
				,Gender				
				,DateOfBirth
				,PlaceOfBirth
				,BloodGroup
				,Religion
				,Nationality
				,Community
				,MobileNumber
				,UserStatus
				,MotherLanguage
				,IsVerified
				,IsLocked
				,SMSEnabled
				,EmailEnabled
				,NotificationEnabled
				,CreatedDate
				,ModifiedDate) 
			VALUES 
					(
					@Title,
					@FirstName
					,@LastName
					,@Email
					,@Gender					
					,@DateOfBirth
					,@PlaceOfBirth
					,@BloodGroup
					,@Religion
					,@Nationality
					,@Community
					,@MobileNumber
					,@UserStatus
					,@MotherLanguage
					,@IsVerified
					,@IsLocked
					,@SMSEnabled
					,@EmailEnabled
					,@NotificationEnabled
					,GETDATE()
					,GETDATE())
			SET @UserId=@@IDENTITY
		END
	ELSE
		BEGIN
			UPDATE dbo.UserAccounts SET
				Title=@Title,
				FirstName=@FirstName,
				LastName=@LastName,
				Email=@Email,
				Gender=@Gender,				
				DateOfBirth=@DateOfBirth,
				PlaceOfBirth=@PlaceOfBirth,
				BloodGroup=@BloodGroup,
				Religion=@Religion,
				Nationality=@Nationality,
				Community=@Community,
				MobileNumber=@MobileNumber,				
				UserStatus=@UserStatus,
				SMSEnabled=@SMSEnabled,
				IsVerified=@IsVerified,
				IsLocked=@IsLocked,
				EmailEnabled=@EmailEnabled,
				NotificationEnabled=@NotificationEnabled,
				ModifiedDate=GETDATE()
			WHERE UserId =@UserId
		END
		--https://msdn.microsoft.com/en-us/library/bb675163(v=vs.110).aspx	
		
	END TRY
	BEGIN CATCH 
		
		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState)
	END CATCH
END
	
RETURN @UserId
