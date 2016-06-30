CREATE PROCEDURE [dbo].[GetClassById]
	@id int = 0	
AS
BEGIN
	SELECT ClassId,ClassName,IsVisibleToApplication FROM DBO.Classes WHERE ClassId=@ID;
END

