CREATE PROCEDURE [dbo].[GetApplications]
(
	@AppliedDate datetime,
	@ApprovedDate datetime
)
AS
	BEGIN
		DECLARE @SQLString nvarchar(MAX);

		SET @SQLString=N'SELECT ApplicationId,UserId,ApplicationStatus,AppliedDate,ApprovedDate,ApplicationType,ApprovedBy,CreatedDate,ModifiedDate WHERE IsDeleted=0 '
		IF(@AppliedDate IS NOT NULL)
			BEGIN
				SET @SQLString=@SQLString+'and AppliedDate = CONVERT(DATE,''' +CONVERT(VARCHAR(20),@AppliedDate, 20) + ''')'
			END

		IF(@ApprovedDate IS NOT NULL)
			BEGIN
				SET @SQLString=@SQLString+'and ApprovedDate = CONVERT(DATE,''' +CONVERT(VARCHAR(20),@ApprovedDate, 20) + ''')'
			END

		EXECUTE sp_executesql @SQLString	
	END	

