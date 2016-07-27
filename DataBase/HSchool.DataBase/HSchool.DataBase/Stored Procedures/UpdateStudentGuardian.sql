CREATE PROCEDURE [dbo].[UpdateStudentLogin]
(
	@StudentId int,
	@LoginEnabled bit,
	@GuardianLoginEnabled bit
)
AS
BEGIN
	UPDATE dbo.Student SET LoginEnabled=@LoginEnabled, GuardianLoginEnabled=@GuardianLoginEnabled WHERE StudentId=@StudentId
END
