CREATE PROCEDURE [dbo].[SaveStudentGuardian]
	@StudentId int,
	@StudentGuardians TypeStudentGuardian Readonly
AS
	BEGIN
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
END
