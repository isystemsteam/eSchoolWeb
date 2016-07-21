CREATE PROCEDURE [dbo].[GetCommunities]	
AS
	BEGIN
		SELECT CommunityId,CommunityName from dbo.CommunityMaster
	END

