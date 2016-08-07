CREATE PROCEDURE [dbo].[UpdateUserRole]
(
	@UserId int,
	@UserRole int
)
AS
	BEGIN
		UPDATE dbo.UserAccounts SET UserRole=@UserRole WHERE UserId=@UserId
	END

