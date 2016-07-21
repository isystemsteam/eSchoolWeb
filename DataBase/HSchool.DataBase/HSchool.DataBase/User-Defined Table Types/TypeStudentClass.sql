CREATE TYPE dbo.TypeStudentClass AS TABLE
(
	StudentClassId int,
	StudentId int,
	ClassId int,
	SectionId int,
	AcademicYear int,
	IsActive bit	
)