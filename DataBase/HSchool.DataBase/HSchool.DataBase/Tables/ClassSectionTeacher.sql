CREATE TABLE [dbo].[ClassSectionTeacher]
(
	[ClassSectionTeacherId] INT NOT NULL PRIMARY KEY identity,
	[UserId] int foreign key references dbo.UserAccounts(UserId),
	[ClassId] int foreign key references dbo.Classes (ClassId),
	[SectionId] int null,
	[AcademicYearId] int foreign key references dbo.AcademicYears(AcademicYearId)
)
