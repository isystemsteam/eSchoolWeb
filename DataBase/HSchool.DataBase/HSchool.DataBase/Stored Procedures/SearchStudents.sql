ALTER PROCEDURE [dbo].[SearchStudents] --0,10,null,null,'P',null,null,null,null,null,null,null
(
	@StartRow int,
	@EndRow int,
	@SortOn varchar(100),
	@SortOrder varchar(5),
	@FirstName varchar(120),
	@LastName varchar(120),
	@RollNumber varchar(120),
	@ClassId int,
	@AcademicYear int,
	@SectionId int,
	@Gender varchar(10),
	@DateOfBirth datetime
)
AS
BEGIN
	BEGIN TRY
		DECLARE @querystring NVARCHAR(MAX);
		SET @querystring=N'select COUNT(1) OVER () TotalRows, ROW_NUMBER() OVER (ORDER BY UA.CreatedDate  DESC) as RowNum, 				
				UA.UserId,
				UA.FirstName,
				UA.LastName,
				UA.UserName,
				UA.DateOfBirth,
				UA.BloodGroup,
				UA.Gender,
				ST.StudentId,
				ST.IsTransportRequired,
				ST.LoginEnabled,
				SC.ClassId,
				CL.ClassName,				
				UA.CreatedDate	
			into #TempStudents 				 
				FROM dbo.UserAccounts UA 
				JOIN dbo.Student ST ON UA.UserId=ST.UserId
				JOIN dbo.StudentClass SC ON ST.StudentId=SC.StudentId 
				JOIN dbo.Classes CL ON CL.ClassId=SC.ClassId
				LEFT OUTER JOIN dbo.Sections SS ON SS.SectionId =SC.SectionId
			WHERE UA.IsDeleted IS NULL '
		
		-- APPLICATION ID
			IF (@ClassId IS NOT NULL OR @ClassId !=0)
				BEGIN
					set @querystring=@querystring+' and SC.ClassId = '+CAST(@ClassId AS NVARCHAR(10))
				END

			IF (@SectionId IS NOT NULL OR @SectionId !=0)
				BEGIN
					set @querystring=@querystring+' and SC.ClassId = '+CAST(@SectionId AS NVARCHAR(10))
				END

			IF (@AcademicYear IS NOT NULL OR @AcademicYear !=0)
				BEGIN
					set @querystring=@querystring+' and SC.AcademicYear = '+CAST(@AcademicYear AS NVARCHAR(10))
				END

			IF (@RollNumber IS NOT NULL OR @RollNumber !='')
				BEGIN
					set @querystring=@querystring+' and ST.RollNumber = '''+@RollNumber+''''
				END

			IF (@FirstName IS NOT NULL OR @FirstName !='')
				BEGIN
					set @querystring=@querystring+' and UA.FirstName like ''%'+@FirstName+'%'''
				END

			IF (@LastName IS NOT NULL OR @LastName !='')
				BEGIN
					set @querystring=@querystring+' and UA.LastName like ''%'+@LastName+'%'''
				END
			SET @querystring+=' '
			set @querystring+='; select * from #TempStudents  where RowNum > '+str(@StartRow)+' AND RowNum <='+str(@EndRow)+' order by CreatedDate DESC; delete #TempStudents ';
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

