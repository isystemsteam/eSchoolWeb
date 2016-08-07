CREATE PROCEDURE [dbo].[SaveInternalUser]
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
	@NotificationEnabled bit,
	@CommunityInDetails	varchar(255),
	@LoginEnabled bit,
	@UserRole int,
	@ProofType int,
	@ProofNumber nvarchar(25),
	@Addresses TypeAddress Readonly
)
AS
	BEGIN

				DECLARE @AddressId int;
				DECLARE @DoorNo varchar(10);
				DECLARE @AddressLine1 VARCHAR(120);
				DECLARE @AddressLine2 VARCHAR(120);
				DECLARE @Taluk VARCHAR(120);
				DECLARE @District VARCHAR(120);
				DECLARE @PinCode VARCHAR(6);

				EXEC @UserId=[SaveUserInformation] @UserId,@Title,@FirstName,@LastName,@Email,@Gender,@DateOfBirth,@PlaceOfBirth,@BloodGroup,@Religion,@Nationality,@Community,@MobileNumber,@UserStatus,@MotherLanguage,@IsLocked,@IsVerified,@SMSEnabled,@EmailEnabled,@NotificationEnabled,@CommunityInDetails,@LoginEnabled

				--SAVE USER ADDRESS
				SELECT TOP 1  @AddressId=AddressId,
					@DoorNo=UA.DoorNo,
					@AddressLine1=UA.AddressLine1,
					@AddressLine2=UA.AddressLine2,
					@Taluk=UA.Taluk,
					@District=UA.District,
					@PinCode=UA.Pincode
				FROM @Addresses UA

				EXEC @AddressId=DBO.SaveAddress @AddressId,@DoorNo,@AddressLine1,@AddressLine2,@Taluk,@District,@PinCode
				
				IF NOT EXISTS (SELECT 1 FROM dbo.UserAddress where UserId=@UserId and AddressId=@AddressId)
					BEGIN
						INSERT INTO dbo.UserAddress (UserId,AddressId) values (@UserId,@AddressId)
					END
	END

