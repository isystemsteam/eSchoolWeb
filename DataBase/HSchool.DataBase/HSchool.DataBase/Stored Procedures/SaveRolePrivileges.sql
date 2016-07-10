CREATE PROCEDURE [dbo].[SaveRolePrivileges]
(
	@TypeRolePrivileges dbo.TypeRolePrivileges READONLY	
)
AS
BEGIN
	BEGIN  TRY

	BEGIN TRANSACTION H_ROLEPRIVILEGEINSERTUPDATE

		DECLARE @RolePrivilegeId INT;
		DECLARE @RoleId INT;
		DECLARE @ModuleId INT;
		DECLARE @Privileges NVARCHAR(50);
		DECLARE @TEMPROWNUM INT=1;
		DECLARE @TOTALROWCOUNT INT;

		--GET TOTAL COUNT
		SELECT @TOTALROWCOUNT=COUNT(1) FROM  @TypeRolePrivileges
		WHILE (@TEMPROWNUM <=@TOTALROWCOUNT)
			BEGIN
				-- GET VALUES
				SELECT @RoleId=RoleId, @ModuleId=ModuleId, @Privileges=Privileges FROM @TypeRolePrivileges WHERE RowNumber=@TEMPROWNUM

				IF NOT EXISTS(SELECT 1 FROM DBO.RolePrivileges WHERE ModuleId=@ModuleId AND RoleId=@RoleId)
					BEGIN
						INSERT INTO DBO.RolePrivileges (RoleId,ModuleId,Privileges,CreatedDate) VALUES (@RoleId,@ModuleId,@Privileges,GETDATE())
					END
				ELSE
					BEGIN
						UPDATE DBO.RolePrivileges SET Privileges=@Privileges,ModifiedDate=GETDATE() WHERE ModuleId=@ModuleId AND RoleId=@RoleId
					END
				SET @TEMPROWNUM=@TEMPROWNUM+1;
			END
	COMMIT TRANSACTION H_ROLEPRIVILEGEINSERTUPDATE
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION H_ROLEPRIVILEGEINSERTUPDATE
		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
		RAISERROR (@ErrorMessage, @ErrorSeverity,@ErrorState) 
	END CATCH
END