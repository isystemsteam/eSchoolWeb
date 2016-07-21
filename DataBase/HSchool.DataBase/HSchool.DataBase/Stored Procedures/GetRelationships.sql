CREATE PROCEDURE [dbo].[GetRelationships]	
AS
	BEGIN
		SELECT RelationshipId,Name FROM dbo.UserRelationship where IsActive=1
	END

