CREATE PROCEDURE [dbo].[GetAllClasses]
	@VisibleOnly bit =NULL	
AS
BEGIN
	IF(@VisibleOnly IS NULL)
		BEGIN
			SELECT ClassId,ClassName,NameInDigit,IsVisibleToApplication FROM DBO.Classes
		END
	ELSE
		SELECT ClassId,ClassName,NameInDigit,IsVisibleToApplication FROM DBO.Classes WHERE IsVisibleToApplication=1
END

