CREATE PROCEDURE [dbo].[SaveStudent]
(
	@StudentId int,
	@UserId int = 0,
	@RollNumber int,
	@FluencyinOthers varchar(120),
	@IsTransportRequired bit,
	@LoginEnabled bit,
	@VisibleMark bit
)
AS
BEGIN
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

		--SELECT @StudentId
END
RETURN @StudentId
