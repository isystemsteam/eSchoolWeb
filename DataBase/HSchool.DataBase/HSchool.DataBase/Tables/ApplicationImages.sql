CREATE TABLE [dbo].[ApplicationImages]
(
	[ImageId] INT NOT NULL PRIMARY KEY identity,
	[ImageName] varchar(120),
	ImageContent varbinary(max),
	ImageLength int,
	ImageFormet varchar(20)
)
