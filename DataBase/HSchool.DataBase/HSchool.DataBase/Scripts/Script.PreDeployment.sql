/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
GO
IF (SELECT COUNT(*) FROM SYS.SYMMETRIC_KEYS WHERE NAME LIKE '%DatabaseMasterKey%') = 0
	BEGIN
		CREATE MASTER KEY ENCRYPTION BY PASSWORD = '9042256256hschooldatabase'
	END

GO
IF (SELECT COUNT(*) FROM SYS.CERTIFICATES WHERE NAME = 'HSCHOOLCERT') = 0
	BEGIN
		CREATE CERTIFICATE HSCHOOLCERT WITH SUBJECT ='9042256256hschooldatabase'
	END

GO
IF (SELECT COUNT(*) FROM SYS.SYMMETRIC_KEYS WHERE NAME = 'HSCHOOLSYMKEY') = 0
	BEGIN
		CREATE SYMMETRIC KEY HSCHOOLSYMKEY WITH ALGORITHM =TRIPLE_DES ENCRYPTION BY CERTIFICATE	HSCHOOLCERT
	END

GO

--OPEN SYMMETRIC KEY 	HSCHOOLSYMKEY DECRYPTION BY CERTIFICATE HSCHOOLCERT

--ENCRYPTBYKEY(KEY_GUID('HSCHOOLSYMKEY'),SecondCol)
--CONVERT(VARCHAR(50),DECRYPTBYKEY(EncryptSecondCol))

GO
--CLOSE SYMMETRIC KEY HSCHOOLSYMKEY

GO
--DROP SYMMETRIC KEY HSCHOOLSYMKEY

GO
--DROP CERTIFICATE HSCHOOLCERT

GO
--DROP MASTER KEY
GO 

/*
DECLARE @TESTVALUE VARBINARY(256)

OPEN SYMMETRIC KEY 	HSCHOOLSYMKEY DECRYPTION BY CERTIFICATE HSCHOOLCERT

SET @TESTVALUE=ENCRYPTBYKEY(KEY_GUID('HSCHOOLSYMKEY'),'Enter321')
SELECT @TESTVALUE

SELECT CONVERT(VARCHAR(50),DECRYPTBYKEY(@TESTVALUE))

CLOSE SYMMETRIC KEY HSCHOOLSYMKEY
*/

--http://blog.sqlauthority.com/2009/04/28/sql-server-introduction-to-sql-server-encryption-and-symmetric-key-encryption-tutorial-with-script/
