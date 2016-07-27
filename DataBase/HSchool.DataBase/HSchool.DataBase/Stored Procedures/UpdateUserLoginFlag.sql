CREATE PROCEDURE [dbo].[UpdateUserLoginFlag]
(
	@UserId int,
	@LoginEnabled bit	
)
AS
BEGIN
	UPDATE dbo.UserAccounts SET LoginEnabled=@LoginEnabled WHERE UserId=@UserId
END

