CREATE PROCEDURE [dbo].[SaveUserInformation]
	@UserId int OUTPUT,
	@Title varchar(10),
	@FirstName varchar(120),
	@LastName varchar(120),
	@Email varchar(255),
	@Gender varchar(15),
	@Age int,
	@DateOfBirth datetime,
	@BloodGroup varchar(12),
	@Religion varchar(50),
	@Nationality varchar(50),
	@Community int,
	@MobileNumber varchar(20),
	@UserStatus int,
	@IsVerified bit,
	@IsLocked bit,
	@SMSEnabled bit,
	@EmailEnabled bit,
	@NotificationEnabled bit,
	@IsDeleted bit,
	@SecurityKey varchar(100),
	@Password varchar(255),
	@GuardianPassword varchar(255),
	@PasswordFormat varchar(12),
	@PasswordQuestion int,
	@PasswordAnswer varchar(20),
	@IsPasswordInsert bit,
	@UserGuardians TypeUserGuardian READONLY
AS
BEGIN
	BEGIN TRY
	BEGIN TRANSACTION INSERTUSER

	-- to type
	DECLARE @ROWSCOUNT INT
	DECLARE @LOOP INT


	IF NOT EXISTS(SELECT 1 FROM dbo.UserAccounts WHERE UserId=@UserId)
		BEGIN
			INSERT INTO dbo.UserAccounts(
				FirstName
				,LastName
				,Email
				,Gender
				,Age
				,DateOfBirth
				,BloodGroup
				,Religion
				,Nationality
				,Community
				,MobileNumber
				,UserStatus
				,IsVerified
				,IsLocked
				,SMSEnabled
				,EmailEnabled
				,NotificationEnabled
				,CreatedDate
				,ModifiedDate) 
			VALUES 
					(@FirstName
					,@LastName
					,@Email
					,@Gender
					,@Age
					,@DateOfBirth
					,@BloodGroup
					,@Religion
					,@Nationality
					,@Community
					,@MobileNumber
					,@UserStatus
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
				FirstName=@FirstName,
				LastName=@LastName,
				Email=@Email,
				Gender=@Gender,
				Age=@Age,
				DateOfBirth=@DateOfBirth,
				BloodGroup=@BloodGroup,
				Religion=@Religion,
				Nationality=@Nationality,
				Community=@Community,
				MobileNumber=@MobileNumber,				
				UserStatus=@UserStatus,
				ModifiedDate=GETDATE()
			WHERE UserId =@UserId
		END
		--https://msdn.microsoft.com/en-us/library/bb675163(v=vs.110).aspx

		-- to update

		UPDATE dbo.UserGuardians SET 
			UserId=@UserId, 
			Title=UG.Title,
			FirstName=UG.FirstName,
			LastName=UG.LastName,
			Gender=UG.Gender,
			Email=UG.Email,
			ReleationShip=UG.ReleationShip,
			Occupation=UG.Occupation,
			Age=UG.Age,
			PrimaryGuardian=UG.PrimaryGuardian,
			AnnualIncome=UG.AnnualIncome,
			IsSameAsUserAddress=UG.IsSameAsUserAddress,
			MobileNumber=UG.MobileNumber,
			OfficeNumber=UG.OfficeNumber,
			IsDeleted=UG.IsDeleted
		FROM dbo.UserGuardians	INNER JOIN @UserGuardians UG ON dbo.UserGuardians.GuardianId=UG.GuardianId
		
		-- to insert
		INSERT INTO dbo.UserGuardians
			(
				UserId,
				Title,
				FirstName,
				LastName,
				Gender,
				Email,
				ReleationShip,
				Occupation,
				Age,
				PrimaryGuardian,
				AnnualIncome,
				IsSameAsUserAddress,
				MobileNumber,
				OfficeNumber,
				IsDeleted
			) 
		SELECT @UserId,
			Title=IUG.Title,
			IUG.FirstName,
			IUG.LastName,
			IUG.Gender,
			IUG.Email,
			IUG.ReleationShip,
			IUG.Occupation,
			IUG.Age,
			IUG.PrimaryGuardian,
			IUG.AnnualIncome,
			IUG.IsSameAsUserAddress,IUG.MobileNumber,IUG.OfficeNumber,IUG.IsDeleted FROM @UserGuardians IUG WHERE IUG.GuardianId=0

		
	IF(@IsPasswordInsert=1)
		BEGIN
			EXEC dbo.SaveCredentials @UserId,@SecurityKey,@Password,@GuardianPassword,@PasswordFormat,@PasswordQuestion,@PasswordAnswer
		END

	END TRY
	BEGIN CATCH 
		ROLLBACK TRANSACTION INSERTUSER
		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState)
	END CATCH
END
	
RETURN @UserId
