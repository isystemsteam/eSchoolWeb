CREATE TABLE [dbo].[ClassSubject]
(
	[ClassSubjectId] INT NOT NULL PRIMARY KEY identity,
	[ClassId] int foreign key references dbo.Classes(ClassId) NOT NULL,
	[SectionId] int null,
	[SubjectId] NVARCHAR(255),
	[AcademicYear] int foreign key references dbo.AcademicYears(AcademicYearId) NOT NULL,
	[CreatedDate] datetime NOT NULL
)
