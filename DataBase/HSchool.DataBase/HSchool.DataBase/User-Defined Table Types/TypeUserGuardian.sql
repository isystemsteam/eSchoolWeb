﻿CREATE TYPE [dbo].[TypeStudentGuardian] AS TABLE
(
	GuardianId INT,
	StudentId int,
	UserId int,
	Title int,
	FirstName varchar(120),
	LastName varchar(120),
	ReleationShip int,
	Occupation varchar(120),
	Gender varchar(15),
	Email varchar(255),	
	DateOfBirth datetime,
	PrimaryGuardian bit,
	AnnualIncome decimal(18,2),
	HighestQualification varchar(50),
	IsSameAsUserAddress bit,
	MobileNumber varchar(20),
	OfficeNumber varchar(20),
	SMSEnabled bit,
	NotificationEnabled bit,
	IsDeleted bit,
	RowNumber int	
)
