CREATE TABLE [dbo].[UserAddress]
(
	[UserAddressId] INT NOT NULL PRIMARY KEY identity, 
    [AddressId] INT NULL foreign key references dbo.[Address](AddressId), 
    [UserId] INT NULL foreign key references dbo.[UserAccounts](UserId)
)
