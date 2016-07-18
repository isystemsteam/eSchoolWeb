CREATE TABLE [dbo].[AcademicYears]
(
	[AcademicYearId] INT NOT NULL PRIMARY KEY identity,
	StartDate datetime NOT null,
	EndDate datetime NOT null,
	IsActive bit not null
)
