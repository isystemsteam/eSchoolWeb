CREATE TABLE [dbo].[StudentImage]
(
	[StudentImageId] INT NOT NULL PRIMARY KEY identity,
	[StudentId] int not null foreign key references dbo.Student(StudentId),
	[ImageId] int not null foreign key references dbo.ApplicationImages(ImageId),
)
