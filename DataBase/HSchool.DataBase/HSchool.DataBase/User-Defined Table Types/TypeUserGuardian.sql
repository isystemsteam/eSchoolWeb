CREATE TYPE [dbo].[TypeUserGuardian] AS TABLE
(
	GuardianId INT NOT NULL PRIMARY KEY identity,
	UserId int,
	Title varchar(12),
	FirstName varchar(120),
	LastName varchar(120),
	Gender varchar(15),
	Email varchar(255),
	ReleationShip int,
	Occupation varchar(255),
	Age int,
	PrimaryGuardian bit,
	AnnualIncome varchar(120),
	IsSameAsUserAddress bit,
	MobileNumber varchar(20),
	OfficeNumber varchar(20),
	IsDeleted bit	
)
