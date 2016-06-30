CREATE PROCEDURE [dbo].[GetAllClasses]
	@VisibleOnly bit =NULL	
AS
BEGIN
	IF(@VisibleOnly IS NOT NULL)
		BEGIN
			SELECT ClassId,ClassName,IsVisibleToApplication FROM DBO.Classes
		END
	ELSE
		SELECT ClassId,ClassName,IsVisibleToApplication FROM DBO.Classes WHERE IsVisibleToApplication=1
END

