CREATE PROCEDURE [dbo].[GetClassSectionById]
	@ClassSectionId int = 0
AS
BEGIN
	SELECT CS.ClassSectionId,CS.ClassId,CS.SectionId,CS.IsActive,CS.IsDeleted, C.ClassName AS ClassName,S.SectionName AS SectionName FROM DBO.ClassSections CS 
				LEFT OUTER JOIN DBO.Classes C ON C.ClassId=CS.ClassId
				LEFT OUTER JOIN DBO.Sections S ON S.SectionId=CS.SectionId
			  WHERE CS.ClassSectionId=@ClassSectionId
END
