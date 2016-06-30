CREATE PROCEDURE [dbo].[GetSectionById]
	@id int = 0	
AS
BEGIN
	SELECT SectionId,SectionName FROM DBO.Sections WHERE SectionId=@ID;
END

