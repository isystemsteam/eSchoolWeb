﻿CREATE PROCEDURE [dbo].[SaveStudentInformation]
(
	@UserId int,
	@RollNumber varchar(20),
	@Title varchar(6),
	@FirstName varchar(120),
	@LastName varchar(120),
	@UserName varchar(120),
	@Email varchar(255),
	@Gender varchar(10),	
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
	@StudentGuardians TypeStudentGuardian Readonly
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION H_INSERTUPDATESTUDENT

		--EXECUTE THE SAVE USER INFORMATION
		EXEC DBO.SaveUserInformation @UserId,@Title,@FirstName,@LastName,@Email,@Gender,@DateOfBirth,@PlaceOfBirth,@BloodGroup,@Religion,@Nationality,@Community,@MobileNumber,@UserStatus,@MotherLanguage,@IsVerified,@IsLocked,@SMSEnabled,@EmailEnabled,@NotificationEnabled
		--GET THE STUDENT ID
		IF(@UserId IS NULL OR @UserId=0)
			BEGIN
				SELECT @UserId = @@IDENTITY
			END

		-- SAVE STUDENT INFORMATION
		IF (@StudentId IS NULL OR @StudentId=0)
			BEGIN
				INSERT INTO dbo.Student
					(UserId,RollNumber,FluencyinOthers,IsTransportRequired,LoginEnabled)
					VALUES
					(@UserId,@RollNumber,@FluencyinOthers,@IsTransportRequired,@LoginEnabled)

				SET @StudentId=@@IDENTITY
			END
		ELSE
			BEGIN
				UPDATE dbo.Student SET FluencyinOthers=@FluencyinOthers,IsTransportRequired=@IsTransportRequired,LoginEnabled=@LoginEnabled WHERE StudentId=@StudentId
			END
		
		-- SAVE STUDENT CLASS INFO
		
				UPDATE dbo.StudentClass 
					SET IsActive=TS.IsActive FROM dbo.StudentClass SC INNER JOIN 
						@StudentClass TS ON SC.ClassId=TS.ClassId AND SC.SectionId=TS.SectionId AND SC.AcademicYear=TS.AcademicYear
			
				INSERT INTO dbo.StudentClass 
					(
						StudentId,
						ClassId,
						SectionId,
						AcademicYear,
						IsActive
					)					
					SELECT @StudentId,TS.ClassId,TS.SectionId,TS.AcademicYear,TS.IsActive 
						FROM @StudentClass TS
							WHERE ClassId!=TS.ClassId AND SectionId!=TS.SectionId AND AcademicYear!=TS.AcademicYear
			

		--TO INSERT & UPDATE STUDENT GURDIANS INFORMATION

		--TO UPDATE
		UPDATE dbo.StudentGuardians SET 
			StudentId=@StudentId, 
			Title=UG.Title,
			FirstName=UG.FirstName,
			LastName=UG.LastName,
			Gender=UG.Gender,
			Email=UG.Email,
			ReleationShip=UG.ReleationShip,
			Occupation=UG.Occupation,
			DateOfBirth=UG.DateOfBirth,
			PrimaryGuardian=UG.PrimaryGuardian,
			AnnualIncome=UG.AnnualIncome,
			IsSameAsUserAddress=UG.IsSameAsUserAddress,
			MobileNumber=UG.MobileNumber,
			OfficeNumber=UG.OfficeNumber,
			IsDeleted=UG.IsDeleted
		FROM dbo.StudentGuardians INNER JOIN @StudentGuardians UG ON dbo.StudentGuardians.GuardianId=UG.GuardianId
		
		-- TO INSERT
		INSERT INTO dbo.StudentGuardians
			(
				StudentId,
				Title,
				FirstName,
				LastName,
				Gender,
				Email,
				ReleationShip,
				Occupation,
				DateOfBirth,
				PrimaryGuardian,
				AnnualIncome,
				IsSameAsUserAddress,
				MobileNumber,
				OfficeNumber,
				IsDeleted
			) 
		SELECT @StudentId,
			IUG.Title,
			IUG.FirstName,
			IUG.LastName,
			IUG.Gender,
			IUG.Email,
			IUG.ReleationShip,
			IUG.Occupation,
			IUG.DateOfBirth,
			IUG.PrimaryGuardian,
			IUG.AnnualIncome,
			IUG.IsSameAsUserAddress,IUG.MobileNumber,IUG.OfficeNumber,IUG.IsDeleted FROM @StudentGuardians IUG WHERE IUG.GuardianId=0

		SELECT @UserId

		COMMIT TRANSACTION H_INSERTUPDATESTUDENT
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION H_INSERTUPDATESTUDENT
		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR (@ErrorMessage, @ErrorSeverity,@ErrorState) 
	END CATCH
END
	
