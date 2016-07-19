CREATE PROCEDURE [dbo].[SaveApplication]
(		
	@ApplicationId int,
	@ApplicationStatus int,
	@AppliedDate datetime,
	@ApprovedDate datetime,
	@ApplicationType int,
	@ApprovedBy int,

	@UserId int,
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
	@StudentClass TypeStudentClass Readonly,
	@StudentGuardians TypeStudentGuardian Readonly,
	@IsStudentUpdate bit
)
AS
BEGIN
	BEGIN TRY
		
		IF(@IsStudentUpdate=1)
			BEGIN
				EXEC @UserId= dbo.SaveStudentInformation @UserId,@Title,@FirstName, @LastName,@UserName,@Email,@Gender,@DateOfBirth,@PlaceOfBirth,@BloodGroup,@Religion,@Nationality,@Community,	@MobileNumber,@UserStatus,@MotherLanguage,@IsVerified,@IsLocked,@SMSEnabled,@EmailEnabled,@NotificationEnabled,	@UserImage,@UserRole,@FluencyinOthers,@IsTransportRequired,@StudentId,@VisibleMark,@StudentClass,@StudentGuardians
			END	

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
						@AppliedDate,
						@ApprovedDate,
						@ApplicationType,
						@ApprovedBy,
						GETDATE()
					)
			END
		END TRY
		BEGIN CATCH
			DECLARE @ErrorMessage NVARCHAR(4000);
			DECLARE @ErrorSeverity INT;
			DECLARE @ErrorState INT;

			SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
			RAISERROR (@ErrorMessage, @ErrorSeverity,@ErrorState) 
		END CATCH
END

