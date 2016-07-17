/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
SET IDENTITY_INSERT dbo.MotherLanguages ON
insert into dbo.MotherLanguages (Name) values ('Tamil');
insert into dbo.MotherLanguages (Name) values ('English');
insert into dbo.MotherLanguages (Name) values ('Hindhi');
SET IDENTITY_INSERT dbo.MotherLanguages OFF

