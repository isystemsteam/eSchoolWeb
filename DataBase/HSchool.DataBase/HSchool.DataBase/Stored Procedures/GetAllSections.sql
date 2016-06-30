CREATE PROCEDURE [dbo].[GetAllSections]	
AS
BEGIN
	SELECT SectionId,SectionName FROM DBO.Sections
END

