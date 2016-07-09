CREATE TABLE [dbo].[StudentGuardianImage]
(
	[StudentGuardianImageId] INT NOT NULL PRIMARY KEY identity,
	[GuardianId] int foreign key references dbo.StudentGuardians(GuardianId) NOT NULL, 
    [ImageId] INT NOT NULL foreign key references dbo.ApplicationImages(ImageId)
)
