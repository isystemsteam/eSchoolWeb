CREATE PROCEDURE [dbo].[GetApplicationStatus]
(
	@ApplicationId int,
	@dateofbirth datetime
)
AS
BEGIN
	SELECT ApplicationStatus FROM dbo.Applications AP 
		JOIN dbo.UserAccounts UA ON UA.UserId=AP.UserId		
			 WHERE AP.ApplicationId=@ApplicationId AND UA.DateOfBirth=@dateofbirth
END

