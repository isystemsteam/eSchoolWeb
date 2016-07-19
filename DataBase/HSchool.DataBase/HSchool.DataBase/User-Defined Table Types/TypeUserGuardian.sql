CREATE TYPE [dbo].[TypeStudentGuardian] AS TABLE
(
	GuardianId INT,
	StudentId int,
	UserId int,
	Title varchar(12),
	FirstName varchar(120),
	LastName varchar(120),
	ReleationShip int,
	Occupation varchar(255),
	Gender varchar(15),
	Email varchar(255),	
	DateOfBirth datetime,
	PrimaryGuardian bit,
	AnnualIncome varchar(120),
	HighestQualification varchar(50),
	IsSameAsUserAddress bit,
	MobileNumber varchar(20),
	OfficeNumber varchar(20),
	SMSEnabled bit,
	NotificationEnabled bit,
	IsDeleted bit,
	RowNumber int	
)
