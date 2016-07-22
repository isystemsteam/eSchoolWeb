CREATE PROCEDURE [dbo].[SaveAddress]
	@AddressId int = 0,
	@DoorNo int,
	@AddressLine1 varchar(120),
	@AddressLine2 varchar(120),
	@Taluk varchar(120),
	@District varchar(120),
	@PinCode varchar(6)
AS
BEGIN
	IF EXISTS(SELECT 1 FROM dbo.[Address] WHERE AddressId=@AddressId)
		BEGIN
			UPDATE dbo.[Address] SET DoorNo=@DoorNo,AddressLine1=@AddressLine1,AddressLine2=@AddressLine2,PinCode=@PinCode,ModifiedDate=GETDATE() WHERE AddressId=@AddressId
		END
	ELSE
		BEGIN
			INSERT INTO dbo.[Address] 
				(DoorNo,AddressLine1,AddressLine2,Taluk,District,PinCode,CreatedDate,ModifiedDate) 
					VALUES 
				(@DoorNo,@AddressLine1,@AddressLine2,@Taluk,@District,@PinCode,GETDATE(),GETDATE())

			SET @AddressId=@@IDENTITY
		END
	RETURN @AddressId
END	

