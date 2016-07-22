CREATE PROCEDURE [dbo].[SearchApplicationS] --0,10,null,null,null,null,null,null,null,null
(
	@StartRow int,
	@EndRow int,
	@SortOn varchar(100),
	@SortOrder varchar(5),
	@ApplicationId int,
	@AppliedDate datetime,
	@FirstName varchar(120),
	@ClassId int,
	@AcademicYear int,
	@ApplicationStatus int
)
AS
BEGIN
	BEGIN TRY
		DECLARE @querystring NVARCHAR(MAX);
		SET @querystring=N'select  COUNT(1) OVER () TotalRows, ROW_NUMBER() OVER (ORDER BY AP.CreatedDate  DESC) as RowNum, 
				AP.ApplicationId,
				AP.UserId,
				AT.ApplicationStatus,
				AP.AppliedDate,
				AP.ApprovedDate,
				AP.ApprovedBy,
				AP.IsVerified,
				UA.FirstName,
				UA.LastName,
				CL.ClassName,
				AP.CreatedDate	
			into #TempApplications 
				FROM dbo.Applications AP 
				JOIN dbo.UserAccounts UA ON UA.UserId=AP.UserId  
				JOIN dbo.Student ST ON ST.UserId = AP.UserId 
				JOIN dbo.StudentClass SC ON ST.StudentId=SC.StudentId 
				JOIN dbo.Classes CL ON CL.ClassId=SC.ClassId 
				JOIN dbo.ApplicationStatus AT ON AT.ApplicationStatusId=AP.ApplicationStatus 

			WHERE AP.CreatedDate IS NOT NULL'
		
		-- APPLICATION ID
			IF (@ApplicationId IS NOT NULL OR @ApplicationId !=0)
				BEGIN
					set @querystring=@querystring+' and AP.ApplicationId = '+CAST(@ApplicationId AS NVARCHAR(10))
				END

			IF (@ClassId IS NOT NULL OR @ClassId !=0)
				BEGIN
					set @querystring=@querystring+' and CL.ClassId = '+CAST(@ClassId AS NVARCHAR(10))
				END

			IF (@ApplicationStatus IS NOT NULL OR @ApplicationStatus !=0)
				BEGIN
					set @querystring=@querystring+' and AP.ApplicationStatus = '+CAST(@ApplicationStatus AS NVARCHAR(10))
				END

		set @querystring+='; select * from #TempApplications  where RowNum > '+str(@StartRow)+' AND RowNum <='+str(@EndRow)+' order by CreatedDate DESC; delete #TempApplications ';
		print @querystring
		EXECUTE sp_executesql @querystring
	END TRY
	BEGIN CATCH
		SELECT ERROR_NUMBER() AS ErrorNumber ,ERROR_SEVERITY() AS ErrorSeverity
			,ERROR_STATE() AS ErrorState
			,ERROR_PROCEDURE() AS ErrorProcedure
			,ERROR_LINE() AS ErrorLine
			,ERROR_MESSAGE() AS ErrorMessage;
	END CATCH
END

