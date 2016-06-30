CREATE PROCEDURE [dbo].[GetAllClassSections]
(
	@CLASSID int=null,
	@ALL BIT=NULL
)	
AS
BEGIN
	IF(@CLASSID!=0)
		BEGIN
			SELECT CS.ClassSectionId,CS.ClassId,CS.SectionId,CS.IsActive,CS.IsDeleted, C.ClassName AS ClassName,S.SectionName AS SectionName FROM DBO.ClassSections CS 
				LEFT OUTER JOIN DBO.Classes C ON C.ClassId=CS.ClassId
				LEFT OUTER JOIN DBO.Sections S ON S.SectionId=CS.SectionId
			  WHERE CS.ClassId=@CLASSID
		END
	IF(@ALL=1)
		BEGIN
			SELECT CS.ClassSectionId,CS.ClassId,CS.SectionId,CS.IsActive,CS.IsDeleted, C.ClassName AS ClassName,S.SectionName AS SectionName FROM DBO.ClassSections CS 
				LEFT OUTER JOIN DBO.Classes C ON C.ClassId=CS.ClassId
				LEFT OUTER JOIN DBO.Sections S ON S.SectionId=CS.SectionId	
		END
	ELSE
		BEGIN
			SELECT CS.ClassSectionId,CS.ClassId,CS.SectionId,CS.IsActive,CS.IsDeleted, C.ClassName AS ClassName,S.SectionName AS SectionName FROM DBO.ClassSections CS 
				LEFT OUTER JOIN DBO.Classes C ON C.ClassId=CS.ClassId
				LEFT OUTER JOIN DBO.Sections S ON S.SectionId=CS.SectionId
			WHERE CS.IsDeleted=0		
		END
	
END
