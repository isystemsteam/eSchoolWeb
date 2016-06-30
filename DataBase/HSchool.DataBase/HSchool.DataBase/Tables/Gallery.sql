CREATE TABLE [dbo].[Gallery]
(
	[GalleryId] INT NOT NULL PRIMARY KEY identity,
	[GroupName] varchar(80),
	ImageId int foreign key references dbo.ApplicationImages (ImageId),
	ImageOrder int,
	IsDisplay bit
)
