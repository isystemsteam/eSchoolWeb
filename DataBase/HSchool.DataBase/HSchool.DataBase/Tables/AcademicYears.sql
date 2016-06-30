CREATE TABLE [dbo].[AcademicYears]
(
	[AcademicYearId] INT NOT NULL PRIMARY KEY identity,
	StartDate datetime not null,
	EndDate datetime not null,
	IsActive bit not null
)
