CREATE PROCEDURE [dbo].[SaveApplication]
(		
	@ApplicationId int,
	@ApplicationStatus int,
	@AppliedDate datetime,
	@ApprovedDate datetime,
	@ApplicationType int,
	@ApprovedBy int,

	@UserId int,
	@RollNumber varchar(20),
	@Title varchar(6),
	@FirstName varchar(120),
	@LastName varchar(120),
	@UserName varchar(120),
	@Email varchar(255),
	@Gender varchar(10),
	@Age int,
	@DateOfBirth datetime,
	@PlaceOfBirth varchar(120),
	@BloodGroup varchar(10),
	@Religion varchar(50),
	@Nationality varchar(50),
	@Community int,
	@MobileNumber varchar(15),
	@UserStatus int,
	@MotherLanguage int,
	@IsVerified bit,
	@IsLocked bit,
	@SMSEnabled bit,
	@EmailEnabled bit,
	@NotificationEnabled bit,
	@UserImage varbinary(max),
	@UserRole int,
	@FluencyinOthers varchar(120),
	@IsTransportRequired bit,
	@StudentId int,	
	@VisibleMark bit,
	@LoginEnabled bit,
	@StudentClass TypeStudentClass Readonly,
	@StudentGuardians TypeStudentGuardian Readonly,
	@Addresses TypeAddress Readonly,
	@IsStudentUpdate bit
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION H_APPLICATION
		-- SAVE STUDENT INFORMATION
		IF(@IsStudentUpdate=1)
			BEGIN
				
				DECLARE @AddressId int;
				DECLARE @DoorNo varchar(10);
				DECLARE @AddressLine1 VARCHAR(120);
				DECLARE @AddressLine2 VARCHAR(120);
				DECLARE @Taluk VARCHAR(120);
				DECLARE @District VARCHAR(120);
				DECLARE @PinCode VARCHAR(6);
				DECLARE @StudentClassId INT;				
				DECLARE @ClassId INT;
				DECLARE @SectionId INT;
				DECLARE @AcademicYear INT;
				DECLARE @IsActive INT;

				-- SAVE USER
				EXEC @UserId=DBO.SaveUserInformation @UserId,@Title,@FirstName,@LastName,@Email,@Gender,@DateOfBirth,@PlaceOfBirth,@BloodGroup,@Religion,@Nationality,@Community,@MobileNumber,@UserStatus,@MotherLanguage,@IsVerified,@IsLocked,@SMSEnabled,@EmailEnabled,@NotificationEnabled

				-- SAVE STUDENT
				EXEC @StudentId= dbo.SaveStudent @StudentId,@UserId,@RollNumber,@FluencyinOthers,@IsTransportRequired,@LoginEnabled,@VisibleMark

				-- SAVE STUDENT GUARDIAN
				EXEC SaveStudentGuardian @StudentId,@StudentGuardians

				-- SAVE CLASS
				SELECT TOP 1 @StudentClassId=StudentClassId,@ClassId=ClassId,@SectionId=SectionId,@IsActive=IsActive,@AcademicYear=AcademicYear FROM @StudentClass
			
				EXEC SaveStudentClass @StudentClassId,@StudentId,@ClassId,@SectionId,@AcademicYear,@IsActive
			
				-- SAVE ADDRESS			
				SELECT TOP 1  @AddressId=AddressId,
					@DoorNo=UA.DoorNo,
					@AddressLine1=UA.AddressLine1,
					@AddressLine2=UA.AddressLine2,
					@Taluk=UA.Taluk,
					@District=UA.District,
					@PinCode=UA.Pincode
				FROM @Addresses UA

				EXEC @AddressId=DBO.SaveAddress @AddressId,@DoorNo,@AddressLine1,@AddressLine2,@Taluk,@District,@PinCode

				--SAVE USER ADDRESS
				IF NOT EXISTS (SELECT 1 FROM dbo.UserAddress where UserId=@UserId and AddressId=@AddressId)
					BEGIN
						INSERT INTO dbo.UserAddress (UserId,AddressId) values (@UserId,@AddressId)
					END

			END		

		-- SAVE APPLICATIONS
		IF EXISTS(SELECT 1 FROM dbo.Applications where ApplicationId=@ApplicationId)
			BEGIN
				UPDATE dbo.Applications SET 
					ApplicationStatus=@ApplicationStatus,ApplicationType=@ApplicationType,ApprovedBy=@ApprovedBy,ApprovedDate=@ApprovedDate,ModifiedDate=GETDATE() 
				WHERE ApplicationId=@ApplicationId
			END
		ELSE
			BEGIN
				INSERT INTO dbo.Applications 
					(
						UserId,
						ApplicationStatus,
						AppliedDate,
						ApprovedDate,
						ApplicationType,
						ApprovedBy,
						CreatedDate
					) 
					VALUES
					(
						@UserId,
						@ApplicationStatus,
						GETDATE(),
						@ApprovedDate,
						@ApplicationType,
						@ApprovedBy,
						GETDATE()
					)
			END
			COMMIT TRANSACTION H_APPLICATION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION H_APPLICATION
			DECLARE @ErrorMessage NVARCHAR(4000);
			DECLARE @ErrorSeverity INT;
			DECLARE @ErrorState INT;

			SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
			RAISERROR (@ErrorMessage, @ErrorSeverity,@ErrorState) 
		END CATCH
END

