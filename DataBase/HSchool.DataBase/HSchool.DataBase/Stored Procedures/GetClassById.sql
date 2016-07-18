CREATE PROCEDURE [dbo].[GetClassById]
	@id int = 0	
AS
BEGIN
	SELECT ClassId,ClassName,NameInDigit,IsVisibleToApplication FROM DBO.Classes WHERE ClassId=@ID;
END

