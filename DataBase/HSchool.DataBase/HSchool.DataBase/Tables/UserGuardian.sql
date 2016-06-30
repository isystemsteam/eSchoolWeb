CREATE TABLE [dbo].[UserGuardians]
(
	GuardianId INT NOT NULL PRIMARY KEY identity,
	UserId int foreign key references dbo.UserAccounts (UserId),
	Title varchar(12),
	FirstName varchar(120),
	LastName varchar(120),
	Gender varchar(15),
	Email varchar(255),
	ReleationShip int foreign key references dbo.UserRelationship (RelationshipId),
	Occupation varchar(255),
	Age int,
	PrimaryGuardian bit,
	AnnualIncome varchar(120),
	IsSameAsUserAddress bit,
	MobileNumber varchar(20),
	OfficeNumber varchar(20),
	IsVerified bit,
	IsDeleted bit,
	CreatedDate datetime,
	ModifiedDate datetime
)
