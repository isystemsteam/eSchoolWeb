CREATE TABLE [dbo].[Address]
(
	[AddressId] INT NOT NULL PRIMARY KEY identity,
	DoorNo varchar(10) NOT NULL,
	AddressLine1 varchar(120),
	AddressLine2 varchar(120) NOT NULL,
	Taluk varchar(120),
	District varchar(120),
	PinCode varchar(6), 
    [CreatedDate] DATETIME NULL, 
    [ModifiedDate] DATETIME NULL
)
