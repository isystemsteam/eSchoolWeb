CREATE TYPE dbo.TypeAddress AS Table
(
	AddressId int,
	DoorNo varchar(10),
	AddressLine1 varchar(120),
	AddressLine2 varchar(120),
	Taluk varchar(120),
	District varchar(120),
	PinCode varchar(6)
)