CREATE PROCEDURE [dbo].[SaveApplicationRole]
	@RoleId int output,
	@RoleName varchar(50),
	@IsActive bit,
	@VisibleToLogin bit	
AS
BEGIN
	BEGIN TRY
	-- TO INSERT & UPDATE ROLES
	IF NOT EXISTS(SELECT 1 FROM dbo.ApplicationRoles WHERE RoleId=@RoleId)
		BEGIN
			INSERT INTO dbo.ApplicationRoles 
					(RoleName, IsActive,VisibleToLogin, CreatedDate, ModifiedDate) 
			VALUES 
					(@RoleName, @IsActive,@VisibleToLogin,GETDATE(),GETDATE())

				SET @RoleId=SCOPE_IDENTITY()
			END
		ELSE
			BEGIN
				UPDATE dbo.ApplicationRoles SET RoleName=@RoleName,VisibleToLogin=@VisibleToLogin, IsActive=@IsActive,ModifiedDate= GETDATE() WHERE RoleId=@RoleId				
			END
		
	END TRY
	BEGIN CATCH		
		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR (@ErrorMessage, @ErrorSeverity,@ErrorState) 
	END CATCH

	RETURN @RoleId
END

