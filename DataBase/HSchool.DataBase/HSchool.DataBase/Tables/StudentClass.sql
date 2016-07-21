CREATE TABLE [dbo].[StudentClass]
(
	[StudentClassId] INT NOT NULL PRIMARY KEY identity,
	StudentId int not null foreign key references dbo.Student (StudentId),
	ClassId int not null foreign key references dbo.Classes (ClassId),
	SectionId int null,
	AcademicYear int not null foreign key references dbo.AcademicYears (AcademicYearId),
	IsActive bit
)
