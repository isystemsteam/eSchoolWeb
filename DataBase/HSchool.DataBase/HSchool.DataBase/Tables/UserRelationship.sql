CREATE TABLE [dbo].[UserRelationship]
(
	RelationshipId INT NOT NULL PRIMARY KEY identity,
	Name varchar(120),
	IsActive bit
)
