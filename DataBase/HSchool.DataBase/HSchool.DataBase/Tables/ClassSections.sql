CREATE TABLE [dbo].[ClassSections]
(
	ClassSectionId int primary key identity,
	[ClassId] INT foreign key references dbo.Classes (ClassId),
	[SectionId] int foreign key references dbo.Sections (SectionId),
	IsActive bit,
	IsDeleted bit
)
