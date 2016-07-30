CREATE PROCEDURE [dbo].[GetApplicationById]
(
	@ApplicationId int
)
AS
BEGIN
	
	--SELECT APPLICATION
	SELECT 
		AP.ApplicationId,
		AP.ApplicationStatus,
		AP.ApplicationType,
		AP.AppliedDate,
		AP.ApprovedBy,
		AP.ApprovedDate,
		AP.IsVerified,
		AP.CreatedDate,
		AP.ReasonMessage,
		S.FluencyinOthers,
		S.IsTransportRequired,
		S.LoginEnabled,
		S.GuardianLoginEnabled,
		S.RollNumber,
		S.StudentId,
		S.VisibleMark,
		UA.BloodGroup,
		UA.Community,
		CM.CommunityName,
		UA.CreatedDate,
		UA.DateOfBirth,
		UA.Email,
		UA.EmailEnabled,
		UA.FirstName,
		UA.Gender,
		UA.IsLocked,
		UA.IsVerified,
		UA.LastName,
		UA.MobileNumber,
		UA.ModifiedDate,
		UA.MotherLanguage,
		ML.Name AS MotherLanguagetDisplay,
		UA.Nationality,
		UA.NotificationEnabled,
		UA.PlaceOfBirth,
		UA.Religion,
		UA.UserId,
		UA.UserLastLogin,
		UA.UserName,
		UA.UserRole,
		UA.UserStatus,
		UA.Title		
			FROM dbo.Applications AP 
				JOIN dbo.Student S ON S.UserId=AP.UserId
				JOIN dbo.UserAccounts UA ON UA.UserId=AP.UserId
				JOIN DBO.MotherLanguages ML ON UA.MotherLanguage=ML.LanguageId 
				JOIN DBO.CommunityMaster CM ON CM.CommunityId=UA.Community				
		WHERE ApplicationId=@ApplicationId

	-- SELECT STUDENT CLASS INFO
	SELECT 
		SC.AcademicYear,
		AY.EndDate,
		AY.StartDate,
		SC.ClassId,
		C.ClassName,
		SC.IsActive,
		SC.SectionId,
		SC.StudentClassId,
		SC.StudentId 
			FROM dbo.StudentClass SC
			JOIN dbo.Classes C ON C.ClassId=SC.ClassId 
			JOIN dbo.AcademicYears AY ON AY.AcademicYearId=SC.AcademicYear
			JOIN dbo.Student S ON S.StudentId=SC.StudentId
			JOIN dbo.Applications AP ON AP.UserId=S.UserId			
		WHERE AP.ApplicationId=@ApplicationId

	-- SELECT STUDENT GUARDIAN
	SELECT 
		SG.AnnualIncome,
		SG.CreatedDate,
		SG.DateOfBirth,
		SG.Email,
		SG.FirstName,
		SG.Gender,
		SG.GuardianId,
		SG.HighestQualification,
		SG.IsDeleted,
		SG.IsVerified,
		SG.LastName,
		SG.MobileNumber,
		SG.IsSameAsUserAddress,
		SG.ModifiedDate,
		SG.NotificationEnabled,
		SG.Occupation,
		SG.OfficeNumber,
		SG.PrimaryGuardian,
		SG.ReleationShip,
		UR.Name AS ReleationShipName,
		SG.SMSEnabled,
		SG.StudentId,
		SG.Title
			 FROM dbo.StudentGuardians SG
				JOIN dbo.Student S ON S.StudentId=SG.StudentId
				JOIN dbo.Applications AP ON AP.UserId=S.UserId
				JOIN DBO.UserRelationship UR ON UR.RelationshipId =SG.ReleationShip
		WHERE AP.ApplicationId=@ApplicationId

		-- ADDRESS
		SELECT AD.DoorNo,AD.AddressLine1,AD.AddressId,AD.AddressLine2,AD.CreatedDate,AD.District,AD.Taluk,AD.Taluk
			 FROM DBO.[UserAddress] UA 
			JOIN DBO.[Address] AD ON AD.AddressId=UA.AddressId
			JOIN DBO.Applications AP ON AP.UserId=UA.UserId
				WHERE AP.ApplicationId=@ApplicationId
END

