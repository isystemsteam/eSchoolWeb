CREATE PROCEDURE [dbo].[GetMotherLanguages]	
AS
	SELECT LanguageId,Name FROM DBO.MotherLanguages
RETURN 0
